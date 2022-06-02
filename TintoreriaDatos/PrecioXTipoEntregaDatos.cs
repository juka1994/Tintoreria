using Microsoft.ApplicationBlocks.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using TintoreriaGlobal;

namespace TintoreriaDatos
{
    public class PrecioXTipoEntregaDatos : HelperSQL
    {
        #region Métodos
        public DataTable GetIndex(int id)
        {
            try
            {
                object[] parametros =
                {
                    id
                };
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "[Cat].[spCIDDB_index_PrecioXTipoEntrega]", parametros);
                DataTable dt = new DataTable();
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            dt = ds.Tables[0];
                        }
                    }
                }
                ds.Dispose();
                return dt;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public RespuestaSQL Delete(int id)
        {
            try
            {
                object[] parametros =
                {
                    id,
                    Comun.id_u
                };
                RespuestaSQL oRespuesta = new RespuestaSQL();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(
                    ConexionSQL,
                    "[Cat].[spCIDDB_delete_tipoEntrega]",
                    parametros
                );

                while (dr.Read())
                {
                    oRespuesta.Success = !dr.IsDBNull(dr.GetOrdinal("success")) ? dr.GetBoolean(dr.GetOrdinal("success")) : false;
                    oRespuesta.Mensaje = !dr.IsDBNull(dr.GetOrdinal("mensaje")) ? dr.GetString(dr.GetOrdinal("mensaje")) : string.Empty;
                }
                dr.Close();

                return oRespuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RespuestaSQL AC(PrecioXTipoEntrega oPrecioXTipoEntrega, int opcion)
        {
            try
            {
                object[] parametros =
                {
                    opcion,
                    oPrecioXTipoEntrega.Id,
                    oPrecioXTipoEntrega.IdTipoEntrega,
                    oPrecioXTipoEntrega.IdTipoRopa,
                    oPrecioXTipoEntrega.Precio, 
                    Comun.id_u
                };
                RespuestaSQL oRespuesta = new RespuestaSQL();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(
                    ConexionSQL,
                    "[Cat].[spCSLDB_ac_precioXTipoEntrega]",
                    parametros
                );

                while (dr.Read())
                {
                    oRespuesta.Success = !dr.IsDBNull(dr.GetOrdinal("success")) ? dr.GetBoolean(dr.GetOrdinal("success")) : false;
                    oRespuesta.Mensaje = !dr.IsDBNull(dr.GetOrdinal("mensaje")) ? dr.GetString(dr.GetOrdinal("mensaje")) : string.Empty;
                    oRespuesta.MensajeErrorSQL = !dr.IsDBNull(dr.GetOrdinal("mensajeSQL")) ? dr.GetString(dr.GetOrdinal("mensajeSQL")) : string.Empty;
                }
                dr.Close();

                return oRespuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PrecioXTipoEntrega GetItem(int id)
        {
            try
            {
                PrecioXTipoEntrega item = new PrecioXTipoEntrega();
                object[] parametros =
                {
                    id
                };
                SqlDataReader Dr = SqlHelper.ExecuteReader(ConexionSQL, "[Cat].[spCIDDB_get_item]", parametros);
                while (Dr.Read())
                {
                    item = new PrecioXTipoEntrega
                    {
                        Id = !Dr.IsDBNull(Dr.GetOrdinal("id")) ? Dr.GetInt32(Dr.GetOrdinal("id")) : 0,
                        IdTipoEntrega = !Dr.IsDBNull(Dr.GetOrdinal("idTipoEntrega")) ? Dr.GetInt32(Dr.GetOrdinal("idTipoEntrega")) : 0,
                        IdTipoRopa = !Dr.IsDBNull(Dr.GetOrdinal("idTipoRopa")) ? Dr.GetInt32(Dr.GetOrdinal("idTipoRopa")) : 0,
                        Precio = !Dr.IsDBNull(Dr.GetOrdinal("precio")) ? Dr.GetDecimal(Dr.GetOrdinal("precio")) : 0
                    };
                }
                Dr.Close();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        #endregion
    }
}
