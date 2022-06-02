using TintoreriaGlobal;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaDatos
{
    public class BusquedaDatos
    {
        public Busqueda ValidarFolioTransferencia(string Folio, string Conexion)
        {
            try
            {
                Busqueda datos = new Busqueda();
                object result = SqlHelper.ExecuteScalar(Conexion, "spCSLDB_ValidarFolioTransaccionTransferencia", Folio);
                if (result != null)
                {
                    datos.Validador = Convert.ToBoolean(result.ToString());
                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
