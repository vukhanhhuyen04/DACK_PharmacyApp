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

        public FrmAdminDashboard(int userId, string fullName, string role)
        {
            InitializeComponent();
            _userId = userId;
            _fullName = fullName;
            _role = role;
            lblBrand.Cursor = Cursors.Hand;
            lblBrandCare.Cursor = Cursors.Hand;

            lblUserName.Text = fullName;   // ví dụ label trên góc phải
        }
        private void lblBrand_MouseEnter(object sender, EventArgs e)
        {
            lblBrand.ForeColor = Color.FromArgb(105, 196, 246); // xanh nhạt
        }

        private void lblBrand_MouseLeave(object sender, EventArgs e)
        {
            lblBrand.ForeColor = Color.White; // hoặc màu cũ
        }


        private void FrmAdminDashboard_Load(object sender, EventArgs e)
        {
            // --- Dữ liệu biểu đồ doanh số ---
            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun" };
            int[] sales = { 100, 120, 80, 160, 130, 200 };
            chartSales.Series["Sales"].Points.DataBindXY(months, sales);
            chartSales.Series["Sales"].Color = Color.FromArgb(59, 201, 170);

            // --- Dữ liệu sản phẩm bán chạy ---
            gvTopProducts.Rows.Add("1", "Paracetamol 500mg", "340");
            gvTopProducts.Rows.Add("2", "Vitamin C 1000mg", "310");
            gvTopProducts.Rows.Add("3", "Panadol Extra", "280");
        }
        private void LoadPage(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;

            pContent.Controls.Clear();
            pContent.Controls.Add(uc);

            uc.BringToFront();
        }

        private void lblBrandCare_Click(object sender, EventArgs e)
        {
            ToggleContent();

        }

        private void lblApp_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

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
            pContent.Visible = !pContent.Visible;
        }

        private void lblBrandCare_Click_1(object sender, EventArgs e)
        {

        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_POS());
        }
    }
}
