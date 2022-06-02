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
    public partial class frm_IngresarProductoGenerico : Form
    {
        #region Variables
        private string _nombre;
        private decimal _monto;
        private int _cantidad;
        private bool _Exception = false;
        public bool Exception
        {
            get { return _Exception; }
            set { _Exception = value; }
        }
        public string nombreproducto
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public decimal monto
        {
            get { return _monto; }
            set { _monto = value; }
        }
        public int cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }
        #endregion

        public frm_IngresarProductoGenerico()
        {
            try
            {
                InitializeComponent();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }
        
      

        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /*****************************************************************************************************************************/

        private void frm_IngresarProductoGeneric_Load(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.IsMdiContainer = true;
                    this.TopMost = false;
                    this.ActiveControl = txtMotivo;
                    this.txtMotivo.Focus();
                    this.txtCantidad.TextAlign = HorizontalAlignment.Right;
                    this.txtMonto.TextAlign = HorizontalAlignment.Right;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        #region Metodos Generales
        private void PermitirSoloNumerosDecimales(KeyPressEventArgs e, string cadena)
        {
            try
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                    if (Char.IsControl(e.KeyChar))
                {
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void permitirSoloNumeros(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                    if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion
        #region Validaciones
        private void txtMotivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    this.txtCantidad.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMotivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtMotivo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                    this.btnOk_Click(null, null);
                else
                    this.PermitirSoloNumerosDecimales(e, txtMonto.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                    this.txtMonto.Focus();
                else
                    this.permitirSoloNumeros(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frm_IngresarProductoGenerico_KeyUp(object sender, KeyEventArgs e)
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
            }
        }

        private void txtMonto_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtMonto.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Eventos

        private void btnOk_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    this.btnOk_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (string.IsNullOrEmpty(this.txtMotivo.Text))
                    {
                        MessageBox.Show(this, "Motivo no puede quedar vacío", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtMotivo.Focus();
                        this.txtMotivo.SelectAll();
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtMonto.Text))
                    {
                        MessageBox.Show(this, "Monto no puede quedar vacío", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtMonto.Focus();
                        this.txtMonto.SelectAll();
                        return;
                    }
                    if (string.IsNullOrEmpty(this.txtCantidad.Text))
                    {
                        MessageBox.Show(this, "Cantidad no puede quedar vacío", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtCantidad.Focus();
                        this.txtCantidad.SelectAll();
                        return;
                    }

                    cantidad = Convert.ToInt32(this.txtCantidad.Text);
                    monto = decimal.Parse(this.txtMonto.Text);
                    nombreproducto = this.txtMotivo.Text;

                    if (monto <= 0)
                    {
                        MessageBox.Show(this, "Monto no puede ser 0", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtMonto.Focus();
                        this.txtMonto.SelectAll();
                        return;
                    }
                    if (cantidad <= 0)
                    {
                        MessageBox.Show(this, "Cantidad no puede ser 0", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtCantidad.Focus();
                        this.txtCantidad.SelectAll();
                        return;
                    }

                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
        }




        #endregion

        
    }
}
