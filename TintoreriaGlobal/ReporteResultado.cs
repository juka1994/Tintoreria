using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class ReporteResultado
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
        private int _id_seccion;
        public int id_seccion
        {
            get { return _id_seccion; }
            set { _id_seccion = value; }
        }
        private string _resultado;
        public string resultado
        {
            get { return _resultado; }
            set { _resultado = value; }
        }
        private string _operacion;
        public string operacion
        {
            get { return _operacion; }
            set { _operacion = value; }
        }
        private string _monto;
        public string monto
        {
            get { return _monto; }
            set { _monto = value; }
        }
        private string _seccion;
	    public string seccion
	    {
		    get { return _seccion;}
		    set { _seccion = value;}
	    }	                
        private List<ReporteResultado> _lstReporteResultado;
        public List<ReporteResultado> lstReporteResultado
        {
            get { return _lstReporteResultado; }
            set { _lstReporteResultado = value; }
        }
        
    }
}
