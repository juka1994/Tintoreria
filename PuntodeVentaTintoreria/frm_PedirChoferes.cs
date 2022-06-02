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
    public partial class frm_PedirChoferes : Form
    {
        public frm_PedirChoferes()
        {
            try
            {
                InitializeComponent();

                if (Comun.ListaChoferes != null)
                {
                    cmbChofer.DataSource = Comun.ListaChoferes;
                    cmbChofer.ValueMember = "id_usuario";
                    cmbChofer.DisplayMember = "nombrecom";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se pudo cargar la información. Contacte a Soporte Técnico.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmGetString_Bunifu ~ frmGetString_Bunifu()");
                this.DialogResult = DialogResult.Abort;
            }

        }
        
      

        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /*****************************************************************************************************************************/
        private string _iddato;

        public string iddato
        {
            get { return _iddato; }
            set { _iddato = value; }
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
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbChofer.SelectedValue.ToString() == "")
                {
                    MessageBox.Show(this, "Sistema Punto de Venta CSL", "Ingrese un dato válido. ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _iddato = this.cmbChofer.SelectedValue.ToString();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Error al guardar los datos. Contacte a Soporte Técnico.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
            }
        }

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
    


    }
}
