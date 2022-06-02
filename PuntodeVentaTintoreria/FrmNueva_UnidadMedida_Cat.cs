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
    public partial class FrmNueva_UnidadMedida_Cat : Form
    {
        private UnidadMedida oItem;
        private Validaciones Val;

        public FrmNueva_UnidadMedida_Cat(UnidadMedida oItem)
        {
            InitializeComponent();
            this.oItem = oItem;
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
                        this.GuadarCatUnidadMedida();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmNueva_UnidadMedida_Cat_Load(object sender, EventArgs e)
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
                if (oItem.id_unidadMedida != 0)
                {
                    this.LLenarDatos();
                    this.lbTitulo.Text = "Editar Unidad de Medida";
                }
                this.ActiveControl = this.txt_unidadMedida;
                this.txt_unidadMedida.Focus();
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
                this.txt_unidadMedida.Text = oItem.descripcion.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void GuadarCatUnidadMedida()
        {
            try
            {
                int Verificador = -1;
                UnidadMedida oUnidad = new UnidadMedida();
                UnidadMedidaNegocio oNegocio = new UnidadMedidaNegocio();
                oUnidad.conexion = Comun.conexion;
                this.ObtenerDatos(oUnidad);
                if (oUnidad.id_unidadMedida!= 0)
                {
                    oUnidad.opcion = 2;
                    oNegocio.AbcUnidadMedida(oUnidad, ref Verificador);
                }
                else
                {
                    oUnidad.opcion = 1;
                    oNegocio.AbcUnidadMedida(oUnidad, ref Verificador);
                }
                this.VerificarMensajeAccion(Verificador);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ObtenerDatos(UnidadMedida oUnidad)
        {
            try
            {
                oUnidad.id_unidadMedida = oItem.id_unidadMedida;
                oUnidad.descripcion = this.txt_unidadMedida.Text;
                oUnidad.id_u = Comun.id_u;
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
                if (this.txt_unidadMedida.Text.Length == 0)
                {
                    this.txt_unidadMedida.Focus();
                    MessageBox.Show(this, "Escriba la unidad de medida", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
