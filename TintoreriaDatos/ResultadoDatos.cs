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
    public class ResultadoDatos
    {
        public void LLenarGridResultado(Resultado resultado)
        {
            try
            {
                object[] Valores = { resultado.id_sucursal, resultado.fecha, resultado.fecha2 };
                DataSet ds = SqlHelper.ExecuteDataset(resultado.conexion, "spCSLDB_CatResultado_Consulta_sp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            resultado.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcResultado(Resultado resultado, ref int Verificador)
        {
            try
            {
                object[] Valores = { resultado.opcion, resultado.id_estadoResultado,resultado.id_sucursal,resultado.fecha,resultado.titulo,resultado.id_operacionContable,resultado.id_seccion,resultado.monto, resultado.id_u };
                object res = SqlHelper.ExecuteScalar(resultado.conexion, "spCSLDB_abc_CatResultado", Valores);                
                if (res != null)
                    Verificador = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboOperacion(Resultado resultado)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(resultado.conexion, "spCSLDB_get_ComboCatOperacionContable");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            resultado.datos = ds.Tables[0];
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
