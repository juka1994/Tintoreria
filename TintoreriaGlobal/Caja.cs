using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Caja
    {
        public Caja()
        {
            _lstCaja = new List<Caja>();
        }
        private string _id_caja;
        public string id_caja
        {
            get { return _id_caja; }
            set { _id_caja = value; }
        }
        private DateTime _fechaCaja;
        public DateTime fechaCaja
        {
            get { return _fechaCaja; }
            set { _fechaCaja = value; }
        }
        private DateTime _fechaCaja2;
        public DateTime fechaCaja2
        {
            get { return _fechaCaja2; }
            set { _fechaCaja2 = value; }
        }  
        private string _id_equipo;
        public string id_equipo
        {
            get { return _id_equipo; }
            set { _id_equipo = value; }
        }
        private string _id_sucursal;
        public string id_sucursal
        {
            get { return _id_sucursal; }
            set { _id_sucursal = value; }
        }
        private string _CadConexion;
        public string CadConexion
        {
            get { return _CadConexion; }
            set { _CadConexion = value; }
        }
        private float _TotalVentas;
        public float TotalVentas
        {
            get { return _TotalVentas; }
            set { _TotalVentas = value; }
        }
        private float _TotalPedidos;
        public float TotalPedidos
        {
            get { return _TotalPedidos; }
            set { _TotalPedidos = value; }
        }
        private float _TotalCambios;
        public float TotalCambios
        {
            get { return _TotalCambios; }
            set { _TotalCambios = value; }
        }
        private float _TotalCancelaciones;
        public float TotalCancelaciones
        {
            get { return _TotalCancelaciones; }
            set { _TotalCancelaciones = value; }
        }
        private float _TotalCompras;
        public float TotalCompras
        {
            get { return _TotalCompras; }
            set { _TotalCompras = value; }
        }
        private float _TotalInicioCaja;
        public float TotalInicioCaja
        {
            get { return _TotalInicioCaja; }
            set { _TotalInicioCaja = value; }
        }
        private float _TotalDepositos;
        public float TotalDepositos
        {
            get { return _TotalDepositos; }
            set { _TotalDepositos = value; }
        }
        private float _TotalRetirosPagos;
        public float TotalRetirosPagos
        {
            get { return _TotalRetirosPagos; }
            set { _TotalRetirosPagos = value; }
        }
        private float _TotalRetiroCajaLlena;
        public float TotalRetirosCajaLlena
        {
            get { return _TotalRetiroCajaLlena; }
            set { _TotalRetiroCajaLlena = value; }
        }
        private float _TotalFinalCaja;
        public float TotalFinalCaja
        {
            get { return _TotalFinalCaja; }
            set { _TotalFinalCaja = value; }
        }
        private float _TotalCaja;
        public float TotalCaja
        {
            get { return _TotalCaja; }
            set { _TotalCaja = value; }
        }
        private float _TotalEfectivo;
        public float TotalEfectivo
        {
            get { return _TotalEfectivo; }
            set { _TotalEfectivo = value; }
        }
        private float _TotalMonedero;
        public float TotalMonedero
        {
            get { return _TotalMonedero; }
            set { _TotalMonedero = value; }
        }
        private float _TotalTarjetas;
        public float TotalTarjetas
        {
            get { return _TotalTarjetas; }
            set { _TotalTarjetas = value; }
        }
        private float _TotalTransferencia;
        public float TotalTransferencia
        {
            get { return _TotalTransferencia; }
            set { _TotalTransferencia = value; }
        }
        private int _M50C;
        public int M50C
        {
            get { return _M50C; }
            set { _M50C = value; }
        }
        private int _M1P;
        public int M1P
        {
            get { return _M1P; }
            set { _M1P = value; }
        }
        private int _M2P;
        public int M2P
        {
            get { return _M2P; }
            set { _M2P = value; }
        }
        private int _M5P;
        public int M5P
        {
            get { return _M5P; }
            set { _M5P = value; }
        }
        private int _M10P;
        public int M10P
        {
            get { return _M10P; }
            set { _M10P = value; }
        }
        private int _M20P;
        public int M20P
        {
            get { return _M20P; }
            set { _M20P = value; }
        }
        private int _M100P;
        public int M100P
        {
            get { return _M100P; }
            set { _M100P = value; }
        }
        private int _B20P;
        public int B20P
        {
            get { return _B20P; }
            set { _B20P = value; }
        }
        private int _B50P;
        public int B50P
        {
            get { return _B50P; }
            set { _B50P = value; }
        }
        private int _B100P;
        public int B100P
        {
            get { return _B100P; }
            set { _B100P = value; }
        }
        private int _B200P;
        public int B200P
        {
            get { return _B200P; }
            set { _B200P = value; }
        }
        private int _B500P;
        public int B500P
        {
            get { return _B500P; }
            set { _B500P = value; }
        }
        private int _B1000P;
        public int B1000P
        {
            get { return _B1000P; }
            set { _B1000P = value; }
        }
        private float _Total;
        public float Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        private string _FechaIngreso;
        public string FechaIngreso
        {
            get { return _FechaIngreso; }
            set { _FechaIngreso = value; }
        }
        private string _HoraIngreso;
        public string HoraIngreso
        {
            get { return _HoraIngreso; }
            set { _HoraIngreso = value; }
        }
        private string _Id_U;
        public string Id_U
        {
            get { return _Id_U; }
            set { _Id_U = value; }
        }
        private int _tickets;
        public int tickets
        {
            get { return _tickets; }
            set { _tickets = value; }
        }
        private int _vales;
        public int vales
        {
            get { return _vales; }
            set { _vales = value; }
        }
        private string _id_producto;
        public string id_producto
        {
            get { return _id_producto; }
            set { _id_producto = value; }
        }
        private string _observaciones;
        public string observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }
        #region Datos para nueva apertura de caja
        private string _id_cajaCat;
        public string id_cajaCat
        {
            get { return _id_cajaCat; }
            set { _id_cajaCat = value; }
        }
        private string _cajaCat;
        public string cajaCat
        {
            get { return _cajaCat; }
            set { _cajaCat = value; }
        }
        private string _mac;
        public string mac
        {
            get { return _mac; }
            set { _mac = value; }
        }
        private string _nombreCaja;
        public string nombreCaja
        {
            get { return _nombreCaja; }
            set { _nombreCaja = value; }
        }
        private int _opcion;
        public int opcion
        {
            get { return _opcion; }
            set { _opcion = value; }
        }
        private string _nombreUsuario;
        public string nombreUsuario
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = value; }
        }
        private byte[] _logoBuffer;
        public byte[] logoBuffer
        {
            get { return _logoBuffer; }
            set { _logoBuffer = value; }
        }
        private string _turno;
        public string turno
        {
            get { return _turno; }
            set { _turno = value; }
        }
        private List<Caja> _lstCaja;
        public List<Caja> lstCaja
        {
            get { return _lstCaja; }
            set { _lstCaja = value; }
        }      
        #endregion
        private string _cajero;
        public string cajero
        {
            get { return _cajero; }
            set { _cajero = value; }
        }
        private string _urlLogo;
        public string urlLogo
        {
            get { return _urlLogo; }
            set { _urlLogo = value; }
        }
    }
}
