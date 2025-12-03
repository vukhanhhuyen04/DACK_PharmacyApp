using System.Collections.Generic;

namespace PharmacyApp
{
    public static class Session
    {
        public static bool IsLoggedIn { get; set; }
        public static int UserId { get; set; }
        public static int StaffId { get; set; }
        public static string FullName { get; set; }
        public static string Role { get; set; }

        // 🔹 Danh sách PermissionKey của user hiện tại
        public static List<string> Permissions { get; set; } = new List<string>();

        public static void Clear()
        {
            IsLoggedIn = false;
            UserId = 0;
            StaffId = 0;
            FullName = null;
            Role = null;
            Permissions = new List<string>();
        }
    }
}
