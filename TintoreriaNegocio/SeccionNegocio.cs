using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class SeccionNegocio
    {
        public void LLenarGridSeccion(Seccion seccion)
        {
            try
            {
                SeccionDatos seccionDatos = new SeccionDatos();
                seccionDatos.LLenarGridSeccion(seccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AbcSeccion(Seccion seccion, ref int Verificador)
        {
            try
            {
                SeccionDatos seccionDatos = new SeccionDatos();
                seccionDatos.AbcSeccion(seccion, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboSeccion(Seccion seccion)
        {
            try
            {
                SeccionDatos seccionDatos = new SeccionDatos();
                seccionDatos.ObtenerComboSeccion(seccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
