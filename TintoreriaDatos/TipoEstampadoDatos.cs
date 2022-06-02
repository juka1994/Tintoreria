namespace TintoreriaDatos
{
    using Microsoft.ApplicationBlocks.Data;
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using TintoreriaGlobal;

    public class TipoEstampadoDatos
    {
        public TipoEstampado LLenarGridEstampado(TipoEstampado Datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "[Cat].[spCSLDB_get_ServTintoreria_EstampadoRopa]");
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

        public void ACEstampado(TipoEstampado Datos, ref int Verificador)
        {
            try
            {
                object[] Values = { Datos.Opcion, Datos.IDEstampado, Datos.Descripcion, Datos.Imagen, Datos.IDUsuario, Datos.Extension, Datos.ImagenModificada};
                object res = SqlHelper.ExecuteScalar(Datos.Conexion, "[Cat].[spCSLDB_ac_ServTintoreria_EstampadoRopa]", Values);
                if (res != null)
                {
                    Datos.IDEstampado = Convert.ToInt32(res.ToString());
                    Verificador = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarEstampado(TipoEstampado Datos, ref int Verificador)
        {
            try
            {
                int Resultado = 0;
                object[] Parametros = { Datos.IDEstampado, Datos.IDUsuario };
                object res = SqlHelper.ExecuteScalar(Datos.Conexion, "[Cat].[spCSLDB_del_ServTintoreria_EstampadoRopa]", Parametros);
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

        public TipoEstampado ObtenerImagen(TipoEstampado Datos)
        {
            try
            {
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "[Cat].[spCSLDB_get_ServTintoreria_EstampadoRopaXID]", Datos.IDEstampado);
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
