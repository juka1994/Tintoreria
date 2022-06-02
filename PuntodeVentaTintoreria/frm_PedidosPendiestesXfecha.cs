using System;
using TintoreriaGlobal;
using TintoreriaNegocio;
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
    public partial class frm_PedidosPendiestesXfecha : Form
    {
        private DateTime fecha;
        public frm_PedidosPendiestesXfecha(DateTime _dat)
        {
            InitializeComponent();
            fecha = _dat;
        }

        private void frm_PedidosPendiestesXfecha_Load(object sender, EventArgs e)
        {
            try
            {
                this.LLegarGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Metodos
        private void LLegarGrid()
        {
            try
            {
                DiasFestivosNegocio _DNegocio = new DiasFestivosNegocio();               
                List<DataTable> tabla = _DNegocio.GetPedidosPendietesXfecha(fecha);
                if (tabla.Count == 2)
                {
                    GridviewTintoreria.AutoGenerateColumns = false;
                    GridviewTintoreria.DataSource = tabla[0];

                    GridviewAPP.AutoGenerateColumns = false;
                    GridviewAPP.DataSource = tabla[1];
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Eventos
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
