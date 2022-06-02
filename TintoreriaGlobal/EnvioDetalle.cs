using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class EnvioDetalle
    {
        private int _id_envioDetalle;
        public int id_envioDetalle
        {
            get { return _id_envioDetalle; }
            set { _id_envioDetalle = value; }
        }

        private string _id_ventaServicio;
        public string id_ventaServicio
        {
            get { return _id_ventaServicio; }
            set { _id_ventaServicio = value; }
        }

        private string _folio;
        public string folio
        {
            get { return _folio; }
            set { _folio = value; }
        }

        private string _recibe;
        public string recibe
        {
            get { return _recibe; }
            set { _recibe = value; }
        }

        private string _observacion;
        public string observacion
        {
            get { return _observacion; }
            set { _observacion = value; }
        }

        public bool entregado { get; set; }

        private int _id_status;
        public int id_status
        {
            get { return _id_status; }
            set { _id_status = value; }
        }

        public int idStatusEnvio => entregado ? 2 : 1;

        private string _nombre;
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
    }
}
