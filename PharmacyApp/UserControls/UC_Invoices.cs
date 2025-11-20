using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PharmacyApp.UserControls
{
    public partial class UC_Invoices : UserControl
    {
        public UC_Invoices()
        {
            InitializeComponent();
            dgvInvoices.SelectionChanged += dgvInvoices_SelectionChanged;


        }

        private void UC_Invoices_Load(object sender, EventArgs e)
        {
            // Mặc định lọc theo ngày hôm nay (hoặc bỏ tham số để lấy tất cả)
            dtpFrom.Value = DateTime.Today;
            dtpTo.Value = DateTime.Today;
            LoadInvoices(dtpFrom.Value.Date, dtpTo.Value.Date, null);

            // sự kiện nếu chưa gán trong Designer
            btnFilter.Click += btnFilter_Click;
            txtSearch.KeyDown += txtSearch_KeyDown;
        }


        private void LoadInvoices(DateTime? fromDate = null, DateTime? toDate = null, string keyword = null)
        {
            using (var conn = new SqlConnection(Program.ConnStr))
            {
                conn.Open();

                string sql = @"
            SELECT InvoiceId,
                   CreatedAt,
                   CustomerName,
                   TotalAmount,
                   PaymentMethod,
                   Status
            FROM Invoices
            WHERE 1 = 1";   // để dễ cộng thêm điều kiện

                var cmd = new SqlCommand();
                cmd.Connection = conn;

                // Lọc theo khoảng ngày
                if (fromDate.HasValue)
                {
                    sql += " AND CreatedAt >= @FromDate";
                    cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = fromDate.Value.Date;
                }

                if (toDate.HasValue)
                {
                    // < ngày+1 để bao trọn cả ngày toDate
                    sql += " AND CreatedAt < @ToDate";
                    cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = toDate.Value.Date.AddDays(1);
                }

                // Lọc theo mã HĐ hoặc tên khách
                if (!string.IsNullOrWhiteSpace(keyword))
                {
                    sql += @"
                AND (
                        CAST(InvoiceId AS NVARCHAR(50)) LIKE @kw
                     OR CustomerName LIKE N'%' + @kw + N'%'
                    )";
                    cmd.Parameters.Add("@kw", SqlDbType.NVarChar, 50).Value = "%" + keyword.Trim() + "%";
                }

                sql += " ORDER BY CreatedAt DESC";
                cmd.CommandText = sql;

                var dt = new DataTable();
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }

                dgvInvoices.DataSource = dt;
            }
        }


        private void dgvInvoices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInvoices.CurrentRow == null) return;

            // ✅ Lấy dữ liệu trực tiếp từ DataRowView, KHÔNG phụ thuộc tên cột trên grid
            var rowView = dgvInvoices.CurrentRow.DataBoundItem as DataRowView;
            if (rowView == null) return;

            int invoiceId = Convert.ToInt32(rowView["InvoiceId"]);
            LoadInvoiceDetails(invoiceId);
        }

        private void LoadInvoiceDetails(int invoiceId)
        {
            using (var conn = new SqlConnection(Program.ConnStr))
            using (var da = new SqlDataAdapter(@"
        SELECT 
            P.ProductCode AS ProductCode,
            P.ProductName AS ProductName,
            D.Quantity    AS Quantity,
            D.UnitPrice   AS UnitPrice,
            D.LineTotal   AS LineTotal
        FROM InvoiceDetails D
        JOIN Products P ON P.ProductId = D.ProductId
        WHERE D.InvoiceId = @InvoiceId", conn))
            {
                da.SelectCommand.Parameters.AddWithValue("@InvoiceId", invoiceId);

                var dt = new DataTable();
                da.Fill(dt);

                // ✅ Cho grid tự sinh cột theo DataTable
                dgvDetails.AutoGenerateColumns = true;
                dgvDetails.DataSource = dt;

                // Đổi tên cột hiển thị (nếu cột tồn tại)
                if (dgvDetails.Columns["ProductCode"] != null)
                    dgvDetails.Columns["ProductCode"].HeaderText = "Mã thuốc";

                if (dgvDetails.Columns["ProductName"] != null)
                    dgvDetails.Columns["ProductName"].HeaderText = "Tên thuốc";

                if (dgvDetails.Columns["Quantity"] != null)
                    dgvDetails.Columns["Quantity"].HeaderText = "SL";

                if (dgvDetails.Columns["UnitPrice"] != null)
                    dgvDetails.Columns["UnitPrice"].HeaderText = "Đơn giá";

                if (dgvDetails.Columns["LineTotal"] != null)
                    dgvDetails.Columns["LineTotal"].HeaderText = "Thành tiền";
            }
        }



        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pnlFilter_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (dtpTo.Value.Date < dtpFrom.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date;
            string kw = txtSearch.Text.Trim();

            LoadInvoices(from, to, kw);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFilter_Click(sender, EventArgs.Empty); // nhấn Enter để lọc
                e.Handled = true;
            }
        }

        private void dgvDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlDetails_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnMarkPaid_Click(object sender, EventArgs e)
        {
            if (dgvInvoices.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy dòng dữ liệu gốc (DataRowView) đang bind với dòng hiện tại
            var rowView = dgvInvoices.CurrentRow.DataBoundItem as DataRowView;
            if (rowView == null) return;

            int invoiceId = Convert.ToInt32(rowView["InvoiceId"]);
            string status = rowView["Status"]?.ToString() ?? "";

            if (status == "Paid")
            {
                MessageBox.Show("Hóa đơn này đã ở trạng thái 'Paid'.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (status == "Canceled")
            {
                MessageBox.Show("Hóa đơn đã bị hủy, không thể chuyển sang 'Paid'.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                "Xác nhận đã nhận đủ tiền và chuyển hóa đơn sang trạng thái 'Paid'?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            // Cập nhật DB
            using (var conn = new SqlConnection(Program.ConnStr))
            using (var cmd = new SqlCommand(@"
        UPDATE Invoices
        SET Status = 'Paid'
        WHERE InvoiceId = @Id;", conn))
            {
                cmd.Parameters.AddWithValue("@Id", invoiceId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            // Cập nhật lại DataGridView hiện tại (khỏi load lại toàn bộ)
            rowView["Status"] = "Paid";
            rowView.EndEdit();
            dgvInvoices.Refresh();

            MessageBox.Show("Đã cập nhật hóa đơn sang trạng thái 'Paid'.",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancelInvoice_Click(object sender, EventArgs e)
        {
            if (dgvInvoices.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một hóa đơn.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var rowView = dgvInvoices.CurrentRow.DataBoundItem as DataRowView;
            if (rowView == null) return;

            int invoiceId = Convert.ToInt32(rowView["InvoiceId"]);
            string status = rowView["Status"]?.ToString() ?? "";

            if (status == "Canceled")
            {
                MessageBox.Show("Hóa đơn này đã bị hủy trước đó.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Tuỳ bạn: cho phép hủy cả Pending & Paid hay chỉ Pending
            if (status == "Paid")
            {
                var warn = MessageBox.Show(
                    "Hóa đơn đang ở trạng thái 'Paid'. Bạn có chắc muốn hủy và trả lại tồn kho?",
                    "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (warn != DialogResult.Yes) return;
            }
            else
            {
                var confirm = MessageBox.Show(
                    "Hủy hóa đơn này và trả lại tồn kho?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;
            }

            using (var conn = new SqlConnection(Program.ConnStr))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Trả lại tồn kho cho tất cả sản phẩm trong hóa đơn
                        using (var cmdStock = new SqlCommand(@"
UPDATE P
SET P.StockQuantity = P.StockQuantity + D.Quantity
FROM Products P
JOIN InvoiceDetails D ON P.ProductId = D.ProductId
WHERE D.InvoiceId = @Id;", conn, tran))
                        {
                            cmdStock.Parameters.AddWithValue("@Id", invoiceId);
                            cmdStock.ExecuteNonQuery();
                        }

                        // 2. Đánh dấu hóa đơn là Canceled
                        using (var cmdInv = new SqlCommand(@"
UPDATE Invoices
SET Status = 'Canceled'
WHERE InvoiceId = @Id;", conn, tran))
                        {
                            cmdInv.Parameters.AddWithValue("@Id", invoiceId);
                            cmdInv.ExecuteNonQuery();
                        }

                        tran.Commit();
                    }
                    catch
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }

            // Cập nhật lại trên grid
            rowView["Status"] = "Canceled";
            rowView.EndEdit();
            dgvInvoices.Refresh();

            MessageBox.Show("Đã hủy hóa đơn và trả lại tồn kho.",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
