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
    public class MembresiaDatos
    {
        public void CargarDatosMembresia(Membresias _datos)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(_datos.conexion, "[Cat].[spCSLDB_get_Membresia]");
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ABCMembresia(Membresias _datos, ref int verificador)
        {
            try
            {
                object[] valores = {_datos.id_user,_datos.id_TipoCredencial,_datos.descripcion,_datos.opcion,_datos.porcentajexVenta};

                object res = SqlHelper.ExecuteScalar(_datos.conexion, "[Cat].[spCSLDB_ABC_ServTintoreria_Membresia]", valores);

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
    }
}
