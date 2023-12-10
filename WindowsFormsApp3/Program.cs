using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.Gui.Forms;

namespace WindowsFormsApp3
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var fLogin = new FMain();
            fLogin.Show();
            Application.Run();

            /*
               FLogin loginForm = new FLogin();
              Application.Run(loginForm);

              if (loginForm.UserSuccessfullyAuthenticated)
              {
                  // MainForm is defined elsewhere
                  Application.Run(new FMain());
              }
             */
        }
    }
}
