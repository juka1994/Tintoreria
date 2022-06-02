namespace TintoreriaDatos
{
    using Microsoft.ApplicationBlocks.Data;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using TintoreriaGlobal;

    public class SimboloTextilDatos : HelperSQL
    {
        #region Methods
        public DataTable GetIndex()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "[Cat].[spCSLDB_index_SimboloTextiles]");
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

        public RespuestaSQL Delete(SimboloTextil oSimboloTextil)
        {
            try
            {
                object[] parametros =
                {
                    oSimboloTextil.Id,
                    oSimboloTextil.id_usuario
                };
                RespuestaSQL oRespuesta = new RespuestaSQL();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(
                    ConexionSQL,
                    "[Cat].[spCSLDB_Delete_SimboloTextil]",
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

        public RespuestaSQL AC_SimboloTextil(SimboloTextil oSimboloTextil)
        {
            try
            {
                object[] parametros = 
                {
                    oSimboloTextil.opcion,
                    oSimboloTextil.Id,
                    oSimboloTextil.IdTipoSimboloRopa,
                    oSimboloTextil.Descripcion,
                    oSimboloTextil.ImagenBase64,
                    oSimboloTextil.id_usuario,
                    oSimboloTextil.Extension,
                    oSimboloTextil.ImagenModificada
                };
                RespuestaSQL oRespuesta = new RespuestaSQL();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(
                    ConexionSQL, 
                    "[Cat].[spCSLDB_AC_SimboloTextil]", 
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

        public SimboloTextil GetItem(int id)
        {
            try
            {
                SimboloTextil item = new SimboloTextil();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(ConexionSQL, "[Cat].[spCSLDB_get_SimboloTextil]", id);
                while (dr.Read())
                {
                    item = new SimboloTextil();
                    item.Id = !dr.IsDBNull(dr.GetOrdinal("id")) ? dr.GetInt32(dr.GetOrdinal("id")) : 0;
                    item.Descripcion = !dr.IsDBNull(dr.GetOrdinal("descripcion")) ? dr.GetString(dr.GetOrdinal("descripcion")) : string.Empty;
                    item.IdTipoSimboloRopa = !dr.IsDBNull(dr.GetOrdinal("id_tipoSimboloRopa")) ? dr.GetInt32(dr.GetOrdinal("id_tipoSimboloRopa")) : 0;
                    item.ImagenBase64 = !dr.IsDBNull(dr.GetOrdinal("logo")) ? dr.GetString(dr.GetOrdinal("logo")) : string.Empty;
                }
                dr.Close();

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
