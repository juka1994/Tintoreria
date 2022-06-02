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
    public partial class Frm_GridEnvio : Form
    {
        public Frm_GridEnvio()
        {
            InitializeComponent();
        }
        private void Frm_GridEnvio_Load(object sender, EventArgs e)
        {
            CargarGrid();
        }
        #region Metodos
        private void CargarGrid()
        {
            try
            {
                Envio env = new Envio();
                EnvioNegocio envNegocio = new EnvioNegocio();
                env.conexion = Comun.conexion;
                env.id_sucursal = Comun.id_sucursal;
                envNegocio.CargarGridEnvio(env);
                this.GridViewGeneral.AutoGenerateColumns = false;
                this.GridViewGeneral.DataSource = env.datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderìa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_GridEnvio ~ CargarGrid()");
            }
        }
        private bool ValidarFilaSeleccionada(List<DataGridViewRow> rowSelected)
        {
            try
            {
                if (rowSelected.Count == 0)
                {
                    MessageBox.Show(this, "Debe seleccionar una fila del grid", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private List<DataGridViewRow> ObtenerFilaSeleccionada()
        {
            try
            {
                List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();


                foreach (DataGridViewRow row in GridViewGeneral.Rows)
                {
                    if (row.Selected)
                    {
                        rowSelected.Add(row);
                    }
                }


                return rowSelected;
            }
            catch (Exception)
            {
                return null;
            }
        }
        private EnvioDetalle ObtenerDatosGrid()
        {
            try
            {
                EnvioDetalle _ED = new EnvioDetalle();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    _ED.id_envioDetalle = Convert.ToInt32(row.Cells["id_envio"].Value.ToString());                                    
                }
                return _ED;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Eventos
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnNuevoEnvio_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_GuardarEnvioV frmdg = new Frm_GuardarEnvioV();
                frmdg.ShowDialog();
                frmdg.Dispose();
                CargarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_GridEnvio ~ BtnNuevoEnvio_Click");
            }
        }

        private void btnGenerarHoja_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    Frm_Reporte R = new Frm_Reporte(1, this.ObtenerDatosGrid().id_envioDetalle);
                    R.ShowDialog();
                    R.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_GridEnvio ~ btnGenerarHoja_Click");
            }
        }

        private void btn_LLegadaEnvio_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    try
                    {
                        frm_EnvioDetalleGrid _EDGrid = new frm_EnvioDetalleGrid(this.ObtenerDatosGrid().id_envioDetalle);
                        _EDGrid.ShowDialog();
                        this.CargarGrid();
                        _EDGrid.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmHome ~ btn_LLegadaEnvio_Click");
            }
        }
        #endregion

        private void pnlPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
