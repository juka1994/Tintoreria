namespace TintoreriaNegocio
{
    using System.Data;
    using TintoreriaDatos;
    using TintoreriaGlobal;

    public class ConversionNegocio
    {
        #region Params
        private readonly ConversionDatos oDatos;
        #endregion

        #region Constructs
        public ConversionNegocio()
        {
            oDatos = new ConversionDatos();
        }
        #endregion

        #region Methods
        public DataTable ObtenerIndex(string idProducto)
        {
            return oDatos.ObtenerIndex(idProducto);
        }
        public Conversion ObtenerItem(int id)
        {
            return oDatos.ObtenerItem(id);
        }
        public DataTable ObtenerCombo()
        {
            return oDatos.ObtenerCombo();
        }
        public RespuestaSQL AC(Conversion oConversion, int opcion)
        {
            return oDatos.AC(oConversion, opcion);
        }
        public RespuestaSQL Del(Conversion oConversion)
        {
            return oDatos.Del(oConversion);
        }
        public DataTable ObtenerComboXIdProducto(string IdProducto)
        {
            return oDatos.ObtenerComboXIdProducto(IdProducto);
        }
        #endregion
    }
}
