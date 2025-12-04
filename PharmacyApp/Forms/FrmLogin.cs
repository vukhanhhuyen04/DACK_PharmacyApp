using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using PharmacyApp;

namespace PharmacyApp.Forms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

            // Các thiết lập an toàn cho Designer
            if (lnkSignUp != null) { lnkSignUp.AutoSize = true; lnkSignUp.MaximumSize = new Size(0, 0); }
            if (lnkForgot != null) { lnkForgot.AutoSize = true; lnkForgot.MaximumSize = new Size(0, 0); }
            if (lnkHelp != null) { lnkHelp.AutoSize = true; lnkHelp.MaximumSize = new Size(0, 0); }
            if (lblBrand != null) { lblBrand.AutoSize = true; lblBrand.MaximumSize = new Size(0, 0); }
            if (lblBrandCare != null) { lblBrandCare.AutoSize = true; lblBrandCare.MaximumSize = new Size(0, 0); }
            if (lblTitle != null) { lblTitle.AutoSize = true; lblTitle.MaximumSize = new Size(0, 0); }

            WireEvents();

            if (IsInDesigner()) return;
            LoadRememberedUser();
            this.Shown += delegate { CenterBrand(); CenterLinks(); };
            this.Resize += delegate { CenterBrand(); CenterLinks(); };
        }

        // Nhận biết đang ở Design-time
        private bool IsInDesigner()
        {
            return DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;
        }

        private void WireEvents()
        {
            if (lnkSignUp != null) lnkSignUp.Click += lnkSignUp_Click;
            if (lnkForgot != null) lnkForgot.Click += lnkForgot_Click;
            if (lnkHelp != null) lnkHelp.Click += lnkHelp_Click;
            if (btnLogin != null) this.AcceptButton = btnLogin; // Enter = Login
            if (chkRemember != null)
                chkRemember.CheckedChanged += chkRemember_CheckedChanged;

            // nếu bạn không gán trong Designer thì có thể bật lên:
            // if (btnLogin != null) btnLogin.Click += btnLogin_Click;
        }

        // ---------- Căn giữa logo ----------
        private void CenterBrand()
        {
            if (lblBrand == null || lblBrandCare == null) return;

            int gap = 0;
            int total = Math.Max(0, lblBrand.Width) + gap + Math.Max(0, lblBrandCare.Width);
            int x = (this.ClientSize.Width - total) / 2;
            if (x < 0) x = 0;
            int y = lblBrand.Top;

            lblBrand.Location = new Point(x, y);
            lblBrandCare.Location = new Point(lblBrand.Right + gap, y);
        }

        // ---------- Căn giữa 3 link dưới card ----------
        private void CenterLinks()
        {
            if (lnkSignUp == null || lnkForgot == null || lnkHelp == null || card == null) return;

            int gap = 12;
            int totalWidth =
                Math.Max(0, lnkSignUp.Width) +
                gap +
                Math.Max(0, lnkForgot.Width) +
                gap +
                Math.Max(0, lnkHelp.Width);

            int startX = (this.ClientSize.Width - totalWidth) / 2;
            if (startX < 0) startX = 0;
            int y = card.Bottom + 20;

            lnkSignUp.Location = new Point(startX, y);
            lnkForgot.Location = new Point(lnkSignUp.Right + gap, y);
            lnkHelp.Location = new Point(lnkForgot.Right + gap, y);
        }

        // ---------- Handlers UI (stub cho Designer) ----------
        private void sepTitle_Click(object sender, EventArgs e) { }
        private void txtPassword_TextChanged(object sender, EventArgs e) { }
        private void FrmLogin_Load(object sender, EventArgs e) { }
        private void guna2Shapes3_Click(object sender, EventArgs e) { }

        private void chkRemember_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkRemember.Checked)
            {
                Properties.Settings.Default.RememberMe = false;
                Properties.Settings.Default.SavedEmail = "";
                Properties.Settings.Default.SavedPassword = "";
                Properties.Settings.Default.Save();
            }
        }

        private void lnkSignUp_Click(object sender, EventArgs e)
        {
            using (var reg = new FrmRegister())
            {
                reg.StartPosition = FormStartPosition.CenterParent;
                reg.ShowInTaskbar = false;
                var result = reg.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    // txtEmail.Text = reg.RegisteredEmail;
                }
            }
        }

        private void lnkForgot_Click(object sender, EventArgs e)
        {
            using (var forgot = new FrmForgotPass())
            {
                forgot.StartPosition = FormStartPosition.CenterParent;
                forgot.ShowInTaskbar = false;
                var result = forgot.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    // txtEmail.Text = forgot.EmailUsed;
                }
            }
        }

        private void lnkHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Liên hệ quản trị viên hoặc bộ phận hỗ trợ.", "Trợ giúp",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ==================== LOGIN ====================
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string pass = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Email và Mật khẩu.",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new SqlConnection(Program.ConnStr))
                using (var cmd = new SqlCommand("sp_User_Login", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", pass);

                    conn.Open();

                    int userId;
                    int staffId;
                    string fullName;
                    string dbRole;

                    // Đọc thông tin cơ bản từ SP
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read())
                        {
                            MessageBox.Show("Sai Email hoặc Mật khẩu.",
                                "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        userId = Convert.ToInt32(rd["UserID"]);
                        staffId = rd["StaffID"] != DBNull.Value ? Convert.ToInt32(rd["StaffID"]) : 0;
                        fullName = rd["FullName"].ToString();
                        dbRole = rd["Role"]?.ToString()?.Trim();
                    }

                    // 🔒 KIỂM TRA TRẠNG THÁI HOẠT ĐỘNG (IsActive trong Staff)
                    bool isActive = true;   // mặc định cho các tài khoản không thuộc Staff (ví dụ Admin hệ thống)

                    if (staffId != 0)
                    {
                        using (var cmdActive = new SqlCommand(
                            "SELECT ISNULL(IsActive, 1) FROM Staff WHERE StaffId = @StaffId", conn))
                        {
                            cmdActive.Parameters.AddWithValue("@StaffId", staffId);
                            var objActive = cmdActive.ExecuteScalar();
                            isActive = objActive != null
                                       && objActive != DBNull.Value
                                       && Convert.ToBoolean(objActive);
                        }
                    }

                    if (!isActive)
                    {
                        MessageBox.Show(
                            "Tài khoản này đã được đánh dấu là 'Không hoạt động'.\n" +
                            "Bạn không thể đăng nhập. Vui lòng liên hệ quản trị viên.",
                            "Tài khoản bị khóa",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                    }

                    // ---- ROLE GỐC TỪ DB ----
                    // ✅ CHUẨN HOÁ ROLE: chỉ còn "Admin" hoặc "Dược sĩ"
                    string normalizedRole;
                    if (string.Equals(dbRole, "Admin", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(dbRole, "Quản trị viên", StringComparison.OrdinalIgnoreCase))
                    {
                        normalizedRole = "Admin";
                    }
                    else
                    {
                        // Mặc định tất cả role khác xem như Dược sĩ
                        normalizedRole = "Dược sĩ";
                    }

                    // 🔥 Nếu đăng nhập bằng mật khẩu mặc định -> bắt buộc đổi mật khẩu
                    if (pass == "12345")
                    {
                        using (var frmChange = new FrmChangePassword(userId))
                        {
                            var result = frmChange.ShowDialog(this);

                            if (result != DialogResult.OK)
                            {
                                // Người dùng không đổi mật khẩu -> không cho vào hệ thống
                                MessageBox.Show("Bạn cần đổi mật khẩu trước khi sử dụng hệ thống.",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }

                        // Sau khi đổi mật khẩu thành công, yêu cầu nhập lại mật khẩu mới
                        MessageBox.Show("Vui lòng đăng nhập lại với mật khẩu mới.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtPassword.Clear();
                        txtPassword.Focus();
                        return;
                    }

                    // ✅ Đăng nhập bình thường (không phải mật khẩu mặc định, và đang Hoạt động)
                    Session.UserId = userId;
                    Session.StaffId = staffId;
                    Session.FullName = fullName;
                    Session.Role = normalizedRole;    // dùng role đã chuẩn hoá
                    Session.IsLoggedIn = true;

                    // 🔹 Nạp quyền từ database vào Session.Permissions
                    PharmacyApp.Security.PermissionService.LoadPermissionsForCurrentUser();

                    // 🔹 Lưu vào Program để chỗ khác dùng (POS, báo cáo,...)
                    Program.CurrentStaffId = staffId;
                    Program.CurrentStaffName = fullName;

                    // ======= REMEMBER ME =======
                    if (chkRemember.Checked)
                    {
                        Properties.Settings.Default.RememberMe = true;
                        Properties.Settings.Default.SavedEmail = email;
                        Properties.Settings.Default.SavedPassword = pass;  // Có thể mã hoá nếu muốn
                    }
                    else
                    {
                        Properties.Settings.Default.RememberMe = false;
                        Properties.Settings.Default.SavedEmail = "";
                        Properties.Settings.Default.SavedPassword = "";
                    }

                    Properties.Settings.Default.Save();

                    // chuyển sang dashboard
                    OpenDashboard();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi không xác định:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Mở Dashboard, đọc từ Session
        private void OpenDashboard()
        {
            this.Hide();

            // Dùng thông tin trong Session (role đã chuẩn hoá)
            var dash = new FrmAdminDashboard(Session.UserId, Session.FullName, Session.Role);

            dash.FormClosed += (s, e) =>
            {
                // Khi đóng dashboard thì thoát luôn app
                this.Close();
            };

            dash.Show();
        }

        private void LoadRememberedUser()
        {
            if (Properties.Settings.Default.RememberMe)
            {
                chkRemember.Checked = true;
                txtEmail.Text = Properties.Settings.Default.SavedEmail;
                txtPassword.Text = Properties.Settings.Default.SavedPassword;
            }
            else
            {
                chkRemember.Checked = false;
                txtEmail.Clear();
                txtPassword.Clear();
            }
        }

    }
}
