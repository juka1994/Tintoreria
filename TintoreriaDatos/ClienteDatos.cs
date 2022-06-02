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
    public class ClienteDatos :HelperSQL
    {
        public void obtenerClienteXIDD(Cliente cliente)
        {
                 
                DataSet ds = SqlHelper.ExecuteDataset(cliente.conexion, "spCSLDB_getClientexIDDATOS", cliente.id_cliente);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            cliente.datos = ds.Tables[0];
                        }
                    }

                }
           
        }

        public void AbcCliente(Cliente cliente, ref int Verificador)
        {
            try
            {
                object[] Valores = {cliente.opcion, cliente.id_cliente, cliente.nombre, cliente.apePat, cliente.apeMat,
                    cliente.correoElectronico, cliente.id_pais, cliente.id_estado, cliente.id_municipio, cliente.fechaNacimiento,
                    cliente.colonia,cliente.id_genero, cliente.telefono, cliente.curp, cliente.solicitado, cliente.entregado,
                    cliente.fechaInicio, cliente.id_tipoCredencial, cliente.id_u,cliente.direccion};
                object res = SqlHelper.ExecuteScalar(ConexionSQL, "spCSLDB_abc_CatCliente", Valores);
                if (res != null)
                    Verificador = 0;
                else
                    Verificador = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void LLenardatosGridGlientes(Cliente _dato)
        {
            try
            {                
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "[Cat].[spCSLDB_get_Clientes]", _dato.tipoBusqueda, _dato.busqueda);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            _dato.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public void LLenarGridCliente(Cliente cliente)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(cliente.conexion, "spCSLDB_CatCliente_Consulta2_sp", cliente.tipoBusqueda, cliente.busqueda);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            cliente.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cliente ObtenerClienteXIDVenta(VentaProductos datos)
        {
            try
            {
                object[] Valores = { datos.IDVenta, datos.IDSucursal };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.StrCnx, "spCSLDB_getClienteXIDVenta", Valores);
                Cliente cliente = new Cliente();
                cliente.credenciales = new Credenciales();
                while (dr.Read())
                {
                    cliente.id_cliente = dr.GetString(dr.GetOrdinal("id_cliente"));
                    cliente.credenciales.id_codigoEab = dr.GetString(dr.GetOrdinal("idCodigoEab"));
                    cliente.credenciales.nombreCompleto = dr.GetString(dr.GetOrdinal("nombreCliente"));
                    cliente.credenciales.monedero = !dr.IsDBNull(dr.GetOrdinal("monedero")) ? dr.GetDecimal(dr.GetOrdinal("monedero")) : 0; 
                }
                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public object Buscarcliente(string nombre, string strCnx)
        {
            try
            {
                object[] Valores = { nombre };
                DataSet ds = SqlHelper.ExecuteDataset(strCnx, "spCSLDB_Busqueda_Cliente_NombreCompleto", Valores);
                DataTable dt = ds.Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cliente obtenerClienteXEANCodigo(VentaProductos datos)
        {
            try
            {
                object[] Valores = { datos.IDVenta, datos.IDSucursal, datos.IDCliente, datos.Usuins };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.StrCnx, "spCSLDB_setClientexCodigoVentaPend", Valores);
                Cliente cliente = new Cliente();
                cliente.credenciales = new Credenciales();
                while (dr.Read())
                {
                    cliente.id_cliente = dr.GetString(dr.GetOrdinal("id_cliente"));
                    cliente.credenciales.id_codigoEab = dr.GetString(dr.GetOrdinal("idCodigoEab"));
                    cliente.credenciales.nombreCompleto = dr.GetString(dr.GetOrdinal("nombreCliente"));
                    cliente.credenciales.monedero = !dr.IsDBNull(dr.GetOrdinal("monedero")) ? dr.GetDecimal(dr.GetOrdinal("monedero")) : 0;
                }
                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cliente obtenerClienteXIDClienteVentas(VentaProductos datos)
        {
            try
            {
                object[] Valores = { datos.IDVenta, datos.IDSucursal, datos.IDCliente, datos.Usuins };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(datos.StrCnx, "spCSLDB_setClientexIDVentaPend", Valores);
                Cliente cliente = new Cliente();
                cliente.credenciales = new Credenciales();
                while (dr.Read())
                {
                    cliente.id_cliente = dr.GetString(dr.GetOrdinal("id_cliente"));
                    cliente.credenciales.id_codigoEab = dr.GetString(dr.GetOrdinal("idCodigoEab"));
                    cliente.credenciales.nombreCompleto = dr.GetString(dr.GetOrdinal("nombreCliente"));
                    cliente.credenciales.monedero = !dr.IsDBNull(dr.GetOrdinal("monedero")) ? dr.GetDecimal(dr.GetOrdinal("monedero")) : 0;
                    cliente.credenciales.puntos = dr.GetInt32(dr.GetOrdinal("puntos"));
                }
                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public Cliente obtenerClienteXID(string idcliente)
        {
            object[] Valores = { idcliente.Trim() };
            SqlDataReader dr = null;
            dr = SqlHelper.ExecuteReader(Comun.conexion, "spCSLDB_setClientexID_Tintoreria", Valores);
            Cliente cliente = new Cliente();
            cliente.credenciales = new Credenciales();
            while (dr.Read())
            {
                cliente.id_cliente = dr.GetString(dr.GetOrdinal("id_cliente"));
                cliente.credenciales.id_codigoEab = dr.GetString(dr.GetOrdinal("idCodigoEab"));
                cliente.credenciales.nombreCompleto = dr.GetString(dr.GetOrdinal("nombreCliente"));
                cliente.credenciales.monedero = !dr.IsDBNull(dr.GetOrdinal("monedero")) ? dr.GetDecimal(dr.GetOrdinal("monedero")) : 0;
                cliente.credenciales.puntos = dr.GetInt32(dr.GetOrdinal("puntos"));
                cliente.credenciales.NivelCredencial= dr.GetString(dr.GetOrdinal("Nivel"));
                cliente.credenciales.idTipoCredencial = dr.GetInt32(dr.GetOrdinal("id_tipocredencial"));
                cliente.credenciales.cantidadVentas = dr.GetInt32(dr.GetOrdinal("Ventas"));
                cliente.credenciales.PorcentajeMonedero = dr.GetDecimal(dr.GetOrdinal("porcentajeMonedero"));
            }

            return cliente;
        }


        public Cliente obtenerClienteXEANCodigoPedido(Cliente cliente)
        {
            try
            {
                object[] Valores = { cliente.id_cliente };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(cliente.conexion, "spCSLDB_getClientexIDCodigo", Valores);
                while (dr.Read())
                {
                    cliente.id_cliente = dr.GetString(dr.GetOrdinal("id_cliente"));
                    cliente.credenciales.id_codigoEab = dr.GetString(dr.GetOrdinal("idCodigoEab"));
                    cliente.credenciales.nombreCompleto = dr.GetString(dr.GetOrdinal("nombreCliente"));
                    cliente.credenciales.monedero = //(float)dr.GetDecimal(dr.GetOrdinal("monedero"));
                    cliente.credenciales.puntos = dr.GetInt32(dr.GetOrdinal("puntos"));
                }
                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cliente obtenerClienteXID(Cliente cliente)
        {
            try
            {
                object[] Valores = { cliente.id_cliente };
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(cliente.conexion, "spCSLDB_getClientexID", Valores);
                while (dr.Read())
                {
                    cliente.id_cliente = dr.GetString(dr.GetOrdinal("id_cliente"));
                    cliente.credenciales.id_codigoEab = dr.GetString(dr.GetOrdinal("idCodigoEab"));
                    cliente.credenciales.nombreCompleto = dr.GetString(dr.GetOrdinal("nombreCliente"));
                    cliente.credenciales.monedero = !dr.IsDBNull(dr.GetOrdinal("monedero")) ? dr.GetDecimal(dr.GetOrdinal("monedero")) : 0;
                    cliente.credenciales.puntos = dr.GetInt32(dr.GetOrdinal("puntos"));
                }
                return cliente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool VerificarCorreo(string conexion, string correo)
        {
            try
            {
                object res = SqlHelper.ExecuteScalar(conexion, "spCSLDB_CatValidarCorreoCliente_Consulta_sp", correo);
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

    }
}
