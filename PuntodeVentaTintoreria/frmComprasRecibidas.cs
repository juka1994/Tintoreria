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
    public partial class frmComprasRecibidas : Form
    {

        private frm_Esperar espere = new frm_Esperar();
        private Validaciones Val;
        private Compra infoCompra;

        public frmComprasRecibidas(Compra compra)
        {
            InitializeComponent();
            Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
            infoCompra = compra;
            infoCompra.id_sucursal = Comun.id_sucursal;
            infoCompra.conexion = Comun.conexion;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        #region MetodosGenerales
        private void GuardarCompra()
        {
            try
            {
                int Verificador = -1;
                CompraNegocio compra_negocio = new CompraNegocio();
                Compra compra = new Compra();
                compra.conexion = Comun.conexion;
                compra.id_u = Comun.id_u;
                compra.id_caja = Comun.id_caja;
                this.ObtenerDatos(compra);
                if (infoCompra.id_compra != null)
                {
                    compra.opcion = 4;
                    compra.id_compra = infoCompra.id_compra;
                    compra_negocio.AbcCompra(compra, ref Verificador);
                }

                int Verificador1 = -1;
                NotificacionNegocio notificacionNegocio = new NotificacionNegocio();
                Notificacion notificacion = new Notificacion();
                notificacion.conexion = Comun.conexion;
                notificacion.opcion = 2;
                notificacion.id_generico = infoCompra.id_compra;
                notificacion.id_persona = infoCompra.id_proveedor;
                notificacion.id_tipoNotificacion = 6;
                notificacion.enviar = true;
                notificacion.nombre = "Pedido Recibido";
                notificacion.texto = "Se recibió el pedido en la sucursal: " + infoCompra.sucursal + " con folio:[" + infoCompra.folioPedido + "], inicié sesion en la aplicación movil para ver los detalles.";
                notificacion.descripcion = notificacion.texto;
                notificacion.id_u = Comun.id_u;
                notificacionNegocio.AbcNotificacionApp(notificacion, ref Verificador1);
                if (Verificador1 == 0)
                    if (notificacion.datos.Rows[0]["id_token"].ToString() != null)
                        ClasesAux.EnvioMensaje.EnviarMensaje(
                            notificacion.datos.Rows[0]["id_token"].ToString(),
                            notificacion.datos.Rows[0]["nombre"].ToString(),
                            notificacion.datos.Rows[0]["descripcion"].ToString(),
                            false);

                this.VerifcarMensajeAccion(Verificador);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    
        private void LlenarDatos()
        {
            try
            {
                this.txt_folioPedido.Text = infoCompra.folioPedido;
                this.cmb_sucursal.SelectedValue = infoCompra.id_sucursal.ToString();
                this.cmb_proveedor.SelectedValue = infoCompra.id_proveedor.ToString();
                this.dtp_fechaPedido.Value = infoCompra.fechaPedido;
                this.txt_fechaPedido.Text = infoCompra.fechaPedido.ToShortDateString();
                this.dtp_horaPedido.Value = Convert.ToDateTime(infoCompra.horaPedido);
                this.txt_horaPedido.Text = infoCompra.horaPedido;
                this.txt_monto.Text = string.Format("{0:C2}", infoCompra.monto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Inicializar()
        {
            try
            {
                CompraNegocio compra_negocio = new CompraNegocio();
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

                if (infoCompra.id_compra != null)
                {
                    compra_detalle.id_compra = infoCompra.id_compra;
                    compra_negocio.ObtenerDetalleCompra(compra_detalle);
                    this.LlenarDatos();
                }
                infoCompra.compraDetalle = compra_detalle;
                this.GridViewCompraDetalle.AutoGenerateColumns = false;
                this.GridViewCompraDetalle.DataSource = infoCompra.compraDetalle.datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ObtenerDatos(Compra compra)
        {
            try
            {
                compra.id_sucursal = this.cmb_sucursal.SelectedValue.ToString();
                compra.id_statusCompra = 4;
                compra.fechaPedido = this.dtp_fechaPedido.Value;
                compra.horaPedido = this.dtp_horaPedido.Value.TimeOfDay.ToString();
                compra.observaciones = infoCompra.observaciones;
                compra.id_proveedor = infoCompra.id_proveedor;
                compra.monto = float.Parse(this.txt_monto.Text, NumberStyles.Currency, CultureInfo.CurrentCulture);
                compra.compraDetalle = new CompraDetalle();
                compra.compraDetalle.datos = (DataTable)this.GridViewCompraDetalle.DataSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void VerifcarMensajeAccion(int Verificador)
        {

            try
            {
                if (Verificador == 0)
                {
                    MessageBox.Show(this, "Los datos se guardaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
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
                foreach (DataGridViewRow row in GridViewCompraDetalle.Rows)
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
        private void CalcularTotal()
        {
            try
            {
                float total = 0.0F;
                if (GridViewCompraDetalle.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in GridViewCompraDetalle.Rows)
                    {
                        total += Convert.ToSingle(row.Cells["costoUltimo"].Value) * Convert.ToInt32(row.Cells["cantidad"].Value) - Convert.ToSingle(row.Cells["descuento"].Value);
                    }
                }
                this.txt_monto.Text = string.Format("{0:C2}", total);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void CalcularDescuento(int rowIndex)
        {
            try
            {
                DataGridViewRow Fila = this.GridViewCompraDetalle.Rows[rowIndex];
                int CantidadDesc = 0;
                int.TryParse(Fila.Cells["cantDef"].Value.ToString(), out CantidadDesc);
                decimal Precio = 0;
                decimal.TryParse(Fila.Cells["costoUltimo"].Value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture, out Precio);
                Fila.Cells["descuento"].Value = Precio * CantidadDesc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion
        #region Validaciones
        private void txt_monto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloDecimal(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmComprasRecibidas ~ txt_monto_KeyPress");
            }
        }

        private void txt_monto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_monto_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion
        private void frmComprasRecibidas_Load(object sender, EventArgs e)
        {
            try
            {
                this.backgroundWorker1.RunWorkerAsync();
                espere.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmComprasRecibidas ~ frmComprasRecibidas_Load");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.GuardarCompra();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmComprasRecibidas ~ btnGuardar_Click");
            }
        }

        private void GridViewProductosDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;
                tb.KeyPress -= new KeyPressEventHandler(dataGridViewTextBox_KeyPress);
                tb.KeyDown -= new KeyEventHandler(dataGridViewTextBox_KeyDown);
                tb.MouseDown -= new MouseEventHandler(dataGridViewTextBox_MouseDown);
                tb.KeyPress += new KeyPressEventHandler(dataGridViewTextBox_KeyPress);
                tb.KeyDown += new KeyEventHandler(dataGridViewTextBox_KeyDown);
                tb.MouseDown += new MouseEventHandler(dataGridViewTextBox_MouseDown);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmComprasRecibidas~ GridViewProductosDetalle_EditingControlShowing");
            }
        }

        private void dataGridViewTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloNumerico(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmComprasRecibidas~ dataGridViewTextBox_KeyPress");
            }
        }
        private void dataGridViewTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void dataGridViewTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                return;
            }
        }

        private void GridViewCompraDetalle_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;
                tb.KeyPress -= new KeyPressEventHandler(dataGridViewTextBox_KeyPress);
                tb.KeyDown -= new KeyEventHandler(dataGridViewTextBox_KeyDown);
                tb.MouseDown -= new MouseEventHandler(dataGridViewTextBox_MouseDown);
                tb.KeyPress += new KeyPressEventHandler(dataGridViewTextBox_KeyPress);
                tb.KeyDown += new KeyEventHandler(dataGridViewTextBox_KeyDown);
                tb.MouseDown += new MouseEventHandler(dataGridViewTextBox_MouseDown);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmComprasRecibidas ~ GridViewCompraDetalle_EditingControlShowing");
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


            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                DataTable Aux = (DataTable)e.Result;
                this.cmb_sucursal.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_sucursal.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_sucursal.DataSource = Aux;
                this.cmb_sucursal.DisplayMember = "nombre";
                this.cmb_sucursal.ValueMember = "id_sucursal";
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
                ProveedorNegocio proveedor_negocio = new ProveedorNegocio();
                Proveedor proveedor = new Proveedor();
                proveedor.conexion = Comun.conexion;
                proveedor_negocio.ObtenerComboProveedorGeneral(proveedor);
                e.Result = proveedor.datos;
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
                this.cmb_proveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_proveedor.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_proveedor.DataSource = Aux;
                this.cmb_proveedor.DisplayMember = "proveedor";
                this.cmb_proveedor.ValueMember = "id_proveedor";
                this.backgroundWorker3.RunWorkerAsync();
            }
            catch (Exception ex)
            {


            }
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                Producto producto = new Producto();
                producto.conexion = Comun.conexion;
                ProductoNegocio producto_negocio = new ProductoNegocio();
                producto_negocio.ObtenerComboProductosCompras(producto, cmb_sucursal.SelectedValue.ToString(), cmb_proveedor.SelectedValue.ToString());
                DataTable Aux = (DataTable)e.Result;
                this.Inicializar();
                this.cmb_proveedor.Focus();
                this.ActiveControl = this.cmb_proveedor;
                this.espere.Close();
            }
            catch (Exception ex)
            {


            }
        }

        private void btnGuardar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    this.btnGuardar_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmComprasRecibidas ~ btnAceptar_KeyPress");
            }
        }
    }
}
