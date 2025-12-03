using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace PharmacyApp.Security
{
    public class BasePermissionControl : UserControl
    {
        /// <summary>
        /// Danh sách role được phép xem UC này
        /// Ví dụ: new [] { UserRole.Admin, UserRole.DuocSi }
        /// </summary>
        public UserRole[] AllowedRoles { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Nếu chưa set thì cho tất cả
            if (AllowedRoles == null || AllowedRoles.Length == 0)
                return;

            if (!AllowedRoles.Contains(CurrentUser.Role))
            {
                MessageBox.Show(
                    "Bạn không có quyền sử dụng chức năng này.",
                    "Phân quyền",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                // Ẩn và disable UC
                this.Visible = false;
                this.Enabled = false;
            }
        }
    }
}
