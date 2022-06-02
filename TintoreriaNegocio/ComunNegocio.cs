using TintoreriaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class ComunNegocio
    {
        public void ObtenerCatalogosTintoreria()
        {
            try
            {
                ComunDatos cm = new ComunDatos();
                cm.ObtenerCatalogosTintoreria();
            }
            catch (Exception ex)
            {
               
            }
        }

        public void ObtenerSucursal(string conexion)
        {
           
                ComunDatos cm = new ComunDatos();
                cm.ObtenerConfiguracion(conexion);
            
        }
        public void ResetCredencial(string conexion)
        {
            try
            {
                ComunDatos cm = new ComunDatos();
                cm.ResetCredencial(conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
