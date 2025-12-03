using System.Collections.Generic;
using System.Linq;

namespace PharmacyApp.Security
{
    public class UserContext : IUserContext
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }

        public List<string> Permissions { get; private set; } = new List<string>();

        public void SetPermissions(IEnumerable<string> perms)
        {
            Permissions = perms?.Distinct().ToList() ?? new List<string>();
        }

        public bool HasPermission(string permissionKey)
        {
            if (string.IsNullOrWhiteSpace(permissionKey)) return false;
            return Permissions != null && Permissions.Contains(permissionKey);
        }

        public bool HasPermission(string module, string action)
        {
            if (string.IsNullOrWhiteSpace(module) || string.IsNullOrWhiteSpace(action))
                return false;

            string key = $"{module}_{action}".ToUpperInvariant();
            return HasPermission(key);
        }
    }
}
