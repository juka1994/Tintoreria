namespace TintoreriaDatos
{
    using System.Configuration;

    public class HelperSQL
    {
        protected readonly string ConexionSQL;

        public HelperSQL()
        {
            ConexionSQL = ConfigurationManager.AppSettings.Get("strConnection");
        }
    }
}
