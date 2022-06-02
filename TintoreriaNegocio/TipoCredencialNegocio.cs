using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class TipoCredencialNegocio
    {
        public void LLenarGridTipoCredenciales(TipoCredenciales credenciales)
        {
            try
            {
                TipoCredencialDatos credenciales_datos = new TipoCredencialDatos();
                credenciales_datos.LLenarGridTipoCredenciales(credenciales);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AbcTipoCredenciales(TipoCredenciales credenciales, ref int Verificador)
        {
            try
            {
                TipoCredencialDatos credenciales_datos = new TipoCredencialDatos();
                credenciales_datos.AbcTipoCredenciales(credenciales, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerComboTipoCredencial(TipoCredenciales _datos)
        {
            try
            {
                TipoCredencialDatos credencialDatos = new TipoCredencialDatos();
                credencialDatos.ObtenerComboTipoCredencial(_datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
