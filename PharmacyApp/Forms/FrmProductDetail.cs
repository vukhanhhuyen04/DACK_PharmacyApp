using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PharmacyApp.Forms
{
    public partial class FrmProductDetail : Form
    {
        private readonly int _productId;
        private string ConnStr => Program.ConnStr;

        // lưu đường dẫn ảnh hiện tại (ImagePath trong DB)
        private string _currentImagePath;

        public FrmProductDetail(int productId)
        {
            InitializeComponent();
            _productId = productId;

            this.Load += FrmProductDetail_Load;
            btnBrowseImage.Click += BtnBrowseImage_Click;
            btnEdit.Click += BtnEdit_Click;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
        }

        // ============== LOAD FORM ==============

        private void FrmProductDetail_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadProduct();
            SetEditMode(false);
        }

        private void LoadCategories()
        {
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

        private void LoadProduct()
        {
            using (var conn = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand(
                @"SELECT ProductId, ProductCode, ProductName, Manufacturer, SalePrice, Barcode, ImagePath
          FROM Products
          WHERE ProductId = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", _productId);
                conn.Open();

                using (var rd = cmd.ExecuteReader())
                {
                    if (!rd.Read())
                    {
                        MessageBox.Show("Không tìm thấy sản phẩm.", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        return;
                    }

                    txtName.Text = rd["ProductName"].ToString();
                    txtCompany.Text = rd["Manufacturer"].ToString();
                    txtPrice.Text = rd["SalePrice"] == DBNull.Value
                                    ? "0"
                                    : Convert.ToDecimal(rd["SalePrice"]).ToString("0.##");
                    txtBarcode.Text = rd["Barcode"].ToString();

                    _currentImagePath = rd["ImagePath"] == DBNull.Value
                                        ? null
                                        : rd["ImagePath"].ToString();

                    if (!string.IsNullOrWhiteSpace(_currentImagePath) && File.Exists(_currentImagePath))
                    {
                        try { picImage.Image = Image.FromFile(_currentImagePath); }
                        catch { picImage.Image = null; }
                    }
                    else
                    {
                        picImage.Image = null;
                    }
                }

                // nếu bạn có bảng ProductCategories thì load CategoryId ở đây,
                // còn chưa làm thì có thể bỏ đoạn dưới
                using (var cmdCat = new SqlCommand(
                    "SELECT TOP 1 CategoryId FROM ProductCategories WHERE ProductId = @Id", conn))
                {
                    cmdCat.Parameters.AddWithValue("@Id", _productId);
                    var catIdObj = cmdCat.ExecuteScalar();
                    if (catIdObj != null && catIdObj != DBNull.Value)
                        cboCategory.SelectedValue = Convert.ToInt32(catIdObj);
                }
            }
        }


        // ============== EDIT MODE ==============

        private void SetEditMode(bool editing)
        {
            txtName.ReadOnly = !editing;
            txtCompany.ReadOnly = !editing;
            txtPrice.ReadOnly = !editing;
            txtBarcode.ReadOnly = !editing;
            cboCategory.Enabled = editing;
            btnBrowseImage.Enabled = editing;

            btnEdit.Visible = !editing;
            btnSave.Visible = editing;
            btnCancel.Visible = editing;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            SetEditMode(true);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            LoadProduct();
            SetEditMode(false);
        }

        // ============== ẢNH ==============

        private void BtnBrowseImage_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Ảnh|*.png;*.jpg;*.jpeg;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _currentImagePath = ofd.FileName;      // lưu đường dẫn
                    picImage.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        // ============== SAVE ==============

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            decimal price = decimal.Parse(txtPrice.Text.Trim());
            int categoryId = (int)cboCategory.SelectedValue;

            using (var conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. UPDATE bảng Products
                        using (var cmd = new SqlCommand(
                            @"UPDATE Products SET
                            ProductName = @Name,
                            Manufacturer = @Manufacturer,
                            SalePrice    = @SalePrice,
                            Barcode      = @Barcode,
                            ImagePath    = @ImagePath
                      WHERE ProductId = @Id", conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@Id", _productId);
                            cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                            cmd.Parameters.AddWithValue("@Manufacturer", txtCompany.Text.Trim());
                            cmd.Parameters.AddWithValue("@SalePrice", price);
                            cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text.Trim());

                            if (string.IsNullOrWhiteSpace(_currentImagePath))
                                cmd.Parameters.AddWithValue("@ImagePath", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("@ImagePath", _currentImagePath);

                            cmd.ExecuteNonQuery();
                        }

                        // 2. (nếu dùng ProductCategories) cập nhật danh mục chính
                        using (var cmdDel = new SqlCommand(
                            "DELETE FROM ProductCategories WHERE ProductId = @Id", conn, tran))
                        {
                            cmdDel.Parameters.AddWithValue("@Id", _productId);
                            cmdDel.ExecuteNonQuery();
                        }

                        using (var cmdIns = new SqlCommand(
                            "INSERT INTO ProductCategories(ProductId, CategoryId) VALUES(@PId, @CId)", conn, tran))
                        {
                            cmdIns.Parameters.AddWithValue("@PId", _productId);
                            cmdIns.Parameters.AddWithValue("@CId", categoryId);
                            cmdIns.ExecuteNonQuery();
                        }

                        tran.Commit();

                        MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        SetEditMode(false);
                        this.DialogResult = DialogResult.OK;
                    }
                    catch (SqlException ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Lỗi khi cập nhật sản phẩm:\n" + ex.Message,
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sản phẩm.");
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPrice.Text) ||
                !decimal.TryParse(txtPrice.Text.Trim(), out _))
            {
                MessageBox.Show("Giá bán không hợp lệ.");
                txtPrice.Focus();
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
    }
}
