namespace PuntodeVentaTintoreria
{
    using PuntodeVentaTintoreria.ClaseAux;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.Windows.Forms;
    using TintoreriaGlobal;
    using TintoreriaNegocio;

    public partial class FrmNuevaPromocion : Form
    {
        #region Attributes
        private int TipoForm = 0;
        private Validaciones Val = new Validaciones();
        private Vales _DatosVales;
        public Vales DatosVales
        {
            get { return _DatosVales; }
            set { _DatosVales = value; }
        }
        private List<Sucursal> ListaSucursales = new List<Sucursal>();
        private List<Sucursal> SucursalesXUsuario = new List<Sucursal>();
        private Producto ProductoM = new Producto();
        private Producto ProductoN = new Producto();
        private List<TipoVales> Lista;
        #endregion

        #region Constructors
        public FrmNuevaPromocion()
        {
            InitializeComponent();
            this.TipoForm = 1;
        }
        public FrmNuevaPromocion(Vales Datos)
        {
            try
            {
                InitializeComponent();
                this._DatosVales = Datos;
                
                if (this._DatosVales.FechaInicio == DateTime.MinValue)
                {
                    this._DatosVales.FechaInicio = DateTime.Today;
                }
                if (this._DatosVales.FechaFin == DateTime.MinValue)
                {
                    this._DatosVales.FechaFin = DateTime.Today;
                }

                this.TipoForm = 2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrnNuevaPromocion ~ FrmNuevaPromocion(Vales Datos)");
            }
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
        private void frm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Iniciar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void radioBntRangoFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBntRangoFechas.Checked)
            {
                this.pnlFechaFin.Enabled = true;
                this.pnlFechaInicio.Enabled = true;
                this.pnlFechaFin.Visible = true;
                this.pnlFechaInicio.Visible = true;
                this.PanelRangoFechas.Enabled = true;
                this.PanelDiasSemanas.Enabled = false;
                this.dtpFechaInicio.Enabled = true;
                this.dtpFechaFin.Enabled = true;
                this.radioBntRangoFechas.Checked = true;
                this.radioBtnDiasSemanas.Checked = false;
                this.chkAplicaLunes.Checked = false;
                this.chkAplicaMartes.Checked = false;
                this.chkAplicaMiercoles.Checked = false;
                this.chkAplicaJueves.Checked = false;
                this.chkAplicaViernes.Checked = false;
                this.chkAplicaSabado.Checked = false;
                this.chkAplicaDomingo.Checked = false;
            }
            else
            {
                this.PanelRangoFechas.Enabled = false;
                this.PanelDiasSemanas.Enabled = true;
                this.radioBtnDiasSemanas.Checked = true;
                this.radioBntRangoFechas.Checked = false;
            }
        }
        private void radioBtnDiasSemanas_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnDiasSemanas.Checked)
            {
                pnlFechaFin.Visible = true;
                pnlFechaInicio.Visible = true;
                dtpFechaInicio.Value = DateTime.Today;
                dtpFechaFin.Value = DateTime.Today;
                PanelRangoFechas.Enabled = false;
                PanelDiasSemanas.Enabled = true;
                radioBtnDiasSemanas.Checked = true;
                radioBntRangoFechas.Checked = false;
            }
            else
            {
                pnlFechaFin.Visible = false;
                pnlFechaInicio.Visible = false;
                PanelRangoFechas.Enabled = true;
                PanelDiasSemanas.Enabled = false;
                radioBntRangoFechas.Checked = true;
                radioBtnDiasSemanas.Checked = false;
            }
        }
        private void cmbTipoVale_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (this.cmbTipoVale.SelectedIndex == -1)
                {
                    this.PanelPorcentajePorDia.Enabled = false;
                    this.PanelMontoEfectivo.Enabled = false;
                    this.PanelNxN.Enabled = false;
                    this.PanelMxN.Enabled = false;
                    this.LimpiarDatosVales();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmNuevaPromocion ~ cmbTipoVale_Validating");
            }
        }
        private void TxtSoloAlfanumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloAlfaNumerico(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmNuevaPromocion ~ txtNombreVale_KeyPress");
            }
        }
        private void TxtNumeroPuntoGuionTilde_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.TextoNumerosPuntoGuionTilde(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmNuevaPromocion ~ txtFolioVale_KeyPress");
            }
        }
        private void cmbTipoVale_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmbTipoVale.SelectedIndex != -1)
                {
                    this.LimpiarDatosVales();
                    TipoVales TVale = (TipoVales)this.cmbTipoVale.SelectedItem;
                    if (TVale.Porcentaje)
                    {
                        this.PanelPorcentajePorDia.Enabled = true;
                        this.PanelNxN.BackColor = Color.FromArgb(111, 111, 111);
                        this.PanelMxN.BackColor = Color.FromArgb(111, 111, 111);
                        this.PanelMontoEfectivo.BackColor = Color.FromArgb(111, 111, 111); ;
                        this.PanelPorcentajePorDia.BackColor = Color.FromArgb(179, 207, 73);
                        this.txtPrcentajeDia.Text = string.Format("{0:F2}", 0);
                        this.PanelMontoEfectivo.Enabled = false;
                        this.PanelNxN.Enabled = false;
                        this.PanelMxN.Enabled = false;
                        this.txtPrcentajeDia.Focus();
                    }
                    else if (TVale.Monto)
                    {
                        this.PanelPorcentajePorDia.Enabled = false;
                        this.PanelMontoEfectivo.Enabled = true;
                        this.PanelNxN.BackColor = Color.FromArgb(111, 111, 111);
                        this.PanelMxN.BackColor = Color.FromArgb(111, 111, 111);
                        this.PanelMontoEfectivo.BackColor = Color.FromArgb(179, 207, 73);
                        this.PanelPorcentajePorDia.BackColor = Color.FromArgb(111, 111, 111);
                        this.txtMontoEfectivo.Text = string.Format("{0:C}", 0);
                        this.PanelNxN.Enabled = false;
                        this.PanelMxN.Enabled = false;
                        this.txtMontoEfectivo.Focus();
                    }
                    else if (TVale.NxN)
                    {
                        this.PanelPorcentajePorDia.Enabled = false;
                        this.PanelMontoEfectivo.Enabled = false;
                        this.PanelNxN.Enabled = true;
                        this.PanelNxN.BackColor = Color.FromArgb(179, 207, 73);
                        this.PanelMxN.BackColor = Color.FromArgb(111, 111, 111);
                        this.PanelMontoEfectivo.BackColor = Color.FromArgb(111, 111, 111);
                        this.PanelPorcentajePorDia.BackColor = Color.FromArgb(111, 111, 111);
                        this.txtCantidadRequeridadNxN.Text = "0";
                        this.txtCantidadGratisNxN.Text = "0";
                        this.PanelMxN.Enabled = false;
                    }
                    else if (TVale.NxM)
                    {
                        this.PanelPorcentajePorDia.Enabled = false;
                        this.PanelMontoEfectivo.Enabled = false;
                        this.PanelNxN.Enabled = false;
                        this.PanelMxN.Enabled = true;
                        this.PanelMxN.BackColor = Color.FromArgb(179, 207, 73);
                        this.PanelNxN.BackColor = Color.FromArgb(111, 111, 111);
                        this.PanelMontoEfectivo.BackColor = Color.FromArgb(111, 111, 111);
                        this.PanelPorcentajePorDia.BackColor = Color.FromArgb(111, 111, 111);
                        this.txtCantidadRequeridadMxN.Text = "0";
                        this.txtCantidadGratisMxN.Text = "0";
                    }
                    else
                    {
                        this.PanelPorcentajePorDia.Enabled = false;
                        this.PanelMontoEfectivo.Enabled = false;
                        this.PanelNxN.Enabled = false;
                        this.PanelMxN.Enabled = false;
                        this.PanelMxN.BackColor = Color.FromArgb(111, 111, 111);
                        this.PanelNxN.BackColor = Color.FromArgb(111, 111, 111);
                        this.PanelMontoEfectivo.BackColor = Color.FromArgb(111, 111, 111);
                        this.PanelPorcentajePorDia.BackColor = Color.FromArgb(111, 111, 111);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmNuevaPromocion ~ cmbTipoVale_SelectedValueChanged");
            }
        }
        private void Txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
        private void TxtSoloDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloDecimal(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmNuevaPromocion ~ Txt_KeyPress");
            }
        }
        private void TxtSoloNumerico_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloNumerico(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmNuevaPromocion ~ Txt_KeyPress");
            }
        }
        private void Txt_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void txtMontoEfectivo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                decimal Monto = 0;
                decimal.TryParse(this.txtMontoEfectivo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Monto);
                this.txtMontoEfectivo.Text = string.Format("{0:c}", Monto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmNuevaPromocion ~ txtMontoEfectivo_Validating");
            }
        }
        private void txtPrcentajeDia_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                decimal Monto = 0;
                decimal.TryParse(this.txtMontoEfectivo.Text, out Monto);
                this.txtMontoEfectivo.Text = string.Format("{0:F2}", Monto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmNuevaPromocion ~ txtPrcentajeDia_Validating");
            }
        }
        private void cmbNxNProducto_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cmbNxNProducto.DataSource != null)
                this.ProductoN.id_producto = cmbNxNProducto.SelectedValue.ToString();
        }
        private void txtCantidadRequeridadNxN_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                TextBox Txt = (TextBox)sender;
                int Cantidad = 0;
                int.TryParse(Txt.Text, out Cantidad);
                Txt.Text = Cantidad.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmNuevaPromocion ~ txtCantidadRequeridadNxN_Validating");
            }
        }
        private void cmbMxNProductoM_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cmbMxNProductoM.DataSource != null)
                this.ProductoM.id_producto = cmbMxNProductoM.SelectedValue.ToString();
        }
        private void cmbMxNProductoN_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cmbMxNProductoN.DataSource != null)
                this.ProductoN.id_producto = cmbMxNProductoN.SelectedValue.ToString();
        }
        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    List<Error> Errores = this.ValidarDatos();
                    if (Errores.Count == 0)
                    {
                        Vales Datos = this.ObtenerDatos();
                        Vales_Negocio ValesNeg = new Vales_Negocio();
                        ValesNeg.ABCVales(Datos);
                        if (Datos.Completado)
                        {
                            MessageBox.Show(this, "Datos guardados correctamente.", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this._DatosVales = Datos;
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            if (Datos.Resultado == 51000)
                            {
                                List<Error> LstError = new List<Error>();
                                LstError.Add(new Error { Numero = 1, Descripcion = "El folio ingresado ya existe.", ControlSender = this });
                                this.MostrarMensajeError(LstError);
                            }
                            else
                                MessageBox.Show(this, "Error.", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        this.MostrarMensajeError(Errores);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmNuevaPromocion ~ btnCerrar_Click");
            }
        }
        #endregion

        #region Methods
        private void Iniciar()
        {
            CargarComboTipoVale();
            CargarComboNxNProducto();
            CargarComboMxNProductoN();
            CargarComboMxNProductoM();
        }
        private void CargarComboTipoVale()
        {
            TipoVales DatosTipoVale = new TipoVales { Conexion = Comun.conexion, IncluirSelect = true };
            Vales_Negocio VN = new Vales_Negocio();
            this.Lista = VN.ObtenerComboTipoVales(DatosTipoVale);
            this.cmbTipoVale.ValueMember = "IDTipoVale";
            this.cmbTipoVale.DisplayMember = "Descripcion";
            this.cmbTipoVale.DataSource = this.Lista;
        }
        private void CargarComboNxNProducto()
        {
            ProductoNegocio producto_negocio = new ProductoNegocio();
            Producto productos = new Producto();
            productos.conexion = Comun.conexion;
            this.cmbNxNProducto.DisplayMember = "nombreProducto";
            this.cmbNxNProducto.ValueMember = "id_producto";
            this.cmbNxNProducto.DataSource = producto_negocio.ObtenerComboProductosRopa();
        }
        private void CargarComboMxNProductoN()
        {
            ProductoNegocio producto_negocio = new ProductoNegocio();
            Producto productos = new Producto();
            productos.conexion = Comun.conexion;
            producto_negocio.ObtenerComboProductos(productos);
            this.cmbMxNProductoN.DisplayMember = "nombreProducto";
            this.cmbMxNProductoN.ValueMember = "id_producto";
            this.cmbMxNProductoN.DataSource = productos.datos;
            
        }
        private void CargarComboMxNProductoM()
        {
            ProductoNegocio producto_negocio = new ProductoNegocio();
            Producto productos = new Producto();
            productos.conexion = Comun.conexion;
            producto_negocio.ObtenerComboProductos(productos);
            this.cmbMxNProductoM.DisplayMember = "nombreProducto";
            this.cmbMxNProductoM.ValueMember = "id_producto";
            this.cmbMxNProductoM.DataSource = productos.datos;

            if (TipoForm == 2)
                this.CargarDatosAModificar();
            else
            {

                this.dtpFechaInicio.Value = DateTime.Today;
                this.dtpFechaFin.Value = DateTime.Today;
            }

            this.ActiveControl = this.txtNombreVale;
            this.txtNombreVale.Focus();
        }
        private void CargarDatosAModificar()
        {
            try
            {
                this.txtNombreVale.Text = this._DatosVales.Nombre;
                this.txtFolioVale.Enabled = true;
                this.txtFolioVale.Text = this._DatosVales.Folio;
                this.txtCantidadLimite.Text = this._DatosVales.CantLimite.ToString();
                this.chkAbiertoPublico.Enabled = false;
                this.chkAbiertoPublico.Checked = this._DatosVales.Abierto;
                this.cmbTipoVale.Enabled = false;
                if (this.ExisteItemEnCombo(this._DatosVales.IDTipoVale))
                    this.cmbTipoVale.SelectedValue = this._DatosVales.IDTipoVale;
                this.LimpiarDatosVales();
                switch (this._DatosVales.IDTipoVale)
                {
                    case 1:
                        this.txtPrcentajeDia.Text = string.Format("{0:F2}", this._DatosVales.Porcentaje);
                        break;
                    case 2:
                        this.txtMontoEfectivo.Text = string.Format("{0:c}", this._DatosVales.Monto);
                        break;
                    case 3:
                        this.ProductoN = this._DatosVales.ProductoRequerido;
                        this.cmbNxNProducto.Text = this.ProductoN.nombreProducto;
                        this.txtCantidadRequeridadNxN.Text = this._DatosVales.CantidadRequeridaNxN.ToString();
                        this.txtCantidadGratisNxN.Text = this._DatosVales.CantidadGratisNxN.ToString();
                        break;
                    case 4:
                        this.ProductoM = this._DatosVales.ProductoRequerido;
                        this.cmbMxNProductoM.Text = this.ProductoM.nombreProducto;
                        this.txtCantidadRequeridadMxN.Text = this._DatosVales.CantRequeridad.ToString();
                        this.ProductoN = this._DatosVales.ProductoGratis;
                        this.cmbMxNProductoN.Text = this.ProductoN.nombreProducto;
                        this.txtCantidadGratisMxN.Text = this._DatosVales.CantGratis.ToString();
                        break;
                }
                this.radioBntRangoFechas.Enabled = false;
                this.radioBtnDiasSemanas.Enabled = false;
                if (this._DatosVales.RequierePeriodo)
                {
                    this.radioBntRangoFechas.Checked = true;
                    this.PanelRangoFechas.Enabled = true;
                    this.pnlFechaInicio.Visible = false;
                    this.pnlFechaFin.Visible = false;
                    this.dtpFechaInicio.Value = this._DatosVales.FechaInicio;
                    this.dtpFechaFin.Value = this._DatosVales.FechaFin;
                    this.pnlFechaInicio.Visible = true;
                    this.pnlFechaInicio.Enabled = true;
                    this.pnlFechaFin.Visible = true;
                    this.pnlFechaFin.Enabled = true;
                    this.dtpFechaInicio.Enabled = true;
                    this.dtpFechaFin.Enabled = true;
                }
                else
                {
                    this.radioBtnDiasSemanas.Checked = true;
                    this.PanelDiasSemanas.Enabled = true;
                    this.chkAplicaLunes.Checked = this._DatosVales.Lunes;
                    this.chkAplicaMartes.Checked = this._DatosVales.Martes;
                    this.chkAplicaMiercoles.Checked = this._DatosVales.Miercoles;
                    this.chkAplicaJueves.Checked = this._DatosVales.Jueves;
                    this.chkAplicaViernes.Checked = this._DatosVales.Viernes;
                    this.chkAplicaSabado.Checked = this._DatosVales.Sabado;
                    this.chkAplicaDomingo.Checked = this._DatosVales.Domingo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private bool ExisteItemEnCombo(int ID)
        {
            try
            {
                bool Band = false;
                foreach (TipoVales Item in this.cmbTipoVale.Items)
                {
                    if (Item.IDTipoVale == ID)
                    {
                        Band = true;
                        break;
                    }
                }
                return Band;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LimpiarDatosVales()
        {
            try
            {
                this.ProductoN = new Producto();
                this.ProductoM = new Producto();
                this.cmbNxNProducto.SelectedValue = "0";
                this.cmbMxNProductoM.SelectedValue = "0";
                this.cmbMxNProductoN.SelectedValue = "0";
                this.txtCantidadRequeridadNxN.Text = string.Empty;
                this.txtCantidadGratisNxN.Text = string.Empty;
                this.txtCantidadRequeridadMxN.Text = string.Empty;
                this.txtCantidadGratisMxN.Text = string.Empty;
                this.txtMontoEfectivo.Text = string.Empty;
                this.txtPrcentajeDia.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private List<Error> ValidarDatos()
        {
            try
            {
                List<Error> Errores = new List<Error>();
                int Aux = 0;
                //Validar TextBox Nombre del Vale
                if (string.IsNullOrEmpty(this.txtNombreVale.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el Nombre del Vale.", ControlSender = this.txtNombreVale });
                if (string.IsNullOrEmpty(this.txtFolioVale.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el Folio del Vale.", ControlSender = this.txtFolioVale });
                if (this.cmbTipoVale.SelectedIndex == -1)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción en Tipo de Vales.", ControlSender = this.cmbTipoVale });
                else
                {
                    TipoVales TVale = (TipoVales)this.cmbTipoVale.SelectedItem;
                    if (TVale.IDTipoVale != 0)
                    {
                        //Validar Datos del PanelPorcentajePorDia
                        if (TVale.Porcentaje)
                        {
                            if (string.IsNullOrEmpty(this.txtPrcentajeDia.Text.Trim()))
                                Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el Porcentaje de descuento.", ControlSender = this.txtPrcentajeDia });
                            else
                            {
                                decimal Porcentaje = this.ObtenerPorcentaje();
                                if (Porcentaje <= 0)
                                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "El porcentaje de descuento debe ser mayor a 0%.", ControlSender = this.txtPrcentajeDia });
                                else if (Porcentaje > 100)
                                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "El porcentaje de descuento no puede ser mayor a 100%.", ControlSender = this.txtPrcentajeDia });
                            }
                        }
                        //Validar Datos del PanelMontoEfectivo
                        if (TVale.Monto)
                        {
                            if (string.IsNullOrEmpty(this.txtMontoEfectivo.Text.Trim()))
                                Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese el Monto en Efectivo.", ControlSender = this.txtMontoEfectivo });
                            else
                            {
                                decimal Monto = this.ObtenerMontoDescuento();
                                if (Monto <= 0)
                                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "El monto de descuento debe ser mayor a $ 0.00.", ControlSender = this.txtMontoEfectivo });
                            }
                        }
                        //Validar Datos del PanelNxN
                        if (TVale.NxN)
                        {
                            if (string.IsNullOrEmpty(ProductoN.id_producto) || ProductoN.id_producto == "0")
                                Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione el producto requerido para la promoción.", ControlSender = this.cmbNxNProducto });
                            if (string.IsNullOrEmpty(this.txtCantidadRequeridadNxN.Text.Trim()))
                                Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la Cantidad Requerida en N x N.", ControlSender = this.PanelNxN });
                            if (string.IsNullOrEmpty(this.txtCantidadGratisNxN.Text.Trim()))
                                Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la Cantidad Gratis en N x N.", ControlSender = this.PanelNxN });
                            if (!string.IsNullOrEmpty(this.txtCantidadRequeridadNxN.Text.Trim()) && !string.IsNullOrEmpty(this.txtCantidadGratisNxN.Text.Trim()))
                            {
                                int CantidadReq = 0, CantidadGratis = 0;
                                CantidadReq = this.ObtenerCantidad(this.txtCantidadRequeridadNxN);
                                CantidadGratis = this.ObtenerCantidad(this.txtCantidadGratisNxN);
                                if (CantidadReq <= 0)
                                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Cantidad Requerida debe ser mayor a 0", ControlSender = this.txtCantidadRequeridadNxN });
                                if (CantidadGratis <= 0)
                                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Cantidad Gratis debe ser mayor a 0.", ControlSender = this.txtCantidadGratisNxN });
                                //if (CantidadReq > 0 && CantidadGratis > 0)
                                //{
                                //    if (CantidadGratis >= CantidadReq)
                                //        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Cantidad Gratis debe ser menor a la cantidad requerida.", ControlSender = this.txtCantidadGratisNxN });
                                //}
                            }
                        }
                        //Validar Datos del PanelMxN
                        if (TVale.NxM)
                        {
                            if (string.IsNullOrEmpty(ProductoM.id_producto) || ProductoM.id_producto == "0")
                                Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione el producto requerido para la promoción.", ControlSender = this.cmbMxNProductoM });
                            if (string.IsNullOrEmpty(ProductoN.id_producto) || ProductoN.id_producto == "0")
                                Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione el producto gratis para la promoción.", ControlSender = this.cmbMxNProductoN });
                            if (string.IsNullOrEmpty(this.txtCantidadRequeridadMxN.Text.Trim()))
                                Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la Cantidad Requerida en M x N.", ControlSender = this.PanelMxN });
                            if (string.IsNullOrEmpty(this.txtCantidadGratisMxN.Text.Trim()))
                                Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la Cantidad Gratis en M x N.", ControlSender = this.PanelMxN });
                            if (!string.IsNullOrEmpty(this.txtCantidadRequeridadMxN.Text.Trim()) && !string.IsNullOrEmpty(this.txtCantidadGratisMxN.Text.Trim()))
                            {
                                int CantidadReq2 = 0, CantidadGratis2 = 0;
                                CantidadReq2 = this.ObtenerCantidad(this.txtCantidadRequeridadMxN);
                                CantidadGratis2 = this.ObtenerCantidad(this.txtCantidadGratisMxN);
                                if (CantidadReq2 <= 0)
                                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Cantidad Requerida debe ser mayor a 0", ControlSender = this.txtCantidadRequeridadMxN });
                                if (CantidadGratis2 <= 0)
                                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Cantidad Gratis debe ser mayor a 0.", ControlSender = this.txtCantidadGratisMxN });
                                if (CantidadReq2 > 0 && CantidadGratis2 > 0)
                                {
                                    if (CantidadGratis2 >= CantidadReq2)
                                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Cantidad Gratis debe ser menor a la cantidad requerida.", ControlSender = this.txtCantidadGratisMxN });
                                }
                            }
                        }
                    }
                    else
                    {
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Seleccione una opción en Tipo Vale.", ControlSender = this.cmbTipoVale });
                    }
                }
                //Validar TextBox Cantidad Limite
                if (string.IsNullOrEmpty(this.txtCantidadLimite.Text.Trim()))
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Ingrese la Cantidad Limite.", ControlSender = this.txtCantidadLimite });
                else
                {
                    if (!Validaciones.IsValidOnlyNumber(this.txtCantidadLimite.Text.Trim()))
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe ingresar el Cantidad Limite válido.", ControlSender = this.txtCantidadLimite });
                }

                //Validar RadioButton Para Seleccionar
                if (!this.radioBntRangoFechas.Checked && !this.radioBtnDiasSemanas.Checked)
                    Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar Rango de Fecha ó Dias de la Semana", ControlSender = this.PanelDiasSemanas });
                //Validar RadioButton Fecha Inicio y Fecha Fin
                if (this.radioBntRangoFechas.Checked)
                {
                    if (this.dtpFechaInicio.Value > this.dtpFechaFin.Value)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La Fecha Final debe ser mayor a la Fecha Inicial", ControlSender = this.PanelRangoFechas });
                    if (this.dtpFechaInicio.Value < DateTime.Today)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "La Fechas deben ser mayores a la Fecha Actual.", ControlSender = this.PanelRangoFechas });
                }
                //Validar RadioButton Para Seleccionar Dias de las Semana
                if (this.radioBtnDiasSemanas.Checked)
                {
                    if (!this.chkAplicaLunes.Checked
                           && !this.chkAplicaMartes.Checked
                           && !this.chkAplicaMiercoles.Checked
                           && !this.chkAplicaJueves.Checked
                           && !this.chkAplicaViernes.Checked
                           && !this.chkAplicaSabado.Checked
                           && !this.chkAplicaDomingo.Checked)
                        Errores.Add(new Error { Numero = (Aux += 1), Descripcion = "Debe seleccionar al menos un Día de la Semana", ControlSender = this.PanelDiasSemanas });
                }
                return Errores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private decimal ObtenerPorcentaje()
        {
            try
            {
                decimal Porcentaje = 0;
                decimal.TryParse(this.txtPrcentajeDia.Text, out Porcentaje);
                return Porcentaje;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private decimal ObtenerMontoDescuento()
        {
            try
            {
                decimal Monto = 0;
                decimal.TryParse(this.txtMontoEfectivo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Monto);
                return Monto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private int ObtenerCantidad(TextBox txtCantidad)
        {
            try
            {
                int Cantidad = 0;
                int.TryParse(txtCantidad.Text, out Cantidad);
                return Cantidad;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private Vales ObtenerDatos()
        {
            try
            {
                Vales DatosAux = new Vales();
                TipoVales AuxTV = this.ObtenerTipoValesSeleccionado();
                int CantidadLimite = 0, CantidadRequeridaNxN = 0, CantidadGratisNxN = 0, CantidadRequeridaMxN = 0, CantidadGratisMxN = 0;
                decimal Monto = 0, Porcentaje = 0;
                DatosAux.IDVale = TipoForm == 2 ? this._DatosVales.IDVale : string.Empty;
                DatosAux.IDTipoVale = Convert.ToInt32(this.cmbTipoVale.SelectedValue.ToString());
                DatosAux.NombreTipoVale = AuxTV.Descripcion;
                DatosAux.Nombre = this.txtNombreVale.Text.Trim();
                DatosAux.Folio = this.txtFolioVale.Text.Trim();
                int.TryParse(this.txtCantidadLimite.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out CantidadLimite);
                decimal.TryParse(this.txtMontoEfectivo.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Monto);
                decimal.TryParse(this.txtPrcentajeDia.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out Porcentaje);
                DatosAux.CantLimite = CantidadLimite;
                DatosAux.Monto = Monto;
                DatosAux.Porcentaje = Porcentaje;
                DatosAux.Abierto = this.chkAbiertoPublico.Checked;
                DatosAux.RangoFechas = this.radioBntRangoFechas.Checked;

                int.TryParse(this.txtCantidadRequeridadNxN.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out CantidadRequeridaNxN);
                int.TryParse(this.txtCantidadGratisNxN.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out CantidadGratisNxN);
                DatosAux.IDProductoNxN = this.ProductoN.id_producto;
                DatosAux.CantidadRequeridaNxN = CantidadRequeridaNxN;
                DatosAux.CantidadGratisNxN = CantidadGratisNxN;

                int.TryParse(this.txtCantidadRequeridadMxN.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out CantidadRequeridaMxN);
                int.TryParse(this.txtCantidadGratisMxN.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out CantidadGratisMxN);
                DatosAux.IDProductoRequerido = this.ProductoM.id_producto;
                DatosAux.IDProductoGratis = this.ProductoN.id_producto;
                DatosAux.CantRequeridad = CantidadRequeridaMxN;
                DatosAux.CantGratis = CantidadGratisMxN;
                DatosAux.FechaInicio = this.dtpFechaInicio.Value;
                DatosAux.FechaFin = this.dtpFechaFin.Value;
                DatosAux.Lunes = this.chkAplicaLunes.Checked;
                DatosAux.Martes = this.chkAplicaMartes.Checked;
                DatosAux.Miercoles = this.chkAplicaMiercoles.Checked;
                DatosAux.Jueves = this.chkAplicaJueves.Checked;
                DatosAux.Viernes = this.chkAplicaViernes.Checked;
                DatosAux.Sabado = this.chkAplicaSabado.Checked;
                DatosAux.Domingo = this.chkAplicaDomingo.Checked;
                DatosAux.Opcion = this.TipoForm;
                DatosAux.Conexion = Comun.conexion;
                DatosAux.IDUsuario = Comun.id_u;
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private TipoVales ObtenerTipoValesSeleccionado()
        {
            try
            {
                TipoVales DatosAux = new TipoVales();
                if (this.cmbTipoVale.SelectedIndex != -1)
                {
                    DatosAux = (TipoVales)this.cmbTipoVale.SelectedItem;
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void MostrarMensajeError(List<Error> Errores)
        {
            try
            {
                string cadenaErrores = string.Empty;
                cadenaErrores = "No se pudo guardar la información. Se presentaron los siguientes errores: \r\n";
                foreach (Error item in Errores)
                {
                    cadenaErrores += item.Numero + "\t" + item.Descripcion + "\r\n";
                }
                MessageBox.Show(this, cadenaErrores, Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
