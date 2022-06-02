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
    public class TipoFibraRopaDatos : HelperSQL
    {
        public TipoFibraRopa ObtenerGridTipoFibraRopa(TipoFibraRopa Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "[Cat].[spCSLDB_get_ServTintoreria_FibraRopa]");
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
                throw;
            }
        }

        public void ACFibraRopa(TipoFibraRopa Datos, ref int Verificador)
        {
            try
            {
                object[] Values = { Datos.Opcion, Datos.IDFibraRopa, Datos.Descripcion, Datos.Imagen, Datos.IDUsuario, Datos.Extension, Datos.ImagenModificada };
                object res = SqlHelper.ExecuteScalar(ConexionSQL, "[Cat].[spCSLDB_ac_ServTintoreria_FibraRopa]", Values);
                if (res != null)
                {
                    Datos.IDFibraRopa = Convert.ToInt32(res.ToString());
                    Verificador = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarFibraRopa(TipoFibraRopa Datos, ref int Verificador)
        {
            try
            {
                int Resultado = 0;
                object[] Parametros = { Datos.IDFibraRopa, Datos.IDUsuario };
                object res = SqlHelper.ExecuteScalar(ConexionSQL, "[Cat].[spCSLDB_del_ServTintoreria_FibraRopa]", Parametros);
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

        public TipoFibraRopa ObtenerImagen(TipoFibraRopa Datos)
        {
            try
            {
                SqlDataReader Dr = SqlHelper.ExecuteReader(ConexionSQL, "[Cat].[spCSLDB_get_ServTintoreria_FibraRopaXID]", Datos.IDFibraRopa);
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
    }
}
