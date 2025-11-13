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

            lblUserName.Text = fullName;   // ví dụ label trên góc phải
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

        private void lblBrandCare_Click(object sender, EventArgs e)
        {

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
    }
}
