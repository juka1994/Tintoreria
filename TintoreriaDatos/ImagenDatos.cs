using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TintoreriaGlobal;

namespace TintoreriaDatos
{
    public class ImagenDatos
    {
        public string ObtenerImagenTipoRopa(int id)
        {
            try
            {
                object Result = SqlHelper.ExecuteScalar(Comun.conexion, "SPCIDDB_ObtenerImagenTipoRopa", id);
                if (Result != null)
                {
                    return Result.ToString();
                }
                throw new FormatException("No se encontró imagen");
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
                object Result = SqlHelper.ExecuteScalar(Comun.conexion, "SPCIDDB_ObtenerImagenEstampadoRopa", id);
                if (Result != null)
                {
                    return Result.ToString();
                }
                throw new FormatException("No se encontró imagen");
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
                object Result = SqlHelper.ExecuteScalar(Comun.conexion, "SPCIDDB_ObtenerImagenFibraRopa", id);
                if (Result != null)
                {
                    return Result.ToString();
                }
                throw new FormatException("No se encontró imagen");
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
                object Result = SqlHelper.ExecuteScalar(Comun.conexion, "SPCIDDB_ObtenerImagenSimboloRopa", id);
                if (Result != null)
                {
                    return Result.ToString();
                }
                throw new FormatException("No se encontró imagen");
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
                object Result = SqlHelper.ExecuteScalar(Comun.conexion, "SPCIDDB_ObtenerImagenColorRopa", id);
                if (Result != null)
                {
                    return Result.ToString();
                }
                throw new FormatException("No se encontró imagen");
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
                object Result = SqlHelper.ExecuteScalar(Comun.conexion, "SPCIDDB_ObtenerImagenSubtipoRopa", id);
                if (Result != null)
                {
                    return Result.ToString();
                }
                throw new FormatException("No se encontró imagen");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
