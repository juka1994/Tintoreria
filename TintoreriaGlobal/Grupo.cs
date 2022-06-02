using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Grupo
    {
        private int _id_Grupo;
        public int id_Grupo
        {
            get { return _id_Grupo; }
            set { _id_Grupo = value; }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private bool _cobrarLavanderia;
        public bool cobrarLavanderia
        {
            get { return _cobrarLavanderia; }
            set { _cobrarLavanderia = value; }
        }

        private bool _esSistema;
        public bool esSistema
        {
            get { return _esSistema; }
            set { _esSistema = value; }
        }

        private string _id_user;
        public string id_user
        {
            get { return _id_user; }
            set { _id_user = value; }
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

    }
}
