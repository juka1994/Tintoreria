using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TintoreriaDatos;
using TintoreriaGlobal;

namespace TintoreriaNegocio
{
    public class VentaTintoreriaNegocio
    {
        #region Variables
        private VentaTintoreriaDatos oDatos;
        #endregion
        #region Constructor
        public VentaTintoreriaNegocio()
        {
            oDatos = new VentaTintoreriaDatos();
        }
        #endregion
        #region Métodos
        public void ObtenerUbicaciones(string idsucursal, int idservicio, ref string idubicacion, ref string ubicacion)
        {
            VentaTintoreriaDatos datos = new VentaTintoreriaDatos();
            datos.ObtenerUbicaciones(idsucursal, idservicio, ref idubicacion, ref ubicacion);
        }

        public void ActualizarStatusProceso(string idsucursal, string idventa, int status)
        {
            VentaTintoreriaDatos datos = new VentaTintoreriaDatos();
            datos.ActualizarStatusProceso(idsucursal, idventa, status);

        }

        public DataTable ObtenerListaProcesos(string idsucursal, int idstatus)
        {
            VentaTintoreriaDatos datos = new VentaTintoreriaDatos();
            return datos.ObtenerListaProcesos(idsucursal, idstatus);
        }

        public Ticket GetDatosGeneralesTicket(string idVenta)
        {
            VentaTintoreriaDatos oDatos = new VentaTintoreriaDatos();
            return oDatos.GetDatosGeneralesTicket(idVenta);
        }

        public List<TicketDetalle> GetListaTicketDetalles(string idVenta)
        {
            VentaTintoreriaDatos oDatos = new VentaTintoreriaDatos();
            return oDatos.GetListaTicketDetalles(idVenta);
        }

        public DataTable GetPreciosPorTipoProducto()
        {
            return oDatos.GetPreciosPorTipoProducto();
        }
        #endregion
    }
}
