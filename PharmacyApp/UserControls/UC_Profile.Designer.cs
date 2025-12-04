namespace PharmacyApp.UserControls
{
    partial class UC_Profile
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
            this.pRoot = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.gbSystem = new Guna.UI2.WinForms.Guna2GroupBox();
            this.cboRole = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnChangePassword = new Guna.UI2.WinForms.Guna2Button();
            this.txtPasswordMask = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.gbProfessional = new Guna.UI2.WinForms.Guna2GroupBox();
            this.cboStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpLicenseExpire = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblExpire = new System.Windows.Forms.Label();
            this.dtpHireDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblHireDate = new System.Windows.Forms.Label();
            this.cboQualification = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblQualification = new System.Windows.Forms.Label();
            this.tlpTop = new System.Windows.Forms.TableLayoutPanel();
            this.pBasic = new Guna.UI2.WinForms.Guna2Panel();
            this.txtAddress = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.cboGender = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.dtpBirthDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblBirthDate = new System.Windows.Forms.Label();
            this.txtFullName = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.pAvatar = new Guna.UI2.WinForms.Guna2Panel();
            this.txtStaffCode = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblStaffCode = new System.Windows.Forms.Label();
            this.btnChangeAvatar = new Guna.UI2.WinForms.Guna2Button();
            this.picAvatar = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.sepTitle = new Guna.UI2.WinForms.Guna2Separator();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pRoot.SuspendLayout();
            this.gbSystem.SuspendLayout();
            this.gbProfessional.SuspendLayout();
            this.tlpTop.SuspendLayout();
            this.pBasic.SuspendLayout();
            this.pAvatar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // pRoot
            // 
            this.pRoot.Controls.Add(this.btnCancel);
            this.pRoot.Controls.Add(this.btnSave);
            this.pRoot.Controls.Add(this.gbSystem);
            this.pRoot.Controls.Add(this.gbProfessional);
            this.pRoot.Controls.Add(this.tlpTop);
            this.pRoot.Controls.Add(this.sepTitle);
            this.pRoot.Controls.Add(this.lblTitle);
            this.pRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pRoot.FillColor = System.Drawing.Color.WhiteSmoke;
            this.pRoot.Location = new System.Drawing.Point(0, 0);
            this.pRoot.Name = "pRoot";
            this.pRoot.Padding = new System.Windows.Forms.Padding(20);
            this.pRoot.Size = new System.Drawing.Size(1112, 825);
            this.pRoot.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BorderRadius = 8;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.Gray;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(775, 786);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 36);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Hủy";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BorderRadius = 8;
            this.btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(201)))), ((int)(((byte)(170)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(920, 786);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 36);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Lưu";
            // 
            // gbSystem
            // 
            this.gbSystem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSystem.Controls.Add(this.cboRole);
            this.gbSystem.Controls.Add(this.btnChangePassword);
            this.gbSystem.Controls.Add(this.txtPasswordMask);
            this.gbSystem.Controls.Add(this.lblRole);
            this.gbSystem.Controls.Add(this.txtUsername);
            this.gbSystem.Controls.Add(this.lblPassword);
            this.gbSystem.Controls.Add(this.lblUsername);
            this.gbSystem.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.gbSystem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gbSystem.Location = new System.Drawing.Point(20, 579);
            this.gbSystem.Name = "gbSystem";
            this.gbSystem.Size = new System.Drawing.Size(1069, 201);
            this.gbSystem.TabIndex = 4;
            this.gbSystem.Text = "Thông tin hệ thống";
            // 
            // cboRole
            // 
            this.cboRole.BackColor = System.Drawing.Color.Transparent;
            this.cboRole.BorderRadius = 6;
            this.cboRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRole.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboRole.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboRole.ItemHeight = 30;
            this.cboRole.Items.AddRange(new object[] {
            "Admin",
            "Dược sĩ"});
            this.cboRole.Location = new System.Drawing.Point(170, 145);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(150, 36);
            this.cboRole.TabIndex = 24;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BorderRadius = 8;
            this.btnChangePassword.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChangePassword.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChangePassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChangePassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChangePassword.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.Location = new System.Drawing.Point(412, 107);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(130, 30);
            this.btnChangePassword.TabIndex = 23;
            this.btnChangePassword.Text = "Đổi mật khẩu";
            // 
            // txtPasswordMask
            // 
            this.txtPasswordMask.BorderRadius = 6;
            this.txtPasswordMask.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPasswordMask.DefaultText = "";
            this.txtPasswordMask.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPasswordMask.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPasswordMask.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPasswordMask.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPasswordMask.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPasswordMask.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPasswordMask.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPasswordMask.Location = new System.Drawing.Point(170, 107);
            this.txtPasswordMask.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPasswordMask.Name = "txtPasswordMask";
            this.txtPasswordMask.PlaceholderText = "";
            this.txtPasswordMask.ReadOnly = true;
            this.txtPasswordMask.SelectedText = "";
            this.txtPasswordMask.Size = new System.Drawing.Size(220, 30);
            this.txtPasswordMask.TabIndex = 22;
            this.txtPasswordMask.UseSystemPasswordChar = true;
            // 
            // lblRole
            // 
            this.lblRole.BackColor = System.Drawing.Color.White;
            this.lblRole.ForeColor = System.Drawing.Color.Black;
            this.lblRole.Location = new System.Drawing.Point(20, 150);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(140, 25);
            this.lblRole.TabIndex = 18;
            this.lblRole.Text = "Vai trò:";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUsername
            // 
            this.txtUsername.BorderRadius = 6;
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.DefaultText = "";
            this.txtUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsername.Location = new System.Drawing.Point(170, 57);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PlaceholderText = "";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.SelectedText = "";
            this.txtUsername.Size = new System.Drawing.Size(220, 30);
            this.txtUsername.TabIndex = 17;
            // 
            // lblPassword
            // 
            this.lblPassword.BackColor = System.Drawing.Color.White;
            this.lblPassword.ForeColor = System.Drawing.Color.Black;
            this.lblPassword.Location = new System.Drawing.Point(20, 107);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(140, 25);
            this.lblPassword.TabIndex = 16;
            this.lblPassword.Text = "Mật khẩu:";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUsername
            // 
            this.lblUsername.BackColor = System.Drawing.Color.White;
            this.lblUsername.ForeColor = System.Drawing.Color.Black;
            this.lblUsername.Location = new System.Drawing.Point(7, 57);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(153, 25);
            this.lblUsername.TabIndex = 14;
            this.lblUsername.Text = "Tên đăng nhập:";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbProfessional
            // 
            this.gbProfessional.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbProfessional.Controls.Add(this.cboStatus);
            this.gbProfessional.Controls.Add(this.dtpLicenseExpire);
            this.gbProfessional.Controls.Add(this.lblStatus);
            this.gbProfessional.Controls.Add(this.lblExpire);
            this.gbProfessional.Controls.Add(this.dtpHireDate);
            this.gbProfessional.Controls.Add(this.lblHireDate);
            this.gbProfessional.Controls.Add(this.cboQualification);
            this.gbProfessional.Controls.Add(this.lblQualification);
            this.gbProfessional.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.gbProfessional.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.gbProfessional.Location = new System.Drawing.Point(20, 381);
            this.gbProfessional.Name = "gbProfessional";
            this.gbProfessional.Size = new System.Drawing.Size(1072, 192);
            this.gbProfessional.TabIndex = 3;
            this.gbProfessional.Text = "Thông tin chuyên môn";
            // 
            // cboStatus
            // 
            this.cboStatus.BackColor = System.Drawing.Color.Transparent;
            this.cboStatus.BorderRadius = 6;
            this.cboStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboStatus.ItemHeight = 30;
            this.cboStatus.Items.AddRange(new object[] {
            "Hoạt động",
            "Ngưng hoạt động"});
            this.cboStatus.Location = new System.Drawing.Point(120, 112);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(244, 36);
            this.cboStatus.TabIndex = 26;
            // 
            // dtpLicenseExpire
            // 
            this.dtpLicenseExpire.BorderRadius = 6;
            this.dtpLicenseExpire.Checked = true;
            this.dtpLicenseExpire.CustomFormat = "dd/MM/yyyy";
            this.dtpLicenseExpire.FillColor = System.Drawing.Color.PowderBlue;
            this.dtpLicenseExpire.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpLicenseExpire.ForeColor = System.Drawing.Color.Black;
            this.dtpLicenseExpire.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpLicenseExpire.Location = new System.Drawing.Point(705, 112);
            this.dtpLicenseExpire.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpLicenseExpire.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpLicenseExpire.Name = "dtpLicenseExpire";
            this.dtpLicenseExpire.Size = new System.Drawing.Size(187, 36);
            this.dtpLicenseExpire.TabIndex = 21;
            this.dtpLicenseExpire.Value = new System.DateTime(2025, 11, 15, 10, 17, 36, 487);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.White;
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(10, 117);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(110, 25);
            this.lblStatus.TabIndex = 25;
            this.lblStatus.Text = "Trạng thái:";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblExpire
            // 
            this.lblExpire.BackColor = System.Drawing.Color.White;
            this.lblExpire.ForeColor = System.Drawing.Color.Black;
            this.lblExpire.Location = new System.Drawing.Point(555, 117);
            this.lblExpire.Name = "lblExpire";
            this.lblExpire.Size = new System.Drawing.Size(140, 25);
            this.lblExpire.TabIndex = 20;
            this.lblExpire.Text = "Ngày hết hạn:";
            this.lblExpire.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpHireDate
            // 
            this.dtpHireDate.BorderRadius = 6;
            this.dtpHireDate.Checked = true;
            this.dtpHireDate.CustomFormat = "dd/MM/yyyy";
            this.dtpHireDate.FillColor = System.Drawing.Color.PowderBlue;
            this.dtpHireDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpHireDate.ForeColor = System.Drawing.Color.Black;
            this.dtpHireDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHireDate.Location = new System.Drawing.Point(705, 55);
            this.dtpHireDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpHireDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpHireDate.Name = "dtpHireDate";
            this.dtpHireDate.Size = new System.Drawing.Size(187, 36);
            this.dtpHireDate.TabIndex = 19;
            this.dtpHireDate.Value = new System.DateTime(2025, 11, 30, 1, 31, 37, 432);
            // 
            // lblHireDate
            // 
            this.lblHireDate.BackColor = System.Drawing.Color.White;
            this.lblHireDate.ForeColor = System.Drawing.Color.Black;
            this.lblHireDate.Location = new System.Drawing.Point(555, 60);
            this.lblHireDate.Name = "lblHireDate";
            this.lblHireDate.Size = new System.Drawing.Size(140, 25);
            this.lblHireDate.TabIndex = 18;
            this.lblHireDate.Text = "Ngày vào làm:";
            this.lblHireDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboQualification
            // 
            this.cboQualification.BackColor = System.Drawing.Color.Transparent;
            this.cboQualification.BorderRadius = 6;
            this.cboQualification.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboQualification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQualification.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboQualification.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboQualification.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboQualification.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboQualification.ItemHeight = 30;
            this.cboQualification.Items.AddRange(new object[] {
            "Dược sĩ",
            "Đại học",
            "Cao đẳng",
            "Trung cấp",
            "Dược tá"});
            this.cboQualification.Location = new System.Drawing.Point(120, 55);
            this.cboQualification.Name = "cboQualification";
            this.cboQualification.Size = new System.Drawing.Size(244, 36);
            this.cboQualification.TabIndex = 15;
            // 
            // lblQualification
            // 
            this.lblQualification.BackColor = System.Drawing.Color.White;
            this.lblQualification.ForeColor = System.Drawing.Color.Black;
            this.lblQualification.Location = new System.Drawing.Point(10, 60);
            this.lblQualification.Name = "lblQualification";
            this.lblQualification.Size = new System.Drawing.Size(110, 25);
            this.lblQualification.TabIndex = 14;
            this.lblQualification.Text = "Trình độ:";
            this.lblQualification.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tlpTop
            // 
            this.tlpTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpTop.ColumnCount = 2;
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpTop.Controls.Add(this.pBasic, 1, 0);
            this.tlpTop.Controls.Add(this.pAvatar, 0, 0);
            this.tlpTop.Location = new System.Drawing.Point(20, 70);
            this.tlpTop.Name = "tlpTop";
            this.tlpTop.RowCount = 1;
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.Size = new System.Drawing.Size(1072, 299);
            this.tlpTop.TabIndex = 2;
            // 
            // pBasic
            // 
            this.pBasic.Controls.Add(this.txtAddress);
            this.pBasic.Controls.Add(this.lblAddress);
            this.pBasic.Controls.Add(this.txtEmail);
            this.pBasic.Controls.Add(this.lblEmail);
            this.pBasic.Controls.Add(this.txtPhone);
            this.pBasic.Controls.Add(this.lblPhone);
            this.pBasic.Controls.Add(this.cboGender);
            this.pBasic.Controls.Add(this.lblGender);
            this.pBasic.Controls.Add(this.dtpBirthDate);
            this.pBasic.Controls.Add(this.lblBirthDate);
            this.pBasic.Controls.Add(this.txtFullName);
            this.pBasic.Controls.Add(this.lblFullName);
            this.pBasic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBasic.Location = new System.Drawing.Point(324, 3);
            this.pBasic.Name = "pBasic";
            this.pBasic.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pBasic.Size = new System.Drawing.Size(745, 293);
            this.pBasic.TabIndex = 1;
            // 
            // txtAddress
            // 
            this.txtAddress.BorderRadius = 6;
            this.txtAddress.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAddress.DefaultText = "";
            this.txtAddress.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAddress.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAddress.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAddress.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAddress.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAddress.Location = new System.Drawing.Point(140, 238);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PlaceholderText = "";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.SelectedText = "";
            this.txtAddress.Size = new System.Drawing.Size(573, 40);
            this.txtAddress.TabIndex = 14;
            // 
            // lblAddress
            // 
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAddress.ForeColor = System.Drawing.Color.Black;
            this.lblAddress.Location = new System.Drawing.Point(10, 238);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(110, 20);
            this.lblAddress.TabIndex = 13;
            this.lblAddress.Text = "Địa chỉ:";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderRadius = 6;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Location = new System.Drawing.Point(140, 194);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(280, 36);
            this.txtEmail.TabIndex = 12;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmail.ForeColor = System.Drawing.Color.Black;
            this.lblEmail.Location = new System.Drawing.Point(10, 194);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(110, 20);
            this.lblEmail.TabIndex = 11;
            this.lblEmail.Text = "Email:";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPhone
            // 
            this.txtPhone.BorderRadius = 6;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.DefaultText = "";
            this.txtPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhone.Location = new System.Drawing.Point(140, 150);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PlaceholderText = "";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.SelectedText = "";
            this.txtPhone.Size = new System.Drawing.Size(180, 36);
            this.txtPhone.TabIndex = 10;
            // 
            // lblPhone
            // 
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPhone.ForeColor = System.Drawing.Color.Black;
            this.lblPhone.Location = new System.Drawing.Point(10, 150);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(110, 20);
            this.lblPhone.TabIndex = 9;
            this.lblPhone.Text = "Số điện thoại:";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboGender
            // 
            this.cboGender.BackColor = System.Drawing.Color.Transparent;
            this.cboGender.BorderRadius = 6;
            this.cboGender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboGender.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboGender.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboGender.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboGender.ItemHeight = 30;
            this.cboGender.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cboGender.Location = new System.Drawing.Point(140, 93);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(120, 36);
            this.cboGender.TabIndex = 8;
            // 
            // lblGender
            // 
            this.lblGender.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGender.ForeColor = System.Drawing.Color.Black;
            this.lblGender.Location = new System.Drawing.Point(10, 93);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(110, 20);
            this.lblGender.TabIndex = 7;
            this.lblGender.Text = "Giới tính:";
            this.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.BorderRadius = 6;
            this.dtpBirthDate.Checked = true;
            this.dtpBirthDate.CustomFormat = "dd/MM/yyyy";
            this.dtpBirthDate.FillColor = System.Drawing.Color.PowderBlue;
            this.dtpBirthDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpBirthDate.ForeColor = System.Drawing.Color.Black;
            this.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBirthDate.Location = new System.Drawing.Point(140, 51);
            this.dtpBirthDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpBirthDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(192, 36);
            this.dtpBirthDate.TabIndex = 6;
            this.dtpBirthDate.Value = new System.DateTime(2025, 11, 15, 10, 17, 36, 487);
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBirthDate.ForeColor = System.Drawing.Color.Black;
            this.lblBirthDate.Location = new System.Drawing.Point(10, 51);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(110, 20);
            this.lblBirthDate.TabIndex = 5;
            this.lblBirthDate.Text = "Ngày sinh:";
            this.lblBirthDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFullName
            // 
            this.txtFullName.BorderRadius = 6;
            this.txtFullName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFullName.DefaultText = "";
            this.txtFullName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFullName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFullName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFullName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFullName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFullName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFullName.Location = new System.Drawing.Point(140, 8);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.PlaceholderText = "";
            this.txtFullName.ReadOnly = true;
            this.txtFullName.SelectedText = "";
            this.txtFullName.Size = new System.Drawing.Size(280, 36);
            this.txtFullName.TabIndex = 4;
            // 
            // lblFullName
            // 
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFullName.ForeColor = System.Drawing.Color.Black;
            this.lblFullName.Location = new System.Drawing.Point(10, 14);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(110, 20);
            this.lblFullName.TabIndex = 3;
            this.lblFullName.Text = "Họ và tên:";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pAvatar
            // 
            this.pAvatar.Controls.Add(this.txtStaffCode);
            this.pAvatar.Controls.Add(this.lblStaffCode);
            this.pAvatar.Controls.Add(this.btnChangeAvatar);
            this.pAvatar.Controls.Add(this.picAvatar);
            this.pAvatar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pAvatar.Location = new System.Drawing.Point(3, 3);
            this.pAvatar.Name = "pAvatar";
            this.pAvatar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.pAvatar.Size = new System.Drawing.Size(315, 293);
            this.pAvatar.TabIndex = 0;
            // 
            // txtStaffCode
            // 
            this.txtStaffCode.BorderRadius = 6;
            this.txtStaffCode.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtStaffCode.DefaultText = "";
            this.txtStaffCode.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtStaffCode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtStaffCode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtStaffCode.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtStaffCode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtStaffCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtStaffCode.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtStaffCode.Location = new System.Drawing.Point(127, 200);
            this.txtStaffCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtStaffCode.Name = "txtStaffCode";
            this.txtStaffCode.PlaceholderText = "";
            this.txtStaffCode.ReadOnly = true;
            this.txtStaffCode.SelectedText = "";
            this.txtStaffCode.Size = new System.Drawing.Size(120, 36);
            this.txtStaffCode.TabIndex = 3;
            // 
            // lblStaffCode
            // 
            this.lblStaffCode.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStaffCode.Location = new System.Drawing.Point(10, 205);
            this.lblStaffCode.Name = "lblStaffCode";
            this.lblStaffCode.Size = new System.Drawing.Size(110, 20);
            this.lblStaffCode.TabIndex = 2;
            this.lblStaffCode.Text = "Mã nhân sự:";
            this.lblStaffCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnChangeAvatar
            // 
            this.btnChangeAvatar.BorderRadius = 8;
            this.btnChangeAvatar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnChangeAvatar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnChangeAvatar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnChangeAvatar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnChangeAvatar.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnChangeAvatar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnChangeAvatar.ForeColor = System.Drawing.Color.White;
            this.btnChangeAvatar.Location = new System.Drawing.Point(50, 160);
            this.btnChangeAvatar.Name = "btnChangeAvatar";
            this.btnChangeAvatar.Size = new System.Drawing.Size(100, 32);
            this.btnChangeAvatar.TabIndex = 1;
            this.btnChangeAvatar.Text = "Đổi ảnh";
            // 
            // picAvatar
            // 
            this.picAvatar.ImageRotate = 0F;
            this.picAvatar.Location = new System.Drawing.Point(30, 10);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.picAvatar.Size = new System.Drawing.Size(140, 140);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;
            // 
            // sepTitle
            // 
            this.sepTitle.Location = new System.Drawing.Point(20, 55);
            this.sepTitle.Name = "sepTitle";
            this.sepTitle.Size = new System.Drawing.Size(400, 2);
            this.sepTitle.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(99)))), ((int)(((byte)(167)))));
            this.lblTitle.Location = new System.Drawing.Point(20, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(473, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THÔNG TIN CÁ NHÂN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UC_Profile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pRoot);
            this.Name = "UC_Profile";
            this.Size = new System.Drawing.Size(1112, 825);
            this.pRoot.ResumeLayout(false);
            this.gbSystem.ResumeLayout(false);
            this.gbProfessional.ResumeLayout(false);
            this.tlpTop.ResumeLayout(false);
            this.pBasic.ResumeLayout(false);
            this.pAvatar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pRoot;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tlpTop;
        private Guna.UI2.WinForms.Guna2Panel pAvatar;
        private Guna.UI2.WinForms.Guna2Separator sepTitle;
        private Guna.UI2.WinForms.Guna2Panel pBasic;
        private Guna.UI2.WinForms.Guna2TextBox txtFullName;
        private System.Windows.Forms.Label lblFullName;
        private Guna.UI2.WinForms.Guna2TextBox txtStaffCode;
        private System.Windows.Forms.Label lblStaffCode;
        private Guna.UI2.WinForms.Guna2Button btnChangeAvatar;
        private Guna.UI2.WinForms.Guna2CirclePictureBox picAvatar;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private Guna.UI2.WinForms.Guna2ComboBox cboGender;
        private System.Windows.Forms.Label lblGender;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Label lblBirthDate;
        private Guna.UI2.WinForms.Guna2TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private Guna.UI2.WinForms.Guna2GroupBox gbProfessional;
        private System.Windows.Forms.Label lblQualification;
        //  private Guna.UI2.WinForms.Guna2TextBox txtLicenseNo;
        // private System.Windows.Forms.Label lblLicenseNo;
        private Guna.UI2.WinForms.Guna2ComboBox cboQualification;
        private System.Windows.Forms.Label lblExpire;
        //  private Guna.UI2.WinForms.Guna2DateTimePicker dtpLicenseIssue;
        //  private System.Windows.Forms.Label lblIssue;
        private System.Windows.Forms.Label lblHireDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpHireDate;

        private Guna.UI2.WinForms.Guna2GroupBox gbSystem;
        private System.Windows.Forms.Label lblRole;
        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpLicenseExpire;
        private Guna.UI2.WinForms.Guna2TextBox txtPasswordMask;
        private System.Windows.Forms.Label lblStatus;
        private Guna.UI2.WinForms.Guna2ComboBox cboRole;
        private Guna.UI2.WinForms.Guna2Button btnChangePassword;
        private Guna.UI2.WinForms.Guna2ComboBox cboStatus;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
    }
}
