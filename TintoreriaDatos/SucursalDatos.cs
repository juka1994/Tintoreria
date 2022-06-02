using TintoreriaGlobal;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaDatos
{
    public class SucursalDatos
    {
        public void ObtenerComboSucursal(Sucursal sucursal)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sucursal.conexion, "spCSLDB_get_ComboCatSucursal");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            sucursal.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboSucursal2(Sucursal sucursal)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sucursal.conexion, "spCSLDB_get_ComboCatSucursal2");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            sucursal.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridSucursal(Sucursal sucursal)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(sucursal.conexion, "spCSLDB_CatSucursal_Consulta_sp");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            sucursal.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcSucursal(Sucursal sucursal, ref int Verificador)
        {
            try
            {
                object[] Valores = { sucursal.opcion, sucursal.id_sucursal, sucursal.id_tipoSucursal,sucursal.nombre,sucursal.direccion,sucursal.telefono,sucursal.codigoPostal,
                                       sucursal.id_pais,sucursal.id_estado,sucursal.id_municipio,sucursal.id_iva, sucursal.id_u };
                object res = SqlHelper.ExecuteScalar(sucursal.conexion, "spCSLDB_abc_CatSucursal", Valores);

                if (res.ToString() != "1")
                    Verificador = 0;
                else
                    Verificador = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ContarSucursales(string conexion)
        {
            try
            {
                object res = SqlHelper.ExecuteScalar(conexion, "spCSLDB_obtenerTotalSucursales");
                int total = Convert.ToInt32(res.ToString());
                if (total != 0)
                    return total;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public decimal ObtenerIvaSucursal(string conexion, string idsucursal)
        {
           
              object res = SqlHelper.ExecuteScalar(conexion, "spCSLDB_obtenerIvaSucursalesDU", idsucursal);
             decimal total = Convert.ToDecimal(res.ToString());
            if (total > 0)
                return total;
            else
                return 0;
            
        }
    }
}
