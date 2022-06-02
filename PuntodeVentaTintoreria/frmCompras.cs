using PuntodeVentaTintoreria.ClaseAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using TintoreriaGlobal;
using TintoreriaNegocio;

namespace PuntodeVentaTintoreria
{
    public partial class frmCompras : Form
    {
        private Validaciones Val;
        private Compra infoCompra;
        private frm_Esperar espere = new frm_Esperar();
        public frmCompras(Compra compra)
        {
            InitializeComponent();

            infoCompra = compra;
            infoCompra.id_sucursal = Comun.id_sucursal;
            infoCompra.conexion = Comun.conexion;
        }

        #region MetodosGenerales
        private void GuardarCompra()
        {
            try
            {
                Val = new Validaciones();
                int Verificador = -1;
                CompraNegocio compra_negocio = new CompraNegocio();
                Compra compra = new Compra();
                compra.conexion = Comun.conexion;
                compra.id_caja = Comun.id_caja;
                compra.id_u = Comun.id_u;
                this.ObtenerDatos(compra);
                if (infoCompra.id_compra != null)
                {
                    compra.opcion = 2;
                    compra.id_compra = infoCompra.id_compra;
                    compra_negocio.AbcCompra(compra, ref Verificador);
                }
                else
                {
                    compra.opcion = 1;
                    compra_negocio.AbcCompra(compra, ref Verificador);
                }
                this.VerifcarMensajeAccion(Verificador);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                this.cmb_sucursal.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_sucursal.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_sucursal.DataSource = sucursal.datos;
                this.cmb_sucursal.DisplayMember = "nombre";
                this.cmb_sucursal.ValueMember = "id_sucursal";

                ProveedorNegocio proveedor_negocio = new ProveedorNegocio();
                Proveedor proveedor = new Proveedor();
                proveedor.conexion = Comun.conexion;
                proveedor_negocio.ObtenerComboProveedor(proveedor);
                this.cmb_proveedor.SelectedValueChanged -= new System.EventHandler(this.cmb_proveedor_SelectedValueChanged);
                this.cmb_proveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_proveedor.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_proveedor.DataSource = proveedor.datos;
                this.cmb_proveedor.DisplayMember = "proveedor";
                this.cmb_proveedor.ValueMember = "id_proveedor";
                this.cmb_proveedor.SelectedValueChanged += new System.EventHandler(this.cmb_proveedor_SelectedValueChanged);

                ProductoNegocio producto_negocio = new ProductoNegocio();
                Producto producto = new Producto();
                producto.conexion = Comun.conexion;
                producto_negocio.ObtenerComboProductosCompras(producto, cmb_sucursal.SelectedValue.ToString(), cmb_proveedor.SelectedValue.ToString());
                this.cmb_producto.SelectedValueChanged -= new System.EventHandler(this.cmb_producto_SelectedValueChanged);
                this.cmb_producto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_producto.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_producto.DataSource = producto.datos;
                this.cmb_producto.DisplayMember = "nombreProducto";
                this.cmb_producto.ValueMember = "id_producto";
                this.cmb_producto.SelectedValueChanged += new System.EventHandler(this.cmb_producto_SelectedValueChanged);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Laavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void LlenarDatos()
        {
            try
            {
                this.txt_folioPedido.Text = infoCompra.folioPedido;
                this.cmb_sucursal.SelectedValue = infoCompra.id_sucursal.ToString();
                this.txt_observaciones.Text = infoCompra.observaciones;
                this.dtp_fechaPedido.Value = infoCompra.fechaPedido;
                txt_fechaPedido.Text = infoCompra.fechaPedido.ToString();
                this.dtp_horaPedido.Value = Convert.ToDateTime(infoCompra.horaPedido);
                txt_horaPedido.Text = infoCompra.horaPedido;
                this.cmb_proveedor.SelectedValue = infoCompra.id_proveedor.ToString();
                this.cmb_proveedor.Enabled = false;
                this.txt_costoTotal.Text = string.Format("{0:C2}", infoCompra.monto);
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
                this.cmb_sucursal.SelectedValue = infoCompra.id_sucursal.ToString();
                this.dtp_fechaPedido.Value = DateTime.Today;
                this.txt_fechaPedido.Text = DateTime.Today.ToString("dd/MM/yyyy");
                this.dtp_horaPedido.Value = DateTime.Now;
                this.txt_horaPedido.Text = DateTime.Now.ToShortTimeString();
                CompraNegocio compra_negocio = new CompraNegocio();
                this.txt_folioPedido.Text = compra_negocio.ObtenerFolioPedido(infoCompra.conexion, infoCompra.id_sucursal);
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
                    this.cmb_sucursal.Enabled = false;
                }
                infoCompra.compraDetalle = compra_detalle;
                this.GridViewCompraDetalle.AutoGenerateColumns = false;
                this.GridViewCompraDetalle.DataSource = infoCompra.compraDetalle.datos;
                if (Comun.id_tu != 1)
                    this.cmb_sucursal.Enabled = false;
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
                compra.id_statusCompra = 1;
                compra.fechaPedido = this.dtp_fechaPedido.Value;
                compra.horaPedido = this.dtp_horaPedido.Value.TimeOfDay.ToString();
                compra.observaciones = this.txt_observaciones.Text;
                compra.id_proveedor = this.cmb_proveedor.SelectedValue.ToString();
                compra.monto = float.Parse(this.txt_costoTotal.Text.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture);
                compra.compraDetalle = new CompraDetalle();
                compra.compraDetalle.datos = (DataTable)this.GridViewCompraDetalle.DataSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidarCampos()
        {
            try
            {
                if (Convert.ToInt32(this.cmb_proveedor.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_proveedor.SelectedIndex) == -1)
                {
                    this.cmb_proveedor.Focus();
                    MessageBox.Show(this, "Seleccione el proveedor de la compra", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.GridViewCompraDetalle.Rows.Count == 0)
                {
                    this.cmb_producto.Focus();
                    MessageBox.Show(this, "Seleccione un producto a la compra", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
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

        private void checkProductos()
        {
            int contador = 0;
            foreach (DataGridViewRow row in GridViewProductosDetalle.Rows)
            {
                DataGridViewCheckBoxCell check = (DataGridViewCheckBoxCell)row.Cells[0];
                DataGridViewTextBoxCell cantidad = (DataGridViewTextBoxCell)row.Cells[3];
                DataGridViewTextBoxCell precioUnitario = (DataGridViewTextBoxCell)row.Cells[5];

                if (Convert.ToBoolean(check.Value) == true)
                {
                    if (Convert.ToDecimal(cantidad.Value.ToString()) > 0 && Convert.ToDecimal(precioUnitario.Value.ToString()) > 0)
                    {
                        string id_producto = this.cmb_producto.SelectedValue.ToString().Trim();
                        bool repetido = false;

                        DataTable dataTable = new DataTable();
                        DataRow[] foundRows;
                        dataTable = GridViewCompraDetalle.DataSource as DataTable;
                        foundRows = dataTable.Select("id_productoFinal = '" + id_producto + "'");

                        repetido = foundRows.Length > 0 ? true : false;

                        if (!repetido)
                        {
                            DataGridViewTextBoxCell nombre_producto = (DataGridViewTextBoxCell)row.Cells[1];
                            DataGridViewComboBoxCell itemUnidadMedida = (DataGridViewComboBoxCell)row.Cells[4];
                            DataGridViewTextBoxCell nombreUnidadMedida_producto = new DataGridViewTextBoxCell() { Value = itemUnidadMedida.FormattedValue };
                            

                            //Agregar las Filas al DataRow y asignar el valor correspondiente. 
                            DataTable dt2 = new DataTable();
                            dt2 = GridViewCompraDetalle.DataSource as DataTable;

                            DataRow datarow;
                            datarow = dt2.NewRow(); //Con esto le indica que es una nueva fila.

                            datarow["nombreProductoFinal"] = nombre_producto.Value.ToString();
                            datarow["cantidadFinal"] = cantidad.Value.ToString();
                            datarow["txtUnidadMedidaFinal"] = itemUnidadMedida.FormattedValue.ToString();
                            datarow["id_productoFinal"] = id_producto;
                            datarow["id_unidadMedidaFinal"] = (int)itemUnidadMedida.Value;
                            decimal auxCantidad = Convert.ToDecimal(cantidad.Value);
                            decimal auxPrecioUnitario = Convert.ToDecimal(precioUnitario.Value);
                            decimal auxSubtotal = auxCantidad * auxPrecioUnitario;
                            datarow["Subtotal"] = auxSubtotal;
                            datarow["costoFinal"] = auxPrecioUnitario;
                            dt2.Rows.Add(datarow);
                        }
                        else
                        {
                            MessageBox.Show(this, "Este producto ya fue agregado", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        MessageBox.Show(this, "La cantidad y el precio unitairo deben ser mayores a 0.", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    contador++;
            }
            if (GridViewProductosDetalle.Rows.Count == contador)
                MessageBox.Show(this, "Seleccione un producto a la compra", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        total += Convert.ToSingle(row.Cells["Subtotal"].Value);
                    }
                }
                this.txt_costoTotal.Text = string.Format("{0:C2}", total);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        
        #endregion
        #region Validaciones
        private void txt_observaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloTexto(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmComprasu ~ txt_observaciones_KeyPress");
            }
        }

        private void txt_observaciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_observaciones_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        #region SegundoPlano

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
                proveedor_negocio.ObtenerComboProveedor(proveedor);
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
                this.cmb_proveedor.SelectedValueChanged -= new System.EventHandler(this.cmb_proveedor_SelectedValueChanged);
                this.cmb_proveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_proveedor.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_proveedor.DataSource = Aux;
                this.cmb_proveedor.DisplayMember = "proveedor";
                this.cmb_proveedor.ValueMember = "id_proveedor";
                this.cmb_proveedor.SelectedValueChanged += new System.EventHandler(this.cmb_proveedor_SelectedValueChanged);
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

            }
            catch (Exception ex)
            {


            }
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                ProductoNegocio producto_negocio = new ProductoNegocio();
                Producto producto = new Producto();
                producto.conexion = Comun.conexion;
                producto_negocio.ObtenerComboProductosCompras(producto, cmb_sucursal.SelectedValue.ToString(), cmb_proveedor.SelectedValue.ToString());
                this.cmb_producto.SelectedValueChanged -= new System.EventHandler(this.cmb_producto_SelectedValueChanged);
                this.cmb_producto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_producto.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_producto.DataSource = producto.datos;
                this.cmb_producto.DisplayMember = "nombreProducto";
                this.cmb_producto.ValueMember = "id_producto";
                this.cmb_producto.SelectedValueChanged += new System.EventHandler(this.cmb_producto_SelectedValueChanged);
                this.Inicializar();
                this.cmb_proveedor.Focus();
                this.ActiveControl = this.cmb_proveedor;
                espere.Close();
            }
            catch (Exception ex)
            {


            }
        }
        
        #endregion

        private void cmb_producto_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    DataTable datos = new DataTable();
                    datos.Clear();
                    this.GridViewProductosDetalle.DataSource = datos;
                    CompraNegocio compra_negocio = new CompraNegocio();
                    Compra compra = new Compra();
                    compra.conexion = Comun.conexion;
                    compra.id_producto = this.cmb_producto.SelectedValue.ToString().Trim();
                    compra.id_sucursal = this.cmb_sucursal.SelectedValue.ToString();
                    compra_negocio.LLenarGridCompraDetalle(compra);
                    UnidadMedidaNegocio oUMNegocio = new UnidadMedidaNegocio();
                    this.GridViewProductosDetalle.AutoGenerateColumns = false;
                    this.GridViewProductosDetalle.DataSource = compra.datos;
                    DataGridViewComboBoxColumn comboboxColumn = GridViewProductosDetalle.Columns["CmbUnidadMedida"] as DataGridViewComboBoxColumn;
                    comboboxColumn.DataSource = oUMNegocio.GetComboUnidadMedidaXIdProducto(compra.id_producto);
                    comboboxColumn.DisplayMember = "descripcion";
                    comboboxColumn.ValueMember = "id_unidadMedida";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCompras ~ btnCancelar_Click");
            }
        }

        private void cmb_proveedor_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    ProductoNegocio producto_negocio = new ProductoNegocio();
                    Producto producto = new Producto();
                    producto.conexion = Comun.conexion;
                    producto_negocio.ObtenerComboProductosCompras(producto, cmb_sucursal.SelectedValue.ToString(), cmb_proveedor.SelectedValue.ToString());
                    this.cmb_proveedor.SelectedValueChanged -= new System.EventHandler(this.cmb_proveedor_SelectedValueChanged);
                    this.cmb_producto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    this.cmb_producto.AutoCompleteSource = AutoCompleteSource.ListItems;
                    this.cmb_producto.DataSource = producto.datos;
                    this.cmb_producto.DisplayMember = "nombreProducto";
                    this.cmb_producto.ValueMember = "id_producto";
                    this.cmb_proveedor.SelectedValueChanged += new System.EventHandler(this.cmb_proveedor_SelectedValueChanged);
                    cmb_producto.SelectedValue = "0";
                    if (this.GridViewCompraDetalle.Rows.Count != 0)
                    {
                        infoCompra.compraDetalle.datos.Clear();
                        this.GridViewCompraDetalle.DataSource = infoCompra.compraDetalle.datos;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCompras ~ cmb_proveedor_SelectedValueChanged");
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
                LogError.AddExcFileTxt(ex, "frmCompras ~ GridViewProductosDetalle_EditingControlShowing");
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
                LogError.AddExcFileTxt(ex, "frmCompras ~ dataGridViewTextBox_KeyPress");
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

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (this.ValidarCampos())
                    {
                        this.GuardarCompra();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCompras ~ btnGuardar_Click");
            }
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (Convert.ToInt32(this.cmb_proveedor.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_proveedor.SelectedIndex) == -1)
                    {
                        this.cmb_proveedor.Focus();
                        MessageBox.Show(this, "Seleccione el proveedor de la compra", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (cmb_producto.SelectedValue.ToString() != "0")
                        {
                            checkProductos();
                            CalcularTotal();
                        }
                        else if (cmb_producto.SelectedValue.ToString() == "0")
                        {
                            MessageBox.Show(this, "Seleccione un producto a la compra", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCompras ~ btn_Agregar_Click");
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    if (MessageBox.Show("¿Desea eliminar este registro?", "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (new Recursos.CursorWait())
                        {
                            DataRow myRow = (this.ObtenerFilaSeleccionada()[0].DataBoundItem as DataRowView).Row;
                            infoCompra.compraDetalle.datos.Rows.Remove(myRow);
                            this.GridViewCompraDetalle.AutoGenerateColumns = false;
                            this.GridViewCompraDetalle.DataSource = infoCompra.compraDetalle.datos;
                            if (GridViewCompraDetalle.Rows.Count > 0)
                                GridViewCompraDetalle.Rows[0].Selected = true;
                            CalcularTotal();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCompras ~ btn_Eliminar_Click");
            }
        }

        private void frmCompras_Load(object sender, EventArgs e)
        {
            try
            {
                this.backgroundWorker1.RunWorkerAsync();
                espere.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCompras ~ frmCompras_Load()");
            }
        }

        private void GridViewProductosDetalle_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //Validamos si no es una fila nueva
            if (!GridViewProductosDetalle.Rows[e.RowIndex].IsNewRow)
            {
                //Sólo controlamos el dato de la columna 3
                if (e.ColumnIndex == 3)
                {
                    if (!decimal.TryParse(e.FormattedValue.ToString(), out decimal valueDecimal))
                    {
                        MessageBox.Show("El valor de cantidad debe ser un número.", "Error de validación",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.GridViewProductosDetalle.Rows[e.RowIndex].ErrorText = "La cantidad debe ser un un número.";
                        e.Cancel = true;
                    }
                }
                else if (e.ColumnIndex == 5)
                {
                    if (!decimal.TryParse(e.FormattedValue.ToString(), out decimal valueDecimal))
                    {
                        MessageBox.Show("El valor de precio unitario debe ser un número.", "Error de validación",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.GridViewProductosDetalle.Rows[e.RowIndex].ErrorText = "El precio unitario debe ser un un número.";
                        e.Cancel = true;
                    }
                }
            }
        }

        private void GridViewProductosDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            GridViewProductosDetalle.Rows[e.RowIndex].ErrorText = String.Empty;
        }
    }
}
