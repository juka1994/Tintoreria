using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class VentaProductos
    {
        public VentaProductos()
        {
            Activo = true;
        }

        private string _StrCnx;
        public string StrCnx
        {
            get { return _StrCnx; }
            set { _StrCnx = value; }
        }
        private float _Monedero;
        public float Monedero
        {
            get { return _Monedero; }
            set { _Monedero = value; }
        }

        private int _puntos;
        public int puntos
        {
            get { return _puntos; }
            set { _puntos = value; }
        }
        private int _tabIndex;
        public int tabIndex
        {
            get { return _tabIndex; }
            set { _tabIndex = value; }
        }                
        // ---------------------------------
        // tbl_CatFamilias
        // ---------------------------------
        private int _id_familia;
        public int IDFamilia
        {
            get { return _id_familia; }
            set { _id_familia = value; }
        }
        private string _descripcion;
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        // ---------------------------------
        // tbl_CatProductos
        // ---------------------------------
        private string _id_producto;
        public string IDProducto
        {
            get { return _id_producto; }
            set { _id_producto = value; }
        }
        private int _id_tallaRopa;
        public int IDTallaRopa
        {
            get { return _id_tallaRopa; }
            set { _id_tallaRopa = value; }
        }
        private int _id_colorRopa;
        public int IDColorRopa
        {
            get { return _id_colorRopa; }
            set { _id_colorRopa = value; }
        }
        
        private int _id_tipoProducto;
        public int IDTipoProducto
        {
            get { return _id_tipoProducto; }
            set { _id_tipoProducto = value; }
        }
        private float _costo_ultimo;
        public float CostoUltimo
        {
            get { return _costo_ultimo; }
            set { _costo_ultimo = value; }
        }
        private decimal _precio;
        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        private int _existencia;
        public int Existencia
        {
            get { return _existencia; }
            set { _existencia = value; }
        }
        private int _inventario_optimo;
        public int InventarioOptimo
        {
            get { return _inventario_optimo; }
            set { _inventario_optimo = value; }
        }
        private int _dias_inventario;
        public int DiasInventario
        {
            get { return _dias_inventario; }
            set { _dias_inventario = value; }
        }
        private string _nombre_producto;
        public string NombreProducto
        {
            get { return _nombre_producto; }
            set { _nombre_producto = value; }
        }
        private bool _activo;
        public bool Activo
        {
            get { return _activo; }
            set { _activo = value; }
        }
        private int _id_unidadMedida;
        public int IDUnidadMedida
        {
            get { return _id_unidadMedida; }
            set { _id_unidadMedida = value; }
        }
        private string _pathimg;
        public string Pathimg
        {
            get { return _pathimg; }
            set { _pathimg = value; }
        }
        private string _usuins;
        public string Usuins
        {
            get { return _usuins; }
            set { _usuins = value; }
        }
        private DateTime _fecins;
        public DateTime Fecins
        {
            get { return _fecins; }
            set { _fecins = value; }
        }
        private string _usuupd;
        public string Usuupd
        {
            get { return _usuupd; }
            set { _usuupd = value; }
        }
        private DateTime _fecupd;
        public DateTime Fecupd
        {
            get { return _fecupd; }
            set { _fecupd = value; }
        }
        // ---------------------------------
        // tbl_CatSucursales
        // ---------------------------------
        private string _id_sucursal;
        public string IDSucursal
        {
            get { return _id_sucursal; }
            set { _id_sucursal = value; }
        }
        // ---------------------------------
        // tbl_CatCodBarProd
        // ---------------------------------
        private string _id_codigoEan;
        public string IDCodigoEan
        {
            get { return _id_codigoEan; }
            set { _id_codigoEan = value; }
        }
        private int _id_status;
        public int IDStatus
        {
            get { return _id_status; }
            set { _id_status = value; }
        }
        // ---------------------------------
        // tbl_Venta
        // ---------------------------------
        private string _id_venta;
        public string IDVenta
        {
            get { return _id_venta; }
            set { _id_venta = value; }
        }
        private int _id_tipoDispositivo;
        public int IDTipoDispositivo
        {
            get { return _id_tipoDispositivo; }
            set { _id_tipoDispositivo = value; }
        }        
        private DateTime _fec_venta;
        public DateTime FecVenta
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
        private int? _id_tipoVenta;
        public int? IDTipoVenta
        {
            get { return _id_tipoVenta; }
            set { _id_tipoVenta = value; }
        }
        private string _id_cliente;
        public string IDCliente
        {
            get { return _id_cliente; }
            set { _id_cliente = value; }
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
        private string _id_caja;
        public string IDCaja
        {
            get { return _id_caja; }
            set { _id_caja = value; }
        }
        private string _id_vendedor;
        public string IDVendedor
        {
            get { return _id_vendedor; }
            set { _id_vendedor = value; }
        }
        private string _id_cajero;
        public string IDCajero
        {
            get { return _id_cajero; }
            set { _id_cajero = value; }
        }
        private float _importe;
        public float Importe
        {
            get { return _importe; }
            set { _importe = value; }
        }
        private decimal _descuento;
        public decimal Descuento
        {
            get { return _descuento; }
            set { _descuento = value; }
        }
        private decimal _iva;
        public decimal Iva
        {
            get { return _iva; }
            set { _iva = value; }
        }
        private decimal _total;
        public decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }
        private decimal _subtotal;
        public decimal Subtotal
        {
            get { return _subtotal; }
            set { _subtotal = value; }
        }
        private decimal _pago;
        public decimal Pago
        {
            get { return _pago; }
            set { _pago = value; }
        }

        private decimal _pagoEfectivo;
        public decimal PagoEfectivo
        {
            get { return _pagoEfectivo; }
            set { _pagoEfectivo = value; }
        }
        private decimal _pagoMonedero;
        public decimal PagoMonedero
        {
            get { return _pagoMonedero; }
            set { _pagoMonedero = value; }
        }
        private decimal _pagoTarjeta;
        public decimal PagoTarjeta
        {
            get { return _pagoTarjeta; }
            set { _pagoTarjeta = value; }
        }
        private decimal _pagoTransferencia;
        public decimal PagoTransferencia
        {
            get { return _pagoTransferencia; }
            set { _pagoTransferencia = value; }
        }
        private bool _banBloqueoMultipleFormasPago;
        public bool banBloqueoMultipleFormasPago
        {
            get { return _banBloqueoMultipleFormasPago; }
            set { _banBloqueoMultipleFormasPago = value; }
        }
        private decimal _cambio;
        public decimal Cambio
        {
            get { return _cambio; }
            set { _cambio = value; }
        }
        private float _adeudo;
        public float adeudo
        {
            get { return _adeudo; }
            set { _adeudo = value; }
        }
        private DataTable _datos;
        public DataTable datos
        {
            get { return _datos; }
            set { _datos = value; }
        }
        private string _conexion;
        public string conexion
        {
            get { return _conexion; }
            set { _conexion = value; }
        }
        private string _id_u;
        public string id_u
        {
            get { return _id_u; }
            set { _id_u = value; }
        }
        private string _busqueda;
        public string busqueda
        {
            get { return _busqueda; }
            set { _busqueda = value; }
        }
        private string _fecha;
        public string fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        private int _tipoBusqueda;
        public int tipoBusqueda
        {
            get { return _tipoBusqueda; }
            set { _tipoBusqueda = value; }
        }

        private decimal _Penalizacion;
        public decimal Penalizacion
        {
            get { return _Penalizacion; }
            set { _Penalizacion = value; }
        }

        private int _idMotivoCancelacion;

        public int idMotivoCancelacion
        {
            get { return _idMotivoCancelacion; }
            set { _idMotivoCancelacion = value; }
        }

        // ---------------------------------
        // tbl_VentaDetalle
        // ---------------------------------
        private string _id_ventadetalle;
        public string IDVentadetalle
        {
            get { return _id_ventadetalle; }
            set { _id_ventadetalle = value; }
        }
        private int? _cantidad_venta;
        public int? CantidadVenta
        {
            get { return _cantidad_venta; }
            set { _cantidad_venta = value; }
        }
        private int? _cantidad_devolucion;
        public int? CantidadDevolucion
        {
            get { return _cantidad_devolucion; }
            set { _cantidad_devolucion = value; }
        }
        private float? _costo;
        public float? Costo
        {
            get { return _costo; }
            set { _costo = value; }
        }
        private float? _porcentaje_desc;
        public float? PorcentajeDesc
        {
            get { return _porcentaje_desc; }
            set { _porcentaje_desc = value; }
        }
        private decimal? _porcentaje_iva;
        public decimal? PorcentajeIva
        {
            get { return _porcentaje_iva; }
            set { _porcentaje_iva = value; }
        }
        private float? _porcentaje_ivaMayoreo;
        public float? PorcentajeIvaMayoreo
        {
            get { return _porcentaje_ivaMayoreo; }
            set { _porcentaje_ivaMayoreo = value; }
        }
        // ---------------------------------
        // tbl_VentaDetalleDescuento
        // ---------------------------------
        private string id_descuentoxdetalle;
        public string IDDescuentoxdetalle
        {
            get { return id_descuentoxdetalle; }
            set { id_descuentoxdetalle = value; }
        }
        private string id_descuento;
        public string IDDescuento
        {
            get { return id_descuento; }
            set { id_descuento = value; }
        }
        private int? id_tipoPromocion;
        public int? IDTipoPromocion
        {
            get { return id_tipoPromocion; }
            set { id_tipoPromocion = value; }
        }
        private int? porcenta_desc;
        public int? PorcentaDesc
        {
            get { return porcenta_desc; }
            set { porcenta_desc = value; }
        }
        // ---------------------------------
        // tbl_VentaxFormaPago
        // ---------------------------------
        private string id_ventaxformapag;
        public string IDVentaxformapag
        {
            get { return id_ventaxformapag; }
            set { id_ventaxformapag = value; }
        }
        private int id_formaPago;
        public int IDFormaPago
        {
            get { return id_formaPago; }
            set { id_formaPago = value; }
        }
        private string sid_formaPago;
        public string SIDFormaPago
        {
            get { return sid_formaPago; }
            set { sid_formaPago = value; }
        }
        private string dato;
        public string Dato
        {
            get { return dato; }
            set { dato = value; }
        }
        // ---------------------------------
        // tbl_Vales
        // ---------------------------------
        private string _id_vale;
        public string IDVale
        {
            get { return _id_vale; }
            set { _id_vale = value; }
        }

        private string _descripcionVale;
        public string DescripcionVale
        {
            get { return _descripcionVale; }
            set { _descripcionVale = value; }
        }

        private int _id_tipoVale;
        public int IDTipoVale
        {
            get { return _id_tipoVale; }
            set { _id_tipoVale = value; }
        }

        private int _regla;
        public int Regla
        {
            get { return _regla; }
            set { _regla = value; }
        }

        private decimal _descuentoVale;
        public decimal DescuentoVale
        {
            get { return _descuentoVale; }
            set { _descuentoVale = value; }
        }

        private DateTime _vigencia;
        public DateTime Vigencia
        {
            get { return _vigencia; }
            set { _vigencia = value; }
        }
        private string _folio;
        public string Folio
        {
            get { return _folio; }
            set { _folio = value; }
        }

        private bool _estatus;
        public bool Estatus
        {
            get { return _estatus; }
            set { _estatus = value; }
        }
        // ---------------------------------
        // tbl_CatProdGratis
        // ---------------------------------
        private string _id_reglaVale;
        public string IDReglaVale
        {
            get { return _id_reglaVale; }
            set { _id_reglaVale = value; }
        }
        private string _id_productoG;
        public string IDProductoG
        {
            get { return _id_productoG; }
            set { _id_productoG = value; }
        }
        private int _cantidadGratis;
        public int CantidadGratis
        {
            get { return _cantidadGratis; }
            set { _cantidadGratis = value; }
        }
        private string _id_venta_text;
        public string IDVentaText
        {
            get { return _id_venta_text; }
            set { _id_venta_text = value; }
        }
        private string _activoText;
        public string ActivoText
        {
            get { return _activoText; }
            set { _activoText = value; }
        }

        private string _observaciones;
        public string observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }

        private DataTable _ventastoday;
        public DataTable ventastoday
        {
            get { return _ventastoday; }
            set { _ventastoday = value; }
        }

        private DataTable _ventadetalle;
        public DataTable ventadetalle
        {
            get { return _ventadetalle; }
            set { _ventadetalle = value; }
        }

        private string _nameTab;
        public string nameTab
        {
            get { return _nameTab; }
            set { _nameTab = value; }
        }

        private int _validador;
        public int validador
        {
            get { return _validador; }
            set { _validador = value; }
        }

        private List<Venta> _lista;
        public List<Venta> lista
        {
            get { return _lista; }
            set { _lista = value; }
        }

        private List<VentaProductos> _listaDetalle;
        public List<VentaProductos> listaDetalle
        {
            get { return _listaDetalle; }
            set { _listaDetalle = value; }
        }

        private decimal _Pendiente;
        public decimal Pendiente
        {
            get { return _Pendiente; }
            set { _Pendiente = value; }
        }

        private bool _BITentregado;
        public bool BITentregado
        {
            get { return _BITentregado; }
            set { _BITentregado = value; }
        }

        private string _txtEstatus;
        public string txtEstatus
        {
            get { return _txtEstatus; }
            set { _txtEstatus = value; }
        }


        private float _PrecioMayoreo;
        public float PrecioMayoreo
        {
            get { return _PrecioMayoreo; }
            set { _PrecioMayoreo = value; }
        }

        private int _CantidadMayoreo;
        public int CantidadMayoreo
        {
            get { return _CantidadMayoreo; }
            set { _CantidadMayoreo = value; }
        }

        private float _PrecioVenta;
        public float PrecioVenta
        {
            get { return _PrecioVenta; }
            set { _PrecioVenta = value; }
        }

        private bool _BandPrecioMayoreo;
        public bool BandPrecioMayoreo
        {
            get { return _BandPrecioMayoreo; }
            set { _BandPrecioMayoreo = value; }
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

        private Vales _Vale;
        public Vales Vale
        {
            get { return _Vale; }
            set { _Vale = value; }
        }

        //Operaciones para cancelacion
        private DataTable _CancelacionDetalle;
        public DataTable CancelacionDetalle
        {
            get { return _CancelacionDetalle; }
            set { _CancelacionDetalle = value; }
        }

        private string _motivo;
        public string motivo
        {
            get { return _motivo; }
            set { _motivo = value; }
        }

        private string _cantidadprendas;
        public string CantidadPrendas
        {
            get { return _cantidadprendas; }
            set { _cantidadprendas = value; }
        }

        private DateTime _fechaCancelacion;
        public DateTime fechaCancelacion
        {
            get { return _fechaCancelacion; }
            set { _fechaCancelacion = value; }
        }


        private string _horaEntrega;
        public string HoraEntrega
        {
            get { return _horaEntrega; }
            set { _horaEntrega = value; }
        }

        private bool _entregado;
        public bool Entregado
        {
            get { return _entregado; }
            set { _entregado = value; }
        }

        private DateTime _fec_entrega;
        public DateTime FecEntrega
        {
            get { return _fec_entrega; }
            set { _fec_entrega = value; }
        }

        private Cambio _cambioModulo;
        public Cambio cambioModulo
        {
            get { return _cambioModulo; }
            set { _cambioModulo = value; }
        }
        private bool _terminado;
        public bool terminado
        {
            get { return _terminado; }
            set { _terminado = value; }
        }        
    }
}
