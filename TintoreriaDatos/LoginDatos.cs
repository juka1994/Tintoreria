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
    public class LoginDatos : HelperSQL
    {
        public Usuario validarUsuario(Usuario usuario)
        {
            try
            {
                SqlDataReader SqlDr = null;
                string[] valores = { usuario.user, usuario.password, Comun.macAddress };
                SqlDr = SqlHelper.ExecuteReader(usuario.conexion, "spCSLDB_login_sp", valores);
                if (SqlDr.HasRows == true)
                {
                    while (SqlDr.Read())
                    {
                        usuario.Validador = SqlDr.GetInt32(0);
                        if (usuario.Validador == 1)
                        {
                            usuario.id_usuario = SqlDr.GetString(SqlDr.GetOrdinal("id_usuario"));
                            usuario.nombre = SqlDr.GetString(SqlDr.GetOrdinal("nombre"));
                            usuario.apellidoPat = SqlDr.GetString(SqlDr.GetOrdinal("apellidoPat"));
                            usuario.apellidoMat = SqlDr.GetString(SqlDr.GetOrdinal("apellidoMat"));
                            usuario.id_tipoUsuario = SqlDr.GetInt32(SqlDr.GetOrdinal("id_tipoUsuario"));
                            if (Convert.IsDBNull(SqlDr["estatus"]))
                                usuario.estatus = false;
                            else
                                usuario.estatus = Convert.ToBoolean(SqlDr["estatus"]);
                            if (Convert.IsDBNull(SqlDr.GetValue(SqlDr.GetOrdinal("CuentaCaducada"))))
                                usuario.cuentaCaducada = false;
                            else
                                usuario.cuentaCaducada = Convert.ToBoolean(SqlDr.GetValue(SqlDr.GetOrdinal("CuentaCaducada")));
                            usuario.id_sucursal = SqlDr.GetString(SqlDr.GetOrdinal("id_sucursal"));
                            usuario.crearid_caja = Convert.ToBoolean(SqlDr["crearid_caja"]);
                            usuario.idcaja = SqlDr.GetString(SqlDr.GetOrdinal("id_caja"));
                            //Llenamos datos necesarios para otras pantallas
                            Comun.id_u = usuario.id_usuario;
                            Comun.id_tu = usuario.id_tipoUsuario;
                            Comun.u_nombre = usuario.nombre;
                            Comun.u_apellidoP = usuario.apellidoPat;
                            Comun.u_apellidoM = usuario.apellidoMat;
                            Comun.id_sucursal = usuario.id_sucursal;
                            Comun.id_caja = usuario.idcaja;
                            if (SqlDr.GetInt32(SqlDr.GetOrdinal("id_turno")) == 1)
                                Comun.turno = "Matutino";
                            else if (SqlDr.GetInt32(SqlDr.GetOrdinal("id_turno")) == 2)
                                Comun.turno = "Vespertino";
                            else
                                Comun.turno = "Mixto";
                            Comun.tipoUsuario = SqlDr.GetString(SqlDr.GetOrdinal("tipoUsuario"));
                            Comun.usuariocuenta = SqlDr.GetString(SqlDr.GetOrdinal("usuariocuenta"));
                            Comun.id_equipo = SqlDr.GetString(SqlDr.GetOrdinal("id_equipo"));
                            Comun.UbicacionMacAddress = SqlDr.GetString(SqlDr.GetOrdinal("ubicacionMacAddress"));
                            Comun.DireccionMacAddress = SqlDr.GetString(SqlDr.GetOrdinal("direccionMacAddress"));
                            Comun.TipoSucursal = SqlDr.GetString(SqlDr.GetOrdinal("tipoSucursal"));
                        }
                    }
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("No se puede obtener la información" + ex.Message);
            }
        }
        public void ObtenerPermisosUsuario(Usuario usuario)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(usuario.conexion, "spCSLDB_PermisoXIDUsuario_sp", usuario.id_usuario);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            usuario.PermisoUsuario = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public RespuestaSQL Login_spCIDDB_Login(string usuario, string password)
        {
            try
            {
                object[] parametros =
                {
                    usuario,
                    password
                };
                RespuestaSQL oRespuesta = new RespuestaSQL();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(
                    ConexionSQL,
                    "Login.spCIDDB_Login",
                    parametros
                );

                while (dr.Read())
                {
                    oRespuesta.Success = !dr.IsDBNull(dr.GetOrdinal("success")) ? dr.GetBoolean(dr.GetOrdinal("success")) : false;
                    oRespuesta.Mensaje = !dr.IsDBNull(dr.GetOrdinal("mensaje")) ? dr.GetString(dr.GetOrdinal("mensaje")) : string.Empty;
                }
                dr.Close();

                return oRespuesta;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
