using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Producto
    {
        public string NombreUnidadMedida { get; set; }

        private string _id_producto;
        public string id_producto
        {
            get { return _id_producto; }
            set { _id_producto = value; }
        } 
        private int _id_familia;
        public int id_familia
        {
            get { return _id_familia; }
            set { _id_familia = value; }
        }
        private bool _IncluirSelect;
        public bool IncluirSelect
        {
            get { return _IncluirSelect; }
            set { _IncluirSelect = value; }
        }
        private string _id_proveedor;
        public string id_proveedor
        {
            get { return _id_proveedor; }
            set { _id_proveedor = value; }
        }
        private int _id_tipoProducto;
        public int id_tipoProducto
        {
            get { return _id_tipoProducto; }
            set { _id_tipoProducto = value; }
        }
        private int _cantidadMayoreo;
        public int cantidadMayoreo
        {
            get { return _cantidadMayoreo; }
            set { _cantidadMayoreo = value; }
        }
        private int _inventarioOptimo;
        public int inventarioOptimo
        {
            get { return _inventarioOptimo; }
            set { _inventarioOptimo = value; }
        }
        private int _diasInventario;
        public int diasInventario
        {
            get { return _diasInventario; }
            set { _diasInventario = value; }
        }
        private string _nombreProducto;
        public string nombreProducto
        {
            get { return _nombreProducto; }
            set { _nombreProducto = value; }
        }
        private int _id_unidadMedida;
        public int id_unidadMedida
        {
            get { return _id_unidadMedida; }
            set { _id_unidadMedida = value; }
        }
        private string _imagen;
        public string imagen
        {
            get { return _imagen; }
            set { _imagen = value; }
        }
        private DateTime _fechaIngreso;
        public DateTime fechaIngreso
        {
            get { return _fechaIngreso; }
            set { _fechaIngreso = value; }
        }
        private string _observaciones;
        public string observaciones
        {
            get { return _observaciones; }
            set { _observaciones = value; }
        }
        private bool _ventaDirecta;
        public bool ventaDirecta
        {
            get { return _ventaDirecta; }
            set { _ventaDirecta = value; }
        }
        private bool _aplicaInventario;
        public bool aplicaInventario
        {
            get { return _aplicaInventario; }
            set { _aplicaInventario = value; }
        }

        private bool _EsAccesorio;

        public bool EsAccesorio
        {
            get { return _EsAccesorio; }
            set { _EsAccesorio = value; }
        }

        private bool _EsHombre;

        public bool EsHombre
        {
            get { return _EsHombre; }
            set { _EsHombre = value; }
        }

        private bool _EsMujer;

        public bool EsMujer
        {
            get { return _EsMujer; }
            set { _EsMujer = value; }
        }
        
        private ProductoDetalle _productoDetalle;
        public ProductoDetalle productoDetalle
        {
            get { return _productoDetalle; }
            set { _productoDetalle = value; }
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
        private string _extension;
        public string extension
        {
            get { return _extension; }
            set { _extension = value; }
        }
        private int _id_marca;
        public int id_marca
        {
            get { return _id_marca; }
            set { _id_marca = value; }
        }
        private int _id_material;
        public int id_material
        {
            get { return _id_material; }
            set { _id_material = value; }
        }
        private bool _cajaNueva;
        public bool cajaNueva
        {
            get { return _cajaNueva; }
            set { _cajaNueva = value; }
        }
    }

}
