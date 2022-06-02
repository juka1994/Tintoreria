namespace TintoreriaDatos
{
    using Microsoft.ApplicationBlocks.Data;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using TintoreriaGlobal;

    public class TipoSimboloTextilDatos : HelperSQL
    {
        #region Methods
        public DataTable GetIndex()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "[Cat].[spCSLDB_index_TipoSimboloRopa]");
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

        public TipoSimboloTextil GetItem(int id)
        {
            try
            {
                TipoSimboloTextil item = new TipoSimboloTextil();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(ConexionSQL, "[Cat].[spCSLDB_get_TipoSimboloTextil]", id);
                while (dr.Read())
                {
                    item = new TipoSimboloTextil();
                    item.Id = !dr.IsDBNull(dr.GetOrdinal("id")) ? dr.GetInt32(dr.GetOrdinal("id")) : 0;
                    item.Descripcion = !dr.IsDBNull(dr.GetOrdinal("descripcion")) ? dr.GetString(dr.GetOrdinal("descripcion")) : string.Empty;
                }
                dr.Close();

                return item;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RespuestaSQL AC_TipoSimboloTextil(TipoSimboloTextil oTipoSimboloTextil, int opcion)
        {
            try
            {
                object[] parametros =
                {
                    opcion,
                    oTipoSimboloTextil.Id,
                    oTipoSimboloTextil.Descripcion,
                    Comun.id_u
                };
                RespuestaSQL oRespuesta = new RespuestaSQL();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(
                    ConexionSQL,
                    "[Cat].[spCSLDB_AC_TipoSimboloTextil]",
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

        public RespuestaSQL Delete(TipoSimboloTextil oTipoSimboloTextil)
        {
            try
            {
                object[] parametros =
                {
                oTipoSimboloTextil.Id,
                Comun.id_u
            };
                RespuestaSQL oRespuesta = new RespuestaSQL();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(
                    ConexionSQL,
                    "[Cat].[spCSLDB_Delete_TipoSimboloTextil]",
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

        public DataTable GetCombo()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "[Cat].[spCSLDB_combo_TipoSimboloRopa]");
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

        #endregion
    }
}
