using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class ProductoDetalle
    {
        private string _id_prodxsuc;
        public string id_prodxsuc
        {
            get { return _id_prodxsuc; }
            set { _id_prodxsuc = value; }
        }
        private bool _interno;
        public bool interno
        {
            get { return _interno; }
            set { _interno = value; }
        }  
        private string _id_producto;
        public string id_producto
        {
            get { return _id_producto; }
            set { _id_producto = value; }
        }
        private string _nombre;
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }       
        private string _id_sucursal;
        public string id_sucursal
        {
            get { return _id_sucursal; }
            set { _id_sucursal = value; }
        }
        private int _id_tallaRopa;
        public int id_tallaRopa
        {
            get { return _id_tallaRopa; }
            set { _id_tallaRopa = value; }
        }
        private string _tallaRopa;
        public string tallaRopa
        {
            get { return _tallaRopa; }
            set { _tallaRopa = value; }
        }  
        private int _id_colorRopa;
        public int id_colorRopa
        {
            get { return _id_colorRopa; }
            set { _id_colorRopa = value; }
        }
        private string _colorRopa;
        public string colorRopa
        {
            get { return _colorRopa; }
            set { _colorRopa = value; }
        }       
        private float _costoUltimo;
        public float costoUltimo
        {
            get { return _costoUltimo; }
            set { _costoUltimo = value; }
        }
        private decimal _precio;
        public decimal precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        private float _precioMayoreo;
        public float precioMayoreo
        {
            get { return _precioMayoreo; }
            set { _precioMayoreo = value; }
        }
        private float _iva;
        public float iva
        {
            get { return _iva; }
            set { _iva = value; }
        }
        private float _ivaMayoreo;
        public float ivaMayoreo
        {
            get { return _ivaMayoreo; }
            set { _ivaMayoreo = value; }
        }
        private int _existencia;
        public int existencia
        {
            get { return _existencia; }
            set { _existencia = value; }
        }
        private int _id_tipoProducto;
        public int id_tipoProducto
        {
            get { return _id_tipoProducto; }
            set { _id_tipoProducto = value; }
        }  
        private int _existenciaApartado;
        public int existenciaApartado
        {
            get { return _existenciaApartado; }
            set { _existenciaApartado = value; }
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
        private string _id_codigoEan;
        public string id_codigoEan
        {
            get { return _id_codigoEan; }
            set { _id_codigoEan = value; }
        }
        private float _descuento;
        public float descuento
        {
            get { return _descuento; }
            set { _descuento = value; }
        }
        
    }
}
