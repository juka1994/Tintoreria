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

    public partial class FrmNuevoSimboloTextil : Form
    {
        private SimboloTextil oSimboloTextil;
        private SimboloTextilNegocio oNegocio;
        private Validaciones Val;
        private bool modificarImagen;
        private const int THUMB_WIDTH = 100;
        private const int THUMB_HEIGTH = 100;
        private string extensionImage;

        public FrmNuevoSimboloTextil(SimboloTextil simboloTextil)
        {
            InitializeComponent();
            this.oSimboloTextil = simboloTextil;
            this.oNegocio = new SimboloTextilNegocio();
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
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(this, "No puedes copiar o pegar", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Frm_Load(object sender, EventArgs e)
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
                if (oSimboloTextil.Id != 0)
                {
                    this.LLenarDatos();
                    this.lbTitulo.Text = "Editar simbolo textil";
                    this.CargarImagen();
                }
                this.ActiveControl = this.txt_Descripcion;
                this.CargarCombos();
                this.txt_Descripcion.Focus();
                
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
        private void CargarCombos()
        {
            TipoSimboloTextilNegocio oNegocioSimboloRopaNegocio = new TipoSimboloTextilNegocio();
            cmbSimboloRopa.DataSource = oNegocioSimboloRopaNegocio.GetCombo();
            cmbSimboloRopa.ValueMember = "id";
            cmbSimboloRopa.DisplayMember = "descripcion";
            cmbSimboloRopa.SelectedValue = oSimboloTextil.IdTipoSimboloRopa;
        }
        private void LLenarDatos()
        {
            try
            {
                this.txt_Descripcion.Text = oSimboloTextil.Descripcion.ToString();
                oSimboloTextil =  this.oNegocio.GetItem(oSimboloTextil.Id);
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
                if (!string.IsNullOrEmpty(oSimboloTextil.ImagenBase64))
                {
                    Bitmap bmpFromString = oSimboloTextil.ImagenBase64.Base64StringToBitmap();
                    this.ImgPrincipal.Image = bmpFromString;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    oSimboloTextil.ImagenBase64 = bmp.ToBase64String(Formato);
                    oSimboloTextil.ImagenModificada = true;
                }

                oSimboloTextil.opcion = oSimboloTextil.Id != 0 ? 2 : 1;

                RespuestaSQL oRespuesta = oNegocio.AC_SimboloTextil(oSimboloTextil);

                MessageBox.Show(oRespuesta.Mensaje, Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, oRespuesta.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmNuevoSimboloTextil ~ Guardar");
            }
        }
        private void ObtenerDatos()
        {
            try
            {
                oSimboloTextil.Descripcion = this.txt_Descripcion.Text;
                oSimboloTextil.IdTipoSimboloRopa = int.Parse(cmbSimboloRopa.SelectedValue.ToString());
                oSimboloTextil.id_usuario = Comun.id_u;
                oSimboloTextil.Extension = this.extensionImage;
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

                if (this.txt_Descripcion.Text.Length == 0)
                {
                    mensajeError += "Escriba la descripción del simbolo textil" + Environment.NewLine;
                    this.txt_Descripcion.Focus();
                }
                if (string.Equals(this.cmbSimboloRopa.SelectedValue.ToString(), "0"))
                {
                    mensajeError += "Seleccione un tipo de simbolo de ropa." + Environment.NewLine;
                    this.cmbSimboloRopa.Focus();
                }
                if (!modificarImagen && oSimboloTextil.Id == 0)
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
        
        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
                LogError.AddExcFileTxt(ex, "FrmNuevoSimboloTextil ~ btn_imagen_Click");
            }
        }
    }
}
