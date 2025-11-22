using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PharmacyApp.UserControls
{
    public partial class UC_Receipt : UserControl
    {
        public int? EditingProductId { get; set; }
        private int _lastGeneratedNumber = 0;
        private static int _barcodeCounter = 1000000000;  // bắt đầu từ 10 số

        public UC_Receipt()
        {
            InitializeComponent();

            this.Load += UC_Receipt_Load;
            btnSave.Click += BtnSave_Click;
            btnBack.Click += BtnBack_Click;

            // mỗi lần sửa SL / Đơn giá thì tính lại tổng
            dgvReceiptList.CellEndEdit += DgvReceiptList_CellEndEdit;

            // nút Thêm dòng
            BtnAddRow.Click += BtnAddRow_Click;
        }

        // 🟢 Load nhà cung cấp
        private void LoadSuppliers()
        {
            using (var conn = new SqlConnection(Program.ConnStr))
            using (var da = new SqlDataAdapter(
                "SELECT SupplierId, SupplierName FROM Suppliers ORDER BY SupplierName", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Gợi ý autocomplete cho txtSupplier
                var ac = new AutoCompleteStringCollection();
                foreach (DataRow row in dt.Rows)
                {
                    ac.Add(row["SupplierName"].ToString());
                }

                txtSupplier.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtSupplier.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtSupplier.AutoCompleteCustomSource = ac;
            }
        }

        private string GenerateNewBarcode()
        {
            _barcodeCounter++;
            return _barcodeCounter.ToString();
        }
        private void UC_Receipt_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
            dtpDate.Value = DateTime.Today;
            _lastGeneratedNumber = GetLastProductNumberFromDB();

        }

        // Mỗi lần sửa SL / Đơn giá → tính lại Thành tiền & Tổng tiền
        private void DgvReceiptList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvReceiptList.Rows[e.RowIndex];
            if (row.IsNewRow) return;

            int qty = 0;
            decimal unitPrice = 0;

            int.TryParse(row.Cells["colQuantity"].Value == null ? null : row.Cells["colQuantity"].Value.ToString(), out qty);
            decimal.TryParse(row.Cells["colUnitPrice"].Value == null ? null : row.Cells["colUnitPrice"].Value.ToString(), out unitPrice);

            decimal total = qty * unitPrice;
            row.Cells["colLineTotal"].Value = total;

            // Tồn sau nhập = chỉ hiển thị = SL (vì bạn không dùng DB để lấy tồn thật)
            if (dgvReceiptList.Columns.Contains("colStockAfter"))
                row.Cells["colStockAfter"].Value = qty;

            RecalculateTotal();
        }

        // 🔢 Tính lại tổng tiền
        private void RecalculateTotal()
        {
            decimal sum = 0m;

            foreach (DataGridViewRow row in dgvReceiptList.Rows)
            {
                if (row.IsNewRow) continue;
                var cell = row.Cells["colLineTotal"];
                if (cell == null || cell.Value == null) continue;

                decimal value;
                if (decimal.TryParse(cell.Value.ToString(), out value))
                    sum += value;
            }

            lblTotal.Text = string.Format("Tổng tiền: {0:N0} VNĐ", sum);
        }

        // 🔐 Sinh số chứng từ tự động nếu để trống
        private string GenerateVoucherNumber()
        {
            string datePrefix = DateTime.Now.ToString("yyyyMMdd");

            using (var conn = new SqlConnection(Program.ConnStr))
            using (var cmd = new SqlCommand(@"
                SELECT TOP 1 VoucherNumber
                FROM Receipts
                WHERE VoucherNumber LIKE 'PN" + datePrefix + @"-%'
                ORDER BY VoucherNumber DESC", conn))
            {
                conn.Open();
                var result = cmd.ExecuteScalar();

                if (result == null)
                {
                    return "PN" + datePrefix + "-0001";
                }
                else
                {
                    string last = result.ToString();   // PN20251120-0003
                    string[] parts = last.Split('-');
                    int lastNumber = int.Parse(parts[1]);
                    return "PN" + datePrefix + "-" + (lastNumber + 1).ToString("D4");
                }
            }
        }

        // 🔍 Tìm ProductId theo Mã SP
        private int? FindProductIdByCode(SqlConnection conn, SqlTransaction tran, string productCode)
        {
            if (string.IsNullOrWhiteSpace(productCode)) return null;

            using (var cmd = new SqlCommand(
                "SELECT ProductId FROM Products WHERE ProductCode = @code", conn, tran))
            {
                cmd.Parameters.AddWithValue("@code", productCode.Trim());
                var obj = cmd.ExecuteScalar();
                if (obj == null || obj == DBNull.Value) return null;
                return Convert.ToInt32(obj);
            }
        }

        // 💾 NÚT LƯU PHIẾU NHẬP
        private void BtnSave_Click(object sender, EventArgs e)
        {
            // 1) Kiểm tra có dòng nào không
            bool hasRow = false;
            foreach (DataGridViewRow row in dgvReceiptList.Rows)
            {
                if (!row.IsNewRow)

                {
                    hasRow = true;
                    break;
                }
            }
            if (!hasRow)
            {
                MessageBox.Show("Chưa có sản phẩm nào trong phiếu nhập.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2) Lấy số chứng từ
            string voucherNumber = txtVoucher.Text.Trim();
            if (string.IsNullOrEmpty(voucherNumber))
            {
                voucherNumber = GenerateVoucherNumber();
                txtVoucher.Text = voucherNumber; // hiển thị luôn
            }

            // 3) Thông tin header
            // 3) Thông tin header
            DateTime receiptDate = dtpDate.Value.Date;
            string note = txtNote.Text.Trim();
            string supplierNameText = txtSupplier.Text.Trim();


            // tính tổng (lại cho chắc)
            decimal totalAmount = 0m;
            foreach (DataGridViewRow row in dgvReceiptList.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["colLineTotal"].Value == null) continue;

                decimal val;
                if (decimal.TryParse(row.Cells["colLineTotal"].Value.ToString(), out val))
                    totalAmount += val;
            }

            using (var conn = new SqlConnection(Program.ConnStr))
            {
                conn.Open();
                var tran = conn.BeginTransaction();

                try
                {
                    // 🔹 Lấy / tạo SupplierId từ txtSupplier
                 //   string supplierNameText = txtSupplier.Text.Trim();
                    int? supplierId = FindOrCreateSupplier(supplierNameText, conn, tran);

                    // 4) Insert header vào Receipts
                    int receiptId;
                    using (var cmd = new SqlCommand(@"
INSERT INTO Receipts
    (VoucherNumber, SupplierId, ReceiptDate, Note, TotalAmount)
VALUES
    (@VoucherNumber, @SupplierId, @ReceiptDate, @Note, @TotalAmount);
SELECT CAST(SCOPE_IDENTITY() AS INT);", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@VoucherNumber", voucherNumber);
                        cmd.Parameters.AddWithValue("@SupplierId",
                            (object)supplierId ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ReceiptDate", receiptDate);
                        cmd.Parameters.AddWithValue("@Note",
                            string.IsNullOrEmpty(note) ? (object)DBNull.Value : note);
                        cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);

                        receiptId = (int)cmd.ExecuteScalar();
                    }


                    // 5) Insert từng dòng chi tiết + cập nhật tồn kho
                    foreach (DataGridViewRow row in dgvReceiptList.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string productCode = row.Cells["colProductCode"].Value == null
                            ? null
                            : row.Cells["colProductCode"].Value.ToString();
                        string productName = row.Cells["colProductName"].Value == null
                            ? null
                            : row.Cells["colProductName"].Value.ToString();
                        // 🔹 Lấy barcode từ grid (hoặc rỗng)
                        string barcode = null;
                        if (dgvReceiptList.Columns.Contains("colBarcode") &&
                            row.Cells["colBarcode"].Value != null)
                        {
                            barcode = row.Cells["colBarcode"].Value.ToString();
                        }


                        // dòng trống → bỏ qua
                        if (string.IsNullOrWhiteSpace(productCode) &&
                            string.IsNullOrWhiteSpace(productName))
                            continue;

                        int qty = 0;
                        decimal unitPrice = 0m;
                        decimal lineTotal = 0m;

                        int.TryParse(row.Cells["colQuantity"].Value == null ? null : row.Cells["colQuantity"].Value.ToString(), out qty);
                        decimal.TryParse(row.Cells["colUnitPrice"].Value == null ? null : row.Cells["colUnitPrice"].Value.ToString(), out unitPrice);
                        decimal.TryParse(row.Cells["colLineTotal"].Value == null ? null : row.Cells["colLineTotal"].Value.ToString(), out lineTotal);

                        string batchNo = row.Cells["colBatchNo"].Value == null ? null : row.Cells["colBatchNo"].Value.ToString();
                        string rowNote = row.Cells["colRowNote"].Value == null ? null : row.Cells["colRowNote"].Value.ToString();

                        DateTime? expired = null;
                        if (row.Cells["colExpiredDate"].Value != null)
                        {
                            DateTime exp;
                            if (DateTime.TryParse(row.Cells["colExpiredDate"].Value.ToString(), out exp))
                            {
                                expired = exp.Date;
                            }
                        }

                        // Đơn vị tính từ grid (có thể để trống)
                        string unitFromRow = null;
                        if (dgvReceiptList.Columns.Contains("colUnit"))
                            unitFromRow = row.Cells["colUnit"].Value == null ? null : row.Cells["colUnit"].Value.ToString();

                        // Giá bán dự kiến
                        decimal? salePrice = null;
                        if (dgvReceiptList.Columns.Contains("colSalePrice") &&
                            row.Cells["colSalePrice"].Value != null)
                        {
                            decimal sp;
                            if (decimal.TryParse(row.Cells["colSalePrice"].Value.ToString(), out sp))
                                salePrice = sp;
                        }

                        // Lấy ProductId từ ProductCode (nếu sản phẩm đã tồn tại)
                        int? productId = FindProductIdByCode(conn, tran, productCode);

                        // Nếu chưa có trong Products → tự tạo sản phẩm mới + sinh mã SP
                        if (productId == null)
                        {
                            if (string.IsNullOrWhiteSpace(productName))
                            {
                                throw new Exception("Dòng nhập kho không có Mã SP và Tên thuốc, không thể tạo mới sản phẩm.");
                            }

                            // productCode có thể đang rỗng → hàm CreateNewProduct sẽ tự GenerateProductCode
                            string newCode = productCode;
                            int newId = CreateNewProduct(
                                conn,
                                tran,
                                ref newCode,    // có thể được cập nhật thành SP000xxx
                                productName,
                                barcode,
                                unitPrice,
                                salePrice,
                                supplierId,
                                expired,
                                unitFromRow);

                            productId = newId;
                            productCode = newCode;

                            // Cập nhật lại lên grid để bạn nhìn thấy mã sản phẩm vừa sinh
                            row.Cells["colProductCode"].Value = productCode;
                            row.Cells["colProductName"].Value = productName;
                        }

                        // 5.1 Insert chi tiết phiếu nhập
                        using (var cmdDet = new SqlCommand(@"
INSERT INTO ReceiptDetails
    (ReceiptId, ProductId, Quantity, UnitPrice, LineTotal, BatchNo, ExpiredDate, RowNote)
VALUES
    (@ReceiptId, @ProductId, @Quantity, @UnitPrice, @LineTotal, @BatchNo, @ExpiredDate, @RowNote);",
                            conn, tran))
                        {
                            cmdDet.Parameters.AddWithValue("@ReceiptId", receiptId);
                            cmdDet.Parameters.AddWithValue("@ProductId", productId.Value);
                            cmdDet.Parameters.AddWithValue("@Quantity", qty);
                            cmdDet.Parameters.AddWithValue("@UnitPrice", unitPrice);
                            cmdDet.Parameters.AddWithValue("@LineTotal", lineTotal);
                            cmdDet.Parameters.AddWithValue("@BatchNo",
                                string.IsNullOrWhiteSpace(batchNo) ? (object)DBNull.Value : batchNo);
                            cmdDet.Parameters.AddWithValue("@ExpiredDate",
                                expired.HasValue ? (object)expired.Value : DBNull.Value);
                            cmdDet.Parameters.AddWithValue("@RowNote",
                                string.IsNullOrWhiteSpace(rowNote) ? (object)DBNull.Value : rowNote);

                            cmdDet.ExecuteNonQuery();
                        }

                        // 5.2 Cập nhật tồn kho Products (và SalePrice, ExpiredDate, Barcode nếu có)
                        using (var cmdStock = new SqlCommand(@"
UPDATE Products
SET StockQuantity = StockQuantity + @qty,
    UnitPrice      = @price,
    SalePrice      = CASE WHEN @salePrice IS NULL THEN SalePrice ELSE @salePrice END,
    ExpiredDate    = CASE WHEN @expired   IS NULL THEN ExpiredDate ELSE @expired   END,
    Barcode        = CASE WHEN @barcode   IS NULL THEN Barcode     ELSE @barcode   END
WHERE ProductId = @pid;", conn, tran))
                        {
                            cmdStock.Parameters.AddWithValue("@qty", qty);
                            cmdStock.Parameters.AddWithValue("@price", unitPrice);
                            cmdStock.Parameters.AddWithValue("@pid", productId.Value);

                            cmdStock.Parameters.AddWithValue("@salePrice",
                                salePrice.HasValue ? (object)salePrice.Value : DBNull.Value);

                            cmdStock.Parameters.AddWithValue("@expired",
                                expired.HasValue ? (object)expired.Value : DBNull.Value);

                            cmdStock.Parameters.AddWithValue("@barcode",
                                string.IsNullOrWhiteSpace(barcode) ? (object)DBNull.Value : barcode);

                            cmdStock.ExecuteNonQuery();
                        }

                    }

                    tran.Commit();

                    MessageBox.Show("Đã lưu phiếu nhập kho.",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var f = this.FindForm();
                    if (f != null)
                    {
                        f.DialogResult = DialogResult.OK;
                        f.Close();
                    }
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi khi lưu phiếu nhập:\n" + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 🔙 Nút quay lại
        private void BtnBack_Click(object sender, EventArgs e)
        {
            var f = this.FindForm();
            if (f != null)
            {
                f.DialogResult = DialogResult.Cancel;
                f.Close();
            }
        }

        // 🔹 Sinh Mã sản phẩm tự động: SP000001, SP000002, ...
        private string GenerateProductCode(SqlConnection conn, SqlTransaction tran)
        {
            using (var cmd = new SqlCommand(@"
        SELECT TOP 1 ProductCode
        FROM Products
        WHERE ProductCode LIKE 'SP%'
        ORDER BY ProductCode DESC;", conn, tran))
            {
                var result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                {
                    return "SP000001";
                }

                string last = result.ToString();   // ví dụ: SP000123
                string numericPart = last.Length > 2 ? last.Substring(2) : "0";

                int num;
                if (!int.TryParse(numericPart, out num))
                {
                    num = 0;
                }

                return "SP" + (num + 1).ToString("D6");
            }
        }

        // 🔹 Tạo sản phẩm mới trong bảng Products nếu chưa có
        // 🔹 Tạo sản phẩm mới trong bảng Products nếu chưa có
        private int CreateNewProduct(
            SqlConnection conn,
            SqlTransaction tran,
            ref string productCode,
            string productName,
            string barcode,          // 🔹 THÊM THAM SỐ NÀY
            decimal unitPrice,
            decimal? salePrice,
            int? supplierId,
            DateTime? expired,
            string unitFromRow)
        {
            // Nếu chưa có mã SP thì tự sinh
            if (string.IsNullOrWhiteSpace(productCode))
            {
                productCode = GenerateProductCode(conn, tran);
            }

            string unitToSave = string.IsNullOrWhiteSpace(unitFromRow) ? "Hộp" : unitFromRow;

            using (var cmd = new SqlCommand(@"
INSERT INTO Products
    (ProductCode, ProductName, Barcode, Unit, UnitPrice, SalePrice,
     StockQuantity, Description, Manufacturer, ExpiredDate, SupplierId)
VALUES
    (@ProductCode, @ProductName, @Barcode, @Unit, @UnitPrice, @SalePrice,
     0, NULL, NULL, @ExpiredDate, @SupplierId);

SELECT CAST(SCOPE_IDENTITY() AS INT);", conn, tran))
            {
                cmd.Parameters.AddWithValue("@ProductCode", productCode);
                cmd.Parameters.AddWithValue("@ProductName", productName ?? "");

                // 🔹 Lưu Barcode (có thể null)
                cmd.Parameters.AddWithValue("@Barcode",
                    string.IsNullOrWhiteSpace(barcode) ? (object)DBNull.Value : barcode);

                cmd.Parameters.AddWithValue("@Unit", unitToSave);
                cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);

                // Nếu chưa nhập SalePrice → mặc định = UnitPrice * 1.2
                decimal finalSale = salePrice.HasValue
                    ? salePrice.Value
                    : Math.Round(unitPrice * 1.2m, 0);
                cmd.Parameters.AddWithValue("@SalePrice", finalSale);

                cmd.Parameters.AddWithValue("@ExpiredDate",
                    expired.HasValue ? (object)expired.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@SupplierId",
                    supplierId.HasValue ? (object)supplierId.Value : DBNull.Value);

                int newId = (int)cmd.ExecuteScalar();
                return newId;
            }
        }


        // Nút Thêm dòng: gõ tay, nhưng tự sinh mã SP
        private void BtnAddRow_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvReceiptList.Rows.Add();
            var row = dgvReceiptList.Rows[rowIndex];

            // Mã SP tự sinh
            string newCode = GenerateNewProductCodeAuto();
            row.Cells["colProductCode"].Value = newCode;

            // Barcode tự sinh từ mã SP
            if (dgvReceiptList.Columns.Contains("colBarcode"))
                row.Cells["colBarcode"].Value = GenerateBarcodeFromProductCode(newCode);

            row.Cells["colProductName"].Value = "";
            row.Cells["colQuantity"].Value = 1;
            row.Cells["colUnitPrice"].Value = 0;
            if (dgvReceiptList.Columns.Contains("colSalePrice"))
                row.Cells["colSalePrice"].Value = 0;
            row.Cells["colLineTotal"].Value = 0;

            if (dgvReceiptList.Columns.Contains("colUnit"))
                row.Cells["colUnit"].Value = "Hộp";

            dgvReceiptList.CurrentCell = row.Cells["colProductName"];
            dgvReceiptList.BeginEdit(true);
        }



        private string GenerateProductCodeForGrid()
        {
            using (var conn = new SqlConnection(Program.ConnStr))
            using (var cmd = new SqlCommand(@"
        SELECT TOP 1 ProductCode
        FROM Products
        WHERE ProductCode LIKE 'SP%'
        ORDER BY ProductCode DESC;", conn))
            {
                conn.Open();
                var result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                    return "SP000001";

                string last = result.ToString();   // vd: SP000123
                string numericPart = last.Length > 2 ? last.Substring(2) : "0";

                int num;
                if (!int.TryParse(numericPart, out num))
                    num = 0;

                return "SP" + (num + 1).ToString("D6");
            }
        }

        private void footerPanel_Paint(object sender, PaintEventArgs e)
        {
        }
        private int GetLastProductNumberFromDB()
        {
            using (var conn = new SqlConnection(Program.ConnStr))
            using (var cmd = new SqlCommand(@"
        SELECT TOP 1 ProductCode
        FROM Products
        WHERE ProductCode LIKE 'SP%'
        ORDER BY ProductCode DESC;", conn))
            {
                conn.Open();
                var result = cmd.ExecuteScalar();

                if (result == null || result == DBNull.Value)
                    return 0;

                string last = result.ToString(); // SP000123
                string numericPart = last.Substring(2);

                int num;
                if (!int.TryParse(numericPart, out num))
                    num = 0;

                return num;
            }
        }
        private string GenerateNewProductCodeAuto()
        {
            _lastGeneratedNumber++;
            return "SP" + _lastGeneratedNumber.ToString("D6");
        }
        private string GenerateBarcodeFromProductCode(string productCode)
        {
            if (string.IsNullOrEmpty(productCode) || productCode.Length <= 2)
                return null;

            // Lấy phần số phía sau "SP"
            string numericPart = productCode.Substring(2);   // vd: "000123"

            // Ví dụ: thêm prefix "893" (mã VN) + numericPart + "0"
            // Bạn có thể đổi format tuỳ ý
            string barcode = "893" + numericPart.PadLeft(6, '0') + "0";

            return barcode;
        }

        private void BtnDeleteRow_Click(object sender, EventArgs e)
        {
            if (dgvReceiptList.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn dòng cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvReceiptList.CurrentRow;

            if (row.IsNewRow)
                return;

            // Xác nhận trước khi xóa
            if (MessageBox.Show("Bạn có chắc muốn xóa dòng này?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.No)
                return;

            dgvReceiptList.Rows.Remove(row);

            // Tính lại tổng
            RecalculateTotal();
        }
        private int? FindOrCreateSupplier(string supplierName, SqlConnection conn, SqlTransaction tran)
        {
            if (string.IsNullOrWhiteSpace(supplierName))
                return null;

            // 1) Thử tìm NCC đã có
            using (var cmd = new SqlCommand(
                "SELECT SupplierId FROM Suppliers WHERE SupplierName = @name", conn, tran))
            {
                cmd.Parameters.AddWithValue("@name", supplierName.Trim());
                var obj = cmd.ExecuteScalar();
                if (obj != null && obj != DBNull.Value)
                    return Convert.ToInt32(obj);
            }

            // 2) Không có → tạo mới
            using (var cmd = new SqlCommand(
                "INSERT INTO Suppliers (SupplierName) VALUES (@name); SELECT SCOPE_IDENTITY();",
                conn, tran))
            {
                cmd.Parameters.AddWithValue("@name", supplierName.Trim());
                int newId = Convert.ToInt32(cmd.ExecuteScalar());
                return newId;
            }
        }

    }
}
