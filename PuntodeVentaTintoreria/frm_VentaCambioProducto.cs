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
using System.Drawing.Printing;

namespace PuntodeVentaTintoreria
{
    public partial class frm_VentaCambioProducto : Form
    {
        Validaciones Val;
        public Cambio cambio { get; set; }
        VentaProductos infoVentaProductos;

      

        public frm_VentaCambioProducto(VentaProductos ventaProductos)
        {
            try
            {
                InitializeComponent();
                infoVentaProductos = ventaProductos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCambios_Bunifu ~ frmCambios_Bunifu()");
            }
        }


        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        /*************************************************************************************************************************************************/

       

        private void frm_VentaCambioProduct_Load(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.LLenarDatos();
                    this.CargarCombos();
                    this.CargarComboPrecio();
                    if (infoVentaProductos.IDTipoProducto == 1)
                    {
                        cmb_producto_nuevo.SelectedValue = infoVentaProductos.IDProducto;
                        cmb_producto_nuevo.Enabled = false;
                    }
                    this.ActiveControl = this.cmb_producto_nuevo;
                    this.cmb_producto_nuevo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCambios_Bunifu ~ frmCambios_Bunifu_Load");
            }
        }
        #region MetodosGeneral
        private void LLenarDatos()
        {
            try
            {
                this.txt_producto.Text = infoVentaProductos.NombreProducto;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ObtenerDatos()
        {
            try
            {
                cambio = new Cambio();
                cambio.id_productoCambio = infoVentaProductos.IDProducto;
                cambio.id_tallaRopaCambio = infoVentaProductos.IDTallaRopa;
                cambio.id_colorRopaCambio = infoVentaProductos.IDColorRopa;
                DataRowView vrowProducto = (DataRowView)cmb_producto_nuevo.SelectedItem;
                DataRow rowProducto = vrowProducto.Row;
                cambio.nombreProducto = rowProducto["nombreProducto"].ToString();
                cambio.id_productoNuevo = rowProducto["id_producto"].ToString();
                cambio.id_tallaRopaNuevo = Convert.ToInt32(rowProducto["id_tallaRopa"].ToString());
                cambio.id_colorRopaNuevo = Convert.ToInt32(rowProducto["id_colorRopa"].ToString());
                DataRowView vrowPrecio = (DataRowView)cmb_precio.SelectedItem;
                DataRow rowPrecio = vrowPrecio.Row;
                cambio.precio = float.Parse(rowPrecio["precio"].ToString(), CultureInfo.InvariantCulture);
                cambio.iva = float.Parse(rowPrecio["iva"].ToString(), CultureInfo.InvariantCulture);
                cambio.id_codigoEan = rowPrecio["id_codigoEan"].ToString();
                cambio.id_tipoProducto = infoVentaProductos.IDTipoProducto;
                cambio.descripcion = rowPrecio["descripcion"].ToString();
                cambio.id_motivo = Convert.ToInt32(cmb_cambio.SelectedValue.ToString());
                cambio.observaciones = this.txt_observaciones.Text;
                cambio.cantidad = Convert.ToInt32(this.txt_cantidad.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void CargarCombos()
        {
            Motivo motivo = new Motivo();
            MotivoNegocio motivoNegocio = new MotivoNegocio();
            motivo.conexion = Comun.conexion;
            motivoNegocio.ObtenerComboMotivo(motivo);
            this.cmb_cambio.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cmb_cambio.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cmb_cambio.DataSource = motivo.datos;
            this.cmb_cambio.DisplayMember = "motivo";
            this.cmb_cambio.ValueMember = "id_motivo";

            Producto producto = new Producto();
            ProductoNegocio productoNegocio = new ProductoNegocio();
            producto.conexion = Comun.conexion;
            producto.id_producto = infoVentaProductos.IDProducto;
            productoNegocio.ObtenerComboCambioProducto(producto);
            this.cmb_producto_nuevo.SelectedValueChanged -= new System.EventHandler(this.cmb_producto_nuevo_SelectedValueChanged);
            this.cmb_producto_nuevo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cmb_producto_nuevo.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cmb_producto_nuevo.DataSource = producto.datos;
            this.cmb_producto_nuevo.DisplayMember = "nombreProducto";
            this.cmb_producto_nuevo.ValueMember = "id_producto";
            this.cmb_producto_nuevo.SelectedValueChanged += new System.EventHandler(this.cmb_producto_nuevo_SelectedValueChanged);
        }
        private bool ValidarCampos()
        {
            try
            {
                if (Convert.ToInt32(this.cmb_producto_nuevo.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_producto_nuevo.SelectedIndex) == -1)
                {
                    this.cmb_producto_nuevo.Focus();
                    MessageBox.Show(this, "Seleccione el producto a cambiar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToInt32(this.cmb_cambio.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_cambio.SelectedIndex) == -1)
                {
                    this.cmb_cambio.Focus();
                    MessageBox.Show(this, "Seleccione el motivo del cambio", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txt_cantidad.Text.Length == 0)
                {
                    this.txt_cantidad.Focus();
                    MessageBox.Show(this, "Escriba la cantidad de producto a cambiar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToInt32(this.txt_cantidad.Text) == 0)
                {
                    this.txt_cantidad.Focus();
                    MessageBox.Show(this, "Escriba una cantidad validad", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToInt32(this.cmb_precio.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_precio.SelectedIndex) == -1)
                {
                    this.cmb_precio.Focus();
                    MessageBox.Show(this, "Seleccione el precio del producto", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txt_observaciones.Text.Length == 0)
                {
                    this.txt_observaciones.Focus();
                    MessageBox.Show(this, "Escriba la observacion del producto a cambiar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        private void CargarComboPrecio()
        {
            Cambio cambio = new Cambio();
            CambioNegocio cambioNegocio = new CambioNegocio();
            DataRowView vrowProducto = (DataRowView)cmb_producto_nuevo.SelectedItem;
            DataRow rowProducto = vrowProducto.Row;
            cambio.id_productoNuevo = rowProducto["id_producto"].ToString();
            cambio.id_tallaRopaNuevo = Convert.ToInt32(rowProducto["id_tallaRopa"].ToString());
            cambio.id_colorRopaNuevo = Convert.ToInt32(rowProducto["id_colorRopa"].ToString());
            cambio.id_sucursal = infoVentaProductos.IDSucursal;
            cambio.conexion = Comun.conexion;
            cambioNegocio.ObtenerComboCambioPrecio(cambio);
            this.cmb_precio.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.cmb_precio.AutoCompleteSource = AutoCompleteSource.ListItems;
            this.cmb_precio.DataSource = cambio.datos;
            this.cmb_precio.DisplayMember = "precio";
            this.cmb_precio.ValueMember = "id";
        }
        private void CargarExistencia()
        {
            ProductoDetalle productoDetalle = new ProductoDetalle();
            ProductoNegocio productoNegocio = new ProductoNegocio();
            DataRowView vrowProducto = (DataRowView)cmb_producto_nuevo.SelectedItem;
            DataRow rowProducto = vrowProducto.Row;
            productoDetalle.id_producto = rowProducto["id_producto"].ToString();
            productoDetalle.id_tallaRopa = Convert.ToInt32(rowProducto["id_tallaRopa"].ToString());
            productoDetalle.id_colorRopa = Convert.ToInt32(rowProducto["id_colorRopa"].ToString());
            productoDetalle.id_sucursal = Comun.id_sucursal;
            productoDetalle.conexion = Comun.conexion;
            productoNegocio.ChecarExistencia(productoDetalle);
            this.txt_existencia.Text = productoDetalle.existencia.ToString();
        }
        #endregion
        #region Validaciones
        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloNumerico(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCambios_Bunifu ~ txt_cantidad_KeyPress");
            }
        }

        private void txt_cantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_observaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloTexto(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCambios_Bunifu ~ txt_observaciones_KeyPress");
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
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txt_cantidad_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion
        #region Eventos
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCambios_Bunifu ~ btnCerrar_Click");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    if (Convert.ToInt32(this.txt_cantidad.Text) <= infoVentaProductos.CantidadVenta)
                    {
                        if (Convert.ToInt32(this.txt_cantidad.Text) <= Convert.ToInt32(this.txt_existencia.Text) && Convert.ToInt32(this.txt_existencia.Text) > 0)
                        {
                            this.ObtenerDatos();
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                            MessageBox.Show(this, "La cantidad deve ser menor a la existencia", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show(this, "La cantidad deve ser menor a la cantidad de venta", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCambios_Bunifu ~ btnGuardar_Click");
            }
        }

        private void cmb_producto_nuevo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.CargarComboPrecio();
                this.CargarExistencia();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCambios_Bunifu ~ cmb_producto_nuevo_SelectedValueChanged");
            }
        }
        #endregion

    }
}
