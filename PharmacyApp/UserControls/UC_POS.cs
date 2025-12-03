using Microsoft.VisualBasic;   // thêm dòng này
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;   // <-- thêm
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Globalization;
using PdfFont = iTextSharp.text.Font;
namespace PharmacyApp.UserControls
{
    public partial class UC_POS : UserControl
    {
        public UC_POS()
        {
            InitializeComponent();
            cboPaymentMethod.Items.Clear();
            cboPaymentMethod.Items.Add("Tiền mặt");
            cboPaymentMethod.Items.Add("Ngân hàng (QR)");
            cboPaymentMethod.SelectedIndex = 0;   // mặc định tiền mặt
            this.Load += UC_POS_Load;
            lvCart.DoubleClick += lvCart_DoubleClick;
            gvProducts.CellDoubleClick += gvProducts_CellDoubleClick;
            btnPay.Click += btnPay_Click;
            btnPaid.Click += btnPaid_Click;
            btnPrintInvoice.Click += btnPrintInvoice_Click;
            btnCancel.Click += btnCancel_Click;
            cboPaymentMethod.SelectedIndexChanged += cboPaymentMethod_SelectedIndexChanged;
            txtCashGiven.TextChanged += txtCashGiven_TextChanged;
            txtCustomerName.TextChanged += txtCustomerName_TextChanged;
            txtCustomerPhone.TextChanged += txtCustomerPhone_TextChanged;

            lstCustomerSuggest.DoubleClick += lstCustomerSuggest_DoubleClick;
            lstCustomerSuggest.KeyDown += lstCustomerSuggest_KeyDown;
        }
        private int? _selectedCategoryId = null;

        private int _lastInvoiceId;     // lưu lại mã HD vừa tạo (nếu muốn hiển thị)
        private string _lastInvoiceCode // nếu muốn kiểu HD000001
            => "HD" + _lastInvoiceId.ToString("D6");
        private void txtCustomerPhone_TextChanged(object sender, EventArgs e)
        {
            ShowCustomerSuggest(txtCustomerPhone.Text);
        }

        private void UC_POS_Load(object sender, EventArgs e)
        {
            if (lvCart.Columns.Count < 6)
            {
                lvCart.Columns.Add("ProductId", 0);
            }
            
            LoadCategoriesForPOS();
            cboCategoryPOS.SelectedIndexChanged += cboCategoryPOS_SelectedIndexChanged;

            _selectedCategoryId = null;
            LoadProducts(null, null);

           
           

           
            pCash.Visible = true;
            pBank.Visible = false;
        }
        private void cboCategoryPOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)cboCategoryPOS.SelectedValue;
            _selectedCategoryId = (id == 0) ? (int?)null : id;

