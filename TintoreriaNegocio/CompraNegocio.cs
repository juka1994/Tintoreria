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
    public class CompraNegocio
    {
        public void AbcCompra(Compra compra, ref int Verificador)
        {
            try
            {
                CompraDatos compra_datos = new CompraDatos();
                compra_datos.AbcCompra(compra, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridCompra(Compra compra,int tabIndex)
        {
            try
            {
                CompraDatos compra_datos = new CompraDatos();
                compra_datos.LLenarGridCompra(compra,tabIndex);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ObtenerFolioPedido(string conexion, string id_sucursal)
        {
            try
            {
                CompraDatos compra_datos = new CompraDatos();
                return compra_datos.ObtenerFolioPedido(conexion, id_sucursal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridCompraDetalle(Compra compra)
        {
            try
            {
                CompraDatos compra_datos = new CompraDatos();
                compra_datos.llenarGridCompraDetalle(compra);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerDetalleCompra(CompraDetalle CompraDetalle)
        {
            try
            {
                CompraDatos compra_datos = new CompraDatos();
                compra_datos.ObtenerDetalleCompra(CompraDetalle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerDetalleCompraCorreo(CompraDetalle compra_detalle)
        {
            try
            {
                CompraDatos compra_datos = new CompraDatos();
                compra_datos.ObtenerDetalleCompraCorreo(compra_detalle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerCorreoProveedor(Compra compra)
        {
            try
            {
                CompraDatos compra_datos = new CompraDatos();
                compra_datos.ObtenerCorreoProveedor(compra);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridCompraApp(Compra compra)
        {
            try
            {
                CompraDatos compra_datos = new CompraDatos();
                compra_datos.LLenarGridCompraApp(compra);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region DEtalle lavado
        public void GuardarDetalleLavado(ref int verf, string id_user, DataTable dt, string sucursal, int opcion, string id_lavado)
        {
            try
            {
                CompraDatos _cDatos = new CompraDatos();
                _cDatos.GuardarDetalleLavado(ref verf, id_user,dt,sucursal,opcion,id_lavado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable CargarDatosGrid()
        {
            try
            {
                CompraDatos _cDatos = new CompraDatos();
               return _cDatos.CargarDatosGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
