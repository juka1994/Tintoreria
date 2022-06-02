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
    public class TipoRopaDatos : HelperSQL
    {
        #region Métodos
        public TipoRopa LLenarGridTipoRopa(TipoRopa Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "[Cat].[spCSLDB_get_TipoRopa]");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            Datos.TablaDatos = ds.Tables[0];
                        }
                    }
                }
                return Datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ACTipoRopa(TipoRopa Datos, ref int Verificador)
        {
            try
            {
                object[] Valores = { Datos.Opcion, Datos.IDTipoRopa, Datos.Descripcion.Trim(), Datos.Imagen, Datos.IDUsuario, Datos.Extension, Datos.ImagenModificada };
                object res = SqlHelper.ExecuteScalar(Datos.Conexion, "[Cat].[spCSLDB_ac_ServTintoreria_TipoRopa]", Valores);
                if (res != null)
                {
                    Datos.IDTipoRopa = Convert.ToInt32(res.ToString());
                    Verificador = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarTipoRopa(TipoRopa Datos, ref int Verificador)
        {
            try
            {
                int Resultado = 0;
                object[] Valores = { Datos.IDTipoRopa, Datos.IDUsuario };
                object res = SqlHelper.ExecuteScalar(Datos.Conexion, "[Cat].[spCSLDB_del_ServTintoreria_TipoRopa]", Valores);
                if (res != null)
                {
                    Resultado = Convert.ToInt32(res.ToString());
                    if (Resultado == 1)
                    {
                        Verificador = 1;
                    }
                    else
                    {
                        Verificador = 0;
                    }
                }
                else
                {
                    Verificador = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TipoRopa ObtenerImagen(TipoRopa Datos)
        {
            try
            {
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "[Cat].[spCSLDB_get_TipoRopaXID]", Datos.IDTipoRopa);
                while (Dr.Read())
                {
                    Datos.Imagen = !Dr.IsDBNull(Dr.GetOrdinal("Imagen")) ? Dr.GetString(Dr.GetOrdinal("Imagen")) : string.Empty;
                }
                Dr.Close();
                return Datos;
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
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "[Cat].[spCSLDB_combo_tipoRopa]");
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
