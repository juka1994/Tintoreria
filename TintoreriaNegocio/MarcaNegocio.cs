using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class MarcaNegocio
    {
        public void llenarGridMarca(Marca marca)
        {
            try
            {
                MarcaDatos marca_datos = new MarcaDatos();
                marca_datos.LLenarGridMarca(marca);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AbcMarca(Marca marca, ref int Verificador)
        {
            try
            {
                MarcaDatos marca_datos = new MarcaDatos();
                marca_datos.AbcMarca(marca, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboMarca(Marca marca)
        {
            try
            {
                MarcaDatos marca_datos = new MarcaDatos();
                marca_datos.ObtenerComboMarca(marca);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
