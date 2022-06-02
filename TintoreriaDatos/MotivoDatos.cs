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
    public class MotivoDatos
    {
        public void LLenarGridMotivo(Motivo motivo)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(motivo.conexion, "spCSLDB_CatMotivo_Consulta_sp");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            motivo.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcMotivo(Motivo motivo, ref int Verificador)
        {
            try
            {
                object[] Valores = { motivo.opcion, motivo.id_motivo, motivo.motivo, motivo.id_u };
                object res = SqlHelper.ExecuteScalar(motivo.conexion, "spCSLDB_abc_CatMotivo", Valores);
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
        public void ObtenerComboMotivo(Motivo motivo)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(motivo.conexion, "spCSLDB_get_ComboCatMotivo");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            motivo.datos = ds.Tables[0];
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
