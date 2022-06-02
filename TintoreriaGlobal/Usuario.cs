using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Usuario
    {
        private string _id_usuario;
        public string id_usuario
        {
            get { return _id_usuario; }
            set { _id_usuario = value; }
        }
        private string _id_sucursal;
        public string id_sucursal
        {
            get { return _id_sucursal; }
            set { _id_sucursal = value; }
        }
        private int _id_tipoUsuario;
        public int id_tipoUsuario
        {
            get { return _id_tipoUsuario; }
            set { _id_tipoUsuario = value; }
        }
        private string _nombre;
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        private string _apellidoPat;
        public string apellidoPat
        {
            get { return _apellidoPat; }
            set { _apellidoPat = value; }
        }
        private string _apellidoMat;
        public string apellidoMat
        {
            get { return _apellidoMat; }
            set { _apellidoMat = value; }
        }
        private DateTime _fechaNacimiento;
        public DateTime fechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }
        private string _telefono;
        public string telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        private int _id_pais;
        public int id_pais
        {
            get { return _id_pais; }
            set { _id_pais = value; }
        }
        private int _id_estado;
        public int id_estado
        {
            get { return _id_estado; }
            set { _id_estado = value; }
        }
        private int _id_municipio;
        public int id_municipio
        {
            get { return _id_municipio; }
            set { _id_municipio = value; }
        }
        private string _direccion;
        public string direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        private int _id_turno;
        public int id_turno
        {
            get { return _id_turno; }
            set { _id_turno = value; }
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
        private DateTime _fCaducidad;
        public DateTime fCaducidad
        {
            get { return _fCaducidad; }
            set { _fCaducidad = value; }
        }
        private int _conInt;
        public int conInt
        {
            get { return _conInt; }
            set { _conInt = value; }
        }
        private bool _estatus;
        public bool estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }
        private DateTime _fBloq;
        public DateTime fBloq
        {
            get { return _fBloq; }
            set { _fBloq = value; }
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
        private Permiso _permisosUsuariosCatalogos;
        public Permiso permisosUsuariosCatalogos
        {
            get { return _permisosUsuariosCatalogos; }
            set { _permisosUsuariosCatalogos = value; }
        }
        private bool _permisoCargados;
        public bool permisoCargados
        {
            get { return _permisoCargados; }
            set { _permisoCargados = value; }
        }
        private string _descripcion;
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        private int _Validador;
        public int Validador
        {
            get { return _Validador; }
            set { _Validador = value; }
        }
        private bool _crearid_caja;
        public bool crearid_caja
        {
            get { return _crearid_caja; }
            set { _crearid_caja = value; }
        }
        private bool _cuentaCaducada;
        public bool cuentaCaducada
        {
            get { return _cuentaCaducada; }
            set { _cuentaCaducada = value; }
        }
        private string _idcaja;
        public string idcaja
        {
            get { return _idcaja; }
            set { _idcaja = value; }
        }
        private string _id_u;
        public string id_u
        {
            get { return _id_u; }
            set { _id_u = value; }
        }
        private DataTable _PermisoUsuario;
        public DataTable PermisoUsuario
        {
            get { return _PermisoUsuario; }
            set { _PermisoUsuario = value; }
        }
    }
}
