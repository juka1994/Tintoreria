using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class TurnoNegocio
    {
        public void ObtenerComboTurno(Turno turno)
        {
            try
            {
                TurnoDatos turno_datos = new TurnoDatos();
                turno_datos.ObtenerComboTurno(turno);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
