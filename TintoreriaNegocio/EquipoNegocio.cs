using TintoreriaDatos;
using TintoreriaGlobal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaNegocio
{
    public class EquipoNegocio
    {
        public void llenarGridEquipo(Equipo equipo)
        {
            try
            {
                EquipoDatos equipo_datos = new EquipoDatos();
                equipo_datos.LLenarGridEquipo(equipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcEquipo(Equipo equipo, ref int Verificador)
        {
            try
            {
                EquipoDatos equipo_datos = new EquipoDatos();
                equipo_datos.AbcEquipo(equipo, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AbcConfiguracionGrid(Equipo equipo, ref int Verificador)
        {
            try
            {
                EquipoDatos equipo_datos = new EquipoDatos();
                equipo_datos.AbcConfiguracionGrid(equipo, ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ConsultaEquipo(Equipo equipo)
        {
            try
            {
                EquipoDatos equipo_datos = new EquipoDatos();
                equipo_datos.ConsultaEquipo(equipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboEquipo(Equipo equipo)
        {
            try
            {
                EquipoDatos equipo_datos = new EquipoDatos();
                equipo_datos.ObtenerComboEquipo(equipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboEquipoNoAsignados(Equipo equipo)
        {
            try
            {
                EquipoDatos equipo_datos = new EquipoDatos();
                equipo_datos.ObtenerComboEquipoNoAsignados(equipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerComboEquipoAsignadosXSucursal(Equipo equipo)
        {
            try
            {
                EquipoDatos equipo_datos = new EquipoDatos();
                equipo_datos.ObtenerComboEquipoAsignadosXSucursal(equipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }  
        public int asignarEquipoMAC(Equipo equipo)
        {
            try
            {
                EquipoDatos equipo_datos = new EquipoDatos();
                return equipo_datos.asignarEquipoMAC(equipo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
