using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class PedidoNegocio
    {
        public void LLenarGridProductoPedidoDetalle(Producto producto)
        {
            try
            {
                PedidoDatos compra_datos = new PedidoDatos();
                compra_datos.LLenarGridProductoPedidoDetalle(producto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
