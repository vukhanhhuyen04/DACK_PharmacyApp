using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyApp.Forms
{
    public partial class FrmForgotPass : Form
    {
        // ===========================
        // Các biến dùng cho OTP
        // ===========================
        private string _otpCode;            // Lưu OTP
        private DateTime _otpExpireTime;    // Thời gian hết hạn OTP
        private int _userId;                // ID user trong database
        private string _userEmail;          // Email của user

        public FrmForgotPass()
        {
            InitializeComponent();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 1) Kiểm tra đã gửi OTP chưa
            if (string.IsNullOrEmpty(_otpCode) || _userId == 0)
            {
                MessageBox.Show("Vui lòng nhấn \"Gửi OTP\" trước khi đổi mật khẩu.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2) Kiểm tra OTP
            string otpInput = txtOtp.Text.Trim();
            if (string.IsNullOrEmpty(otpInput))
            {
                MessageBox.Show("Vui lòng nhập mã OTP.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DateTime.Now > _otpExpireTime)
            {
                MessageBox.Show("Mã OTP đã hết hạn. Vui lòng yêu cầu mã mới.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.Equals(otpInput, _otpCode))
            {
                MessageBox.Show("Mã OTP không đúng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3) Kiểm tra mật khẩu mới
            string newPass = txtNew.Text.Trim();
            string confirm = txtConfirm.Text.Trim();

            if (string.IsNullOrEmpty(newPass))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPass.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.Equals(newPass, confirm))
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4) Cập nhật mật khẩu trong database
            try
            {
                using (SqlConnection conn = new SqlConnection(Program.ConnStr))
                {
                    conn.Open();

                    string sql = @"
                UPDATE Users
                SET Password = @Password
                WHERE UserID = @UserID";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        // Nếu sau này bạn dùng hash thì đổi newPass -> HashPassword(newPass)
                        cmd.Parameters.AddWithValue("@Password", newPass);
                        cmd.Parameters.AddWithValue("@UserID", _userId);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Đổi mật khẩu thành công. Hãy đăng nhập lại với mật khẩu mới.",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Không thể cập nhật mật khẩu. Vui lòng thử lại.",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật mật khẩu: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void txtNew_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtConfirm_TextChanged(object sender, EventArgs e)
        {

        }

        private void card_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtOld_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblBrand_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {

        }



        private void btnSendOtp_Click(object sender, EventArgs e)
        {
            string email = txtUsername.Text.Trim();   // ô này nhập email
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Vui lòng nhập email tài khoản.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(Program.ConnStr))
                {
                    conn.Open();

                    string sql = @"
                SELECT UserID, Email
                FROM Users
                WHERE Email = @Email";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        using (SqlDataReader rd = cmd.ExecuteReader())
                        {
                            if (!rd.Read())
                            {
                                MessageBox.Show("Không tìm thấy tài khoản này.", "Lỗi",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            _userId = rd.GetInt32(rd.GetOrdinal("UserID"));
                            _userEmail = rd["Email"]?.ToString();
                        }
                    }
                }

                if (string.IsNullOrEmpty(_userEmail))
                {
                    MessageBox.Show("Tài khoản này chưa có email. Vui lòng liên hệ admin.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 1) Tạo OTP
                var rnd = new Random();
                _otpCode = rnd.Next(100000, 999999).ToString();   // 6 số
                _otpExpireTime = DateTime.Now.AddMinutes(5);      // hết hạn sau 5 phút

                // 2) Gửi email
                SendOtpEmail(_userEmail, _otpCode);

                MessageBox.Show("Đã gửi mã OTP tới email của bạn. Mã có hiệu lực trong 5 phút.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtOtp.Enabled = true;
                txtNew.Enabled = true;
                txtConfirm.Enabled = true;
                txtOtp.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi OTP: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SendOtpEmail(string toEmail, string otpCode)
        {
            // 👉 THAY BẰNG GMAIL CỦA BẠN
            string fromEmail = "hangthianhthu0048@gmail.com";

            // 👉 APP PASSWORD 16 KÝ TỰ (KHÔNG PHẢI MẬT KHẨU LOGIN)
            string fromPass = "pswc jvgu blwx yldx".Replace(" ", "");

            var mail = new MailMessage();
            mail.From = new MailAddress(fromEmail, "EternaMed"); // tên hiển thị
            mail.To.Add(toEmail);                                // email người nhận
            mail.Subject = "Mã OTP đặt lại mật khẩu";
            mail.Body =
                $"Mã OTP của bạn là: {otpCode}\n\n" +
                "Mã có hiệu lực trong 5 phút. Vui lòng không chia sẻ cho bất kỳ ai.";

            // Cấu hình SMTP cho Gmail
            var smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(fromEmail, fromPass);

            // ✅ CHỈ GỬI 1 LẦN RỒI THOI
            smtp.Send(mail);
        }



    }
}
