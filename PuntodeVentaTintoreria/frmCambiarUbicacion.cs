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
using TintoreriaGlobal;
using TintoreriaNegocio;

namespace PuntodeVentaTintoreria
{
    public partial class frmCambiarUbicacion : Form
    {
        private string idSucursal;
        private int idTipoServicio;
        private string id;
        private int ubicacionActual;
        private UbicacionNegocio oNegocio = new UbicacionNegocio();

        public frmCambiarUbicacion(string idSucursal, int idTipoServicio, int ubicacionActual, string id)
        {
            this.idSucursal = idSucursal;
            this.idTipoServicio = idTipoServicio;
            this.ubicacionActual = ubicacionActual;
            this.id = id;

            InitializeComponent();

            CargarComboUbicacion();
        }

        private void CargarComboUbicacion()
        {
            try
            {
                cmbUbicacion.DataSource = oNegocio.ObtenerListaUbicaciones(this.idSucursal, this.idTipoServicio);
                cmbUbicacion.DisplayMember = "Descripcion";
                cmbUbicacion.ValueMember = "IdUbicacion";

                cmbUbicacion.SelectedValue = ubicacionActual;
                if(cmbUbicacion.SelectedIndex == -1)
                {
                    cmbUbicacion.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCambiarUbicacion ~ CargarComboUbicacion");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.Guardar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmCambiarUbicacion ~ btnGuardar_Click");
            }

        }
        private void Guardar()
        {
            
            try
            {
                int id_ubicacion = (int)cmbUbicacion.SelectedValue;

                TicketNegocio oNegocio = new TicketNegocio();
                RespuestaSQL respuesta = oNegocio.Ticket_cambiarUbicacion(id, id_ubicacion);


                MessageBox.Show(this, respuesta.Mensaje, "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, respuesta.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
          
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
