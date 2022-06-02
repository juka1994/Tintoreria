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
    public class MaterialDatos
    {
        public void LLenarGridMaterial(Material material)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(material.conexion, "spCSLDB_CatMaterial_Consulta_sp");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            material.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcMaterial(Material material, ref int Verificador)
        {
            try
            {
                object[] Valores = { material.opcion, material.id_material, material.descripcion, material.id_u };
                object res = SqlHelper.ExecuteScalar(material.conexion, "spCSLDB_abc_CatMaterial", Valores);
                Verificador = Convert.ToInt32(res);
                if (Verificador > 0)
                    Verificador = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboMaterial(Material material)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(material.conexion, "spCSLDB_get_ComboCatMaterial");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            material.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
