using Microsoft.ApplicationBlocks.Data;
using System;
using TintoreriaGlobal;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaDatos
{
    public class EnvioDetalleDatos : HelperSQL
    {
        public List<EnvioDetalle> CargarDatosGridEnvio(int _idEnvio)
        {
            try
            {
                List<EnvioDetalle> Lista = new List<EnvioDetalle>();
                EnvioDetalle Item;
                SqlDataReader dr = SqlHelper.ExecuteReader(ConexionSQL, "[Cat].[spCSLDB_GET_ENVIO_DETALLE]", _idEnvio);
                while (dr.Read())
                {
                    Item = new EnvioDetalle();
                    Item.id_envioDetalle = dr.IsDBNull(dr.GetOrdinal("id_envioDetalle")) ? 0 : dr.GetInt32(dr.GetOrdinal("id_envioDetalle"));
                    Item.id_ventaServicio = dr.IsDBNull(dr.GetOrdinal("id_ventaServicio")) ? string.Empty : dr.GetString(dr.GetOrdinal("id_ventaServicio"));
                    Item.nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? string.Empty : dr.GetString(dr.GetOrdinal("Nombre"));
                    Item.folio =  dr.IsDBNull(dr.GetOrdinal("folio")) ? string.Empty : dr.GetString(dr.GetOrdinal("folio"));
                    Item.recibe = dr.IsDBNull(dr.GetOrdinal("recibe")) ? string.Empty : dr.GetString(dr.GetOrdinal("recibe"));
                    Item.observacion = dr.IsDBNull(dr.GetOrdinal("observacion")) ? String.Empty : dr.GetString(dr.GetOrdinal("observacion"));
                    //Item.id_status = dr.IsDBNull(dr.GetOrdinal("id_status")) ? 0 : dr.GetInt32(dr.GetOrdinal("id_status"));

                    Lista.Add(Item);
                }
               
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GuardarDatos(DataTable _tbl, string user,ref int verificador)
        {
            try
            {
                object res = SqlHelper.ExecuteScalar(ConexionSQL, CommandType.StoredProcedure, "[dbo].[spCSLDB_c_EnvioDetalle]",
                    new SqlParameter("@TblEnvioDetalle", _tbl),
                    new SqlParameter("@ID_USER",user));
                if(res != null)
                {
                    verificador = 1;
                }
                else
                {
                    verificador = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
