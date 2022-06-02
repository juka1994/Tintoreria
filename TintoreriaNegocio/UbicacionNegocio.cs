
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TintoreriaGlobal;
using TintoreriaDatos;

namespace TintoreriaNegocio
{
    public class UbicacionNegocio
    {
        public List<Ubicacion> ObtenerListaUbicaciones(string idSucursal, int idTipoServicio)
        {
            UbicacionDatos oDatos = new UbicacionDatos();
            return oDatos.ObtenerListaUbicaciones(idSucursal, idTipoServicio);
        }
    }
}
