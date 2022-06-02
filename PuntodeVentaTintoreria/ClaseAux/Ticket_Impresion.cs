using TintoreriaGlobal;
using TintoreriaNegocio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PuntodeVentaTintoreria.ClaseAux
{
    public class Ticket_Impresion
    {
        #region Variables Globales
        Ticket datos = new Ticket();
        VentaProductos venta = new VentaProductos();
        Pago pago = new Pago();
        int tipo = 0;
        int numcopias = Comun.numeroTickets;
        int widthVenta = 190;
        int heightVenta = 700;
        int heightPedido = 710;
        int heightCancelacion = 670;
        #endregion
        #region Constructor
        public Ticket_Impresion()
        {
            try
            {

            }
            catch (Exception)
            {
            }
        }
        public Ticket_Impresion(int ticket, VentaProductos vt)
        {
            try
            {
                tipo = ticket;
                venta = vt;
            }
            catch (Exception)
            {
            }
        }
        public Ticket_Impresion(int ticket, VentaProductos vt, Pago pg)
        {
            try
            {
                tipo = ticket;
                venta = vt;
                pago = pg;
            }
            catch (Exception)
            {
            }
        }
        public Ticket_Impresion(int ticket, Pago pg)
        {
            try
            {
                tipo = ticket;
                this.pago = pg;
            }
            catch (Exception)
            {
            }
        }
        #endregion
        #region Métodos
        public void imprimirTicket()
        {
            try
            {
                Ticket ticket = new Ticket();
                TicketNegocio tn = new TicketNegocio();
                VentaProductosNegocio vpn = new VentaProductosNegocio();
                PagoNegocio pn = new PagoNegocio();
                ticket.strcnx = Comun.conexion;
                ticket.id_sucursal = Comun.id_sucursal;
                datos = Comun.ticket;
                venta.StrCnx = Comun.conexion;
                venta.IDSucursal = Comun.id_sucursal;
                switch (tipo)
                {
                    case 1: 
                        venta.StrCnx = Comun.conexion;
                        venta = vpn.obtenerDatosVenta(venta);
                        venta.listaDetalle = vpn.ObtenerVentaDetalle(venta);
                        datos.error = false;
                        break;
                    case 2: 
                        venta.StrCnx = Comun.conexion;
                        venta = vpn.obtenerDatosVenta(venta);
                        venta.listaDetalle = vpn.ObtenerVentaDetalle(venta);
                        datos.error = false;
                        break;
                    case 3:
                        decimal pago = venta.Pago;
                        venta.StrCnx = Comun.conexion;
                        venta = vpn.obtenerDatosVenta(venta);
                        venta.listaDetalle = vpn.ObtenerVentaDetalle(venta);
                        venta.Pago = pago;
                        datos.error = false;
                        break;
                    case 4:
                        venta.StrCnx = Comun.conexion;
                        venta = vpn.obtenerDatosCancelacion(venta);
                        venta.listaDetalle = vpn.ObtenerVentaDetalle(venta);
                        datos.error = false;
                        break;
                    /*
                    case 5: venta.StrCnx = Comun.Conexion;
                        vpn.obtenerDatosVenta(venta);
                        venta = vpn.ObtenerVentaDetalle(venta);
                        pago.totalVenta = (decimal)venta.Total;
                        pago.pagado = (decimal)venta.Pago;
                        float pendiente = 0;
                        if (venta.Pago <= venta.Total)
                            pendiente = (float)(venta.Total - venta.Pago);
                        else
                            pendiente = 0;
                        pago.pendiente = (decimal)pendiente;
                        break;
                    case 6:
                        venta.StrCnx = Comun.Conexion;
                        vpn.obtenerDatosVenta(venta);
                        venta = vpn.ObtenerVentaDetalle(venta);
                        pago.conexion = Comun.Conexion;
                        pago = pn.ObtenerDetallePagoTicket(pago);
                        break;
                    */
                }
                if (datos.error)
                {
                    throw new Exception("No se pudo obtener los datos del Ticket.");
                }
                for (int i = 0; i < numcopias; i++)
                {
                    position_y = 10;
                    this.impresionTicket();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("No se pudo obtener los datos del Ticket.");
            }
        }
        private int height_Venta(int _heightVenta)
        {
            if (venta.listaDetalle != null)
            {
                foreach (VentaProductos detalle in venta.listaDetalle)
                {
                    if (detalle.IDTipoProducto == 1)
                        _heightVenta += (15);
                    else if (detalle.IDTipoProducto == 2)
                        _heightVenta += (15 * 3);
                }
            }
            if (!venta.banBloqueoMultipleFormasPago)
                _heightVenta = _heightVenta + position_y;
            return _heightVenta;
        }
        #endregion
        #region imprimirTicket
        int position_y = 10;
        private void impresionTicket()
        {
            List<VentaProductos> detalleventa=new List<VentaProductos>();
            detalleventa = venta.listaDetalle;
            PrintDocument documento = new PrintDocument();
            PaperSize plantilla = new PaperSize("Ticket", 0, 0);
            if (detalleventa.Count > 1)
            {
                foreach (VentaProductos producto in detalleventa)
                {
                    heightVenta += 10;
                }
            }
            
                switch (tipo)
            {
                case 1:
                    plantilla = new PaperSize("Ticket", widthVenta, height_Venta(heightVenta));
                    break;

                case 2:
                    plantilla = new PaperSize("Ticket", widthVenta, height_Venta(heightPedido));
                    break;

                case 3:
                    plantilla = new PaperSize("Ticket", widthVenta, height_Venta(heightPedido));
                    break;

                case 4:
                    plantilla = new PaperSize("Ticket", widthVenta, height_Venta(heightCancelacion));
                    break;
                default:
                    plantilla = new PaperSize("Ticket", 0, 0);
                    break;
            }
            documento.DefaultPageSettings.PaperSize = plantilla;
            documento.PrintPage += new PrintPageEventHandler(Document_PrintPage);
            PrinterSettings ps = new PrinterSettings();
            ps.PrinterName = Comun.namePrinter;
            ps.DefaultPageSettings.PaperSize = plantilla;
            documento.PrinterSettings = ps;
            if (ps.IsValid)
                documento.Print();
            else
                throw new Exception("Verifique la configuración de la impresora.");
        }
        private void Document_PrintPage(object sender, PrintPageEventArgs e)
        {
            PrintDocument dc = (PrintDocument)sender;
            PaperSize plantilla;
            Graphics g = e.Graphics;
            SolidBrush Brush = new SolidBrush(Color.Black);
            PageSettings ps;
            switch (tipo)
            {
                case 1:
                    plantilla = new PaperSize("Ticket", widthVenta, height_Venta(heightVenta));
                    dc.DefaultPageSettings.PaperSize = plantilla;
                    ps = dc.DefaultPageSettings;
                    this.agregarEncabezado(ref g, ps);
                    this.agregarEncabezadoContenido(ref g, ps);
                    this.agregarDatosContenido(ref g, venta.listaDetalle, ps);
                    this.agregarTotalesContenidoVentaDirecta(ref g, ps, venta);
                    this.agregarPieTicket(ref g, ps);
                    break;
                case 2:
                    plantilla = new PaperSize("Ticket", widthVenta, height_Venta(heightPedido));
                    dc.DefaultPageSettings.PaperSize = plantilla;
                    ps = dc.DefaultPageSettings;
                    this.agregarEncabezado(ref g, ps);
                    this.agregarEncabezadoContenido(ref g, ps);
                    this.agregarDatosContenido(ref g, venta.listaDetalle, ps);
                    this.agregarTotalesContenidoApartadoCPago(ref g, ps, venta);
                    this.agregarPieTicket(ref g, ps);
                    break;
                case 3:
                    plantilla = new PaperSize("Ticket", widthVenta, height_Venta(heightPedido));
                    dc.DefaultPageSettings.PaperSize = plantilla;
                    ps = dc.DefaultPageSettings;
                    this.agregarEncabezado(ref g, ps);
                    this.agregarEncabezadoContenido(ref g, ps);
                    this.agregarDatosContenido(ref g, venta.listaDetalle, ps);
                    this.agregarTotalesContenidoApartadoSPago(ref g, ps, venta);
                    this.agregarPieTicket(ref g, ps);
                    break;
                case 4:
                    plantilla = new PaperSize("Ticket", widthVenta, height_Venta(heightCancelacion));
                    dc.DefaultPageSettings.PaperSize = plantilla;
                    ps = dc.DefaultPageSettings;
                    this.agregarEncabezado(ref g, ps);
                    this.agregarEncabezadoContenido(ref g, ps);
                    this.agregarDatosContenido(ref g, venta.listaDetalle, ps);
                    this.agregarTotalesContenidoCancelacion(ref g, ps, venta);
                    this.agregarPieTicket(ref g, ps);
                    break;
                /*
                case 4:
                case 5:
                case 6:
                    this.agregarCuerpoTicketVenta(ref g, ps);
                    break;
               */
            }
        }
        #region Métodos para la construccion del documento a imprimir
        private void agregarEncabezado(ref Graphics g, PageSettings ps)
        {
           
                // *******************************    DATOS DEL ENCABEZADO  ************************************ //
                this.addTitleCenter(datos.razonsocial.ToUpper(), ref g, ps.PaperSize.Width, ps.PaperSize.Height );
                this.addLogo(ref g, ps.PaperSize.Width, ps.PaperSize.Height);
                this.addTextCenter("SUC. " + datos.nombresucursal.ToUpper(), ref g, ps.PaperSize.Width, ps.PaperSize.Height);
                this.addTextCenter("RFC. " + datos.rfc.ToUpper(), ref g, ps.PaperSize.Width, ps.PaperSize.Height);
                this.addTextCenter(datos.direccion.ToUpper(), ref g, ps.PaperSize.Width, ps.PaperSize.Height);
                this.addTextCenter("C.P. " + datos.codigopostal + " TEL. " + datos.telefono, ref g, ps.PaperSize.Width, ps.PaperSize.Height);
                this.addTextCenter(datos.municipio.ToUpper() + ", " + datos.estado.ToUpper(), ref g, ps.PaperSize.Width, ps.PaperSize.Height);
                this.addletterspace_comentario('-', ref g, ps.PaperSize.Width, ps.PaperSize.Height, new Font("Arial", 8));
                // **************************** TERMINA REGION DATOS DEL ENCABEZADO  *************************** //
          
        }
        private void agregarEncabezadoContenido(ref Graphics g, PageSettings ps)
        {
           
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF pf = new PointF();
                StringFormat sf = new StringFormat();
                pf.X = 2;
                pf.Y = position_y += 15;
                sf.Alignment = StringAlignment.Near;
                switch (tipo)
                {
                    case 1: g.DrawString("LISTA PRODUCTOS VENDIDOS", new Font("Arial", 6), Brush, pf, sf);
                        break;
                    case 2: g.DrawString("LISTA PRODUCTOS APARTADOS", new Font("Arial", 6), Brush, pf, sf);
                        break;
                    case 3: g.DrawString("LISTA PRODUCTOS APARTADOS", new Font("Arial", 6), Brush, pf, sf);
                        break;
                    case 4: g.DrawString("LISTA PRODUCTOS CANCELADOS", new Font("Arial", 6), Brush, pf, sf);
                        break;
                }

                pf.X = 1;
                pf.Y = position_y += 15;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("#", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 12;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("CONCEPTO", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 92;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("P/U", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 132;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("IVA", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 162;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("P/T", new Font("Arial", 6), Brush, pf, sf);
                this.addletterspace_comentario('-', ref g, ps.PaperSize.Width, ps.PaperSize.Height, new Font("Arial", 8));
           
        }
        private void agregarDatosContenido(ref Graphics g, List<VentaProductos> detalleventa, PageSettings ps)
        {
          
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF pf = new PointF();
                StringFormat sf = new StringFormat();
                foreach (VentaProductos producto in detalleventa)
                {
                    pf.X = 4;
                    pf.Y = position_y += 10;
                    sf.Alignment = StringAlignment.Center;
                    g.DrawString(producto.CantidadVenta.ToString(), new Font("Arial", 6), Brush, pf, sf);
                  
                    pf.X = 117;
                    sf.Alignment = StringAlignment.Far;
                    g.DrawString(string.Format("{0:F2}", producto.Precio), new Font("Arial", 6), Brush, pf, sf);
                    pf.X = 152;
                    sf.Alignment = StringAlignment.Far;
                    g.DrawString(string.Format("{0:F2}", producto.Iva), new Font("Arial", 6), Brush, pf, sf);
                    pf.X = 187;
                    sf.Alignment = StringAlignment.Far;
                    g.DrawString(string.Format("{0:F2}", producto.Total), new Font("Arial", 6), Brush, pf, sf);
                    pf.X = 7;
                    sf.Alignment = StringAlignment.Near;
                    //string[] producto_line = producto.NombreProducto.Split(Environment.NewLine.ToString().ToCharArray());
                    this.addDatosContenido(ref g, ps, producto.NombreProducto, new Font("Arial", 6), sf.Alignment, 12);

                    /*foreach (string aux_producto in producto_line)
                    {
                        if (aux_producto.Length > 15)
                        {
                            int aux = 15;
                          //  g.DrawString(aux_producto.Substring(0, aux), new Font("Arial", 6), Brush, pf, sf);
                            this.addMensaje2(ref g, ps, aux_producto.Substring(0, aux), new Font("Arial", 6), sf.Alignment, 20);
                        }
                        else
                            
                        //pf.Y = position_y += 15;
                    }*/
                    pf.Y = position_y -= 10;

                }
                this.addletterspace_comentario('-', ref g, ps.PaperSize.Width, ps.PaperSize.Height, new Font("Arial", 8));
           
        }
        
        private void agregarTotalesContenidoVentaDirecta(ref Graphics g, PageSettings ps, VentaProductos venta)
        {
           
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF pf = new PointF();
                StringFormat sf = new StringFormat();
                position_y += 35;
                string aux = string.Format("{0:C2}", venta.Subtotal);
                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("SUBTOTAL: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 182;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Far;
                g.DrawString(aux, new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;
                //-------------------------
                aux = string.Format("{0:C2}", venta.Iva);
                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("IVA: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 182;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Far;
                g.DrawString(aux, new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;

                aux = string.Format("{0:C2}", venta.Descuento);
                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("USTED AHORRO: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 182;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Far;
                g.DrawString(aux, new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;
                //-------------------------
                aux = string.Format("{0:C2}", venta.Total);
                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("TOTAL: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 182;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Far;
                g.DrawString(aux, new Font("Arial", 6), Brush, pf, sf);
                position_y += 20;
                //-------------------------
                aux = string.Format("{0:C2}", venta.Pago);
                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("PAGO: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 182;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Far;
                g.DrawString(aux, new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;
                //-------------------------
                aux = string.Format("{0:C2}", venta.Cambio);
                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("CAMBIO: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 182;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Far;
                g.DrawString(aux, new Font("Arial", 6), Brush, pf, sf);
                if (!venta.banBloqueoMultipleFormasPago)
                {
                    pf.X = 2;
                    pf.Y = position_y+10;
                    sf.Alignment = StringAlignment.Near;
                    this.addMensaje(ref g, ps, "Esta venta no puede ser cancelada por múltiples formas de pago", new Font("Arial", 6), StringAlignment.Center, ps.PaperSize.Width);
                    position_y -= 15;
                }
                position_y += 15;
                this.addletterspace_comentario('-', ref g, ps.PaperSize.Width, ps.PaperSize.Height, new Font("Arial", 8));
           
        }
        private void agregarTotalesContenidoApartadoSPago(ref Graphics g, PageSettings ps, VentaProductos venta)
        {
          
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF pf = new PointF();
                StringFormat sf = new StringFormat();
                position_y += 35;
                string aux = string.Format("{0:C2}", venta.Subtotal);
                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("SUBTOTAL: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 187;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Far;
                g.DrawString(aux, new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;
                //-------------------------
                aux = string.Format("{0:C2}", venta.Iva);
                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("IVA: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 187;
                pf.Y = position_y;
                sf.Alignment = StringAlignment.Far;
                g.DrawString(aux, new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;

                aux = string.Format("{0:C2}", venta.Descuento);
                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("USTED AHORRO: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 187;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Far;
                g.DrawString(aux, new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;
                //-------------------------
                aux = string.Format("{0:C2}", venta.Total);
                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("TOTAL: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 187;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Far;
                g.DrawString(aux, new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;

                //--------------------------------------
                position_y += 15;
                //-------------------------------------    

                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("SALDO ACTUAL ", new Font("Arial", 6), Brush, pf, sf);
                //--------------------------------------
                position_y += 15;
                //-------------------------------------
                aux = string.Format("{0:C2}", venta.Pago);
                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("TOTAL PAGOS: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 187;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Far;
                g.DrawString(aux, new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;
                //--------------------------------------
                //-------------------------------------
                aux = string.Format("{0:C2}", venta.Pendiente);
                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("ADEUDO: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 187;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Far;
                g.DrawString(aux, new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;
                //--------------------------------------
                if (!venta.banBloqueoMultipleFormasPago)
                {
                    pf.X = 30;
                    pf.Y = position_y;
                    sf.Alignment = StringAlignment.Near;
                    this.addMensaje(ref g,ps, "Este Pedido no puede ser cancelado por múltiples formas de pago", new Font("Arial", 6), StringAlignment.Center, ps.PaperSize.Width);
                    position_y -= 15;
                }
          
        }
        private void agregarTotalesContenidoApartadoCPago(ref Graphics g, PageSettings ps, VentaProductos venta)
        {
           
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF pf = new PointF();
                StringFormat sf = new StringFormat();
                position_y += 35;
                string aux = string.Format("{0:C2}", venta.Subtotal);
                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("SUBTOTAL: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 187;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Far;
                g.DrawString(aux, new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;
                //-------------------------
                aux = string.Format("{0:C2}", venta.Iva);
                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("IVA: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 187;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Far;
                g.DrawString(aux, new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;

                aux = string.Format("{0:C2}", venta.Descuento);
                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("USTED AHORRO: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 187;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Far;
                g.DrawString(aux, new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;
                //-------------------------
                aux = string.Format("{0:C2}", venta.Total);
                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("TOTAL: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 187;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Far;
                g.DrawString(aux, new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;

                //--------------------------------------
                position_y += 15;
                //-------------------------------------    

                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("SALDO ACTUAL ", new Font("Arial", 6), Brush, pf, sf);
                //--------------------------------------
                position_y += 15;
                //-------------------------------------
                aux = string.Format("{0:C2}", venta.Pago);
                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("PAGO: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 187;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Far;
                g.DrawString(aux, new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;
                //--------------------------------------
                //-------------------------------------
                aux = string.Format("{0:C2}", venta.Pago);
                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("TOTAL PAGOS: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 187;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Far;
                g.DrawString(aux, new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;
                //--------------------------------------
                //-------------------------------------
                aux = string.Format("{0:C2}", venta.Pendiente);
                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("ADEUDO: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 187;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Far;
                g.DrawString(aux, new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;
                //--------------------------------------
                if (!venta.banBloqueoMultipleFormasPago)
                {
                    pf.X = 30;
                    pf.Y = position_y;
                    sf.Alignment = StringAlignment.Near;
                    this.addMensaje(ref g, ps, "Este Pedido no puede ser cancelada por múltiples formas de pago", new Font("Arial", 6), StringAlignment.Center, ps.PaperSize.Width);
                    position_y -= 15;
                }
            
        }
        private void agregarTotalesContenidoCancelacion(ref Graphics g, PageSettings ps, VentaProductos venta)
        {
            
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF pf = new PointF();
                StringFormat sf = new StringFormat();
                position_y += 35;
                string aux = string.Format("{0:C2}", venta.Subtotal);
                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("SUBTOTAL: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 187;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Far;
                g.DrawString(aux, new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;
                //-------------------------
                aux = string.Format("{0:C2}", venta.Iva);
                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("IVA: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 187;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Far;
                g.DrawString(aux, new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;

                aux = string.Format("{0:C2}", venta.Descuento);
                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("USTED AHORRO: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 187;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Far;
                g.DrawString(aux, new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;
                //-------------------------
                aux = string.Format("{0:C2}", venta.Total);
                pf.X = 2;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Near;
                g.DrawString("TOTAL: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 187;
                pf.Y = position_y+5;
                sf.Alignment = StringAlignment.Far;
                g.DrawString(aux, new Font("Arial", 6), Brush, pf, sf);
                position_y += 20;                
          
        }
        //Corregir 1pto
        private void agregarCuerpoTicketPago(ref Graphics h, PageSettings ps)
        {
          
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF pf = new PointF();
                StringFormat sf = new StringFormat();
                string aux;
                this.addletterspace('-', ref h, ps.PaperSize.Width, ps.PaperSize.Height, new Font("Arial", 8));
                sf.Alignment = StringAlignment.Near;
                pf.X = 10;
                pf.Y = position_y += 15;
                h.DrawString("FOLIO", new Font("Arial", 6), Brush, pf, sf);
                sf.Alignment = StringAlignment.Far;
                pf.X = 380;
                h.DrawString("IMPORTE COBRADO", new Font("Arial", 6), Brush, pf, sf);
                this.addletterspace('-', ref h, ps.PaperSize.Width, ps.PaperSize.Height, new Font("Arial", 8));
                sf.Alignment = StringAlignment.Near;
                pf.X = 10;
                pf.Y = position_y += 20;
                h.DrawString(pago.venta.Folio, new Font("Arial", 6), Brush, pf, sf);
                sf.Alignment = StringAlignment.Far;
                pf.X = 380;
                aux = string.Format("{0:F2}", pago.total);
                h.DrawString(aux.PadLeft(8, '$'), new Font("Arial", 6), Brush, pf, sf);
                position_y += 25;
                //-------------------------------------
                position_y += 15;
                aux = string.Format("{0:F2}", pago.subtotal);
                pf.X = 130;
                pf.Y = position_y;
                sf.Alignment = StringAlignment.Near;
                h.DrawString("A PAGAR: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 370;
                pf.Y = position_y;
                sf.Alignment = StringAlignment.Far;
                h.DrawString(aux.PadLeft(8, '*'), new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;
                //--------------------------------------
                //-------------------------------------
                aux = string.Format("{0:F2}", pago.iva);
                pf.X = 130;
                pf.Y = position_y;
                sf.Alignment = StringAlignment.Near;
                h.DrawString("IVA: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 370;
                pf.Y = position_y;
                sf.Alignment = StringAlignment.Far;
                h.DrawString(aux.PadLeft(8, '*'), new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;
                //--------------------------------------
                //-------------------------------------
                aux = string.Format("{0:F2}", pago.descuento);
                pf.X = 130;
                pf.Y = position_y;
                sf.Alignment = StringAlignment.Near;
                h.DrawString("USTED AHORRO: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 370;
                pf.Y = position_y;
                sf.Alignment = StringAlignment.Far;
                h.DrawString(aux.PadLeft(8, '*'), new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;
                //--------------------------------------
                //-------------------------------------
                aux = string.Format("{0:F2}", pago.total);
                pf.X = 130;
                pf.Y = position_y;
                sf.Alignment = StringAlignment.Near;
                h.DrawString("TOTAL: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 370;
                pf.Y = position_y;
                sf.Alignment = StringAlignment.Far;
                h.DrawString(aux.PadLeft(8, '*'), new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;
                //-------------------------------------
                position_y += 15;
                //-------------------------------------                
                pf.X = 130;
                pf.Y = position_y;
                sf.Alignment = StringAlignment.Near;
                h.DrawString("DATOS DEL PAGO ", new Font("Arial", 6), Brush, pf, sf);
                //--------------------------------------
                position_y += 15;
                //-------------------------------------
                aux = string.Format("{0:F2}", pago.pago);
                pf.X = 130;
                pf.Y = position_y;
                sf.Alignment = StringAlignment.Near;
                h.DrawString("SU PAGO: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 370;
                pf.Y = position_y;
                sf.Alignment = StringAlignment.Far;
                h.DrawString(aux.PadLeft(8, '*'), new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;
                //--------------------------------------
                //-------------------------------------
                aux = string.Format("{0:F2}", pago.cambio);
                pf.X = 130;
                pf.Y = position_y;
                sf.Alignment = StringAlignment.Near;
                h.DrawString("SU CAMBIO: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 370;
                pf.Y = position_y;
                sf.Alignment = StringAlignment.Far;
                h.DrawString(aux.PadLeft(8, '*'), new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;
                //--------------------------------------
                position_y += 15;
                //-------------------------------------                
                pf.X = 130;
                pf.Y = position_y;
                sf.Alignment = StringAlignment.Near;
                h.DrawString("SALDO ACTUAL ", new Font("Arial", 6), Brush, pf, sf);
                //--------------------------------------
                position_y += 15;
                //-------------------------------------
                aux = string.Format("{0:F2}", pago.totalVenta);
                pf.X = 130;
                pf.Y = position_y;
                sf.Alignment = StringAlignment.Near;
                h.DrawString("SALDO INICIAL: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 370;
                pf.Y = position_y;
                sf.Alignment = StringAlignment.Far;
                h.DrawString(aux.PadLeft(8, '*'), new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;
                //--------------------------------------
                //-------------------------------------
                aux = string.Format("{0:F2}", pago.pagado);
                pf.X = 130;
                pf.Y = position_y;
                sf.Alignment = StringAlignment.Near;
                h.DrawString("PAGOS: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 370;
                pf.Y = position_y;
                sf.Alignment = StringAlignment.Far;
                h.DrawString(aux.PadLeft(8, '*'), new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;
                //--------------------------------------
                //-------------------------------------
                aux = string.Format("{0:F2}", pago.pendiente);
                pf.X = 130;
                pf.Y = position_y;
                sf.Alignment = StringAlignment.Near;
                h.DrawString("ADEUDO: ", new Font("Arial", 6), Brush, pf, sf);
                pf.X = 370;
                pf.Y = position_y;
                sf.Alignment = StringAlignment.Far;
                h.DrawString(aux.PadLeft(8, '*'), new Font("Arial", 6), Brush, pf, sf);
                position_y += 15;
                //--------------------------------------
           
        }
        private void agregarPieTicket(ref Graphics g, PageSettings ps)
        {
            
                position_y += 15;
                this.addTextLeft("FOLIO: " + venta.Folio, ref g, ps.PaperSize.Width, ps.PaperSize.Height);
                
                if (tipo == 3)
                this.addTextLeft("FECHA DE ENTREGA: " + venta.Fecupd.ToShortDateString(), ref g, ps.PaperSize.Width, ps.PaperSize.Height);
                
                if (tipo != 4)
                  //  this.addTextLeft("CLIENTE: " + venta.NombreCliente.ToUpper(), ref g, ps.PaperSize.Width, ps.PaperSize.Height);
                //this.addTextLeft("VENDEDOR: " + venta.NombreVendedor.ToUpper(), ref g, ps.PaperSize.Width, ps.PaperSize.Height);

                this.addDatosPie(ref g, ps, "CLIENTE: " + venta.NombreCliente.ToUpper(), new Font("Arial", 6), StringAlignment.Near, 2);
                this.addDatosPie(ref g, ps, "VENDEDOR: " + venta.NombreVendedor.ToUpper(), new Font("Arial", 6), StringAlignment.Near, 2);
                
                
                if (tipo!=4)
                this.addTextLeft("FECHA Y HORA: " + venta.FecVenta.ToString(), ref g, ps.PaperSize.Width, ps.PaperSize.Height);
                
                if (tipo == 4)
                {
                    this.addTextLeft("FECHA: " + venta.fechaCancelacion.ToString("dd/MM/yyyy HH:mm:ss"), ref g, ps.PaperSize.Width, ps.PaperSize.Height);
                    this.addTextLeft("                                 Firma", ref g, ps.PaperSize.Width, ps.PaperSize.Height);
                    this.addTextLeft("", ref g, ps.PaperSize.Width, ps.PaperSize.Height);  
                    this.addTextLeft("______________________________________", ref g, ps.PaperSize.Width, ps.PaperSize.Height);
                    this.addTextLeft("CLIENTE: " + venta.NombreCliente.ToUpper(), ref g, ps.PaperSize.Width, ps.PaperSize.Height);                
                }
                position_y += 10;
                switch (tipo)
                {
                    case 1:
                        this.addletterspace_comentario('-', ref g, ps.PaperSize.Width, ps.PaperSize.Height, new Font("Arial", 8));
                        if (!string.IsNullOrEmpty(datos.mensaje1))
                        {
                            
                            this.addMensaje(ref g, ps, datos.mensaje1, new Font("Arial", 6), StringAlignment.Center, ps.PaperSize.Width);
                        }
                        break;
                    case 2: 
                        this.addletterspace_comentario('-', ref g, ps.PaperSize.Width, ps.PaperSize.Height, new Font("Arial", 8));
                        if (!string.IsNullOrEmpty(datos.mensaje2))
                            this.addMensaje(ref g, ps, datos.mensaje2, new Font("Arial", 6), StringAlignment.Center, ps.PaperSize.Width);
                        break;
                    case 3:
                        this.addletterspace_comentario('-', ref g, ps.PaperSize.Width, ps.PaperSize.Height, new Font("Arial", 8));
                        if (!string.IsNullOrEmpty(datos.mensaje2))
                            this.addMensaje(ref g, ps, datos.mensaje2, new Font("Arial", 6), StringAlignment.Center, ps.PaperSize.Width);
                        break;
                    case 4:
                        this.addletterspace_comentario('-', ref g, ps.PaperSize.Width, ps.PaperSize.Height, new Font("Arial", 8));
                        if (!string.IsNullOrEmpty(datos.mensaje1))
                        {
                            this.addMensaje(ref g, ps, datos.mensaje2, new Font("Arial", 6), StringAlignment.Center, ps.PaperSize.Width);
                        }
                        break;
                    /*
                    case 5:
                    case 6: this.addTextLeft(venta.FecVenta.ToString(), ref g, ps.PaperSize.Width, ps.PaperSize.Height);
                        position_y += 15;
                        if (!string.IsNullOrEmpty(datos.mensaje2))
                            this.addMensaje(ref g, ps, datos.mensaje2, new Font("Arial", 8, FontStyle.Bold), StringAlignment.Near, 10);
                        break;
                     */
                }
                if (!string.IsNullOrEmpty(datos.mensaje3))
                {
                    this.addMensaje(ref g, ps, datos.mensaje3, new Font("Arial", 6), StringAlignment.Center, ps.PaperSize.Width);
                    this.addletterspace_comentario('-', ref g, ps.PaperSize.Width, ps.PaperSize.Height, new Font("Arial", 8));
                }
           
        }
        #endregion
        #region Métodos Auxiliares
        private void addTitleCenter(string text, ref Graphics h, int max_x, int max_y)
        {
            SolidBrush Brush = new SolidBrush(Color.Black);
            PointF pf = new PointF();
            pf.X = max_x / 2;
            pf.Y = position_y += 15;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            h.DrawString(text, new Font("Arial", 6, FontStyle.Bold), Brush, pf, sf);
        }
        private void addTextCenter(string text, ref Graphics h, int max_x, int max_y)
        {
            SolidBrush Brush = new SolidBrush(Color.Black);
            PointF pf = new PointF();
            pf.X = max_x / 2;
            pf.Y = position_y += 15;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            h.DrawString(text, new Font("Arial", 6), Brush, pf, sf);
        }
        private void addTextLeft(string text, ref Graphics h, int max_x, int max_y)
        {
            SolidBrush Brush = new SolidBrush(Color.Black);
            PointF pf = new PointF();
            int x = 2;
            pf.X = x;
            pf.Y = position_y += 15;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            h.DrawString(text, new Font("Arial", 6), Brush, pf, sf);
        }
        private void addTextRigth(string text, ref Graphics h, int max_x, int max_y)
        {
            SolidBrush Brush = new SolidBrush(Color.Black);
            PointF pf = new PointF();
            pf.X = 300;
            pf.Y = position_y += 15;
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Far;
            h.DrawString(text, new Font("Arial", 6), Brush, pf, sf);
        }
        private void addCB(string folio, ref Graphics h, int max_x, int max_y)
        {
            SolidBrush Brush = new SolidBrush(Color.Black);
            PointF pf = new PointF();
            pf.Y = position_y += 20;
            folio = folio + BarCodeEan13.Ean13.CalculateChecksum(folio);
            BarCodeEan13.Ean13 barcode = new BarCodeEan13.Ean13(folio, null);
            Image folio_cbarra = barcode.Paint();
            pf.X = (int)(max_x - folio_cbarra.Width) / 2;
            h.DrawImage(folio_cbarra, pf);
            position_y += folio_cbarra.Height;
        }
        private void addLogo(ref Graphics h, int max_x, int max_y)
        {
            SolidBrush Brush = new SolidBrush(Color.Black);
            PointF pf = new PointF();
            pf.Y = position_y += 20;
            Image logoImg;
            try
            {
                logoImg = Image.FromFile(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Empresas\" + Comun.id_empresa + ".png"));
            }
            catch (Exception)
            {
                logoImg = PuntodeVentaTintoreria.Properties.Resources.fondo01;
            }
            pf.X = (int)(max_x - 150) / 2;
            h.DrawImage(logoImg, pf.X, pf.Y, 150, 50);
            position_y += 50;
        }
        private void addletterspace_comentario(char letra, ref Graphics h, int max_x, int may_y, Font fuente)
        {
           
                string cadena = "";
                for (int i = 0; i < 55; i++)
                    cadena += letra;
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF pf = new PointF();
                pf.X = 2;
                pf.Y = position_y += 15;
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                h.DrawString(cadena, fuente, Brush, pf, sf);
          
        }
        private void addletterspace(char letra, ref Graphics h, int max_x, int may_y, Font fuente)
        {
            
                string cadena = "";
                for (int i = 0; i < 75; i++)
                    cadena += letra;
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF pf = new PointF();
                pf.X = 10;
                pf.Y = position_y += 15;
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;
                h.DrawString(cadena, fuente, Brush, pf, sf);
           
        }
        private void addMensaje (ref Graphics g, PageSettings ps, string mensajes, Font fuente, StringAlignment sa, int px)
        {
          
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF pf = new PointF();
                pf.X = px/2;
                if (!venta.banBloqueoMultipleFormasPago) { pf.Y = position_y += 30; }
                else{ pf.Y = position_y += 18;}
                StringFormat sf = new StringFormat();
                sf.Alignment = sa;

                string cadena = "", palabra = "", lastcadena = "", lastpalabra = "";
                int i = 0;
                bool band = false;

                string[] lineas = Regex.Split(mensajes, "\r\n");

                foreach (string mensajeLinea in lineas)
                {
                    string mensaje = mensajeLinea.Trim();
                    while (i < mensaje.Length)
                    {
                        while (cadena.Length < 25)
                        {
                            while (mensaje[i] != ' ')
                            {
                                palabra += mensaje[i];
                                i++;
                                    if (i >= mensaje.Length)
                                    {
                                        band = true;
                                        break;
                                    }
                                
                                
                            }
                            palabra += ' ';
                            i++;
                            lastcadena = cadena;
                            lastpalabra = palabra;
                            cadena += palabra;
                            palabra = "";
                            if (band)
                                break;
                        }
                        if (i >= mensaje.Length)
                        {
                            g.DrawString(cadena, fuente, Brush, pf, sf);
                            pf.Y = position_y += 12;
                        }
                        else
                        {
                            g.DrawString(lastcadena, fuente, Brush, pf, sf);
                            pf.Y = position_y += 12;
                            cadena = lastpalabra;
                        }
                    }
                    
                    i = 0;
                    band = false;
                    lastcadena = "";
                    lastpalabra = "";
                    cadena = "";
                    palabra = "";
                }
               pf.Y = position_y -= 5;
            
        }
        private void addDatosPie(ref Graphics g, PageSettings ps, string mensajes, Font fuente, StringAlignment sa, int px)
        {
           
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF pf = new PointF();
                pf.X = px;
                pf.Y = position_y += 14;
                StringFormat sf = new StringFormat();
                sf.Alignment = sa;

                string cadena = "", palabra = "", lastcadena = "", lastpalabra = "";
                int i = 0;
                bool band = false;

                string[] lineas = Regex.Split(mensajes, "\r\n");

                foreach (string mensajeLinea in lineas)
                {
                    string mensaje = mensajeLinea.Trim();
                    while (i < mensaje.Length)
                    {
                        while (cadena.Length <= 30)
                        {
                            while (mensaje[i] != ' ')
                            {
                                palabra += mensaje[i];
                                i++;
                                if (i >= mensaje.Length)
                                {
                                    band = true;
                                    break;
                                }
                            }
                            palabra += ' ';
                            i++;
                            lastcadena = cadena;
                            lastpalabra = palabra;
                            cadena += palabra;
                            palabra = "";
                            if (band)
                                break;
                        }
                        if (i >= mensaje.Length)
                        {
                            g.DrawString(cadena, fuente, Brush, pf, sf);
                            pf.Y = position_y += 12;
                        }
                        else
                        {
                            g.DrawString(lastcadena, fuente, Brush, pf, sf);
                            pf.Y = position_y += 12;
                            cadena = lastpalabra;
                        }
                    }
                    pf.Y = position_y-= 12;
                    i = 0;
                    band = false;
                    lastcadena = "";
                    lastpalabra = "";
                    cadena = "";
                    palabra = "";
                }

          
        }
        private void addDatosContenido(ref Graphics g, PageSettings ps, string mensajes, Font fuente, StringAlignment sa, int px)
        {
           
                SolidBrush Brush = new SolidBrush(Color.Black);
                PointF pf = new PointF();
                pf.X = px;
                pf.Y = position_y;
                StringFormat sf = new StringFormat();
                sf.Alignment = sa;

                string cadena = "", palabra = "", lastcadena = "", lastpalabra = "";
                int i = 0;
                bool band = false;

                string[] lineas = Regex.Split(mensajes, "\r\n");

                foreach (string mensajeLinea in lineas)
                {
                    string mensaje = mensajeLinea.Trim();
                    while (i < mensaje.Length)
                    {
                        while (cadena.Length <= 13)
                        {
                            while (mensaje[i] != ' ')
                            {
                                palabra += mensaje[i];
                                i++;
                                if (i >= mensaje.Length)
                                {
                                    band = true;
                                    break;
                                }
                            }
                            palabra += ' ';
                            i++;
                            lastcadena = cadena;
                            lastpalabra = palabra;
                            cadena += palabra;
                            palabra = "";
                            if (band)
                                break;
                        }
                        if (i >= mensaje.Length)
                        {
                            g.DrawString(cadena, fuente, Brush, pf, sf);
                            pf.Y = position_y += 10;
                        }
                        else
                        {
                            g.DrawString(lastcadena, fuente, Brush, pf, sf);
                            pf.Y = position_y += 10;
                            cadena = lastpalabra;
                        }
                    }
                    i = 0;
                    band = false;
                    lastcadena = "";
                    lastpalabra = "";
                    cadena = "";
                    palabra = "";
                }

           
        }
        #endregion

        #endregion
    }
}
