using PharmacyApp;                 // dùng Session
using PharmacyApp.UserControls;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PharmacyApp.Forms
{
    public partial class FrmAdminDashboard : Form
    {
        private readonly int _userId;
        private readonly string _fullName;
        private readonly string _role;

        private bool _isDashboardActive = true;

        public FrmAdminDashboard(int userId, string fullName, string role)
        {
            InitializeComponent();

            _userId = userId;
            _fullName = fullName;
            _role = role;

            // Brand
            lblBrand.Text =
                "<span style='color:#69C4F6;'>Eterna</span>" +
                "<span style='color:#36D7B7;'>Med</span>";
            lblBrand.Cursor = Cursors.Hand;

            // Tên user trên góc phải
            lblUserName.Text = fullName;
        }

        private void FrmAdminDashboard_Load(object sender, EventArgs e)
        {
            ShowDashboard();
        }

        private void ShowDashboard()
        {
            pContent.Controls.Clear();
            var dash = new UC_Dashboard();
            dash.Dock = DockStyle.Fill;
            pContent.Controls.Add(dash);

            pContent.Visible = true;
            _isDashboardActive = true;
        }

        private void LoadPage(UserControl uc)
        {
            pContent.Visible = true;
            pContent.Controls.Clear();

            uc.Dock = DockStyle.Fill;
            pContent.Controls.Add(uc);
            uc.BringToFront();

            _isDashboardActive = false;
        }

        // ===================== BRAND CLICK =====================
        private void lblBrand_Click(object sender, EventArgs e)
        {
            if (_isDashboardActive)
            {
                pContent.Visible = !pContent.Visible;   // ẩn / hiện dashboard
            }
            else
            {
                ShowDashboard();                       // từ trang khác quay lại dashboard
            }
        }

        private void lblBrand_MouseEnter(object sender, EventArgs e)
        {
            lblBrand.Cursor = Cursors.Hand;
            lblBrand.ForeColor = Color.FromArgb(105, 196, 246);
        }

        private void lblBrand_MouseLeave(object sender, EventArgs e)
        {
            lblBrand.Cursor = Cursors.Default;
            lblBrand.ForeColor = Color.White;
        }

        // ===================== MENU BÊN TRÁI =====================
        private void btnCatalog_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_Catalog());
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_Staff());
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_Report());
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_Warehouse());
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_POS());
        }

        private void btnInvoices_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_Invoices());
        }

        // ===================== PROFILE =====================
        private void btnProfile_Click(object sender, EventArgs e)
        {
            var uc = new UC_Profile
            {
                Dock = DockStyle.Fill,
                StaffId = Session.StaffId,               // lấy StaffId từ Session
                IsAdmin = Session.Role == "Admin"        // phân quyền
            };

            pContent.Controls.Clear();
            pContent.Controls.Add(uc);
            _isDashboardActive = false;
        }

        // ===================== LOGOUT =====================
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Reset session
                Session.IsLoggedIn = false;
                Session.UserId = 0;
                Session.StaffId = 0;
                Session.FullName = null;
                Session.Role = null;

                this.Hide();
                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Show();
                this.Close();
            }
        }

        // ====== Các event trống ======
        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }
        private void guna2Panel6_Paint(object sender, PaintEventArgs e) { }
        private void pTop_Paint(object sender, PaintEventArgs e) { }
        private void value4_Click(object sender, EventArgs e) { }
        private void lblApp_Click(object sender, EventArgs e) { }
        private void lblBrandCare_Click(object sender, EventArgs e) { }
        private void lblBrand_MouseMove(object sender, MouseEventArgs e) { lblBrand.Cursor = Cursors.Hand; }
        private void lblBrandCare_MouseMove(object sender, MouseEventArgs e) { lblBrand.Cursor = Cursors.Hand; }
    }
}
