using TintoreriaGlobal;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaDatos
{
    public class ReportesDatos : HelperSQL
    {
        public void ObtenerProductosMasVendidosTop10(ReporteProductosTop10 reporteProductosTop10)
        {
            try
            {
                SqlDataReader dr = null;
                object[] Valores = { reporteProductosTop10.id_sucursal, reporteProductosTop10.fechaInicio, reporteProductosTop10.fechaFin};
                dr = SqlHelper.ExecuteReader(reporteProductosTop10.conexion, "spCSLDB_Consultar_ReportesProductosMasVendidosTop10", Valores);
                ReporteProductosTop10 reporte;
                reporteProductosTop10.lstReporteProductosTop10 = new List<ReporteProductosTop10>();
                while (dr.Read())
                {
                    reporte = new ReporteProductosTop10();
                    reporte.codigoBarra = dr["id_codigoEan"].ToString();
                    reporte.producto = dr["nombre_producto"].ToString();
                    reporte.numVentas = Convert.ToInt32(dr["numVentas"].ToString());
                    reporteProductosTop10.lstReporteProductosTop10.Add(reporte);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerProductosMenosVendidosTop10(ReporteProductosTop10 reporteProductosTop10)
        {
            try
            {
                SqlDataReader dr = null;
                object[] Valores = { reporteProductosTop10.id_sucursal, reporteProductosTop10.fechaInicio, reporteProductosTop10.fechaFin };
                dr = SqlHelper.ExecuteReader(reporteProductosTop10.conexion, "spCSLDB_Consultar_ReportesProductosMenosVendidosTop10", Valores);
                ReporteProductosTop10 reporte;
                reporteProductosTop10.lstReporteProductosTop10 = new List<ReporteProductosTop10>();
                while (dr.Read())
                {
                    reporte = new ReporteProductosTop10();
                    reporte.codigoBarra = dr["id_codigoEan"].ToString();
                    reporte.producto = dr["nombre_producto"].ToString();
                    reporte.numVentas = Convert.ToInt32(dr["numVentas"].ToString());
                    reporteProductosTop10.lstReporteProductosTop10.Add(reporte);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerVendedoresMayoresVentasTop5(ReporteVendedorTop5 reporteProductosTop5)
        {
            try
            {
                SqlDataReader dr = null;
                object[] Valores = { reporteProductosTop5.id_sucursal, reporteProductosTop5.fechaInicio, reporteProductosTop5.fechaFin };
                dr = SqlHelper.ExecuteReader(reporteProductosTop5.conexion, "spCSLDB_Consultar_ReportesVendedoresMayoresVentasTop5", Valores);
                ReporteVendedorTop5 reporte;
                reporteProductosTop5.lstReporteVendedorTop5 = new List<ReporteVendedorTop5>();
                while (dr.Read())
                {
                    reporte = new ReporteVendedorTop5();
                    reporte.vendedor = dr["vendedor"].ToString();
                    reporte.numVentas = Convert.ToInt32(dr["numVentas"].ToString());
                    reporteProductosTop5.lstReporteVendedorTop5.Add(reporte);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerProductosMasPedidosTop10(ReporteProductosTop10 reporteProductosTop10)
        {
            try
            {
                SqlDataReader dr = null;
                object[] Valores = { reporteProductosTop10.id_sucursal, reporteProductosTop10.fechaInicio, reporteProductosTop10.fechaFin };
                dr = SqlHelper.ExecuteReader(reporteProductosTop10.conexion, "spCSLDB_Consultar_ReportesProductosMasPedidosTop10", Valores);
                ReporteProductosTop10 reporte;
                reporteProductosTop10.lstReporteProductosTop10 = new List<ReporteProductosTop10>();
                while (dr.Read())
                {
                    reporte = new ReporteProductosTop10();
                    reporte.codigoBarra = dr["id_codigoEan"].ToString();
                    reporte.producto = dr["nombre_producto"].ToString();
                    reporte.numVentas = Convert.ToInt32(dr["numVentas"].ToString());
                    reporteProductosTop10.lstReporteProductosTop10.Add(reporte);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerCajaXID(Caja caja)
        {
            try
            {
                object[] Valores = { caja.id_caja, caja.id_sucursal };
                SqlDataReader SqlDr = SqlHelper.ExecuteReader(caja.CadConexion, "spCSLDB_CatCajaXSucursalID_Consulta_sp", Valores);
                while (SqlDr.Read())
                {
                    caja.TotalInicioCaja = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("caja_inicial"));
                    caja.TotalVentas = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("ventas"));
                    caja.TotalPedidos = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("pedidos"));
                    caja.TotalCambios = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("cambios"));
                    caja.TotalCancelaciones = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("cancelaciones"));
                    caja.TotalCompras = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("compras"));
                    caja.TotalDepositos = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("depositos"));
                    caja.TotalRetirosPagos = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("retiros"));
                    caja.TotalEfectivo = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("efectivo"));
                    caja.TotalMonedero = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("monedero"));
                    caja.TotalTarjetas = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("tarjetas"));
                    caja.TotalTransferencia = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("transferencias"));
                    caja.TotalCaja = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("total"));
                    caja.TotalFinalCaja = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("caja_final"));
                    caja.urlLogo = (string)SqlDr.GetString(SqlDr.GetOrdinal("Logo"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerCajaXIDEquipoFechas(Caja caja)
        {
            try
            {
                object[] Valores = { caja.id_equipo, caja.fechaCaja, caja.fechaCaja2, caja.id_sucursal };
                SqlDataReader SqlDr = SqlHelper.ExecuteReader(caja.CadConexion, "spCSLDB_CatCajaXSucursalXEquipoFechasID_Consulta_sp", Valores);
                while (SqlDr.Read())
                {
                    caja.TotalInicioCaja = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("caja_inicial"));
                    caja.TotalVentas = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("ventas"));
                    caja.TotalPedidos = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("pedidos"));
                    caja.TotalCambios = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("cambios"));
                    caja.TotalCancelaciones = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("cancelaciones"));
                    caja.TotalCompras = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("compras"));
                    caja.TotalDepositos = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("depositos"));
                    caja.TotalRetirosPagos = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("retiros"));
                    caja.TotalEfectivo = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("efectivo"));
                    caja.TotalMonedero = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("monedero"));
                    caja.TotalTarjetas = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("tarjetas"));
                    caja.TotalTransferencia = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("transferencias"));
                    caja.TotalCaja = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("total"));
                    caja.TotalFinalCaja = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("caja_final"));
                    caja.urlLogo = (string)SqlDr.GetString(SqlDr.GetOrdinal("Logo"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerProveedorMasComprasTop5(ReporteProveedorComprasTop5 reporteProductosTop5)
        {
            try
            {
                SqlDataReader dr = null;
                object[] Valores = {reporteProductosTop5.id_sucursal, reporteProductosTop5.fechaInicio, reporteProductosTop5.fechaFin };
                dr = SqlHelper.ExecuteReader(reporteProductosTop5.conexion, "spCSLDB_Consultar_ReportesProveedorMasComprasTop5", Valores);
                ReporteProveedorComprasTop5 reporte;
                reporteProductosTop5.lstReporteProveedorComprasTop5 = new List<ReporteProveedorComprasTop5>();
                while (dr.Read())
                {
                    reporte = new ReporteProveedorComprasTop5();
                    reporte.proveedor = dr["proveedor"].ToString();
                    reporte.numCompras = Convert.ToInt32(dr["numCompras"].ToString());
                    reporteProductosTop5.lstReporteProveedorComprasTop5.Add(reporte);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ObtenerProveedorMenosComprasTop5(ReporteProveedorComprasTop5 reporteProveedorComprasTop5)
        {
            try
            {
                SqlDataReader dr = null;
                object[] Valores = { reporteProveedorComprasTop5.id_sucursal, reporteProveedorComprasTop5.fechaInicio, reporteProveedorComprasTop5.fechaFin };
                dr = SqlHelper.ExecuteReader(reporteProveedorComprasTop5.conexion, "spCSLDB_Consultar_ReportesProveedorMenosComprasTop5", Valores);
                ReporteProveedorComprasTop5 reporte;
                reporteProveedorComprasTop5.lstReporteProveedorComprasTop5 = new List<ReporteProveedorComprasTop5>();
                while (dr.Read())
                {
                    reporte = new ReporteProveedorComprasTop5();
                    reporte.proveedor = dr["proveedor"].ToString();
                    reporte.numCompras = Convert.ToInt32(dr["numCompras"].ToString());
                    reporteProveedorComprasTop5.lstReporteProveedorComprasTop5.Add(reporte);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ObtenerProveedorMasCambiosPorFallasTop5(ReporteProveedorComprasTop5 reporteProveedorComprasTop5)
        {
            try
            {
                SqlDataReader dr = null;
                object[] Valores = { reporteProveedorComprasTop5.id_sucursal, reporteProveedorComprasTop5.fechaInicio, reporteProveedorComprasTop5.fechaFin };
                dr = SqlHelper.ExecuteReader(reporteProveedorComprasTop5.conexion, "spCSLDB_Consultar_ReportesProveedorMasCambiosTop5", Valores);
                ReporteProveedorComprasTop5 reporte;
                reporteProveedorComprasTop5.lstReporteProveedorComprasTop5 = new List<ReporteProveedorComprasTop5>();
                while (dr.Read())
                {
                    reporte = new ReporteProveedorComprasTop5();
                    reporte.proveedor = dr["proveedor"].ToString();
                    reporte.numCompras = Convert.ToInt32(dr["numCambios"].ToString());
                    reporteProveedorComprasTop5.lstReporteProveedorComprasTop5.Add(reporte);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ObtenerProductosMasCambiosPorFallasTop10(ReporteProductosTop10 ReporteProductosCambiosTop10)
        {
            try
            {
                SqlDataReader dr = null;
                object[] Valores = { ReporteProductosCambiosTop10.id_sucursal, ReporteProductosCambiosTop10.fechaInicio, ReporteProductosCambiosTop10.fechaFin };
                dr = SqlHelper.ExecuteReader(ReporteProductosCambiosTop10.conexion, "spCSLDB_Consultar_ReportesProductosMasCambiadosTop10", Valores);
                ReporteProductosTop10 reporte;
                ReporteProductosCambiosTop10.lstReporteProductosTop10 = new List<ReporteProductosTop10>();
                while (dr.Read())
                {
                    reporte = new ReporteProductosTop10();
                    reporte.codigoBarra = dr["id_codigoEan"].ToString();
                    reporte.producto = dr["nombre_producto"].ToString();
                    reporte.numVentas = Convert.ToInt32(dr["numCambios"].ToString());
                    ReporteProductosCambiosTop10.lstReporteProductosTop10.Add(reporte);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerResultadoXMesXSucursal(ReporteResultado reporteResultado)
        {
            try
            {
                object[] Valores = { reporteResultado.id_sucursal, reporteResultado.fechaInicio,reporteResultado.fechaFin};
                DataSet ds = SqlHelper.ExecuteDataset(reporteResultado.conexion, "spCSLDB_Consultar_ReportesEstadosResultados", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            float granTotal = 0.0F;
                            foreach(DataRow auxSeccion in ds.Tables[0].Rows)
                            {
                                float auxTotal=0.0F;
                                reporteResultado.lstReporteResultado.Add( new ReporteResultado { seccion = auxSeccion["descripcion"].ToString(), resultado = "", operacion = "", monto = "" });
                                try
                                {
                                    if (ds.Tables[1] != null)
                                        foreach (DataRow auxResultado in ds.Tables[1].Select("id_seccion=" + auxSeccion["id_seccion"]).CopyToDataTable().Rows)
                                        {
                                            reporteResultado.lstReporteResultado.Add(new ReporteResultado { seccion = "", resultado = auxResultado["resultado"].ToString(), operacion = auxResultado["operacion"].ToString(), monto = string.Format("{0:C2}", float.Parse(auxResultado["monto"].ToString())) });
                                            auxTotal += auxResultado["operacion"].Equals("+") ? float.Parse(auxResultado["monto"].ToString()) : (float.Parse(auxResultado["monto"].ToString()) * -1);
                                        }
                                }
                                catch (Exception)
                                { 
                                }
                                granTotal += auxTotal;
                                reporteResultado.lstReporteResultado.Add(new ReporteResultado { seccion = "", resultado = "", operacion = "Total " + auxSeccion["descripcion"].ToString(), monto = string.Format("{0:C2}",auxTotal) });
                            }
                            reporteResultado.lstReporteResultado.Add(new ReporteResultado { seccion = "", resultado = "", operacion = "", monto = ""});
                            reporteResultado.lstReporteResultado.Add(new ReporteResultado { seccion = "", resultado = "", operacion = "Gran Total", monto = string.Format("{0:C2}", granTotal) });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerDesgloseMovimientosXDia(DesgloseMovimientos desgloseMovimientos)
        {                                
            try
            {
                object[] Valores = { desgloseMovimientos.id_sucursal, desgloseMovimientos.id_caja};
                DataSet ds = SqlHelper.ExecuteDataset(desgloseMovimientos.conexion, "spCSLDB_Consultar_ReportesDesgloseMovimientos", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        desgloseMovimientos.lstCaja = new List<DesgloseMovimientos>();  
                        if (ds.Tables[0] != null)
                        {    
                            if (ds.Tables[0].Rows.Count == 1)
                            {                                                               
                                desgloseMovimientos.lstCaja.Add(new DesgloseMovimientos { TotalInicioCaja = float.Parse(ds.Tables[0].Rows[0]["caja_inicial"].ToString()),
                                    TotalVentas = float.Parse(ds.Tables[0].Rows[0]["ventas"].ToString()),TotalPedidos = float.Parse(ds.Tables[0].Rows[0]["pedidos"].ToString()),
                                    TotalCambios = float.Parse(ds.Tables[0].Rows[0]["cambios"].ToString()),TotalCancelaciones = float.Parse(ds.Tables[0].Rows[0]["cancelaciones"].ToString()),
                                    TotalCompras = float.Parse(ds.Tables[0].Rows[0]["compras"].ToString()),TotalDepositos = float.Parse(ds.Tables[0].Rows[0]["depositos"].ToString()),
                                    TotalRetiros = float.Parse(ds.Tables[0].Rows[0]["retiros"].ToString()),TotalEfectivo = float.Parse(ds.Tables[0].Rows[0]["efectivo"].ToString()),
                                    TotalMonedero = float.Parse(ds.Tables[0].Rows[0]["monedero"].ToString()),TotalTarjetas = float.Parse(ds.Tables[0].Rows[0]["tarjetas"].ToString()),
                                    TotalTransferencia = float.Parse(ds.Tables[0].Rows[0]["transferencias"].ToString()),TotalCaja = float.Parse(ds.Tables[0].Rows[0]["totalCaja"].ToString()),
                                    TotalFinalCaja = float.Parse(ds.Tables[0].Rows[0]["caja_final"].ToString())
                                });
                            }                          
                        }
                        DesgloseMovimientos reporte;
                        desgloseMovimientos.lstVenta = new List<DesgloseMovimientos>();
                        if (ds.Tables[1] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[1].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folio"].ToString();
                                reporte.FecVenta = Convert.ToDateTime(auxResultado["fec_venta"]).ToString("dd/MM/yyyy");
                                reporte.HorVenta = auxResultado["hor_venta"].ToString();
                                reporte.NombreCliente = auxResultado["cliente"].ToString();
                                reporte.NombreVendedor = auxResultado["vendedor"].ToString();
                                reporte.Importe = float.Parse(auxResultado["importe"].ToString());
                                reporte.Descuento = float.Parse(auxResultado["descuento"].ToString());
                                reporte.Iva = float.Parse(auxResultado["iva"].ToString());
                                reporte.Total = float.Parse(auxResultado["total"].ToString());
                                desgloseMovimientos.lstVenta.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstPedido = new List<DesgloseMovimientos>();
                        if (ds.Tables[2] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[2].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folio"].ToString();
                                reporte.FecVenta = Convert.ToDateTime(auxResultado["fec_venta"]).ToString("dd/MM/yyyy");
                                reporte.HorVenta = auxResultado["hor_venta"].ToString();
                                reporte.NombreCliente = auxResultado["cliente"].ToString();
                                reporte.NombreVendedor = auxResultado["vendedor"].ToString();
                                reporte.Importe = float.Parse(auxResultado["importe"].ToString());
                                reporte.Descuento = float.Parse(auxResultado["descuento"].ToString());
                                reporte.Iva = float.Parse(auxResultado["iva"].ToString());
                                reporte.Total = float.Parse(auxResultado["total"].ToString());
                                desgloseMovimientos.lstPedido.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstCambio = new List<DesgloseMovimientos>();
                        if (ds.Tables[3] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[3].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folio"].ToString();
                                reporte.FecVenta = Convert.ToDateTime(auxResultado["fec_venta"]).ToString("dd/MM/yyyy");
                                reporte.HorVenta = auxResultado["hor_venta"].ToString();
                                reporte.NombreCliente = auxResultado["cliente"].ToString();
                                reporte.NombreVendedor = auxResultado["vendedor"].ToString();
                                reporte.Importe = float.Parse(auxResultado["importe"].ToString());
                                reporte.Descuento = float.Parse(auxResultado["descuento"].ToString());
                                reporte.Iva = float.Parse(auxResultado["iva"].ToString());
                                reporte.Total = float.Parse(auxResultado["total"].ToString());
                                desgloseMovimientos.lstCambio.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstCancelacion = new List<DesgloseMovimientos>();
                        if (ds.Tables[4] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[4].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folio"].ToString();
                                reporte.tipoVenta = auxResultado["tipoVenta"].ToString();
                                reporte.FecVenta = Convert.ToDateTime(auxResultado["fec_venta"]).ToString("dd/MM/yyyy");
                                reporte.HorVenta = auxResultado["hor_venta"].ToString();
                                reporte.NombreCliente = auxResultado["cliente"].ToString();
                                reporte.NombreVendedor = auxResultado["vendedor"].ToString();
                                reporte.Importe = float.Parse(auxResultado["importe"].ToString());
                                reporte.pago = float.Parse(auxResultado["pago"].ToString());
                                reporte.Iva = float.Parse(auxResultado["iva"].ToString());
                                reporte.Total = float.Parse(auxResultado["total"].ToString());
                                desgloseMovimientos.lstCancelacion.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstCompra = new List<DesgloseMovimientos>();
                        if (ds.Tables[5] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[5].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folioPedido"].ToString();                                
                                reporte.FecVenta = Convert.ToDateTime(auxResultado["fecha"]).ToString("dd/MM/yyyy");
                                reporte.HorVenta = auxResultado["hora"].ToString();                                
                                reporte.pago = float.Parse(auxResultado["monto"].ToString());                                
                                reporte.Total = float.Parse(auxResultado["total"].ToString());
                                desgloseMovimientos.lstCompra.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstRetiro = new List<DesgloseMovimientos>();
                        if (ds.Tables[6] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[6].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.motivo = auxResultado["motivo"].ToString();
                                reporte.pago = float.Parse(auxResultado["monto"].ToString());
                                reporte.NombreVendedor = auxResultado["vendedor"].ToString();
                                desgloseMovimientos.lstRetiro.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstDeposito = new List<DesgloseMovimientos>();
                        if (ds.Tables[7] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[7].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.motivo = auxResultado["motivo"].ToString();                                                                
                                reporte.pago = float.Parse(auxResultado["monto"].ToString());
                                reporte.NombreVendedor = auxResultado["vendedor"].ToString();
                                desgloseMovimientos.lstDeposito.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstEfectivo = new List<DesgloseMovimientos>();
                        if (ds.Tables[8] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[8].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folio"].ToString();
                                reporte.monto = float.Parse(auxResultado["monto"].ToString());
                                reporte.NombreCliente = auxResultado["cliente"].ToString();
                                reporte.NombreCajero = auxResultado["cajero"].ToString();
                                desgloseMovimientos.lstEfectivo.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstTarjeta = new List<DesgloseMovimientos>();
                        if (ds.Tables[9] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[9].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folio"].ToString();
                                reporte.NombreCliente = auxResultado["cliente"].ToString();
                                reporte.NombreCajero = auxResultado["cajero"].ToString();
                                reporte.autorizacion = auxResultado["autorizacion"].ToString();
                                reporte.identificacion = auxResultado["identificacion"].ToString();
                                reporte.banco = auxResultado["banco"].ToString();
                                reporte.tipoTarjeta = auxResultado["tipoTarjeta"].ToString();
                                reporte.monto = float.Parse(auxResultado["monto"].ToString());
                                desgloseMovimientos.lstTarjeta.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstTransferencia = new List<DesgloseMovimientos>();
                        if (ds.Tables[10] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[10].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folio"].ToString();
                                reporte.NombreCliente = auxResultado["cliente"].ToString();
                                reporte.NombreCajero = auxResultado["cajero"].ToString();
                                reporte.autorizacion = auxResultado["autorizacion"].ToString();
                                reporte.banco = auxResultado["banco"].ToString();
                                reporte.monto = float.Parse(auxResultado["monto"].ToString());
                                desgloseMovimientos.lstTransferencia.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstMonedero = new List<DesgloseMovimientos>();
                        if (ds.Tables[11] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[11].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folio"].ToString();
                                reporte.monto = float.Parse(auxResultado["monto"].ToString());
                                reporte.NombreCliente = auxResultado["cliente"].ToString();
                                reporte.NombreCajero = auxResultado["cajero"].ToString();
                                desgloseMovimientos.lstMonedero.Add(reporte);
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
        public void ObtenerDesgloseMovimientosActual(DesgloseMovimientos desgloseMovimientos)
        {
            try
            {
                object[] Valores = { desgloseMovimientos.id_sucursal, desgloseMovimientos.id_caja};
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "spCSLDB_Consultar_ReportesDesgloseMovimientosActual", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            desgloseMovimientos.Empresas.nombreComercial = ds.Tables[0].Rows[0]["NombreEmpresa"].ToString();
                            desgloseMovimientos.Empresas.slogan = ds.Tables[0].Rows[0]["Slogan"].ToString();
                            desgloseMovimientos.Empresas.rfc = ds.Tables[0].Rows[0]["RFC"].ToString();
                            desgloseMovimientos.Empresas.pathImg = ds.Tables[0].Rows[0]["Logo"].ToString();
                        }

                        desgloseMovimientos.lstCaja = new List<DesgloseMovimientos>();
                        if (ds.Tables[1] != null)
                        {
                            if (ds.Tables[1].Rows.Count == 1)
                            {
                                desgloseMovimientos.lstCaja.Add(new DesgloseMovimientos
                                {
                                    TotalInicioCaja = float.Parse(ds.Tables[1].Rows[0]["caja_inicial"].ToString()),
                                    TotalVentas = float.Parse(ds.Tables[1].Rows[0]["ventas"].ToString()),
                                    TotalPedidos = float.Parse(ds.Tables[1].Rows[0]["pedidos"].ToString()),
                                    TotalCambios = float.Parse(ds.Tables[1].Rows[0]["cambios"].ToString()),
                                    TotalCancelaciones = float.Parse(ds.Tables[1].Rows[0]["cancelaciones"].ToString()),
                                    TotalCompras = float.Parse(ds.Tables[1].Rows[0]["compras"].ToString()),
                                    TotalDepositos = float.Parse(ds.Tables[1].Rows[0]["depositos"].ToString()),
                                    TotalRetiros = float.Parse(ds.Tables[1].Rows[0]["retiros"].ToString()),
                                    TotalEfectivo = float.Parse(ds.Tables[1].Rows[0]["efectivo"].ToString()),
                                    TotalMonedero = float.Parse(ds.Tables[1].Rows[0]["monedero"].ToString()),
                                    TotalTarjetas = float.Parse(ds.Tables[1].Rows[0]["tarjetas"].ToString()),
                                    TotalTransferencia = float.Parse(ds.Tables[1].Rows[0]["transferencias"].ToString()),
                                    TotalCaja = float.Parse(ds.Tables[1].Rows[0]["totalCaja"].ToString())
                                });
                            }
                        }
                        DesgloseMovimientos reporte;
                        desgloseMovimientos.lstVenta = new List<DesgloseMovimientos>();
                        if (ds.Tables[2] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[2].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folio"].ToString();
                                reporte.FecVenta = Convert.ToDateTime(auxResultado["fec_venta"]).ToString("dd/MM/yyyy");
                                reporte.HorVenta = auxResultado["hor_venta"].ToString();
                                reporte.NombreCliente = auxResultado["cliente"].ToString();
                                reporte.NombreVendedor = auxResultado["vendedor"].ToString();
                                reporte.Importe = float.Parse(auxResultado["importe"].ToString());
                                reporte.Descuento = float.Parse(auxResultado["descuento"].ToString());
                                reporte.Iva = float.Parse(auxResultado["iva"].ToString());
                                reporte.Total = float.Parse(auxResultado["total"].ToString());
                                desgloseMovimientos.lstVenta.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstPedido = new List<DesgloseMovimientos>();
                        if (ds.Tables[3] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[3].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folio"].ToString();
                                reporte.FecVenta = Convert.ToDateTime(auxResultado["fec_venta"]).ToString("dd/MM/yyyy");
                                reporte.HorVenta = auxResultado["hor_venta"].ToString();
                                reporte.NombreCliente = auxResultado["cliente"].ToString();
                                reporte.NombreVendedor = auxResultado["vendedor"].ToString();
                                reporte.Importe = float.Parse(auxResultado["importe"].ToString());
                                reporte.Descuento = float.Parse(auxResultado["descuento"].ToString());
                                reporte.Iva = float.Parse(auxResultado["iva"].ToString());
                                reporte.Total = float.Parse(auxResultado["total"].ToString());
                                desgloseMovimientos.lstPedido.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstCambio = new List<DesgloseMovimientos>();
                        if (ds.Tables[4] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[4].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folio"].ToString();
                                reporte.FecVenta = Convert.ToDateTime(auxResultado["fec_venta"]).ToString("dd/MM/yyyy");
                                reporte.HorVenta = auxResultado["hor_venta"].ToString();
                                reporte.NombreCliente = auxResultado["cliente"].ToString();
                                reporte.NombreVendedor = auxResultado["vendedor"].ToString();
                                reporte.Importe = float.Parse(auxResultado["importe"].ToString());
                                reporte.Descuento = float.Parse(auxResultado["descuento"].ToString());
                                reporte.Iva = float.Parse(auxResultado["iva"].ToString());
                                reporte.Total = float.Parse(auxResultado["total"].ToString());
                                desgloseMovimientos.lstCambio.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstCancelacion = new List<DesgloseMovimientos>();
                        if (ds.Tables[5] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[5].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folio"].ToString();
                                reporte.tipoVenta = auxResultado["tipoVenta"].ToString();
                                reporte.FecVenta = Convert.ToDateTime(auxResultado["fec_venta"]).ToString("dd/MM/yyyy");
                                reporte.HorVenta = auxResultado["hor_venta"].ToString();
                                reporte.NombreCliente = auxResultado["cliente"].ToString();
                                reporte.NombreVendedor = auxResultado["vendedor"].ToString();
                                reporte.Importe = float.Parse(auxResultado["importe"].ToString());
                                reporte.pago = float.Parse(auxResultado["pago"].ToString());
                                reporte.Iva = float.Parse(auxResultado["iva"].ToString());
                                reporte.Total = float.Parse(auxResultado["total"].ToString());
                                desgloseMovimientos.lstCancelacion.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstCompra = new List<DesgloseMovimientos>();
                        if (ds.Tables[6] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[6].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folioPedido"].ToString();
                                reporte.FecVenta = Convert.ToDateTime(auxResultado["fecha"]).ToString("dd/MM/yyyy");
                                reporte.HorVenta = auxResultado["hora"].ToString();
                                reporte.pago = float.Parse(auxResultado["monto"].ToString());
                                reporte.Total = float.Parse(auxResultado["total"].ToString());
                                desgloseMovimientos.lstCompra.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstRetiro = new List<DesgloseMovimientos>();
                        if (ds.Tables[7] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[7].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.motivo = auxResultado["motivo"].ToString();
                                reporte.pago = float.Parse(auxResultado["monto"].ToString());
                                reporte.NombreVendedor = auxResultado["vendedor"].ToString();
                                desgloseMovimientos.lstRetiro.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstDeposito = new List<DesgloseMovimientos>();
                        if (ds.Tables[8] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[8].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.motivo = auxResultado["motivo"].ToString();
                                reporte.pago = float.Parse(auxResultado["monto"].ToString());
                                reporte.NombreVendedor = auxResultado["vendedor"].ToString();
                                desgloseMovimientos.lstDeposito.Add(reporte);
                            }
                        }
                        if (ds.Tables[9] != null)
                        {
                            if (ds.Tables[9].Rows.Count == 1)
                            {
                                desgloseMovimientos.sucursal = ds.Tables[9].Rows[0]["sucursal"].ToString();
                                desgloseMovimientos.caja = ds.Tables[9].Rows[0]["caja"].ToString();
                            }
                        }
                        desgloseMovimientos.lstEfectivo = new List<DesgloseMovimientos>();
                        if (ds.Tables[10] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[10].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folio"].ToString();
                                reporte.monto = float.Parse(auxResultado["monto"].ToString());
                                reporte.NombreCliente = auxResultado["cliente"].ToString();
                                reporte.NombreCajero = auxResultado["cajero"].ToString();
                                desgloseMovimientos.lstEfectivo.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstTarjeta = new List<DesgloseMovimientos>();
                        if (ds.Tables[11] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[11].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folio"].ToString();
                                reporte.NombreCliente = auxResultado["cliente"].ToString();
                                reporte.NombreCajero = auxResultado["cajero"].ToString();
                                reporte.autorizacion = auxResultado["autorizacion"].ToString();
                                reporte.identificacion = auxResultado["identificacion"].ToString();
                                reporte.banco = auxResultado["banco"].ToString();
                                reporte.tipoTarjeta = auxResultado["tipoTarjeta"].ToString();
                                reporte.monto = float.Parse(auxResultado["monto"].ToString());                                
                                desgloseMovimientos.lstTarjeta.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstTransferencia = new List<DesgloseMovimientos>();
                        if (ds.Tables[12] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[12].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folio"].ToString();
                                reporte.NombreCliente = auxResultado["cliente"].ToString();
                                reporte.NombreCajero = auxResultado["cajero"].ToString();
                                reporte.autorizacion = auxResultado["autorizacion"].ToString();                                
                                reporte.banco = auxResultado["banco"].ToString();                                
                                reporte.monto = float.Parse(auxResultado["monto"].ToString());  
                                desgloseMovimientos.lstTransferencia.Add(reporte);
                            }                            
                        }
                        desgloseMovimientos.lstMonedero = new List<DesgloseMovimientos>();
                        if (ds.Tables[13] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[13].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folio"].ToString();
                                reporte.monto = float.Parse(auxResultado["monto"].ToString());
                                reporte.NombreCliente = auxResultado["cliente"].ToString();
                                reporte.NombreCajero = auxResultado["cajero"].ToString();
                                desgloseMovimientos.lstMonedero.Add(reporte);
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
        public void ObtenerDesgloseMovimientosXFechas(DesgloseMovimientos desgloseMovimientos)
        {
            try
            {
                object[] Valores = {desgloseMovimientos.id_equipo,desgloseMovimientos.fechaInicio,desgloseMovimientos.fechaFin,desgloseMovimientos.id_sucursal };
                DataSet ds = SqlHelper.ExecuteDataset(desgloseMovimientos.conexion, "spCSLDB_Consultar_ReportesDesgloseMovimientosXfechas", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        desgloseMovimientos.lstCaja = new List<DesgloseMovimientos>();
                        if (ds.Tables[0] != null)
                        {
                            if (ds.Tables[0].Rows.Count == 1)
                            {
                                desgloseMovimientos.logo = ds.Tables[0].Rows[0]["Logo"].ToString();

                                desgloseMovimientos.lstCaja.Add(new DesgloseMovimientos
                                {
                                    TotalInicioCaja = float.Parse(ds.Tables[0].Rows[0]["caja_inicial"].ToString()),
                                    TotalVentas = float.Parse(ds.Tables[0].Rows[0]["ventas"].ToString()),
                                    TotalPedidos = float.Parse(ds.Tables[0].Rows[0]["pedidos"].ToString()),
                                    TotalCambios = float.Parse(ds.Tables[0].Rows[0]["cambios"].ToString()),
                                    TotalCancelaciones = float.Parse(ds.Tables[0].Rows[0]["cancelaciones"].ToString()),
                                    TotalCompras = float.Parse(ds.Tables[0].Rows[0]["compras"].ToString()),
                                    TotalDepositos = float.Parse(ds.Tables[0].Rows[0]["depositos"].ToString()),
                                    TotalRetiros = float.Parse(ds.Tables[0].Rows[0]["retiros"].ToString()),
                                    TotalEfectivo = float.Parse(ds.Tables[0].Rows[0]["efectivo"].ToString()),
                                    TotalMonedero = float.Parse(ds.Tables[0].Rows[0]["monedero"].ToString()),
                                    TotalTarjetas = float.Parse(ds.Tables[0].Rows[0]["tarjetas"].ToString()),
                                    TotalTransferencia = float.Parse(ds.Tables[0].Rows[0]["transferencias"].ToString()),
                                    TotalCaja = float.Parse(ds.Tables[0].Rows[0]["totalCaja"].ToString()),
                                    TotalFinalCaja = float.Parse(ds.Tables[0].Rows[0]["caja_final"].ToString()),
                                });
                            }
                        }
                        DesgloseMovimientos reporte;
                        desgloseMovimientos.lstVenta = new List<DesgloseMovimientos>();
                        if (ds.Tables[1] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[1].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folio"].ToString();
                                reporte.FecVenta = Convert.ToDateTime(auxResultado["fec_venta"]).ToString("dd/MM/yyyy");
                                reporte.HorVenta = auxResultado["hor_venta"].ToString();
                                reporte.NombreCliente = auxResultado["cliente"].ToString();
                                reporte.NombreVendedor = auxResultado["vendedor"].ToString();
                                reporte.Importe = float.Parse(auxResultado["importe"].ToString());
                                reporte.Descuento = float.Parse(auxResultado["descuento"].ToString());
                                reporte.Iva = float.Parse(auxResultado["iva"].ToString());
                                reporte.Total = float.Parse(auxResultado["total"].ToString());
                                desgloseMovimientos.lstVenta.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstPedido = new List<DesgloseMovimientos>();
                        if (ds.Tables[2] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[2].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folio"].ToString();
                                reporte.FecVenta = Convert.ToDateTime(auxResultado["fec_venta"]).ToString("dd/MM/yyyy");
                                reporte.HorVenta = auxResultado["hor_venta"].ToString();
                                reporte.NombreCliente = auxResultado["cliente"].ToString();
                                reporte.NombreVendedor = auxResultado["vendedor"].ToString();
                                reporte.Importe = float.Parse(auxResultado["importe"].ToString());
                                reporte.Descuento = float.Parse(auxResultado["descuento"].ToString());
                                reporte.Iva = float.Parse(auxResultado["iva"].ToString());
                                reporte.Total = float.Parse(auxResultado["total"].ToString());
                                desgloseMovimientos.lstPedido.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstCambio = new List<DesgloseMovimientos>();
                        if (ds.Tables[3] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[3].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folio"].ToString();
                                reporte.FecVenta = Convert.ToDateTime(auxResultado["fec_venta"]).ToString("dd/MM/yyyy");
                                reporte.HorVenta = auxResultado["hor_venta"].ToString();
                                reporte.NombreCliente = auxResultado["cliente"].ToString();
                                reporte.NombreVendedor = auxResultado["vendedor"].ToString();
                                reporte.Importe = float.Parse(auxResultado["importe"].ToString());
                                reporte.Descuento = float.Parse(auxResultado["descuento"].ToString());
                                reporte.Iva = float.Parse(auxResultado["iva"].ToString());
                                reporte.Total = float.Parse(auxResultado["total"].ToString());
                                desgloseMovimientos.lstCambio.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstCancelacion = new List<DesgloseMovimientos>();
                        if (ds.Tables[4] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[4].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folio"].ToString();
                                reporte.tipoVenta = auxResultado["tipoVenta"].ToString();
                                reporte.FecVenta = Convert.ToDateTime(auxResultado["fec_venta"]).ToString("dd/MM/yyyy");
                                reporte.HorVenta = auxResultado["hor_venta"].ToString();
                                reporte.NombreCliente = auxResultado["cliente"].ToString();
                                reporte.NombreVendedor = auxResultado["vendedor"].ToString();
                                reporte.Importe = float.Parse(auxResultado["importe"].ToString());
                                reporte.pago = float.Parse(auxResultado["pago"].ToString());
                                reporte.Iva = float.Parse(auxResultado["iva"].ToString());
                                reporte.Total = float.Parse(auxResultado["total"].ToString());
                                desgloseMovimientos.lstCancelacion.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstCompra = new List<DesgloseMovimientos>();
                        if (ds.Tables[5] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[5].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folioPedido"].ToString();
                                reporte.FecVenta = Convert.ToDateTime(auxResultado["fecha"]).ToString("dd/MM/yyyy");
                                reporte.HorVenta = auxResultado["hora"].ToString();
                                reporte.pago = float.Parse(auxResultado["monto"].ToString());
                                reporte.Total = float.Parse(auxResultado["total"].ToString());
                                desgloseMovimientos.lstCompra.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstRetiro = new List<DesgloseMovimientos>();
                        if (ds.Tables[6] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[6].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.motivo = auxResultado["motivo"].ToString();
                                reporte.pago = float.Parse(auxResultado["monto"].ToString());
                                reporte.NombreVendedor = auxResultado["vendedor"].ToString();
                                desgloseMovimientos.lstRetiro.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstDeposito = new List<DesgloseMovimientos>();
                        if (ds.Tables[7] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[7].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.motivo = auxResultado["motivo"].ToString();
                                reporte.pago = float.Parse(auxResultado["monto"].ToString());
                                reporte.NombreVendedor = auxResultado["vendedor"].ToString();
                                desgloseMovimientos.lstDeposito.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstEfectivo = new List<DesgloseMovimientos>();
                        if (ds.Tables[8] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[8].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folio"].ToString();
                                reporte.monto = float.Parse(auxResultado["monto"].ToString());
                                reporte.NombreCliente = auxResultado["cliente"].ToString();
                                reporte.NombreCajero = auxResultado["cajero"].ToString();
                                desgloseMovimientos.lstEfectivo.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstTarjeta = new List<DesgloseMovimientos>();
                        if (ds.Tables[9] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[9].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folio"].ToString();
                                reporte.NombreCliente = auxResultado["cliente"].ToString();
                                reporte.NombreCajero = auxResultado["cajero"].ToString();
                                reporte.autorizacion = auxResultado["autorizacion"].ToString();
                                reporte.identificacion = auxResultado["identificacion"].ToString();
                                reporte.banco = auxResultado["banco"].ToString();
                                reporte.tipoTarjeta = auxResultado["tipoTarjeta"].ToString();
                                reporte.monto = float.Parse(auxResultado["monto"].ToString());
                                desgloseMovimientos.lstTarjeta.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstTransferencia = new List<DesgloseMovimientos>();
                        if (ds.Tables[10] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[10].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folio"].ToString();
                                reporte.NombreCliente = auxResultado["cliente"].ToString();
                                reporte.NombreCajero = auxResultado["cajero"].ToString();
                                reporte.autorizacion = auxResultado["autorizacion"].ToString();
                                reporte.banco = auxResultado["banco"].ToString();
                                reporte.monto = float.Parse(auxResultado["monto"].ToString());
                                desgloseMovimientos.lstTransferencia.Add(reporte);
                            }
                        }
                        desgloseMovimientos.lstMonedero = new List<DesgloseMovimientos>();
                        if (ds.Tables[11] != null)
                        {
                            foreach (DataRow auxResultado in ds.Tables[11].Rows)
                            {
                                reporte = new DesgloseMovimientos();
                                reporte.Folio = auxResultado["folio"].ToString();
                                reporte.monto = float.Parse(auxResultado["monto"].ToString());
                                reporte.NombreCliente = auxResultado["cliente"].ToString();
                                reporte.NombreCajero = auxResultado["cajero"].ToString();
                                desgloseMovimientos.lstMonedero.Add(reporte);
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
    }
}
