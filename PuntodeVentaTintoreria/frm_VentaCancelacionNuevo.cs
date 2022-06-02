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
using System.Globalization;
using System.Drawing.Printing;

namespace PuntodeVentaTintoreria
{
    public partial class frm_VentaCancelacionNuevo : Form
    {
       
        
        

        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        /*************************************************************************************************************************************************/
        Validaciones Val;
        VentaProductos infoVenta = new VentaProductos();


        public frm_VentaCancelacionNuevo()
        {
            try
            {
                InitializeComponent();
                infoVenta.IDVenta = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelacion ~ frmCancelacion()");
            }
        }


   
        

        private void frm_VentaCancelacionNuevo_Load(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.CargarCombos();
                }
                this.ActiveControl = this.txt_folio;
                this.txt_folio.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelacion ~ frmCancelacion_Load");
            }
        }
        #region MetodosGenerales
        private void CargarDatos(VentaProductos ventaProducto)
        {
            try
            {
                txt_folio.Text = ventaProducto.Folio;
                txt_cliente.Text = ventaProducto.NombreCliente;
                txtDescuento.Text = String.Format("{0:C2}", ventaProducto.Descuento);
                txtIva.Text = String.Format("{0:C2}", ventaProducto.Iva);
                txtSubtotal.Text = String.Format("{0:C2}", ventaProducto.Subtotal);
                txtTotal.Text = String.Format("{0:C2}", ventaProducto.Total);
                dtp_fechaPedido.Text = ventaProducto.FecVenta.ToString();
                //txt_fechaPedido.Text = ventaProducto.FecVenta.ToShortDateString();
                dtp_horaPedido.Text = ventaProducto.HorVenta;
                //txt_horaPedido.Text = ventaProducto.HorVenta;
                cmb_tipoVenta.SelectedValue = ventaProducto.IDTipoVenta;

                VentaProductosNegocio venta_negocio = new VentaProductosNegocio();
                VentaProductos ventaProductos = new VentaProductos();
                ventaProductos.conexion = Comun.conexion;
                ventaProductos.IDSucursal = ventaProducto.IDSucursal;
                ventaProductos.IDVenta = ventaProducto.IDVenta;
                venta_negocio.LLenarGridCancelacionDetalle(ventaProductos);
                this.DGVTabPage.AutoGenerateColumns = false;
                this.DGVTabPage.DataSource = ventaProductos.datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelacion ~ CargarDatos()");
            }
        }
        private VentaProductos CargarDetalleVenta(string folio)
        {
            VentaProductosNegocio venta_negocio = new VentaProductosNegocio();
            VentaProductos ventaProductos = new VentaProductos();
            ventaProductos.conexion = Comun.conexion;
            ventaProductos.Folio = folio;
            ventaProductos.IDSucursal = Comun.id_sucursal;
            venta_negocio.ObtenerNuevaCancelacion(ventaProductos);
            return ventaProductos;
        }
        private void ObtenerDatos(VentaProductos ventaProducto)
        {
            ventaProducto.conexion = Comun.conexion;
            ventaProducto.id_u = Comun.id_u;
            ventaProducto.IDVenta = infoVenta.IDVenta;
            ventaProducto.IDSucursal = infoVenta.IDSucursal;
            ventaProducto.IDCaja = Comun.id_caja;
            ventaProducto.IDCajero = Comun.id_u;
            ventaProducto.motivo = txt_motivo.Text;
            ventaProducto.CancelacionDetalle = (DataTable)this.DGVTabPage.DataSource;
        }
        private void CargarCombos()
        {
            VentaProductosNegocio venta_negocio = new VentaProductosNegocio();
            VentaProductos ventaProductos = new VentaProductos();
            ventaProductos.conexion = Comun.conexion;
            venta_negocio.ObtenerComboTipoVenta(ventaProductos);
            this.cmb_tipoVenta.DisplayMember = "tipoVenta";
            this.cmb_tipoVenta.ValueMember = "id_tipoVenta";
            this.cmb_tipoVenta.DataSource = ventaProductos.datos;
            dtp_fechaPedido.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dtp_horaPedido.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        private void VerificarMensajeAccion(int Verificador)
        {
            try
            {
                if (Verificador == 0)
                {
                    MessageBox.Show(this, "Los datos se guardaron correctamente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "La forma de pago no permite cancelar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (this.txt_motivo.Text.Length == 0)
                {
                    this.txt_motivo.Focus();
                    MessageBox.Show(this, "Escriba el motivo de la cancelación", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        #region Validaciones
        private void txt_motivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloTexto(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelacion ~ txt_motivo_KeyPress");
            }
        }

        private void txt_motivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_motivo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txt_folio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_folio_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txt_folio_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloNumerico(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelacion ~ txt_folio_KeyPress");
            }
        }

        #endregion
        #region Eventos
        private void txt_folio_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    using (new Recursos.CursorWait())
                    {
                        infoVenta = this.CargarDetalleVenta(txt_folio.Text);
                        if (infoVenta.IDVenta != null)
                            this.CargarDatos(infoVenta);
                        else
                            MessageBox.Show(this, "No hay venta registrada con el folio escrito", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelacion ~ txt_folio_KeyUp");
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (infoVenta.IDVenta != null)
                {
                    if (this.ValidarCampos())
                    {
                        if (MessageBox.Show("¿Esta seguro de cancelar la venta?", "Cancelar Venta", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            int Verificador = -1;
                            VentaProductosNegocio VentaProductos_negocio = new VentaProductosNegocio();
                            VentaProductos ventaProducto = new VentaProductos();
                            this.ObtenerDatos(ventaProducto);
                            using (new Recursos.CursorWait())
                            {
                                VentaProductos_negocio.CancelarVenta(ventaProducto, ref Verificador);
                            }
                            this.VerificarMensajeAccion(Verificador);
                        }
                    }
                }
                else
                    MessageBox.Show(this, "Folio no cargado", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelacion ~ btnAceptar_Click");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelacion ~ btnCancelar_Click");
            }
        }
        #endregion


    }
}
