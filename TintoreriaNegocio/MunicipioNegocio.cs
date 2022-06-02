using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class MunicipioNegocio
    {
        public void ObtenerComboMunicipio(Municipio municipio)
        {
            try
            {
                MunicipioDatos estado_datos = new MunicipioDatos();
                estado_datos.ObtenerComboMunicipio(municipio);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       
    }
}
