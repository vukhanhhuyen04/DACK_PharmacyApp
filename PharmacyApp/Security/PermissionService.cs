using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PharmacyApp.Security
{
    public static class PermissionService
    {
        // (không bắt buộc) Định nghĩa sẵn các key để dùng cho đỡ sai chính tả
        public const string DASHBOARD_VIEW = "DASHBOARD_VIEW";
        public const string STAFF_VIEW = "STAFF_VIEW";
        public const string STAFF_EDIT = "STAFF_EDIT";
        public const string STAFF_DELETE = "STAFF_DELETE";
        public const string PRODUCT_VIEW = "PRODUCT_VIEW";
        public const string PRODUCT_EDIT = "PRODUCT_EDIT";
        public const string INVOICE_VIEW = "INVOICE_VIEW";
        public const string INVOICE_CREATE = "INVOICE_CREATE";
        public const string WAREHOUSE_VIEW = "WAREHOUSE_VIEW";
        public const string WAREHOUSE_EDIT = "WAREHOUSE_EDIT";
        public const string REPORT_VIEW = "REPORT_VIEW";
        public const string SYSTEM_CONFIG = "SYSTEM_CONFIG";

        /// <summary>
        /// Lấy danh sách PermissionKey cho 1 user dựa vào Users.RoleID.
        /// </summary>
        public static List<string> GetPermissionsForUser(int userId)
        {
            var list = new List<string>();

            using (var conn = new SqlConnection(Program.ConnStr))
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
SELECT DISTINCT p.PermissionKey
FROM   Users u
       LEFT JOIN Roles r ON r.RoleID = u.RoleID
       LEFT JOIN RolePermissions rp ON rp.RoleID = r.RoleID
       LEFT JOIN Permissions p ON p.PermissionID = rp.PermissionID
WHERE  u.UserID = @uid";

                cmd.Parameters.AddWithValue("@uid", userId);

                conn.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(rd["PermissionKey"].ToString());
                    }
                }
            }

            return list;
        }


        /// <summary>
        /// Nạp quyền vào Session cho user hiện tại (dùng sau khi login).
        /// </summary>
        public static void LoadPermissionsForCurrentUser()
        {
            if (!Session.IsLoggedIn || Session.UserId <= 0)
            {
                Session.Permissions = new List<string>();
                return;
            }

            Session.Permissions = GetPermissionsForUser(Session.UserId);
        }

        /// <summary>
        /// Kiểm tra user hiện tại có 1 quyền cụ thể không.
        /// </summary>
        public static bool Has(string permissionKey)
        {
            if (string.IsNullOrWhiteSpace(permissionKey))
                return false;

            return Session.Permissions != null
                   && Session.Permissions.Contains(permissionKey);
        }

        /// <summary>
        /// Có ít nhất 1 trong các quyền truyền vào.
        /// </summary>
        public static bool HasAny(params string[] keys)
        {
            if (keys == null || keys.Length == 0) return false;
            if (Session.Permissions == null || Session.Permissions.Count == 0) return false;

            foreach (var k in keys)
            {
                if (!string.IsNullOrWhiteSpace(k) &&
                    Session.Permissions.Contains(k))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Bắt buộc có đầy đủ tất cả quyền trong danh sách.
        /// </summary>
        public static bool HasAll(params string[] keys)
        {
            if (keys == null || keys.Length == 0) return false;
            if (Session.Permissions == null || Session.Permissions.Count == 0) return false;

            foreach (var k in keys)
            {
                if (string.IsNullOrWhiteSpace(k)) return false;
                if (!Session.Permissions.Contains(k)) return false;
            }
            return true;
        }
        /// <summary>
        /// Dùng cho AuthService skeleton: trả về quyền mặc định theo username
        /// (admin / nvsale / ketoan). Không phụ thuộc database nhà thuốc.
        /// </summary>
        public static List<string> GetDefaultPermissionsFor(string username)
        {
            var list = new List<string>();
            if (string.IsNullOrWhiteSpace(username)) return list;

            username = username.Trim().ToLowerInvariant();

            if (username == "admin")
            {
                // full quyền
                list.AddRange(new[]
                {
                    "DASHBOARD_VIEW",
                    "STAFF_VIEW","STAFF_EDIT","STAFF_DELETE",
                    "PRODUCT_VIEW","PRODUCT_EDIT",
                    "INVOICE_VIEW","INVOICE_CREATE",
                    "WAREHOUSE_VIEW","WAREHOUSE_EDIT",
                    "REPORT_VIEW",
                    "SYSTEM_CONFIG"
                });
            }
            else if (username == "nvsale")
            {
                // nhân viên bán hàng
                list.AddRange(new[]
                {
                    "DASHBOARD_VIEW",
                    "PRODUCT_VIEW",
                    "INVOICE_VIEW","INVOICE_CREATE"
                });
            }
            else if (username == "ketoan")
            {
                // kế toán
                list.AddRange(new[]
                {
                    "DASHBOARD_VIEW",
                    "INVOICE_VIEW",
                    "REPORT_VIEW"
                });
            }
            // các user khác: không quyền gì (hoặc thêm quyền tối thiểu nếu bạn muốn)

            return list;
        }
    }
}
   