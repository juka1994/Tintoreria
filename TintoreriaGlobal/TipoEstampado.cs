using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class TipoEstampado
    {
        public bool ImagenModificada { get; set; }
        public TipoEstampado()
        {
            _IDEstampado = 0;
            _Descripcion = string.Empty;
            _TablaDatos = new DataTable();
            _Imagen = string.Empty;
            Conexion = string.Empty;
            IDUsuario = string.Empty;
        }

        private int _IDEstampado;

        public int IDEstampado
        {
            get { return _IDEstampado; }
            set { _IDEstampado = value; }
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
