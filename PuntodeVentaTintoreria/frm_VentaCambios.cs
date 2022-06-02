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
    public partial class frm_VentaCambios : Form
    {
        frm_Esperar espere = new frm_Esperar();
        public frm_VentaCambios()
        {
            try
            {
                InitializeComponent();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmVentaCambios ~ frmCambiosGrid_Bunifu()");
            }
        }
        
        

        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        /***************************************************************************************************************************************************/

        
   

        private void frm_VentaCambios_Load(object sender, EventArgs e)
        {
            try
            {
                this.backgroundWorker1.RunWorkerAsync();
                espere.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCambiosGrid_Bunifu ~ frmCambiosGrid_Bunifu_Load");
            }
        }
        #region MetodosGenerales
        private void ImagenGrid()
        {
            try
            {
                switch (tabControlCambio.SelectedIndex)
                {
                    case 0:
                        foreach (DataGridViewRow Grid in this.GridViewCambios.Rows)
                        {
                            if (Convert.ToInt32(Grid.Cells[12].Value) == 1)
                                Grid.Cells[13].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_ORANGE.png"), new Size(25, 25));
                            else if (Convert.ToInt32(Grid.Cells[12].Value) == 2)
                                Grid.Cells[13].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_GREEN.png"), new Size(25, 25));
                            else if (Convert.ToInt32(Grid.Cells[12].Value) == 3)
                                Grid.Cells[13].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_BLUE.png"), new Size(25, 25));
                        }
                        break;
                    case 1:
                        foreach (DataGridViewRow Grid in this.GridViewNuevos.Rows)
                        {
                            if (Convert.ToInt32(Grid.Cells[12].Value) == 1)
                                Grid.Cells[13].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_ORANGE.png"), new Size(25, 25));
                            else if (Convert.ToInt32(Grid.Cells[12].Value) == 2)
                                Grid.Cells[13].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_GREEN.png"), new Size(25, 25));
                            else if (Convert.ToInt32(Grid.Cells[12].Value) == 3)
                                Grid.Cells[13].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_BLUE.png"), new Size(25, 25));
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCambiosGrid_Bunifu ~ ImagenGrid()");
            }
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
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
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void CargarGridCambio(int tabIndex, string id_sucursal, DateTime fecha)
        {
            try
            {
                VentaProductos ventaProductos = new VentaProductos();
                VentaProductosNegocio ventaProductosNegocio = new VentaProductosNegocio();
                ventaProductos.conexion = Comun.conexion;
                ventaProductos.FecVenta = fecha;
                ventaProductos.IDSucursal = id_sucursal;
                ventaProductos.tabIndex = tabIndex;
                ventaProductosNegocio.LLenarGridCambio(ventaProductos);
                switch (tabIndex)
                {
                    case 0:
                        this.GridViewCambios.AutoGenerateColumns = false;
                        this.GridViewCambios.DataSource = ventaProductos.datos;
                        break;
                    case 1:
                        this.GridViewNuevos.AutoGenerateColumns = false;
                        this.GridViewNuevos.DataSource = ventaProductos.datos;
                        break;
                }
                ImagenGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
        private List<DataGridViewRow> ObtenerFilaSeleccionada()
        {
            try
            {
                List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();
                switch (this.tabControlCambio.SelectedIndex)
                {
                    case 0:
                        foreach (DataGridViewRow row in GridViewCambios.Rows)
                        {
                            if (row.Selected)
                            {
                                rowSelected.Add(row);
                            }
                        }
                        break;
                    case 1:
                        foreach (DataGridViewRow row in GridViewNuevos.Rows)
                        {
                            if (row.Selected)
                            {
                                rowSelected.Add(row);
                            }
                        }
                        break;
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
        private VentaProductos ObtenerDatosGridCambios()
        {
            try
            {
                VentaProductos ventaProducto = new VentaProductos();
                int TabIndex = this.tabControlCambio.SelectedIndex + 1;
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    ventaProducto.Folio = row.Cells["folio" + TabIndex].Value.ToString();
                    ventaProducto.FecVenta = Convert.ToDateTime(row.Cells["fec_venta" + TabIndex].Value.ToString());
                    ventaProducto.HorVenta = row.Cells["hor_venta" + TabIndex].Value.ToString();
                    ventaProducto.IDCliente = row.Cells["id_cliente" + TabIndex].Value.ToString();
                    ventaProducto.NombreCliente = row.Cells["cliente" + TabIndex].Value.ToString();
                    ventaProducto.IDVendedor = row.Cells["id_vendedor" + TabIndex].Value.ToString();
                    ventaProducto.NombreVendedor = row.Cells["vendedor" + TabIndex].Value.ToString();
                    ventaProducto.Importe = float.Parse(row.Cells["importe" + TabIndex].Value.ToString(), CultureInfo.InvariantCulture);
                    ventaProducto.Descuento = decimal.Parse(row.Cells["descuento" + TabIndex].Value.ToString(), CultureInfo.InvariantCulture);
                    ventaProducto.Iva = decimal.Parse(row.Cells["iva" + TabIndex].Value.ToString(), CultureInfo.InvariantCulture);
                    ventaProducto.Total = decimal.Parse(row.Cells["total" + TabIndex].Value.ToString(), CultureInfo.InvariantCulture);
                    ventaProducto.IDSucursal = row.Cells["id_sucursal" + TabIndex].Value.ToString();
                    ventaProducto.IDVenta = row.Cells["id_venta" + TabIndex].Value.ToString();
                    ventaProducto.IDStatus = Convert.ToInt32(row.Cells["id_statusVenta" + TabIndex].Value.ToString());
                }
                return ventaProducto;
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        #endregion
        #region Eventos
        private void tabControlCambio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.CargarGridCambio(tabControlCambio.SelectedIndex, cmb_sucursal.SelectedValue.ToString(), dtp_fechaPedido.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCambiosGrid_Bunifu ~ tabControlCambio_SelectedIndexChanged");
            }
        }

        private void dtp_fechaPedido_onValueChanged(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.CargarGridCambio(tabControlCambio.SelectedIndex, cmb_sucursal.SelectedValue.ToString(), dtp_fechaPedido.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCambiosGrid_Bunifu ~ dtp_fechaPedido_onValueChanged");
            }
        }

        private void cmb_sucursal_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (Comun.id_tu == 1)
                    {
                        this.CargarGridCambio(tabControlCambio.SelectedIndex, cmb_sucursal.SelectedValue.ToString(), dtp_fechaPedido.Value);
                    }
                    else
                    {
                        cmb_sucursal.Enabled = false;
                        this.CargarGridCambio(tabControlCambio.SelectedIndex, cmb_sucursal.SelectedValue.ToString(), dtp_fechaPedido.Value);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCambiosGrid_Bunifu ~ cmb_sucursal_SelectedValueChanged");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCambiosGrid_Bunifu ~ btnSalir_Click");
            }
        }
        private void GridViewGeneral_Sorted(object sender, EventArgs e)
        {
            try
            {
                this.ImagenGrid();
            }
            catch (Exception)
            {
            }
        }
        private void btnImprimirTicketPagos_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    VentaProductos venta_aux = this.ObtenerDatosGridCambios();
                    if (this.ValidarSucursal(venta_aux.IDSucursal))
                    {
                        if (venta_aux.IDStatus != 3)
                        {
                            this.Visible = false;
                            VentaProductos ventaProductos = this.ObtenerDatosGridCambios();
                            ventaProductos.IDTipoVenta = 1;
                            Ticket_Impresion impresion = new Ticket_Impresion(1, ventaProductos);
                            impresion.imprimirTicket();
                            this.Visible = true;
                        }
                        else
                            MessageBox.Show(this, "Este Folio no puede ser reimpreso porque ya fue cambiado", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCambiosGrid_Bunifu ~ btnImprimirTicketPagos_Click");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frm_BuscarVenta fbv = new frm_BuscarVenta();
                fbv.ShowDialog();
                using (new Recursos.CursorWait())
                {
                    this.CargarGridCambio(tabControlCambio.SelectedIndex, cmb_sucursal.SelectedValue.ToString(), dtp_fechaPedido.Value);
                }
                fbv.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCambiosGrid_Bunifu ~ btnNuevo_Click");
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
                this.cmb_sucursal.SelectedValue = Comun.id_sucursal;
                this.tabControlCambio.SelectedIndex = 0;
                this.backgroundWorker2.RunWorkerAsync();
            }
            catch (Exception ex)
            {
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                VentaProductos ventaProductos = new VentaProductos();
                VentaProductosNegocio ventaProductosNegocio = new VentaProductosNegocio();
                ventaProductos.conexion = Comun.conexion;
                ventaProductos.FecVenta = this.dtp_fechaPedido.Value;
                ventaProductos.IDSucursal = Comun.id_sucursal;
                ventaProductos.tabIndex = 0;
                ventaProductosNegocio.LLenarGridCambio(ventaProductos);
                e.Result = ventaProductos.datos;
            }
            catch (Exception ex)
            {

            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                DataTable Aux = (DataTable)e.Result;
                switch (this.tabControlCambio.SelectedIndex)
                {
                    case 0:
                        this.GridViewCambios.AutoGenerateColumns = false;
                        this.GridViewCambios.DataSource = Aux;
                        break;
                    case 1:
                        this.GridViewNuevos.AutoGenerateColumns = false;
                        this.GridViewNuevos.DataSource = Aux;
                        break;
                }
                ImagenGrid();
                this.dtp_fechaPedido.Value = DateTime.Today;
                espere.Close();
            }
            catch (Exception ex)
            {

            }
        }

       
    }
}
