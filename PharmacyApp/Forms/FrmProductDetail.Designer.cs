using Guna.UI2.WinForms;
using System.Windows.Forms;
using System.Drawing;

namespace PharmacyApp.Forms
{
    partial class FrmProductDetail
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Guna2PictureBox picImage;
        private Guna2Button btnBrowseImage;
        private Label lblTitle;
        private Label label1;
        private Guna2TextBox txtName;
        private Label label2;
        private Guna2TextBox txtCompany;
        private Label label3;
        private Guna2TextBox txtPrice;
        private Label label4;
        private Guna2TextBox txtBarcode;
        private Label label5;
        private Guna2ComboBox cboCategory;
        private Guna2Button btnEdit;
        private Guna2Button btnSave;
        private Guna2Button btnCancel;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.picImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnBrowseImage = new Guna.UI2.WinForms.Guna2Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCompany = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrice = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBarcode = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboCategory = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnEdit = new Guna.UI2.WinForms.Guna2Button();
            this.btnSave = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // FrmProductDetail (Form)
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Color.White;
            this.ClientSize = new System.Drawing.Size(720, 380);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmProductDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết sản phẩm";

            // ==== màu mint chủ đạo ====
            Color mint = Color.FromArgb(105, 196, 246);   // xanh giống bạn hay dùng
            Color mintDark = Color.FromArgb(54, 215, 183);

            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = mintDark;
            this.lblTitle.Location = new System.Drawing.Point(24, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(210, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Chi tiết sản phẩm";
            // 
            // picImage
            // 
            this.picImage.BorderRadius = 12;
            this.picImage.Location = new System.Drawing.Point(24, 68);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(220, 220);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picImage.TabIndex = 1;
            this.picImage.TabStop = false;
            this.picImage.FillColor = Color.WhiteSmoke;
            // 
            // btnBrowseImage
            // 
            this.btnBrowseImage.BorderRadius = 10;
            this.btnBrowseImage.FillColor = mint;
            this.btnBrowseImage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnBrowseImage.ForeColor = Color.White;
            this.btnBrowseImage.Location = new System.Drawing.Point(24, 302);
            this.btnBrowseImage.Name = "btnBrowseImage";
            this.btnBrowseImage.Size = new System.Drawing.Size(220, 32);
            this.btnBrowseImage.TabIndex = 2;
            this.btnBrowseImage.Text = "Chọn ảnh...";
            // 
            // label1 - tên sản phẩm
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(270, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tên sản phẩm:";
            // 
            // txtName
            // 
            this.txtName.BorderRadius = 8;
            this.txtName.PlaceholderText = "Ví dụ: Paracetamol 500mg";
            this.txtName.Location = new System.Drawing.Point(370, 74);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(300, 28);
            this.txtName.TabIndex = 4;
            this.txtName.FocusedState.BorderColor = mintDark;
            this.txtName.HoverState.BorderColor = mint;
            // 
            // label2 - công ty
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Công ty dược:";
            // 
            // txtCompany
            // 
            this.txtCompany.BorderRadius = 8;
            this.txtCompany.PlaceholderText = "Ví dụ: Công ty Dược ABC";
            this.txtCompany.Location = new System.Drawing.Point(370, 118);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(300, 28);
            this.txtCompany.TabIndex = 6;
            this.txtCompany.FocusedState.BorderColor = mintDark;
            this.txtCompany.HoverState.BorderColor = mint;
            // 
            // label3 - giá bán
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(270, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Giá bán:";
            // 
            // txtPrice
            // 
            this.txtPrice.BorderRadius = 8;
            this.txtPrice.PlaceholderText = "VD: 150000";
            this.txtPrice.Location = new System.Drawing.Point(370, 162);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(160, 28);
            this.txtPrice.TabIndex = 8;
            this.txtPrice.FocusedState.BorderColor = mintDark;
            this.txtPrice.HoverState.BorderColor = mint;
            // 
            // label4 - barcode
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Barcode:";
            // 
            // txtBarcode
            // 
            this.txtBarcode.BorderRadius = 8;
            this.txtBarcode.PlaceholderText = "Mã vạch / QR code";
            this.txtBarcode.Location = new System.Drawing.Point(370, 206);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(300, 28);
            this.txtBarcode.TabIndex = 10;
            this.txtBarcode.FocusedState.BorderColor = mintDark;
            this.txtBarcode.HoverState.BorderColor = mint;
            // 
            // label5 - danh mục
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(270, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Danh mục:";
            // 
            // cboCategory
            // 
            this.cboCategory.BackColor = Color.Transparent;
            this.cboCategory.BorderRadius = 8;
            this.cboCategory.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategory.FocusedColor = mintDark;
            this.cboCategory.FocusedState.BorderColor = mintDark;
            this.cboCategory.ItemHeight = 24;
            this.cboCategory.Location = new System.Drawing.Point(370, 250);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(220, 30);
            this.cboCategory.TabIndex = 12;
            // 
            // btnEdit
            // 
            this.btnEdit.BorderRadius = 10;
            this.btnEdit.FillColor = mint;
            this.btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnEdit.ForeColor = Color.White;
            this.btnEdit.Location = new System.Drawing.Point(370, 302);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 32);
            this.btnEdit.TabIndex = 13;
            this.btnEdit.Text = "Sửa";
            // 
            // btnSave
            // 
            this.btnSave.BorderRadius = 10;
            this.btnSave.FillColor = mintDark;
            this.btnSave.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new System.Drawing.Point(466, 302);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 32);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Lưu";
            // 
            // btnCancel
            // 
            this.btnCancel.BorderRadius = 10;
            this.btnCancel.FillColor = Color.Silver;
            this.btnCancel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new System.Drawing.Point(562, 302);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 32);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Hủy";
            // 
            // add controls to Form
            // 
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.cboCategory);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBarcode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnBrowseImage);
            this.Controls.Add(this.picImage);

            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
