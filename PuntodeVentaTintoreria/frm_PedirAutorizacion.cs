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

namespace PuntodeVentaTintoreria
{
    public partial class frm_PedirAutorizacion : Form
    {
        public frm_PedirAutorizacion()
        {
            try
            {
                InitializeComponent();
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

        #region Propiedades
        public Usuario usuarioAutoriza = new Usuario();
        private string _IDTabla;
        private string _NombreTabla;
        private string _Texto;
        public string IDTabla
        {
            set { _IDTabla = value; }
        }
        public string NombreTabla
        {
            set { _NombreTabla = value; }
        }
        public string Texto
        {
            set { _Texto = value; }
        }
        #endregion
       

        private void frm_PedirAutorizacion_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAutorizacion ~ frmAutorizacion_Load");
                this.Close();
            }
        }
        #region Métodos Generales
        private void MostrarMensajeError(int error)
        {
            try
            {
                switch (error)
                {
                    case 2:
                        MessageBox.Show(this, "La cuenta está bloqueada.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ActiveControl = this.txtUsuario;
                        this.txtUsuario.Focus();
                        break;
                    case 3:
                        MessageBox.Show(this, "La cuenta NO es de tipo Administrador.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ActiveControl = this.txtUsuario;
                        this.txtUsuario.Focus();
                        break;
                    case 4:
                        MessageBox.Show(this, "La contraseña es incorrecta.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ActiveControl = this.txtContraseña;
                        this.txtContraseña.Focus();
                        break;
                    case 5:
                        MessageBox.Show(this, "La cuenta no existe.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ActiveControl = this.txtUsuario;
                        this.txtUsuario.Focus();
                        break;
                    case 20:
                        MessageBox.Show(this, "Ingrese cuenta de Usuario.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ActiveControl = this.txtUsuario;
                        this.txtUsuario.Focus();
                        break;
                    case 21:
                        MessageBox.Show(this, "Ingrese Password.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ActiveControl = this.txtContraseña;
                        this.txtContraseña.Focus();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private Usuario ObtenerDatos()
        {
            try
            {
                Usuario datos = new Usuario();
                datos.user = this.txtUsuario.Text;
                datos.password = this.txtContraseña.Text;
                datos.conexion = Comun.conexion;
                datos.id_usuario = Comun.id_u;
                datos.id_sucursal = Comun.id_sucursal;
                return datos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private int ValidarDatos()
        {
            try
            {
                if (string.IsNullOrEmpty(this.txtUsuario.Text) || string.IsNullOrWhiteSpace(this.txtUsuario.Text))
                    return 20;
                if (string.IsNullOrEmpty(this.txtContraseña.Text) || string.IsNullOrWhiteSpace(this.txtContraseña.Text))
                    return 21;
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion
        #region Validaciones
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
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAutorizacion ~ txtUsuario_KeyPress");
            }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    this.btnAceptar_Click(this.btnAceptar, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAutorizacion ~ txtContraseña_KeyPress");
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

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
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

        private void txtContraseña_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
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
                    int error = this.ValidarDatos();
                    if (error == 0)
                    {
                        Usuario datos = new Usuario();
                        UsuarioNegocio un = new UsuarioNegocio();
                        datos = un.AutorizacionAdmin(this.ObtenerDatos());
                        if (datos.Validador == 1)
                        {
                            usuarioAutoriza = datos;
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            this.MostrarMensajeError(datos.Validador);
                        }
                    }
                    else
                        this.MostrarMensajeError(error);
                }
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Abort;
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAutorizacion ~ btnAceptar_Click");
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
                this.DialogResult = DialogResult.Abort;
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAutorizacion ~ btnCancelar_Click");
            }
        }
        #endregion


    }
}
