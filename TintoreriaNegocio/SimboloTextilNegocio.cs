namespace TintoreriaNegocio
{
    using System;
    using System.Data;
    using TintoreriaDatos;
    using TintoreriaGlobal;
    public class SimboloTextilNegocio
    {
        #region Parameters
        private SimboloTextilDatos oDatos;
        #endregion

        #region Constructors
        public SimboloTextilNegocio()
        {
            oDatos = new SimboloTextilDatos();
        }
        #endregion
        #region Methods
        public DataTable GetIndex()
        {
            return oDatos.GetIndex();
        }
        public SimboloTextil GetItem(int id)
        {
            return oDatos.GetItem(id);
        }

        public RespuestaSQL AC_SimboloTextil(SimboloTextil oSimboloTextil)
        {
            return oDatos.AC_SimboloTextil(oSimboloTextil);
        }

        public RespuestaSQL Delete(SimboloTextil oSimboloTextil)
        {
            return oDatos.Delete(oSimboloTextil);
        }
        #endregion
    }
}
