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

    public partial class FrmACSubTipoRopa : Form
    {
        #region Variables
        private SubTipoRopa oSubTipoRopa;
        private SubTipoRopaNegocio oNegocio;
        private Validaciones Val;
        private string extensionImage = string.Empty;
        private bool modificarImagen;
        private const int THUMB_WIDTH = 100;
        private const int THUMB_HEIGTH = 100;
        #endregion

        #region Constructors
        public FrmACSubTipoRopa(SubTipoRopa oSubTipoRopa)
        {
            InitializeComponent();
            this.oSubTipoRopa = oSubTipoRopa;
            this.oNegocio = new SubTipoRopaNegocio();
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
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmACSubTipoRopa ~ btnGuardar_Click");
            }
        }
        #endregion

        #region Methods
        private void Inicializar()
        {
            try
            {
                if (this.oSubTipoRopa.Id != 0)
                {
                    this.LLenarDatos();
                    this.LbTitulo.Text = "Editar SubTipo de Ropa";
                }
                this.CargarImagen();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void LLenarDatos()
        {
            try
            {
                this.oSubTipoRopa = oNegocio.GetSubTipoRopaXId(this.oSubTipoRopa.Id);
                this.TxtDescripcion.Text = this.oSubTipoRopa.Descripcion;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private bool ValidarCampos()
        {
            Validaciones Val = new Validaciones();
            try
            {
                string mensajeError = string.Empty;

                if (this.TxtDescripcion.Text.Length == 0)
                {
                    mensajeError += "Escriba la descripción del SubTipo de Ropa." + Environment.NewLine;
                    this.TxtDescripcion.Focus();
                }

                if (!modificarImagen && oSubTipoRopa.Id == 0)
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
                this.oSubTipoRopa.Descripcion = this.TxtDescripcion.Text;
                this.oSubTipoRopa.Extension = this.extensionImage;
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
                    oSubTipoRopa.ImagenBase64 = bmp.ToBase64String(Formato);
                    oSubTipoRopa.ImagenModificada = true;
                }

                int opcion  = oSubTipoRopa.Id == 0 ? 1 : 2;

                RespuestaSQL oRespuesta = oNegocio.AC(oSubTipoRopa, opcion);

                MessageBox.Show(oRespuesta.Mensaje, Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, oRespuesta.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Validaciones
        private void TxtDescipcion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void TxtDescipcion_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        private void BtnImagen_Click(object sender, EventArgs e)
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
                LogError.AddExcFileTxt(ex, "FrmACSubTipoRopa ~ BtnImagen_Click");
            }
        }

        private void CargarImagen()
        {
            try
            {
                if (!string.IsNullOrEmpty(oSubTipoRopa.ImagenBase64))
                {
                    Bitmap bmpFromString = oSubTipoRopa.ImagenBase64.Base64StringToBitmap();
                    this.ImgPrincipal.Image = bmpFromString;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool ThumbnailCallback()
        {
            return true;
        }
    }
}
