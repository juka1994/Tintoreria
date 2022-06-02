namespace PuntodeVentaTintoreria
{
    using PuntodeVentaTintoreria.ClaseAux;
    using System;
    using System.Configuration;
    using System.Data;
    using System.Windows.Forms;
    using TintoreriaGlobal;
    using TintoreriaNegocio;

    public partial class frmStockQuitar : Form
    {
        private Validaciones Val;
        Almacen infoAlmacen;
        private decimal cantidadConvertida;

        public frmStockQuitar(Almacen almacen)
        {
            InitializeComponent();
            this.cantidadConvertida = 0;
            infoAlmacen = almacen;
            Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
        }
        #region Metodos Generales
        private void GuadarAlmacen()
        {
            try
            {
                int Verificador = 0;
                Almacen almacen = new Almacen();
                almacen = infoAlmacen;
                almacen.conexion = Comun.conexion;
                almacen.id_u = Comun.id_u;
                AlmacenNegocio almacen_negocio = new AlmacenNegocio();
                this.ObtenerDatos(almacen);
                if (almacen.cantidad <= almacen.existencia)
                {
                    almacen.opcion = 2;
                    almacen_negocio.AbcAlmacen(almacen, ref Verificador);
                    this.VerifcarMensajeAccion(Verificador);
                }
                else
                    MessageBox.Show(this, "Mayor que la cantidad en existencia", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Inicializar()
        {
            try
            {
                this.TxtCantidadActual.Text = infoAlmacen.existencia.ToString();
                this.TxtNombreProducto.Text = infoAlmacen.nombreProducto;
                this.TxtUnidadMedidaProducto.Text = infoAlmacen.NombreUnidadMedida;
                this.TxtNuevaCantidadAlmacen.Text = infoAlmacen.existencia.ToString();
                CargarComboUnidadesMedida(infoAlmacen.id_producto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ObtenerDatos(Almacen almacen)
        {
            try
            {
                almacen.opcion = 2;

                if (decimal.TryParse(this.TxtCantidadIngresar.Text.Trim(), out decimal cantidadMovimiento))
                {
                    almacen.CantidadMovimiento = cantidadMovimiento;
                }
                else
                {
                    almacen.CantidadMovimiento = 0;
                }

                almacen.UnidadMedidaMovimiento = CmbUnidadesMedidas.Text.Trim();

                if (decimal.TryParse(this.TxtCantidadActual.Text.Trim(), out decimal cantidadProducto))
                {
                    almacen.CantidadProducto = cantidadProducto;
                }
                else
                {
                    almacen.CantidadProducto = 0;
                }

                almacen.UnidadMedidaProducto = this.TxtUnidadMedidaProducto.Text.Trim();

                almacen.observaciones = TxtObservaciones.Text.ToString();
                almacen.CantidadConvertida = this.cantidadConvertida;

                if (decimal.TryParse(this.TxtNuevaCantidadAlmacen.Text.Trim(), out decimal cantidadAlmacen))
                {
                    almacen.CantidadAlmacen = cantidadAlmacen;
                }
                else
                {
                    almacen.CantidadAlmacen = 0;
                }

                if (decimal.TryParse(this.TxtFactorConversion.Text.Trim(), out decimal factorConversion))
                {
                    almacen.FactorConversion = factorConversion;
                }
                else
                {
                    almacen.FactorConversion = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private bool ValidarCampos()
        {
            try
            {
                Validaciones Val = new Validaciones();
                string mensajeError = string.Empty;
                if (this.TxtCantidadIngresar.Text.Length == 0)
                {
                    this.TxtCantidadIngresar.Focus();
                    mensajeError += "Escriba la cantidad a agregar." + Environment.NewLine;
                }
                if (string.Equals(this.CmbUnidadesMedidas.SelectedValue.ToString(), "0"))
                {
                    this.CmbUnidadesMedidas.Focus();
                    mensajeError += "Seleccione una unidad de medida para la cantidad a agregar." + Environment.NewLine;
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
        private void VerifcarMensajeAccion(int Verificador)
        {
            try
            {
                if (Verificador == 0)
                {
                    MessageBox.Show(this, "Los datos se guardaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion        
        #region Validaciones
        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloNumerico(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_cantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_cantidad_MouseDown(object sender, MouseEventArgs e)
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
                Val.SoloTexto(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        

        private void frmStockQuitar_Load(object sender, EventArgs e)
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
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (this.ValidarCampos())
                    {
                        this.GuadarAlmacen();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CargarComboUnidadesMedida(string idProducto)
        {
            ConversionNegocio oNegocio = new ConversionNegocio();
            CmbUnidadesMedidas.ValueMember = "id";
            CmbUnidadesMedidas.DisplayMember = "descripcion";
            CmbUnidadesMedidas.DataSource = oNegocio.ObtenerComboXIdProducto(idProducto);
            CmbUnidadesMedidas.SelectedValue = infoAlmacen.IdUnidadMedidaProducto;
        }

        private void CmbUnidadesMedidas_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (CmbUnidadesMedidas.SelectedValue != null)
                {
                    string idUnidadMedida = CmbUnidadesMedidas.SelectedValue.ToString();
                    DataTable dataTable = new DataTable();
                    DataRow[] rows;
                    dataTable = CmbUnidadesMedidas.DataSource as DataTable;
                    rows = dataTable.Select("id = '" + idUnidadMedida + "'");

                    // For each row, print the values of each column.
                    string txtFactorConversion = "0";
                    foreach (DataRow row in rows)
                    {
                        txtFactorConversion = row["factorConversion"].ToString();
                    }
                    TxtFactorConversion.Text = txtFactorConversion.ToString();
                    CalcularNuevaCantidadAlmacen();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void CalcularNuevaCantidadAlmacen()
        {
            decimal cantidadFactorConversion = Convert.ToDecimal(string.IsNullOrEmpty(this.TxtFactorConversion.Text) ? "0" : this.TxtFactorConversion.Text);
            decimal cantidadIngresa = Convert.ToDecimal(string.IsNullOrEmpty(this.TxtCantidadIngresar.Text) ? "0" : this.TxtCantidadIngresar.Text);
            decimal cantidadAlmacen = Convert.ToDecimal(string.IsNullOrEmpty(this.TxtCantidadActual.Text) ? "0" : this.TxtCantidadActual.Text);
            cantidadConvertida = cantidadFactorConversion * cantidadIngresa;
            decimal nuevaCantidadAlmacen = cantidadAlmacen - cantidadConvertida;
            this.TxtNuevaCantidadAlmacen.Text = nuevaCantidadAlmacen.ToString();
        }

        private void TxtCantidadIngresar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void TxtCantidadIngresar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.TxtCantidadIngresar.Text.Trim()))
                {
                    Val = new Validaciones();

                    Val.PermitirSoloNumerosDecimales(e, this.TxtCantidadIngresar.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmStockQuitar ~ TxtCantidadIngresar_KeyPress");
            }
        }

        private void TxtCantidadIngresar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (decimal.TryParse(this.TxtCantidadIngresar.Text.Trim(), out decimal value))
                {
                    CalcularNuevaCantidadAlmacen();
                }
                else
                {
                    this.TxtCantidadIngresar.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmStockQuitar ~ TxtCantidadIngresar_TextChanged");
            }
        }
    }
}
