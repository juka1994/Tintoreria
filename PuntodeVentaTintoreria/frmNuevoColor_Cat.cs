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

    public partial class frmNuevoColor_Cat : Form
    {
        #region Variables
        private ColorRopa oColorRopa;
        private ColorRopaNegocio oNegocio;
        private Validaciones Val;
        private string extensionImage = string.Empty;
        private bool modificarImagen;
        private const int THUMB_WIDTH = 100;
        private const int THUMB_HEIGTH = 100; 
        #endregion

        #region Constructors
        public frmNuevoColor_Cat(ColorRopa oColorRopa)
        {
            InitializeComponent();
            this.oColorRopa = oColorRopa;
            this.oNegocio = new ColorRopaNegocio();
            this.Inicializar();
        }
        #endregion

        #region Events
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    this.modificarImagen = true;
                    this.ImgPrincipal.ImageLocation = BuscarImagen.FileName;
                    //obtenemos la extesion de la imagen
                    this.extensionImage = Path.GetExtension(BuscarImagen.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmNuevoColor_Cat ~ btn_imagen_Click");
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
                        this.Guardar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmColorRopa_Bunifu ~ btnGuardar_Click");
            }
        }
        #endregion

        #region Methods
        private void Inicializar()
        {
            try
            {
                if (this.oColorRopa.id_colorRopa != 0)
                {
                    this.LLenarDatos();
                    this.lbTitulo.Text = "Editar Color";
                }
                this.CargarImagen();
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
                this.oColorRopa = oNegocio.GetItem(this.oColorRopa.id_colorRopa);
                this.txtDescripcion.Text = oColorRopa.descripcion;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void CargarImagen()
        {
            try
            {
                if (!string.IsNullOrEmpty(oColorRopa.ImagenBase64))
                {
                    Bitmap bmpFromString = oColorRopa.ImagenBase64.Base64StringToBitmap();
                    this.ImgPrincipal.Image = bmpFromString;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidarCampos()
        {
            Validaciones Val = new Validaciones();
            try
            {
                string mensajeError = string.Empty;

                if (this.txtDescripcion.Text.Length == 0)
                {
                    mensajeError += "Escriba la descripción del simbolo textil" + Environment.NewLine;
                    this.txtDescripcion.Focus();
                }
                if (!modificarImagen && oColorRopa.id_colorRopa == 0)
                {
                    mensajeError += "Seleccione una imagen" + Environment.NewLine;
                    this.ImgPrincipal.Focus();
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
                return false;
            }
        }
        private void ObtenerDatos()
        {
            try
            {
                this.oColorRopa.descripcion = this.txtDescripcion.Text;
                this.oColorRopa.id_u = Comun.id_u;
                this.oColorRopa.Extension = this.extensionImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Guardar()
        {
            try
            {
                this.ObtenerDatos();

                if (modificarImagen)
                {
                    //obtenemos la imagen a subir
                    Image image = new Bitmap(this.ImgPrincipal.Image);
                    //obtengo su formato
                    ImageFormat Formato = HelperImgCID.GetImageFormat(LblImage.Text);

                    //genero el thumbnail
                    Image.GetThumbnailImageAbort callback = new Image.GetThumbnailImageAbort(ThumbnailCallback);

                    Image pThumbnail = image.GetThumbnailImage(THUMB_WIDTH, THUMB_HEIGTH, callback, new IntPtr());
                    Bitmap bmp = new Bitmap(pThumbnail);
                    oColorRopa.ImagenBase64 = bmp.ToBase64String(Formato);
                    oColorRopa.ImagenModificada = true;
                }

                oColorRopa.opcion = oColorRopa.id_colorRopa != 0 ? 2 : 1;

                RespuestaSQL oRespuesta = oNegocio.AbcColorRopa(oColorRopa);

                MessageBox.Show(oRespuesta.Mensaje, Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, oRespuesta.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public bool ThumbnailCallback()
        {
            return true;
        }
        #endregion

        #region Validaciones
        private void txt_color_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloTexto(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmNuevoColor_Cat ~ txt_color_KeyPress");
            }
        }

        private void txt_color_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_color_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion
        
       

       
    }
}
