using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class ReporteProductosTop10
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
        private string _codigoBarra;
        public string codigoBarra
        {
            get { return _codigoBarra; }
            set { _codigoBarra = value; }
        }
        private string _producto;
        public string producto
        {
            get { return _producto; }
            set { _producto = value; }
        }
        private int _numVentas;
        public int numVentas
        {
            get { return _numVentas; }
            set { _numVentas = value; }
        }
        private List<ReporteProductosTop10> _lstReporteProductosTop10;
        public List<ReporteProductosTop10> lstReporteProductosTop10
        {
            get { return _lstReporteProductosTop10; }
            set { _lstReporteProductosTop10 = value; }
        }
        
    }
}
