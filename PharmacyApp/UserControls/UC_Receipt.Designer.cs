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

        private Guna.UI2.WinForms.Guna2DataGridView dgvLines;

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
            this.dgvLines = new Guna.UI2.WinForms.Guna2DataGridView();
            this.footerPanel = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotal = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnBack = new Guna.UI2.WinForms.Guna2Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.headerPanel.SuspendLayout();
            this.infoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).BeginInit();
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
            // dgvLines
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.dgvLines.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvLines.ColumnHeadersHeight = 30;
            this.dgvLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLines.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvLines.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLines.Location = new System.Drawing.Point(24, 210);
            this.dgvLines.Name = "dgvLines";
            this.dgvLines.RowHeadersVisible = false;
            this.dgvLines.RowHeadersWidth = 51;
            this.dgvLines.RowTemplate.Height = 32;
            this.dgvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvLines.Size = new System.Drawing.Size(952, 360);
            this.dgvLines.TabIndex = 0;
            this.dgvLines.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLines.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.dgvLines.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.dgvLines.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgvLines.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.dgvLines.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.dgvLines.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLines.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.dgvLines.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvLines.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLines.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvLines.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLines.ThemeStyle.HeaderStyle.Height = 30;
            this.dgvLines.ThemeStyle.ReadOnly = false;
            this.dgvLines.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvLines.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvLines.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvLines.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.dgvLines.ThemeStyle.RowsStyle.Height = 32;
            this.dgvLines.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.dgvLines.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
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
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Mã SP";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Tên thuốc";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Barcode";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "SL";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Đơn giá";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Thành tiền";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Số lô";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Hạn dùng";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Ghi chú";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // UC_Receipt
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.dgvLines);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.infoPanel);
            this.Controls.Add(this.headerPanel);
            this.Name = "UC_Receipt";
            this.Size = new System.Drawing.Size(1000, 650);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).EndInit();
            this.footerPanel.ResumeLayout(false);
            this.footerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}
