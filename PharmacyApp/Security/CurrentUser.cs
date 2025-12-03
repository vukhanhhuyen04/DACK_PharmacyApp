using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PharmacyApp.Security
{
    public static class CurrentUser
    {
        public static int UserId { get; set; }
        public static string Username { get; set; }
        public static UserRole Role { get; set; }

        public static bool IsAdmin => Role == UserRole.Admin;
        public static bool IsDuocSi => Role == UserRole.DuocSi;

        public static void Reset()
        {
            UserId = 0;
            Username = null;
            Role = 0;
        }
    }
}
