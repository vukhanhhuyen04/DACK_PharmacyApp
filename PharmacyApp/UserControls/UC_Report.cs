using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using PharmacyApp.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;



namespace PharmacyApp.UserControls
{
    public partial class UC_Report : UserControl
    {
        public UC_Report()
        {
            InitializeComponent();

            // Gắn event
            this.Load += UC_Report_Load;
            btnFilter.Click += BtnFilter_Click;
           // btnExportPdf.Click += BtnExportPdf_Click;
            cboPeriod.SelectedIndexChanged += cboPeriod_SelectedIndexChanged;
           

        }

        // ==============================
        // 1. KHỞI TẠO LÚC LOAD
        // ==============================
        private void UC_Report_Load(object sender, EventArgs e)
        {
            InitCombos();
            LoadReportData();
        }

        private void InitCombos()
        {
            // Kỳ báo cáo
            cboPeriod.Items.Clear();
            cboPeriod.Items.AddRange(new object[] { "Ngày", "Tháng", "Năm" });
            if (cboPeriod.SelectedIndex < 0)
                cboPeriod.SelectedIndex = 0; // mặc định: Ngày

            // Tháng 1-12
            cboMonth.Items.Clear();
            for (int m = 1; m <= 12; m++)
                cboMonth.Items.Add(m.ToString("00"));
            cboMonth.SelectedIndex = DateTime.Now.Month - 1;

            // Năm: 5 năm gần nhất
            cboYear.Items.Clear();
            int yearNow = DateTime.Now.Year;
            for (int y = yearNow - 4; y <= yearNow; y++)
                cboYear.Items.Add(y.ToString());
            cboYear.SelectedIndex = cboYear.Items.Count - 1;
        }


        // ==============================
        // 2. EVENT COMBOBOX / BUTTON
        // ==============================
        private void cboPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            string period = cboPeriod.SelectedItem?.ToString() ?? "";

            // Chỉ khi xem theo NGÀY mới cần chọn THÁNG
            cboMonth.Enabled = (period == "Ngày");

            LoadReportData();
        }



