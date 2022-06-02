using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class DetalleLavado
    {
        private string _id_lavado;
        public string id_lavado
        {
            get { return _id_lavado; }
            set { _id_lavado = value; }
        }

        private int _id_status;
        public int id_status
        {
            get { return _id_status; }
            set { _id_status = value; }
        }

        private string _id_lavadoDetalle;
        public string id_lavadoDetalle
        {
            get { return _id_lavadoDetalle; }
            set { _id_lavadoDetalle = value; }
        }

        private string _nombreProducto;
        public string nombreProducto
        {
            get { return _nombreProducto; }
            set { _nombreProducto = value; }
        }

        private decimal _cantidad;
        public decimal cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }

        private string _descripcion;
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        private string _descStatus;
        public string descStatus
        {
            get { return _descStatus; }
            set { _descStatus = value; }
        }

    }
}
