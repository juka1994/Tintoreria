using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Membresias
    {
        private int _id_TipoCredencial;
        public int id_TipoCredencial
        {
            get { return _id_TipoCredencial; }
            set { _id_TipoCredencial = value; }
        }

        private string _descripcion;
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private int _puntos;
        public int puntos
        {
            get { return _puntos; }
            set { _puntos = value; }
        }

        private decimal _porcentajexVenta;

        public decimal porcentajexVenta
        {
            get { return _porcentajexVenta; }
            set { _porcentajexVenta = value; }
        }

        private DataTable _datosTabla;
        public DataTable datosTabla
        {
            get { return _datosTabla; }
            set { _datosTabla = value; }
        }

        private string _conexion;
        public string conexion
        {
            get { return _conexion; }
            set { _conexion = value; }
        }

        private string _id_user;    
        public string id_user
        {
            get { return _id_user; }
            set { _id_user = value; }
        }

        private int _opcion;
        public int opcion
        {
            get { return _opcion; }
            set { _opcion = value; }
        }

    }
}
