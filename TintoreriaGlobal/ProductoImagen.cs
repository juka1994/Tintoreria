using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class ProductoImagen
    {
        private string _IdImagen;

        public string IdImagnen
        {
            get { return _IdImagen; }
            set { _IdImagen = value; }
        }

        private string _IdProducto;

        public string IdProducto
        {
            get { return _IdProducto; }
            set { _IdProducto = value; }
        }

        private string _UrlImagen;

        public string UrlImagen
        {
            get { return _UrlImagen; }
            set { _UrlImagen = value; }
        }

        private string _UrlImagenMin;

        public string UrlImagenMin
        {
            get { return _UrlImagenMin; }
            set { _UrlImagenMin = value; }
        }
        
        private string _Alt;

        public string Alt
        {
            get { return _Alt; }
            set { _Alt = value; }
        }

        private string _Title;

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _NombreArc;

        public string NombreArc
        {
            get { return _NombreArc; }
            set { _NombreArc = value; }
        }

        private string _TipoArc;

        public string TipoArc
        {
            get { return _TipoArc; }
            set { _TipoArc = value; }
        }

        private string _Imagen;

        public string imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }




        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _Conexion;

        public string Conexion
        {
            get { return _Conexion; }
            set { _Conexion = value; }
        }

        private DataTable _TablaDatos;
        public DataTable TablaDatos
        {
            get { return _TablaDatos; }
            set { _TablaDatos = value; }
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

        private bool _Completado;

        public bool Completado
        {
            get { return _Completado; }
            set { _Completado = value; }
        }
        
    }
}
