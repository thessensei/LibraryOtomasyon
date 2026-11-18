using System;
using System.Data.Common;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using MttSinema.Formlar;
using MttSinema.Veri;

namespace MttSinema
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("tr-TR");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string yol = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MttSinema", "sinema.db");
            try
            {
                using (var depo = SinemaDeposu.Ac(yol))
                using (var menu = new AnaMenuFormu(depo))
                    Application.Run(menu);
            }
            catch (Exception ex) when (ex is DbException || ex is KayitHatasi || ex is IOException || ex is UnauthorizedAccessException)
            {
                MessageBox.Show($"Veritabanı açılamadı:\n{yol}\n\n{ex.Message}", "MTT Sinema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
