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
using PharmacyApp.Forms;

namespace PharmacyApp.UserControls
{
    public partial class UC_Warehouse : UserControl
    {
        private bool _isEditing = false;

        public UC_Warehouse()
        {

            InitializeComponent();
            // ví dụ sau này:
            // btnAdd.Click += BtnAdd_Click;
            // btnEdit.Click += BtnEdit_Click;
            // btnDelete.Click += BtnDelete_Click;

             dgvWarehouse.AutoGenerateColumns = false; // nếu bạn bind bằng DataSource
            this.Load += UC_Warehouse_Load;
            btnTim.Click += BtnTim_Click;
            txtSearch.KeyDown += TxtSearch_KeyDown;
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
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = conn;

                // --- SQL chính ---
                string sql = @"
SELECT 
    p.ProductId,
    p.ProductCode,           -- Mã SP
    p.Barcode,               -- Barcode
    p.ProductName,           -- Tên thuốc
    p.Unit,
    p.UnitPrice,
    p.SalePrice,
    s.SupplierName,          -- Nhà cung cấp
    s.SupplierId AS SupplierCode,
    p.StockQuantity,         -- Số lượng tồn
    N'Kho chính' AS LocationName,
    p.ExpiredDate            -- Hạn dùng
FROM Products p
LEFT JOIN Suppliers s 
    ON p.SupplierId = s.SupplierId
WHERE 1 = 1";

                // --- Lọc theo từ khóa (nếu có) ---
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    sql += @"
  AND (
        p.ProductCode  LIKE @kw
        OR p.Barcode   LIKE @kw
        OR p.ProductName LIKE @kw
      )";
                    cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                }

                sql += @"
ORDER BY p.ProductName;";

                cmd.CommandText = sql;

                using (var da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvWarehouse.AutoGenerateColumns = false;
                    dgvWarehouse.DataSource = dt;
                }
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
            _isEditing = !_isEditing;

            if (_isEditing)
            {
                btnEdit.Text = "Đang sửa...";

                // Cho phép sửa, nhưng chỉ một số cột
                dgvWarehouse.ReadOnly = false;

                foreach (DataGridViewColumn col in dgvWarehouse.Columns)
                    col.ReadOnly = true;   // khoá hết

                // ✅ Các cột cho phép sửa (đặt đúng tên column trong Designer)
                if (dgvWarehouse.Columns.Contains("colTenThuoc"))
                    dgvWarehouse.Columns["colTenThuoc"].ReadOnly = false;

                if (dgvWarehouse.Columns.Contains("colDonViTinh"))
                    dgvWarehouse.Columns["colDonViTinh"].ReadOnly = false;

                if (dgvWarehouse.Columns.Contains("colGiaNhap"))
                    dgvWarehouse.Columns["colGiaNhap"].ReadOnly = false;

                if (dgvWarehouse.Columns.Contains("colGiaBan"))
                    dgvWarehouse.Columns["colGiaBan"].ReadOnly = false;

                if (dgvWarehouse.Columns.Contains("colHanDung"))
                    dgvWarehouse.Columns["colHanDung"].ReadOnly = false;

                if (dgvWarehouse.Columns.Contains("colDonViTinh"))
                    dgvWarehouse.Columns["colDonViTinh"].ReadOnly = false;

                // (Nếu muốn cho sửa Nhà cung cấp thì mở thêm colNhaCungCap, nhưng phần này hơi phức tạp vì dính 2 bảng)
                MessageBox.Show("Bạn có thể sửa trực tiếp các ô (Tên thuốc, ĐVT, Giá, HSD) trong lưới.\n" +
                                "Rời ô là hệ thống tự lưu.",
                                "Chế độ sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                btnEdit.Text = "Sửa";
                dgvWarehouse.ReadOnly = true;
            }
        }




        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvWarehouse.CurrentRow == null) return;

