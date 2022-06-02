using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class IvaNegocio
    {
        public void ObtenerComboIva(Iva iva)
        {
            try
            {
                IvaDatos iva_datos = new IvaDatos();
                iva_datos.ObtenerComboIva(iva);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridIva(Iva iva)
        {
            try
            {
                IvaDatos iva_datos = new IvaDatos();
                iva_datos.LLenarGridIva(iva);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AbcIva(Iva iva, ref int Verificador)
        {
            try
            {
                IvaDatos iva_datos = new IvaDatos();
                iva_datos.AbcIva(iva, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
