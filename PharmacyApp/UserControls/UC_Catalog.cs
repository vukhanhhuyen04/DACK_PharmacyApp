using PharmacyApp.Forms;
using PharmacyApp.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace PharmacyApp.UserControls
{
    public partial class UC_Catalog : UserControl
    {
        public UC_Catalog()
        {
            InitializeComponent();
            this.Load += UC_Catalog_Load;
        }
        private void UC_Catalog_Load(object sender, EventArgs e)
        {
            // tạm thời: load dữ liệu demo để test UI
            LoadDummyProducts();
        }
        private void LoadDummyProducts()
        {
            flpProducts.Controls.Clear();   // flpProducts chính là flowLayoutPanel2 bạn vừa rename

            for (int i = 1; i <= 12; i++)
            {
                var card = new UC_ProductCard();

                card.ProductId = i;
                card.ProductNameText = "Paracetamol " + i;
                card.CompanyName = "Công ty Dược ABC";
                card.Price = 120000 + i * 1000;
                // nếu có ảnh default thì gán, chưa có thì bỏ dòng này
                // card.ProductImage = Properties.Resources.no_image;

                // ví dụ bắt sự kiện click card
                card.CardClicked += (s, e) =>
                {
                    MessageBox.Show("Bạn chọn: " + card.ProductNameText);
                };

                flpProducts.Controls.Add(card);
            }
        }
    

private void dgvMedicine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // mở form thêm sản phẩm
            using (var frm = new FrmProductAdd())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Nếu thêm thành công thì load lại danh sách sản phẩm
                    LoadDummyProducts();
                    // sau này bạn đổi lại thành LoadProductsFromDatabase();
                }
            }
        }
    }
}
