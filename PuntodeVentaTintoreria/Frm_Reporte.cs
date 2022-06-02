using Microsoft.Reporting.WinForms;
using PuntodeVentaTintoreria.ClaseAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TintoreriaGlobal;
using TintoreriaNegocio;

namespace PuntodeVentaTintoreria
{
    public partial class Frm_Reporte : Form
    {
        int infoTipoReporte = 0, infoIDEnvio = 0;
        DesgloseMovimientos infoDesgloseMovimientos;
        Caja InfoCaja;
        frm_Esperar espere = new frm_Esperar();
        public Frm_Reporte()
        {
            InitializeComponent();           
        }
        public Frm_Reporte(int opcion, int IdEnvio)
        {
            InitializeComponent();
            infoTipoReporte = opcion;
            infoIDEnvio = IdEnvio;
            if (opcion == 6)
            {
                infoDesgloseMovimientos = new DesgloseMovimientos();
                infoDesgloseMovimientos.lstCaja = new List<DesgloseMovimientos>();
                infoDesgloseMovimientos.lstVenta = new List<DesgloseMovimientos>();
                infoDesgloseMovimientos.lstPedido = new List<DesgloseMovimientos>();
                infoDesgloseMovimientos.lstCambio = new List<DesgloseMovimientos>();
                infoDesgloseMovimientos.lstCancelacion = new List<DesgloseMovimientos>();
                infoDesgloseMovimientos.lstCompra = new List<DesgloseMovimientos>();
                infoDesgloseMovimientos.lstRetiro = new List<DesgloseMovimientos>();
                infoDesgloseMovimientos.lstDeposito = new List<DesgloseMovimientos>();
                infoDesgloseMovimientos.lstEfectivo = new List<DesgloseMovimientos>();
                infoDesgloseMovimientos.lstTarjeta = new List<DesgloseMovimientos>();
                infoDesgloseMovimientos.lstTransferencia = new List<DesgloseMovimientos>();
                infoDesgloseMovimientos.lstMonedero = new List<DesgloseMovimientos>();
            }
            
        }
        public Frm_Reporte(int Opcion, object Obj)
        {
            InitializeComponent();
            if (Opcion == 3)
            {
                this.infoTipoReporte = Opcion;
                this.InfoCaja = Obj as Caja;
            }
            else if (Opcion == 4)
            {
                this.infoTipoReporte = Opcion;
                this.InfoCaja = Obj as Caja;
            }
            else if (Opcion == 5)
            {
                this.infoTipoReporte = Opcion;
                this.InfoCaja = Obj as Caja;
            }
            else
            {
                this.infoTipoReporte = Opcion;
            }            
        }

