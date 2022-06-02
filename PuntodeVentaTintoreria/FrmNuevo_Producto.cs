namespace PuntodeVentaTintoreria
{
    using PuntodeVentaTintoreria.ClaseAux;
    using System;
    using System.ComponentModel;
    using System.Configuration;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Globalization;
    using System.IO;
    using System.Windows.Forms;
    using TintoreriaGlobal;
    using TintoreriaNegocio;

    public partial class FrmNuevo_Producto : Form
    {
        private Validaciones Val;
        private Producto infoProducto;
        private bool ModificarImagen;
        private frm_Esperar espere = new frm_Esperar();
        public FrmNuevo_Producto(Producto producto)
        {
            InitializeComponent();
            infoProducto = producto;
            Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
        }
        #region Metodos Generales
        private void Inicializar()
        {
            try
            {
                ProductoNegocio producto_negocio = new ProductoNegocio();
                ProductoDetalle producto_detalle = new ProductoDetalle();
                producto_detalle.conexion = Comun.conexion;
                producto_detalle.id_producto = infoProducto.id_producto;
                //Obtengo la imagen, ya que en el grid se quita para que sea más rápida la consulta
                infoProducto.imagen = producto_negocio.ObtenerImagen(producto_detalle);
                producto_negocio.ObtenerDetalleProductoGeneral(producto_detalle);
                infoProducto.productoDetalle = producto_detalle;
                this.LlenarDatos();
                if (!string.IsNullOrEmpty(infoProducto.id_producto))
                {
                    this.lblTitulo.Text = "Editar producto";
                    this.cmb_unidadmedida.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void GuardarProducto()
        {
            try
            {
                Val = new Validaciones();
                int Verificador = -1;
                ProductoNegocio productoNegocio = new ProductoNegocio();
                Producto producto = new Producto();
                producto.productoDetalle = new ProductoDetalle();
                producto.conexion = Comun.conexion;
                producto.id_u = Comun.id_u;
                this.ObtenerDatos(producto);
                if (infoProducto.id_producto != null)
                {
                    producto.opcion = 2;
                    producto.id_producto = infoProducto.id_producto;
                    productoNegocio.AbcProductoGeneral2(producto, ref Verificador);
                    infoProducto.id_producto = producto.id_producto;
                    if (ModificarImagen)
                    {
                        try
                        {
                            ImageFormat Formato = HelperImgCID.GetImageFormat(LblImage.Text);
                            Image image = new Bitmap(this.ImgPrincipal.Image);
                            Bitmap auxBitmap = (Bitmap)image;
                            producto.imagen = auxBitmap.ToBase64String(Formato);
                            producto.opcion = 4;
                            productoNegocio.AbcProductoGeneral2(producto, ref Verificador);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                else
                {
                    producto.opcion = 1;
                    try
                    {
                        if (ModificarImagen)
                        {
                            ImageFormat Formato = HelperImgCID.GetImageFormat(LblImage.Text);
                            Image image = new Bitmap(this.ImgPrincipal.Image);
                            Bitmap auxBitmap = (Bitmap)image;
                            producto.imagen = auxBitmap.ToBase64String(Formato);
                            productoNegocio.AbcProductoGeneral2(producto, ref Verificador);

                            if (Verificador == 0)
                            {
                                infoProducto.id_producto = producto.id_producto;
                            }
                            else
                                MessageBox.Show("Ocurrió un problema, no se guardo la información intente más tarde", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("Debe seleccionar una imagen", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception EX)
                    {
                        MessageBox.Show("Permisos", "Error" + EX, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                this.VerificarMensajeAccion(Verificador);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ObtenerDatos(Producto producto)
        {
            try
            {
                producto.nombreProducto = this.txt_nombre.Text;

                int stockMinimo = 0;
                int.TryParse(this.txt_stockminimo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out stockMinimo);
                producto.inventarioOptimo = stockMinimo;
                producto.imagen = "";
                producto.id_proveedor = this.cmb_proveedor.SelectedValue.ToString();
                producto.id_familia = Convert.ToInt32(this.cmb_familia.SelectedValue);
                producto.id_unidadMedida = Convert.ToInt32(this.cmb_unidadmedida.SelectedValue);
                producto.observaciones = this.txt_observaciones.Text;
                producto.id_tipoProducto = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void LlenarDatos()
        {
            try
            {
                this.txt_nombre.Text = infoProducto.nombreProducto;
                this.txt_stockminimo.Text = infoProducto.inventarioOptimo.ToString();
                try
                {
                    Bitmap bmpFromString = infoProducto.imagen.Base64StringToBitmap();
                    this.ImgPrincipal.Image = bmpFromString;
                }
                catch (Exception ex)
                {
                    this.ImgPrincipal.Image = PuntodeVentaTintoreria.Properties.Resources.icono_productos;
                }
                this.cmb_proveedor.SelectedValue = infoProducto.id_proveedor.ToString();
                this.cmb_proveedor.Enabled = false;
                this.cmb_familia.SelectedValue = infoProducto.id_familia.ToString();
                this.cmb_unidadmedida.SelectedValue = infoProducto.id_unidadMedida.ToString();
                this.txt_observaciones.Text = infoProducto.observaciones;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidarCampos()
        {
            try
            {
                Validaciones Val = new Validaciones();

                string mensajeError = string.Empty;

                if (string.IsNullOrEmpty(this.txt_nombre.Text))
                {
                    mensajeError += "Escriba el nombre del producto." + Environment.NewLine;
                    this.txt_nombre.Focus();
                }
                if (string.IsNullOrEmpty(this.txt_stockminimo.Text))
                {
                    mensajeError += "Escriba el stock minimo del producto." + Environment.NewLine;
                    this.txt_stockminimo.Focus();
                }
                if (Convert.ToInt32(this.cmb_proveedor.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_proveedor.SelectedIndex) == -1)
                {
                    mensajeError += "Seleccione el proveedor del producto." + Environment.NewLine;
                    this.cmb_proveedor.Focus();
                }
                if (Convert.ToInt32(this.cmb_familia.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_familia.SelectedIndex) == -1)
                {
                    mensajeError += "Seleccione la familia del producto." + Environment.NewLine;
                    this.cmb_familia.Focus();
                }
                if (Convert.ToInt32(this.cmb_unidadmedida.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_unidadmedida.SelectedIndex) == -1)
                {
                    mensajeError += "Seleccione la unidad de medida del producto." + Environment.NewLine;
                    this.cmb_unidadmedida.Focus();
                }
                if (string.IsNullOrEmpty(mensajeError))
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(this, mensajeError, Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        private void VerificarMensajeAccion(int Verificador)
        {
            try
            {
                if (Verificador == 0)
                {
                    UtilFtp.UploadFTP(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Productos\" + infoProducto.id_producto + ".PNG"), ConfigurationManager.AppSettings.Get("ServerFtpTxt") + @"/Productos/", ConfigurationManager.AppSettings.Get("UsuarioFtpTxt"), ConfigurationManager.AppSettings.Get("ContraseñaFtpTxt"));
                    MessageBox.Show(this, "Los datos se guardaron correctamente", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void CargarCombo()
        {
            try
            {
                ProveedorNegocio proveedor_negocio = new ProveedorNegocio();
                Proveedor proveedor = new Proveedor();
                proveedor.conexion = Comun.conexion;
                proveedor_negocio.ObtenerComboProveedor(proveedor);
                this.cmb_proveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_proveedor.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_proveedor.DataSource = proveedor.datos;
                this.cmb_proveedor.DisplayMember = "proveedor";
                this.cmb_proveedor.ValueMember = "id_proveedor";

                FamiliaNegocio familia_negocio = new FamiliaNegocio();
                Familia familia = new Familia();
                familia.conexion = Comun.conexion;
                familia_negocio.ObtenerComboFamilia(familia);
                this.cmb_familia.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_familia.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_familia.DataSource = familia.datos;
                this.cmb_familia.DisplayMember = "familia";
                this.cmb_familia.ValueMember = "id_familia";

                UnidadMedidaNegocio unidadmedida_negocio = new UnidadMedidaNegocio();
                UnidadMedida unidadmedida = new UnidadMedida();
                unidadmedida.conexion = Comun.conexion;
                unidadmedida_negocio.ObtenerComboUnidadMedida(unidadmedida);
                this.cmb_unidadmedida.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_unidadmedida.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_unidadmedida.DataSource = unidadmedida.datos;
                this.cmb_unidadmedida.DisplayMember = "unidadMedida";
                this.cmb_unidadmedida.ValueMember = "id_unidadMedida";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion
        #region Validaciones
        private void txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.TextoNumerosPuntoGuionTilde(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmNuevo_Productos ~ txt_nombre_KeyPress");
            }
        }

        private void txt_nombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_nombre_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txt_precio_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_precio_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txt_precioMayoreo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_precioMayoreo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txt_cantidadMayoreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloNumerico(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmNuevo_Producto ~ txt_cantidadMayoreo_KeyPress");
            }
        }

        private void txt_cantidadMayoreo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_cantidadMayoreo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txt_stockminimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloNumerico(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmNuevo_Producto ~ txt_stockminimo_KeyPress");
            }
        }

        private void txt_stockminimo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_stockminimo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txt_codigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloNumerico(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmNuevo_Producto ~ txt_codigo_KeyPress");
            }
        }

        private void txt_codigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_codigo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txt_observaciones_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.TextoNumerosPuntoGuionTilde(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmNuevo_Producto~ txt_codigo_KeyPress");
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

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                DataTable Aux = (DataTable)e.Result;
                this.cmb_proveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_proveedor.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_proveedor.DataSource = Aux;
                this.cmb_proveedor.DisplayMember = "proveedor";
                this.cmb_proveedor.ValueMember = "id_proveedor";
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
                FamiliaNegocio familia_negocio = new FamiliaNegocio();
                Familia familia = new Familia();
                familia.conexion = Comun.conexion;
                familia_negocio.ObtenerComboFamilia(familia);
                e.Result = familia.datos;
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
                this.cmb_familia.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_familia.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_familia.DataSource = Aux;
                this.cmb_familia.DisplayMember = "familia";
                this.cmb_familia.ValueMember = "id_familia";
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
                UnidadMedidaNegocio unidadmedida_negocio = new UnidadMedidaNegocio();
                UnidadMedida unidadmedida = new UnidadMedida();
                unidadmedida.conexion = Comun.conexion;
                unidadmedida_negocio.ObtenerComboUnidadMedida(unidadmedida);
                e.Result = unidadmedida.datos;
            }
            catch (Exception ex)
            {

            }
        }

        private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                DataTable Aux = (DataTable)e.Result;
                this.cmb_unidadmedida.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_unidadmedida.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_unidadmedida.DataSource = Aux;
                this.cmb_unidadmedida.DisplayMember = "unidadMedida";
                this.cmb_unidadmedida.ValueMember = "id_unidadMedida";
                if (infoProducto.id_producto != null)
                    this.Inicializar();

                espere.Close();

            }
            catch (Exception ex)
            {


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

        private void FrmNuevo_Producto_Load(object sender, EventArgs e)
        {
            try
            {
                this.backgroundWorker1.RunWorkerAsync();
                espere.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmNuevo_Producto ~ frmProductos_Bunifu_Load");
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (this.ValidarCampos())
                    {
                        this.GuardarProducto();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmNuevo_Producto ~ btnGuardar_Click");
            }
        }

        private void btn_imagen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog BuscarImagen = new OpenFileDialog();
                BuscarImagen.Filter = "Image Files|*.png;*.jpg;*.bmp;*.gif";
                BuscarImagen.FileName = "";
                BuscarImagen.Title = "Seleccione una imagen";
                BuscarImagen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures).ToString();
                if (BuscarImagen.ShowDialog() == DialogResult.OK)
                {
                    this.LblImage.Text = BuscarImagen.FileName;
                    ModificarImagen = true;
                    this.ImgPrincipal.ImageLocation = BuscarImagen.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmNuevo_Producto ~ btn_imagen_Click");
            }

        }


    }
}
