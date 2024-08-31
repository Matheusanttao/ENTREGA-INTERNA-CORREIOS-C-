using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace correios
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
       {
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Registre o evento Application.ApplicationExit para executar o salvamento dos cadastros quando o aplicativo for fechado
          

            Application.Run(new Menu());
        }
    }
}
