using System;
using TintoreriaGlobal;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace TintoreriaDatos
{
    public class VehiculoDatos
    {
        public Vehiculo LLenarGridVehiculo(Vehiculo _datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(_datos.conexion, "[Cat].[spCSLDB_get_Vehiculo]");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            _datos.datosTabla = ds.Tables[0];
                        }
                    }
                }
                return _datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarVehiculo(Vehiculo _veh, ref int Verificador)
        {
            try
            {
                int Resultado = 0;
                object[] Valores = { _veh.IDUsuario, _veh.ID_vehiculo,_veh.NombreVeh,_veh.placas,_veh.Descripcion,_veh.opcion = 3};
                object res = SqlHelper.ExecuteScalar(_veh.conexion, "[Cat].[spCSLDB_ABC_ServTintoreria_Vehiculo]", Valores);
                if (res != null)
                {
                    Resultado = Convert.ToInt32(res.ToString());
                    if (Resultado == 1)
                    {
                        Verificador = 1;
                    }
                    else
                    {
                        Verificador = 0;
                    }
                }
                else
                {
                    Verificador = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AcVehiculo(Vehiculo _veh, ref int verificador)
        {
            try
            {
                object [] valores = {_veh.IDUsuario, _veh.ID_vehiculo,_veh.NombreVeh,_veh.placas,_veh.Descripcion,_veh.opcion};

                object res = SqlHelper.ExecuteScalar(_veh.conexion, "[Cat].[spCSLDB_ABC_ServTintoreria_Vehiculo]", valores);

                if (res.ToString() != "1")
                    verificador = 0;
                else
                    verificador = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
