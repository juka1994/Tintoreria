using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Almacen
    {
        public int IdUnidadMedidaProducto { get; set; }
        public string NombreUnidadMedida { get; set; }
        public decimal CantidadMovimiento { get; set; }
        public string UnidadMedidaMovimiento { get; set; }
        public decimal CantidadProducto { get; set; }
        public string UnidadMedidaProducto { get; set; }
        public decimal CantidadConvertida { get; set; }
        public decimal CantidadAlmacen { get; set; }
        public decimal FactorConversion { get; set; }
       
        private string _id_producto;
        public string id_producto
        {
            get { return _id_producto; }
            set { _id_producto = value; }
        }

        private string _id_codigoEan;
        public string id_codigoEan
        {
            get { return _id_codigoEan; }
            set { _id_codigoEan = value; }
        }

        private string _nombreProducto;
        public string nombreProducto
        {
            get { return _nombreProducto; }
            set { _nombreProducto = value; }
        }

        private decimal _existencia;
        public decimal existencia
        {
            get { return _existencia; }
            set { _existencia = value; }
        }

        private string _id_sucursal;
        public string id_sucursal
        {
            get { return _id_sucursal; }
            set { _id_sucursal = value; }
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

        private int _diferencia;
        public int diferencia
        {
            get { return _diferencia; }
            set { _diferencia = value; }
        }

        private int _existenciaSistema;
        public int existenciaSistema
        {
            get { return _existenciaSistema; }
            set { _existenciaSistema = value; }
        }

        private int _existenciaFisica;
        public int existenciaFisica
        {
            get { return _existenciaFisica; }
            set { _existenciaFisica = value; }
        }                

        private int _cantidad;
        public int cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
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

        private DataTable _importarExcel;
        public DataTable importarExcel
        {
            get { return _importarExcel; }
            set { _importarExcel = value; }
        }
        
    }
}
