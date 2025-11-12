using System.Collections.Generic;


namespace PharmacyApp.Auth
{
    public interface IUserContext
    {
        int UserId { get; set; }
        string Username { get; set; }
        string FullName { get; set; }
        List<string> Permissions { get; }


        bool HasPermission(string module, string action);
        string GetScope(string module, string action);
        void SetPermissions(IEnumerable<string> perms);
    }
}