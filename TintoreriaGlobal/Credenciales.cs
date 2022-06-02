using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Credenciales
    {
        public decimal PorcentajeMonedero { get; set; }

        private int _cantidadVentas;

        public int cantidadVentas
        {
            get { return _cantidadVentas; }
            set { _cantidadVentas = value; }
        }

        private string _NivelCredencial;

        public string NivelCredencial
        {
            get { return _NivelCredencial; }
            set { _NivelCredencial = value; }
        }

        private int _idTipoCredencial;

        public int idTipoCredencial
        {
            get { return _idTipoCredencial; }
            set { _idTipoCredencial = value; }
        }

        private string _id_credencial;
        public string id_credencial
        {
            get { return _id_credencial; }
            set { _id_credencial = value; }
        }

        private int _id_tipoCredencial;
        public int id_tipoCrdencial
        {
            get { return _id_tipoCredencial; }
            set { _id_tipoCredencial = value; }
        }

        private string _id_cliente;
        public string id_cliente
        {
            get { return _id_cliente; }
            set { _id_cliente = value; }
        }

        private string _tipoCredencial;
        public string tipoCredencial
        {
            get { return _tipoCredencial; }
            set { _tipoCredencial = value; }
        }

        private string _id_codigoEab;
        public string id_codigoEab
        {
            get { return _id_codigoEab; }
            set { _id_codigoEab = value; }
        }
        
        private decimal _monedero;
        public decimal monedero
        {
            get { return _monedero; }
            set { _monedero = value; }
        }

        private int _puntos;
        public int puntos
        {
            get { return _puntos; }
            set { _puntos = value; }
        }

        private string _nombreCompleto;
        public string nombreCompleto
        {
            get { return _nombreCompleto; }
            set { _nombreCompleto = value; }
        }

        private string _conexion;
        public string conexion
        {
            get { return _conexion; }
            set { _conexion = value; }
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

        private int _opcion;
        public int opcion
        {
            get { return _opcion; }
            set { _opcion = value; }
        }
    }
}
