using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCS_POS.Kasir
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.CurrentCulture = new System.Globalization.CultureInfo("id-ID");
            Application.Run(new MainForm());
            // Application.Run(new Form1());
        }

        public static void StartOnScreenKeyboard()
        {
            string windir = Environment.GetEnvironmentVariable("WINDIR");
            string osk = null;

            if (osk == null)
            {
                osk = System.IO.Path.Combine(System.IO.Path.Combine(windir, "sysnative"), "osk.exe");
                if (!System.IO.File.Exists(osk))
                {
                    osk = null;
                }
            }

            if (osk == null)
            {
                osk = System.IO.Path.Combine(System.IO.Path.Combine(windir, "system32"), "osk.exe");
                if (!System.IO.File.Exists(osk))
                {
                    osk = null;
                }
            }

            if (osk == null)
            {
                osk = "osk.exe";
            }

            System.Diagnostics.Process.Start(osk);
        }
    }
}
