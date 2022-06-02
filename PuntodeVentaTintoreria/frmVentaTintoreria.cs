using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Componentes;
using TintoreriaNegocio;
using TintoreriaGlobal;
using System.IO;
using System.Globalization;
using PuntodeVentaTintoreria.ClaseAux;
using System.Drawing.Printing;
using Microsoft.Reporting.WinForms;

namespace PuntodeVentaTintoreria
{
    /*primero que nada se debe definir los tipo de entregar nomarl urgente, porq al capturar producto segun el tipo debera tener un precio*/
    /*Nota importante solo debe haber una caja por sucursal, ya que la unicacion se calciula en tiempo real en memoria*/
    /*para que haya mas de una caja debera controlar en disco la ubicacion*/
    /*hay una clave especial para producto general*/

    public partial class frmVentaTintoreria : Form
    {
        #region Variables
        VentaTintoreria ventaGlobal;
        private CultureInfo provider = CultureInfo.CurrentCulture;
        private int tipoEntrega;
        private int horasEntrega;
        private int RowIndex;
        private string claveSeleccionada;
        private int opcion;
        private decimal PrecioKgGlobal;
        private bool iconosdibujados;
        private decimal precioXRangoTiempo;
        private decimal porcentajeMonedero;
        private DataTable dtPrecioPorTipoRopa;
        //decimal monederoglobal = 0, subtotalglobal = 0, ivaglobal = 0, totalglobal = 0, descuentoglobal = 0;
        //int puntosglobal = 0, cantidadglobal = 0;

        #endregion

        #region Constructor

        public frmVentaTintoreria(int op)
        {
            InitializeComponent();
            this.precioXRangoTiempo = 0;
            this.porcentajeMonedero = 0;
            opcion = op;
            iconosdibujados = false;
            tipoEntrega = 1;
            RowIndex = 0;
            ConfiguracionInicial();
            CargarArticulos();
        }

        #endregion

        #region Eventos

        #region Eventos de control de Formulario

        protected virtual void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        protected virtual void BtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            ventaGlobal = null;
            this.Close();
        }

        #endregion

        #region Eventos de control de Tiempos de entrega

        private void BtnCambioEntegaA_Click(object sender, EventArgs e)
        {
            if (tipoEntrega > 1)
            {
                tipoEntrega--;

                MostrarEntrega();
            }
        }

        private void BtnCambioEntegaS_Click(object sender, EventArgs e)
        {
            if (tipoEntrega < Comun.EntregasRopa.Rows.Count)
            {
                tipoEntrega++;
                MostrarEntrega();
            }
        }


        #endregion

        #endregion

        private void CrearCargoGenerico(string nombre, decimal preciop, string cometarios, string clavegrupo, string claveprod, string descripcion)
        {
            try
            {
                //se crea un registro de ropa, dentro de la clase venta. Se calcula segun los precios actuales.
                DataRow datos = ventaGlobal.tablaRopaServicio.NewRow();

                DateTime fecha = DateTime.Now;

                datos["idTemp"] = fecha.Day.ToString() + fecha.Month.ToString() + fecha.Year.ToString() + fecha.Hour.ToString() + fecha.Minute.ToString() + fecha.Second.ToString();
                datos["id_grupo"] = clavegrupo; // 10000
                datos["id_tiporopa"] = clavegrupo; //10000
                datos["id_ropa"] = claveprod; //"PGeneral1000";
                datos["id_color"] = "0";
                datos["id_fibra"] = "0";
                datos["id_estampado"] = "0";
                datos["comentarios"] = cometarios;
                datos["nombreTemporal"] = nombre;
                datos["nombrePrenda"] = nombre;
                datos["descripcionPrenda"] = descripcion;//"Otros Cargos";
                datos["cantidad_venta"] = "1";
                datos["descuento"] = "0";

                //datos["productoDisponible"] = "1";

                decimal precio = preciop;
                int puntos = 0;
                decimal porcentajemonedero = 0;

                if (opcion == 1)
                {
                    porcentajemonedero = Comun.MonederoRopa["10000" + ventaGlobal.Id_tipocredencial.ToString()];
                    puntos = Comun.PtosRopa["10000" + ventaGlobal.Id_tipocredencial.ToString()];
                }
                else
                if (opcion == 2)
                {
                    porcentajemonedero = Comun.MonederoRopa["10001" + ventaGlobal.Id_tipocredencial.ToString()];
                    puntos = Comun.PtosRopa["10001" + ventaGlobal.Id_tipocredencial.ToString()];
                }

                decimal monederonuevo = precio * (porcentajemonedero / 100);
                datos["precio"] = precio;
                datos["subtotal"] = precio;
                datos["total"] = precio;

                datos["monedero"] = monederonuevo;
                datos["puntos"] = puntos;
                datos["simbolosLavado"] = "";
                //falta cargar ubicacion
                datos["idubicacion"] = "0";
                datos["ubicacion"] = "S/N";
                ventaGlobal.tablaRopaServicio.Rows.Add(datos);
                dgwDatosVenta.DataSource = ventaGlobal.tablaRopaServicio;
                MostrarDatosTotales();
            }
            catch (Exception) { }
        }

        private void ArticuloEvento_Click(object sender, EventArgs e)
        {
            Articulo prenda = (Articulo)sender;
            panelDatosGen02.Visible = false;
            frmSelSubTipoPrenda frmst = new frmSelSubTipoPrenda(prenda.CveArticulo, prenda.NombreArticulo);
            if (frmst.ShowDialog() == DialogResult.OK)
            {
                //se crea un registro de ropa, dentro de la clase venta. Se calcula segun los precios actuales.
                DataRow datos = ventaGlobal.tablaRopaServicio.NewRow();
                DateTime fecha = DateTime.Now;
                datos["idTemp"]=fecha.Day.ToString()+fecha.Month.ToString()+fecha.Year.ToString()+fecha.Hour.ToString()+fecha.Minute.ToString()+fecha.Second.ToString();
                datos["id_grupo"] = frmst.Idgrupo.Trim();
                datos["id_tiporopa"] = prenda.CveArticulo.Trim();
                datos["id_ropa"] = frmst.Clavetipo.Trim();
                datos["id_color"] = frmst.ClaveColor;
                datos["id_fibra"] = frmst.ClaveFibra;
                datos["id_estampado"] = frmst.ClaveEstampado;
                datos["comentarios"] = frmst.Comentarioprenda;
                datos["nombreTemporal"] = prenda.NombreArticulo;                
                datos["nombrePrenda"] = prenda.NombreArticulo + "-" + frmst.Nombresubtipo;
                datos["descripcionPrenda"] = frmst.Descripcionprenda;
                datos["cantidad_venta"] = "1";
                datos["idvale"] = "";
                datos["descuento"] = "0";

                decimal precio = 0;
                int idTipoRopa = 0;
                int.TryParse(prenda.CveArticulo.Trim(), out idTipoRopa);
                precio = GetPrecio(idTipoRopa);
                decimal porcentajemonedero = this.porcentajeMonedero;//Comun.MonederoRopa[frmst.Idgrupo + ventaGlobal.Id_tipocredencial.ToString()];
                int puntos = Comun.PtosRopa[frmst.Idgrupo + ventaGlobal.Id_tipocredencial.ToString()];
                decimal monederonuevo = precio * (porcentajemonedero / 100);

                if (opcion == 2)
                { // es lavanderia
                    if (!frmst.Cobro)
                    {
                        precio = 0;
                    }
                }

                datos["precio"] = precio;
                datos["subtotal"] = precio;
                datos["total"] = precio;

                datos["monedero"] = monederonuevo;
                datos["puntos"] = puntos;
                
                datos["simbolosLavado"] = "";

                if (opcion == 1)
                {
                    frmSelDatosPrenda frmdp = new frmSelDatosPrenda(datos["nombrePrenda"].ToString(), "");
                    if (frmdp.ShowDialog() == DialogResult.OK)
                    {
                        datos["simbolosLavado"] = frmdp.ListaXml;
                    }
                    frmdp.Dispose();
                }

                string id="", ubi="S/N";
                
                AgregarUbicacion(ref id, ref ubi);
                datos["idubicacion"] = id;
                datos["ubicacion"] = ubi;

                ventaGlobal.tablaRopaServicio.Rows.Add(datos);
            }
            frmst.Dispose();
            dgwDatosVenta.DataSource = ventaGlobal.tablaRopaServicio;
            MostrarDatosTotales();
        }
        private decimal GetPrecio(int tipoRopa = 0)
        {
            decimal precio = 0;
            if(this.opcion == 1)
            {
                DataRow[] result = this.dtPrecioPorTipoRopa.Select("id_tipoRopa = '" + tipoRopa + "' AND id_tipoEntrega = '" + this.tipoEntrega + "'");
                foreach (DataRow row in result)
                {
                    precio = Convert.ToDecimal(row["precio"]);
                }
            }
            else
            {
                precio = this.precioXRangoTiempo;
            }
            
            return precio;
        }
        private void AgregarUbicacion(ref string id, ref string val)
        {
            try
            {
                VentaTintoreriaNegocio neg = new VentaTintoreriaNegocio();
                neg.ObtenerUbicaciones(Comun.id_sucursal,1,ref id, ref val);
            }
            catch (Exception) { }
        }

