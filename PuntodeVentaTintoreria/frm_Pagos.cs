using PuntodeVentaTintoreria.ClaseAux;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using TintoreriaGlobal;

namespace PuntodeVentaTintoreria
{
    public partial class frm_Pagos : Form
    {
        #region Variables

        private int op;
        private Validaciones Val;
        private CultureInfo provider = CultureInfo.CurrentCulture;
        private bool banSalir = false;
        private decimal Total = 0;
        private decimal TotalPagar = 0;
        private decimal PagoEfectivo = 0;
        private decimal PagoMonedero = 0;
        private decimal PagoTarjeta = 0;
        private decimal PagoTransferencia = 0;
        private FormaPago DatosTarjeta = new FormaPago();
        private FormaPago DatosTransferencia = new FormaPago();
        private decimal Cambio = 0;
        private decimal Pendiente = 0;
        private decimal MonederoCliente = 0;
        private decimal NuevoMontoMonedero = 0;
        private string Cliente;
        private bool Pagopedido;
        //private int SegundosTiempoVenta = 0;
        private DateTime TiempoVenta = DateTime.Parse(DateTime.Now.ToShortDateString(), CultureInfo.CurrentCulture);
        //private bool _stopTiempoVenta = false;
        private int TipoForm = 0;

        #endregion

