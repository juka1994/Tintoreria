using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TintoreriaNegocio
{
    public class UnidadMedidaNegocio
    {
        public void llenarGridUnidadMedida(UnidadMedida unidadMedida)
        {
            try
            {
                UnidadMedidaDatos unidadMedida_datos = new UnidadMedidaDatos();
                unidadMedida_datos.LLenarGridUnidadMedida(unidadMedida);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcUnidadMedida(UnidadMedida unidadMedida, ref int Verificador)
        {
            try
            {
                UnidadMedidaDatos unidadMedida_datos = new UnidadMedidaDatos();
                unidadMedida_datos.AbcUnidadMedida(unidadMedida, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboUnidadMedida(UnidadMedida unidadmedida)
        {
            try
            {
                UnidadMedidaDatos unidadMedida_datos = new UnidadMedidaDatos();
                unidadMedida_datos.ObtenerComboUnidadMedida(unidadmedida);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetComboUnidadMedidaXIdProducto(string idProducto)
        {
            UnidadMedidaDatos oDatos = new UnidadMedidaDatos();
            return oDatos.GetComboUnidadMedidaXIdProducto(idProducto);
        }
    }
}
