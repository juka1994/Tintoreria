using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public static class Comun
    {
        public static string TipoSucursal { get; set; }
        public static string UbicacionMacAddress { get; set; }
        public static string DireccionMacAddress { get; set; }

        public static string PathBaseImages { get; set; }

        public const string NOMBRE_SISTEMA = "Sistema Punto de Venta Lavanderia";

        private static DateTime _fechaReinicio;

        public static DateTime fechaReinicio
        {
            get { return _fechaReinicio; }
            set { _fechaReinicio = value; }
        }

        private static int _cantidadVentasTotal;

        public static int cantidadVentasTotal
        {
            get { return _cantidadVentasTotal; }
            set { _cantidadVentasTotal = value; }
        }

        private static string _horaCierre;

        public static string horaCierre
        {
            get { return _horaCierre; }
            set { _horaCierre = value; }
        }

        private static string _horaApertura;

        public static string horaApertura
        {
            get { return _horaApertura; }
            set { _horaApertura = value; }
        }



        private static string _conexion;
        public static string conexion
        {
            get { return _conexion; }
            set { _conexion = value; }
        }
        private static string _id_sucursal;
        public static string id_sucursal
        {
            get { return _id_sucursal; }
            set { _id_sucursal = value; }
        }
        private static int _id_empresa;
        public static int id_empresa
        {
            get { return _id_empresa; }
            set { _id_empresa = value; }
        }
        private static string _id_u;
        public static string id_u
        {
            get { return _id_u; }
            set { _id_u = value; }
        }
        private static int _id_tu;
        public static int id_tu
        {
            get { return _id_tu; }
            set { _id_tu = value; }
        }
        private static string _id_equipo;
        public static string id_equipo
        {
            get { return _id_equipo; }
            set { _id_equipo = value; }
        }
        private static string _namePrinter;
        public static string namePrinter
        {
            get { return _namePrinter; }
            set { _namePrinter = value; }
        }
        private static int _numeroTickets;
        public static int numeroTickets
        {
            get { return _numeroTickets; }
            set { _numeroTickets = value; }
        }
        
        private static string _macAddress;
        public static string macAddress
        {
            get { return _macAddress; }
            set { _macAddress = value; }
        }
        private static string _id_caja;    
        public static string id_caja
        {
            get { return _id_caja; }
            set { _id_caja = value; }
        }
        private static string _u_nombre;
        public static string u_nombre
        {
            get { return _u_nombre; }
            set { _u_nombre = value; }
        }
        private static string _u_apellidoP;
        public static string u_apellidoP
        {
            get { return _u_apellidoP; }
            set { _u_apellidoP = value; }
        }
        private static string _u_apellidoM;
        public static string u_apellidoM
        {
            get { return _u_apellidoM; }
            set { _u_apellidoM = value; }
        }
        private static string _hostName;
        public static string hostName
        {
            get { return _hostName; }
            set { _hostName = value; }
        }
        private static string _nombre_sucursal;
        public static string nombre_sucursal
        {
            get { return _nombre_sucursal; }
            set { _nombre_sucursal = value; }
        }
        private static Ticket _ticket;
        public static Ticket ticket
        {
            get { return _ticket; }
            set { _ticket = value; }
        }
        private static string _turno;
        public static string turno
        {
            get { return _turno; }
            set { _turno = value; }
        }
        private static string _tipoUsuario;
        public static string tipoUsuario
        {
            get { return _tipoUsuario; }
            set { _tipoUsuario = value; }
        }
        private static string _usuariocuenta;
        public static string usuariocuenta
        {
            get { return _usuariocuenta; }
            set { _usuariocuenta = value; }
        }
        private static string _correosistema;
        public static string correosistema
        {
            get { return _correosistema; }
            set { _correosistema = value; }
        }
        private static string _password;
        public static string password
        {
            get { return _password; }
            set { _password = value; }
        }
        private static string _correoelectronico;
        public static string correoelectronico
        {
            get { return _correoelectronico; }
            set { _correoelectronico = value; }
        }
        private static bool _html;
        public static bool html
        {
            get { return _html; }
            set { _html = value; }
        }
        private static string _host;
        public static string host
        {
            get { return _host; }
            set { _host = value; }
        }
        private static int _puerto;
        public static int puerto
        {
            get { return _puerto; }
            set { _puerto = value; }
        }
        private static bool _ssl;
        public static bool ssl
        {
            get { return _ssl; }
            set { _ssl = value; }
        }
        private static DataTable _PermisoUsuario;
        public static DataTable PermisoUsuario
        {
            get { return _PermisoUsuario; }
            set { _PermisoUsuario = value; }
        }
        private static DataTable _notificaciones;
        public static DataTable notificaciones
        {
            get { return _notificaciones; }
            set { _notificaciones = value; }
        }

        private static DataTable _ListaRopa;
        public static DataTable ListaRopa
        {
            get { return _ListaRopa; }
            set { _ListaRopa = value; }
        }

        private static DataTable _ListaChoferes;
        public static DataTable ListaChoferes
        {
            get { return _ListaChoferes; }
            set { _ListaChoferes = value; }
        }

        private static DataTable _ListaLimpieza;
        public static DataTable ListaLimpieza
        {
            get { return _ListaLimpieza; }
            set { _ListaLimpieza = value; }
        }

        private static DataTable _TipoListaRopa;
        public static DataTable TipoListaRopa
        {
            get { return _TipoListaRopa; }
            set { _TipoListaRopa = value; }
        }

        private static DataTable _ColoresRopa;
        public static DataTable ColoresRopa
        {
            get { return _ColoresRopa; }
            set { _ColoresRopa = value; }
        }

        private static Dictionary<string,decimal> _PreciosRopa;
        public static Dictionary<string, decimal> PreciosRopa
        {
            get { return _PreciosRopa; }
            set { _PreciosRopa = value; }
        }

        private static Dictionary<string, decimal> _MonederoRopa;
        public static Dictionary<string, decimal> MonederoRopa
        {
            get { return _MonederoRopa; }
            set { _MonederoRopa = value; }
        }

        private static Dictionary<string, int> _PtosRopa;
        public static Dictionary<string, int> PtosRopa
        {
            get { return _PtosRopa; }
            set { _PtosRopa = value; }
        }

        private static DataTable _EntregasRopa;
        public static DataTable EntregasRopa
        {
            get { return _EntregasRopa; }
            set { _EntregasRopa = value; }
        }

        private static DataTable _EstampadosRopa;
        public static DataTable EstampadosRopa
        {
            get { return _EstampadosRopa; }
            set { _EstampadosRopa = value; }
        }

        private static DataTable _FibrasRopa;
        public static DataTable FibrasRopa
        {
            get { return _FibrasRopa; }
            set { _FibrasRopa = value; }
        }

        private static DataTable _SimbolosRopa;
        public static DataTable SimbolosRopa
        {
            get { return _SimbolosRopa; }
            set { _SimbolosRopa = value; }
        }

        private static DataTable _FechasFestivas;
        public static DataTable FechasFestivas
        {
            get { return _FechasFestivas; }
            set { _FechasFestivas = value; }
        }

        private static decimal _iva;
        public static decimal iva
        {
            get { return _iva; }
            set { _iva = value; }
        }

        private static decimal _PrecioxKgspecial;
        public static decimal PrecioxKgspecial
        {
            get { return _PrecioxKgspecial; }
            set { _PrecioxKgspecial = value; }
        }

        public static DataTable _ListaSucursales;
        public static DataTable ListaSucursales
        {
            get { return _ListaSucursales; }
            set { _ListaSucursales = value; }
        }

        public static DataTable _ListaVehiculos;
        public static DataTable ListaVehiculos
        {
            get { return _ListaVehiculos; }
            set { _ListaVehiculos = value; }
        }

        public static DataTable _ListaEstatus;
        public static DataTable ListaEstatus
        {
            get { return _ListaEstatus; }
            set { _ListaEstatus = value; }
        }

    }
}
