using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TintoreriaGlobal;

namespace TintoreriaDatos
{
    public class Vales_Datos
    {
        public void ActivarVale(Vales Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_ActivarVale", Datos.IDVale, Datos.IDUsuario);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                        Datos.Completado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ReActivarVale(Vales Datos)
        {
            try
            {
                Datos.Completado = false;
                object[] Parametros = { Datos.IDVale, Datos.CantLimite, Datos.FechaInicio, Datos.FechaFin, Datos.IDUsuario };
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_ReactivarVale", Parametros);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                        Datos.Completado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EliminarVale(Vales Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_EliminarVale", Datos.IDVale, Datos.IDUsuario);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                        Datos.Completado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SuspenderVale(Vales Datos)
        {
            try
            {
                Datos.Completado = false;
                object Result = SqlHelper.ExecuteScalar(Datos.Conexion, "spCSLDB_set_SuspenderVale", Datos.IDVale, Datos.IDUsuario);
                if (Result != null)
                {
                    int Resultado = 0;
                    int.TryParse(Result.ToString(), out Resultado);
                    if (Resultado == 1)
                        Datos.Completado = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ABCVales(Vales Datos)
        {
            try
            {
                object[] parametros = { Datos.Opcion, Datos.IDVale, Datos.IDTipoVale, Datos.Nombre, Datos.Folio, Datos.CantLimite,
                                        Datos.Monto, Datos.Porcentaje, Datos.Abierto, Datos.RangoFechas, Datos.FechaInicio,
                                        Datos.FechaFin, Datos.Lunes, Datos.Martes, Datos.Miercoles, Datos.Jueves,
                                        Datos.Viernes, Datos.Sabado, Datos.Domingo, Datos.CantRequeridad, Datos.CantGratis, Datos.CantidadRequeridaNxN,
                                        Datos.CantidadGratisNxN, Datos.IDProductoNxN,Datos.IDProductoRequerido, Datos.IDProductoGratis, Datos.IDUsuario };
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_abc_Vales", parametros);
                Datos.Completado = false;
                while (Dr.Read())
                {
                    Datos.Resultado = Dr.IsDBNull(Dr.GetOrdinal("Resultado")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("Resultado"));
                    if (Datos.Resultado == 1)
                    {
                        Datos.Completado = true;
                        Datos.IDVale = Dr.IsDBNull(Dr.GetOrdinal("IDVale")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDVale"));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerVales(Vales Datos)
        {
            try
            {
                object[] Parametros = { Datos.TabVales };
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_Vales", Parametros);
                Datos.TablaDatos = new DataTable();
                if (ds != null)
                    if (ds.Tables.Count == 1)
                        Datos.TablaDatos = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ObtenerValesBusqueda(Vales Datos)
        {
            try
            {
                object[] Parametros = { Datos.TabVales, Datos.OpcionRadioButton, Datos.Nombre };
                DataSet ds = SqlHelper.ExecuteDataset(Datos.Conexion, "spCSLDB_get_ValesBusqueda2", Parametros);
                Datos.TablaDatos = new DataTable();
                if (ds != null)
                    if (ds.Tables.Count == 1)
                        Datos.TablaDatos = ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Vales ObtenerValeDetalle(Vales Datos)
        {
            try
            {
                Vales Resultado = new Vales();
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ValesDetalle", Datos.IDVale);
                while (Dr.Read())
                {
                    Resultado.IDVale = !Dr.IsDBNull(Dr.GetOrdinal("id_vale")) ? Dr.GetString(Dr.GetOrdinal("id_vale")) : string.Empty;
                    Resultado.IDTipoVale = !Dr.IsDBNull(Dr.GetOrdinal("id_tipoVale")) ? Dr.GetInt32(Dr.GetOrdinal("id_tipoVale")) : 0;
                    Resultado.IDEstatusVale = !Dr.IsDBNull(Dr.GetOrdinal("id_estatusVale")) ? Dr.GetInt32(Dr.GetOrdinal("id_estatusVale")) : 0;
                    Resultado.Nombre = !Dr.IsDBNull(Dr.GetOrdinal("Titulo")) ? Dr.GetString(Dr.GetOrdinal("Titulo")) : string.Empty;
                    Resultado.Folio = !Dr.IsDBNull(Dr.GetOrdinal("folio")) ? Dr.GetString(Dr.GetOrdinal("folio")) : string.Empty;
                    Resultado.CantLimite = !Dr.IsDBNull(Dr.GetOrdinal("cantLimite")) ? Dr.GetInt32(Dr.GetOrdinal("cantLimite")) : 0;
                    Resultado.Abierto = !Dr.IsDBNull(Dr.GetOrdinal("abierto")) ? Dr.GetBoolean(Dr.GetOrdinal("abierto")) : false;
                    Resultado.RequierePeriodo = !Dr.IsDBNull(Dr.GetOrdinal("rangoFechas")) ? Dr.GetBoolean(Dr.GetOrdinal("rangoFechas")) : false;
                    switch (Resultado.IDTipoVale)
                    {
                        case 1:
                        case 2:
                            Resultado.Monto = !Dr.IsDBNull(Dr.GetOrdinal("monto")) ? Dr.GetDecimal(Dr.GetOrdinal("monto")) : 0;
                            Resultado.Porcentaje = !Dr.IsDBNull(Dr.GetOrdinal("porcentaje")) ? Dr.GetDecimal(Dr.GetOrdinal("porcentaje")) : 0;
                            if (Resultado.RequierePeriodo)
                            {
                                Resultado.FechaInicio = !Dr.IsDBNull(Dr.GetOrdinal("fechaInicio")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaInicio")) : DateTime.Today;
                                Resultado.FechaFin = !Dr.IsDBNull(Dr.GetOrdinal("fechaFin")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaFin")) : DateTime.Today;
                            }
                            else
                            {
                                Resultado.Lunes = !Dr.IsDBNull(Dr.GetOrdinal("lunes")) ? Dr.GetBoolean(Dr.GetOrdinal("lunes")) : false;
                                Resultado.Martes = !Dr.IsDBNull(Dr.GetOrdinal("martes")) ? Dr.GetBoolean(Dr.GetOrdinal("martes")) : false;
                                Resultado.Miercoles = !Dr.IsDBNull(Dr.GetOrdinal("miercoles")) ? Dr.GetBoolean(Dr.GetOrdinal("miercoles")) : false;
                                Resultado.Jueves = !Dr.IsDBNull(Dr.GetOrdinal("jueves")) ? Dr.GetBoolean(Dr.GetOrdinal("jueves")) : false;
                                Resultado.Viernes = !Dr.IsDBNull(Dr.GetOrdinal("viernes")) ? Dr.GetBoolean(Dr.GetOrdinal("viernes")) : false;
                                Resultado.Sabado = !Dr.IsDBNull(Dr.GetOrdinal("sabado")) ? Dr.GetBoolean(Dr.GetOrdinal("sabado")) : false;
                                Resultado.Domingo = !Dr.IsDBNull(Dr.GetOrdinal("domingo")) ? Dr.GetBoolean(Dr.GetOrdinal("domingo")) : false;
                            }
                            break;
                        case 3:
                            string IDProductoNXN = !Dr.IsDBNull(Dr.GetOrdinal("id_productoRequerido")) ? Dr.GetString(Dr.GetOrdinal("id_productoRequerido")) : string.Empty;
                            string NombreProductoNXN = !Dr.IsDBNull(Dr.GetOrdinal("ProductoN")) ? Dr.GetString(Dr.GetOrdinal("ProductoN")) : string.Empty;
                            Resultado.ProductoRequerido = new Producto { id_producto = IDProductoNXN, nombreProducto = NombreProductoNXN };
                            Resultado.CantidadRequeridaNxN = !Dr.IsDBNull(Dr.GetOrdinal("cantRequerida")) ? Dr.GetInt32(Dr.GetOrdinal("cantRequerida")) : 0;
                            Resultado.CantidadGratisNxN = !Dr.IsDBNull(Dr.GetOrdinal("cantGratis")) ? Dr.GetInt32(Dr.GetOrdinal("cantGratis")) : 0;
                            if (Resultado.RequierePeriodo)
                            {
                                Resultado.FechaInicio = !Dr.IsDBNull(Dr.GetOrdinal("fechaInicio")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaInicio")) : DateTime.Today;
                                Resultado.FechaFin = !Dr.IsDBNull(Dr.GetOrdinal("fechaFin")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaFin")) : DateTime.Today;
                            }
                            else
                            {
                                Resultado.Lunes = !Dr.IsDBNull(Dr.GetOrdinal("lunes")) ? Dr.GetBoolean(Dr.GetOrdinal("lunes")) : false;
                                Resultado.Martes = !Dr.IsDBNull(Dr.GetOrdinal("martes")) ? Dr.GetBoolean(Dr.GetOrdinal("martes")) : false;
                                Resultado.Miercoles = !Dr.IsDBNull(Dr.GetOrdinal("miercoles")) ? Dr.GetBoolean(Dr.GetOrdinal("miercoles")) : false;
                                Resultado.Jueves = !Dr.IsDBNull(Dr.GetOrdinal("jueves")) ? Dr.GetBoolean(Dr.GetOrdinal("jueves")) : false;
                                Resultado.Viernes = !Dr.IsDBNull(Dr.GetOrdinal("viernes")) ? Dr.GetBoolean(Dr.GetOrdinal("viernes")) : false;
                                Resultado.Sabado = !Dr.IsDBNull(Dr.GetOrdinal("sabado")) ? Dr.GetBoolean(Dr.GetOrdinal("sabado")) : false;
                                Resultado.Domingo = !Dr.IsDBNull(Dr.GetOrdinal("domingo")) ? Dr.GetBoolean(Dr.GetOrdinal("domingo")) : false;
                            }
                            break;
                        case 4:
                            string IDProductoM = !Dr.IsDBNull(Dr.GetOrdinal("id_productoRequerido")) ? Dr.GetString(Dr.GetOrdinal("id_productoRequerido")) : string.Empty;
                            string NombreProductoM = !Dr.IsDBNull(Dr.GetOrdinal("ProductoM")) ? Dr.GetString(Dr.GetOrdinal("ProductoM")) : string.Empty;
                            string IDProductoN = !Dr.IsDBNull(Dr.GetOrdinal("id_productoGratis")) ? Dr.GetString(Dr.GetOrdinal("id_productoGratis")) : string.Empty;
                            string NombreProductoN = !Dr.IsDBNull(Dr.GetOrdinal("ProductoN")) ? Dr.GetString(Dr.GetOrdinal("ProductoN")) : string.Empty;
                            Resultado.ProductoRequerido = new Producto { id_producto = IDProductoM, nombreProducto = NombreProductoM };
                            Resultado.CantRequeridad = !Dr.IsDBNull(Dr.GetOrdinal("cantRequerida")) ? Dr.GetInt32(Dr.GetOrdinal("cantRequerida")) : 0;
                            Resultado.ProductoGratis = new Producto { id_producto = IDProductoN, nombreProducto = NombreProductoN };
                            Resultado.CantGratis = !Dr.IsDBNull(Dr.GetOrdinal("cantGratis")) ? Dr.GetInt32(Dr.GetOrdinal("cantGratis")) : 0;
                            if (Resultado.RequierePeriodo)
                            {
                                Resultado.FechaInicio = !Dr.IsDBNull(Dr.GetOrdinal("fechaInicio")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaInicio")) : DateTime.Today;
                                Resultado.FechaFin = !Dr.IsDBNull(Dr.GetOrdinal("fechaFin")) ? Dr.GetDateTime(Dr.GetOrdinal("fechaFin")) : DateTime.Today;
                            }
                            else
                            {
                                Resultado.Lunes = !Dr.IsDBNull(Dr.GetOrdinal("lunes")) ? Dr.GetBoolean(Dr.GetOrdinal("lunes")) : false;
                                Resultado.Martes = !Dr.IsDBNull(Dr.GetOrdinal("martes")) ? Dr.GetBoolean(Dr.GetOrdinal("martes")) : false;
                                Resultado.Miercoles = !Dr.IsDBNull(Dr.GetOrdinal("miercoles")) ? Dr.GetBoolean(Dr.GetOrdinal("miercoles")) : false;
                                Resultado.Jueves = !Dr.IsDBNull(Dr.GetOrdinal("jueves")) ? Dr.GetBoolean(Dr.GetOrdinal("jueves")) : false;
                                Resultado.Viernes = !Dr.IsDBNull(Dr.GetOrdinal("viernes")) ? Dr.GetBoolean(Dr.GetOrdinal("viernes")) : false;
                                Resultado.Sabado = !Dr.IsDBNull(Dr.GetOrdinal("sabado")) ? Dr.GetBoolean(Dr.GetOrdinal("sabado")) : false;
                                Resultado.Domingo = !Dr.IsDBNull(Dr.GetOrdinal("domingo")) ? Dr.GetBoolean(Dr.GetOrdinal("domingo")) : false;
                            }
                            break;
                    }

                }
                return Resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<TipoVales> ObtenerComboTipoVale(TipoVales Datos)
        {
            try
            {
                List<TipoVales> Lista = new List<TipoVales>();
                TipoVales Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.Conexion, "spCSLDB_get_ComboTipoVale", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new TipoVales();
                    Item.IDTipoVale = Dr.IsDBNull(Dr.GetOrdinal("IDTipoVale")) ? 0 : Dr.GetInt32(Dr.GetOrdinal("IDTipoVale"));
                    Item.Descripcion = Dr.IsDBNull(Dr.GetOrdinal("Descripcion")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Descripcion"));
                    Item.Porcentaje = Dr.IsDBNull(Dr.GetOrdinal("Porcentaje")) ? false : Dr.GetBoolean(Dr.GetOrdinal("Porcentaje"));
                    Item.Monto = Dr.IsDBNull(Dr.GetOrdinal("Monto")) ? false : Dr.GetBoolean(Dr.GetOrdinal("Monto"));
                    Item.NxN = Dr.IsDBNull(Dr.GetOrdinal("NxN")) ? false : Dr.GetBoolean(Dr.GetOrdinal("NxN"));
                    Item.NxM = Dr.IsDBNull(Dr.GetOrdinal("NxM")) ? false : Dr.GetBoolean(Dr.GetOrdinal("NxM"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Producto> ObtenerComboCatProducto(Producto Datos)
        {
            try
            {
                List<Producto> Lista = new List<Producto>();
                Producto Item;
                SqlDataReader Dr = SqlHelper.ExecuteReader(Datos.conexion, "spCSLDB_get_ComboCatProducto", Datos.IncluirSelect);
                while (Dr.Read())
                {
                    Item = new Producto();
                    Item.id_producto = Dr.IsDBNull(Dr.GetOrdinal("IDProducto")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("IDProducto"));
                    Item.nombreProducto = Dr.IsDBNull(Dr.GetOrdinal("Nombre")) ? string.Empty : Dr.GetString(Dr.GetOrdinal("Nombre"));
                    Lista.Add(Item);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ConsultaVale(Venta ventavale)
        {

            SqlDataReader Dr = SqlHelper.ExecuteReader(ventavale.vale.Conexion, "spCSLDB_get_ValesDetalleVenta", ventavale.vale.Folio);
            while (Dr.Read())
            {
                ventavale.vale.IDVale = !Dr.IsDBNull(Dr.GetOrdinal("id_vale")) ? Dr.GetString(Dr.GetOrdinal("id_vale")) : string.Empty;
                ventavale.vale.IDTipoVale = !Dr.IsDBNull(Dr.GetOrdinal("id_tipoVale")) ? Dr.GetInt32(Dr.GetOrdinal("id_tipoVale")) : 0;
                ventavale.vale.Nombre = !Dr.IsDBNull(Dr.GetOrdinal("Titulo")) ? Dr.GetString(Dr.GetOrdinal("Titulo")) : string.Empty;
                ventavale.vale.Folio = !Dr.IsDBNull(Dr.GetOrdinal("folio")) ? Dr.GetString(Dr.GetOrdinal("folio")) : string.Empty;
                switch (ventavale.vale.IDTipoVale)
                {
                    case 1:
                    case 2:
                        ventavale.vale.Monto = !Dr.IsDBNull(Dr.GetOrdinal("monto")) ? Dr.GetDecimal(Dr.GetOrdinal("monto")) : 0;
                        ventavale.vale.Porcentaje = !Dr.IsDBNull(Dr.GetOrdinal("porcentaje")) ? Dr.GetDecimal(Dr.GetOrdinal("porcentaje")) : 0;
                        break;
                    case 3:
                        string IDProductoNXN = !Dr.IsDBNull(Dr.GetOrdinal("id_productoRequerido")) ? Dr.GetString(Dr.GetOrdinal("id_productoRequerido")) : string.Empty;
                        string NombreProductoNXN = !Dr.IsDBNull(Dr.GetOrdinal("ProductoN")) ? Dr.GetString(Dr.GetOrdinal("ProductoN")) : string.Empty;
                        ventavale.vale.ProductoRequerido = new Producto { id_producto = IDProductoNXN, nombreProducto = NombreProductoNXN };
                        ventavale.vale.CantidadRequeridaNxN = !Dr.IsDBNull(Dr.GetOrdinal("cantRequerida")) ? Dr.GetInt32(Dr.GetOrdinal("cantRequerida")) : 0;
                        ventavale.vale.CantidadGratisNxN = !Dr.IsDBNull(Dr.GetOrdinal("cantGratis")) ? Dr.GetInt32(Dr.GetOrdinal("cantGratis")) : 0;
                        break;
                    case 4:
                        string IDProductoM = !Dr.IsDBNull(Dr.GetOrdinal("id_productoRequerido")) ? Dr.GetString(Dr.GetOrdinal("id_productoRequerido")) : string.Empty;
                        string NombreProductoM = !Dr.IsDBNull(Dr.GetOrdinal("ProductoM")) ? Dr.GetString(Dr.GetOrdinal("ProductoM")) : string.Empty;
                        string IDProductoN = !Dr.IsDBNull(Dr.GetOrdinal("id_productoGratis")) ? Dr.GetString(Dr.GetOrdinal("id_productoGratis")) : string.Empty;
                        string NombreProductoN = !Dr.IsDBNull(Dr.GetOrdinal("ProductoN")) ? Dr.GetString(Dr.GetOrdinal("ProductoN")) : string.Empty;
                        ventavale.vale.ProductoRequerido = new Producto { id_producto = IDProductoM, nombreProducto = NombreProductoM };
                        ventavale.vale.CantRequeridad = !Dr.IsDBNull(Dr.GetOrdinal("cantRequerida")) ? Dr.GetInt32(Dr.GetOrdinal("cantRequerida")) : 0;
                        ventavale.vale.ProductoGratis = new Producto { id_producto = IDProductoN, nombreProducto = NombreProductoN };
                        ventavale.vale.CantGratis = !Dr.IsDBNull(Dr.GetOrdinal("cantGratis")) ? Dr.GetInt32(Dr.GetOrdinal("cantGratis")) : 0;
                        break;
                }

            }
            //return ventavale.vale;

        }
        public void ModificarDescuentoVentaDetalle(ref int Verificador, ref Venta ventavale)
        {
            try
            {
                object res = SqlHelper.ExecuteScalar(ventavale.vale.Conexion, CommandType.StoredProcedure, "spCSLDB_set_CatVentaDetalleDescuento",
                new SqlParameter("@lstVentaDetalleDescuentoVale", ventavale.vale.TablaDatos),
                new SqlParameter("@IDSucursal", ventavale.id_sucursal)
                );
                if (res != null)
                    Verificador = 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
