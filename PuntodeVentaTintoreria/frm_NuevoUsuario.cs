using System;
using TintoreriaGlobal;
using TintoreriaNegocio;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntodeVentaTintoreria
{
    public partial class frm_NuevoUsuario : Form
    {
        private Usuario infoUsuario;
        private Validaciones Val;
        public frm_NuevoUsuario(Usuario _Usuario)
        {
            InitializeComponent();
            infoUsuario = _Usuario;            
        }
        private void frm_NuevoUsuario_Load(object sender, EventArgs e)
        {
            using (new Recursos.CursorWait())
            {
                this.Init();
            }
        }
        #region Metodos Generales
        private void Init()
        {
            try
            {
                if (infoUsuario.id_usuario != null)
                {
                    LlenarUsuarios();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LlenarUsuarios()
        {
            try
            {
                this.txt_Nombre.Text = infoUsuario.nombre;
                this.txtApPaterno.Text = infoUsuario.apellidoPat;
                this.txtApMaterno.Text = infoUsuario.apellidoMat;
                this.dtp_fechaNacimiento.Value = infoUsuario.fechaNacimiento;
                this.txtTelefono.Text = infoUsuario.telefono;
                this.cmb_estado.SelectedValue = infoUsuario.id_estado;
                this.cmbMunicipio.SelectedValue = infoUsuario.id_municipio;
                this.txtDireccion.Text = infoUsuario.direccion;
                this.cmb_Sucursal.SelectedValue = infoUsuario.id_sucursal;
                this.cmbTipoUsuario.SelectedValue = infoUsuario.id_tipoUsuario;
                this.txtUsuario.Text = infoUsuario.user;
                this.txtContraseña.Text = infoUsuario.password;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarUsuario()
        {
            try
            {
                int Verificador = -1;
                Usuario _Usu = new Usuario();
                _Usu.conexion = Comun.conexion;
                _Usu.id_usuario = Comun.id_u;
                UsuarioNegocio _UsuNegocio = new UsuarioNegocio();
                this.ObtenerDatosVehiculo(ref _Usu);
                if (_Usu.id_usuario != null)
                {
                    _Usu.opcion = 2;
                    _UsuNegocio.AbcUsuario(_Usu, ref Verificador);
                }
                else
                {
                    _Usu.opcion = 1;
                    _UsuNegocio.AbcUsuario(_Usu, ref Verificador);
                }
                this.VerifcarMensajeAccion(Verificador);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerDatosVehiculo(ref Usuario usu)
        {
            try
            {
                usu.id_usuario = infoUsuario.id_usuario;
                usu.nombre = this.txt_Nombre.Text;
                usu.apellidoPat = this.txtApPaterno.Text;
                usu.apellidoMat = this.txtApMaterno.Text;
                usu.fechaNacimiento = this.dtp_fechaNacimiento.Value;
                usu.telefono = this.txtTelefono.Text;
                usu.id_pais = 143;
                usu.id_estado = Convert.ToInt32(this.cmb_estado.SelectedValue);
                usu.id_municipio = Convert.ToInt32(this.cmbMunicipio.SelectedValue);
                usu.direccion = this.txtDireccion.Text;
                usu.id_sucursal = this.cmb_Sucursal.SelectedValue.ToString();
                usu.id_tipoUsuario = Convert.ToInt32(this.cmbTipoUsuario.SelectedValue);
                usu.id_turno = 1;
                usu.user = this.txtUsuario.Text;
                usu.password = this.txtContraseña.Text;
                if (infoUsuario.password != this.txtContraseña.Text)
                    usu.cambio_passs = 1;
                else
                    usu.cambio_passs = 0;
                usu.fCaducidad = DateTime.Now;
                usu.conInt = 0;
                usu.estatus = true;
                usu.fBloq = DateTime.Now;

                if (this.infoUsuario.permisoCargados)
                {
                    usu.permisoCargados = true;
                    usu.datos = infoUsuario.datos;
                }
                else
                {
                    PermisoNegocio permisoNegocio = new PermisoNegocio();
                    Permiso permiso = new Permiso();
                    permiso.conexion = Comun.conexion;
                    permiso.id_tipoUsuario = usu.id_tipoUsuario;
                    permisoNegocio.PermisoXDefecto(permiso);
                    usu.datos = permiso.datos;
                    usu.permisoCargados = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

        #region Eventos
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (this.ValidarCampos())
                    {
                        this.GuardarUsuario();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ValidarCampos()
        {
            try
            {
                UsuarioNegocio usuario_negocio = new UsuarioNegocio();
                Val = new Validaciones();
                if (this.txt_Nombre.Text == string.Empty || this.txt_Nombre.Text == "")
                {
                    this.txt_Nombre.Focus();
                    MessageBox.Show(this, "Escriba el nombre del usuario", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txtApPaterno.Text == string.Empty || this.txtApPaterno.Text == "")
                {
                    this.txtApPaterno.Focus();
                    MessageBox.Show(this, "Escriba el apellido paterno del usuario", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txtApMaterno.Text == string.Empty || this.txtApMaterno.Text == "")
                {
                    this.txtApMaterno.Focus();
                    MessageBox.Show(this, "Escriba el apellido materno del usuario", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.dtp_fechaNacimiento.Value.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    this.dtp_fechaNacimiento.Focus();
                    MessageBox.Show(this, "Escriba una fecha de nacimiento valida", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txtTelefono.Text == string.Empty || this.txtTelefono.Text == "")
                {
                    this.txtTelefono.Focus();
                    MessageBox.Show(this, "Escriba el teléfono del usuario", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToInt32(this.cmb_estado.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_estado.SelectedIndex) == -1)
                {
                    this.cmb_estado.Focus();
                    MessageBox.Show(this, "Seleccione el estado del usuario", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToInt32(this.cmbMunicipio.SelectedIndex) == 0 || Convert.ToInt32(this.cmbMunicipio.SelectedIndex) == -1)
                {
                    this.cmbMunicipio.Focus();
                    MessageBox.Show(this, "Seleccione el municipio del usuario", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txtDireccion.Text == string.Empty || this.txtDireccion.Text == "")
                {
                    this.txtDireccion.Focus();
                    MessageBox.Show(this, "Escriba la dirección del usuario", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToInt32(this.cmb_Sucursal.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_Sucursal.SelectedIndex) == -1)
                {
                    this.cmb_Sucursal.Focus();
                    MessageBox.Show(this, "Seleccione la sucursal del usuario", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToInt32(this.cmbTipoUsuario.SelectedIndex) == 0 || Convert.ToInt32(this.cmbTipoUsuario.SelectedIndex) == -1)
                {
                    this.cmbTipoUsuario.Focus();
                    MessageBox.Show(this, "Seleccione el tipo de usuario del usuario", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txtUsuario.Text == string.Empty || this.txtUsuario.Text == "")
                {
                    this.txtUsuario.Focus();
                    MessageBox.Show(this, "Escriba el user del usuario", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txtUsuario.Text != string.Empty || this.txtUsuario.Text != "")
                {
                    if (usuario_negocio.VerificarUserUsuario(Comun.conexion, this.txtUsuario.Text, infoUsuario.id_usuario))
                    {
                        this.txtUsuario.Focus();
                        MessageBox.Show(this, "El user ya existe", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                if (this.txtContraseña.Text == string.Empty || this.txtContraseña.Text == "")
                {
                    this.txtContraseña.Focus();
                    MessageBox.Show(this, "Escriba las password del usuario", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        #endregion

        private void BtnPermiso_Click(object sender, EventArgs e)
        {

        }
    }
}
