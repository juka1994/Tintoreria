using TintoreriaGlobal;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TintoreriaDatos
{
    public class ComunDatos
    {
        public void ObtenerCatalogosTintoreria()
        {

            
            object[] Valores0 = { Comun.id_sucursal };
                DataSet res = SqlHelper.ExecuteDataset(Comun.conexion, "WspCSLDB_TintoreriaCatalogos", Valores0);


            if (res != null)
            {
                if (res.Tables[0] != null && res.Tables[0].Rows.Count > 0)
                    Comun.ListaRopa = res.Tables[0];

                if (res.Tables[1].Rows.Count > 0)
                {
                    Comun.PreciosRopa = new Dictionary<string, decimal>();
                    foreach (DataRow item in res.Tables[1].Rows)
                    {
                        Comun.PreciosRopa.Add(item["id_ropa"].ToString().Trim() + item["id_tipoEntrega"].ToString().Trim()+ item["id_tipoServicio"].ToString().Trim(), Convert.ToDecimal(item["precio"].ToString()));
                    }
                }

                if (res.Tables[8].Rows.Count > 0)
                {
                    Comun.PtosRopa = new Dictionary<string, int>();
                    Comun.MonederoRopa = new Dictionary<string, decimal>();
                    foreach (DataRow item in res.Tables[8].Rows)
                    {
                        Comun.PtosRopa.Add(item["id_grupo"].ToString().Trim() + item["id_tipoCredencial"].ToString().Trim(), Convert.ToInt32(item["porcPtos"].ToString()));
                        Comun.MonederoRopa.Add(item["id_grupo"].ToString().Trim() + item["id_tipoCredencial"].ToString().Trim(), Convert.ToDecimal(item["porcMone"].ToString()));

                    }
                }


                if (res.Tables[2] != null && res.Tables[2].Rows.Count > 0)
                    Comun.EntregasRopa = res.Tables[2];

                if (res.Tables[3] != null && res.Tables[3].Rows.Count > 0)
                    Comun.TipoListaRopa = res.Tables[3];

                if (res.Tables[4] != null && res.Tables[4].Rows.Count > 0)
                    Comun.ColoresRopa = res.Tables[4];

                if (res.Tables[5] != null && res.Tables[5].Rows.Count > 0)
                    Comun.EstampadosRopa = res.Tables[5];

                if (res.Tables[6] != null && res.Tables[6].Rows.Count > 0)
                    Comun.FibrasRopa = res.Tables[6];

                if (res.Tables[7] != null && res.Tables[7].Rows.Count > 0)
                    Comun.SimbolosRopa = res.Tables[7];

                if (res.Tables[9] != null && res.Tables[9].Rows.Count > 0)
                    Comun.ListaChoferes = res.Tables[9];

                if (res.Tables[10] != null && res.Tables[10].Rows.Count > 0)
                    Comun.ListaLimpieza = res.Tables[10];

                
                if (res.Tables[12] != null && res.Tables[12].Rows.Count > 0)
                    Comun.ListaSucursales = res.Tables[12];

                if (res.Tables[13] != null && res.Tables[13].Rows.Count > 0)
                    Comun.ListaVehiculos = res.Tables[13];

                if (res.Tables[14] != null && res.Tables[14].Rows.Count > 0)
                    Comun.FechasFestivas = res.Tables[14];

                

            }

        }


        public void ObtenerConfiguracion(string conexion)
        {
            try
            {
                object[] Valores0 = { Comun.macAddress };
                object res = SqlHelper.ExecuteScalar(conexion, "spCSLDB_obtenerSucursalEquipo", Valores0);
                Comun.id_sucursal = Convert.ToString(res);
                if (!string.IsNullOrEmpty(Comun.id_sucursal) && !string.IsNullOrWhiteSpace(Comun.id_sucursal))
                {
                    SqlDataReader SqlDr = null;
                    object[] Valores = { Comun.id_sucursal,  Comun.macAddress};
                    SqlDr = SqlHelper.ExecuteReader(conexion, "spCSLDB_obtenerConfiguracionInicial", Valores);
                    if (SqlDr.HasRows == true)
                    {
                        while (SqlDr.Read())
                        {
                            Comun.id_sucursal = SqlDr.GetString(SqlDr.GetOrdinal("id_sucursal"));
                            Comun.id_empresa = SqlDr.GetInt32(SqlDr.GetOrdinal("id_empresa"));
                            Comun.id_tu = SqlDr.GetInt32(SqlDr.GetOrdinal("id_tipoSucursal"));
                            Comun.nombre_sucursal = SqlDr.GetString(SqlDr.GetOrdinal("nombre_sucursal"));
                            Comun.id_equipo = SqlDr.GetString(SqlDr.GetOrdinal("id_equipo"));
                            Comun.namePrinter = SqlDr.GetString(SqlDr.GetOrdinal("namePrinter"));
                            Comun.numeroTickets = SqlDr.GetInt32(SqlDr.GetOrdinal("numeroTickets"));
                            Comun.correosistema = SqlDr.GetString(SqlDr.GetOrdinal("correosistema"));
                            Comun.password = SqlDr.GetString(SqlDr.GetOrdinal("password"));
                            Comun.correoelectronico = SqlDr.GetString(SqlDr.GetOrdinal("correoelectronico"));
                            Comun.html = SqlDr.GetBoolean(SqlDr.GetOrdinal("html"));
                            Comun.host = SqlDr.GetString(SqlDr.GetOrdinal("host"));
                            Comun.puerto = SqlDr.GetInt32(SqlDr.GetOrdinal("puerto"));
                            Comun.ssl = SqlDr.GetBoolean(SqlDr.GetOrdinal("ssl"));
                            Comun.horaCierre = SqlDr.GetString(SqlDr.GetOrdinal("horaCierre"));
                            Comun.horaApertura = SqlDr.GetString(SqlDr.GetOrdinal("horaApertura"));
                            //cambiara 
                            Comun.iva = SqlDr.GetDecimal(SqlDr.GetOrdinal("iva"));
                            DateTime fecha =  SqlDr.GetDateTime(SqlDr.GetOrdinal("fechaReinicio"));
                            Comun.fechaReinicio = fecha;
                            Comun.cantidadVentasTotal = SqlDr.GetInt32(SqlDr.GetOrdinal("cantVentas"));

                        }
                    }
                    else
                        throw new Exception("No se pudo cargar la configuracion inicial. Informe a su administrador");

                    Comun.ticket = new Ticket();
                    SqlDr = null;
                    SqlDr = SqlHelper.ExecuteReader(conexion, "spCSLDB_obtenerDatosGenerales", Comun.id_sucursal);

                    if (SqlDr.HasRows == true)
                    {
                        while (SqlDr.Read())
                        {
                            Comun.ticket.razonsocial = SqlDr.GetString(SqlDr.GetOrdinal("razonSocial"));
                            Comun.ticket.rfc = SqlDr.GetString(SqlDr.GetOrdinal("rfc"));
                            Comun.ticket.mensaje1 = SqlDr.GetString(SqlDr.GetOrdinal("mensaje1"));
                            Comun.ticket.mensaje2 = SqlDr.GetString(SqlDr.GetOrdinal("mensaje2"));
                            Comun.ticket.mensaje3 = SqlDr.GetString(SqlDr.GetOrdinal("mensaje3"));
                            Comun.ticket.nombresucursal = SqlDr.GetString(SqlDr.GetOrdinal("sucursal"));
                            Comun.ticket.direccion = SqlDr.GetString(SqlDr.GetOrdinal("direccion"));
                            Comun.ticket.municipio = SqlDr.GetString(SqlDr.GetOrdinal("municipio"));
                            Comun.ticket.estado = SqlDr.GetString(SqlDr.GetOrdinal("estado"));
                            Comun.ticket.pais = SqlDr.GetString(SqlDr.GetOrdinal("pais"));
                            Comun.ticket.codigopostal = SqlDr.GetString(SqlDr.GetOrdinal("codigopostal")).ToString();
                            Comun.ticket.namePrinter = Comun.namePrinter;
                            Comun.ticket.url_logo = SqlDr.GetString(SqlDr.GetOrdinal("logo")).ToString();
                            Comun.ticket.telefono = SqlDr.GetString(SqlDr.GetOrdinal("telefono"));
                            Comun.ticket.error = false;
                            Comun.ticket.NombreComercial = SqlDr.GetString(SqlDr.GetOrdinal("NombreComercial"));
                            Comun.ticket.Slogan = SqlDr.GetString(SqlDr.GetOrdinal("Slogan"));
                        }
                    }
                    else
                        Comun.ticket.error = true;

                    if (SqlDr.IsClosed != false)
                        SqlDr.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ResetCredencial(string conexion)
        {
            try
            {
                object res = SqlHelper.ExecuteScalar(conexion, "Reset_Credenciales");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
