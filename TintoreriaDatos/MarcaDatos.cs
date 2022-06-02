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
    public class MarcaDatos
    {
        public void LLenarGridMarca(Marca marca)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(marca.conexion, "spCSLDB_CatMarca_Consulta_sp");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            marca.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcMarca(Marca marca, ref int Verificador)
        {
            try
            {
                object[] Valores = { marca.opcion, marca.id_marca, marca.descripcion, marca.id_u };
                object res = SqlHelper.ExecuteScalar(marca.conexion, "spCSLDB_abc_CatMarca", Valores);
                Verificador = Convert.ToInt32(res);
                if (Verificador > 0)
                    Verificador = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboMarca(Marca marca)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(marca.conexion, "spCSLDB_get_ComboCatMarca");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            marca.datos = ds.Tables[0];
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
