using System.Collections.Generic;
using System.Linq;

namespace PharmacyApp.Auth
{
    public class UserContext : IUserContext
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public List<string> Permissions { get; } = new List<string>(); // format: Module:Action:Scope

        public bool HasPermission(string module, string action)
        {
            return Permissions.Any(p => p.StartsWith(
                $"{module}:{action}",
                System.StringComparison.OrdinalIgnoreCase));
        }

        public string GetScope(string module, string action)
        {
            var match = Permissions.FirstOrDefault(p => p.StartsWith(
                $"{module}:{action}",
                System.StringComparison.OrdinalIgnoreCase));

            return match?.Split(':').ElementAtOrDefault(2) ?? "All";
        }

        public void SetPermissions(IEnumerable<string> perms)
        {
            Permissions.Clear();
            Permissions.AddRange(perms);
        }
    }
}
