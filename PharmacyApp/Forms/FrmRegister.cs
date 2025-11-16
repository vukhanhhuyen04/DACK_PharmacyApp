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
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi;
            //flowLayoutPanel1.SizeChanged += (_, __) => CenterBrand();
         //   flowLayoutPanel1.PerformLayout();
          ////  this.BeginInvoke((Action)(() => CenterBrand()));
          //  btnSignUp.AutoRoundedCorners = false;
          //  btnSignUp.Size = new Size(405, 50);
          //  btnSignUp.Padding = new Padding(0, 3, 0, 1);
          //  btnSignUp.TextOffset = new Point(0, 1);

            // 1) Flow host tự đo kích thước, không dùng size cố định
            //flowLayoutPanel1.AutoSize = true;
            //flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            //flowLayoutPanel1.WrapContents = false;
            //flowLayoutPanel1.BackColor = Color.Transparent;
            //flowLayoutPanel1.Margin = new Padding(0);
            //flowLayoutPanel1.Padding = new Padding(0);

            //// 2) Hai label brand phải AutoSize
            //lblBrand.AutoSize = true;
            //lblBrandCare.AutoSize = true;
            //lblBrand.MaximumSize = new Size(0, 0);
            //lblBrandCare.MaximumSize = new Size(0, 0);
            //lblBrand.Margin = new Padding(0);
            //lblBrandCare.Margin = new Padding(0);

            //// 3) Đặt flow lên trên mọi thứ trong card
            //flowLayoutPanel1.BringToFront();

            // Sóng ở sau – nội dung ở trước
            //shapeTop1.SendToBack();
            shapeTop2.SendToBack();
            shapeTop3.SendToBack();

            lblTitle.BringToFront();
            sepTitle.BringToFront();
            card.BringToFront();
            lblBrand?.BringToFront();
            lblBrandCare?.BringToFront();
            linkLabel1?.BringToFront();

            WireEvents();
            // 1) Brand “pharmacare” không bị cắt
            lblBrand.AutoSize = true;
            lblBrandCare.AutoSize = true;
            lblBrand.MaximumSize = new System.Drawing.Size(0, 0);
            lblBrandCare.MaximumSize = new System.Drawing.Size(0, 0);
            lblBrand.BackColor = System.Drawing.Color.Transparent;
            lblBrandCare.BackColor = System.Drawing.Color.Transparent;

            // 2) Nút “Đăng kí” đủ cao và không hụt text
            //btnSignUp.AutoRoundedCorners = false;               // tránh bo góc làm hụt text
            //btnSignUp.Size = new System.Drawing.Size(405, 46);  // tăng chiều cao 44 -> 46 (hoặc 48)
            //btnSignUp.TextAlign = HorizontalAlignment.Center;
            //btnSignUp.TextOffset = new System.Drawing.Point(0, -1); // đẩy text lên 1px nếu thấy “đè”

            // 3) LinkLabel đã AutoSize sẵn — canh giữa dưới nút
            linkLabel1.AutoSize = true;
            linkLabel1.BackColor = System.Drawing.Color.Transparent;

            // 4) Canh giữa brand/link trong card
            //CenterBrand();
            //CenterLink();
            //this.Resize += (s, e) => { CenterBrand(); CenterLink(); };
        }
        //void CenterBrand()
        //{
        //    var x = (card.ClientSize.Width - //flowLayoutPanel1.Width) / 2;
        //    var y = 20; // cách mép trên card 20px
        //                // chặn giá trị âm khi card nhỏ
        //    if (x < 0) x = 0;
        //    flowLayoutPanel1.Location = new Point(x, y);
        //}




        private void WireEvents()
        {
            btnSignUp1.Click += btnSignUp_Click;      // đảm bảo đã nối
            linkLabel1.Click += lnkLogin_Click;      // “Đăng nhập” 
        }
        private void lnkLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // hoặc OK, tuỳ bạn muốn xử lý gì ở Login
            this.Close();
        }
        //protected override void OnShown(EventArgs e)
        //{
        //    base.OnShown(e);

        //    lblBrand.AutoSize = true;
        //    lblBrandCare.AutoSize = true;

        //    // canh giữa lần đầu
        //    CenterBrand();

        //    // canh lại mỗi khi kích thước thay đổi
        //    this.Resize += (_, __) => CenterBrand();
        //    card.SizeChanged += (_, __) => CenterBrand();
        //    lblBrand.SizeChanged += (_, __) => CenterBrand();
        //    lblBrandCare.SizeChanged += (_, __) => CenterBrand();
        //}

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string pass = txtPass.Text.Trim();
            string role = "Staff";

            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thiếu dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var conn = new System.Data.SqlClient.SqlConnection(Program.ConnStr))
                using (var cmd = new System.Data.SqlClient.SqlCommand("sp_User_Register", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FullName", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", pass);
                    cmd.Parameters.AddWithValue("@Role", role);

                    conn.Open();
                    var newID = cmd.ExecuteScalar();
                    MessageBox.Show("Đăng ký thành công! ID người dùng: " + newID,
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                MessageBox.Show(ex.Message, "Đăng ký thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //protected override void OnShown(EventArgs e)
        //{
        //    base.OnShown(e);
        //    CenterBrand();
        //    CenterLink();
        //    this.Resize += (s, _) => { CenterBrand(); CenterLink(); };
        //}
        private void lblTitle_Click(object sender, EventArgs e) { }
        private void guna2Shapes1_Click(object sender, EventArgs e)
        {

        }
        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var f = new FrmRegister())
            {
                var result = f.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    MessageBox.Show("Bạn đã đăng ký thành công, hãy đăng nhập lại nhé!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void guna2Shapes2_Click(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {

        }

        private void lblBrandCare_Click(object sender, EventArgs e)
        {

        }

        private void lblBrandCare_Click_1(object sender, EventArgs e)
        {

        }

        private void lblBrand_Click(object sender, EventArgs e)
        {

        }

        
    }
}
