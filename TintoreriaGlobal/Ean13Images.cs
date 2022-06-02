using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class Ean13Images
    {
        private string _id_ean13;
        public string id_ean13
        {
            get { return _id_ean13; }
            set { _id_ean13 = value; }
        }
        private string _path;
        public string path
        {
            get { return _path; }
            set { _path = value; }
        }
        private List<Ean13Images> _Lista01;
        public List<Ean13Images> Lista01
        {
            get { return _Lista01; }
            set { _Lista01 = value; }
        }
        private List<Ean13Images> _Lista02;
        public List<Ean13Images> Lista02
        {
            get { return _Lista02; }
            set { _Lista02 = value; }
        }
        private List<Ean13Images> _Lista03;
        public List<Ean13Images> Lista03
        {
            get { return _Lista03; }
            set { _Lista03 = value; }
        }
        private string _conexion;
        public string conexion
        {
            get { return _conexion; }
            set { _conexion = value; }
        }
        private string _id_producto;
        public string id_producto
        {
            get { return _id_producto; }
            set { _id_producto = value; }
        }
        private string _id_codigoEan;
        public string id_codigoEan
        {
            get { return _id_codigoEan; }
            set { _id_codigoEan = value; }
        }
    }
}
