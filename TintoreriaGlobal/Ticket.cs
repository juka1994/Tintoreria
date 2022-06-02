using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Ticket
    {
        private string _razonsocial;
        public string razonsocial
        {
            get { return _razonsocial; }
            set { _razonsocial = value; }
        }
        private string _rfc;
        public string rfc
        {
            get { return _rfc; }
            set { _rfc = value; }
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
        private string _nombresucursal;
        public string nombresucursal
        {
            get { return _nombresucursal; }
            set { _nombresucursal = value; }
        }
        private string _direccion;
        public string direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        private string _municipio;
        public string municipio
        {
            get { return _municipio; }
            set { _municipio = value; }
        }
        private string _estado;
        public string estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        private string _codigopostal;
        public string codigopostal
        {
            get { return _codigopostal; }
            set { _codigopostal = value; }
        }
        private List<VentaProductos> _detalleVenta;
        public List<VentaProductos> detalleVenta
        {
            get { return _detalleVenta; }
            set { _detalleVenta = value; }
        }
        private string _idventa;
        public string idventa
        {
            get { return _idventa; }
            set { _idventa = value; }
        }
        private VentaProductos _datosVenta;
        public VentaProductos datosVenta
        {
            get { return _datosVenta; }
            set { _datosVenta = value; }
        }
        private string _id_sucursal;
        public string id_sucursal
        {
            get { return _id_sucursal; }
            set { _id_sucursal = value; }
        }
        private string _strcnx;
        public string strcnx
        {
            get { return _strcnx; }
            set { _strcnx = value; }
        }
        private bool _error;
        public bool error
        {
            get { return _error; }
            set { _error = value; }
        }
        private string _namePrinter;
        public string namePrinter
        {
            get { return _namePrinter; }
            set { _namePrinter = value; }
        }
        private string _url_logo;
        public string url_logo
        {
            get { return _url_logo; }
            set { _url_logo = value; }
        }
        private string _pais;
        public string pais
        {
            get { return _pais; }
            set { _pais = value; }
        }
        private string _telefono;
        public string telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        private string _representanteLegal;
        public string representanteLegal
        {
            get { return _representanteLegal; }
            set { _representanteLegal = value; }
        }
        private byte[] _logoBuffer;
        public byte[] logoBuffer
        {
            get { return _logoBuffer; }
            set { _logoBuffer = value; }
        }
        private string _correo;
        public string Correo
        {
            get { return _correo; }
            set { _correo = value; }
        }

        private string _NombreComercial;

        public string NombreComercial
        {
            get { return _NombreComercial; }
            set { _NombreComercial = value; }
        }

        private string _Slogan;

        public string Slogan
        {
            get { return _Slogan; }
            set { _Slogan = value; }
        }

    }
}
