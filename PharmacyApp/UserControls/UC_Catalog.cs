using Guna.UI2.WinForms;
using PharmacyApp.Forms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PharmacyApp.UserControls
{
    public partial class UC_Catalog : UserControl
    {
        private string ConnStr => Program.ConnStr;

        // danh mục đang chọn (null = tất cả)
        private int? _selectedCategoryId = null;

        public UC_Catalog()
        {
            InitializeComponent();
            this.Load += UC_Catalog_Load;
        }

        private void UC_Catalog_Load(object sender, EventArgs e)
        {
            WireCategoryButtons();

            btnFind.Click += BtnFind_Click;
            btnRefresh.Click += BtnRefresh_Click;
            txtSearch.KeyDown += TxtSearch_KeyDown;
            chkShowInactive.CheckedChanged += ChkShowInactive_CheckedChanged;
            // load tất cả sản phẩm lần đầu
            LoadProducts(null, null);

          //  btnAdd.Click += btnAdd_Click;
        }

        // ============= DANH MỤC (HÀNG NÚT GUNA2) =============

        private void WireCategoryButtons()
        {
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c is Guna2Button btn && !btn.Text.StartsWith("+"))
                {
                    btn.Click += CategoryButton_Click;
                }
            }
        }

        private void CategoryButton_Click(object sender, EventArgs e)
        {
            var clicked = sender as Guna2Button;
            if (clicked == null) return;

            string catName = clicked.Text.Trim();

            HighlightSelectedCategory(clicked);

            // tìm CategoryId trong bảng Categories
            _selectedCategoryId = GetCategoryIdByName(catName);

            string keyword = string.IsNullOrWhiteSpace(txtSearch.Text)
                                ? null
                                : txtSearch.Text.Trim();

            LoadProducts(_selectedCategoryId, keyword);
        }

        private void HighlightSelectedCategory(Guna2Button selected)
        {
            Color activeColor = Color.FromArgb(0, 150, 136);
            Color normalColor = Color.Teal;

            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c is Guna2Button btn && !btn.Text.StartsWith("+"))
                {
                    btn.FillColor = (btn == selected) ? activeColor : normalColor;
                }
            }
        }

        private int? GetCategoryIdByName(string categoryName)
        {
            using (var conn = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand(
                "SELECT TOP 1 CategoryId FROM Categories WHERE CategoryName = @Name", conn))
            {
                cmd.Parameters.AddWithValue("@Name", categoryName);
                conn.Open();
                var result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                    return null;
                return Convert.ToInt32(result);
            }
        }

        // ============= TÌM KIẾM / LÀM MỚI =============

        private void BtnFind_Click(object sender, EventArgs e)
        {
            string keyword = string.IsNullOrWhiteSpace(txtSearch.Text)
                                ? null
                                : txtSearch.Text.Trim();

            LoadProducts(_selectedCategoryId, keyword);
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnFind_Click(sender, EventArgs.Empty);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            _selectedCategoryId = null;

            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c is Guna2Button btn && !btn.Text.StartsWith("+"))
                {
                    btn.FillColor = Color.Teal;
                }
            }

            LoadProducts(null, null);
        }

        // ============= LOAD PRODUCT TỪ DB (JOIN ProductCategories) =============

        private void LoadProducts(int? categoryId, string keyword)
        {
            flpProducts.Controls.Clear();

            using (var conn = new SqlConnection(ConnStr))
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                // ⬇️ Base query: chưa lọc IsActive
                cmd.CommandText = @"
SELECT DISTINCT
    P.ProductId,
    P.ProductName,
    P.Manufacturer,
    P.SalePrice,
    P.ImagePath
FROM Products P
LEFT JOIN ProductCategories PC ON P.ProductId = PC.ProductId
LEFT JOIN Categories C ON C.CategoryId = PC.CategoryId
WHERE 1 = 1";   // dùng 1=1 để nối điều kiện dễ hơn

                // 🆕 Lọc theo checkbox
                if (chkShowInactive.Checked)
                {
                    // Hiện sản phẩm NGƯNG kinh doanh
                    cmd.CommandText += " AND P.IsActive = 0";
                }
                else
                {
                    // Mặc định: chỉ hiện sản phẩm đang kinh doanh
                    cmd.CommandText += " AND P.IsActive = 1";
                }

                // Lọc theo danh mục
                if (categoryId.HasValue)
                {
                    cmd.CommandText += " AND PC.CategoryId = @CategoryId";
                    cmd.Parameters.AddWithValue("@CategoryId", categoryId.Value);
                }

                // Lọc theo keyword
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    cmd.CommandText += " AND P.ProductName LIKE @Keyword";
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                }

                cmd.CommandText += " ORDER BY P.ProductName";

                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        int id = (int)rd["ProductId"];
                        string name = rd["ProductName"].ToString();
                        string company = rd["Manufacturer"].ToString();

                        decimal price = rd["SalePrice"] == DBNull.Value
                                        ? 0
                                        : (decimal)rd["SalePrice"];

                        Image img = null;
                        if (rd["ImagePath"] != DBNull.Value)
                        {
                            string path = rd["ImagePath"].ToString();
                            if (!string.IsNullOrWhiteSpace(path) && File.Exists(path))
                            {
                                try { img = Image.FromFile(path); } catch { }
                            }
                        }

                        var card = new UC_ProductCard();
                        card.ProductId = id;
                        card.ProductNameText = name;
                        card.CompanyName = company;
                        card.Price = price;
                        if (img != null)
                            card.ProductImage = img;

                        // Edit
                        card.EditClicked += (s, e) =>
                        {
                            using (var frm = new FrmProductDetail(id))
                            {
                                if (frm.ShowDialog() == DialogResult.OK)
                                {
                                    string kw = string.IsNullOrWhiteSpace(txtSearch.Text)
                                                    ? null
                                                    : txtSearch.Text.Trim();
                                    LoadProducts(_selectedCategoryId, kw);
                                }
                            }
                        };

                        // Delete = Ngưng kinh doanh (nếu bạn đã đổi)
                        card.DeleteClicked += (s, e) =>
                        {
                            using (var frm = new FrmProductDeactivate(id, name))
                            {
                                if (frm.ShowDialog() == DialogResult.OK)
                                {
                                    string kw = string.IsNullOrWhiteSpace(txtSearch.Text)
                                                    ? null
                                                    : txtSearch.Text.Trim();
                                    LoadProducts(_selectedCategoryId, kw);
                                }
                            }
                        };

                        // Click card = xem chi tiết
                        card.CardClicked += (s, e) =>
                        {
                            using (var frm = new FrmProductDetail(id))
                            {
                                if (frm.ShowDialog() == DialogResult.OK)
                                {
                                    string kw = string.IsNullOrWhiteSpace(txtSearch.Text)
                                                    ? null
                                                    : txtSearch.Text.Trim();
                                    LoadProducts(_selectedCategoryId, kw);
                                }
                            }
                        };

                        flpProducts.Controls.Add(card);
                    }
                }
            }
        }


        // ============= NÚT THÊM THUỐC =============

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmProductAdd())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string keyword = string.IsNullOrWhiteSpace(txtSearch.Text)
                                        ? null
                                        : txtSearch.Text.Trim();
                    LoadProducts(_selectedCategoryId, keyword);
                }
            }
        }

        // các event trống cũ, cứ để đó cho Designer
        private void dgvMedicine_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void guna2Button7_Click(object sender, EventArgs e) { }
        private void guna2Button2_Click(object sender, EventArgs e) { }
        private void guna2Button5_Click(object sender, EventArgs e) { }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {

        }

        private void ChkShowInactive_CheckedChanged(object sender, EventArgs e)
        {
            string keyword = string.IsNullOrWhiteSpace(txtSearch.Text)
                                ? null
                                : txtSearch.Text.Trim();

            LoadProducts(_selectedCategoryId, keyword);
        }

        private void f(object sender, EventArgs e)
        {

        }

        private void FlowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            // Lấy các button đang hiển thị
            var buttons = flowLayoutPanel1.Controls
                                          .OfType<Control>()
                                          .Where(c => c.Visible)
                                          .ToList();

            if (buttons.Count == 0) return;

            int totalWidth = flowLayoutPanel1.ClientSize.Width
                             - flowLayoutPanel1.Padding.Left
                             - flowLayoutPanel1.Padding.Right;

            int spacing = 10; // khoảng cách giữa các nút
            int buttonWidth = (totalWidth - spacing * (buttons.Count - 1)) / buttons.Count;

            foreach (var btn in buttons)
            {
                btn.Width = buttonWidth;
                btn.Margin = new Padding(0, 10, spacing, 10); // top/bottom 10, right = spacing
            }

            // Nút cuối cùng không cần margin phải
            if (buttons.Count > 0)
            {
                var last = buttons[buttons.Count - 1];
                last.Margin = new Padding(0, 10, 0, 10);
            }
        }

    }
}
