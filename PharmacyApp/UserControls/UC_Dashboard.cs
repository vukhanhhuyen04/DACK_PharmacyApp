using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using PharmacyApp.Helpers;   // để dùng DBHelper

namespace PharmacyApp.UserControls
{
    public partial class UC_Dashboard : UserControl
    {
        public UC_Dashboard()
        {
            InitializeComponent();

            // Designer đã gán this.Load += UC_Dashboard_Load rồi
            // => không gán lại nữa để tránh chạy double.
            // this.Load += UC_Dashboard_Load;
        }

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                LoadMetricCards();   // 4 ô thống kê
                LoadSalesChart();    // Biểu đồ doanh số
                LoadTopProducts();   // Bảng top sản phẩm
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải Dashboard: " + ex.Message,
                                "Dashboard", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================================
        // 1. 4 Ô THỐNG KÊ TRÊN ĐẦU
        // =====================================================================
        private void LoadMetricCards()
        {
            // 1. Dược sĩ đang hoạt động (IsActive = 1)
            int activeStaff = ExecInt(@"
                SELECT COUNT(*) 
                FROM Staff
                WHERE IsActive = 1;
            ");

            // 2. Tổng số dược sĩ
            int totalStaff = ExecInt(@"
                SELECT COUNT(*)
                FROM Staff;
            ");

            // 3. Số đơn hàng (hoá đơn) trong ngày
            int todayInvoices = ExecInt(@"
                SELECT COUNT(*)
                FROM Invoices
                WHERE CAST(CreatedAt AS date) = CAST(GETDATE() AS date);
            ");

            // 4. Tổng doanh thu trong ngày
            decimal todayRevenue = ExecDecimal(@"
                SELECT ISNULL(SUM(TotalAmount), 0)
                FROM Invoices
                WHERE CAST(CreatedAt AS date) = CAST(GETDATE() AS date);
            ");

            // Gán ra 4 label (Label thường)
            value1.Text = activeStaff.ToString();       // Dược sĩ đang hoạt động
            value2.Text = totalStaff.ToString();        // Tổng dược sĩ
            value3.Text = todayInvoices.ToString();     // Số hoá đơn hôm nay
            value4.Text = todayRevenue.ToString("N0");  // Doanh thu hôm nay (1.000.000)
        }

        // =====================================================================
        // 2. BIỂU ĐỒ DOANH SỐ (Invoices)
        // =====================================================================
        private void LoadSalesChart()
        {
            string sql = @"
                SELECT TOP 12
                       FORMAT(CreatedAt, 'MM/yyyy') AS Thang,
                       SUM(TotalAmount) AS DoanhThu
                FROM Invoices
                GROUP BY FORMAT(CreatedAt, 'MM/yyyy')
                ORDER BY MIN(CreatedAt);";

            DataTable dt = DBHelper.GetDataTable(sql);

            chartSales.Series.Clear();
            Series series = chartSales.Series.Add("Sales");
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.FromArgb(59, 201, 170);

            foreach (DataRow row in dt.Rows)
            {
                string month = row["Thang"].ToString();
                decimal total = row.Field<decimal>("DoanhThu");
                series.Points.AddXY(month, total);
            }
        }

        // =====================================================================
        // 3. BẢNG TOP SẢN PHẨM BÁN CHẠY
        // =====================================================================
        private void LoadTopProducts()
        {
            string sql = @"
                SELECT TOP 5
                       p.ProductName,
                       SUM(d.Quantity) AS SoLuongBan
                FROM InvoiceDetails d
                INNER JOIN Invoices  i ON i.InvoiceId  = d.InvoiceId
                INNER JOIN Products  p ON p.ProductId  = d.ProductId
                -- bạn muốn trong ngày thì đổi thành:
                -- WHERE CAST(i.CreatedAt AS date) = CAST(GETDATE() AS date)
                WHERE i.CreatedAt >= DATEADD(day, -30, GETDATE())
                GROUP BY p.ProductName
                ORDER BY SoLuongBan DESC;";

            DataTable dt = DBHelper.GetDataTable(sql);

            gvTopProducts.Rows.Clear();
            int stt = 1;

            foreach (DataRow row in dt.Rows)
            {
                string name = row["ProductName"].ToString();
                int qty = Convert.ToInt32(row["SoLuongBan"]);

                gvTopProducts.Rows.Add(stt.ToString(), name, qty.ToString());
                stt++;
            }
        }

        // =====================================================================
        // 4. HÀM HỖ TRỢ DÙNG DBHelper.ExecuteScalar
        // =====================================================================
        private int ExecInt(string sql)
        {
            object result = DBHelper.ExecuteScalar(sql);
            if (result == null || result == DBNull.Value)
                return 0;

            return Convert.ToInt32(result);
        }

        private decimal ExecDecimal(string sql)
        {
            object result = DBHelper.ExecuteScalar(sql);
            if (result == null || result == DBNull.Value)
                return 0m;

            return Convert.ToDecimal(result);
        }
    }
}
