using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class MotivoNegocio
    {
        public void LLenarGridMotivo(Motivo motivo)
        {
            try
            {
                MotivoDatos motivoDatos = new MotivoDatos();
                motivoDatos.LLenarGridMotivo(motivo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcMotivo(Motivo motivo, ref int Verificador)
        {
            try
            {
                MotivoDatos motivoDatos = new MotivoDatos();
                motivoDatos.AbcMotivo(motivo, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboMotivo(Motivo motivo)
        {
            try
            {
                MotivoDatos motivoDatos = new MotivoDatos();
                motivoDatos.ObtenerComboMotivo(motivo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}
