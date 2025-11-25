using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PharmacyApp.Forms
{
    public partial class FrmProductAdd : Form
    {
        // 🔹 Lưu đường dẫn ảnh
        private string _currentImagePath;

        // 🔹 Connection string
        private string ConnStr => Program.ConnStr;

        public FrmProductAdd()
        {
            InitializeComponent();

            this.Load += FrmProductAdd_Load;

            btnBrowseImage.Click += BtnBrowseImage_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
        }

        // ========== LOAD FORM ==========

        private void FrmProductAdd_Load(object sender, EventArgs e)
        {
            // Load danh mục
            using (var conn = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand(
                "SELECT CategoryId, CategoryName FROM Categories ORDER BY CategoryName", conn))
            {
                conn.Open();
                var dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                cboCategory.DataSource = dt;
                cboCategory.DisplayMember = "CategoryName";
                cboCategory.ValueMember = "CategoryId";
            }
        }

        // ========== CHỌN ẢNH ==========

        private void BtnBrowseImage_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Ảnh|*.png;*.jpg;*.jpeg;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _currentImagePath = ofd.FileName;
                    picImage.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        // ========== SINH MÃ SP ==========

        private string GenerateProductCode()
        {
            using (var conn = new SqlConnection(ConnStr))
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
                string numPart = last.Substring(2);

                int num;
                if (!int.TryParse(numPart, out num))
                    num = 0;

                return "SP" + (num + 1).ToString("D6");
            }
        }

        // ========== KIỂM TRA INPUT ==========

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTenThuoc.Text))
            {
                MessageBox.Show("Vui lòng nhập tên thuốc.");
                txtTenThuoc.Focus();
                return false;
            }

            if (!decimal.TryParse(txtGiaNhap.Text.Trim(), out _))
            {
                MessageBox.Show("Giá nhập không hợp lệ.");
                txtGiaNhap.Focus();
                return false;
            }

            if (cboCategory.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục.");
                cboCategory.Focus();
                return false;
            }

            return true;
        }

        // ========== LƯU SẢN PHẨM ==========

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            string name = txtTenThuoc.Text.Trim();
            string barcode = txtBarcode.Text.Trim();
            decimal unitPrice = decimal.Parse(txtGiaNhap.Text.Trim());

            decimal salePrice;
            if (!decimal.TryParse(txtGiaBan.Text.Trim(), out salePrice))
                salePrice = Math.Round(unitPrice * 1.2m, 0);

            int categoryId = (int)cboCategory.SelectedValue;
            string productCode = GenerateProductCode();
            string unit = "Hộp"; // default

            using (var conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        int newProductId;

                        using (var cmd = new SqlCommand(@"
INSERT INTO Products
    (ProductCode, ProductName, Barcode, Unit, UnitPrice, SalePrice,
     StockQuantity, Description, Manufacturer, ExpiredDate, SupplierId, ImagePath)
VALUES
    (@ProductCode, @ProductName, @Barcode, @Unit, @UnitPrice, @SalePrice,
     0, NULL, NULL, NULL, NULL, @ImagePath);

SELECT CAST(SCOPE_IDENTITY() AS INT);",
                                conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@ProductCode", productCode);
                            cmd.Parameters.AddWithValue("@ProductName", name);
                            cmd.Parameters.AddWithValue("@Barcode",
                                string.IsNullOrWhiteSpace(barcode) ? (object)DBNull.Value : barcode);
                            cmd.Parameters.AddWithValue("@Unit", unit);
                            cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                            cmd.Parameters.AddWithValue("@SalePrice", salePrice);
                            cmd.Parameters.AddWithValue("@ImagePath",
                                string.IsNullOrWhiteSpace(_currentImagePath)
                                ? (object)DBNull.Value
                                : _currentImagePath);

                            newProductId = (int)cmd.ExecuteScalar();
                        }

                        // Lưu danh mục
                        using (var cmdCat = new SqlCommand(
                            "INSERT INTO ProductCategories(ProductId, CategoryId) VALUES(@PId, @CId);",
                            conn, tran))
                        {
                            cmdCat.Parameters.AddWithValue("@PId", newProductId);
                            cmdCat.Parameters.AddWithValue("@CId", categoryId);
                            cmdCat.ExecuteNonQuery();
                        }

                        tran.Commit();

                        MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Lỗi khi thêm sản phẩm:\n" + ex.Message,
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
