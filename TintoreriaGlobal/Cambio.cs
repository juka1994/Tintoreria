using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Cambio
    {
        private string _id_cambio;
        public string id_cambio
        {
            get { return _id_cambio; }
            set { _id_cambio = value; }
        }

        private string _nombreProducto;
        public string nombreProducto
        {
            get { return _nombreProducto; }
            set { _nombreProducto = value; }
        }

        private string _id_codigoEan;
        public string id_codigoEan
        {
            get { return _id_codigoEan; }
            set { _id_codigoEan = value; }
        }

        private string _descripcion;
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private int _id_tipoProducto;
        public int id_tipoProducto
        {
            get { return _id_tipoProducto; }
            set { _id_tipoProducto = value; }
        }
        

        private string _id_caja;
        public string id_caja
        {
            get { return _id_caja; }
            set { _id_caja = value; }
        }

        private float _precio;
        public float precio
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

        private string _id_sucursal;
        public string id_sucursal
        {
            get { return _id_sucursal; }
            set { _id_sucursal = value; }
        }

        private string _id_productoCambio;
        public string id_productoCambio
        {
            get { return _id_productoCambio; }
            set { _id_productoCambio = value; }
        }

        private int _id_tallaRopaCambio;
        public int id_tallaRopaCambio
        {
            get { return _id_tallaRopaCambio; }
            set { _id_tallaRopaCambio = value; }
        }

        private int _id_colorRopaCambio;
        public int id_colorRopaCambio
        {
            get { return _id_colorRopaCambio; }
            set { _id_colorRopaCambio = value; }
        }

        private string _id_productoNuevo;
        public string id_productoNuevo
        {
            get { return _id_productoNuevo; }
            set { _id_productoNuevo = value; }
        }

        private int _id_tallaRopaNuevo;
        public int id_tallaRopaNuevo
        {
            get { return _id_tallaRopaNuevo; }
            set { _id_tallaRopaNuevo = value; }
        }

        private int _id_colorRopaNuevo;
        public int id_colorRopaNuevo
        {
            get { return _id_colorRopaNuevo; }
            set { _id_colorRopaNuevo = value; }
        }

        private int _id_motivo;
        public int id_motivo
        {
            get { return _id_motivo; }
            set { _id_motivo = value; }
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

        private int _cantidad;
        public int cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
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
    }
}
