using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class MaterialNegocio
    {
        public void llenarGridMaterial(Material material)
        {
            try
            {
                MaterialDatos material_datos = new MaterialDatos();
                material_datos.LLenarGridMaterial(material);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AbcMaterial(Material material, ref int Verificador)
        {
            try
            {
                MaterialDatos material_datos = new MaterialDatos();
                material_datos.AbcMaterial(material, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboMaterial(Material material)
        {
            try
            {
                MaterialDatos material_datos = new MaterialDatos();
                material_datos.ObtenerComboMaterial(material);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
