namespace PharmacyApp.UserControls
{
    partial class UC_Receipt
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2Panel headerPanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;

        private Guna.UI2.WinForms.Guna2Panel infoPanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblSupplier;
        private Guna.UI2.WinForms.Guna2ComboBox cboSupplier;

        private Guna.UI2.WinForms.Guna2HtmlLabel lblWarehouse;
        private Guna.UI2.WinForms.Guna2ComboBox cboWarehouse;

        private Guna.UI2.WinForms.Guna2HtmlLabel lblVoucher;
        private Guna.UI2.WinForms.Guna2TextBox txtVoucher;

        private Guna.UI2.WinForms.Guna2HtmlLabel lblDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDate;

        private Guna.UI2.WinForms.Guna2HtmlLabel lblNote;
        private Guna.UI2.WinForms.Guna2TextBox txtNote;

        private Guna.UI2.WinForms.Guna2DataGridView dgvReceiptList;

        private Guna.UI2.WinForms.Guna2Panel footerPanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotal;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnBack;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
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
            this.lblSupplier = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cboSupplier = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblWarehouse = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.cboWarehouse = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblVoucher = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtVoucher = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.dtpDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblNote = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtNote = new Guna.UI2.WinForms.Guna2TextBox();
            this.dgvReceiptList = new Guna.UI2.WinForms.Guna2DataGridView();
            this.footerPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.colProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBarcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLineTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBatchNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colExpiredDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRowNote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.headerPanel.SuspendLayout();
            this.infoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptList)).BeginInit();
            this.footerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.FillColor = System.Drawing.Color.White;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(20, 12, 20, 8);
            this.headerPanel.ShadowDecoration.Enabled = true;
            this.headerPanel.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 0, 4);
            this.headerPanel.Size = new System.Drawing.Size(1000, 56);
            this.headerPanel.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(71)))), ((int)(((byte)(109)))));
            this.lblTitle.Location = new System.Drawing.Point(24, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(216, 43);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Phiếu nhập kho";
            // 
            // infoPanel
            // 
            this.infoPanel.Controls.Add(this.lblSupplier);
            this.infoPanel.Controls.Add(this.cboSupplier);
            this.infoPanel.Controls.Add(this.lblWarehouse);
            this.infoPanel.Controls.Add(this.cboWarehouse);
            this.infoPanel.Controls.Add(this.lblVoucher);
            this.infoPanel.Controls.Add(this.txtVoucher);
            this.infoPanel.Controls.Add(this.lblDate);
            this.infoPanel.Controls.Add(this.dtpDate);
            this.infoPanel.Controls.Add(this.lblNote);
            this.infoPanel.Controls.Add(this.txtNote);
            this.infoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoPanel.FillColor = System.Drawing.Color.White;
            this.infoPanel.Location = new System.Drawing.Point(0, 56);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Padding = new System.Windows.Forms.Padding(20);
            this.infoPanel.Size = new System.Drawing.Size(1000, 148);
            this.infoPanel.TabIndex = 2;
            // 
            // lblSupplier
            // 
            this.lblSupplier.BackColor = System.Drawing.Color.Transparent;
            this.lblSupplier.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSupplier.Location = new System.Drawing.Point(24, 18);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(94, 22);
            this.lblSupplier.TabIndex = 0;
            this.lblSupplier.Text = "Nhà cung cấp";
            // 
            // cboSupplier
            // 
            this.cboSupplier.BackColor = System.Drawing.Color.Transparent;
            this.cboSupplier.BorderRadius = 6;
            this.cboSupplier.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupplier.FocusedColor = System.Drawing.Color.Empty;
            this.cboSupplier.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSupplier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboSupplier.ItemHeight = 30;
            this.cboSupplier.Location = new System.Drawing.Point(24, 42);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(250, 36);
            this.cboSupplier.TabIndex = 1;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.BackColor = System.Drawing.Color.Transparent;
            this.lblWarehouse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblWarehouse.Location = new System.Drawing.Point(300, 18);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(66, 22);
            this.lblWarehouse.TabIndex = 2;
            this.lblWarehouse.Text = "Kho nhập";
            // 
            // cboWarehouse
            // 
            this.cboWarehouse.BackColor = System.Drawing.Color.Transparent;
            this.cboWarehouse.BorderRadius = 6;
            this.cboWarehouse.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWarehouse.FocusedColor = System.Drawing.Color.Empty;
            this.cboWarehouse.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboWarehouse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboWarehouse.ItemHeight = 30;
            this.cboWarehouse.Location = new System.Drawing.Point(300, 42);
            this.cboWarehouse.Name = "cboWarehouse";
            this.cboWarehouse.Size = new System.Drawing.Size(220, 36);
            this.cboWarehouse.TabIndex = 3;
            // 
            // lblVoucher
            // 
            this.lblVoucher.BackColor = System.Drawing.Color.Transparent;
            this.lblVoucher.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVoucher.Location = new System.Drawing.Point(540, 18);
            this.lblVoucher.Name = "lblVoucher";
            this.lblVoucher.Size = new System.Drawing.Size(83, 22);
            this.lblVoucher.TabIndex = 4;
            this.lblVoucher.Text = "Số chứng từ";
            // 
            // txtVoucher
            // 
            this.txtVoucher.BorderRadius = 6;
            this.txtVoucher.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtVoucher.DefaultText = "";
            this.txtVoucher.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtVoucher.Location = new System.Drawing.Point(540, 42);
            this.txtVoucher.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVoucher.Name = "txtVoucher";
            this.txtVoucher.PlaceholderText = "Tự sinh nếu để trống";
            this.txtVoucher.SelectedText = "";
            this.txtVoucher.Size = new System.Drawing.Size(160, 36);
            this.txtVoucher.TabIndex = 5;
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDate.Location = new System.Drawing.Point(720, 18);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(75, 22);
            this.lblDate.TabIndex = 6;
            this.lblDate.Text = "Ngày nhập";
            // 
            // dtpDate
            // 
            this.dtpDate.BorderRadius = 6;
            this.dtpDate.Checked = true;
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate.Location = new System.Drawing.Point(720, 42);
            this.dtpDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(203, 36);
            this.dtpDate.TabIndex = 7;
            this.dtpDate.Value = new System.DateTime(2025, 11, 16, 0, 17, 30, 680);
            // 
            // lblNote
            // 
            this.lblNote.BackColor = System.Drawing.Color.Transparent;
            this.lblNote.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNote.Location = new System.Drawing.Point(24, 84);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(52, 22);
            this.lblNote.TabIndex = 8;
            this.lblNote.Text = "Ghi chú";
            // 
            // txtNote
            // 
            this.txtNote.BorderRadius = 6;
            this.txtNote.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNote.DefaultText = "";
            this.txtNote.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNote.Location = new System.Drawing.Point(24, 104);
            this.txtNote.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNote.Name = "txtNote";
            this.txtNote.PlaceholderText = "Thông tin thêm về phiếu nhập...";
            this.txtNote.SelectedText = "";
            this.txtNote.Size = new System.Drawing.Size(836, 28);
            this.txtNote.TabIndex = 9;
            // 
            // dgvReceiptList
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.dgvReceiptList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReceiptList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReceiptList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReceiptList.ColumnHeadersHeight = 30;
            this.dgvReceiptList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colProductCode,
            this.colProductId,
            this.colProductName,
            this.colBarcode,
            this.colQuantity,
            this.colUnitPrice,
            this.colLineTotal,
            this.colBatchNo,
            this.colExpiredDate,
            this.colRowNote});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReceiptList.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReceiptList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvReceiptList.Location = new System.Drawing.Point(24, 210);
            this.dgvReceiptList.Name = "dgvReceiptList";
            this.dgvReceiptList.RowHeadersVisible = false;
            this.dgvReceiptList.RowHeadersWidth = 51;
            this.dgvReceiptList.RowTemplate.Height = 32;
            this.dgvReceiptList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvReceiptList.Size = new System.Drawing.Size(952, 360);
            this.dgvReceiptList.TabIndex = 0;
            this.dgvReceiptList.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvReceiptList.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvReceiptList.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvReceiptList.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvReceiptList.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvReceiptList.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvReceiptList.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvReceiptList.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvReceiptList.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvReceiptList.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvReceiptList.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvReceiptList.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReceiptList.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvReceiptList.ThemeStyle.ReadOnly = false;
            this.dgvReceiptList.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvReceiptList.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReceiptList.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvReceiptList.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvReceiptList.ThemeStyle.RowsStyle.Height = 32;
            this.dgvReceiptList.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvReceiptList.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // footerPanel
            // 
            this.footerPanel.Controls.Add(this.lblTotal);
            this.footerPanel.Controls.Add(this.btnSave);
            this.footerPanel.Controls.Add(this.btnBack);
            this.footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footerPanel.FillColor = System.Drawing.Color.White;
            this.footerPanel.Location = new System.Drawing.Point(0, 586);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Padding = new System.Windows.Forms.Padding(20, 8, 20, 8);
            this.footerPanel.Size = new System.Drawing.Size(1000, 64);
            this.footerPanel.TabIndex = 1;
            // 
            // lblTotal
            // 
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(24, 20);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(147, 27);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "Tổng tiền: 0 VNĐ";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSave.BorderRadius = 8;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(201)))), ((int)(((byte)(170)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(1500, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(130, 40);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu phiếu";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBack.BorderRadius = 8;
            this.btnBack.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(98)))), ((int)(((byte)(98)))));
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(1640, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 40);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Quay lại";
            // 
            // colProductCode
            // 
            this.colProductCode.HeaderText = "Mã SP";
            this.colProductCode.MinimumWidth = 6;
            this.colProductCode.Name = "colProductCode";
            // 
            // colProductId
            // 
            this.colProductId.HeaderText = "ProductId";
            this.colProductId.MinimumWidth = 6;
            this.colProductId.Name = "colProductId";
            this.colProductId.Visible = false;
            // 
            // colProductName
            // 
            this.colProductName.HeaderText = "Tên thuốc";
            this.colProductName.MinimumWidth = 6;
            this.colProductName.Name = "colProductName";
            // 
            // colBarcode
            // 
            this.colBarcode.HeaderText = "Barcode";
            this.colBarcode.MinimumWidth = 6;
            this.colBarcode.Name = "colBarcode";
            // 
            // colQuantity
            // 
            this.colQuantity.HeaderText = "SL";
            this.colQuantity.MinimumWidth = 6;
            this.colQuantity.Name = "colQuantity";
            // 
            // colUnitPrice
            // 
            this.colUnitPrice.HeaderText = "Đơn giá";
            this.colUnitPrice.MinimumWidth = 6;
            this.colUnitPrice.Name = "colUnitPrice";
            // 
            // colLineTotal
            // 
            this.colLineTotal.HeaderText = "Thành tiền";
            this.colLineTotal.MinimumWidth = 6;
            this.colLineTotal.Name = "colLineTotal";
            // 
            // colBatchNo
            // 
            this.colBatchNo.HeaderText = "Số lô";
            this.colBatchNo.MinimumWidth = 6;
            this.colBatchNo.Name = "colBatchNo";
            // 
            // colExpiredDate
            // 
            this.colExpiredDate.HeaderText = "Hạn dùng";
            this.colExpiredDate.MinimumWidth = 6;
            this.colExpiredDate.Name = "colExpiredDate";
            // 
            // colRowNote
            // 
            this.colRowNote.HeaderText = "Ghi chú";
            this.colRowNote.MinimumWidth = 6;
            this.colRowNote.Name = "colRowNote";
            // 
            // UC_Receipt
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.dgvReceiptList);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.headerPanel);
            this.Name = "UC_Receipt";
            this.Size = new System.Drawing.Size(1000, 650);
            this.Load += new System.EventHandler(this.UC_Receipt_Load);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReceiptList)).EndInit();
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn colProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBarcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLineTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBatchNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExpiredDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRowNote;
    }
}
