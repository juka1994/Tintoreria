using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class EmpresaNegocio
    {
        public void AbcEmpresa(Empresa empresa, ref int Verificador)
        {
            try
            {
                EmpresaDatos empresa_datos = new EmpresaDatos();
                empresa_datos.AbcEmpresa(empresa, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridEmpresa(Empresa empresa)
        {
            try
            {
                EmpresaDatos empresa_datos = new EmpresaDatos();
                empresa_datos.LLenarGridEmpresa(empresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarDatosEmpresa(Empresa empresa)
        {
            try
            {
                EmpresaDatos empresa_datos = new EmpresaDatos();
                empresa_datos.LLenarDatosEmpresa(empresa);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void LLenarGridCorreoEmpresa(Empresa empresa)
        {
            try
            {
                EmpresaDatos empresa_datos = new EmpresaDatos();
                empresa_datos.LLenarGridCorreoEmpresa(empresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void GuardarCorreoEmpresa(Empresa empresa, ref int Verificador)
        {
            try
            {
                EmpresaDatos empresa_datos = new EmpresaDatos();
                empresa_datos.GuardarCorreoEmpresa(empresa, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridCredencialReset(Empresa empresa)
        {
            try
            {
                EmpresaDatos empresa_datos = new EmpresaDatos();
                empresa_datos.LLenarGridCredencialReset(empresa);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcCredencialReset(Empresa empresa, ref int Verificador)
        {
            try
            {
                EmpresaDatos empresa_datos = new EmpresaDatos();
                empresa_datos.AbcCredencialReset(empresa, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
