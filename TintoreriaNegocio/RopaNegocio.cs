using System;
using System.Data;
using TintoreriaDatos;
using TintoreriaGlobal;

namespace TintoreriaNegocio
{
    public class RopaNegocio
    {
        #region Variables
        readonly RopaDatos oDatos; 
        #endregion

        #region Constructor
        public RopaNegocio()
        {
            oDatos = new RopaDatos();  
        }
        #endregion

        #region Métodos
        public DataTable GetIndex()
        {
            return oDatos.GetIndex();
        }

        public Ropa GetItem(string id)
        {
            return oDatos.GetItem(id);
        }

        public RespuestaSQL AC(Ropa oRopa, int opcion)
        {
            return oDatos.AC(oRopa, opcion);
        }

        public RespuestaSQL Delete(Ropa oRopa)
        {
            return oDatos.Delete(oRopa);
        }
        #endregion
    }
}
