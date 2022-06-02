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
    public class TipoSucursalDatos
    {       
        public TipoSucursal ObtenerComboTipoSucursal(TipoSucursal tipoSucursal)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(tipoSucursal.conexion, "spCSLDB_get_ComboCatTipoSucursal",tipoSucursal.opcion);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            tipoSucursal.datos = ds.Tables[0];
                        }
                    }
                }
                return tipoSucursal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
