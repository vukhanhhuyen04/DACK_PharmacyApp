using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PharmacyApp.Forms
{
    public partial class FrmSearchResults : Form
    {
        private bool _isAdmin;

        public FrmSearchResults()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        /// <summary>
        /// products: bảng sản phẩm
        /// invoices: bảng hóa đơn
        /// staff   : bảng nhân viên (null nếu dược sĩ)
        /// isAdmin : true = Admin, false = Dược sĩ
        /// </summary>
        public void LoadResults(DataTable products, DataTable invoices, DataTable staff, bool isAdmin)
        {
            _isAdmin = isAdmin;
            flowResults.Controls.Clear();

            // ===== Sản phẩm =====
            if (products != null && products.Rows.Count > 0)
            {
                AddHeader("Sản phẩm");

                foreach (DataRow row in products.Rows)
                {
                    string id = row["ProductId"].ToString();
                    string name = row["ProductName"].ToString();
                    string code = row["ProductCode"]?.ToString();

                    var item = CreateItem(
                        "💊",
                        name,
                        $"Mã: {code} - ID: {id}",
                        () =>
                        {
                            if (Owner is FrmAdminDashboard parent)
                                parent.SearchOpenProduct(id);
                            Close();
                        });

                    flowResults.Controls.Add(item);
                }
            }

            // ===== Hóa đơn =====
            if (invoices != null && invoices.Rows.Count > 0)
            {
                AddHeader("Hóa đơn");

                foreach (DataRow row in invoices.Rows)
                {
                    string id = row["InvoiceId"].ToString();
                    DateTime created = Convert.ToDateTime(row["CreatedAt"]);
                    string customer = row["CustomerName"]?.ToString();

                    var item = CreateItem(
                        "🧾",
                        $"Hóa đơn #{id}",
                        $"{created:dd/MM/yyyy HH:mm} - KH: {customer}",
                        () =>
                        {
                            if (Owner is FrmAdminDashboard parent)
                                parent.SearchOpenInvoice(id);
                            Close();
                        });

                    flowResults.Controls.Add(item);
                }
            }

            // ===== Nhân viên (chỉ Admin) =====
            if (isAdmin && staff != null && staff.Rows.Count > 0)
            {
                AddHeader("Nhân viên / Dược sĩ");

                foreach (DataRow row in staff.Rows)
                {
                    string id = row["StaffId"].ToString();
                    string name = row["FullName"].ToString();
                    string code = row["StaffCode"]?.ToString();

                    var item = CreateItem(
                        "👨‍⚕️",
                        name,
                        $"Mã NV: {code} - ID: {id}",
                        () =>
                        {
                            if (Owner is FrmAdminDashboard parent)
                                parent.SearchOpenStaff(id);
                            Close();
                        });

                    flowResults.Controls.Add(item);
                }
            }

            if (flowResults.Controls.Count == 0)
            {
                AddHeader("Không tìm thấy kết quả phù hợp.");
            }
        }

        // ===== UI helper =====

        private void AddHeader(string text)
        {
            var lbl = new Label
            {
                Text = text,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.DimGray,
                AutoSize = true,
                Margin = new Padding(10, 10, 10, 5)
            };
            flowResults.Controls.Add(lbl);
        }

        private Panel CreateItem(string icon, string title, string subtitle, Action onClick)
        {
            var p = new Panel
            {
                Height = 60,
                Dock = DockStyle.Top,
                BackColor = Color.White,
                Margin = new Padding(10),
                Cursor = Cursors.Hand
            };
            p.Click += (s, e) => onClick();

            var lblIcon = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI Emoji", 24),
                Dock = DockStyle.Left,
                Width = 50,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                AutoSize = true,
                Dock = DockStyle.Top
            };

            var lblSub = new Label
            {
                Text = subtitle,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                AutoSize = true,
                Dock = DockStyle.Top
            };

            var textPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 8, 0, 0)
            };
            textPanel.Controls.Add(lblSub);
            textPanel.Controls.Add(lblTitle);

            p.Controls.Add(textPanel);
            p.Controls.Add(lblIcon);

            p.MouseEnter += (s, e) => p.BackColor = Color.FromArgb(240, 240, 240);
            p.MouseLeave += (s, e) => p.BackColor = Color.White;

            return p;
        }
    }
}
