using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TintoreriaGlobal;

namespace TintoreriaDatos
{
    public class NotificacionDatos
    {        
        public void ObtenerNotificaciones(Notificacion notificacion)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(notificacion.conexion, "spCSLDB_CatNotificaciones_Consulta_sp", notificacion.id_sucursal);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            notificacion.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void NotificarStockMinimo(String conexion, String id_sucursal)
        {
            try
            {
                object res = SqlHelper.ExecuteDataset(conexion, "spCSLDB_set_CheckStockMinimo", id_sucursal);                
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
                object[] Valores = { notificacion.id_sucursal, notificacion.id_tipoNotificacion, notificacion.id_u };
                SqlHelper.ExecuteDataset(notificacion.conexion, "spCSLDB_set_CheckNotificacion",Valores);                
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
                object[] Valores = {notificacion.opcion,notificacion.id_notificacionApp,notificacion.id_persona,notificacion.id_generico,notificacion.id_tipoNotificacion,notificacion.enviar,
                                       notificacion.nombre,notificacion.texto,notificacion.descripcion,notificacion.id_u};
                DataSet ds = SqlHelper.ExecuteDataset(notificacion.conexion, "spCSLDB_abc_NotificacionApp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            if(ds.Tables[0].Rows.Count >0)
                                Verificador = 0;
                            notificacion.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AbcNotificacionAppDU(Notificacion notificacion, ref int Verificador)
        {
            
                object[] Valores = {notificacion.opcion,notificacion.id_notificacionApp,notificacion.id_persona,notificacion.id_generico,notificacion.id_tipoNotificacion,notificacion.enviar,
                                       notificacion.nombre,notificacion.texto,notificacion.descripcion,notificacion.id_u};
                DataSet ds = SqlHelper.ExecuteDataset(notificacion.conexion, "spCSLDB_abc_NotificacionAppDU", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                                Verificador = 0;
                            notificacion.datos = ds.Tables[0];
                        }
                    }
                }
            
        }
    }
}
