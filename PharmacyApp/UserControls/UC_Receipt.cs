using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PharmacyApp.UserControls
{
    public partial class UC_Receipt : UserControl
    {
        public int? EditingProductId { get; set; }
        public UC_Receipt()
        {
            InitializeComponent();

            this.Load += UC_Receipt_Load;
            btnSave.Click += BtnSave_Click;
            btnBack.Click += BtnBack_Click;

            // mỗi lần sửa SL / Đơn giá thì tính lại tổng
            dgvReceiptList.CellEndEdit += DgvReceiptList_CellEndEdit;
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

                cboSupplier.DataSource = dt;
                cboSupplier.DisplayMember = "SupplierName";
                cboSupplier.ValueMember = "SupplierId";
                cboSupplier.SelectedIndex = -1;
            }
        }

        private void UC_Receipt_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
            dtpDate.Value = DateTime.Today;
        }

        // Mỗi lần sửa SL / Đơn giá → tính lại Thành tiền & Tổng tiền
        private void DgvReceiptList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvReceiptList.Rows[e.RowIndex];
            if (row.IsNewRow) return;

            // Lấy SL + Đơn giá
            int qty = 0;
            decimal price = 0m;

            if (row.Cells["colQuantity"].Value != null)
                int.TryParse(row.Cells["colQuantity"].Value.ToString(), out qty);

            if (row.Cells["colUnitPrice"].Value != null)
                decimal.TryParse(row.Cells["colUnitPrice"].Value.ToString(), out price);

            decimal lineTotal = qty * price;
            row.Cells["colLineTotal"].Value = lineTotal;

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
                if (cell?.Value == null) continue;

                if (decimal.TryParse(cell.Value.ToString(), out decimal value))
                    sum += value;
            }

            lblTotal.Text = $"Tổng tiền: {sum:N0} VNĐ";
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
                    return $"PN{datePrefix}-0001";
                }
                else
                {
                    string last = result.ToString();   // PN20251120-0003
                    string[] parts = last.Split('-');
                    int lastNumber = int.Parse(parts[1]);
                    return $"PN{datePrefix}-{(lastNumber + 1).ToString("D4")}";
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
            int? supplierId = null;
            if (cboSupplier.SelectedValue != null && cboSupplier.SelectedValue != DBNull.Value)
                supplierId = Convert.ToInt32(cboSupplier.SelectedValue);

            DateTime receiptDate = dtpDate.Value.Date;
            string note = txtNote.Text.Trim();

            // tính tổng (lại cho chắc)
            decimal totalAmount = 0m;
            foreach (DataGridViewRow row in dgvReceiptList.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["colLineTotal"].Value == null) continue;

                if (decimal.TryParse(row.Cells["colLineTotal"].Value.ToString(), out decimal val))
                    totalAmount += val;
            }

            using (var conn = new SqlConnection(Program.ConnStr))
            {
                conn.Open();
                var tran = conn.BeginTransaction();

                try
                {
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

                        string productCode = row.Cells["colProductCode"].Value?.ToString();
                        string productName = row.Cells["colProductName"].Value?.ToString();

                        // dòng trống → bỏ qua
                        if (string.IsNullOrWhiteSpace(productCode) &&
                            string.IsNullOrWhiteSpace(productName))
                            continue;

                        int qty = 0;
                        decimal unitPrice = 0m;
                        decimal lineTotal = 0m;

                        int.TryParse(row.Cells["colQuantity"].Value?.ToString(), out qty);
                        decimal.TryParse(row.Cells["colUnitPrice"].Value?.ToString(), out unitPrice);
                        decimal.TryParse(row.Cells["colLineTotal"].Value?.ToString(), out lineTotal);

                        string batchNo = row.Cells["colBatchNo"].Value?.ToString();
                        string rowNote = row.Cells["colRowNote"].Value?.ToString();

                        DateTime? expired = null;
                        if (row.Cells["colExpiredDate"].Value != null &&
                            DateTime.TryParse(row.Cells["colExpiredDate"].Value.ToString(), out DateTime exp))
                        {
                            expired = exp.Date;
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
                            int newId = CreateNewProduct(conn, tran,
                                ref newCode,            // có thể được cập nhật thành SP000xxx
                                productName,
                                unitPrice,
                                supplierId,             // dùng SupplierId của phiếu nhập
                                expired);

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
                                (object)expired ?? DBNull.Value);
                            cmdDet.Parameters.AddWithValue("@RowNote",
                                string.IsNullOrWhiteSpace(rowNote) ? (object)DBNull.Value : rowNote);

                            cmdDet.ExecuteNonQuery();
                        }

                        // 5.2 Cập nhật tồn kho Products
                        using (var cmdStock = new SqlCommand(@"
UPDATE Products
SET StockQuantity = StockQuantity + @qty,
    UnitPrice = @price
WHERE ProductId = @pid;", conn, tran))
                        {
                            cmdStock.Parameters.AddWithValue("@qty", qty);
                            cmdStock.Parameters.AddWithValue("@price", unitPrice);
                            cmdStock.Parameters.AddWithValue("@pid", productId.Value);
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

                if (!int.TryParse(numericPart, out int num))
                {
                    num = 0;
                }

                return "SP" + (num + 1).ToString("D6");
            }
        }
        // 🔹 Tạo sản phẩm mới trong bảng Products nếu chưa có
        //  - productCode có thể rỗng → hàm sẽ tự gán GenerateProductCode
        //  - trả về ProductId mới
        private int CreateNewProduct(SqlConnection conn, SqlTransaction tran,
            ref string productCode, string productName, decimal unitPrice,
            int? supplierId, DateTime? expired)
        {
            if (string.IsNullOrWhiteSpace(productCode))
            {
                productCode = GenerateProductCode(conn, tran);
            }

            using (var cmd = new SqlCommand(@"
INSERT INTO Products
    (ProductCode, ProductName, Unit, UnitPrice, StockQuantity,
     Manufacturer, ExpiredDate, SupplierId)
VALUES
    (@ProductCode, @ProductName, @Unit, @UnitPrice, 0,
     @Manufacturer, @ExpiredDate, @SupplierId);
SELECT CAST(SCOPE_IDENTITY() AS INT);", conn, tran))
            {
                cmd.Parameters.AddWithValue("@ProductCode", productCode);
                cmd.Parameters.AddWithValue("@ProductName", productName ?? "");

                // TODO: nếu bạn có cột Unit, Manufacturer... thì chỉnh lại cho đúng
                cmd.Parameters.AddWithValue("@Unit", "Hộp");          // đơn vị mặc định
                cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                cmd.Parameters.AddWithValue("@Manufacturer", DBNull.Value);
                cmd.Parameters.AddWithValue("@ExpiredDate",
                    (object)expired ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SupplierId",
                    (object)supplierId ?? DBNull.Value);

                int newId = (int)cmd.ExecuteScalar();
                return newId;
            }
        }

    }
}
