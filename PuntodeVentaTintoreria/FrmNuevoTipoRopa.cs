namespace PuntodeVentaTintoreria
{
    using PuntodeVentaTintoreria.ClaseAux;
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows.Forms;
    using TintoreriaGlobal;
    using TintoreriaNegocio;

    public partial class FrmNuevoTipoRopa : Form
    {
        private TipoRopa infoTipo;
        private Validaciones Val;
        private bool ModificarImagen;
        private const int THUMB_WIDTH = 100;
        private const int THUMB_HEIGTH = 100;
        private string extensionImage = string.Empty;

        public FrmNuevoTipoRopa(TipoRopa Tipo)
        {
            InitializeComponent();
            infoTipo = Tipo;
            this.Inicializar();
        }
        #region Validaciones
        private void txt_motivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloTexto(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_motivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_motivo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (this.ValidarCampos())
                    {
                        this.Guardar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmNuevo_Motivo_Load(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.Inicializar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Metodos Generales
        private void Inicializar()
        {
            try
            {
                if (infoTipo.IDTipoRopa != 0)
                {
                    this.LLenarDatos();
                    this.lbTitulo.Text = "Editar Tipo de Ropa";
                    this.CargarImagen();
                }
                this.ActiveControl = this.txt_TipoRopa;
                this.txt_TipoRopa.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void LLenarDatos()
        {
            try
            {

                this.txt_TipoRopa.Text = infoTipo.Descripcion.ToString();
                TipoRopa Tipo = new TipoRopa();
                Tipo.IDTipoRopa = infoTipo.IDTipoRopa;
                Tipo.Conexion = Comun.conexion;
                TipoRopaNegocio TipoNegocio = new TipoRopaNegocio();
                TipoNegocio.ObtenerImagen(Tipo);
                infoTipo.Imagen = Tipo.Imagen;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void CargarImagen()
        {
            try
            {
                if (infoTipo.Imagen == "0")
                {
                    StreamReader streamReader = new StreamReader(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\TipoRopa\0.jpg"));
                    Bitmap bmp = new Bitmap(streamReader.BaseStream);
                    streamReader.Close();
                    this.ImgPrincipal.Image = bmp;
                }
                else
                {
                    ImageFormat Formato = ImageFormat.Png;
                    infoTipo.Extension = ".png";
                    Bitmap bmpFromString = infoTipo.Imagen.Base64StringToBitmap();
                    this.ImgPrincipal.Image = bmpFromString;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Guardar()
        {
            try
            {
                int Verificador = -1;
                TipoRopa Tipo = new TipoRopa();
                TipoRopaNegocio TipoNegocio = new TipoRopaNegocio();
                Tipo.Conexion = Comun.conexion;
                this.ObtenerDatos(Tipo);

                if (ModificarImagen)
                {
                    //obtenemos la imagen a subir
                    Image image = new Bitmap(this.ImgPrincipal.Image);
                    //obtengo su formato
                    ImageFormat Formato = HelperImgCID.GetImageFormat(LblImage.Text);

                    //genero el thumbnail
                    Image.GetThumbnailImageAbort callback = new Image.GetThumbnailImageAbort(ThumbnailCallback);

                    Image pThumbnail = image.GetThumbnailImage(THUMB_WIDTH, THUMB_HEIGTH, callback, new IntPtr());
                    Bitmap bmp = new Bitmap(pThumbnail);
                    Tipo.Imagen = bmp.ToBase64String(Formato);
                    Tipo.ImagenModificada = true;
                }

                Tipo.Opcion = Tipo.IDTipoRopa != 0 ? 2 : 1;

                TipoNegocio.ACTIpoRopa(Tipo, ref Verificador);
                this.VerificarMensajeAccion(Verificador);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmNuevoTipoRopa ~ GuadarCatMotivo");
            }
        }
        public bool ThumbnailCallback()
        {
            return true;
        }
        private void ObtenerDatos(TipoRopa Tipo)
        {
            try
            {
                Tipo.IDTipoRopa = infoTipo.IDTipoRopa;
                Tipo.Descripcion = this.txt_TipoRopa.Text;
                Tipo.IDUsuario = Comun.id_u;
                Tipo.Extension = this.extensionImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private bool ValidarCampos()
        {
            string mensajeError = string.Empty;

            if (this.txt_TipoRopa.Text.Length == 0)
            {
                mensajeError += "Escriba el tipo de ropa." + Environment.NewLine;
                this.txt_TipoRopa.Focus();
            }
            if (!ModificarImagen && infoTipo.IDTipoRopa == 0)
            {
                mensajeError += "Seleccione una imagen." + Environment.NewLine;
                this.LblImage.Focus();
            }

            if (string.IsNullOrEmpty(mensajeError))
            {
                return true;
            }
            else
            {
                MessageBox.Show(this, mensajeError, "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
        private void VerificarMensajeAccion(int Verificador)
        {

            try
            {
                if (Verificador == 0)
                {
                    MessageBox.Show(this, "Los datos se guardaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show(this, "No se permite la modificación de este registro", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txt_motivo_TextChanged(object sender, EventArgs e)
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
                    //obtenemos la extesion de la imagen
                    this.extensionImage = Path.GetExtension(BuscarImagen.FileName);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmNuevoTipoRopa ~ btn_imagen_Click");
            }

        }
    }
}
