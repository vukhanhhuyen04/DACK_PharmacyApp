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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pRoot = new Guna.UI2.WinForms.Guna2Panel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pLeft = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.gvProducts = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cboCategoryPOS = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pRight = new Guna.UI2.WinForms.Guna2Panel();
            this.pPayment = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSymptoms = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblSymptoms = new System.Windows.Forms.Label();
            this.txtCustomerPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstCustomerSuggest = new System.Windows.Forms.ListBox();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.txtCustomerName = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnPrintInvoice = new Guna.UI2.WinForms.Guna2Button();
            this.btnPaid = new Guna.UI2.WinForms.Guna2Button();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.lblTotalCaption = new System.Windows.Forms.Label();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnPay = new Guna.UI2.WinForms.Guna2Button();
            this.pBank = new Guna.UI2.WinForms.Guna2Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pbQr = new System.Windows.Forms.PictureBox();
            this.pCash = new Guna.UI2.WinForms.Guna2Panel();
            this.lblChange = new System.Windows.Forms.Label();
            this.lblCashGiven = new System.Windows.Forms.Label();
            this.txtChange = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCashGiven = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboPaymentMethod = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtTotal = new Guna.UI2.WinForms.Guna2TextBox();
            this.lvCart = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblCart = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.pHeader = new Guna.UI2.WinForms.Guna2Panel();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblStaffName = new System.Windows.Forms.Label();
            this.lblStaffCaption = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtSearchProduct = new Guna.UI2.WinForms.Guna2TextBox();
            this.colMaThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenThuoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGiaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTonKho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pRoot.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.pLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducts)).BeginInit();
            this.pRight.SuspendLayout();
            this.pPayment.SuspendLayout();
            this.pBank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQr)).BeginInit();
            this.pCash.SuspendLayout();
            this.pHeader.SuspendLayout();
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
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 889F));
            this.tlpMain.Size = new System.Drawing.Size(1345, 889);
            this.tlpMain.TabIndex = 1;
            // 
            // pLeft
            // 
            this.pLeft.BorderRadius = 8;
            this.pLeft.Controls.Add(this.label1);
            this.pLeft.Controls.Add(this.gvProducts);
            this.pLeft.Controls.Add(this.cboCategoryPOS);
            this.pLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pLeft.FillColor = System.Drawing.Color.White;
            this.pLeft.Location = new System.Drawing.Point(3, 3);
            this.pLeft.Name = "pLeft";
            this.pLeft.Padding = new System.Windows.Forms.Padding(0, 60, 0, 0);
            this.pLeft.Size = new System.Drawing.Size(733, 883);
            this.pLeft.TabIndex = 0;
            this.pLeft.Paint += new System.Windows.Forms.PaintEventHandler(this.pLeft_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(19, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nhóm thuốc:";
            // 
            // gvProducts
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.gvProducts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.gvProducts.ColumnHeadersHeight = 18;
            this.gvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.gvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaThuoc,
            this.colTenThuoc,
            this.colDonVi,
            this.colGiaBan,
            this.colTonKho,
            this.colProductId});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvProducts.DefaultCellStyle = dataGridViewCellStyle9;
            this.gvProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvProducts.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.gvProducts.Location = new System.Drawing.Point(0, 60);
            this.gvProducts.Name = "gvProducts";
            this.gvProducts.ReadOnly = true;
            this.gvProducts.RowHeadersVisible = false;
            this.gvProducts.RowHeadersWidth = 51;
            this.gvProducts.RowTemplate.Height = 24;
            this.gvProducts.Size = new System.Drawing.Size(733, 823);
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
            // cboCategoryPOS
            // 
            this.cboCategoryPOS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboCategoryPOS.BackColor = System.Drawing.Color.Transparent;
            this.cboCategoryPOS.BorderRadius = 6;
            this.cboCategoryPOS.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCategoryPOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoryPOS.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboCategoryPOS.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboCategoryPOS.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCategoryPOS.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboCategoryPOS.ItemHeight = 30;
            this.cboCategoryPOS.Items.AddRange(new object[] {
            "Tất cả",
            "Giảm đau",
            "Hạ sốt",
            "Vitamin"});
            this.cboCategoryPOS.Location = new System.Drawing.Point(189, 12);
            this.cboCategoryPOS.Name = "cboCategoryPOS";
            this.cboCategoryPOS.Size = new System.Drawing.Size(200, 36);
            this.cboCategoryPOS.TabIndex = 0;
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
            // pPayment
            // 
            this.pPayment.Controls.Add(this.txtSymptoms);
            this.pPayment.Controls.Add(this.lblSymptoms);
            this.pPayment.Controls.Add(this.txtCustomerPhone);
            this.pPayment.Controls.Add(this.label3);
            this.pPayment.Controls.Add(this.lstCustomerSuggest);
            this.pPayment.Controls.Add(this.lblCustomerName);
            this.pPayment.Controls.Add(this.txtCustomerName);
            this.pPayment.Controls.Add(this.btnPrintInvoice);
            this.pPayment.Controls.Add(this.btnPaid);
            this.pPayment.Controls.Add(this.lblPaymentMethod);
            this.pPayment.Controls.Add(this.lblTotalCaption);
            this.pPayment.Controls.Add(this.btnCancel);
            this.pPayment.Controls.Add(this.btnPay);
            this.pPayment.Controls.Add(this.pBank);
            this.pPayment.Controls.Add(this.pCash);
            this.pPayment.Controls.Add(this.cboPaymentMethod);
            this.pPayment.Controls.Add(this.txtTotal);
            this.pPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPayment.FillColor = System.Drawing.Color.White;
            this.pPayment.Location = new System.Drawing.Point(0, 282);
            this.pPayment.Name = "pPayment";
            this.pPayment.Size = new System.Drawing.Size(600, 601);
            this.pPayment.TabIndex = 4;
            // 
            // txtSymptoms
            // 
            this.txtSymptoms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSymptoms.BorderRadius = 6;
            this.txtSymptoms.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSymptoms.DefaultText = "";
            this.txtSymptoms.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSymptoms.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSymptoms.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSymptoms.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSymptoms.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSymptoms.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSymptoms.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSymptoms.Location = new System.Drawing.Point(323, 103);
            this.txtSymptoms.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSymptoms.Name = "txtSymptoms";
            this.txtSymptoms.PlaceholderText = "";
            this.txtSymptoms.SelectedText = "";
            this.txtSymptoms.Size = new System.Drawing.Size(232, 41);
            this.txtSymptoms.TabIndex = 24;
            // 
            // lblSymptoms
            // 
            this.lblSymptoms.AutoSize = true;
            this.lblSymptoms.BackColor = System.Drawing.Color.White;
            this.lblSymptoms.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSymptoms.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblSymptoms.Location = new System.Drawing.Point(24, 110);
            this.lblSymptoms.Name = "lblSymptoms";
            this.lblSymptoms.Size = new System.Drawing.Size(129, 28);
            this.lblSymptoms.TabIndex = 23;
            this.lblSymptoms.Text = "Triệu chứng:";
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerPhone.BorderRadius = 6;
            this.txtCustomerPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCustomerPhone.DefaultText = "";
            this.txtCustomerPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCustomerPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCustomerPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomerPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCustomerPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomerPhone.Location = new System.Drawing.Point(325, 54);
            this.txtCustomerPhone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.PlaceholderText = "";
            this.txtCustomerPhone.SelectedText = "";
            this.txtCustomerPhone.Size = new System.Drawing.Size(230, 41);
            this.txtCustomerPhone.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(24, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 28);
            this.label3.TabIndex = 21;
            this.label3.Text = "SĐT:";
            // 
            // lstCustomerSuggest
            // 
            this.lstCustomerSuggest.FormattingEnabled = true;
            this.lstCustomerSuggest.ItemHeight = 16;
            this.lstCustomerSuggest.Location = new System.Drawing.Point(324, 43);
            this.lstCustomerSuggest.Name = "lstCustomerSuggest";
            this.lstCustomerSuggest.Size = new System.Drawing.Size(231, 84);
            this.lstCustomerSuggest.TabIndex = 20;
            this.lstCustomerSuggest.Visible = false;
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.BackColor = System.Drawing.Color.White;
            this.lblCustomerName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCustomerName.Location = new System.Drawing.Point(24, 20);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(165, 28);
            this.lblCustomerName.TabIndex = 19;
            this.lblCustomerName.Text = "Tên khách hàng:";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCustomerName.BorderRadius = 6;
            this.txtCustomerName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCustomerName.DefaultText = "";
            this.txtCustomerName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCustomerName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCustomerName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCustomerName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomerName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCustomerName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCustomerName.Location = new System.Drawing.Point(324, 8);
            this.txtCustomerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.PlaceholderText = "";
            this.txtCustomerName.SelectedText = "";
            this.txtCustomerName.Size = new System.Drawing.Size(230, 41);
            this.txtCustomerName.TabIndex = 18;
            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintInvoice.BorderRadius = 8;
            this.btnPrintInvoice.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrintInvoice.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrintInvoice.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrintInvoice.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrintInvoice.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPrintInvoice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrintInvoice.ForeColor = System.Drawing.Color.White;
            this.btnPrintInvoice.Location = new System.Drawing.Point(469, 429);
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(116, 49);
            this.btnPrintInvoice.TabIndex = 17;
            this.btnPrintInvoice.Text = "In hóa đơn";
            this.btnPrintInvoice.Visible = false;
            // 
            // btnPaid
            // 
            this.btnPaid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPaid.BorderRadius = 8;
            this.btnPaid.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPaid.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPaid.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPaid.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPaid.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPaid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPaid.ForeColor = System.Drawing.Color.White;
            this.btnPaid.Location = new System.Drawing.Point(469, 359);
            this.btnPaid.Name = "btnPaid";
            this.btnPaid.Size = new System.Drawing.Size(116, 49);
            this.btnPaid.TabIndex = 16;
            this.btnPaid.Text = "Đã thanh toán";
            // 
            // lblPaymentMethod
            // 
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.BackColor = System.Drawing.Color.White;
            this.lblPaymentMethod.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentMethod.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblPaymentMethod.Location = new System.Drawing.Point(20, 199);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(250, 28);
            this.lblPaymentMethod.TabIndex = 11;
            this.lblPaymentMethod.Text = "Phương thức thanh toán:";
            // 
            // lblTotalCaption
            // 
            this.lblTotalCaption.AutoSize = true;
            this.lblTotalCaption.BackColor = System.Drawing.Color.White;
            this.lblTotalCaption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCaption.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblTotalCaption.Location = new System.Drawing.Point(20, 154);
            this.lblTotalCaption.Name = "lblTotalCaption";
            this.lblTotalCaption.Size = new System.Drawing.Size(225, 28);
            this.lblTotalCaption.TabIndex = 5;
            this.lblTotalCaption.Text = "Tổng giá trị đơn hàng:";
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
            this.btnCancel.Location = new System.Drawing.Point(469, 429);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 49);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Hủy hóa đơn";
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
            this.btnPay.Location = new System.Drawing.Point(469, 286);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(116, 49);
            this.btnPay.TabIndex = 9;
            this.btnPay.Text = "Thanh toán";
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click_1);
            // 
            // pBank
            // 
            this.pBank.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pBank.Controls.Add(this.label2);
            this.pBank.Controls.Add(this.pbQr);
            this.pBank.Location = new System.Drawing.Point(15, 378);
            this.pBank.Name = "pBank";
            this.pBank.Size = new System.Drawing.Size(417, 220);
            this.pBank.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(9, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 28);
            this.label2.TabIndex = 14;
            this.label2.Text = "Quét mã QR để thanh toán";
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
            // pCash
            // 
            this.pCash.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pCash.Controls.Add(this.lblChange);
            this.pCash.Controls.Add(this.lblCashGiven);
            this.pCash.Controls.Add(this.txtChange);
            this.pCash.Controls.Add(this.txtCashGiven);
            this.pCash.Location = new System.Drawing.Point(15, 242);
            this.pCash.Name = "pCash";
            this.pCash.Size = new System.Drawing.Size(417, 130);
            this.pCash.TabIndex = 7;
            // 
            // lblChange
            // 
            this.lblChange.AutoSize = true;
            this.lblChange.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblChange.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChange.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblChange.Location = new System.Drawing.Point(5, 72);
            this.lblChange.Name = "lblChange";
            this.lblChange.Size = new System.Drawing.Size(102, 28);
            this.lblChange.TabIndex = 13;
            this.lblChange.Text = "Tiền thối:";
            // 
            // lblCashGiven
            // 
            this.lblCashGiven.AutoSize = true;
            this.lblCashGiven.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblCashGiven.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashGiven.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblCashGiven.Location = new System.Drawing.Point(5, 27);
            this.lblCashGiven.Name = "lblCashGiven";
            this.lblCashGiven.Size = new System.Drawing.Size(163, 28);
            this.lblCashGiven.TabIndex = 12;
            this.lblCashGiven.Text = "Tiền khách đưa:";
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
            this.txtChange.Location = new System.Drawing.Point(238, 70);
            this.txtChange.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtChange.Name = "txtChange";
            this.txtChange.PlaceholderText = "0";
            this.txtChange.ReadOnly = true;
            this.txtChange.SelectedText = "";
            this.txtChange.Size = new System.Drawing.Size(150, 30);
            this.txtChange.TabIndex = 9;
            this.txtChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.txtCashGiven.Location = new System.Drawing.Point(238, 25);
            this.txtCashGiven.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCashGiven.Name = "txtCashGiven";
            this.txtCashGiven.PlaceholderText = "0";
            this.txtCashGiven.SelectedText = "";
            this.txtCashGiven.Size = new System.Drawing.Size(150, 30);
            this.txtCashGiven.TabIndex = 7;
            this.txtCashGiven.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboPaymentMethod
            // 
            this.cboPaymentMethod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.cboPaymentMethod.Location = new System.Drawing.Point(324, 191);
            this.cboPaymentMethod.Name = "cboPaymentMethod";
            this.cboPaymentMethod.Size = new System.Drawing.Size(230, 36);
            this.cboPaymentMethod.TabIndex = 6;
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.txtTotal.Location = new System.Drawing.Point(323, 152);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.PlaceholderText = "0";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.SelectedText = "";
            this.txtTotal.Size = new System.Drawing.Size(230, 30);
            this.txtTotal.TabIndex = 4;
            this.txtTotal.TextChanged += new System.EventHandler(this.txtTotal_TextChanged);
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
            this.lblCart.Click += new System.EventHandler(this.lblCart_Click);
            // 
            // pHeader
            // 
            this.pHeader.Controls.Add(this.lblDate);
            this.pHeader.Controls.Add(this.lblStaffName);
            this.pHeader.Controls.Add(this.lblStaffCaption);
            this.pHeader.Controls.Add(this.lblTitle);
            this.pHeader.Controls.Add(this.txtSearchProduct);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(1345, 70);
            this.pHeader.TabIndex = 0;
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(1090, 34);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(95, 20);
            this.lblDate.TabIndex = 8;
            this.lblDate.Text = "11/11/2025";
            // 
            // lblStaffName
            // 
            this.lblStaffName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStaffName.AutoSize = true;
            this.lblStaffName.BackColor = System.Drawing.Color.Transparent;
            this.lblStaffName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(201)))), ((int)(((byte)(170)))));
            this.lblStaffName.Location = new System.Drawing.Point(1207, 12);
            this.lblStaffName.Name = "lblStaffName";
            this.lblStaffName.Size = new System.Drawing.Size(79, 20);
            this.lblStaffName.TabIndex = 7;
            this.lblStaffName.Text = "Nguyễn A";
            // 
            // lblStaffCaption
            // 
            this.lblStaffCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStaffCaption.AutoSize = true;
            this.lblStaffCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblStaffCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffCaption.ForeColor = System.Drawing.Color.White;
            this.lblStaffCaption.Location = new System.Drawing.Point(1090, 12);
            this.lblStaffCaption.Name = "lblStaffCaption";
            this.lblStaffCaption.Size = new System.Drawing.Size(84, 20);
            this.lblStaffCaption.TabIndex = 6;
            this.lblStaffCaption.Text = "Nhân viên:";
            this.lblStaffCaption.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTitle.Location = new System.Drawing.Point(20, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(223, 38);
            this.lblTitle.TabIndex = 3;
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
            this.txtSearchProduct.Location = new System.Drawing.Point(311, 18);
            this.txtSearchProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchProduct.Name = "txtSearchProduct";
            this.txtSearchProduct.PlaceholderText = "Tìm thuốc theo tên / mã...";
            this.txtSearchProduct.SelectedText = "";
            this.txtSearchProduct.Size = new System.Drawing.Size(722, 36);
            this.txtSearchProduct.TabIndex = 1;
            this.txtSearchProduct.TextChanged += new System.EventHandler(this.txtSearchProduct_TextChanged);
            this.txtSearchProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchProduct_KeyDown);
            // 
            // colMaThuoc
            // 
            this.colMaThuoc.DataPropertyName = "ProductCode";
            this.colMaThuoc.HeaderText = "Mã thuốc";
            this.colMaThuoc.MinimumWidth = 6;
            this.colMaThuoc.Name = "colMaThuoc";
            this.colMaThuoc.ReadOnly = true;
            // 
            // colTenThuoc
            // 
            this.colTenThuoc.DataPropertyName = "ProductName";
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
            this.colGiaBan.DataPropertyName = "SalePrice";
            this.colGiaBan.HeaderText = "Giá bán";
            this.colGiaBan.MinimumWidth = 6;
            this.colGiaBan.Name = "colGiaBan";
            this.colGiaBan.ReadOnly = true;
            // 
            // colTonKho
            // 
            this.colTonKho.DataPropertyName = "StockQuantity";
            this.colTonKho.HeaderText = "Tồn Kho";
            this.colTonKho.MinimumWidth = 6;
            this.colTonKho.Name = "colTonKho";
            this.colTonKho.ReadOnly = true;
            // 
            // colProductId
            // 
            this.colProductId.DataPropertyName = "ProductId";
            this.colProductId.HeaderText = "Column1";
            this.colProductId.MinimumWidth = 6;
            this.colProductId.Name = "colProductId";
            this.colProductId.ReadOnly = true;
            this.colProductId.Visible = false;
            // 
            // UC_POS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.pRoot);
            this.Name = "UC_POS";
            this.Size = new System.Drawing.Size(1345, 959);
            this.pRoot.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.pLeft.ResumeLayout(false);
            this.pLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProducts)).EndInit();
            this.pRight.ResumeLayout(false);
            this.pRight.PerformLayout();
            this.pPayment.ResumeLayout(false);
            this.pPayment.PerformLayout();
            this.pBank.ResumeLayout(false);
            this.pBank.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbQr)).EndInit();
            this.pCash.ResumeLayout(false);
            this.pCash.PerformLayout();
            this.pHeader.ResumeLayout(false);
            this.pHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pRoot;
        private Guna.UI2.WinForms.Guna2Panel pHeader;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchProduct;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private Guna.UI2.WinForms.Guna2Panel pLeft;
        private Guna.UI2.WinForms.Guna2ComboBox cboCategoryPOS;
        private Guna.UI2.WinForms.Guna2Panel pRight;
        private Guna.UI2.WinForms.Guna2DataGridView gvProducts;
        private System.Windows.Forms.ListView lvCart;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCart;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private Guna.UI2.WinForms.Guna2Panel pPayment;
        private Guna.UI2.WinForms.Guna2TextBox txtTotal;
        private Guna.UI2.WinForms.Guna2Panel pCash;
        private Guna.UI2.WinForms.Guna2ComboBox cboPaymentMethod;
        private Guna.UI2.WinForms.Guna2Panel pBank;
        private System.Windows.Forms.PictureBox pbQr;
        private Guna.UI2.WinForms.Guna2TextBox txtChange;
        private Guna.UI2.WinForms.Guna2TextBox txtCashGiven;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Button btnPay;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.Label lblTotalCaption;
        private System.Windows.Forms.Label lblChange;
        private System.Windows.Forms.Label lblCashGiven;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStaffCaption;
        private System.Windows.Forms.Label lblStaffName;
        private System.Windows.Forms.Label lblDate;
        private Guna.UI2.WinForms.Guna2Button btnPrintInvoice;
        private Guna.UI2.WinForms.Guna2Button btnPaid;
        private System.Windows.Forms.Label lblCustomerName;
        private Guna.UI2.WinForms.Guna2TextBox txtCustomerName;
        private System.Windows.Forms.ListBox lstCustomerSuggest;
        private Guna.UI2.WinForms.Guna2TextBox txtCustomerPhone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSymptoms;
        private Guna.UI2.WinForms.Guna2TextBox txtSymptoms;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenThuoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colGiaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTonKho;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductId;
    }
}
