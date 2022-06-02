using System;
using TintoreriaGlobal;
using TintoreriaDatos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class VehiculoNegocio
    {
        public Vehiculo obtenerVehiculo(Vehiculo _datos)
        {
            try
            {
                VehiculoDatos VehDatos = new VehiculoDatos();
                return VehDatos.LLenarGridVehiculo(_datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarVehiculo(Vehiculo _vehiculo, ref int Verificador)
        {
            try
            {
                VehiculoDatos _vehDatos = new VehiculoDatos();
                _vehDatos.EliminarVehiculo(_vehiculo, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AbcVehiculo(Vehiculo _vehiculo, ref int verificador)
        {
            try
            {
                VehiculoDatos _vehDatos = new VehiculoDatos();
                _vehDatos.AcVehiculo(_vehiculo ,ref  verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
