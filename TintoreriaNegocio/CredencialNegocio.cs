using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class CredencialNegocio
    {
        public void LLenarGridCredenciales(Credenciales credenciales)
        {
            try
            {
                CredencialDatos credenciales_datos = new CredencialDatos();
                credenciales_datos.LLenarGridCredenciales(credenciales);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AbcCredenciales(Credenciales credenciales, ref int Verificador)
        {
            try
            {
                CredencialDatos credenciales_datos = new CredencialDatos();
                credenciales_datos.AbcCredenciales(credenciales, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
