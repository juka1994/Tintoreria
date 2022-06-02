using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class ColorRopa
    {
        public string ImagenBase64 { get; set; }
        public string Extension { get; set; }
        public bool ImagenModificada { get; set; }

        private int _id_colorRopa;
        public int id_colorRopa
        {
            get { return _id_colorRopa; }
            set { _id_colorRopa = value; }
        }

        private string _descripcion;
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _conexion;
        public string conexion
        {
            get { return _conexion; }
            set { _conexion = value; }
        }

        private DataTable _datos;
        public DataTable datos
        {
            get { return _datos; }
            set { _datos = value; }
        }

        private string _id_u;
        public string id_u
        {
            get { return _id_u; }
            set { _id_u = value; }
        }

        private int _opcion;
        public int opcion
        {
            get { return _opcion; }
            set { _opcion = value; }
        }

       public int a { get; set; }
        public int r { get; set;}
        public int g { get; set; }
        public int b { get; set; }
        public string Color { get; set; }
    }
}
