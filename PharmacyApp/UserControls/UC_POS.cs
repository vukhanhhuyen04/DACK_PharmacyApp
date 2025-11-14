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
    public partial class UC_POS : UserControl
    {
        public UC_POS()
        {
            InitializeComponent();
            cboPaymentMethod.Items.Clear();
            cboPaymentMethod.Items.Add("Tiền mặt");
            cboPaymentMethod.Items.Add("Ngân hàng (QR)");
            cboPaymentMethod.SelectedIndex = 0;   // mặc định tiền mặt

        }
        private decimal _totalAmount = 0m;

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }
        private void AddToCart(string ma, string ten, int soLuong, decimal donGia)
        {
            // Đã có trong giỏ => tăng SL
            foreach (ListViewItem item in lvCart.Items)
            {
                if (item.SubItems[0].Text == ma)
                {
                    int slCu = int.Parse(item.SubItems[2].Text);
                    int slMoi = slCu + soLuong;
                    item.SubItems[2].Text = slMoi.ToString();

                    decimal thanhTien = slMoi * donGia;
                    item.SubItems[4].Text = thanhTien.ToString("N0");
                    RecalculateTotal();
                    return;
                }
            }

            // Chưa có => thêm mới
            decimal tt = soLuong * donGia;
            var lvi = new ListViewItem(new[]
            {
        ma,
        ten,
        soLuong.ToString(),
        donGia.ToString("N0"),
        tt.ToString("N0")
    });

            lvCart.Items.Add(lvi);
            RecalculateTotal();
        }
        private void gvProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = gvProducts.Rows[e.RowIndex];

            string ma = row.Cells["colMaThuoc"].Value.ToString();
            string ten = row.Cells["colTenThuoc"].Value.ToString();
            decimal gia = Convert.ToDecimal(row.Cells["colGiaBan"].Value);
            // mặc định thêm 1
            AddToCart(ma, ten, 1, gia);
        }
        private void RecalculateTotal()
        {
            decimal sum = 0m;

            foreach (ListViewItem item in lvCart.Items)
            {
                // cột Thành tiền là subitem[4]
                if (decimal.TryParse(item.SubItems[4].Text,
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.CurrentCulture,
                    out decimal lineTotal))
                {
                    sum += lineTotal;
                }
            }

            _totalAmount = sum;
            txtTotal.Text = _totalAmount.ToString("N0");

            // tính lại tiền thối nếu đang nhập tiền mặt
            RecalculateChange();
        }
        private void cboPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPaymentMethod.SelectedItem.ToString().StartsWith("Tiền mặt"))
            {
                pCash.Visible = true;
                pBank.Visible = false;
            }
            else
            {
                pCash.Visible = false;
                pBank.Visible = true;

                // Nếu có file QR sẵn thì load:
                // pbQr.Image = Image.FromFile("qr_bank.png");
            }
        }
        private void txtCashGiven_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép: số, backspace, phím điều hướng
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // chặn ký tự khác số
            }
        }
        private void txtCashGiven_TextChanged(object sender, EventArgs e)
        {
            RecalculateChange();
        }

        private void RecalculateChange()
        {
            if (!pCash.Visible) return; // chỉ áp dụng cho tiền mặt

            if (string.IsNullOrWhiteSpace(txtCashGiven.Text))
            {
                txtChange.Text = "0";
                return;
            }

            if (!decimal.TryParse(txtCashGiven.Text, out decimal cash))
            {
                txtChange.Text = "0";
                return;
            }

            if (cash < 0)
            {
                MessageBox.Show("Tiền khách đưa không được âm.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCashGiven.Text = "";
                return;
            }

            if (cash < _totalAmount)
            {
                // chưa đủ tiền => thối = 0 (hoặc cho cảnh báo khi bấm Thanh toán)
                txtChange.Text = "0";
            }
            else
            {
                decimal change = cash - _totalAmount;
                txtChange.Text = change.ToString("N0");
            }
        }
        private void btnPay_Click(object sender, EventArgs e)
        {
            if (lvCart.Items.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm trong giỏ hàng.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Kiểm tra theo phương thức thanh toán
            if (cboPaymentMethod.SelectedItem.ToString().StartsWith("Tiền mặt"))
            {
                if (!decimal.TryParse(txtCashGiven.Text, out decimal cash))
                {
                    MessageBox.Show("Vui lòng nhập tiền khách đưa.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cash < _totalAmount)
                {
                    MessageBox.Show("Tiền khách đưa không được nhỏ hơn tổng hóa đơn.", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                // Ngân hàng: bạn có thể hiển thị form xác nhận
                var result = MessageBox.Show("Xác nhận đã nhận tiền qua ngân hàng?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes) return;
            }

            // TODO: Lưu hoá đơn vào DB, trừ kho tại đây...

            // In hoá đơn ra PDF
            PrintBillToPdf();

            MessageBox.Show("Thanh toán thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reset form
            lvCart.Items.Clear();
            RecalculateTotal();
            txtCashGiven.Text = "";
            txtChange.Text = "0";
        }
        private void PrintBillToPdf()
        {
            // Gợi ý cấu trúc:
            // 1. Show SaveFileDialog cho user chọn vị trí lưu (HoaDon_yyyyMMddHHmm.pdf)
            // 2. Dùng thư viện PDF (ví dụ iTextSharp hoặc QuestPDF) để:
            //    - In tên nhà thuốc, địa chỉ
            //    - Thời gian, nhân viên, phương thức thanh toán
            //    - Duyệt lvCart.Items để in từng dòng:
            //        Mã, Tên thuốc, SL, Đơn giá, Thành tiền
            //    - In Tổng tiền, Tiền khách đưa, Tiền thối
            //
            // Khi bạn quyết định dùng thư viện nào (iTextSharp hay QuestPDF)
            // bảo mình, mình viết luôn code cụ thể cho thư viện đó.
        }

        private void lblPaymentMethod_Click(object sender, EventArgs e)
        {

        }

        private void pLeft_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPay_Click_1(object sender, EventArgs e)
        {

        }

        private void lblCart_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
