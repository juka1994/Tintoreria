using System;
using System.Data;
using TintoreriaDatos;
using TintoreriaGlobal;

namespace TintoreriaNegocio
{
    public class SubTipoRopaNegocio
    {
        #region Constructores
        private readonly SubTipoRopaDatos oDatos;

        public SubTipoRopaNegocio()
        {
            oDatos = new SubTipoRopaDatos();
        }
        #endregion

        #region Métodos
        public DataTable GetIndex()
        {
            return oDatos.GetIndex();
        }

        public RespuestaSQL AC(SubTipoRopa oSubTipoRopa, int opcion)
        {
            return oDatos.AC(oSubTipoRopa, opcion);
        }

        public SubTipoRopa GetSubTipoRopaXId(int id)
        {
            return oDatos.GetSubTipoRopaXId(id);
        }

        public RespuestaSQL Delete(SubTipoRopa subTipo)
        {
            return oDatos.Delete(subTipo);
        }

        public DataTable GetCombo()
        {
            return oDatos.GetCombo();
        }
        #endregion
    }
}
