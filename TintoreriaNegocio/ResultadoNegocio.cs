using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class ResultadoNegocio
    {
        public void LLenarGridResultado(Resultado resultado)
        {
            try
            {
                ResultadoDatos resultadoDatos = new ResultadoDatos();
                resultadoDatos.LLenarGridResultado(resultado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AbcResultado(Resultado resultado, ref int Verificador)
        {
            try
            {
                ResultadoDatos resultadoDatos = new ResultadoDatos();
                resultadoDatos.AbcResultado(resultado, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboOperacion(Resultado resultado)
        {
            try
            {
                ResultadoDatos resultadoDatos = new ResultadoDatos();
                resultadoDatos.ObtenerComboOperacion(resultado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
