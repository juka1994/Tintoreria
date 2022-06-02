using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class EstadoNegocio
    {
        public void ObtenerComboEstado(Estado estado)
        {
            try
            {
                EstadoDatos estado_datos = new EstadoDatos();
                estado_datos.ObtenerComboEstado(estado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
