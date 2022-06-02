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
    public partial class frm_CancelarVenta : Form
    {
        private VentaProductos infoventa;
        private Validaciones Val;
        public frm_CancelarVenta(VentaProductos _venta)
        {
            InitializeComponent();
            infoventa = _venta;
        }

        private void frm_CancelarVenta_Load(object sender, EventArgs e)
        {
            using (new Recursos.CursorWait())
            {
                this.CargarcomboMotivo();
                this.ObtenerDatos();
            }

        }

        #region Metodos Generales       
        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (this.ValidarCampos())
                    {
                        this.GuardarCancelacionVenta();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavadería", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarCancelacionVenta()
        {
            try
            {
                int verificador = -1;
                VentaProductos _venta = new VentaProductos();
                this.ObtenerDatosCancelacion(_venta);
                VentaProductosNegocio _cancelarVenta = new VentaProductosNegocio();
                _cancelarVenta.CancelacionVenta(_venta,ref verificador);

                if (verificador == 1)
                {
                    MessageBox.Show(this, "Los datos se guardaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavadería", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        private void ObtenerDatosCancelacion(VentaProductos _venta)
        {
            try
            {
                _venta.conexion = Comun.conexion;
                _venta.IDSucursal = Comun.id_sucursal;
                _venta.IDVenta = infoventa.IDVenta;
                _venta.id_u = Comun.id_u;
                _venta.IDCaja = Comun.id_caja;
                _venta.motivo = txt_Observacion.Text;
                _venta.Total = Convert.ToDecimal(txt_SaldoTotal.Text);
                _venta.Pago = Convert.ToDecimal(txt_MontoPagado.Text);
                _venta.Penalizacion = Convert.ToDecimal(txt_MontoPenalizacion.Text);
                _venta.idMotivoCancelacion = Convert.ToInt32(cmb_motivoCancel.SelectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavadería", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarcomboMotivo()
        {
            try
            {
                Motivo motivo = new Motivo();
                MotivoNegocio motivoNegocio = new MotivoNegocio();
                motivo.conexion = Comun.conexion;
                motivoNegocio.ObtenerComboMotivo(motivo);

                this.cmb_motivoCancel.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_motivoCancel.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_motivoCancel.DataSource = motivo.datos;
                this.cmb_motivoCancel.DisplayMember = "motivo";
                this.cmb_motivoCancel.ValueMember = "id_motivo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavaderìa", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void ObtenerDatos()
        {
            try
            {
                this.txt_MontoPagado.Text = infoventa.Pago.ToString();
                this.txt_SaldoTotal.Text = infoventa.Total.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            try
            {
                Val = new Validaciones();
                if (Convert.ToInt32(this.cmb_motivoCancel.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_motivoCancel.SelectedIndex) == -1)
                {
                    this.cmb_motivoCancel.Focus();
                    MessageBox.Show(this, "Seleccione el motivo de la cancelación", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txt_Observacion.Text == string.Empty)
                {
                    this.txt_Observacion.Focus();
                    MessageBox.Show(this, "Escriba la observación", "Sistema Punto de VentaLavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txt_MontoPenalizacion.Text == string.Empty || Convert.ToDecimal(this.txt_MontoPenalizacion.Text) < 0)
                {
                    this.txt_MontoPenalizacion.Focus();
                    MessageBox.Show(this, "El monto de la Penalización debe ser mayor o igual a: 0", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }               
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion

        #region Eventos
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

        #endregion

    }
}
