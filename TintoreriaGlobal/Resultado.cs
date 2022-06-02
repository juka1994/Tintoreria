using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Resultado
    {
        private int _id_operacionContable;
        public int id_operacionContable
        {
            get { return _id_operacionContable; }
            set { _id_operacionContable = value; }
        }

        private string _descripcion;
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _id_sucursal;
        public string id_sucursal
        {
            get { return _id_sucursal; }
            set { _id_sucursal = value; }
        }

        private string _id_estadoResultado;
        public string id_estadoResultado
        {
            get { return _id_estadoResultado; }
            set { _id_estadoResultado = value; }
        }

        private DateTime _fecha;
        public DateTime fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        private DateTime _fecha2;
        public DateTime fecha2
        {
            get { return _fecha2; }
            set { _fecha2 = value; }
        }

        private string _titulo;
        public string titulo
        {
            get { return _titulo; }
            set { _titulo = value; }
        }

        private int _id_seccion;
        public int id_seccion
        {
            get { return _id_seccion; }
            set { _id_seccion = value; }
        }

        private float _monto;
        public float monto
        {
            get { return _monto; }
            set { _monto = value; }
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

        private int _tipoBusqueda;
        public int tipoBusqueda
        {
            get { return _tipoBusqueda; }
            set { _tipoBusqueda = value; }
        }
        
     
    }
}