        #region Metodos Generales
        private void ExcluirDatosReporte()
        {
            try
            {
                if (infoTipoReporte == 1)
                {
                    this.panel_cabecera.Visible = false;
                    this.RvPrincipal.Dock = DockStyle.Fill;
                }
                else if (infoTipoReporte == 2)
                {
                    this.panel_cabecera.Visible = false;
                    this.RvPrincipal.Dock = DockStyle.Fill;
                }
                else if (infoTipoReporte == 3)
                {
                    this.panel_cabecera.Visible = false;
                    this.RvPrincipal.Dock = DockStyle.Fill;
                }
                else if (this.infoTipoReporte == 4)
                {
                    this.cmbCaja.Visible = false;
                }
                else if (infoTipoReporte == 5)
                {
                    this.cmbCaja.Visible = true;
                    this.cmb_equipo.Visible = false;
                    this.lblFechaInicio.Text = "Fecha";
                    this.lblFechaInicio.Location = new Point(325, 12);
                    this.dtp_fechaCajaInicio.Location = new Point(350, 41);
                    this.lblFechaF.Visible = false;
                    this.dtp_fechaCajaFin.Visible = false;
                    this.label2.Text = "Caja";
                    this.label2.Location = new Point(570, 12);
                    this.cmbCaja.Location = new Point(520, 41);
                    //this.lblFechaInicio.Text = "Fecha";
                    //this.lblFechaInicio.Location = new Point(640, 12);
                    //this.dtp_fechaCajaInicio.Location = new Point(670, 41);

                    //this.label2.Text = "Caja";
                    //this.label2.Location = new Point(405, 12);
                    //this.cmbCaja.Location = new Point(338, 41);
                }
                else if (this.infoTipoReporte == 6)
                {
                    this.cmbCaja.Visible = false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CargarReporte()
        {
            try
            {
                if (this.infoTipoReporte == 1)
                {
                    RvPrincipal.SetDisplayMode(DisplayMode.PrintLayout);
                    RvPrincipal.ZoomMode = ZoomMode.Percent;
                    RvPrincipal.ZoomPercent = 110;
                    RvPrincipal.LocalReport.DataSources.Clear();
                    this.RvPrincipal.LocalReport.ReportEmbeddedResource = "PuntodeVentaTintoreria.Formatos.GenerarEnvio.rdlc";
                    Envio EnvioD = new Envio();
                    EnvioD.id_envio = infoIDEnvio;
                    EnvioD.conexion = Comun.conexion;
                    EnvioNegocio envio_Negocio = new EnvioNegocio();
                    envio_Negocio.CargarDatosListaEnvioR(EnvioD);
                    ReportParameter[] parameters = new ReportParameter[7];
                    parameters[0] = new ReportParameter("NombreEmpresa", EnvioD.Empresas.nombreComercial);
                    parameters[1] = new ReportParameter("Slogan", EnvioD.Empresas.slogan);
                    parameters[2] = new ReportParameter("RFC", EnvioD.Empresas.rfc);
                    parameters[3] = new ReportParameter("Logo", EnvioD.Empresas.pathImg);
                    parameters[4] = new ReportParameter("NombreChofer", EnvioD.NombreChofer);
                    parameters[5] = new ReportParameter("Vehiculo", EnvioD.Vehiculo);
                    parameters[6] = new ReportParameter("Sucursal", EnvioD.NombreSucursal);
                    RvPrincipal.LocalReport.EnableExternalImages = true;
                    RvPrincipal.LocalReport.SetParameters(parameters);
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("ListaEnvios", EnvioD.ListaEnvio));
                    this.RvPrincipal.RefreshReport();
                }
                else if (this.infoTipoReporte == 2)
                {
                    DesgloseMovimientos infoDesgloseMovimientos = new DesgloseMovimientos();
                    ReportesNegocio reportes_negocio = new ReportesNegocio();
                    infoDesgloseMovimientos.id_sucursal = Comun.id_sucursal;
                    infoDesgloseMovimientos.id_caja = Comun.id_caja.Trim();
                    RvPrincipal.SetDisplayMode(DisplayMode.PrintLayout);
                    RvPrincipal.ZoomMode = ZoomMode.Percent;
                    RvPrincipal.ZoomPercent = 110;
                    this.RvPrincipal.LocalReport.ReportEmbeddedResource = "PuntodeVentaTintoreria.Formatos.MovimientoActual.rdlc";
                    reportes_negocio.ObtenerDesgloseMovimientosActual(infoDesgloseMovimientos);

                    ReportParameter[] parameters = new ReportParameter[7];
                    parameters[0] = new ReportParameter("nombreEmpresa", infoDesgloseMovimientos.Empresas.nombreComercial); // Comun.ticket.razonsocial
                    parameters[1] = new ReportParameter("Slogan", infoDesgloseMovimientos.Empresas.slogan);
                    parameters[2] = new ReportParameter("RFC", Comun.ticket.rfc); //Comun.ticket.direccion                       
                    parameters[3] = new ReportParameter("logo", infoDesgloseMovimientos.Empresas.pathImg);
                    parameters[4] = new ReportParameter("sucursal", infoDesgloseMovimientos.sucursal);
                    parameters[5] = new ReportParameter("caja", infoDesgloseMovimientos.caja);
                    parameters[6] = new ReportParameter("fecha", DateTime.Now.ToShortDateString());
                    RvPrincipal.LocalReport.EnableExternalImages = true;
                    RvPrincipal.LocalReport.SetParameters(parameters);
                    RvPrincipal.LocalReport.DataSources.Clear();
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Caja", infoDesgloseMovimientos.lstCaja));
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Venta", infoDesgloseMovimientos.lstVenta));
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Pedido", infoDesgloseMovimientos.lstPedido));
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Cambio", infoDesgloseMovimientos.lstCambio));
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Cancelacion", infoDesgloseMovimientos.lstCancelacion));
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Compra", infoDesgloseMovimientos.lstCompra));
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Retiro", infoDesgloseMovimientos.lstRetiro));
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Deposito", infoDesgloseMovimientos.lstDeposito));
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Efectivo", infoDesgloseMovimientos.lstEfectivo));
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Tarjeta", infoDesgloseMovimientos.lstTarjeta));
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Transferencia", infoDesgloseMovimientos.lstTransferencia));
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Monedero", infoDesgloseMovimientos.lstMonedero));
                    this.RvPrincipal.RefreshReport();

                }
                else if (this.infoTipoReporte == 3)
                {
                    RvPrincipal.SetDisplayMode(DisplayMode.PrintLayout);
                    RvPrincipal.ZoomMode = ZoomMode.Percent;
                    RvPrincipal.ZoomPercent = 110;
                    RvPrincipal.LocalReport.ReportEmbeddedResource = "PuntodeVentaTintoreria.Formatos.CajaActual.rdlc";
                    ReportParameter[] parameters = new ReportParameter[4];
                    parameters[0] = new ReportParameter("NombreEmpresa", Comun.ticket.NombreComercial);
                    parameters[1] = new ReportParameter("RFC", Comun.ticket.rfc);
                    parameters[2] = new ReportParameter("Slogan", Comun.ticket.Slogan);
                    parameters[3] = new ReportParameter("Logo", InfoCaja.urlLogo);
                    RvPrincipal.LocalReport.EnableExternalImages = true;
                    RvPrincipal.LocalReport.SetParameters(parameters);
                    RvPrincipal.LocalReport.DataSources.Clear();
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Caja", InfoCaja.lstCaja));
                    RvPrincipal.LocalReport.EnableExternalImages = true;
                    this.RvPrincipal.RefreshReport();
                }
                else if (this.infoTipoReporte == 4)
                {
                    this.CargarComboSucursal();
                    this.CargarComboEquipos();
                    this.dtp_fechaCajaInicio.Value = DateTime.Now;
                    this.dtp_fechaCajaFin.Value = DateTime.Now;
                    this.cmb_sucursal.SelectedValue = Comun.id_sucursal;
                    this.cmb_equipo.SelectedValue = Comun.id_equipo;
                    RvPrincipal.SetDisplayMode(DisplayMode.PrintLayout);
                    RvPrincipal.ZoomMode = ZoomMode.Percent;
                    RvPrincipal.ZoomPercent = 110;
                    RvPrincipal.LocalReport.ReportEmbeddedResource = "PuntodeVentaTintoreria.Formatos.CajaXfechaXSucursal.rdlc";
                    ReportParameter[] parameters = new ReportParameter[8];
                    parameters[0] = new ReportParameter("NombreEmpresa", Comun.ticket.NombreComercial);
                    parameters[1] = new ReportParameter("RFC", Comun.ticket.rfc);
                    parameters[2] = new ReportParameter("Slogan", Comun.ticket.Slogan);
                    parameters[3] = new ReportParameter("Logo", "");
                    DataRowView vrowSucursal = (DataRowView)this.cmb_sucursal.SelectedItem;
                    DataRow rowSucursal = vrowSucursal.Row;
                    parameters[4] = new ReportParameter("Sucursal", rowSucursal["nombre"].ToString());
                    DataRowView vrowEquipo = (DataRowView)this.cmb_equipo.SelectedItem;
                    DataRow rowEquipo = vrowEquipo.Row;
                    parameters[5] = new ReportParameter("Equipo", rowEquipo["nombre"].ToString());
                    parameters[6] = new ReportParameter("FechaInicio", dtp_fechaCajaInicio.Value.ToShortDateString());
                    parameters[7] = new ReportParameter("FechaFin", dtp_fechaCajaFin.Value.ToShortDateString());
                    RvPrincipal.LocalReport.EnableExternalImages = true;
                    RvPrincipal.LocalReport.SetParameters(parameters);
                    RvPrincipal.LocalReport.DataSources.Clear();
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Caja", InfoCaja.lstCaja));
                    this.RvPrincipal.RefreshReport();
                    if (Comun.id_tu != 1)
                    {
                        cmb_sucursal.Enabled = false;
                        cmb_equipo.Enabled = false;
                    }
                }
                else if (this.infoTipoReporte == 5)
                {
                    this.CargarComboSucursal();
                    this.dtp_fechaCajaInicio.Value = DateTime.Now;
                    this.cmb_sucursal.SelectedValue = Comun.id_sucursal;
                    Usuario usuario = new Usuario();
                    usuario.datos = (DataTable)this.cmbCaja.DataSource;
                    foreach (DataRow aux in usuario.datos.Rows)
                        if (aux["id_caja"].ToString().Equals(Comun.id_caja))
                            this.cmbCaja.SelectedValue = aux["id_caja"].ToString();
                    RvPrincipal.LocalReport.ReportEmbeddedResource = "PuntodeVentaTintoreria.Formatos.CajaXDiaXSucursal.rdlc";
                    RvPrincipal.SetDisplayMode(DisplayMode.PrintLayout);
                    RvPrincipal.ZoomMode = ZoomMode.Percent;
                    RvPrincipal.ZoomPercent = 110;
                    ReportParameter[] parameters = new ReportParameter[7];
                    parameters[0] = new ReportParameter("NombreEmpresa", Comun.ticket.NombreComercial);
                    parameters[1] = new ReportParameter("Slogan", Comun.ticket.Slogan);
                    parameters[2] = new ReportParameter("RFC", Comun.ticket.rfc);
                    parameters[3] = new ReportParameter("Logo", "");
                    parameters[4] = new ReportParameter("Sucursal", " ");
                    parameters[5] = new ReportParameter("Fecha", " ");
                    parameters[6] = new ReportParameter("Caja", " ");
                    RvPrincipal.LocalReport.EnableExternalImages = true;
                    RvPrincipal.LocalReport.SetParameters(parameters);
                    RvPrincipal.LocalReport.DataSources.Clear();
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Caja", InfoCaja.lstCaja));
                    this.RvPrincipal.RefreshReport();
                    if (Comun.id_tu != 1)
                        cmb_sucursal.Enabled = false;
                }
                else if (infoTipoReporte == 6)
                {
                    this.CargarComboSucursal();
                    this.CargarComboEquipos();
                    this.dtp_fechaCajaInicio.Value = DateTime.Now;
                    this.dtp_fechaCajaFin.Value = DateTime.Now;
                    this.cmb_sucursal.SelectedValue = Comun.id_sucursal;
                    this.cmb_equipo.SelectedValue = Comun.id_equipo;
                    RvPrincipal.LocalReport.ReportEmbeddedResource = "PuntodeVentaTintoreria.Formatos.MovimientoCajaXFechaXSucursal.rdlc";
                    RvPrincipal.SetDisplayMode(DisplayMode.PrintLayout);
                    RvPrincipal.ZoomMode = ZoomMode.Percent;
                    RvPrincipal.ZoomPercent = 110;
                    ReportParameter[] parameters = new ReportParameter[8];
                    parameters[0] = new ReportParameter("nombreEmpresa", Comun.ticket.NombreComercial);
                    parameters[1] = new ReportParameter("Slogan", Comun.ticket.Slogan);
                    parameters[2] = new ReportParameter("RFC", Comun.ticket.rfc);
                    parameters[3] = new ReportParameter("Logo", "");
                    parameters[4] = new ReportParameter("sucursal", " ");
                    parameters[5] = new ReportParameter("equipo", " ");
                    parameters[6] = new ReportParameter("fechaInicio", " ");
                    parameters[7] = new ReportParameter("fechaFin", " ");
                    RvPrincipal.LocalReport.EnableExternalImages = true;
                    RvPrincipal.LocalReport.SetParameters(parameters);
                    RvPrincipal.LocalReport.DataSources.Clear();
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Caja", infoDesgloseMovimientos.lstCaja));
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Venta", infoDesgloseMovimientos.lstVenta));
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Pedido", infoDesgloseMovimientos.lstPedido));
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Cancelaciones", infoDesgloseMovimientos.lstCancelacion));
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Compra", infoDesgloseMovimientos.lstCompra));
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Retiro", infoDesgloseMovimientos.lstRetiro));
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Deposito", infoDesgloseMovimientos.lstDeposito));
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Efectivo", infoDesgloseMovimientos.lstEfectivo));
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Tarjeta", infoDesgloseMovimientos.lstTarjeta));
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Transferencia", infoDesgloseMovimientos.lstTransferencia));
                    RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Monedero", infoDesgloseMovimientos.lstMonedero));
                    this.RvPrincipal.RefreshReport();
                    if (Comun.id_tu != 1)
                    {
                        cmb_sucursal.Enabled = false;
                        cmb_equipo.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_Reporte ~ CargarReporte() error en el tipo de reporte " + infoTipoReporte);
            }

        }

        private void CargarComboSucursal()
        {
            try
            {
                SucursalNegocio sucursal_negocio = new SucursalNegocio();
                Sucursal sucursal = new Sucursal();
                sucursal.conexion = Comun.conexion;
                sucursal_negocio.ObtenerComboSucursal(sucursal);
                this.cmb_sucursal.SelectedValueChanged -= new System.EventHandler(this.cmb_sucursal_SelectedValueChanged);
                this.cmb_sucursal.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_sucursal.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_sucursal.DisplayMember = "nombre";
                this.cmb_sucursal.ValueMember = "id_sucursal";
                this.cmb_sucursal.DataSource = sucursal.datos;
                
                this.cmb_sucursal.SelectedValueChanged += new System.EventHandler(this.cmb_sucursal_SelectedValueChanged);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarComboEquipos()
        {
            try
            {
                Equipo equipo = new Equipo();
                EquipoNegocio equipo_negocio = new EquipoNegocio();
                equipo.conexion = Comun.conexion;
                equipo.id_sucursal = this.cmb_sucursal.SelectedValue.ToString();
                equipo_negocio.ObtenerComboEquipoAsignadosXSucursal(equipo);
                this.cmb_equipo.ValueMember = "id_equipo";
                this.cmb_equipo.DisplayMember = "nombre";
                this.cmb_equipo.DataSource = equipo.datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboCaja()
        {
            try
            {
                UsuarioNegocio usuario_negocio = new UsuarioNegocio();
                Usuario usuario = new Usuario();
                usuario.conexion = Comun.conexion;
                usuario_negocio.ObtenerComboCaja(usuario, dtp_fechaCajaInicio.Value, cmb_sucursal.SelectedValue.ToString());
                this.cmbCaja.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmbCaja.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmbCaja.DisplayMember = "caja";
                this.cmbCaja.ValueMember = "id_caja";
                this.cmbCaja.DataSource = usuario.datos;
                this.cmbCaja.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            try
            {
                if (Convert.ToInt32(this.cmb_sucursal.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_sucursal.SelectedIndex) == -1)
                {
                    this.cmb_sucursal.Focus();
                    MessageBox.Show(this, "Seleccione una sucursal", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.infoTipoReporte == 4 || this.infoTipoReporte == 6)
                {
                    if (Convert.ToInt32(this.cmb_equipo.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_equipo.SelectedIndex) == -1)
                    {
                        this.cmb_equipo.Focus();
                        MessageBox.Show(this, "Seleccione un equipo", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else if (this.infoTipoReporte == 5)
                {
                    if (Convert.ToInt32(this.cmbCaja.SelectedIndex) == 0 || Convert.ToInt32(this.cmbCaja.SelectedIndex) == -1)
                    {
                        this.cmb_sucursal.Focus();
                        MessageBox.Show(this, "Seleccione una caja", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                //if (this.dtp_fechaCajaInicio.Value.CompareTo(this.dtp_fechaCajaFin.Value) == 1)
                //{
                //    this.dtp_fechaCajaFin.Focus();
                //    MessageBox.Show(this, "La fecha fin no puede ser mayor que la fecha inicio", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return false;
                //}
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Eventos

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Frm_Reporte_Load(object sender, EventArgs e)
        {
            try
            {
                //this.backgroundWorker1.RunWorkerAsync();
                //espere.ShowDialog();
                System.Threading.Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentCulture;
                this.ExcluirDatosReporte();
                this.CargarReporte();
                this.RvPrincipal.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_Reporte ~ Frm_Reporte_Load()");
            }

        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.infoTipoReporte == 4)
                {
                    using (new Recursos.CursorWait())
                    {
                        if (this.ValidarCampos())
                        {
                            ReportesNegocio reportes_negocio = new ReportesNegocio();
                            InfoCaja.CadConexion = Comun.conexion;
                            InfoCaja.id_sucursal = this.cmb_sucursal.SelectedValue.ToString();
                            InfoCaja.fechaCaja = this.dtp_fechaCajaInicio.Value;
                            InfoCaja.fechaCaja2 = this.dtp_fechaCajaFin.Value;
                            InfoCaja.id_equipo = this.cmb_equipo.SelectedValue.ToString();
                            InfoCaja.lstCaja = new List<Caja>();
                            reportes_negocio.ObtenerCajaXIDEquipoFechas(InfoCaja);
                            InfoCaja.lstCaja.Add(InfoCaja);
                            RvPrincipal.SetDisplayMode(DisplayMode.PrintLayout);
                            RvPrincipal.ZoomMode = ZoomMode.Percent;
                            RvPrincipal.ZoomPercent = 110;
                            ReportParameter[] parameters = new ReportParameter[8];
                            parameters[0] = new ReportParameter("NombreEmpresa", Comun.ticket.NombreComercial);
                            parameters[1] = new ReportParameter("RFC", Comun.ticket.rfc);
                            parameters[2] = new ReportParameter("Slogan", Comun.ticket.Slogan);
                            parameters[3] = new ReportParameter("Logo", InfoCaja.urlLogo);
                            DataRowView vrowSucursal = (DataRowView)this.cmb_sucursal.SelectedItem;
                            DataRow rowSucursal = vrowSucursal.Row;
                            parameters[4] = new ReportParameter("Sucursal", rowSucursal["nombre"].ToString());
                            DataRowView vrowEquipo = (DataRowView)this.cmb_equipo.SelectedItem;
                            DataRow rowEquipo = vrowEquipo.Row;
                            parameters[5] = new ReportParameter("Equipo", rowEquipo["nombre"].ToString());
                            parameters[6] = new ReportParameter("FechaInicio", dtp_fechaCajaInicio.Value.ToShortDateString());
                            parameters[7] = new ReportParameter("FechaFin", dtp_fechaCajaFin.Value.ToShortDateString());
                            RvPrincipal.LocalReport.EnableExternalImages = true;
                            RvPrincipal.LocalReport.SetParameters(parameters);
                            RvPrincipal.LocalReport.DataSources.Clear();
                            RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Caja", InfoCaja.lstCaja));
                            this.RvPrincipal.RefreshReport();
                        }
                    }
                }
                if (this.infoTipoReporte == 5)
                {
                    using (new Recursos.CursorWait())
                    {
                        if (this.ValidarCampos())
                        {
                            ReportesNegocio reportes_negocio = new ReportesNegocio();
                            InfoCaja.CadConexion = Comun.conexion;
                            InfoCaja.id_sucursal = this.cmb_sucursal.SelectedValue.ToString();
                            InfoCaja.fechaCaja = this.dtp_fechaCajaInicio.Value;
                            InfoCaja.id_caja = this.cmbCaja.SelectedValue.ToString();
                            InfoCaja.lstCaja = new List<Caja>();
                            reportes_negocio.ObtenerCajaXID(InfoCaja);
                            InfoCaja.lstCaja.Add(InfoCaja);
                            RvPrincipal.SetDisplayMode(DisplayMode.PrintLayout);
                            RvPrincipal.ZoomMode = ZoomMode.Percent;
                            RvPrincipal.ZoomPercent = 110;
                            ReportParameter[] parameters = new ReportParameter[7];
                            parameters[0] = new ReportParameter("NombreEmpresa", Comun.ticket.NombreComercial);
                            parameters[1] = new ReportParameter("Slogan", Comun.ticket.rfc);
                            parameters[2] = new ReportParameter("RFC", Comun.ticket.rfc);
                            parameters[3] = new ReportParameter("Logo", "");
                            DataRowView vrowSucursal = (DataRowView)this.cmb_sucursal.SelectedItem;
                            DataRow rowSucursal = vrowSucursal.Row;
                            parameters[4] = new ReportParameter("Sucursal", rowSucursal["nombre"].ToString());
                            parameters[5] = new ReportParameter("Fecha", this.dtp_fechaCajaInicio.Value.ToShortDateString());
                            DataRowView vrowCaja = (DataRowView)this.cmbCaja.SelectedItem;
                            DataRow rowCaja = vrowCaja.Row;
                            parameters[6] = new ReportParameter("Caja", rowCaja["caja"].ToString());
                            RvPrincipal.LocalReport.EnableExternalImages = true;
                            RvPrincipal.LocalReport.SetParameters(parameters);
                            RvPrincipal.LocalReport.DataSources.Clear();
                            RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Caja", InfoCaja.lstCaja));
                            this.RvPrincipal.RefreshReport();
                            if (Comun.id_tu != 1)
                                cmb_sucursal.Enabled = false;
                        }
                    }
                }
                if (this.infoTipoReporte == 6)
                {
                    if (this.ValidarCampos())
                    {
                        ReportesNegocio reportes_negocio = new ReportesNegocio();
                        infoDesgloseMovimientos.conexion = Comun.conexion;
                        infoDesgloseMovimientos.id_sucursal = this.cmb_sucursal.SelectedValue.ToString();
                        infoDesgloseMovimientos.fechaInicio = this.dtp_fechaCajaInicio.Value;
                        infoDesgloseMovimientos.fechaFin = this.dtp_fechaCajaFin.Value;
                        infoDesgloseMovimientos.id_equipo = this.cmb_equipo.SelectedValue.ToString();
                        reportes_negocio.ObtenerDesgloseMovimientosXFechas(infoDesgloseMovimientos);
                        RvPrincipal.SetDisplayMode(DisplayMode.PrintLayout);
                        RvPrincipal.ZoomMode = ZoomMode.Percent;
                        RvPrincipal.ZoomPercent = 110;
                        ReportParameter[] parameters = new ReportParameter[8];
                        parameters[0] = new ReportParameter("nombreEmpresa", Comun.ticket.NombreComercial);
                        parameters[1] = new ReportParameter("Slogan", Comun.ticket.Slogan);
                        parameters[2] = new ReportParameter("RFC", Comun.ticket.rfc);
                        parameters[3] = new ReportParameter("Logo", infoDesgloseMovimientos.logo);
                        DataRowView vrowSucursal = (DataRowView)this.cmb_sucursal.SelectedItem;
                        DataRow rowSucursal = vrowSucursal.Row;
                        parameters[4] = new ReportParameter("sucursal", rowSucursal["nombre"].ToString());
                        DataRowView vrowEquipo = (DataRowView)this.cmb_sucursal.SelectedItem;
                        DataRow rowEquipo = vrowEquipo.Row;
                        parameters[5] = new ReportParameter("equipo", rowSucursal["nombre"].ToString());
                        parameters[6] = new ReportParameter("fechaInicio", dtp_fechaCajaInicio.Value.ToShortDateString());
                        parameters[7] = new ReportParameter("fechaFin", dtp_fechaCajaFin.Value.ToShortDateString());
                        RvPrincipal.LocalReport.EnableExternalImages = true;
                        RvPrincipal.LocalReport.SetParameters(parameters);
                        RvPrincipal.LocalReport.DataSources.Clear();
                        RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Caja", infoDesgloseMovimientos.lstCaja));
                        RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Venta", infoDesgloseMovimientos.lstVenta));
                        RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Pedido", infoDesgloseMovimientos.lstPedido));
                        RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Cancelaciones", infoDesgloseMovimientos.lstCancelacion));
                        RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Compra", infoDesgloseMovimientos.lstCompra));
                        RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Retiro", infoDesgloseMovimientos.lstRetiro));
                        RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Deposito", infoDesgloseMovimientos.lstDeposito));
                        RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Efectivo", infoDesgloseMovimientos.lstEfectivo));
                        RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Tarjeta", infoDesgloseMovimientos.lstTarjeta));
                        RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Transferencia", infoDesgloseMovimientos.lstTransferencia));
                        RvPrincipal.LocalReport.DataSources.Add(new ReportDataSource("Monedero", infoDesgloseMovimientos.lstMonedero));
                        this.RvPrincipal.RefreshReport();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_Reporte ~ BtnGenerar_Click()");
            }
        }

        private void dtp_fechaCajaInicio_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.infoTipoReporte == 5)
                {
                    this.CargarComboCaja();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_Reporte ~ cmb_sucursal_SelectedValueChanged");
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_Reporte ~ backgroundWorker1_DoWork");
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_Reporte ~ backgroundWorker1_RunWorkerCompleted");
            }
        }

        private void cmb_sucursal_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
              
                if (this.infoTipoReporte == 4 || this.infoTipoReporte == 6)
                {
                    this.CargarComboEquipos();
                }
                else if (this.infoTipoReporte == 5)
                {
                    this.CargarComboCaja();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_Reporte ~ cmb_sucursal_SelectedValueChanged");
            }
        }

        #endregion
    }
}