        private void BtnFilter_Click(object sender, EventArgs e)
        {
            LoadReportData();
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF File|*.pdf";
            save.FileName = $"BaoCaoDoanhThu_{DateTime.Now:yyyyMMdd}.pdf";

            if (save.ShowDialog() != DialogResult.OK) return;

            try
            {
                Document doc = new Document(PageSize.A4, 25, 25, 25, 30);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(save.FileName, FileMode.Create));
                doc.Open();

                // ====== FONT UNICODE HỖ TRỢ TIẾNG VIỆT ======
                var blue = new BaseColor(46, 99, 167);  // màu thương hiệu

                string fontsPath = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
                string fontPath = Path.Combine(fontsPath, "arial.ttf");   // có sẵn trên Windows

                BaseFont bfUni = BaseFont.CreateFont(
                    fontPath,
                    BaseFont.IDENTITY_H,   // Unicode
                    BaseFont.EMBEDDED      // nhúng font vào PDF
                );

                var fontLogo = new iTextSharp.text.Font(bfUni, 14, iTextSharp.text.Font.BOLD, blue);
                var fontTitle = new iTextSharp.text.Font(bfUni, 22, iTextSharp.text.Font.BOLD, blue);
                var fontInfo = new iTextSharp.text.Font(bfUni, 11, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                var fontHeader = new iTextSharp.text.Font(bfUni, 11, iTextSharp.text.Font.BOLD, BaseColor.WHITE);
                var fontCell = new iTextSharp.text.Font(bfUni, 10, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                var fontChartTitle = new iTextSharp.text.Font(bfUni, 14, iTextSharp.text.Font.BOLD, blue);
                var fontFooter = new iTextSharp.text.Font(bfUni, 9, iTextSharp.text.Font.ITALIC, BaseColor.GRAY);

                // ------------------------------
                // 1) HEADER BÁO CÁO
                // ------------------------------
                var headerTable = new PdfPTable(2);
                headerTable.WidthPercentage = 100;
                headerTable.SetWidths(new float[] { 1f, 3f });

                PdfPCell cellLogo = new PdfPCell(new Phrase("EternaMed", fontLogo));
                cellLogo.HorizontalAlignment = Element.ALIGN_LEFT;
                cellLogo.Border = PdfPCell.NO_BORDER;
                headerTable.AddCell(cellLogo);

                PdfPCell cellTitle = new PdfPCell(new Phrase("BÁO CÁO DOANH THU", fontTitle));
                cellTitle.HorizontalAlignment = Element.ALIGN_RIGHT;
                cellTitle.VerticalAlignment = Element.ALIGN_MIDDLE;
                cellTitle.Border = PdfPCell.NO_BORDER;
                headerTable.AddCell(cellTitle);

                doc.Add(headerTable);

                // Line dưới header
                var line = new LineSeparator(1f, 100f, blue, Element.ALIGN_CENTER, -2);
                doc.Add(new Chunk(line));
                doc.Add(new Paragraph("\n"));

                // ------------------------------
                // 2) THÔNG TIN BÁO CÁO
                // ------------------------------
                doc.Add(new Paragraph($"• Kỳ báo cáo: {cboPeriod.Text}", fontInfo));
                doc.Add(new Paragraph($"• Thời gian: Tháng {cboMonth.Text} / Năm {cboYear.Text}", fontInfo));
                doc.Add(new Paragraph($"• Ngày tạo báo cáo: {DateTime.Now:dd/MM/yyyy}", fontInfo));
                doc.Add(new Paragraph("\n"));

                // ------------------------------
                // 3) BẢNG DOANH THU
                // ------------------------------
                PdfPTable table = new PdfPTable(gvRevenue.Columns.Count);
                table.WidthPercentage = 100;
                table.SpacingBefore = 10f;
                table.SpacingAfter = 10f;

                // Header bảng
                foreach (DataGridViewColumn col in gvRevenue.Columns)
                {
                    PdfPCell header = new PdfPCell(new Phrase(col.HeaderText, fontHeader));
                    header.BackgroundColor = blue;
                    header.Padding = 5;
                    header.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(header);
                }

                // Dữ liệu
                bool alternate = false;
                foreach (DataGridViewRow row in gvRevenue.Rows)
                {
                    if (row.IsNewRow) continue;

                    alternate = !alternate;
                    BaseColor bgColor = alternate ? new BaseColor(245, 245, 250) : BaseColor.WHITE;

                    foreach (DataGridViewCell c in row.Cells)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(c.Value?.ToString() ?? "", fontCell));
                        cell.BackgroundColor = bgColor;
                        cell.Padding = 4;
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cell);
                    }
                }

                doc.Add(table);
                doc.Add(new Paragraph("\n"));

                // ------------------------------
                // 4) BIỂU ĐỒ DOANH THU
                // ------------------------------
                Paragraph chartTitle1 = new Paragraph("Biểu đồ doanh thu", fontChartTitle);
                chartTitle1.Alignment = Element.ALIGN_CENTER;
                doc.Add(chartTitle1);
                doc.Add(new Paragraph("\n"));

                iTextSharp.text.Image chart1 =
                    iTextSharp.text.Image.GetInstance(ChartToImage(chartRevenue));
                chart1.ScaleToFit(480f, 260f);
                chart1.Alignment = Element.ALIGN_CENTER;
                doc.Add(chart1);

                doc.Add(new Paragraph("\n\n"));

                // ------------------------------
                // 5) BIỂU ĐỒ TOP SẢN PHẨM
                // ------------------------------
                Paragraph chartTitle2 = new Paragraph("Top sản phẩm bán chạy", fontChartTitle);
                chartTitle2.Alignment = Element.ALIGN_CENTER;
                doc.Add(chartTitle2);
                doc.Add(new Paragraph("\n"));

                iTextSharp.text.Image chart2 =
                    iTextSharp.text.Image.GetInstance(ChartToImage(chartTopProducts));
                chart2.ScaleToFit(480f, 260f);
                chart2.Alignment = Element.ALIGN_CENTER;
                doc.Add(chart2);

                doc.Add(new Paragraph("\n\n"));

