using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class ClienteNegocio
    {
        public void obtenerClienteXIDD(Cliente cliente)
        {
           
                ClienteDatos cliente_datos = new ClienteDatos();
                cliente_datos.obtenerClienteXIDD(cliente);
            
        }

        public void AbcCliente(Cliente cliente, ref int Verificador)
        {
            try
            {
                ClienteDatos cliente_datos = new ClienteDatos();
                cliente_datos.AbcCliente(cliente, ref Verificador);
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
                ClienteDatos cliente_datos = new ClienteDatos();
                cliente_datos.LLenarGridCliente(cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //D
        public void LLenarGridClientes(Cliente cliente)
        {
            try
            {
                ClienteDatos cliente_datos = new ClienteDatos();
                cliente_datos.LLenardatosGridGlientes(cliente);
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
                ClienteDatos cliente_datos = new ClienteDatos();
                return cliente_datos.ObtenerClienteXIDVenta(datos);
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
                ClienteDatos cliente_datos = new ClienteDatos();
                return cliente_datos.Buscarcliente(nombre, strCnx);
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
                ClienteDatos cliente_datos = new ClienteDatos();
                return cliente_datos.obtenerClienteXEANCodigo(datos);
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
                ClienteDatos cliente_datos = new ClienteDatos();
                return cliente_datos.obtenerClienteXIDClienteVentas(datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cliente obtenerClienteXEANCodigoPedido(Cliente cliente)
        {
            try
            {
                ClienteDatos cliente_datos = new ClienteDatos();
                return cliente_datos.obtenerClienteXEANCodigoPedido(cliente);
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
                ClienteDatos cliente_datos = new ClienteDatos();
                return cliente_datos.obtenerClienteXID(cliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Cliente obtenerClienteXID(string idcliente)
        {
            try
            {
                ClienteDatos cliente_datos = new ClienteDatos();
                return cliente_datos.obtenerClienteXID(idcliente);
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
                ClienteDatos cliente_datos = new ClienteDatos();
                return cliente_datos.VerificarCorreo(conexion, correo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
