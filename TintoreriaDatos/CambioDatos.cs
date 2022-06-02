using TintoreriaGlobal;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaDatos
{
    public class CambioDatos
    {
        //public bool VerificarCambioProducto(Cambio cambio)
        //{
        //    try
        //    {
        //        object[] Valores = { cambio.id_sucursal, cambio.id_caja, cambio.id_productoCambio, cambio.id_tallaRopaCambio, cambio.id_colorRopaCambio, cambio.id_productoNuevo, cambio.id_tallaRopaNuevo, cambio.id_colorRopaNuevo };
        //        object res = SqlHelper.ExecuteScalar(cambio.conexion, "spCSLDB_set_CheckCambio", Valores);
        //        if (res != null)
        //            return res.ToString() == "1" ? true : false;
        //        else
        //            return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public void AbcCambio(Cambio cambio,ref int Verificador)
        //{
        //    try
        //    {
        //        object[] Valores = {cambio.id_cambio,cambio.id_sucursal, cambio.id_caja, cambio.id_productoCambio, cambio.id_tallaRopaCambio, cambio.id_colorRopaCambio, cambio.id_productoNuevo, cambio.id_tallaRopaNuevo, cambio.id_colorRopaNuevo,cambio.id_motivo,cambio.observaciones,cambio.id_u};
        //        object res = SqlHelper.ExecuteScalar(cambio.conexion, "spCSLDB_abc_CatCambios", Valores);
        //        if (res != null)
        //            Verificador = 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public void ObtenerComboCambioPrecio(Cambio cambio)
        {
            try
            {
                object[] Valores = { cambio.id_productoNuevo, cambio.id_colorRopaNuevo, cambio.id_tallaRopaNuevo, cambio.id_sucursal };
                DataSet ds = SqlHelper.ExecuteDataset(cambio.conexion, "spCSLDB_get_ComboCambioPrecio", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            cambio.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
