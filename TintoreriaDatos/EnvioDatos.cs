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
  public  class EnvioDatos
    {
        public void CargarGridEnvio(Envio env)
        {
            try
            {
                try
                {
                    object[] Valores = { env.id_sucursal };
                    DataSet ds = SqlHelper.ExecuteDataset(env.conexion, "WAspCSLDB_getDatosEnvio_sp");
                    if (ds != null)
                    {
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0] != null)
                            {
                                env.datos = ds.Tables[0];
                            }
                        }
                    }
                }
                catch (SqlException exSQL)
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ActualizarFechaVenta(Envio fechaActualizar)
        {
            try
            {
                try
                {
                    object[] Valores = { fechaActualizar.idventa,fechaActualizar.id_envio, fechaActualizar.recibe, fechaActualizar.fecha_recibe, fechaActualizar.hora_recibe, fechaActualizar.id_u };
                    DataSet ds = SqlHelper.ExecuteDataset(fechaActualizar.conexion, "WAspCSLDB_CambiarFechaRecibe_sp", Valores);

                }
                catch (SqlException exSQL)
                {
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GuardarEnvio(Envio env, DataTable TablaDatosEnviar )
        {
            try
            {
                object res = SqlHelper.ExecuteScalar(env.conexion, CommandType.StoredProcedure, "WAspCSLDB_GuardarEnvio_sp",
                   new SqlParameter("@TablaDatosEnviar", TablaDatosEnviar),
                    new SqlParameter("@id_sucursal", env.id_sucursal),
                    new SqlParameter("@id_chofer", env.id_chofer),
                    new SqlParameter("@id_vehiculo", env.id_vehiculo),
                    new SqlParameter("@usuins", env.id_u));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarDatosListaEnvio(Envio env)
        {
            try
            {
                try
                {
                    object[] Valores = { env.id_envio };
                    DataSet ds = SqlHelper.ExecuteDataset(env.conexion, "[dbo].[WAspCSLDB_getDatosEnvioXID_sp]", Valores);
                    if (ds != null)
                    {
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0] != null)
                            {
                                env.Empresas.nombreComercial = ds.Tables[0].Rows[0]["NombreEmpresa"].ToString();
                                env.Empresas.slogan = ds.Tables[0].Rows[0]["Slogan"].ToString();
                                env.Empresas.rfc = ds.Tables[0].Rows[0]["RFC"].ToString();
                                env.Empresas.pathImg = ds.Tables[0].Rows[0]["Logo"].ToString();
                            }
                            if (ds.Tables[1] != null)
                            {
                                env.NombreChofer = ds.Tables[1].Rows[0]["NombreChofer"].ToString();
                                env.Vehiculo = ds.Tables[1].Rows[0]["Vehiculo"].ToString();
                                env.NombreSucursal = ds.Tables[1].Rows[0]["NombreSucursal"].ToString();
                            }
                            Envio EnvioLis;
                            env.ListaEnvio = new List<Envio>();
                            if (ds.Tables[2] != null)
                            {
                                foreach (DataRow auxResultado in ds.Tables[2].Rows)
                                {
                                    EnvioLis = new Envio();
                                    EnvioLis.folio = auxResultado["Folio"].ToString();
                                    EnvioLis.Cliente = auxResultado["Cliente"].ToString();
                                    EnvioLis.Telefono = auxResultado["Telefono"].ToString();
                                    EnvioLis.Direccion = auxResultado["Direccion"].ToString();
                                    EnvioLis.recibe = auxResultado["Recibe"].ToString();
                                    EnvioLis.Observacion = auxResultado["Observacion"].ToString();
                                    EnvioLis.id_chofer = auxResultado["FirmaRecibe"].ToString();
                                    EnvioLis.fecha_salida = auxResultado["FechaEntrega"].ToString();
                                    env.ListaEnvio.Add(EnvioLis);
                                }
                            }
                        }
                    }
                }
                catch (SqlException exSQL)
                {

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
