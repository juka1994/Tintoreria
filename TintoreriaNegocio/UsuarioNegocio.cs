using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class UsuarioNegocio
    {
        public void AbcUsuario(Usuario usuario, ref int Verificador)
        {
            try
            {
                UsuarioDatos usuario_datos = new UsuarioDatos();
                usuario_datos.AbcUsuario(usuario, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridUsuario(Usuario usuario)
        {
            try
            {
                UsuarioDatos usuario_datos = new UsuarioDatos();
                usuario_datos.LLenarGridUsuario(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool VerificarUserUsuario(string conexion, string user, string id_usuario)
        {
            try
            {
                UsuarioDatos usuario_datos = new UsuarioDatos();
                return usuario_datos.VerificarUserUsuario(conexion, user, id_usuario);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void GuardarUsuarioXPermiso(Usuario Usuario, ref int Verificador)
        {
            try
            {
                UsuarioDatos usuario_datos = new UsuarioDatos();
                usuario_datos.GuardarUsuarioXPermiso(Usuario, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ConsultaPerfil(Usuario usuario)
        {
            try
            {
                UsuarioDatos usuario_datos = new UsuarioDatos();
                usuario_datos.ConsultaPerfil(usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcPerfil(Usuario usuario, ref int Verificador)
        {
            try
            {
                UsuarioDatos usuario_datos = new UsuarioDatos();
                usuario_datos.AbcPerfil(usuario, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Usuario AutorizacionAdmin(Usuario datos)
        {
            try
            {
                UsuarioDatos ud = new UsuarioDatos();
                return ud.AutorizacionAdmin(datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboCaja(Usuario usuario, DateTime fecha, string id_sucursal)
        {
            try
            {
                UsuarioDatos usuario_datos = new UsuarioDatos();
                usuario_datos.ObtenerComboCaja(usuario, fecha, id_sucursal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
