using System;
using TintoreriaGlobal;
using TintoreriaDatos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class Retiro_DepositoNegocio
    {
        #region Retiros
        public void GuardarRetiro(Retiros _dat, ref int verificador)
        {
            try
            {
                Retiro_DepositoDatos _RDatos = new Retiro_DepositoDatos();
                _RDatos.GuardarRetiro(_dat, ref verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Deposito
        public void Deposito(Depositos _dep, ref int verificador)
        {
            try
            {
                Retiro_DepositoDatos _Deposito = new Retiro_DepositoDatos();
                _Deposito.GuardarDeposito(_dep, ref verificador);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
