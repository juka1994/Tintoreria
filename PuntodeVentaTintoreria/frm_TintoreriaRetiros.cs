using System;
using TintoreriaGlobal;
using TintoreriaNegocio;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntodeVentaTintoreria
{
    public partial class frm_TintoreriaRetiros : Form
    {
        int TipoForm = 0;
        private Retiros inforRetiro;
        public frm_TintoreriaRetiros(int op, Retiros _dato)
        {
            InitializeComponent();
            inforRetiro = _dato;
            this.TipoForm = op;
        } 

        #region Metodos
        private void GuardarRetiro()
        {
            try
            {
                int verificador = -1;
                Retiros _retiro = new Retiros();
                Retiro_DepositoNegocio _RNEgocio = new Retiro_DepositoNegocio();
                switch (TipoForm)
                { 
                    case 1: //retiro
                        this.obtenerDatos(_retiro);
                        _retiro.id_tipo = 1;
                        _RNEgocio.GuardarRetiro(_retiro, ref verificador);
                        break;
                    case 2: //retiro caja llena
                        this.obtenerDatos(_retiro);
                        _retiro.id_tipo = 2;
                        _RNEgocio.GuardarRetiro(_retiro, ref verificador);
                        break;
                }
                
                if (verificador == 0)
                {
                    MessageBox.Show(this, "Los datos se guardaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Error al intentar guardar los datos", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            try
            {           
               
                if (this.txt_Monto.Text == string.Empty)
                {
                    this.txt_Monto.Focus();
                    MessageBox.Show(this, "Capture el monto a retirar", "Sistema Punto de VentaLavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }            
                if (this.txt_Motivo.Text == string.Empty)
                {
                    this.txt_Motivo.Focus();
                    MessageBox.Show(this, "Escriba el motivo del traspaso", "Sistema Punto de VentaLavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void obtenerDatos(Retiros _dat)
        {
            try
            {
                _dat.id_retiro = inforRetiro.id_retiro;
                _dat.id_sucursal = Comun.id_sucursal.Trim();
                _dat.id_caja = Comun.id_caja.Trim();
                _dat.id_cajero = Comun.id_u.Trim();
                _dat.id_tipo = inforRetiro.id_tipo;
                _dat.monto = Convert.ToDecimal(txt_Monto.Text.ToString());
                _dat.motivo = txt_Motivo.Text;
                _dat.id_user = Comun.id_u.Trim();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Iniciar()
        {
            try
            {
                this.TipoFormDatos();
                this.ActiveControl = this.txt_Monto;
                this.txt_Monto.Text = string.Format("{0:F2}", 0);
                this.txt_Monto.Focus();
                this.txt_Monto.SelectAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void TipoFormDatos()
        {
            try
            {
                switch (TipoForm)
                {
                    case 1:
                        this.Text = " Retiro";
                        txt_titulo.Text = "Retiro de Efectivo";
                        break;
                    case 2:
                        this.Text = " Retiro";
                        txt_titulo.Text = "Retiro de Efectivo";
                        this.txt_Motivo.ReadOnly = true;
                        this.txt_Motivo.Text = "Retiro por caja llena";
                        break;
                    case 3:
                        this.Text = " Retiro";
                        txt_titulo.Text = "Retiro de Efectivo, por concepto de pago";
                        break;
                }
                this.txt_Monto.Text = string.Format("{0:F2}", 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region eventos
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Regresar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (this.ValidarCampos())
                    {
                        this.GuardarRetiro();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Txt_Monto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Validaciones _VAL = new Validaciones();
                _VAL.SoloDecimal(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(),Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void frm_TintoreriaRetiros_Load(object sender, EventArgs e)
        {
            this.Iniciar();
        }
    }
}
