using PuntodeVentaTintoreria.ClaseAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TintoreriaGlobal;
using TintoreriaNegocio;

namespace PuntodeVentaTintoreria
{
    public partial class frmProductosImagenes_Nuevo : Form
    {
        private Validaciones Val;
        private ProductoImagen infoProducto;
        private string IDProductoAux;
        private bool ModificarImagen;
        private frm_Esperar espere = new frm_Esperar();

        public frmProductosImagenes_Nuevo(ProductoImagen productoImagen)
        {
            InitializeComponent();
            infoProducto = productoImagen;
        }


        public frmProductosImagenes_Nuevo(string ID)
        {
            InitializeComponent();
            IDProductoAux = ID;
            infoProducto = new ProductoImagen();
        }

        public bool ThumbnailCallback()
        {
            return true;
        }
        #region Metodos Generales
        private void Inicializar()
        {
            try
            {
                this.LlenarDatos();
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
                ProductoImagenNegocio productoNegocio = new ProductoImagenNegocio();
                ProductoImagen producto = new ProductoImagen();
                producto.Conexion = Comun.conexion;
                producto.id_u = Comun.id_u;
                this.ObtenerDatos(producto);

                if (infoProducto.IdImagnen != null)
                {
                    producto.opcion = 2;
                    producto.IdImagnen = infoProducto.IdImagnen;
                    producto.IdProducto = infoProducto.IdProducto;
                    producto.TipoArc = infoProducto.TipoArc;
                    producto.imagen = "";
                    productoNegocio.AbcProductoImg(producto, ref Verificador);

                    if (producto.Completado == true)
                    {


                        if (ModificarImagen || producto.Title != infoProducto.Title)
                        {
                            try
                            {







                                ImageFormat Formato = ImageFormat.Png;
                                producto.TipoArc = ".png";

                                Image imagen2 = Recursos.ResizeImage2(this.ImgPrincipal.Image, 272, 390);
                                Image imagen = Recursos.ImageCenter(imagen2);
                                imagen.Save(Path.Combine(System.Windows.Forms.Application.StartupPath, @"" + producto.UrlImagen));

                                //************************************************************************************************************************************************************************
                                //************************************************************************************************************************************************************************

                                //GUARDAR O ACTUALZIAR IMAGEN
                                // CONVERTIR BASE 64 IMAGEN
                                StreamReader streamReader = new StreamReader(Path.Combine(System.Windows.Forms.Application.StartupPath, @"" + producto.UrlImagen));
                                Bitmap bmp = new Bitmap(streamReader.BaseStream);
                                streamReader.Close();
                                producto.imagen = bmp.ToBase64String(Formato);


                                //Guardar Datos y multimedia
                                producto.opcion = 4;
                                productoNegocio.AbcProductoImg(producto, ref Verificador);

                                //************************************************************************************************************************************************************************
                                //************************************************************************************************************************************************************************


                                //Guradar FTP

                                string pathimg = Path.Combine(System.Windows.Forms.Application.StartupPath, @"" + producto.UrlImagen);
                                string servidor = ConfigurationManager.AppSettings.Get("ServerFtpTxt2") + @"/ProductosImagen/";
                                string usuario = ConfigurationManager.AppSettings.Get("UsuarioFtpTxt2");
                                string contraseña = ConfigurationManager.AppSettings.Get("ContraseñaFtpTxt2");
                                string paththumb = Path.Combine(System.Windows.Forms.Application.StartupPath, @"" + producto.UrlImagenMin);
                                string servidorthumb = ConfigurationManager.AppSettings.Get("ServerFtpTxt2") + @"/ProductosImagen/Thum/";

                                UtilFtp.UploadFTP(pathimg, servidor, usuario, contraseña);
                                Image.GetThumbnailImageAbort callback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                                Image image = new Bitmap(this.ImgPrincipal.Image);
                                Image pThumbnail = image.GetThumbnailImage(100, 100, callback, new IntPtr());
                                pThumbnail.Save(Path.Combine(System.Windows.Forms.Application.StartupPath, @"" + producto.UrlImagenMin));
                                UtilFtp.UploadFTP(paththumb, servidorthumb, usuario, contraseña);


                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }



                    }
                    this.VerifcarMensajeAccion(Verificador);
                }
                else
                {
                    producto.opcion = 1;
                    producto.IdProducto = this.IDProductoAux;
                    producto.TipoArc = ".png";

                    if (ModificarImagen == true)
                    {
                        try
                        {
                            ImageFormat Formato = ImageFormat.Png;
                            producto.TipoArc = ".png";

                            Image imagen2 = Recursos.ResizeImage2(this.ImgPrincipal.Image, 272, 390);
                            Image imagen = Recursos.ImageCenter(imagen2);



                            //imagen.Save(Path.Combine(System.Windows.Forms.Application.StartupPath, @"" + producto.UrlImagen));

                            //************************************************************************************************************************************************************************
                            //************************************************************************************************************************************************************************


                            //   StreamReader streamReader = new StreamReader(Path.Combine(System.Windows.Forms.Application.StartupPath, @"" + producto.UrlImagen));

                            imagen.Save(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\ProductosImagen\temporalimg" + producto.TipoArc));

                            StreamReader streamReader = new StreamReader(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\ProductosImagen\temporalimg" + producto.TipoArc));
                            Bitmap bmp = new Bitmap(streamReader.BaseStream);
                            streamReader.Close();
                            producto.imagen = bmp.ToBase64String(Formato);



                            //Guardar Imagen Datos y Multimedia, opcion 1
                            productoNegocio.AbcProductoImg(producto, ref Verificador);

                            if (Verificador == 0)
                            {
                                //************************************************************************************************************************************************************************
                                //************************************************************************************************************************************************************************
                                imagen.Save(Path.Combine(System.Windows.Forms.Application.StartupPath, @"" + producto.UrlImagen));


                                //Subir FTP Archuivo
                                UtilFtp.UploadFTP(Path.Combine(System.Windows.Forms.Application.StartupPath, @"" + producto.UrlImagen), ConfigurationManager.AppSettings.Get("ServerFtpTxt2") + @"/ProductosImagen/", ConfigurationManager.AppSettings.Get("UsuarioFtpTxt2"), ConfigurationManager.AppSettings.Get("ContraseñaFtpTxt2"));
                                Image.GetThumbnailImageAbort callback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                                Image image = new Bitmap(this.ImgPrincipal.Image);
                                Image pThumbnail = image.GetThumbnailImage(100, 100, callback, new IntPtr());
                                pThumbnail.Save(Path.Combine(System.Windows.Forms.Application.StartupPath, @"" + producto.UrlImagenMin));
                                UtilFtp.UploadFTP(Path.Combine(System.Windows.Forms.Application.StartupPath, @"" + producto.UrlImagenMin), ConfigurationManager.AppSettings.Get("ServerFtpTxt2") + @"/ProductosImagen/Thum/", ConfigurationManager.AppSettings.Get("UsuarioFtpTxt2"), ConfigurationManager.AppSettings.Get("ContraseñaFtpTxt2"));

                            }
                            else
                                MessageBox.Show("No se almaceno la imagen, recuerde que puede guardar máximo 5 imagenes por producto", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    else
                        MessageBox.Show("Debe seleccionar una imagen", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);



                    this.VerifcarMensajeAccion(Verificador);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ObtenerDatos(ProductoImagen producto)
        {
            try
            {
                producto.NombreArc = this.txt_Nombre.Text;
                producto.Descripcion = this.txt_Descripcion.Text;
                producto.Alt = this.txt_Alt.Text;
                string textoSinAcentos = Remover.RemoverAcentos(this.txt_Title.Text);
                string textoSinAcento_Signos = Remover.RemoverSignosAcentos(textoSinAcentos);
                producto.Title = textoSinAcento_Signos;
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
                this.txt_Nombre.Text = infoProducto.NombreArc;
                this.txt_Title.Text = infoProducto.Title;
                this.txt_Alt.Text = infoProducto.Alt;
                try
                {
                    if (infoProducto.UrlImagen == null)
                    {
                    }
                    else
                    {
                        this.ImgPrincipal.ImageLocation = Path.Combine(System.Windows.Forms.Application.StartupPath, @"" + infoProducto.UrlImagen);
                        this.LblImage.Text = infoProducto.UrlImagen;
                    }
                }
                catch (Exception)
                {
                    this.ImgPrincipal.Image = PuntodeVentaTintoreria.Properties.Resources.icono_productos;
                }

                this.txt_Descripcion.Text = infoProducto.Descripcion;

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
                if (this.txt_Nombre.Text == string.Empty || this.txt_Nombre.Text == "")
                {
                    this.txt_Nombre.Focus();
                    MessageBox.Show(this, "Escriba el nombre de la imagen", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txt_Descripcion.Text == string.Empty || this.txt_Descripcion.Text == "")
                {
                    this.txt_Descripcion.Focus();
                    MessageBox.Show(this, "Escriba la descripción de la imagen", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txt_Alt.Text == string.Empty || this.txt_Alt.Text == "")
                {
                    this.txt_Alt.Focus();
                    MessageBox.Show(this, "Escriba el mensaje alternativo alt", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txt_Title.Text == string.Empty || this.txt_Title.Text == "")
                {
                    this.txt_Title.Focus();
                    MessageBox.Show(this, "Escriba el mensaje alternativo title", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    this.Visible = false;
                }
                else if (Verificador == 1)
                {
                    MessageBox.Show(this, "No se puede guardar mas de 4 imagenes", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                LogError.AddExcFileTxt(ex, "frmProductosimagenes_nuevo ~ txt_nombre_KeyPress");
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
                LogError.AddExcFileTxt(ex, "frmProductosImagenes_nuevo ~ txt_codigo_KeyPress");
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

        private void frmProductosImagenes_Nuevo_Load(object sender, EventArgs e)
        {
            try
            {
                Inicializar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmProductosImagenes_Nuevo ~ frmProductosImagenes_Nuevo_Load");
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
                LogError.AddExcFileTxt(ex, "frmProductosImagenesNUevo ~ btn_imagen_Click");
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
                LogError.AddExcFileTxt(ex, "frmProductosImagenes_Nuevo ~ btnGuardar_Click");
            }
        }
    }
}
