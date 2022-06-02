using TintoreriaGlobal;
using TintoreriaNegocio;
using PuntodeVentaTintoreria.ClaseAux;
using System;
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
    public partial class frmAbrirCaja : Form
    {
       
        public frmAbrirCaja()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCaja_AperturaCaja ~ frmCaja_AperturaCaja()");
                this.DialogResult = DialogResult.Abort;
            }

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
            try
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCaja_AperturaCaja ~ btnCerrar_Click");
                this.DialogResult = DialogResult.Abort;
            }
        }



        /***********************************************************************************************************************/


       
       
        #region Metodos Generales
        private void inicializar()
        {
            try
            {
                this.inicializarTextbox();
                this.TxtNomCajero.Text = Comun.u_nombre + " " + Comun.u_apellidoP + " " + Comun.u_apellidoM;
                this.TxtFecha.Text = DateTime.Now.ToShortDateString();
                this.TxtHora.Text = DateTime.Now.ToString("HH:mm:ss"); //HH FORMAT 24 HOURS
                this.TxtB1000P.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void guardarAperturaCaja()
        {
            try
            {
                Caja caja = new Caja();
                caja.CadConexion = Comun.conexion;
                caja = this.obtenerDatos();
                CajaNegocio caja_negocio = new CajaNegocio();
                int verificador = caja_negocio.GuardarAperturaCaja(caja);
                if (verificador == 0)
                {
                    MessageBox.Show(this, "Error al insertar los datos.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private Caja obtenerDatos()
        {
            try
            {
                this.inicializarTextbox();
                Caja caja = new Caja();
                caja.CadConexion = Comun.conexion;
                caja.id_caja = Comun.id_caja;
                caja.id_equipo = Comun.id_equipo;
                caja.M50C = Convert.ToInt32(this.TxtM50C.Text);
                caja.M1P = Convert.ToInt32(this.TxtM1P.Text);
                caja.M2P = Convert.ToInt32(this.TxtM2P.Text);
                caja.M5P = Convert.ToInt32(this.TxtM5P.Text);
                caja.M10P = Convert.ToInt32(this.TxtM10P.Text);
                caja.M20P = Convert.ToInt32(this.TxtM20P.Text);
                caja.M100P = Convert.ToInt32(this.TxtM100P.Text);
                caja.B20P = Convert.ToInt32(this.TxtB20P.Text);
                caja.B50P = Convert.ToInt32(this.TxtB50P.Text);
                caja.B100P = Convert.ToInt32(this.TxtB100P.Text);
                caja.B200P = Convert.ToInt32(this.TxtB200P.Text);
                caja.B500P = Convert.ToInt32(this.TxtB500P.Text);
                caja.B1000P = Convert.ToInt32(this.TxtB1000P.Text);
                caja.Total = this.calcularTotal();
                caja.Id_U = Comun.id_u;
                caja.FechaIngreso = this.TxtFecha.Text;
                caja.HoraIngreso = this.TxtHora.Text;
                caja.id_sucursal = Comun.id_sucursal;
                return caja;
            }
            catch (Exception ex)
            {

                return null;

            }
        }
        private float calcularTotal()
        {
            try
            {
                float centavos = 0, total = 0;
                int m50c, m1p, m2p, m5p, m10p, m20p, m100p, b20p, b50p, b100p, b200p, b500p, b1000p;
                m1p = m50c = m2p = m5p = m10p = m20p = m100p = b20p = b50p = b100p = b200p = b500p = b1000p = 0;
                int.TryParse(this.TxtM1P.Text, out m1p);
                int.TryParse(this.TxtM2P.Text, out m2p);
                int.TryParse(this.TxtM5P.Text, out m5p);
                int.TryParse(this.TxtM10P.Text, out m10p);
                int.TryParse(this.TxtM20P.Text, out m20p);
                int.TryParse(this.TxtM100P.Text, out m100p);
                int.TryParse(this.TxtB20P.Text, out b20p);
                int.TryParse(this.TxtB50P.Text, out b50p);
                int.TryParse(this.TxtB100P.Text, out b100p);
                int.TryParse(this.TxtB200P.Text, out b200p);
                int.TryParse(this.TxtB500P.Text, out b500p);
                int.TryParse(this.TxtB1000P.Text, out b1000p);
                int.TryParse(this.TxtM50C.Text, out m50c);
                centavos = m50c * 0.5F;
                total = centavos + m1p + (m2p * 2) +
                    (m5p * 5) + (m10p * 10) +
                    ((m20p + b20p) * 20) +
                    ((m100p + b100p) * 100) +
                    (b50p * 50) + (b200p * 200) +
                    (b500p * 500) + (b1000p * 1000);
                return total;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        private void inicializarTextbox()
        {
            try
            {
                if (this.TxtM50C.Text == "" || this.TxtM50C.Text == string.Empty)
                    this.TxtM50C.Text = "0";
                if (this.TxtM1P.Text == "" || this.TxtM1P.Text == string.Empty)
                    this.TxtM1P.Text = "0";
                if (this.TxtM2P.Text == "" || this.TxtM2P.Text == string.Empty)
                    this.TxtM2P.Text = "0";
                if (this.TxtM5P.Text == "" || this.TxtM5P.Text == string.Empty)
                    this.TxtM5P.Text = "0";
                if (this.TxtM10P.Text == "" || this.TxtM10P.Text == string.Empty)
                    this.TxtM10P.Text = "0";
                if (this.TxtM20P.Text == "" || this.TxtM20P.Text == string.Empty)
                    this.TxtM20P.Text = "0";
                if (this.TxtM100P.Text == "" || this.TxtM100P.Text == string.Empty)
                    this.TxtM100P.Text = "0";
                if (this.TxtB20P.Text == "" || this.TxtB20P.Text == string.Empty)
                    this.TxtB20P.Text = "0";
                if (this.TxtB50P.Text == "" || this.TxtB50P.Text == string.Empty)
                    this.TxtB50P.Text = "0";
                if (this.TxtB100P.Text == "" || this.TxtB100P.Text == string.Empty)
                    this.TxtB100P.Text = "0";
                if (this.TxtB200P.Text == "" || this.TxtB200P.Text == string.Empty)
                    this.TxtB200P.Text = "0";
                if (this.TxtB500P.Text == "" || this.TxtB500P.Text == string.Empty)
                    this.TxtB500P.Text = "0";
                if (this.TxtB1000P.Text == "" || this.TxtB1000P.Text == string.Empty)
                    this.TxtB1000P.Text = "0";
                if (this.txtTotal.Text == "" || this.txtTotal.Text == string.Empty)
                    this.txtTotal.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void permitirSoloNumeros(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                    if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion
        #region Eventos
        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.guardarAperturaCaja();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCaja_AperturaCaja ~ BtnContinuar_Click");
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void TxtM100P_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                this.permitirSoloNumeros(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCaja_AperturaCaja ~ cajas_KeyPress");
            }
        }

        private void TxtM100P_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                this.txtTotal.Text = string.Format("{0:c}", this.calcularTotal());
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCaja_AperturaCaja ~ cajas_KeyUp");
            }
        }

        private void TxtM100P_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                int aux = 0;
                int.TryParse(txt.Text, out aux);
                txt.Text = aux.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCaja_AperturaCaja ~ txtNotNull_Validating");
            }
        }






        #endregion

        private void frmAbrirCaja_Load(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.inicializar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCaja_AperturaCaja ~ frmCaja_AperturaCaja_Load");
                this.DialogResult = DialogResult.Abort;
            }
        }
    }
}
