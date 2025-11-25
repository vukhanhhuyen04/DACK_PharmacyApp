using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PharmacyApp.Forms
{
    public partial class FrmProductDeactivate : Form
    {
        private readonly int _productId;
        private readonly string _productName;
        private string ConnStr => Program.ConnStr;

        public FrmProductDeactivate(int productId, string productName)
        {
            InitializeComponent();
            _productId = productId;
            _productName = productName;

            this.Load += FrmProductDeactivate_Load;
            btnDeactivate.Click += BtnDeactivate_Click;
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;
        }

        private void FrmProductDeactivate_Load(object sender, EventArgs e)
        {
            lblProductName.Text = _productName;
        }

        private void BtnDeactivate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Xác nhận ngưng kinh doanh sản phẩm này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
                return;

            string reason = txtReason.Text.Trim();

            using (var conn = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand(@"
UPDATE Products
SET IsActive = 0,
    Description = CASE 
        WHEN @Reason = '' THEN Description
        ELSE ISNULL(Description, '') + CHAR(13)+CHAR(10) 
             + 'Ngưng KD: ' + @Reason
    END
WHERE ProductId = @Id;", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@Id", _productId);
                cmd.Parameters.AddWithValue("@Reason", reason);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Đã chuyển sản phẩm sang trạng thái NGƯNG KINH DOANH.",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
