using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class ReportesNegocio
    {
        public void ObtenerProductosMasVendidosTop10(ReporteProductosTop10 reporteProductosTop10)
        {
            try
            {
                ReportesDatos reportesDatos = new ReportesDatos();
                reportesDatos.ObtenerProductosMasVendidosTop10(reporteProductosTop10);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerProductosMenosVendidosTop10(ReporteProductosTop10 reporteProductosTop10)
        {
            try
            {
                ReportesDatos reportesDatos = new ReportesDatos();
                reportesDatos.ObtenerProductosMenosVendidosTop10(reporteProductosTop10);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerVendedoresMayoresVentasTop5(ReporteVendedorTop5 reporteProductosTop5)
        {
            try
            {
                ReportesDatos reportesDatos = new ReportesDatos();
                reportesDatos.ObtenerVendedoresMayoresVentasTop5(reporteProductosTop5);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerProductosMasPedidosTop10(ReporteProductosTop10 reporteProductosTop10)
        {
            try
            {
                ReportesDatos reportesDatos = new ReportesDatos();
                reportesDatos.ObtenerProductosMasPedidosTop10(reporteProductosTop10);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerCajaXID(Caja caja)
        {
            try
            {
                ReportesDatos reportesDatos = new ReportesDatos();
                reportesDatos.ObtenerCajaXID(caja);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerCajaXIDEquipoFechas(Caja caja)
        {
            try
            {
                ReportesDatos reportesDatos = new ReportesDatos();
                reportesDatos.ObtenerCajaXIDEquipoFechas(caja);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerProveedorMasComprasTop5(ReporteProveedorComprasTop5 ReporteProveedorComprasTop5)
        {
            try
            {
                ReportesDatos reportesDatos = new ReportesDatos();
                reportesDatos.ObtenerProveedorMasComprasTop5(ReporteProveedorComprasTop5);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerProveedorMenosComprasTop5(ReporteProveedorComprasTop5 ReporteProveedorComprasTop5)
        {
            try
            {
                ReportesDatos reportesDatos = new ReportesDatos();
                reportesDatos.ObtenerProveedorMenosComprasTop5(ReporteProveedorComprasTop5);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerProveedorMasCambiosPorFallasTop5(ReporteProveedorComprasTop5 ReporteProveedorComprasTop5)
        {
            try
            {
                ReportesDatos reportesDatos = new ReportesDatos();
                reportesDatos.ObtenerProveedorMasCambiosPorFallasTop5(ReporteProveedorComprasTop5);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerProductosMasCambiosPorFallasTop10(ReporteProductosTop10 ReporteProductosCambiosTop10)
        {
            try
            {
                ReportesDatos reportesDatos = new ReportesDatos();
                reportesDatos.ObtenerProductosMasCambiosPorFallasTop10(ReporteProductosCambiosTop10);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerResultadoXMesXSucursal(ReporteResultado reporteResultado)
        {
            try
            {
                ReportesDatos reportesDatos = new ReportesDatos();
                reportesDatos.ObtenerResultadoXMesXSucursal(reporteResultado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerDesgloseMovimientosXDia(DesgloseMovimientos desgloseMovimientos)
        {
            try
            {
                ReportesDatos reportesDatos = new ReportesDatos();
                reportesDatos.ObtenerDesgloseMovimientosXDia(desgloseMovimientos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerDesgloseMovimientosActual(DesgloseMovimientos desgloseMovimientos)
        {
            try
            {
                ReportesDatos reportesDatos = new ReportesDatos();
                reportesDatos.ObtenerDesgloseMovimientosActual(desgloseMovimientos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerDesgloseMovimientosXFechas(DesgloseMovimientos desgloseMovimientos)
        {
            try
            {
                ReportesDatos reportesDatos = new ReportesDatos();
                reportesDatos.ObtenerDesgloseMovimientosXFechas(desgloseMovimientos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
