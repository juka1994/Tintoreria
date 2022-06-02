using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TintoreriaDatos;

namespace TintoreriaNegocio
{
    public class ImagenNegocio
    {

        public string ObtenerImagenTipoRopa(int id)
        {
            try
            {
                ImagenDatos datos = new ImagenDatos();
                return datos.ObtenerImagenTipoRopa(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ObtenerImagenEstampadoRopa(int id)
        {
            try
            {
                ImagenDatos datos = new ImagenDatos();
                return datos.ObtenerImagenEstampadoRopa(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ObtenerImagenFibraRopa(int id)
        {
            try
            {
                ImagenDatos datos = new ImagenDatos();
                return datos.ObtenerImagenFibraRopa(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ObtenerImagenSimboloRopa(int id)
        {
            try
            {
                ImagenDatos datos = new ImagenDatos();
                return datos.ObtenerImagenSimboloRopa(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ObtenerImagenColorRopa(int id)
        {
            try
            {
                ImagenDatos datos = new ImagenDatos();
                return datos.ObtenerImagenColorRopa(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string ObtenerImagenSubtipoRopa(int id)
        {
            try
            {
                ImagenDatos datos = new ImagenDatos();
                return datos.ObtenerImagenSubtipoRopa(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
