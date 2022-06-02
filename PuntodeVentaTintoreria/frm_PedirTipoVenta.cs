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
using TintoreriaNegocio;

using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
using PuntodeVentaTintoreria.ClaseAux;
using System.Management;

namespace PuntodeVentaTintoreria
{
    public partial class frm_PedirTipoVenta : Form
    {
        public frm_PedirTipoVenta()
        {
          
                InitializeComponent();
          

        }
        
      

        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /*****************************************************************************************************************************/
        private int _dato;

        public int dato
        {
            get { return _dato; }
            set { _dato = value; }
        }

        


        private void frm_PedirCadenaTexto_Load(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception)
            {
                MessageBox.Show(this, "No se pudo cargar la información. Contacte a Soporte Técnico.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
            }
        }
        #region Eventos
      
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Error al salir. Contacte a Soporte Técnico.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
            }
        }






        #endregion

        private void btnPrepago_Click(object sender, EventArgs e)
        {
            _dato = 1;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnAnticipo_Click(object sender, EventArgs e)
        {
            _dato = 2;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnPagoPendiente_Click(object sender, EventArgs e)
        {
            _dato = 3;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
