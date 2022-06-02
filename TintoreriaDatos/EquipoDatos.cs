using TintoreriaGlobal;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaDatos
{
    public class EquipoDatos
    {
        public void LLenarGridEquipo(Equipo equipo)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(equipo.conexion, "spCSLDB_CatEquipo_Consulta_sp");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            equipo.datos = ds.Tables[0];
                        }
                    }
                }
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
                object[] Valores = { equipo.opcion, equipo.id_equipo, equipo.id_sucursal, equipo.nombre, equipo.macAddress ?? string.Empty, equipo.namePrinter ?? string.Empty, equipo.liberarEquipo, equipo.id_u };
                object res = SqlHelper.ExecuteScalar(equipo.conexion, "spCSLDB_abc_CatEquipo", Valores);
                if (res.ToString() != "1")
                    Verificador = 0;
                else
                    Verificador = 1;
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
                object[] Valores = { equipo.id_equipo, equipo.namePrinter, equipo.id_u };
                object res = SqlHelper.ExecuteScalar(equipo.conexion, "spCSLDB_abc_CatConfiguracionGrid", Valores);
                if (res != null)
                    Verificador = 0;
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
                object[] Valores = { equipo.id_equipo };
                DataSet ds = SqlHelper.ExecuteDataset(equipo.conexion, "spCSLDB_CatConfiguracionGrid_Consulta_sp", Valores);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            if (ds.Tables[0].Rows.Count == 1)
                            {
                                equipo.nombre = ds.Tables[0].Rows[0][1].ToString();
                                equipo.macAddress = ds.Tables[0].Rows[0][2].ToString();
                                equipo.namePrinter = ds.Tables[0].Rows[0][3].ToString();
                            }
                        }
                    }
                }
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
                DataSet ds = SqlHelper.ExecuteDataset(equipo.conexion, "spCSLDB_get_ComboCatEquipo");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            equipo.datos = ds.Tables[0];
                        }
                    }
                }
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
                DataSet ds = SqlHelper.ExecuteDataset(equipo.conexion, "spCSLDB_get_ComboCatEquipoNoAsignados");
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            equipo.datos = ds.Tables[0];
                        }
                    }
                }
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
                DataSet ds = SqlHelper.ExecuteDataset(equipo.conexion, "spCSLDB_get_ComboCatEquipoAsignadosXSucursal",equipo.id_sucursal);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0] != null)
                        {
                            equipo.datos = ds.Tables[0];
                        }
                    }
                }
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
                object[] parametros = { equipo.opcion, equipo.id_equipo, equipo.macAddress, equipo.nombre, equipo.namePrinter, equipo.id_sucursal };
                if (SqlHelper.ExecuteNonQuery(equipo.conexion, "spCSLDB_equipoMac_Asignar_sp", parametros) > 0)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