        public frm_Pagos(decimal total, decimal pagar, decimal pendiente, decimal monederoCliente, string cliente, decimal nuevoMontoMonedero, int opcion)
        {
            try
            {
                InitializeComponent();
                Total = total;
                TotalPagar = pagar;
                MonederoCliente = monederoCliente;
                Cliente = cliente;
                NuevoMontoMonedero = nuevoMontoMonedero;
                Pendiente = pendiente;
                Pagopedido = false;
                op = opcion;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        public frm_Pagos(decimal total, decimal pagar, decimal pendiente, decimal monederoCliente, string cliente, decimal nuevoMontoMonedero, bool pedido)
        {
            try
            {
                InitializeComponent();
                Total = total;
                TotalPagar = pagar;
                MonederoCliente = monederoCliente;
                Cliente = cliente;
                NuevoMontoMonedero = nuevoMontoMonedero;
                Pendiente = pendiente;
                Pagopedido = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }



        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /*****************************************************************************************************************************/

        private void frm_Pagos_Load(object sender, EventArgs e)
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
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmPago ~ frmCatCobroMultiFormasPago_Load");
            }

        }


        #region Métodos Generales

        private void Inicializar()
        {
            try
            {
                this.Txt_Total.Text = string.Format("{0:c}", Total);
                this.Txt_Pagar.Text = string.Format("{0:c}", TotalPagar);
                this.Txt_Pendiente.Text = string.Format("{0:c}", Pendiente);
                this.Txt_PagoEfectivo.Text = string.Format("{0:c}", PagoEfectivo);
                this.txtPagoTarjeta.Text = string.Format("{0:c}", PagoEfectivo);
                this.Txt_PagoMonedero.Text = string.Format("{0:c}", PagoMonedero);
                this.txtPagoTransferencia.Text = string.Format("{0:c}", PagoTransferencia);
                this.Txt_Cambio.Text = string.Format("{0:c}", Cambio);
                this.TxtNombreCliente.Text = this.Cliente;
                this.Txt_NewMonedero.Text = string.Format("{0:c}", NuevoMontoMonedero);
                this.Txt_Monedero.Text = string.Format("{0:c}", MonederoCliente);
                if (MonederoCliente > 0)
                {
                    this.Txt_PagoMonedero.ReadOnly = false;
                }
                else
                {
                    this.Txt_PagoMonedero.ReadOnly = true;
                }
                this.DrawCambio();
                if (this.TipoForm == 1)
                {
                    this.Txt_PagoEfectivo.Enabled = false;
                    this.Txt_PagoMonedero.Enabled = false;
                    this.txtPagoTarjeta.Enabled = false;
                    this.chkTarjeta.Enabled = false;
                }
                else
                {
                    this.ActiveControl = this.Txt_PagoEfectivo;
                    this.Txt_PagoEfectivo.Focus();
                    this.Txt_PagoEfectivo.SelectAll();
                }
                if (Pendiente > 0)
                {
                    this.chkTarjeta.Enabled = false;
                    this.chkTransferencia.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private decimal ObtenerPagoEfectivo()
        {
            try
            {
                decimal pEfect = 0;
                decimal.TryParse(this.Txt_PagoEfectivo.Text, NumberStyles.Currency, provider, out pEfect);
                return pEfect;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        private decimal ObtenerPagoMonedero()
        {
            try
            {
                decimal pMoned = 0;
                decimal.TryParse(this.Txt_PagoMonedero.Text, NumberStyles.Currency, provider, out pMoned);
                return pMoned;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        private decimal ObtenerPagoTarjeta()
        {
            try
            {
                decimal pTarjeta = 0;
                decimal.TryParse(this.txtPagoTarjeta.Text, NumberStyles.Currency, provider, out pTarjeta);
                return pTarjeta;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        private decimal ObtenerPagoTotal()
        {
            try
            {
                return this.ObtenerPagoEfectivo()
                    + this.ObtenerPagoMonedero()
                    + this.ObtenerPagoTarjeta()
                    + this.ObtenerPagoTransferencia();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        private decimal ObtenerPagoTransferencia()
        {
            try
            {
                decimal pTransferencia = 0;
                decimal.TryParse(this.txtPagoTransferencia.Text, NumberStyles.Currency, provider, out pTransferencia);
                return pTransferencia;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        private decimal ObtenerCambio()
        {
            try
            {
                return TotalPagar - this.GetTotalPago();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        private decimal GetTotalPago()
        {
            try
            {
                return this.ObtenerPagoEfectivo() + this.ObtenerPagoMonedero() + this.ObtenerPagoTarjeta() + this.ObtenerPagoTransferencia();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        private bool ValidarFormasDePago()
        {

            decimal PagoTotal = this.ObtenerPagoTotal();
            decimal PagoEfectivo = this.ObtenerPagoEfectivo();
            if ((PagoTotal - PagoEfectivo) > TotalPagar)
                return false;
            else
                return true;

        }
        private bool ValidarPagoMonedero(decimal pagoMon)
        {

            bool resultado = false;
            if (pagoMon > MonederoCliente)
                resultado = false;
            else
                resultado = true;
            return resultado;

        }
        private void DrawCambio()
        {
            try
            {
                decimal cambioPago = 0;
                cambioPago = this.ObtenerCambio();
                if (cambioPago <= 0)
                {
                    this.pnl_cambio.BackColor = Color.MediumSpringGreen;
                    this.Txt_Cambio.BackColor = Color.MediumSpringGreen;
                    this.Txt_Cambio.Text = string.Format("{0:c}", cambioPago * -1);// this.Txt_Cambio.Text = string.Format("{0:c}", cambioPago * -1);
                    this.label9.Text = "CAMBIO";
                }
                else
                {
                    this.pnl_cambio.BackColor = Color.OrangeRed;
                    this.Txt_Cambio.BackColor = Color.OrangeRed;
                    this.Txt_Cambio.Text = string.Format("{0:c}", cambioPago);
                    this.label9.Text = "  DEBE";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ObtenerDatos()
        {
            try
            {
                this.PagoMonedero = this.ObtenerPagoMonedero();
                this.PagoTarjeta = this.ObtenerPagoTarjeta();
                this.PagoTransferencia = this.ObtenerPagoTransferencia();
                this.PagoEfectivo = this.ObtenerPagoEfectivo();
                this.Cambio = this.ObtenerCambio();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #region Métodos ObtenerPropiedades
        public decimal getPago()
        {
            return (PagoEfectivo + PagoMonedero + PagoTarjeta + PagoTransferencia);
        }
        public decimal getPagoMonedero()
        {
            return (PagoMonedero);
        }
        public decimal getPagoEfectivo()
        {
            decimal PagoTotal = this.ObtenerPagoTotal();
            decimal PagoEfectivo = this.ObtenerPagoEfectivo();
            return (PagoTotal - PagoEfectivo - TotalPagar) * -1;
        }
        public decimal getPagoTarjeta()
        {
            return PagoTarjeta;
        }
        public decimal getPagoTransferencia()
        {
            return PagoTransferencia;
        }
        public decimal getCambio()
        {
            return Cambio;
        }
        public decimal getTotalPagar()
        {
            return TotalPagar;
        }
        public bool getbanSalir()
        {
            return banSalir;
        }
        public decimal getPendiente()
        {
            return Pendiente;
        }
        public FormaPago getDatosTarjeta()
        {
            return DatosTarjeta;
        }
        public FormaPago getDatosTransferencia()
        {
            return DatosTransferencia;
        }
        #endregion

        #endregion
        #region Eventos
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCatCobroMultiFormasPago ~ btn_Cancelar_Click");
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btn_Cobrar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (this.ValidarFormasDePago())
                    {
                        if (ValidarPagoMonedero(ObtenerPagoMonedero()))
                        {
                            /* if (Pagopedido)
                             {
                                 if (this.GetTotalPago() >= (TotalPagar*0.10))
                                 {
                                     this.ObtenerDatos();
                                     this.DialogResult = DialogResult.OK;
                                 }
                                 else
                                 {
                                     MessageBox.Show(this, "Debe Cubrir al menos el 10% del monto total", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                 }
                             }
                             else*/

                            if (op == 1)
                            {
                                if (this.GetTotalPago() >= TotalPagar)
                                {
                                    this.ObtenerDatos();
                                    this.DialogResult = DialogResult.OK;
                                }
                                else
                                {
                                    MessageBox.Show(this, "Debe Cubrir el monto a pagar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {

                                if (this.GetTotalPago() > 0)
                                {
                                    this.ObtenerDatos();
                                    this.DialogResult = DialogResult.OK;
                                }
                                else
                                {
                                    MessageBox.Show(this, "Debe indicar un monto mayo a cero", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                            }


                        }
                        else
                        {
                            MessageBox.Show(this, "Ingrese un monto Monedero válido", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "La suma de pago Monedero, pago Tarjeta y pago Transferencia no debe ser mayor al total a pagar.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCatCobroMultiFormasPago ~ btn_Cobrar_Click");
            }
        }

        private void Txt_PagoEfectivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                Val = new Validaciones();
                Val.PermitirSoloNumerosDecimales(e, txt.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCatCobroMultiFormasPago ~ Txt_KeyPress");
            }
        }

        private void Txt_PagoEfectivo_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                this.DrawCambio();
                if (e.KeyCode == Keys.Enter)
                {
                    //if ((PagoEfectivo + PagoMonedero) >= TotalPagar)
                    //{
                    //    this.DialogResult = DialogResult.Cancel;
                    //}
                    //else
                    //{
                    //    MessageBox.Show(this,"Debe Cubrir el monto a pagar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCatCobroMultiFormasPago ~ Txt_Pago_KeyUp");
            }
        }

        private void Txt_PagoEfectivo_Click(object sender, EventArgs e)
        {
            try
            {
                TextBox aux = (TextBox)sender;
                this.ActiveControl = aux;
                aux.Focus();
                aux.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCatCobroMultiFormasPago ~ Txt_PagoEfectivo_Enter");
            }
        }

        private void Txt_PagoEfectivo_Enter(object sender, EventArgs e)
        {
            try
            {
                TextBox aux = (TextBox)sender;
                this.ActiveControl = aux;
                aux.Focus();
                aux.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCatCobroMultiFormasPago ~ Txt_PagoEfectivo_Enter");
            }
        }

        private void Txt_PagoEfectivo_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                decimal aux = 0;
                decimal.TryParse(txt.Text, NumberStyles.Currency, provider, out aux);
                txt.Text = string.Format("{0:c}", aux);
                this.DrawCambio();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCatCobroMultiFormasPago ~ Txt_PagoEfectivo_Validating");
            }
        }

        private void chkTransferencia_OnChange(object sender, EventArgs e)
        {
            try
            {
                if (this.chkTransferencia.Checked)
                {
                    this.DatosTransferencia.monto = TotalPagar;
                    frm_DatosPagoTransferencia dt = new frm_DatosPagoTransferencia(DatosTransferencia, 0);
                    dt.ShowDialog();
                    dt.Dispose();
                    if (dt.DialogResult == DialogResult.OK)
                    {
                        this.DatosTransferencia = dt.datos;
                        this.PagoTransferencia = DatosTransferencia.monto;
                        this.txtPagoTransferencia.Text = string.Format("{0:c}", DatosTransferencia.monto);
                        this.DrawCambio();
                    }
                    else
                    {
                        this.txtPagoTransferencia.Text = string.Format("{0:c}", 0);
                        this.PagoTransferencia = 0;
                        this.DatosTransferencia = new FormaPago();
                        this.DrawCambio();
                        this.chkTransferencia.Checked = false;
                    }
                }
                else
                {
                    this.txtPagoTransferencia.Text = string.Format("{0:c}", 0);
                    this.PagoTransferencia = 0;
                    this.DatosTransferencia = new FormaPago();
                    this.DrawCambio();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmPago ~ chkTransferencia_CheckedChanged");
            }
        }


        private void chkTarjeta_OnChange(object sender, EventArgs e)
        {
            try
            {
                if (this.chkTarjeta.Checked)
                {
                    this.DatosTarjeta.monto = TotalPagar;
                    frm_DatosPagoTarjeta dt = new frm_DatosPagoTarjeta(DatosTarjeta, 0);
                    dt.ShowDialog();
                    dt.Dispose();
                    if (dt.DialogResult == DialogResult.OK)
                    {
                        this.DatosTarjeta = dt.datos;
                        this.PagoTarjeta = DatosTarjeta.monto;
                        this.txtPagoTarjeta.Text = string.Format("{0:c}", DatosTarjeta.monto);
                        this.DrawCambio();
                    }
                    else
                    {
                        this.txtPagoTarjeta.Text = string.Format("{0:c}", 0);
                        this.PagoTarjeta = 0;
                        this.DatosTarjeta = new FormaPago();
                        this.DrawCambio();
                        this.chkTarjeta.Checked = false;
                    }
                }
                else
                {
                    this.txtPagoTarjeta.Text = string.Format("{0:c}", 0);
                    this.PagoTarjeta = 0;
                    this.DatosTarjeta = new FormaPago();
                    this.DrawCambio();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmPago ~ chkTarjeta_CheckedChanged");

            }
        }




        #endregion

        #region Nuevo metodos
        public decimal getNewPagoEfectivo()
        {
            decimal pagoEfectivo = ObtenerPagoEfectivo();
            return pagoEfectivo;
        }
        #endregion

    }
}
