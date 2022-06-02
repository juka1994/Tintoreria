using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TintoreriaGlobal;

namespace TintoreriaDatos
{
    public class RopaDatos : HelperSQL
    {
        #region Métodos
        public DataTable GetIndex()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "[Cat].[spCSLDB_index_ropa]");
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

        public RespuestaSQL Delete(Ropa oRopa)
        {
            try
            {
                object[] parametros =
                {
                    oRopa.Id,
                    Comun.id_u
                };
                RespuestaSQL oRespuesta = new RespuestaSQL();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(
                    ConexionSQL,
                    "[Cat].[spCSLDB_Delete_ropa]",
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

        public RespuestaSQL AC(Ropa oRopa, int opcion)
        {
            try
            {
                object[] parametros =
                {
                    opcion,
                    oRopa.Id,
                    oRopa.IdTipoRopa,
                    oRopa.IdSubTipoRopa,
                    oRopa.IdGrupo,
                    Comun.id_u
                };
                RespuestaSQL oRespuesta = new RespuestaSQL();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(
                    ConexionSQL,
                    "[Cat].[spCSLDB_ac_ropa]",
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

        public Ropa GetItem(string id)
        {
            try
            {
                object[] parametros =
                {
                    id.Trim()
                };
                Ropa oRespuesta = new Ropa();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(
                    ConexionSQL,
                    "[Cat].[spCSLDB_get_ropa]",
                    parametros
                );

                while (dr.Read())
                {
                    oRespuesta.Id = !dr.IsDBNull(dr.GetOrdinal("id")) ? dr.GetString(dr.GetOrdinal("id")) : string.Empty;
                    oRespuesta.IdTipoRopa = !dr.IsDBNull(dr.GetOrdinal("id_tipoRopa")) ? dr.GetInt32(dr.GetOrdinal("id_tipoRopa")) : 0;
                    oRespuesta.IdSubTipoRopa = !dr.IsDBNull(dr.GetOrdinal("id_subTipoRopa")) ? dr.GetString(dr.GetOrdinal("id_subTipoRopa")) : string.Empty;
                    oRespuesta.IdGrupo = !dr.IsDBNull(dr.GetOrdinal("id_grupo")) ? dr.GetInt32(dr.GetOrdinal("id_grupo")) : 0;
                }
                dr.Close();

                return oRespuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
