using PuntodeVentaTintoreria.ClaseAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TintoreriaGlobal;
using TintoreriaNegocio;

namespace PuntodeVentaTintoreria
{
    public partial class FrmMembresìa_Editar : Form
    {
        private Credenciales infoCredenciales;
        private Validaciones Val;

        public FrmMembresìa_Editar(Credenciales credencial)
        {
            InitializeComponent();
            infoCredenciales = credencial;
            Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
            infoCredenciales.id_credencial = "1";
        }

        #region Metodos Generales
        private void Inicializar()
        {
            try
            {
                
                if (infoCredenciales.id_credencial != null)
                {
                    this.LLenarDatos();
                }
                this.ActiveControl = this.txt_nombre;
                this.txt_nombre.Focus();
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
                this.txt_nombre.Text = infoCredenciales.nombreCompleto.ToString();
                this.txt_tipoMonedero.Text = infoCredenciales.tipoCredencial.ToString();
                this.txt_codigo.Text = infoCredenciales.id_codigoEab.ToString();
                this.txt_puntos.Text = infoCredenciales.puntos.ToString();
                this.txt_monedero.Text = infoCredenciales.monedero.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void GuadarCatCredencial()
        {
            try
            {
                int Verificador = 0;
                Credenciales Credencial = new Credenciales();
                Credencial.conexion = Comun.conexion;
                CredencialNegocio Credencial_Negocio = new CredencialNegocio();
                this.ObtenerDatos(ref Credencial);
                if (Credencial.id_credencial != null)
                {
                    Credencial.opcion = 2;
                    Credencial_Negocio.AbcCredenciales(Credencial, ref Verificador);
                }
                this.VerifcarMensajeAccion(Verificador);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ObtenerDatos(ref Credenciales credencial)
        {
            try
            {
                credencial.id_credencial = infoCredenciales.id_credencial;
                credencial.puntos = Convert.ToInt32(this.txt_puntos.Text);
                credencial.monedero = decimal.Parse(this.txt_monedero.Text, CultureInfo.InvariantCulture.NumberFormat);
                credencial.id_u = Comun.id_u;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private bool ValidarCampos()
        {
            Validaciones Val = new Validaciones();
            try
            {
                if (this.txt_puntos.Text.Length == 0)
                {
                    this.txt_puntos.Focus();
                    MessageBox.Show(this, "Escriba la cantidad de puntos", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txt_monedero.Text.Length == 0)
                {
                    this.txt_monedero.Focus();
                    MessageBox.Show(this, "Escriba la cantidad del monedero", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #endregion

        private void FrmMembresìa_Editar_Load(object sender, EventArgs e)
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
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderìa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmMembresìa_Editar~ FrmMembresìa_Editar_Load");
            }
        }
        #region Validaciones
        private void txt_puntos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_puntos_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloNumerico(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_puntos_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txt_monedero_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_monedero_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloDecimal(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_monedero_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        #endregion

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (this.ValidarCampos())
                    {
                        this.GuadarCatCredencial();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmMembresia_Editar ~ btnGuardar_Click");
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_nombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
