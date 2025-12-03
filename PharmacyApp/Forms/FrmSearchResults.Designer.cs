using System.Drawing;
using System.Windows.Forms;

namespace PharmacyApp.Forms
{
    partial class FrmSearchResults
    {
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flowResults;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.flowResults = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowResults
            // 
            this.flowResults.AutoScroll = true;
            this.flowResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowResults.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowResults.WrapContents = false;
            this.flowResults.BackColor = Color.White;
            // 
            // FrmSearchResults
            // 
            this.ClientSize = new System.Drawing.Size(520, 600);
            this.Controls.Add(this.flowResults);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kết quả tìm kiếm";
            this.ResumeLayout(false);
        }
    }
}
