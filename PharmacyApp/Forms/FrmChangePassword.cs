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

namespace PharmacyApp.Forms
{
    public partial class FrmChangePassword : Form
    {
        private readonly int _userId;

        public FrmChangePassword(int userId)
        {
            InitializeComponent();
            _userId = userId;

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += BtnCancel_Click;

            lblBrand.BringToFront();
            lblTitle.BringToFront();
            guna2HtmlLabel1.Text =
              "<span style='color:#69C4F6;'>Eterna</span>" +
              "<span style='color:#36D7B7;'>Med</span>";

        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string newPass = txtNew.Text.Trim();
            string confirm = txtConfirm.Text.Trim();

            if (string.IsNullOrWhiteSpace(newPass))
            {
                MessageBox.Show("Mật khẩu mới không được để trống.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNew.Focus();
                return;
            }

            if (newPass.Length < 4)
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 4 ký tự.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNew.Focus();
                return;
            }

            if (newPass != confirm)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp.",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirm.Focus();
                return;
            }

            try
            {
                using (var conn = new SqlConnection(Program.ConnStr))
                using (var cmd = new SqlCommand(
                    "UPDATE Users SET Password = @Password WHERE UserId = @UserId", conn))
                {
                    cmd.Parameters.AddWithValue("@Password", newPass);
                    cmd.Parameters.AddWithValue("@UserId", _userId);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show("Đổi mật khẩu thành công.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }

                    else
                    {
                        MessageBox.Show("Không tìm thấy tài khoản để đổi mật khẩu.",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đổi mật khẩu:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void card_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
