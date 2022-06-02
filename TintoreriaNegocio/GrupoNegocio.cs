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
    public class GrupoNegocio
    {
        #region Variables
        private readonly GrupoDatos oDatos;
        #endregion

        #region Constructor
        public GrupoNegocio()
        {
            oDatos = new GrupoDatos();
        }
        #endregion


        #region Métodos
        public void LlennarDatosGridGrupo(Grupo _datos)
        {
            try
            {
                GrupoDatos _grupoDatos = new GrupoDatos();
                _grupoDatos.LlenarDatosGridGrupo(_datos);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ABC_Grupo(Grupo _dato, ref int verificador)
        {
            try
            {
                GrupoDatos _grupoDato = new GrupoDatos();
                _grupoDato.ABC_Grupo(_dato, ref verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetCombo()
        {
            return oDatos.Getcombo();
        } 
        #endregion
    }
}
