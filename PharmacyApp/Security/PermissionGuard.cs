using System.Linq;
using System.Windows.Forms;
using PharmacyApp.Auth;


namespace PharmacyApp.Security
{
    public static class PermissionGuard
    {
        // Khóa UI theo chế độ xem-only
        public static void ApplyViewOnly(Control root, params Control[] exceptionsEnabled)
        {
            foreach (Control c in root.Controls)
            {
                if (exceptionsEnabled.Contains(c)) continue;
                switch (c)
                {
                    case DataGridView dgv:
                        dgv.ReadOnly = true;
                        dgv.AllowUserToAddRows = false;
                        dgv.AllowUserToDeleteRows = false;
                        break;
                    case TextBox tb: tb.ReadOnly = true; break;
                    case RichTextBox rtb: rtb.ReadOnly = true; break;
                    case ComboBox cb: cb.Enabled = false; break;
                    case Button btn: btn.Enabled = false; break;
                    default: c.Enabled = false; break;
                }
            }
        }


        // Tiện ích bật/tắt control theo quyền
        public static void Bind(Control control, IUserContext ctx, string module, string action)
        {
            control.Enabled = ctx.HasPermission(module, action);
        }
    }
}