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
    public class IvaDatos
    {
        public void ObtenerComboIva(Iva iva)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(iva.conexion, "spCSLDB_get_ComboCatIva");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            iva.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridIva(Iva iva)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(iva.conexion, "spCSLDB_CatIva_Consulta_sp");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            iva.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcIva(Iva iva, ref int Verificador)
        {
            try
            {
                object[] Valores = { iva.opcion, iva.id_iva, iva.iva, iva.id_u };
                object res = SqlHelper.ExecuteScalar(iva.conexion, "spCSLDB_abc_CatIva", Valores);
                Verificador = Convert.ToInt32(res);
                if (Verificador > 0)
                    Verificador = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }    
}
