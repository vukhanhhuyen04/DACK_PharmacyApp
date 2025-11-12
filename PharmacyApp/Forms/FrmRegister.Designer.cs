namespace PharmacyApp.Forms
{
    partial class FrmRegister
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.borderless = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.shadow = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.shapeTop2 = new Guna.UI2.WinForms.Guna2Shapes();
            this.shapeTop3 = new Guna.UI2.WinForms.Guna2Shapes();
            this.sepTitle = new Guna.UI2.WinForms.Guna2Separator();
            this.card = new Guna.UI2.WinForms.Guna2Panel();
            this.lblBrandCare = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblBrand = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnSignUp1 = new Guna.UI2.WinForms.Guna2Button();
            this.txtPass = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNIC = new Guna.UI2.WinForms.Guna2TextBox();
            this.grpRole = new Guna.UI2.WinForms.Guna2GroupBox();
            this.rdoAdmin = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rdoPharmacist = new Guna.UI2.WinForms.Guna2RadioButton();
            this.txtPhone = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.card.SuspendLayout();
            this.grpRole.SuspendLayout();
            this.SuspendLayout();
            // 
            // borderless
            // 
            this.borderless.ContainerControl = this;
            this.borderless.DockIndicatorTransparencyValue = 0.6D;
            this.borderless.TransparentWhileDrag = true;
            // 
            // shapeTop2
            // 
            this.shapeTop2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shapeTop2.BorderThickness = 0;
            this.shapeTop2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(99)))), ((int)(((byte)(167)))));
            this.shapeTop2.Location = new System.Drawing.Point(168, -264);
            this.shapeTop2.Name = "shapeTop2";
            this.shapeTop2.PolygonSkip = 1;
            this.shapeTop2.Rotate = 0F;
            this.shapeTop2.Shape = Guna.UI2.WinForms.Enums.ShapeType.Ellipse;
            this.shapeTop2.Size = new System.Drawing.Size(1559, 420);
            this.shapeTop2.TabIndex = 4;
            this.shapeTop2.Text = "guna2Shapes3";
            this.shapeTop2.Zoom = 80;
            this.shapeTop2.Click += new System.EventHandler(this.guna2Shapes1_Click);
            // 
            // shapeTop3
            // 
            this.shapeTop3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shapeTop3.BorderThickness = 0;
            this.shapeTop3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(147)))), ((int)(((byte)(178)))));
            this.shapeTop3.Location = new System.Drawing.Point(-120, -270);
            this.shapeTop3.Name = "shapeTop3";
            this.shapeTop3.PolygonSkip = 1;
            this.shapeTop3.Rotate = 0F;
            this.shapeTop3.Shape = Guna.UI2.WinForms.Enums.ShapeType.Ellipse;
            this.shapeTop3.Size = new System.Drawing.Size(1239, 270);
            this.shapeTop3.TabIndex = 5;
            this.shapeTop3.Text = "guna2Shapes3";
            this.shapeTop3.Zoom = 80;
            this.shapeTop3.Click += new System.EventHandler(this.guna2Shapes2_Click);
            // 
            // sepTitle
            // 
            this.sepTitle.FillColor = System.Drawing.Color.WhiteSmoke;
            this.sepTitle.Location = new System.Drawing.Point(229, 162);
            this.sepTitle.Name = "sepTitle";
            this.sepTitle.Size = new System.Drawing.Size(300, 10);
            this.sepTitle.TabIndex = 7;
            // 
            // card
            // 
            this.card.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.card.BackColor = System.Drawing.Color.Transparent;
            this.card.BorderRadius = 10;
            this.card.Controls.Add(this.lblBrandCare);
            this.card.Controls.Add(this.lblBrand);
            this.card.Controls.Add(this.linkLabel1);
            this.card.Controls.Add(this.btnSignUp1);
            this.card.Controls.Add(this.txtPass);
            this.card.Controls.Add(this.txtEmail);
            this.card.Controls.Add(this.txtNIC);
            this.card.Controls.Add(this.grpRole);
            this.card.Controls.Add(this.txtPhone);
            this.card.Controls.Add(this.txtName);
            this.card.FillColor = System.Drawing.Color.WhiteSmoke;
            this.card.Location = new System.Drawing.Point(119, 193);
            this.card.Name = "card";
            this.card.ShadowDecoration.Enabled = true;
            this.card.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 6, 0, 12);
            this.card.Size = new System.Drawing.Size(520, 574);
            this.card.TabIndex = 8;
            // 
            // lblBrandCare
            // 
            this.lblBrandCare.BackColor = System.Drawing.Color.Transparent;
            this.lblBrandCare.Font = new System.Drawing.Font("Segoe UI Semibold", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrandCare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(215)))), ((int)(((byte)(183)))));
            this.lblBrandCare.Location = new System.Drawing.Point(275, 24);
            this.lblBrandCare.Name = "lblBrandCare";
            this.lblBrandCare.Size = new System.Drawing.Size(79, 52);
            this.lblBrandCare.TabIndex = 13;
            this.lblBrandCare.Text = "Med";
            // 
            // lblBrand
            // 
            this.lblBrand.BackColor = System.Drawing.Color.Transparent;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI Semibold", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(196)))), ((int)(((byte)(246)))));
            this.lblBrand.Location = new System.Drawing.Point(164, 24);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(110, 52);
            this.lblBrand.TabIndex = 12;
            this.lblBrand.Text = "Eterna";
            // 
            // linkLabel1
            // 
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(215)))), ((int)(((byte)(183)))));
            this.linkLabel1.Location = new System.Drawing.Point(213, 536);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(95, 23);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Đăng nhập";
            // 
            // btnSignUp1
            // 
            this.btnSignUp1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSignUp1.BorderRadius = 6;
            this.btnSignUp1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSignUp1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSignUp1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSignUp1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSignUp1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(201)))), ((int)(((byte)(170)))));
            this.btnSignUp1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignUp1.ForeColor = System.Drawing.Color.White;
            this.btnSignUp1.Location = new System.Drawing.Point(58, 478);
            this.btnSignUp1.Name = "btnSignUp1";
            this.btnSignUp1.Size = new System.Drawing.Size(405, 43);
            this.btnSignUp1.TabIndex = 7;
            this.btnSignUp1.Text = "Đăng kí";
            // 
            // txtPass
            // 
            this.txtPass.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtPass.BorderRadius = 6;
            this.txtPass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPass.DefaultText = "";
            this.txtPass.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPass.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPass.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPass.Location = new System.Drawing.Point(58, 428);
            this.txtPass.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '●';
            this.txtPass.PlaceholderText = "Mật khẩu";
            this.txtPass.SelectedText = "";
            this.txtPass.Size = new System.Drawing.Size(405, 42);
            this.txtPass.TabIndex = 6;
            this.txtPass.TextChanged += new System.EventHandler(this.txtPass_TextChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtEmail.BorderRadius = 6;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Location = new System.Drawing.Point(58, 376);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "Email của bạn";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(405, 42);
            this.txtEmail.TabIndex = 5;
            // 
            // txtNIC
            // 
            this.txtNIC.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtNIC.BorderRadius = 6;
            this.txtNIC.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNIC.DefaultText = "";
            this.txtNIC.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNIC.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNIC.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNIC.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNIC.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNIC.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNIC.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNIC.Location = new System.Drawing.Point(58, 324);
            this.txtNIC.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtNIC.Name = "txtNIC";
            this.txtNIC.PlaceholderText = "Địa chỉ";
            this.txtNIC.SelectedText = "";
            this.txtNIC.Size = new System.Drawing.Size(405, 42);
            this.txtNIC.TabIndex = 4;
            // 
            // grpRole
            // 
            this.grpRole.BorderRadius = 8;
            this.grpRole.Controls.Add(this.rdoAdmin);
            this.grpRole.Controls.Add(this.rdoPharmacist);
            this.grpRole.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpRole.ForeColor = System.Drawing.Color.DimGray;
            this.grpRole.Location = new System.Drawing.Point(80, 164);
            this.grpRole.Name = "grpRole";
            this.grpRole.Size = new System.Drawing.Size(360, 100);
            this.grpRole.TabIndex = 11;
            this.grpRole.Text = "Bạn là ai?";
            // 
            // rdoAdmin
            // 
            this.rdoAdmin.AutoSize = true;
            this.rdoAdmin.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdoAdmin.CheckedState.BorderThickness = 0;
            this.rdoAdmin.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdoAdmin.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdoAdmin.CheckedState.InnerOffset = -4;
            this.rdoAdmin.Location = new System.Drawing.Point(137, 45);
            this.rdoAdmin.Name = "rdoAdmin";
            this.rdoAdmin.Size = new System.Drawing.Size(81, 27);
            this.rdoAdmin.TabIndex = 1;
            this.rdoAdmin.Text = "Admin";
            this.rdoAdmin.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rdoAdmin.UncheckedState.BorderThickness = 2;
            this.rdoAdmin.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdoAdmin.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // rdoPharmacist
            // 
            this.rdoPharmacist.AutoSize = true;
            this.rdoPharmacist.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdoPharmacist.CheckedState.BorderThickness = 0;
            this.rdoPharmacist.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdoPharmacist.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdoPharmacist.CheckedState.InnerOffset = -4;
            this.rdoPharmacist.Location = new System.Drawing.Point(137, 73);
            this.rdoPharmacist.Name = "rdoPharmacist";
            this.rdoPharmacist.Size = new System.Drawing.Size(87, 27);
            this.rdoPharmacist.TabIndex = 2;
            this.rdoPharmacist.Text = "Dược sĩ";
            this.rdoPharmacist.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rdoPharmacist.UncheckedState.BorderThickness = 2;
            this.rdoPharmacist.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdoPharmacist.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            // 
            // txtPhone
            // 
            this.txtPhone.BorderColor = System.Drawing.Color.Gainsboro;
            this.txtPhone.BorderRadius = 6;
            this.txtPhone.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPhone.DefaultText = "";
            this.txtPhone.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPhone.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPhone.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPhone.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhone.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPhone.Location = new System.Drawing.Point(58, 272);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.PlaceholderText = "Số điện thoại";
            this.txtPhone.SelectedText = "";
            this.txtPhone.Size = new System.Drawing.Size(405, 42);
            this.txtPhone.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.BorderRadius = 6;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.DefaultText = "";
            this.txtName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtName.Location = new System.Drawing.Point(58, 108);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtName.Name = "txtName";
            this.txtName.PlaceholderText = "Tên của bạn";
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(405, 48);
            this.txtName.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(712, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 30);
            this.btnClose.TabIndex = 9;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnMinimize.IconColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(671, 12);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(35, 30);
            this.btnMinimize.TabIndex = 10;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(306, 96);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(147, 50);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "Đăng kí";
            this.lblTitle.Click += new System.EventHandler(this.lblTitle_Click);
            // 
            // FrmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(22)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(759, 855);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.card);
            this.Controls.Add(this.sepTitle);
            this.Controls.Add(this.shapeTop3);
            this.Controls.Add(this.shapeTop2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sign Up";
            this.Load += new System.EventHandler(this.FrmRegister_Load);
            this.card.ResumeLayout(false);
            this.card.PerformLayout();
            this.grpRole.ResumeLayout(false);
            this.grpRole.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm borderless;
        private Guna.UI2.WinForms.Guna2ShadowForm shadow;
        private Guna.UI2.WinForms.Guna2Shapes shapeTop3;
        private Guna.UI2.WinForms.Guna2Shapes shapeTop2;
        private Guna.UI2.WinForms.Guna2Separator sepTitle;
        private Guna.UI2.WinForms.Guna2Panel card;
        private Guna.UI2.WinForms.Guna2TextBox txtPhone;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private Guna.UI2.WinForms.Guna2GroupBox grpRole;
        private Guna.UI2.WinForms.Guna2RadioButton rdoAdmin;
        private Guna.UI2.WinForms.Guna2RadioButton rdoPharmacist;
        private Guna.UI2.WinForms.Guna2TextBox txtPass;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtNIC;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private Guna.UI2.WinForms.Guna2ControlBox btnMinimize;
        private Guna.UI2.WinForms.Guna2ControlBox btnClose;
        private System.Windows.Forms.Label lblTitle;
        private Guna.UI2.WinForms.Guna2Button btnSignUp1;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblBrand;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblBrandCare;
    }
}