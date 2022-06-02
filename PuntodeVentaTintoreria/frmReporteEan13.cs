using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TintoreriaGlobal;

namespace PuntodeVentaTintoreria
{
    public partial class frmReporteEan13 : Form
    {
        Ean13Images infoEan13Imganes;
        public frmReporteEan13(Ean13Images eanImagenes)
        {
            InitializeComponent();
            infoEan13Imganes = eanImagenes;
            InitializeComponent();
        }

        private void frmReporteEan13_Load(object sender, EventArgs e)
        {

        }
    }
}
