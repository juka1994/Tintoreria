using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
   public class Depositos
    {

        private string _id_deposito;
        public string id_deposito
        {
            get { return _id_deposito; }
            set { _id_deposito = value; }
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

        private decimal _monto;

        public decimal monto
        {
            get { return _monto; }
            set { _monto = value; }
        }

        private string _motivo;

        public  string motivo
        {
            get { return _motivo; }
            set { _motivo = value; }
        }


    }
}
