using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCS_POS
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

            // Saat dalam mode debugging, tidak perlu di trap
            if (System.Diagnostics.Debugger.IsAttached)
            {
                Application.Run(new MainForm());
            }
            else
            {
                try
                {
                    Application.Run(new MainForm());
                }
                catch (Exception ex)
                {
                    var excForm = new ExceptionForm();
                    excForm.MessageTextBox.Text = ex.Message;
                    excForm.StackTraceTextBox.Text = ex.StackTrace;
                    excForm.ShowDialog();
                }
            }
            
            // Application.Run(new TesterForm());
        }
    }
}
