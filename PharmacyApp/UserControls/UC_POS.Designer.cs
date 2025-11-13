namespace PharmacyApp.UserControls
{
    partial class UC_POS
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pRoot = new Guna.UI2.WinForms.Guna2Panel();
            this.pHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtSearchProduct = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblStaffCaption = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblStaffName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblDate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.pRight = new Guna.UI2.WinForms.Guna2Panel();
            this.cboCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.gvProducts = new Guna.UI2.WinForms.Guna2DataGridView();
            this.colMaThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTonKho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCart = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lvCart = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pPayment = new Guna.UI2.WinForms.Guna2Panel();
            this.lblTotalCaption = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtTotal = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboPaymentMethod = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pCash = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCashGiven = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtCashGiven = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblChange = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtChange = new Guna.UI2.WinForms.Guna2TextBox();
            this.pBank = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pbQr = new System.Windows.Forms.PictureBox();
            this.btnPay = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.lblPaymentMethod = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pRoot.SuspendLayout();
            this.pHeader.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.pLeft.SuspendLayout();
            this.pRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducts)).BeginInit();
            this.pPayment.SuspendLayout();
            this.pCash.SuspendLayout();
            this.pBank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQr)).BeginInit();
            this.SuspendLayout();
            // 
            // pRoot
            // 
            this.pRoot.Controls.Add(this.tlpMain);
            this.pRoot.Controls.Add(this.pHeader);
            this.pRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRoot.FillColor = System.Drawing.Color.WhiteSmoke;
            this.pRoot.Location = new System.Drawing.Point(0, 0);
            this.pRoot.Name = "pRoot";
            this.pRoot.Size = new System.Drawing.Size(1345, 959);
            this.pRoot.TabIndex = 0;
            // 
            // pHeader
            // 
            this.pHeader.Controls.Add(this.lblDate);
            this.pHeader.Controls.Add(this.lblStaffName);
            this.pHeader.Controls.Add(this.lblStaffCaption);
            this.pHeader.Controls.Add(this.txtSearchProduct);
            this.pHeader.Controls.Add(this.lblTitle);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(1345, 70);
            this.pHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(201, 39);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Bán hàng (POS)";
            // 
            // txtSearchProduct
            // 
            this.txtSearchProduct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchProduct.BorderRadius = 6;
            this.txtSearchProduct.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchProduct.DefaultText = "";
            this.txtSearchProduct.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchProduct.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchProduct.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchProduct.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchProduct.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchProduct.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchProduct.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchProduct.Location = new System.Drawing.Point(250, 18);
            this.txtSearchProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.PlaceholderText = "Tìm thuốc theo tên / mã...";
            this.txtSearchProduct.SelectedText = "";
            this.txtSearchProduct.Size = new System.Drawing.Size(722, 36);
            this.txtSearchProduct.TabIndex = 1;
            // 
            // lblStaffCaption
            // 
            this.lblStaffCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStaffCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblStaffCaption.ForeColor = System.Drawing.Color.White;
            this.lblStaffCaption.Location = new System.Drawing.Point(1064, 18);
            this.lblStaffCaption.Name = "lblStaffCaption";
            this.lblStaffCaption.Size = new System.Drawing.Size(66, 18);
            this.lblStaffCaption.TabIndex = 2;
            this.lblStaffCaption.Text = "Nhân viên:";
            // 
            // lblStaffName
            // 
            this.lblStaffName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStaffName.BackColor = System.Drawing.Color.Transparent;
            this.lblStaffName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(201)))), ((int)(((byte)(170)))));
            this.lblStaffName.Location = new System.Drawing.Point(1180, 18);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(62, 18);
            this.lblStaffName.TabIndex = 3;
            this.lblStaffName.Text = "Nguyễn A";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(1064, 36);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(67, 18);
            this.lblDate.TabIndex = 4;
            this.lblDate.Text = "11/11/2025";
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpMain.Controls.Add(this.pLeft, 0, 0);
            this.tlpMain.Controls.Add(this.pRight, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 70);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 626F));
            this.tlpMain.Size = new System.Drawing.Size(1345, 889);
            this.tlpMain.TabIndex = 1;
            // 
            // pLeft
            // 
            this.pLeft.BorderRadius = 8;
            this.pLeft.Controls.Add(this.gvProducts);
            this.pLeft.Controls.Add(this.guna2HtmlLabel1);
            this.pLeft.Controls.Add(this.cboCategory);
            this.pLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pLeft.FillColor = System.Drawing.Color.White;
            this.pLeft.Location = new System.Drawing.Point(3, 3);
            this.pLeft.Name = "pLeft";
            this.pLeft.Size = new System.Drawing.Size(733, 883);
            this.pLeft.TabIndex = 0;
            // 
            // pRight
            // 
            this.pRight.Controls.Add(this.pPayment);
            this.pRight.Controls.Add(this.lvCart);
            this.pRight.Controls.Add(this.lblCart);
            this.pRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRight.Location = new System.Drawing.Point(742, 3);
            this.pRight.Name = "pRight";
            this.pRight.Size = new System.Drawing.Size(600, 883);
            this.pRight.TabIndex = 1;
            // 
            // cboCategory
            // 
            this.cboCategory.BackColor = System.Drawing.Color.Transparent;
            this.cboCategory.BorderRadius = 6;
            this.cboCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboCategory.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCategory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboCategory.ItemHeight = 30;
            this.cboCategory.Items.AddRange(new object[] {
            "Tất cả",
            "Giảm đau",
            "Hạ sốt",
            "Vitamin"});
            this.cboCategory.Location = new System.Drawing.Point(118, 10);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(200, 36);
            this.cboCategory.TabIndex = 0;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(17, 28);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(77, 18);
            this.guna2HtmlLabel1.TabIndex = 1;
            this.guna2HtmlLabel1.Text = "Nhóm thuốc:";
            // 
            // gvProducts
            // 
            dataGridViewCellStyle22.BackColor = System.Drawing.Color.White;
            this.gvProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle22;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
            this.gvProducts.ColumnHeadersHeight = 18;
            this.gvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.gvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaThuoc,
            this.colTenThuoc,
            this.colDonVi,
            this.colGiaBan,
            this.colTonKho});
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvProducts.DefaultCellStyle = dataGridViewCellStyle24;
            this.gvProducts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gvProducts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gvProducts.Location = new System.Drawing.Point(0, 52);
            this.gvProducts.Name = "gvProducts";
            this.gvProducts.ReadOnly = true;
            this.gvProducts.RowHeadersVisible = false;
            this.gvProducts.RowHeadersWidth = 51;
            this.gvProducts.RowTemplate.Height = 24;
            this.gvProducts.Size = new System.Drawing.Size(733, 831);
            this.gvProducts.TabIndex = 2;
            this.gvProducts.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.gvProducts.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.gvProducts.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.gvProducts.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.gvProducts.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.gvProducts.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.gvProducts.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gvProducts.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.gvProducts.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.gvProducts.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvProducts.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.gvProducts.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.gvProducts.ThemeStyle.HeaderStyle.Height = 18;
            this.gvProducts.ThemeStyle.ReadOnly = true;
            this.gvProducts.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.gvProducts.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.gvProducts.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvProducts.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.gvProducts.ThemeStyle.RowsStyle.Height = 24;
            this.gvProducts.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gvProducts.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // colMaThuoc
            // 
            this.colMaThuoc.DataPropertyName = "DrugCode";
            this.colMaThuoc.HeaderText = "Mã thuốc";
            this.colMaThuoc.MinimumWidth = 6;
            this.colMaThuoc.Name = "colMaThuoc";
            this.colMaThuoc.ReadOnly = true;
            // 
            // colTenThuoc
            // 
            this.colTenThuoc.DataPropertyName = "DrugName";
            this.colTenThuoc.HeaderText = "Tên thuốc";
            this.colTenThuoc.MinimumWidth = 6;
            this.colTenThuoc.Name = "colTenThuoc";
            this.colTenThuoc.ReadOnly = true;
            // 
            // colDonVi
            // 
            this.colDonVi.DataPropertyName = "Unit";
            this.colDonVi.HeaderText = "Đơn vị";
            this.colDonVi.MinimumWidth = 6;
            this.colDonVi.Name = "colDonVi";
            this.colDonVi.ReadOnly = true;
            // 
            // colGiaBan
            // 
            this.colGiaBan.DataPropertyName = "UnitPrice";
            this.colGiaBan.HeaderText = "Giá bán";
            this.colGiaBan.MinimumWidth = 6;
            this.colGiaBan.Name = "colGiaBan";
            this.colGiaBan.ReadOnly = true;
            // 
            // colTonKho
            // 
            this.colTonKho.DataPropertyName = "StockQty";
            this.colTonKho.HeaderText = "Tồn Kho";
            this.colTonKho.MinimumWidth = 6;
            this.colTonKho.Name = "colTonKho";
            this.colTonKho.ReadOnly = true;
            // 
            // lblCart
            // 
            this.lblCart.BackColor = System.Drawing.Color.Transparent;
            this.lblCart.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCart.Location = new System.Drawing.Point(0, 0);
            this.lblCart.Name = "lblCart";
            this.lblCart.Size = new System.Drawing.Size(600, 30);
            this.lblCart.TabIndex = 2;
            this.lblCart.Text = "Giỏ hàng";
            // 
            // lvCart
            // 
            this.lvCart.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvCart.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvCart.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCart.FullRowSelect = true;
            this.lvCart.GridLines = true;
            this.lvCart.HideSelection = false;
            this.lvCart.Location = new System.Drawing.Point(0, 30);
            this.lvCart.Name = "lvCart";
            this.lvCart.Size = new System.Drawing.Size(600, 252);
            this.lvCart.TabIndex = 3;
            this.lvCart.UseCompatibleStateImageBehavior = false;
            this.lvCart.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Mã";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tên thuốc";
            this.columnHeader2.Width = 180;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "SL";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Đơn giá";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 90;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Thành tiền";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 100;
            // 
            // pPayment
            // 
            this.pPayment.Controls.Add(this.btnCancel);
            this.pPayment.Controls.Add(this.btnPay);
            this.pPayment.Controls.Add(this.lblTotalCaption);
            this.pPayment.Controls.Add(this.pBank);
            this.pPayment.Controls.Add(this.pCash);
            this.pPayment.Controls.Add(this.cboPaymentMethod);
            this.pPayment.Controls.Add(this.lblPaymentMethod);
            this.pPayment.Controls.Add(this.txtTotal);
            this.pPayment.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pPayment.FillColor = System.Drawing.Color.White;
            this.pPayment.Location = new System.Drawing.Point(0, 288);
            this.pPayment.Name = "pPayment";
            this.pPayment.Size = new System.Drawing.Size(600, 595);
            this.pPayment.TabIndex = 4;
            // 
            // lblTotalCaption
            // 
            this.lblTotalCaption.AutoSize = false;
            this.lblTotalCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCaption.Location = new System.Drawing.Point(20, 15);
            this.lblTotalCaption.Name = "lblTotalCaption";
            this.lblTotalCaption.Size = new System.Drawing.Size(225, 26);
            this.lblTotalCaption.TabIndex = 3;
            this.lblTotalCaption.Text = "Tổng giá trị đơn hàng:";
            this.lblTotalCaption.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotal
            // 
            this.txtTotal.BorderRadius = 6;
            this.txtTotal.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTotal.DefaultText = "";
            this.txtTotal.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTotal.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTotal.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotal.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotal.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTotal.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotal.Location = new System.Drawing.Point(365, 11);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.PlaceholderText = "0";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.SelectedText = "";
            this.txtTotal.Size = new System.Drawing.Size(160, 30);
            this.txtTotal.TabIndex = 4;
            this.txtTotal.TextChanged += new System.EventHandler(this.txtTotal_TextChanged);
            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.BackColor = System.Drawing.Color.Transparent;
            this.cboPaymentMethod.BorderRadius = 6;
            this.cboPaymentMethod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPaymentMethod.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboPaymentMethod.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPaymentMethod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboPaymentMethod.ItemHeight = 30;
            this.cboPaymentMethod.Items.AddRange(new object[] {
            "Tiền mặt",
            "Ngân hàng (QR)"});
            this.cboPaymentMethod.Location = new System.Drawing.Point(365, 58);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(160, 36);
            this.cboPaymentMethod.TabIndex = 6;
            // 
            // pCash
            // 
            this.pCash.Controls.Add(this.txtChange);
            this.pCash.Controls.Add(this.lblChange);
            this.pCash.Controls.Add(this.txtCashGiven);
            this.pCash.Controls.Add(this.lblCashGiven);
            this.pCash.Location = new System.Drawing.Point(15, 136);
            this.pCash.Name = "pCash";
            this.pCash.Size = new System.Drawing.Size(417, 80);
            this.pCash.TabIndex = 7;
            // 
            // lblCashGiven
            // 
            this.lblCashGiven.BackColor = System.Drawing.Color.Transparent;
            this.lblCashGiven.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashGiven.Location = new System.Drawing.Point(5, 5);
            this.lblCashGiven.Name = "lblCashGiven";
            this.lblCashGiven.Size = new System.Drawing.Size(154, 30);
            this.lblCashGiven.TabIndex = 6;
            this.lblCashGiven.Text = "Tiền khách đưa:";
            // 
            // txtCashGiven
            // 
            this.txtCashGiven.BorderRadius = 6;
            this.txtCashGiven.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCashGiven.DefaultText = "";
            this.txtCashGiven.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCashGiven.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCashGiven.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCashGiven.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCashGiven.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCashGiven.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCashGiven.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCashGiven.Location = new System.Drawing.Point(238, 6);
            this.txtCashGiven.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCashGiven.Name = "txtCashGiven";
            this.txtCashGiven.PlaceholderText = "0";
            this.txtCashGiven.ReadOnly = true;
            this.txtCashGiven.SelectedText = "";
            this.txtCashGiven.Size = new System.Drawing.Size(150, 30);
            this.txtCashGiven.TabIndex = 7;
            this.txtCashGiven.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblChange
            // 
            this.lblChange.BackColor = System.Drawing.Color.Transparent;
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.Location = new System.Drawing.Point(5, 45);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(93, 30);
            this.lblChange.TabIndex = 8;
            this.lblChange.Text = "Tiền thối:";
            // 
            // txtChange
            // 
            this.txtChange.BorderRadius = 6;
            this.txtChange.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtChange.DefaultText = "";
            this.txtChange.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtChange.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtChange.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtChange.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtChange.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtChange.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtChange.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtChange.Location = new System.Drawing.Point(238, 44);
            this.txtChange.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtChange.Name = "txtChange";
            this.txtChange.PlaceholderText = "0";
            this.txtChange.ReadOnly = true;
            this.txtChange.SelectedText = "";
            this.txtChange.Size = new System.Drawing.Size(150, 30);
            this.txtChange.TabIndex = 9;
            this.txtChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pBank
            // 
            this.pBank.Controls.Add(this.pbQr);
            this.pBank.Controls.Add(this.guna2HtmlLabel2);
            this.pBank.Location = new System.Drawing.Point(15, 264);
            this.pBank.Name = "pBank";
            this.pBank.Size = new System.Drawing.Size(417, 220);
            this.pBank.TabIndex = 8;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(5, 5);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(258, 30);
            this.guna2HtmlLabel2.TabIndex = 4;
            this.guna2HtmlLabel2.Text = "Quét mã QR để thanh toán";
            // 
            // pbQr
            // 
            this.pbQr.Location = new System.Drawing.Point(110, 58);
            this.pbQr.Name = "pbQr";
            this.pbQr.Size = new System.Drawing.Size(130, 130);
            this.pbQr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbQr.TabIndex = 5;
            this.pbQr.TabStop = false;
            // 
            // btnPay
            // 
            this.btnPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPay.BorderRadius = 8;
            this.btnPay.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPay.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPay.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(438, 136);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(110, 36);
            this.btnPay.TabIndex = 9;
            this.btnPay.Text = "Thanh toán";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BorderRadius = 8;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(438, 243);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 48);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Hủy hóa đơn";
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = false;
            this.lblPaymentMethod.BackColor = System.Drawing.Color.Transparent;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentMethod.Location = new System.Drawing.Point(20, 58);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(225, 26);
            this.lblPaymentMethod.TabIndex = 5;
            this.lblPaymentMethod.Text = "Phương thức thanh toán:";
            this.lblPaymentMethod.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPaymentMethod.Click += new System.EventHandler(this.lblPaymentMethod_Click);
            // 
            // UC_POS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pRoot);
            this.Name = "UC_POS";
            this.Size = new System.Drawing.Size(1345, 959);
            this.pRoot.ResumeLayout(false);
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.tlpMain.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.pLeft.PerformLayout();
            this.pRight.ResumeLayout(false);
            this.pRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducts)).EndInit();
            this.pPayment.ResumeLayout(false);
            this.pCash.ResumeLayout(false);
            this.pCash.PerformLayout();
            this.pBank.ResumeLayout(false);
            this.pBank.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pRoot;
        private Guna.UI2.WinForms.Guna2Panel pHeader;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStaffCaption;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchProduct;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private Guna.UI2.WinForms.Guna2Panel pLeft;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2ComboBox cboCategory;
        private Guna.UI2.WinForms.Guna2Panel pRight;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblDate;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblStaffName;
        private Guna.UI2.WinForms.Guna2DataGridView gvProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTonKho;
        private System.Windows.Forms.ListView lvCart;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCart;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private Guna.UI2.WinForms.Guna2Panel pPayment;
        private Guna.UI2.WinForms.Guna2TextBox txtTotal;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTotalCaption;
        private Guna.UI2.WinForms.Guna2Panel pCash;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCashGiven;
        private Guna.UI2.WinForms.Guna2ComboBox cboPaymentMethod;
        private Guna.UI2.WinForms.Guna2Panel pBank;
        private System.Windows.Forms.PictureBox pbQr;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2TextBox txtChange;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblChange;
        private Guna.UI2.WinForms.Guna2TextBox txtCashGiven;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnPay;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblPaymentMethod;
    }
}
