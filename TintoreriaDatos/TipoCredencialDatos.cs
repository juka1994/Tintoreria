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
    public class TipoCredencialDatos
    {
        public void LLenarGridTipoCredenciales(TipoCredenciales credenciales)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(credenciales.conexion, "spCSLDB_CatTipoCredenciales_Consulta_sp");
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
        public void AbcTipoCredenciales(TipoCredenciales credenciales, ref int Verificador)
        {
            try
            {
                object[] Valores = { credenciales.id_tipoCredencial,credenciales.descripcion,credenciales.puntos,credenciales.id_u };
                object res = SqlHelper.ExecuteScalar(credenciales.conexion, "spCSLDB_abc_CatTipoCredencial", Valores);                
                if(Convert.ToInt32(res)!=0)
                    Verificador = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ObtenerComboTipoCredencial(TipoCredenciales _dat)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(_dat.conexion, "[dbo].[spCSLDB_get_ComboCatTipoCredencial]");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            _dat.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
