namespace TintoreriaNegocio
{
    using TintoreriaDatos;
    using TintoreriaGlobal;
    using System;

    public class ColorRopaNegocio
    {
        private readonly ColorRopaDatos oDatos;

        #region Constructors
        public ColorRopaNegocio()
        {
            oDatos = new ColorRopaDatos();
        }
        #endregion

        #region Methods
        public void llenarGridColorRopa(ColorRopa colorRopa)
        {
            try
            {
                ColorRopaDatos colorRopa_datos = new ColorRopaDatos();
                colorRopa_datos.LLenarGridColorRopa(colorRopa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public RespuestaSQL AbcColorRopa(ColorRopa colorRopa)
        {
            return oDatos.AbcColorRopa(colorRopa);
        }
        public void ObtenerComboColorRopa(ColorRopa colorRopa)
        {
            try
            {
                ColorRopaDatos colorRopa_datos = new ColorRopaDatos();
                colorRopa_datos.ObtenerComboColorRopa(colorRopa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ColorRopa GetItem(int id)
        {
            return oDatos.GetItem(id);
        }
        public RespuestaSQL Delete(ColorRopa oColorRopa)
        {
            return oDatos.Delete(oColorRopa);
        }
        #endregion

    }
}
