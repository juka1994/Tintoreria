using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class AlmacenNegocio
    {
        public void AbcAlmacen(Almacen almacen, ref int Verificador)
        {
            try
            {
                AlmacenDatos almacen_datos = new AlmacenDatos();
                almacen_datos.AbcAlmacen(almacen, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ImportarExcel(Almacen almacen, ref int Verificador)
        {
            try
            {
                AlmacenDatos almacen_datos = new AlmacenDatos();
                almacen_datos.ImportarExcel(almacen, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridAlmacen(Almacen almacen)
        {
            try
            {
                AlmacenDatos almacen_datos = new AlmacenDatos();
                almacen_datos.LLenarGridAlmacen(almacen);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridHistorial(Almacen almacen)
        {
            try
            {
                AlmacenDatos almacen_datos = new AlmacenDatos();
                almacen_datos.LLenarGridHistorial(almacen);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridHistorialImportados(Almacen almacen)
        {
            try
            {
                AlmacenDatos almacen_datos = new AlmacenDatos();
                almacen_datos.LLenarGridHistorialImportados(almacen);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridStockBajo(Almacen almacen)
        {
            try
            {
                AlmacenDatos almacenDatos = new AlmacenDatos();
                almacenDatos.LLenarGridStockBajo(almacen);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
