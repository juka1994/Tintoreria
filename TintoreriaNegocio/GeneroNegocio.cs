using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class GeneroNegocio
    {
        public void ObtenerComboGenero(Genero genero)
        {
            try
            {
                GeneroDatos genero_datos = new GeneroDatos();
                genero_datos.ObtenerComboGenero(genero);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
