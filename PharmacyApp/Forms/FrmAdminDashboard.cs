using PharmacyApp;                 // dùng Session
using PharmacyApp.UserControls;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using PharmacyApp.Helpers;
using System.Data.SqlClient;
using PharmacyApp.Forms;
using PharmacyApp.Security;        // ⬅ QUAN TRỌNG

namespace PharmacyApp.Forms
{
    public partial class FrmAdminDashboard : Form
    {
        private readonly int _userId;
        private readonly string _fullName;
        private readonly string _role;     // vẫn giữ để phân biệt Admin/Dược sĩ cho search
        private UserControl _currentPage;
        private bool _isDashboardActive = true;

        public FrmAdminDashboard(int userId, string fullName, string role)
        {
            InitializeComponent();

            _userId = userId;
            _fullName = fullName;
            _role = role;

            // Brand
            lblBrand.Text =
                "<span style='color:#69C4F6;'>Eterna</span>" +
                "<span style='color:#36D7B7;'>Med</span>";
            lblBrand.Cursor = Cursors.Hand;

            // Tên user trên góc phải
            lblUserName.Text = fullName;
            // Không cho panel bắt Tab
            pTop.TabStop = false;
            pSide.TabStop = false;
            pContent.TabStop = false;

            // Đặt focus mặc định vào nút đầu tiên (POS)
            this.ActiveControl = btnPOS;
        }

        // helper: check permission nhanh
        private bool Can(string permKey) => PermissionService.Has(permKey);

        private void FrmAdminDashboard_Load(object sender, EventArgs e)
        {
            ApplyRoleUI();     // Ẩn menu theo quyền DB

            // ⬅ CHẶN DƯỢC SĨ XEM DASHBOARD
            if (_role == "Admin")
            {
                ShowDashboard();   // Chỉ Admin mới load Dashboard
            }
            else
            {
                // Dược sĩ: vào thẳng POS (hoặc Catalog tùy bạn)
                LoadPage(new UC_POS(), PermissionService.INVOICE_CREATE);
                _isDashboardActive = false;

                // Không cho hover/click brand nhảy về Dashboard
                lblBrand.Cursor = Cursors.Default;
            }
        }

        private void ApplyRoleUI()
        {
            // Chỉ ai có quyền STAFF_VIEW mới thấy menu Nhân viên
            btnUsers.Visible = Can(PermissionService.STAFF_VIEW);

            // Chỉ ai có quyền REPORT_VIEW mới thấy báo cáo
            btnRevenue.Visible = Can(PermissionService.REPORT_VIEW);

            // Chỉ ai có quyền WAREHOUSE_VIEW mới thấy Kho
            btnInventory.Visible = Can(PermissionService.WAREHOUSE_VIEW) ||
                                   Can(PermissionService.WAREHOUSE_EDIT);

            // POS & Catalog & Invoices sẽ được chặn thêm ở LoadPage,
            // nhưng bạn có thể ẩn luôn nếu muốn:
            // btnPOS.Visible = Can(PermissionService.INVOICE_CREATE);
            // btnCatalog.Visible = Can(PermissionService.PRODUCT_VIEW);
        }

