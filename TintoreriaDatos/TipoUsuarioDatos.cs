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
    public class TipoUsuarioDatos
    {
        public void ObtenerComboTipoUsuario(TipoUsuario tipoUsuario)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(tipoUsuario.conexion, "spCSLDB_get_ComboCatTipoUsuario");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            tipoUsuario.datos = ds.Tables[0];
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
