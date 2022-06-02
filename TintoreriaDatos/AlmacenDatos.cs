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
    public class AlmacenDatos
    {
        public void AbcAlmacen(Almacen almacen, ref int Verificador)
        {
            try
            {
                //, @factorConversion DECIMAL(18,6)
                //, @observaciones NVARCHAR(MAX)
                object[] Valores = 
                {
                    almacen.opcion 
                    , almacen.id_producto
                    , almacen.id_sucursal
                    , Comun.id_u
                    , almacen.CantidadMovimiento
                    , almacen.UnidadMedidaMovimiento
                    , almacen.CantidadProducto
                    , almacen.UnidadMedidaProducto
                    , almacen.CantidadConvertida
                    , almacen.CantidadAlmacen
                    , almacen.FactorConversion
                    , almacen.observaciones
                };

                object res = SqlHelper.ExecuteScalar(almacen.conexion, "spCSLDB_set_CantidadStock", Valores);
                if (res != null)
                    Verificador = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridAlmacen(Almacen almacen)
        {
            try
            {
                object[] Valores = { almacen.id_sucursal,almacen.tipoBusqueda,almacen.busqueda};
                DataSet ds = SqlHelper.ExecuteDataset(almacen.conexion, "spCSLDB_CatAlmacen_Consulta2_sp",Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            almacen.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }         
        public void LLenarGridHistorial(Almacen almacen)
        {
            try
            {
                object[] Valores = {almacen.tipoBusqueda,almacen.busqueda};
                DataSet ds = SqlHelper.ExecuteDataset(almacen.conexion, "spCSLDB_CatHistorialMovimientos_Consulta2_sp",Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            almacen.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridHistorialImportados(Almacen almacen)
        {
            try
            {
                object[] Valores = { almacen.tipoBusqueda, almacen.busqueda };
                DataSet ds = SqlHelper.ExecuteDataset(almacen.conexion, "spCSLDB_CatHistorialMovimientosImportados_Consulta2_sp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            almacen.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ImportarExcel(Almacen almacen, ref int Verificador)
        {
           
                object res = SqlHelper.ExecuteScalar(almacen.conexion, CommandType.StoredProcedure, "spCSLDB_set_ImportarExcel",
                    new SqlParameter("@importarExcel", almacen.datos),
                    new SqlParameter("@usuario", almacen.id_u));
                if (res != null)
                    Verificador = 0;
          
        }

        public void LLenarGridStockBajo(Almacen almacen)
        {
                       
                DataSet ds = SqlHelper.ExecuteDataset(almacen.conexion, "spCSLDB_CatStockBajo_Consulta_sp", almacen.id_sucursal);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            almacen.datos = ds.Tables[0];
                        }
                    }
                }
            
        }
    }
}
