using Microsoft.Office.Interop.Excel;
using PuntodeVentaTintoreria.ClaseAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
    
    public partial class frmAlmacen : Form
    {
        Almacen infoAlmacen = new Almacen();
        int tipoBusqueda = 1;
        private Validaciones Val;
        frm_Esperar espere = new frm_Esperar();
        public frmAlmacen()
        {
            InitializeComponent();
            infoAlmacen.id_sucursal = Comun.id_sucursal;
            Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
        }

       


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                SucursalNegocio sucursal_negocio = new SucursalNegocio();
                Sucursal sucursal = new Sucursal();
                sucursal.conexion = Comun.conexion;
                sucursal_negocio.ObtenerComboSucursal(sucursal);
                this.cmb_sucursal.SelectedValueChanged -= new System.EventHandler(this.cmb_sucursal_SelectedValueChanged);
                e.Result = sucursal.datos;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmAlmacen ~ txt_buscador_Enter");


            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                System.Data.DataTable aux = (System.Data.DataTable)e.Result;
                this.cmb_sucursal.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_sucursal.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_sucursal.DataSource = aux;
                this.cmb_sucursal.DisplayMember = "nombre";
                this.cmb_sucursal.ValueMember = "id_sucursal";
                this.cmb_sucursal.SelectedValueChanged += new System.EventHandler(this.cmb_sucursal_SelectedValueChanged);
                this.cmb_sucursal.SelectedValue = infoAlmacen.id_sucursal;
                backgroundWorker2.RunWorkerAsync();

            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmAlmacen ~ txt_buscador_Enter");

            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                AlmacenNegocio almacen_negocio = new AlmacenNegocio();
                Almacen almacen = new Almacen();
                almacen.conexion = Comun.conexion;
                almacen.id_sucursal = infoAlmacen.id_sucursal;
                almacen.tipoBusqueda = tipoBusqueda;
                almacen.busqueda = "";
                almacen_negocio.LLenarGridAlmacen(almacen);
                infoAlmacen.datos = almacen.datos;
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmAlmacen ~ txt_buscador_Enter");
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.GridviewAlmacen.AutoGenerateColumns = false;
                this.GridviewAlmacen.DataSource = infoAlmacen.datos;
                espere.Close();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmAlmacen ~ txt_buscador_Enter");
            }
        }

        private void btnDetalleimagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarCampos())
                {
                    using (new Recursos.CursorWait())
                    {
                        Almacen almacen = new Almacen();
                        almacen.conexion = Comun.conexion;
                        almacen.busqueda = "";
                        almacen.tipoBusqueda = tipoBusqueda;
                        almacen.id_sucursal = cmb_sucursal.SelectedValue.ToString();
                        //if (ValidarExcel())
                        //{
                        //    ExportarExcel(almacen);
                        //    DialogResult = System.Windows.Forms.DialogResult.OK;
                        //}
                        //else
                            MessageBox.Show(this, "Existe un problema con el Excel verifique el programa", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAlmacen ~ btnExportar_Click");
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
                        infoAlmacen.id_sucursal = cmb_sucursal.SelectedValue.ToString();
                        CargarGridAlmacen("", tipoBusqueda, infoAlmacen.id_sucursal);
                    }
                    else
                    {
                        cmb_sucursal.Enabled = false;
                        CargarGridAlmacen("", tipoBusqueda, infoAlmacen.id_sucursal);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAlmacen ~ cmb_sucursal_SelectedValueChanged");
            }
        }

        private void pnlBotones_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmAlmacen_Load(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker1.RunWorkerAsync();
                espere.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAlmacen ~ frmAlmacen");
            }
        }
        #region MetodosGenerales
        private Almacen ObtenerDatosGridAlmacen()
        {
            try
            {
                Almacen almacen = new Almacen();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    almacen.id_producto = row.Cells["id_producto"].Value.ToString();
                    almacen.nombreProducto = row.Cells["nombre_producto"].Value.ToString();
                    almacen.existencia = Convert.ToDecimal(row.Cells["existencia"].Value.ToString());
                    almacen.id_sucursal = row.Cells["id_sucursal"].Value.ToString();
                    almacen.NombreUnidadMedida = row.Cells["unidadMedida"].Value.ToString();
                }
                return almacen;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private void CargarCombo()
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
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private List<DataGridViewRow> ObtenerFilaSeleccionada()
        {
            try
            {
                List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in GridviewAlmacen.Rows)
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
                    MessageBox.Show(this, "Debe seleccionar una fila del grid", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void CargarGridAlmacen(string busqueda, int tipoBusqueda, string id_sucursal)
        {
            try
            {
                AlmacenNegocio almacen_negocio = new AlmacenNegocio();
                Almacen almacen = new Almacen();
                almacen.conexion = Comun.conexion;
                almacen.id_sucursal = id_sucursal;
                almacen.tipoBusqueda = tipoBusqueda;
                almacen.busqueda = busqueda;
                almacen_negocio.LLenarGridAlmacen(almacen);
                infoAlmacen.datos = almacen.datos;
                this.GridviewAlmacen.AutoGenerateColumns = false;
                this.GridviewAlmacen.DataSource = almacen.datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidarCampos()
        {
            try
            {
                Val = new Validaciones();
                if (Convert.ToInt32(this.cmb_sucursal.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_sucursal.SelectedIndex) == -1)
                {
                    this.cmb_sucursal.Focus();
                    MessageBox.Show(this, "Seleccione una Sucursal", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion
       

        private void btnImportados_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarCampos())
                {
                    this.Visible = false;
                    frmHistorialImportados frmhi = new frmHistorialImportados();
                    frmhi.ShowDialog();
                    frmhi.Dispose();
                    this.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAlmacen ~ btnImportados_Click");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.CargarGridAlmacen(this.txt_buscador.Text, 1, cmb_sucursal.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderis", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAlmacen ~ btnBuscar_Click");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.txt_buscador.Text = "Búsqueda por código o nombre";
                CargarGridAlmacen("", tipoBusqueda, cmb_sucursal.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAlmacen ~ btnCancelar_Click");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarCampos())
                {
                    if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                    {
                        frm_PedirAutorizacion frma = new frm_PedirAutorizacion();
                        frma.ShowDialog();
                        frma.Dispose();
                        Almacen almacen = this.ObtenerDatosGridAlmacen();
                        if (frma.DialogResult == DialogResult.OK)
                        {
                            frmStockAgregar frmsa = new frmStockAgregar(almacen);
                            frmsa.ShowDialog();
                            frmsa.Dispose();
                            using (new Recursos.CursorWait())
                            {
                                CargarGridAlmacen("", tipoBusqueda, cmb_sucursal.SelectedValue.ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAlmacen ~ btnAgregar_Click");
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarCampos())
                {
                    frm_PedirAutorizacion frma = new frm_PedirAutorizacion();
                    frma.ShowDialog();
                    frma.Dispose();
                    Almacen almacen = this.ObtenerDatosGridAlmacen();
                    if (frma.DialogResult == DialogResult.OK)
                    {
                        frmStockQuitar frmsq = new frmStockQuitar(almacen);
                        frmsq.ShowDialog();
                        frmsq.Dispose();
                        using (new Recursos.CursorWait())
                        {
                            CargarGridAlmacen("", tipoBusqueda, cmb_sucursal.SelectedValue.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAlmacen ~ btnQuitar_Click");
            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarCampos())
                {
                    this.Visible = false;
                    frmHistorial frmh = new frmHistorial();
                    frmh.ShowDialog();
                    frmh.Dispose();
                    this.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAlmacen_Bunifu ~ btnHistorial_Click");
            }
        }

        #region Events
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAlmacen ~ txt_buscador_KeyPress");
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
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void txt_buscador_Enter(object sender, EventArgs e)
        {
            try
            {
                this.txt_buscador.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAlmacen ~ txt_buscador_Enter");
            }
        }
        #endregion

        private void txt_buscador_Click(object sender, EventArgs e)
        {
            this.txt_buscador.Text = string.Empty;
        }
    }
}
