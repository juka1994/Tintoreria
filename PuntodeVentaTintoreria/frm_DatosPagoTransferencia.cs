using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TintoreriaGlobal;
using TintoreriaNegocio;

using System.Collections;

using PuntodeVentaTintoreria.ClaseAux;
using System.Management;

namespace PuntodeVentaTintoreria
{
    public partial class frm_DatosPagoTransferencia : Form
    {

        #region Variables
        private FormaPago _datos;
        public FormaPago datos
        {
            get { return _datos; }
            set { _datos = value; }
        }

        int opcion = 0;
        #endregion

        public frm_DatosPagoTransferencia()
        {
            InitializeComponent();

        }

        public frm_DatosPagoTransferencia(FormaPago fp, int op)
        {
            InitializeComponent();
            datos = fp;
            opcion = op;
            this.CargarDatos();
        }


        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }









        /*********************************************************************************************************************/

      
        #region Constructor/Load
       
        private void frm_DatosPagoTransferencia_Load(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.CargarComboBancos();
                    this.ActiveControl = this.txtNumCheque;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
            }
        }
        #endregion


        #region Métodos Generales
        private void CargarComboBancos()
        {
            try
            {
                BancoNegocio bn = new BancoNegocio();
                Banco datos = new Banco();
                datos.conexion = Comun.conexion;
                List<Banco> bancos = bn.llenarComboBancos(datos);
                this.cmbBancos.DisplayMember = "nombreBanco";
                this.cmbBancos.ValueMember = "idBanco";
                this.cmbBancos.DataSource = bancos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void CargarDatos()
        {
            try
            {
                if (opcion == 1)
                {
                    if (datos != null)
                    {
                        this.txtNumCheque.Text = datos.numCheque;
                        this.cmbBancos.SelectedItem = datos.banco;
                        this.txtMonto.Text = string.Format("{0:F2}", datos.monto);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private Hashtable ValidarDatos()
        {
            try
            {
                Hashtable errores = new Hashtable();
                if (this.cmbBancos.SelectedIndex == -1)
                    errores.Add(1, "Seleccione una banco de la lista. ");
                else
                {
                    Banco banco = new Banco();
                    banco = (Banco)this.cmbBancos.SelectedItem;
                    if (banco.idBanco == 0)
                        errores.Add(1, "Seleccione una banco de la lista. ");
                }
                if (string.IsNullOrEmpty(this.txtNumCheque.Text))
                    errores.Add(2, "Ingrese el número de autorización. ");
                decimal monto = 0;
                decimal.TryParse(this.txtMonto.Text, out monto);
                if (monto <= 0)
                    errores.Add(4, "Ingrese un monto válido mayor a " + string.Format("{0:c}", 0) + ".");
                else
                    if (opcion == 0)
                {
                    if (monto > datos.monto)
                    {
                        errores.Add(4, "Ingrese un monto menor a " + string.Format("{0:c}", datos.monto) + ".");
                    }
                }
                if (this.ValidarFolioTransaccion())
                    errores.Add(5, "El folio de transacción ya ha sido ingresado previamente. Verifique la información.");
                return errores;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private void MostrarMensajeError(Hashtable errores)
        {
            try
            {
                string cadenaErrores = string.Empty;
                cadenaErrores = "No se pudo guardar la información. Se presentaron los siguientes errores: \r\n";
                int aux = 1;
                foreach (DictionaryEntry de in errores)
                {
                    Console.WriteLine("\t{0}:\t{1}", de.Key, de.Value);
                    cadenaErrores += aux + "\t" + de.Value + "\r\n"; ;
                    aux++;
                }
                this.panelNotifi.Visible = true;
                this.txt_mensaje.Visible = true;
                //this.picAlerta.Visible = true;
                this.txt_mensaje.Text = cadenaErrores;
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
                if (this.cmbBancos.SelectedIndex == -1)
                    datos.banco = new Banco();
                else
                {
                    Banco banco = new Banco();
                    banco = (Banco)this.cmbBancos.SelectedItem;
                    if (banco.idBanco == 0)
                        datos.banco = new Banco();
                    else
                        datos.banco = banco;
                }
                if (string.IsNullOrEmpty(this.txtNumCheque.Text))
                    datos.autorizacion = string.Empty;
                else
                    datos.autorizacion = this.txtNumCheque.Text;
                decimal monto = 0;
                decimal.TryParse(this.txtMonto.Text, out monto);
                datos.monto = monto;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private bool ValidarFolioTransaccion()
        {
            try
            {
                Busqueda datos = new Busqueda();
                datos.strcnx = Comun.conexion;
                BusquedaNegocio bn = new BusquedaNegocio();
                datos = bn.ValidarFolioTransferencia(this.txtNumCheque.Text, datos.strcnx);
                return datos.Validador;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        #endregion
        #region Validaciones
     
        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)13)
                {
                    this.btnAceptar_Click(null, null);
                }
                else
                {
                    Validaciones val = new Validaciones();
                    val.PermitirSoloNumerosDecimales(e, this.txtMonto.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmDatosTransferencia_Bunifu ~ txtMonto_KeyPress");
            }
        }

        private void txtNumCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)13)
                {
                    this.cmbBancos.Focus();
                }
                else
                {
                    Validaciones val = new Validaciones();
                    val.SoloNumerico(e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmDatosTransferencia_Bunifu ~ txtNumCheque_KeyPress");
            }
        }

        private void txtNumCheque_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtNumCheque_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtMonto_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                decimal aux = 0;
                decimal.TryParse(this.txtMonto.Text, out aux);
                this.txtMonto.Text = string.Format("{0:F2}", aux);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtNumCheque_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.ValidarFolioTransaccion()) //Si el folio de transaccion ya existe, informar.
                {
                    this.txt_mensaje.Visible = true;
                    this.txt_mensaje.Text = "El folio de transacción ya ha sido ingresado previamente. Verifique la información.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Ocurrió un error. Contacte a Soporte Técnico. Detalles del error: " + ex.Message,
                    "Sistema Venta de Boletos v1.2", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmDatosTransferencia_Bunifu ~ txtNumCheque_Validating");
            }
        }
        #endregion
        #region Eventos

        private void btnAceptar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    this.btnAceptar_Click(sender, e);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(this, ex.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.panelNotifi.Visible = false;
                    Hashtable errores = new Hashtable();
                    errores = this.ValidarDatos();
                    if (errores.Count == 0)
                    {
                        this.ObtenerDatos();
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        this.MostrarMensajeError(errores);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmDatosTransferencia_Bunifu ~ btnAceptar_Click");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmDatosTransferencia_Bunifu ~ btnCerrar_Click");
                this.DialogResult = DialogResult.Abort;
            }
        }






        #endregion

     
    }
}
