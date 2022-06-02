using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class CambioNegocio
    {
        //public bool VerificarCambioProducto(Cambio cambio)
        //{
        //    try
        //    {
        //        CambioDatos cambioDatos = new CambioDatos();
        //        return cambioDatos.VerificarCambioProducto(cambio);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public void ObtenerComboCambioPrecio(Cambio cambio)
        {
            try
            {
                CambioDatos cambioDatos = new CambioDatos();
                cambioDatos.ObtenerComboCambioPrecio(cambio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
