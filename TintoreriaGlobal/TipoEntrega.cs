using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class TipoEntrega
    {
        private int _id_tipoEntrega;
        public int id_tipoEntrega
        {
            get { return _id_tipoEntrega; }
            set { _id_tipoEntrega = value; }
        }

        private string _descripcion;
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private int _horas;
        public int horas
        {
            get { return _horas; }
            set { _horas = value; }
        }

        private decimal _precioXkilo;
        public decimal precioXkilo
        {
            get { return _precioXkilo; }
            set { _precioXkilo = value; }
        }

        private DataTable _datosTabla;
        public DataTable datosTabla
        {
            get { return _datosTabla; }
            set { _datosTabla = value; }
        }

        private int _opcion;
        public int opcion
        {
            get { return _opcion; }
            set { _opcion = value; }
        }

        private string _id_user;
        public string id_user
        {
            get { return _id_user; }
            set { _id_user = value; }
        }

    }
}
