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
    public partial class frm_VentaCambioNuevo : Form
    {
       
        
        

        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

       
        /*************************************************************************************************************************************************/

        private CultureInfo provider = CultureInfo.CurrentCulture;
        Cliente cliente;
        VentaProductos ventaProductoNueva;
        VentaProductos infoVentaProductos;
        bool check;
        Cambio cambio;
        decimal granTotal;
        public frm_VentaCambioNuevo(VentaProductos ventaProductos)
        {
            try
            {
                InitializeComponent();
                infoVentaProductos = ventaProductos;
                cambio = new Cambio();
                cambio.datos = new DataTable();
                cambio.datos.Columns.Add("id_cambio", typeof(string));
                cambio.datos.Columns.Add("id_sucursal", typeof(string));
                cambio.datos.Columns.Add("id_caja", typeof(string));
                cambio.datos.Columns.Add("id_productoCambio", typeof(string));
                cambio.datos.Columns.Add("id_tallaRopaCambio", typeof(int));
                cambio.datos.Columns.Add("id_colorRopaCambio", typeof(int));
                cambio.datos.Columns.Add("id_productoNuevo", typeof(string));
                cambio.datos.Columns.Add("id_tallaRopaNuevo", typeof(int));
                cambio.datos.Columns.Add("id_colorRopaNuevo", typeof(int));
                cambio.datos.Columns.Add("id_motivo", typeof(int));
                cambio.datos.Columns.Add("cantidad", typeof(int));
                cambio.datos.Columns.Add("observaciones", typeof(string));
                granTotal = infoVentaProductos.Total;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCambioTicket ~ frmCambioTicket()");
            }
        }

        private void frm_VentaCambioNuevo_Load(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.LLenarDatos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCambioTicket ~ frmCambioTicket_Load");
            }
        }
        #region MetodosGenerales
        private void AbrirCajon()
        {
            try
            {
                PrinterSettings ps = new PrinterSettings();
                ps.PrinterName = string.IsNullOrEmpty(Comun.namePrinter) ? "" : Comun.namePrinter;
                byte[] codigo = new byte[] { 27, 112, 48, 50, 250 };
                if (ps.IsValid)
                    RawPrinterHelper.SendStringToPrinter(ps.PrinterName, System.Text.ASCIIEncoding.ASCII.GetString(codigo));
                else
                    throw new Exception("No se pudo conectar con la impresora.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void LLenarDatos()
        {
            try
            {
                ClienteNegocio cliente_negocio = new ClienteNegocio();
                cliente = new Cliente();
                cliente.credenciales = new Credenciales();
                cliente.conexion = Comun.conexion;
                cliente.id_cliente = infoVentaProductos.IDCliente;
                cliente = cliente_negocio.obtenerClienteXID(cliente);

                this.txt_folio.Text = infoVentaProductos.Folio;
                this.txt_cliente.Text = infoVentaProductos.NombreCliente;
                this.txtDescuento.Text = String.Format("{0:C2}", infoVentaProductos.Descuento);
                this.txtIva.Text = String.Format("{0:C2}", infoVentaProductos.Iva);
                this.txtSubtotal.Text = String.Format("{0:C2}", infoVentaProductos.Importe);
                this.txtTotal.Text = String.Format("{0:C2}", infoVentaProductos.Total);
                this.dtp_fechaPedido.Text = infoVentaProductos.FecVenta.ToString();
                //this.txt_fechaPedido.Text = infoVentaProductos.FecVenta.ToShortDateString();
                this.dtp_horaPedido.Text = infoVentaProductos.HorVenta;
                this.dtp_fechaPedido.Text = infoVentaProductos.HorVenta;
                VentaProductosNegocio venta_negocio = new VentaProductosNegocio();
                VentaProductos ventaProductos = new VentaProductos();
                ventaProductos.conexion = Comun.conexion;
                ventaProductos.IDSucursal = infoVentaProductos.IDSucursal;
                ventaProductos.IDVenta = infoVentaProductos.IDVenta;
                venta_negocio.LLenarGridCambioDetalle(ventaProductos);
                this.GridViewDetalle.AutoGenerateColumns = false;
                this.GridViewDetalle.DataSource = ventaProductos.datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCambioTicket ~ LLenarDatos()");
            }
        }
        private List<DataGridViewRow> ObtenerFilaSeleccionada()
        {
            try
            {
                List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in GridViewDetalle.Rows)
                {
                    if (row.Selected)
                    {
                        rowSelected.Add(row);
                    }
                }
                return rowSelected;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private bool ValidarFilaSeleccionada(List<DataGridViewRow> rowSelected)
        {
            try
            {
                if (rowSelected.Count == 0)
                {
                    MessageBox.Show(this, "Debe seleccionar una fila del grid", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private VentaProductos ObtenerDatosGridDetalle()
        {
            try
            {
                VentaProductos ventaProducto = new VentaProductos();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    ventaProducto.CantidadVenta = Convert.ToInt32(row.Cells["Cantidad"].Value.ToString()) - Convert.ToInt32(row.Cells["cambios"].Value.ToString());
                    ventaProducto.NombreProducto = row.Cells["Nombre"].Value.ToString();
                    ventaProducto.IDProducto = row.Cells["IDProducto"].Value.ToString();
                    ventaProducto.IDTallaRopa = Convert.ToInt32(row.Cells["IDTallaRopa"].Value.ToString());
                    ventaProducto.IDColorRopa = Convert.ToInt32(row.Cells["IDColorRopa"].Value.ToString());
                    ventaProducto.Precio = decimal.Parse(row.Cells["Precio"].Value.ToString(), CultureInfo.InvariantCulture);
                    ventaProducto.Descuento = decimal.Parse(row.Cells["Descuento"].Value.ToString(), CultureInfo.InvariantCulture);
                    ventaProducto.Iva = decimal.Parse(row.Cells["Iva"].Value.ToString(), CultureInfo.InvariantCulture);
                    ventaProducto.Total = decimal.Parse(row.Cells["Total"].Value.ToString(), CultureInfo.InvariantCulture);
                    ventaProducto.Descripcion = row.Cells["Descripcion"].Value.ToString();
                    ventaProducto.Subtotal = decimal.Parse(row.Cells["Subtotal"].Value.ToString(), CultureInfo.InvariantCulture);
                    ventaProducto.IDCodigoEan = row.Cells["IDCodigoEan"].Value.ToString();
                    ventaProducto.IDTipoProducto = Convert.ToInt32(row.Cells["id_tipoProducto"].Value.ToString());
                    check = Convert.ToBoolean(row.Cells["cambiado"].Value);
                    ventaProducto.IDSucursal = infoVentaProductos.IDSucursal;
                }
                return ventaProducto;
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        private void VerificarMensajeAccion(int Verificador)
        {
            try
            {
                if (Verificador == 0)
                {
                    MessageBox.Show(this, "Los datos se guardaron correctamente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public bool ValidarCambios()
        {
            try
            {
                if (this.ventaProductoNueva == null)
                {
                    this.GridViewDetalle.Focus();
                    MessageBox.Show(this, "No existe ningun cambio realizado", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.ventaProductoNueva.ventadetalle.Rows.Count == 0)
                {
                    this.GridViewDetalle.Focus();
                    MessageBox.Show(this, "No existe ningun cambio realizado", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void btnCambiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCambios())
                {
                    int Verificador = -1;
                    decimal totalExtra = 0;
                    decimal.TryParse(this.txtCobroExtra.Text, NumberStyles.Currency, provider, out totalExtra);
                    frm_Pagos fccmp = new frm_Pagos(totalExtra, totalExtra, 0, cliente.credenciales.monedero, cliente.credenciales.nombreCompleto, 0, 1);
                    fccmp.ShowDialog();
                    if (fccmp.DialogResult == DialogResult.OK)
                    {
                        VentaProductosNegocio ventaproducto_negocio = new VentaProductosNegocio();
                        ventaProductoNueva.IDSucursal = infoVentaProductos.IDSucursal;
                        ventaProductoNueva.IDVenta = infoVentaProductos.IDVenta;
                        ventaProductoNueva.IDCliente = cliente.id_cliente;
                        ventaProductoNueva.IDCaja = Comun.id_caja;
                        ventaProductoNueva.IDVendedor = Comun.id_u;
                        ventaProductoNueva.IDCajero = Comun.id_u;
                        ventaProductoNueva.Subtotal = totalExtra;
                        ventaProductoNueva.Iva = 0;
                        ventaProductoNueva.Descuento = 0;
                        ventaProductoNueva.Total = totalExtra;


                        ventaProductoNueva.PagoEfectivo = fccmp.getPagoEfectivo();
                        ventaProductoNueva.PagoMonedero = fccmp.getPagoMonedero();
                        ventaProductoNueva.PagoTarjeta = fccmp.getPagoTarjeta();
                        ventaProductoNueva.PagoTransferencia = fccmp.getPagoTransferencia();
                        ventaProductoNueva.Pago = ventaProductoNueva.PagoEfectivo + ventaProductoNueva.PagoMonedero + ventaProductoNueva.PagoTarjeta + ventaProductoNueva.PagoTransferencia;
                        ventaProductoNueva.Cambio = fccmp.getCambio();

                        ventaProductoNueva.DatosTarjeta = new DataTable();
                        ventaProductoNueva.DatosTarjeta.Columns.Add("autorizacion", typeof(string));
                        ventaProductoNueva.DatosTarjeta.Columns.Add("tipoDocumento", typeof(string));
                        ventaProductoNueva.DatosTarjeta.Columns.Add("folioDNI", typeof(string));
                        ventaProductoNueva.DatosTarjeta.Columns.Add("numTarjeta", typeof(string));
                        ventaProductoNueva.DatosTarjeta.Columns.Add("id_banco", typeof(int));
                        ventaProductoNueva.DatosTarjeta.Columns.Add("monto", typeof(float));

                        if (ventaProductoNueva.PagoTarjeta > 0)
                        {
                            if (fccmp.getDatosTarjeta() != null)
                            {
                                FormaPago DatosPagoTarjeta = fccmp.getDatosTarjeta();
                                ventaProductoNueva.DatosTarjeta.Rows.Add(
                                    new Object[] {
                                DatosPagoTarjeta.autorizacion,
                                DatosPagoTarjeta.tipoDocumento != null ? DatosPagoTarjeta.tipoDocumento.id_tipoDocumento : string.Empty,
                                DatosPagoTarjeta.folioIFE,
                                DatosPagoTarjeta.numtarjeta,
                                DatosPagoTarjeta.banco != null ? DatosPagoTarjeta.banco.idBanco : 0,
                                DatosPagoTarjeta.monto});
                            }
                        }

                        ventaProductoNueva.DatosTransferencia = new DataTable();
                        ventaProductoNueva.DatosTransferencia.Columns.Add("autorizacion", typeof(string));
                        ventaProductoNueva.DatosTransferencia.Columns.Add("id_banco", typeof(int));
                        ventaProductoNueva.DatosTransferencia.Columns.Add("monto", typeof(float));

                        if (ventaProductoNueva.PagoTransferencia > 0)
                        {
                            if (fccmp.getDatosTransferencia() != null)
                            {
                                FormaPago DatosPagoTransferencia = fccmp.getDatosTransferencia();
                                ventaProductoNueva.DatosTransferencia.Rows.Add(
                                    new Object[] {
                                DatosPagoTransferencia.autorizacion,
                                DatosPagoTransferencia.banco != null ? DatosPagoTransferencia.banco.idBanco : 0,
                                DatosPagoTransferencia.monto});
                            }
                        }

                        ventaProductoNueva.StrCnx = Comun.conexion;
                        ventaProductoNueva.cambioModulo = cambio;
                        ventaproducto_negocio.InsertarProductosCambios(ref Verificador, ref ventaProductoNueva, cliente);
                        try
                        {
                            this.AbrirCajon();
                            ventaProductoNueva.IDTipoVenta = 1;
                            Ticket_Impresion impresion = new Ticket_Impresion(1, ventaProductoNueva);
                            impresion.imprimirTicket();
                            MessageBox.Show(this, "!!Cambio Realizado!!!", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, "!!Cambio Realizado!!! - No se pudo imprimir el Ticket. " + ex.Message, "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                    fccmp.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCambioTicket ~ btnCambiar_Click");
            }
        }

        private void btn_Cambio_Click(object sender, EventArgs e)
        {
            try
            {
                this.ObtenerDatosGridDetalle();
                if (check == false)
                {
                    this.Visible = false;
                    frm_VentaCambioProducto frmc = new frm_VentaCambioProducto(this.ObtenerDatosGridDetalle());
                    frmc.ShowDialog();
                    if (frmc.DialogResult == DialogResult.OK)
                    {
                        Cambio returnCambio = frmc.cambio;
                        float subtotal = 0, iva = 0, total = 0, precio;
                        ventaProductoNueva = new VentaProductos();
                        ventaProductoNueva.ventadetalle = new DataTable();
                        ventaProductoNueva.ventadetalle = (DataTable)GridViewDetalle.DataSource;
                        DataRow[] resultNuevo = ventaProductoNueva.ventadetalle.Select("IDProducto ='" + returnCambio.id_productoNuevo + "' AND IDTallaRopa=" + returnCambio.id_tallaRopaNuevo + " AND IDColorRopa=" + returnCambio.id_colorRopaNuevo);
                        if (resultNuevo.Count() == 0)
                        {
                            DataRow[] resultCambio = ventaProductoNueva.ventadetalle.Select("IDProducto ='" + returnCambio.id_productoCambio + "' AND IDTallaRopa=" + returnCambio.id_tallaRopaCambio + " AND IDColorRopa=" + returnCambio.id_colorRopaCambio);
                            if (float.Parse(resultCambio[0]["precio"].ToString()) > returnCambio.precio)
                            {
                                iva = float.Parse(resultCambio[0]["iva"].ToString()) / Convert.ToInt32(resultCambio[0]["cantidad_venta"]) * returnCambio.cantidad;
                                subtotal = float.Parse(resultCambio[0]["subtotal"].ToString()) / Convert.ToInt32(resultCambio[0]["cantidad_venta"]) * returnCambio.cantidad;
                                total = float.Parse(resultCambio[0]["total"].ToString()) / Convert.ToInt32(resultCambio[0]["cantidad_venta"]) * returnCambio.cantidad;
                                precio = float.Parse(resultCambio[0]["precio"].ToString());
                            }
                            else
                            {
                                subtotal = returnCambio.cantidad * returnCambio.precio;
                                iva = returnCambio.cantidad * returnCambio.iva;
                                total = subtotal + iva;
                                precio = returnCambio.precio;
                            }
                            resultCambio[0]["iva"] = float.Parse(resultCambio[0]["iva"].ToString()) - (float.Parse(resultCambio[0]["iva"].ToString()) / Convert.ToInt32(resultCambio[0]["cantidad_venta"]) * returnCambio.cantidad);
                            resultCambio[0]["subtotal"] = float.Parse(resultCambio[0]["subtotal"].ToString()) - (float.Parse(resultCambio[0]["subtotal"].ToString()) / Convert.ToInt32(resultCambio[0]["cantidad_venta"]) * returnCambio.cantidad);
                            resultCambio[0]["total"] = float.Parse(resultCambio[0]["total"].ToString()) - (float.Parse(resultCambio[0]["total"].ToString()) / Convert.ToInt32(resultCambio[0]["cantidad_venta"]) * returnCambio.cantidad);
                            resultCambio[0]["cantidad_venta"] = Convert.ToInt32(resultCambio[0]["cantidad_venta"]) - returnCambio.cantidad;
                            if (Convert.ToInt32(resultCambio[0]["cantidad_venta"]) <= Convert.ToInt32(resultCambio[0]["cambios"]))
                            {
                                resultCambio[0]["cambiado"] = 1;
                            }
                            ventaProductoNueva.ventadetalle.Rows.Add(returnCambio.nombreProducto, returnCambio.id_tallaRopaNuevo, returnCambio.id_colorRopaNuevo, returnCambio.id_productoNuevo,
                                    returnCambio.descripcion, returnCambio.id_codigoEan, precio, returnCambio.cantidad, subtotal, iva, 0, total, returnCambio.cantidad, 1, returnCambio.id_tipoProducto);
                            if (Convert.ToInt32(resultCambio[0]["cantidad_venta"]) == 0)
                            {
                                DataRow myRow = (this.ObtenerFilaSeleccionada()[0].DataBoundItem as DataRowView).Row;
                                ventaProductoNueva.ventadetalle.Rows.Remove(myRow);
                            }
                            GridViewDetalle.DataSource = ventaProductoNueva.ventadetalle;
                        }
                        else
                        {
                            DataRow[] resultCambio = ventaProductoNueva.ventadetalle.Select("IDProducto ='" + returnCambio.id_productoCambio + "' AND IDTallaRopa=" + returnCambio.id_tallaRopaCambio + " AND IDColorRopa=" + returnCambio.id_colorRopaCambio);
                            if (resultNuevo[0]["IDProducto"].ToString() == resultCambio[0]["IDProducto"].ToString() && resultNuevo[0]["IDTallaRopa"].ToString() == resultCambio[0]["IDTallaRopa"].ToString() && resultNuevo[0]["IDColorRopa"].ToString() == resultCambio[0]["IDColorRopa"].ToString() && resultNuevo[0]["id_tipoProducto"].ToString() == "1")
                            {
                                resultCambio[0]["cambiado"] = 1;
                                resultCambio[0]["cambios"] = returnCambio.cantidad;
                            }
                            else
                            {
                                if (resultNuevo[0]["IDProducto"].ToString() == resultCambio[0]["IDProducto"].ToString() && resultNuevo[0]["IDTallaRopa"].ToString() == resultCambio[0]["IDTallaRopa"].ToString() && resultNuevo[0]["IDColorRopa"].ToString() == resultCambio[0]["IDColorRopa"].ToString() && Convert.ToInt32(resultCambio[0]["cantidad_venta"].ToString()) == returnCambio.cantidad)
                                {
                                    resultCambio[0]["cambiado"] = 1;
                                    resultCambio[0]["cambios"] = Convert.ToInt32(resultCambio[0]["cambios"]) + returnCambio.cantidad;
                                }
                                else
                                {
                                    resultCambio[0]["subtotal"] = float.Parse(resultCambio[0]["subtotal"].ToString()) - (float.Parse(resultCambio[0]["subtotal"].ToString()) / Convert.ToInt32(resultCambio[0]["cantidad_venta"]) * returnCambio.cantidad);
                                    resultCambio[0]["total"] = float.Parse(resultCambio[0]["total"].ToString()) - (float.Parse(resultCambio[0]["total"].ToString()) / Convert.ToInt32(resultCambio[0]["cantidad_venta"]) * returnCambio.cantidad);
                                    resultCambio[0]["iva"] = float.Parse(resultCambio[0]["iva"].ToString()) - (float.Parse(resultCambio[0]["iva"].ToString()) / Convert.ToInt32(resultCambio[0]["cantidad_venta"]) * returnCambio.cantidad);
                                    resultCambio[0]["cantidad_venta"] = Convert.ToInt32(resultCambio[0]["cantidad_venta"]) - returnCambio.cantidad;
                                    if (Convert.ToInt32(resultCambio[0]["cantidad_venta"]) <= Convert.ToInt32(resultCambio[0]["cambios"]))
                                    {
                                        resultCambio[0]["cambiado"] = 1;
                                    }
                                    if (Convert.ToInt32(resultCambio[0]["cantidad_venta"]) == 0)
                                    {
                                        DataRow myRow = (this.ObtenerFilaSeleccionada()[0].DataBoundItem as DataRowView).Row;
                                        ventaProductoNueva.ventadetalle.Rows.Remove(myRow);
                                    }
                                    resultNuevo[0]["subtotal"] = (float.Parse(resultNuevo[0]["subtotal"].ToString()) / Convert.ToInt32(resultNuevo[0]["cantidad_venta"])) * (Convert.ToInt32(resultNuevo[0]["cantidad_venta"]) + returnCambio.cantidad);
                                    resultNuevo[0]["iva"] = (float.Parse(resultNuevo[0]["iva"].ToString()) / Convert.ToInt32(resultNuevo[0]["cantidad_venta"])) * (Convert.ToInt32(resultNuevo[0]["cantidad_venta"]) + returnCambio.cantidad);
                                    resultNuevo[0]["total"] = (float.Parse(resultNuevo[0]["total"].ToString()) / Convert.ToInt32(resultNuevo[0]["cantidad_venta"])) * (Convert.ToInt32(resultNuevo[0]["cantidad_venta"]) + returnCambio.cantidad);
                                    resultNuevo[0]["cantidad_venta"] = Convert.ToInt32(resultNuevo[0]["cantidad_venta"]) + returnCambio.cantidad;
                                    resultNuevo[0]["cambios"] = Convert.ToInt32(resultNuevo[0]["cambios"]) + returnCambio.cantidad;
                                    if (Convert.ToInt32(resultNuevo[0]["cantidad_venta"]) <= Convert.ToInt32(resultNuevo[0]["cambios"]))
                                    {
                                        resultNuevo[0]["cambiado"] = 1;
                                    }
                                }
                            }
                        }
                        cambio.datos.Rows.Add(returnCambio.id_cambio, infoVentaProductos.IDSucursal, Comun.id_caja, returnCambio.id_productoCambio, returnCambio.id_tallaRopaCambio, returnCambio.id_colorRopaCambio,
                            returnCambio.id_productoNuevo, returnCambio.id_tallaRopaNuevo, returnCambio.id_colorRopaNuevo, returnCambio.id_motivo, returnCambio.cantidad, returnCambio.observaciones);
                        if (granTotal <= decimal.Parse(ventaProductoNueva.ventadetalle.Compute("Sum(total)", "").ToString()))
                        {
                            this.txtTotal.Text = String.Format("{0:C2}", ventaProductoNueva.ventadetalle.Compute("Sum(total)", ""));
                            this.txtSubtotal.Text = String.Format("{0:C2}", ventaProductoNueva.ventadetalle.Compute("Sum(subtotal)", ""));
                            this.txtIva.Text = String.Format("{0:C2}", ventaProductoNueva.ventadetalle.Compute("Sum(iva)", ""));
                            this.txtDescuento.Text = String.Format("{0:C2}", ventaProductoNueva.ventadetalle.Compute("Sum(descuento)", ""));
                            txtCobroExtra.Text = String.Format("{0:C2}", (decimal.Parse(ventaProductoNueva.ventadetalle.Compute("Sum(total)", "").ToString()) - granTotal));
                        }
                    }
                    frmc.Dispose();
                    this.Visible = true;
                }
                else
                    MessageBox.Show(this, "El producto seleccionado acaba de ser cambiado", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCambioTicket ~ btn_Cambio_Click");
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
                LogError.AddExcFileTxt(ex, "frmCambioTicket ~ btnCancelar_Click");
            }
        }
        #endregion
    }
}
