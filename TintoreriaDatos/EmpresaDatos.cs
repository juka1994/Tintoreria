using TintoreriaGlobal;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaDatos
{
    public class EmpresaDatos
    {
        public void AbcEmpresa(Empresa empresa, ref int Verificador)
        {
            try
            {
                object[] Valores = { empresa.id_empresa, empresa.razonSocial, empresa.nombreComercial, empresa.slogan, empresa.logo, empresa.rfc, empresa.mensaje1, empresa.mensaje2, empresa.mensaje3,empresa.numeroTickets, empresa.id_u };
                object res = SqlHelper.ExecuteScalar(empresa.conexion, "spCSLDB_abc_CatEmpresas", Valores);
                if (res != null)
                    Verificador = 0;
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
                DataSet ds = SqlHelper.ExecuteDataset(empresa.conexion, "spCSLDB_CatEmpresas_Consulta_sp");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            empresa.datos = ds.Tables[0];
                        }
                    }
                }
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
                DataSet ds = SqlHelper.ExecuteDataset(empresa.conexion, "spCSLDB_CatEmpresas_ConsultaModificar_sp");
                if(ds!=null)
                {
                    if(ds.Tables.Count>0)
                    {
                        if(ds.Tables[0]!=null)
                        {
                            empresa.datos = ds.Tables[0];
                        }
                    }
                }
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
                DataSet ds = SqlHelper.ExecuteDataset(empresa.conexion, "spCSLDB_CatCorreoEmpresa_Consulta_sp");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            empresa.datos = ds.Tables[0];
                        }
                    }
                }
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
                object[] Valores = { empresa.id_empresa, empresa.correoElectronico, empresa.correoSistema, empresa.password, empresa.ssl, empresa.html, empresa.puerto, empresa.host, empresa.id_u };
                object res = SqlHelper.ExecuteScalar(empresa.conexion, "spCSLDB_set_CatCorreoEmpresa", Valores);
                if (res != null)
                    Verificador = 0;
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
                DataSet ds = SqlHelper.ExecuteDataset(empresa.conexion, "spCSLDB_CatCredencialReset_Consulta_sp");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            empresa.datos = ds.Tables[0];
                        }
                    }
                }
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
                object[] Valores = {empresa.opcion, empresa.id_empresa, empresa.fechaDeCredenciales1, empresa.fechaDeCredenciales2, empresa.id_u };
                object res = SqlHelper.ExecuteScalar(empresa.conexion, "spCSLDB_abc_CatResetCredencial", Valores);
                if (res != null)
                    Verificador = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
