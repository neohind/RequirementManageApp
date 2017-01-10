using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RequireManager
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

            frmLogin loginForm = new frmLogin();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                frmMain mainForm = new RequireManager.frmMain();
                mainForm.SetSelectedProject(loginForm.SelectedProject);
                Application.Run(mainForm);
            }
        }
    }
}
