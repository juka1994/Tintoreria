using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class ReporteBodega
    {
        private string _proveedor;
        public string proveedor
        {
            get { return _proveedor; }
            set { _proveedor = value; }
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
        private int _cantidad;
        public int cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }
        private List<ReporteBodega> _lstReporteBodega;
        public List<ReporteBodega> lstReporteBodega
        {
            get { return _lstReporteBodega; }
            set { _lstReporteBodega = value; }
        }
    }
}
