using TintoreriaGlobal;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaDatos
{
    public class ProductoImagenDatos
    {

        public void DescargarImagen(ProductoImagen producto,string idequipo, string idsursal,  ref int Verificador)
        {
            object[] Valores = { producto.IdImagnen, idequipo, idsursal };
            DataSet ds = SqlHelper.ExecuteDataset(producto.Conexion, "spCSLDB_abc_CatProductoImagenes_DownLoadProd", Valores);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0] != null)
                    {
                        DataTable tabla = new DataTable();
                        tabla = ds.Tables[0];
                        producto.Completado = true;
                        producto.imagen = tabla.Rows[0]["imagen"].ToString();
                        Verificador = 1;

                    }
                }
            }
            else
            {
                producto.Completado = false;
                Verificador = 0;
            }


        }


        public bool BuscarActualizacionImagen(string Conexion, string idequipo, string idsursal, string idimagen)
        {

            object[] Valores = { idimagen, idequipo, idsursal };
            int resultado = (int)SqlHelper.ExecuteScalar(Conexion, "spCSLDB_abc_CatProductoImagenes_IsExits", Valores);

            if (resultado == 1)
            {
                return true;
            }
            else
            {
                return false;
            }




        }


        public void LLenarGridProductoImagen(ProductoImagen producto)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(producto.Conexion, "spCSLDB_CatProductoImgenes_Consulta_sp", producto.IdProducto);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            producto.TablaDatos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcProductoImagen(ProductoImagen producto, ref int Verificador)
        {
           
                object[] Valores = { producto.opcion, producto.IdImagnen, producto.IdProducto, producto.Alt, producto.Title,
                                       producto.NombreArc, producto.TipoArc, producto.Descripcion, producto.id_u, producto.imagen };
                DataSet ds = SqlHelper.ExecuteDataset(producto.Conexion, "spCSLDB_abc_CatProductoImagenes", Valores);
                if (ds != null)
                {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0] != null)
                    {
                        DataTable tabla = new DataTable();
                        tabla = ds.Tables[0];
                        producto.Completado = true;
                        producto.UrlImagen = tabla.Rows[0]["UrlImagen"].ToString();
                        producto.UrlImagenMin = tabla.Rows[0]["UrlImagenTump"].ToString();
                        Verificador = 0;

                    }
                }
                else
                    Verificador = 5;
                }
                else
                {
                    producto.Completado = false;
                    Verificador = 1;
                }
           
        }
    }
}
