using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TintoreriaDatos;
using TintoreriaGlobal;

namespace TintoreriaNegocio
{
    public class TipoEstampadoNegocio
    {
        public TipoEstampado ObtenerTipoEstampado(TipoEstampado Datos)
        {
            try
            {
                TipoEstampadoDatos EstampadoNeg = new TipoEstampadoDatos();
                return EstampadoNeg.LLenarGridEstampado(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ACEstampado(TipoEstampado Datos, ref int Verificador)
        {
            try
            {
                TipoEstampadoDatos EstampadoNeg = new TipoEstampadoDatos();
                EstampadoNeg.ACEstampado(Datos, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarEstampado(TipoEstampado Datos, ref int Verificador)
        {
            try
            {
                TipoEstampadoDatos EstampadoNeg = new TipoEstampadoDatos();
                EstampadoNeg.EliminarEstampado(Datos, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TipoEstampado ObtenerImagen(TipoEstampado Datos)
        {
            try
            {
                TipoEstampadoDatos Tipo = new TipoEstampadoDatos();
                return Datos = Tipo.ObtenerImagen(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
