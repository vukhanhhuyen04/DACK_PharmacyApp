using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PharmacyApp.Forms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

            // Các thiết lập an toàn cho Designer (không dùng null-forgiving, không C# 8)
            if (lnkSignUp != null) { lnkSignUp.AutoSize = true; lnkSignUp.MaximumSize = new Size(0, 0); }
            if (lnkForgot != null) { lnkForgot.AutoSize = true; lnkForgot.MaximumSize = new Size(0, 0); }
            if (lnkHelp != null) { lnkHelp.AutoSize = true; lnkHelp.MaximumSize = new Size(0, 0); }
            if (lblBrand != null) { lblBrand.AutoSize = true; lblBrand.MaximumSize = new Size(0, 0); }
            if (lblBrandCare != null) { lblBrandCare.AutoSize = true; lblBrandCare.MaximumSize = new Size(0, 0); }
            if (lblTitle != null) { lblTitle.AutoSize = true; lblTitle.MaximumSize = new Size(0, 0); }

            WireEvents();

            // Khi mở trong Designer thì dừng tại đây để tránh lỗi preview
            if (IsInDesigner()) return;

            // Canh giữa sau khi form hiện và khi resize
            this.Shown += delegate { CenterBrand(); CenterLinks(); };
            this.Resize += delegate { CenterBrand(); CenterLinks(); };
        }

        // Nhận biết đang ở Design-time (C# 7.3)
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

        // ---------- Handlers UI (an toàn cho Designer) ----------
        private void sepTitle_Click(object sender, EventArgs e) { }
        private void txtPassword_TextChanged(object sender, EventArgs e) { }
        private void FrmLogin_Load(object sender, EventArgs e) { }

        // Designer báo thiếu: thêm stub cho sự kiện này
        private void guna2Shapes3_Click(object sender, EventArgs e) { }

        private void lnkSignUp_Click(object sender, EventArgs e)
        {
            using (var reg = new FrmRegister())
            {
                reg.StartPosition = FormStartPosition.CenterParent;
                reg.ShowInTaskbar = false;
                var result = reg.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    // txtEmail.Text = reg.RegisteredEmail; // nếu sau này có expose property
                }
            }
        }

        // 👉 Sửa tại đây: mở form quên mật khẩu
        private void lnkForgot_Click(object sender, EventArgs e)
        {
            using (var forgot = new FrmForgotPass())
            {
                forgot.StartPosition = FormStartPosition.CenterParent;
                forgot.ShowInTaskbar = false;
                var result = forgot.ShowDialog(this);

                if (result == DialogResult.OK)
                {
                    // Nếu sau này bạn muốn lấy email mới đặt lại để tự fill vào ô txtEmail
                    // có thể thêm property trong FrmForgotPassword và gán tại đây.
                    // txtEmail.Text = forgot.EmailUsed;
                }
            }
        }

        private void lnkHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Liên hệ quản trị viên hoặc bộ phận hỗ trợ.", "Trợ giúp",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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
                    using (var rd = cmd.ExecuteReader())
                    {
                        if (!rd.Read())
                        {
                            // Không có bản ghi nào => sai tài khoản / mật khẩu
                            MessageBox.Show("Sai Email hoặc Mật khẩu.",
                                "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        int userId = rd.GetInt32(rd.GetOrdinal("UserID"));
                        string fullName = rd.GetString(rd.GetOrdinal("FullName"));
                        string role = rd.GetString(rd.GetOrdinal("Role"));

                        // ✅ Đăng nhập thành công → mở Dashboard
                        OpenDashboard(userId, fullName, role);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenDashboard(int userId, string fullName, string role)
        {
            // Ẩn form Login
            this.Hide();

            // Tạo dashboard (admin/pharmacist tuỳ bạn, ví dụ admin)
            var dash = new FrmAdminDashboard(userId, fullName, role);

            // Khi đóng dashboard thì đóng luôn login → thoát app
            dash.FormClosed += (s, e) => this.Close();

            dash.Show();
        }

        private void chkRemember_CheckedChanged(object sender, EventArgs e)
        {
            // TODO: nhớ mật khẩu nếu bạn muốn
        }
    }
}
