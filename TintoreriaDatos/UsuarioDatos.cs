using TintoreriaGlobal;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaDatos
{
    public class UsuarioDatos
    {
        public void AbcUsuario(Usuario usuario, ref int Verificador)
        {
            try
            {
                object[] Valores = { usuario.opcion,usuario.id_usuario,usuario.id_sucursal,usuario.id_tipoUsuario,usuario.nombre,usuario.apellidoPat,usuario.apellidoMat,usuario.fechaNacimiento,usuario.telefono,usuario.id_pais,usuario.id_estado,usuario.id_municipio,usuario.direccion,usuario.id_turno,usuario.user,usuario.password,usuario.fCaducidad,usuario.conInt,usuario.estatus,usuario.fBloq,usuario.cambio_passs,usuario.id_u };
                object res = SqlHelper.ExecuteScalar(usuario.conexion, "spCSLDB_abc_CatUsuario", Valores);
                if (res != null)
                    Verificador = 0;
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
                DataSet ds = SqlHelper.ExecuteDataset(usuario.conexion, "spCSLDB_CatUsuario_Consulta2_sp", usuario.tipoBusqueda, usuario.busqueda);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            usuario.datos = ds.Tables[0];
                        }
                    }
                }
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
                object[] Valores = { user, id_usuario };
                object res = SqlHelper.ExecuteScalar(conexion, "spCSLDB_CatValidarUserUsuario_Consulta_sp", Valores);
                if (res != null)
                    return res.ToString() == "1" ? true : false;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void GuardarUsuarioXPermiso(Usuario datos, ref int Verificador)
        {
            try
            {
                object result = SqlHelper.ExecuteScalar(datos.conexion,
                    CommandType.StoredProcedure, "spCSLDB_abc_CatUsuario",
                    new SqlParameter("@opcion", datos.opcion),
                    new SqlParameter("@id_usuario", datos.id_usuario),
                    new SqlParameter("@id_sucursal", datos.id_sucursal),
                    new SqlParameter("@id_tipoUsuario", datos.id_tipoUsuario),
                    new SqlParameter("@nombre", datos.nombre),
                    new SqlParameter("@apellidoPat", datos.apellidoPat),
                    new SqlParameter("@apellidoMat", datos.apellidoMat),
                    new SqlParameter("@fechaNacimiento", datos.fechaNacimiento),
                    new SqlParameter("@telefono", datos.telefono),
                    new SqlParameter("@id_pais", datos.id_pais),
                    new SqlParameter("@id_estado", datos.id_estado),
                    new SqlParameter("@id_municipio", datos.id_municipio),
                    new SqlParameter("@direccion", datos.direccion),
                    new SqlParameter("@id_turno", datos.id_turno),
                    new SqlParameter("@user", datos.user),
                    new SqlParameter("@password", datos.password),
                    new SqlParameter("@fCaducidad", datos.fCaducidad),
                    new SqlParameter("@conInt", datos.conInt),
                    new SqlParameter("@estatus", datos.estatus),
                    new SqlParameter("@fBloq", datos.fBloq),
                    new SqlParameter("@cambio_Pass", datos.cambio_passs),
                    new SqlParameter("@permisoCargados", datos.permisoCargados),
                    new SqlParameter("@permisoUsuarioCatalogo", datos.datos),
                    new SqlParameter("@Usuario", datos.id_u));
                if (result != null)
                {
                    Verificador = 0;
                    datos.id_usuario = result.ToString();
                }
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
                object[] Valores = { usuario.id_usuario };
                DataSet ds = SqlHelper.ExecuteDataset(usuario.conexion, "spCSLDB_CatPerfil_Consulta_sp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            if (ds.Tables[0].Rows.Count == 1)
                            {
                                usuario.id_usuario = ds.Tables[0].Rows[0][0].ToString();
                                usuario.id_tipoUsuario = Convert.ToInt32(ds.Tables[0].Rows[0][1]);
                                usuario.descripcion = ds.Tables[0].Rows[0][2].ToString();
                                usuario.nombre = ds.Tables[0].Rows[0][3].ToString();
                                usuario.apellidoPat = ds.Tables[0].Rows[0][4].ToString();
                                usuario.apellidoMat = ds.Tables[0].Rows[0][5].ToString();
                                usuario.password = "qwertyuiop1234";
                            }
                        }
                    }
                }
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
                object[] Valores = { usuario.id_usuario, usuario.password, usuario.cambio_passs, usuario.id_u };
                object res = SqlHelper.ExecuteScalar(usuario.conexion, "spCSLDB_abc_CatPerfil", Valores);
                if (res != null)
                    Verificador = 0;
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
                object[] parametros = { datos.user, datos.password, datos.id_sucursal };
                SqlDataReader dtr = SqlHelper.ExecuteReader(datos.conexion, "spCSLDB_get_AutorizacionAdmin", parametros);
                while (dtr.Read())
                {
                    datos.Validador = dtr.GetInt32(0);
                    if (datos.Validador == 1)
                    {
                        datos.id_usuario = dtr.GetString(dtr.GetOrdinal("id_usuario"));
                    }
                }
                return datos;
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
                DataSet ds = SqlHelper.ExecuteDataset(usuario.conexion, "spCSLDB_get_ComboCatCaja", fecha, id_sucursal);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            usuario.datos = ds.Tables[0];
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
