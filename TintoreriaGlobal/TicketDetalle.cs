using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaGlobal
{
    public class TicketDetalle
    {
        public decimal Cantidad { get; set; }
        public string  Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Descuento { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
    }
}
