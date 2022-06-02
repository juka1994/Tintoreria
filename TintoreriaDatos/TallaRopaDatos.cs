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
    public class TallaRopaDatos
    {
        public void LLenarGridTallaRopa(TallaRopa TallaRopa)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(TallaRopa.conexion, "spCSLDB_CatTallaRopa_Consulta_sp");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            TallaRopa.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcTallaRopa(TallaRopa TallaRopa, ref int Verificador)
        {
            try
            {
                object[] Valores = { TallaRopa.opcion, TallaRopa.id_tallaRopa, TallaRopa.descripcion, TallaRopa.id_u };
                object res = SqlHelper.ExecuteScalar(TallaRopa.conexion, "spCSLDB_abc_CatTallaRopa", Valores);
                Verificador = Convert.ToInt32(res);
                if (Verificador > 0)
                    Verificador = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboTallaRopa(TallaRopa tallaRopa)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(tallaRopa.conexion, "spCSLDB_get_ComboCatTallaRopa");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            tallaRopa.datos = ds.Tables[0];
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
