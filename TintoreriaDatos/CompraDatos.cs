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
    public class CompraDatos : HelperSQL
    {        
        public void AbcCompra(Compra compra, ref int Verificador)
        {
            try
            {                                
                object res = SqlHelper.ExecuteScalar(compra.conexion,CommandType.StoredProcedure, "spCSLDB_abc_CatCompras", 
                    new SqlParameter("@opcion",compra.opcion),
                    new SqlParameter("@id_compra", compra.id_compra),
                    new SqlParameter("@id_statusCompra", compra.id_statusCompra),
                    new SqlParameter("@id_sucursal", compra.id_sucursal),
                    new SqlParameter("@id_proveedor",compra.id_proveedor),
                    new SqlParameter("@id_caja", compra.id_caja),
                    new SqlParameter("@fechaPedido", compra.fechaPedido),
                    new SqlParameter("@horaPedido", compra.horaPedido),
                    new SqlParameter("@monto", compra.monto),
                    new SqlParameter("@observaciones", compra.observaciones),
                    new SqlParameter("@compraDetalle", compra.compraDetalle.datos),
                    new SqlParameter("@usuario", compra.id_u));
                if (res != null)
                    Verificador = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GuardarDetalleLavado(ref int verificador, string user, DataTable dt,string sucursal,int opcion,string id_lavado)
        {
            try
            {                
                object res = SqlHelper.ExecuteScalar(ConexionSQL,CommandType.StoredProcedure, "[Cat].[spCSLDB_A_DetalleLavado]",
                       new SqlParameter("@tabla", dt),
                       new SqlParameter("@user", user),
                       new SqlParameter("@sucursal", sucursal),
                       new SqlParameter("@opcion", opcion),
                       new SqlParameter("@id_lavado",id_lavado));
                if (res != null)
                {
                    int.TryParse(res.ToString(), out int x);
                    if (x.Equals(0))
                    {
                        verificador = -1;
                    }
                    else if(x.Equals(-1))
                    {
                        verificador = -2;
                    }
                    else
                    {
                        verificador = 0;
                    }
                }
                             
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
                object[] Valores = {tabIndex,compra.tipoBusqueda,compra.id_sucursal,compra.busqueda,compra.fechaPedido};
                DataSet ds = SqlHelper.ExecuteDataset(compra.conexion, "spCSLDB_CatCompras_Consulta_sp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            compra.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string ObtenerFolioPedido(string conexion,string id_sucursal)
        {
            try
            {
                string res = SqlHelper.ExecuteScalar(conexion, "spCSLDB_FolioPedido_Consulta_sp",id_sucursal).ToString();
                if (res != null)
                {
                    return res;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void llenarGridCompraDetalle(Compra compra)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(compra.conexion, "CompraGetGeneralesProductoSolicitar", compra.id_producto);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            compra.datos = ds.Tables[0];                             
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerDetalleCompra(CompraDetalle compraDetalle)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(compraDetalle.conexion, "spCSLDB_CatCompraDetalleXID_Consulta_sp", compraDetalle.id_compra);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            compraDetalle.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerDetalleCompraCorreo(CompraDetalle compraDetalle)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(compraDetalle.conexion, "spCSLDB_CatCompraDetalleCorreoXID_Consulta_sp", compraDetalle.id_compra);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            compraDetalle.datos = ds.Tables[0];
                        }
                    }
                }
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
                DataSet ds = SqlHelper.ExecuteDataset(compra.conexion, "spCSLDB_get_correoProveedor", compra.id_proveedor);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            if(ds.Tables[0].Rows.Count==1)
                            {
                               compra.correoProveedor = ds.Tables[0].Rows[0][0].ToString();
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
        public void LLenarGridCompraApp(Compra compra)
        {
            try
            {                
                DataSet ds = SqlHelper.ExecuteDataset(compra.conexion, "spCSLDB_CatComprasApp_Consulta_sp", compra.id_sucursal);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            compra.datos = ds.Tables[0];
                        }
                    }
                }
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
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "[Cat].[spCSLDB_get_LavadoDetalle]");
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
    }
}
