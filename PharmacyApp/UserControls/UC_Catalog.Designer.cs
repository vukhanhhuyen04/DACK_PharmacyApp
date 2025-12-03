namespace PharmacyApp.UserControls
{
    partial class UC_Catalog
    {
        private System.ComponentModel.IContainer components = null;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.btnFind = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.chkShowInactive = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button2 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button3 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button4 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button5 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button6 = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button7 = new Guna.UI2.WinForms.Guna2Button();
            this.flpProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.guna2Panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.BorderRadius = 8;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(248, 14);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "🔎 Tìm thuốc...";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(439, 40);
            this.txtSearch.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.BorderRadius = 8;
            this.btnAdd.FillColor = System.Drawing.Color.MediumSeaGreen;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(1031, 14);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(110, 40);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Thêm thuốc";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BorderRadius = 8;
            this.btnRefresh.FillColor = System.Drawing.Color.DodgerBlue;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(1147, 14);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(101, 40);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // btnFind
            // 
            this.btnFind.BorderRadius = 8;
            this.btnFind.FillColor = System.Drawing.Color.SkyBlue;
            this.btnFind.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFind.ForeColor = System.Drawing.Color.White;
            this.btnFind.Location = new System.Drawing.Point(926, 14);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(99, 40);
            this.btnFind.TabIndex = 4;
            this.btnFind.Text = "Tìm";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.Controls.Add(this.chkShowInactive);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.btnRefresh);
            this.guna2Panel1.Controls.Add(this.btnAdd);
            this.guna2Panel1.Controls.Add(this.btnFind);
            this.guna2Panel1.Controls.Add(this.txtSearch);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Padding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.guna2Panel1.Size = new System.Drawing.Size(1263, 70);
            this.guna2Panel1.TabIndex = 5;
            // 
            // chkShowInactive
            // 
            this.chkShowInactive.AutoSize = true;
            this.chkShowInactive.Location = new System.Drawing.Point(693, 31);
            this.chkShowInactive.Name = "chkShowInactive";
            this.chkShowInactive.Size = new System.Drawing.Size(227, 20);
            this.chkShowInactive.TabIndex = 5;
            this.chkShowInactive.Text = "Hiện sản phẩm ngưng kinh doanh";
            this.chkShowInactive.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH MỤC THUỐC";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.guna2Button1);
            this.flowLayoutPanel1.Controls.Add(this.guna2Button2);
            this.flowLayoutPanel1.Controls.Add(this.guna2Button3);
            this.flowLayoutPanel1.Controls.Add(this.guna2Button4);
            this.flowLayoutPanel1.Controls.Add(this.guna2Button5);
            this.flowLayoutPanel1.Controls.Add(this.guna2Button6);
            this.flowLayoutPanel1.Controls.Add(this.guna2Button7);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 70);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1263, 60);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // guna2Button1
            // 
            this.guna2Button1.BorderRadius = 20;
            this.guna2Button1.FillColor = System.Drawing.Color.Teal;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(15, 15);
            this.guna2Button1.Margin = new System.Windows.Forms.Padding(5);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(137, 31);
            this.guna2Button1.TabIndex = 5;
            this.guna2Button1.Text = "Thuốc tân dược";
            // 
            // guna2Button2
            // 
            this.guna2Button2.BorderRadius = 20;
            this.guna2Button2.FillColor = System.Drawing.Color.Teal;
            this.guna2Button2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button2.ForeColor = System.Drawing.Color.White;
            this.guna2Button2.Location = new System.Drawing.Point(162, 15);
            this.guna2Button2.Margin = new System.Windows.Forms.Padding(5);
            this.guna2Button2.Name = "guna2Button2";
            this.guna2Button2.Size = new System.Drawing.Size(182, 31);
            this.guna2Button2.TabIndex = 6;
            this.guna2Button2.Text = "Thực phẩm chức năng";
            this.guna2Button2.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // guna2Button3
            // 
            this.guna2Button3.BorderRadius = 20;
            this.guna2Button3.FillColor = System.Drawing.Color.Teal;
            this.guna2Button3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button3.ForeColor = System.Drawing.Color.White;
            this.guna2Button3.Location = new System.Drawing.Point(354, 15);
            this.guna2Button3.Margin = new System.Windows.Forms.Padding(5);
            this.guna2Button3.Name = "guna2Button3";
            this.guna2Button3.Size = new System.Drawing.Size(135, 31);
            this.guna2Button3.TabIndex = 7;
            this.guna2Button3.Text = "Dược mỹ phẩm";
            // 
            // guna2Button4
            // 
            this.guna2Button4.BorderRadius = 20;
            this.guna2Button4.FillColor = System.Drawing.Color.Teal;
            this.guna2Button4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button4.ForeColor = System.Drawing.Color.White;
            this.guna2Button4.Location = new System.Drawing.Point(499, 15);
            this.guna2Button4.Margin = new System.Windows.Forms.Padding(5);
            this.guna2Button4.Name = "guna2Button4";
            this.guna2Button4.Size = new System.Drawing.Size(90, 31);
            this.guna2Button4.TabIndex = 8;
            this.guna2Button4.Text = "Mẹ & bé";
            // 
            // guna2Button5
            // 
            this.guna2Button5.BorderRadius = 20;
            this.guna2Button5.FillColor = System.Drawing.Color.Teal;
            this.guna2Button5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button5.ForeColor = System.Drawing.Color.White;
            this.guna2Button5.Location = new System.Drawing.Point(599, 15);
            this.guna2Button5.Margin = new System.Windows.Forms.Padding(5);
            this.guna2Button5.Name = "guna2Button5";
            this.guna2Button5.Size = new System.Drawing.Size(117, 31);
            this.guna2Button5.TabIndex = 9;
            this.guna2Button5.Text = "Dụng cụ y tế";
            this.guna2Button5.Click += new System.EventHandler(this.guna2Button5_Click);
            // 
            // guna2Button6
            // 
            this.guna2Button6.BorderRadius = 20;
            this.guna2Button6.FillColor = System.Drawing.Color.Teal;
            this.guna2Button6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button6.ForeColor = System.Drawing.Color.White;
            this.guna2Button6.Location = new System.Drawing.Point(726, 15);
            this.guna2Button6.Margin = new System.Windows.Forms.Padding(5);
            this.guna2Button6.Name = "guna2Button6";
            this.guna2Button6.Size = new System.Drawing.Size(97, 31);
            this.guna2Button6.TabIndex = 10;
            this.guna2Button6.Text = "Hóa dược";
            // 
            // guna2Button7
            // 
            this.guna2Button7.BorderRadius = 20;
            this.guna2Button7.FillColor = System.Drawing.Color.Teal;
            this.guna2Button7.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button7.ForeColor = System.Drawing.Color.White;
            this.guna2Button7.Location = new System.Drawing.Point(833, 15);
            this.guna2Button7.Margin = new System.Windows.Forms.Padding(5);
            this.guna2Button7.Name = "guna2Button7";
            this.guna2Button7.Size = new System.Drawing.Size(189, 31);
            this.guna2Button7.TabIndex = 11;
            this.guna2Button7.Text = "+ (nút thêm danh mục)";
            this.guna2Button7.Visible = false;
            this.guna2Button7.Click += new System.EventHandler(this.guna2Button7_Click);
            // 
            // flpProducts
            // 
            this.flpProducts.AutoScroll = true;
            this.flpProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProducts.Location = new System.Drawing.Point(0, 130);
            this.flpProducts.Name = "flpProducts";
            this.flpProducts.Padding = new System.Windows.Forms.Padding(10);
            this.flpProducts.Size = new System.Drawing.Size(1263, 781);
            this.flpProducts.TabIndex = 7;
            // 
            // UC_Catalog
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.flpProducts);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "UC_Catalog";
            this.Size = new System.Drawing.Size(1263, 911);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Guna.UI2.WinForms.Guna2Button btnFind;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button guna2Button2;
        private Guna.UI2.WinForms.Guna2Button guna2Button3;
        private Guna.UI2.WinForms.Guna2Button guna2Button4;
        private Guna.UI2.WinForms.Guna2Button guna2Button5;
        private Guna.UI2.WinForms.Guna2Button guna2Button6;
        private Guna.UI2.WinForms.Guna2Button guna2Button7;
        private System.Windows.Forms.FlowLayoutPanel flpProducts;
        private System.Windows.Forms.CheckBox chkShowInactive;
    }
}
