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
    public class DiasFestivosDatos: HelperSQL
    {
        public DataTable LLenarDatosGrid()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "[Cat].[spCSLDB_get_DiasFestivos]");
                DataTable dt = new DataTable();
                if(ds != null)
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

        public List<DataTable> GetPedidosPendietesXfecha(DateTime fecha)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "[Cat].[spCSLDB_GET_PedidosPendientesXentregrar]",fecha);
                List<DataTable> list = new List<DataTable>();
                if (ds != null)
                {
                    if (ds.Tables.Count == 2)
                    {
                        if (ds.Tables[0] != null)
                        {
                            list.Add(ds.Tables[0]);
                        }

                        if (ds.Tables[1] != null)
                        {
                            list.Add(ds.Tables[1]);
                        }
                    }                        
                }

                return list;
                        
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ABCDiasFestivos(DiasFestivos _datos, ref int verificador)
        {
            try
            {
                object[] valores = {_datos.id_user,_datos.id_diasFestivos,_datos.descripcion,_datos.diaFestivo,_datos.opcion};

                object res = SqlHelper.ExecuteScalar(ConexionSQL, "[Cat].[spCSLDB_ABC_ServTintoreria_FechasFestivas]", valores);


                if (res.ToString() == "1000")
                    verificador = 2;
                else if (res.ToString() != "1")
                    verificador = 0;
                else
                    verificador = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
