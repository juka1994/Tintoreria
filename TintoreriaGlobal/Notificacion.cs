using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Notificacion
    {
        private string _id_notificacion;
        public string id_notificacion
        {
            get { return _id_notificacion; }
            set { _id_notificacion = value; }
        }        
        private string _id_generico;
        public string id_generico
        {
            get { return _id_generico; }
            set { _id_generico = value; }
        }        
        private int _id_statusNotificacion;
        public int id_statusNotificacion
        {
            get { return _id_statusNotificacion; }
            set { _id_statusNotificacion = value; }
        }        
        private string _id_sucursal;
        public string id_sucursal
        {
            get { return _id_sucursal; }
            set { _id_sucursal = value; }
        }
        private int _id_tipoNotificacion;
        public int id_tipoNotificacion
        {
            get { return _id_tipoNotificacion; }
            set { _id_tipoNotificacion = value; }
        }
        private string _id_notificacionApp;
        public string id_notificacionApp
        {
            get { return _id_notificacionApp; }
            set { _id_notificacionApp = value; }
        }
        private bool _enviar;
        public bool enviar
        {
            get { return _enviar; }
            set { _enviar = value; }
        }
        private string _nombre;
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        private string _texto;
        public string texto
        {
            get { return _texto; }
            set { _texto = value; }
        }
        private string _descripcion;
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        private string _id_persona;
        public string id_persona
        {
            get { return _id_persona; }
            set { _id_persona = value; }
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
    }
}
