using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class CompraDetalle
    {
        public CompraDetalle()
        {
            _datos = new DataTable();
        }
        public string NombreUnidadMedida { get; set; }
        public int IdUnidadMedida { get; set; }
        private string _id_compra;
        public string id_compra
        {
            get { return _id_compra; }
            set { _id_compra = value; }
        }        

        private string _nombreProducto;
        public string nombreProducto
        {
            get { return _nombreProducto; }
            set { _nombreProducto = value; }
        }

        private int _cantidad;
        public int cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        private string _id_producto;
        public string id_producto
        {
            get { return _id_producto; }
            set { _id_producto = value; }
        }

        private int _id_tallaRopa;
        public int id_tallaRopa
        {
            get { return _id_tallaRopa; }
            set { _id_tallaRopa = value; }
        }

        private int _id_colorRopa;
        public int id_colorRopa
        {
            get { return _id_colorRopa; }
            set { _id_colorRopa = value; }
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
    }

}
