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
    public partial class FrmNuevo_Motivo : Form
    {
        private Motivo infoMotivo;
        private Validaciones Val;

        public FrmNuevo_Motivo(Motivo motivo)
        {
            InitializeComponent();
            infoMotivo = motivo;
            this.Inicializar();
            Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
        }
        #region Validaciones
        private void txt_motivo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_motivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_motivo_MouseDown(object sender, MouseEventArgs e)
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
                        this.GuadarCatMotivo();
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
                if (infoMotivo.id_motivo != 0)
                {
                    this.LLenarDatos();
                    this.lbTitulo.Text = "Editar Motivo";
                }
                this.ActiveControl = this.txt_motivo;
                this.txt_motivo.Focus();
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
                this.txt_motivo.Text = infoMotivo.motivo.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void GuadarCatMotivo()
        {
            try
            {
                int Verificador = -1;
                Motivo motivo = new Motivo();
                MotivoNegocio motivoNegocio = new MotivoNegocio();
                motivo.conexion = Comun.conexion;
                this.ObtenerDatos(motivo);
                if (motivo.id_motivo != 0)
                {
                    motivo.opcion = 2;
                    motivoNegocio.AbcMotivo(motivo, ref Verificador);
                }
                else
                {
                    motivo.opcion = 1;
                    motivoNegocio.AbcMotivo(motivo, ref Verificador);
                }
                this.VerificarMensajeAccion(Verificador);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ObtenerDatos(Motivo motivo)
        {
            try
            {
                motivo.id_motivo = infoMotivo.id_motivo;
                motivo.motivo = this.txt_motivo.Text;
                motivo.id_u = Comun.id_u;
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
                if (this.txt_motivo.Text.Length == 0)
                {
                    this.txt_motivo.Focus();
                    MessageBox.Show(this, "Escriba el tipo de motivo", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txt_motivo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
