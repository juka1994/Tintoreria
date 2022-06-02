using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TintoreriaDatos
{
    public class itemSimbolo
    {
        [XmlAttribute]
        public string id;
        [XmlAttribute]
        public string value;
    }
   
}
