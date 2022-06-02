using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TintoreriaDatos;
using TintoreriaGlobal;

namespace TintoreriaNegocio
{
    public class Vales_Negocio
    {
        public void ActivarVale(Vales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                VD.ActivarVale(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ReActivarVale(Vales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                VD.ReActivarVale(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarVale(Vales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                VD.EliminarVale(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }      
        public void SuspenderVale(Vales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                VD.SuspenderVale(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ABCVales(Vales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                VD.ABCVales(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerVales(Vales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                VD.ObtenerVales(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerValesBusqueda(Vales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                VD.ObtenerValesBusqueda(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TipoVales> ObtenerComboTipoVales(TipoVales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                return VD.ObtenerComboTipoVale(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Producto> ObtenerComboCatProducto(Producto Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                return VD.ObtenerComboCatProducto(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Vales ObtenerValeDetalle(Vales Datos)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                return VD.ObtenerValeDetalle(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ConsultaVale(Venta ventavale)
        {
            
                Vales_Datos VD = new Vales_Datos();
                VD.ConsultaVale(ventavale);
           
        }
        public void ModificarDescuentoVentaDetalle(ref int Verificador, ref Venta ventavale)
        {
            try
            {
                Vales_Datos VD = new Vales_Datos();
                VD.ModificarDescuentoVentaDetalle(ref Verificador, ref ventavale);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
