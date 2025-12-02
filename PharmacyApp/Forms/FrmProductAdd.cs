using System;
using System.Collections.Generic;      // ← thêm
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

            // 🟢 Gõ vào các ô rồi ENTER để load dữ liệu từ kho
            txtBarcode.KeyDown += SearchField_KeyDown;
            txtTenThuoc.KeyDown += SearchField_KeyDown;
            // Nếu có textbox mã sản phẩm thì gắn thêm:
             txtMaSP.KeyDown += SearchField_KeyDown;
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

            // Gợi ý tên thuốc
            LoadProductNameSuggestions();
        }


        // ========== BẮT PHÍM ENTER Ở Ô TÌM KIẾM ==========

        private void SearchField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoadInfoFromExistingProduct();   // ✅ gọi hàm đọc từ bảng Products
            }
        }


        // ========== LẤY THÔNG TIN TỪ KHO ==========

        /// <summary>
        /// Tìm thuốc trong kho theo mã / barcode / tên rồi đổ dữ liệu lên form.
        /// </summary>
//        private void LoadInfoFromWarehouse()
//        {
//            try
//            {
//                string barcode = txtBarcode.Text.Trim();
//                string tenThuoc = txtTenThuoc.Text.Trim();

//                // Không có gì để tìm thì thôi
//                if (string.IsNullOrEmpty(barcode) && string.IsNullOrEmpty(tenThuoc))
//                    return;

//                using (var conn = new SqlConnection(ConnStr))
//                using (var cmd = new SqlCommand())
//                {
//                    cmd.Connection = conn;
//                    var where = new System.Collections.Generic.List<string>();

//                    // 🔍 Điều kiện tìm theo Barcode
//                    if (!string.IsNullOrEmpty(barcode))
//                    {
//                        where.Add("p.Barcode = @Barcode");
//                        cmd.Parameters.AddWithValue("@Barcode", barcode);
//                    }

//                    // 🔍 Điều kiện tìm theo Tên thuốc
//                    if (!string.IsNullOrEmpty(tenThuoc))
//                    {
//                        where.Add("p.ProductName LIKE @ProductName");
//                        cmd.Parameters.AddWithValue("@ProductName", "%" + tenThuoc + "%");
//                    }

//                    // Phòng hờ – lẽ ra không rơi vào vì đã check ở trên
//                    if (where.Count == 0) return;

//                    cmd.CommandText = $@"
//SELECT TOP 1
//    p.ProductId,
//    p.ProductCode,
//    p.ProductName,
//    p.Barcode,
//    rd.UnitPrice   AS ImportPrice,
//    p.SalePrice,
//    rd.ExpiredDate,
//    rd.BatchNo,
//    p.Description
//FROM ReceiptDetails rd
//JOIN Receipts      r ON rd.ReceiptId = r.ReceiptId
//JOIN Products      p ON rd.ProductId = p.ProductId
//WHERE {string.Join(" OR ", where)}
//ORDER BY r.ReceiptDate DESC;      -- lấy lần nhập gần nhất";

//                    conn.Open();
//                    using (var reader = cmd.ExecuteReader())
//                    {
//                        if (!reader.Read())
//                        {
//                            MessageBox.Show("Không tìm thấy thông tin thuốc đã nhập kho.",
//                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                            return;
//                        }

//                        // 🟢 Đổ dữ liệu lên form

//                        // Nếu form có textbox Mã SP thì fill ở đây, còn không thì bỏ qua
//                        // txtMaSanPham.Text = reader["ProductCode"].ToString();

//                        // Barcode & Tên thuốc
//                        if (string.IsNullOrEmpty(txtBarcode.Text))
//                            txtBarcode.Text = reader["Barcode"]?.ToString();

//                        if (string.IsNullOrEmpty(txtTenThuoc.Text))
//                            txtTenThuoc.Text = reader["ProductName"]?.ToString();

//                        // Giá nhập
//                        if (reader["ImportPrice"] != DBNull.Value)
//                            txtGiaNhap.Text = Convert.ToDecimal(reader["ImportPrice"])
//                                .ToString("0");

