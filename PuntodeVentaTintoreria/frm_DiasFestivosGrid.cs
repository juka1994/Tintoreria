using System;
using TintoreriaNegocio;
using TintoreriaGlobal;
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
    public partial class frm_DiasFestivosGrid : Form
    {
        public frm_DiasFestivosGrid()
        {
            InitializeComponent();
        }

        private void frm_DiasFestivosGrid_Load(object sender, EventArgs e)
        {
            try
            {
                this.LLenarGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Metodos Generales
        public void LLenarGrid()
        {
            try
            {
                DiasFestivosNegocio _negocio = new DiasFestivosNegocio();
                _negocio.LLenarDatosGrid();
                this.GridviewGeneral.AutoGenerateColumns = false;
                this.GridviewGeneral.DataSource = _negocio.LLenarDatosGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);            
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
                foreach (DataGridViewRow row in GridviewGeneral.Rows)
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

        private DiasFestivos ObtenerDatosGrid()
        {
            try
            {
                DiasFestivos _dias = new DiasFestivos();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    _dias.id_diasFestivos = Convert.ToInt32(row.Cells["id_fechaFestiva"].Value.ToString());
                    _dias.descripcion = row.Cells["descripcion"].Value.ToString();
                    _dias.diaFestivo = Convert.ToDateTime(row.Cells["fecha"].Value.ToString());
                }
                return _dias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EliminarDiasFestivos(object _datos)
        {
            try
            {
                DiasFestivos _dat = (DiasFestivos)_datos;
                int verificador = -1;
                _dat.opcion = 3;
                _dat.id_user = Comun.id_u;
                DiasFestivosNegocio _dNegocio = new DiasFestivosNegocio();
                _dNegocio.ABCDiasFestivos(_dat, ref verificador);

                if (verificador == 0)
                {
                    this.LLenarGrid();
                    MessageBox.Show("Los datos se eliminaron correctamente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (verificador == 1)
                {
                    MessageBox.Show("No se puedo eliminar este registro", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

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

        private void btn_nuevodiaFestivo_Click(object sender, EventArgs e)
        {
            try
            {
                frm_NuevoDiaFestivo _festivo = new frm_NuevoDiaFestivo(new DiasFestivos());            
                _festivo.ShowDialog();
                this.LLenarGrid();
                _festivo.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    try
                    {
                        frm_NuevoDiaFestivo _DFestivo = new frm_NuevoDiaFestivo(this.ObtenerDatosGrid());

                        _DFestivo.ShowDialog();
                        this.LLenarGrid();
                        _DFestivo.Dispose();                   
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    try
                    {
                        if (MessageBox.Show("¿Desea eliminar este Registro?", "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            this.EliminarDiasFestivos(this.ObtenerDatosGrid());
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
