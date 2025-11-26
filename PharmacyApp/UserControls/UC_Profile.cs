using PharmacyApp.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace PharmacyApp.UserControls
{
    public partial class UC_Profile : UserControl
    {
        public int StaffId { get; set; }
        public bool IsAdmin { get; set; }

        private string _avatarPathInDb;
        private int _userId;   // UserId liên kết với Staff

        public UC_Profile()
        {
            InitializeComponent();
            StaffId = Session.StaffId;
            IsAdmin = Session.Role == "Admin";
            this.Load += UC_Profile_Load;
            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;
            btnChangeAvatar.Click += BtnChangeAvatar_Click;
            btnChangePassword.Click += BtnChangePassword_Click;
        }

        private void UC_Profile_Load(object sender, EventArgs e)
        {
            // Chuẩn hóa lại danh sách trình độ cho đúng với dữ liệu DB
            cboQualification.Items.Clear();
            cboQualification.Items.AddRange(new object[]
            {
        "Dược sĩ Đại học",
        "Dược sĩ Cao đẳng",
        "Dược sĩ Trung cấp",
        "Dược tá"
            });

            if (StaffId == 0) return;

            LoadProfileFromDb();
            ApplyPermission();
        }


        // ==================================================
        //     1. LOAD THÔNG TIN TỪ DB
        // ==================================================
        private void LoadProfileFromDb()
        {
            try
            {
                using (var conn = new SqlConnection(Program.ConnStr))
                using (var cmd = new SqlCommand(@"
SELECT 
    s.StaffId,
    s.StaffCode,
    s.FullName        AS StaffName,
    s.Gender,
    s.Email           AS StaffEmail,
    s.Phone,
    s.HireDate,
    s.Degree,
    s.LicenseExpireDate,
    s.LicenseNo,
    s.LicenseIssueDate,
    s.Address,
    s.IsActive,
    s.UserId,
    s.AvatarPath,

    u.Email           AS Username,
    u.Role
FROM Staff s
LEFT JOIN Users u ON s.UserId = u.UserId
WHERE s.StaffId = @StaffId", conn))
                {
                    cmd.Parameters.AddWithValue("@StaffId", StaffId);
                    conn.Open();

                    using (var rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read())
                        {
                            MessageBox.Show("Không tìm thấy hồ sơ.", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // ===== Mã nhân sự =====
                        txtStaffCode.Text = rd["StaffCode"]?.ToString();

                        // ===== ẢNH =====
                        _avatarPathInDb = rd["AvatarPath"]?.ToString();
                        LoadAvatarToPictureBox(_avatarPathInDb);

                        // ===== Cơ bản =====
                        txtFullName.Text = rd["StaffName"]?.ToString();
                        txtPhone.Text = rd["Phone"]?.ToString();
                        txtEmail.Text = rd["StaffEmail"]?.ToString();
                        txtAddress.Text = rd["Address"]?.ToString();
                        if (rd["UserId"] != DBNull.Value)
                            _userId = Convert.ToInt32(rd["UserId"]);
                        else
                            _userId = 0;

                        if (rd["HireDate"] != DBNull.Value)
                            dtpBirthDate.Value = Convert.ToDateTime(rd["HireDate"]);

                        SelectComboByText(cboGender, rd["Gender"]?.ToString());

                        // ===== Chuyên môn =====
                        SelectComboByText(cboQualification, rd["Degree"]?.ToString());
                        txtLicenseNo.Text = rd["LicenseNo"]?.ToString();

                        if (rd["LicenseIssueDate"] != DBNull.Value)
                            dtpLicenseIssue.Value = Convert.ToDateTime(rd["LicenseIssueDate"]);

                        if (rd["LicenseExpireDate"] != DBNull.Value)
                            dtpLicenseExpire.Value = Convert.ToDateTime(rd["LicenseExpireDate"]);

                        // ===== Hệ thống =====
                        txtUsername.Text = rd["Username"]?.ToString();
                        txtPasswordMask.Text = string.IsNullOrWhiteSpace(txtUsername.Text) ? "" : "********";

                        SelectComboByText(cboRole, rd["Role"]?.ToString());

                        bool isActive = rd["IsActive"] != DBNull.Value &&
                                        Convert.ToBoolean(rd["IsActive"]);
                        cboStatus.SelectedIndex = isActive ? 0 : 1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectComboByText(ComboBox cbo, string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return;

            for (int i = 0; i < cbo.Items.Count; i++)
            {
                if (cbo.Items[i].ToString().Equals(text, StringComparison.OrdinalIgnoreCase))
                {
                    cbo.SelectedIndex = i;
                    return;
                }
            }
        }

        private void LoadAvatarToPictureBox(string path)
        {
            try
            {
                picAvatar.Image?.Dispose();
                picAvatar.Image = null;

                if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
                {
                    picAvatar.Image = Image.FromFile(path);
                }
            }
            catch { }
        }

        // ==================================================
        //     2. ÁP QUYỀN
        // ==================================================
        private void ApplyPermission()
        {
            bool canEditBasic = true;
            bool canEditProfessional = IsAdmin;
            bool canEditSystem = IsAdmin;

            txtFullName.ReadOnly = !canEditBasic;
            txtPhone.ReadOnly = !canEditBasic;
            txtEmail.ReadOnly = !canEditBasic;
            txtAddress.ReadOnly = !canEditBasic;
            dtpBirthDate.Enabled = canEditBasic;
            cboGender.Enabled = canEditBasic;

            btnChangeAvatar.Enabled = canEditBasic;

            cboQualification.Enabled = canEditProfessional;
            txtLicenseNo.ReadOnly = !canEditProfessional;
            dtpLicenseIssue.Enabled = canEditProfessional;
            dtpLicenseExpire.Enabled = canEditProfessional;

            txtUsername.ReadOnly = true;
            cboRole.Enabled = canEditSystem;
            cboStatus.Enabled = canEditSystem;
        }

        // ==================================================
        //     3. LƯU CSDL
        // ==================================================
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            try
            {
                using (var conn = new SqlConnection(Program.ConnStr))
                using (var cmd = new SqlCommand(@"
UPDATE Staff
SET 
    FullName          = @FullName,
    Gender            = @Gender,
    Email             = @Email,
    Phone             = @Phone,
    HireDate          = @HireDate,
    Degree            = @Degree,
    Address           = @Address,
    LicenseNo         = @LicenseNo,
    LicenseIssueDate  = @LicenseIssueDate,
    LicenseExpireDate = @LicenseExpireDate,
    AvatarPath        = @AvatarPath,
    IsActive          = @IsActive
WHERE StaffId = @StaffId;

UPDATE u
SET u.Role = @Role
FROM Users u
JOIN Staff s ON s.UserId = u.UserId
WHERE s.StaffId = @StaffId;
", conn))
                {
                    cmd.Parameters.AddWithValue("@StaffId", StaffId);
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Gender", cboGender.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@HireDate", dtpBirthDate.Value.Date);
                    cmd.Parameters.AddWithValue("@Degree", cboQualification.Text);

                    cmd.Parameters.AddWithValue("@Address",
                        string.IsNullOrWhiteSpace(txtAddress.Text) ? (object)DBNull.Value : txtAddress.Text);

                    cmd.Parameters.AddWithValue("@LicenseNo",
                        string.IsNullOrWhiteSpace(txtLicenseNo.Text) ? (object)DBNull.Value : txtLicenseNo.Text);

                    cmd.Parameters.AddWithValue("@LicenseIssueDate", dtpLicenseIssue.Value.Date);
                    cmd.Parameters.AddWithValue("@LicenseExpireDate", dtpLicenseExpire.Value.Date);

                    cmd.Parameters.AddWithValue("@AvatarPath",
                        string.IsNullOrWhiteSpace(_avatarPathInDb) ? (object)DBNull.Value : _avatarPathInDb);

                    bool isActive = cboStatus.SelectedIndex == 0;
                    cmd.Parameters.AddWithValue("@IsActive", isActive);

                    cmd.Parameters.AddWithValue("@Role",
                        string.IsNullOrWhiteSpace(cboRole.Text) ? (object)DBNull.Value : cboRole.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đã lưu thông tin cá nhân.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Họ và tên không được để trống.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        // ==================================================
        //     4. NÚT HỦY
        // ==================================================
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            LoadProfileFromDb();
        }

        // ==================================================
        //     5. ĐỔI ẢNH → LƯU FILE + UPDATE AvatarPath
        // ==================================================
        private void BtnChangeAvatar_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Ảnh (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string folder = Path.Combine(Application.StartupPath, "Images", "Staffs");
                        Directory.CreateDirectory(folder);

                        string fileName = $"staff_{StaffId}{Path.GetExtension(ofd.FileName)}";
                        string newPath = Path.Combine(folder, fileName);

                        File.Copy(ofd.FileName, newPath, true);

                        _avatarPathInDb = newPath;
                        LoadAvatarToPictureBox(newPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi tải ảnh:\n" + ex.Message);
                    }
                }
            }
        }

        private void BtnChangePassword_Click(object sender, EventArgs e)
        {
            if (_userId == 0)
            {
                MessageBox.Show("Không tìm thấy tài khoản hệ thống để đổi mật khẩu.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var frm = new FrmChangePassword(_userId))
            {
                var result = frm.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    // đổi pass thành công, chỉ cần mask lại ô mật khẩu
                    txtPasswordMask.Text = "********";
                }
            }
        }

    }
}
