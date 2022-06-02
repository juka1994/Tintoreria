using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TintoreriaGlobal
{
    public class Familia
    {
        private int _id_familia;
        public int id_familia
        {
            get { return _id_familia; }
            set { _id_familia = value; }
        }

        private string _descripcion;
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _porcentaje_puntos;
        public string porcentaje_puntos
        {
            get { return _porcentaje_puntos; }
            set { _porcentaje_puntos = value; }
        }

        private string _porcentaje_monedero;
        public string porcentaje_monedero
        {
            get { return _porcentaje_monedero; }
            set { _porcentaje_monedero = value; }
        }

        private DataTable _lstTipoCrendencial;
        public DataTable lstTipoCrendencial
        {
            get { return _lstTipoCrendencial; }
            set { _lstTipoCrendencial = value; }
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
