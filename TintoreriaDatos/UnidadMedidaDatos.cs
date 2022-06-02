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
    public class UnidadMedidaDatos : HelperSQL
    {
        public void LLenarGridUnidadMedida(UnidadMedida unidadMedida)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(unidadMedida.conexion, "spCSLDB_CatUnidadMedida_Consulta_sp");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            unidadMedida.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcUnidadMedida(UnidadMedida unidadMedida, ref int Verificador)
        {
            try
            {
                object[] Valores = { unidadMedida.opcion, unidadMedida.id_unidadMedida, unidadMedida.descripcion, unidadMedida.id_u };
                object res = SqlHelper.ExecuteScalar(unidadMedida.conexion, "spCSLDB_abc_CatUnidadMedida", Valores);
                Verificador = Convert.ToInt32(res);
                if (Verificador > 0)
                    Verificador = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboUnidadMedida(UnidadMedida unidadmedida)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(unidadmedida.conexion, "spCSLDB_get_ComboCatUnidadMedida");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            unidadmedida.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetComboUnidadMedidaXIdProducto(string idProducto)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "dbo.UnidadMedidaGetComboXIdProducto", idProducto);
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
