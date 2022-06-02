using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Banco
    {
        private string _nombreBanco;
        public string nombreBanco
        {
            get { return _nombreBanco; }
            set { _nombreBanco = value; }
        }

        private int _idBanco;
        public int idBanco
        {
            get { return _idBanco; }
            set { _idBanco = value; }
        }

        private string _conexion;
        public string conexion
        {
            get { return _conexion; }
            set { _conexion = value; }
        }
    }
}
