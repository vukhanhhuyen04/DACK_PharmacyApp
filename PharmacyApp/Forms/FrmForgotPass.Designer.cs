namespace PharmacyApp.Forms
{
    partial class FrmForgotPass
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.card = new Guna.UI2.WinForms.Guna2Panel();
            this.txtOld = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.shapeTop2 = new Guna.UI2.WinForms.Guna2Shapes();
            this.sepTitle = new Guna.UI2.WinForms.Guna2Separator();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.lblBrandCare = new System.Windows.Forms.Label();
            this.card.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // card
            // 
            this.card.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.card.BackColor = System.Drawing.Color.Transparent;
            this.card.BorderRadius = 12;
            this.card.Controls.Add(this.lblBrandCare);
            this.card.Controls.Add(this.lblBrand);
            this.card.Controls.Add(this.txtOld);
            this.card.Controls.Add(this.btnSave);
            this.card.Controls.Add(this.btnCancel);
            this.card.FillColor = System.Drawing.Color.WhiteSmoke;
            this.card.Location = new System.Drawing.Point(192, 253);
            this.card.Name = "card";
            this.card.ShadowDecoration.Enabled = true;
            this.card.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 6, 0, 12);
            this.card.Size = new System.Drawing.Size(560, 303);
            this.card.TabIndex = 3;
            // 
            // txtOld
            // 
            this.txtOld.BorderRadius = 6;
            this.txtOld.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOld.DefaultText = "";
            this.txtOld.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtOld.Location = new System.Drawing.Point(80, 116);
            this.txtOld.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOld.Name = "txtOld";
            this.txtOld.PlaceholderText = "Email";
            this.txtOld.SelectedText = "";
            this.txtOld.Size = new System.Drawing.Size(405, 48);
            this.txtOld.TabIndex = 1;
            this.txtOld.TextChanged += new System.EventHandler(this.txtOld_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 6;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(201)))), ((int)(((byte)(170)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(305, 207);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 40);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Gửi OTP";
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 6;
            this.btnCancel.FillColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.btnCancel.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancel.Location = new System.Drawing.Point(80, 207);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // shapeTop2
            // 
            this.shapeTop2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.shapeTop2.BorderThickness = 0;
            this.shapeTop2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(99)))), ((int)(((byte)(167)))));
            this.shapeTop2.Location = new System.Drawing.Point(160, -274);
            this.shapeTop2.Name = "shapeTop2";
            this.shapeTop2.PolygonSkip = 1;
            this.shapeTop2.Rotate = 0F;
            this.shapeTop2.Shape = Guna.UI2.WinForms.Enums.ShapeType.Ellipse;
            this.shapeTop2.Size = new System.Drawing.Size(1345, 400);
            this.shapeTop2.TabIndex = 4;
            this.shapeTop2.Zoom = 80;
            // 
            // sepTitle
            // 
            this.sepTitle.FillColor = System.Drawing.Color.WhiteSmoke;
            this.sepTitle.Location = new System.Drawing.Point(322, 171);
            this.sepTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sepTitle.Name = "sepTitle";
            this.sepTitle.Size = new System.Drawing.Size(300, 2);
            this.sepTitle.TabIndex = 5;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.AutoSize = false;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(243, 98);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(458, 52);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Quên mật khẩu";
            this.lblTitle.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnMinimize.IconColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(857, 11);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(35, 30);
            this.btnMinimize.TabIndex = 12;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(898, 11);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 30);
            this.btnClose.TabIndex = 13;
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI Semibold", 22.2F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(196)))), ((int)(((byte)(246)))));
            this.lblBrand.Location = new System.Drawing.Point(154, 21);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(129, 50);
            this.lblBrand.TabIndex = 54;
            this.lblBrand.Text = "Eterna";
            this.lblBrand.Click += new System.EventHandler(this.lblBrand_Click);
            // 
            // lblBrandCare
            // 
            this.lblBrandCare.Font = new System.Drawing.Font("Segoe UI Semibold", 22.2F, System.Drawing.FontStyle.Bold);
            this.lblBrandCare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(215)))), ((int)(((byte)(183)))));
            this.lblBrandCare.Location = new System.Drawing.Point(289, 21);
            this.lblBrandCare.Name = "lblBrandCare";
            this.lblBrandCare.Size = new System.Drawing.Size(129, 50);
            this.lblBrandCare.TabIndex = 55;
            this.lblBrandCare.Text = "Med";
            // 
            // FrmForgotPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(22)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(945, 748);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.sepTitle);
            this.Controls.Add(this.card);
            this.Controls.Add(this.shapeTop2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmForgotPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmChangePassword";
            this.card.ResumeLayout(false);
            this.card.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Shapes shapeTop2;
        private Guna.UI2.WinForms.Guna2Panel card;
        private Guna.UI2.WinForms.Guna2TextBox txtOld;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Separator sepTitle;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2ControlBox btnMinimize;
        private Guna.UI2.WinForms.Guna2ControlBox btnClose;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Label lblBrandCare;
    }
}
