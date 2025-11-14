using PharmacyApp.Forms;
using System;
using System.Windows.Forms;

namespace PharmacyApp
{
    internal static class Program
    {
        // Chuỗi kết nối dùng chung
        public static string ConnStr = "";

        [STAThread]
        static void Main()
        {
#if NET5_0_OR_GREATER
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1) Mở form cấu hình trước
            using (var cfgForm = new FrmConfig())
            {
                if (cfgForm.ShowDialog() != DialogResult.OK)
                {
                    // Người dùng Cancel → thoát luôn
                    return;
                }
            }

            // 2) Sau khi config OK → mở Login
            Application.Run(new FrmLogin());
        }
    }
}
