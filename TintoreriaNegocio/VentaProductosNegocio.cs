using System;
using System.Collections.Generic;
using TintoreriaDatos;
using TintoreriaGlobal;

namespace TintoreriaNegocio
{
    public class VentaProductosNegocio
    {
        public void LLenarGridBusquedaFolio(VentaProductos ventaProductos)
        {
            try
            {
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.LLenarGridBusquedaFolio(ventaProductos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RespuestaSQL ActualizarFechaEntrega(VentaProductos fechActualizar)
        {

            VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
            return ventaProductosDatos.ActualizarFechaVenta(fechActualizar);

        }

        public void LLenarGridBusquedaFolioNombre(VentaProductos ventaProductos)
        {

            VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
            ventaProductosDatos.LLenarGridBusquedaFolioNombre(ventaProductos);

        }

        public void ActualizarVentaTemporal(VentaProductos ventaActualizar)
        {
            try
            {
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.ActualizarVentaTemporal(ventaActualizar);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.AgregarProductoVentaTmp(venta);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.ConsultaProductos(ventaProductos);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.InsertarVentaPendiente(datos);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.InsertarPedidoPendiente(datos);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.liberarVentasNoGuardadas(datos);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                return ventaProductosDatos.LlenaComboFamilia(datos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<VentaProductos> ObtenerDetalleVentaPendiente(VentaProductos datos)
        {
            try
            {
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                return ventaProductosDatos.ObtenerDetalleVentaPendiente(datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ProductoDetalle obtenerExistenciaProducto(ProductoDetalle datosProd)
        {
            try
            {
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                return ventaProductosDatos.obtenerExistenciaProducto(datosProd);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                return ventaProductosDatos.ObtenerVentasPendientes(datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Producto ObtenerProductoXIDEanCode(VentaProductos producto)
        {
            try
            {
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                return ventaProductosDatos.ObtenerProductoXIDEanCode(producto);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.EliminarProductoVentaTmp(venta);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.InsertarProductos(ref Verificador, ref ventaProductos, ref ListaProductos, cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertarPrendasTintoreria(ref int Verificador, ref VentaTintoreria ventag)
        {

            VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
            ventaProductosDatos.InsertarPrendasTintoreria(ref Verificador, ref ventag);

        }

        public void AgregarPagoAVenta(ref int Verificador, ref VentaTintoreria ventag)
        {

            VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
            ventaProductosDatos.AgregarPagoAVenta(ref Verificador, ref ventag);

        }


        public Producto obtenerExistenciaProducto(Producto datosProd)
        {
            try
            {
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                return ventaProductosDatos.obtenerExistenciaProducto(datosProd);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.insertarProductoGenerico2(prodGen);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.insertarProductoGenerico(prodGen);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                return ventaProductosDatos.liberarVentaTab(datos);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.CambiarPrecioMayoreo(venta);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                return ventaProductosDatos.obtenerDatosVenta(datos);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                return ventaProductosDatos.ObtenerVentaDetalle(datos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void LLenarGridVentas(VentaProductos ventaProductos)
        {
            try
            {
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.LLenarGridVentas(ventaProductos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridVentaDetalle(VentaProductos ventaProductos)
        {
            try
            {
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.LLenarGridVentaDetalle(ventaProductos);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.InsertarProductosPedidos2(ref Verificador, ref ventaProductos, cliente);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.InsertarProductosPedidos(ref Verificador, ref ventaProductos, cliente);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.ObtenerComboTipoVenta(ventaProductos);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.ObtenerNuevaCancelacion(ventaProductos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridCancelacionDetalle(VentaProductos ventaProductos)
        {
            try
            {
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.LLenarGridCancelacionDetalle(ventaProductos);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.CancelarVenta(ventaProductos, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridCancelacion(VentaProductos ventaProductos)
        {
            try
            {
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.LLenarGridCancelacion(ventaProductos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridPedido(VentaProductos ventaProductos)
        {
            try
            {
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.LLenarGridPedido(ventaProductos);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.LLenarGridPedidoPago(venta);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.InsertarPagosPedido(ref Verificador, ref ventaProductos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridHome(int tabIndex, VentaProductos ventaProductos)
        {
            try
            {
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.LLenarGridHome(tabIndex, ventaProductos);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.ObtenerDetalleApartado(ventaProductos);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.ModificarProductosPedidos(ref Verificador, ref ventaProductos, cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridProductosXEntregar(VentaProductos ventaProductos)
        {
            try
            {
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.LLenarGridProductosXEntregar(ventaProductos);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.EntregarProductos(ventaProductos, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridBusquedaVenta(VentaProductos ventaProductos)
        {
            try
            {
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.LLenarGridBusquedaVenta(ventaProductos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridCambioDetalle(VentaProductos ventaProductos)
        {
            try
            {
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.LLenarGridCambioDetalle(ventaProductos);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.InsertarProductosCambios(ref Verificador, ref ventaProductos, cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridCambio(VentaProductos ventaProductos)
        {
            try
            {
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.LLenarGridCambio(ventaProductos);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                return ventaProductosDatos.obtenerDatosCancelacion(datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridPedidoApp(VentaProductos ventaProductos)
        {
            try
            {
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.LLenarGridPedidoApp(ventaProductos);
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
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                return ventaProductosDatos.ObtenerDetallePedidoApp(ventaProductos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridPedidoPagadosApp(VentaProductos ventaProductos)
        {
            try
            {
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.LLenarGridPedidoPagadosApp(ventaProductos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ActualizarPedidoListo(VentaProductos ventaProductos)
        {
            try
            {
                VentaProductosDatos ventaProductosDatos = new VentaProductosDatos();
                ventaProductosDatos.ActualizarPedidoListo(ventaProductos);
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
                VentaProductosDatos _ventaDatos = new VentaProductosDatos();
                _ventaDatos.CancelacionVenta(_venta, ref verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
