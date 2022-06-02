using TintoreriaGlobal;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaDatos
{
    public class ProductoDatos : HelperSQL
    {
        public string ObtenerImagen(ProductoDetalle producto)
        {
           
                string imagen = string.Empty;

                SqlDataReader dr = SqlHelper.ExecuteReader(producto.conexion, "spCSLDB_CatProductoObtenerImagen", producto.id_producto);
                while (dr.Read())
                {
                    imagen = dr.GetString(dr.GetOrdinal("imagen"));
                }
                return imagen;
           
        }
        public void LLenarGridProducto(Producto producto)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(producto.conexion, "spCSLDB_CatProducto_Consulta2_sp", producto.tipoBusqueda, producto.busqueda);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            producto.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridProductoSinImagen(Producto producto)
        {
            
                DataSet ds = SqlHelper.ExecuteDataset(producto.conexion, "spCSLDB_CatProducto_Consulta3_sp", producto.tipoBusqueda, producto.busqueda);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            producto.datos = ds.Tables[0];
                        }
                    }
                }
          
        }
        public void AbcProductoGeneral2(Producto producto, ref int Verificador)
        {
            
                object[] Valores = { producto.opcion, producto.id_producto, producto.nombreProducto, producto.productoDetalle.costoUltimo, producto.productoDetalle.precio, producto.productoDetalle.precioMayoreo,
                                    producto.fechaIngreso, producto.cantidadMayoreo, producto.inventarioOptimo, producto.imagen, producto.productoDetalle.id_codigoEan, producto.id_proveedor, producto.id_familia,
                                    producto.id_unidadMedida, producto.ventaDirecta, producto.aplicaInventario, producto.observaciones, producto.id_tipoProducto, producto.diasInventario, producto.EsAccesorio,
                                    producto.EsHombre, producto.EsMujer, producto.id_u };
                object res = SqlHelper.ExecuteScalar(producto.conexion, "spCSLDB_abc_CatProducto2", Valores);
            if (res != null)
            {
                producto.id_producto = res.ToString();
                Verificador = 0;
            }
            else
                Verificador = 1;
           
        }
        public void AbcProductoGeneral(Producto producto, ref int Verificador)
        {
            try
            {
                object[] Valores = { producto.opcion, producto.id_producto, producto.nombreProducto, producto.productoDetalle.costoUltimo, producto.productoDetalle.precio, producto.productoDetalle.precioMayoreo, 
                                    producto.fechaIngreso, producto.cantidadMayoreo, producto.inventarioOptimo, producto.imagen, producto.productoDetalle.id_codigoEan, producto.id_proveedor, producto.id_familia,
                                    producto.id_unidadMedida, producto.ventaDirecta, producto.aplicaInventario, producto.observaciones, producto.id_tipoProducto, producto.diasInventario, producto.EsAccesorio,
                                    producto.EsHombre, producto.EsMujer, producto.id_u };
                object res = SqlHelper.ExecuteScalar(producto.conexion, "spCSLDB_abc_CatProducto", Valores);
                if (res != null)
                {
                    producto.id_producto = res.ToString();
                    Verificador = 0;
                }
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
                SqlDataReader dr = SqlHelper.ExecuteReader(producto_detalle.conexion, "spCSLDB_CatProductoDetalleGeneralXID_Consulta_sp", producto_detalle.id_producto);
                while (dr.Read())
                {
                    producto_detalle.id_codigoEan = dr.GetString(dr.GetOrdinal("id_codigoEan"));
                    producto_detalle.interno = dr.GetBoolean(dr.GetOrdinal("interno"));
                    producto_detalle.costoUltimo = (float)dr.GetDecimal(dr.GetOrdinal("costoUltimo"));
                    producto_detalle.precio = dr.GetDecimal(dr.GetOrdinal("precio"));
                    producto_detalle.precioMayoreo = (float)dr.GetDecimal(dr.GetOrdinal("precioMayoreo"));
                }
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
                List<Ean13Images> lista = new List<Ean13Images>();
                Ean13Images Item;
                SqlDataReader dr = SqlHelper.ExecuteReader(Ean13.conexion, "spCSLDB_CatProductoCodBarXID_Consulta_sp", Ean13.id_producto);
                while (dr.Read())
                {
                    Item = new Ean13Images();
                    Item.id_ean13 = dr.GetString(dr.GetOrdinal("id_codigoEan"));
                    lista.Add(Item);
                }
                return lista;
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
                DataSet ds = SqlHelper.ExecuteDataset(producto_detalle.conexion, "spCSLDB_CatProductoDetalleRopaXID_Consulta_sp", producto_detalle.id_producto);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            producto_detalle.datos = ds.Tables[0];
                        }
                    }
                }
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
                object res = SqlHelper.ExecuteScalar(producto.conexion, CommandType.StoredProcedure, "spCSLDB_abc_CatProductoRopa2",
                new SqlParameter("@opcion", producto.opcion),
                new SqlParameter("@id_producto", producto.id_producto),
                new SqlParameter("@nombreProducto", producto.nombreProducto),
                new SqlParameter("@fechaIngreso", producto.fechaIngreso),
                new SqlParameter("@cantidadMayoreo", producto.cantidadMayoreo),
                new SqlParameter("@inventarioOptimo", producto.inventarioOptimo),
                new SqlParameter("@imagen", producto.imagen),
                new SqlParameter("@id_proveedor", producto.id_proveedor),
                new SqlParameter("@id_familia", producto.id_familia),
                new SqlParameter("@id_unidadMedida", producto.id_unidadMedida),
                new SqlParameter("@id_marca", producto.id_marca),
                new SqlParameter("@id_material", producto.id_material),
                new SqlParameter("@productoDetalleDatos", producto.productoDetalle.datos),
                new SqlParameter("@ventaDirecta", producto.ventaDirecta),
                new SqlParameter("@aplicaInventario", producto.aplicaInventario),
                new SqlParameter("@observaciones", producto.observaciones),
                new SqlParameter("@id_tipoProducto", producto.id_tipoProducto),
                new SqlParameter("@diasInventario", producto.diasInventario),
                new SqlParameter("@EsHombre", producto.EsHombre),
                new SqlParameter("@EsMujer", producto.EsMujer),
                new SqlParameter("@usuario", producto.id_u)
                );
                if (res != null)
                {
                    producto.id_producto = res.ToString();
                    Verificador = 0;
                }
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
                object res = SqlHelper.ExecuteScalar(producto.conexion, CommandType.StoredProcedure, "spCSLDB_abc_CatProductoRopa",
                new SqlParameter("@opcion", producto.opcion),
                new SqlParameter("@id_producto", producto.id_producto),
                new SqlParameter("@nombreProducto", producto.nombreProducto),
                new SqlParameter("@fechaIngreso", producto.fechaIngreso),
                new SqlParameter("@cantidadMayoreo", producto.cantidadMayoreo),
                new SqlParameter("@inventarioOptimo", producto.inventarioOptimo),
                new SqlParameter("@imagen", producto.imagen),
                new SqlParameter("@id_proveedor", producto.id_proveedor),
                new SqlParameter("@id_familia", producto.id_familia),
                new SqlParameter("@id_unidadMedida", producto.id_unidadMedida),
                new SqlParameter("@id_marca", producto.id_marca),
                new SqlParameter("@id_material", producto.id_material),
                new SqlParameter("@productoDetalleDatos", producto.productoDetalle.datos),
                new SqlParameter("@ventaDirecta", producto.ventaDirecta),
                new SqlParameter("@aplicaInventario", producto.aplicaInventario),
                new SqlParameter("@observaciones", producto.observaciones),
                new SqlParameter("@id_tipoProducto", producto.id_tipoProducto),
                new SqlParameter("@diasInventario", producto.diasInventario),
                new SqlParameter("@EsHombre", producto.EsHombre),
                new SqlParameter("@EsMujer", producto.EsMujer),
                new SqlParameter("@usuario", producto.id_u)
                );
                if (res != null)
                {
                    producto.id_producto = res.ToString();
                    Verificador = 0;
                }
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
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "spCSLDB_get_ComboCatProductosRopa");
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
                return dt;
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
                DataSet ds = SqlHelper.ExecuteDataset(producto.conexion, "spCSLDB_get_ComboCatProductos");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            producto.datos = ds.Tables[0];
                        }
                    }
                }
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
                DataSet ds = SqlHelper.ExecuteDataset(producto.conexion, "spCSLDB_get_ComboCatProductosXSucursal", producto.productoDetalle.id_sucursal);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            producto.datos = ds.Tables[0];
                        }
                    }
                }
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
                DataSet ds = SqlHelper.ExecuteDataset(producto.conexion, "spCSLDB_get_ComboCatProductosCompras", id_sucursal, id_proveedor);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            producto.datos = ds.Tables[0];
                        }
                    }
                }
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
                SqlDataReader dr = null;
                Producto item;
                List<Producto> lista = new List<Producto>();
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_consultarProductosActualizarImagen2");
                while (dr.Read())
                {
                    item = new Producto();
                    if (Convert.IsDBNull(dr.GetValue(dr.GetOrdinal("id_producto"))))
                        item.id_producto = string.Empty;
                    else
                        item.id_producto = dr.GetString(dr.GetOrdinal("id_producto"));
                    if (Convert.IsDBNull(dr.GetValue(dr.GetOrdinal("imagen"))))
                        item.imagen = "";
                    else
                        item.imagen = dr.GetString(dr.GetOrdinal("imagen"));
                    lista.Add(item);
                }
                return lista;
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
                SqlDataReader dr = null;
                Producto item;
                List<Producto> lista = new List<Producto>();
                dr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_consultarProductosActualizarImagen");
                while (dr.Read())
                {
                    item = new Producto();
                    if (Convert.IsDBNull(dr.GetValue(dr.GetOrdinal("id_producto"))))
                        item.id_producto = string.Empty;
                    else
                        item.id_producto = dr.GetString(dr.GetOrdinal("id_producto"));
                    if (Convert.IsDBNull(dr.GetValue(dr.GetOrdinal("imagen"))))
                        item.imagen = "";
                    else
                        item.imagen = dr.GetString(dr.GetOrdinal("imagen"));
                    lista.Add(item);
                }
                return lista;
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
                DataSet ds = SqlHelper.ExecuteDataset(producto.conexion, "spCSLDB_get_ComboCambioProducto", producto.id_producto);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            producto.datos = ds.Tables[0];
                        }
                    }
                }
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
                object[] Valores = { productoDetalle.id_sucursal, productoDetalle.id_producto, productoDetalle.id_tallaRopa, productoDetalle.id_colorRopa };
                DataSet ds = SqlHelper.ExecuteDataset(productoDetalle.conexion, "spCSLDB_set_ChecarExistenciaXID", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            if (ds.Tables[0].Rows.Count == 1)
                            {
                                productoDetalle.existencia = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
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

        public DataTable CargarDatosCompraDetalle(string id)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "[Cat].[spCSLDB_get_DetalleLavado]", id);
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
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable GetComboProductosLavado()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "[Cat].[spCSLDB_get_ComboProducto]");
                DataTable dt = new DataTable();
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            dt= ds.Tables[0];
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
