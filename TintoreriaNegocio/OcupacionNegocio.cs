using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class OcupacionNegocio
    {
        public void ObtenerComboOcupacion(Ocupacion ocupacion)
        {
            try
            {
                OcupacionDatos ocupacion_datos = new OcupacionDatos();
                ocupacion_datos.ObtenerComboOcupacion(ocupacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void llenarGridOcupacion(Ocupacion ocupacion)
        {
            try
            {
                OcupacionDatos ocupacion_datos = new OcupacionDatos();
                ocupacion_datos.LLenarGridOcupacion(ocupacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AbcOcupacion(Ocupacion ocupacion, ref int Verificador)
        {
            try
            {
                OcupacionDatos ocupacion_datos = new OcupacionDatos();
                ocupacion_datos.AbcOcupacion(ocupacion, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
