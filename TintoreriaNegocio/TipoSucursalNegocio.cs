using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class TipoSucursalNegocio
    {        
        public TipoSucursal ObtenerComboTipoSucursal(TipoSucursal tipoSucursal)
        {
            try
            {
               TipoSucursalDatos tipoSucursal_datos = new TipoSucursalDatos();
               return tipoSucursal_datos.ObtenerComboTipoSucursal(tipoSucursal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
