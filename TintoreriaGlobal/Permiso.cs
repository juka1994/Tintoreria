using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Permiso
    {
        private string _id_permiso;
        public string id_permiso
        {
            get { return _id_permiso; }
            set { _id_permiso = value; }
        }

        public string catalogo { get; set; }

        private int _id_catalogo;

        public int id_catalogo
        {
            get { return _id_catalogo; }
            set { _id_catalogo = value; }
        }

        private string _id_usuario;

        public string id_usuario
        {
            get { return _id_usuario; }
            set { _id_usuario = value; }
        }


        private bool _liberarEquipo;

        public bool liberarEquipo
        {
            get { return _liberarEquipo; }
            set { _liberarEquipo = value; }
        }

        private bool _activoCatalogo;
        public bool activoCatalogo
        {
            get { return _activoCatalogo; }
            set { _activoCatalogo = value; }
        }

        private List<Permiso> _lstPermisosUsuariosCatalogos;
        public List<Permiso> lstPermisosUsuariosCatalogos
        {
            get { return _lstPermisosUsuariosCatalogos; }
            set { _lstPermisosUsuariosCatalogos = value; }
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

        private string _conexion;
        public string conexion
        {
            get { return _conexion; }
            set { _conexion = value; }
        }

        private int _opcion;
        public int opcion
        {
            get { return _opcion; }
            set { _opcion = value; }
        }

        private int _id_tipoUsuario;
        public int id_tipoUsuario
        {
            get { return _id_tipoUsuario; }
            set { _id_tipoUsuario = value; }
        }
    }

}
