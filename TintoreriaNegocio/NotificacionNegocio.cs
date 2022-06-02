using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TintoreriaDatos;
using TintoreriaGlobal;

namespace TintoreriaNegocio
{
    public class NotificacionNegocio
    {        
        public void ObtenerNotificaciones(Notificacion notificacion)
        {
            try
            {
                NotificacionDatos notificacion_datos = new NotificacionDatos();
                notificacion_datos.ObtenerNotificaciones(notificacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void NotificarStockMinimo(String conexion,String id_sucursal)
        {
            try
            {
                NotificacionDatos notificacion_datos = new NotificacionDatos();
                notificacion_datos.NotificarStockMinimo(conexion, id_sucursal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ActualizarNotificacion(Notificacion notificacion)
        {
            try
            {
                NotificacionDatos notificacion_datos = new NotificacionDatos();
                notificacion_datos.ActualizarNotificacion(notificacion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcNotificacionApp(Notificacion notificacion,ref int Verificador)
        {
            try
            {
                NotificacionDatos notificacion_datos = new NotificacionDatos();
                notificacion_datos.AbcNotificacionApp(notificacion,ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcNotificacionAppDU(Notificacion notificacion, ref int Verificador)
        {
            try
            {
                NotificacionDatos notificacion_datos = new NotificacionDatos();
                notificacion_datos.AbcNotificacionAppDU(notificacion, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
