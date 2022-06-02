using Componentes;
using PuntodeVentaTintoreria.ClaseAux;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TintoreriaGlobal;
using TintoreriaNegocio;

namespace PuntodeVentaTintoreria
{
    public partial class frmGridEntregas : Form
    {
        public frmGridEntregas()
        {
            InitializeComponent();
        }

        private void frmGridEntregas_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
        }

        private void chkVentaMovil_Load(object sender, EventArgs e)
        {

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFecha_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    try
                    {
                        FrmCambiarFechaTicket colorRopa = new FrmCambiarFechaTicket(this.ObtenerDatosGrid());
                        colorRopa.ShowDialog();
                        this.CargarGridBusqueda(txt_buscador.Text);
                        colorRopa.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavaderìa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogError.AddExcFileTxt(ex, "FrmGridEntregas ~ btnFecha_Click");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmGridEntregas ~ btnFecha_Click");
            }

        }

        private void btnUbicacion_Click(object sender, EventArgs e)
        {

            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    var oUbicacion = GridViewGeneral.CurrentRow.DataBoundItem;

                    DataRowView oDRView = GridViewGeneral.CurrentRow.DataBoundItem as DataRowView;

                    string idSucursal = oDRView.Row["id_sucursal"].ToString();
                    int idTipoServicio = int.Parse(oDRView.Row["id_tipoServicio"].ToString());
                    string id = oDRView.Row["id_ventaServicio"].ToString();
                    int id_ubicacionActual = int.Parse(oDRView.Row["id_ubicacion"].ToString());

                    this.Visible = false;
                    frmCambiarUbicacion frm = new frmCambiarUbicacion(idSucursal, idTipoServicio, id_ubicacionActual, id);
                    frm.ShowDialog();
                    frm.Dispose();
                    this.CargarGridBusqueda(txt_buscador.Text);
                    this.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmGridEntregas~ btnUbicacion_Click");
            }
        }


        private bool ValidarFilaSeleccionada(List<DataGridViewRow> rowSelected)
        {
            try
            {
                if (rowSelected.Count == 0)
                {
                    MessageBox.Show(this, "Debe seleccionar una fila del grid", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void txt_buscador_Click(object sender, EventArgs e)
        {
            try
            {
                this.txt_buscador.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmGridEntregas ~ txt_buscador_Click");
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.CargarGridBusqueda(txt_buscador.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmGridEntrega_Grid ~ btnBuscar_Click");
            }
        }


        private void CargarGridBusqueda(string buscador)
        {
            try
            {
                VentaProductos ventaProductos = new VentaProductos();
                VentaProductosNegocio ventaProductosNegocio = new VentaProductosNegocio();
                ventaProductos.conexion = Comun.conexion;
                ventaProductos.Folio = buscador;

                ventaProductos.NombreCliente = buscador;
                ventaProductos.IDSucursal = Comun.id_sucursal;
                ventaProductosNegocio.LLenarGridBusquedaFolioNombre(ventaProductos);
                this.GridViewGeneral.AutoGenerateColumns = false;
                this.GridViewGeneral.DataSource = ventaProductos.datos;
                ImagenGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }


        private List<DataGridViewRow> ObtenerFilaSeleccionada()
        {
            try
            {
                List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();


                foreach (DataGridViewRow row in GridViewGeneral.Rows)
                {
                    if (row.Selected)
                    {
                        rowSelected.Add(row);
                    }
                }


                return rowSelected;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void ImagenGrid()
        {


            foreach (DataGridViewRow Grid in this.GridViewGeneral.Rows)
            {
                if (Convert.ToInt32(Grid.Cells[0].Value) == 1)
                    Grid.Cells[1].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_ORANGE.png"), new Size(25, 25));
                else if (Convert.ToInt32(Grid.Cells[0].Value) == 2)
                    Grid.Cells[1].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_GREEN.png"), new Size(25, 25));
                else if (Convert.ToInt32(Grid.Cells[0].Value) == 3)
                    Grid.Cells[1].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_RED.png"), new Size(25, 25));
                else if (Convert.ToInt32(Grid.Cells[0].Value) == 4)
                    Grid.Cells[1].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_BLUE.png"), new Size(25, 25));
                else if (Convert.ToInt32(Grid.Cells[0].Value) == 5)
                    Grid.Cells[1].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_YELLOW.png"), new Size(25, 25));
            }


        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return new Bitmap(imgToResize, size);
        }

        private void pnlPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }
        private VentaProductos ObtenerDatosGrid()
        {
            try
            {
                VentaProductos venta = new VentaProductos();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    venta.IDVenta = row.Cells["id_ventaServicio"].Value.ToString();
                    venta.IDCliente = row.Cells["id_cliente"].Value.ToString();
                    venta.CantidadPrendas = row.Cells["Cantidad"].Value.ToString();
                    venta.IDSucursal = row.Cells["id_sucursal"].Value.ToString();
                    venta.HoraEntrega = row.Cells["horaEntrega"].Value.ToString();
                    venta.Usuins = row.Cells["cajero"].Value.ToString();
                    venta.IDStatus = Convert.ToInt32(row.Cells["id_statusServicio"].Value);
                    venta.Folio = row.Cells["folio"].Value.ToString();
                    venta.FecEntrega = Convert.ToDateTime(row.Cells["fechaEntrega"].Value);
                    venta.id_u = Comun.id_u;
                    venta.Pago = Convert.ToDecimal(row.Cells["pago"].Value.ToString());
                    venta.Total = Convert.ToDecimal(row.Cells["total"].Value.ToString());
                }
                return venta;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    try
                    {
                        FrmDetalleTintoteria colorRopa = new FrmDetalleTintoteria(this.ObtenerDatosGrid());
                        colorRopa.ShowDialog();
                        this.CargarGridBusqueda(txt_buscador.Text);
                        colorRopa.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LogError.AddExcFileTxt(ex, "frmGridEntregas ~ button35_Click");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmGridEntregas ~ btnModificar_Click");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txt_buscador.Text = "";
            this.GridViewGeneral.DataSource = "";
        }

        private void btnEntregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    DialogResult result = MessageBox.Show("¿Seguro que desea entregar esta venta?", "Entregar venta", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        TicketNegocio oNegocio = new TicketNegocio();
                        VentaProductos oVenta = this.ObtenerDatosGrid();
                        RespuestaSQL oRespuesta = oNegocio.Ticket_EntregarVentaServicio(oVenta.IDVenta, Comun.id_u);
                        MessageBox.Show(
                            oRespuesta.Mensaje,
                            Comun.NOMBRE_SISTEMA,
                            MessageBoxButtons.OK,
                            oRespuesta.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmGridEntregas ~ btnModificar_Click");
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    try
                    {
                        frm_CancelarVenta _cancelarVenta = new frm_CancelarVenta(this.ObtenerDatosGrid());

                        if (ObtenerDatosGrid().IDStatus != 3)
                        {
                            _cancelarVenta.ShowDialog();
                            this.CargarGridBusqueda(txt_buscador.Text);
                            _cancelarVenta.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("El registro seleccionado se encuentra cancelado", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavaderìa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    this.btnBuscar_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txt_buscador_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    this.btnBuscar_Click(sender, e);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void BtnTerminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    DialogResult result = MessageBox.Show("¿Ya ha terminado de hacer esta venta?", "Terminar venta", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        TicketNegocio oNegocio = new TicketNegocio();
                        VentaProductos oVenta = this.ObtenerDatosGrid();
                        RespuestaSQL oRespuesta = oNegocio.Ticket_TerminarVentaServicio(oVenta.IDVenta, Comun.id_u);
                        MessageBox.Show(
                            oRespuesta.Mensaje,
                            Comun.NOMBRE_SISTEMA,
                            MessageBoxButtons.OK,
                            oRespuesta.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmGridEntregas ~ btnModificar_Click");
            }
        }

        private void BtnPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    VentaProductos oVentaProducto = this.ObtenerDatosGrid();

                    Venta oVenta = new Venta();
                    TicketNegocio oNegocio = new TicketNegocio();

                    oVenta = oNegocio.Ticket_GetPagoPendiente(oVentaProducto.IDVenta);

                    if (!oVenta.Respuesta.Success)
                    {
                        MessageBox.Show(
                            oVenta.Respuesta.Mensaje,
                            Comun.NOMBRE_SISTEMA,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        return;
                    }

                    frm_Pagos frmPago = new frm_Pagos(oVenta.total, oVenta.Pagar, oVenta.Pendiente, oVenta.MonederoCliente, oVenta.cliente.nombreCompleto, oVenta.NuevoMonedero, 0);

                    frmPago.ShowDialog();

                    if (frmPago.DialogResult == DialogResult.OK)
                    {
                        VentaProductosNegocio vn = new VentaProductosNegocio();
                        ClienteNegocio cn = new ClienteNegocio();
                        VentaTintoreria ventaGlobal = new VentaTintoreria();

                        //hasta aqui se tiene todo los datos de la venta en memoria
                        ventaGlobal.PagoEfectivo = frmPago.getNewPagoEfectivo();
                        ventaGlobal.PagoMonedero = frmPago.getPagoMonedero();
                        ventaGlobal.PagoTarjeta = frmPago.getPagoTarjeta();
                        ventaGlobal.PagoTransferencia = frmPago.getPagoTransferencia();
                        ventaGlobal.Pago = ventaGlobal.PagoEfectivo + ventaGlobal.PagoMonedero + ventaGlobal.PagoTarjeta + ventaGlobal.PagoTransferencia;
                        ventaGlobal.Cambio = frmPago.getCambio();

                        if (ventaGlobal.PagoMonedero > 0 || ventaGlobal.PagoTarjeta > 0 || ventaGlobal.PagoTransferencia > 0)
                            ventaGlobal.banBloqueoMultipleFormasPago = true;

                        if (ventaGlobal.PagoMonedero > 0)
                            ventaGlobal.isMonedero = true;

                        ventaGlobal.Id_ventaServicio = oVentaProducto.IDVenta;
                        ventaGlobal.id_sucursal = Comun.id_sucursal;
                        ventaGlobal.Id_caja = Comun.id_caja;
                        ventaGlobal.Id_vendedor = Comun.id_u;
                        ventaGlobal.Id_cajero = Comun.id_u;
                        ventaGlobal.idCliente = oVentaProducto.IDCliente;
                        ventaGlobal.monedero = oVenta.NuevoMonedero;


                        ventaGlobal.DatosTarjeta = new DataTable();
                        ventaGlobal.DatosTarjeta.Columns.Add("autorizacion", typeof(string));
                        ventaGlobal.DatosTarjeta.Columns.Add("tipoDocumento", typeof(string));
                        ventaGlobal.DatosTarjeta.Columns.Add("folioDNI", typeof(string));
                        ventaGlobal.DatosTarjeta.Columns.Add("numTarjeta", typeof(string));
                        ventaGlobal.DatosTarjeta.Columns.Add("id_banco", typeof(int));
                        ventaGlobal.DatosTarjeta.Columns.Add("monto", typeof(float));
                        if (ventaGlobal.PagoTarjeta > 0)
                        {


                            if (frmPago.getDatosTarjeta() != null)
                            {
                                FormaPago DatosPagoTarjeta = frmPago.getDatosTarjeta();
                                ventaGlobal.DatosTarjeta.Rows.Add(
                                new Object[] {
                                DatosPagoTarjeta.autorizacion,
                                DatosPagoTarjeta.tipoDocumento != null ? DatosPagoTarjeta.tipoDocumento.id_tipoDocumento : string.Empty,
                                DatosPagoTarjeta.folioIFE,
                                DatosPagoTarjeta.numtarjeta,
                                DatosPagoTarjeta.banco != null ? DatosPagoTarjeta.banco.idBanco : 0,
                                DatosPagoTarjeta.monto});
                            }
                        }


                        ventaGlobal.DatosTransferencia = new DataTable();
                        ventaGlobal.DatosTransferencia.Columns.Add("autorizacion", typeof(string));
                        ventaGlobal.DatosTransferencia.Columns.Add("id_banco", typeof(int));
                        ventaGlobal.DatosTransferencia.Columns.Add("monto", typeof(float));
                        if (ventaGlobal.PagoTransferencia > 0)
                        {


                            if (frmPago.getDatosTransferencia() != null)
                            {
                                FormaPago DatosPagoTransferencia = frmPago.getDatosTransferencia();
                                ventaGlobal.DatosTransferencia.Rows.Add(
                                new Object[] {
                                DatosPagoTransferencia.autorizacion,
                                DatosPagoTransferencia.banco != null ? DatosPagoTransferencia.banco.idBanco : 0,
                                DatosPagoTransferencia.monto});
                            }
                        }
                        int Verificador = 0;

                        vn.AgregarPagoAVenta(ref Verificador, ref ventaGlobal);


                        try
                        {
                            HelperTicketCID.AbrirCajon();

                            HelperTicketCID.ImprimirTicket(ventaGlobal.Id_ventaServicio);

                            //TicketNegocio oNegocio = new TicketNegocio();
                            //VentaProductos oVenta = this.ObtenerDatosGrid();
                            //RespuestaSQL oRespuesta = oNegocio.Ticket_TerminarVentaServicio(oVenta.IDVenta, Comun.id_u);
                            //MessageBox.Show(
                            //    oRespuesta.Mensaje,
                            //    Comun.NOMBRE_SISTEMA,
                            //    MessageBoxButtons.OK,
                            //    oRespuesta.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error
                            //);

                            MessageBox.Show(this, "!!Venta exitosa!!!", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, "!!Venta exitosa!!! - No se pudo imprimir el Ticket. " + ex.Message, Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmGridEntregas ~ BtnPago_Click");
            }
        }
    }
}
