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
    public partial class UC_ProductCard : UserControl
    {
        public UC_ProductCard()
        {
            InitializeComponent();

            // Cho click vào đâu trên card cũng coi như click card
            guna2ShadowPanel1.Click += Card_Click;
            guna2PictureBox1.Click += Card_Click;
            ProductName.Click += Card_Click;
            label2.Click += Card_Click;
            label3.Click += Card_Click;

            guna2Button1.Click += BtnEdit_Click;   // nút ✎
            guna2Button2.Click += BtnDelete_Click; // nút 🗑
        }

        // ========================
        //       PROPERTIES
        // ========================

        public int ProductId { get; set; }

        // Text hiển thị tên thuốc trên label ProductName
        public string ProductNameText
        {
            get => ProductName.Text;
            set => ProductName.Text = value;
        }

        // Công ty sản xuất (label2)
        public string CompanyName
        {
            get => label2.Text;
            set => label2.Text = value;
        }

        private decimal _price;
        public decimal Price
        {
            get => _price;
            set
            {
                _price = value;
                label3.Text = string.Format("{0:N0}đ", value);
            }
        }

        public Image ProductImage
        {
            get => guna2PictureBox1.Image;
            set => guna2PictureBox1.Image = value;
        }

        // ========================
        //          EVENTS
        // ========================

        // Click cả card (xem chi tiết / chọn thuốc)
        public event EventHandler CardClicked;

        // Nhấn nút sửa
        public event EventHandler EditClicked;

        // Nhấn nút xóa
        public event EventHandler DeleteClicked;

        private void Card_Click(object sender, EventArgs e)
        {
            CardClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            EditClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteClicked?.Invoke(this, EventArgs.Empty);
        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}