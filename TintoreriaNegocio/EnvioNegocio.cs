using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TintoreriaDatos;
using TintoreriaGlobal;

namespace TintoreriaNegocio
{
   public  class EnvioNegocio
    {
        public void CargarGridEnvio(Envio env)
        {
            try
            {
                EnvioDatos envDatos = new EnvioDatos();
                envDatos.CargarGridEnvio(env);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ActualizarFechaEntrega(Envio fechActualizar)
        {
            try
            {
                EnvioDatos ventaProductosDatos = new EnvioDatos();
                ventaProductosDatos.ActualizarFechaVenta(fechActualizar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Guardarenvio(Envio env, DataTable DatosTabla)
        {
            try
            {
                EnvioDatos envio_datos = new EnvioDatos();
                envio_datos.GuardarEnvio(env, DatosTabla);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CargarDatosListaEnvioR(Envio env)
        {
            try
            {
                EnvioDatos envDatos = new EnvioDatos();
                envDatos.CargarDatosListaEnvio(env);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
