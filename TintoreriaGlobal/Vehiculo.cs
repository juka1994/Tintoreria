using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Vehiculo
    {
        private int _ID_vehiculo;
        public int ID_vehiculo
        {
            get { return _ID_vehiculo; }
            set { _ID_vehiculo = value; }
        }


        private string _NombreVeh;
        public string NombreVeh
        {
            get { return _NombreVeh; }
            set { _NombreVeh = value; }
        }

        private string _Placas;
        public string placas
        {
            get { return _Placas; }
            set { _Placas = value; }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private DataTable _datosTabla;
        public DataTable datosTabla
        {
            get { return _datosTabla; }
            set { _datosTabla = value; }
        }

        private int _opcion;
        public int opcion
        {
            get { return _opcion; }
            set { _opcion = value; }
        }

        public string conexion { get; set; }
        public string IDUsuario { get; set; }
    }
}
