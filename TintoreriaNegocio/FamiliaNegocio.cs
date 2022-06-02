using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class FamiliaNegocio
    {
        public void LlenarGridPorcentaje(Familia familia)
        {
            try
            {
                FamiliaDatos familia_datos = new FamiliaDatos();
                familia_datos.LlenarGridPorcentaje(familia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcFamilia(Familia familia, ref int Verificador)
        {
            try
            {
                FamiliaDatos familia_datos = new FamiliaDatos();
                familia_datos.AbcFamilia(familia, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridFamilia(Familia familia)
        {
            try
            {
                FamiliaDatos familia_datos = new FamiliaDatos();
                familia_datos.LLenarGridFamilia(familia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboFamilia(Familia familia)
        {
            try
            {
                FamiliaDatos familia_datos = new FamiliaDatos();
                familia_datos.ObtenerComboFamilia(familia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