                // ------------------------------
                // 6) FOOTER
                // ------------------------------
                Paragraph footer = new Paragraph("EternaMed Reporting System © 2025", fontFooter);
                footer.Alignment = Element.ALIGN_CENTER;
                doc.Add(footer);

                doc.Close();

                MessageBox.Show("Xuất PDF thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi PDF:\n" + ex.Message);
            }
        }





        // ==============================
        // 3. LOAD DỮ LIỆU BÁO CÁO
        // ==============================
        private void LoadReportData()
        {
            if (cboPeriod.SelectedItem == null || cboYear.SelectedItem == null)
                return;

            string period = cboPeriod.SelectedItem.ToString();
            int year = int.Parse(cboYear.SelectedItem.ToString());
            int month = (cboMonth.SelectedItem != null)
                        ? int.Parse(cboMonth.SelectedItem.ToString())
                        : DateTime.Now.Month;

            DataTable dtRevenue = new DataTable();

            switch (period)
            {
                case "Ngày":
                    // Doanh thu từng ngày trong THÁNG đã chọn
                    dtRevenue = LoadRevenueByDay(year, month);
                    break;

                case "Tháng":
                    // Doanh thu từng THÁNG trong NĂM đã chọn
                    dtRevenue = LoadRevenueByMonth(year);
                    break;

                case "Năm":
                    // Doanh thu từng NĂM (từ năm đầu đến năm đã chọn)
                    dtRevenue = LoadRevenueByYear(year);
                    break;

                default:
                    dtRevenue = new DataTable();
                    break;
            }

            // Bind grid
            gvRevenue.DataSource = dtRevenue;

            // Đảm bảo DataPropertyName đúng với cột SQL
            colNgay.DataPropertyName = "Ngay";
            colTongSoDon.DataPropertyName = "TongSoDon";
            colTongTien.DataPropertyName = "TongTien";
            colPhuongThuc.DataPropertyName = "PaymentMethod";

            // Vẽ chart doanh thu + top sản phẩm
            BindRevenueChart(dtRevenue);
            BindTopProductsChart(year, month, period);
            // Căn giữa header
            gvRevenue.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            // Căn giữa toàn bộ nội dung
            foreach (DataGridViewColumn col in gvRevenue.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

        }




        // ==============================
        // 4. SQL LẤY DỮ LIỆU TỪ DB
        // ==============================
        // TODO: ĐỔI lại tên bảng/cột cho đúng CSDL của bạn:
        //  - Invoices(InvoiceId, InvoiceDate, TotalAmount, PaymentMethod)
        //  - InvoiceDetails(InvoiceId, ProductId, Quantity, UnitPrice)
        //  - Products(ProductId, ProductName)
        // 4. SQL LẤY DỮ LIỆU TỪ DB
        // ==============================
        private DataTable LoadRevenueByDay(int year, int month)
        {
            string sql = @"
        SELECT 
            DAY(CreatedAt)           AS Ngay,
            PaymentMethod,
            COUNT(*)                 AS TongSoDon,
            SUM(TotalAmount)         AS TongTien
        FROM Invoices
        WHERE YEAR(CreatedAt) = @Year
          AND MONTH(CreatedAt) = @Month
        GROUP BY DAY(CreatedAt), PaymentMethod
        ORDER BY Ngay";

            return DBHelper.GetDataTable(sql,
                new SqlParameter("@Year", year),
                new SqlParameter("@Month", month));
        }



        private DataTable LoadRevenueByWeek(int year)
        {
            string sql = @"
        SELECT 
            DATEPART(WEEK, CreatedAt)  AS Ngay,
            PaymentMethod,
            COUNT(*)                   AS TongSoDon,
            SUM(TotalAmount)           AS TongTien
        FROM Invoices
        WHERE YEAR(CreatedAt) = @Year
        GROUP BY DATEPART(WEEK, CreatedAt), PaymentMethod
        ORDER BY Ngay";

            return DBHelper.GetDataTable(sql,
                new SqlParameter("@Year", year));
        }

        private DataTable LoadRevenueByMonth(int year)
        {
            string sql = @"
        SELECT 
            MONTH(CreatedAt)         AS Ngay,
            PaymentMethod,
            COUNT(*)                 AS TongSoDon,
            SUM(TotalAmount)         AS TongTien
        FROM Invoices
        WHERE YEAR(CreatedAt) = @Year
        GROUP BY MONTH(CreatedAt), PaymentMethod
        ORDER BY Ngay";

            return DBHelper.GetDataTable(sql,
                new SqlParameter("@Year", year));
        }


        private DataTable LoadRevenueByYear(int year)
        {
            string sql = @"
        SELECT 
            YEAR(CreatedAt)          AS Ngay,
            PaymentMethod,
            COUNT(*)                 AS TongSoDon,
            SUM(TotalAmount)         AS TongTien
        FROM Invoices
        WHERE YEAR(CreatedAt) <= @Year
        GROUP BY YEAR(CreatedAt), PaymentMethod
        ORDER BY Ngay";

            return DBHelper.GetDataTable(sql,
                new SqlParameter("@Year", year));
        }



        // ==============================
        // 5. VẼ CHART DOANH THU
        // ==============================
        private void BindRevenueChart(DataTable dt)
        {
            var series = chartRevenue.Series["Series1"];
            series.Points.Clear();
            series.ChartType = SeriesChartType.Column;

            if (dt == null || dt.Rows.Count == 0)
                return;

            // Tùy kiểu cột Ngay mà group cho đúng
            if (dt.Columns["Ngay"].DataType == typeof(DateTime))
            {
                var groups = dt.AsEnumerable()
                               .GroupBy(r => r.Field<DateTime>("Ngay"))
                               .Select(g => new
                               {
                                   Ngay = g.Key,
                                   TongTien = g.Sum(r => Convert.ToDecimal(r["TongTien"]))
                               })
                               .OrderBy(x => x.Ngay);

                foreach (var item in groups)
                {
                    string label = item.Ngay.ToString("dd/MM");
                    series.Points.AddXY(label, (double)item.TongTien);
                }
            }
            else
            {
                var groups = dt.AsEnumerable()
                               .GroupBy(r => Convert.ToInt32(r["Ngay"]))
                               .Select(g => new
                               {
                                   Key = g.Key,
                                   TongTien = g.Sum(r => Convert.ToDecimal(r["TongTien"]))
                               })
                               .OrderBy(x => x.Key);

                foreach (var item in groups)
                {
                    string label = item.Key.ToString();
                    series.Points.AddXY(label, (double)item.TongTien);
                }
            }
        }

        // ==============================
        // 6. VẼ CHART TOP SẢN PHẨM
        // ==============================
        // 6. VẼ CHART TOP SẢN PHẨM
        // ==============================
        private void BindTopProductsChart(int year, int month, string period)
        {
            var series = chartTopProducts.Series["Series1"];
            series.Points.Clear();
            series.ChartType = SeriesChartType.Column;

            // where clause cho kỳ báo cáo
            string sqlWhere;
            var pars = new List<SqlParameter>
    {
        new SqlParameter("@Year", year)
    };

            if (period == "Ngày" || period == "Tháng")
            {
                sqlWhere = "YEAR(i.CreatedAt) = @Year AND MONTH(i.CreatedAt) = @Month";
                pars.Add(new SqlParameter("@Month", month));
            }
            else
            {
                sqlWhere = "YEAR(i.CreatedAt) = @Year";
            }

            string sql = $@"
        SELECT TOP 5
            p.ProductName,
            SUM(d.LineTotal) AS TongTien
        FROM InvoiceDetails d
        INNER JOIN Invoices  i ON d.InvoiceId = i.InvoiceId
        INNER JOIN Products  p ON d.ProductId = p.ProductId
        WHERE {sqlWhere}
        GROUP BY p.ProductName
        ORDER BY TongTien DESC";

            DataTable dt = DBHelper.GetDataTable(sql, pars.ToArray());

            if (dt == null || dt.Rows.Count == 0)
                return;

            foreach (DataRow row in dt.Rows)
            {
                string name = row["ProductName"].ToString();
                double amount = Convert.ToDouble(row["TongTien"]);
                series.Points.AddXY(name, amount);
            }
        }
        private byte[] ChartToImage(Chart chart)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                chart.SaveImage(ms, ChartImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
