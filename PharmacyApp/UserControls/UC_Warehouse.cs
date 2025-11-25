using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacyApp.UserControls
{
    public partial class UC_Warehouse : UserControl
    {

        public UC_Warehouse()
        {
            InitializeComponent();
            // ví dụ sau này:
            // btnAdd.Click += BtnAdd_Click;
            // btnEdit.Click += BtnEdit_Click;
            // btnDelete.Click += BtnDelete_Click;

             dgvWarehouse.AutoGenerateColumns = false; // nếu bạn bind bằng DataSource
            this.Load += UC_Warehouse_Load;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var frm = new Form();
            frm.Text = "Nhập kho";
            frm.Size = new Size(950, 700);

            var uc = new UC_Receipt();
            uc.Dock = DockStyle.Fill;

            frm.Controls.Add(uc);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadStats();
                LoadWarehouse();
            }
        }


        private void cboLocation_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadWarehouse(string keyword = null)
        {
            using (var conn = new SqlConnection(Program.ConnStr))
            using (var da = new SqlDataAdapter(@"
        SELECT 
            p.ProductCode,                        -- Mã SP
            p.Barcode,                            -- Barcode
            p.ProductName,                        -- Tên thuốc
            s.SupplierName,                       -- Nhà cung cấp
            s.SupplierId AS SupplierCode,         -- Mã NCC (nếu cần)
            p.StockQuantity,                      -- Số lượng tồn
            N'Kho chính' AS LocationName,         -- Vị trí (kho chính)
            p.ExpiredDate                         -- Hạn dùng
        FROM Products p
        LEFT JOIN Suppliers s 
            ON p.SupplierId = s.SupplierId
WHERE p.IsActive = 1  
        ORDER BY p.ProductName", conn))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvWarehouse.AutoGenerateColumns = false;     // RẤT QUAN TRỌNG
                dgvWarehouse.DataSource = dt;
            }
        }
        private void LoadStats()
        {
            using (var conn = new SqlConnection(Program.ConnStr))
            using (var cmd = new SqlCommand(@"
SELECT 
    TotalProducts = COUNT(*),
    LowStock = SUM(CASE WHEN StockQuantity <= 10 THEN 1 ELSE 0 END),
    Expired = SUM(CASE WHEN ExpiredDate IS NOT NULL 
                        AND ExpiredDate < CAST(GETDATE() AS DATE) 
                       THEN 1 ELSE 0 END)
FROM Products", conn))
            {
                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        lblTotalProducts.Text = rd["TotalProducts"].ToString();
                        lblLowStock.Text = rd["LowStock"].ToString();
                        lblExpired.Text = rd["Expired"].ToString();
                    }
                }
            }
        }
        private void dgvWarehouse_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dgvWarehouse.Rows[e.RowIndex];
            if (row.DataBoundItem is DataRowView drv)
            {
                int stock = Convert.ToInt32(drv["StockQuantity"]);
                DateTime? exp = drv["ExpiredDate"] as DateTime?;

                if (exp.HasValue && exp.Value < DateTime.Today)
                {
                    row.DefaultCellStyle.BackColor = Color.LightSalmon;  // hết hạn
                }
                else if (stock <= 10)
                {
                    row.DefaultCellStyle.BackColor = Color.Khaki; // sắp hết hàng
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvWarehouse.CurrentRow == null) return;

            int productId = Convert.ToInt32(
                dgvWarehouse.CurrentRow.Cells["colProductId"].Value);

            using (var f = new Form())
            {
                f.StartPosition = FormStartPosition.CenterParent;
                f.Text = "Sửa thông tin sản phẩm";
                f.Size = new Size(600, 500);
                f.MinimizeBox = false;
                f.MaximizeBox = false;

                var uc = new UC_Receipt();
                uc.Dock = DockStyle.Fill;
                uc.EditingProductId = productId;   // 🔹 gán ID, KHÔNG gọi LoadProduct

                f.Controls.Add(uc);

                if (f.ShowDialog() == DialogResult.OK)
                {
                    LoadStats();
                    LoadWarehouse(txtSearch.Text);
                }
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvWarehouse.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvWarehouse.CurrentRow.Cells["colProductId"].Value);
            int stock = Convert.ToInt32(dgvWarehouse.CurrentRow.Cells["colStockQuantity"].Value);

            if (stock > 0)
            {
                if (MessageBox.Show(
                    "Sản phẩm còn tồn kho. Bạn có chắc muốn xóa?",
                    "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }

            using (var conn = new SqlConnection(Program.ConnStr))
            using (var cmd = new SqlCommand("DELETE FROM Products WHERE ProductId=@id", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            LoadStats();
            LoadWarehouse();
        }

        private void btnAddReceipt_Click(object sender, EventArgs e)
        {
            using (var f = new Form())
            {
                f.StartPosition = FormStartPosition.CenterParent;
                f.Text = "Phiếu nhập kho";
                f.Size = new Size(1000, 700);
                f.MinimizeBox = false;
                f.MaximizeBox = false;

                var uc = new UC_Receipt();
                uc.Dock = DockStyle.Fill;
                f.Controls.Add(uc);

                if (f.ShowDialog() == DialogResult.OK)
                {
                    // Sau khi lưu phiếu nhập xong → reload kho
                    LoadStats();
                    LoadWarehouse(txtSearch.Text);
                }
            }
        }

        private void UC_Warehouse_Load(object sender, EventArgs e)
        {
            LoadStats();
            LoadWarehouse();          // 🔴 Lần đầu mở Kho là có dữ liệu luôn
        }
        public void RefreshWarehouse()
        {
            LoadStats();
            LoadWarehouse(txtSearch.Text);
        }

    }
}
