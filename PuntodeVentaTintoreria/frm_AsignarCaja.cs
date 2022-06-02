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

using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
using PuntodeVentaTintoreria.ClaseAux;
using System.Drawing.Printing;
using System.Management;

namespace PuntodeVentaTintoreria
{
    public partial class frm_AsignarCaja : Form
    {
        public frm_AsignarCaja()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAsignarCaja ~ frmAsignarCaja()");
                this.Close();
            }

        }
        
        private void PanelTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(Cursor.Position.X + e.X, Cursor.Position.Y + e.Y);
            }
        }

        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }








        /*********************************************************************************************************************/

        Validaciones Val;
        frm_Esperar frmEspera = new frm_Esperar();

      
        

        #region Métodos Generales
        private void CargarCombos()
        {
            try
            {
                this.LLenarComboCajas();
                this.LlenarComboSucursales();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void GuardarMac()
        {
            try
            {
                int Verificador = 0;
                EquipoNegocio equipoNegocio = new EquipoNegocio();
                Equipo equipo = new Equipo();
                equipo.conexion = Comun.conexion;
                this.ObtenerDatos(equipo);
                if (string.IsNullOrEmpty(Comun.macAddress))
                    equipo.opcion = 0;
                else
                    equipo.opcion = 1;
                Verificador = equipoNegocio.asignarEquipoMAC(equipo);
                if (Verificador == 1)
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings["strBanMac"].Value = "true";
                    config.AppSettings.Settings["strMac"].Value = equipo.macAddress;
                    config.AppSettings.Settings["strBanHostName"].Value = "true";
                    config.AppSettings.Settings["strHostName"].Value = equipo.nombre;
                    config.Save(ConfigurationSaveMode.Modified);
                    Comun.macAddress = equipo.macAddress;
                   // this.bgw.RunWorkerAsync();
                   // frmEspera.ShowDialog();
                    MessageBox.Show(this, "Datos guardados correctamente.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show(this, "No se pudo actualizar la información. Puede que la dirección MAC ingresada ya existe.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Inicializar()
        {
            try
            {
                this.CargarCombos();
                this.mktxtMac.Text = Comun.macAddress;
                this.txtNombreCaja.Text = Comun.hostName;
                if (string.IsNullOrEmpty(Comun.macAddress))
                {
                    this.mktxtMac.ReadOnly = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void LlenarComboSucursales()
        {
            try
            {
                Sucursal datos = new Sucursal();
                SucursalNegocio sn = new SucursalNegocio();
                datos.conexion = Comun.conexion;
                datos.opcion = 1;
                sn.ObtenerComboSucursal(datos);
                this.cmbSucCaja.DataSource = datos.datos;
                this.cmbSucCaja.ValueMember = "id_sucursal";
                this.cmbSucCaja.DisplayMember = "nombre";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void LLenarComboCajas()
        {
            try
            {
                Equipo equipo = new Equipo();
                EquipoNegocio equipo_negocio = new EquipoNegocio();
                equipo.conexion = Comun.conexion;
                equipo_negocio.ObtenerComboEquipoNoAsignados(equipo);
                this.cmbEquipo.SelectedValueChanged -= new System.EventHandler(this.cmbEquipo_SelectedValueChanged);
                this.cmbEquipo.DataSource = equipo.datos;
                this.cmbEquipo.ValueMember = "id_equipo";
                this.cmbEquipo.DisplayMember = "nombre";
                this.cmbEquipo.SelectedValueChanged += new System.EventHandler(this.cmbEquipo_SelectedValueChanged);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ObtenerDatos(Equipo equipo)
        {
            try
            {
                equipo.id_equipo = cmbEquipo.SelectedValue.ToString();
                equipo.macAddress = this.mktxtMac.Text;
                equipo.nombre = this.txtNombreCaja.Text;
                equipo.namePrinter = this.txt_namePrinter.Text;
                equipo.id_sucursal = cmbSucCaja.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void mostrarMensajeError(int error)
        {
            try
            {
                this.txt_mensaje.Visible = true;
                switch (error)
                {
                    case 1:
                        panelNotifi.Visible = true;
                        this.txt_mensaje.Text = "Ingrese una dirección MAC válida.";
                        this.ActiveControl = this.mktxtMac;
                        this.mktxtMac.Focus();
                        break;
                    case 2:
                        panelNotifi.Visible = true;
                        this.txt_mensaje.Text = "Seleccione un número de caja.";
                        this.ActiveControl = this.cmbEquipo;
                        this.cmbEquipo.Focus();
                        break;
                    case 3:
                        panelNotifi.Visible = true;
                        this.txt_mensaje.Text = "Seleccione una sucursal para la caja.";
                        this.ActiveControl = this.cmbSucCaja;
                        this.cmbSucCaja.Focus();
                        break;
                    case 4:
                        panelNotifi.Visible = true;
                        this.txt_mensaje.Text = "Asigne un nombre a la caja.";
                        this.ActiveControl = this.txtNombreCaja;
                        this.txtNombreCaja.Focus();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private int ValidarCampos()
        {
            try
            {
                Validaciones validar = new Validaciones();
                if (string.IsNullOrEmpty(this.mktxtMac.Text) || string.IsNullOrWhiteSpace(this.mktxtMac.Text))
                    return 1;
                if (!validar.validarDireccionMAC(this.mktxtMac.Text))
                    return 1;
                if (this.cmbEquipo.SelectedIndex == -1)
                    return 2;
                DataRowView vrow = (DataRowView)this.cmbEquipo.SelectedItem;
                DataRow row = vrow.Row;
                if (string.IsNullOrEmpty(row["id_equipo"].ToString()))
                    return 2;
                if (this.cmbSucCaja.SelectedIndex == -1)
                    return 3;
                DataRowView vrow2 = (DataRowView)this.cmbSucCaja.SelectedItem;
                DataRow row2 = vrow2.Row;
                if (string.IsNullOrEmpty(row["id_sucursal"].ToString()))
                    return 3;
                if (string.IsNullOrEmpty(this.txtNombreCaja.Text) || string.IsNullOrWhiteSpace(this.txtNombreCaja.Text))
                    return 4;
                return 0;
            }
            catch (Exception ex)
            {
                return 0;

            }
        }
        private void CargarImagenPendiente()
        {
            try
            {
                Producto datos = new Producto();
                ProductoNegocio pn = new ProductoNegocio();
                List<Producto> lista = new List<Producto>();
                datos.conexion = Comun.conexion;
                //lista = pn.ObtenerImagenProductosActualizar(datos);
                lista = pn.ObtenerImagenProductosActualizar2(datos);
                this.CargarCatalogoProductos(lista);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void CargarCatalogoProductos(List<Producto> lista)
        {
            try
            {
                foreach (Producto producto in lista)
                {
                    if (producto.imagen != null || producto.imagen != "")
                    {
                        try
                        {
                            ImageFormat Formato = ImageFormat.Png;
                            producto.extension = ".png";
                            Bitmap bmpFromString = producto.imagen.Base64StringToBitmap();
                            bmpFromString.Save(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Productos\" + producto.id_producto + producto.extension), Formato);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion
        #region Validaciones


        private void txtNombreCaja_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloAlfaNumerico(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAsignarCaja ~ txtNombreCaja_KeyPress");
            }
        }

        private void txtNombreCaja_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtNombreCaja_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txt_namePrinter_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloAlfaNumerico(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAsignarCaja ~ txt_namePrinter_KeyPress");
            }
        }

        private void txt_namePrinter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_namePrinter_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion
        #region Eventos
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAsignarCaja ~ btn_Cancelar_Click");
                this.Close();
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    int error = ValidarCampos();
                    if (error == 0)
                    {
                        this.GuardarMac();
                    }
                    else
                    {
                        this.mostrarMensajeError(error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAsignarCaja ~ btn_Guardar_Click");
                this.Close();
            }
        }

        private void cmbEquipo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataRowView vrow = (DataRowView)this.cmbEquipo.SelectedItem;
                DataRow row = vrow.Row;
                cmbSucCaja.SelectedValue = Convert.ToString(row["id_sucursal"].ToString());
                txt_namePrinter.Text = Convert.ToString(row["namePrinter"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAsignarCaja ~ cmbEquipo_SelectedValueChanged");
            }
        }

        private void btn_impresora_Click(object sender, EventArgs e)
        {
            try
            {
                PrintDialog printDialog1 = new PrintDialog();
                printDialog1.AllowCurrentPage = false;
                printDialog1.AllowPrintToFile = false;
                printDialog1.AllowSelection = false;
                printDialog1.AllowSomePages = false;
                printDialog1.ShowHelp = false;
                printDialog1.ShowNetwork = false;
                printDialog1.PrintToFile = false;
                DialogResult result = printDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    PrinterSettings ps = printDialog1.PrinterSettings;
                    this.txt_namePrinter.Text = ps.PrinterName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Error en btnSeleccionarPrinter_Click " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAsignarCaja ~ btn_impresora_Click");
            }
        }



        /*
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.CargarImagenPendiente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (!frmEspera.IsDisposed)
                {
                    frmEspera.DialogResult = DialogResult.Abort;
                    frmEspera.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        */
        #endregion

        private void frm_AsignarCaja_Load(object sender, EventArgs e)
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
                LogError.AddExcFileTxt(ex, "frmAsignarCaja ~ frmAsignarCaja_Load");
            }
        }
    }
}
