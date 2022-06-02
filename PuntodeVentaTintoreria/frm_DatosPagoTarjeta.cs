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
    public partial class frm_DatosPagoTarjeta : Form
    {

      

       

        


        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        #region Variables

        private FormaPago _datos;
        public FormaPago datos
        {
            get { return _datos; }
            set { _datos = value; }
        }
        int opcion = 0;
        #endregion
        #region Constructor

        public frm_DatosPagoTarjeta()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        public frm_DatosPagoTarjeta(FormaPago fp, int op)
        {
            try
            {
                InitializeComponent();

                datos = fp;
                opcion = op;
                this.CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }



        #endregion

        private void frm_DatosPagoTarjeta_Load(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.CargarComboBancos();
                    this.LlenarComboDocumentos();
                    this.ActiveControl = this.txtNumAutorizacion;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmDatosTarjeta_Bunifu ~ frmDatosTarjeta_Bunifu_Load");
                this.DialogResult = DialogResult.Abort;
            }
        }






        /*********************************************************************************************************************/

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

        private void LlenarComboDocumentos()
        {
            try
            {
                TipoDocumento datos = new TipoDocumento();
                TipoDocumentoNegocio tn = new TipoDocumentoNegocio();
                datos.conexion = Comun.conexion;
                this.cmbDocumento.ValueMember = "id_tipoDocumento";
                this.cmbDocumento.DisplayMember = "descripcion";
                this.cmbDocumento.DataSource = tn.LlenarComboDocumentos(datos);
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
                        this.txtDNI.Text = datos.folioIFE;
                        this.txtNumAutorizacion.Text = datos.autorizacion;
                        this.cmbBancos.SelectedItem = datos.banco;
                        this.txtMonto.Text = string.Format("{0:F2}", datos.monto);
                        this.txtMonto.ReadOnly = true;
                    }
                    else
                    {
                        datos = new FormaPago();
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
                Validaciones val = new Validaciones();
                if (string.IsNullOrEmpty(this.txtNumAutorizacion.Text))
                    errores.Add(1, "Ingrese el número de autorización. ");
                if (this.cmbDocumento.SelectedIndex == -1)
                    errores.Add(2, "Seleccione un tipo de Identificación. ");
                else
                {
                    TipoDocumento td = new TipoDocumento();
                    td = (TipoDocumento)this.cmbDocumento.SelectedItem;
                    if (string.IsNullOrEmpty(td.id_tipoDocumento))
                        errores.Add(2, "Seleccione un tipo de Identificación. ");
                }

                if (string.IsNullOrEmpty(this.txtDNI.Text) || string.IsNullOrWhiteSpace(this.txtDNI.Text))
                    errores.Add(3, "Ingrese el núm. de Identificación. ");
                else
                {
                    TipoDocumento td = new TipoDocumento();
                    td = (TipoDocumento)this.cmbDocumento.SelectedItem;
                    if (!string.IsNullOrEmpty(td.id_tipoDocumento))
                    {
                        switch (td.id_tipoDocumento)
                        {
                            case "307F5273-3028-45DD-8019-3A0A890AC8AC":
                                if (!val.ValidarIFE(this.txtDNI.Text))
                                    errores.Add(3, "Núm. de INE no válido.");
                                break;
                            case "6135947D-27BC-4146-8082-A2E55B07D087":
                                if (!val.ValidarLicenciaConducir(this.txtDNI.Text))
                                    errores.Add(3, "Núm. de Licencia no válido.");
                                break;
                            case "91FF9941-5815-420F-AC5A-9FD0AAF7FB45":
                                if (!val.ValidarPasaporte(this.txtDNI.Text))
                                    errores.Add(3, "Núm. de Pasaporte no válido.");
                                break;

                            case "FB4FB831-7E8B-4E66-8B0C-B5C3F31A3A13":
                                if (!val.ValidarCedulaProfesional(this.txtDNI.Text))
                                    errores.Add(3, "Núm. de Cédula Profesional no válido.");
                                break;
                        }
                    }
                }

                if (string.IsNullOrEmpty(this.txtNumTarjeta.Text) || string.IsNullOrWhiteSpace(this.txtNumTarjeta.Text))
                    errores.Add(4, "Ingrese el núm. de la tarjeta. ");
                else
                {
                    if (!val.ValidarTarjetaCreditoDebito(this.txtNumTarjeta.Text))
                        errores.Add(4, "El número de la tarjeta no es correcto. ");
                }
                if (this.cmbBancos.SelectedIndex == -1)
                    errores.Add(5, "Seleccione una banco de la lista. ");
                else
                {
                    Banco banco = new Banco();
                    banco = (Banco)this.cmbBancos.SelectedItem;
                    if (banco.idBanco == 0)
                        errores.Add(5, "Seleccione una banco de la lista. ");
                }
                decimal monto = 0;
                decimal.TryParse(this.txtMonto.Text, out monto);
                if (monto <= 0)
                    errores.Add(6, "Ingrese un monto válido mayor a 0. ");
                else
                    if (opcion == 0)
                {
                    if (monto > (decimal)datos.monto)
                    {
                        errores.Add(6, "Ingrese un monto menor o igual a " + string.Format("{0:c}", datos.monto) + ".");
                    }
                }
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
                datos = new FormaPago();
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
                if (this.cmbDocumento.SelectedIndex == -1)
                    datos.tipoDocumento = new TipoDocumento();
                else
                {
                    TipoDocumento td = new TipoDocumento();
                    td = (TipoDocumento)this.cmbDocumento.SelectedItem;
                    if (string.IsNullOrEmpty(td.id_tipoDocumento))
                        datos.tipoDocumento = new TipoDocumento();
                    else
                        datos.tipoDocumento = td;
                }
                if (string.IsNullOrEmpty(this.txtNumAutorizacion.Text))
                    datos.autorizacion = string.Empty;
                else
                    datos.autorizacion = this.txtNumAutorizacion.Text;
                if (string.IsNullOrEmpty(this.txtDNI.Text) || string.IsNullOrWhiteSpace(this.txtDNI.Text))
                    datos.folioIFE = string.Empty;
                else
                    datos.folioIFE = this.txtDNI.Text;
                decimal monto = 0;
                decimal.TryParse(this.txtMonto.Text, out monto);
                datos.monto = monto;
                if (string.IsNullOrEmpty(this.txtNumTarjeta.Text) || string.IsNullOrWhiteSpace(this.txtNumTarjeta.Text))
                    datos.numtarjeta = string.Empty;
                else
                    datos.numtarjeta = this.txtNumTarjeta.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #endregion
        #region Validaciones
        private void txtMonto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtMonto_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtNumTarjeta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtNumTarjeta_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtDNI_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtDNI_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtNumAutorizacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtNumAutorizacion_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)13)
                {
                    this.btnAceptar.Focus();
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
                LogError.AddExcFileTxt(ex, "frmDatosTarjeta ~ txtMonto_KeyPress");
            }
        }

        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)13)
                {
                    this.txtNumTarjeta.Focus();
                }
                else
                {
                    Validaciones val = new Validaciones();
                    val.TextoNumerosPuntoGuionTilde(e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmDatosTarjeta ~ txtDNI_KeyPress");
            }
        }

        private void txtNumAutorizacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)13)
                {
                    this.cmbDocumento.Focus();
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
                LogError.AddExcFileTxt(ex, "frmDatosTarjeta ~ txtNumAutorizacion_KeyPress");
            }
        }

        private void txtNumTarjeta_KeyPress(object sender, KeyPressEventArgs e)
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
                LogError.AddExcFileTxt(ex, "frmDatosTarjeta ~ txtNumTarjeta_KeyPress");
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
        #endregion
        #region Eventos
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.txt_mensaje.Visible = false;
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
                LogError.AddExcFileTxt(ex, "frmDatosTarjeta ~ btnAceptar_Click");
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
                LogError.AddExcFileTxt(ex, "frmDatosTarjeta ~ btnCerrar_Click");
                this.DialogResult = DialogResult.Abort;
            }
        }
        #endregion

      
     
    }
}
