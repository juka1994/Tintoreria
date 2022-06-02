using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class FormaPago
    {

        private string _autorizacion;
        public string autorizacion
        {
            get { return _autorizacion; }
            set { _autorizacion = value; }
        }

        private string _folioIFE;
        public string folioIFE
        {
            get { return _folioIFE; }
            set { _folioIFE = value; }
        }

        private int _idBanco;
        public int idBanco
        {
            get { return _idBanco; }
            set { _idBanco = value; }
        }

        private string _numtarjeta;
        public string numtarjeta
        {
            get { return _numtarjeta; }
            set { _numtarjeta = value; }
        }

        private decimal _monto;
        public decimal monto
        {
            get { return _monto; }
            set { _monto = value; }
        }


        //
        //**************************************   Cheques   ****************************************
        //

        private string _numCheque;
        public string numCheque
        {
            get { return _numCheque; }
            set { _numCheque = value; }
        }

        private string _nombrePersona;
        public string nombrePersona
        {
            get { return _nombrePersona; }
            set { _nombrePersona = value; }
        }

        private Banco _banco;
        public Banco banco
        {
            get { return _banco; }
            set { _banco = value; }
        }

        private int _IDFormaPago;
        public int IDFormaPago
        {
            get { return _IDFormaPago; }
            set { _IDFormaPago = value; }
        }

        private string _Forma_Pago;
        public string Forma_Pago
        {
            get { return _Forma_Pago; }
            set { _Forma_Pago = value; }
        }

        private TipoDocumento _tipoDocumento;
        public TipoDocumento tipoDocumento
        {
            get { return _tipoDocumento; }
            set { _tipoDocumento = value; }
        }
        

    }
}
