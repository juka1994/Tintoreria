using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class ReporteVendedorTop5
    {
        private string _conexion;
        public string conexion
        {
            get { return _conexion; }
            set { _conexion = value; }
        }
        private string _id_sucursal;
        public string id_sucursal
        {
            get { return _id_sucursal; }
            set { _id_sucursal = value; }
        }
        private DateTime _fechaInicio;
        public DateTime fechaInicio
        {
            get { return _fechaInicio; }
            set { _fechaInicio = value; }
        }
        private DateTime _fechaFin;
        public DateTime fechaFin
        {
            get { return _fechaFin; }
            set { _fechaFin = value; }
        }
        private string _vendedor;
        public string vendedor
        {
            get { return _vendedor; }
            set { _vendedor = value; }
        }
                private int _numVentas;
        public int numVentas
        {
            get { return _numVentas; }
            set { _numVentas = value; }
        }
        private List<ReporteVendedorTop5> _lstReporteVendedorTop5;
        public List<ReporteVendedorTop5> lstReporteVendedorTop5
        {
            get { return _lstReporteVendedorTop5; }
            set { _lstReporteVendedorTop5 = value; }
        }
    }
}
