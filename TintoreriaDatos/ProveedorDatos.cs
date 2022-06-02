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
    public class ProveedorDatos
    {
        public void AbcProveedor(Proveedor proveedor, ref int Verificador)
        {
            try
            {
                object[] Valores = { proveedor.opcion, proveedor.id_proveedor, proveedor.proveedor, proveedor.direccion, proveedor.telefono, proveedor.contacto, proveedor.correo, proveedor.sendMail, proveedor.user, proveedor.password, proveedor.cambio_passs, proveedor.id_u };
                object res = SqlHelper.ExecuteScalar(proveedor.conexion, "spCSLDB_abc_CatProveedor", Valores);
                if (res != null)
                    Verificador = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridProveedor(Proveedor proveedor)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(proveedor.conexion, "spCSLDB_CatProveedor_Consulta2_sp", proveedor.tipoBusqueda, proveedor.busqueda);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            proveedor.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboProveedor(Proveedor proveedor)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(proveedor.conexion, "spCSLDB_get_ComboCatProveedor");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            proveedor.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboProveedorGeneral(Proveedor proveedor)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(proveedor.conexion, "spCSLDB_get_ComboCatProveedorGeneral");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            proveedor.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool VerificarUserProveedor(string conexion, string user, string id_proveedor)
        {
            try
            {
                object[] Valores = { user, id_proveedor };
                object res = SqlHelper.ExecuteScalar(conexion, "spCSLDB_CatValidarUserProveedor_Consulta_sp", Valores);
                if (res != null)
                    return res.ToString() == "1" ? true : false;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
