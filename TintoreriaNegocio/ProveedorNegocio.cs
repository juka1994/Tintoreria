using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class ProveedorNegocio
    {
        public void AbcProveedor(Proveedor proveedor, ref int Verificador)
        {
            try
            {
                ProveedorDatos proveedor_datos = new ProveedorDatos();
                proveedor_datos.AbcProveedor(proveedor, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridProveedor(Proveedor proveedor)
        {
            try
            {
                ProveedorDatos proveedor_datos = new ProveedorDatos();
                proveedor_datos.LLenarGridProveedor(proveedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboProveedor(Proveedor proveedor)
        {
            try
            {
                ProveedorDatos proveedor_datos = new ProveedorDatos();
                proveedor_datos.ObtenerComboProveedor(proveedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool VerificarUserProveedor(string conexion, string user, string id_proveedor)
        {
            try
            {
                ProveedorDatos proveedor_datos = new ProveedorDatos();
                return proveedor_datos.VerificarUserProveedor(conexion, user, id_proveedor);
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void ObtenerComboProveedorGeneral(Proveedor proveedor)
        {
            try
            {
                ProveedorDatos proveedor_datos = new ProveedorDatos();
                proveedor_datos.ObtenerComboProveedorGeneral(proveedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
