using PuntodeVentaTintoreria.ClaseAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TintoreriaGlobal;
using TintoreriaNegocio;

namespace PuntodeVentaTintoreria
{
    
    public partial class frmBodega : Form
    {
        Validaciones Val;
        frm_Esperar espere = new frm_Esperar();
        public frmBodega()
        {
            try
            {
                InitializeComponent();
                Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBodega ~ frmBodega_Bunifu()");
            }
           
        }

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
                LogError.AddExcFileTxt(ex, "frmBodega ~ txt_buscador_KeyPress");
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
                LogError.AddExcFileTxt(ex, "frmBodega ~ txt_buscador_Enter");
            }
        }
        private void txt_buscador_Click(object sender, EventArgs e)
        {
            try
            {
                this.txt_buscador.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBodega ~ txt_buscador_Click");
            }
        }
        #endregion
        #region MetodosGenerales
        private List<DataGridViewRow> ObtenerFilaSeleccionada()
        {
            try
            {
                List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in GridViewArticulos.Rows)
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
        private void CargarGridArticulos(string busqueda, string id_sucursal)
        {
            try
            {
                BodegaNegocio bodega_negocio = new BodegaNegocio();
                Bodega bodega = new Bodega();
                bodega.conexion = Comun.conexion;
                bodega.id_sucursal = id_sucursal;
                bodega.busqueda = busqueda;
                bodega_negocio.LLenarGridBodega(bodega);
                this.GridViewArticulos.AutoGenerateColumns = false;
                this.GridViewArticulos.DataSource = bodega.datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private Bodega ObtenerDatosGridArticulos()
        {
            try
            {
                Bodega bodega = new Bodega();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    bodega.nombreProducto = row.Cells["nombreProducto"].Value.ToString();
                    bodega.id_producto = row.Cells["id_producto"].Value.ToString();
                    bodega.id_sucursal = row.Cells["id_sucursal"].Value.ToString();
                    bodega.id_colorRopa = Convert.ToInt32(row.Cells["id_colorRopa"].Value.ToString());
                    bodega.cantidad = Convert.ToInt32(row.Cells["cantidad"].Value.ToString());
                    bodega.id_tallaRopa = Convert.ToInt32(row.Cells["id_tallaRopa"].Value.ToString());
                    bodega.costo = float.Parse(row.Cells["costoUltimo"].Value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture);
                    bodega.subtotal = float.Parse(row.Cells["subtotal"].Value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture);
                    bodega.id_proveedor = row.Cells["id_proveedor"].Value.ToString();
                }
                return bodega;
            }
            catch (Exception ex)
            {
                return null;
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
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void GridViewPendientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlBusqueda_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    frm_PedirAutorizacion frma = new frm_PedirAutorizacion();
                    frma.ShowDialog();
                    frma.Dispose();
                    if (frma.DialogResult == DialogResult.OK)
                    {
                        frmAplicarBodega frmab = new frmAplicarBodega(this.ObtenerDatosGridArticulos());
                        frmab.ShowDialog();
                        frmab.Dispose();
                        using (new Recursos.CursorWait())
                        {
                            CargarGridArticulos("", this.cmb_sucursal.SelectedValue.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBodega ~ btnAplicar_Click");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.CargarGridArticulos(this.txt_buscador.Text, this.cmb_sucursal.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBodega ~ btnBuscar_Click");
            }
        }

        private void frmBodega_Load(object sender, EventArgs e)
        {
            try
            {
                this.backgroundWorker1.RunWorkerAsync();
                espere.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBodega ~ frmBodega_Load");
            }
        }


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
                this.backgroundWorker2.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        this.CargarGridArticulos("", this.cmb_sucursal.SelectedValue.ToString());
                    }
                    else
                    {
                        cmb_sucursal.Enabled = false;
                        this.CargarGridArticulos("", this.cmb_sucursal.SelectedValue.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBodega_Bunifu ~ cmb_sucursal_SelectedValueChanged");
            }

        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                BodegaNegocio bodega_negocio = new BodegaNegocio();
                Bodega bodega = new Bodega();
                bodega.conexion = Comun.conexion;
                bodega.id_sucursal = Comun.id_sucursal;
                bodega.busqueda = "";
                bodega_negocio.LLenarGridBodega(bodega);
                e.Result = bodega.datos;
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
                this.GridViewArticulos.AutoGenerateColumns = false;
                this.GridViewArticulos.DataSource = Aux;

                espere.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.txt_buscador.Text = "Búsqueda por sucursal o nombre";
                    CargarGridArticulos("", this.cmb_sucursal.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBodega ~ btnCancelar_Click");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    frm_PedirAutorizacion frma = new frm_PedirAutorizacion();
                    frma.ShowDialog();
                    frma.Dispose();
                    Bodega bodega = this.ObtenerDatosGridArticulos();
                    if (frma.DialogResult == DialogResult.OK)
                    {
                        bodega.opcion = 2;
                        frmAArticuloBodega frmab = new frmAArticuloBodega(bodega);
                        frmab.ShowDialog();
                        frmab.Dispose();
                        using (new Recursos.CursorWait())
                        {
                            CargarGridArticulos("", this.cmb_sucursal.SelectedValue.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBodega ~ btnExcluir");
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    frm_PedirAutorizacion frma = new frm_PedirAutorizacion();
                    frma.ShowDialog();
                    frma.Dispose();
                    Bodega bodega = this.ObtenerDatosGridArticulos();
                    if (frma.DialogResult == DialogResult.OK)
                    {
                        bodega.opcion = 1;
                        frmAArticuloBodega frmab = new frmAArticuloBodega(bodega);
                        frmab.ShowDialog();
                        frmab.Dispose();
                        using (new Recursos.CursorWait())
                        {
                            CargarGridArticulos("", this.cmb_sucursal.SelectedValue.ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBodega_Bunifu ~ btnQuitar_Click");
            }
        }
    }
}
