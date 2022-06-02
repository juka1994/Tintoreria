using System;
using System.Configuration;
using System.Windows.Forms;
using TintoreriaGlobal;
using TintoreriaNegocio;

namespace PuntodeVentaTintoreria
{
    public partial class frmHistorial : Form
    {
        Validaciones Val;
        int tipoBusqueda = 1;
        public frmHistorial()
        {
            try
            {
                InitializeComponent();
                Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region MetodosGenerales
        public void CargarGridHistorial(string busqueda, int tipoBusqueda)
        {
            try
            {
                AlmacenNegocio almacen_negocio = new AlmacenNegocio();
                Almacen almacen = new Almacen();
                almacen.conexion = Comun.conexion;
                almacen.busqueda = busqueda;
                almacen.tipoBusqueda = tipoBusqueda;
                almacen_negocio.LLenarGridHistorial(almacen);
                this.GridViewHistorial.AutoGenerateColumns = false;
                this.GridViewHistorial.DataSource = almacen.datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion
        #region Validaciones
        private void txt_buscador_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.TextoNumerosPuntoGuionTilde(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_buscador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_buscador_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        

        private void frmHistorial_Load(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.CargarGridHistorial("", tipoBusqueda);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.CargarGridHistorial(this.txt_buscador.Text, 1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txt_buscador_Click(object sender, EventArgs e)
        {
            try
            {
                txt_buscador.SelectAll();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.txt_buscador.Text = "";
                this.CargarGridHistorial("", 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Events
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void txt_buscador_Click_1(object sender, EventArgs e)
        {
            this.txt_buscador.Text = string.Empty;
        }
    }
}
