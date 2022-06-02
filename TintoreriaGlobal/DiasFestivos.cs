using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class DiasFestivos
    {
        private int _id_diasFestivos;
        public int id_diasFestivos
        {
            get { return _id_diasFestivos; }
            set { _id_diasFestivos = value; }
        }

        private string _descripcion;        
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private DateTime _diaFestivo;

        public DateTime diaFestivo
        {
            get { return _diaFestivo; }
            set { _diaFestivo = value; }
        }


        private int _opciopn;
        public int opcion
        {
            get { return _opciopn; }
            set { _opciopn = value; }
        }

        private string _id_user;
        public string id_user
        {
            get { return _id_user; }
            set { _id_user = value; }
        }

    }
}
