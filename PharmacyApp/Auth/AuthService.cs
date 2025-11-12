using PharmacyApp.Security; // để gọi PermissionService

namespace PharmacyApp.Auth
{
    public class AuthService
    {
        private readonly IUserContext _ctx;
        public AuthService(IUserContext ctx) { _ctx = ctx; }

        // Skeleton: xác thực giả lập (admin/123, nvsale/123, ketoan/123)
        public bool Authenticate(string username, string password, out string message)
        {
            message = string.Empty;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                message = "Vui lòng nhập đủ tên đăng nhập và mật khẩu.";
                return false;
            }

            bool ok = false;
            if (username == "admin" && password == "123") ok = true;
            else if (username == "nvsale" && password == "123") ok = true;
            else if (username == "ketoan" && password == "123") ok = true;

            if (!ok)
            {
                message = "Sai tài khoản hoặc mật khẩu";
                return false;
            }

            // Thiết lập thông tin người dùng
            if (username == "admin") _ctx.UserId = 1;
            else if (username == "nvsale") _ctx.UserId = 2;
            else if (username == "ketoan") _ctx.UserId = 3;
            else _ctx.UserId = 0;

            _ctx.Username = username;
            _ctx.FullName = username.ToUpperInvariant();

            // Nạp quyền mặc định (hard-coded cho skeleton)
            var perms = PermissionService.GetDefaultPermissionsFor(username);
            _ctx.SetPermissions(perms);

            return true;
        }
    }
}
