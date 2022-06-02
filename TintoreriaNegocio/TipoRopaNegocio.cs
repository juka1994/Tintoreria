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
    public class TipoRopaNegocio
    {
        #region Variables
        private TipoRopaDatos oDatos;
        #endregion

        #region Constructor
        public TipoRopaNegocio()
        {
            this.oDatos = new TipoRopaDatos();
        }
        #endregion
        public TipoRopa ObtenerTipoRopa(TipoRopa Datos)
        {
            try
            {
                TipoRopaDatos Tipo = new TipoRopaDatos();
                return Datos = Tipo.LLenarGridTipoRopa(Datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ACTIpoRopa(TipoRopa Tipo, ref int Verificador)
        {
            try
            {
                TipoRopaDatos TipoDatos = new TipoRopaDatos();
                TipoDatos.ACTipoRopa(Tipo, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarTipoRopa(TipoRopa Tipo, ref int Verificador)
        {
            try
            {
                TipoRopaDatos TipoDatos = new TipoRopaDatos();
                TipoDatos.EliminarTipoRopa(Tipo, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TipoRopa ObtenerImagen(TipoRopa Datos)
        {
            try
            {
                TipoRopaDatos Tipo = new TipoRopaDatos();
                return Datos = Tipo.ObtenerImagen(Datos);
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
    }
}
