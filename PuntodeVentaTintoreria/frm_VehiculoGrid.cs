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
    public partial class frm_VehiculoGrid : Form
    {
        
        public frm_VehiculoGrid()
        {
            InitializeComponent();           
        }

        private void frm_VehiculoGrid_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarDatosGridVehiculo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Metodos Generales
        public void CargarDatosGridVehiculo()
        {
            try
            {
                VehiculoNegocio _vehNegocio = new VehiculoNegocio();
                Vehiculo _vehiculo = new Vehiculo();
                _vehiculo.conexion = Comun.conexion;
                _vehNegocio.obtenerVehiculo(_vehiculo);
                this.GridviewGeneral.AutoGenerateColumns = false;
                this.GridviewGeneral.DataSource = _vehiculo.datosTabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema punto de Venta Lavanderia", MessageBoxButtons.OK ,MessageBoxIcon.Error);               
            }
        }

        private bool ValidarFilaSeleccionada(List<DataGridViewRow> rowSelected)
        {
            try
            {
                if (rowSelected.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar una fila del grid", "Sistema Punto de Venta Lavanderia",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

        public Vehiculo ObtenerDatosGridVehiculo()
        {
            try
            {
                Vehiculo _vehiculo = new Vehiculo();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    _vehiculo.ID_vehiculo = Convert.ToInt32(row.Cells["id_Vehiculo"].Value.ToString());
                    _vehiculo.NombreVeh = row.Cells["nombreVehiculo"].Value.ToString();
                    _vehiculo.placas = row.Cells["placa"].Value.ToString();
                    _vehiculo.Descripcion = row.Cells["descripcion"].Value.ToString();
                }
                return _vehiculo;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void EliminarCatVehiculo(object _Datos)
        {
            try
            {
                Vehiculo _vehiculo = (Vehiculo)_Datos;
                int Verificador = -1;
                VehiculoNegocio _vehNegocio = new VehiculoNegocio();
                _vehiculo.conexion = Comun.conexion;
                _vehiculo.IDUsuario = Comun.id_u;
                _vehNegocio.EliminarVehiculo(_vehiculo, ref Verificador);
                if (Verificador == 1)
                {
                    this.CargarDatosGridVehiculo();
                    MessageBox.Show("Los datos se eliminaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }else if (Verificador == 0)
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

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    if (MessageBox.Show("¿Desea eliminar este Registro?", "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.EliminarCatVehiculo(this.ObtenerDatosGridVehiculo());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btn_nuevoVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                frm_NuevoVehiculo newVehiculo = new frm_NuevoVehiculo(new Vehiculo());
                newVehiculo.ShowDialog();
                this.CargarDatosGridVehiculo();
                newVehiculo.Dispose();
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
                    frm_NuevoVehiculo _vehNew = new frm_NuevoVehiculo(ObtenerDatosGridVehiculo());
                    _vehNew.ShowDialog();
                    this.CargarDatosGridVehiculo();
                    _vehNew.Dispose();
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
