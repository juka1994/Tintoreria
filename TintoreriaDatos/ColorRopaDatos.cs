namespace TintoreriaDatos
{
    using TintoreriaGlobal;
    using Microsoft.ApplicationBlocks.Data;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    public class ColorRopaDatos : HelperSQL
    {
        #region Methods
        public void LLenarGridColorRopa(ColorRopa colorRopa)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "spCSLDB_CatColorRopa_Consulta_sp");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            colorRopa.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public RespuestaSQL AbcColorRopa(ColorRopa colorRopa)
        {
            try
            {
                object[] parametros =
                {
                    colorRopa.opcion,
                    colorRopa.id_colorRopa,
                    colorRopa.descripcion,
                    colorRopa.id_u,
                    colorRopa.ImagenBase64,
                    colorRopa.Extension,
                    colorRopa.ImagenModificada
                };
                RespuestaSQL oRespuesta = new RespuestaSQL();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(
                    ConexionSQL,
                    "[Cat].[spCSLDB_AC_ColorRopa]",
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

        public RespuestaSQL Delete(ColorRopa oColorRopa)
        {
            
            try
            {
                object[] parametros =
                {
                oColorRopa.id_colorRopa,
                oColorRopa.id_u
            };
                RespuestaSQL oRespuesta = new RespuestaSQL();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(
                    ConexionSQL,
                    "[Cat].[spCSLDB_Delete_ColorRopa]",
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

        public void ObtenerComboColorRopa(ColorRopa colorRopa)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "spCSLDB_get_ComboCatColorRopa");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            colorRopa.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ColorRopa GetItem(int id)
        {
            try
            {
                ColorRopa item = new ColorRopa();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(ConexionSQL, "[Cat].[spCSLDB_get_ColorRopa]", id);
                while (dr.Read())
                {
                    item = new ColorRopa();
                    item.id_colorRopa = !dr.IsDBNull(dr.GetOrdinal("id")) ? dr.GetInt32(dr.GetOrdinal("id")) : 0;
                    item.descripcion = !dr.IsDBNull(dr.GetOrdinal("descripcion")) ? dr.GetString(dr.GetOrdinal("descripcion")) : string.Empty;
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
