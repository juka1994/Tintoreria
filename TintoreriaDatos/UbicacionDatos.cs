using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TintoreriaGlobal;

namespace TintoreriaDatos
{
    public class UbicacionDatos : HelperSQL
    {
        public List<Ubicacion> ObtenerListaUbicaciones(string idSucursal, int idTipoServicio)
        {
            try
            {
                List<Ubicacion> lista = new List<Ubicacion>();
                Ubicacion item;

                object[] parametros = { idSucursal, idTipoServicio };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(ConexionSQL, "Ubicacion.get_Ubicaciones", parametros);

                while (dr.Read())
                {
                    item = new Ubicacion();
                    item.IdUbicacion = !dr.IsDBNull(dr.GetOrdinal("id_ubicacion")) ? dr.GetInt32(dr.GetOrdinal("id_ubicacion")) : 0;
                    item.Descripcion = !dr.IsDBNull(dr.GetOrdinal("descripcion")) ? dr.GetString(dr.GetOrdinal("descripcion")) : string.Empty;
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
