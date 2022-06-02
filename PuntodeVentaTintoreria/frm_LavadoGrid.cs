using System;
using TintoreriaGlobal;
using TintoreriaNegocio;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PuntodeVentaTintoreria.ClaseAux;

namespace PuntodeVentaTintoreria
{
    public partial class frm_LavadoGrid : Form
    {
        private DataTable dt2;
        private DetalleLavado infDetalle;
        private int tipoOpcion;
        public frm_LavadoGrid(DetalleLavado _dato, int tipo)
        {
            InitializeComponent();
            infDetalle = _dato;
            tipoOpcion = tipo;
        }

        private void frm_LavadoGrid_Load(object sender, EventArgs e)
        {
            try
            {
                this.LLenarComboProducto();
                dt2 = new DataTable();
                dt2.Columns.Add("nombreProductoFinal", typeof(string));
                dt2.Columns.Add("cantidadFinal", typeof(decimal));
                dt2.Columns.Add("txtUnidadMedidaFinal", typeof(string));
                dt2.Columns.Add("id_productoFinal", typeof(string));
                dt2.Columns.Add("id_unidadMedidaFinal", typeof(int));
                dt2.Columns.Add("id_lavadoDetalle", typeof(string));
                //dt2.Columns.Add("Subtotal", typeof(decimal));
                this.GridViewCompraDetalle.DataSource = dt2;
                this.CargarDatosCompraDetalle();
                this.opciones();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Metodos

        private void opciones()
        {
            switch (tipoOpcion)
            {
                case 1:
                    
                    break;
                case 2:                    
                    this.btnEntregar.Text = "Modificar";
                    this.GridViewCompraDetalle.ReadOnly = false;
                    break;
                case 3:               
                    this.btnEntregar.Text = "Finalizar";
                    this.btn_Agregar.Enabled = false;
                    this.btn_Eliminar.Enabled = false;                                 
                    this.cmb_producto.Enabled = false;
                    this.label10.Enabled = false;
                    this.label11.Enabled = false;
                    this.lblTitulo.Text = "Finalizar Detalle Lavado";                                
                    break;         
            }
        }

        private void FinalizarLavado()
        {
            try
            {
                int Verificador = -1;
                CompraNegocio compra_negocio = new CompraNegocio();
                string id_user = Comun.id_u.Trim();
                string sucursal = Comun.id_sucursal.Trim();
                DataTable datosTabla = this.ObtenerDatos();
                int opcion = 3;
                string id_lavado = infDetalle.id_lavado;
                compra_negocio.GuardarDetalleLavado(ref Verificador, id_user, datosTabla, sucursal, opcion,id_lavado);


                switch (Verificador)
                {
                    case 0:
                        MessageBox.Show("Los datos se finalizaron correctamente", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        break;
                    case -2:
                        MessageBox.Show("Producto insifuciente en bodega",Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    default:
                        MessageBox.Show("Este registro no se puedo finalizar",Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarDetalleLavado()
        {
            try
            {
                int Verificador = -1;
                CompraNegocio compra_negocio = new CompraNegocio();
                string id_user = Comun.id_u.Trim();
                string sucursal = Comun.id_sucursal.Trim();
                DataTable datosTabla = this.ObtenerDatos();
                string id_lavado = infDetalle.id_lavado;
                int opcion = 1;

                compra_negocio.GuardarDetalleLavado(ref Verificador, id_user, datosTabla, sucursal, opcion,id_lavado);

                this.mensaje(ref Verificador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ModificarLavado()
        {
            try
            {
                int Verificador = -1;
                CompraNegocio compra_negocio = new CompraNegocio();
                string id_user = Comun.id_u.Trim();
                string sucursal = Comun.id_sucursal.Trim();
                DataTable datosTabla = this.ObtenerDatos();               
                int opcion = 2;
                string id_lavado = infDetalle.id_lavado;
                compra_negocio.GuardarDetalleLavado(ref Verificador, id_user, datosTabla, sucursal, opcion,id_lavado);

                if (Verificador == 0)
                {
                    MessageBox.Show("Los datos se modificaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Este registro no se puedo modificar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mensaje(ref int verificador)
        {
            try
            {
                if (verificador == 0)
                {
                    MessageBox.Show(this, "Los datos se guardaron correctamente", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(this, "Error al intentar Guardar los datos", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable ObtenerDatos()
        {
            try
            {
                dt2 = (DataTable)this.GridViewCompraDetalle.DataSource;

                return dt2;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LLenarComboProducto()
        {
            try
            {
                ProductoNegocio _pNegocio = new ProductoNegocio();

                this.cmb_producto.SelectedValueChanged -= new System.EventHandler(this.cmb_producto_SelectedValueChanged);
                this.cmb_producto.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_producto.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_producto.DataSource = _pNegocio.GetComboProductosLavado();
                this.cmb_producto.DisplayMember = "nombreProducto";
                this.cmb_producto.ValueMember = "id_producto";
                this.cmb_producto.SelectedValueChanged += new System.EventHandler(this.cmb_producto_SelectedValueChanged);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    if (Convert.ToDecimal(cantidad.Value.ToString()) > 0)
                    {
                        string id_producto = this.cmb_producto.SelectedValue.ToString().Trim();
                        bool repetido = false;

                        DataTable dataTable = new DataTable();
                        DataRow[] foundRows;
                        dataTable = GridViewCompraDetalle.DataSource as DataTable;
                        if (dataTable != null)
                        {
                            foundRows = dataTable.Select("id_productoFinal = '" + id_producto + "'");
                            repetido = foundRows.Length > 0 ? true : false;
                        }



                        if (!repetido)
                        {
                            DataGridViewTextBoxCell nombre_producto = (DataGridViewTextBoxCell)row.Cells[1];
                            DataGridViewComboBoxCell itemUnidadMedida = (DataGridViewComboBoxCell)row.Cells[4];
                            DataGridViewTextBoxCell nombreUnidadMedida_producto = new DataGridViewTextBoxCell() { Value = itemUnidadMedida.FormattedValue };


                            //Agregar las Filas al DataRow y asignar el valor correspondiente. 
                            DataTable dt2 = GridViewCompraDetalle.DataSource as DataTable;

                            DataRow datarow;
                            datarow = dt2.NewRow(); //Con esto le indica que es una nueva fila.

                            datarow["nombreProductoFinal"] = nombre_producto.Value.ToString();
                            datarow["cantidadFinal"] = cantidad.Value.ToString();
                            datarow["txtUnidadMedidaFinal"] = itemUnidadMedida.FormattedValue.ToString();
                            datarow["id_productoFinal"] = id_producto;
                            datarow["id_unidadMedidaFinal"] = (int)itemUnidadMedida.Value;
                            //decimal auxCantidad = Convert.ToDecimal(cantidad.Value);
                            //decimal auxPrecioUnitario = Convert.ToDecimal(precioUnitario.Value);
                            //decimal auxSubtotal = auxCantidad * auxPrecioUnitario;
                            //datarow["Subtotal"] = auxSubtotal;
                            //datarow["costoFinal"] = auxPrecioUnitario;
                            dt2.Rows.Add(datarow);
                        }
                        else
                        {
                            MessageBox.Show(this, "Este producto ya fue agregado", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                        MessageBox.Show(this, "La cantidad y el precio unitairo deben ser mayores a 0.", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    contador++;
            }
            if (GridViewProductosDetalle.Rows.Count == contador)
                MessageBox.Show(this, "Seleccione un producto a la compra", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private bool ValidarCampos()
        {
            try
            {
                if (this.GridViewCompraDetalle.Rows.Count == 0)
                {
                    this.cmb_producto.Focus();
                    MessageBox.Show(this, "Seleccione un producto", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void CargarDatosCompraDetalle()
        {
            try
            {           
                string id_lavado = infDetalle.id_lavado;
                ProductoNegocio _pNegocio = new ProductoNegocio();
                _pNegocio.CargarDatosCompraDetalle(id_lavado);
                dt2 = _pNegocio.CargarDatosCompraDetalle(id_lavado);
                GridViewCompraDetalle.AutoGenerateColumns = false;
                GridViewCompraDetalle.DataSource = dt2;                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Eventos
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmb_producto_SelectedValueChanged(object sender, EventArgs e)
        {
            try
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
                        compra.id_sucursal = Comun.id_sucursal;
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
                    LogError.AddExcFileTxt(ex, "frmLavadoGrid ~ btnCancelar_Click");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            using (new Recursos.CursorWait())
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
                            ProductoNegocio _pNegocio = new ProductoNegocio();
                            DataRow myRow = (this.ObtenerFilaSeleccionada()[0].DataBoundItem as DataRowView).Row;
                            dt2.Rows.Remove(myRow);
                            this.GridViewCompraDetalle.AutoGenerateColumns = false;
                            this.GridViewCompraDetalle.DataSource = dt2;
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
                LogError.AddExcFileTxt(ex, "frmLavadoGrid ~ btn_Eliminar_Click");
            }
        }

        private void btnEntregar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (this.ValidarCampos())
                    {
                        switch (tipoOpcion)
                        {
                            case 1:
                            this.GuardarDetalleLavado();
                                break;
                            case 2:
                                this.ModificarLavado();
                                break;
                            case 3:
                                this.FinalizarLavado();
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmLavadoGrid ~ btnEntregar_Click");
            }
        }      
        #endregion
    }
}
