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
using System.Management;
using System.Runtime.InteropServices;

namespace PuntodeVentaTintoreria
{
    public partial class frm_Login : Form
    {

        #region Dlls para poder hacer el movimiento del Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        #endregion

        public frm_Login()
        {
            InitializeComponent();
        }

        private void frm_Login_Load(object sender, EventArgs e)
        {
            try
            {
                this.configurarSistema();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmLogin_Bunifu ~ frmLogin_Bunifu_Shown");
            }

            this.txtUsuario.Focus();

        }
        //private void PanelTitulo_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Left)
        //    {
        //        this.Location = new Point(Cursor.Position.X + e.X, Cursor.Position.Y + e.Y);
        //    }
        //}

        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnTeclado_Click(object sender, EventArgs e)
        {

        }

        /*********************************************************************************************************************/

        private List<Producto> listaImagenesPendiente = new List<Producto>();
        private bool LoginOk, ImagenOk;

        private Usuario usuario;
   
       
        #region Validaciones
        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtUsuario_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtContraseña_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
                    if (LoginOk)
                    {
                        if (this.validarDatosEntrada())
                        {
                            if (Convert.ToBoolean(ConfigurationManager.AppSettings.Get("strBanMac")))
                                Comun.macAddress = ConfigurationManager.AppSettings.Get("strMac");
                            usuario = new Usuario();
                            usuario.Validador = 1;
                            usuario.id_sucursal = Comun.id_sucursal;
                            usuario = this.obtenerDatosUsuario(usuario);
                            usuario.conexion = Comun.conexion;
                            if (!string.IsNullOrEmpty(Comun.macAddress))
                            {
                                usuario = this.ingresar(usuario);
                                LoginNegocio login_negocio = new LoginNegocio();
                                login_negocio.ObtenerPermisosUsuario(usuario);
                                Comun.PermisoUsuario = usuario.PermisoUsuario;
                                if (usuario.Validador == 1)
                                {
                                    if (usuario.id_sucursal == Comun.id_sucursal)
                                    {
                                        //Verificar cambios en el catálodo de productos para la sucursal
                                        if (usuario.crearid_caja == false)
                                        {
                                            frmAbrirCaja aperturaCaja = new frmAbrirCaja();
                                            aperturaCaja.ShowDialog();
                                            aperturaCaja.Dispose();
                                            if (aperturaCaja.DialogResult == DialogResult.OK)
                                            {
                                                this.Visible = false;
                                                frmHome home = new frmHome();
                                                home.ShowDialog();
                                                home.Dispose();
                                                this.Visible = true;
                                                //this.txtUsuario.Focus();
                                                this.txtUsuario.Text = "Usuario";
                                                this.txtContraseña.Text = "CONTRASEÑA";
                                                panelNotifi.Visible = false;
                                            }

                                        }
                                        else
                                        {
                                            this.Visible = false;
                                            frmHome home = new frmHome();
                                            home.ShowDialog();
                                            home.Dispose();
                                            this.Visible = true;
                                            //this.txtUsuario.Focus();
                                            this.txtUsuario.Text = "Usuario";
                                            this.txtContraseña.Text = "CONTRASEÑA";
                                            panelNotifi.Visible = false;
                                            //this.Close();
                                        }
                                    }
                                    else
                                        this.datosIncorrectos(4);
                                }
                                else
                                {
                                    this.datosIncorrectos(usuario.Validador);
                                    if (usuario.Validador == 8)
                                    {
                                      frm_AsignarCaja frmac = new frm_AsignarCaja();
                                        frmac.ShowDialog();
                                        frmac.Dispose();
                                        if (frmac.DialogResult != DialogResult.OK)
                                        {
                                            this.Close();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "No se pudo obtener la configuración del Equipo. El sistema debe cerrarse.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmLogin_Bunifu ~ btnAceptar_Click");
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    this.txtContraseña.SelectAll();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
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
                LogError.AddExcFileTxt(ex, "frmLogin_Bunifu ~ txtContraseña_KeyPress");
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    this.txtContraseña.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmLogin_Bunifu ~ txtUsuario_KeyPress");
            }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            try
            {
                this.txtUsuario.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmLogin_Bunifu ~ txtUsuario_Enter");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Está seguro que desea salir de la aplicación?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmLogin_Bunifu ~ btnCancelar_Click");
            }
        }
        #endregion
        #region Metodos Generales
        private void CargarImagenPendiente()
        {
            try
            {
                Producto datos = new Producto();
                ProductoNegocio pn = new ProductoNegocio();
                List<Producto> lista = new List<Producto>();
                datos.conexion = Comun.conexion;
                //listaImagenesPendiente = pn.ObtenerImagenProductosActualizar(datos);
                listaImagenesPendiente = pn.ObtenerImagenProductosActualizar2(datos);
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

                try
                {
                    ImageFormat Formato = ImageFormat.Png;
                    Bitmap bmpFromString = Comun.ticket.url_logo.Base64StringToBitmap();
                    pictureBox1.Image = bmpFromString;
                    bmpFromString.Save(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Empresas\1.png"), Formato);

                }
                catch (Exception)
                {
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void datosIncorrectos(int opcion)
        {
            try
            {
                panelNotifi.Visible = true;
                switch (opcion)
                {
                    case 2:
                        
                        this.mensaje("Su cuenta ha caducado. Comuníquese con un Administrador.");
                        this.picAlerta.Visible = true;
                        break;
                    case 3:
                        
                        this.mensaje("Su cuenta está bloqueada. Comuníquese con un Administrador.");
                        this.picAlerta.Visible = true;
                        break;
                    case 4:
                        this.mensaje("El usuario no está registrado para ésta Sucursal.");
                        this.picAlerta.Visible = true;
                        break;
                    case 5:
                        
                        this.mensaje("No existe la cuenta.");
                        this.picAlerta.Visible = true;
                        break;
                    case 6:
                       
                        this.mensaje("Ha excedido el número de intentos. Su cuenta fue bloqueada. Comuníquese con un Administrador.");
                        this.picAlerta.Visible = true;
                        break;
                    case 7:
                      
                        this.mensaje("Contraseña Incorrecta. Intente nuevamente.");
                        this.picAlerta.Visible = true;
                        break;
                    case 8:
                      
                        this.mensaje("No fue Localizada la caja. Asigne una caja.");
                        this.picAlerta.Visible = true;
                        break;
                    case 10:
                        this.picAlerta.Visible = true;
                        break;
                    case 15:
                     
                        this.mensaje("No se pudo conectar al servidor.");
                        this.picAlerta.Visible = true;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private string GetHostName()
        {
            try
            {
                ManagementObjectSearcher objMOS = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'");
                ManagementObjectCollection objMOC = objMOS.Get();
                string HostName = String.Empty;
                foreach (ManagementObject objMO in objMOC)
                {
                    if (HostName == String.Empty)
                    {
                        HostName = objMO["DNSHostName"].ToString();
                    }
                    objMO.Dispose();
                }
                if (Convert.ToBoolean(ConfigurationManager.AppSettings.Get("strBanHostName")))
                {
                    HostName = ConfigurationManager.AppSettings.Get("strHostName");
                }
                return HostName;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        private string GetMACAddress()
        {
            try
            {
                ManagementObjectSearcher objMOS = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'");
                ManagementObjectCollection objMOC = objMOS.Get();
                string MACAddress = String.Empty;
                foreach (ManagementObject objMO in objMOC)
                {
                    if (MACAddress == String.Empty)
                    {
                        MACAddress = objMO["MacAddress"].ToString();
                    }
                    objMO.Dispose();
                }
                if (Convert.ToBoolean(ConfigurationManager.AppSettings.Get("strBanMac")))
                {
                    MACAddress = ConfigurationManager.AppSettings.Get("strMac");
                }
                return MACAddress;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        private void iniciarSistema()
        {
            try
            {
                ComunNegocio comun_negocio = new ComunNegocio();
                comun_negocio.ObtenerSucursal(Comun.conexion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmLogin ~ iniciarSistema");
            }
        }
        private Usuario ingresar(Usuario usuario)
        {
            try
            {
                LoginNegocio login_negocio = new LoginNegocio();
                return (login_negocio.validarUsuario(usuario));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void mensaje(string msj)
        {

            this.txt_mensaje.Text = msj;
            this.txt_mensaje.Visible = true;

        }
        private Usuario obtenerDatosUsuario(Usuario usuario)
        {
            try
            {
                usuario.user = this.txtUsuario.Text;
                usuario.password = this.txtContraseña.Text;
                return usuario;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private bool validarDatosEntrada()
        {
            try
            {
                if (this.txtUsuario.Text == "USUARIO" || this.txtContraseña.Text == "CONTRASEÑA")
                {
                    if (this.txtUsuario.Text == "USUARIO")
                    {
                        this.txtUsuario.Focus();
                        this.picAlerta.Visible = true;
                        this.mensaje("Debes ingresar usuario");
                    }
                    else if (this.txtContraseña.Text == "CONTRASEÑA")
                    {
                        this.txtContraseña.Focus();
                        this.picAlerta.Visible = true;
                        this.mensaje("Debes ingresar contraseña");
                    }
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        private void configurarSistema()
        {
            try
            {

                Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
                if (Convert.ToBoolean(ConfigurationManager.AppSettings.Get("strBanMac")))
                {
                    Comun.macAddress = ConfigurationManager.AppSettings.Get("strMac");
                    Comun.hostName = ConfigurationManager.AppSettings.Get("strHostName");
                }
                else
                {
                    Comun.macAddress = GetMACAddress();
                    Comun.hostName = GetHostName();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

        private void bgw_LoginInit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (LoginOk)
                {
                    txtMsgConeccion.Text = "Conectado";
                    pic_status.Image = PuntodeVentaTintoreria.Properties.Resources.StatusGreen_32px;
                    //txtMsgLogin.BackColor = Color.DeepSkyBlue;
                    timeLogin.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmLogin - bgw_LoginInit_RunWorkerCompleted");
            }
        }

        private void timeLogin_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!bgw_LoginInit.IsBusy)
                    bgw_LoginInit.RunWorkerAsync();
            }
            catch (Exception)
            {
            }
        }

        private void bgw_LoginInit_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                iniciarSistema();
                LoginOk = true;
                if (!string.IsNullOrEmpty(Comun.id_sucursal) && !string.IsNullOrWhiteSpace(Comun.id_sucursal))
                {
                    ImageFormat Formato = ImageFormat.Png;
                    Bitmap bmpFromString = Comun.ticket.url_logo.Base64StringToBitmap();
                    pictureBox1.Image = bmpFromString;
                    Comun.ticket.url_logo = string.Empty;
                }
            }
            catch (Exception)
            {
                LoginOk = false;
            }
        }

        //Descarga de imagenes, revisar y actualizar codigo
        /*
        private void bgw_ImagenInit_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CargarImagenPendiente();
                ImagenOk = true;
            }
            catch (Exception)
            {
            }
        }

        private void bgw_ImagenInit_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (ImagenOk)
                {
                    CargarCatalogoProductos(listaImagenesPendiente);
                    timeImagen.Enabled = false;
                }
            }
            catch (Exception)
            {
            }
        }

        private void timeImagen_Tick(object sender, EventArgs e)
        {
            try
            {
                if (!bgw_ImagenInit.IsBusy)
                    bgw_ImagenInit.RunWorkerAsync();
            }
            catch (Exception)
            {

            }
        }

    */
        private void txtUsuario_MouseClick(object sender, MouseEventArgs e)
        {
            txtUsuario.SelectAll();
        }

        private void txtContraseña_MouseClick(object sender, MouseEventArgs e)
        {
            txtContraseña.SelectAll();
        }
        
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
                LogError.AddExcFileTxt(ex, "frmLogin_Bunifu ~ btnAceptar_KeyPress");
            }
        }

        private void frm_Login_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void PanelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {             
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);     
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

    }
}
