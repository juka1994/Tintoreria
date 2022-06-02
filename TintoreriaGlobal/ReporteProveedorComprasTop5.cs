using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class ReporteProveedorComprasTop5
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
        private string _id_proveedor;
        public string id_proveedor
        {
            get { return _id_proveedor; }
            set { _id_proveedor = value; }
        }
        private string _proveedor;
        public string proveedor
        {
            get { return _proveedor; }
            set { _proveedor = value; }
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
        private int _numCompras;
        public int numCompras
        {
            get { return _numCompras; }
            set { _numCompras = value; }
        }
        private List<ReporteProveedorComprasTop5> _lstReporteProveedorComprasTop5;
        public List<ReporteProveedorComprasTop5> lstReporteProveedorComprasTop5
        {
            get { return _lstReporteProveedorComprasTop5; }
            set { _lstReporteProveedorComprasTop5 = value; }
        }
    }
}
