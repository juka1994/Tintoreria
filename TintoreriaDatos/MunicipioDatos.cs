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
    public class MunicipioDatos
    {
        public void ObtenerComboMunicipio(Municipio municipio)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(municipio.conexion, "spCSLDB_get_ComboCatMunicipio", municipio.id_pais, municipio.id_estado);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            municipio.datos = ds.Tables[0];
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