        private void EsGratisEvento_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloV4 a = (ArticuloV4)sender;
                if (ventaGlobal.isGratis == false)
                {
                    if (MessageBox.Show("¿Se aplicará la promoción VENTA GRATIS?", "CSL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ventaGlobal.isGratis = true;
                        a._isCheck = false;
                    }
                    else
                        a._isCheck = true;
                }
                else
                {
                    if (MessageBox.Show("¿Está seguro de cancelar VENTA GRATIS?", "CSL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ventaGlobal.isGratis = false;
                        a._isCheck = true;
                    }
                    else
                        a._isCheck = false;
                }
            }
            catch (Exception) { }
        }

        private void Aplicar3X1Evento_Click(object sender, EventArgs e)
        {
            try
            {

                ArticuloV4 a = (ArticuloV4)sender;


                if (ventaGlobal.aplicar3X1 == false)
                {
                    if (MessageBox.Show("¿Se aplicará la promoción 3X1?", "CSL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ventaGlobal.aplicar3X1 = true;
                        a._isCheck = false;



                        //aplicar vale
                    }
                    else
                        a._isCheck = true;

                }
                else
                {

                    if (MessageBox.Show("¿Está seguro de cancelar promoción 3X1?", "CSL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ventaGlobal.aplicar3X1 = false;
                        a._isCheck = true;
                    }
                    else
                        a._isCheck = false;

                }




            }
            catch (Exception)
            {


            }

        }
        
        private void ArticuloV3Evento_Click(object sender, EventArgs e)
        {
            try
            {
                
                ArticuloV4 a = (ArticuloV4)sender;

                if (ventaGlobal.IdformaEntrega == 1)
                {
                    frm_PedirChoferes frmchof = new frm_PedirChoferes();
                    if (frmchof.ShowDialog() == DialogResult.OK)
                    {

                        ventaGlobal.UsuChofer = frmchof.iddato;
                        ventaGlobal.IdformaEntrega = 2;
                        a._isCheck = false;
                    }
                    else
                        a._isCheck = true;

                    frmchof.Dispose();
                }
                else
                {

                    if (MessageBox.Show("¿Esta seguro de regresar el ticket a VENTA EN SUCURSAL?", "CSL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ventaGlobal.UsuChofer = "";
                        ventaGlobal.IdformaEntrega = 1;
                        a._isCheck = true;
                    }
                    else
                        a._isCheck = false;

                }
                
                

                
            }
            catch (Exception)
            {

                
            }
           
        }

        private void ArticuloV32Evento_Click(object sender, EventArgs e)
        {
            try
            {

                ArticuloV4 a = (ArticuloV4)sender;

                if (ventaGlobal.isReproceso == false)
                {
                    if (MessageBox.Show("¿Si presiona OK el ticket será un trabajo de REPROCESO y no habrá cobro?", "CSL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {


                        ventaGlobal.isReproceso = true;
                        a._isCheck = false;
                    }
                    else
                        a._isCheck = true;


                }
                else
                {

                    if (MessageBox.Show("¿Si preciona OK el ticket sera un trabajo NORMAL y se cobrará?", "CSL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ventaGlobal.isReproceso = false;
                        a._isCheck = true;
                    }
                    else
                        a._isCheck = false;

                }




            }
            catch (Exception)
            {


            }

        }

        #region Metodos
        private int validarVenta()
        {
            try
            {
                float montototal = 0;
                
                //Hay productos
                if (ventaGlobal.tablaRopaServicio.Rows.Count <= 0)
                {
                    return 9;
                }

                //el total es convertido
                if (!float.TryParse(this.txtTotal.Text, NumberStyles.Currency, provider, out montototal))
                {
                    this.txtTotal.Focus();
                    return 3;
                }

                //hay cliente
                if (string.IsNullOrEmpty(ventaGlobal.idCliente))
                    return 10;

                //el monto a pagar es menor q cero
                if (montototal < 0)
                {
                    return 8;
                }
                else
                if(montototal == 0)
                {
                    return 11;
                }

                if (ventaGlobal.vale == null)
                {
                    ventaGlobal.vale = new Vales();
                    ventaGlobal.vale.IDVale = "";
                    ventaGlobal.vale.Folio = "";
                    ventaGlobal.vale.IDTipoVale = 0;
                    ventaGlobal.vale.Nombre = "";
                    ventaGlobal.vale.DescuentoTotalVale = 0;

                }

                return 1000;
            }
            catch (Exception )
            {
                return 0;
            }
        }

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

        private void LimpiarVentaProductos()
        {
            try
            {
                this.txtSubtotal.Text = string.Format("{0:F2}", 0);
                this.txtIva.Text = string.Format("{0:F2}", 0);
                this.txtDescuento.Text = string.Format("{0:F2}", 0);
                this.txtMonedero.Text = string.Format("{0:F2}", 0);
                this.txtTotal.Text = string.Format("{0:F2}", 0);
                this.txtCliente.Text = "";
                this.txtnomCliente.Text = "";
                this.txtMonederoCliente.Text = string.Format("{0:F2}", 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void QuitarVenta(TabPage tab)
        {
            /*try
            {
                foreach (Venta venta in ventasPendientes)
                {
                    if (tab.Name == venta.id_ventaTemporal)
                    {
                        this.ventasPendientes.Remove(venta);
                        this.tabControl1.TabPages.Remove(tab);
                        break;
                    }
                }
                if (ventasPendientes.Count == 0)
                {
                    VentaProductos nuevaVenta = AgregarVentaPendienteNueva();
                    Venta ventaPend = new Venta();
                    ventaPend.id_ventaTemporal = nuevaVenta.IDVenta;
                    ventaPend.textTab = nuevaVenta.nameTab;
                    ventaPend.cliente = new Cliente();
                    ventaPend.cliente.id_cliente = nuevaVenta.IDCliente;
                    ventaPend.idCliente = nuevaVenta.IDCliente;
                    ventaPend.vale = new Vales();
                    ventasPendientes.Add(ventaPend);
                    AgregarTabVenta(nuevaVenta);
                    nuevaVenta.StrCnx = Comun.conexion;
                    this.MostrarDatosCliente(nuevaVenta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }*/
        }

        private void MensajeErrorPago(int i)
        {
            try
            {
                string mensaje = "";
                switch (i)
                {
                    case 2:
                        mensaje = "El pago no cubre el total";
                        break;
                    case 1:
                        mensaje = "No cuenta con suficiente monedero";
                        break;
                    case 3:
                        mensaje = "Dato no válido en el total de venta";
                        break;
                    case 8:
                    case 11:
                        mensaje = "El total no puede ser negativo o cero. Revise la venta.";
                        break;
                    case 9:
                        mensaje = "No hay productos en la venta";
                        break;
                    case 10:
                        mensaje = "Introduzca un cliente";
                        break;
                    case 15:
                        mensaje ="El peso en Kilogramos a cobrar debe ser mayor a cero";
                        break;
                    default:
                        mensaje = "Ocurrió un error. Comuníquese a Soporte.";
                        break;
                }
                MessageBox.Show(this, mensaje, "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void VenderPagoCompleto(int opcion)
        {
            try
            {
                int Verificador = -1;
                int aux = this.validarVenta();

                if (aux == 1000)
                {
                    frm_Pagos frmC = new frm_Pagos(decimal.Parse(this.txtTotal.Text, NumberStyles.Currency), decimal.Parse(this.txtTotal.Text, NumberStyles.Currency), 0, decimal.Parse(this.txtMonederoCliente.Text, NumberStyles.Currency), this.txtnomCliente.Text, decimal.Parse(this.txtMonedero.Text, NumberStyles.Currency),opcion);
                    frmC.ShowDialog();

                    if (frmC.DialogResult == DialogResult.OK)
                    {
                        VentaProductosNegocio vn = new VentaProductosNegocio();
                        ClienteNegocio cn = new ClienteNegocio();

                        //hasta aqui se tiene todo los datos de la venta en memoria
                        ventaGlobal.PagoEfectivo = frmC.getPagoEfectivo();
                        ventaGlobal.PagoMonedero = frmC.getPagoMonedero();
                        ventaGlobal.PagoTarjeta = frmC.getPagoTarjeta();
                        ventaGlobal.PagoTransferencia = frmC.getPagoTransferencia();
                        ventaGlobal.Pago = ventaGlobal.PagoEfectivo + ventaGlobal.PagoMonedero + ventaGlobal.PagoTarjeta + ventaGlobal.PagoTransferencia;
                        ventaGlobal.Cambio = frmC.getCambio();

                        if (ventaGlobal.PagoMonedero > 0 || ventaGlobal.PagoTarjeta > 0 || ventaGlobal.PagoTransferencia > 0)
                            ventaGlobal.banBloqueoMultipleFormasPago = true;

                        if (ventaGlobal.PagoMonedero > 0 )
                            ventaGlobal.isMonedero = true;

                        ventaGlobal.Id_statusServicio = 2;
                        ventaGlobal.id_sucursal = Comun.id_sucursal;
                        //ventaGlobal.idCliente = cliente.id_cliente;
                        ventaGlobal.Id_caja = Comun.id_caja;
                        ventaGlobal.Id_vendedor = Comun.id_u;
                        ventaGlobal.Id_cajero = Comun.id_u;

                        // ventaGlobal.monedero = float.Parse(ventaGlobal.monedero, NumberStyles.Currency);
                        //ventaGlobal.puntos = int.Parse(this.txtPuntos.Text, NumberStyles.Currency);

                        ventaGlobal.DatosTarjeta = new DataTable();
                        ventaGlobal.DatosTarjeta.Columns.Add("autorizacion", typeof(string));
                        ventaGlobal.DatosTarjeta.Columns.Add("tipoDocumento", typeof(string));
                        ventaGlobal.DatosTarjeta.Columns.Add("folioDNI", typeof(string));
                        ventaGlobal.DatosTarjeta.Columns.Add("numTarjeta", typeof(string));
                        ventaGlobal.DatosTarjeta.Columns.Add("id_banco", typeof(int));
                        ventaGlobal.DatosTarjeta.Columns.Add("monto", typeof(float));
                        if (ventaGlobal.PagoTarjeta > 0)
                        {
                                       

                            if (frmC.getDatosTarjeta() != null)
                            {
                                FormaPago DatosPagoTarjeta = frmC.getDatosTarjeta();
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
                                    

                            if (frmC.getDatosTransferencia() != null)
                            {
                                FormaPago DatosPagoTransferencia = frmC.getDatosTransferencia();
                                    ventaGlobal.DatosTransferencia.Rows.Add(
                                    new Object[] {
                                DatosPagoTransferencia.autorizacion,
                                DatosPagoTransferencia.banco != null ? DatosPagoTransferencia.banco.idBanco : 0,
                                DatosPagoTransferencia.monto});
                            }
                        }
                        vn.InsertarPrendasTintoreria(ref Verificador, ref ventaGlobal);

                        try
                        {
                            this.AbrirCajon();
                            VentaProductos oVentaProducto = new VentaProductos();
                            oVentaProducto.IDVenta = ventaGlobal.Id_ventaServicio;
                            oVentaProducto.IDSucursal = ventaGlobal.id_sucursal;
                            oVentaProducto.IDTipoVenta = ventaGlobal.Id_tipoServicio;

                            this.ImprimirTicket(ventaGlobal.Id_ventaServicio);
                            
                            MessageBox.Show(this, "!!Venta exitosa!!!", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, "!!Venta exitosa!!! - No se pudo imprimir el Ticket. " + ex.Message, "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        finally
                        {
                            this.LimpiarVentaProductos();
                            this.QuitarVenta(this.tabControl1.SelectedTab);
                            this.Close();
                        }
                    }
                }
                else
                {
                    this.MensajeErrorPago(aux);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        public void ImprimirTicket(string idVenta)
        {
            List<TicketDetalle> listaDetalle = new List<TicketDetalle>();
            VentaTintoreriaNegocio oNegocio = new VentaTintoreriaNegocio();
            LocalReport Rtp = new LocalReport();

            //listaDetalle = oNegocio.GetListaTicketDetalles(idVenta);
            TicketDetalle ticket = new TicketDetalle
            {
                Cantidad = 1,
                Descripcion = "Prueba",
                Descuento = 0,
                Impuesto = 1,
                PrecioUnitario = 20,
                Subtotal = 20,
                Total = 21
            };

            for (int i = 0; i < 21; i++)
            {
                listaDetalle.Add(ticket);
            }
            

            Rtp.EnableExternalImages = true;
            Rtp.DataSources.Clear();
            string path = Path.Combine(Application.StartupPath, @"Formatos\Ticket.rdlc");
            if (System.IO.File.Exists(path))
            {
                Rtp.ReportPath = path;
            }
            else
            {
                new Exception("No se encontro el formato del ticket, contacte a soporte técnico.");
            }

            ReportParameter[] Parametros = new ReportParameter[8];
            Parametros[0] = new ReportParameter("LogoEmpresa", HelperImgCID.IMAGEN_DEFAULT_BASE64);
            Parametros[1] = new ReportParameter("NombreEmpresa", "Empresa S.A de C.V. de S.L.");
            Parametros[2] = new ReportParameter("Direccion", "Palenque 490 col. centenario tuchtlan");
            Parametros[3] = new ReportParameter("RFC", "GAGF900731KFJ");
            Parametros[4] = new ReportParameter("NumTicket", "12320190507000000030");
            Parametros[5] = new ReportParameter("Mensaje1", "Mensaje1");
            Parametros[6] = new ReportParameter("Mensaje2", "Mensaje2");
            Parametros[7] = new ReportParameter("Mensaje3", "Mensaje3");

            Rtp.SetParameters(Parametros);
            Rtp.DataSources.Add(new ReportDataSource("Detalles", listaDetalle));
            Impresor imp = new Impresor();
            imp.Imprime(Rtp);//llamo a la función e creedme imprime de fabula.
        }

        private void VenderSinPagoInicial()
        {
            try
            {
                int Verificador = -1;

               



                    VentaProductosNegocio vn = new VentaProductosNegocio();


                   // ClienteNegocio cn = new ClienteNegocio();

                    

                    ventaGlobal.PagoEfectivo = 0;
                    ventaGlobal.PagoMonedero = 0;
                    ventaGlobal.PagoTarjeta = 0;
                    ventaGlobal.PagoTransferencia = 0;
                    ventaGlobal.Pago = 0;
                    ventaGlobal.Cambio = 0;
                    ventaGlobal.banBloqueoMultipleFormasPago = false;
                    ventaGlobal.isMonedero = false;
                    ventaGlobal.Id_statusServicio = 2;
                    ventaGlobal.id_sucursal = Comun.id_sucursal;
                    //ventaGlobal.idCliente = cliente.id_cliente;
                    ventaGlobal.Id_caja = Comun.id_caja;
                    ventaGlobal.Id_vendedor = Comun.id_u;
                    ventaGlobal.Id_cajero = Comun.id_u;
                    ventaGlobal.DatosTarjeta = new DataTable();
                    ventaGlobal.DatosTransferencia = new DataTable();
                //crear formato de tablas
                ventaGlobal.DatosTarjeta.Columns.Add("autorizacion", typeof(string));
                ventaGlobal.DatosTarjeta.Columns.Add("tipoDocumento", typeof(string));
                ventaGlobal.DatosTarjeta.Columns.Add("folioDNI", typeof(string));
                ventaGlobal.DatosTarjeta.Columns.Add("numTarjeta", typeof(string));
                ventaGlobal.DatosTarjeta.Columns.Add("id_banco", typeof(int));
                ventaGlobal.DatosTarjeta.Columns.Add("monto", typeof(float));

                ventaGlobal.DatosTransferencia.Columns.Add("autorizacion", typeof(string));
                ventaGlobal.DatosTransferencia.Columns.Add("id_banco", typeof(int));
                ventaGlobal.DatosTransferencia.Columns.Add("monto", typeof(float));


                



                vn.InsertarPrendasTintoreria(ref Verificador, ref ventaGlobal);

                        try
                        {
                            this.AbrirCajon();
                            //  Ticket_Impresion impresion = new Ticket_Impresion(1, ventaProductos);
                            //  impresion.imprimirTicket();
                            MessageBox.Show(this, "!!Venta exitosa!!!", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(this, "!!Venta exitosa!!! - No se pudo imprimir el Ticket. " + ex.Message, "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        finally
                        {
                            this.LimpiarVentaProductos();
                            this.QuitarVenta(this.tabControl1.SelectedTab);
                            ventaGlobal = null;
                            this.Close();
                         }

               

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void VenderSinCosto(int opcion)
        {
            try
            {
                int Verificador = -1;

                int aux = this.validarVenta();
                if (aux == 1000)
                {



                    VentaProductosNegocio vn = new VentaProductosNegocio();
                   ClienteNegocio cn = new ClienteNegocio();



                    ventaGlobal.PagoEfectivo = 0;
                    ventaGlobal.PagoMonedero = 0;
                    ventaGlobal.PagoTarjeta = 0;
                    ventaGlobal.PagoTransferencia = 0;
                    ventaGlobal.Pago = 0;
                    ventaGlobal.Cambio = 0;
                    ventaGlobal.banBloqueoMultipleFormasPago = false;
                    ventaGlobal.isMonedero = false;
                    ventaGlobal.Id_statusServicio = 2;
                    ventaGlobal.id_sucursal = Comun.id_sucursal;
                   // ventaGlobal.idCliente = cliente.id_cliente;
                    ventaGlobal.Id_caja = Comun.id_caja;
                    ventaGlobal.Id_vendedor = Comun.id_u;
                    ventaGlobal.Id_cajero = Comun.id_u;
                    ventaGlobal.DatosTarjeta = null;
                    ventaGlobal.DatosTransferencia = null;
                    ventaGlobal.total = 0;

                    if (opcion == 1)
                    {
                        ventaGlobal.isGratis = false;
                        ventaGlobal.isReproceso = true;
                    }
                    else
                    {
                        ventaGlobal.isGratis = true;
                        ventaGlobal.isReproceso = false;
                    }

                    vn.InsertarPrendasTintoreria(ref Verificador, ref ventaGlobal);

                    try
                    {
                        this.AbrirCajon();
                        //  Ticket_Impresion impresion = new Ticket_Impresion(1, ventaProductos);
                        //  impresion.imprimirTicket();
                        MessageBox.Show(this, "!!Venta exitosa!!!", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, "!!Venta exitosa!!! - No se pudo imprimir el Ticket. " + ex.Message, "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    finally
                    {
                        this.LimpiarVentaProductos();
                        this.QuitarVenta(this.tabControl1.SelectedTab);

                        this.Close();
                    }

                }
                else
                {
                    this.MensajeErrorPago(aux);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        
        private void ObtenerVale(string codigovale)
        {
            try
            {
            
                if (ventaGlobal.vale == null)
                {
                    Vales_Negocio vale_negocio = new Vales_Negocio();
                    
                    if (codigovale != "")
                    {
                        Venta ventaAux = new Venta();
                        ventaAux.vale = new Vales { Conexion = Comun.conexion, Folio = codigovale };
                        ventaAux.vale.TablaDatos = new DataTable();
                        ventaAux.vale.TablaDatos.Columns.Add("id_venta", typeof(string));
                        ventaAux.vale.TablaDatos.Columns.Add("id_sucursal", typeof(string));
                        ventaAux.vale.TablaDatos.Columns.Add("id_producto", typeof(string));
                        ventaAux.vale.TablaDatos.Columns.Add("id_tallaRopa", typeof(string));
                        ventaAux.vale.TablaDatos.Columns.Add("id_colorRopa", typeof(string));
                        ventaAux.vale.TablaDatos.Columns.Add("id_ventaDetalle", typeof(string));
                        ventaAux.vale.TablaDatos.Columns.Add("descuento", typeof(float));
                        
                        vale_negocio.ConsultaVale(ventaAux);
                        

                        if (ventaAux.vale.IDVale != null)
                        {
                            if (ventaGlobal.tablaRopaServicio.Rows.Count != 0)
                            {

                                ventaGlobal.vale = ventaAux.vale;
                                MostrarDatosTotales();
                                MessageBox.Show(this, "Vale aplicado correctamente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                                MessageBox.Show(this, "No hay prendas capturadas, no se puede aplicar el vale", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                           
                            MessageBox.Show(this, "Vale no encontrado, revise el codigo e intente de nuevo", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                    MessageBox.Show(this, "Esta venta ya tiene un vale aplicado", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void MostrarDatosTotales()
        {
            try
            {
                dgwDatosVenta.DataSource = ventaGlobal.tablaRopaServicio;
                if (ventaGlobal.tablaRopaServicio.Rows.Count > 0)
                {
                    decimal subtotal = 0, iva = 0, total = 0, descuento = 0;
                    int puntos = 0, cantidad = 0;
                    foreach (DataRow item in ventaGlobal.tablaRopaServicio.Rows)
                    {
                        subtotal += Convert.ToDecimal(item["subtotal"].ToString());
                        total += Convert.ToDecimal(item["total"].ToString());
                        descuento += Convert.ToDecimal(item["descuento"].ToString());
                        puntos += Convert.ToInt32(item["puntos"].ToString());
                        if (item["id_ropa"].ToString().Trim() != "PGeneral1000" && item["id_ropa"].ToString().Trim() != "PGeneral1001")
                            cantidad += Convert.ToInt32(item["cantidad_venta"].ToString());
                    }

                    ventaGlobal.monedero = total*(this.porcentajeMonedero/100);
                    ventaGlobal.subTotal = (float)subtotal;
                    iva = (subtotal * (Comun.iva / 100));
                    ventaGlobal.descuento = (float)descuento;
                    ventaGlobal.puntos = puntos;
                    ventaGlobal.Cantidadprendas = cantidad;
                    ventaGlobal.iva = (float)iva;
                    
                    if (ventaGlobal.vale != null)
                    {
                        int banVale = 0;
                        switch (ventaGlobal.vale.IDTipoVale)
                        {
                            case 1: //Vales porcentaje de descuento, se aplica al monto general, no por producto.


                                ventaGlobal.descuentoGeneral += ((ventaGlobal.subTotal) * (float)(ventaGlobal.vale.Porcentaje / 100));
                                break;
                            case 2:
                                ventaGlobal.descuentoGeneral += (float)ventaGlobal.vale.Monto;
                                break;
                            case 3:
                                //MessageBox.Show(this, "Vale No Disponibles por el momento", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                int cantidadRopa = 0;
                                
                                //foreach (VentaProductos ventaProductoAux in ventaGlobal.tablaRopaServicio.Rows)
                                //{
                                //    if (ventaProductoAux.IDProducto == ventaGlobal.vale.ProductoRequerido.id_producto)
                                //    {
                                //        banVale = 1;
                                //        if (ventaProductoAux.CantidadVenta >= (int)ventaGlobal.vale.CantidadRequeridaNxN)
                                //        {
                                //            banVale = 2;
                                //            break;
                                //        }
                                //    }
                                //}
                                //if (banVale == 2)
                                //{
                                //    foreach (VentaProductos ventaProductoAux in ventaGlobal.productosVenta)
                                //    {
                                //        if (ventaProductoAux.IDProducto == ventaGlobal.vale.ProductoRequerido.id_producto)
                                //        {
                                //            ventaGlobal.descuento = (ventaGlobal.vale.CantidadGratisNxN * ventaProductoAux.Precio);
                                //            ventaProductoAux.Descuento = ventaGlobal.descuento;
                                //            ventaGlobal.vale.DescuentoTotalVale = ventaProductoAux.Descuento;
                                //            ventaGlobal.vale.TablaDatos.Rows.Add(new Object[] {
                                //                        ventavale.id_ventaTemporal,
                                //                        Comun.id_sucursal,
                                //                        ventaProductoAux.IDProducto,
                                //                        ventaProductoAux.IDTallaRopa,
                                //                        ventaProductoAux.IDColorRopa,
                                //                        ventaProductoAux.IDVentadetalle,
                                //                        ventaProductoAux.Descuento
                                //                    });
                                //            break;
                                //        }
                                //    }
                                //}
                                //else
                                //    ventaGlobal.vale = new Vales();
                                this.txtDescuentoVale.Text = string.Format("{0:F2}", ventaGlobal.vale.DescuentoTotalVale);
                                if (banVale == 0)
                                    MessageBox.Show(this, "Revisar las condiciones para aplicar el vale, no existe el producto requerido", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else if (banVale == 1)
                                    MessageBox.Show(this, "Revisar las condiciones para aplicar el vale, no existe la cantidad minima del producto requerido", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                else if (banVale == 2)
                                {
                                    ventaGlobal.vale.Conexion = Comun.conexion;
                                    ventaGlobal.id_sucursal = Comun.id_sucursal;
                                    //vale_negocio.ModificarDescuentoVentaDetalle(ref Verificador, ref ventaAux);
                                    ventaGlobal.vale = ventaGlobal.vale;
                                    MessageBox.Show(this, "Vale Aplicado Correctamente", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                break;
                            case 4:
                                MessageBox.Show(this, "Vale No Disponibles por el momento", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                break;
                        }

                        linkDelVale.Visible = true;
                        txtValeaplicado.Visible = true;
                        txtValeaplicado.Text = ventaGlobal.vale.Nombre;

                    }
                    else
                        ventaGlobal.descuentoGeneral = 0;

                    ventaGlobal.total = (ventaGlobal.subTotal) - (ventaGlobal.descuento + ventaGlobal.descuentoGeneral);
                    if (ventaGlobal.total < 0) ventaGlobal.total = 0;

                    txtMonedero.Text = string.Format("{0:C2}", ventaGlobal.monedero);
                    txtSubtotal.Text = string.Format("{0:C2}", ventaGlobal.subTotal);
                    txtDescuentoVale.Text = string.Format("{0:F2}", ventaGlobal.descuentoGeneral);
                    txtDescuento.Text = string.Format("{0:C2}", ventaGlobal.descuento);
                    txtIva.Text = string.Format("{0:C2}", ventaGlobal.iva);
                    txtTotal.Text = string.Format("{0:C2}", ventaGlobal.total);

                    txtCantidadPrenda.Text = ventaGlobal.Cantidadprendas.ToString();
                }
            }
            catch (Exception)
            {

              
            }
        }

        private void ConfiguracionInicial()
        {
            try
            {
                //CrearVenta En Memoria
                ventaGlobal = new VentaTintoreria();
                               
                //colocar Datos Iniciales de la Venta;
                ventaGlobal.bandPrecioMayoreo = false;
                ventaGlobal.Cambio = 0;
                ventaGlobal.Cantidadprendas = 0;
                ventaGlobal.cliente=null;
                ventaGlobal.Comentarios = "";
                ventaGlobal.descuento = 0;
                ventaGlobal.Entregado = false;
                ventaGlobal.EsApp = false;
                ventaGlobal.EsWeb = false;
                ventaGlobal.FechaEntrega = DateTime.Now;
                ventaGlobal.FechaRecargo = DateTime.Now;
                ventaGlobal.FecTerminado = DateTime.Now;
                ventaGlobal.isGratis = false;
                ventaGlobal.aplicar3X1 = false;
                ventaGlobal.Fec_ventaServicio = DateTime.Now;
                ventaGlobal.Folio = "";
                ventaGlobal.HoraEntrega = "";

                //tipo de entrega
                ventaGlobal.Hor_ventaServicio = "";
                ventaGlobal.idCliente = "";
                ventaGlobal.IdformaEntrega = 1;
                ventaGlobal.IdTipoEntrega = 1;
                ventaGlobal.Id_caja = "";
                ventaGlobal.Id_cajero = "";
                ventaGlobal.Id_statusServicio = 1;
                ventaGlobal.id_sucursal = Comun.id_sucursal;
                ventaGlobal.Id_tipocredencial = 0;  //default sin credencial
                ventaGlobal.Id_tipoServicio = opcion; //tintoreria
                ventaGlobal.Id_vendedor = Comun.id_u;
                ventaGlobal.Id_ventaServicio = ""; //llave se genera despues de crearlo
                ventaGlobal.iva = 0;
                ventaGlobal.Latitud = "0";
                ventaGlobal.ListaDeSimbolos = new Dictionary<string, string>();
                ventaGlobal.Longitud = "0";
                ventaGlobal.monedero = 0;
                ventaGlobal.Pago = 0;
                ventaGlobal.Pendiente = 0;
                ventaGlobal.puntos = 0;
                ventaGlobal.Recargo = false;
                ventaGlobal.subTotal = 0;
                ventaGlobal.Terminado = false;
                ventaGlobal.total = 0;
                ventaGlobal.descuentoGeneral = 0;
                ventaGlobal.Totalkilogramos = 0;
                ventaGlobal.Usuario = Comun.id_u;
                ventaGlobal.UsuChofer="";
                ventaGlobal.Usuent="";
                ventaGlobal.Usurec="";
                ventaGlobal.Usuter="";
                ventaGlobal.vale= null;
                ventaGlobal._cantidadServicios=0;

                if (opcion == 2)
                {
                    btnSimbolos.Visible = false;
                    txtKg.Visible = true;
                    lblKg.Visible = true;
                    btnLavanderia.Visible = true;
                    btnPrendasTintoreria.Visible = false;
                }
                else
                {
                    btnSimbolos.Visible = true;
                    txtKg.Visible = false;
                    lblKg.Visible = false;
                    btnLavanderia.Visible = false;
                    btnPrendasTintoreria.Visible = true;
                    VentaTintoreriaNegocio oNegocio = new VentaTintoreriaNegocio();
                    this.dtPrecioPorTipoRopa = oNegocio.GetPreciosPorTipoProducto();
                }

                //Crear Tabla de Venta en Memoria
                ventaGlobal.tablaRopaServicio = new DataTable();
                ventaGlobal.tablaRopaServicio.Columns.Add("idTemp", typeof(string));
                ventaGlobal.tablaRopaServicio.Columns.Add("id_grupo", typeof(int));
                ventaGlobal.tablaRopaServicio.Columns.Add("id_ropa", typeof(string));
                ventaGlobal.tablaRopaServicio.Columns.Add("id_tiporopa", typeof(int));
                ventaGlobal.tablaRopaServicio.Columns.Add("id_color", typeof(int));
                ventaGlobal.tablaRopaServicio.Columns.Add("id_fibra", typeof(int));
                ventaGlobal.tablaRopaServicio.Columns.Add("id_estampado", typeof(int));
                ventaGlobal.tablaRopaServicio.Columns.Add("simbolosLavado", typeof(string));
                ventaGlobal.tablaRopaServicio.Columns.Add("nombrePrenda", typeof(string));
                ventaGlobal.tablaRopaServicio.Columns.Add("nombreTemporal", typeof(string));
                ventaGlobal.tablaRopaServicio.Columns.Add("descripcionPrenda", typeof(string));
                ventaGlobal.tablaRopaServicio.Columns.Add("idvale", typeof(string));
                ventaGlobal.tablaRopaServicio.Columns.Add("idubicacion", typeof(int));
                ventaGlobal.tablaRopaServicio.Columns.Add("ubicacion", typeof(string));
                ventaGlobal.tablaRopaServicio.Columns.Add("precio", typeof(float));
                ventaGlobal.tablaRopaServicio.Columns.Add("cantidad_venta", typeof(int));
                ventaGlobal.tablaRopaServicio.Columns.Add("subtotal", typeof(float));
                ventaGlobal.tablaRopaServicio.Columns.Add("descuento", typeof(float));
                ventaGlobal.tablaRopaServicio.Columns.Add("total", typeof(float));
                ventaGlobal.tablaRopaServicio.Columns.Add("monedero", typeof(float));
                ventaGlobal.tablaRopaServicio.Columns.Add("puntos", typeof(int));
                ventaGlobal.tablaRopaServicio.Columns.Add("comentarios", typeof(string));
            }
            catch (Exception)
            {

                
            }
        }

        private void CrearArticulo(string clave, string nombreCtrl, int index)
        {
            try
            {
                Articulo icon_Creativa = new Articulo();
                icon_Creativa.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
                icon_Creativa.Name = nombreCtrl.Trim().ToUpper();
                icon_Creativa.CveArticulo = clave.Trim();
                icon_Creativa.NombreArticulo = nombreCtrl.Trim().ToUpper();
                icon_Creativa.ColorBoder = Color.MediumTurquoise;
                icon_Creativa.ColorFinal = Color.PaleTurquoise;
                icon_Creativa.ColorInicial = Color.LightGray;

                icon_Creativa.Size = new System.Drawing.Size(80, 100);
                icon_Creativa.TabIndex = index;
                string path = @"C:\CSL\IMG\Prendas\" + clave + ".png";
                string path2 = @"C:\CSL\IMG\Prendas\default.png";

                try
                {
                    if (File.Exists(path))
                        icon_Creativa.imgArticulo.Image = Image.FromFile(path);
                    else
                        icon_Creativa.imgArticulo.Image = Image.FromFile(path2);
                }
                catch (Exception)
                {

                }


                icon_Creativa.ArticuloClick += new EventHandler(this.ArticuloEvento_Click);

                panelTipoRopa.Controls.Add(icon_Creativa);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void CargarArticulos()
        {
            try
            {
                for (int contador = 0; contador < Comun.TipoListaRopa.Rows.Count; contador++)
                {
                    if (Convert.ToInt32(Comun.TipoListaRopa.Rows[contador]["id_tipoRopa"].ToString()) < 10000)
                    {
                        CrearArticulo(Comun.TipoListaRopa.Rows[contador]["id_tipoRopa"].ToString(), Comun.TipoListaRopa.Rows[contador]["descripcion"].ToString(), contador);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void MostrarEntrega()
        {
            try
            {
                DateTime fecha = DateTime.Now;
                DateTime fechaEntrega = fecha;
                TimeSpan horaServicio = TimeSpan.Parse(fecha.ToString("HH:mm:ss"));
                TimeSpan horaEntrega = horaServicio;
                DataRow[] fila = Comun.EntregasRopa.Select("id_tipoEntrega = " + tipoEntrega.ToString());
                if (fila != null)
                {
                    txtEntrega.Text = fila[0]["descripcion"].ToString().Trim();
                    if(this.opcion == 2) //venta por lavanderia
                    {
                        this.precioXRangoTiempo = Convert.ToDecimal(fila[0]["precioKg"].ToString().Trim());
                    }
                    
                    DataTable dt = ventaGlobal.tablaRopaServicio as DataTable;

                    //actualizo los precios de lavanderia
                    foreach (DataRow dr in dt.Rows)
                    {
                        decimal cantidad = Convert.ToDecimal(dr["cantidad_venta"]);
                        decimal subtotal = 0;
                        int idTipoRopa = 0;
                        int.TryParse(dr["id_tiporopa"].ToString(), out idTipoRopa);
                        decimal precio = GetPrecio(idTipoRopa);
                        subtotal = precio * cantidad;
                        dr["subtotal"] = subtotal;
                        //ya que los descuentos son hacia el total pero de la venta, no por articulo, tanto el total como subtotal son los mimos
                        dr["total"] = subtotal;
                    }

                    int.TryParse(fila[0]["horas"].ToString(), out int HorasServicio);
                    txtHorasEntrega.Text = string.Format("{0} hrs", HorasServicio.ToString());
                    bool.TryParse(fila[0]["EsUrgente"].ToString(), out bool esUrgente);
                    string horaLimAux = fila[0]["HoraLimite"].ToString();
                    string horaEntAux = fila[0]["HoraEntrega"].ToString();
                    TimeSpan horaCorte = TimeSpan.Parse(horaLimAux);
                    horaEntrega = TimeSpan.Parse(horaEntAux);
                    if (esUrgente)
                    {
                        fechaEntrega = new DateTime(fecha.Year, fecha.Month, fecha.Day, horaEntrega.Hours, horaEntrega.Minutes, horaEntrega.Seconds);
                    }
                    else
                    {
                        if(horaServicio > horaCorte)
                        {
                            fechaEntrega = new DateTime(fecha.Year, fecha.Month, fecha.Day + 1, horaEntrega.Hours, horaEntrega.Minutes, horaEntrega.Seconds);
                        }
                        else
                        {
                            fechaEntrega = new DateTime(fecha.Year, fecha.Month, fecha.Day, horaEntrega.Hours, horaEntrega.Minutes, horaEntrega.Seconds);
                        }
                    }
                }
                else
                {
                    txtEntrega.Text = "NORMAL";
                    horasEntrega = 24;
                    txtHorasEntrega.Text = "24 hrs";
                    fechaEntrega = fecha.AddHours(24);
                }
                //Revisando Fechas Festivas
                foreach (DataRow item in Comun.FechasFestivas.Rows)
                {
                    DateTime fechafestiva = Convert.ToDateTime(item["Fecha"].ToString());

                    if (fechaEntrega.ToShortDateString() ==  fechafestiva.ToShortDateString() )
                    {
                        fechaEntrega.AddDays(1);
                    }
                }
                txtFechaEntrega.Text = fechaEntrega.ToShortDateString();
                txtHoraEntrega.Text = fechaEntrega.ToString("HH:mm:ss");
                txtFechaEntrega.TextAlign = HorizontalAlignment.Center;
                txtHoraEntrega.TextAlign = HorizontalAlignment.Center;
                ventaGlobal.FechaEntrega = fechaEntrega;
                ventaGlobal.HoraEntrega = horaEntrega.ToString();
                //recalcular precios.
                MostrarDatosTotales();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        private void FrmVentaTintoreria_Load(object sender, EventArgs e)
        {
            try
            {
                MostrarEntrega();
            }
            catch (Exception) { }
        }

        private void LlenarDatosCliente(Cliente datos)
        {
            try
            {
                if (string.IsNullOrEmpty(datos.id_cliente))
                {
                    this.txtCliente.Text = "";
                    this.txtMonederoCliente.Text = string.Format("{0:C2}", 0.0);
                    this.txtnomCliente.Text = "";
                    this.txtNivelMonederoCliente.Text="";
                }
                else
                {
                    this.txtCliente.Text = datos.codigoMonedero;
                    this.txtMonederoCliente.Text = string.Format("{0:C2}", datos.credenciales.monedero);
                    this.txtnomCliente.Text = datos.credenciales.nombreCompleto;
                    this.txtNivelMonederoCliente.Text = datos.credenciales.NivelCredencial;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void AsignarClienteListaVentas(Cliente datos)
        {
            try
            {
                //solo a la venta actual.
                ventaGlobal.idCliente = datos.id_cliente;
                ventaGlobal.cliente = datos;
                ventaGlobal.Id_tipocredencial = datos.credenciales.idTipoCredencial;
                MostrarDatosTotales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        
        private void linkBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.TabPages.Count > 0)
                {
                    if (tabControl1.SelectedTab != null)
                    {
                        frm_BuscarCliente bc = new frm_BuscarCliente();
                        bc.ShowDialog();
                        if (bc.DialogResult == DialogResult.OK)
                        {
                            using (new Recursos.CursorWait())
                            {
                            //
                                Cliente cliente = new Cliente();
                                ClienteNegocio cn = new ClienteNegocio();
                                VentaProductos datos = new VentaProductos();
                                cliente = bc.cliente;

                                datos.Usuins = Comun.id_u;
                                datos.StrCnx = Comun.conexion;
                                datos.IDCliente = cliente.id_cliente;
                                datos.IDVenta = this.tabControl1.SelectedTab.Name;
                                datos.IDSucursal = Comun.id_sucursal;


                              
                                cliente = cn.obtenerClienteXID(datos.IDCliente);
                                if (string.IsNullOrEmpty(cliente.id_cliente))
                                    MessageBox.Show(this, "No se cargaron los datos del cliente. ", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            //se asigna a venta
                            ventaGlobal.cliente = cliente;
                            ventaGlobal.idCliente = cliente.id_cliente;
                            ventaGlobal.Id_tipocredencial = cliente.credenciales.idTipoCredencial;
                            this.porcentajeMonedero = cliente.credenciales.PorcentajeMonedero;

                            this.LlenarDatosCliente(cliente);
                            this.AsignarClienteListaVentas(cliente);
                            //DgvProductosBindingSource(datos);
                        }
                    }
                bc.Dispose();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    if (tabControl1.TabPages.Count > 0)
                    {
                        if (tabControl1.SelectedTab != null)
                        {
                            VentaProductos datos = new VentaProductos();
                            ClienteNegocio cn = new ClienteNegocio();
                            datos.Usuins = Comun.id_u;
                            datos.StrCnx = Comun.conexion;
                            datos.IDCliente = this.txtCliente.Text;
                            datos.IDVenta = this.tabControl1.SelectedTab.Name;
                            datos.IDSucursal = Comun.id_sucursal;
                            Cliente cliente = new Cliente();
                            cliente.credenciales = new Credenciales();
                            cliente = cn.obtenerClienteXEANCodigo(datos);
                            if (string.IsNullOrEmpty(cliente.id_cliente))
                                MessageBox.Show(this, "Código de cliente incorrecto", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.LlenarDatosCliente(cliente);
                            this.AsignarClienteListaVentas(cliente);
                        }
                    }
                }
                else
                {
                    this.PermitirSoloNumeros(e);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Código de cliente incorrecto", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtCliente_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void PermitirSoloNumeros(KeyPressEventArgs e)
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
        
        private void obtenerFila(string clave)
        {
            try
            {
                for (int i = 0; i < ventaGlobal.tablaRopaServicio.Rows.Count; i++)
                {
                    if (ventaGlobal.tablaRopaServicio.Rows[i]["idTemp"].ToString() == clave)
                    {
                        RowIndex = i;
                        break;
                    }
                }
            }
            catch (Exception)
            {

               
            }

        }


        /*************Recalcular******************************/
        private void RecalcularPrecioKg(decimal totalg)
        {
            try
            {
                for (int i = 0; i < ventaGlobal.tablaRopaServicio.Rows.Count; i++)
                {

              
                    if (ventaGlobal.tablaRopaServicio.Rows[i]["id_ropa"].ToString().Trim() == "PGeneral1001")
                    {
                        int cantidad = Convert.ToInt32(ventaGlobal.tablaRopaServicio.Rows[RowIndex]["cantidad_venta"].ToString());
                        decimal descuento = Convert.ToInt32(ventaGlobal.tablaRopaServicio.Rows[RowIndex]["descuento"].ToString());

                        decimal precioPrenda = totalg;
                        decimal porcentajemonedero = Comun.MonederoRopa["10001" + ventaGlobal.Id_tipocredencial.ToString()];
                        int puntos = Comun.PtosRopa["10001" + ventaGlobal.Id_tipocredencial.ToString()];

                        decimal subtotal = (cantidad * precioPrenda);
                        decimal total = subtotal - descuento;
                        decimal monederonuevo = total * (porcentajemonedero / 100);

                        puntos = puntos * cantidad;
                        ventaGlobal.tablaRopaServicio.Rows[RowIndex]["puntos"] = puntos.ToString();
                        ventaGlobal.tablaRopaServicio.Rows[RowIndex]["monedero"] = monederonuevo.ToString();
                        
                        ventaGlobal.tablaRopaServicio.Rows[RowIndex]["comentarios"] = ventaGlobal.Totalkilogramos.ToString();
                        ventaGlobal.tablaRopaServicio.Rows[RowIndex]["nombreTemporal"] = "SERV. POR KG. (" + ventaGlobal.Totalkilogramos.ToString() + ")";
                        ventaGlobal.tablaRopaServicio.Rows[RowIndex]["nombrePrenda"] = "SERV. POR KG. (" + ventaGlobal.Totalkilogramos.ToString() + ")";
                        ventaGlobal.tablaRopaServicio.Rows[RowIndex]["descripcionPrenda"] = "Kg(" + ventaGlobal.Totalkilogramos.ToString() + ") - Precio( $" + PrecioKgGlobal.ToString("0.00") + " X Kg)";


                        

                        break;
                    }
                }




                MostrarDatosTotales();

            }
            catch (Exception)
            {


            }

        }
        
        private void RecalcularMonedero(int index)
        {
            try
            {
                if ((ventaGlobal.tablaRopaServicio.Rows[index]["id_ropa"].ToString().Trim() != "PGeneral1000") && (ventaGlobal.tablaRopaServicio.Rows[index]["id_ropa"].ToString().Trim() != "PGeneral1001"))
                {
                    int cantidad = Convert.ToInt32(ventaGlobal.tablaRopaServicio.Rows[index]["cantidad_venta"].ToString());
                    decimal descuento = Convert.ToInt32(ventaGlobal.tablaRopaServicio.Rows[index]["descuento"].ToString());

                    decimal precioPrenda = Comun.PreciosRopa[ventaGlobal.tablaRopaServicio.Rows[RowIndex]["id_ropa"].ToString().Trim() + ventaGlobal.IdTipoEntrega.ToString().Trim() + ventaGlobal.Id_tipoServicio.ToString()];
                    decimal porcentajemonedero = Comun.MonederoRopa[ventaGlobal.tablaRopaServicio.Rows[index]["id_grupo"].ToString() + ventaGlobal.Id_tipocredencial.ToString()];
                    int puntos = Comun.PtosRopa[ventaGlobal.tablaRopaServicio.Rows[index]["id_grupo"].ToString() + ventaGlobal.Id_tipocredencial.ToString()];

                    decimal subtotal = (cantidad * precioPrenda);
                    decimal total = subtotal - descuento;

                    decimal monederonuevo = total * (porcentajemonedero / 100);

                    puntos = puntos * cantidad;
                    ventaGlobal.tablaRopaServicio.Rows[index]["puntos"] = puntos.ToString();
                    ventaGlobal.tablaRopaServicio.Rows[index]["monedero"] = monederonuevo.ToString();
                }
                else
                {
                    if (ventaGlobal.tablaRopaServicio.Rows[index]["id_ropa"].ToString().Trim() == "PGeneral1000")
                    {
                        int cantidad = Convert.ToInt32(ventaGlobal.tablaRopaServicio.Rows[RowIndex]["cantidad_venta"].ToString());
                        decimal descuento = Convert.ToInt32(ventaGlobal.tablaRopaServicio.Rows[RowIndex]["descuento"].ToString());

                        decimal precioPrenda = Convert.ToDecimal(ventaGlobal.tablaRopaServicio.Rows[RowIndex]["precio"].ToString());
                        decimal porcentajemonedero = Comun.MonederoRopa["10000" + ventaGlobal.Id_tipocredencial.ToString()];
                        int puntos = Comun.PtosRopa["10000" + ventaGlobal.Id_tipocredencial.ToString()];

                        decimal subtotal = (cantidad * precioPrenda);
                        decimal total = subtotal - descuento;
                        decimal monederonuevo = total * (porcentajemonedero / 100);

                        puntos = puntos * cantidad;
                        ventaGlobal.tablaRopaServicio.Rows[RowIndex]["puntos"] = puntos.ToString();
                        ventaGlobal.tablaRopaServicio.Rows[RowIndex]["monedero"] = monederonuevo.ToString();
                    }
                    else
                    if (ventaGlobal.tablaRopaServicio.Rows[index]["id_ropa"].ToString().Trim() == "PGeneral1001")
                    {
                        int cantidad = Convert.ToInt32(ventaGlobal.tablaRopaServicio.Rows[RowIndex]["cantidad_venta"].ToString());
                        decimal descuento = Convert.ToInt32(ventaGlobal.tablaRopaServicio.Rows[RowIndex]["descuento"].ToString());

                        decimal precioPrenda = PrecioKgGlobal * (decimal)ventaGlobal.Totalkilogramos;
                        decimal porcentajemonedero = Comun.MonederoRopa["10001" + ventaGlobal.Id_tipocredencial.ToString()];
                        int puntos = Comun.PtosRopa["10001" + ventaGlobal.Id_tipocredencial.ToString()];

                        decimal subtotal = (cantidad * precioPrenda);
                        decimal total = subtotal - descuento;
                        decimal monederonuevo = total * (porcentajemonedero / 100);

                        puntos = puntos * cantidad;
                        ventaGlobal.tablaRopaServicio.Rows[RowIndex]["puntos"] = puntos.ToString();
                        ventaGlobal.tablaRopaServicio.Rows[RowIndex]["monedero"] = monederonuevo.ToString();

                    }



                    }

                MostrarDatosTotales();

            }
            catch (Exception)
            {


            }

        }

        private void RecalcularPreciosRopa(int index)
        {
            try
            {
                if ((ventaGlobal.tablaRopaServicio.Rows[index]["id_ropa"].ToString().Trim() != "PGeneral1000") && (ventaGlobal.tablaRopaServicio.Rows[index]["id_ropa"].ToString().Trim() != "PGeneral1001"))
                {
                    int cantidad = Convert.ToInt32(ventaGlobal.tablaRopaServicio.Rows[index]["cantidad_venta"].ToString());
                    decimal descuento = Convert.ToInt32(ventaGlobal.tablaRopaServicio.Rows[index]["descuento"].ToString());

                    decimal precioPrenda = Comun.PreciosRopa[ventaGlobal.tablaRopaServicio.Rows[RowIndex]["id_ropa"].ToString().Trim() + ventaGlobal.IdTipoEntrega.ToString().Trim() + ventaGlobal.Id_tipoServicio.ToString()];
                    decimal porcentajemonedero = Comun.MonederoRopa[ventaGlobal.tablaRopaServicio.Rows[index]["id_grupo"].ToString() + ventaGlobal.Id_tipocredencial.ToString()];
                    int puntos = Comun.PtosRopa[ventaGlobal.tablaRopaServicio.Rows[index]["id_grupo"].ToString() + ventaGlobal.Id_tipocredencial.ToString()];

                    decimal subtotal = (cantidad * precioPrenda);
                    decimal total = subtotal - descuento;

                    decimal monederonuevo = total * (porcentajemonedero / 100);

                    puntos = puntos * cantidad;
                    ventaGlobal.tablaRopaServicio.Rows[index]["puntos"] = puntos.ToString();
                    ventaGlobal.tablaRopaServicio.Rows[index]["monedero"] = monederonuevo.ToString();
                    ventaGlobal.tablaRopaServicio.Rows[index]["precio"] = precioPrenda.ToString();
                    ventaGlobal.tablaRopaServicio.Rows[index]["subtotal"] = subtotal.ToString();
                    ventaGlobal.tablaRopaServicio.Rows[index]["total"] = total.ToString();

                    MostrarDatosTotales();

                }
            }
            catch (Exception)
            {


            }

        }

        private void RecalcularDatosCantidad()
        {
            try
            {
                //es producto General
                if ((ventaGlobal.tablaRopaServicio.Rows[RowIndex]["id_ropa"].ToString().Trim() != "PGeneral1000") && (ventaGlobal.tablaRopaServicio.Rows[RowIndex]["id_ropa"].ToString().Trim() != "PGeneral1001"))
                {
                    int cantidad = Convert.ToInt32(ventaGlobal.tablaRopaServicio.Rows[RowIndex]["cantidad_venta"].ToString());
                    decimal descuento = Convert.ToInt32(ventaGlobal.tablaRopaServicio.Rows[RowIndex]["descuento"].ToString());
                   
                    decimal precioPrenda = Comun.PreciosRopa[ventaGlobal.tablaRopaServicio.Rows[RowIndex]["id_ropa"].ToString().Trim() + ventaGlobal.IdTipoEntrega.ToString().Trim() + ventaGlobal.Id_tipoServicio.ToString()];
                    decimal porcentajemonedero = Comun.MonederoRopa[ventaGlobal.tablaRopaServicio.Rows[RowIndex]["id_grupo"].ToString() + ventaGlobal.Id_tipocredencial.ToString()];
                    int puntos = Comun.PtosRopa[ventaGlobal.tablaRopaServicio.Rows[RowIndex]["id_grupo"].ToString() + ventaGlobal.Id_tipocredencial.ToString()];

                    decimal subtotal = (cantidad * precioPrenda);
                    decimal total = subtotal - descuento;

                    decimal monederonuevo = total * (porcentajemonedero / 100);

                    puntos = puntos * cantidad;
                    ventaGlobal.tablaRopaServicio.Rows[RowIndex]["puntos"] = puntos.ToString();
                    ventaGlobal.tablaRopaServicio.Rows[RowIndex]["monedero"] = monederonuevo.ToString();
                    ventaGlobal.tablaRopaServicio.Rows[RowIndex]["precio"] = precioPrenda.ToString();
                    ventaGlobal.tablaRopaServicio.Rows[RowIndex]["subtotal"] = subtotal.ToString();
                    ventaGlobal.tablaRopaServicio.Rows[RowIndex]["total"] = total.ToString();
                }
                else
                    MessageBox.Show("Para Otros Cargos y Venta por Kg, no se puede cambiar la cantidad", "", MessageBoxButtons.OK, MessageBoxIcon.Information);


                MostrarDatosTotales();
            }
            catch (Exception)
            {

                
            }

        }

        /*************Recalcular******************************/

        private void DgwDatosVenta_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgwDatosVenta.SelectedRows.Count > 0)
                {
                    claveSeleccionada = dgwDatosVenta.SelectedRows[0].Cells["idtemp"].Value.ToString();
                }
            }
            catch (Exception) { }
        }

        private void BtnPrendasTintoreria_Click(object sender, EventArgs e)
        {
            try
            {
                panelDatosGen02.Size = this.Size;
                panelDatosGen02.Location = this.Location;
                panelDatosGen02.Visible = true;
            }
            catch (Exception) { }
        }

        private void btnPrendasLavanderia_Click(object sender, EventArgs e)
        {
            try
            {
                if (ventaGlobal.Totalkilogramos <= 0)
                {
                    //Pedir Kilogramos
                    frm_PedirKilogramos kilos = new frm_PedirKilogramos();
                    if (kilos.ShowDialog() == DialogResult.OK)
                    {
                        decimal total = 0;
                        ventaGlobal.Totalkilogramos = (float)kilos.precio;
                        txtKg.Text = ventaGlobal.Totalkilogramos.ToString("0.00");

                        //CalcularPreciosegunkg
                        total =  PrecioKgGlobal * (decimal)ventaGlobal.Totalkilogramos;


                        //Crearregistrodeventa.
                        CrearCargoGenerico("SERV. POR KG (" + ventaGlobal.Totalkilogramos.ToString() + ")", total, ventaGlobal.Totalkilogramos.ToString(), "10001", "PGeneral1001", "Kg(" + ventaGlobal.Totalkilogramos.ToString() + ") - Precio( $"+ PrecioKgGlobal.ToString("0.00") + " X Kg)");


                        //panelDatosGen02.Visible = true;
                    }
                }
                else
                {
                    panelDatosGen02.Size = this.Size;
                    panelDatosGen02.Location = this.Location;
                    panelDatosGen02.Visible = true;
                }
            }
            catch (Exception)
            {


            }
        }

        private void btnClosePrendasTint_Click(object sender, EventArgs e)
        {
            try
            {
                panelDatosGen02.Visible = false;
            }
            catch (Exception)
            {


            }
        }

        private void btnCantidadS_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgwDatosVenta.SelectedRows.Count > 0)
                {
                    obtenerFila(claveSeleccionada);
                    decimal cantidad = Convert.ToDecimal(ventaGlobal.tablaRopaServicio.Rows[RowIndex]["cantidad_venta"].ToString());
                    decimal subtotal = 0;
                    int idTipoRopa = 0;
                    int.TryParse(ventaGlobal.tablaRopaServicio.Rows[RowIndex]["id_tiporopa"].ToString(), out idTipoRopa);
                    decimal precio = GetPrecio(idTipoRopa);
                    cantidad += 1;
                    subtotal = cantidad * precio;

                    ventaGlobal.tablaRopaServicio.Rows[RowIndex]["cantidad_venta"] = cantidad;
                    ventaGlobal.tablaRopaServicio.Rows[RowIndex]["subtotal"] = subtotal;
                    ventaGlobal.tablaRopaServicio.Rows[RowIndex]["total"] = subtotal;

                    MostrarDatosTotales();
                }
                else
                    MessageBox.Show("Debe seleccionar una prenda del listado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                
            }
        }

        private void btnDatos_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgwDatosVenta.SelectedRows.Count > 0)
                {
                    obtenerFila(claveSeleccionada);


                    if ((ventaGlobal.tablaRopaServicio.Rows[RowIndex]["id_ropa"].ToString().Trim() != "PGeneral1000") && (ventaGlobal.tablaRopaServicio.Rows[RowIndex]["id_ropa"].ToString().Trim() != "PGeneral1001"))
                    {

                        frmSelSubTipoPrenda frmst = new frmSelSubTipoPrenda(ventaGlobal.tablaRopaServicio.Rows[RowIndex]["id_tiporopa"].ToString(), ventaGlobal.tablaRopaServicio.Rows[RowIndex]["nombrePrenda"].ToString(), ventaGlobal.tablaRopaServicio.Rows[RowIndex]["id_ropa"].ToString(), ventaGlobal.tablaRopaServicio.Rows[RowIndex]["id_color"].ToString(), ventaGlobal.tablaRopaServicio.Rows[RowIndex]["id_fibra"].ToString(), ventaGlobal.tablaRopaServicio.Rows[RowIndex]["id_estampado"].ToString(), ventaGlobal.tablaRopaServicio.Rows[RowIndex]["comentarios"].ToString());
                        if (frmst.ShowDialog() == DialogResult.OK)
                        {

                            ventaGlobal.tablaRopaServicio.Rows[RowIndex]["id_grupo"] = frmst.Idgrupo.Trim();
                            ventaGlobal.tablaRopaServicio.Rows[RowIndex]["id_ropa"] = frmst.Clavetipo.Trim();
                            ventaGlobal.tablaRopaServicio.Rows[RowIndex]["id_color"] = frmst.ClaveColor;
                            ventaGlobal.tablaRopaServicio.Rows[RowIndex]["id_fibra"] = frmst.ClaveFibra;
                            ventaGlobal.tablaRopaServicio.Rows[RowIndex]["id_estampado"] = frmst.ClaveEstampado;
                            ventaGlobal.tablaRopaServicio.Rows[RowIndex]["comentarios"] = frmst.Comentarioprenda;
                            ventaGlobal.tablaRopaServicio.Rows[RowIndex]["nombrePrenda"] = ventaGlobal.tablaRopaServicio.Rows[RowIndex]["nombreTemporal"] + " " + frmst.Nombresubtipo;
                            ventaGlobal.tablaRopaServicio.Rows[RowIndex]["descripcionPrenda"] = frmst.Descripcionprenda;
                            RecalcularDatosCantidad();

                        }
                        frmst.Dispose();

                    }
                    else
                        MessageBox.Show("El articulo de Otros Gastos no incluye esta opción", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Debe seleccionar una prenda del listado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {


            }
        }

        private void btnSimbolos_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgwDatosVenta.SelectedRows.Count > 0)
                {
                    obtenerFila(claveSeleccionada);



                    if ((ventaGlobal.tablaRopaServicio.Rows[RowIndex]["id_ropa"].ToString().Trim() != "PGeneral1000") && (ventaGlobal.tablaRopaServicio.Rows[RowIndex]["id_ropa"].ToString().Trim() != "PGeneral1001"))
                    {
                        frmSelDatosPrenda frmdp = new frmSelDatosPrenda(ventaGlobal.tablaRopaServicio.Rows[RowIndex]["nombrePrenda"].ToString(), ventaGlobal.tablaRopaServicio.Rows[RowIndex]["simbolosLavado"].ToString());
                        if (frmdp.ShowDialog() == DialogResult.OK)
                        {

                            ventaGlobal.tablaRopaServicio.Rows[RowIndex]["simbolosLavado"] = frmdp.ListaXml;

                        }
                        frmdp.Dispose();
                    }
                    else
                        MessageBox.Show("El articulo de Otros Gastos no incluye esta opción", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Debe seleccionar una prenda del listado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {


            }
        }

        private void btnCantidadR_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgwDatosVenta.SelectedRows.Count > 0)
                {
                    obtenerFila(claveSeleccionada);
                    decimal cantidad = Convert.ToDecimal(ventaGlobal.tablaRopaServicio.Rows[RowIndex]["cantidad_venta"].ToString());
                    if(cantidad > 1)
                    {
                        decimal subtotal = 0;
                        int idTipoRopa = 0;
                        int.TryParse(ventaGlobal.tablaRopaServicio.Rows[RowIndex]["id_tiporopa"].ToString(), out idTipoRopa);
                        decimal precio = GetPrecio(idTipoRopa);
                        cantidad -= 1;
                        subtotal = cantidad * precio;

                        ventaGlobal.tablaRopaServicio.Rows[RowIndex]["cantidad_venta"] = cantidad;
                        ventaGlobal.tablaRopaServicio.Rows[RowIndex]["subtotal"] = subtotal;
                        ventaGlobal.tablaRopaServicio.Rows[RowIndex]["total"] = subtotal;

                        MostrarDatosTotales();
                    }
                    else
                    {
                        MessageBox.Show("La cantidad debe ser mayor a 0.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("Debe seleccionar una prenda del listado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {


            }
        }

       private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgwDatosVenta.SelectedRows.Count > 0)
                {
                    obtenerFila(claveSeleccionada);

                    ventaGlobal.tablaRopaServicio.Rows[RowIndex].Delete();
                    MostrarDatosTotales();

                }
                else
                    MessageBox.Show("Debe seleccionar una prenda del listado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {


            }
        }
        
        private void btnComentarioVenta_Click(object sender, EventArgs e)
        {
            try
            {

                frm_PedirCadenaTexto frmtxt = new frm_PedirCadenaTexto();
                if (frmtxt.ShowDialog() == DialogResult.OK)
                {
                    ventaGlobal.Comentarios = frmtxt.dato;
                }
                frmtxt.Dispose();
            }
            catch (Exception)
            {

                
            }
        }

        private void txtKg_Click(object sender, EventArgs e)
        {
            try
            {
                //Pedir Kilogramos
                frm_PedirKilogramos kilos = new frm_PedirKilogramos();
                if (kilos.ShowDialog() == DialogResult.OK)
                {
                    decimal total = 0;
                    ventaGlobal.Totalkilogramos = (float)kilos.precio;
                    txtKg.Text = ventaGlobal.Totalkilogramos.ToString("0.00");

                    //CalcularPreciosegunkg
                    total = PrecioKgGlobal * (decimal)ventaGlobal.Totalkilogramos;


                    RecalcularPrecioKg(total);

                 

                }
            }
            catch (Exception)
            {

                
            }
        }

        private void btnOtrosCargoVenta_Click(object sender, EventArgs e)
        {
            try
            {
                frm_PedirOtrosCargos frmcargos = new frm_PedirOtrosCargos();
                if (frmcargos.ShowDialog() == DialogResult.OK)
                {
                    CrearCargoGenerico(frmcargos.dato,frmcargos.precio,frmcargos.Comentario,"10000", "PGeneral1000", "Otros Cargos");
                    //Crear cargos 

                }
                frmcargos.Dispose();

            }
            catch (Exception)
            {

             
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ventaGlobal = null;
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            try
            {

                int aux = this.validarVenta();
                if (aux == 1000)
                {


                            if (ventaGlobal.isReproceso)
                            {
                                //No se cobra el ticket
                                VenderSinCosto(1);
                            }
                            else
                                if (ventaGlobal.isGratis)
                            {
                                // no se cobra el ticket
                                VenderSinCosto(2);
                            }
                            else
                            {




                                frm_PedirTipoVenta frmtv = new frm_PedirTipoVenta();

                                if (frmtv.ShowDialog() == DialogResult.OK)
                                {

                                    ventaGlobal.idtipopagoinicial = frmtv.dato;

                                    if (frmtv.dato == 1)
                                    {
                                        //Abrir pago completo
                                        ventaGlobal.idtipopagoinicial = 1;
                                        VenderPagoCompleto(1);
                                    }
                                    else
                                    if (frmtv.dato == 2)
                                    {
                                        //abrir pago parcial
                                        ventaGlobal.idtipopagoinicial = 2;
                                        VenderPagoCompleto(2);
                                    }
                                    else
                                    if (frmtv.dato == 3)
                                    {
                                        //no abrir nada
                                        ventaGlobal.idtipopagoinicial = 3;
                                        VenderSinPagoInicial();

                                    }

                                }
                                frmtv.Dispose();



                            }

                }
                else
                {
                    this.MensajeErrorPago(aux);
                }

            }
            catch (Exception)
            {

                
            }
        }

        private void btnAplicarValeDesc_Click(object sender, EventArgs e)
        {
            try
            {
                frm_PedirCodigoVale valef = new frm_PedirCodigoVale();
                if (valef.ShowDialog() == DialogResult.OK)
                {
                    //Aplicar Vale
                    ObtenerVale(valef.TextotxtCantidad);
                }

                valef.Dispose();

            }
            catch (Exception)
            {

               
            }
        }

        private void linkDelVale_Click(object sender, EventArgs e)
        {
            try
            {
                linkDelVale.Visible = false;
                txtValeaplicado.Visible = false;
                ventaGlobal.vale = null;
                MostrarDatosTotales();
            }
            catch (Exception)
            {

               
            }
        }


    }
}
