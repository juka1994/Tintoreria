using System;
using System.Configuration;
using System.Windows.Forms;
using TintoreriaGlobal;
using TintoreriaNegocio;

namespace PuntodeVentaTintoreria
{
    public partial class FrmNueva_Marca_Cat : Form
    {
        private Marca info;
        private Validaciones Val;

        public FrmNueva_Marca_Cat(Marca oMarca)
        {
            InitializeComponent();
            info = oMarca;
            this.Inicializar();
            Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
        }
        #region Validaciones
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_MouseDown(object sender, MouseEventArgs e)
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

        private void FrmNueva_Marca_Load(object sender, EventArgs e)
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
                if (info.id_marca != 0)
                {
                    this.LLenarDatos();
                    this.lbTitulo.Text = "Editar Motivo";
                }
                this.ActiveControl = this.txt_descripcion;
                this.txt_descripcion.Focus();
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
                this.txt_descripcion.Text = info.descripcion;
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
                Marca oModelo = new Marca();
                MarcaNegocio oNegocio = new MarcaNegocio();
                oModelo.conexion = Comun.conexion;
                this.ObtenerDatos(oModelo);

                if (oModelo.id_marca != 0)
                {
                    oModelo.opcion = 2;
                }
                else
                {
                    oModelo.opcion = 1;
                }

                oNegocio.AbcMarca(oModelo, ref Verificador);
                this.VerificarMensajeAccion(Verificador);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ObtenerDatos(Marca oMarca)
        {
            try
            {
                oMarca.id_marca = info.id_marca;
                oMarca.descripcion = this.txt_descripcion.Text;
                oMarca.id_u = Comun.id_u;
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
                if (this.txt_descripcion.Text.Length == 0)
                {
                    this.txt_descripcion.Focus();
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

    }
}
