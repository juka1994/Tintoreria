using System;
using TintoreriaDatos;
using TintoreriaGlobal;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class MembresiaNegocio
    {
        public void CargarDatosMembresia(Membresias _membresia)
        {
            try
            {
                MembresiaDatos _memDatos = new MembresiaDatos();
                _memDatos.CargarDatosMembresia(_membresia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ABCMembresia(Membresias _datos, ref int verificador)
        {
            try
            {
                MembresiaDatos _memDatos = new MembresiaDatos();
                _memDatos.ABCMembresia(_datos, ref verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
