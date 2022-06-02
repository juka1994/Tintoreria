using System;
using System.Drawing;
using System.Windows.Forms;
using TintoreriaGlobal;
using TintoreriaNegocio;

namespace PuntodeVentaTintoreria
{
    public partial class frmLoginPermisos : Form
    {
        private int opcion;
        public int VerificarOpcion = 0;

        public frmLoginPermisos(int opcion)
        {
            InitializeComponent();
            this.opcion = opcion;
        }
        
        private void PanelTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(Cursor.Position.X + e.X, Cursor.Position.Y + e.Y);
            }
        }

        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        protected virtual void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnIngresar_click(object sender, EventArgs e)
        {
            try
            {
                LoginNegocio oNegocio = new LoginNegocio();
                string usuario = txtUsuario.Text;
                string password = txtContraseña.Text;
                RespuestaSQL respuesta = oNegocio.Login_spCIDDB_Login(usuario, password);
                if (respuesta.Success)
                {
                    switch (opcion)
                    {
                        case 1:
                            VerificarOpcion = 1;
                            this.DialogResult = DialogResult.OK;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    MessageBox.Show(this, respuesta.Mensaje, Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