            int id = Convert.ToInt32(dgvWarehouse.CurrentRow.Cells["colProductId"].Value);
            int stock = Convert.ToInt32(
    dgvWarehouse.CurrentRow.Cells["colSoLuongTon"].Value);


            if (stock > 0)
            {
                if (MessageBox.Show(
                    "Sản phẩm còn tồn kho. Bạn có chắc muốn xóa?",
                    "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            }

            using (var conn = new SqlConnection(Program.ConnStr))
            using (var cmd = new SqlCommand(
                "UPDATE Products SET IsActive = 0 WHERE ProductId = @id", conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Đã ngừng kinh doanh sản phẩm.",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
            dgvWarehouse.Columns["colGiaNhap"].DefaultCellStyle.Format = "N0";
            dgvWarehouse.Columns["colGiaBan"].DefaultCellStyle.Format = "N0";

            dgvWarehouse.Columns["colGiaNhap"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            dgvWarehouse.Columns["colGiaBan"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleRight;
            // 🔒 Ban đầu chỉ xem, không sửa
            dgvWarehouse.ReadOnly = true;
            dgvWarehouse.AllowUserToAddRows = false;

        }
        public void RefreshWarehouse()
        {
            LoadStats();
            LoadWarehouse(txtSearch.Text);
        }

        private void dgvWarehouse_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!_isEditing) return;
            if (e.RowIndex < 0) return;

            var row = dgvWarehouse.Rows[e.RowIndex];
            int productId = Convert.ToInt32(row.Cells["colProductId"].Value);

            string colName = dgvWarehouse.Columns[e.ColumnIndex].Name;
            object newValue = row.Cells[e.ColumnIndex].Value ?? DBNull.Value;

            string sql = null;

            switch (colName)
            {
                case "colTenThuoc":
                    sql = "UPDATE Products SET ProductName = @val WHERE ProductId = @id";
                    break;

                case "colDonViTinh":       // ⭐ ĐƠN VỊ TÍNH 
                    sql = "UPDATE Products SET Unit = @val WHERE ProductId = @id";
                    break;

                case "colGiaNhap":
                    sql = "UPDATE Products SET UnitPrice = @val WHERE ProductId = @id";
                    if (!decimal.TryParse(Convert.ToString(newValue), out decimal giaNhap))
                    {
                        MessageBox.Show("Giá nhập không hợp lệ.");
                        LoadWarehouse(txtSearch.Text);
                        return;
                    }
                    newValue = giaNhap;
                    break;

                case "colGiaBan":
                    sql = "UPDATE Products SET SalePrice = @val WHERE ProductId = @id";
                    if (!decimal.TryParse(Convert.ToString(newValue), out decimal giaBan))
                    {
                        MessageBox.Show("Giá bán không hợp lệ.");
                        LoadWarehouse(txtSearch.Text);
                        return;
                    }
                    newValue = giaBan;
                    break;

                case "colHanDung":
                    sql = "UPDATE Products SET ExpiredDate = @val WHERE ProductId = @id";
                    if (DateTime.TryParse(newValue?.ToString(), out DateTime d))
                        newValue = d.Date;
                    else
                        newValue = DBNull.Value;
                    break;

                default:
                    return;
            }

            try
            {
                using (var conn = new SqlConnection(Program.ConnStr))
                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", productId);
                    cmd.Parameters.AddWithValue("@val", newValue);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu: " + ex.Message);
                LoadWarehouse(txtSearch.Text);
            }
        }
        private void BtnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            // Nếu ô tìm kiếm trống → load lại toàn bộ kho
            if (string.IsNullOrEmpty(keyword))
            {
                LoadWarehouse();          // không truyền keyword → lấy toàn bộ
            }
            else
            {
                LoadWarehouse(keyword);   // lọc theo mã, barcode, tên thuốc
            }
        }
        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;    // chặn tiếng “bíp”/xuống dòng
                BtnTim_Click(sender, e);      // gọi lại nút Tìm
            }
        }


    }
}
