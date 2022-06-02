using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Envio
    {
        public Envio()
        {
            _idventa = string.Empty;
            _datos = new DataTable();
            _id_sucursal = string.Empty;
            _id_chofer = string.Empty;
            _id_vehiculo = string.Empty;
            _Empresas = new Empresa();
        }
        private  string _id_sucursal;
        public  string id_sucursal
        {
            get { return _id_sucursal; }
            set { _id_sucursal = value; }
        }

        private DataTable _datos;
        public DataTable datos
        {
            get { return _datos; }
            set { _datos = value; }
        }
        private int _id_envio;
        public int id_envio
        {
            get { return _id_envio; }
            set { _id_envio = value; }
        }

        private string _idventa;
        public string idventa
        {
            get { return _idventa; }
            set { _idventa = value; }
        }

        private string _folio;
        public  string folio
        {
            get { return _folio; }
            set { _folio = value; }
        }


        private  string _id_chofer;
        public  string id_chofer
        {
            get { return _id_chofer; }
            set { _id_chofer = value; }
        }

        private  string _conexion;
        public  string conexion
        {
            get { return _conexion; }
            set { _conexion = value; }
        }

        private  string _id_vehiculo;
        public  string id_vehiculo
        {
            get { return _id_vehiculo; }
            set { _id_vehiculo = value; }
        }


        private  string _hora_entrega;
        public  string hora_entrega
        {
            get { return _hora_entrega; }
            set { _hora_entrega = value; }
        }


        private string _hora_recibe;
        public string hora_recibe
        {
            get { return _hora_recibe;; }
            set { _hora_recibe= value; }
        }


        private string _recibe;
        public string recibe
        {
            get { return _recibe; ; }
            set { _recibe = value; }
        }
        private string _id_u;
        public string id_u
        {
            get { return _id_u; }
            set { _id_u = value; }
        }

        private string _Observacion;

        public string Observacion
        {
            get { return _Observacion; }
            set { _Observacion = value; }
        }


        private  string _fecha_salida;
        public  string fecha_salida
        {
            get { return _fecha_salida; }
            set { _fecha_salida = value; }
        }

        private DateTime _fecha_recibe;
        public DateTime fecha_recibe
        {
            get { return _fecha_recibe; }
            set { _fecha_recibe = value; }
        }

        private Empresa _Empresas;

        public Empresa Empresas
        {
            get { return _Empresas; }
            set { _Empresas = value; }
        }

        public string NombreChofer { get; set; }
        public string Vehiculo { get; set; }
        public string NombreSucursal { get; set; }
        public string Cliente { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        

        private List<Envio> _ListaEnvio;

        public List<Envio> ListaEnvio
        {
            get { return _ListaEnvio; }
            set { _ListaEnvio = value; }
        }

        
    }
}
