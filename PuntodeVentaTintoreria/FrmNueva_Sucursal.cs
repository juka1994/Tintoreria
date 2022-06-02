using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TintoreriaGlobal;
using TintoreriaNegocio;

namespace PuntodeVentaTintoreria
{
    public partial class FrmNueva_Sucursal : Form
    {
        private Sucursal infoSucursal;
        private Validaciones Val;
        public FrmNueva_Sucursal(Sucursal sucursal)
        {
            InitializeComponent();
            infoSucursal = sucursal;
            Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
        }

        private void FrmNueva_Sucursal_Load(object sender, EventArgs e)
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
            }

        }
        #region Metodos Generales
        private void cmb_estado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.cmb_estado.SelectedIndex != -1)
                {
                    String Value = this.cmb_estado.SelectedValue.ToString();
                    int IDEstado = 0;
                    int.TryParse(Value, out IDEstado);
                    this.llenarComboMunicipio(IDEstado);
                }
                else
                {
                    MessageBox.Show(this, "Seleccione un elemento de la lista", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Inicializar()
        {
            try
            {
                this.llenarComboEstado();
                this.llenarComboIva();
                this.llenarComboTipoSucursal(1);
                if (infoSucursal.id_sucursal != null)
                {
                    this.llenarComboTipoSucursal(2);
                    this.lbTitulo.Text = "Editar Sucursal";
                    this.cmb_tipoSucursal.Enabled = false;
                    this.LLenarDatos();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void LLenarDatos()
        {
            try
            {
                infoSucursal.id_pais = 1;
                this.txt_sucursal.Text = infoSucursal.nombre.ToString();
                this.txt_direccion.Text = infoSucursal.direccion.ToString();
                this.txt_telefono.Text = infoSucursal.telefono.ToString();
                this.txt_codigoPostal.Text = infoSucursal.codigoPostal.ToString();
                this.cmb_tipoSucursal.SelectedValue = infoSucursal.id_tipoSucursal.ToString();
                this.cmb_estado.SelectedValue = infoSucursal.id_estado.ToString();
                this.cmb_municipio.SelectedValue = infoSucursal.id_municipio.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void llenarComboTipoSucursal(int opcion)
        {
            try
            {
                TipoSucursal tipoSucursal = new TipoSucursal();
                tipoSucursal.conexion = Comun.conexion;
                tipoSucursal.opcion = opcion;
                TipoSucursalNegocio tipoSucursal_Negocio = new TipoSucursalNegocio();
                tipoSucursal = tipoSucursal_Negocio.ObtenerComboTipoSucursal(tipoSucursal);
                this.cmb_tipoSucursal.DataSource = tipoSucursal.datos;
                this.cmb_tipoSucursal.DisplayMember = "descripcion";
                this.cmb_tipoSucursal.ValueMember = "id_tipoSucursal";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void llenarComboEstado()
        {
            try
            {
                EstadoNegocio estado_negocio = new EstadoNegocio();
                Estado estado = new Estado();
                estado.conexion = Comun.conexion;
                estado.id_pais = 143;
                estado_negocio.ObtenerComboEstado(estado);
                this.cmb_estado.DataSource = estado.datos;
                this.cmb_estado.DisplayMember = "descripcion";
                this.cmb_estado.ValueMember = "id_estado";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void llenarComboMunicipio(int IDEstado)
        {
            try
            {
                Municipio municipio = new Municipio();
                municipio.conexion = Comun.conexion;
                MunicipioNegocio municipio_negocio = new MunicipioNegocio();
                municipio.id_pais = 143;
                municipio.id_estado = IDEstado;
                municipio_negocio.ObtenerComboMunicipio(municipio);
                this.cmb_municipio.DisplayMember = "descripcion";
                this.cmb_municipio.ValueMember = "id_municipio";
                this.cmb_municipio.DataSource = municipio.datos;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void GuadarCatSucursal()
        {
            try
            {
                int Verificador = 0;
                Sucursal sucursal = new Sucursal();
                sucursal.conexion = Comun.conexion;
                SucursalNegocio sucursal_Negocio = new SucursalNegocio();
                this.ObtenerDatos(ref sucursal);
                if (sucursal_Negocio.ContarSucursales(Comun.conexion) != 0 && sucursal_Negocio.ContarSucursales(Comun.conexion) < 1000)
                {
                    if (sucursal.id_sucursal != null)
                    {
                        sucursal.opcion = 2;
                        sucursal_Negocio.AbcSucursal(sucursal, ref Verificador);
                    }
                    else
                    {
                        sucursal.opcion = 1;
                        sucursal_Negocio.AbcSucursal(sucursal, ref Verificador);
                    }
                    this.VerifcarMensajeAccion(Verificador);
                }
                else
                {
                    MessageBox.Show(this, "Número maximo de sucursales registradas", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ObtenerDatos(ref Sucursal sucursal)
        {
            try
            {
                sucursal.id_sucursal = infoSucursal.id_sucursal;
                sucursal.id_tipoSucursal = Convert.ToInt32(this.cmb_tipoSucursal.SelectedValue);
                sucursal.nombre = this.txt_sucursal.Text;
                sucursal.direccion = this.txt_direccion.Text;
                sucursal.telefono = this.txt_telefono.Text;
                sucursal.codigoPostal = this.txt_codigoPostal.Text;
                sucursal.id_pais = 143;
                sucursal.id_estado = Convert.ToInt32(this.cmb_estado.SelectedValue);
                sucursal.id_municipio = Convert.ToInt32(this.cmb_municipio.SelectedValue);
                sucursal.id_iva = Convert.ToInt32(this.cmb_iva.SelectedValue);
                sucursal.id_u = Comun.id_u;
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
                Val = new Validaciones();
                if (Convert.ToInt32(this.cmb_tipoSucursal.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_tipoSucursal.SelectedIndex) == -1)
                {
                    this.cmb_tipoSucursal.Focus();
                    MessageBox.Show(this, "Seleccione el tipo de sucursal", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txt_codigoPostal.Text == string.Empty || this.txt_codigoPostal.Text == "")
                {
                    this.txt_codigoPostal.Focus();
                    MessageBox.Show(this, "Escriba el codigo postal de la sucursal", "Sistema Punto de VentaLavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txt_sucursal.Text == string.Empty || this.txt_sucursal.Text == "")
                {
                    this.txt_sucursal.Focus();
                    MessageBox.Show(this, "Escriba el nombre de la sucursal", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToInt32(this.cmb_estado.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_estado.SelectedIndex) == -1)
                {
                    this.cmb_estado.Focus();
                    MessageBox.Show(this, "Seleccione el estado", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txt_telefono.Text == string.Empty || this.txt_telefono.Text == "")
                {
                    this.txt_telefono.Focus();
                    MessageBox.Show(this, "Escriba el teléfono de sucursal", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToInt32(this.cmb_municipio.SelectedIndex) == 0 || Convert.ToInt32(this.cmb_municipio.SelectedIndex) == -1)
                {
                    this.cmb_municipio.Focus();
                    MessageBox.Show(this, "Seleccione el municipio", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txt_direccion.Text == string.Empty || this.txt_direccion.Text == "")
                {
                    this.txt_direccion.Focus();
                    MessageBox.Show(this, "Escriba la dirección de la sucursal", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToInt32(this.cmb_iva.SelectedIndex) == -1)
                {
                    this.cmb_municipio.Focus();
                    MessageBox.Show(this, "Seleccione el IVA", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
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
                    decimal.TryParse(cmb_iva.SelectedValue.ToString(), out decimal iva);
                    Comun.iva = iva;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void llenarComboIva()
        {
            try
            {
                IvaNegocio iva_negocio = new IvaNegocio();
                Iva iva = new Iva();
                iva.conexion = Comun.conexion;
                iva_negocio.ObtenerComboIva(iva);
                this.cmb_iva.DataSource = iva.datos;
                this.cmb_iva.DisplayMember = "iva";
                this.cmb_iva.ValueMember = "id_iva";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmb_tipoSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (this.ValidarCampos())
                    {
                        this.GuadarCatSucursal();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
