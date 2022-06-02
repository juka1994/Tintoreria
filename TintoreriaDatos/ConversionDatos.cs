namespace TintoreriaDatos
{
    using Microsoft.ApplicationBlocks.Data;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using TintoreriaGlobal;

    public class ConversionDatos : HelperSQL
    {
        #region Methods
        public DataTable ObtenerIndex(string idProducto)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "Conversion.spCIDDB_Index", idProducto);
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
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public RespuestaSQL AC(Conversion oConversion, int opcion)
        {
            try
            {
                object[] parametros =
                {
                    opcion,
                    oConversion.Id,
                    oConversion.IdProducto,
                    oConversion.IdUnidadMedidaSalida,
                    oConversion.Cantidad,
                    Comun.id_u
                };
                RespuestaSQL oRespuesta = new RespuestaSQL();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(
                    ConexionSQL,
                    "[Conversion].[spCIDDB_AC]",
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

        public RespuestaSQL Del(Conversion oConversion)
        {
            try
            {
                object[] parametros =
                {
                    oConversion.Id,
                    Comun.id_u
                };
                RespuestaSQL oRespuesta = new RespuestaSQL();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(
                    ConexionSQL,
                    "[Conversion].[spCIDDB_Del]",
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

        public DataTable ObtenerCombo()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "Conversion.spCIDDB_Combo");
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
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Conversion ObtenerItem(int id)
        {
            try
            {
                Conversion item = new Conversion();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(ConexionSQL, "[Conversion].[spCIDDB_Item]", id);
                while (dr.Read())
                {
                    item = new Conversion();
                    item.Id = !dr.IsDBNull(dr.GetOrdinal("id")) ? dr.GetInt32(dr.GetOrdinal("id")) : 0;
                    item.IdUnidadMedidaSalida = !dr.IsDBNull(dr.GetOrdinal("idUnidadMedidaSalida")) ? dr.GetInt32(dr.GetOrdinal("idUnidadMedidaSalida")) : 0;
                    item.Cantidad = !dr.IsDBNull(dr.GetOrdinal("cantidad")) ? dr.GetDecimal(dr.GetOrdinal("cantidad")) : 0;
                }
                dr.Close();

                return item;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ObtenerComboXIdProducto(string IdProducto)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "Conversion.spCIDDB_ComboXIdProducto", IdProducto);
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
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }
}
