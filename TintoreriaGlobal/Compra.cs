using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Compra
    {
        public Compra()
        {
            _compraDetalle = new CompraDetalle();
        }
        private string _id_compra;
        public string id_compra
        {
            get { return _id_compra; }
            set { _id_compra = value; }
        }

        private int _id_statusCompra;
        public int id_statusCompra
        {
            get { return _id_statusCompra; }
            set { _id_statusCompra = value; }
        }

        private string _folioPedido;
        public string folioPedido
        {
            get { return _folioPedido; }
            set { _folioPedido = value; }
        }

        private string _id_sucursal;
        public string id_sucursal
        {
            get { return _id_sucursal; }
            set { _id_sucursal = value; }
        }
        private string _sucursal;
        public string sucursal
        {
            get { return _sucursal; }
            set { _sucursal = value; }
        }        
        private string _id_producto;
        public string id_producto
        {
            get { return _id_producto; }
            set { _id_producto = value; }
        }

        private string _id_proveedor;
        public string id_proveedor
        {
            get { return _id_proveedor; }
            set { _id_proveedor = value; }
        }

        private CompraDetalle _compraDetalle;
        public CompraDetalle compraDetalle
        {
            get { return _compraDetalle; }
            set { _compraDetalle = value; }
        }

        private DateTime _fechaPedido;
        public DateTime fechaPedido
        {
            get { return _fechaPedido; }
            set { _fechaPedido = value; }
        }

        private string _horaPedido;
        public string horaPedido
        {
            get { return _horaPedido; }
            set { _horaPedido = value; }
        }

        private float _monto;
        public float monto
        {
            get { return _monto; }
            set { _monto = value; }
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

        private string _id_caja;
        public string id_caja
        {
            get { return _id_caja; }
            set { _id_caja = value; }
        }

        private string _correoProveedor;
        public string correoProveedor
        {
            get { return _correoProveedor; }
            set { _correoProveedor = value; }
        }
        
    }
}
