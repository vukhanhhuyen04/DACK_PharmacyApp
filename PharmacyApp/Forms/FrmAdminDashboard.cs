using PharmacyApp.UserControls;
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
    // FrmAdminDashboard.cs
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
            lblBrand.Text =
     "<span style='color:#69C4F6;'>Eterna</span>" +
     "<span style='color:#36D7B7;'>Med</span>";

            lblBrand.Cursor = Cursors.Hand;
            //  lblBrandCare.Cursor = Cursors.Hand;



            lblUserName.Text = fullName;   // ví dụ label trên góc phải
        }
        private void lblBrand_MouseEnter(object sender, EventArgs e)
        {
            lblBrand.Cursor = Cursors.Hand;
            lblBrand.ForeColor = Color.FromArgb(105, 196, 246); // xanh nhạt
        }

        private void lblBrand_MouseLeave(object sender, EventArgs e)
        {
            lblBrand.Cursor = Cursors.Default;
            lblBrand.ForeColor = Color.White; // hoặc màu cũ
        }


        private void FrmAdminDashboard_Load(object sender, EventArgs e)
        {
            ShowDashboard();


            //_isDashboardActive = true;

            //// --- Dữ liệu biểu đồ doanh số ---
            //string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun" };
            //int[] sales = { 100, 120, 80, 160, 130, 200 };

            //// Lấy series "Sales", nếu chưa có thì tạo mới
            //var series = chartSales.Series["Sales"];
            //if (series == null)
            //{
            //    series = chartSales.Series.Add("Sales");
            //}

            //series.Points.DataBindXY(months, sales);
            //series.Color = Color.FromArgb(59, 201, 170);

            //// --- Dữ liệu sản phẩm bán chạy ---
            //gvTopProducts.Rows.Add("1", "Paracetamol 500mg", "340");
            //gvTopProducts.Rows.Add("2", "Vitamin C 1000mg", "310");
            //gvTopProducts.Rows.Add("3", "Panadol Extra", "280");
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


        private void lblBrandCare_Click(object sender, EventArgs e)
        {
            if (_isDashboardActive)
            {
                // Đang ở dashboard -> ẩn/hiện dashboard
                pContent.Visible = !pContent.Visible;
            }
            else
            {
                // Đang ở trang khác -> quay về dashboard
                ShowDashboard();
            }

        }

        private void lblApp_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //string keyword = txtSearch.Text.Trim();

            //if (pContent.Controls.Count == 0) return;

            //var current = pContent.Controls[0];

            //if (current is UC_Dashboard dash)
            //{
            //    dash.ApplySearch(keyword);   // gọi vào UC_Dashboard
            //}
            //else if (current is UC_Catalog catalog)
            //{
            //    catalog.ApplySearch(keyword); // nếu muốn dùng chung search cho Catalog
            //}
            //// ... các UC khác thì tùy bạn
        }


        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

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

        private void value4_Click(object sender, EventArgs e)
        {

        }
        private void ToggleContent()
        {
            pContent.Visible = !pContent.Visible;   // đổi trạng thái ẩn/hiện
        }

        private void lblBrand_Click(object sender, EventArgs e)
        {
            if (_isDashboardActive)
            {
                pContent.Visible = !pContent.Visible;
            }
            else
            {
                ShowDashboard();
            }
        }




        private void btnPOS_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_POS());
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_Profile());

        }
        private void btnInvoices_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_Invoices());
        }

        private void btnInvoices_Click_1(object sender, EventArgs e)
        {

        }

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
                // Ẩn dashboard hiện tại
                this.Hide();

                // Mở lại form đăng nhập
                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Show();

                // Đóng dashboard khi logout hoàn tất
                this.Close();
            }
        }


        private void guna2Panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblBrand_MouseMove(object sender, MouseEventArgs e)
        {
            lblBrand.Cursor = Cursors.Hand;
        }

        private void lblBrandCare_MouseMove(object sender, MouseEventArgs e)
        {
            lblBrand.Cursor = Cursors.Hand;
        }

        private void pTop_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
