using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class PermisoNegocio
    {
        public void LLenarGridPermiso(string Conexion, ref List<Permiso> lstPermisosUsuariosCatalogos, int opc, string id_usuario, int id_tipoUsuario)
        {
            try
            {
                PermisoDatos permiso_datos = new PermisoDatos();
                permiso_datos.LLenarGridPermiso(Conexion, lstPermisosUsuariosCatalogos, opc, id_usuario, id_tipoUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void PermisoXDefecto(Permiso permiso)
        {
            try
            {
                PermisoDatos permisoDatos = new PermisoDatos();
                permisoDatos.PermisoXDefecto(permiso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
