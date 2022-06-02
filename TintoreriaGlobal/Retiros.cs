using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Retiros
    {
        private string _id_retiro;
        public string id_retiro
        {
            get { return _id_retiro; }
            set { _id_retiro = value; }
        }
    
        private string _id_sucursal;
        public string id_sucursal
        {
            get { return _id_sucursal; }
            set { _id_sucursal = value; }
        }

        private string _id_caja;
        public string id_caja
        {
            get { return _id_caja; }
            set { _id_caja = value; }
        }

        private string _id_cajero;
        public string id_cajero
        {
            get { return _id_cajero; }
            set { _id_cajero = value; }
        }

        private int _id_tipo;
        public int id_tipo
        {
            get { return _id_tipo; }
            set { _id_tipo = value; }
        }

        private decimal _monto;
        public decimal monto
        {
            get { return _monto; }
            set { _monto = value; }
        }

        private string _motivo;
        public string motivo
        {
            get { return _motivo; }
            set { _motivo = value; }
        }
        private string _id_user;
        public string id_user
        {
            get { return _id_user; }
            set { _id_user = value; }
        }

    }
}
