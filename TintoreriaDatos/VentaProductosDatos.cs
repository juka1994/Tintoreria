using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TintoreriaGlobal;

namespace TintoreriaDatos
{
    public class VentaProductosDatos
    {

        public void LLenarGridBusquedaFolio(VentaProductos ventaProducto)
        {
            try
            {
                object[] Valores = { ventaProducto.Folio, ventaProducto.IDSucursal };
                DataSet ds = SqlHelper.ExecuteDataset(ventaProducto.conexion, "WAspCSLDB_CatBusquedaFolio_sp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            ventaProducto.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }         
        }

        public RespuestaSQL ActualizarFechaVenta(VentaProductos fechaActualizar)
        {
            try
            {
                object[] Valores = { fechaActualizar.IDVenta, fechaActualizar.FecEntrega, fechaActualizar.HoraEntrega, fechaActualizar.id_u };
                SqlDataReader dr = SqlHelper.ExecuteReader(fechaActualizar.conexion, "WAspCSLDB_CambiarFechaEntrega_sp", Valores);
                RespuestaSQL respuesta = new RespuestaSQL();
                while (dr.Read())
                {
                    respuesta.Success = !dr.IsDBNull(dr.GetOrdinal("success")) ? dr.GetBoolean(dr.GetOrdinal("success")) : false;
                    respuesta.Mensaje = !dr.IsDBNull(dr.GetOrdinal("mensaje")) ? dr.GetString(dr.GetOrdinal("mensaje")) : string.Empty;
                }
                return respuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void LLenarGridBusquedaFolioNombre(VentaProductos ventaProducto)
        {

            object[] Valores = { ventaProducto.Folio, ventaProducto.NombreCliente, ventaProducto.IDSucursal };
            DataSet ds = SqlHelper.ExecuteDataset(ventaProducto.conexion, "WAspCSLDB_CatBusquedaFolioNombre_sp", Valores);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0] != null)
                    {
                        ventaProducto.datos = ds.Tables[0];
                    }
                }
            }

        }
        public void ActualizarVentaTemporal(VentaProductos ventaActualizar)
        {
            try
            {
                try
                {
                    object[] Valores = { ventaActualizar.IDVenta, ventaActualizar.IDSucursal, ventaActualizar.nameTab };
                    DataSet ds = SqlHelper.ExecuteDataset(ventaActualizar.StrCnx, "spCSLDB_abc_VentaTemporal", Valores);
                    ventaActualizar.validador = 0;
                }
                catch (SqlException exSQL)
                {
                    ventaActualizar.validador = exSQL.Number;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AgregarProductoVentaTmp(VentaProductos venta)
        {
            try
            {
                try
                {
                    object[] Valores = { venta.IDVenta, venta.IDSucursal, venta.IDCaja,
                                         venta.IDVendedor, venta.IDCajero, venta.IDProducto, venta.IDTallaRopa, venta.IDColorRopa,
                                         venta.CantidadVenta, venta.Precio, venta.observaciones, venta.BandPrecioMayoreo};
                    DataSet ds = SqlHelper.ExecuteDataset(venta.StrCnx, "spCSLDB_ActualizarProductoTemp", Valores);
                    venta.validador = 0;
                }
                catch (SqlException exSQL)
                {
                    venta.validador = exSQL.Number;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ConsultaProductos(VentaProductos ventaProductos)
        {
            try
            {
                SqlDataReader dr = null;
                object[] Valores = { ventaProductos.IDFamilia, ventaProductos.NombreProducto, ventaProductos.IDCodigoEan, ventaProductos.IDSucursal };
                dr = SqlHelper.ExecuteReader(ventaProductos.StrCnx, "spCSLDB_Consultar_ProductosXSucursal_EnExistencia", Valores);
                VentaProductos ventaProducto;
                while (dr.Read())
                {
                    ventaProducto = new VentaProductos();
                    ventaProducto.IDProducto = dr["id_producto"].ToString();
                    ventaProducto.IDTallaRopa = Convert.ToInt32(dr["id_tallaRopa"].ToString());
                    ventaProducto.IDColorRopa = Convert.ToInt32(dr["id_colorRopa"].ToString());
                    ventaProducto.IDFamilia = Convert.ToInt32(dr["id_familia"]);
                    ventaProducto.IDTipoProducto = Convert.ToInt32(dr["id_tipoProducto"]);
                    ventaProducto.Precio = Convert.ToDecimal(dr["precio"]);
                    ventaProducto.PrecioMayoreo = (float)Convert.ToDecimal(dr["precioMayoreo"]);
                    ventaProducto.Existencia = Convert.ToInt32(dr["existencia"]);
                    ventaProducto.NombreProducto = dr["nombre_producto"].ToString();
                    ventaProducto.IDCodigoEan = dr["id_codigoEan"].ToString();
                    ventaProducto.PorcentajeIva = Convert.ToDecimal(dr["iva"]);
                    ventaProducto.PorcentajeIvaMayoreo = (float)Convert.ToDecimal(dr["ivaMayoreo"]);
                    ventaProducto.CantidadMayoreo = (int)Convert.ToInt32(dr["cantidadMayoreo"]);
                    ventaProductos.listaDetalle.Add(ventaProducto);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertarVentaPendiente(VentaProductos datos)
        {
            try
            {
                object[] Valores = { datos.IDSucursal, datos.IDCajero, datos.nameTab, datos.IDCaja };
                SqlDataReader dr = SqlHelper.ExecuteReader(datos.StrCnx, "spCSLDB_InsertarNuevaVentaPendiente", Valores);
                while (dr.Read())
                {
                    datos.IDVenta = dr.GetString(dr.GetOrdinal("id_venta"));
                    datos.IDCliente = dr.GetString(dr.GetOrdinal("id_cliente"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void liberarVentasNoGuardadas(VentaProductos datos)
        {
            try
            {
                object[] valores = { datos.IDCaja, datos.IDSucursal };
                SqlHelper.ExecuteNonQuery(datos.StrCnx, "spCSLDB_LiberarVentasNoGuardadas", valores);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Familia> LlenaComboFamilia(Familia datos)
        {
            try
            {
                SqlDataReader dr = null;
                Familia item;
                List<Familia> lista = new List<Familia>();
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_Combo_CatFamilias_Activo", datos.opcion);
                while (dr.Read())
                {
                    item = new Familia();
                    item.id_familia = dr.GetInt32(dr.GetOrdinal("id_familia"));
                    if (Convert.IsDBNull(dr.GetValue(dr.GetOrdinal("descripcion"))))
                        item.descripcion = string.Empty;
                    else
                        item.descripcion = dr.GetString(dr.GetOrdinal("descripcion"));
                    lista.Add(item);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VentaProductos> ObtenerDetalleVentaPendiente(VentaProductos datos)
        {
            try
            {
                VentaProductos venta;
                List<VentaProductos> lista = new List<VentaProductos>();
                SqlDataReader SqlDr = null;
                object[] valores = { datos.IDVenta, datos.IDSucursal };
                SqlDr = SqlHelper.ExecuteReader(datos.StrCnx, "spCSLDB_obtenerDetalleVenta", valores);
                while (SqlDr.Read())
                {
                    venta = new VentaProductos();
                    venta.IDProducto = SqlDr.GetString(SqlDr.GetOrdinal("id_producto"));
                    venta.IDTallaRopa = SqlDr.GetInt32(SqlDr.GetOrdinal("id_tallaRopa"));
                    venta.IDColorRopa = SqlDr.GetInt32(SqlDr.GetOrdinal("id_colorRopa"));
                    venta.NombreProducto = SqlDr.GetString(SqlDr.GetOrdinal("nombre_producto"));
                    venta.IDCodigoEan = SqlDr.GetString(SqlDr.GetOrdinal("id_codigoEan"));
                    venta.Descripcion = SqlDr.GetString(SqlDr.GetOrdinal("descripcion"));
                    venta.Precio = SqlDr.GetDecimal(SqlDr.GetOrdinal("precio"));
                    venta.CantidadVenta = SqlDr.GetInt32(SqlDr.GetOrdinal("cantidad_venta"));
                    venta.Subtotal = SqlDr.GetDecimal(SqlDr.GetOrdinal("subtotal"));
                    venta.Descuento = SqlDr.GetDecimal(SqlDr.GetOrdinal("descuento"));
                    venta.Iva = SqlDr.GetDecimal(SqlDr.GetOrdinal("iva"));
                    venta.Total = SqlDr.GetDecimal(SqlDr.GetOrdinal("total"));
                    venta.Monedero = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("monedero"));
                    venta.puntos = SqlDr.GetInt32(SqlDr.GetOrdinal("puntos"));
                    venta.IDVentadetalle = SqlDr.GetString(SqlDr.GetOrdinal("id_ventaDetalle"));
                    lista.Add(venta);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ProductoDetalle obtenerExistenciaProducto(ProductoDetalle datos)
        {
            try
            {
                SqlDataReader SqlDr = null;
                object[] valores = { datos.id_producto, datos.id_tallaRopa, datos.id_colorRopa, datos.id_sucursal };
                SqlDr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_obtenerExistenciaSucXIDProducto", valores);
                datos = new ProductoDetalle();
                while (SqlDr.Read())
                {
                    datos.id_producto = SqlDr.GetString(SqlDr.GetOrdinal("id_producto"));
                    datos.existencia = SqlDr.GetInt32(SqlDr.GetOrdinal("existencia"));
                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VentaProductos> ObtenerVentasPendientes(VentaProductos datos)
        {
            try
            {
                VentaProductos venta;
                List<VentaProductos> lista = new List<VentaProductos>();
                SqlDataReader SqlDr = null;
                object[] valores = { datos.IDSucursal, datos.IDCajero };
                SqlDr = SqlHelper.ExecuteReader(datos.StrCnx, "spCSLDB_obtenerVentasPendientes", valores);
                while (SqlDr.Read())
                {
                    venta = new VentaProductos();
                    venta.IDVenta = SqlDr.GetString(SqlDr.GetOrdinal("id_venta"));
                    venta.IDSucursal = SqlDr.GetString(SqlDr.GetOrdinal("id_sucursal"));
                    venta.IDCliente = SqlDr.GetString(SqlDr.GetOrdinal("id_cliente"));
                    venta.Importe = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("importe"));
                    venta.Descuento = SqlDr.GetDecimal(SqlDr.GetOrdinal("descuento"));
                    venta.Iva = SqlDr.GetDecimal(SqlDr.GetOrdinal("iva"));
                    venta.Total = SqlDr.GetDecimal(SqlDr.GetOrdinal("total"));
                    venta.nameTab = SqlDr.GetString(SqlDr.GetOrdinal("nameTab"));
                    lista.Add(venta);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Producto ObtenerProductoXIDEanCode(VentaProductos datos)
        {
            try
            {
                Producto aux = new Producto();
                aux.productoDetalle = new ProductoDetalle();
                aux.id_producto = string.Empty;
                aux.productoDetalle.id_codigoEan = string.Empty;
                SqlDataReader dr = SqlHelper.ExecuteReader(datos.StrCnx, "spCSLDB_get_ProductoXIDEanCode", datos.IDCodigoEan, datos.IDSucursal);
                while (dr.Read())
                {
                    aux.id_producto = dr.GetString(dr.GetOrdinal("IDProducto"));
                    aux.productoDetalle.id_tallaRopa = dr.GetInt32(dr.GetOrdinal("IDTallaRopa"));
                    aux.productoDetalle.id_colorRopa = dr.GetInt32(dr.GetOrdinal("IDColorRopa"));
                    aux.productoDetalle.id_codigoEan = dr.GetString(dr.GetOrdinal("IDEanCode"));
                    aux.productoDetalle.precio = dr.GetDecimal(dr.GetOrdinal("Precio"));
                    aux.productoDetalle.precioMayoreo = (float)dr.GetDecimal(dr.GetOrdinal("PrecioMayoreo"));
                }
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EliminarProductoVentaTmp(VentaProductos venta)
        {
            try
            {
                try
                {
                    object[] Valores = { venta.IDVenta, venta.IDSucursal, venta.IDProducto, venta.IDTallaRopa, venta.IDColorRopa };
                    DataSet ds = SqlHelper.ExecuteDataset(venta.StrCnx, "spCSLDB_Temp_EliminarProducto", Valores);
                    venta.validador = 0;
                }
                catch (SqlException exSQL)
                {
                    venta.validador = exSQL.Number;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertarProductos(ref int Verificador, ref VentaProductos ventaProductos, ref List<VentaProductos> ListaProductos, Cliente cliente)
        {
            try
            {
                object res = SqlHelper.ExecuteScalar(ventaProductos.StrCnx, CommandType.StoredProcedure, "spCSLDB_abc_CatVenta",
                new SqlParameter("@IDVenta", ventaProductos.IDVenta),
                new SqlParameter("@IDSucursal", ventaProductos.IDSucursal),
                new SqlParameter("@IDTipoVenta", ventaProductos.IDTipoVenta),
                new SqlParameter("@IDStatus", ventaProductos.IDStatus),
                new SqlParameter("@IDCliente", ventaProductos.IDCliente),
                new SqlParameter("@NuevoMonedero", ventaProductos.Monedero),
                new SqlParameter("@Puntos", ventaProductos.puntos),
                new SqlParameter("@IDCaja", ventaProductos.IDCaja),
                new SqlParameter("@IDVendedor", ventaProductos.IDVendedor),
                new SqlParameter("@IDCajero", ventaProductos.IDCajero),
                new SqlParameter("@Descuento", ventaProductos.Descuento),
                new SqlParameter("@Subtotal", ventaProductos.Subtotal),
                new SqlParameter("@Iva", ventaProductos.Iva),
                new SqlParameter("@Total", ventaProductos.Total),
                new SqlParameter("@Pago", ventaProductos.Pago),
                new SqlParameter("@PagoEfectivo", ventaProductos.PagoEfectivo),
                new SqlParameter("@PagoTarjeta", ventaProductos.PagoTarjeta),
                new SqlParameter("@PagoTransferencia", ventaProductos.PagoTransferencia),
                new SqlParameter("@PagoMonedero", ventaProductos.PagoMonedero),
                new SqlParameter("@Cambio", ventaProductos.Cambio),
                new SqlParameter("@IDVale", ventaProductos.Vale.IDVale),
                new SqlParameter("@folioVale", ventaProductos.Vale.Folio),
                new SqlParameter("@IDTipoVale", ventaProductos.Vale.IDTipoVale),
                new SqlParameter("@descripcionVale", ventaProductos.Vale.Nombre),
                new SqlParameter("@montoDescuento", ventaProductos.Vale.DescuentoTotalVale),
                new SqlParameter("@lstDatosTarjeta", ventaProductos.DatosTarjeta),
                new SqlParameter("@lstDatosTransferencia", ventaProductos.DatosTransferencia),
                new SqlParameter("@lstVentaDetalle", ventaProductos.ventadetalle)
                );
                if (res != null)
                    Verificador = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertarPrendasTintoreria(ref int Verificador, ref VentaTintoreria venta)
        {
            object res = SqlHelper.ExecuteScalar(Comun.conexion, CommandType.StoredProcedure, "spCSLDB_abc_CatVentaTintoreria",
                new SqlParameter("@IDSucursal", venta.id_sucursal),
                new SqlParameter("@IDTipoServicio", venta.Id_tipoServicio),
                new SqlParameter("@IDStatus", venta.Id_statusServicio),
                new SqlParameter("@IDCliente", venta.idCliente),
                new SqlParameter("@IDTipoCredencial", venta.Id_tipocredencial),
                new SqlParameter("@IDTipoEntrega", venta.IdTipoEntrega),
                new SqlParameter("@IDFormaEntrega", venta.IdformaEntrega),
                new SqlParameter("@NombrePrenda", ""),
                new SqlParameter("@NuevoMonedero", venta.monedero),
                new SqlParameter("@Puntos", venta.puntos),
                new SqlParameter("@IDCaja", venta.Id_caja),
                new SqlParameter("@IDVendedor", venta.Id_vendedor),
                new SqlParameter("@IDCajero", venta.Id_cajero),
                new SqlParameter("@IDChofer", venta.UsuChofer),
                new SqlParameter("@Descuento", venta.descuentoGeneral),
                new SqlParameter("@DescuentoGeneral", venta.descuento),
                new SqlParameter("@Subtotal", venta.subTotal),
                new SqlParameter("@Total", venta.total),
                new SqlParameter("@Pago", venta.Pago),
                new SqlParameter("@Iva", venta.iva),
                new SqlParameter("@PagoEfectivo", venta.PagoEfectivo),
                new SqlParameter("@PagoTarjeta", venta.PagoTarjeta),
                new SqlParameter("@PagoTransferencia", venta.PagoTransferencia),
                new SqlParameter("@PagoMonedero", venta.PagoMonedero),
                new SqlParameter("@Cambio", venta.Cambio),
                new SqlParameter("@Reproceso", venta.isReproceso),
                new SqlParameter("@Gratis", venta.isGratis),
                new SqlParameter("@Monedero", venta.isMonedero),
                new SqlParameter("@Multipago", venta.banBloqueoMultipleFormasPago),
                new SqlParameter("@Es3x1", venta.aplicar3X1),
                new SqlParameter("@FechaEntrega", venta.FechaEntrega),
                new SqlParameter("@HoraEntrega", venta.HoraEntrega),
                new SqlParameter("@HorasAsignadas", venta.Horasasignadas),
                new SqlParameter("@CantidadPrendas", venta.Cantidadprendas),
                new SqlParameter("@KgPrendas", venta.Totalkilogramos),
                new SqlParameter("@IdTipoPagoInicial", venta.idtipopagoinicial),
                new SqlParameter("@IDVale", venta.vale.IDVale),
                new SqlParameter("@folioVale", venta.vale.Folio),
                new SqlParameter("@IDTipoVale", venta.vale.IDTipoVale),
                new SqlParameter("@descripcionVale", venta.vale.Nombre),
                new SqlParameter("@montoDescuento", venta.vale.DescuentoTotalVale),
                new SqlParameter("@Comentarios", venta.Comentarios),
                new SqlParameter("@lstDatosTarjeta", venta.DatosTarjeta),
                new SqlParameter("@lstDatosTransferencia", venta.DatosTransferencia),
                new SqlParameter("@lstVentaDetalle", venta.tablaRopaServicio)
            );
            if (res != null)
            {
                Verificador = 0;
                venta.Id_ventaServicio = res.ToString();
            }
        }


        public Producto obtenerExistenciaProducto(Producto datos)
        {
            try
            {
                SqlDataReader SqlDr = null;
                object[] valores = { datos.id_producto, datos.productoDetalle.id_tallaRopa, datos.productoDetalle.id_colorRopa, datos.productoDetalle.id_sucursal };
                SqlDr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_obtenerExistenciaSucXIDProducto", valores);
                while (SqlDr.Read())
                {
                    datos.id_producto = SqlDr.GetString(SqlDr.GetOrdinal("id_producto"));
                    datos.productoDetalle.existencia = SqlDr.GetInt32(SqlDr.GetOrdinal("existencia"));
                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void insertarProductoGenerico2(VentaProductos prodGen)
        {
            try
            {
                object[] Valores = { prodGen.NombreProducto, prodGen.Precio, prodGen.IDTipoProducto, prodGen.IDCajero };
                object idProducto = SqlHelper.ExecuteScalar(prodGen.StrCnx, "spCSLDB_abc_CatProductoGenerico2", Valores);
                prodGen.IDProducto = idProducto.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void insertarProductoGenerico(VentaProductos prodGen)
        {
            try
            {
                object[] Valores = { prodGen.NombreProducto, prodGen.Precio, prodGen.IDTipoProducto, prodGen.IDCajero };
                object idProducto = SqlHelper.ExecuteScalar(prodGen.StrCnx, "spCSLDB_abc_CatProductoGenerico", Valores);
                prodGen.IDProducto = idProducto.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool liberarVentaTab(VentaProductos datos)
        {
            try
            {
                object[] valores = { datos.IDCaja, datos.IDVenta, datos.IDSucursal };
                return SqlHelper.ExecuteScalar(datos.StrCnx, "spCSLDB_LiberarVentaTab", valores).ToString() == "1" ? true : false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void CambiarPrecioMayoreo(VentaProductos venta)
        {
            try
            {
                object[] Valores = { venta.IDVenta, venta.IDSucursal, 1 };
                if (SqlHelper.ExecuteNonQuery(venta.StrCnx, "spCSLDB_Temp_CambiarPrecioProducto", Valores) > 0)
                    venta.validador = 0;
                else
                    venta.validador = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VentaProductos obtenerDatosVenta(VentaProductos datos)
        {
            try
            {
                SqlDataReader SqlDr = null;
                object[] valores = { datos.IDVenta, datos.IDSucursal, datos.IDTipoVenta };
                SqlDr = SqlHelper.ExecuteReader(datos.StrCnx, "spCSLDB_get_DatosGeneralesVenta", valores);
                while (SqlDr.Read())
                {
                    datos.IDVenta = !SqlDr.IsDBNull(SqlDr.GetOrdinal("id_ventaServicio")) ? SqlDr.GetString(SqlDr.GetOrdinal("id_ventaServicio")) : string.Empty;
                    datos.IDSucursal = !SqlDr.IsDBNull(SqlDr.GetOrdinal("id_sucursal")) ? SqlDr.GetString(SqlDr.GetOrdinal("id_sucursal")) : string.Empty;
                    datos.Folio = !SqlDr.IsDBNull(SqlDr.GetOrdinal("folio")) ? SqlDr.GetString(SqlDr.GetOrdinal("folio")) : string.Empty;
                    datos.FecVenta = !SqlDr.IsDBNull(SqlDr.GetOrdinal("fec_ventaServicio")) ? SqlDr.GetDateTime(SqlDr.GetOrdinal("fec_ventaServicio")) : DateTime.Today;
                    datos.HorVenta = !SqlDr.IsDBNull(SqlDr.GetOrdinal("hor_ventaServicio")) ? SqlDr.GetString(SqlDr.GetOrdinal("hor_ventaServicio")) : string.Empty;
                    datos.NombreCliente = !SqlDr.IsDBNull(SqlDr.GetOrdinal("nombre")) ? SqlDr.GetString(SqlDr.GetOrdinal("nombre")) : string.Empty;
                    datos.NombreVendedor = !SqlDr.IsDBNull(SqlDr.GetOrdinal("cajero")) ? SqlDr.GetString(SqlDr.GetOrdinal("cajero")) : string.Empty;
                    datos.Subtotal = !SqlDr.IsDBNull(SqlDr.GetOrdinal("importe")) ? SqlDr.GetDecimal(SqlDr.GetOrdinal("importe")) : 0;
                    datos.Descuento = !SqlDr.IsDBNull(SqlDr.GetOrdinal("descuento")) ? SqlDr.GetDecimal(SqlDr.GetOrdinal("descuento")) : 0;
                    datos.Iva = !SqlDr.IsDBNull(SqlDr.GetOrdinal("iva")) ? SqlDr.GetDecimal(SqlDr.GetOrdinal("iva")) : 0;
                    datos.Total = !SqlDr.IsDBNull(SqlDr.GetOrdinal("total")) ? SqlDr.GetDecimal(SqlDr.GetOrdinal("total")) : 0;
                    datos.Pago = !SqlDr.IsDBNull(SqlDr.GetOrdinal("pago")) ? SqlDr.GetDecimal(SqlDr.GetOrdinal("pago")) : 0;
                    datos.Cambio = !SqlDr.IsDBNull(SqlDr.GetOrdinal("cambio")) ? SqlDr.GetDecimal(SqlDr.GetOrdinal("cambio")) : 0;
                    datos.Pendiente = !SqlDr.IsDBNull(SqlDr.GetOrdinal("pendiente")) ? SqlDr.GetDecimal(SqlDr.GetOrdinal("pendiente")) : 0;
                    datos.Fecupd = !SqlDr.IsDBNull(SqlDr.GetOrdinal("fec_entrega")) ? SqlDr.GetDateTime(SqlDr.GetOrdinal("fec_entrega")) : DateTime.Today;
                    datos.banBloqueoMultipleFormasPago = !SqlDr.IsDBNull(SqlDr.GetOrdinal("formaPago")) ? SqlDr.GetBoolean(SqlDr.GetOrdinal("formaPago")) : false;
                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<VentaProductos> ObtenerVentaDetalle(VentaProductos datos)
        {
            try
            {
                List<VentaProductos> listaProductos = new List<VentaProductos>();
                VentaProductos auxProductos = new VentaProductos();
                SqlDataReader SqlDr = null;
                object[] valores = { datos.IDVenta, datos.IDSucursal };
                SqlDr = SqlHelper.ExecuteReader(datos.StrCnx, "spCSLDB_get_VentasDetalle", valores);
                while (SqlDr.Read())
                {
                    auxProductos = new VentaProductos();
                    auxProductos.IDTipoProducto = 1;
                    auxProductos.CantidadVenta = !SqlDr.IsDBNull(SqlDr.GetOrdinal("cantidad_venta")) ? SqlDr.GetInt32(SqlDr.GetOrdinal("cantidad_venta")) : 0;  //SqlDr.GetInt32(SqlDr.GetOrdinal("cantidad_venta"));
                    auxProductos.NombreProducto = !SqlDr.IsDBNull(SqlDr.GetOrdinal("nombre_producto")) ? SqlDr.GetString(SqlDr.GetOrdinal("nombre_producto")) : string.Empty;  //SqlDr.GetString(SqlDr.GetOrdinal("nombre_producto"));
                    auxProductos.Precio = !SqlDr.IsDBNull(SqlDr.GetOrdinal("precio")) ? SqlDr.GetDecimal(SqlDr.GetOrdinal("precio")) : 0;
                    auxProductos.Iva = !SqlDr.IsDBNull(SqlDr.GetOrdinal("iva")) ? SqlDr.GetDecimal(SqlDr.GetOrdinal("iva")) : 0;
                    auxProductos.Total = !SqlDr.IsDBNull(SqlDr.GetOrdinal("total")) ? SqlDr.GetDecimal(SqlDr.GetOrdinal("total")) : 0;
                    listaProductos.Add(auxProductos);
                }
                return listaProductos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridVentas(VentaProductos ventaProducto)
        {
            try
            {
                object[] Valores = { ventaProducto.IDSucursal, ventaProducto.FecVenta, ventaProducto.IDCaja, ventaProducto.tipoBusqueda, ventaProducto.busqueda };
                DataSet ds = SqlHelper.ExecuteDataset(ventaProducto.conexion, "spCSLDB_CatVentas_Consulta2_sp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            ventaProducto.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridVentaDetalle(VentaProductos ventaProducto)
        {
            try
            {
                object[] Valores = { ventaProducto.IDSucursal, ventaProducto.IDVenta };
                DataSet ds = SqlHelper.ExecuteDataset(ventaProducto.conexion, "spCSLDB_CatVentaDetalle_Consulta_sp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            ventaProducto.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertarPedidoPendiente(VentaProductos datos)
        {
            try
            {
                object[] Valores = { datos.IDSucursal, datos.IDCajero, datos.nameTab, datos.IDCaja };
                SqlDataReader dr = SqlHelper.ExecuteReader(datos.StrCnx, "spCSLDB_InsertarNuevoPedidoPendiente", Valores);
                while (dr.Read())
                {
                    datos.IDVenta = dr.GetString(dr.GetOrdinal("id_venta"));
                    datos.IDCliente = dr.GetString(dr.GetOrdinal("id_cliente"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertarProductosPedidos2(ref int Verificador, ref VentaProductos ventaProductos, Cliente cliente)
        {
            try
            {
                object res = SqlHelper.ExecuteScalar(ventaProductos.StrCnx, CommandType.StoredProcedure, "spCSLDB_abc_CatVentaPedido2",
                new SqlParameter("@IDVenta", ventaProductos.IDVenta),
                new SqlParameter("@IDSucursal", ventaProductos.IDSucursal),
                new SqlParameter("@IDTipoVenta", ventaProductos.IDTipoVenta),
                new SqlParameter("@IDStatus", ventaProductos.IDStatus),
                new SqlParameter("@IDCliente", ventaProductos.IDCliente),
                new SqlParameter("@NuevoMonedero", ventaProductos.Monedero),
                new SqlParameter("@Puntos", ventaProductos.puntos),
                new SqlParameter("@IDCaja", ventaProductos.IDCaja),
                new SqlParameter("@IDVendedor", ventaProductos.IDVendedor),
                new SqlParameter("@IDCajero", ventaProductos.IDCajero),
                new SqlParameter("@Descuento", ventaProductos.Descuento),
                new SqlParameter("@Subtotal", ventaProductos.Subtotal),
                new SqlParameter("@Iva", ventaProductos.Iva),
                new SqlParameter("@Total", ventaProductos.Total),
                new SqlParameter("@Pago", ventaProductos.Pago),
                new SqlParameter("@PagoEfectivo", ventaProductos.PagoEfectivo),
                new SqlParameter("@PagoTarjeta", ventaProductos.PagoTarjeta),
                new SqlParameter("@PagoTransferencia", ventaProductos.PagoTransferencia),
                new SqlParameter("@PagoMonedero", ventaProductos.PagoMonedero),
                new SqlParameter("@Cambio", ventaProductos.Cambio),
                new SqlParameter("@lstDatosTarjeta", ventaProductos.DatosTarjeta),
                new SqlParameter("@lstDatosTransferencia", ventaProductos.DatosTransferencia),
                new SqlParameter("@lstVentaDetalle", ventaProductos.ventadetalle)
                );
                if (res != null)
                {
                    Verificador = 0;
                    ventaProductos.IDVenta = res.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertarProductosPedidos(ref int Verificador, ref VentaProductos ventaProductos, Cliente cliente)
        {
            try
            {
                object res = SqlHelper.ExecuteScalar(ventaProductos.StrCnx, CommandType.StoredProcedure, "spCSLDB_abc_CatVentaPedido",
                new SqlParameter("@IDVenta", ventaProductos.IDVenta),
                new SqlParameter("@IDSucursal", ventaProductos.IDSucursal),
                new SqlParameter("@IDTipoVenta", ventaProductos.IDTipoVenta),
                new SqlParameter("@IDStatus", ventaProductos.IDStatus),
                new SqlParameter("@IDCliente", ventaProductos.IDCliente),
                new SqlParameter("@NuevoMonedero", ventaProductos.Monedero),
                new SqlParameter("@Puntos", ventaProductos.puntos),
                new SqlParameter("@IDCaja", ventaProductos.IDCaja),
                new SqlParameter("@IDVendedor", ventaProductos.IDVendedor),
                new SqlParameter("@IDCajero", ventaProductos.IDCajero),
                new SqlParameter("@Descuento", ventaProductos.Descuento),
                new SqlParameter("@Subtotal", ventaProductos.Subtotal),
                new SqlParameter("@Iva", ventaProductos.Iva),
                new SqlParameter("@Total", ventaProductos.Total),
                new SqlParameter("@Pago", ventaProductos.Pago),
                new SqlParameter("@PagoEfectivo", ventaProductos.PagoEfectivo),
                new SqlParameter("@PagoTarjeta", ventaProductos.PagoTarjeta),
                new SqlParameter("@PagoTransferencia", ventaProductos.PagoTransferencia),
                new SqlParameter("@PagoMonedero", ventaProductos.PagoMonedero),
                new SqlParameter("@Cambio", ventaProductos.Cambio),
                new SqlParameter("@lstDatosTarjeta", ventaProductos.DatosTarjeta),
                new SqlParameter("@lstDatosTransferencia", ventaProductos.DatosTransferencia),
                new SqlParameter("@lstVentaDetalle", ventaProductos.ventadetalle)
                );
                if (res != null)
                {
                    Verificador = 0;
                    ventaProductos.IDVenta = res.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboTipoVenta(VentaProductos ventaProductos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ventaProductos.conexion, "spCSLDB_get_ComboCatTipoVenta");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            ventaProductos.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerNuevaCancelacion(VentaProductos ventaProductos)
        {
            try
            {
                object[] Valores = { ventaProductos.Folio, ventaProductos.IDSucursal };
                DataSet ds = SqlHelper.ExecuteDataset(ventaProductos.conexion, "spCSLDB_CatNuevaCancelacion_Consulta_sp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            if (ds.Tables[0].Rows.Count == 1)
                            {
                                ventaProductos.IDVenta = ds.Tables[0].Rows[0][0].ToString();
                                ventaProductos.Folio = ds.Tables[0].Rows[0][1].ToString();
                                ventaProductos.IDSucursal = ds.Tables[0].Rows[0][2].ToString();
                                ventaProductos.IDTipoVenta = Convert.ToInt32(ds.Tables[0].Rows[0][3]);
                                ventaProductos.FecVenta = Convert.ToDateTime(ds.Tables[0].Rows[0][4]);
                                ventaProductos.HorVenta = ds.Tables[0].Rows[0][5].ToString();
                                ventaProductos.IDCliente = ds.Tables[0].Rows[0][6].ToString();
                                ventaProductos.NombreCliente = ds.Tables[0].Rows[0][7].ToString();
                                ventaProductos.Subtotal = decimal.Parse(ds.Tables[0].Rows[0][8].ToString());
                                ventaProductos.Descuento = decimal.Parse(ds.Tables[0].Rows[0][9].ToString());
                                ventaProductos.Iva = decimal.Parse(ds.Tables[0].Rows[0][10].ToString());
                                ventaProductos.Total = decimal.Parse(ds.Tables[0].Rows[0][11].ToString());
                                ventaProductos.IDCaja = ds.Tables[0].Rows[0][12].ToString();
                                ventaProductos.IDCajero = ds.Tables[0].Rows[0][13].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridCancelacionDetalle(VentaProductos ventaProducto)
        {
            try
            {
                object[] Valores = { ventaProducto.IDSucursal, ventaProducto.IDVenta };
                DataSet ds = SqlHelper.ExecuteDataset(ventaProducto.conexion, "spCSLDB_CatCancelacionDetalle_Consulta_sp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            ventaProducto.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void CancelarVenta(VentaProductos ventaProductos, ref int Verificador)
        {
            try
            {
                if (ventaProductos.CancelacionDetalle != null)
                    foreach (DataRow auxproducto in ventaProductos.CancelacionDetalle.Rows)
                        if (auxproducto["estado"].ToString() != "1")
                            auxproducto["estado"] = "0";
                object res = SqlHelper.ExecuteScalar(ventaProductos.conexion, CommandType.StoredProcedure, "spCSLDB_set_NuevaCancelacion",
                new SqlParameter("@cancelacionDetalle", ventaProductos.CancelacionDetalle),
                new SqlParameter("@id_venta", ventaProductos.IDVenta),
                new SqlParameter("@id_sucursal", ventaProductos.IDSucursal),
                new SqlParameter("@id_caja", ventaProductos.IDCaja),
                new SqlParameter("@id_cajero", ventaProductos.IDCajero),
                new SqlParameter("@motivo", ventaProductos.motivo),
                new SqlParameter("@usuario", ventaProductos.id_u)
                );
                if (res.ToString() != "")
                    Verificador = 0;
                else
                    Verificador = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridCancelacion(VentaProductos ventaProducto)
        {
            try
            {
                object[] Valores = { ventaProducto.IDSucursal, ventaProducto.fechaCancelacion, ventaProducto.IDCaja, ventaProducto.tipoBusqueda, ventaProducto.busqueda };
                DataSet ds = SqlHelper.ExecuteDataset(ventaProducto.conexion, "spCSLDB_CatCancelacion_Consulta2_sp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            ventaProducto.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridPedido(VentaProductos ventaProducto)
        {
            try
            {
                object[] Valores = { ventaProducto.IDSucursal, ventaProducto.FecVenta, ventaProducto.IDCaja, ventaProducto.tipoBusqueda, ventaProducto.busqueda };
                DataSet ds = SqlHelper.ExecuteDataset(ventaProducto.conexion, "spCSLDB_CatPedido_Consulta2_sp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            ventaProducto.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridPedidoPago(VentaProductos venta)
        {
            try
            {
                object[] Valores = { venta.IDVenta, venta.IDSucursal };
                DataSet ds = SqlHelper.ExecuteDataset(venta.conexion, "spCSLDB_CatPagosPedidoXID_Consulta_sp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            venta.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void InsertarPagosPedido(ref int Verificador, ref VentaProductos ventaProductos)
        {
            try
            {
                object res = SqlHelper.ExecuteScalar(ventaProductos.StrCnx, CommandType.StoredProcedure, "spCSLDB_abc_CatVentaPedidoPagos",
                new SqlParameter("@IDVenta", ventaProductos.IDVenta),
                new SqlParameter("@IDSucursal", ventaProductos.IDSucursal),
                new SqlParameter("@IDCliente", ventaProductos.IDCliente),
                new SqlParameter("@IDCaja", ventaProductos.IDCaja),
                new SqlParameter("@IDVendedor", ventaProductos.IDVendedor),
                new SqlParameter("@IDCajero", ventaProductos.IDCajero),
                new SqlParameter("@Pago", ventaProductos.Pago),
                new SqlParameter("@PagoEfectivo", ventaProductos.PagoEfectivo),
                new SqlParameter("@PagoTarjeta", ventaProductos.PagoTarjeta),
                new SqlParameter("@PagoTransferencia", ventaProductos.PagoTransferencia),
                new SqlParameter("@PagoMonedero", ventaProductos.PagoMonedero),
                new SqlParameter("@lstDatosTarjeta", ventaProductos.DatosTarjeta),
                new SqlParameter("@lstDatosTransferencia", ventaProductos.DatosTransferencia)
                );
                if (res != null)
                {
                    Verificador = 0;
                    ventaProductos.IDVenta = res.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridHome(int tabIndex, VentaProductos ventaProducto)
        {
            try
            {
                object[] Valores = { tabIndex, ventaProducto.IDCaja, ventaProducto.Folio, ventaProducto.NombreCliente };
                DataSet ds = SqlHelper.ExecuteDataset(ventaProducto.conexion, "[dbo].[spCSLDB_ResumenVentaDia_Consulta_sp]", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            ventaProducto.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerDetalleApartado(VentaProductos ventaProductos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ventaProductos.conexion, "spCSLDB_obtenerDetalleVentaApartado", ventaProductos.IDVenta, ventaProductos.IDSucursal);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            ventaProductos.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ModificarProductosPedidos(ref int Verificador, ref VentaProductos ventaProductos, Cliente cliente)
        {
            try
            {
                object res = SqlHelper.ExecuteScalar(ventaProductos.StrCnx, CommandType.StoredProcedure, "spCSLDB_abc_CatVentaPedidoModificar",
                new SqlParameter("@IDVenta", ventaProductos.IDVenta),
                new SqlParameter("@IDSucursal", ventaProductos.IDSucursal),
                new SqlParameter("@IDCliente", ventaProductos.IDCliente),
                new SqlParameter("@IDVendedor", ventaProductos.IDVendedor),
                new SqlParameter("@IDCajero", ventaProductos.IDCajero),
                new SqlParameter("@Descuento", ventaProductos.Descuento),
                new SqlParameter("@Subtotal", ventaProductos.Subtotal),
                new SqlParameter("@Iva", ventaProductos.Iva),
                new SqlParameter("@Total", ventaProductos.Total),
                new SqlParameter("@lstVentaDetalle", ventaProductos.ventadetalle)
                );
                if (res != null)
                {
                    Verificador = 0;
                    ventaProductos.IDVenta = res.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridProductosXEntregar(VentaProductos ventaProducto)
        {
            try
            {
                object[] Valores = { ventaProducto.Folio };
                DataSet ds = SqlHelper.ExecuteDataset(ventaProducto.conexion, "spCSLDB_CatProductosXEntregar_Consulta_sp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            ventaProducto.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EntregarProductos(VentaProductos ventaProductos, ref int Verificador)
        {
            try
            {
                object res = SqlHelper.ExecuteScalar(ventaProductos.conexion, CommandType.StoredProcedure, "spCSLDB_set_EntregarPedido",
                new SqlParameter("@productoXentregar", ventaProductos.datos),
                new SqlParameter("@id_venta", ventaProductos.IDVenta),
                new SqlParameter("@usuario", ventaProductos.id_u)
                );
                if (res != null)
                    Verificador = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridBusquedaVenta(VentaProductos ventaProducto)
        {
            try
            {
                object[] Valores = { ventaProducto.tipoBusqueda, ventaProducto.Folio, ventaProducto.NombreCliente, ventaProducto.FecVenta, ventaProducto.IDSucursal };
                DataSet ds = SqlHelper.ExecuteDataset(ventaProducto.conexion, "spCSLDB_CatBusquedaVenta2_Consulta2_sp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            ventaProducto.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridCambioDetalle(VentaProductos ventaProducto)
        {
            try
            {
                object[] Valores = { ventaProducto.IDSucursal, ventaProducto.IDVenta };
                DataSet ds = SqlHelper.ExecuteDataset(ventaProducto.conexion, "spCSLDB_CatCambioDetalle_Consulta_sp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            ventaProducto.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertarProductosCambios(ref int Verificador, ref VentaProductos ventaProductos, Cliente cliente)
        {
            try
            {
                object res = SqlHelper.ExecuteScalar(ventaProductos.StrCnx, CommandType.StoredProcedure, "spCSLDB_abc_CatVentaCambios",
                new SqlParameter("@IDVenta", ventaProductos.IDVenta),
                new SqlParameter("@IDSucursal", ventaProductos.IDSucursal),
                new SqlParameter("@IDCliente", ventaProductos.IDCliente),
                new SqlParameter("@IDCaja", ventaProductos.IDCaja),
                new SqlParameter("@IDVendedor", ventaProductos.IDVendedor),
                new SqlParameter("@IDCajero", ventaProductos.IDCajero),
                new SqlParameter("@Descuento", ventaProductos.Descuento),
                new SqlParameter("@SubTotal", ventaProductos.Subtotal),
                new SqlParameter("@Iva", ventaProductos.Iva),
                new SqlParameter("@Total", ventaProductos.Total),
                new SqlParameter("@Pago", ventaProductos.Pago),
                new SqlParameter("@PagoEfectivo", ventaProductos.PagoEfectivo),
                new SqlParameter("@PagoTarjeta", ventaProductos.PagoTarjeta),
                new SqlParameter("@PagoTransferencia", ventaProductos.PagoTransferencia),
                new SqlParameter("@PagoMonedero", ventaProductos.PagoMonedero),
                new SqlParameter("@Cambio", ventaProductos.Cambio),
                new SqlParameter("@lstDatosTarjeta", ventaProductos.DatosTarjeta),
                new SqlParameter("@lstDatosTransferencia", ventaProductos.DatosTransferencia),
                new SqlParameter("@lstCambioDetalle", ventaProductos.cambioModulo.datos)
                );
                if (res != null)
                {
                    Verificador = 0;
                    ventaProductos.IDVenta = res.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridCambio(VentaProductos ventaProducto)
        {
            try
            {
                object[] Valores = { ventaProducto.tabIndex, ventaProducto.IDSucursal, ventaProducto.FecVenta };
                DataSet ds = SqlHelper.ExecuteDataset(ventaProducto.conexion, "spCSLDB_CatCambios_Consulta_sp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            ventaProducto.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public VentaProductos obtenerDatosCancelacion(VentaProductos datos)
        {
            try
            {
                SqlDataReader SqlDr = null;
                object[] valores = { datos.IDVenta, datos.IDSucursal };
                SqlDr = SqlHelper.ExecuteReader(datos.StrCnx, "spCSLDB_get_DatosGeneralesCancelacion", valores);
                while (SqlDr.Read())
                {
                    datos.IDVenta = SqlDr.GetString(SqlDr.GetOrdinal("id_venta"));
                    datos.IDSucursal = SqlDr.GetString(SqlDr.GetOrdinal("id_sucursal"));
                    datos.Folio = SqlDr.GetString(SqlDr.GetOrdinal("folio"));
                    datos.FecVenta = SqlDr.GetDateTime(SqlDr.GetOrdinal("fec_venta"));
                    datos.HorVenta = SqlDr.GetString(SqlDr.GetOrdinal("hor_venta"));
                    datos.fechaCancelacion = Convert.ToDateTime(SqlDr.GetString(SqlDr.GetOrdinal("fechaCancelacion")));
                    datos.NombreCliente = SqlDr.GetString(SqlDr.GetOrdinal("nombre"));
                    datos.NombreVendedor = SqlDr.GetString(SqlDr.GetOrdinal("cajero"));
                    datos.Subtotal = SqlDr.GetDecimal(SqlDr.GetOrdinal("importe"));
                    datos.Descuento = SqlDr.GetDecimal(SqlDr.GetOrdinal("descuento"));
                    datos.Iva = SqlDr.GetDecimal(SqlDr.GetOrdinal("iva"));
                    datos.Total = SqlDr.GetDecimal(SqlDr.GetOrdinal("total"));
                }
                return datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridPedidoApp(VentaProductos ventaProducto)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ventaProducto.conexion, "spCSLDB_CatPedidoApp_Consulta_sp", ventaProducto.IDSucursal);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            ventaProducto.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cliente ObtenerDetallePedidoApp(VentaProductos ventaProductos)
        {
            try
            {
                SqlDataReader SqlDr = null;
                Cliente cliente = new Cliente();
                SqlDr = SqlHelper.ExecuteReader(ventaProductos.conexion, "spCSLDB_CatDetallePedidoApp_Consulta_sp", ventaProductos.IDVenta);
                while (SqlDr.Read())
                {
                    cliente.direccion = SqlDr.GetString(SqlDr.GetOrdinal("direccion"));
                    cliente.id_pais = SqlDr.GetInt32(SqlDr.GetOrdinal("id_pais"));
                    cliente.id_estado = SqlDr.GetInt32(SqlDr.GetOrdinal("id_estado"));
                    cliente.id_municipio = SqlDr.GetInt32(SqlDr.GetOrdinal("id_municipio"));
                    cliente.telefono = SqlDr.GetString(SqlDr.GetOrdinal("telefono"));
                    cliente.id_tipoEntrega = SqlDr.GetInt32(SqlDr.GetOrdinal("id_tipoEntrega"));
                    cliente.numtransaccion = SqlDr.GetString(SqlDr.GetOrdinal("numtransaccion"));
                    cliente.fechatransaccion = SqlDr.GetDateTime(SqlDr.GetOrdinal("fechatransaccion")).ToShortDateString();
                    cliente.horatransaccion = SqlDr.GetString(SqlDr.GetOrdinal("horatransaccion"));
                    cliente.observaciones = SqlDr.GetString(SqlDr.GetOrdinal("observaciones"));
                }
                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridPedidoPagadosApp(VentaProductos ventaProducto)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ventaProducto.conexion, "spCSLDB_CatPedidoPagadosApp_Consulta_sp", ventaProducto.IDSucursal);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            ventaProducto.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ActualizarPedidoListo(VentaProductos ventaProdcutos)
        {
            try
            {
                object[] Valores = { ventaProdcutos.IDVenta, ventaProdcutos.IDSucursal, ventaProdcutos.id_u };
                SqlHelper.ExecuteScalar(ventaProdcutos.conexion, "spCSLDB_set_PedidoListo", Valores);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CancelacionVenta(VentaProductos _venta, ref int verificador)
        {
            try
            {
                object[] valores = { _venta.IDSucursal, _venta.IDVenta, _venta.IDCaja, _venta.motivo, _venta.Total, _venta.Pago, _venta.Penalizacion, _venta.idMotivoCancelacion, _venta.id_u };

                SqlDataReader Dr = SqlHelper.ExecuteReader(_venta.conexion, "[dbo].[spCSLDB_CancelacionVenta]", valores);
                RespuestaSQL respuesta = new RespuestaSQL();
                while (Dr.Read())
                {
                    respuesta.Success = !Dr.IsDBNull(Dr.GetOrdinal("success")) ? Dr.GetBoolean(Dr.GetOrdinal("success")) : false;
                    respuesta.Mensaje = !Dr.IsDBNull(Dr.GetOrdinal("mensaje")) ? Dr.GetString(Dr.GetOrdinal("mensaje")) : string.Empty;
                }
                if (respuesta.Success)
                {
                    verificador = 1;
                }
                else
                {
                    verificador = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AgregarPagoAVenta(ref int Verificador, ref VentaTintoreria venta)
        {
            object res = SqlHelper.ExecuteScalar(Comun.conexion, CommandType.StoredProcedure, "spCSLDB_AddPago",
                new SqlParameter("@IDVenta", venta.Id_ventaServicio),
                new SqlParameter("@IDSucursal", venta.id_sucursal),
                new SqlParameter("@IDCliente", venta.idCliente),
                new SqlParameter("@NuevoMonedero", venta.monedero),
                new SqlParameter("@IDCajero", venta.Id_cajero),
                new SqlParameter("@Pago", venta.Pago),
                new SqlParameter("@PagoEfectivo", venta.PagoEfectivo),
                new SqlParameter("@PagoTarjeta", venta.PagoTarjeta),
                new SqlParameter("@PagoTransferencia", venta.PagoTransferencia),
                new SqlParameter("@PagoMonedero", venta.PagoMonedero),
                new SqlParameter("@lstDatosTarjeta", venta.DatosTarjeta),
                new SqlParameter("@lstDatosTransferencia", venta.DatosTransferencia),
                new SqlParameter("@IDCaja", venta.Id_caja)
            );
            if (res != null)
            {
                Verificador = 0;
                venta.Id_ventaServicio = res.ToString();
            }
        }
    }
}
