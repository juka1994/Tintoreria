using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Sucursal
    {
        private string _id_sucursal;
        public string id_sucursal
        {
            get { return _id_sucursal; }
            set { _id_sucursal = value; }
        }

        private int _id_tipoSucursal;
        public int id_tipoSucursal
        {
            get { return _id_tipoSucursal; }
            set { _id_tipoSucursal = value; }
        }

        private string _nombre;
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _direccion;
        public string direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }

        private string _telefono;
        public string telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }

        private string _codigoPostal;
        public string codigoPostal
        {
            get { return _codigoPostal; }
            set { _codigoPostal = value; }
        }

        private int _id_pais;
        public int id_pais
        {
            get { return _id_pais; }
            set { _id_pais = value; }
        }
        
        private int _id_estado;
        public int id_estado
        {
            get { return _id_estado; }
            set { _id_estado = value; }
        }

        private int _id_municipio;
        public int id_municipio
        {
            get { return _id_municipio; }
            set { _id_municipio = value; }
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

        private int _id_iva;
        public int id_iva
	    {
            get { return _id_iva; }
            set { _id_iva = value; }
	    }      
    }
}
