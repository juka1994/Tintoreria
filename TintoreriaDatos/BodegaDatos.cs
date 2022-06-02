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
    public class BodegaDatos
    {        
        public void LLenarGridBodega(Bodega bodega)
        {
            try
            {
                object[] Valores = { bodega.id_sucursal,bodega.busqueda};
                DataSet ds = SqlHelper.ExecuteDataset(bodega.conexion, "spCSLDB_CatBodega_Consulta_sp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            bodega.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridAplicarBodega(Bodega bodega)
        {
            try
            {
                object[] Valores = { bodega.id_proveedor, bodega.id_sucursal };
                DataSet ds = SqlHelper.ExecuteDataset(bodega.conexion, "spCSLDB_CatBodegaAplicar_Consulta_sp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            bodega.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridProductos(Bodega bodega)
        {
            try
            {
                object[] Valores = { bodega.id_proveedor, bodega.id_sucursal };
                DataSet ds = SqlHelper.ExecuteDataset(bodega.conexion, "spCSLDB_CatBodegaProductoXProvedor_Consulta_sp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            bodega.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcBodega(Bodega bodega, ref int Verificador)
        {
            try
            {
                object[] Valores = { bodega.opcion, bodega.cantidad, bodega.id_producto, bodega.id_sucursal, bodega.id_tallaRopa, bodega.id_colorRopa, bodega.id_u };
                object res = SqlHelper.ExecuteScalar(bodega.conexion, "spCSLDB_set_CantidadBodega", Valores);
                if (res != null)
                    Verificador = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ReporteBodega> LLenarGridProductosReporte(Bodega bodega)
        {
            try
            {
                List<ReporteBodega> reporte_bodega = new List<ReporteBodega>();
                ReporteBodega reporte;
                object[] Valores = { bodega.id_proveedor, bodega.id_sucursal };
                SqlDataReader SqlDr = SqlHelper.ExecuteReader(bodega.conexion, "spCSLDB_CatBodegaProductoXProvedorReporte_Consulta_sp", Valores);
                while (SqlDr.Read())
                {
                    reporte = new ReporteBodega();
                    reporte.proveedor = SqlDr.GetString(SqlDr.GetOrdinal("proveedor"));
                    reporte.codigoBarra = SqlDr.GetString(SqlDr.GetOrdinal("id_codigoEan"));
                    reporte.producto = SqlDr.GetString(SqlDr.GetOrdinal("nombreProducto"));
                    reporte.cantidad = SqlDr.GetInt32(SqlDr.GetOrdinal("cantidad"));
                    reporte_bodega.Add(reporte);
                }
                return reporte_bodega;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
