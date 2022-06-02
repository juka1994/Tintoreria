using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class TipoFibraRopa
    {
        public bool ImagenModificada { get; set; }
        public TipoFibraRopa()
        {
            _IDFibraRopa = 0;
            _Descripcion = string.Empty;
            _Imagen = string.Empty;
            _TablaDatos = new DataTable();
            Extension = string.Empty;
            Opcion = 0;
            Conexion = string.Empty;
            IDUsuario = string.Empty;
        }

        private int _IDFibraRopa;

        public int IDFibraRopa
        {
            get { return _IDFibraRopa; }
            set { _IDFibraRopa = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _Imagen;

        public string Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }

        private DataTable _TablaDatos;

        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
        }

        public string Extension { get; set; }
        public int Opcion { get; set; }
        public string Conexion { get; set; }
        public string IDUsuario { get; set; }

    }
}
