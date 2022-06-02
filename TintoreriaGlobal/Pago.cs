using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Pago
    {
        private string _IDPago;
        public string IDPago
        {
            get { return _IDPago; }
            set { _IDPago = value; }
        }
        private string _IDVenta;
        public string IDVenta
        {
            get { return _IDVenta; }
            set { _IDVenta = value; }
        }
        private string _IDSucursal;
        public string IDSucursal
        {
            get { return _IDSucursal; }
            set { _IDSucursal = value; }
        }
        private string _IDSucursalVenta;
        public string IDSucursalVenta
        {
            get { return _IDSucursalVenta; }
            set { _IDSucursalVenta = value; }
        }
        private string _IDCaja;
        public string IDCaja
        {
            get { return _IDCaja; }
            set { _IDCaja = value; }
        }
        private string _IDCajero;
        public string IDCajero
        {
            get { return _IDCajero; }
            set { _IDCajero = value; }
        }
        private string _SIDFormaPago;
        public string SIDFormaPago
        {
            get { return _SIDFormaPago; }
            set { _SIDFormaPago = value; }
        }
        private string _SPago;
        public string SPago
        {
            get { return _SPago; }
            set { _SPago = value; }
        }
        private decimal _subtotal;
        public decimal subtotal
        {
            get { return _subtotal; }
            set { _subtotal = value; }
        }
        private decimal _iva;
        public decimal iva
        {
            get { return _iva; }
            set { _iva = value; }
        }
        private decimal _descuento;
        public decimal descuento
        {
            get { return _descuento; }
            set { _descuento = value; }
        }
        private decimal _total;
        public decimal total
        {
            get { return _total; }
            set { _total = value; }
        }
        private decimal _pago;
        public decimal pago
        {
            get { return _pago; }
            set { _pago = value; }
        }
        private decimal _cambio;
        public decimal cambio
        {
            get { return _cambio; }
            set { _cambio = value; }
        }
        private decimal _pagado;
        public decimal pagado
        {
            get { return _pagado; }
            set { _pagado = value; }
        }
        private decimal _pendiente;
        public decimal pendiente
        {
            get { return _pendiente; }
            set { _pendiente = value; }
        }
        private string _usuins;
        public string usuins
        {
            get { return _usuins; }
            set { _usuins = value; }
        }
        private int _opcion;
        public int opcion
        {
            get { return _opcion; }
            set { _opcion = value; }
        }
        private bool _validador;
        public bool validador
        {
            get { return _validador; }
            set { _validador = value; }
        }
        private string _conexion;
        public string conexion
        {
            get { return _conexion; }
            set { _conexion = value; }
        }
        private FormaPago _pagoTarjeta;
        public FormaPago pagoTarjeta
        {
            get { return _pagoTarjeta; }
            set { _pagoTarjeta = value; }
        }
        private FormaPago _pagoCheque;
        public FormaPago pagoCheque
        {
            get { return _pagoCheque; }
            set { _pagoCheque = value; }
        }
        private Cliente _cliente;
        public Cliente cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }
        private DateTime _fechaPago;
        public DateTime fechaPago
        {
            get { return _fechaPago; }
            set { _fechaPago = value; }
        }
        private VentaProductos _venta;
        public VentaProductos venta
        {
            get { return _venta; }
            set { _venta = value; }
        }
        private decimal _totalVenta;
        public decimal totalVenta
        {
            get { return _totalVenta; }
            set { _totalVenta = value; }
        }
        private decimal _pagoEfectivo;
        public decimal pagoEfectivo
        {
            get { return _pagoEfectivo; }
            set { _pagoEfectivo = value; }
        }
        private decimal _pagoTarjetas;
        public decimal pagoTarjetas
        {
            get { return _pagoTarjetas; }
            set { _pagoTarjetas = value; }
        }
        private decimal _pagoCheques;
        public decimal pagoCheques
        {
            get { return _pagoCheques; }
            set { _pagoCheques = value; }
        }
        private decimal _pagoMonedero;
        public decimal pagoMonedero
        {
            get { return _pagoMonedero; }
            set { _pagoMonedero = value; }
        }
        private string _folio;
        public string folio
        {
            get { return _folio; }
            set { _folio = value; }
        }
        private string _vendedor;
        public string vendedor
        {
            get { return _vendedor; }
            set { _vendedor = value; }
        }
    }
}
