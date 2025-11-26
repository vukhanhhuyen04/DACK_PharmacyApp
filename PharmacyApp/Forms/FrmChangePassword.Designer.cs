namespace PharmacyApp.Forms
{
    partial class FrmChangePassword
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
            this.btnMinimize = new Guna.UI2.WinForms.Guna2ControlBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2ControlBox();
            this.card = new Guna.UI2.WinForms.Guna2Panel();
            this.lblBrandCare = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblBrand = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtOld = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtNew = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtConfirm = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.shapeTop2 = new Guna.UI2.WinForms.Guna2Shapes();
            this.sepTitle = new Guna.UI2.WinForms.Guna2Separator();
            this.card.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.btnMinimize.FillColor = System.Drawing.Color.Transparent;
            this.btnMinimize.IconColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(712, 12);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(35, 30);
            this.btnMinimize.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(753, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(35, 30);
            this.btnClose.TabIndex = 2;
            // 
            // card
            // 
            this.card.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.card.BackColor = System.Drawing.Color.Transparent;
            this.card.BorderRadius = 12;
            this.card.Controls.Add(this.lblBrandCare);
            this.card.Controls.Add(this.lblBrand);
            this.card.Controls.Add(this.txtOld);
            this.card.Controls.Add(this.txtNew);
            this.card.Controls.Add(this.txtConfirm);
            this.card.Controls.Add(this.btnSave);
            this.card.Controls.Add(this.btnCancel);
            this.card.FillColor = System.Drawing.Color.WhiteSmoke;
            this.card.Location = new System.Drawing.Point(120, 164);
            this.card.Name = "card";
            this.card.ShadowDecoration.Enabled = true;
            this.card.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 6, 0, 12);
            this.card.Size = new System.Drawing.Size(560, 412);
            this.card.TabIndex = 3;
            // 
            // lblBrandCare
            // 
            this.lblBrandCare.BackColor = System.Drawing.Color.Transparent;
            this.lblBrandCare.Font = new System.Drawing.Font("Segoe UI Semibold", 22.2F, System.Drawing.FontStyle.Bold);
            this.lblBrandCare.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(215)))), ((int)(((byte)(183)))));
            this.lblBrandCare.Location = new System.Drawing.Point(295, 21);
            this.lblBrandCare.Name = "lblBrandCare";
            this.lblBrandCare.Size = new System.Drawing.Size(79, 52);
            this.lblBrandCare.TabIndex = 51;
            this.lblBrandCare.Text = "Med";
            // 
            // lblBrand
            // 
            this.lblBrand.BackColor = System.Drawing.Color.Transparent;
            this.lblBrand.Font = new System.Drawing.Font("Segoe UI Semibold", 22.2F, System.Drawing.FontStyle.Bold);
            this.lblBrand.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(196)))), ((int)(((byte)(246)))));
            this.lblBrand.Location = new System.Drawing.Point(186, 21);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(110, 52);
            this.lblBrand.TabIndex = 50;
            this.lblBrand.Text = "Eterna";
            // 
            // txtOld
            // 
            this.txtOld.BorderRadius = 6;
            this.txtOld.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOld.DefaultText = "";
            this.txtOld.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtOld.Location = new System.Drawing.Point(80, 102);
            this.txtOld.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOld.Name = "txtOld";
            this.txtOld.PasswordChar = '●';
            this.txtOld.PlaceholderText = "Mật khẩu hiện tại";
            this.txtOld.SelectedText = "";
            this.txtOld.Size = new System.Drawing.Size(405, 48);
            this.txtOld.TabIndex = 1;
            // 
            // txtNew
            // 
            this.txtNew.BorderRadius = 6;
            this.txtNew.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNew.DefaultText = "";
            this.txtNew.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNew.Location = new System.Drawing.Point(80, 176);
            this.txtNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNew.Name = "txtNew";
            this.txtNew.PasswordChar = '●';
            this.txtNew.PlaceholderText = "Mật khẩu mới";
            this.txtNew.SelectedText = "";
            this.txtNew.Size = new System.Drawing.Size(405, 48);
            this.txtNew.TabIndex = 2;
            // 
            // txtConfirm
            // 
            this.txtConfirm.BorderRadius = 6;
            this.txtConfirm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirm.DefaultText = "";
            this.txtConfirm.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtConfirm.Location = new System.Drawing.Point(80, 252);
            this.txtConfirm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.PasswordChar = '●';
            this.txtConfirm.PlaceholderText = "Nhập lại mật khẩu mới";
            this.txtConfirm.SelectedText = "";
            this.txtConfirm.Size = new System.Drawing.Size(405, 48);
            this.txtConfirm.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 6;
            this.btnSave.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(201)))), ((int)(((byte)(170)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(385, 325);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 40);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Lưu";
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 6;
            this.btnCancel.FillColor = System.Drawing.Color.Gainsboro;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10.8F);
            this.btnCancel.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancel.Location = new System.Drawing.Point(80, 325);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 40);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Hủy";
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22.2F);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(285, 74);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(223, 52);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Đổi mật khẩu";
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
            this.shapeTop2.Size = new System.Drawing.Size(1200, 400);
            this.shapeTop2.TabIndex = 4;
            this.shapeTop2.Zoom = 80;
            // 
            // sepTitle
            // 
            this.sepTitle.FillColor = System.Drawing.Color.WhiteSmoke;
            this.sepTitle.Location = new System.Drawing.Point(246, 135);
            this.sepTitle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sepTitle.Name = "sepTitle";
            this.sepTitle.Size = new System.Drawing.Size(300, 2);
            this.sepTitle.TabIndex = 5;
            // 
            // FrmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(22)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(800, 652);
            this.Controls.Add(this.sepTitle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.card);
            this.Controls.Add(this.shapeTop2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmChangePassword";
            this.card.ResumeLayout(false);
            this.card.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Shapes shapeTop2;
        private Guna.UI2.WinForms.Guna2ControlBox btnMinimize;
        private Guna.UI2.WinForms.Guna2ControlBox btnClose;
        private Guna.UI2.WinForms.Guna2Panel card;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTitle;
        private Guna.UI2.WinForms.Guna2TextBox txtOld;
        private Guna.UI2.WinForms.Guna2TextBox txtNew;
        private Guna.UI2.WinForms.Guna2TextBox txtConfirm;
        private Guna.UI2.WinForms.Guna2Button btnSave;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblBrand;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblBrandCare;
        private Guna.UI2.WinForms.Guna2Separator sepTitle;
    }
}