            string keyword = txtSearchProduct.Text.Trim();
            LoadProducts(_selectedCategoryId, keyword);
        }
        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            string kw = txtSearchProduct.Text.Trim();
            LoadProducts(_selectedCategoryId, kw);
        }


        private decimal _totalAmount = 0m;
        private int? _currentInvoiceId = null;   // mã hóa đơn hiện tại (vừa tạo / đang xử lý)

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
        }

        // Thêm sản phẩm vào giỏ hàng
        private void AddToCart(ProductDto p, int soLuong)
        {
            // Nếu đã có trong giỏ
            foreach (ListViewItem item in lvCart.Items)
            {
                if (item.SubItems[0].Text == p.ProductCode)
                {
                    int slCu = int.Parse(item.SubItems[2].Text);
                    int slMoi = slCu + soLuong;

                    if (slMoi > p.Stock)
                    {
                        MessageBox.Show("Không đủ tồn kho!", "Lỗi");
                        return;
                    }

                    item.SubItems[2].Text = slMoi.ToString();
                    item.SubItems[4].Text = (slMoi * p.UnitPrice).ToString("N0");

                    RecalculateTotal();
                    return;
                }
            }

            // Nếu chưa có – thêm mới
            if (soLuong > p.Stock)
            {
                MessageBox.Show("Không đủ tồn kho!", "Lỗi");
                return;
            }

            decimal lineTotal = soLuong * p.UnitPrice;

            var lvi = new ListViewItem(new[]
            {
        p.ProductCode,              // 0
        p.ProductName,              // 1
        soLuong.ToString(),         // 2
        p.UnitPrice.ToString("N0"), // 3
        lineTotal.ToString("N0"),   // 4
        p.ProductId.ToString() ,     // 5 (ẩn)
        p.Stock.ToString()
    });

            lvCart.Items.Add(lvi);
            RecalculateTotal();
        }

        // Double click vào grid sản phẩm để thêm vào giỏ
        private void gvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = gvProducts.Rows[e.RowIndex];

            var p = new ProductDto
            {
                ProductId = Convert.ToInt32(row.Cells["colProductId"].Value),
                ProductCode = row.Cells["colMaThuoc"].Value.ToString(),
                ProductName = row.Cells["colTenThuoc"].Value.ToString(),
                UnitPrice = Convert.ToDecimal(row.Cells["colGiaBan"].Value),
                Stock = Convert.ToInt32(row.Cells["colTonKho"].Value)
            };

            AddToCart(p, 1);
        }



        // Tính lại tổng tiền
        private void RecalculateTotal()
        {
            decimal sum = 0m;

            foreach (ListViewItem item in lvCart.Items)
            {
                // cột Thành tiền là subitem[4]
                if (decimal.TryParse(
                        item.SubItems[4].Text,
                        System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.CurrentCulture,
                        out decimal lineTotal))
                {
                    sum += lineTotal;
                }
            }

            _totalAmount = sum;
            txtTotal.Text = _totalAmount.ToString("N0");

            // tính lại tiền thối nếu đang nhập tiền mặt
            RecalculateChange();
        }

        // Chọn phương thức thanh toán
        private void cboPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPaymentMethod.SelectedItem.ToString().StartsWith("Tiền mặt"))
            {
                pCash.Visible = true;
                pBank.Visible = false;
            }
            else
            {
                pCash.Visible = false;
                pBank.Visible = true;

                // Nếu có file QR sẵn thì load:
                pbQr.Image = Properties.Resources.qr_bank1;
            }
        }

        // Chỉ cho gõ số vào ô Tiền khách đưa
        private void txtCashGiven_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép: số, backspace, phím điều hướng
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // chặn ký tự khác số
            }
        }

        // Khi đổi Tiền khách đưa => tính lại tiền thối
        private void txtCashGiven_TextChanged(object sender, EventArgs e)
        {
            RecalculateChange();
        }

        private void RecalculateChange()
        {
            if (!pCash.Visible) return; // chỉ áp dụng cho tiền mặt

            if (string.IsNullOrWhiteSpace(txtCashGiven.Text))
            {
                txtChange.Text = "0";
                return;
            }

            if (!decimal.TryParse(txtCashGiven.Text, out decimal cash))
            {
                txtChange.Text = "0";
                return;
            }

            if (cash < 0)
            {
                MessageBox.Show("Tiền khách đưa không được âm.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCashGiven.Text = "";
                return;
            }

            if (cash < _totalAmount)
            {
                // chưa đủ tiền => thối = 0 (hoặc cho cảnh báo khi bấm Thanh toán)
                txtChange.Text = "0";
            }
            else
            {
                decimal change = cash - _totalAmount;
                txtChange.Text = change.ToString("N0");
            }
        }

        // Nút Thanh toán
        // Nút Thanh toán
        private void btnPay_Click(object sender, EventArgs e)
        {
            if (lvCart.Items.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm trong giỏ hàng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Kiểm tra theo phương thức thanh toán
            string paymentText = cboPaymentMethod.SelectedItem.ToString();
            string status;

            if (paymentText.StartsWith("Tiền mặt"))
            {
                // tiền mặt: bắt buộc nhập tiền khách đưa
                if (!decimal.TryParse(txtCashGiven.Text, out decimal cash))
                {
                    MessageBox.Show("Vui lòng nhập tiền khách đưa.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cash < _totalAmount)
                {
                    MessageBox.Show("Tiền khách đưa không được nhỏ hơn tổng hóa đơn.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                status = "Paid";   // ✅ tiền mặt: thanh toán xong là Paid luôn
            }
            else
            {
                // Ngân hàng: cho phép lưu đơn với trạng thái Pending
                var result = MessageBox.Show("Xác nhận đã gửi yêu cầu thanh toán qua ngân hàng?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;

                status = "Pending";
            }

            // 1) Lưu hóa đơn + chi tiết xuống DB
            try
            {
                _currentInvoiceId = SaveInvoiceToDatabase(status);

                // Thông báo
                MessageBox.Show(
                    $"Đã lưu hóa đơn.\nMã hóa đơn: {_lastInvoiceCode}\nTrạng thái: {status}",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ✅ Nếu là tiền mặt (Paid) → IN LUÔN HÓA ĐƠN
                if (status == "Paid" && _currentInvoiceId.HasValue)
                {
                    PrintBillToPdf(_currentInvoiceId.Value);
                    ClearCurrentForm();      // nếu muốn sau khi in là reset form
                }
                else
                {
                    // QR (Pending) thì giữ lại màn hình, cho user bấm nút ĐÃ THANH TOÁN sau
                    // không clear form, không in
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lưu hóa đơn thất bại:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _currentInvoiceId = null;
                return;
            }
        }



        /// <summary>
        /// Lưu hóa đơn & chi tiết vào database.
        /// Giả sử:
        ///   - Bảng Invoices(Id IDENTITY, CreatedAt, CustomerName, Symptom,
        ///                   TotalAmount, PaymentMethod, CashGiven, ChangeAmount)
        ///   - Bảng InvoiceDetails(Id IDENTITY, InvoiceId, ProductCode,
        ///                         ProductName, Quantity, UnitPrice, LineTotal)
        /// Bạn sửa lại tên bảng/cột cho đúng với DB của bạn.
        /// </summary>
        private int SaveInvoiceToDatabase(string status)
        {
            string customerName = txtCustomerName.Text.Trim();
            string symptom = txtSymptoms.Text.Trim();
            string paymentMethod = cboPaymentMethod.SelectedItem?.ToString() ?? "";

            decimal cashGiven = 0m;
            decimal changeAmount = 0m;

            if (paymentMethod.StartsWith("Tiền mặt"))
            {
                decimal.TryParse(txtCashGiven.Text, out cashGiven);
                decimal.TryParse(
                    txtChange.Text.Replace(".", "").Replace(",", ""),
                    out changeAmount
                );
            }

            int? customerId = GetOrCreateCustomerId();

            // 🔹 Lấy NV đang đăng nhập từ Program
            int? staffId = Program.CurrentStaffId;
            string staffName = Program.CurrentStaffName ?? "";

            using (var conn = new SqlConnection(Program.ConnStr))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        string sql = @"
INSERT INTO Invoices
    (CreatedAt, CustomerId, CustomerName, Symptom, TotalAmount,
     PaymentMethod, CashGiven, ChangeAmount, Status,
     StaffId, StaffName)
VALUES
    (@CreatedAt, @CustomerId, @CustomerName, @Symptom, @TotalAmount,
     @PaymentMethod, @CashGiven, @ChangeAmount, @Status,
     @StaffId, @StaffName);
SELECT CAST(SCOPE_IDENTITY() AS int);";

                        using (var cmdInv = new SqlCommand(sql, conn, tran))
                        {
                            cmdInv.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                            cmdInv.Parameters.AddWithValue("@CustomerId",
                                (object)customerId ?? DBNull.Value);
                            cmdInv.Parameters.AddWithValue("@CustomerName",
                                string.IsNullOrEmpty(customerName)
                                    ? (object)DBNull.Value
                                    : customerName);
                            cmdInv.Parameters.AddWithValue("@Symptom",
                                string.IsNullOrEmpty(symptom)
                                    ? (object)DBNull.Value
                                    : symptom);
                            cmdInv.Parameters.AddWithValue("@TotalAmount", _totalAmount);
                            cmdInv.Parameters.AddWithValue("@PaymentMethod", paymentMethod);

                            // 🔹 Chỉ add 1 lần, không lặp tên tham số
                            if (paymentMethod.StartsWith("Tiền mặt"))
                            {
                                cmdInv.Parameters.AddWithValue("@CashGiven", cashGiven);
                                cmdInv.Parameters.AddWithValue("@ChangeAmount", changeAmount);
                            }
                            else
                            {
                                cmdInv.Parameters.AddWithValue("@CashGiven", DBNull.Value);
                                cmdInv.Parameters.AddWithValue("@ChangeAmount", DBNull.Value);
                            }

                            cmdInv.Parameters.AddWithValue("@Status", status);

                            // 🔹 Tham số nhân viên – CHỈ add 1 lần
                            cmdInv.Parameters.AddWithValue("@StaffId",
                                (object)staffId ?? DBNull.Value);
                            cmdInv.Parameters.AddWithValue("@StaffName",
                                string.IsNullOrEmpty(staffName)
                                    ? (object)DBNull.Value
                                    : staffName);

                            int invoiceId = (int)cmdInv.ExecuteScalar();
                            _lastInvoiceId = invoiceId;

                            // ===== Chi tiết + trừ kho như code cũ của em =====
                            foreach (ListViewItem item in lvCart.Items)
                            {
                                int productId = int.Parse(item.SubItems[5].Text);
                                int qty = int.Parse(item.SubItems[2].Text);

                                decimal unitPrice = decimal.Parse(
                                    item.SubItems[3].Text,
                                    System.Globalization.NumberStyles.Any,
                                    System.Globalization.CultureInfo.CurrentCulture);

                                decimal lineTotal = decimal.Parse(
                                    item.SubItems[4].Text,
                                    System.Globalization.NumberStyles.Any,
                                    System.Globalization.CultureInfo.CurrentCulture);

                                using (var cmdDet = new SqlCommand(@"
INSERT INTO InvoiceDetails
    (InvoiceId, ProductId, Quantity, UnitPrice, LineTotal)
VALUES
    (@InvoiceId, @ProductId, @Quantity, @UnitPrice, @LineTotal);",
                                    conn, tran))
                                {
                                    cmdDet.Parameters.AddWithValue("@InvoiceId", invoiceId);
                                    cmdDet.Parameters.AddWithValue("@ProductId", productId);
                                    cmdDet.Parameters.AddWithValue("@Quantity", qty);
                                    cmdDet.Parameters.AddWithValue("@UnitPrice", unitPrice);
                                    cmdDet.Parameters.AddWithValue("@LineTotal", lineTotal);
                                    cmdDet.ExecuteNonQuery();
                                }

                                using (var cmdStock = new SqlCommand(@"
UPDATE Products
SET StockQuantity = StockQuantity - @qty
WHERE ProductId = @pid;", conn, tran))
                                {
                                    cmdStock.Parameters.AddWithValue("@qty", qty);
                                    cmdStock.Parameters.AddWithValue("@pid", productId);
                                    cmdStock.ExecuteNonQuery();
                                }
                            }

                            tran.Commit();
                            return invoiceId;
                        }
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }










        // Các event trống (nếu bạn không dùng thì có thể xoá)
        private void lblPaymentMethod_Click(object sender, EventArgs e)
        {
        }

        private void pLeft_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnPay_Click_1(object sender, EventArgs e)
        {
        }

        private void lblCart_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }
        public class ProductDto
        {
            public int ProductId { get; set; }
            public string ProductCode { get; set; }
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
            public int Stock { get; set; }
        }
        private ProductDto GetProductByCode(string code)
        {
            using (SqlConnection conn = new SqlConnection(Program.ConnStr))
            {
                conn.Open();
                string sql = @"
    SELECT ProductId, ProductCode, ProductName, UnitPrice, StockQuantity
    FROM Products
    WHERE ProductCode = @code
      AND IsActive = 1";   // 🔴 chỉ lấy thuốc đang kinh doanh

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@code", code);

                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                        {
                            return new ProductDto
                            {
                                ProductId = rd.GetInt32(0),
                                ProductCode = rd.GetString(1),
                                ProductName = rd.GetString(2),
                                UnitPrice = rd.GetDecimal(3),
                                Stock = rd.GetInt32(4)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public class CustomerDto
        {
            public int CustomerId { get; set; }
            public string FullName { get; set; }
            public string PhoneNumber { get; set; }

            public override string ToString()
            {
                return $"{FullName} - {PhoneNumber}";
            }
        }

        private void txtSearchProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;   // tránh kêu "ting"

                // Nếu không có sản phẩm nào trong grid thì thôi
                if (gvProducts.Rows.Count == 0)
                    return;

                // Lấy dòng đang chọn, nếu chưa chọn thì lấy dòng đầu tiên
                var row = gvProducts.CurrentRow ?? gvProducts.Rows[0];

                var p = new ProductDto
                {
                    ProductId = Convert.ToInt32(row.Cells["colProductId"].Value),
                    ProductCode = row.Cells["colMaThuoc"].Value.ToString(),
                    ProductName = row.Cells["colTenThuoc"].Value.ToString(),
                    UnitPrice = Convert.ToDecimal(row.Cells["colGiaBan"].Value),
                    Stock = Convert.ToInt32(row.Cells["colTonKho"].Value)
                };

                AddToCart(p, 1);
                txtSearchProduct.SelectAll();
            }
        }

        private void LoadProducts(int? categoryId, string keyword)
        {
            using (var conn = new SqlConnection(Program.ConnStr))
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                cmd.CommandText = @"
SELECT 
    P.ProductId,
    P.ProductCode,
    P.ProductName,
    P.Unit,
     P.SalePrice,    
    P.StockQuantity
FROM Products P
LEFT JOIN ProductCategories PC ON P.ProductId = PC.ProductId
WHERE P.IsActive = 1
AND (@CategoryId IS NULL OR PC.CategoryId = @CategoryId)
AND (@kw IS NULL OR P.ProductCode LIKE @kw OR P.ProductName LIKE @kw)
ORDER BY P.ProductName";

                cmd.Parameters.Add("@CategoryId", SqlDbType.Int)
                    .Value = (object)categoryId ?? DBNull.Value;

                cmd.Parameters.Add("@kw", SqlDbType.NVarChar)
                    .Value = string.IsNullOrWhiteSpace(keyword)
                    ? (object)DBNull.Value
                    : "%" + keyword + "%";

                conn.Open();

                using (var da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gvProducts.DataSource = dt;
                }
            }
        }






        private void lvCart_DoubleClick(object sender, EventArgs e)
        {
            if (lvCart.SelectedItems.Count == 0) return;

            var item = lvCart.SelectedItems[0];

            int oldQty = int.Parse(item.SubItems[2].Text);

            string input = Interaction.InputBox(
                "Nhập số lượng mới (0 để xóa thuốc):",
                "Cập nhật số lượng",
                oldQty.ToString()
            );

            if (string.IsNullOrWhiteSpace(input)) return;

            if (!int.TryParse(input, out int newQty) || newQty < 0)
            {
                MessageBox.Show("Số lượng phải là số nguyên >= 0", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ⛔ Nếu newQty == 0 → XÓA SẢN PHẨM
            if (newQty == 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này khỏi giỏ?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    lvCart.Items.Remove(item);
                    RecalculateTotal();
                }
                return;
            }

            // Kiểm tra tồn kho
            int stock = int.Parse(item.SubItems[6].Text);
            if (newQty > stock)
            {
                MessageBox.Show("Số lượng vượt quá tồn kho!", "Lỗi");
                return;
            }

            // Cập nhật số lượng
            item.SubItems[2].Text = newQty.ToString();

            decimal unitPrice = decimal.Parse(item.SubItems[3].Text,
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.CurrentCulture);

            decimal lineTotal = newQty * unitPrice;
            item.SubItems[4].Text = lineTotal.ToString("N0");

            RecalculateTotal();
        }

        private List<CustomerDto> SearchCustomers(string keyword)
        {
            var result = new List<CustomerDto>();

            using (var conn = new SqlConnection(Program.ConnStr))
            {
                conn.Open();

                string sql = @"
SELECT TOP 10 CustomerId, FullName, PhoneNumber
FROM Customers
WHERE FullName LIKE N'%' + @kw + N'%'
   OR PhoneNumber LIKE '%' + @kw + '%'
ORDER BY FullName";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@kw", keyword);

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            result.Add(new CustomerDto
                            {
                                CustomerId = rd.GetInt32(0),
                                FullName = rd.GetString(1),
                                PhoneNumber = rd.IsDBNull(2) ? "" : rd.GetString(2)
                            });
                        }
                    }
                }
            }

            return result;
        }

        private int? _selectedCustomerId = null;

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            _selectedCustomerId = null;

            string kw = txtCustomerName.Text.Trim();
            if (kw.Length < 1)
            {
                lstCustomerSuggest.Visible = false;
                return;
            }

            var list = SearchCustomers(kw);

            if (list.Count == 0)
            {
                lstCustomerSuggest.Visible = false;
                return;
            }

            lstCustomerSuggest.Items.Clear();
            foreach (var c in list)
                lstCustomerSuggest.Items.Add(c);

            lstCustomerSuggest.Visible = true;
            lstCustomerSuggest.BringToFront();
        }


        private void lstCustomerSuggest_DoubleClick(object sender, EventArgs e)
        {
            ApplySelectedCustomer();
        }

        private void lstCustomerSuggest_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ApplySelectedCustomer();
                e.Handled = true;
            }
        }

        private void ApplySelectedCustomer()
        {
            if (lstCustomerSuggest.SelectedItem is CustomerDto c)
            {
                _selectedCustomerId = c.CustomerId;
                txtCustomerName.Text = c.FullName;
                txtCustomerPhone.Text = c.PhoneNumber;   // ô SĐT
                lstCustomerSuggest.Visible = false;
            }
        }

        private int? GetOrCreateCustomerId()
        {
            string name = txtCustomerName.Text.Trim();
            string phone = txtCustomerPhone.Text.Trim();

            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(phone))
                return null; // hóa đơn không có khách

            // Nếu đã chọn khách từ gợi ý
            if (_selectedCustomerId.HasValue)
                return _selectedCustomerId.Value;

            using (var conn = new SqlConnection(Program.ConnStr))
            {
                conn.Open();

                // 1. Tìm theo Phone trước
                if (!string.IsNullOrEmpty(phone))
                {
                    string findSql = @"
SELECT TOP 1 CustomerId
FROM Customers
WHERE PhoneNumber = @phone";

                    using (var cmdFind = new SqlCommand(findSql, conn))
                    {
                        cmdFind.Parameters.AddWithValue("@phone", phone);
                        var id = cmdFind.ExecuteScalar();
                        if (id != null)
                            return Convert.ToInt32(id);
                    }
                }

                // 2. Nếu chưa có → tạo khách mới
                string insertSql = @"
INSERT INTO Customers(FullName, PhoneNumber)
VALUES (@name, @phone);
SELECT SCOPE_IDENTITY();";

                using (var cmdIns = new SqlCommand(insertSql, conn))
                {
                    cmdIns.Parameters.AddWithValue("@name", (object)name ?? DBNull.Value);
                    cmdIns.Parameters.AddWithValue("@phone",
                        string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone);

                    int newId = Convert.ToInt32(cmdIns.ExecuteScalar());
                    return newId;
                }
            }
        }

        private void btnPaid_Click(object sender, EventArgs e)
        {
            string paymentText = cboPaymentMethod.SelectedItem?.ToString() ?? "";

            // ✅ Nếu CHƯA có hóa đơn nào lưu (_currentInvoiceId == null)
            if (_currentInvoiceId == null)
            {
                // Trường hợp thanh toán bằng QR:
                if (paymentText.StartsWith("Ngân hàng"))
                {
                    try
                    {
                        // Lưu thẳng 1 hóa đơn mới với trạng thái Paid
                        _currentInvoiceId = SaveInvoiceToDatabase("Paid");

                        MessageBox.Show(
                            $"Đã lưu hóa đơn (QR). Mã: {_currentInvoiceId}",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ClearCurrentForm();  // nếu muốn tạo đơn mới luôn
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lưu hóa đơn thất bại:\n" + ex.Message,
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Tiền mặt mà chưa bấm Thanh toán
                    MessageBox.Show(
                        "Với thanh toán tiền mặt, hãy bấm nút 'Thanh toán' để lưu hóa đơn.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                return;
            }

            // ✅ Nếu ĐÃ có hóa đơn (_currentInvoiceId != null) → thường là hóa đơn QR trạng thái Pending
            // hoặc bạn muốn cập nhật lại tiền mặt lần 2.
            decimal cash = 0;
            decimal change = 0;

            decimal.TryParse(txtCashGiven.Text, out cash);
            decimal.TryParse(
                txtChange.Text.Replace(".", "").Replace(",", ""),
                out change
            );

            using (var conn = new SqlConnection(Program.ConnStr))
            {
                conn.Open();
                string sql = @"
UPDATE Invoices
SET Status = 'Paid',
    CashGiven = @CashGiven,
    ChangeAmount = @ChangeAmount
WHERE InvoiceId = @Id";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    if (paymentText.StartsWith("Tiền mặt"))
                    {
                        cmd.Parameters.AddWithValue("@CashGiven", (object)cash);
                        cmd.Parameters.AddWithValue("@ChangeAmount", (object)change);
                    }
                    else
                    {
                        // ✅ QR: không lưu tiền mặt
                        cmd.Parameters.AddWithValue("@CashGiven", DBNull.Value);
                        cmd.Parameters.AddWithValue("@ChangeAmount", DBNull.Value);
                    }

                    cmd.Parameters.AddWithValue("@Id", _currentInvoiceId.Value);
                    cmd.ExecuteNonQuery();
                }
            }


            MessageBox.Show("Đã cập nhật trạng thái hóa đơn thành 'Đã thanh toán'.",
     "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // ✅ In luôn hóa đơn sau khi khách chuyển khoản xong
            if (_currentInvoiceId.HasValue)
            {
                PrintBillToPdf(_currentInvoiceId.Value);
            }

            // Nếu sau khi Paid bạn muốn clear luôn:
            ClearCurrentForm();

        }


        private void btnPrintInvoice_Click(object sender, EventArgs e)
        {
            if (_currentInvoiceId == null)
            {
                MessageBox.Show("Chưa có hóa đơn nào để in.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            PrintBillToPdf(_currentInvoiceId.Value);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (_currentInvoiceId == null)
            {
                // chưa lưu DB → chỉ clear giỏ & form
                if (MessageBox.Show("Hủy giỏ hàng hiện tại?", "Xác nhận",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ClearCurrentForm();
                }
                return;
            }

            if (MessageBox.Show("Hủy hóa đơn hiện tại và trả lại tồn kho?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            using (var conn = new SqlConnection(Program.ConnStr))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Trả lại tồn kho
                        var cmdStock = new SqlCommand(@"
UPDATE P
SET P.StockQuantity = P.StockQuantity + D.Quantity
FROM Products P
JOIN InvoiceDetails D ON P.ProductId = D.ProductId
WHERE D.InvoiceId = @Id", conn, tran);

                        cmdStock.Parameters.AddWithValue("@Id", _currentInvoiceId.Value);
                        cmdStock.ExecuteNonQuery();

                        // 2. Cập nhật trạng thái hóa đơn
                        var cmdInv = new SqlCommand(@"
UPDATE Invoices
SET Status = 'Canceled'
WHERE InvoiceId = @Id", conn, tran);

                        cmdInv.Parameters.AddWithValue("@Id", _currentInvoiceId.Value);
                        cmdInv.ExecuteNonQuery();

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }

            MessageBox.Show("Đã hủy hóa đơn và trả lại tồn kho.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear UI
            ClearCurrentForm();
        }
        private void ClearCurrentForm()
        {
            _currentInvoiceId = null;
            lvCart.Items.Clear();
            RecalculateTotal();
            txtCashGiven.Text = "";
            txtChange.Text = "0";
            txtCustomerName.Text = "";
            txtSymptoms.Text = "";
        }
        private void ShowCustomerSuggest(string keyword)
        {
            _selectedCustomerId = null;

            string kw = keyword.Trim();
            if (kw.Length < 1)
            {
                lstCustomerSuggest.Visible = false;
                return;
            }

            var list = SearchCustomers(kw);

            if (list.Count == 0)
            {
                lstCustomerSuggest.Visible = false;
                return;
            }

            lstCustomerSuggest.Items.Clear();
            foreach (var c in list)
                lstCustomerSuggest.Items.Add(c);

            lstCustomerSuggest.Visible = true;
            lstCustomerSuggest.BringToFront();
        }
        private void LoadCategoriesForPOS()
        {
            using (var conn = new SqlConnection(Program.ConnStr))
            using (var cmd = new SqlCommand(
                "SELECT CategoryId, CategoryName FROM Categories ORDER BY CategoryName", conn))
            {
                conn.Open();
                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                // Thêm dòng "Tất cả"
                var dtAll = dt.Clone();
                dtAll.Rows.Add(0, "Tất cả");
                foreach (DataRow r in dt.Rows)
                    dtAll.ImportRow(r);

                cboCategoryPOS.DataSource = dtAll;
                cboCategoryPOS.DisplayMember = "CategoryName";
                cboCategoryPOS.ValueMember = "CategoryId";
            }
        }
        

private void PrintBillToPdf(int invoiceId)
    {
        try
        {
            // 1) Chọn nơi lưu file PDF
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Lưu hóa đơn PDF";
            sfd.Filter = "PDF Files|*.pdf";
            sfd.FileName = $"HoaDon_{invoiceId}.pdf";

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            string path = sfd.FileName;

            // 2) Tạo document PDF
            Document doc = new Document(PageSize.A5, 30, 30, 20, 20);
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();

                // FONT
                // FONT
                string fontPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Fonts),
                    "times.ttf"
                );
                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                PdfFont font16b = new PdfFont(bf, 16, PdfFont.BOLD);
                PdfFont font12 = new PdfFont(bf, 12, PdfFont.NORMAL);
                PdfFont font12b = new PdfFont(bf, 12, PdfFont.BOLD);


                // -------------------------
                //       HEADER
                // -------------------------
                Paragraph shopName = new Paragraph("Nhà Thuốc EternaMed", font16b);
            shopName.Alignment = Element.ALIGN_CENTER;
            doc.Add(shopName);

            Paragraph shopAddr = new Paragraph("Địa chỉ: 2 Đường số 7, TP.HCM\nHotline: 0909-090-909\n\n", font12);
            shopAddr.Alignment = Element.ALIGN_CENTER;
            doc.Add(shopAddr);

            doc.Add(new Paragraph($"HÓA ĐƠN BÁN HÀNG\n\n", font16b) { Alignment = Element.ALIGN_CENTER });

            // -------------------------
            //   LẤY THÔNG TIN INVOICE
            // -------------------------
            string sqlInv = @"
SELECT InvoiceId, CreatedAt, CustomerName, Symptom, TotalAmount,
       PaymentMethod, CashGiven, ChangeAmount, Status,
       CustomerId, StaffId, StaffName
FROM Invoices
WHERE InvoiceId = @id";

            string sqlDet = @"
SELECT d.ProductId, p.ProductName, d.Quantity, d.UnitPrice, d.LineTotal
FROM InvoiceDetails d
JOIN Products p ON p.ProductId = d.ProductId
WHERE d.InvoiceId = @id";

            DataTable dtInv = new DataTable();
            DataTable dtDet = new DataTable();

            using (var conn = new SqlConnection(Program.ConnStr))
            {
                conn.Open();

                using (var da = new SqlDataAdapter(sqlInv, conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@id", invoiceId);
                    da.Fill(dtInv);
                }

                using (var da = new SqlDataAdapter(sqlDet, conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@id", invoiceId);
                    da.Fill(dtDet);
                }
            }

            if (dtInv.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hóa đơn để in!");
                return;
            }

            var inv = dtInv.Rows[0];

            // -----------------------
            //   THÔNG TIN HÓA ĐƠN
            // -----------------------
            doc.Add(new Paragraph($"Mã hóa đơn: HD{invoiceId:000000}", font12));
            doc.Add(new Paragraph($"Ngày bán: {((DateTime)inv["CreatedAt"]).ToString("dd/MM/yyyy HH:mm")}", font12));

            string staffName = inv["StaffName"] == DBNull.Value ? "Không rõ" : inv["StaffName"].ToString();
            doc.Add(new Paragraph($"Nhân viên: {staffName}", font12));

            doc.Add(new Paragraph($"Khách hàng: {inv["CustomerName"].ToString()}", font12));

            if (inv["Symptom"] != DBNull.Value)
                doc.Add(new Paragraph($"Triệu chứng: {inv["Symptom"]}", font12));

            doc.Add(new Paragraph("\n"));

            // -------------------------
            //   BẢNG SẢN PHẨM
            // -------------------------
            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100;
            table.SetWidths(new float[] { 4, 1.5f, 2, 2 });

            table.AddCell(new PdfPCell(new Phrase("Tên thuốc", font12b)));
            table.AddCell(new PdfPCell(new Phrase("SL", font12b)));
            table.AddCell(new PdfPCell(new Phrase("Đơn giá", font12b)));
            table.AddCell(new PdfPCell(new Phrase("Thành tiền", font12b)));

            foreach (DataRow row in dtDet.Rows)
            {
                table.AddCell(new Phrase(row["ProductName"].ToString(), font12));
                table.AddCell(new Phrase(row["Quantity"].ToString(), font12));
                table.AddCell(new Phrase(
                    Convert.ToDecimal(row["UnitPrice"]).ToString("N0"), font12));
                table.AddCell(new Phrase(
                    Convert.ToDecimal(row["LineTotal"]).ToString("N0"), font12));
            }

            doc.Add(table);
            doc.Add(new Paragraph("\n"));

                // -------------------------
                //   TỔNG TIỀN & THANH TOÁN
                // -------------------------
                decimal total = Convert.ToDecimal(inv["TotalAmount"]);
                doc.Add(new Paragraph($"Tổng tiền: {total.ToString("N0")} đ", font12b));

                // Lấy phương thức thanh toán
                string paymentMethod = inv["PaymentMethod"] == DBNull.Value
                    ? ""
                    : inv["PaymentMethod"].ToString();

                // ✅ Chỉ in tiền khách đưa / tiền thối nếu là TIỀN MẶT
                if (paymentMethod.StartsWith("Tiền mặt") && inv["CashGiven"] != DBNull.Value)
                {
                    decimal cash = Convert.ToDecimal(inv["CashGiven"]);
                    decimal change = Convert.ToDecimal(inv["ChangeAmount"]);

                    doc.Add(new Paragraph($"Tiền khách đưa: {cash.ToString("N0")} đ", font12));
                    doc.Add(new Paragraph($"Tiền thối lại: {change.ToString("N0")} đ", font12));
                }
                else if (paymentMethod.StartsWith("Ngân hàng"))
                {
                    // OPTIONAL: thêm dòng xác nhận QR cho đẹp
                    doc.Add(new Paragraph($"Đã thanh toán qua Ngân hàng (QR)", font12));
                }

                // In phương thức thanh toán
                doc.Add(new Paragraph($"\nPhương thức: {paymentMethod}", font12));

                doc.Add(new Paragraph("\nCảm ơn quý khách đã mua hàng!\nChúc quý khách mau khỏe.", font12)
                {
                    Alignment = Element.ALIGN_CENTER
                });


                doc.Close();

            MessageBox.Show("Đã xuất hóa đơn PDF thành công!",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        catch (Exception ex)
        {
            MessageBox.Show("Lỗi khi in hóa đơn:\n" + ex.Message,
                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}
}
