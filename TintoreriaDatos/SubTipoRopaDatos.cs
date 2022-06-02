namespace TintoreriaDatos
{
    using Microsoft.ApplicationBlocks.Data;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using TintoreriaGlobal;

    public class SubTipoRopaDatos : HelperSQL
    {
        #region Métodos
        public DataTable GetIndex()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "[Cat].[spCSLDB_index_subTipoRopa]");
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

        public DataTable GetCombo()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "[Cat].[spCSLDB_combo_subTipoRopa]");
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

        public RespuestaSQL Delete(SubTipoRopa subTipo)
        {
            try
            {
                object[] parametros =
                {
                    subTipo.Id,
                    Comun.id_u
                };
                RespuestaSQL oRespuesta = new RespuestaSQL();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(
                    ConexionSQL,
                    "[Cat].[spCSLDB_Delete_subTipoRopa]",
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

        public SubTipoRopa GetSubTipoRopaXId(int id)
        {
            try
            {
                object[] parametros =
                {
                    id
                };
                SubTipoRopa oRespuesta = new SubTipoRopa();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(
                    ConexionSQL,
                    "[Cat].[spCSLDB_get_subTipoRopaXId]",
                    parametros
                );

                while (dr.Read())
                {
                    oRespuesta.Id = !dr.IsDBNull(dr.GetOrdinal("id")) ? dr.GetInt32(dr.GetOrdinal("id")) : 0;
                    oRespuesta.Descripcion = !dr.IsDBNull(dr.GetOrdinal("descripcion")) ? dr.GetString(dr.GetOrdinal("descripcion")) : string.Empty;
                    oRespuesta.ImagenBase64 = !dr.IsDBNull(dr.GetOrdinal("logo")) ? dr.GetString(dr.GetOrdinal("logo")) : string.Empty;
                }
                dr.Close();

                return oRespuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RespuestaSQL AC(SubTipoRopa oSubTipoRopa, int opcion)
        {
            try
            {
                object[] parametros =
                {
                    opcion,
                    oSubTipoRopa.Id,
                    oSubTipoRopa.Descripcion,
                    Comun.id_u,
                    oSubTipoRopa.ImagenBase64,
                    oSubTipoRopa.Extension,
                    oSubTipoRopa.ImagenModificada
                };
                RespuestaSQL oRespuesta = new RespuestaSQL();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(
                    ConexionSQL,
                    "[Cat].[spCSLDB_ac_subTipoRopa]",
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
        #endregion
    }
}
