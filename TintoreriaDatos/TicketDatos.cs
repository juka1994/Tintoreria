using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TintoreriaGlobal;

namespace TintoreriaDatos
{
    public class TicketDatos : HelperSQL
    {
        public Ticket obtenerDatosGenerales(Ticket ticket)
        {
            try
            {
                SqlDataReader SqlDr = null;
                SqlDr = SqlHelper.ExecuteReader(ticket.strcnx, "spCSLDB_obtenerDatosGenerales", ticket.id_sucursal);

                if (SqlDr.HasRows == true)
                {
                    SqlDr.Read();
                    ticket.razonsocial = SqlDr.GetString(SqlDr.GetOrdinal("razonSocial"));
                    ticket.rfc = SqlDr.GetString(SqlDr.GetOrdinal("rfc"));
                    ticket.mensaje1 = SqlDr.GetString(SqlDr.GetOrdinal("mensaje1"));
                    ticket.mensaje2 = SqlDr.GetString(SqlDr.GetOrdinal("mensaje2"));
                    ticket.mensaje3 = SqlDr.GetString(SqlDr.GetOrdinal("mensaje3"));
                    ticket.nombresucursal = SqlDr.GetString(SqlDr.GetOrdinal("sucursal"));
                    ticket.direccion = SqlDr.GetString(SqlDr.GetOrdinal("direccion"));
                    ticket.municipio = SqlDr.GetString(SqlDr.GetOrdinal("municipio"));
                    ticket.estado = SqlDr.GetString(SqlDr.GetOrdinal("estado"));
                    ticket.pais = SqlDr.GetString(SqlDr.GetOrdinal("pais"));
                    ticket.codigopostal = SqlDr.GetInt32(SqlDr.GetOrdinal("codigopostal")).ToString();
                    ticket.namePrinter = Comun.namePrinter;
                    ticket.logoBuffer = (byte[])SqlDr["logo"];
                    ticket.url_logo = SqlDr.GetString(SqlDr.GetOrdinal("UrlLogo")).ToString();
                    ticket.telefono = SqlDr.GetString(SqlDr.GetOrdinal("telefono"));
                    ticket.Correo = SqlDr.GetString(SqlDr.GetOrdinal("correo"));
                    ticket.representanteLegal = SqlDr.GetString(SqlDr.GetOrdinal("representanteLegal"));
                    ticket.error = false;
                }
                else
                    ticket.error = true;
                return ticket;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public VentaProductos obtenerDatosGlobales(VentaProductos vp)
        {
            try
            {
                SqlDataReader SqlDr = null;
                SqlDr = SqlHelper.ExecuteReader(vp.StrCnx, "obtenerDatosGlobales", vp.IDVenta);

                if (SqlDr.HasRows == true)
                {
                    SqlDr.Read();
                    vp.Folio = SqlDr.GetString(SqlDr.GetOrdinal("folio"));
                    vp.FecVenta = SqlDr.GetDateTime(SqlDr.GetOrdinal("fec_venta"));
                    vp.HorVenta = SqlDr.GetString(SqlDr.GetOrdinal("hor_venta"));
                    if (Convert.IsDBNull(SqlDr.GetValue(SqlDr.GetOrdinal("id_cliente"))))
                        vp.IDCliente = string.Empty;
                    else
                        vp.IDCliente = SqlDr.GetString(SqlDr.GetOrdinal("id_cliente"));
                    vp.NombreCliente = SqlDr.GetString(SqlDr.GetOrdinal("cliente"));
                    if (string.IsNullOrWhiteSpace(vp.NombreCliente))
                        vp.NombreCliente = "PÚBLICO EN GENERAL";
                    vp.IDVendedor = SqlDr.GetString(SqlDr.GetOrdinal("id_vendedor"));
                    vp.NombreVendedor = SqlDr.GetString(SqlDr.GetOrdinal("vendedor"));
                    vp.Importe = (float)(SqlDr.GetDecimal(SqlDr.GetOrdinal("importe")));
                    vp.Descuento = SqlDr.GetDecimal(SqlDr.GetOrdinal("descuento"));
                    vp.Iva = !SqlDr.IsDBNull(SqlDr.GetOrdinal("iva")) ? SqlDr.GetDecimal(SqlDr.GetOrdinal("iva")) : 0;
                    vp.Total = SqlDr.GetDecimal(SqlDr.GetOrdinal("total"));
                    vp.Pago = !SqlDr.IsDBNull(SqlDr.GetOrdinal("pago")) ? SqlDr.GetDecimal(SqlDr.GetOrdinal("pago")) : 0;
                    vp.Cambio = !SqlDr.IsDBNull(SqlDr.GetOrdinal("success")) ? SqlDr.GetDecimal(SqlDr.GetOrdinal("success")) : 0;
                }
                return vp;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<VentaProductos> obtenerDatosVenta(VentaProductos vp)
        {
            try
            {
                SqlDataReader SqlDr = null;
                SqlDr = SqlHelper.ExecuteReader(vp.StrCnx, "obtenerDatosVenta", vp.IDVenta);
                List<VentaProductos> detalle = new List<VentaProductos>();
                VentaProductos producto;
                if (SqlDr.HasRows == true)
                {
                    while (SqlDr.Read())
                    {
                        producto = new VentaProductos();

                        producto.CantidadVenta = SqlDr.GetInt32(SqlDr.GetOrdinal("cantidad_venta"));
                        producto.Precio = !SqlDr.IsDBNull(SqlDr.GetOrdinal("precio")) ? SqlDr.GetDecimal(SqlDr.GetOrdinal("precio")) : 0;
                        producto.Descuento = SqlDr.GetDecimal(SqlDr.GetOrdinal("descuento"));
                        producto.Iva = !SqlDr.IsDBNull(SqlDr.GetOrdinal("iva")) ? SqlDr.GetDecimal(SqlDr.GetOrdinal("iva")) : 0;
                        if (Convert.IsDBNull(SqlDr.GetValue(SqlDr.GetOrdinal("observaciones"))))
                            producto.observaciones = string.Empty;
                        else
                            producto.observaciones = SqlDr.GetString(SqlDr.GetOrdinal("observaciones"));
                        producto.Importe = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("importe"));
                        producto.NombreProducto = SqlDr.GetString(SqlDr.GetOrdinal("nombre_producto"));
                        detalle.Add(producto);
                    }
                }
                return detalle;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ObtenerMonederoVenta(string conexion, ref string monto_monedero, string id_venta)
        {
            try
            {
                SqlDataReader SqlDr = null;
                object[] valores = { id_venta };
                SqlDr = SqlHelper.ExecuteReader(conexion, "ObtenerMonedero_sp", valores);
                if (SqlDr.HasRows == true)
                {
                    while (SqlDr.Read())
                    {

                        float cantidad = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("monto"));
                        monto_monedero = cantidad.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DataTable ObtenerDatosTicket(string folio)
        {
            try
            {
                DataTable oDTable = new DataTable();
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "Ticket.get_Ticket", folio);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            oDTable = ds.Tables[0];
                        }
                    }
                }
                return oDTable;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RespuestaSQL Configuracion_ac_Configuracion(Equipo oEquipo, int opcion)
        {
            try
            {
                object[] parametros =
                {
                    oEquipo.id_equipo,
                    opcion,
                    oEquipo.namePrinter
                };
                SqlDataReader oDReader = SqlHelper.ExecuteReader(ConexionSQL, "Configuracion.ac_Configuracion", parametros);
                RespuestaSQL respuesta = new RespuestaSQL();
                while (oDReader.Read())
                {
                    respuesta.Success = !oDReader.IsDBNull(oDReader.GetOrdinal("success")) ? oDReader.GetBoolean(oDReader.GetOrdinal("success")) : false;
                    respuesta.Mensaje = !oDReader.IsDBNull(oDReader.GetOrdinal("mensaje")) ? oDReader.GetString(oDReader.GetOrdinal("mensaje")) : string.Empty;
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RespuestaSQL Ticket_cambiarUbicacion(string id_ventaServicio, int id_ubicacion)
        {
            try
            {
                object[] parametros =
                {
                    id_ventaServicio,
                    id_ubicacion
                };
                SqlDataReader oDReader = SqlHelper.ExecuteReader(ConexionSQL, "Ticket.cambiarUbicacion", parametros);
                RespuestaSQL respuesta = new RespuestaSQL();
                while (oDReader.Read())
                {
                    respuesta.Success = !oDReader.IsDBNull(oDReader.GetOrdinal("success")) ? oDReader.GetBoolean(oDReader.GetOrdinal("success")) : false;
                    respuesta.Mensaje = !oDReader.IsDBNull(oDReader.GetOrdinal("mensaje")) ? oDReader.GetString(oDReader.GetOrdinal("mensaje")) : string.Empty;
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public RespuestaSQL Ticket_EntregarVentaServicio(string idVentaServicio, string idUsuario)
        {
            try
            {
                object[] parametros =
                {
                    idVentaServicio,
                    idUsuario
                };
                SqlDataReader oDReader = SqlHelper.ExecuteReader(ConexionSQL, "Ticket.EntregarVentaServicio", parametros);
                RespuestaSQL respuesta = new RespuestaSQL();
                while (oDReader.Read())
                {
                    respuesta.Success = !oDReader.IsDBNull(oDReader.GetOrdinal("success")) ? oDReader.GetBoolean(oDReader.GetOrdinal("success")) : false;
                    respuesta.Mensaje = !oDReader.IsDBNull(oDReader.GetOrdinal("mensaje")) ? oDReader.GetString(oDReader.GetOrdinal("mensaje")) : string.Empty;
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public RespuestaSQL Ticket_TerminarVentaServicio(string idVentaServicio, string idUsuario)
        {
            try
            {
                object[] parametros =
                {
                    idVentaServicio,
                    idUsuario
                };
                SqlDataReader oDReader = SqlHelper.ExecuteReader(ConexionSQL, "Ticket.TerminarVentaServicio", parametros);
                RespuestaSQL respuesta = new RespuestaSQL();
                while (oDReader.Read())
                {
                    respuesta.Success = !oDReader.IsDBNull(oDReader.GetOrdinal("success")) ? oDReader.GetBoolean(oDReader.GetOrdinal("success")) : false;
                    respuesta.Mensaje = !oDReader.IsDBNull(oDReader.GetOrdinal("mensaje")) ? oDReader.GetString(oDReader.GetOrdinal("mensaje")) : string.Empty;
                    respuesta.MensajeErrorSQL = !oDReader.IsDBNull(oDReader.GetOrdinal("mensajeErrorSQL")) ? oDReader.GetString(oDReader.GetOrdinal("mensajeErrorSQL")) : string.Empty;
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Venta Ticket_GetPagoPendiente(string idVentaServicio)
        {
            try
            {
                object[] parametros =
                {
                    idVentaServicio
                };
                SqlDataReader oDReader = SqlHelper.ExecuteReader(ConexionSQL, "Ticket.GetPagoPendiente", parametros);
                Venta oVenta = new Venta
                {
                    Respuesta = new RespuestaSQL()
                };

                while (oDReader.Read())
                {

                    oVenta.Respuesta.Success = !oDReader.IsDBNull(oDReader.GetOrdinal("success")) ? oDReader.GetBoolean(oDReader.GetOrdinal("success")) : false;
                    oVenta.Respuesta.Mensaje = !oDReader.IsDBNull(oDReader.GetOrdinal("mensaje")) ? oDReader.GetString(oDReader.GetOrdinal("mensaje")) : string.Empty;
                    oVenta.Respuesta.MensajeErrorSQL = !oDReader.IsDBNull(oDReader.GetOrdinal("mensajeErrorSQL")) ? oDReader.GetString(oDReader.GetOrdinal("mensajeErrorSQL")) : string.Empty;
                    if (oVenta.Respuesta.Success)
                    {
                        oVenta.total = !oDReader.IsDBNull(oDReader.GetOrdinal("total")) ? oDReader.GetDecimal(oDReader.GetOrdinal("total")) : 0;
                        oVenta.Pagar = !oDReader.IsDBNull(oDReader.GetOrdinal("pagar")) ? oDReader.GetDecimal(oDReader.GetOrdinal("pagar")) : 0;
                        oVenta.Pendiente = !oDReader.IsDBNull(oDReader.GetOrdinal("pendiente")) ? oDReader.GetDecimal(oDReader.GetOrdinal("pendiente")) : 0;
                        oVenta.MonederoCliente = !oDReader.IsDBNull(oDReader.GetOrdinal("monedero")) ? oDReader.GetDecimal(oDReader.GetOrdinal("monedero")) : 0;
                        oVenta.NuevoMonedero = !oDReader.IsDBNull(oDReader.GetOrdinal("nuevoMonedero")) ? oDReader.GetDecimal(oDReader.GetOrdinal("nuevoMonedero")) : 0;
                        oVenta.cliente = new Cliente
                        {
                            nombreCompleto = !oDReader.IsDBNull(oDReader.GetOrdinal("nombreCliente")) ? oDReader.GetString(oDReader.GetOrdinal("nombreCliente")) : string.Empty
                        };
                    }
                }
                return oVenta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
