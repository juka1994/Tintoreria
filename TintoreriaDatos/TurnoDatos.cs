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
    public class TurnoDatos
    {
        public void ObtenerComboTurno(Turno turno)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(turno.conexion, "spCSLDB_get_ComboCatTurno");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            turno.datos = ds.Tables[0];
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
