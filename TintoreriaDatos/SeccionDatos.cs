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
    public class SeccionDatos
    {
        public void LLenarGridSeccion(Seccion seccion)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(seccion.conexion, "spCSLDB_CatSeccion_Consulta_sp");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            seccion.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcSeccion(Seccion seccion, ref int Verificador)
        {
            try
            {
                object[] Valores = { seccion.opcion, seccion.id_seccion, seccion.descripcion, seccion.id_u };
                object res = SqlHelper.ExecuteScalar(seccion.conexion, "spCSLDB_abc_CatSeccion", Valores);
                Verificador = Convert.ToInt32(res);
                if (Verificador > 0)
                    Verificador = 0;
                else
                    Verificador = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboSeccion(Seccion seccion)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(seccion.conexion, "spCSLDB_get_ComboCatSeccion");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            seccion.datos = ds.Tables[0];
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
