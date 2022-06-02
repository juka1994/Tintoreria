using TintoreriaGlobal;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaDatos
{
    public class PedidoDatos
    {
        public void LLenarGridProductoPedidoDetalle(Producto producto)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(producto.conexion, "spCSLDB_CatProductoPedidoDetalle_Consulta_sp",producto.id_producto, producto.productoDetalle.id_sucursal);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            producto.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
