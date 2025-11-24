using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PharmacyApp.Forms
{
    public partial class FrmProductDetail : Form
    {
        private readonly int _productId;
        private string ConnStr => Program.ConnStr;

        // nếu cần giữ state riêng
        private byte[] _currentImageBytes;

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
                @"SELECT TOP 1 ProductId, ProductName, CompanyName, Price, Barcode, CategoryId, Image
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
                    txtCompany.Text = rd["CompanyName"].ToString();
                    txtPrice.Text = Convert.ToDecimal(rd["Price"]).ToString("0.##");
                    txtBarcode.Text = rd["Barcode"].ToString();

                    if (rd["CategoryId"] != DBNull.Value)
                        cboCategory.SelectedValue = (int)rd["CategoryId"];

                    if (rd["Image"] != DBNull.Value)
                    {
                        _currentImageBytes = (byte[])rd["Image"];
                        picImage.Image = BytesToImage(_currentImageBytes);
                    }
                    else
                    {
                        _currentImageBytes = null;
                        picImage.Image = null; // hoặc ảnh default nếu có
                        // picImage.Image = Properties.Resources.demo_medicine;
                    }
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
            // load lại dữ liệu cũ từ DB
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
                    picImage.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        private Image BytesToImage(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0) return null;
            using (var ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

        private byte[] ImageToBytes(Image img)
        {
            if (img == null) return null;
            using (var ms = new MemoryStream())
            {
                img.Save(ms, img.RawFormat);
                return ms.ToArray();
            }
        }

        // ============== SAVE ==============
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            decimal price = decimal.Parse(txtPrice.Text.Trim());
            int categoryId = (int)cboCategory.SelectedValue;
            byte[] imgBytes = ImageToBytes(picImage.Image);

            using (var conn = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand(
                @"UPDATE Products SET
                        ProductName = @Name,
                        CompanyName = @Company,
                        Price       = @Price,
                        Barcode     = @Barcode,
                        CategoryId  = @CategoryId,
                        Image       = @Image
                  WHERE ProductId = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", _productId);
                cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@Company", txtCompany.Text.Trim());
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Barcode", txtBarcode.Text.Trim());
                cmd.Parameters.AddWithValue("@CategoryId", categoryId);

                if (imgBytes == null)
                    cmd.Parameters.Add("@Image", SqlDbType.VarBinary).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@Image", SqlDbType.VarBinary).Value = imgBytes;

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SetEditMode(false);
                    this.DialogResult = DialogResult.OK; // để UC_Catalog reload nếu muốn
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật sản phẩm:\n" + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
