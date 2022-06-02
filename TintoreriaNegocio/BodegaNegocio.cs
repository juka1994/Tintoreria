using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class BodegaNegocio
    {       
        public void LLenarGridBodega(Bodega bodega)
        {
            try
            {
                BodegaDatos bodega_datos = new BodegaDatos();
                bodega_datos.LLenarGridBodega(bodega);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridAplicarBodega(Bodega bodega)
        {
            try
            {
                BodegaDatos bodega_datos = new BodegaDatos();
                bodega_datos.LLenarGridAplicarBodega(bodega);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridProductos(Bodega bodega)
        {
            try
            {
                BodegaDatos bodega_datos = new BodegaDatos();
                bodega_datos.LLenarGridProductos(bodega);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcBodega(Bodega bodega, ref int Verificador)
        {
            try
            {
                BodegaDatos bodega_datos = new BodegaDatos();
                bodega_datos.AbcBodega(bodega, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ReporteBodega> LLenarGridProductosReporte(Bodega bodega)
        {
            try
            {
                BodegaDatos bodega_datos = new BodegaDatos();
                return bodega_datos.LLenarGridProductosReporte(bodega);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
