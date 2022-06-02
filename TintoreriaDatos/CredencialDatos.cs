using TintoreriaGlobal;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaDatos
{
    public class CredencialDatos
    {
        public void LLenarGridCredenciales(Credenciales credenciales)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(credenciales.conexion, "spCSLDB_CatCredenciales_Consulta_sp");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            credenciales.datos = ds.Tables[0];
                        }
                    }
                }
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
                object[] Valores = { credenciales.id_credencial,credenciales.puntos,credenciales.monedero,credenciales.id_u };
                object res = SqlHelper.ExecuteScalar(credenciales.conexion, "spCSLDB_abc_CatCredenciales", Valores);                
                if(res!=null)
                    Verificador = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
