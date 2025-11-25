namespace PharmacyApp.Forms
{
    partial class FrmProductDeactivate
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblProductNameLabel = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.btnDeactivate = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Teal;
            this.lblTitle.Location = new System.Drawing.Point(76, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 43);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Ngưng kinh doanh sản phẩm";
            // 
            // lblProductNameLabel
            // 
            this.lblProductNameLabel.AutoSize = true;
            this.lblProductNameLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblProductNameLabel.Location = new System.Drawing.Point(26, 80);
            this.lblProductNameLabel.Name = "lblProductNameLabel";
            this.lblProductNameLabel.Size = new System.Drawing.Size(132, 25);
            this.lblProductNameLabel.TabIndex = 1;
            this.lblProductNameLabel.Text = "Tên sản phẩm:";
            // 
            // lblProductName
            // 
            this.lblProductName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblProductName.ForeColor = System.Drawing.Color.Black;
            this.lblProductName.Location = new System.Drawing.Point(177, 80);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(343, 27);
            this.lblProductName.TabIndex = 2;
            this.lblProductName.Text = "Tên thuốc";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblReason.Location = new System.Drawing.Point(26, 128);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(120, 25);
            this.lblReason.TabIndex = 3;
            this.lblReason.Text = "Lý do ngưng:";
            // 
            // txtReason
            // 
            this.txtReason.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtReason.Location = new System.Drawing.Point(31, 155);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReason.Size = new System.Drawing.Size(491, 128);
            this.txtReason.TabIndex = 4;
            // 
            // btnDeactivate
            // 
            this.btnDeactivate.BorderRadius = 6;
            this.btnDeactivate.FillColor = System.Drawing.Color.Firebrick;
            this.btnDeactivate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeactivate.ForeColor = System.Drawing.Color.White;
            this.btnDeactivate.Location = new System.Drawing.Point(31, 309);
            this.btnDeactivate.Name = "btnDeactivate";
            this.btnDeactivate.Size = new System.Drawing.Size(206, 48);
            this.btnDeactivate.TabIndex = 5;
            this.btnDeactivate.Text = "Ngưng kinh doanh";
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 6;
            this.btnCancel.FillColor = System.Drawing.Color.Gray;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(317, 309);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(206, 48);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Hủy";
            // 
            // FrmProductDeactivate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 385);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDeactivate);
            this.Controls.Add(this.txtReason);
            this.Controls.Add(this.lblReason);
            this.Controls.Add(this.lblProductName);
            this.Controls.Add(this.lblProductNameLabel);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProductDeactivate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ngưng kinh doanh sản phẩm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblProductNameLabel;
        public System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.TextBox txtReason;
        private Guna.UI2.WinForms.Guna2Button btnDeactivate;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
    }
}
