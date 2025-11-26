using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyApp.UserControls

{
    public partial class UC_Staff : UserControl
    {
        
        // ==============================
        //       BIẾN TRẠNG THÁI
        // ==============================
        private enum EditMode
        {
            None,
            Add,
            Edit
        }
        private EditMode _mode = EditMode.None;
        private int? _currentStaffId = null;  // khóa chính trong bảng Staff
        public UC_Staff()
        {
            InitializeComponent();
            // Gán event ở đây cho dễ quản lý
            this.Load += UC_Staff_Load;
            btnXoa.Click += BtnXoa_Click;

            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnLuu.Click += BtnLuu_Click;
            btnHuy.Click += BtnHuy_Click;
            btnTim.Click += BtnTim_Click;
            dgvStaff.CellFormatting += DgvStaff_CellFormatting;
            tglTrangThai.CheckedChanged += TglTrangThai_CheckedChanged;

            dgvStaff.SelectionChanged += DgvStaff_SelectionChanged;
            // ⭐ Tìm nhanh
            txtTimNhanh.TextChanged += TxtTimNhanh_TextChanged;
            txtTimNhanh.KeyDown += TxtTimNhanh_KeyDown;
        }
        // ==============================
        //       LOAD FORM
        // ==============================
        private void UC_Staff_Load(object sender, EventArgs e)
        {
            
            LoadStaffList();
            SetFormMode(EditMode.None);
        }

        private void DgvStaff_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvStaff.Columns[e.ColumnIndex].Name == "colActive")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    bool active = Convert.ToBoolean(e.Value);
                    e.Value = active ? "Hoạt động" : "Không hoạt động";
                    e.FormattingApplied = true;
                }
            }
        }
        private void TglTrangThai_CheckedChanged(object sender, EventArgs e)
        {
            lblStatusText.Text = tglTrangThai.Checked ? "Hoạt động" : "Không hoạt động";
        }





        // Hàm load danh sách dược sĩ
        private void LoadStaffList(string keyword = null)
        {
            using (var conn = new SqlConnection(Program.ConnStr))
            {
                conn.Open();

                string sql = @"
            SELECT StaffId,
                   StaffCode,
                   FullName,
                   Gender,
                   Email,
                   Phone,
                   HireDate,
                   Degree,
                   LicenseExpireDate,
                   IsActive
            FROM Staff
            WHERE (@kw IS NULL
                   OR FullName  LIKE '%' + @kw + '%'
                   OR StaffCode LIKE '%' + @kw + '%'
                   OR Phone     LIKE '%' + @kw + '%'
                   OR Email     LIKE '%' + @kw + '%')
            ORDER BY FullName";

                using (var da = new SqlDataAdapter(sql, conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@kw",
                        string.IsNullOrWhiteSpace(keyword) ? (object)DBNull.Value : keyword.Trim());

                    var dt = new DataTable();
                    da.Fill(dt);

                    dgvStaff.AutoGenerateColumns = false;   // ❗ LUÔN là false
                    dgvStaff.DataSource = dt;

                    // Ẩn cột Id nội bộ, chỉ cho thấy Mã nhân viên (StaffCode)
                    colStaffId.Visible = false;
                }
            }
        }


        // ==============================
        //       HỖ TRỢ FORM
        // ==============================
        private void ClearForm()
        {
            txtMaNV.Text = "";
            txtHoTen.Text = "";
            cboGioiTinh.SelectedIndex = -1;
            txtEmail.Text = "";
            txtSDT.Text = "";
            dtNgayVaoLam.Value = DateTime.Today;
            cboBangCap.SelectedIndex = -1;
            //dtNgayHetHanBang.Value = DateTime.Today;
            tglTrangThai.Checked = true; // mặc định hoạt động

            _currentStaffId = null;
        }

        private void FillFormFromRow(DataGridViewRow row)
        {

            if (row == null) return;

            // Lấy object gốc đang bind (DataRowView)
            var drv = row.DataBoundItem as DataRowView;
            if (drv == null) return;

            // Đọc từ DataTable theo tên cột trong bảng Staff
            _currentStaffId = drv["StaffId"] != DBNull.Value
                ? Convert.ToInt32(drv["StaffId"])
                : (int?)null;

            txtMaNV.Text = drv["StaffCode"]?.ToString();
            txtHoTen.Text = drv["FullName"]?.ToString();
            cboGioiTinh.Text = drv["Gender"]?.ToString();
            txtEmail.Text = drv["Email"]?.ToString();
            txtSDT.Text = drv["Phone"]?.ToString();

            if (drv["HireDate"] != DBNull.Value)
                dtNgayVaoLam.Value = Convert.ToDateTime(drv["HireDate"]);

            cboBangCap.Text = drv["Degree"]?.ToString();

            // Trạng thái
            lblStatusText.Text = tglTrangThai.Checked ? "Hoạt động" : "Không hoạt động";

            tglTrangThai.Checked = drv["IsActive"] != DBNull.Value
                && Convert.ToBoolean(drv["IsActive"]);
            if (drv["LicenseExpireDate"] != DBNull.Value)
                dtLicenseExpire.Value = Convert.ToDateTime(drv["LicenseExpireDate"]);
            else
                dtLicenseExpire.Value = DateTime.Today;

        }


        private void SetFormMode(EditMode mode)
        {
            _mode = mode;

            bool isEditing = (mode == EditMode.Add || mode == EditMode.Edit);

            // Cho phép nhập
            txtHoTen.Enabled = isEditing;
            cboGioiTinh.Enabled = isEditing;
            txtEmail.Enabled = isEditing;
            txtSDT.Enabled = isEditing;
            dtNgayVaoLam.Enabled = isEditing;
            cboBangCap.Enabled = isEditing;
            //dtNgayHetHanBang.Enabled = isEditing;
            tglTrangThai.Enabled = isEditing;

            // Mã NV thường không cho sửa khi Edit
            txtMaNV.Enabled = (mode == EditMode.Add);

            // Nút
            btnThem.Enabled = (mode == EditMode.None);
            btnSua.Enabled = (mode == EditMode.None && dgvStaff.CurrentRow != null);
            btnLuu.Enabled = isEditing;
            btnHuy.Enabled = isEditing;
        }

        // Khi chọn dòng khác trên grid → fill form
        private void DgvStaff_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStaff.CurrentRow == null)
                return;

            FillFormFromRow(dgvStaff.CurrentRow);
        }


        // ==============================
        //       CÁC NÚT CHỨC NĂNG
        // ==============================
        private void BtnThem_Click(object sender, EventArgs e)
        {
            ClearForm();

            txtMaNV.Text = GenerateNewStaffCode();  // ⭐ tự sinh DSxxx
            txtMaNV.Enabled = false;

            tglTrangThai.Checked = true;
            SetFormMode(EditMode.Add);
        }




        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (dgvStaff.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một dược sĩ để sửa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FillFormFromRow(dgvStaff.CurrentRow);
            SetFormMode(EditMode.Edit);
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            // Khôi phục lại dữ liệu từ dòng đang chọn
            if (dgvStaff.CurrentRow != null)
                FillFormFromRow(dgvStaff.CurrentRow);
            else
                ClearForm();

            SetFormMode(EditMode.None);
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            string kw = txtTimNhanh.Text.Trim();
            // nếu trống thì load tất cả
            if (string.IsNullOrWhiteSpace(kw))
                LoadStaffList(null);
            else
                LoadStaffList(kw);
        }


        // ==============================
        //       LƯU (THÊM / SỬA)
        // ==============================
        private void BtnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            if (_mode == EditMode.Add)
            {
                InsertStaff();
            }
            else if (_mode == EditMode.Edit)
            {
                UpdateStaff();
            }

            LoadStaffList();
            SetFormMode(EditMode.None);
        }

        // ==============================
        //       VALIDATE
        // ==============================
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtHoTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
                return false;
            }

            // Ví dụ kiểm tra độ dài / chỉ số
            if (!txtSDT.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa chữ số.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
                return false;
            }

            if (dtNgayVaoLam.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Ngày vào làm không được lớn hơn ngày hiện tại.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtNgayVaoLam.Focus();
                return false;
            }

            // Có thể thêm validate Email ở đây nếu cần

            return true;
        }

        // ==============================
        //       THÊM MỚI DB
        // ==============================
        private void InsertStaff()
        {
            // Bắt buộc phải có Email để tạo tài khoản
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập Email để tạo tài khoản đăng nhập.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            string email = txtEmail.Text.Trim();
            string fullName = txtHoTen.Text.Trim();
            string phone = txtSDT.Text.Trim();
            string gender = string.IsNullOrEmpty(cboGioiTinh.Text) ? null : cboGioiTinh.Text;
            string degree = string.IsNullOrEmpty(cboBangCap.Text) ? null : cboBangCap.Text;
            DateTime hireDate = dtNgayVaoLam.Value.Date;
            DateTime? licenseExpire = dtLicenseExpire.Value.Date;
            bool isActive = tglTrangThai.Checked;

            string staffCode = txtMaNV.Text.Trim();
            string defaultPassword = "12345";   // mật khẩu mặc định
            string role = "Dược sĩ";            // role trong bảng Users

            using (var conn = new SqlConnection(Program.ConnStr))
            {
                conn.Open();

                // 1. Kiểm tra email đã tồn tại trong Users chưa
                using (var checkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Users WHERE Email = @Email", conn))
                {
                    checkCmd.Parameters.AddWithValue("@Email", email);
                    int exists = (int)checkCmd.ExecuteScalar();
                    if (exists > 0)
                    {
                        MessageBox.Show("Email này đã được sử dụng cho tài khoản khác. " +
                                        "Vui lòng nhập email khác.",
                            "Trùng email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // 2. Tạo User + Staff trong 1 lệnh
                string sql = @"
DECLARE @UserId INT;

INSERT INTO Users (FullName, Email, Password, Role, CreatedAt)
VALUES (@FullName, @Email, @Password, @Role, GETDATE());

SET @UserId = SCOPE_IDENTITY();

INSERT INTO Staff
    (StaffCode, FullName, Gender, Email, Phone,
     HireDate, Degree, LicenseExpireDate, IsActive, CreatedAt, UserId)
VALUES
    (@StaffCode, @FullName, @Gender, @Email, @Phone,
     @HireDate, @Degree, @LicenseExpireDate, @IsActive, GETDATE(), @UserId);";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    // Users
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", defaultPassword);
                    cmd.Parameters.AddWithValue("@Role", role);

                    // Staff
                    cmd.Parameters.AddWithValue("@StaffCode", staffCode);
                    cmd.Parameters.AddWithValue("@Gender",
                        string.IsNullOrEmpty(gender) ? (object)DBNull.Value : gender);
                    cmd.Parameters.AddWithValue("@Phone",
                        string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone);
                    cmd.Parameters.AddWithValue("@HireDate", hireDate);
                    cmd.Parameters.AddWithValue("@Degree",
                        string.IsNullOrEmpty(degree) ? (object)DBNull.Value : degree);

                    cmd.Parameters.AddWithValue("@LicenseExpireDate",
                        licenseExpire.HasValue ? (object)licenseExpire.Value : DBNull.Value);

                    cmd.Parameters.AddWithValue("@IsActive", isActive);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Đã thêm dược sĩ mới và tạo tài khoản đăng nhập (mật khẩu: 12345).",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        // ==============================
        //       CẬP NHẬT DB
        // ==============================
        private void UpdateStaff()
        {
            if (_currentStaffId == null)
            {
                MessageBox.Show("Không xác định được dược sĩ cần cập nhật.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string email = txtEmail.Text.Trim();
            string fullName = txtHoTen.Text.Trim();
            string phone = txtSDT.Text.Trim();
            string gender = string.IsNullOrEmpty(cboGioiTinh.Text) ? null : cboGioiTinh.Text;
            string degree = string.IsNullOrEmpty(cboBangCap.Text) ? null : cboBangCap.Text;
            DateTime hireDate = dtNgayVaoLam.Value.Date;
            DateTime? licenseExpire = dtLicenseExpire.Value.Date;
            bool isActive = tglTrangThai.Checked;

            using (var conn = new SqlConnection(Program.ConnStr))
            {
                conn.Open();

                string sql = @"
UPDATE s
SET s.FullName          = @FullName,
    s.Gender            = @Gender,
    s.Email             = @Email,
    s.Phone             = @Phone,
    s.HireDate          = @HireDate,
    s.Degree            = @Degree,
    s.LicenseExpireDate = @LicenseExpireDate,
    s.IsActive          = @IsActive
FROM Staff s
WHERE s.StaffId = @StaffId;

-- Đồng bộ sang bảng Users (nếu Staff có UserId)
UPDATE u
SET u.FullName = @FullName,
    u.Email    = @Email
FROM Users u
JOIN Staff s ON s.UserId = u.UserId
WHERE s.StaffId = @StaffId;";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@StaffId", _currentStaffId.Value);
                    cmd.Parameters.AddWithValue("@FullName", fullName);

                    cmd.Parameters.AddWithValue("@Gender",
                        string.IsNullOrEmpty(gender) ? (object)DBNull.Value : gender);

                    cmd.Parameters.AddWithValue("@Email",
                        string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);

                    cmd.Parameters.AddWithValue("@Phone",
                        string.IsNullOrEmpty(phone) ? (object)DBNull.Value : phone);

                    cmd.Parameters.AddWithValue("@HireDate", hireDate);

                    cmd.Parameters.AddWithValue("@Degree",
                        string.IsNullOrEmpty(degree) ? (object)DBNull.Value : degree);

                    cmd.Parameters.AddWithValue("@LicenseExpireDate",
                        licenseExpire.HasValue ? (object)licenseExpire.Value : DBNull.Value);

                    cmd.Parameters.AddWithValue("@IsActive", isActive);

                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Cập nhật thông tin dược sĩ thành công.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void txtSDt_Click(object sender, EventArgs e)
        {

        }

        private void txtMaNV_Click(object sender, EventArgs e)
        {

        }
        private string GenerateNewStaffCode()
        {
            using (var conn = new SqlConnection(Program.ConnStr))
            {
                conn.Open();

                string sql = @"
            SELECT TOP 1 StaffCode
            FROM Staff
            WHERE StaffCode LIKE 'DS%'
            ORDER BY StaffId DESC";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    var result = cmd.ExecuteScalar();

                    // Nếu chưa có ai trong bảng Staff → bắt đầu từ DS001
                    if (result == null || result == DBNull.Value)
                        return "DS001";

                    string lastCode = result.ToString();   // ví dụ: "DS012"

                    // Tách phần số (bỏ 2 ký tự 'D','S')
                    int number = 0;
                    if (!int.TryParse(lastCode.Substring(2), out number))
                    {
                        // Nếu parse lỗi thì cũng quay về DS001 cho chắc
                        return "DS001";
                    }

                    number++; // tăng lên 1

                    // Ghép lại dạng DS + 3 số
                    return "DS" + number.ToString("000");   // DS013
                }
            }
        }


        // Gõ tới đâu lọc tới đó
        private void TxtTimNhanh_TextChanged(object sender, EventArgs e)
        {
            string kw = txtTimNhanh.Text.Trim();
            LoadStaffList(string.IsNullOrWhiteSpace(kw) ? null : kw);
        }

        // Nhấn Enter trong ô tìm = bấm nút Tìm
        private void TxtTimNhanh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                BtnTim_Click(sender, EventArgs.Empty);
            }
        }
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            if (dgvStaff.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy StaffId hiện tại
            var drv = dgvStaff.CurrentRow.DataBoundItem as DataRowView;
            if (drv == null || drv["StaffId"] == DBNull.Value)
            {
                MessageBox.Show("Không xác định được nhân viên cần xóa.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int staffId = Convert.ToInt32(drv["StaffId"]);

            var confirm = MessageBox.Show(
                "Bạn có chắc muốn xóa nhân viên này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            using (var conn = new SqlConnection(Program.ConnStr))
            {
                conn.Open();
                string sql = "DELETE FROM Staff WHERE StaffId = @StaffId";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@StaffId", staffId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Đã xóa nhân viên.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // refresh lại danh sách & form
            LoadStaffList(string.IsNullOrWhiteSpace(txtTimNhanh.Text)
                ? null
                : txtTimNhanh.Text.Trim());
            ClearForm();
            SetFormMode(EditMode.None);
        }

        private void txtTimNhanh_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
