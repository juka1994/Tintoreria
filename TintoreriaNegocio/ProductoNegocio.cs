using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TintoreriaNegocio
{
    public class ProductoNegocio
    {
        public string ObtenerImagen(ProductoDetalle producto)
        {
            try
            {
                ProductoDatos productos_datos = new ProductoDatos();
                return productos_datos.ObtenerImagen(producto);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void LLenarGridProducto(Producto producto)
        {
            
                ProductoDatos producto_datos = new ProductoDatos();
                producto_datos.LLenarGridProducto(producto);
           
        }
        public void LLenarGridProductoSinImagen(Producto producto)
        {
           
                ProductoDatos producto_datos = new ProductoDatos();
                producto_datos.LLenarGridProductoSinImagen(producto);
           
        }

      

        public void AbcProductoGeneral2(Producto producto, ref int Verificador)
        {
           
                ProductoDatos producto_datos = new ProductoDatos();
                producto_datos.AbcProductoGeneral2(producto, ref Verificador);
          
        }
        public void AbcProductoGeneral(Producto producto, ref int Verificador)
        {
            try
            {
                ProductoDatos producto_datos = new ProductoDatos();
                producto_datos.AbcProductoGeneral(producto, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerDetalleProductoGeneral(ProductoDetalle producto_detalle)
        {
            try
            {
                ProductoDatos producto_datos = new ProductoDatos();
                producto_datos.ObtenerDetalleProductoGeneral(producto_detalle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Ean13Images> ObtenerCodigoBarraProducto(Producto Ean13)
        {
            try
            {
                ProductoDatos producto_datos = new ProductoDatos();
                return producto_datos.ObtenerCodigoBarraProducto(Ean13);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerDetalleProductoRopa(ProductoDetalle producto_detalle)
        {
            try
            {
                ProductoDatos producto_datos = new ProductoDatos();
                producto_datos.ObtenerDetalleProductoRopa(producto_detalle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcProductoRopa2(Producto producto, ref int Verificador)
        {
            try
            {
                ProductoDatos producto_datos = new ProductoDatos();
                producto_datos.AbcProductoRopa2(producto, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcProductoRopa(Producto producto, ref int Verificador)
        {
            try
            {
                ProductoDatos producto_datos = new ProductoDatos();
                producto_datos.AbcProductoRopa(producto, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }     
        public void ObtenerComboProductos(Producto producto)
        {
            try
            {
                ProductoDatos producto_datos = new ProductoDatos();
                producto_datos.ObtenerComboProductos(producto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ObtenerComboProductosRopa()
        {
            try
            {
                ProductoDatos producto_datos = new ProductoDatos();
                return  producto_datos.ObtenerComboProductosRopa();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
  
        public void ObtenerComboProductosXSucursal(Producto producto)
        {
            try
            {
                ProductoDatos producto_datos = new ProductoDatos();
                producto_datos.ObtenerComboProductosXSucursal(producto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboProductosCompras(Producto producto, string id_sucursal, string id_proveedor)
        {
            try
            {
                ProductoDatos producto_datos = new ProductoDatos();
                producto_datos.ObtenerComboProductosCompras(producto, id_sucursal, id_proveedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Producto> ObtenerImagenProductosActualizar2(Producto datos)
        {
            try
            {
                ProductoDatos producto_datos = new ProductoDatos();
                return producto_datos.ObtenerImagenProductosActualizar2(datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Producto> ObtenerImagenProductosActualizar(Producto datos)
        {
            try
            {
                ProductoDatos producto_datos = new ProductoDatos();
                return producto_datos.ObtenerImagenProductosActualizar(datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboCambioProducto(Producto producto)
        {
            try
            {
                ProductoDatos producto_datos = new ProductoDatos();
                producto_datos.ObtenerComboCambioProducto(producto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ChecarExistencia(ProductoDetalle productoDetalle)
        {
            try
            {
                ProductoDatos productoDatos = new ProductoDatos();
                productoDatos.ChecarExistencia(productoDetalle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Detalle Lavado
        public DataTable GetComboProductosLavado()
        {
            try
            {
                ProductoDatos PDatos = new ProductoDatos();
                return PDatos.GetComboProductosLavado();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CargarDatosCompraDetalle(string id_lavado)
        {
            try
            {
                ProductoDatos _pDatos = new ProductoDatos();
                return _pDatos.CargarDatosCompraDetalle(id_lavado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
