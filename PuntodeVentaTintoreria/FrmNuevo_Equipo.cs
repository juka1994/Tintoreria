using PuntodeVentaTintoreria.ClaseAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TintoreriaGlobal;
using TintoreriaNegocio;

namespace PuntodeVentaTintoreria
{
    public partial class FrmNuevo_Equipo : Form
    {
        private Equipo infoTipo;
        private Validaciones Val;

        public FrmNuevo_Equipo(Equipo Tipo)
        {
            InitializeComponent();
            infoTipo = Tipo;
            this.Inicializar();
        }
        #region Validaciones
        private void txt_NombreEquipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloTexto(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_NombreEquipo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_NombreEquipo_MouseDown(object sender, MouseEventArgs e)
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
                        this.Guardar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmNuevo_Motivo_Load(object sender, EventArgs e)
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
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Metodos Generales
        private void Inicializar()
        {
            try
            {
                if (!string.IsNullOrEmpty(infoTipo.id_equipo))
                {
                    this.LLenarDatos();
                    this.lbTitulo.Text = "Editar Equipo";
                }
                this.ActiveControl = this.txt_NombreEquipo;
                this.txt_NombreEquipo.Focus();
                this.ComboSucursal();
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
                this.txt_NombreEquipo.Text = infoTipo.descripcion.ToString();
                Equipo Tipo = new Equipo();
                Tipo.id_equipo = infoTipo.id_equipo;
                this.txt_NImpresora.Text = infoTipo.namePrinter;
                this.cmb_sucursal.SelectedValue = infoTipo.id_sucursal.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboSucursal()
        {
            try
            {
                if (Comun.ListaSucursales != null)
                {
                    cmb_sucursal.DataSource = Comun.ListaSucursales;
                    cmb_sucursal.ValueMember = "id_sucursal";
                    cmb_sucursal.DisplayMember = "nombre";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Guardar()
        {
            try
            {
                int Verificador = -1;
                Equipo Tipo = new Equipo();
                EquipoNegocio TipoNegocio = new EquipoNegocio();
                Tipo.conexion = Comun.conexion;
                this.ObtenerDatos(Tipo);
                if (!string.IsNullOrEmpty(Tipo.id_equipo))
                {
                    Tipo.opcion = 2;
                    TipoNegocio.AbcEquipo(Tipo, ref Verificador);
                }
                else
                {
                    Tipo.opcion = 1;
                    TipoNegocio.AbcEquipo(Tipo, ref Verificador);
                }
                this.VerificarMensajeAccion(Verificador);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmNuevo_Equipo ~ Guardar()");
            }
        }
        private void ObtenerDatos(Equipo Tipo)
        {
            try
            {
                Tipo.id_equipo = infoTipo.id_equipo;
                Tipo.nombre = this.txt_NombreEquipo.Text;
                Tipo.namePrinter = this.txt_NImpresora.Text;
                Tipo.id_sucursal = this.cmb_sucursal.SelectedValue.ToString();
                Tipo.liberarEquipo = this.chkBoxLiberar.Checked;
                Tipo.id_u = Comun.id_u;
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
                if (this.txt_NombreEquipo.Text.Length == 0)
                {
                    this.txt_NombreEquipo.Focus();
                    MessageBox.Show(this, "Escriba el nombre del equipo", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void VerificarMensajeAccion(int Verificador)
        {

            try
            {
                if (Verificador == 0)
                {
                    MessageBox.Show(this, "Los datos se guardaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show(this, "No se permite la modificación de este registro", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_SeleccionarImpresora_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog1 = new PrintDialog();
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.txt_NImpresora.Text = printDialog1.PrinterSettings.PrinterName;
            }
        }
    }
}
