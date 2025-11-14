using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using PharmacyApp;   // để dùng DbConfig, ConfigHelper, Program

namespace PharmacyApp.Forms
{
    public partial class FrmConfig : Form
    {
        private IContainer components = null;

        private Label lblServer;
        private Label lblDatabase;
        private Label lblUid;
        private Label lblPassword;

        private TextBox txtServer;
        private TextBox txtDatabase;
        private TextBox txtUid;
        private TextBox txtPassword;

        private CheckBox chkWindowsAuth;
        private Button btnSave;
        private Button btnCancel;

        public FrmConfig()
        {
            InitializeComponent();

            this.Load += FrmConfig_Load;
            chkWindowsAuth.CheckedChanged += chkWindowsAuth_CheckedChanged;
            btnSave.Click += btnSave_Click;
            btnCancel.Click += btnCancel_Click;
        }

        private void FrmConfig_Load(object sender, EventArgs e)
        {
            // Đọc config nếu có
            var cfg = ConfigHelper.LoadConfig();

            txtServer.Text = string.IsNullOrWhiteSpace(cfg.Server) ? @".\SQLEXPRESS" : cfg.Server;
            txtDatabase.Text = string.IsNullOrWhiteSpace(cfg.Database) ? "Database1" : cfg.Database;
            txtUid.Text = cfg.UserId ?? "sa";
            txtPassword.Text = cfg.Password ?? "";
            chkWindowsAuth.Checked = cfg.UseWindowsAuth;

            ToggleAuthControls();
        }

        private void chkWindowsAuth_CheckedChanged(object sender, EventArgs e)
        {
            ToggleAuthControls();
        }

        private void ToggleAuthControls()
        {
            bool useWin = chkWindowsAuth.Checked;
            txtUid.Enabled = !useWin;
            txtPassword.Enabled = !useWin;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        // ================== Designer code ==================
        private void InitializeComponent()
        {
            this.components = new Container();
            this.lblServer = new Label();
            this.lblDatabase = new Label();
            this.lblUid = new Label();
            this.lblPassword = new Label();
            this.txtServer = new TextBox();
            this.txtDatabase = new TextBox();
            this.txtUid = new TextBox();
            this.txtPassword = new TextBox();
            this.chkWindowsAuth = new CheckBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Location = new System.Drawing.Point(30, 30);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(44, 13);
            this.lblServer.TabIndex = 0;
            this.lblServer.Text = "Server:";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(110, 27);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(190, 20);
            this.txtServer.TabIndex = 1;
            // 
            // lblDatabase
            // 
            this.lblDatabase.AutoSize = true;
            this.lblDatabase.Location = new System.Drawing.Point(30, 60);
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(59, 13);
            this.lblDatabase.TabIndex = 2;
            this.lblDatabase.Text = "Database:";
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(110, 57);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(190, 20);
            this.txtDatabase.TabIndex = 3;
            // 
            // lblUid
            // 
            this.lblUid.AutoSize = true;
            this.lblUid.Location = new System.Drawing.Point(30, 90);
            this.lblUid.Name = "lblUid";
            this.lblUid.Size = new System.Drawing.Size(29, 13);
            this.lblUid.TabIndex = 4;
            this.lblUid.Text = "UID:";
            // 
            // txtUid
            // 
            this.txtUid.Location = new System.Drawing.Point(110, 87);
            this.txtUid.Name = "txtUid";
            this.txtUid.Size = new System.Drawing.Size(190, 20);
            this.txtUid.TabIndex = 5;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(30, 120);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(59, 13);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(110, 117);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(190, 20);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // chkWindowsAuth
            // 
            this.chkWindowsAuth.AutoSize = true;
            this.chkWindowsAuth.Location = new System.Drawing.Point(33, 150);
            this.chkWindowsAuth.Name = "chkWindowsAuth";
            this.chkWindowsAuth.Size = new System.Drawing.Size(128, 17);
            this.chkWindowsAuth.TabIndex = 8;
            this.chkWindowsAuth.Text = "Window Authentication";
            this.chkWindowsAuth.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(80, 185);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(190, 185);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FrmConfig
            // 
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(340, 235);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkWindowsAuth);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUid);
            this.Controls.Add(this.lblUid);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.lblDatabase);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.lblServer);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfig";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Config";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // ================== Nút Save / Cancel ==================
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtServer.Text) ||
                string.IsNullOrWhiteSpace(txtDatabase.Text))
            {
                MessageBox.Show("Server và Database không được để trống.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cfg = new DbConfig
            {
                Server = txtServer.Text.Trim(),
                Database = txtDatabase.Text.Trim(),
                UseWindowsAuth = chkWindowsAuth.Checked,
                UserId = txtUid.Text.Trim(),
                Password = txtPassword.Text
            };

            string connStr = ConfigHelper.BuildConnectionString(cfg);

            // Test kết nối
            try
            {
                using (var conn = new SqlConnection(connStr))
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối SQL thất bại:\n" + ex.Message,
                    "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lưu file + gán ConnStr dùng chung
            ConfigHelper.SaveConfig(cfg);
            Program.ConnStr = connStr;

            MessageBox.Show("Lưu cấu hình & kết nối thành công!",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
