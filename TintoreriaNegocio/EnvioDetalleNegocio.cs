using System;
using TintoreriaGlobal;
using TintoreriaDatos;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class EnvioDetalleNegocio
    {
        public List<EnvioDetalle> CargarDatosGridEnvio(int id)
        {
            try
            {
                EnvioDetalleDatos _EDatos = new EnvioDetalleDatos();
                return _EDatos.CargarDatosGridEnvio(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GuardarDatos(DataTable _tbl, string user,ref int verificador)
        {
            try
            {
                EnvioDetalleDatos _EDatos = new EnvioDetalleDatos();
                _EDatos.GuardarDatos(_tbl, user,ref verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
