using System;
using System.IO;
using System.Windows.Forms;

namespace PharmacyApp   // 👉 ĐỔI cho khớp namespace project của bạn
{
    // 🔹 Phải là public để dùng được ở nơi khác
    public class DbConfig
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public bool UseWindowsAuth { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }

    public static class ConfigHelper
    {
        private static readonly string ConfigPath =
            Path.Combine(Application.StartupPath, "dbconfig.ini");

        public static DbConfig LoadConfig()
        {
            var cfg = new DbConfig();

            if (!File.Exists(ConfigPath))
                return cfg;

            foreach (var line in File.ReadAllLines(ConfigPath))
            {
                if (string.IsNullOrWhiteSpace(line) || line.TrimStart().StartsWith("#"))
                    continue;

                var parts = line.Split(new[] { '=' }, 2);
                if (parts.Length != 2) continue;

                var key = parts[0].Trim();
                var val = parts[1].Trim();

                switch (key)
                {
                    case "Server": cfg.Server = val; break;
                    case "Database": cfg.Database = val; break;
                    case "UseWindowsAuth":
                        cfg.UseWindowsAuth = val.Equals("true", StringComparison.OrdinalIgnoreCase);
                        break;
                    case "UserId": cfg.UserId = val; break;
                    case "Password": cfg.Password = val; break;
                }
            }

            return cfg;
        }

        public static void SaveConfig(DbConfig cfg)
        {
            var lines = new[]
            {
                $"Server={cfg.Server}",
                $"Database={cfg.Database}",
                $"UseWindowsAuth={cfg.UseWindowsAuth}",
                $"UserId={cfg.UserId}",
                $"Password={cfg.Password}"
            };
            File.WriteAllLines(ConfigPath, lines);
        }

        public static string BuildConnectionString(DbConfig cfg)
        {
            if (cfg.UseWindowsAuth)
            {
                return $"Data Source={cfg.Server};Initial Catalog={cfg.Database};" +
                       $"Integrated Security=True;Encrypt=False;";
            }
            else
            {
                return $"Data Source={cfg.Server};Initial Catalog={cfg.Database};" +
                       $"User ID={cfg.UserId};Password={cfg.Password};Encrypt=False;";
            }
        }
    }
}
