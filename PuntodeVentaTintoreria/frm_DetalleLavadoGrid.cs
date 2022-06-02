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
    public partial class frm_DetalleLavadoGrid : Form
    {
        public frm_DetalleLavadoGrid()
        {
            InitializeComponent();
        }

        private void frm_DetalleLavadoGrid_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarDatosGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Metodos Generales
        private void CargarDatosGrid()
        {
            try
            {
                CompraNegocio _DNegocio = new CompraNegocio();
                _DNegocio.CargarDatosGrid();
                GridViewGeneral.AutoGenerateColumns = false;
                GridViewGeneral.DataSource = _DNegocio.CargarDatosGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFilaSeleccionada(List<DataGridViewRow> rowSelected)
        {
            try
            {
                if (rowSelected.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar una fila del grid", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
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

        public DetalleLavado ObtenerDatosLavado()
        {
            try
            {
                DetalleLavado _detalleL = new DetalleLavado();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    _detalleL.id_lavado = row.Cells["id_lavado"].Value.ToString();
                    _detalleL.id_status = Convert.ToInt32(row.Cells["id_status"].Value.ToString());
                }
                return _detalleL;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Eventos
        private void btn_nuevoDetalleLavado_Click(object sender, EventArgs e)
        {
            try
            {
                frm_LavadoGrid _lavado = new frm_LavadoGrid(new DetalleLavado(),1);
                _lavado.ShowDialog();
                this.CargarDatosGrid();
                _lavado.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                throw ex;
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
                throw ex;
            }
        }
        private void btnEntregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    frm_LavadoGrid _dLavado = new frm_LavadoGrid(this.ObtenerDatosLavado(),2);
                    _dLavado.ShowDialog();
                    this.CargarDatosGrid();
                    _dLavado.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        private void btn_FinalizarLavadoDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    if (this.ObtenerDatosLavado().id_status != 2)
                    {
                        frm_LavadoGrid _dLavado = new frm_LavadoGrid(this.ObtenerDatosLavado(), 3);
                        _dLavado.ShowDialog();
                        this.CargarDatosGrid();
                        _dLavado.Dispose();
                    }
                    else
                    {
                    MessageBox.Show("El registro se encuentra con status \"Finalizado\"", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
