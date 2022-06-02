using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class DocumentosXPagarNegocio
    {

        public void LLenarGridDatosRopaMonitor(DocumentosXPagar documentosXPagar)
        {

            DocumentosXPagarDatos documentosXPagarDatos = new DocumentosXPagarDatos();
            documentosXPagarDatos.LLenarGridDatosRopaMonitor(documentosXPagar);

        }


        public void LLenarGridDatosRopa(DocumentosXPagar documentosXPagar)
        {
           
                DocumentosXPagarDatos documentosXPagarDatos = new DocumentosXPagarDatos();
                documentosXPagarDatos.LLenarGridXDatosRopa(documentosXPagar);
            
        }

        public void LLenarGridPagos(DocumentosXPagar documentosXPagar)
        {
            
                DocumentosXPagarDatos documentosXPagarDatos = new DocumentosXPagarDatos();
                documentosXPagarDatos.LLenarGridXPagos(documentosXPagar);
            
        }

        public void LLenarGridDocumentosXPagar(DocumentosXPagar documentosXPagar,int tabIndex)
        {
            try
            {
                DocumentosXPagarDatos documentosXPagarDatos = new DocumentosXPagarDatos();
                documentosXPagarDatos.LLenarGridDocumentosXPagar(documentosXPagar,tabIndex);
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
                DocumentosXPagarDatos documentosXPagarDatos = new DocumentosXPagarDatos();
                documentosXPagarDatos.LLenarGridDocumentosXPagarPagos(documentosXPagar);
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
                DocumentosXPagarDatos documentosXPagarDatos = new DocumentosXPagarDatos();
                documentosXPagarDatos.AbcDocumentosXPagar2(documentosXPagar, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcDocumentosXPagar(DocumentosXPagar documentosXPagar,ref int Verificador)
        {
            try
            {
                DocumentosXPagarDatos documentosXPagarDatos = new DocumentosXPagarDatos();
                documentosXPagarDatos.AbcDocumentosXPagar(documentosXPagar, ref Verificador);
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
                DocumentosXPagarDatos documentosXPagarDatos = new DocumentosXPagarDatos();
                documentosXPagarDatos.AbcAplicarBodega(documentosXPagar, bodega, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
