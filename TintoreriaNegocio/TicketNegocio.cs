using System.Collections.Generic;
using System.Data;
using TintoreriaDatos;
using TintoreriaGlobal;

namespace TintoreriaNegocio
{
    public class TicketNegocio
    {
        #region Attributes Control
        readonly TicketDatos oDatos;
        #endregion

        #region Constructors
        public TicketNegocio()
        {
            this.oDatos = new TicketDatos();
        }
        #endregion

        #region Methods
        public Ticket obtenerDatosGenerales(Ticket ticket)
        {
            return oDatos.obtenerDatosGenerales(ticket);
        }
        public VentaProductos obtenerDatosGlobales(VentaProductos vp)
        {
            return oDatos.obtenerDatosGlobales(vp);
        }
        public List<VentaProductos> obtenerDatosVenta(VentaProductos vp)
        {
            return oDatos.obtenerDatosVenta(vp);
        }
        public void ObtenerMonederoVenta(string conexion, ref string monto_monedero, string id_venta)
        {
            oDatos.ObtenerMonederoVenta(conexion, ref monto_monedero, id_venta);
        }
        public DataTable ObtenerDatosTicket(string folio)
        {
            return oDatos.ObtenerDatosTicket(folio);
        }
        public RespuestaSQL Configuracion_ac_Configuracion(Equipo oEquipo, int opcion)
        {
            return oDatos.Configuracion_ac_Configuracion(oEquipo, opcion);
        }
        public RespuestaSQL Ticket_cambiarUbicacion(string id_ventaServicio, int id_ubicacion)
        {
            return oDatos.Ticket_cambiarUbicacion(id_ventaServicio, id_ubicacion);
        }
        public RespuestaSQL Ticket_EntregarVentaServicio(string idVentaServicio, string idUsuario)
        {
            return oDatos.Ticket_EntregarVentaServicio(idVentaServicio, idUsuario);
        }
        public RespuestaSQL Ticket_TerminarVentaServicio(string idVentaServicio, string idUsuario)
        {
            return oDatos.Ticket_TerminarVentaServicio(idVentaServicio, idUsuario);
        }
        public Venta Ticket_GetPagoPendiente(string idVentaServicio)
        {
            return oDatos.Ticket_GetPagoPendiente(idVentaServicio);
        }
        #endregion

    }
}
