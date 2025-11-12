using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyApp.Forms
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();

            lnkSignUp.AutoSize = true;
            lnkForgot.AutoSize = true;
            lnkHelp.AutoSize = true;
            lblBrand.AutoSize = true;
            lblBrandCare.AutoSize = true;
            // bỏ mọi giới hạn width/height (nếu có)
            lnkSignUp.MaximumSize = new System.Drawing.Size(0, 0);
            lnkForgot.MaximumSize = new System.Drawing.Size(0, 0);
            lnkHelp.MaximumSize = new System.Drawing.Size(0, 0);
            lblBrand.MaximumSize = new System.Drawing.Size(0, 0);
            lblBrandCare.MaximumSize = new System.Drawing.Size(0, 0);

            CenterBrand();
            this.Resize += (s, e) => CenterBrand();

            // canh giữa theo Form
            void CenterLinks()
            {
                int totalWidth = lnkSignUp.Width + 12 + lnkForgot.Width + 12 + lnkHelp.Width;
                int startX = (this.ClientSize.Width - totalWidth) / 2;
                int y = card.Bottom + 20;

                lnkSignUp.Location = new System.Drawing.Point(startX, y);
                lnkForgot.Location = new System.Drawing.Point(lnkSignUp.Right + 12, y);
                lnkHelp.Location = new System.Drawing.Point(lnkForgot.Right + 12, y);
            }

            CenterLinks();
            this.Resize += (s, e) => CenterLinks();

            WireEvents();
            this.AcceptButton = btnLogin;   // Enter = Login
            lblTitle.AutoSize = true;             // đảm bảo tự nới kích thước
            lblTitle.MaximumSize = new System.Drawing.Size(0, 0); // bỏ giới hạn width
        }
        private void CenterBrand()
        {
            int gap = 0; // nếu muốn cách 4–8 px: gap = 6;
            int total = lblBrand.Width + gap + lblBrandCare.Width;
            int x = (this.ClientSize.Width - total) / 2;
            int y = lblBrand.Top; // hoặc: y = this.ClientSize.Height - 96;

            lblBrand.Location = new System.Drawing.Point(x, y);
            lblBrandCare.Location = new System.Drawing.Point(lblBrand.Right + gap, y);
        }
        private void WireEvents()
        {
            lnkSignUp.Click += lnkSignUp_Click;
            lnkForgot.Click += lnkForgot_Click;
            lnkHelp.Click += lnkHelp_Click;
            // btnLogin.Click đã nối sẵn trong Designer
        }
        private void sepTitle_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            var pass = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Vui lòng nhập Email và Mật khẩu.", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (var conn = new System.Data.SqlClient.SqlConnection(Program.ConnStr))
                using (var cmd = new System.Data.SqlClient.SqlCommand("sp_User_Login", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", pass);

                    conn.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string fullName = reader["FullName"].ToString();
                            string role = reader["Role"].ToString();

                            MessageBox.Show($"Xin chào {fullName} ({role})!", "Đăng nhập thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Mở form chính nếu có
                            // this.Hide();
                            // new FrmMain().ShowDialog();
                            // this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Email hoặc mật khẩu không đúng.", "Lỗi đăng nhập",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Đăng nhập thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }
        private void lnkSignUp_Click(object sender, EventArgs e)
        {
            using (var reg = new FrmRegister())
            {
                reg.StartPosition = FormStartPosition.CenterParent;
                reg.ShowInTaskbar = false;              // gọn taskbar
                var result = reg.ShowDialog(this);      // MỞ DẠNG MODAL - KHÔNG Hide login

                if (result == DialogResult.OK)
                {
                    // (tuỳ chọn) điền sẵn email vừa đăng ký
                    // txtEmail.Text = reg.RegisteredEmail;
                }
            }
        }

        private void lnkForgot_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng Quên mật khẩu sẽ được bổ sung.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void lnkHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Liên hệ quản trị viên hoặc bộ phận hỗ trợ.", "Trợ giúp",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

    }
}
