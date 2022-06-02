using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Equipo
    {
        private string _id_equipo;
        public string id_equipo
        {
            get { return _id_equipo; }
            set { _id_equipo = value; }
        }

        private string _id_sucursal;
        public string id_sucursal
        {
            get { return _id_sucursal; }
            set { _id_sucursal = value; }
        }

        private string _descripcion;
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private bool _liberarEquipo;
        public bool liberarEquipo
        {
            get { return _liberarEquipo; }
            set { _liberarEquipo = value; }
        }

        private string _nombre;
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        private string _macAddress;
        public string macAddress
        {
            get { return _macAddress; }
            set { _macAddress = value; }
        }

        private string _namePrinter;
        public string namePrinter
        {
            get { return _namePrinter; }
            set { _namePrinter = value; }
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

        private string _conexion;
        public string conexion
        {
            get { return _conexion; }
            set { _conexion = value; }
        }

        private int _opcion;
        public int opcion
        {
            get { return _opcion; }
            set { _opcion = value; }
        }
       
    }

}
