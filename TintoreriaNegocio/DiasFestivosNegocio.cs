using System;
using TintoreriaDatos;
using TintoreriaGlobal;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace TintoreriaNegocio
{
    public class DiasFestivosNegocio
    {
        public DataTable LLenarDatosGrid()
        {
            try
            {
                DiasFestivosDatos _datos = new DiasFestivosDatos();
                return _datos.LLenarDatosGrid();
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
                DiasFestivosDatos _datos = new DiasFestivosDatos();
                return _datos.GetPedidosPendietesXfecha(fecha);
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
                DiasFestivosDatos _dDatos = new DiasFestivosDatos();
                _dDatos.ABCDiasFestivos(_datos, ref verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
