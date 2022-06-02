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

    public partial class FrmACConversion : Form
    {
        #region Params
        private Conversion oConversion;
        private ConversionNegocio oNegocio;
        private Validaciones Val;
        #endregion

        #region Constructors
        public FrmACConversion(Conversion oConversion)
        {
            InitializeComponent();
            this.oConversion = oConversion;
            this.TxtUnidadMedida.Text = oConversion.NombreUnidadMedidaEntrada;
            this.oNegocio = new ConversionNegocio();
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
                if (this.oConversion.Id != 0)
                {
                    this.LLenarDatos();
                    this.lbTitulo.Text = "Editar conversión";
                }
                
                this.CargarCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void CargarCombo()
        {
            this.CmbUnidadMedida.DataSource = oNegocio.ObtenerCombo();
            this.CmbUnidadMedida.DisplayMember = "descripcion";
            this.CmbUnidadMedida.ValueMember = "id_unidadMedida";
            this.CmbUnidadMedida.SelectedValue = oConversion.IdUnidadMedidaSalida;
        }

        private void LLenarDatos()
        {
            try
            {
                this.oConversion = this.oNegocio.ObtenerItem(this.oConversion.Id);
                this.TxtCantidad.Text = oConversion.Cantidad.ToString("N6");
                
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
                int valueCmb = (int)CmbUnidadMedida.SelectedValue;

                if (valueCmb == 0)
                {
                    mensajeError += "Seleccione una unidad de medida." + Environment.NewLine;
                    this.CmbUnidadMedida.Focus();
                }
                if(!decimal.TryParse(TxtCantidad.Text, out decimal cantidad))
                {
                    mensajeError += "Ingrese una cantidad." + Environment.NewLine;
                    this.TxtCantidad.Focus();
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
                this.oConversion.IdUnidadMedidaSalida = (int)this.CmbUnidadMedida.SelectedValue;
                this.oConversion.Cantidad = decimal.Parse(this.TxtCantidad.Text);
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
                int opcion = oConversion.Id != 0 ? 2 : 1;
                RespuestaSQL oRespuesta = new RespuestaSQL();
                oRespuesta = oNegocio.AC(oConversion, opcion);

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
                LogError.AddExcFileTxt(ex, "FrmACConversion ~ txt_color_KeyPress");
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

        private void TxtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.PermitirSoloNumerosDecimales(e, TxtCantidad.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmACConversion ~ TxtCantidad_KeyPress");
            }
        }
    }
}
