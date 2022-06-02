using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class VentaTintoreria
    {

        private bool _isMonedero;
        public bool isMonedero
        {
            get { return _isMonedero; }
            set { _isMonedero = value; }
        }


        private bool _banBloqueoMultipleFormasPago;
        public bool banBloqueoMultipleFormasPago
        {
            get { return _banBloqueoMultipleFormasPago; }
            set { _banBloqueoMultipleFormasPago = value; }
        }

        private decimal _PagoEfectivo;
        public decimal PagoEfectivo
        {
            get { return _PagoEfectivo; }
            set { _PagoEfectivo = value; }
        }

        private decimal _PagoMonedero;
        public decimal PagoMonedero
        {
            get { return _PagoMonedero; }
            set { _PagoMonedero = value; }
        }
        
        private decimal _PagoTarjeta;
        public decimal PagoTarjeta
        {
            get { return _PagoTarjeta; }
            set { _PagoTarjeta = value; }
        }

        private decimal _PagoTransferencia;
        public decimal PagoTransferencia
        {
            get { return _PagoTransferencia; }
            set { _PagoTransferencia = value; }
        }

       

        private bool _aplicar3X1;

        public bool aplicar3X1
        {
            get { return _aplicar3X1; }
            set { _aplicar3X1 = value; }
        }


        private bool _isGratis;

        public bool isGratis
        {
            get { return _isGratis; }
            set { _isGratis = value; }
        }

        private bool _isReproceso;

        public bool isReproceso
        {
            get { return _isReproceso; }
            set { _isReproceso = value; }
        }

        private int _idtipopagoinicial;

        public int idtipopagoinicial
        {
            get { return _idtipopagoinicial; }
            set { _idtipopagoinicial = value; }
        }

        private string _id_sucursal;
        public string id_sucursal
        {
            get { return _id_sucursal; }
            set { _id_sucursal = value; }
        }
        
        
        //Datatable de ropa que se agrego en el servicio
        private DataTable _tablaRopaServicio;
        public DataTable tablaRopaServicio
        {
            get { return _tablaRopaServicio; }
            set { _tablaRopaServicio = value; }
        }

        private DataTable _DatosTarjeta;
        public DataTable DatosTarjeta
        {
            get { return _DatosTarjeta; }
            set { _DatosTarjeta = value; }
        }


        private DataTable _DatosTransferencia;
        public DataTable DatosTransferencia
        {
            get { return _DatosTransferencia; }
            set { _DatosTransferencia = value; }
        }


        private string _idCliente;
        public string idCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }

        /*private FormaPago _pagoCheque;
        public FormaPago pagoCheque
        {
            get { return _pagoCheque; }
            set { _pagoCheque = value; }
        }

        private FormaPago _pagoTarjeta;
        public FormaPago pagoTarjeta
        {
            get { return _pagoTarjeta; }
            set { _pagoTarjeta = value; }
        }

        private FormaPago _pagoMonedero;
        public FormaPago pagoMonedero
        {
            get { return _pagoMonedero; }
            set { _pagoMonedero = value; }
        }

        private FormaPago _pagoEfectivo;
        public FormaPago pagoEfectivo
        {
            get { return _pagoEfectivo; }
            set { _pagoEfectivo = value; }
        }
        */


        private Cliente _cliente;
        public Cliente cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        private bool _bandPrecioMayoreo;
        public bool bandPrecioMayoreo
        {
            get { return _bandPrecioMayoreo; }
            set { _bandPrecioMayoreo = value; }
        }

        private Vales _vale;
        public Vales vale
        {
            get { return _vale; }
            set { _vale = value; }
        }

        private float _subTotal;
        public float subTotal
        {
            get { return _subTotal; }
            set { _subTotal = value; }
        }
        
        private float _descuento;
        public float descuento
        {
            get { return _descuento; }
            set { _descuento = value; }
        }


        private float _descuentoGeneral;
        public float descuentoGeneral
        {
            get { return _descuentoGeneral; }
            set { _descuentoGeneral = value; }
        }


        private float _iva;
        public float iva
        {
            get { return _iva; }
            set { _iva = value; }
        }

        private float _total;
        public float total
        {
            get { return _total; }
            set { _total = value; }
        }

        private decimal _monedero;
        public decimal monedero
        {
            get { return _monedero; }
            set { _monedero = value; }
        }

        private int _puntos;
        public int puntos
        {
            get { return _puntos; }
            set { _puntos = value; }
        }

       

        private int cantidadServicios;
        public int _cantidadServicios
        {
            get { return cantidadServicios; }
            set { cantidadServicios = value; }
        }


        private string _id_ventaServicio;
        private int _id_tipoServicio;
        private int _id_tipocredencial;
        private string _folio;
        private DateTime _fec_ventaServicio;
        private string _hor_ventaServicio;
        private string _id_caja;
        private string _id_vendedor;
        private string _id_cajero;
        private decimal _pago;
        private decimal _cambio;
        private float _pendiente;
        private string _latitud;
        private string _longitud;
        private int _id_statusServicio;
        private int _idTipoEntrega;
        private int _idformaEntrega;
        private string _usuChofer;
        private string _comentarios;
        private bool _esWeb;
        private bool _esApp;
        private int _horasasignadas;
        private DateTime _fechaEntrega;
        private string _horaEntrega;
        private int _cantidadprendas;
        private float _totalkilogramos;
        private DateTime _fechaRecargo;
        private bool _recargo;
        private string _usurec;
       
        private bool _entregado;
        private string _usuent;
        private bool _terminado;
        private DateTime _fecTerminado;
        private string _usuter;
        private string _usuario;
        private Dictionary<string, string> _listaDeSimbolos;


        public string Id_ventaServicio { get => _id_ventaServicio; set => _id_ventaServicio = value; }
        public int Id_tipoServicio { get => _id_tipoServicio; set => _id_tipoServicio = value; }
        public int Id_tipocredencial { get => _id_tipocredencial; set => _id_tipocredencial = value; }
        public string Folio { get => _folio; set => _folio = value; }
        public DateTime Fec_ventaServicio { get => _fec_ventaServicio; set => _fec_ventaServicio = value; }
        public string Hor_ventaServicio { get => _hor_ventaServicio; set => _hor_ventaServicio = value; }
        public string Id_caja { get => _id_caja; set => _id_caja = value; }
        public string Id_vendedor { get => _id_vendedor; set => _id_vendedor = value; }
        public string Id_cajero { get => _id_cajero; set => _id_cajero = value; }
        public decimal Pago { get => _pago; set => _pago = value; }
        public decimal Cambio { get => _cambio; set => _cambio = value; }
        public float Pendiente { get => _pendiente; set => _pendiente = value; }
        public string Latitud { get => _latitud; set => _latitud = value; }
        public string Longitud { get => _longitud; set => _longitud = value; }
        public int Id_statusServicio { get => _id_statusServicio; set => _id_statusServicio = value; }
        public int IdTipoEntrega { get => _idTipoEntrega; set => _idTipoEntrega = value; }
        public int IdformaEntrega { get => _idformaEntrega; set => _idformaEntrega = value; }
        public string UsuChofer { get => _usuChofer; set => _usuChofer = value; }
        public string Comentarios { get => _comentarios; set => _comentarios = value; }
        public bool EsWeb { get => _esWeb; set => _esWeb = value; }
        public bool EsApp { get => _esApp; set => _esApp = value; }
        public int Horasasignadas { get => _horasasignadas; set => _horasasignadas = value; }
        public DateTime FechaEntrega { get => _fechaEntrega; set => _fechaEntrega = value; }
        public string HoraEntrega { get => _horaEntrega; set => _horaEntrega = value; }
        public int Cantidadprendas { get => _cantidadprendas; set => _cantidadprendas = value; }
        public float Totalkilogramos { get => _totalkilogramos; set => _totalkilogramos = value; }
        public DateTime FechaRecargo { get => _fechaRecargo; set => _fechaRecargo = value; }
        public bool Recargo { get => _recargo; set => _recargo = value; }
        public string Usurec { get => _usurec; set => _usurec = value; }
        
        public bool Entregado { get => _entregado; set => _entregado = value; }
        public string Usuent { get => _usuent; set => _usuent = value; }
        public bool Terminado { get => _terminado; set => _terminado = value; }
        public DateTime FecTerminado { get => _fecTerminado; set => _fecTerminado = value; }
        public string Usuter { get => _usuter; set => _usuter = value; }
        public string Usuario { get => _usuario; set => _usuario = value; }
        public Dictionary<string, string> ListaDeSimbolos { get => _listaDeSimbolos; set => _listaDeSimbolos = value; }
    }
}
