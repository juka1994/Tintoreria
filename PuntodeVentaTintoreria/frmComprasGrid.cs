using PuntodeVentaTintoreria.ClaseAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TintoreriaGlobal;
using TintoreriaNegocio;

namespace PuntodeVentaTintoreria
{
    public partial class frmComprasGrid : Form
    {
        Compra infoCompra = new Compra();
        frm_Esperar espere = new frm_Esperar();
        int tipoBusqueda = 1;
        int tabIndex;
        Validaciones Val;
        int tab = 0;
        public frmComprasGrid()
        {
            InitializeComponent();
            Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
        }

        public frmComprasGrid(int index)
        {
            InitializeComponent();
            tab = index;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        #region Metodos Generales
        private bool ValidarSucursal(String id_sucursal)
        {
            try
            {
                if (id_sucursal != Comun.id_sucursal)
                {
                    MessageBox.Show(this, "Operacion no valida para esta sucursal", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                switch (this.tabControlCompras.SelectedIndex)
                {
                    case 0:
                        foreach (DataGridViewRow row in GridViewCompras.Rows)
                        {
                            if (row.Selected)
                            {
                                rowSelected.Add(row);
                            }
                        }
                        break;
                    case 1:
                        foreach (DataGridViewRow row in GridViewEnviado.Rows)
                        {
                            if (row.Selected)
                            {
                                rowSelected.Add(row);
                            }
                        }
                        break;
                    case 2:
                        foreach (DataGridViewRow row in GridViewProcesado.Rows)
                        {
                            if (row.Selected)
                            {
                                rowSelected.Add(row);
                            }
                        }
                        break;
                    case 3:
                        foreach (DataGridViewRow row in GridViewRecibido.Rows)
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
        private void CargarGridCompras(string busqueda, DateTime fecha, int tipoBusqueda, int tabIndex, string id_sucursal)
        {
            try
            {
                CompraNegocio compra_negocio = new CompraNegocio();
                Compra compra = new Compra();
                compra.conexion = Comun.conexion;
                compra.tipoBusqueda = tipoBusqueda;
                compra.busqueda = busqueda;
                compra.id_sucursal = id_sucursal;
                compra.fechaPedido = fecha;
                compra_negocio.LLenarGridCompra(compra, tabIndex);
                switch (tabIndex)
                {
                    case 0:
                        this.GridViewCompras.AutoGenerateColumns = false;
                        this.GridViewCompras.DataSource = compra.datos;
                        break;
                    case 1:
                        this.GridViewEnviado.AutoGenerateColumns = false;
                        this.GridViewEnviado.DataSource = compra.datos;
                        break;
                    case 2:
                        this.GridViewProcesado.AutoGenerateColumns = false;
                        this.GridViewProcesado.DataSource = compra.datos;
                        break;
                    case 3:
                        this.GridViewRecibido.AutoGenerateColumns = false;
                        this.GridViewRecibido.DataSource = compra.datos;
                        break;
                    default:
                        this.GridViewCompras.AutoGenerateColumns = false;
                        this.GridViewCompras.DataSource = compra.datos;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private Compra ObtenerDatosGridCompra()
        {
            try
            {
                Compra compra = new Compra();
                int TabIndex = this.tabControlCompras.SelectedIndex + 1;
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    compra.id_compra = row.Cells["id_compra" + TabIndex].Value.ToString();
                    compra.id_statusCompra = Convert.ToInt32(row.Cells["id_statusCompra" + TabIndex].Value.ToString());
                    compra.folioPedido = row.Cells["folioPedido" + TabIndex].Value.ToString();
                    compra.id_sucursal = row.Cells["id_sucursal" + TabIndex].Value.ToString();
                    compra.sucursal = row.Cells["nombre" + TabIndex].Value.ToString();
                    compra.id_proveedor = row.Cells["id_proveedor" + TabIndex].Value.ToString();
                    compra.fechaPedido = Convert.ToDateTime(row.Cells["fechaPedido" + TabIndex].Value.ToString());
                    compra.horaPedido = row.Cells["horaPedido" + TabIndex].Value.ToString();
                    compra.monto = float.Parse(row.Cells["monto" + TabIndex].Value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture);
                    compra.observaciones = row.Cells["observaciones" + TabIndex].Value.ToString();
                }
                return compra;
            }
            catch (Exception ex)
            {
                return null;

            }
        }

        private void EliminarCompra(Compra compra)
        {
            try
            {
                int Verificador = -1;
                CompraNegocio compraNegocio = new CompraNegocio();
                compra.conexion = Comun.conexion;
                compra.opcion = 3;
                compra.id_u = Comun.id_u;
                CompraDetalle compra_detalle = new CompraDetalle();
                compra_detalle.datos = new DataTable();
                compra_detalle.datos.Columns.Add("nombreProductoFinal", typeof(string));
                compra_detalle.datos.Columns.Add("cantidadFinal", typeof(decimal));
                compra_detalle.datos.Columns.Add("txtUnidadMedidaFinal", typeof(string));
                compra_detalle.datos.Columns.Add("id_productoFinal", typeof(string));
                compra_detalle.datos.Columns.Add("id_unidadMedidaFinal", typeof(int));
                compra_detalle.datos.Columns.Add("costoFinal", typeof(decimal));
                compra_detalle.datos.Columns.Add("Subtotal", typeof(decimal));

                compra.compraDetalle = compra_detalle;
                compraNegocio.AbcCompra(compra, ref Verificador);
                if (Verificador == 0)
                {
                    this.txt_buscador.Text = "";
                    this.CargarGridCompras("", DateTime.Now, tipoBusqueda, this.tabControlCompras.SelectedIndex, this.cmb_sucursal.SelectedValue.ToString());
                    MessageBox.Show(this, "Los datos se eliminaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ProcesarCompra(Compra compra)
        {
            try
            {
                int Verificador = -1;
                CompraNegocio compraNegocio = new CompraNegocio();
                compra.conexion = Comun.conexion;
                compra.opcion = 6;
                compra.id_u = Comun.id_u;
                compra.id_sucursal = Comun.id_sucursal;
                CompraDetalle compra_detalle = new CompraDetalle();
                compra_detalle.datos = new DataTable();
                compra_detalle.datos.Columns.Add("nombreProductoFinal", typeof(string));
                compra_detalle.datos.Columns.Add("cantidadFinal", typeof(decimal));
                compra_detalle.datos.Columns.Add("txtUnidadMedidaFinal", typeof(string));
                compra_detalle.datos.Columns.Add("id_productoFinal", typeof(string));
                compra_detalle.datos.Columns.Add("id_unidadMedidaFinal", typeof(int));
                compra_detalle.datos.Columns.Add("costoFinal", typeof(decimal));
                compra_detalle.datos.Columns.Add("Subtotal", typeof(decimal));
                compra.compraDetalle = compra_detalle;
                compra.id_statusCompra = 3;
                compraNegocio.AbcCompra(compra, ref Verificador);
                if (Verificador == 0)
                {
                    this.txt_buscador.Text = "";
                    this.CargarGridCompras("", DateTime.Now, tipoBusqueda, this.tabControlCompras.SelectedIndex, this.cmb_sucursal.SelectedValue.ToString());
                    MessageBox.Show(this, "Los datos fueron procesados correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.CargarGridCompras("", DateTime.Now, 1, 2, compra.id_sucursal);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void EnviarCompra(Compra compra)
        {
            try
            {
                int Verificador = -1;
                CompraNegocio compraNegocio = new CompraNegocio();
                compra.conexion = Comun.conexion;
                compra.opcion = 5;
                compra.id_u = Comun.id_u;
                CompraDetalle compra_detalle = new CompraDetalle();
                compra_detalle.datos = new DataTable();
                compra_detalle.datos.Columns.Add("nombreProductoFinal", typeof(string));
                compra_detalle.datos.Columns.Add("cantidadFinal", typeof(decimal));
                compra_detalle.datos.Columns.Add("txtUnidadMedidaFinal", typeof(string));
                compra_detalle.datos.Columns.Add("id_productoFinal", typeof(string));
                compra_detalle.datos.Columns.Add("id_unidadMedidaFinal", typeof(int));
                compra_detalle.datos.Columns.Add("costoFinal", typeof(decimal));
                compra_detalle.datos.Columns.Add("Subtotal", typeof(decimal));
                compra.compraDetalle = compra_detalle;
                compra.id_statusCompra = 2;
                compraNegocio.AbcCompra(compra, ref Verificador);
                if (Verificador == 0)
                {
                    this.txt_buscador.Text = "";
                    this.CargarGridCompras("", DateTime.Now, tipoBusqueda, this.tabControlCompras.SelectedIndex, this.cmb_sucursal.SelectedValue.ToString());
                    MessageBox.Show(this, "La compra fue enviada satisfactoriamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                LogError.AddExcFileTxt(ex, "frmComprasGrid ~ txt_buscador_KeyPress");
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
        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GridViewCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.CargarGridCompras(this.txt_buscador.Text, this.dtp_fecha.Value, tipoBusqueda, this.tabControlCompras.SelectedIndex, this.cmb_sucursal.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmComprasGrid ~ btnBuscar_Click");
            }
        }

        private void pnlBotones_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmComprasGrid_Load(object sender, EventArgs e)
        {
            try
            {
                this.backgroundWorker1.RunWorkerAsync();
                espere.ShowDialog();
                check_folio.Checked = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmComprasGrid ~ frmComprasGrid_Bunifu_Load");
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
                this.cmb_sucursal.SelectedValueChanged -= new System.EventHandler(this.cmb_sucursal_SelectedValueChanged);
                e.Result = sucursal.datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                DataTable tabla = (DataTable)e.Result;
                this.cmb_sucursal.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_sucursal.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_sucursal.DataSource = tabla;
                this.cmb_sucursal.DisplayMember = "nombre";
                this.cmb_sucursal.ValueMember = "id_sucursal";
                this.cmb_sucursal.SelectedValueChanged += new System.EventHandler(this.cmb_sucursal_SelectedValueChanged);
                this.backgroundWorker2.RunWorkerAsync();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CompraNegocio compra_negocio = new CompraNegocio();
                Compra compra = new Compra();
                compra.conexion = Comun.conexion;
                compra.tipoBusqueda = tipoBusqueda;
                compra.busqueda = "";
                compra.id_sucursal = Comun.id_sucursal;
                compra.fechaPedido = DateTime.Now;
                compra_negocio.LLenarGridCompra(compra, 1);
                infoCompra.datos = compra.datos;
            }
            catch (Exception ex)
            {

            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.GridViewEnviado.AutoGenerateColumns = false;
                this.GridViewEnviado.DataSource = infoCompra.datos;
                this.cmb_sucursal.SelectedValue = Comun.id_sucursal;
                this.backgroundWorker3.RunWorkerAsync();
            }
            catch (Exception ex)
            {

            }
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CompraNegocio compra_negocio = new CompraNegocio();
                Compra compra = new Compra();
                compra.conexion = Comun.conexion;
                compra.tipoBusqueda = tipoBusqueda;
                compra.busqueda = "";
                compra.id_sucursal = Comun.id_sucursal;
                compra.fechaPedido = DateTime.Now;
                compra_negocio.LLenarGridCompra(compra, 2);
                infoCompra.datos = compra.datos;
            }
            catch (Exception ex)
            {

            }
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.GridViewProcesado.AutoGenerateColumns = false;
                this.GridViewProcesado.DataSource = infoCompra.datos;
                this.cmb_sucursal.SelectedValue = Comun.id_sucursal;
                this.backgroundWorker4.RunWorkerAsync();
            }
            catch (Exception ex)
            {

            }
        }

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CompraNegocio compra_negocio = new CompraNegocio();
                Compra compra = new Compra();
                compra.conexion = Comun.conexion;
                compra.tipoBusqueda = tipoBusqueda;
                compra.busqueda = "";
                compra.id_sucursal = Comun.id_sucursal;
                compra.fechaPedido = DateTime.Now;
                compra_negocio.LLenarGridCompra(compra, 3);
                infoCompra.datos = compra.datos;
            }
            catch (Exception ex)
            {

            }
        }

        private void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.GridViewRecibido.AutoGenerateColumns = false;
                this.GridViewRecibido.DataSource = infoCompra.datos;
                this.cmb_sucursal.SelectedValue = Comun.id_sucursal;
                espere.Close();
            }
            catch (Exception ex)
            {

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
                        this.CargarGridCompras("", DateTime.Now, tipoBusqueda, this.tabControlCompras.SelectedIndex, this.cmb_sucursal.SelectedValue.ToString());
                    }
                    else
                    {
                        cmb_sucursal.Enabled = false;
                        this.CargarGridCompras("", DateTime.Now, tipoBusqueda, this.tabControlCompras.SelectedIndex, this.cmb_sucursal.SelectedValue.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmComprasGrid ~ cmb_sucursal_SelectedValueChanged");
            }
        }

        private void check_folio_OnChange(object sender, EventArgs e)
        {
            try
            {
                if (check_folio.Checked)
                {
                    check_fecha.CheckedChanged -= new System.EventHandler(this.check_fecha_OnChange);
                    check_fecha.Checked = false;
                    check_fecha.CheckedChanged += new System.EventHandler(this.check_fecha_OnChange);
                    dtp_fecha.Visible = false;
                    txt_buscador.Visible = true;
                    tipoBusqueda = 1;
                    this.CargarGridCompras(txt_buscador.Text, DateTime.Now, tipoBusqueda, this.tabControlCompras.SelectedIndex, this.cmb_sucursal.SelectedValue.ToString());
                }
                else
                {
                    this.CargarGridCompras(txt_buscador.Text, DateTime.Now, tipoBusqueda, this.tabControlCompras.SelectedIndex, this.cmb_sucursal.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmComprasGrid ~ check_folio_OnChange");
            }
        }

        private void check_fecha_OnChange(object sender, EventArgs e)
        {
            if (check_fecha.Checked)
            {
                check_folio.Checked = false;
                check_folio.CheckedChanged -= new System.EventHandler(this.check_fecha_OnChange);
                check_folio.Checked = false;
                check_folio.CheckedChanged += new System.EventHandler(this.check_fecha_OnChange);
                dtp_fecha.Visible = true;
                txt_buscador.Visible = false;
                tipoBusqueda = 2;
                this.CargarGridCompras("", dtp_fecha.Value, tipoBusqueda, this.tabControlCompras.SelectedIndex, this.cmb_sucursal.SelectedValue.ToString());
            }
            else
            {
                txt_buscador.Visible = true;
                this.CargarGridCompras("", dtp_fecha.Value, tipoBusqueda, this.tabControlCompras.SelectedIndex, this.cmb_sucursal.SelectedValue.ToString());
            }
        }

        private void GridViewEnviado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.txt_buscador.Text = "";
                    this.CargarGridCompras("", DateTime.Now, 1, this.tabControlCompras.SelectedIndex, this.cmb_sucursal.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmComprasGrid ~ btnCancelar_Click");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmCompras fc = new frmCompras(new Compra());
                fc.ShowDialog();
                fc.Dispose();
                using (new Recursos.CursorWait())
                {
                    this.txt_buscador.Text = "";
                    this.CargarGridCompras("", DateTime.Now, tipoBusqueda, this.tabControlCompras.SelectedIndex, this.cmb_sucursal.SelectedValue.ToString());
                }
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmComprasGrid ~ btnNuevo_Click");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    Compra compra = this.ObtenerDatosGridCompra();
                    if (this.ValidarSucursal(compra.id_sucursal))
                    {
                        if (compra.id_statusCompra == 1)
                        {
                            this.Visible = false;
                            frmCompras fpr = new frmCompras(compra);
                            fpr.ShowDialog();
                            using (new Recursos.CursorWait())
                            {
                                this.txt_buscador.Text = "";
                                this.CargarGridCompras("", DateTime.Now, tipoBusqueda, this.tabControlCompras.SelectedIndex, this.cmb_sucursal.SelectedValue.ToString());
                            }
                            fpr.Dispose();
                            this.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show(this, "El estatus de la compra no permite su modificación.", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmComprasGrid~ btnModificar_Click");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Compra compra = this.ObtenerDatosGridCompra();
                if (this.ValidarSucursal(compra.id_sucursal))
                {
                    if (compra.id_statusCompra == 1)
                    {
                        if (MessageBox.Show("¿Desea eliminar este registro?", "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            using (new Recursos.CursorWait())
                            {
                                this.EliminarCompra(this.ObtenerDatosGridCompra());
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "El estatus de la compra no permite su eliminación.", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmComprasGrid ~ btnEliminar_Click");
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    Compra compra = this.ObtenerDatosGridCompra();
                    if (this.ValidarSucursal(compra.id_sucursal))
                    {
                        if (compra.id_statusCompra == 1)
                        {
                            using (new Recursos.CursorWait())
                            {
                                CompraNegocio compra_negocio = new CompraNegocio();
                                Compra compra_aux = this.ObtenerDatosGridCompra();
                                CompraDetalle compra_detalle = new CompraDetalle();
                                compra_detalle.conexion = Comun.conexion;
                                compra_detalle.datos = new DataTable();
                                compra_detalle.datos.Columns.Add("nombreProductoFinal", typeof(string));
                                compra_detalle.datos.Columns.Add("cantidadFinal", typeof(decimal));
                                compra_detalle.datos.Columns.Add("txtUnidadMedidaFinal", typeof(string));
                                compra_detalle.datos.Columns.Add("id_productoFinal", typeof(string));
                                compra_detalle.datos.Columns.Add("id_unidadMedidaFinal", typeof(int));
                                compra_detalle.datos.Columns.Add("costoFinal", typeof(decimal));
                                compra_detalle.datos.Columns.Add("Subtotal", typeof(decimal));
                                compra_detalle.datos.Columns.Add("imagen", typeof(String));

                                if (compra_aux.id_compra != null)
                                {
                                    compra_detalle.id_compra = compra_aux.id_compra;
                                    compra_negocio.ObtenerDetalleCompraCorreo(compra_detalle);
                                }
                                compra_aux.conexion = Comun.conexion;
                                compra_negocio.ObtenerCorreoProveedor(compra_aux);
                                if (compra_aux.correoProveedor != null)
                                {
                                    string html = ClasesAux.EnvioCorreo.GenerarHtmlCompras(Comun.ticket.razonsocial, Comun.ticket.rfc, Comun.ticket.direccion, compra_detalle.datos);

                                    ClasesAux.EnvioCorreo.EnviarCorreo(
                                            Comun.correosistema
                                           , Comun.password
                                           , compra_aux.correoProveedor
                                           , "Compras Punto de Venta - " + Comun.ticket.razonsocial
                                           , html
                                           , false
                                           , ""
                                           , Comun.html
                                           , Comun.host
                                           , Comun.puerto
                                           , Comun.ssl
                                           , compra_detalle.datos);
                                }
                                this.EnviarCompra(compra_aux);

                                int Verificador = -1;
                                NotificacionNegocio notificacionNegocio = new NotificacionNegocio();
                                Notificacion notificacion = new Notificacion();
                                notificacion.conexion = Comun.conexion;
                                notificacion.opcion = 2;
                                notificacion.id_generico = compra_aux.id_compra;
                                notificacion.id_persona = compra_aux.id_proveedor;
                                notificacion.id_tipoNotificacion = 1;
                                notificacion.enviar = true;
                                notificacion.nombre = "Pedido Solicitado";
                                notificacion.texto = "Se registró un pedido en la sucursal: " + compra_aux.sucursal + " con folio:[" + compra_aux.folioPedido + "], inicié sesion en la aplicación movil para ver los detalles.";
                                notificacion.descripcion = notificacion.texto;
                                notificacion.id_u = Comun.id_u;
                                notificacionNegocio.AbcNotificacionAppDU(notificacion, ref Verificador);
                                if (Verificador == 0)
                                    if (notificacion.datos.Rows[0]["id_token"].ToString() != null)
                                        ClasesAux.EnvioMensaje.EnviarMensaje(
                                            notificacion.datos.Rows[0]["id_token"].ToString(),
                                            notificacion.datos.Rows[0]["nombre"].ToString(),
                                            notificacion.datos.Rows[0]["descripcion"].ToString(),
                                            false);

                                this.CargarGridCompras("", DateTime.Now, 1, 1, compra.id_sucursal);
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "El estatus de la compra no permite su envió", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmComprasGrid ~ btnEnviar_Click");
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    Compra compra = this.ObtenerDatosGridCompra();
                    if (this.ValidarSucursal(compra.id_sucursal))
                    {
                        if (compra.id_statusCompra == 2)
                        {
                            using (new Recursos.CursorWait())
                            {
                                this.ProcesarCompra(this.ObtenerDatosGridCompra());
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "El estatus de la compra no permite su envió", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmComprasGrid ~ btnProcesar_Click");
            }
        }

        private void btnRecibir_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    Compra compra = this.ObtenerDatosGridCompra();
                    if (this.ValidarSucursal(compra.id_sucursal))
                    {
                        if (compra.id_statusCompra == 3)
                        {
                            this.Visible = false;
                            frmComprasRecibidas fcr = new frmComprasRecibidas(compra);
                            fcr.ShowDialog();
                            using (new Recursos.CursorWait())
                            {
                                this.txt_buscador.Text = "";
                                this.CargarGridCompras("", DateTime.Now, 1, 2, this.cmb_sucursal.SelectedValue.ToString());
                                this.CargarGridCompras("", DateTime.Now, 1, 3, this.cmb_sucursal.SelectedValue.ToString());
                            }
                            fcr.Dispose();
                            this.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show(this, "El estatus de la compra no permite su modificación.", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta LavAnderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmComprasGrid ~ btnRecibir_Click");
            }
        }

        private void tcVales_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CargarGridCompras("", DateTime.Today, 1, this.tabControlCompras.SelectedIndex, infoCompra.id_sucursal);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmPromociones ~ tcVales_SelectedIndexChanged");
            }
        }

       
    }
}
