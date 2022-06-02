using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class PrecioXTipoEntrega
    {
        public int Id { get; set; }
        public int IdTipoRopa { get; set; }
        public int IdTipoEntrega { get; set; }

        public string NombreTipoRopa { get; set; }
        public decimal Precio { get; set; }
    }
}
