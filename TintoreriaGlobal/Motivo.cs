using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Motivo
    {
        private int _id_motivo;
        public int id_motivo
        {
            get { return _id_motivo; }
            set { _id_motivo = value; }
        }

        private string _motivo;
        public string motivo
        {
            get { return _motivo; }
            set { _motivo = value; }
        }

        private Boolean _bodega;
        public Boolean bodega
        {
            get { return _bodega; }
            set { _bodega = value; }
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
