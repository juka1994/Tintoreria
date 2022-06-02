using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class DesgloseMovimientos
    {
        public DesgloseMovimientos()
        {           
            _Empresas = new Empresa();
        }

        private Empresa _Empresas;
        public Empresa Empresas
        {
            get { return _Empresas; }
            set { _Empresas = value; }
        }

        private string _logo;

        public string logo
        {
            get { return _logo; }
            set { _logo = value; }
        }


        private string _conexion;
        public string conexion
        {
            get { return _conexion; }
            set { _conexion = value; }
        }
        private string _id_sucursal;
        public string id_sucursal
        {
            get { return _id_sucursal; }
            set { _id_sucursal = value; }
        }
        private DateTime _fechaInicio;
        public DateTime fechaInicio
        {
            get { return _fechaInicio; }
            set { _fechaInicio = value; }
        }
        private DateTime _fechaFin;
        public DateTime fechaFin
        {
            get { return _fechaFin; }
            set { _fechaFin = value; }
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
        private float _TotalFinalCaja;
        public float TotalFinalCaja
        {
            get { return _TotalFinalCaja; }
            set { _TotalFinalCaja = value; }
        }        
        private float _TotalDepositos;
        public float TotalDepositos
        {
            get { return _TotalDepositos; }
            set { _TotalDepositos = value; }
        }
        private float _TotalRetiros;
        public float TotalRetiros
        {
            get { return _TotalRetiros; }
            set { _TotalRetiros = value; }
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
        private float _Total;
        public float Total
        {
            get { return _Total; }
            set { _Total = value; }
        }
        private string _id_caja;
        public string id_caja
        {
            get { return _id_caja; }
            set { _id_caja = value; }
        }
        private string _nombre_cliente;
        public string NombreCliente
        {
            get { return _nombre_cliente; }
            set { _nombre_cliente = value; }
        }
        private string _nombre_vendedor;
        public string NombreVendedor
        {
            get { return _nombre_vendedor; }
            set { _nombre_vendedor = value; }
        }
        private float _importe;
        public float Importe
        {
            get { return _importe; }
            set { _importe = value; }
        }
        private float _descuento;
        public float Descuento
        {
            get { return _descuento; }
            set { _descuento = value; }
        }
        private float _iva;
        public float Iva
        {
            get { return _iva; }
            set { _iva = value; }
        }
        private string _fec_venta;
        public string FecVenta
        {
            get { return _fec_venta; }
            set { _fec_venta = value; }
        }
        private string _hor_venta;
        public string HorVenta
        {
            get { return _hor_venta; }
            set { _hor_venta = value; }
        }
        private string _folio;
        public string Folio
        {
            get { return _folio; }
            set { _folio = value; }
        }
        private float _pago;
        public float pago
        {
            get { return _pago; }
            set { _pago = value; }
        }
        private string _tipoVenta;
        public string tipoVenta
        {
            get { return _tipoVenta; }
            set { _tipoVenta = value; }
        }
        private string _motivo;
        public string motivo
        {
            get { return _motivo; }
            set { _motivo = value; }
        }
        private string _sucursal;
        public string sucursal
        {
            get { return _sucursal; }
            set { _sucursal = value; }
        }
        private string _caja;
        public string caja
        {
            get { return _caja; }
            set { _caja = value; }
        }
        private string _id_equipo;
        public string id_equipo
        {
            get { return _id_equipo; }
            set { _id_equipo = value; }
        }
        private float _monto;
        public float monto
        {
            get { return _monto; }
            set { _monto = value; }
        }
        private string _banco;
        public string banco
        {
            get { return _banco; }
            set { _banco = value; }
        }        
        private string _cajero;
        public string NombreCajero
        {
            get { return _cajero; }
            set { _cajero = value; }
        }
        private string _tipoTarjeta;
        public string tipoTarjeta
        {
            get { return _tipoTarjeta; }
            set { _tipoTarjeta = value; }
        }
        private string _autorizacion;
        public string autorizacion
        {
            get { return _autorizacion; }
            set { _autorizacion = value; }
        }
        private string _identificacion;
        public string identificacion
        {
            get { return _identificacion; }
            set { _identificacion = value; }
        }        
        private List<DesgloseMovimientos> _lstVenta;
        public List<DesgloseMovimientos> lstVenta
        {
            get { return _lstVenta; }
            set { _lstVenta = value; }
        }
        private List<DesgloseMovimientos> _lstCaja;
        public List<DesgloseMovimientos> lstCaja
        {
            get { return _lstCaja; }
            set { _lstCaja = value; }
        }
        private List<DesgloseMovimientos> _lstPedido;
        public List<DesgloseMovimientos> lstPedido
        {
            get { return _lstPedido; }
            set { _lstPedido = value; }
        }
        private List<DesgloseMovimientos> _lstCambio;
        public List<DesgloseMovimientos> lstCambio
        {
            get { return _lstCambio; }
            set { _lstCambio = value; }
        }
        private List<DesgloseMovimientos> _lstCancelacion;
        public List<DesgloseMovimientos> lstCancelacion
        {
            get { return _lstCancelacion; }
            set { _lstCancelacion = value; }
        }
        private List<DesgloseMovimientos> _lstCompra;
        public List<DesgloseMovimientos> lstCompra
        {
            get { return _lstCompra; }
            set { _lstCompra = value; }
        }
        private List<DesgloseMovimientos> _lstRetiro;
        public List<DesgloseMovimientos> lstRetiro
        {
            get { return _lstRetiro; }
            set { _lstRetiro = value; }
        }
        private List<DesgloseMovimientos> _lstDeposito;
        public List<DesgloseMovimientos> lstDeposito
        {
            get { return _lstDeposito; }
            set { _lstDeposito = value; }
        }
        private List<DesgloseMovimientos> _lstEfectivo;
        public List<DesgloseMovimientos> lstEfectivo
        {
            get { return _lstEfectivo; }
            set { _lstEfectivo = value; }
        }
        private List<DesgloseMovimientos> _lstTarjeta;
        public List<DesgloseMovimientos> lstTarjeta
        {
            get { return _lstTarjeta; }
            set { _lstTarjeta = value; }
        }
        private List<DesgloseMovimientos> _lstTransferencia;
        public List<DesgloseMovimientos> lstTransferencia
        {
            get { return _lstTransferencia; }
            set { _lstTransferencia = value; }
        }
        private List<DesgloseMovimientos> _lstMonedero;
        public List<DesgloseMovimientos> lstMonedero
        {
            get { return _lstMonedero; }
            set { _lstMonedero = value; }
        }
        
    }
}