//                        // Giá bán
//                        if (reader["SalePrice"] != DBNull.Value)
//                            txtGiaBan.Text = Convert.ToDecimal(reader["SalePrice"])
//                                .ToString("0");

//                        // Ngày hết hạn
//                        if (reader["ExpireDate"] != DBNull.Value)
//                            dtpExpireDate.Value = (DateTime)reader["ExpiredDate"];

//                        // Số lô – nếu bạn có textbox số lô
//                        if (reader["BatchNo"] != DBNull.Value)
//                            txtSoLo.Text = reader["BatchNo"].ToString();

//                        // Mô tả – chỉ fill nếu đang trống
//                        if (reader["Description"] != DBNull.Value &&
//                            string.IsNullOrWhiteSpace(txtMoTa.Text))
//                        {
//                            txtMoTa.Text = reader["Description"].ToString();
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Lỗi khi tải thông tin từ kho:\n" + ex.Message,
//                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }




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

            // Lấy dữ liệu từ form
            string name = txtTenThuoc.Text.Trim();
            string barcode = txtBarcode.Text.Trim();
            string codeInput = txtMaSP.Text.Trim();   // mã SP gõ tay (nếu có)
            decimal unitPrice = decimal.Parse(txtGiaNhap.Text.Trim());

            decimal salePrice;
            if (!decimal.TryParse(txtGiaBan.Text.Trim(), out salePrice))
                salePrice = Math.Round(unitPrice * 1.2m, 0);

            int categoryId = (int)cboCategory.SelectedValue;
            string unit = "Hộp"; // default

            string description = string.IsNullOrWhiteSpace(txtMoTa.Text)
                                    ? null
                                    : txtMoTa.Text.Trim();

            DateTime? expired = null;
            try
            {
                expired = dtpExpireDate.Value.Date;
            }
            catch { }

            using (var conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        int productId;        // sẽ dùng chung cho cả update / insert
                        int? existingId = null;

                        // ===== 1. THỬ TÌM SẢN PHẨM ĐÃ NHẬP KHO (IsActive = 0) THEO MÃ / BARCODE =====
                        using (var cmdFind = new SqlCommand())
                        {
                            cmdFind.Connection = conn;
                            cmdFind.Transaction = tran;

                            var where = new List<string>();
                            string sqlFind = "SELECT TOP 1 ProductId FROM Products WHERE IsActive = 0";

                            if (!string.IsNullOrWhiteSpace(codeInput))
                            {
                                where.Add("ProductCode = @Code");
                                cmdFind.Parameters.AddWithValue("@Code", codeInput);
                            }

                            if (!string.IsNullOrWhiteSpace(barcode))
                            {
                                where.Add("Barcode = @Barcode");
                                cmdFind.Parameters.AddWithValue("@Barcode", barcode);
                            }

                            // Chỉ tìm khi có ít nhất 1 điều kiện
                            if (where.Count > 0)
                            {
                                sqlFind += " AND (" + string.Join(" OR ", where) + ")";
                                cmdFind.CommandText = sqlFind;

                                var obj = cmdFind.ExecuteScalar();
                                if (obj != null && obj != DBNull.Value)
                                    existingId = Convert.ToInt32(obj);
                            }
                        }

                        // ===== 2. NẾU TÌM THẤY → UPDATE & KÍCH HOẠT LẠI (IsActive = 1) =====
                        if (existingId.HasValue)
                        {
                            using (var cmdUpdate = new SqlCommand(@"
UPDATE Products
SET ProductName = @Name,
    Barcode     = @Barcode,
    Unit        = @Unit,
    UnitPrice   = @UnitPrice,
    SalePrice   = @SalePrice,
    Description = @Description,
    ExpiredDate = @ExpiredDate,
    CategoryId  = @CategoryId,
    ImagePath   = @ImagePath,
    IsActive    = 1
WHERE ProductId = @Id;", conn, tran))
                            {
                                cmdUpdate.Parameters.AddWithValue("@Name", name);
                                cmdUpdate.Parameters.AddWithValue("@Barcode",
                                    string.IsNullOrWhiteSpace(barcode) ? (object)DBNull.Value : barcode);
                                cmdUpdate.Parameters.AddWithValue("@Unit", unit);
                                cmdUpdate.Parameters.AddWithValue("@UnitPrice", unitPrice);
                                cmdUpdate.Parameters.AddWithValue("@SalePrice", salePrice);
                                cmdUpdate.Parameters.AddWithValue("@Description",
                                    (object)description ?? DBNull.Value);
                                cmdUpdate.Parameters.AddWithValue("@ExpiredDate",
                                    expired.HasValue ? (object)expired.Value : DBNull.Value);
                                cmdUpdate.Parameters.AddWithValue("@CategoryId", categoryId);
                                cmdUpdate.Parameters.AddWithValue("@ImagePath",
                                    string.IsNullOrWhiteSpace(_currentImagePath)
                                        ? (object)DBNull.Value
                                        : _currentImagePath);
                                cmdUpdate.Parameters.AddWithValue("@Id", existingId.Value);

                                cmdUpdate.ExecuteNonQuery();
                            }

                            productId = existingId.Value;
                        }
                        else
                        {
                            // ===== 3. KHÔNG TÌM THẤY → TẠO SẢN PHẨM MỚI =====

                            // Nếu người dùng có nhập mã SP thì ưu tiên dùng, ngược lại tự sinh
                            string productCode = string.IsNullOrWhiteSpace(codeInput)
                                                    ? GenerateProductCode()
                                                    : codeInput;

                            using (var cmd = new SqlCommand(@"
INSERT INTO Products
    (ProductCode, ProductName, Barcode, Unit, UnitPrice, SalePrice,
     StockQuantity, Description, Manufacturer, ExpiredDate, SupplierId, ImagePath,
     CategoryId, IsActive)
VALUES
    (@ProductCode, @ProductName, @Barcode, @Unit, @UnitPrice, @SalePrice,
     0, @Description, NULL, @ExpiredDate, NULL, @ImagePath,
     @CategoryId, 1);

SELECT CAST(SCOPE_IDENTITY() AS INT);", conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@ProductCode", productCode);
                                cmd.Parameters.AddWithValue("@ProductName", name);
                                cmd.Parameters.AddWithValue("@Barcode",
                                    string.IsNullOrWhiteSpace(barcode) ? (object)DBNull.Value : barcode);
                                cmd.Parameters.AddWithValue("@Unit", unit);
                                cmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                                cmd.Parameters.AddWithValue("@SalePrice", salePrice);
                                cmd.Parameters.AddWithValue("@Description",
                                    (object)description ?? DBNull.Value);
                                cmd.Parameters.AddWithValue("@ExpiredDate",
                                    expired.HasValue ? (object)expired.Value : DBNull.Value);
                                cmd.Parameters.AddWithValue("@ImagePath",
                                    string.IsNullOrWhiteSpace(_currentImagePath)
                                        ? (object)DBNull.Value
                                        : _currentImagePath);
                                cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                                cmd.Parameters.AddWithValue("@IsActive", 1);

                                productId = (int)cmd.ExecuteScalar();

                                // Hiển thị lại mã SP vừa sinh lên textbox
                                txtMaSP.Text = productCode;
                            }
                        }

                        // ===== 4. ĐẢM BẢO CÓ BẢNG NỐI ProductCategories =====
                        using (var cmdCat = new SqlCommand(@"
IF NOT EXISTS (SELECT 1 FROM ProductCategories WHERE ProductId = @PId AND CategoryId = @CId)
    INSERT INTO ProductCategories(ProductId, CategoryId)
    VALUES (@PId, @CId);", conn, tran))
                        {
                            cmdCat.Parameters.AddWithValue("@PId", productId);
                            cmdCat.Parameters.AddWithValue("@CId", categoryId);
                            cmdCat.ExecuteNonQuery();
                        }

                        // OK
                        tran.Commit();

                        MessageBox.Show("Lưu sản phẩm thành công!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show("Lỗi khi lưu sản phẩm:\n" + ex.Message,
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadInfoFromExistingProduct()
        {
            try
            {
                // 🔹 Lấy dữ liệu người dùng gõ
                string productCode = txtMaSP.Text.Trim();   // ĐỔI tên control cho đúng
                string barcode = txtBarcode.Text.Trim();
                string name = txtTenThuoc.Text.Trim();

                if (string.IsNullOrEmpty(productCode) &&
                    string.IsNullOrEmpty(barcode) &&
                    string.IsNullOrEmpty(name))
                    return;

                using (var conn = new SqlConnection(ConnStr))
                using (var cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    var where = new List<string>();

                    if (!string.IsNullOrEmpty(productCode))
                    {
                        where.Add("ProductCode = @Code");
                        cmd.Parameters.AddWithValue("@Code", productCode);
                    }

                    if (!string.IsNullOrEmpty(barcode))
                    {
                        where.Add("Barcode = @Barcode");
                        cmd.Parameters.AddWithValue("@Barcode", barcode);
                    }

                    if (!string.IsNullOrEmpty(name))
                    {
                        where.Add("ProductName LIKE @Name");
                        cmd.Parameters.AddWithValue("@Name", "%" + name + "%");
                    }

                    cmd.CommandText = $@"
SELECT TOP 1
    ProductId,
    ProductCode,
    ProductName,
    Barcode,
    UnitPrice,
    SalePrice,
    ExpiredDate,
    Description,
    CategoryId,
    ImagePath
FROM Products
WHERE {string.Join(" OR ", where)}
ORDER BY ProductId DESC;";

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show("Không tìm thấy sản phẩm nào khớp với thông tin đã nhập.",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // ===== FILL LÊN FORM =====

                        // 🟢 MÃ SẢN PHẨM – luôn gán
                        txtMaSP.Text = reader["ProductCode"].ToString();

                        // Barcode & Tên thuốc – nếu thích có thể luôn gán, ở đây mình cũng gán luôn cho chắc
                        txtBarcode.Text = reader["Barcode"]?.ToString();
                        txtTenThuoc.Text = reader["ProductName"]?.ToString();

                        // 🟢 GIÁ NHẬP – luôn gán (KHÔNG check IsNullOrEmpty nữa)
                        if (reader["UnitPrice"] != DBNull.Value)
                            txtGiaNhap.Text = Convert.ToDecimal(reader["UnitPrice"])
                                .ToString("0");

                        // 🟢 GIÁ BÁN – luôn gán
                        if (reader["SalePrice"] != DBNull.Value)
                            txtGiaBan.Text = Convert.ToDecimal(reader["SalePrice"])
                                .ToString("0");

                        // Hạn dùng
                        if (reader["ExpiredDate"] != DBNull.Value)
                            dtpExpireDate.Value = (DateTime)reader["ExpiredDate"];

                        // Mô tả – nếu bạn muốn luôn override thì bỏ if, còn muốn chỉ fill khi trống thì để nguyên:
                        if (string.IsNullOrWhiteSpace(txtMoTa.Text) &&
                            reader["Description"] != DBNull.Value)
                        {
                            txtMoTa.Text = reader["Description"].ToString();
                        }

                        // Nhóm ngành theo CategoryId
                        if (reader["CategoryId"] != DBNull.Value)
                        {
                            try
                            {
                                cboCategory.SelectedValue = (int)reader["CategoryId"];
                            }
                            catch { }
                        }

                        // Ảnh nếu có lưu ImagePath
                        if (reader["ImagePath"] != DBNull.Value)
                        {
                            string path = reader["ImagePath"].ToString();
                            if (System.IO.File.Exists(path))
                            {
                                _currentImagePath = path;
                                picImage.Image = Image.FromFile(path);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin sản phẩm:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private AutoCompleteStringCollection _productNameAuto;

        private void LoadProductNameSuggestions()
        {
            _productNameAuto = new AutoCompleteStringCollection();

            using (var conn = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand(
                "SELECT DISTINCT ProductName FROM Products WHERE ProductName IS NOT NULL ORDER BY ProductName",
                conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader["ProductName"].ToString();
                        if (!string.IsNullOrWhiteSpace(name))
                            _productNameAuto.Add(name);
                    }
                }
            }

            // Gán AutoComplete
            txtTenThuoc.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtTenThuoc.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtTenThuoc.AutoCompleteCustomSource = _productNameAuto;
        }


    }
}
