using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyApp.UserControls
{
    public partial class UC_Dashboard : UserControl
    {
        public UC_Dashboard()
        {
            InitializeComponent();
            this.Load += UC_Dashboard_Load;
        }

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            // --- Dữ liệu biểu đồ doanh số ---
            string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun" };
            int[] sales = { 100, 120, 80, 160, 130, 200 };

            var series = chartSales.Series["Sales"];
            if (series == null)
            {
                series = chartSales.Series.Add("Sales");
            }

            series.Points.Clear();
            series.Points.DataBindXY(months, sales);
            series.Color = Color.FromArgb(59, 201, 170);

            // --- Dữ liệu sản phẩm bán chạy ---
            gvTopProducts.Rows.Clear();
            gvTopProducts.Rows.Add("1", "Paracetamol 500mg", "340");
            gvTopProducts.Rows.Add("2", "Vitamin C 1000mg", "310");
            gvTopProducts.Rows.Add("3", "Panadol Extra", "280");
        }
    }
}
