namespace PharmacyApp.UserControls
{
    partial class UC_Warehouse
    {
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2Panel headerPanel;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2ComboBox cboLocation;
        private Guna.UI2.WinForms.Guna2DataGridView dgvWarehouse;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.headerPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboLocation = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dgvWarehouse = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cardTotalItems = new Guna.UI2.WinForms.Guna2Panel();
            this.cardLowStock = new Guna.UI2.WinForms.Guna2Panel();
            this.cardExpired = new Guna.UI2.WinForms.Guna2Panel();
            this.infoPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalItems = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblLowStock = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblExpired = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouse)).BeginInit();
            this.cardTotalItems.SuspendLayout();
            this.cardLowStock.SuspendLayout();
            this.cardExpired.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.FillColor = System.Drawing.Color.White;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(24, 16, 24, 8);
            this.headerPanel.ShadowDecoration.Enabled = true;
            this.headerPanel.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.headerPanel.Size = new System.Drawing.Size(1000, 44);
            this.headerPanel.TabIndex = 4;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(71)))), ((int)(((byte)(109)))));
            this.lblTitle.Location = new System.Drawing.Point(24, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(121, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Kho hàng";
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(24, 166);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Tìm theo mã phiếu, lô hàng...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(260, 36);
            this.txtSearch.TabIndex = 2;
            // 
            // cboLocation
            // 
            this.cboLocation.BackColor = System.Drawing.Color.Transparent;
            this.cboLocation.BorderRadius = 8;
            this.cboLocation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocation.FocusedColor = System.Drawing.Color.Empty;
            this.cboLocation.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLocation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboLocation.ItemHeight = 30;
            this.cboLocation.Items.AddRange(new object[] {
            "Tất cả kho",
            "Kho chính",
            "Kho quầy",
            "Kho chờ hủy"});
            this.cboLocation.Location = new System.Drawing.Point(300, 166);
            this.cboLocation.Name = "cboLocation";
            this.cboLocation.Size = new System.Drawing.Size(200, 36);
            this.cboLocation.TabIndex = 1;
            // 
            // dgvWarehouse
            // 
            this.dgvWarehouse.AllowUserToAddRows = false;
            this.dgvWarehouse.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dgvWarehouse.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWarehouse.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvWarehouse.ColumnHeadersHeight = 29;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWarehouse.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvWarehouse.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvWarehouse.Location = new System.Drawing.Point(24, 209);
            this.dgvWarehouse.Name = "dgvWarehouse";
            this.dgvWarehouse.RowHeadersVisible = false;
            this.dgvWarehouse.RowHeadersWidth = 51;
            this.dgvWarehouse.RowTemplate.Height = 36;
            this.dgvWarehouse.Size = new System.Drawing.Size(952, 411);
            this.dgvWarehouse.TabIndex = 0;
            this.dgvWarehouse.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvWarehouse.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvWarehouse.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvWarehouse.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvWarehouse.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvWarehouse.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvWarehouse.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvWarehouse.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvWarehouse.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvWarehouse.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvWarehouse.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvWarehouse.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvWarehouse.ThemeStyle.HeaderStyle.Height = 29;
            this.dgvWarehouse.ThemeStyle.ReadOnly = false;
            this.dgvWarehouse.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvWarehouse.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvWarehouse.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvWarehouse.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvWarehouse.ThemeStyle.RowsStyle.Height = 36;
            this.dgvWarehouse.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvWarehouse.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // cardTotalItems
            // 
            this.cardTotalItems.BackColor = System.Drawing.Color.Transparent;
            this.cardTotalItems.BorderRadius = 10;
            this.cardTotalItems.Controls.Add(this.lblTotalItems);
            this.cardTotalItems.FillColor = System.Drawing.Color.White;
            this.cardTotalItems.Location = new System.Drawing.Point(24, 15);
            this.cardTotalItems.Name = "cardTotalItems";
            this.cardTotalItems.ShadowDecoration.Enabled = true;
            this.cardTotalItems.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 2, 4, 4);
            this.cardTotalItems.Size = new System.Drawing.Size(200, 80);
            this.cardTotalItems.TabIndex = 2;
            // 
            // cardLowStock
            // 
            this.cardLowStock.BackColor = System.Drawing.Color.Transparent;
            this.cardLowStock.BorderRadius = 10;
            this.cardLowStock.Controls.Add(this.lblLowStock);
            this.cardLowStock.FillColor = System.Drawing.Color.White;
            this.cardLowStock.Location = new System.Drawing.Point(244, 15);
            this.cardLowStock.Name = "cardLowStock";
            this.cardLowStock.ShadowDecoration.Enabled = true;
            this.cardLowStock.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 2, 4, 4);
            this.cardLowStock.Size = new System.Drawing.Size(200, 80);
            this.cardLowStock.TabIndex = 1;
            // 
            // cardExpired
            // 
            this.cardExpired.BackColor = System.Drawing.Color.Transparent;
            this.cardExpired.BorderRadius = 10;
            this.cardExpired.Controls.Add(this.lblExpired);
            this.cardExpired.FillColor = System.Drawing.Color.White;
            this.cardExpired.Location = new System.Drawing.Point(464, 15);
            this.cardExpired.Name = "cardExpired";
            this.cardExpired.ShadowDecoration.Enabled = true;
            this.cardExpired.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 2, 4, 4);
            this.cardExpired.Size = new System.Drawing.Size(200, 80);
            this.cardExpired.TabIndex = 0;
            // 
            // infoPanel
            // 
            this.infoPanel.Controls.Add(this.cardExpired);
            this.infoPanel.Controls.Add(this.cardLowStock);
            this.infoPanel.Controls.Add(this.cardTotalItems);
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.infoPanel.Location = new System.Drawing.Point(0, 44);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Padding = new System.Windows.Forms.Padding(24, 12, 24, 12);
            this.infoPanel.Size = new System.Drawing.Size(1000, 110);
            this.infoPanel.TabIndex = 3;
            // 
            // lblTotalItems
            // 
            this.lblTotalItems.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalItems.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalItems.Location = new System.Drawing.Point(16, 16);
            this.lblTotalItems.Name = "lblTotalItems";
            this.lblTotalItems.Size = new System.Drawing.Size(139, 25);
            this.lblTotalItems.TabIndex = 0;
            this.lblTotalItems.Text = "Tổng mặt hàng: 0";
            // 
            // lblLowStock
            // 
            this.lblLowStock.BackColor = System.Drawing.Color.Transparent;
            this.lblLowStock.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLowStock.Location = new System.Drawing.Point(16, 16);
            this.lblLowStock.Name = "lblLowStock";
            this.lblLowStock.Size = new System.Drawing.Size(123, 25);
            this.lblLowStock.TabIndex = 0;
            this.lblLowStock.Text = "Sắp hết hàng: 0";
            // 
            // lblExpired
            // 
            this.lblExpired.BackColor = System.Drawing.Color.Transparent;
            this.lblExpired.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblExpired.Location = new System.Drawing.Point(16, 16);
            this.lblExpired.Name = "lblExpired";
            this.lblExpired.Size = new System.Drawing.Size(82, 25);
            this.lblExpired.TabIndex = 0;
            this.lblExpired.Text = "Hết hạn: 0";
            // 
            // UC_Warehouse
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.dgvWarehouse);
            this.Controls.Add(this.cboLocation);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.headerPanel);
            this.Name = "UC_Warehouse";
            this.Size = new System.Drawing.Size(1000, 650);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouse)).EndInit();
            this.cardTotalItems.ResumeLayout(false);
            this.cardTotalItems.PerformLayout();
            this.cardLowStock.ResumeLayout(false);
            this.cardLowStock.PerformLayout();
            this.cardExpired.ResumeLayout(false);
            this.cardExpired.PerformLayout();
            this.infoPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel cardTotalItems;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalItems;
        private Guna.UI2.WinForms.Guna2Panel cardLowStock;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLowStock;
        private Guna.UI2.WinForms.Guna2Panel cardExpired;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblExpired;
        private Guna.UI2.WinForms.Guna2Panel infoPanel;
    }
}
