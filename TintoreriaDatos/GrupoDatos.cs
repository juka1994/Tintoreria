using System;
using TintoreriaGlobal;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.ApplicationBlocks.Data;


namespace TintoreriaDatos
{
    public class GrupoDatos : HelperSQL
    {
        #region Métodos
        public void LlenarDatosGridGrupo(Grupo _dato)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "[Cat].[spCSLDB_get_Grupo]");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            _dato.datosTabla = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ABC_Grupo(Grupo _dato, ref int verificador)
        {
            try
            {
                object[] valores = { _dato.id_user, _dato.id_Grupo, _dato.Descripcion, _dato.cobrarLavanderia, _dato.opcion };

                object res = SqlHelper.ExecuteScalar(ConexionSQL, "[Cat].[spCSLDB_ABC_ServTintoreria_Grupos]", valores);

                if (res.ToString() != "1")
                    verificador = 0;
                else
                    verificador = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Getcombo()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "[Cat].[spCSLDB_combo_grupo]");
                DataTable dt = new DataTable();

                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            dt = ds.Tables[0];
                        }
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion
    }
}
