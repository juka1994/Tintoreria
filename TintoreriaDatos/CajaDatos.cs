using TintoreriaGlobal;
using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TintoreriaDatos
{
    public class CajaDatos
    {
        public void AgregarDeposito(Movimiento deposito)
        {
            try
            {
                if (SqlHelper.ExecuteNonQuery(deposito.conexion, "spCSLDB_abc_Depositos", deposito.opcion, deposito.id_movimiento, deposito.id_caja, deposito.usuins, deposito.monto, deposito.motivo, deposito.id_sucursal) <= 0)
                    deposito.validador = false;
                else
                    deposito.validador = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AgregarRetiro(Movimiento retiro)
        {
            try
            {
                if (SqlHelper.ExecuteNonQuery(retiro.conexion, "spCSLDB_abc_Retiros", retiro.opcion, retiro.id_movimiento, retiro.id_caja, retiro.usuins, retiro.tipoMovimiento, retiro.monto, retiro.motivo, retiro.id_sucursal) <= 0)
                    retiro.validador = false;
                else
                    retiro.validador = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GuardarAperturaCaja(Caja caja)
        {
            try
            {
                object[] valores = {  caja.id_caja, caja.id_equipo, caja.id_sucursal, caja.M50C, caja.M1P, caja.M2P, caja.M5P, caja.M10P, caja.M20P, caja.M100P, 
                                      caja.B20P, caja.B50P, caja.B100P, caja.B200P, caja.B500P, caja.B1000P, caja.Total, caja.Id_U, caja.FechaIngreso, caja.HoraIngreso};
                if (SqlHelper.ExecuteNonQuery(caja.CadConexion, "spCSLDB_aperturaCaja_Insertar_sp", valores) > 1)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GuardarMontoTotalEnCaja(Caja caja)
        {
            try
            {
                object[] Valores = { caja.id_caja, caja.id_sucursal, caja.M50C, caja.M1P, caja.M2P, caja.M5P, caja.M10P, caja.M20P, caja.M100P, 
                                     caja.B20P, caja.B50P, caja.B100P, caja.B200P, caja.B500P, caja.B1000P, caja.Total,caja.Id_U};
                if (SqlHelper.ExecuteNonQuery(caja.CadConexion, "spCSLDB_CierreCaja_Modificar_sp", Valores) > 1)
                    return 1;
                else
                    return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerCajaXID(Caja caja)
        {
            try
            {
                object[] Valores = { caja.id_caja, caja.id_sucursal };
                SqlDataReader SqlDr = SqlHelper.ExecuteReader(caja.CadConexion, "spCSLDB_CatCajaXSucursalID_Consulta_sp", Valores);
                while (SqlDr.Read())
                {
                    caja.TotalInicioCaja = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("caja_inicial"));
                    caja.TotalVentas = (float) SqlDr.GetDecimal(SqlDr.GetOrdinal("ventas"));
                    caja.TotalPedidos = (float) SqlDr.GetDecimal(SqlDr.GetOrdinal("pedidos"));
                    caja.TotalCambios = (float) SqlDr.GetDecimal(SqlDr.GetOrdinal("cambios"));
                    caja.TotalCancelaciones = (float) SqlDr.GetDecimal(SqlDr.GetOrdinal("cancelaciones"));
                    caja.TotalCompras = (float) SqlDr.GetDecimal(SqlDr.GetOrdinal("compras"));
                    caja.TotalDepositos = (float) SqlDr.GetDecimal(SqlDr.GetOrdinal("depositos"));
                    caja.TotalRetirosPagos = (float) SqlDr.GetDecimal(SqlDr.GetOrdinal("retiros"));
                    caja.TotalEfectivo = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("efectivo"));
                    caja.TotalMonedero = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("monedero"));
                    caja.TotalTarjetas = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("tarjetas"));
                    caja.TotalTransferencia = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("transferencias"));
                    caja.TotalCaja = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("total"));
                    caja.TotalFinalCaja = (float)SqlDr.GetDecimal(SqlDr.GetOrdinal("caja_final"));
                    caja.urlLogo = (string)SqlDr.GetString(SqlDr.GetOrdinal("Logo"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
