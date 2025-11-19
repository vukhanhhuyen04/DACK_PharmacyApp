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

            // 👉 THAY BẰNG APP PASSWORD 16 KÝ TỰ (KHÔNG PHẢI MẬT KHẨU ĐĂNG NHẬP)
            string fromPass = "pswc jvgu blwx yldx".Replace(" ", "");

            var mail = new MailMessage();
            mail.From = new MailAddress(fromEmail, "EternaMed"); // tên hiển thị
            mail.To.Add(toEmail);                                  // email người nhận
            mail.Subject = "Mã OTP đặt lại mật khẩu";
            mail.Body =
                $"Mã OTP của bạn là: {otpCode}\n\n" +
                "Mã có hiệu lực trong 5 phút. Vui lòng không chia sẻ cho bất kỳ ai.";

            // Cấu hình SMTP cho Gmail
            var smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(fromEmail, fromPass);

            // Gửi mail
            smtp.Send(mail);
            // 1) Tạo OTP
            var rnd = new Random();
            _otpCode = rnd.Next(100000, 999999).ToString();   // 6 số
            _otpExpireTime = DateTime.Now.AddMinutes(5);      // hết hạn sau 5 phút

            // 2) Gửi email
            SendOtpEmail(_userEmail, _otpCode);
            try
            {
                SendOtpEmail(_userEmail, _otpCode);
                MessageBox.Show("Đã gửi mã OTP tới email của bạn.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi email: " + ex.Message);
            }

        }


    }
}
