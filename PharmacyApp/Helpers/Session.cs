namespace PharmacyApp
{
    public static class Session
    {
        public static int StaffId { get; set; }
        public static int UserId { get; set; }
        public static string FullName { get; set; }
        public static string Role { get; set; }    // Admin / Dược sĩ
        public static bool IsLoggedIn { get; set; }
    }
}
