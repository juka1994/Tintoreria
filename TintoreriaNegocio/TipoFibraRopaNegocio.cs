using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TintoreriaDatos;
using TintoreriaGlobal;

namespace TintoreriaNegocio
{
    public class TipoFibraRopaNegocio
    {
        public TipoFibraRopa ObtenerGridTipoFibraRopa(TipoFibraRopa Datos)
        {
            try
            {
                TipoFibraRopaDatos DatosFR = new TipoFibraRopaDatos();
                return DatosFR.ObtenerGridTipoFibraRopa(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ACFibraRopa(TipoFibraRopa Datos, ref int Verificador)
        {
            try
            {
                TipoFibraRopaDatos DatosFR = new TipoFibraRopaDatos();
                DatosFR.ACFibraRopa(Datos, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarTipoFibraRopa(TipoFibraRopa Datos, ref int Verificador)
        {
            try
            {
                TipoFibraRopaDatos DatosFR = new TipoFibraRopaDatos();
                DatosFR.EliminarFibraRopa(Datos, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TipoFibraRopa ObtenerImagen(TipoFibraRopa Datos)
        {
            try
            {
                TipoFibraRopaDatos DatosFR = new TipoFibraRopaDatos();
                return DatosFR.ObtenerImagen(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
