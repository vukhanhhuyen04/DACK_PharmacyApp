using System;
using System.Windows.Forms;

namespace PharmacyApp
{
    internal static class Program
    {
        // Kết nối SQL dùng chung (nếu cần)
        public static readonly string ConnStr =
    @"Data Source=.\SQLEXPRESS;Initial Catalog=pharma;User ID=sa;Password=12345;Encrypt=False;";


        [STAThread]
        static void Main()
        {
#if NET5_0_OR_GREATER
    Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PharmacyApp.Forms.FrmLogin());
        }


    }
}
