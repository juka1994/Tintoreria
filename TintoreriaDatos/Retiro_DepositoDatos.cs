using System;
using TintoreriaGlobal;
using TintoreriaDatos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationBlocks.Data;

namespace TintoreriaDatos
{
    public class Retiro_DepositoDatos : HelperSQL
    {
        #region Retiros
        public void GuardarRetiro(Retiros _dato, ref int verificador)
        {
            try
            {
                object[] valores = {_dato.id_retiro,_dato.id_sucursal, _dato.id_caja,_dato.id_cajero,_dato.id_tipo,_dato.monto,_dato.motivo};
                object res = SqlHelper.ExecuteScalar(ConexionSQL, "[dbo].[spCSLDB_abc_Retiros]", valores);

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
        #endregion

        #region Depositos
        public void GuardarDeposito(Depositos deb, ref int verificador)
        {
            try
            {
                Object[] valores = {deb.id_deposito, deb.id_caja, deb.id_cajero, deb.monto, deb.motivo, deb.id_sucursal };
                Object res = SqlHelper.ExecuteScalar(ConexionSQL, "[dbo].[spCSLDB_abc_Depositos]", valores);

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
        #endregion
    }
}
