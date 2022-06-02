using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class DocumentosXPagar
    {
        private string _idventa;
        public string idventa
        {
            get { return _idventa; }
            set { _idventa = value; }
        }

        private string _id_compra;
        public string id_compra
        {
            get { return _id_compra; }
            set { _id_compra = value; }
        }
        private string _id_pagoDocXPagar;
        public string id_pagoDocXPagar
        {
            get { return _id_pagoDocXPagar; }
            set { _id_pagoDocXPagar = value; }
        }
        private string _nombreProducto;
        public string nombreProducto
        {
            get { return _nombreProducto; }
            set { _nombreProducto = value; }
        }        
        private string _id_docXPagar;
        public string id_docXPagar
        {
            get { return _id_docXPagar; }
            set { _id_docXPagar = value; }
        }
        private string _folio;
        public string folio
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
        private float _monto;
        public float monto
        {
            get { return _monto; }
            set { _monto = value; }
        }
        private string _proveedor;
        public string proveedor
        {
            get { return _proveedor; }
            set { _proveedor = value; }
        }
        private Boolean _aplicarBodega;
        public Boolean aplicarBodega
        {
            get { return _aplicarBodega; }
            set { _aplicarBodega = value; }
        }                
        private int _id_status;
        public int id_status
        {
            get { return _id_status; }
            set { _id_status = value; }
        }
        private string _id_caja;
        public string id_caja
        {
            get { return _id_caja; }
            set { _id_caja = value; }
        }
        private string _id_sucursal;
        public string id_sucursal
        {
            get { return _id_sucursal; }
            set { _id_sucursal = value; }
        }
        private DateTime _fecha;
        public DateTime fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        private string _hora;
        public string hora
        {
            get { return _hora; }
            set { _hora = value; }
        }
        private float _total;
        public float total
        {
            get { return _total; }
            set { _total = value; }
        }
        private string _imagen;
        public string imagen
        {
            get { return _imagen; }
            set { _imagen = value; }
        }
        private string _extension;
        public string extension
        {
            get { return _extension; }
            set { _extension = value; }
        }        
        private int _opcion;
        public int opcion
        {
            get { return _opcion; }
            set { _opcion = value; }
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
        private int _tipoBusqueda;
        public int tipoBusqueda
        {
            get { return _tipoBusqueda; }
            set { _tipoBusqueda = value; }
        }                        
    }
}
