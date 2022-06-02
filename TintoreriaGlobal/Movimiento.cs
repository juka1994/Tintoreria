using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Movimiento
    {
        private string _conexion;
        public string conexion
        {
            get { return _conexion; }
            set { _conexion = value; }
        }
        private string _id_caja;
        public string id_caja
        {
            get { return _id_caja; }
            set { _id_caja = value; }
        }
        private string _id_movimiento;
        public string id_movimiento
        {
            get { return _id_movimiento; }
            set { _id_movimiento = value; }
        }
        private string _id_sucursal;
        public string id_sucursal
        {
            get { return _id_sucursal; }
            set { _id_sucursal = value; }
        }
        private decimal _monto;
        public decimal monto
        {
            get { return _monto; }
            set { _monto = value; }
        }
        private string _motivo;
        public string motivo
        {
            get { return _motivo; }
            set { _motivo = value; }
        }
        private int _opcion;
        public int opcion
        {
            get { return _opcion; }
            set { _opcion = value; }
        }
        private int _tipoMovimiento;
        public int tipoMovimiento
        {
            get { return _tipoMovimiento; }
            set { _tipoMovimiento = value; }
        }
        private string _usuins;
        public string usuins
        {
            get { return _usuins; }
            set { _usuins = value; }
        }
        private bool _validador;
        public bool validador
        {
            get { return _validador; }
            set { _validador = value; }
        }

    }
}
