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

        private Guna.UI2.WinForms.Guna2Panel cardTotalItems;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalItems;
        private Guna.UI2.WinForms.Guna2Panel cardLowStock;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLowStock;
        private Guna.UI2.WinForms.Guna2Panel cardExpired;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblExpired;
        private Guna.UI2.WinForms.Guna2Panel infoPanel;

        // ⬇️ Thanh button thao tác
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnEdit;
        private Guna.UI2.WinForms.Guna2Button btnDelete;

        // ⬇️ Các cột DataGridView
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNhaCungCap;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaNCC;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSoLuongTon;
        private System.Windows.Forms.DataGridViewTextBoxColumn colViTri;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHanDung;

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
            this.infoPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.cardExpired = new Guna.UI2.WinForms.Guna2Panel();
            this.lblExpired = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cardLowStock = new Guna.UI2.WinForms.Guna2Panel();
            this.lblLowStock = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cardTotalItems = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalItems = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboLocation = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnDelete = new Guna.UI2.WinForms.Guna2Button();
            this.dgvWarehouse = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colMaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNhaCungCap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaNCC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSoLuongTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colViTri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHanDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnTim = new Guna.UI2.WinForms.Guna2Button();
            this.headerPanel.SuspendLayout();
            this.infoPanel.SuspendLayout();
            this.cardExpired.SuspendLayout();
            this.cardLowStock.SuspendLayout();
            this.cardTotalItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouse)).BeginInit();
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
            this.headerPanel.Size = new System.Drawing.Size(1000, 48);
            this.headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(71)))), ((int)(((byte)(109)))));
            this.lblTitle.Location = new System.Drawing.Point(24, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(121, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Kho hàng";
            // 
            // infoPanel
            // 
            this.infoPanel.Controls.Add(this.cardExpired);
            this.infoPanel.Controls.Add(this.cardLowStock);
            this.infoPanel.Controls.Add(this.cardTotalItems);
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoPanel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.infoPanel.Location = new System.Drawing.Point(0, 48);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Padding = new System.Windows.Forms.Padding(24, 12, 24, 12);
            this.infoPanel.Size = new System.Drawing.Size(1000, 110);
            this.infoPanel.TabIndex = 1;
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
            this.cardExpired.TabIndex = 2;
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
            this.cardTotalItems.TabIndex = 0;
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
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(24, 172);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Tìm theo mã, barcode, tên thuốc...";
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
            this.cboLocation.Location = new System.Drawing.Point(300, 172);
            this.cboLocation.Name = "cboLocation";
            this.cboLocation.Size = new System.Drawing.Size(200, 36);
            this.cboLocation.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.BorderRadius = 8;
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(201)))), ((int)(((byte)(170)))));
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(634, 172);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 36);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = this.btnAdd.Anchor;
            this.btnEdit.BorderRadius = 8;
            this.btnEdit.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(196)))), ((int)(((byte)(246)))));
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(750, 172);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(110, 36);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Sửa";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = this.btnAdd.Anchor;
            this.btnDelete.BorderRadius = 8;
            this.btnDelete.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(866, 172);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(110, 36);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Xóa";
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
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWarehouse.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvWarehouse.ColumnHeadersHeight = 32;
            this.dgvWarehouse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSP,
            this.colBarcode,
            this.colTenSP,
            this.colNhaCungCap,
            this.colMaNCC,
            this.colSoLuongTon,
            this.colViTri,
            this.colHanDung});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWarehouse.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvWarehouse.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvWarehouse.Location = new System.Drawing.Point(24, 220);
            this.dgvWarehouse.MultiSelect = false;
            this.dgvWarehouse.Name = "dgvWarehouse";
            this.dgvWarehouse.ReadOnly = true;
            this.dgvWarehouse.RowHeadersVisible = false;
            this.dgvWarehouse.RowHeadersWidth = 51;
            this.dgvWarehouse.RowTemplate.Height = 36;
            this.dgvWarehouse.Size = new System.Drawing.Size(952, 400);
            this.dgvWarehouse.TabIndex = 7;
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
            this.dgvWarehouse.ThemeStyle.HeaderStyle.Height = 32;
            this.dgvWarehouse.ThemeStyle.ReadOnly = true;
            this.dgvWarehouse.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvWarehouse.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvWarehouse.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvWarehouse.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvWarehouse.ThemeStyle.RowsStyle.Height = 36;
            this.dgvWarehouse.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvWarehouse.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // colMaSP
            // 
            this.colMaSP.DataPropertyName = "MaSP";
            this.colMaSP.HeaderText = "Mã SP";
            this.colMaSP.MinimumWidth = 6;
            this.colMaSP.Name = "colMaSP";
            this.colMaSP.ReadOnly = true;
            // 
            // colBarcode
            // 
            this.colBarcode.DataPropertyName = "Barcode";
            this.colBarcode.HeaderText = "Barcode";
            this.colBarcode.MinimumWidth = 6;
            this.colBarcode.Name = "colBarcode";
            this.colBarcode.ReadOnly = true;
            // 
            // colTenSP
            // 
            this.colTenSP.DataPropertyName = "TenSP";
            this.colTenSP.HeaderText = "Tên thuốc";
            this.colTenSP.MinimumWidth = 6;
            this.colTenSP.Name = "colTenSP";
            this.colTenSP.ReadOnly = true;
            // 
            // colNhaCungCap
            // 
            this.colNhaCungCap.DataPropertyName = "TenNCC";
            this.colNhaCungCap.HeaderText = "Nhà cung cấp";
            this.colNhaCungCap.MinimumWidth = 6;
            this.colNhaCungCap.Name = "colNhaCungCap";
            this.colNhaCungCap.ReadOnly = true;
            // 
            // colMaNCC
            // 
            this.colMaNCC.DataPropertyName = "MaNCC";
            this.colMaNCC.HeaderText = "Mã NCC";
            this.colMaNCC.MinimumWidth = 6;
            this.colMaNCC.Name = "colMaNCC";
            this.colMaNCC.ReadOnly = true;
            // 
            // colSoLuongTon
            // 
            this.colSoLuongTon.DataPropertyName = "SoLuongTon";
            this.colSoLuongTon.HeaderText = "Số lượng tồn";
            this.colSoLuongTon.MinimumWidth = 6;
            this.colSoLuongTon.Name = "colSoLuongTon";
            this.colSoLuongTon.ReadOnly = true;
            // 
            // colViTri
            // 
            this.colViTri.DataPropertyName = "ViTri";
            this.colViTri.HeaderText = "Vị trí";
            this.colViTri.MinimumWidth = 6;
            this.colViTri.Name = "colViTri";
            this.colViTri.ReadOnly = true;
            // 
            // colHanDung
            // 
            this.colHanDung.DataPropertyName = "HanDung";
            this.colHanDung.HeaderText = "Hạn dùng";
            this.colHanDung.MinimumWidth = 6;
            this.colHanDung.Name = "colHanDung";
            this.colHanDung.ReadOnly = true;
            // 
            // btnTim
            // 
            this.btnTim.BorderRadius = 6;
            this.btnTim.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTim.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTim.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTim.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTim.FillColor = System.Drawing.Color.Blue;
            this.btnTim.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTim.ForeColor = System.Drawing.Color.White;
            this.btnTim.Location = new System.Drawing.Point(518, 172);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(110, 36);
            this.btnTim.TabIndex = 8;
            this.btnTim.Text = "Tìm";
            // 
            // UC_Warehouse
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.btnTim);
            this.Controls.Add(this.dgvWarehouse);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cboLocation);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.headerPanel);
            this.Name = "UC_Warehouse";
            this.Size = new System.Drawing.Size(1000, 650);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.infoPanel.ResumeLayout(false);
            this.cardExpired.ResumeLayout(false);
            this.cardExpired.PerformLayout();
            this.cardLowStock.ResumeLayout(false);
            this.cardLowStock.PerformLayout();
            this.cardTotalItems.ResumeLayout(false);
            this.cardTotalItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnTim;
    }
}
