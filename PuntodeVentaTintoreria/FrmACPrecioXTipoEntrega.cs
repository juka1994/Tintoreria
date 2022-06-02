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

    public partial class FrmACPrecioXTipoEntrega : Form
    {
        #region Variables
        private PrecioXTipoEntrega oPrecioXTipoEntrega;
        private PrecioXTipoEntregaNegocio oNegocio;
        private Validaciones Val;
        #endregion

        #region Constructors
        public FrmACPrecioXTipoEntrega(PrecioXTipoEntrega oPrecioXTipoEntrega)
        {
            InitializeComponent();
            this.oPrecioXTipoEntrega = oPrecioXTipoEntrega;
            this.oNegocio = new PrecioXTipoEntregaNegocio();
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
                LogError.AddExcFileTxt(ex, "FrmACPrecioXTipoEntrega ~ btnguardar_Click");
            }
        }
        #endregion

        #region Methods
        private void Inicializar()
        {
            try
            {
                if (this.oPrecioXTipoEntrega.Id != 0)
                {
                    this.LLenarDatos();
                    this.LbTitulo.Text = "Editar precio";
                }

                CargarCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void CargarCombo()
        {
            TipoEntregaNegocio oTipoEntregaNegocio = new TipoEntregaNegocio();
            CmbTipoEntrega.DataSource = oTipoEntregaNegocio.GetCombo();
            CmbTipoEntrega.DisplayMember = "descripcion";
            CmbTipoEntrega.ValueMember = "id";
            CmbTipoEntrega.SelectedValue = this.oPrecioXTipoEntrega.IdTipoEntrega;
        }

        private void LLenarDatos()
        {
            try
            {
                this.oPrecioXTipoEntrega = oNegocio.GetItem(this.oPrecioXTipoEntrega.Id);
                this.TxtPrecio.Text = oPrecioXTipoEntrega.Precio.ToString("C2");
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

                if (string.Equals(CmbTipoEntrega.SelectedValue, "0"))
                {
                    mensajeError += "Seleccione un tipo de entrega." + Environment.NewLine;
                    this.CmbTipoEntrega.Focus();
                }

                if (string.IsNullOrEmpty(this.TxtPrecio.Text) || string.Equals(this.TxtPrecio.Text, "0"))
                {
                    mensajeError += "Escriba un precio mayor a 0." + Environment.NewLine;
                    this.TxtPrecio.Focus();
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
                this.oPrecioXTipoEntrega.IdTipoEntrega = Convert.ToInt32(this.CmbTipoEntrega.SelectedValue);
                this.oPrecioXTipoEntrega.Precio = Convert.ToDecimal(this.TxtPrecio.Text);
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

                int opcion = oPrecioXTipoEntrega.Id != 0 ? 2 : 1;

                RespuestaSQL oRespuesta = oNegocio.AC(oPrecioXTipoEntrega, opcion);

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
                LogError.AddExcFileTxt(ex, "FrmACPrecioXTipoEntrega ~ txt_color_KeyPress");
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
