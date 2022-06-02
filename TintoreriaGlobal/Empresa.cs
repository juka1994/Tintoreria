using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Empresa
    {
        private int _id_empresa;
        public int id_empresa
        {
            get { return _id_empresa; }
            set { _id_empresa = value; }
        }

        private int _numeroTickets;
        public int numeroTickets
        {
            get { return _numeroTickets; }
            set { _numeroTickets = value; }
        }

        private string _razonSocial;
        public string razonSocial
        {
            get { return _razonSocial; }
            set { _razonSocial = value; }
        }

        private string _nombreComercial;
        public string nombreComercial
        {
            get { return _nombreComercial; }
            set { _nombreComercial = value; }
        }

        private string _slogan;
        public string slogan
        {
            get { return _slogan; }
            set { _slogan = value; }
        }

        private string _pathImg;
        public string pathImg
        {
            get { return _pathImg; }
            set { _pathImg = value; }
        }

        private string _logo;
        public string logo
        {
            get { return _logo; }
            set { _logo = value; }
        }      

        private string _rfc;
        public string rfc
        {
            get { return _rfc; }
            set { _rfc = value; }
        }

        private string _representanteLegal;
        public string representanteLegal
        {
            get { return _representanteLegal; }
            set { _representanteLegal = value; }
        }

        private string _sitioWeb;
        public string sitioWeb
        {
            get { return _sitioWeb; }
            set { _sitioWeb = value; }
        }

        private string _extension;
        public string extension
        {
            get { return _extension; }
            set { _extension = value; }
        }

        private string _correoElectronico;
        public string correoElectronico
        {
            get { return _correoElectronico; }
            set { _correoElectronico = value; }
        }

        private string _correoSistema;
        public string correoSistema
        {
            get { return _correoSistema; }
            set { _correoSistema = value; }
        }

        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        private bool _ssl;
        public bool ssl
        {
            get { return _ssl; }
            set { _ssl = value; }
        }

        private bool _html;
        public bool html
        {
            get { return _html; }
            set { _html = value; }
        }

        private int _puerto;
        public int puerto
        {
            get { return _puerto; }
            set { _puerto = value; }
        }

        private string _host;
        public string host
        {
            get { return _host; }
            set { _host = value; }
        }

        private string _id_sucursalMatriz;
        public string id_sucursalMatriz
        {
            get { return _id_sucursalMatriz; }
            set { _id_sucursalMatriz = value; }
        }

        private DataTable _datos;
        public DataTable datos
        {
            get { return _datos; }
            set { _datos = value; }
        }

        private string _id_u;
        public string id_u
        {
            get { return _id_u; }
            set { _id_u = value; }
        }

        private string _conexion;
        public string conexion
        {
            get { return _conexion; }
            set { _conexion = value; }
        }

        private int _opcion;
        public int opcion
        {
            get { return _opcion; }
            set { _opcion = value; }
        }

        private string _mensaje1;
        public string mensaje1
        {
            get { return _mensaje1; }
            set { _mensaje1 = value; }
        }

        private string _mensaje2;
        public string mensaje2
        {
            get { return _mensaje2; }
            set { _mensaje2 = value; }
        }

        private string _mensaje3;
        public string mensaje3
        {
            get { return _mensaje3; }
            set { _mensaje3 = value; }
        }

        private DateTime _fechaDeCredenciales1;
        public DateTime fechaDeCredenciales1
        {
            get { return _fechaDeCredenciales1; }
            set { _fechaDeCredenciales1 = value; }
        }

        private DateTime _fechaDeCredenciales2;
        public DateTime fechaDeCredenciales2
        {
            get { return _fechaDeCredenciales2; }
            set { _fechaDeCredenciales2 = value; }
        }


    }

}
