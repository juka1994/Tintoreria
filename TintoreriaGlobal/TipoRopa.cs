namespace TintoreriaGlobal
{
    using System.Data;

    public class TipoRopa
    {
        public bool ImagenModificada { get; set; }
        public TipoRopa()
        {
            IDTipoRopa = 0;
            _Descripcion = string.Empty;
            Conexion = string.Empty;
            IDUsuario = string.Empty;
            Opcion = 0;
        }
        private int _IDTipoRopa;

        public int IDTipoRopa
        {
            get { return _IDTipoRopa; }
            set { _IDTipoRopa = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private DataTable _TablaDatos;

        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }

        private string _Imagen;

        public string Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }
        public string Extension { get; set; }
        public int Opcion { get; set; }
        public string Conexion { get; set; }
        public string IDUsuario { get; set; }
    }
}
