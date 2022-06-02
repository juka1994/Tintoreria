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

    public partial class FrmNuevoTipoSimboloTextil : Form
    {
        #region Variables
        private TipoSimboloTextil oTipoSimboloTextil;
        private TipoSimboloTextilNegocio oNegocio;
        private Validaciones Val;

        #endregion

        #region Constructors
        public FrmNuevoTipoSimboloTextil(TipoSimboloTextil oTipoSimboloTextil)
        {
            InitializeComponent();
            this.oTipoSimboloTextil = oTipoSimboloTextil;
            this.oNegocio = new TipoSimboloTextilNegocio();
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
                LogError.AddExcFileTxt(ex, "FrnNuevoTipoSimboloTextil ~ btnGuardar_Click");
            }
        }
        #endregion

        #region Methods
        private void Inicializar()
        {
            try
            {
                if (this.oTipoSimboloTextil.Id != 0)
                {
                    this.LLenarDatos();
                    this.lbTitulo.Text = "Editar tipo simbolo textil";
                }
                
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
                this.oTipoSimboloTextil = oNegocio.GetItem(this.oTipoSimboloTextil.Id);
                this.txtDescripcion.Text = oTipoSimboloTextil.Descripcion;
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

                if (this.txtDescripcion.Text.Length == 0)
                {
                    mensajeError += "Escriba la descripción del tipo del simbolo textil" + Environment.NewLine;
                    this.txtDescripcion.Focus();
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
                this.oTipoSimboloTextil.Descripcion = this.txtDescripcion.Text;
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

                int opcion = oTipoSimboloTextil.Id != 0 ? 2 : 1;

                RespuestaSQL oRespuesta = oNegocio.AC_TipoSimboloTextil(oTipoSimboloTextil, opcion);

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
                LogError.AddExcFileTxt(ex, "FrmNuevoTipoSimboloTextil ~ txt_color_KeyPress");
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
