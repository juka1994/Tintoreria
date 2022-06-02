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

namespace PuntodeVentaTintoreria
{
    public partial class frm_TintoreriaDepositos : Form
    {
        private Validaciones Val;
        private Depositos infoDeposito;
        public frm_TintoreriaDepositos(Depositos _dato)
        {
            InitializeComponent();
            infoDeposito = _dato;
        }

        private void frm_TintoreriaDepositos_Load(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void txt_titulo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (this.ValidarCampos())
                    {
                        this.GuardarDeposito();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavadería", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            try
            {
                Val = new Validaciones();

                if (this.textMonto.Text == string.Empty || Convert.ToDecimal(this.textMonto.Text) < 0)
                {
                    this.textMonto.Focus();
                    MessageBox.Show(this, "El monto del deposito debe ser mayor o igual a: 0", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (this.txt_Motivo.Text == string.Empty)
                {
                    this.txt_Motivo.Focus();
                    MessageBox.Show(this, "Escriba el motivo", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void GuardarDeposito ()
        {
            try
            {
                int verificador = -1;
                Depositos depositos = new Depositos();
                this.ObtenerDatosCancelacion(depositos);
                Retiro_DepositoNegocio retiro = new Retiro_DepositoNegocio();
                retiro.Deposito(depositos, ref verificador);

                if (verificador == 0)
                {
                    MessageBox.Show(this, "Los datos se guardaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Error al guardar datos ", "Sistemas Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavadería", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerDatosCancelacion( Depositos depositos)
        {
            depositos.id_deposito = infoDeposito.id_deposito;
            depositos.id_caja = Comun.id_caja.Trim();
            depositos.id_sucursal = Comun.id_sucursal.Trim();
            depositos.id_cajero = Comun.id_u.Trim();
            depositos.monto = Convert.ToDecimal(textMonto.Text);
            depositos.motivo = txt_Motivo.Text;
            
        }

        private void textMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloDecimal(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavadería", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
    }
}
