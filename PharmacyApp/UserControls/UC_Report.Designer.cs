namespace PharmacyApp.UserControls
{
    partial class UC_Report
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pRoot = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTilte = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pFilter = new Guna.UI2.WinForms.Guna2Panel();
            this.cboPeriod = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.cboMonth = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnExportPdf = new Guna.UI2.WinForms.Guna2Button();
            this.tlpCharts = new System.Windows.Forms.TableLayoutPanel();
            this.pChartRevenue = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChartRevenue = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pChartTopProducts = new Guna.UI2.WinForms.Guna2Panel();
            this.chartTopProducts = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblChartTopProducts = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pGrid = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            this.gvRevenue = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongSoDon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTongTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhuongThuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cboYear = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnFilter = new Guna.UI2.WinForms.Guna2Button();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.lblMonth = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.pRoot.SuspendLayout();
            this.pFilter.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.tlpCharts.SuspendLayout();
            this.pChartRevenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
            this.pChartTopProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopProducts)).BeginInit();
            this.pGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRevenue)).BeginInit();
            this.SuspendLayout();
            // 
            // pRoot
            // 
            this.pRoot.Controls.Add(this.pGrid);
            this.pRoot.Controls.Add(this.tlpCharts);
            this.pRoot.Controls.Add(this.guna2Panel1);
            this.pRoot.Controls.Add(this.pFilter);
            this.pRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRoot.FillColor = System.Drawing.Color.WhiteSmoke;
            this.pRoot.Location = new System.Drawing.Point(0, 0);
            this.pRoot.Name = "pRoot";
            this.pRoot.Size = new System.Drawing.Size(1023, 630);
            this.pRoot.TabIndex = 0;
            // 
            // lblTilte
            // 
            this.lblTilte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTilte.BackColor = System.Drawing.Color.Transparent;
            this.lblTilte.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTilte.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(99)))), ((int)(((byte)(167)))));
            this.lblTilte.Location = new System.Drawing.Point(20, 12);
            this.lblTilte.Name = "lblTilte";
            this.lblTilte.Size = new System.Drawing.Size(265, 43);
            this.lblTilte.TabIndex = 0;
            this.lblTilte.Text = "Báo cáo doanh thu";
            // 
            // pFilter
            // 
            this.pFilter.Controls.Add(this.lblTilte);
            this.pFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pFilter.FillColor = System.Drawing.Color.WhiteSmoke;
            this.pFilter.Location = new System.Drawing.Point(0, 0);
            this.pFilter.Name = "pFilter";
            this.pFilter.Size = new System.Drawing.Size(1023, 70);
            this.pFilter.TabIndex = 1;
            // 
            // cboPeriod
            // 
            this.cboPeriod.BackColor = System.Drawing.Color.Transparent;
            this.cboPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPeriod.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboPeriod.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboPeriod.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPeriod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboPeriod.ItemHeight = 30;
            this.cboPeriod.Items.AddRange(new object[] {
            "Ngày",
            "Tuần",
            "Tháng",
            "Năm"});
            this.cboPeriod.Location = new System.Drawing.Point(138, 14);
            this.cboPeriod.Name = "cboPeriod";
            this.cboPeriod.Size = new System.Drawing.Size(120, 36);
            this.cboPeriod.TabIndex = 2;
            this.cboPeriod.SelectedIndexChanged += new System.EventHandler(this.cboPeriod_SelectedIndexChanged);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.lblYear);
            this.guna2Panel1.Controls.Add(this.lblMonth);
            this.guna2Panel1.Controls.Add(this.lblPeriod);
            this.guna2Panel1.Controls.Add(this.btnFilter);
            this.guna2Panel1.Controls.Add(this.btnExportPdf);
            this.guna2Panel1.Controls.Add(this.cboYear);
            this.guna2Panel1.Controls.Add(this.cboMonth);
            this.guna2Panel1.Controls.Add(this.cboPeriod);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.FillColor = System.Drawing.Color.WhiteSmoke;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 70);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1023, 70);
            this.guna2Panel1.TabIndex = 3;
            // 
            // cboMonth
            // 
            this.cboMonth.BackColor = System.Drawing.Color.Transparent;
            this.cboMonth.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonth.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMonth.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboMonth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboMonth.ItemHeight = 30;
            this.cboMonth.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cboMonth.Location = new System.Drawing.Point(366, 14);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(80, 36);
            this.cboMonth.TabIndex = 4;
            // 
            // btnExportPdf
            // 
            this.btnExportPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportPdf.BorderRadius = 6;
            this.btnExportPdf.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnExportPdf.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnExportPdf.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnExportPdf.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnExportPdf.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnExportPdf.ForeColor = System.Drawing.Color.White;
            this.btnExportPdf.Location = new System.Drawing.Point(895, 15);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new System.Drawing.Size(100, 36);
            this.btnExportPdf.TabIndex = 7;
            this.btnExportPdf.Text = "Xuất PDF";
            // 
            // tlpCharts
            // 
            this.tlpCharts.ColumnCount = 2;
            this.tlpCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCharts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCharts.Controls.Add(this.pChartTopProducts, 1, 0);
            this.tlpCharts.Controls.Add(this.pChartRevenue, 0, 0);
            this.tlpCharts.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpCharts.Location = new System.Drawing.Point(0, 140);
            this.tlpCharts.Name = "tlpCharts";
            this.tlpCharts.RowCount = 1;
            this.tlpCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCharts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCharts.Size = new System.Drawing.Size(1023, 300);
            this.tlpCharts.TabIndex = 4;
            // 
            // pChartRevenue
            // 
            this.pChartRevenue.Controls.Add(this.chartRevenue);
            this.pChartRevenue.Controls.Add(this.lblChartRevenue);
            this.pChartRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pChartRevenue.Location = new System.Drawing.Point(3, 3);
            this.pChartRevenue.Name = "pChartRevenue";
            this.pChartRevenue.Size = new System.Drawing.Size(505, 294);
            this.pChartRevenue.TabIndex = 0;
            // 
            // lblChartRevenue
            // 
            this.lblChartRevenue.BackColor = System.Drawing.Color.Transparent;
            this.lblChartRevenue.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChartRevenue.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartRevenue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(99)))), ((int)(((byte)(167)))));
            this.lblChartRevenue.Location = new System.Drawing.Point(0, 0);
            this.lblChartRevenue.Name = "lblChartRevenue";
            this.lblChartRevenue.Size = new System.Drawing.Size(505, 25);
            this.lblChartRevenue.TabIndex = 6;
            this.lblChartRevenue.Text = "Biểu đồ doanh thu";
            // 
            // chartRevenue
            // 
            chartArea3.Name = "ChartArea1";
            this.chartRevenue.ChartAreas.Add(chartArea3);
            this.chartRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chartRevenue.Legends.Add(legend3);
            this.chartRevenue.Location = new System.Drawing.Point(0, 25);
            this.chartRevenue.Name = "chartRevenue";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chartRevenue.Series.Add(series3);
            this.chartRevenue.Size = new System.Drawing.Size(505, 269);
            this.chartRevenue.TabIndex = 7;
            this.chartRevenue.Text = "chart1";
            // 
            // pChartTopProducts
            // 
            this.pChartTopProducts.Controls.Add(this.chartTopProducts);
            this.pChartTopProducts.Controls.Add(this.lblChartTopProducts);
            this.pChartTopProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pChartTopProducts.Location = new System.Drawing.Point(514, 3);
            this.pChartTopProducts.Name = "pChartTopProducts";
            this.pChartTopProducts.Size = new System.Drawing.Size(506, 294);
            this.pChartTopProducts.TabIndex = 1;
            // 
            // chartTopProducts
            // 
            chartArea4.Name = "ChartArea1";
            this.chartTopProducts.ChartAreas.Add(chartArea4);
            this.chartTopProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            legend4.Name = "Legend1";
            this.chartTopProducts.Legends.Add(legend4);
            this.chartTopProducts.Location = new System.Drawing.Point(0, 25);
            this.chartTopProducts.Name = "chartTopProducts";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartTopProducts.Series.Add(series4);
            this.chartTopProducts.Size = new System.Drawing.Size(506, 269);
            this.chartTopProducts.TabIndex = 7;
            this.chartTopProducts.Text = "chart1";
            // 
            // lblChartTopProducts
            // 
            this.lblChartTopProducts.BackColor = System.Drawing.Color.Transparent;
            this.lblChartTopProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblChartTopProducts.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartTopProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(99)))), ((int)(((byte)(167)))));
            this.lblChartTopProducts.Location = new System.Drawing.Point(0, 0);
            this.lblChartTopProducts.Name = "lblChartTopProducts";
            this.lblChartTopProducts.Size = new System.Drawing.Size(506, 25);
            this.lblChartTopProducts.TabIndex = 6;
            this.lblChartTopProducts.Text = "Top sản phẩm bán chạy";
            // 
            // pGrid
            // 
            this.pGrid.BorderRadius = 8;
            this.pGrid.Controls.Add(this.gvRevenue);
            this.pGrid.Controls.Add(this.guna2DataGridView1);
            this.pGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pGrid.FillColor = System.Drawing.Color.White;
            this.pGrid.Location = new System.Drawing.Point(0, 440);
            this.pGrid.Name = "pGrid";
            this.pGrid.Size = new System.Drawing.Size(1023, 190);
            this.pGrid.TabIndex = 5;
            // 
            // guna2DataGridView1
            // 
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.guna2DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle11;
            this.guna2DataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.Location = new System.Drawing.Point(431, 108);
            this.guna2DataGridView1.Name = "guna2DataGridView1";
            this.guna2DataGridView1.RowHeadersVisible = false;
            this.guna2DataGridView1.RowHeadersWidth = 51;
            this.guna2DataGridView1.RowTemplate.Height = 24;
            this.guna2DataGridView1.Size = new System.Drawing.Size(8, 8);
            this.guna2DataGridView1.TabIndex = 1;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.guna2DataGridView1.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 4;
            this.guna2DataGridView1.ThemeStyle.ReadOnly = false;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.Height = 24;
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // gvRevenue
            // 
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            this.gvRevenue.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvRevenue.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.gvRevenue.ColumnHeadersHeight = 18;
            this.gvRevenue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.gvRevenue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNgay,
            this.colTongSoDon,
            this.colTongTien,
            this.colPhuongThuc});
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvRevenue.DefaultCellStyle = dataGridViewCellStyle16;
            this.gvRevenue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvRevenue.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gvRevenue.Location = new System.Drawing.Point(0, 0);
            this.gvRevenue.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.gvRevenue.MultiSelect = false;
            this.gvRevenue.Name = "gvRevenue";
            this.gvRevenue.ReadOnly = true;
            this.gvRevenue.RowHeadersVisible = false;
            this.gvRevenue.RowHeadersWidth = 51;
            this.gvRevenue.RowTemplate.Height = 24;
            this.gvRevenue.Size = new System.Drawing.Size(1023, 190);
            this.gvRevenue.TabIndex = 16;
            this.gvRevenue.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gvRevenue.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gvRevenue.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gvRevenue.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gvRevenue.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gvRevenue.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.gvRevenue.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gvRevenue.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gvRevenue.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gvRevenue.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvRevenue.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gvRevenue.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.gvRevenue.ThemeStyle.HeaderStyle.Height = 18;
            this.gvRevenue.ThemeStyle.ReadOnly = true;
            this.gvRevenue.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gvRevenue.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gvRevenue.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvRevenue.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gvRevenue.ThemeStyle.RowsStyle.Height = 24;
            this.gvRevenue.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gvRevenue.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // colNgay
            // 
            this.colNgay.DataPropertyName = "TotalOrders";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "dd/MM/yyyy";
            this.colNgay.DefaultCellStyle = dataGridViewCellStyle14;
            this.colNgay.HeaderText = "Ngày";
            this.colNgay.MinimumWidth = 6;
            this.colNgay.Name = "colNgay";
            this.colNgay.ReadOnly = true;
            // 
            // colTongSoDon
            // 
            this.colTongSoDon.HeaderText = "Tổng số đơn";
            this.colTongSoDon.MinimumWidth = 6;
            this.colTongSoDon.Name = "colTongSoDon";
            this.colTongSoDon.ReadOnly = true;
            // 
            // colTongTien
            // 
            this.colTongTien.DataPropertyName = "TotalAmount";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N0";
            this.colTongTien.DefaultCellStyle = dataGridViewCellStyle15;
            this.colTongTien.HeaderText = "Tổng tiền";
            this.colTongTien.MinimumWidth = 6;
            this.colTongTien.Name = "colTongTien";
            this.colTongTien.ReadOnly = true;
            // 
            // colPhuongThuc
            // 
            this.colPhuongThuc.DataPropertyName = "PaymentMethod";
            this.colPhuongThuc.HeaderText = "Phương thức";
            this.colPhuongThuc.MinimumWidth = 6;
            this.colPhuongThuc.Name = "colPhuongThuc";
            this.colPhuongThuc.ReadOnly = true;
            // 
            // cboYear
            // 
            this.cboYear.BackColor = System.Drawing.Color.Transparent;
            this.cboYear.BorderRadius = 6;
            this.cboYear.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboYear.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboYear.ItemHeight = 30;
            this.cboYear.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cboYear.Location = new System.Drawing.Point(569, 15);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(90, 36);
            this.cboYear.TabIndex = 6;
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.BorderRadius = 6;
            this.btnFilter.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFilter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFilter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFilter.ForeColor = System.Drawing.Color.White;
            this.btnFilter.Location = new System.Drawing.Point(779, 15);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(100, 36);
            this.btnFilter.TabIndex = 8;
            this.btnFilter.Text = "Lọc";
            // 
            // lblPeriod
            // 
            this.lblPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(99)))), ((int)(((byte)(167)))));
            this.lblPeriod.Location = new System.Drawing.Point(16, 20);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(101, 23);
            this.lblPeriod.TabIndex = 9;
            this.lblPeriod.Text = "Kỳ báo cáo:";
            // 
            // lblMonth
            // 
            this.lblMonth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMonth.AutoSize = true;
            this.lblMonth.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(99)))), ((int)(((byte)(167)))));
            this.lblMonth.Location = new System.Drawing.Point(295, 20);
            this.lblMonth.Name = "lblMonth";
            this.lblMonth.Size = new System.Drawing.Size(65, 23);
            this.lblMonth.TabIndex = 10;
            this.lblMonth.Text = "Tháng:";
            // 
            // lblYear
            // 
            this.lblYear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(99)))), ((int)(((byte)(167)))));
            this.lblYear.Location = new System.Drawing.Point(501, 20);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(53, 23);
            this.lblYear.TabIndex = 11;
            this.lblYear.Text = "Năm:";
            // 
            // UC_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pRoot);
            this.Name = "UC_Report";
            this.Size = new System.Drawing.Size(1023, 630);
            this.pRoot.ResumeLayout(false);
            this.pFilter.ResumeLayout(false);
            this.pFilter.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.tlpCharts.ResumeLayout(false);
            this.pChartRevenue.ResumeLayout(false);
            this.pChartRevenue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).EndInit();
            this.pChartTopProducts.ResumeLayout(false);
            this.pChartTopProducts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopProducts)).EndInit();
            this.pGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2DataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRevenue)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pRoot;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTilte;
        private Guna.UI2.WinForms.Guna2Panel pFilter;
        private Guna.UI2.WinForms.Guna2ComboBox cboPeriod;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ComboBox cboMonth;
        private System.Windows.Forms.TableLayoutPanel tlpCharts;
        private Guna.UI2.WinForms.Guna2Panel pChartTopProducts;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopProducts;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblChartTopProducts;
        private Guna.UI2.WinForms.Guna2Panel pChartRevenue;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblChartRevenue;
        private Guna.UI2.WinForms.Guna2Button btnExportPdf;
        private Guna.UI2.WinForms.Guna2Panel pGrid;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private Guna.UI2.WinForms.Guna2DataGridView gvRevenue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongSoDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTongTien;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhuongThuc;
        private Guna.UI2.WinForms.Guna2Button btnFilter;
        private Guna.UI2.WinForms.Guna2ComboBox cboYear;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblMonth;
    }
}
