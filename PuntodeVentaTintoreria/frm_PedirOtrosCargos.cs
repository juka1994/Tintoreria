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
    public partial class frm_PedirOtrosCargos : Form
    {
        public frm_PedirOtrosCargos()
        {
            try
            {
                InitializeComponent();
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
        private string _dato;

        public string dato
        {
            get { return _dato; }
            set { _dato = value; }
        }

        private string _Comentario;

        public string Comentario
        {
            get { return _Comentario; }
            set { _Comentario = value; }
        }

        private decimal _precio;
        public decimal precio
        {
            get { return _precio; }
            set { _precio = value; }
        }


        private void frm_PedirCadenaTexto_Load(object sender, EventArgs e)
        {
            try
            {
                this.ActiveControl = this.txtCantidad;
                this.txtCantidad.Text = dato;
                this.txtCantidad.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "No se pudo cargar la información. Contacte a Soporte Técnico.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
            }
        }
        #region Eventos

        private void PermitirSoloNumerosDecimales(KeyPressEventArgs e, string cadena)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                  if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar != 8)
                    e.Handled = true;
                else
                    e.Handled = false;
            }
            else
            {
                if (e.KeyChar == (char)'.')
                {
                    if (cadena.IndexOf('.') == -1)
                        e.Handled = false;
                    else
                        e.Handled = true;
                }
                else
                {
                    e.Handled = true;
                }
            }

        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if ((string.IsNullOrEmpty(this.txtCantidad.Text) || string.IsNullOrWhiteSpace(this.txtCantidad.Text)) || (string.IsNullOrEmpty(this.txtPrecio.Text) || string.IsNullOrWhiteSpace(this.txtPrecio.Text)))
                {
                    MessageBox.Show(this, "Sistema Punto de Venta CSL", "Debe Capturar los datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _precio = Convert.ToDecimal(this.txtPrecio.Text);
                    dato = this.txtCantidad.Text;
                    _Comentario = txtComentarios.Text;
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

        private void txtCantidad_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtCantidad.SelectAll();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Error al salir. Contacte a Soporte Técnico.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
            }
        }



        #endregion

        private void txtPrecio_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtPrecio.SelectAll();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Error al salir. Contacte a Soporte Técnico.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
            }
        }


        

    private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                this.PermitirSoloNumerosDecimales(e,txtPrecio.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
