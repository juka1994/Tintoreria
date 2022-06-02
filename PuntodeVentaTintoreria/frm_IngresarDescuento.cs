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
    public partial class frm_IngresarDescuento : Form
    {
        #region Variables
        private decimal _monto;
        private string _motivo;
        private decimal _montomax;
        private int tipo = 0;

        private bool _Exception = true;
        public bool Exception
        {
            get { return _Exception; }
            set { _Exception = value; }
        }
        public decimal montomax
        {
            get { return _montomax; }
            set { _montomax = value; }
        }
        public decimal monto
        {
            get { return _monto; }
            set { _monto = value; }
        }
        public string motivo
        {
            get { return _motivo; }
            set { _motivo = value; }
        }
        #endregion

        public frm_IngresarDescuento(int tipodesc)
        {
            try
            {
                InitializeComponent();
                tipo = tipodesc;
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

     
      

        private void frm_IngresarDescuento_Load(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (tipo == 1)
                    {
                        this.txtMotivo.Visible = false;
                        this.label2.Visible = false;
                        this.ActiveControl = this.txtMonto;
                        this.txtMonto.Focus();
                    }
                    else
                    {
                        this.txtMotivo.Visible = true;
                        this.label2.Visible = true;
                        this.ActiveControl = this.txtMotivo;
                        this.txtMotivo.Focus();
                    }
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
        #endregion
        #region Validaciones
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
                this.Close();
            }
        }

        private void frm_IngresarDescuento_KeyUp(object sender, KeyEventArgs e)
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

        private void txtMonto_Enter(object sender, EventArgs e)
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

        private void txtMotivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    this.txtMonto.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMonto_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                decimal aux = 0;
                decimal.TryParse(this.txtMonto.Text, out aux);
                this.txtMonto.Text = string.Format("{0:F2}", aux);
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
                MessageBox.Show(this, ex.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                this.Close();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (txtMotivo.Text != "" || tipo == 1)
                    {
                        this.motivo = txtMotivo.Text;
                        decimal dato = 0;
                        decimal.TryParse(this.txtMonto.Text, out dato);
                        this.txtMonto.Text = string.Format("{0:F2}", dato);
                        this.monto = dato;
                        if (monto >= 0)
                        {
                            if (monto != 0)
                            {
                                if (montomax < monto)
                                {
                                    MessageBox.Show(this, "El monto no debe ser mayor al total a pagar: " + montomax, "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.txtMonto.Focus();
                                }
                                else
                                {
                                    this.DialogResult = DialogResult.OK;
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "El monto no debe ser 0", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.txtMonto.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "El monto debe ser mayor a 0.00", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.txtMonto.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Se requiere el motivo del descuento", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtMotivo.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        #endregion



    }
}
