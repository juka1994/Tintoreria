using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class SucursalNegocio
    {
        public void ObtenerComboSucursal(Sucursal sucursal)
        {
            try
            {
                SucursalDatos sucursal_datos = new SucursalDatos();
                sucursal_datos.ObtenerComboSucursal(sucursal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboSucursal2(Sucursal sucursal)
        {
            try
            {
                SucursalDatos sucursal_datos = new SucursalDatos();
                sucursal_datos.ObtenerComboSucursal2(sucursal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcSucursal(Sucursal sucursal, ref int Verificador)
        {
            try
            {
                SucursalDatos sucursal_datos = new SucursalDatos();
                sucursal_datos.AbcSucursal(sucursal, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void llenarGridSucursal(Sucursal sucursal)
        {
            try
            {
                SucursalDatos sucursal_datos = new SucursalDatos();
                sucursal_datos.LLenarGridSucursal(sucursal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ContarSucursales(string Conexion)
        {
            try
            {
                SucursalDatos sucursal_datos = new SucursalDatos();
                return sucursal_datos.ContarSucursales(Conexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public decimal ObtenerIvaSucursal(string Conexion, string idsucursal)
        {
          
                SucursalDatos sucursal_datos = new SucursalDatos();
                return sucursal_datos.ObtenerIvaSucursal(Conexion,idsucursal);
           
        }
    }
}
