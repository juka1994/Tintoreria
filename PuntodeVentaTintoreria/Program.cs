using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TintoreriaGlobal;

namespace PuntodeVentaTintoreria
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Seteamos la cultura a Español México
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-MX");
            Comun.PathBaseImages = Application.StartupPath + @"\Resources\Iconos";
            Application.Run(new frm_Login());
           //Application.Run(new frmVentaTintoreria());
            //Application.Run(new frmSelDatosPrenda());
           // Application.Run(new frmSelSubTipoPrenda());
        }
    }
}
