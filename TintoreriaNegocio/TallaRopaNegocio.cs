using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class TallaRopaNegocio
    {
        public void llenarGridTallaRopa(TallaRopa tallaRopa)
        {
            try
            {
                TallaRopaDatos TallaRopa_datos = new TallaRopaDatos();
                TallaRopa_datos.LLenarGridTallaRopa(tallaRopa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AbcTallaRopa(TallaRopa tallaRopa, ref int Verificador)
        {
            try
            {
                TallaRopaDatos TallaRopa_datos = new TallaRopaDatos();
                TallaRopa_datos.AbcTallaRopa(tallaRopa, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboTallaRopa(TallaRopa talla)
        {
            try
            {
                TallaRopaDatos TallaRopa_datos = new TallaRopaDatos();
                TallaRopa_datos.ObtenerComboTallaRopa(talla);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
