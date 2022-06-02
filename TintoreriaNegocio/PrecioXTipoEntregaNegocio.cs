using System;
using System.Data;
using TintoreriaDatos;
using TintoreriaGlobal;

namespace TintoreriaNegocio
{
    public class PrecioXTipoEntregaNegocio
    {
        #region Variables
        private PrecioXTipoEntregaDatos oDatos;
        #endregion

        #region Constructor
        public PrecioXTipoEntregaNegocio()
        {
            oDatos = new PrecioXTipoEntregaDatos();
        }
        #endregion

        #region Métodos
        public DataTable GetIndex(int id)
        {
            return oDatos.GetIndex(id);
        }

        public PrecioXTipoEntrega GetItem(int id)
        {
            return oDatos.GetItem(id);
        }

        public RespuestaSQL AC(PrecioXTipoEntrega oPrecioXTipoEntrega, int opcion)
        {
            return oDatos.AC(oPrecioXTipoEntrega, opcion);
        }

        public RespuestaSQL Delete(int id)
        {
            return oDatos.Delete(id);
        }
        #endregion
    }
}
