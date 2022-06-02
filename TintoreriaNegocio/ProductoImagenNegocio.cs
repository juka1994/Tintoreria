using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class ProductoImagenNegocio
    {
        public void LLenarGridProductoImg(ProductoImagen producto)
        {
           
                ProductoImagenDatos producto_datos = new ProductoImagenDatos();
                producto_datos.LLenarGridProductoImagen(producto);
           
        }

        public bool BuscarActualizacionImagen(string Conexion, string idequipo, string idsursal, string idimagen)
        {

            ProductoImagenDatos producto_datos = new ProductoImagenDatos();
            return producto_datos.BuscarActualizacionImagen(Conexion,idequipo, idsursal, idimagen);

        }

        public void DescargarImagen(ProductoImagen producto, string idequipo, string idsursal, ref int Verificador)
        {

            ProductoImagenDatos producto_datos = new ProductoImagenDatos();
            producto_datos.DescargarImagen(producto, idequipo, idsursal, ref Verificador);

        }

        public void AbcProductoImg(ProductoImagen producto, ref int Verificador)
        {
           
                ProductoImagenDatos producto_datos = new ProductoImagenDatos();
                producto_datos.AbcProductoImagen(producto, ref Verificador);
          
        }
    }
}
