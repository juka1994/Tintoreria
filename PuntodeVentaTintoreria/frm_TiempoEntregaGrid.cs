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
    public partial class frm_TiempoEntregaGrid : Form
    {
        public frm_TiempoEntregaGrid()
        {
            InitializeComponent();
        }
        private void frm_TiempoEntregaGrid_Load(object sender, EventArgs e)
        {
            try
            {
                this.LlenarDatosGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Metodos Generales
        private void LlenarDatosGrid()
        {
            try
            {
                TipoEntregaNegocio _tipoNegocio = new TipoEntregaNegocio();
                TipoEntrega _tipo = new TipoEntrega();
                _tipoNegocio.LLenarDatosGrid(_tipo);
                this.GridviewGeneral.AutoGenerateColumns = false;
                this.GridviewGeneral.DataSource = _tipo.datosTabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EliminarRegistroGrid(object _Datos){
            try
            {

                int Verificador = -1;
                TipoEntrega _tipo = (TipoEntrega) _Datos;
                TipoEntregaNegocio _tipoN = new TipoEntregaNegocio();
                _tipo.id_user = Comun.id_u;
                _tipo.opcion = 3;

                _tipoN.ABCTipoEntrega(_tipo, ref Verificador);

                if (Verificador == 0)
                {
                    this.LlenarDatosGrid();
                    MessageBox.Show("Los datos se eliminaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Verificador == 1)
                {
                    MessageBox.Show(this, "Este registro no se puede eliminar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public TipoEntrega ObtenerDatosGrid()
        {
            try
            {
                TipoEntrega _tipo = new TipoEntrega();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    _tipo.id_tipoEntrega = Convert.ToInt32(row.Cells["id_TipoEntrega"].Value.ToString());
                    _tipo.descripcion = row.Cells["descripcionEntrega"].Value.ToString();
                    _tipo.horas = Convert.ToInt32(row.Cells["horaEntrega"].Value.ToString());
                    _tipo.precioXkilo = Convert.ToDecimal(row.Cells["precioEntrega"].Value.ToString());
                }
                return _tipo;
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
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    frm_NuevoTiempoEntrega _vehNew = new frm_NuevoTiempoEntrega(ObtenerDatosGrid());
                    _vehNew.ShowDialog();
                    this.LlenarDatosGrid();
                    _vehNew.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    if (MessageBox.Show("¿Desea eliminar este Registro?", "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.EliminarRegistroGrid(this.ObtenerDatosGrid());                   
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_nuevoTentrega_Click(object sender, EventArgs e)
        {
            try
            {
                frm_NuevoTiempoEntrega _new = new frm_NuevoTiempoEntrega(new TipoEntrega());
                _new.ShowDialog();
                this.LlenarDatosGrid();
                _new.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


    }
}
