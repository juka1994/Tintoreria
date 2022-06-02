using PuntodeVentaTintoreria.ClaseAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
    public partial class FrmProductosRopa : Form
    {
        private Validaciones Val;
        private Producto infoProducto;
        private bool ModificarImagen;
        private frm_Esperar espere = new frm_Esperar();
        public FrmProductosRopa(Producto producto)
        {
            InitializeComponent();
            Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
            infoProducto = producto;
        }
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
                ColorRopaNegocio color_negocio = new ColorRopaNegocio();
                ColorRopa color = new ColorRopa();
                color.conexion = Comun.conexion;
                color_negocio.ObtenerComboColorRopa(color);
                e.Result = color.datos;
            }
            catch (Exception ex)
            {


            }
        }

        private void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                DataTable Aux = (DataTable)e.Result;
                this.cmb_color.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_color.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_color.DataSource = Aux;
                this.cmb_color.DisplayMember = "colorRopa";
                this.cmb_color.ValueMember = "id_colorRopa";
                this.backgroundWorker5.RunWorkerAsync();
            }
            catch (Exception ex)
            {


            }
        }

        private void backgroundWorker5_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                TallaRopaNegocio talla_negocio = new TallaRopaNegocio();
                TallaRopa talla = new TallaRopa();
                talla.conexion = Comun.conexion;
                talla_negocio.ObtenerComboTallaRopa(talla);
                e.Result = talla.datos;
            }
            catch (Exception ex)
            {


            }
        }

        private void backgroundWorker5_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                DataTable Aux = (DataTable)e.Result;
                this.cmb_talla.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_talla.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_talla.DataSource = Aux;
                this.cmb_talla.DisplayMember = "tallaRopa";
                this.cmb_talla.ValueMember = "id_tallaRopa";
                this.backgroundWorker6.RunWorkerAsync();
            }
            catch (Exception ex)
            {


            }
        }

        private void backgroundWorker6_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                MarcaNegocio marca_negocio = new MarcaNegocio();
                Marca marca = new Marca();
                marca.conexion = Comun.conexion;
                marca_negocio.ObtenerComboMarca(marca);
                e.Result = marca.datos;
            }
            catch (Exception ex)
            {


            }
        }

        private void backgroundWorker6_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                DataTable Aux = (DataTable)e.Result;
                this.cmb_marca.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_marca.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_marca.DataSource = Aux;
                this.cmb_marca.DisplayMember = "marca";
                this.cmb_marca.ValueMember = "id_marca";
                this.backgroundWorker7.RunWorkerAsync();
            }
            catch (Exception ex)
            {

            }
        }

        private void backgroundWorker7_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                MaterialNegocio material_negocio = new MaterialNegocio();
                Material material = new Material();
                material.conexion = Comun.conexion;
                material_negocio.ObtenerComboMaterial(material);
                e.Result = material.datos;
            }
            catch (Exception ex)
            {


            }
        }

        private void backgroundWorker7_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                DataTable Aux = (DataTable)e.Result;
                this.cmb_material.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_material.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_material.DataSource = Aux;
                this.cmb_material.DisplayMember = "material";
                this.cmb_material.ValueMember = "id_material";
                this.Inicializar();
                this.txt_nombre.Focus();
                this.ActiveControl = this.txt_nombre;
                espere.Close();
            }
            catch (Exception ex)
            {


            }
        }
        #endregion

        #region Metodos Generales
        private void Inicializar()
        {
            try
            {
                ProductoNegocio producto_negocio = new ProductoNegocio();
                ProductoDetalle producto_detalle = new ProductoDetalle();
                producto_detalle.conexion = Comun.conexion;
                producto_detalle.datos = new DataTable();
                producto_detalle.datos.Columns.Add("codigoBarra", typeof(string));
                producto_detalle.datos.Columns.Add("colorRopa", typeof(string));
                producto_detalle.datos.Columns.Add("tallaRopa", typeof(string));
                producto_detalle.datos.Columns.Add("costoUltimo", typeof(float));
                producto_detalle.datos.Columns.Add("precio", typeof(float));
                producto_detalle.datos.Columns.Add("preciomayoreo", typeof(float));
                producto_detalle.datos.Columns.Add("id_colorRopa", typeof(int));
                producto_detalle.datos.Columns.Add("id_tallaRopa", typeof(int));
                producto_detalle.datos.Columns.Add("interno", typeof(bool));
                if (infoProducto.id_producto != null)
                {
                    producto_detalle.id_producto = infoProducto.id_producto;
                    producto_negocio.ObtenerDetalleProductoRopa(producto_detalle);
                    infoProducto.imagen = producto_negocio.ObtenerImagen(producto_detalle);
                    this.LlenarDatos();
                }
                infoProducto.productoDetalle = producto_detalle;
                this.dataGridViewTextBox.AutoGenerateColumns = false;
                this.dataGridViewTextBox.DataSource = infoProducto.productoDetalle.datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    //productoNegocio.AbcProductoRopa(producto, ref Verificador);
                    productoNegocio.AbcProductoRopa2(producto, ref Verificador);
                    infoProducto.id_producto = producto.id_producto;
                    if (ModificarImagen)
                    {
                        try
                        {
                            ImageFormat Formato = ImageFormat.Png;
                            producto.extension = ".png";

                            Image imagen = Recursos.ResizeImage(this.ImgPrincipal.Image, 150, 150, Formato);
                            imagen.Save(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Productos\" + producto.id_producto + producto.extension));

                            StreamReader streamReader = new StreamReader(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Productos\" + producto.id_producto + producto.extension));
                            Bitmap bmp = new Bitmap(streamReader.BaseStream);
                            streamReader.Close();
                            producto.imagen = bmp.ToBase64String(Formato);

                            producto.opcion = 4;
                            //productoNegocio.AbcProductoRopa(producto, ref Verificador);
                            productoNegocio.AbcProductoRopa2(producto, ref Verificador);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                }
                else
                {
                    producto.opcion = 1;
                    //productoNegocio.AbcProductoRopa(producto, ref Verificador);

                    try
                    {
                        ImageFormat Formato = ImageFormat.Png;
                        producto.extension = ".png";

                        Image imagen = Recursos.ResizeImage(this.ImgPrincipal.Image, 150, 150, Formato);
                        imagen.Save(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Productos\" + producto.id_producto + producto.extension));

                        StreamReader streamReader = new StreamReader(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Productos\" + producto.id_producto + producto.extension));
                        Bitmap bmp = new Bitmap(streamReader.BaseStream);
                        streamReader.Close();
                        producto.imagen = bmp.ToBase64String(Formato);

                        //producto.opcion = 4;
                        // Esto ya estaba -- productoNegocio.AbcProductoRopa(producto, ref Verificador);
                        //productoNegocio.AbcProductoRopa2(producto, ref Verificador);


                        productoNegocio.AbcProductoRopa2(producto, ref Verificador);
                        infoProducto.id_producto = producto.id_producto;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                this.VerifcarMensajeAccion(Verificador);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ObtenerDatos(Producto producto)
        {
            try
            {
                producto.nombreProducto = this.txt_nombre.Text;
                producto.fechaIngreso = this.dtp_fechaIngreso.Value;
                int cantidadMayoreo = 0;
                int.TryParse(this.txt_cantidadMayoreo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out cantidadMayoreo);
                producto.cantidadMayoreo = cantidadMayoreo;
                int stockMinimo = 0;
                int.TryParse(this.txt_stockminimo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out stockMinimo);
                producto.inventarioOptimo = stockMinimo;
                producto.imagen = "";
                producto.id_proveedor = this.cmb_proveedor.SelectedValue.ToString();
                producto.id_familia = Convert.ToInt32(this.cmb_familia.SelectedValue);
                producto.id_unidadMedida = Convert.ToInt32(this.cmb_unidadmedida.SelectedValue);
                producto.id_marca = Convert.ToInt32(this.cmb_marca.SelectedValue);
                producto.id_material = Convert.ToInt32(this.cmb_material.SelectedValue);
                producto.ventaDirecta = this.checkBoxVentaDirecta.Checked;
                producto.aplicaInventario = this.checkBoxInventario.Checked;
                producto.observaciones = this.txt_observaciones.Text;
                producto.EsHombre = this.CheckEsHombre.Checked;
                producto.EsMujer = this.CheckEsMujer.Checked;
                producto.id_tipoProducto = 2;
                producto.productoDetalle = new ProductoDetalle();
                producto.productoDetalle.datos = (DataTable)this.dataGridViewTextBox.DataSource;
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
                this.txt_nombre.Text = infoProducto.nombreProducto;
                this.dtp_fechaIngreso.Value = infoProducto.fechaIngreso;
                this.txt_cantidadMayoreo.Text = infoProducto.cantidadMayoreo.ToString().Replace(",", "");
                this.txt_stockminimo.Text = infoProducto.inventarioOptimo.ToString();
                try
                {
                    //ImageFormat Formato = ImageFormat.Png;
                    //infoProducto.extension = ".png";
                    Bitmap bmpFromString = infoProducto.imagen.Base64StringToBitmap();
                    //bmpFromString.Save(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Productos\" + infoProducto.id_producto + infoProducto.extension), Formato);
                    //this.ImgPrincipal.ImageLocation = Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Productos\" + infoProducto.id_producto + infoProducto.extension);
                    this.ImgPrincipal.Image = bmpFromString;
                }
                catch (Exception)
                {
                    this.ImgPrincipal.Image = PuntodeVentaTintoreria.Properties.Resources.icono_propa;
                }
                this.cmb_proveedor.SelectedValue = infoProducto.id_proveedor.ToString();
                this.cmb_proveedor.Enabled = false;
                this.cmb_familia.SelectedValue = infoProducto.id_familia.ToString();
                this.cmb_unidadmedida.SelectedValue = infoProducto.id_unidadMedida.ToString();
                this.cmb_marca.SelectedValue = infoProducto.id_marca.ToString();
                this.cmb_material.SelectedValue = infoProducto.id_material.ToString();
                this.checkBoxVentaDirecta.Checked = infoProducto.ventaDirecta;
                this.checkBoxInventario.Checked = infoProducto.aplicaInventario;
                this.txt_observaciones.Text = infoProducto.observaciones;
                this.CheckEsHombre.Checked = infoProducto.EsHombre;
                this.CheckEsMujer.Checked = infoProducto.EsMujer;
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
                if (this.txt_nombre.Text == string.Empty || this.txt_nombre.Text == "")
                {
                    this.txt_nombre.Focus();
                    MessageBox.Show(this, "Escriba el nombre del producto", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txt_cantidadMayoreo.Text == string.Empty || this.txt_cantidadMayoreo.Text == "")
                {
                    this.txt_cantidadMayoreo.Focus();
                    MessageBox.Show(this, "Escriba la cantidad mayoreo del producto", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txt_stockminimo.Text == string.Empty || this.txt_stockminimo.Text == "")
                {
                    this.txt_stockminimo.Focus();
                    MessageBox.Show(this, "Escriba el stock mínimo del producto", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToInt32(this.cmb_proveedor.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_proveedor.SelectedIndex) == -1)
                {
                    this.cmb_proveedor.Focus();
                    MessageBox.Show(this, "Seleccione el proveedor del producto", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToInt32(this.cmb_familia.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_familia.SelectedIndex) == -1)
                {
                    this.cmb_familia.Focus();
                    MessageBox.Show(this, "Seleccione la familia del producto", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToInt32(this.cmb_unidadmedida.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_unidadmedida.SelectedIndex) == -1)
                {
                    this.cmb_unidadmedida.Focus();
                    MessageBox.Show(this, "Seleccione la unidad de medida del producto", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToInt32(this.cmb_marca.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_marca.SelectedIndex) == -1)
                {
                    this.cmb_marca.Focus();
                    MessageBox.Show(this, "Seleccione la marca del producto", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToInt32(this.cmb_material.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_material.SelectedIndex) == -1)
                {
                    this.cmb_material.Focus();
                    MessageBox.Show(this, "Seleccione el material del producto", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (dataGridViewTextBox.Rows.Count == 0)
                {
                    this.cmb_color.Focus();
                    MessageBox.Show(this, "Agregue una combinacion del producto", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private bool ValidarCamposDetalle()
        {
            try
            {
                Val = new Validaciones();
                if (this.txt_precio.Text == string.Empty || this.txt_precio.Text == "")
                {
                    this.txt_precio.Focus();
                    MessageBox.Show(this, "Escriba el precio del producto", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txt_precioMayoreo.Text == string.Empty || this.txt_precioMayoreo.Text == "")
                {
                    this.txt_precioMayoreo.Focus();
                    MessageBox.Show(this, "Escriba el precio mayoreo del producto", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToInt32(this.cmb_color.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_color.SelectedIndex) == -1)
                {
                    this.cmb_proveedor.Focus();
                    MessageBox.Show(this, "Seleccione el color del producto", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToInt32(this.cmb_talla.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_talla.SelectedIndex) == -1)
                {
                    this.cmb_proveedor.Focus();
                    MessageBox.Show(this, "Seleccione la talla del producto", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (!checkBoxCodigoBarra.Checked)
                {
                    if (this.txt_codigo.Text == string.Empty || this.txt_codigo.Text == "")
                    {
                        this.txt_codigo.Focus();
                        MessageBox.Show(this, "Escriba el codigo del producto", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (this.txt_codigo.Text.Length < 13)
                    {
                        this.txt_codigo.Focus();
                        MessageBox.Show(this, "El codigo de barra debe de ser de 13 digitos", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                    if (!Val.validarCodigoEAN13(this.txt_codigo.Text))
                    {
                        this.txt_codigo.Focus();
                        MessageBox.Show(this, "El codigo de barra no es valido", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
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
                    UtilFtp.UploadFTP(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Productos\" + infoProducto.id_producto + ".PNG"), ConfigurationManager.AppSettings.Get("ServerFtpTxt") + @"/Productos/", ConfigurationManager.AppSettings.Get("UsuarioFtpTxt"), ConfigurationManager.AppSettings.Get("ContraseñaFtpTxt"));
                    MessageBox.Show(this, "Los datos se guardaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Visible = false;
                }
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
                ProveedorNegocio proveedor_negocio = new ProveedorNegocio();
                Proveedor proveedor = new Proveedor();
                proveedor.conexion = Comun.conexion;
                proveedor_negocio.ObtenerComboProveedor(proveedor);
                this.cmb_proveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_proveedor.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_proveedor.DataSource = proveedor.datos;
                this.cmb_proveedor.DisplayMember = "proveedor";
                this.cmb_proveedor.ValueMember = "id_proveedor";
                //
                FamiliaNegocio familia_negocio = new FamiliaNegocio();
                Familia familia = new Familia();
                familia.conexion = Comun.conexion;
                familia_negocio.ObtenerComboFamilia(familia);
                this.cmb_familia.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_familia.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_familia.DataSource = familia.datos;
                this.cmb_familia.DisplayMember = "familia";
                this.cmb_familia.ValueMember = "id_familia";
                //
                UnidadMedidaNegocio unidadmedida_negocio = new UnidadMedidaNegocio();
                UnidadMedida unidadmedida = new UnidadMedida();
                unidadmedida.conexion = Comun.conexion;
                unidadmedida_negocio.ObtenerComboUnidadMedida(unidadmedida);
                this.cmb_unidadmedida.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_unidadmedida.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_unidadmedida.DataSource = unidadmedida.datos;
                this.cmb_unidadmedida.DisplayMember = "unidadMedida";
                this.cmb_unidadmedida.ValueMember = "id_unidadMedida";
                //
                ColorRopaNegocio color_negocio = new ColorRopaNegocio();
                ColorRopa color = new ColorRopa();
                color.conexion = Comun.conexion;
                color_negocio.ObtenerComboColorRopa(color);
                this.cmb_color.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_color.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_color.DataSource = color.datos;
                this.cmb_color.DisplayMember = "colorRopa";
                this.cmb_color.ValueMember = "id_colorRopa";
                //
                TallaRopaNegocio talla_negocio = new TallaRopaNegocio();
                TallaRopa talla = new TallaRopa();
                talla.conexion = Comun.conexion;
                talla_negocio.ObtenerComboTallaRopa(talla);
                this.cmb_talla.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_talla.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_talla.DataSource = talla.datos;
                this.cmb_talla.DisplayMember = "tallaRopa";
                this.cmb_talla.ValueMember = "id_tallaRopa";
                //
                MarcaNegocio marca_negocio = new MarcaNegocio();
                Marca marca = new Marca();
                marca.conexion = Comun.conexion;
                marca_negocio.ObtenerComboMarca(marca);
                this.cmb_marca.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_marca.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_marca.DataSource = marca.datos;
                this.cmb_marca.DisplayMember = "marca";
                this.cmb_marca.ValueMember = "id_marca";
                //
                MaterialNegocio material_negocio = new MaterialNegocio();
                Material material = new Material();
                material.conexion = Comun.conexion;
                material_negocio.ObtenerComboMaterial(material);
                this.cmb_material.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_material.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_material.DataSource = material.datos;
                this.cmb_material.DisplayMember = "material";
                this.cmb_material.ValueMember = "id_material";
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
                foreach (DataGridViewRow row in dataGridViewTextBox.Rows)
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
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmProductosRopa ~ txt_nombre_KeyPress");
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
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmProductosRopa ~ txt_cantidadMayoreo_KeyPress");
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
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmProductosRopa~ txt_stockminimo_KeyPress");
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

        private void txt_costo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.PermitirSoloNumerosDecimales(e, this.txt_precio.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmProductosRopa ~ txt_costo_KeyPress");
            }
        }

        private void txt_costo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_costo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txt_precio_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.PermitirSoloNumerosDecimales(e, this.txt_precio.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmProductosRopa ~ txt_precio_KeyPress");
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
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txt_precioMayoreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.PermitirSoloNumerosDecimales(e, this.txt_precioMayoreo.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmProductosRopa ~ txt_precioMayoreo_KeyPress");
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
                LogError.AddExcFileTxt(ex, "frmProductosRopa ~ txt_codigo_KeyPress");
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
                LogError.AddExcFileTxt(ex, "frmProductosRopa ~ txt_observaciones_KeyPress");
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
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmProductosRopa_Load(object sender, EventArgs e)
        {
            try
            {
                this.backgroundWorker1.RunWorkerAsync();
                espere.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmProductosRopa ~ frmProductosRopa_Bunifu_Load");
            }
        }

        private void txt_costo_TextChanged(object sender, EventArgs e)
        {

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
                LogError.AddExcFileTxt(ex, "frmProductos ~ btn_imagen_Click");
            }
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCamposDetalle())
                {
                    ProductoDetalle productoDetalle = new ProductoDetalle();
                    DataRowView vrowColor = (DataRowView)this.cmb_color.SelectedItem;
                    DataRow rowColor = vrowColor.Row;
                    productoDetalle.id_colorRopa = Convert.ToInt32(rowColor["id_colorRopa"].ToString());
                    productoDetalle.colorRopa = rowColor["colorRopa"].ToString();
                    DataRowView vrowTalla = (DataRowView)this.cmb_talla.SelectedItem;
                    DataRow rowTalla = vrowTalla.Row;
                    productoDetalle.id_tallaRopa = Convert.ToInt32(rowTalla["id_tallaRopa"].ToString());
                    productoDetalle.tallaRopa = rowTalla["tallaRopa"].ToString();
                    float costo = 0F;
                    float.TryParse(this.txt_costo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out costo);
                    productoDetalle.costoUltimo = costo;
                    decimal precio = 0;
                    decimal.TryParse(this.txt_precio.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out precio);
                    productoDetalle.precio = precio;
                    float precioMayoreo = 0F;
                    float.TryParse(this.txt_precioMayoreo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out precioMayoreo);
                    productoDetalle.precioMayoreo = precioMayoreo;
                    productoDetalle.id_codigoEan = this.txt_codigo.Text;
                    productoDetalle.interno = this.checkBoxCodigoBarra.Checked;
                    DataRow[] rows = new DataRow[0];
                    rows = infoProducto.productoDetalle.datos.Select("id_colorRopa = '" + productoDetalle.id_colorRopa.ToString() + "' AND id_tallaRopa = '" + productoDetalle.id_tallaRopa.ToString() + "'");
                    if (rows.Count() == 0)
                    {
                        infoProducto.productoDetalle.datos.Rows.Add(new Object[] {
                                productoDetalle.id_codigoEan,
                                productoDetalle.colorRopa,
                                productoDetalle.tallaRopa,
                                productoDetalle.costoUltimo,
                                productoDetalle.precio,
                                productoDetalle.precioMayoreo,
                                productoDetalle.id_colorRopa,
                                productoDetalle.id_tallaRopa,
                                productoDetalle.interno
                            });
                        this.dataGridViewTextBox.AutoGenerateColumns = false;
                        this.dataGridViewTextBox.DataSource = infoProducto.productoDetalle.datos;
                    }
                    else
                        MessageBox.Show(this, "Este producto ya fue agregado", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmProductosRopa ~ btn_Agregar_Click");
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
                        DataRow myRow = (this.ObtenerFilaSeleccionada()[0].DataBoundItem as DataRowView).Row;
                        infoProducto.productoDetalle.datos.Rows.Remove(myRow);
                    }
                    this.dataGridViewTextBox.AutoGenerateColumns = false;
                    this.dataGridViewTextBox.DataSource = infoProducto.productoDetalle.datos;
                    if (dataGridViewTextBox.Rows.Count > 0)
                        dataGridViewTextBox.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmProductosRopa ~ btn_Eliminar_Click");
            }
        }
        private void checkBoxCodigoBarra_OnChange(object sender, EventArgs e)
        {
            try
            {
                if (!checkBoxCodigoBarra.Checked)
                {
                    this.txt_codigo.Enabled = true;
                }
                else
                {
                    this.txt_codigo.Enabled = false;
                    this.txt_codigo.Text = "";
                    MessageBox.Show(this, "Los codigos de barra automaticos no pueden ser modificados", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmProductosRopa ~ checkBoxCodigoBarra_OnChange");
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
                LogError.AddExcFileTxt(ex, "frmProductosRopa~ btnGuardar_Click");
            }
        }


        private void dataGridViewTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloDecimal(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dataGridViewTextBox_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta    Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