        private void ShowDashboard()
        {
            // ⬅ Thêm bảo vệ cho chắc: nếu có call nhầm từ nơi khác
            if (_role != "Admin")
            {
                MessageBox.Show("Chỉ Admin mới được xem Dashboard.",
                    "Phân quyền",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            pContent.Visible = true;
            pContent.Controls.Clear();

            var dash = new UC_Dashboard();
            dash.Dock = DockStyle.Fill;

            pContent.Controls.Add(dash);
            dash.BringToFront();

            _currentPage = dash;          // để search còn hoạt động
            _isDashboardActive = true;
        }

        /// <summary>
        /// Load 1 UserControl vào pContent.
        /// Nếu requiredPermissionKey != null thì bắt buộc phải có quyền đó.
        /// </summary>
        private void LoadPage(UserControl uc, string requiredPermissionKey = null)
        {
            if (!string.IsNullOrWhiteSpace(requiredPermissionKey) &&
                !PermissionService.Has(requiredPermissionKey))
            {
                MessageBox.Show(
                    "Bạn không có quyền truy cập chức năng này.",
                    "Phân quyền",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                uc.Dispose();
                return;
            }

            pContent.Visible = true;
            pContent.Controls.Clear();

            uc.Dock = DockStyle.Fill;
            pContent.Controls.Add(uc);
            uc.BringToFront();

            _currentPage = uc;
            _isDashboardActive = false;
        }

        // ===================== BRAND CLICK =====================
        private void lblBrand_Click(object sender, EventArgs e)
        {
            // ⬅ Dược sĩ bấm brand sẽ không làm gì
            if (_role != "Admin")
                return;

            if (_isDashboardActive)
            {
                pContent.Visible = !pContent.Visible;   // ẩn / hiện dashboard
            }
            else
            {
                ShowDashboard();                       // từ trang khác quay lại dashboard
            }
        }

        private void lblBrand_MouseEnter(object sender, EventArgs e)
        {
            // ⬅ Chỉ Admin mới được thấy hover kiểu link
            if (_role == "Admin")
            {
                lblBrand.Cursor = Cursors.Hand;
                lblBrand.ForeColor = Color.FromArgb(105, 196, 246);
            }
            else
            {
                lblBrand.Cursor = Cursors.Default;
            }
        }

        private void lblBrand_MouseLeave(object sender, EventArgs e)
        {
            if (_role == "Admin")
            {
                lblBrand.Cursor = Cursors.Default;
                lblBrand.ForeColor = Color.White;
            }
        }

        // ===================== MENU BÊN TRÁI =====================
        private void btnCatalog_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_Catalog(), PermissionService.PRODUCT_VIEW);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            // Quản lý nhân viên: cần quyền STAFF_VIEW (vào form),
            // còn thêm/sửa/xóa sẽ check STAFF_EDIT / STAFF_DELETE bên trong UC_Staff
            LoadPage(new UC_Staff(), PermissionService.STAFF_VIEW);
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_Report(), PermissionService.REPORT_VIEW);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_Warehouse(), PermissionService.WAREHOUSE_VIEW);
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_POS(), PermissionService.INVOICE_CREATE);
        }

        private void btnInvoices_Click(object sender, EventArgs e)
        {
            LoadPage(new UC_Invoices(), PermissionService.INVOICE_VIEW);
        }

        // ===================== PROFILE =====================
        private void btnProfile_Click(object sender, EventArgs e)
        {
            var uc = new UC_Profile
            {
                Dock = DockStyle.Fill,
                StaffId = Session.StaffId,               // lấy StaffId từ Session
                IsAdmin = Session.Role == "Admin"        // cái này bạn đang dùng trong UC_Profile
            };

            pContent.Controls.Clear();
            pContent.Controls.Add(uc);
            _currentPage = uc;
            _isDashboardActive = false;
        }

        // ===================== LOGOUT =====================
        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Session.Clear();

                this.Hide();
                FrmLogin frmLogin = new FrmLogin();
                frmLogin.Show();
                this.Close();
            }
        }

        // ====== Các event trống ======
        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }
        private void guna2Panel6_Paint(object sender, PaintEventArgs e) { }
        private void pTop_Paint(object sender, PaintEventArgs e) { }
        private void value4_Click(object sender, EventArgs e) { }
        private void lblApp_Click(object sender, EventArgs e) { }
        private void lblBrandCare_Click(object sender, EventArgs e) { }
        private void lblBrand_MouseMove(object sender, MouseEventArgs e) { lblBrand.Cursor = Cursors.Hand; }
        private void lblBrandCare_MouseMove(object sender, MouseEventArgs e) { lblBrand.Cursor = Cursors.Hand; }

        // ===================== GLOBAL SEARCH =====================
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string kw = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(kw)) return;

            // Search vẫn giữ behaviour Admin tìm thêm Staff
            if (_role == "Admin")
                GlobalSearchAdmin(kw);
            else
                GlobalSearchPharmacist(kw);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearch.PerformClick();
            }
        }

        // Mở danh mục thuốc từ global search
        public void SearchOpenProduct(string productId)
        {
            var uc = new UC_Catalog();
            LoadPage(uc, PermissionService.PRODUCT_VIEW);
            // TODO: uc.SearchByProductId(productId);
        }

        // Mở hóa đơn từ global search
        public void SearchOpenInvoice(string invoiceId)
        {
            var uc = new UC_Invoices();
            LoadPage(uc, PermissionService.INVOICE_VIEW);
            // TODO: uc.SearchByInvoiceId(invoiceId);
        }

        // Mở nhân viên / dược sĩ từ global search (Admin)
        public void SearchOpenStaff(string staffId)
        {
            var uc = new UC_Staff();
            LoadPage(uc, PermissionService.STAFF_VIEW);
            // TODO: uc.SearchByStaffId(staffId);
        }

        private void GlobalSearchAdmin(string kw)
        {
            string like = "%" + kw + "%";

            // 1. Sản phẩm
            DataTable dtProducts = DBHelper.GetDataTable(
                @"SELECT TOP 20 ProductId, ProductName, ProductCode 
          FROM Products
          WHERE IsActive = 1 AND 
                (ProductName LIKE @kw OR ProductCode LIKE @kw OR Barcode LIKE @kw)",
                new SqlParameter("@kw", like));

            // 2. Hóa đơn
            DataTable dtInvoices = DBHelper.GetDataTable(
                @"SELECT TOP 20 InvoiceId, CreatedAt, CustomerName
          FROM Invoices
          WHERE CONVERT(nvarchar(20), InvoiceId) LIKE @kw
             OR CustomerName LIKE @kw",
                new SqlParameter("@kw", like));

            // 3. Nhân viên / dược sĩ
            DataTable dtStaff = DBHelper.GetDataTable(
                @"SELECT TOP 20 StaffId, FullName, StaffCode
          FROM Staff
          WHERE IsActive = 1 AND 
                (FullName LIKE @kw OR StaffCode LIKE @kw)",
                new SqlParameter("@kw", like));

            var frm = new FrmSearchResults();
            frm.Owner = this;
            frm.LoadResults(dtProducts, dtInvoices, dtStaff, true);
            frm.ShowDialog();
        }

        private void GlobalSearchPharmacist(string kw)
        {
            string like = "%" + kw + "%";

            DataTable dtProducts = DBHelper.GetDataTable(
                @"SELECT TOP 20 ProductId, ProductName, ProductCode 
          FROM Products
          WHERE IsActive = 1 AND 
                (ProductName LIKE @kw OR ProductCode LIKE @kw OR Barcode LIKE @kw)",
                new SqlParameter("@kw", like));

            DataTable dtInvoices = DBHelper.GetDataTable(
                @"SELECT TOP 20 InvoiceId, CreatedAt, CustomerName
          FROM Invoices
          WHERE CONVERT(nvarchar(20), InvoiceId) LIKE @kw
             OR CustomerName LIKE @kw",
                new SqlParameter("@kw", like));

            var frm = new FrmSearchResults();
            frm.Owner = this;
            frm.LoadResults(dtProducts, dtInvoices, null, false);
            frm.ShowDialog();
        }
    }
}
