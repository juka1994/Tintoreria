using System;
using TintoreriaDatos;
using TintoreriaGlobal;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TintoreriaNegocio
{
   public class TipoEntregaNegocio
    {
        #region Variables
        private TipoEntregaDatos oDatos;
        #endregion

        #region Constructor
        public TipoEntregaNegocio()
        {
            this.oDatos = new TipoEntregaDatos();
        }
        #endregion

        #region Métodos
        public TipoEntrega LLenarDatosGrid(TipoEntrega _Datos)
        {
            try
            {
                TipoEntregaDatos _tipoDatos = new TipoEntregaDatos();
                return _tipoDatos.LLenarDatosGrid(_Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ABCTipoEntrega(TipoEntrega _datos, ref int verificador)
        {
            try
            {
                TipoEntregaDatos _tipoNegocio = new TipoEntregaDatos();
                _tipoNegocio.ABCTipoEntrega(_datos, ref verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetCombo()
        {
            return oDatos.GetCombo();
        }
        #endregion
    }
}
