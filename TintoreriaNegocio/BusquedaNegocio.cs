using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class BusquedaNegocio
    {
        public Busqueda ValidarFolioTransferencia(string Folio, string Conexion)
        {
            try
            {
                BusquedaDatos bd = new BusquedaDatos();
                return bd.ValidarFolioTransferencia(Folio, Conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
