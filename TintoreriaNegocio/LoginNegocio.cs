using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class LoginNegocio
    {
        public Usuario validarUsuario(Usuario usuario)
        {
            try
            {
                LoginDatos login_datos = new LoginDatos();
                login_datos.validarUsuario(usuario);
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerPermisosUsuario(Usuario usuario)
        {
            try
            {
                LoginDatos login_datos = new LoginDatos();
                login_datos.ObtenerPermisosUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public RespuestaSQL Login_spCIDDB_Login(string usuario, string password)
        {
            LoginDatos login_datos = new LoginDatos();
            return login_datos.Login_spCIDDB_Login(usuario, password);
        }
    }
}
