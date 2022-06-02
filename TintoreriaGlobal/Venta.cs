using System.Collections.Generic;
using System.Data;

namespace TintoreriaGlobal
{
    public class Venta
    {
        public RespuestaSQL Respuesta { get; set; }
        public decimal Pagar { get; set; }
        public decimal Pendiente { get; set; }
        public decimal MonederoCliente { get; set; }
        public decimal NuevoMonedero { get; set; }


        private string _id_sucursal;
        public string id_sucursal
        {
            get { return _id_sucursal; }
            set { _id_sucursal = value; }
        }

        private string _id_ventaTemporal;
        public string id_ventaTemporal
        {
            get { return _id_ventaTemporal; }
            set { _id_ventaTemporal = value; }
        }

        private string _textTab;
        public string textTab
        {
            get { return _textTab; }
            set { _textTab = value; }
        }

        private List<VentaProductos> _productosVenta;
        public List<VentaProductos> productosVenta
        {
            get { return _productosVenta; }
            set { _productosVenta = value; }
        }

        private DataTable _tablaProductosVenta;
        public DataTable tablaProductosVenta
        {
            get { return _tablaProductosVenta; }
            set { _tablaProductosVenta = value; }
        }

        private string _dataGridViewName;
        public string dataGridViewName
        {
            get { return _dataGridViewName; }
            set { _dataGridViewName = value; }
        }

        private string _idCliente;
        public string idCliente
        {
            get { return _idCliente; }
            set { _idCliente = value; }
        }

        private FormaPago _pagoCheque;
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

        private decimal _descuento;
        public decimal descuento
        {
            get { return _descuento; }
            set { _descuento = value; }
        }

        private float _iva;
        public float iva
        {
            get { return _iva; }
            set { _iva = value; }
        }

        private decimal _total;
        public decimal total
        {
            get { return _total; }
            set { _total = value; }
        }

        private float _monedero;
        public float monedero
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

    }
}
