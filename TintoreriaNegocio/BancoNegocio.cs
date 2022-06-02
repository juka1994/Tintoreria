using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class BancoNegocio
    {
        public List<Banco> llenarComboBancos(Banco datos)
        {
            try
            {
                BancoDatos bd = new BancoDatos();
                return bd.llenarComboBancos(datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
