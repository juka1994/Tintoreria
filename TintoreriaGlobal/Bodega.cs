using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Bodega
    {
        private string _id_producto;
        public string id_producto
        {
            get { return _id_producto; }
            set { _id_producto = value; }
        }
               
        private string _nombreProducto;
        public string nombreProducto
        {
            get { return _nombreProducto; }
            set { _nombreProducto = value; }
        }

        private string _id_sucursal;
        public string id_sucursal
        {
            get { return _id_sucursal; }
            set { _id_sucursal = value; }
        }

        private string _id_proveedor;
        public string id_proveedor
        {
            get { return _id_proveedor; }
            set { _id_proveedor = value; }
        }

        private int _id_colorRopa;
        public int id_colorRopa
        {
            get { return _id_colorRopa; }
            set { _id_colorRopa = value; }
        }

        private int _id_tallaRopa;
        public int id_tallaRopa
        {
            get { return _id_tallaRopa; }
            set { _id_tallaRopa = value; }
        }       

        private int _cantidad;
        public int cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        private float _costo;
        public float costo
        {
            get { return _costo; }
            set { _costo = value; }
        }

        private float _subtotal;
        public float subtotal
        {
            get { return _subtotal; }
            set { _subtotal = value; }
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
    }
}
