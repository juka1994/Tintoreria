using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class CajaNegocio
    {
        public int GuardarAperturaCaja(Caja caja)
        {
            try
            {
                CajaDatos caja_datos = new CajaDatos();
                return caja_datos.GuardarAperturaCaja(caja);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AgregarDeposito(Movimiento deposito)
        {
            try
            {
                CajaDatos datos = new CajaDatos();
                datos.AgregarDeposito(deposito);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AgregarRetiro(Movimiento retiro)
        {
            try
            {
                CajaDatos datos = new CajaDatos();
                datos.AgregarRetiro(retiro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GuardarMontoTotalEnCaja(Caja caja)
        {
            try
            {
                CajaDatos datos = new CajaDatos();
                return datos.GuardarMontoTotalEnCaja(caja);
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
                CajaDatos datos = new CajaDatos();
                datos.ObtenerCajaXID(caja);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
