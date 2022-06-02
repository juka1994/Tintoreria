using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class TipoUsuarioNegocio
    {
        public void ObtenerComboTipoUsuario(TipoUsuario tipoUsuario)
        {
            try
            {
                TipoUsuarioDatos tipoUsuario_datos = new TipoUsuarioDatos();
                tipoUsuario_datos.ObtenerComboTipoUsuario(tipoUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
