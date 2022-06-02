using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TintoreriaGlobal;
using TintoreriaNegocio;

using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
using PuntodeVentaTintoreria.ClaseAux;
using System.Management;
using System.Globalization;

namespace PuntodeVentaTintoreria
{
    public partial class frm_VentaCancelaciones : Form
    {
        VentaProductos infoVentas = new VentaProductos();
        int tipoBusqueda = 1;
        private Validaciones Val;
        frm_Esperar espere = new frm_Esperar();

        public frm_VentaCancelaciones()
        {
            try
            {
                InitializeComponent();
                infoVentas.IDSucursal = Comun.id_sucursal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelacion_Grid ~ frmCancelacion_Grid()");
            }
        }
        
      

        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        

        /************************************************************************************************************************************/


        


        private void frm_VentaCancelaciones_Load(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker1.RunWorkerAsync();
                espere.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelacion_Grid ~ frmCancelacion_Grid_Load");
            }
        }
        #region MetodosGenerales
        private List<DataGridViewRow> ObtenerFilaSeleccionada()
        {
            try
            {
                List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in GridViewCancelacion.Rows)
                {
                    if (row.Selected)
                    {
                        rowSelected.Add(row);
                    }
                }
                return rowSelected;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private bool ValidarFilaSeleccionada(List<DataGridViewRow> rowSelected)
        {
            try
            {
                if (rowSelected.Count == 0)
                {
                    MessageBox.Show(this, "Debe seleccionar una fila del grid", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private VentaProductos ObtenerDatosGridCancelacion()
        {
            try
            {
                VentaProductos ventaProducto = new VentaProductos();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    ventaProducto.Folio = row.Cells["folio"].Value.ToString();
                    ventaProducto.NombreCliente = row.Cells["cliente"].Value.ToString();
                    ventaProducto.Subtotal = decimal.Parse(row.Cells["subtotal"].Value.ToString(), CultureInfo.InvariantCulture);
                    ventaProducto.Iva = decimal.Parse(row.Cells["iva"].Value.ToString(), CultureInfo.InvariantCulture);
                    ventaProducto.Total = decimal.Parse(row.Cells["total"].Value.ToString(), CultureInfo.InvariantCulture);
                    ventaProducto.Pago = decimal.Parse(row.Cells["pago"].Value.ToString(), CultureInfo.InvariantCulture);
                    ventaProducto.IDSucursal = row.Cells["id_sucursal"].Value.ToString();
                    ventaProducto.IDVenta = row.Cells["id_venta"].Value.ToString();
                    ventaProducto.IDCaja = row.Cells["id_caja"].Value.ToString();
                    ventaProducto.IDCliente = row.Cells["id_cliente"].Value.ToString();
                }
                return ventaProducto;
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        private void CargarGridCancelacion(string busqueda, int tipoBusqueda, string id_sucursal, DateTime fecha, string id_caja)
        {
            try
            {
                VentaProductosNegocio venta_negocio = new VentaProductosNegocio();
                VentaProductos venta = new VentaProductos();
                venta.conexion = Comun.conexion;
                venta.IDSucursal = id_sucursal;
                venta.tipoBusqueda = tipoBusqueda;
                venta.fechaCancelacion = fecha;
                venta.IDCaja = id_caja;
                venta.busqueda = busqueda;
                venta_negocio.LLenarGridCancelacion(venta);
                infoVentas.datos = venta.datos;
                this.GridViewCancelacion.AutoGenerateColumns = false;
                this.GridViewCancelacion.DataSource = venta.datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void CargarComboCaja()
        {
            try
            {
                UsuarioNegocio usuario_negocio = new UsuarioNegocio();
                Usuario usuario = new Usuario();
                usuario.conexion = Comun.conexion;
                usuario_negocio.ObtenerComboCaja(usuario, dtp_fechaCancelacion.Value, cmb_sucursal.SelectedValue.ToString());
                this.cmb_caja.SelectedValueChanged -= new System.EventHandler(this.cmb_caja_SelectedValueChanged);
                this.cmb_caja.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_caja.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_caja.DataSource = usuario.datos;
                this.cmb_caja.DisplayMember = "caja";
                this.cmb_caja.ValueMember = "id_caja";
                this.cmb_caja.SelectedValueChanged += new System.EventHandler(this.cmb_caja_SelectedValueChanged);
                this.cmb_caja.SelectedValue = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelacion_Grid ~ CargarComboCaja()");
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
                this.cmb_sucursal.DataSource = sucursal.datos;
                this.cmb_sucursal.DisplayMember = "nombre";
                this.cmb_sucursal.ValueMember = "id_sucursal";
                this.cmb_sucursal.SelectedValueChanged += new System.EventHandler(this.cmb_sucursal_SelectedValueChanged);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelacion_Grid ~ CargarComboSucursal()");
            }
        }
        private bool ValidarSucursal(String id_sucursal)
        {
            try
            {
                if (id_sucursal != Comun.id_sucursal)
                {
                    MessageBox.Show(this, "Operacion no valida para esta sucursal", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
        #region Validaciones
        private void txt_buscador_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloAlfaNumerico(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelacion_Grid ~ txt_buscador_KeyPress");
            }
        }

        private void txt_buscador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_buscador_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion
        #region Eventos
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    VentaProductos venta_aux = this.ObtenerDatosGridCancelacion();
                    if (this.ValidarSucursal(venta_aux.IDSucursal))
                    {
                        this.Visible = false;
                        VentaProductos ventaProductos = this.ObtenerDatosGridCancelacion();
                        Ticket_Impresion impresion = new Ticket_Impresion(4, ventaProductos);
                        impresion.imprimirTicket();
                        this.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelacion_Grid ~ btnImprimir_Click");
            }
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frm_VentaCancelacionNuevo frmc = new frm_VentaCancelacionNuevo();
                frmc.ShowDialog();
                frmc.Dispose();
                this.Visible = true;
                this.txt_buscador.Text = "Búsqueda por nombre o folio";
                this.CargarGridCancelacion("", tipoBusqueda, cmb_sucursal.SelectedValue.ToString(), dtp_fechaCancelacion.Value, cmb_caja.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelacion_Grid ~ btnNueva_Click");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelacion_Grid ~ btnCerrar_Click");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.CargarGridCancelacion(this.txt_buscador.Text, 1, cmb_sucursal.SelectedValue.ToString(), dtp_fechaCancelacion.Value, cmb_caja.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelacion_Grid ~ btnBuscar_Click");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.txt_buscador.Text = "Búsqueda por nombre o folio";
                this.CargarGridCancelacion("", 1, cmb_sucursal.SelectedValue.ToString(), dtp_fechaCancelacion.Value, cmb_caja.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelacion_Grid ~ btnCancelar_Click");
            }
        }

        private void cmb_sucursal_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Comun.id_tu == 1)
                {
                    infoVentas.IDSucursal = cmb_sucursal.SelectedValue.ToString();
                    this.CargarComboCaja();
                    this.CargarGridCancelacion("", 1, infoVentas.IDSucursal, dtp_fechaCancelacion.Value, cmb_caja.SelectedValue.ToString());
                }
                else
                {
                    cmb_sucursal.Enabled = false;
                    this.CargarComboCaja();
                    this.CargarGridCancelacion("", 1, infoVentas.IDSucursal, dtp_fechaCancelacion.Value, cmb_caja.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelacion_Grid ~ cmb_sucursal_SelectedValueChanged");
            }
        }

        private void dtp_fechaCancelacion_onValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.CargarComboCaja();
                this.CargarGridCancelacion("", 1, infoVentas.IDSucursal, dtp_fechaCancelacion.Value, cmb_caja.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelacion_Grid ~ dtp_fechaCancelacion_onValueChanged");
            }
        }

        private void cmb_caja_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.CargarGridCancelacion("", 1, cmb_sucursal.SelectedValue.ToString(), dtp_fechaCancelacion.Value, cmb_caja.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelacion_Grid ~ cmb_caja_SelectedValueChanged");
            }
        }

        private void txt_buscador_Click(object sender, EventArgs e)
        {
            try
            {
                txt_buscador.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelacion_Grid ~ txt_buscador_Click");
            }
        }


        #endregion

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                SucursalNegocio sucursal_negocio = new SucursalNegocio();
                Sucursal sucursal = new Sucursal();
                sucursal.conexion = Comun.conexion;
                sucursal_negocio.ObtenerComboSucursal(sucursal);
                e.Result = sucursal.datos;

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelacion_Grid ~ backgroundWorker1_DoWork");
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                DataTable Aux = (DataTable)e.Result;
                this.cmb_sucursal.SelectedValueChanged -= new System.EventHandler(this.cmb_sucursal_SelectedValueChanged);
                this.cmb_sucursal.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_sucursal.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_sucursal.DataSource = Aux;
                this.cmb_sucursal.DisplayMember = "nombre";
                this.cmb_sucursal.ValueMember = "id_sucursal";
                this.cmb_sucursal.SelectedValueChanged += new System.EventHandler(this.cmb_sucursal_SelectedValueChanged);

                this.dtp_fechaCancelacion.Text = DateTime.Now.ToString("dd/MM/yyyy");
                this.cmb_sucursal.SelectedValue = infoVentas.IDSucursal;
                Usuario usuario = new Usuario();
                usuario.datos = (DataTable)this.cmb_caja.DataSource;
                foreach (DataRow aux in usuario.datos.Rows)
                    if (aux["id_caja"].ToString().Equals(Comun.id_caja))
                        this.cmb_caja.SelectedValue = aux["id_caja"].ToString();
                espere.Close();
                this.dtp_fechaCancelacion.Value = DateTime.Today;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCancelacion_Grid ~ backgroundWorker1_DoWork");
            }
        }





    }
}
