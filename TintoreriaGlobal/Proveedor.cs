using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Proveedor
    {
        private string _id_proveedor;
        public string id_proveedor
        {
            get { return _id_proveedor; }
            set { _id_proveedor = value; }
        }

        private string _proveedor;
        public string proveedor
        {
            get { return _proveedor; }
            set { _proveedor = value; }
        }

        private string _direccion;
        public string direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        private string _telefono;
        public string telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        private string _contacto;
        public string contacto
        {
            get { return _contacto; }
            set { _contacto = value; }
        }

        private string _correo;
        public string correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        private bool _sendMail;
        public bool sendMail
        {
            get { return _sendMail; }
            set { _sendMail = value; }
        }

        private string _user;
        public string user
        {
            get { return _user; }
            set { _user = value; }
        }

        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        private int _cambio_pass;
        public int cambio_passs
        {
            get { return _cambio_pass; }
            set { _cambio_pass = value; }
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

        private string _busqueda;
        public string busqueda
        {
            get { return _busqueda; }
            set { _busqueda = value; }
        }

        private int _tipoBusqueda;
        public int tipoBusqueda
        {
            get { return _tipoBusqueda; }
            set { _tipoBusqueda = value; }
        }
    }
}
