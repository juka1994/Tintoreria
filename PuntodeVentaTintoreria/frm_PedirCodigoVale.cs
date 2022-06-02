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
    public partial class frm_PedirCodigoVale : Form
    {
        public frm_PedirCodigoVale()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        
      

        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /*****************************************************************************************************************************/
        private bool _Exception = true;
        public bool Exception
        {
            get { return _Exception; }
            set { _Exception = value; }
        }
        public string TextolblCantidad
        {
            get { return lbTitulo.Text; }
            set { lbTitulo.Text = value; }
        }

        public string TextotxtCantidad
        {
            get { return txtCantidad.Text; }
            set { txtCantidad.Text = value; }
        }
        

        private void frm_PedirCodigoVale_Load(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TextotxtCantidad))
                    this.txtCantidad.Text = "";

                this.txtCantidad.Focus();
                this.txtCantidad.SelectionStart = txtCantidad.Text.Length;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCodigoVale_Bunifu ~ frmCodigoVale_Load");
                this.Close();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.OK;
                this.Exception = false;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCodigoVale_Bunifu ~ btnAceptar_Click");
                this.Close();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
                this.Exception = false;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCodigoVale_Bunifu ~ btnCancelar_Click");
                this.Close();
            }
        }

        private void frm_PedirCodigoVale_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCodigoVale_Bunifu ~ frmCodigoVale_KeyUp");
            }
        }

        private void txtCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(this.txtCantidad.Text))
                        this.txtCantidad.Text = "";
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCodigoVale_Bunifu ~ txtCantidad_KeyUp");
            }
        }

        private void txtCantidad_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtCantidad.Text))
                    this.txtCantidad.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCodigoVale_Bunifu ~ txtCantidad_Validating");
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Validaciones val = new Validaciones();
                val.SoloAlfaNumerico(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCodigoVale_Bunifu ~ txtCantidad_KeyPress");
            }
        }

     
    }
}
