using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriaBD_Crud
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
            //cl_GestorBD gestor = new cl_GestorBD();
            //gestor.CriarBD("teste");
            Application.Run(new frmPrincipal());
        }
    }
}
