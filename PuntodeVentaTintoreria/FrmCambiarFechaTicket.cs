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

namespace Componentes
{
    public partial class FrmCambiarFechaTicket : Form
    {
        private VentaProductos infoventa;
        public FrmCambiarFechaTicket(VentaProductos venta)
        {
            InitializeComponent();
            infoventa = venta;
            infoventa.conexion = Comun.conexion;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dtp_fechaIngreso_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void FrmCambiarFechaTicket_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pnlBotones_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e)
        {

        }

        private void PanelTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void panelTitulo2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button29_Click(object sender, EventArgs e)
        {
            this.GuadarFecHA();
            this.Close();
        }

        private void ObtenerDatos(ref VentaProductos venta)
        {
            try
            {
                venta.IDVenta = infoventa.IDVenta;
                venta.FecEntrega = this.dtp_fechaIngreso.Value;
                venta.id_u = Comun.id_u;
                venta.HoraEntrega = "00:00:00.000";
                venta.IDSucursal = Comun.id_sucursal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void VerifcarMensajeAccion(int Verificador)
        {

            try
            {
               
                    MessageBox.Show(this, "Los datos se guardaron correctamente", "Sistema Punto de Venta Lavanderìa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void GuadarFecHA()
        {
            try
            {
                VentaProductos venta = new VentaProductos();
                venta.conexion = Comun.conexion;
                VentaProductosNegocio fech_Negocio = new VentaProductosNegocio();
                this.ObtenerDatos(ref venta);
   
                RespuestaSQL respuesta = fech_Negocio.ActualizarFechaEntrega(venta);
                MessageBox.Show(respuesta.Mensaje, Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, respuesta.Success ? MessageBoxIcon.Information :  MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
