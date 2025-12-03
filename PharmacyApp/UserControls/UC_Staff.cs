using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using PharmacyApp;
using PharmacyApp.Security;   // ⬅ QUAN TRỌNG

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

            this.Load += UC_Staff_Load;

            btnXoa.Click += BtnXoa_Click;
            btnThem.Click += BtnThem_Click;
            btnSua.Click += BtnSua_Click;
            btnLuu.Click += BtnLuu_Click;
            btnHuy.Click += BtnHuy_Click;
            //btnTim.Click += BtnTim_Click;

            dgvStaff.CellFormatting += DgvStaff_CellFormatting;
            dgvStaff.SelectionChanged += DgvStaff_SelectionChanged;
            dgvStaff.CellClick += dgvStaff_CellClick;

            tglTrangThai.CheckedChanged += TglTrangThai_CheckedChanged;

            txtTimNhanh.TextChanged += TxtTimNhanh_TextChanged;
            txtTimNhanh.KeyDown += TxtTimNhanh_KeyDown;
        }

        // helper permission
        private bool CanView => PermissionService.Has(PermissionService.STAFF_VIEW);
        private bool CanEdit => PermissionService.Has(PermissionService.STAFF_EDIT);
        private bool CanDelete => PermissionService.Has(PermissionService.STAFF_DELETE);

        // ==============================
        //       LOAD FORM
        // ==============================
        private void UC_Staff_Load(object sender, EventArgs e)
        {
            if (!CanView)
            {
                MessageBox.Show("Bạn không có quyền xem danh sách nhân viên.", "Phân quyền",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Enabled = false;
                return;
            }

            LoadStaffList();
            SetFormMode(EditMode.None);
            ApplyPermissions();
        }

        private void ApplyPermissions()
        {
            // Cho xem grid và tìm kiếm nếu có STAFF_VIEW
            dgvStaff.Enabled = CanView;
            txtTimNhanh.Enabled = CanView;
            //btnTim.Enabled = CanView;

            // Nút thêm/sửa/lưu/hủy tuỳ theo STAFF_EDIT
            btnThem.Enabled = CanEdit;
            btnSua.Enabled = CanEdit;
            btnLuu.Enabled = CanEdit;
            btnHuy.Enabled = CanEdit;

            // Xóa cần STAFF_DELETE
            btnXoa.Enabled = CanDelete;

            // Ô nhập dữ liệu: chỉ cho nhập nếu có quyền sửa
            bool canEditFields = CanEdit;

            txtHoTen.Enabled = canEditFields;
            cboGioiTinh.Enabled = canEditFields;
            txtEmail.Enabled = canEditFields;
            txtSDT.Enabled = canEditFields;
            dtNgayVaoLam.Enabled = canEditFields;
            dtNgaySinh.Enabled = canEditFields;
            cboBangCap.Enabled = canEditFields;
            dtLicenseExpire.Enabled = canEditFields;
            tglTrangThai.Enabled = canEditFields;
            txtMaNV.Enabled = false; // mã NV luôn tự sinh
            cboVaiTro.Enabled = canEditFields;
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
SELECT 
    s.StaffId,
    s.StaffCode,
    s.FullName,
    s.Gender,
    s.BirthDate,
    s.Email,
    s.Phone,
    s.HireDate,
    s.Degree,
    s.LicenseExpireDate,
    u.Role,
    s.IsActive
FROM Staff s
LEFT JOIN Users u ON s.UserId = u.UserId
WHERE (@kw IS NULL
       OR s.FullName  LIKE '%' + @kw + '%'
       OR s.StaffCode LIKE '%' + @kw + '%'
       OR s.Phone     LIKE '%' + @kw + '%'
       OR s.Email     LIKE '%' + @kw + '%')
ORDER BY s.FullName";

                using (var da = new SqlDataAdapter(sql, conn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@kw",
                        string.IsNullOrWhiteSpace(keyword) ? (object)DBNull.Value : keyword.Trim());

                    var dt = new DataTable();
                    da.Fill(dt);

                    dgvStaff.AutoGenerateColumns = false;
                    dgvStaff.DataSource = dt;

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
            dtNgaySinh.Value = DateTime.Today;
            cboBangCap.SelectedIndex = -1;
            tglTrangThai.Checked = true;

            _currentStaffId = null;
        }

        private void FillFormFromRow(DataGridViewRow row)
        {
            if (row == null) return;

            var drv = row.DataBoundItem as DataRowView;
            if (drv == null) return;

            _currentStaffId = drv["StaffId"] != DBNull.Value
                ? Convert.ToInt32(drv["StaffId"])
                : (int?)null;

            txtMaNV.Text = drv["StaffCode"]?.ToString();
            txtHoTen.Text = drv["FullName"]?.ToString();
            cboGioiTinh.Text = drv["Gender"]?.ToString();
            txtEmail.Text = drv["Email"]?.ToString();
            txtSDT.Text = drv["Phone"]?.ToString();

            if (drv["BirthDate"] != DBNull.Value)
                dtNgaySinh.Value = Convert.ToDateTime(drv["BirthDate"]);
            else
                dtNgaySinh.Value = DateTime.Today;

            cboBangCap.Text = drv["Degree"]?.ToString();

            tglTrangThai.Checked = drv["IsActive"] != DBNull.Value
                && Convert.ToBoolean(drv["IsActive"]);
            lblStatusText.Text = tglTrangThai.Checked ? "Hoạt động" : "Không hoạt động";

            if (drv["LicenseExpireDate"] != DBNull.Value)
                dtLicenseExpire.Value = Convert.ToDateTime(drv["LicenseExpireDate"]);
            else
                dtLicenseExpire.Value = DateTime.Today;

            if (drv.Row.Table.Columns.Contains("Role"))
                cboVaiTro.Text = drv["Role"]?.ToString();
            else
                cboVaiTro.SelectedIndex = -1;
        }

        private void SetFormMode(EditMode mode)
        {
            // Nếu không có quyền sửa -> luôn ở chế độ xem
            if (!CanEdit)
            {
                _mode = EditMode.None;
                ApplyPermissions();
                return;
            }

            _mode = mode;

            bool isEditing = (mode == EditMode.Add || mode == EditMode.Edit);

            txtHoTen.Enabled = isEditing;
            cboGioiTinh.Enabled = isEditing;
            txtEmail.Enabled = isEditing;
            txtSDT.Enabled = isEditing;
            dtNgayVaoLam.Enabled = isEditing;
            dtNgaySinh.Enabled = isEditing;
            cboBangCap.Enabled = isEditing;
            dtLicenseExpire.Enabled = isEditing;
            tglTrangThai.Enabled = isEditing;
            txtMaNV.Enabled = (mode == EditMode.Add);
            cboVaiTro.Enabled = isEditing;

            btnThem.Enabled = (mode == EditMode.None) && CanEdit;
            btnSua.Enabled = (mode == EditMode.None) && CanEdit;
            btnLuu.Enabled = isEditing && CanEdit;
            btnHuy.Enabled = isEditing && CanEdit;
            btnXoa.Enabled = CanDelete;
        }

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
            if (!CanEdit)
            {
                MessageBox.Show("Bạn không có quyền thêm nhân viên.", "Phân quyền",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ClearForm();
            txtMaNV.Text = GenerateNewStaffCode();
            txtMaNV.Enabled = false;

            tglTrangThai.Checked = true;
            SetFormMode(EditMode.Add);
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            if (!CanEdit)
            {
                MessageBox.Show("Bạn không có quyền sửa thông tin nhân viên.", "Phân quyền",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
            if (dgvStaff.CurrentRow != null)
                FillFormFromRow(dgvStaff.CurrentRow);
            else
                ClearForm();

            SetFormMode(EditMode.None);
        }

        private void BtnTim_Click(object sender, EventArgs e)
        {
            string kw = txtTimNhanh.Text.Trim();
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
            if (!CanEdit)
            {
                MessageBox.Show("Bạn không có quyền lưu thay đổi.", "Phân quyền",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateForm()) return;

            if (_mode == EditMode.Add)
                InsertStaff();
            else if (_mode == EditMode.Edit)
                UpdateStaff();

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
            }
            else if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Số điện thoại không được để trống.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
            }
            else if (!txtSDT.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa chữ số.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSDT.Focus();
            }
            else if (dtNgayVaoLam.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Ngày vào làm không được lớn hơn ngày hiện tại.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtNgayVaoLam.Focus();
            }
            else
            {
                return true;
            }
            return false;
        }

        // ==============================
        //       THÊM MỚI DB
        // ==============================
        private void InsertStaff()
        {
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
            string defaultPassword = "12345";
            // string role = "Dược sĩ";
            string role = string.IsNullOrEmpty(cboVaiTro.Text)
                            ? "Dược sĩ"        // nếu bạn không chọn gì thì mặc định Dược sĩ
                            : cboVaiTro.Text.Trim();

            using (var conn = new SqlConnection(Program.ConnStr))
            {
                conn.Open();

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

                string sql = @"
DECLARE @UserId INT;
DECLARE @RoleId INT;

-- Lấy RoleId theo vai trò được chọn
SELECT @RoleId = RoleID
FROM Roles
WHERE RoleName = @Role;

INSERT INTO Users (FullName, Email, Password, Role, RoleId, CreatedAt)
VALUES (@FullName, @Email, @Password, @Role, @RoleId, GETDATE());

SET @UserId = SCOPE_IDENTITY();

INSERT INTO Staff
    (StaffCode, FullName, Gender, BirthDate, Email, Phone,
     HireDate, Degree, LicenseExpireDate, IsActive, CreatedAt, UserId)
VALUES
    (@StaffCode, @FullName, @Gender, @BirthDate, @Email, @Phone,
     @HireDate, @Degree, @LicenseExpireDate, @IsActive, GETDATE(), @UserId);";



                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FullName", fullName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", defaultPassword);
                    cmd.Parameters.AddWithValue("@Role", role);

                    cmd.Parameters.AddWithValue("@StaffCode", staffCode);
                    cmd.Parameters.AddWithValue("@Gender",
                        string.IsNullOrEmpty(gender) ? (object)DBNull.Value : gender);
                    cmd.Parameters.AddWithValue("@BirthDate", dtNgaySinh.Value.Date);
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
    s.BirthDate         = @BirthDate,
    s.HireDate          = @HireDate,
    s.Degree            = @Degree,
    s.LicenseExpireDate = @LicenseExpireDate,
    s.IsActive          = @IsActive
FROM Staff s
WHERE s.StaffId = @StaffId;

-- Cập nhật cả Role (text) và RoleID cho Users
UPDATE u
SET u.Role   = @Role,
    u.RoleID = (
        SELECT RoleID
        FROM Roles
        WHERE RoleName = @Role
    )
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
                    cmd.Parameters.AddWithValue("@BirthDate", dtNgaySinh.Value.Date);
                    cmd.Parameters.AddWithValue("@Role",
                        string.IsNullOrEmpty(cboVaiTro.Text) ? (object)DBNull.Value : cboVaiTro.Text);
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
                    if (result == null || result == DBNull.Value)
                        return "DS001";

                    string lastCode = result.ToString();
                    int number;
                    if (!int.TryParse(lastCode.Substring(2), out number))
                        return "DS001";

                    number++;
                    return "DS" + number.ToString("000");
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
            if (!CanDelete)
            {
                MessageBox.Show("Bạn không có quyền xóa nhân viên.", "Phân quyền",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvStaff.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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

            LoadStaffList(string.IsNullOrWhiteSpace(txtTimNhanh.Text)
                ? null
                : txtTimNhanh.Text.Trim());
            ClearForm();
            SetFormMode(EditMode.None);
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvStaff.Rows[e.RowIndex];

            txtMaNV.Text = row.Cells["colStaffCode"].Value?.ToString();
            txtHoTen.Text = row.Cells["colFullName"].Value?.ToString();
            txtEmail.Text = row.Cells["colEmail"].Value?.ToString();
            txtSDT.Text = row.Cells["colPhone"].Value?.ToString();
            cboGioiTinh.Text = row.Cells["colGender"].Value?.ToString();

            string degree = row.Cells["colDegree"].Value?.ToString();
            cboBangCap.SelectedItem = degree;

            if (row.Cells["colBirthDate"].Value != DBNull.Value)
                dtNgaySinh.Value = Convert.ToDateTime(row.Cells["colBirthDate"].Value);

            if (row.Cells["colHireDate"].Value != DBNull.Value)
                dtNgayVaoLam.Value = Convert.ToDateTime(row.Cells["colHireDate"].Value);

            cboVaiTro.SelectedItem = row.Cells["colRole"].Value?.ToString();

            string active = row.Cells["colActive"].Value.ToString();
            tglTrangThai.Checked = active == "True";
        }
    }
}
