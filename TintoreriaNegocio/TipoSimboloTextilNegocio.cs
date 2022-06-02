namespace TintoreriaNegocio
{
    using System;
    using System.Data;
    using TintoreriaDatos;
    using TintoreriaGlobal;

    public class TipoSimboloTextilNegocio
    {
        #region Parameters
        private readonly TipoSimboloTextilDatos oDatos;
        #endregion
        #region Constructors
        public TipoSimboloTextilNegocio()
        {
            oDatos = new TipoSimboloTextilDatos();
        }
        #endregion

        #region Methods
        public DataTable GetIndex()
        {
            return oDatos.GetIndex();
        }

        public DataTable GetCombo()
        {
            return oDatos.GetCombo();
        }

        public RespuestaSQL Delete(TipoSimboloTextil oTipoSimboloTextil)
        {
            return oDatos.Delete(oTipoSimboloTextil);
        }

        public TipoSimboloTextil GetItem(int id)
        {
            return oDatos.GetItem(id);
        }

        public RespuestaSQL AC_TipoSimboloTextil(TipoSimboloTextil oTipoSimboloTextil, int opcion)
        {
            return oDatos.AC_TipoSimboloTextil(oTipoSimboloTextil, opcion);
        }
        #endregion
    }
}
