using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class TipoDocumentoNegocio
    {
        public List<TipoDocumento> LlenarComboDocumentos(TipoDocumento datos)
        {
            try
            {
                TipoDocumentoDatos td = new TipoDocumentoDatos();
                return td.LlenarComboDocumentos(datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
