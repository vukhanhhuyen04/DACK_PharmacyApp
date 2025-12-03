using System.Collections.Generic;

namespace PharmacyApp.Security
{
    public interface IUserContext
    {
        int UserId { get; set; }
        string Username { get; set; }
        string FullName { get; set; }

        /// <summary>
        /// Danh sách PermissionKey (VD: "STAFF_VIEW", "PRODUCT_EDIT", ...)
        /// </summary>
        List<string> Permissions { get; }

        /// <summary>
        /// Gán lại list quyền.
        /// </summary>
        void SetPermissions(IEnumerable<string> perms);

        /// <summary>
        /// Kiểm tra 1 permission key cụ thể.
        /// </summary>
        bool HasPermission(string permissionKey);

        /// <summary>
        /// Shortcut: ghép module + action thành key: MODULE_ACTION
        /// VD: ("STAFF","EDIT") -> "STAFF_EDIT"
        /// </summary>
        bool HasPermission(string module, string action);
    }
}
