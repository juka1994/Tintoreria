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
    public class OcupacionDatos
    {
        public void ObtenerComboOcupacion(Ocupacion ocupacion)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ocupacion.conexion, "spCSLDB_get_ComboCatOcupacion");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            ocupacion.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LLenarGridOcupacion(Ocupacion ocupacion)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ocupacion.conexion, "spCSLDB_CatOcupacion_Consulta_sp");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            ocupacion.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcOcupacion(Ocupacion ocupacion, ref int Verificador)
        {
            try
            {
                object[] Valores = { ocupacion.opcion, ocupacion.id_ocupacion, ocupacion.descripcion, ocupacion.id_u };
                object res = SqlHelper.ExecuteScalar(ocupacion.conexion, "spCSLDB_abc_CatOcupacion", Valores);
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
