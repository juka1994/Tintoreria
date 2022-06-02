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
    public class DocumentosXPagarDatos
    {
        public void LLenarGridDatosRopaMonitor(DocumentosXPagar documentosXPagar)
        {


            object[] Valores = { documentosXPagar.idventa, documentosXPagar.id_sucursal };
            DataSet ds = SqlHelper.ExecuteDataset(documentosXPagar.conexion, "WAspCSLDB_CatDatosRopa_ConsultaMonitor_sp", Valores);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0] != null)
                    {
                        documentosXPagar.datos = ds.Tables[0];
                    }
                }
            }
        }

        public void LLenarGridXDatosRopa(DocumentosXPagar documentosXPagar)
        {
            
                object[] Valores = { documentosXPagar.idventa, documentosXPagar.id_sucursal };
                DataSet ds = SqlHelper.ExecuteDataset(documentosXPagar.conexion, "WAspCSLDB_CatDatosRopa_Consulta_sp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            documentosXPagar.datos = ds.Tables[0];
                        }
                    }
                }
            
        }

        public void LLenarGridXPagos(DocumentosXPagar documentosXPagar)
        {
            
                object[] Valores = { documentosXPagar.idventa, documentosXPagar.id_sucursal };
                DataSet ds = SqlHelper.ExecuteDataset(documentosXPagar.conexion, "WAspCSLDB_CatPagos_Consulta_sp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            documentosXPagar.datos = ds.Tables[0];
                        }
                    }
                }
           
        }

        public void LLenarGridDocumentosXPagar(DocumentosXPagar documentosXPagar, int tabIndex)
        {
            try
            {
                object[] Valores = { documentosXPagar.id_sucursal, tabIndex };
                DataSet ds = SqlHelper.ExecuteDataset(documentosXPagar.conexion, "spCSLDB_CatDocumentosXPagar_Consulta_sp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            documentosXPagar.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void LLenarGridDocumentosXPagarPagos(DocumentosXPagar documentosXPagar)
        {
            try
            {
                object[] Valores = { documentosXPagar.id_docXPagar,documentosXPagar.id_sucursal };
                DataSet ds = SqlHelper.ExecuteDataset(documentosXPagar.conexion, "spCSLDB_CatPagosDocumentosXID_Consulta_sp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            documentosXPagar.datos = ds.Tables[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcDocumentosXPagar2(DocumentosXPagar documentosXPagar, ref int Verificador)
        {
            try
            {
                object[] Valores = { documentosXPagar.opcion, documentosXPagar.id_pagoDocXPagar, documentosXPagar.id_docXPagar, documentosXPagar.id_sucursal, documentosXPagar.id_caja, documentosXPagar.monto, documentosXPagar.pago, documentosXPagar.imagen, documentosXPagar.id_u };
                object res = SqlHelper.ExecuteScalar(documentosXPagar.conexion, "spCSLDB_abc_CatDocumentosXPagarPagos2", Valores);
                if (res != null)
                {
                    documentosXPagar.id_pagoDocXPagar = res.ToString();
                    Verificador = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AbcDocumentosXPagar(DocumentosXPagar documentosXPagar, ref int Verificador)
        {
            try
            {
                object[] Valores = { documentosXPagar.opcion, documentosXPagar.id_pagoDocXPagar, documentosXPagar.id_docXPagar, documentosXPagar.id_sucursal, documentosXPagar.id_caja, documentosXPagar.monto, documentosXPagar.pago, documentosXPagar.imagen, documentosXPagar.id_u };
                object res = SqlHelper.ExecuteScalar(documentosXPagar.conexion, "spCSLDB_abc_CatDocumentosXPagarPagos", Valores);                
                if (res != null)
                {
                    documentosXPagar.id_pagoDocXPagar = res.ToString();
                    Verificador = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcAplicarBodega(DocumentosXPagar documentosXPagar, Bodega bodega, ref int Verificador)
        {
            try
            {
                object[] Valores = { documentosXPagar.id_pagoDocXPagar, documentosXPagar.id_docXPagar, documentosXPagar.id_sucursal, documentosXPagar.id_caja, documentosXPagar.monto, documentosXPagar.pago, bodega.nombreProducto, bodega.id_producto, bodega.id_tallaRopa, bodega.id_colorRopa, bodega.cantidad, documentosXPagar.id_u };
                object res = SqlHelper.ExecuteScalar(documentosXPagar.conexion, "spCSLDB_abc_CatAplicarBodega", Valores);
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
