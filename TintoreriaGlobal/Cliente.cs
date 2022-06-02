using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Cliente
    {
        private string _id_cliente;
        public string id_cliente
        {
            get { return _id_cliente; }
            set { _id_cliente = value; }
        }

        private string _nombre;
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        private string _nombrecompleto;
        public string nombreCompleto
        {
            get { return _nombrecompleto; }
            set { _nombrecompleto = value; }
        }

        private string _apePat;
        public string apePat
        {
            get { return _apePat; }
            set { _apePat = value; }
        }

        private string _apeMat;
        public string apeMat
        {
            get { return _apeMat; }
            set { _apeMat = value; }
        }

        private string _correoElectronico;
        public string correoElectronico
        {
            get { return _correoElectronico; }
            set { _correoElectronico = value; }
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

        private DateTime _fechaNacimiento;
        public DateTime fechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        private string _colonia;
        public string colonia
        {
            get { return _colonia; }
            set { _colonia = value; }
        }

        private int _id_ocupacion;
        public int id_ocupacion
        {
            get { return _id_ocupacion; }
            set { _id_ocupacion = value; }
        }

        private int _id_genero;
        public int id_genero
        {
            get { return _id_genero; }
            set { _id_genero = value; }
        }

        private string _telefono;
        public string telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        private string _curp;
        public string curp
        {
            get { return _curp; }
            set { _curp = value; }
        }

        private bool _solicitado;
        public bool solicitado
        {
            get { return _solicitado; }
            set { _solicitado = value; }
        }

        private bool _entregado;
        public bool entregado
        {
            get { return _entregado; }
            set { _entregado = value; }
        }

        private DateTime _fechaInicio;
        public DateTime fechaInicio
        {
            get { return _fechaInicio; }
            set { _fechaInicio = value; }
        }

        private string _codigoMonedero;
        public string codigoMonedero
        {
            get { return _codigoMonedero; }
            set { _codigoMonedero = value; }
        }
        private string _direccion;
        public string direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        private int _id_tipoEntrega;
        public int id_tipoEntrega
        {
            get { return _id_tipoEntrega; }
            set { _id_tipoEntrega = value; }
        }
        private string _numtransaccion;
        public string numtransaccion
        {
            get { return _numtransaccion; }
            set { _numtransaccion = value; }
        }
        private string _fechatransaccion;
        public string fechatransaccion
        {
            get { return _fechatransaccion; }
            set { _fechatransaccion = value; }
        }
        private string _horatransaccion;
        public string horatransaccion
        {
            get { return _horatransaccion; }
            set { _horatransaccion = value; }
        }
        private string _observaciones;
        public string observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
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

        private Credenciales _credenciales;
        public Credenciales credenciales
        {
            get { return _credenciales; }
            set { _credenciales = value; }
        }

        /*===============CLIENTES CREDENCIALES====================*/

        private string _id_credencial;
        public string id_credencial
        {
            get { return _id_credencial; }
            set { _id_credencial = value; }
        }

        private int _id_tipoCredencial;
        public int id_tipoCredencial
        {
            get { return _id_tipoCredencial; }
            set { _id_tipoCredencial = value; }
        }

        private decimal _monedero;
        public decimal monedero
        {
            get { return _monedero; }
            set { _monedero = value; }
        }

        /*===============TIPO CREDENCIAL====================*/
        private string _descripcion;
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

    }
}
