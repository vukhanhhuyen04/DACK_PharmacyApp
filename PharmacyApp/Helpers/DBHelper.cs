using System;
using System.Data;
using System.Data.SqlClient;
using PharmacyApp;          // để dùng Program, DbConfig, ConfigHelper

namespace PharmacyApp.Helpers
{
    public static class DBHelper
    {
        // Lấy connection string từ Program.ConnStr hoặc từ file config (nếu ConnStr đang null)
        private static string GetConnectionString()
        {
            if (!string.IsNullOrEmpty(Program.ConnStr))
                return Program.ConnStr;

            // Fallback: đọc file config (ConfigHelper) nếu chưa có ConnStr
            var cfg = ConfigHelper.LoadConfig();
            return ConfigHelper.BuildConnectionString(cfg);
        }

        // ============================
        // SELECT → DataTable
        // ============================
        public static DataTable GetDataTable(string query, params SqlParameter[] parameters)
        {
            string connStr = GetConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // ============================
        // SELECT 1 value → object
        // ============================
        public static object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            string connStr = GetConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

        // ============================
        // INSERT / UPDATE / DELETE
        // ============================
        public static int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            string connStr = GetConnectionString();

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
