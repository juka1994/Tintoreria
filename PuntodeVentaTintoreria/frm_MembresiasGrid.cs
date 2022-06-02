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
    public partial class frm_MembresiasGrid : Form
    {
        public frm_MembresiasGrid()
        {
            InitializeComponent();
        }

        private void frm_MembresiasGrid_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarDatosGridMembresias();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Metodos Generales
        private void CargarDatosGridMembresias()
        {
            try
            {
                Membresias _membresia = new Membresias();
                _membresia.conexion = Comun.conexion;
                _membresia.id_user = Comun.id_u;
                MembresiaNegocio _memNego = new MembresiaNegocio();
                _memNego.CargarDatosMembresia(_membresia);
                this.GridviewGeneral.AutoGenerateColumns = false;
                this.GridviewGeneral.DataSource = _membresia.datosTabla;
                
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

        public Membresias ObtenerDatosGridMembresia()
        {
            try
            {
                Membresias _membresia = new Membresias();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    _membresia.id_TipoCredencial = Convert.ToInt32(row.Cells["id_tipoCredencial"].Value.ToString());
                    _membresia.descripcion = row.Cells["descripcion"].Value.ToString();
                    _membresia.puntos = Convert.ToInt32(row.Cells["puntos"].Value.ToString());
                    _membresia.porcentajexVenta =Convert.ToDecimal(row.Cells["porcentajexVenta"].Value.ToString());
                }
                return _membresia;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void EliminarCatMembresia(object _Datos)
        {
            try
            {
                Membresias _mem = (Membresias)_Datos;
                int Verificador = -1;
                MembresiaNegocio _vehNegocio = new MembresiaNegocio();
                _mem.conexion = Comun.conexion;
                _mem.id_user = Comun.id_u;
                _mem.opcion = 3;
                _vehNegocio.ABCMembresia(_mem, ref Verificador);

                if (Verificador == 0)
                {
                    this.CargarDatosGridMembresias();
                    MessageBox.Show("Los datos se eliminaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Verificador == 1)
                {
                    MessageBox.Show(this, "Este registro no se puede eliminar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btn_nuevoVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                frm_nuevaMembresia _newMebresia = new frm_nuevaMembresia(new Membresias());
                _newMebresia.ShowDialog();
                this.CargarDatosGridMembresias();
                _newMebresia.Dispose();

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
                    frm_nuevaMembresia _vehNew = new frm_nuevaMembresia(ObtenerDatosGridMembresia());
                    _vehNew.ShowDialog();
                    this.CargarDatosGridMembresias();
                    _vehNew.Dispose();
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
                    if (MessageBox.Show("¿Desea eliminar este Registro?", "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.EliminarCatMembresia(this.ObtenerDatosGridMembresia());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
