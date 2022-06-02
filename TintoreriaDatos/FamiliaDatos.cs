using TintoreriaGlobal;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaDatos
{
    public class FamiliaDatos
    {
        public void LlenarGridPorcentaje(Familia familia)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(familia.conexion, "spCSLDB_CatFamiliaPorcentaje_Consulta_sp", familia.id_familia);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            familia.lstTipoCrendencial = ds.Tables[0];
                        }
                    }
                }
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
                object res = SqlHelper.ExecuteScalar(familia.conexion, CommandType.StoredProcedure, "spCSLDB_abc_CatFamilia",
                new SqlParameter("@opcion", familia.opcion),
                new SqlParameter("@id_familia", familia.id_familia),
                new SqlParameter("@descripcion", familia.descripcion),
                new SqlParameter("@usuario", familia.id_u)
                );
                if (res != null)
                    Verificador = 0;
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
                DataSet ds = SqlHelper.ExecuteDataset(familia.conexion, "spCSLDB_CatFamilia_Consulta_sp", familia.tipoBusqueda, familia.busqueda);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            familia.datos = ds.Tables[0];
                        }
                    }
                }
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
                DataSet ds = SqlHelper.ExecuteDataset(familia.conexion, "spCSLDB_get_ComboCatFamilia");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            familia.datos = ds.Tables[0];
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
