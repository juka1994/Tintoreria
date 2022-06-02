using System;
using TintoreriaDatos;
using TintoreriaGlobal;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace TintoreriaDatos
{
    public class TipoEntregaDatos : HelperSQL
    {
        #region Métodos
        public TipoEntrega LLenarDatosGrid(TipoEntrega _datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "[Cat].[spCSLDB_Get_TipoEntrega]");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            _datos.datosTabla = ds.Tables[0];
                        }
                    }
                }
                return _datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ABCTipoEntrega(TipoEntrega _dato, ref int verificador)
        {
            try
            {
                object[] valores = { _dato.id_tipoEntrega, _dato.descripcion, _dato.horas, _dato.precioXkilo, _dato.id_user, _dato.opcion };

                object res = SqlHelper.ExecuteScalar(ConexionSQL, "[Cat].[spCSLDB_ABC_ServTintoreria_TipoEntrega]", valores);

                if (res.ToString() != "1")
                {
                    verificador = 0;
                }
                else
                {
                    verificador = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetCombo()
        {
            DataSet ds = SqlHelper.ExecuteDataset(ConexionSQL, "[Cat].[spCIDDB_combo_tipoEntrega]");
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
            ds.Dispose();
            return dt;
        }
        #endregion
    }
}
