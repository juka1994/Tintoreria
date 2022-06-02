using TintoreriaGlobal;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaDatos
{
    public class PermisoDatos
    {
        public void LLenarGridPermiso(string Conexion, List<Permiso> lstPermisosUsuariosCatalogos, int opc, string id_usuario, int id_tipoUsuario)
        {
            try
            {
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(Conexion, "spCSLDB_Permiso_Consulta_sp", opc, id_usuario, id_tipoUsuario);
                Permiso permisosUsuariosCatalogos;
                while (dr.Read())
                {
                    permisosUsuariosCatalogos = new Permiso();
                    permisosUsuariosCatalogos.id_permiso = dr["id_permiso"].ToString();
                    permisosUsuariosCatalogos.id_catalogo = Convert.ToInt32(dr["id_catalogo"].ToString());
                    permisosUsuariosCatalogos.catalogo = dr["catalago"].ToString();
                    permisosUsuariosCatalogos.activoCatalogo = Convert.ToBoolean(Convert.ToInt32(dr["activoCatalogo"].ToString()));
                    permisosUsuariosCatalogos.id_tipoUsuario = Convert.ToInt32(dr["id_tipoUsuario"].ToString());
                    lstPermisosUsuariosCatalogos.Add(permisosUsuariosCatalogos);
                }
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
                DataSet ds = SqlHelper.ExecuteDataset(permiso.conexion, "spCSLDB_PermisoXDefecto_Consulta_sp", permiso.id_tipoUsuario);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            permiso.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
