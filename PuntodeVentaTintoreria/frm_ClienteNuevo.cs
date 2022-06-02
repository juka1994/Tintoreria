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
using System.Globalization;
using System.Drawing.Printing;

namespace PuntodeVentaTintoreria
{
    public partial class frm_ClienteNuevo : Form
    {
       
        
        

        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        /*************************************************************************************************************************************************/

        private Validaciones Val;
        private Cliente infoCliente;

        public frm_ClienteNuevo(Cliente cliente)
        {
            try
            {
                InitializeComponent();
                this.infoCliente = cliente;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCliente Nuevo");
            }
        }

        private void frm_ClienteNuevo_Load(object sender, EventArgs e)
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
                LogError.AddExcFileTxt(ex, "frmClientes_Bunifu ~ frmClientes_Bunifu_Load");
            }
        }

        #region Metodos Generales
        private void CargarCombos()
        {
            try
            {
                EstadoNegocio estado_negocio = new EstadoNegocio();
                Estado estado = new Estado();
                estado.conexion = Comun.conexion;
                estado.id_pais = 143;
                estado_negocio.ObtenerComboEstado(estado);
                this.cmb_estado.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_estado.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_estado.DisplayMember = "descripcion";
                this.cmb_estado.ValueMember = "id_estado";
                this.cmb_estado.SelectedValueChanged -= new System.EventHandler(this.cmb_estado_SelectedValueChanged);
                this.cmb_estado.DataSource = estado.datos;
                this.cmb_estado.SelectedValue = 7;
                this.cmb_estado.SelectedValueChanged += new System.EventHandler(this.cmb_estado_SelectedValueChanged);

                MunicipioNegocio municipio_negocio = new MunicipioNegocio();
                Municipio municipio = new Municipio();
                municipio.conexion = Comun.conexion;
                municipio.id_pais = 143;
                municipio.id_estado = Convert.ToInt32(this.cmb_estado.SelectedValue);
                municipio_negocio.ObtenerComboMunicipio(municipio);
                this.cmb_municipio.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_municipio.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_municipio.DisplayMember = "descripcion";
                this.cmb_municipio.ValueMember = "id_municipio";
                this.cmb_municipio.DataSource = municipio.datos;
                this.cmb_municipio.SelectedValue = 101;

                //COMBO OCUPACION
                //OcupacionNegocio ocupacion_negocio = new OcupacionNegocio();
                //Ocupacion ocupacion = new Ocupacion();
                //ocupacion.conexion = Comun.conexion;
                //ocupacion_negocio.ObtenerComboOcupacion(ocupacion);
                //this.cmb_ocupacion.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                //this.cmb_ocupacion.AutoCompleteSource = AutoCompleteSource.ListItems;
                //this.cmb_ocupacion.DisplayMember = "descripcion";
                //this.cmb_ocupacion.ValueMember = "id_ocupacion";
                //this.cmb_ocupacion.DataSource = ocupacion.datos;
                //
                TipoCredencialNegocio _negocio = new TipoCredencialNegocio();
                TipoCredenciales _credencial = new TipoCredenciales();
                _credencial.conexion = Comun.conexion;
                _negocio.ObtenerComboTipoCredencial(_credencial);
                this.cmb_membresia.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_membresia.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_membresia.DisplayMember = "descripcion";
                this.cmb_membresia.ValueMember = "id_tipocredencial";
                this.cmb_membresia.DataSource = _credencial.datos;
                //
                GeneroNegocio genero_negocio = new GeneroNegocio();
                Genero genero = new Genero();
                genero.conexion = Comun.conexion;
                genero_negocio.ObtenerComboGenero(genero);
                this.cmb_genero.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_genero.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_genero.DataSource = genero.datos;
                this.cmb_genero.DisplayMember = "descripcion";
                this.cmb_genero.ValueMember = "id_genero";
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
                CargarCombos();
                if (infoCliente.id_cliente != null)
                {
                    this.LlenarDatos();
                    this.lbTitulo.Text = "Editar Cliente";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void GuardarCliente()
        {
            try
            {
                Val = new Validaciones();
                int Verificador = -1;
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                Cliente cliente = new Cliente();                               
                this.ObtenerDatos(cliente);
                if (infoCliente.id_cliente != null)
                {
                    cliente.opcion = 2;
                    cliente.id_cliente = infoCliente.id_cliente;
                    clienteNegocio.AbcCliente(cliente, ref Verificador);
                }
                else
                {
                    cliente.opcion = 1;
                    clienteNegocio.AbcCliente(cliente, ref Verificador);
                }
                this.VerifcarMensajeAccion(Verificador);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ObtenerDatos(Cliente cliente)
        {
            try
            {
                cliente.nombre = this.txt_nombre.Text;
                cliente.apePat = this.txt_apellidoPaterno.Text;
                cliente.apeMat = this.txt_apellidoMaterno.Text;
                cliente.correoElectronico = this.txt_correoElectronico.Text;
                cliente.id_pais = 143;
                cliente.id_estado = Convert.ToInt32(this.cmb_estado.SelectedValue);
                cliente.id_municipio = Convert.ToInt32(this.cmb_municipio.SelectedValue);
                cliente.fechaNacimiento = this.dtp_fechaNacimiento.Value;
                cliente.colonia = this.txt_colonia.Text;
                cliente.id_tipoCredencial = Convert.ToInt32(this.cmb_membresia.SelectedValue);
                cliente.id_genero = Convert.ToInt32(this.cmb_genero.SelectedValue);
                cliente.telefono = this.txt_telefono.Text;
                cliente.curp = this.txt_curp.Text;
                cliente.direccion = this.txt_direccion.Text;
                cliente.codigoMonedero = this.txt_Monedero.Text;
                cliente.fechaInicio = DateTime.Now;
                cliente.solicitado = true;
                cliente.entregado = true;
                cliente.id_u = Comun.id_u;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void LlenarDatos()
        {
            try
            {
                this.txt_nombre.Text = infoCliente.nombre;
                this.txt_apellidoPaterno.Text = infoCliente.apePat;
                this.txt_apellidoMaterno.Text = infoCliente.apeMat;
                this.txt_correoElectronico.Text = infoCliente.correoElectronico;
                this.cmb_estado.SelectedValue = infoCliente.id_estado;
                this.cmb_municipio.SelectedValue = infoCliente.id_municipio;
                this.dtp_fechaNacimiento.Value = infoCliente.fechaNacimiento;
                this.txt_colonia.Text = infoCliente.colonia;
                this.cmb_membresia.SelectedValue = infoCliente.id_tipoCredencial;
                this.cmb_genero.SelectedValue = infoCliente.id_genero;
                this.txt_telefono.Text = infoCliente.telefono;
                this.txt_curp.Text = infoCliente.curp;
                this.txt_direccion.Text = infoCliente.direccion;
                this.txt_Monedero.Text = infoCliente.codigoMonedero;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private bool ValidarCampos()
        {
            try
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                Val = new Validaciones();
                if (this.txt_nombre.Text == string.Empty || this.txt_nombre.Text == "")
                {
                    this.txt_nombre.Focus();
                    MessageBox.Show(this, "Escriba el nombre del cliente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txt_apellidoPaterno.Text == string.Empty || this.txt_apellidoPaterno.Text == "")
                {
                    this.txt_apellidoPaterno.Focus();
                    MessageBox.Show(this, "Escriba el apellido paterno del cliente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txt_apellidoMaterno.Text == string.Empty || this.txt_apellidoMaterno.Text == "")
                {
                    this.txt_apellidoMaterno.Focus();
                    MessageBox.Show(this, "Escriba el apellido materno del cliente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txt_correoElectronico.Text == string.Empty || this.txt_correoElectronico.Text == "")
                {
                    this.txt_correoElectronico.Focus();
                    MessageBox.Show(this, "Escriba el correo electrónico del cliente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (infoCliente.id_cliente == null)
                {

                    if (!clienteNegocio.VerificarCorreo(Comun.conexion, this.txt_correoElectronico.Text))
                    {
                        this.txt_correoElectronico.Focus();
                        MessageBox.Show(this, "El correo electrónico ya se encuentra registrado", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                if (Convert.ToInt32(this.cmb_estado.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_estado.SelectedIndex) == -1)
                {
                    this.cmb_estado.Focus();
                    MessageBox.Show(this, "Seleccione el estado del cliente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToInt32(this.cmb_municipio.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_municipio.SelectedIndex) == -1)
                {
                    this.cmb_municipio.Focus();
                    MessageBox.Show(this, "Seleccione el municipio del cliente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.dtp_fechaNacimiento.Value.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    this.dtp_fechaNacimiento.Focus();
                    MessageBox.Show(this, "Escriba una fecha de nacimiento valida", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txt_colonia.Text == string.Empty || this.txt_colonia.Text == "")
                {
                    this.txt_colonia.Focus();
                    MessageBox.Show(this, "Escriba la colonia del cliente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToInt32(this.cmb_membresia.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_membresia.SelectedIndex) == -1)
                {
                    this.cmb_membresia.Focus();
                    MessageBox.Show(this, "Seleccione la ocupación del cliente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToInt32(this.cmb_genero.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_genero.SelectedIndex) == -1)
                {
                    this.cmb_genero.Focus();
                    MessageBox.Show(this, "Seleccione el género del cliente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txt_telefono.Text == string.Empty || this.txt_telefono.Text == "")
                {
                    this.txt_telefono.Focus();
                    MessageBox.Show(this, "Escriba el teléfono del cliente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if(this.txt_curp.Text == string.Empty)
                {
                    this.txt_curp.Focus();
                    MessageBox.Show(this, "Escriba el curp del cliente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txt_direccion.Text == string.Empty)
                {
                    this.txt_direccion.Focus();
                    MessageBox.Show(this, "Escriba la dirección del cliente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
            catch (Exception)
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
                    MessageBox.Show(this, "Los datos se guardaron correctamente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion
        #region Validaciones
        private void txt_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloTexto(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmClientes_Bunifu ~ txt_nombre_KeyPress");
            }
        }

        private void txt_nombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_nombre_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txt_apellidoPaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloTexto(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmClientes_Bunifu ~ txt_apellidoPaterno_KeyPress");
            }
        }

        private void txt_apellidoPaterno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_apellidoPaterno_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txt_apellidoMaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloTexto(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmClientes_Bunifu ~ txt_apellidoMaterno_KeyPress");
            }
        }

        private void txt_apellidoMaterno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_apellidoMaterno_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txt_correoElectronico_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.TextoNumerosPuntoGuionTilde(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmClientes_Bunifu ~ txt_correoElectronico_KeyPress");
            }
        }

        private void txt_correoElectronico_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_correoElectronico_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txt_colonia_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.TextoNumerosPuntoGuionTilde(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmClientes_Bunifu ~ txt_colonia_KeyPress");
            }
        }

        private void txt_colonia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_colonia_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.NumeroTelefono(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmClientes_Bunifu ~ txt_telefono_KeyPress");
            }
        }

        private void txt_telefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_telefono_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txt_curp_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloAlfaNumerico(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmClientes_Bunifu ~ txt_curp_KeyPress");
            }
        }

        private void txt_curp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_curp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txt_codigoMonedero_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloNumerico(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmClientes_Bunifu ~ txt_codigoMonedero_KeyPress");
            }
        }

        private void txt_codigoMonedero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_codigoMonedero_MouseDown(object sender, MouseEventArgs e)
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
                LogError.AddExcFileTxt(ex, "frmClientes_Bunifu ~ btnCerrar_Click");
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
                        this.GuardarCliente();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmClientes_Bunifu ~ btnCerrar_Click");
            }
        }

        private void cmb_estado_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                MunicipioNegocio municipio_negocio = new MunicipioNegocio();
                Municipio municipio = new Municipio();
                municipio.conexion = Comun.conexion;
                municipio.id_pais = 143;
                municipio.id_estado = Convert.ToInt32(this.cmb_estado.SelectedValue);
                municipio_negocio.ObtenerComboMunicipio(municipio);
                this.cmb_municipio.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_municipio.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_municipio.DataSource = municipio.datos;
                this.cmb_municipio.DisplayMember = "descripcion";
                this.cmb_municipio.ValueMember = "id_municipio";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmClientes_Bunifu ~ cmb_estado_SelectedValueChanged");
            }
        }
        #endregion

        
    }
}
