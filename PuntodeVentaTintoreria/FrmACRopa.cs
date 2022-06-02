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

    public partial class FrmACRopa : Form
    {
        #region Variables
        private Ropa oRopa;
        private RopaNegocio oNegocio;
        private Validaciones Val;
        #endregion

        #region Constructors
        public FrmACRopa(Ropa oRopa)
        {
            InitializeComponent();
            this.oRopa = oRopa;
            this.oNegocio = new RopaNegocio();
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
                LogError.AddExcFileTxt(ex, "FrmACRopa ~ btnGuardar_Click");
            }
        }
        #endregion

        #region Methods
        private void Inicializar()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.oRopa.Id))
                {
                    this.LLenarDatos();
                    this.LbTitulo.Text = "Editar ropa";
                }
                CargarComboTipoRopa();
                CargarComboSubTipoRopa();
                CargarComboGrupo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarComboGrupo()
        {
            GrupoNegocio oNegocioGrupo = new GrupoNegocio();
            CmbGrupo.DataSource = oNegocioGrupo.GetCombo();
            CmbGrupo.ValueMember = "id";
            CmbGrupo.DisplayMember = "descripcion";
            CmbGrupo.SelectedValue = oRopa.IdGrupo == 0 ? 0 : oRopa.IdGrupo;
        }

        private void CargarComboSubTipoRopa()
        {
            SubTipoRopaNegocio oNegocioSubTipoRopa = new SubTipoRopaNegocio();
            CmbSubTipoRopa.DataSource = oNegocioSubTipoRopa.GetCombo();
            CmbSubTipoRopa.ValueMember = "id";
            CmbSubTipoRopa.DisplayMember = "descripcion";
            CmbSubTipoRopa.SelectedValue = oRopa.IdSubTipoRopa ?? "0";
        }

        private void CargarComboTipoRopa()
        {
            TipoRopaNegocio oNegocioTipoRopa = new TipoRopaNegocio();
            CmbTipoRopa.DataSource = oNegocioTipoRopa.GetCombo();
            CmbTipoRopa.ValueMember = "id";
            CmbTipoRopa.DisplayMember = "descripcion";
            CmbTipoRopa.SelectedValue = oRopa.IdTipoRopa == 0 ? 0 : oRopa.IdTipoRopa;
        }

        private void LLenarDatos()
        {
            try
            {
                this.oRopa = oNegocio.GetItem(this.oRopa.Id);
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

                if (Convert.ToInt32(this.CmbTipoRopa.SelectedValue) == 0)
                {
                    mensajeError += "Seleccione un tipo de ropa." + Environment.NewLine;
                    this.CmbTipoRopa.Focus();
                }
                if (string.IsNullOrEmpty(this.CmbSubTipoRopa.SelectedValue.ToString()))
                {
                    mensajeError += "Seleccione un subtipo de ropa." + Environment.NewLine;
                    this.CmbSubTipoRopa.Focus();
                }
                if (Convert.ToInt32(this.CmbGrupo.SelectedValue) == 0)
                {
                    mensajeError += "Seleccione un grupo de ropa." + Environment.NewLine;
                    this.CmbGrupo.Focus();
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
                this.oRopa.IdTipoRopa = Convert.ToInt32(this.CmbTipoRopa.SelectedValue);
                this.oRopa.IdSubTipoRopa = this.CmbSubTipoRopa.SelectedValue.ToString();
                this.oRopa.IdGrupo = Convert.ToInt32(this.CmbGrupo.SelectedValue);
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

                int opcion = string.IsNullOrEmpty(oRopa.Id) ? 1 : 2;

                RespuestaSQL oRespuesta = oNegocio.AC(oRopa, opcion);

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
                LogError.AddExcFileTxt(ex, "FrmACRopa ~ txt_color_KeyPress");
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
