namespace TintoreriaDatos
{
    using Microsoft.ApplicationBlocks.Data;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using TintoreriaGlobal;

    public class VentaTintoreriaDatos : HelperSQL
    {
        public void ActualizarStatusProceso(string idsucursal, string idventa, int status)
        {

           SqlHelper.ExecuteNonQuery(Comun.conexion, "WspCSLDB_TintoreriaActualizarStatusProcesos", idsucursal, idventa, status);

        }

        public void ObtenerUbicaciones(string idsucursal, int idservicio, ref string idubicacion, ref string ubicacion)
        {
            

            idubicacion = "0";
            ubicacion = "S/N";
            DataSet ds = SqlHelper.ExecuteDataset(Comun.conexion, "WspCSLDB_TintoreriaUbiTintoreria", idsucursal, idservicio);

            if (ds != null)
                if (ds.Tables[0] != null)
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        idubicacion = ds.Tables[0].Rows[0]["id_ubicacion"].ToString();
                        ubicacion = ds.Tables[0].Rows[0]["descripcion"].ToString();
                    }
        }

        public DataTable ObtenerListaProcesos(string idsucursal, int idstatus)
        {
            DataSet ds = SqlHelper.ExecuteDataset(Comun.conexion, "WspCSLDB_TintoreriaListaVentasXProceso", idsucursal, idstatus);

            if (ds != null)
                if (ds.Tables[0] != null)
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return ds.Tables[0];
                    }

            return null;

        }

        public Ticket GetDatosGeneralesTicket(string idVenta)
        {
            try
            {
                Ticket item = new Ticket();
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(ConexionSQL, "[Ticket].[get_TicketDetalles]");
                while (dr.Read())
                {
                    item = new Ticket();
                    //item.Cantidad = !dr.IsDBNull(dr.GetOrdinal("cantidad")) ? dr.GetInt32(dr.GetOrdinal("cantidad")) : 0;
                    //item.Descripcion = !dr.IsDBNull(dr.GetOrdinal("descripcion")) ? dr.GetString(dr.GetOrdinal("descripcion")) : string.Empty;
                    //item.PrecioUnitario = !dr.IsDBNull(dr.GetOrdinal("precioUnitario")) ? dr.GetDecimal(dr.GetOrdinal("precioUnitario")) : 0;
                    //item.Impuesto = !dr.IsDBNull(dr.GetOrdinal("impuesto")) ? dr.GetDecimal(dr.GetOrdinal("impuesto")) : 0;
                    //item.Descuento = !dr.IsDBNull(dr.GetOrdinal("descuento")) ? dr.GetDecimal(dr.GetOrdinal("descuento")) : 0;
                    //item.Subtotal = !dr.IsDBNull(dr.GetOrdinal("subtotal")) ? dr.GetDecimal(dr.GetOrdinal("subtotal")) : 0;
                    //item.Total = !dr.IsDBNull(dr.GetOrdinal("total")) ? dr.GetDecimal(dr.GetOrdinal("total")) : 0;

                }
                dr.Close();

                return item;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TicketDetalle> GetListaTicketDetalles(string idVenta)
        {
            try
            {
                List<TicketDetalle> lista = new List<TicketDetalle>();
                TicketDetalle item;
                SqlDataReader dr = null;
                dr = SqlHelper.ExecuteReader(ConexionSQL, "[Ticket].[get_TicketDetalles]");
                while (dr.Read())
                {
                    item = new TicketDetalle();
                    item.Cantidad = !dr.IsDBNull(dr.GetOrdinal("cantidad")) ? dr.GetInt32(dr.GetOrdinal("cantidad")) : 0;
                    item.Descripcion = !dr.IsDBNull(dr.GetOrdinal("descripcion")) ? dr.GetString(dr.GetOrdinal("descripcion")) : string.Empty;
                    item.PrecioUnitario = !dr.IsDBNull(dr.GetOrdinal("precioUnitario")) ? dr.GetDecimal(dr.GetOrdinal("precioUnitario")) : 0;
                    item.Impuesto = !dr.IsDBNull(dr.GetOrdinal("impuesto")) ? dr.GetDecimal(dr.GetOrdinal("impuesto")) : 0;
                    item.Descuento = !dr.IsDBNull(dr.GetOrdinal("descuento")) ? dr.GetDecimal(dr.GetOrdinal("descuento")) : 0;
                    item.Subtotal = !dr.IsDBNull(dr.GetOrdinal("subtotal")) ? dr.GetDecimal(dr.GetOrdinal("subtotal")) : 0;
                    item.Total = !dr.IsDBNull(dr.GetOrdinal("total")) ? dr.GetDecimal(dr.GetOrdinal("total")) : 0;

                    lista.Add(item);
                }
                dr.Close();
                
                return lista;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetPreciosPorTipoProducto()
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(Comun.conexion, "[Cat].[spCIDDB_get_ListaDePreciosXTipoEntrega]");
                DataTable dt = new DataTable();
                if (ds != null)
                    if (ds.Tables[0] != null)
                        if (ds.Tables[0].Rows.Count > 0)
                            return dt = ds.Tables[0];
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
