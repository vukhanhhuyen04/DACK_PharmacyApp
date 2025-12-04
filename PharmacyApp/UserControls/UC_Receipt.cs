using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace PharmacyApp.UserControls
{
    public partial class UC_Receipt : UserControl
    {
        public int? EditingProductId { get; set; }
        private int _lastGeneratedNumber = 0;
        private static int _barcodeCounter = 1000000000;  // bắt đầu từ 10 số
        private const int DEFAULT_CATEGORY_ID = 1;
        private AutoCompleteStringCollection _productNameAutoComplete;
        private DataTable _productTable;   // nếu muốn sau này fill thêm mã SP, đơn vị, giá...
        private decimal ParseMoney(object cellValue)
        {
            if (cellValue == null) return 0m;

            var s = cellValue.ToString().Trim();
            if (string.IsNullOrEmpty(s)) return 0m;

            // Bỏ dấu . và , dùng để ngăn cách hàng nghìn
            s = s.Replace(".", "").Replace(",", "");

            decimal value;
            if (!decimal.TryParse(s, NumberStyles.Number, CultureInfo.InvariantCulture, out value))
                value = 0m;

            return value;
        }
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
            // 🔹 AutoComplete cho tên thuốc
            dgvReceiptList.EditingControlShowing += DgvReceiptList_EditingControlShowing;

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
        // 🟢 Load danh sách kho từ bảng Warehouses
        // 🟢 Load danh sách kho từ bảng Warehouses
        private void LoadWarehouses()
        {
            using (var conn = new SqlConnection(Program.ConnStr))
            using (var da = new SqlDataAdapter(
                "SELECT WarehouseId, WarehouseName FROM Warehouses ORDER BY WarehouseName", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboWarehouse.DataSource = dt;
                cboWarehouse.DisplayMember = "WarehouseName";
                cboWarehouse.ValueMember = "WarehouseId";

                // Chọn mặc định: Kho chính nếu có
                if (dt.Rows.Count > 0)
                {
                    // ❌ SAI: dt.Select("WarehouseName = N'Kho chính'");
                    // ✅ ĐÚNG:
                    DataRow[] main = dt.Select("WarehouseName = 'Kho chính'");

                    if (main.Length > 0)
                        cboWarehouse.SelectedValue = (int)main[0]["WarehouseId"];
                    else
                        cboWarehouse.SelectedIndex = 0;
                }
            }
        }


        // 🔹 Gắn AutoComplete cho ô đang sửa nếu là cột Tên thuốc
        private void DgvReceiptList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // chỉ xử lý nếu đang sửa cột colProductName
            if (dgvReceiptList.CurrentCell == null) return;

            var col = dgvReceiptList.Columns[dgvReceiptList.CurrentCell.ColumnIndex];

            if (col.Name == "colProductName" && e.Control is TextBox tb)
            {
                tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                tb.AutoCompleteCustomSource = _productNameAutoComplete;
            }
            else if (e.Control is TextBox tb2)
            {
                // các cột khác tắt AutoComplete để tránh bị dính
                tb2.AutoCompleteMode = AutoCompleteMode.None;
                tb2.AutoCompleteSource = AutoCompleteSource.None;
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
            LoadWarehouses();
            LoadProductNames();
            dtpDate.Value = DateTime.Today;
            _lastGeneratedNumber = GetLastProductNumberFromDB();

        }
        // 🟢 Load danh sách thuốc để AutoComplete tên thuốc
        private void LoadProductNames()
        {
            using (var conn = new SqlConnection(Program.ConnStr))
            using (var da = new SqlDataAdapter(
                "SELECT ProductId, ProductCode, ProductName FROM Products ORDER BY ProductName",
                conn))
            {
                _productTable = new DataTable();
                da.Fill(_productTable);

                _productNameAutoComplete = new AutoCompleteStringCollection();
                foreach (DataRow row in _productTable.Rows)
                {
                    string name = row["ProductName"].ToString();
                    if (!string.IsNullOrWhiteSpace(name))
                        _productNameAutoComplete.Add(name);
                }
            }
        }

        // Mỗi lần sửa SL / Đơn giá → tính lại Thành tiền & Tổng tiền
        private void DgvReceiptList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvReceiptList.Rows[e.RowIndex];
            if (row.IsNewRow) return;

            int qty = 0;
            int.TryParse(row.Cells["colQuantity"].Value?.ToString(), out qty);

            // dùng hàm ParseMoney mới
            decimal unitPrice = ParseMoney(row.Cells["colUnitPrice"].Value);

            decimal total = qty * unitPrice;
            row.Cells["colLineTotal"].Value = total;

            // Tồn sau nhập = chỉ hiển thị = SL (vì bạn không dùng DB để lấy tồn thật)
            if (dgvReceiptList.Columns.Contains("colStockAfter"))
                row.Cells["colStockAfter"].Value = qty;

            RecalculateTotal();
            // ... cuối hàm DgvReceiptList_CellEndEdit

            // Nếu vừa sửa cột Tên thuốc → thử điền lại Mã SP từ bảng sản phẩm
            if (dgvReceiptList.Columns[e.ColumnIndex].Name == "colProductName"
                && _productTable != null)
            {
                string name = row.Cells["colProductName"].Value?.ToString();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    DataRow[] found = _productTable.Select(
                        $"ProductName = '{name.Replace("'", "''")}'");

                    if (found.Length > 0)
                    {
                        row.Cells["colProductCode"].Value = found[0]["ProductCode"].ToString();
                    }
                }
            }

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
        // 🔍 Tìm ProductId theo Mã SP hoặc Tên thuốc
        private int? FindProductByCodeOrName(
            SqlConnection conn,
            SqlTransaction tran,
            string productCode,
            string productName,
            out string realProductCode)
        {
            realProductCode = productCode;

            // 1. Thử tìm theo Mã SP (nếu có)
            if (!string.IsNullOrWhiteSpace(productCode))
            {
                using (var cmd = new SqlCommand(
                    "SELECT ProductId FROM Products WHERE ProductCode = @code",
                    conn, tran))
                {
                    cmd.Parameters.AddWithValue("@code", productCode.Trim());
                    var obj = cmd.ExecuteScalar();
                    if (obj != null && obj != DBNull.Value)
                    {
                        return Convert.ToInt32(obj);
                    }
                }
            }

            // 2. Nếu không có / không tìm thấy, thử tìm theo Tên thuốc
            if (!string.IsNullOrWhiteSpace(productName))
            {
                using (var cmd = new SqlCommand(
                    "SELECT TOP 1 ProductId, ProductCode FROM Products WHERE ProductName = @name",
                    conn, tran))
                {
                    cmd.Parameters.AddWithValue("@name", productName.Trim());
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["ProductId"]);
                            realProductCode = reader["ProductCode"].ToString(); // mã thật trong DB
                            return id;
                        }
                    }
                }
            }

            // 3. Không tìm thấy
            return null;
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
                totalAmount += ParseMoney(row.Cells["colLineTotal"].Value);
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
    (VoucherNumber, SupplierId, ReceiptDate, Note, TotalAmount, WarehouseId)
VALUES
    (@VoucherNumber, @SupplierId, @ReceiptDate, @Note, @TotalAmount, @WarehouseId);
SELECT CAST(SCOPE_IDENTITY() AS INT);", conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@VoucherNumber", voucherNumber);
                        cmd.Parameters.AddWithValue("@SupplierId",
                            (object)supplierId ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ReceiptDate", receiptDate);
                        cmd.Parameters.AddWithValue("@Note",
                            string.IsNullOrEmpty(note) ? (object)DBNull.Value : note);
                        cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);

                        // 🔹 Lấy WarehouseId từ combobox
                        if (cboWarehouse.SelectedValue != null)
                            cmd.Parameters.AddWithValue("@WarehouseId", cboWarehouse.SelectedValue);
                        else
                            cmd.Parameters.AddWithValue("@WarehouseId", DBNull.Value);

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
                        int.TryParse(row.Cells["colQuantity"].Value?.ToString(), out qty);

                        decimal unitPrice = ParseMoney(row.Cells["colUnitPrice"].Value);
                        decimal lineTotal = ParseMoney(row.Cells["colLineTotal"].Value);

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
                            salePrice = ParseMoney(row.Cells["colSalePrice"].Value);
                        }


                        //// Lấy ProductId từ ProductCode (nếu sản phẩm đã tồn tại)
                        //int? productId = FindProductIdByCode(conn, tran, productCode);

                        //// Nếu chưa có trong Products → tự tạo sản phẩm mới + sinh mã SP
                        //if (productId == null)
                        //{
                        //    if (string.IsNullOrWhiteSpace(productName))
                        //    {
                        //        throw new Exception("Dòng nhập kho không có Mã SP và Tên thuốc, không thể tạo mới sản phẩm.");
                        //    }

                        //    // productCode có thể đang rỗng → hàm CreateNewProduct sẽ tự GenerateProductCode
                        //    string newCode = productCode;
                        //    int newId = CreateNewProduct(
                        //        conn,
                        //        tran,
                        //        ref newCode,    // có thể được cập nhật thành SP000xxx
                        //        productName,
                        //        barcode,
                        //        unitPrice,
                        //        salePrice,
                        //        supplierId,
                        //        expired,
                        //        unitFromRow);

                        //    productId = newId;
                        //    productCode = newCode;

                        //    // Cập nhật lại lên grid để bạn nhìn thấy mã sản phẩm vừa sinh
                        //    row.Cells["colProductCode"].Value = productCode;
                        //    row.Cells["colProductName"].Value = productName;
                        //}
                        // 🔍 Tìm sản phẩm theo Mã SP hoặc Tên thuốc
                        string realProductCode;
                        int? productId = FindProductByCodeOrName(conn, tran, productCode, productName, out realProductCode);

                        // Nếu tìm được sản phẩm có sẵn → dùng luôn ProductId cũ, Mã SP cũ
                        if (productId != null)
                        {
                            productCode = realProductCode;                          // cập nhật lại mã SP đúng
                            row.Cells["colProductCode"].Value = productCode;        // hiển thị lại trên grid
                        }
                        else
                        {
                            // ❗ Không có trong Products → TẠO MỚI
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
                        // Chuẩn hóa đơn vị từ grid
                        string unitToUpdate = null;

                        // CHỈ cập nhật Unit nếu sản phẩm vừa tạo mới
                        bool isNewProduct = false;

                        if (productId == null)
                            isNewProduct = true;
                        if (productId != null)
                        {
                            // Load Unit từ DB
                            using (var cmdUnit = new SqlCommand(
                                "SELECT Unit FROM Products WHERE ProductId = @pid", conn, tran))
                            {
                                cmdUnit.Parameters.AddWithValue("@pid", productId.Value);
                                object unitObj = cmdUnit.ExecuteScalar();
                                if (unitObj != null && unitObj != DBNull.Value)
                                    row.Cells["colUnit"].Value = unitObj.ToString();
                            }
                        }

                        // nếu không phải sản phẩm mới → KHÔNG update Unit
                        if (isNewProduct && dgvReceiptList.Columns.Contains("colUnit"))
                        {
                            var cellUnit = row.Cells["colUnit"].Value;
                            if (cellUnit != null && !string.IsNullOrWhiteSpace(cellUnit.ToString()))
                                unitToUpdate = cellUnit.ToString().Trim();
                        }


                        using (var cmdStock = new SqlCommand(@"
UPDATE Products
SET StockQuantity = StockQuantity + @qty,
    Unit          = CASE WHEN @unit IS NULL OR @unit = '' THEN Unit ELSE @unit END,
    UnitPrice      = @price,
    SalePrice      = CASE WHEN @salePrice IS NULL THEN SalePrice ELSE @salePrice END,
    ExpiredDate    = CASE WHEN @expired   IS NULL THEN ExpiredDate ELSE @expired   END,
    Barcode        = CASE WHEN @barcode   IS NULL THEN Barcode     ELSE @barcode   END,
    -- 🔹 NHẬP KHO LẠI → TỰ ĐỘNG MỞ KINH DOANH
    IsActive       = 1
WHERE ProductId = @pid;", conn, tran))

                        {
                            cmdStock.Parameters.AddWithValue("@qty", qty);
                            cmdStock.Parameters.AddWithValue("@price", unitPrice);
                            cmdStock.Parameters.AddWithValue("@pid", productId.Value);

                            cmdStock.Parameters.AddWithValue("@unit",
                                (object)unitToUpdate ?? DBNull.Value);

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
        private int CreateNewProduct(
    SqlConnection conn,
    SqlTransaction tran,
    ref string productCode,
    string productName,
    string barcode,
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
     StockQuantity, Description, Manufacturer, ExpiredDate, SupplierId, CategoryId, IsActive)
VALUES
    (@ProductCode, @ProductName, @Barcode, @Unit, @UnitPrice, @SalePrice,
     0, NULL,
     -- 🔹 LẤY TÊN NHÀ CUNG CẤP LÀM Manufacturer
     (SELECT SupplierName FROM Suppliers WHERE SupplierId = @SupplierId),
     @ExpiredDate, @SupplierId, @CategoryId, @IsActive);

SELECT CAST(SCOPE_IDENTITY() AS INT);", conn, tran))
            {
                cmd.Parameters.AddWithValue("@ProductCode", productCode);
                cmd.Parameters.AddWithValue("@ProductName", productName ?? "");

                cmd.Parameters.AddWithValue("@Barcode",
                    string.IsNullOrWhiteSpace(barcode) ? (object)DBNull.Value : barcode);

                cmd.Parameters.AddWithValue("@Unit", unitToSave);
                cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);

                decimal finalSale = salePrice.HasValue
                    ? salePrice.Value
                    : Math.Round(unitPrice * 1.2m, 0);
                cmd.Parameters.AddWithValue("@SalePrice", finalSale);

                cmd.Parameters.AddWithValue("@ExpiredDate",
                    expired.HasValue ? (object)expired.Value : DBNull.Value);

                cmd.Parameters.AddWithValue("@SupplierId",
                    supplierId.HasValue ? (object)supplierId.Value : DBNull.Value);

                cmd.Parameters.AddWithValue("@CategoryId", DEFAULT_CATEGORY_ID);
                cmd.Parameters.AddWithValue("@IsActive", 1);

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
            // Không có dòng được chọn
            if (dgvReceiptList.CurrentRow == null)
            {
                MessageBox.Show("Hãy chọn dòng cần xóa!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow row = dgvReceiptList.CurrentRow;

            // Không được xóa dòng mới (dòng nhập dữ liệu trống)
            if (row.IsNewRow)
                return;

            // Xác nhận
            DialogResult confirm = MessageBox.Show(
                "Bạn có chắc muốn xóa dòng này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.No)
                return;

            // Xóa dòng
            dgvReceiptList.Rows.Remove(row);

            // Tính lại tổng tiền
            RecalculateTotal();

            // Nếu muốn: tự chọn dòng kế tiếp để không bị deselect
            if (dgvReceiptList.Rows.Count > 0)
            {
                int idx = Math.Min(dgvReceiptList.Rows.Count - 1, row.Index);
                dgvReceiptList.CurrentCell = dgvReceiptList.Rows[idx].Cells[0];
            }
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
