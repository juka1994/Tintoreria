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
    public partial class Frm_UsuarioGrid : Form
    {
        
        public Frm_UsuarioGrid()
        {
            InitializeComponent();           
        }

        private void Frm_UsuarioGrid_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarDatosGridUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Metodos Generales
        public void CargarDatosGridUsuario()
        {
            try
            {
                UsuarioNegocio _usuarioNegocio = new UsuarioNegocio();
                Usuario _usuario = new Usuario();
                _usuario.conexion = Comun.conexion;
                _usuarioNegocio.LLenarGridUsuario(_usuario);
                this.GridviewGeneral.AutoGenerateColumns = false;
                this.GridviewGeneral.DataSource = _usuario.datos;
                //UsuarioNegocio _vehNegocio = new UsuarioNegocio();
                //Usuario _usuario = new Usuario();
                //_usuario.conexion = Comun.conexion;
                //_usuario.obtenerVehiculo(_vehiculo);
                //this.GridviewGeneral.AutoGenerateColumns = false;
                //this.GridviewGeneral.DataSource = _vehiculo.datosTabla;
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

        public Usuario ObtenerDatosGridUsuario()
        {
            try
            {
                Usuario _usuario = new Usuario();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    _usuario.nombre = row.Cells["nombre"].Value.ToString();
                    _usuario.id_sucursal = row.Cells["Id_Sucursal"].Value.ToString();
                    _usuario.id_tipoUsuario = Convert.ToInt32(row.Cells["id_tipoUsuario"].Value.ToString());
                    _usuario.fechaNacimiento = Convert.ToDateTime(row.Cells["fechaNacimiento"].Value);
                    _usuario.telefono = row.Cells["telefono"].Value.ToString();
                    _usuario.user = row.Cells["user"].Value.ToString();
                    //_vehiculo.ID_vehiculo = Convert.ToInt32(row.Cells["id_Vehiculo"].Value.ToString());
                    //_vehiculo.NombreVeh = row.Cells["nombreVehiculo"].Value.ToString();
                    //_vehiculo.placas = row.Cells["placa"].Value.ToString();
                    //_vehiculo.Descripcion = row.Cells["descripcion"].Value.ToString();
                }
                return _usuario;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void EliminarCatUsuario(object _Datos)
        {
            try
            {
                Usuario _usuario = (Usuario)_Datos;
                int Verificador = -1;
                UsuarioNegocio _usuNegocio = new UsuarioNegocio();
                _usuario.conexion = Comun.conexion;
                _usuario.id_usuario= Comun.id_u;
                //_usuNegocio.EliminarUsuario(_vehiculo, ref Verificador);
                if (Verificador == 1)
                {
                    //this.CargarDatosGridVehiculo();
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
                       // this.EliminarCatVehiculo(this.ObtenerDatosGridUsario());
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
               // this.CargarDatosGridVehiculo();
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
                    //frm_NuevoVehiculo _vehNew = new frm_NuevoVehiculo(ObtenerDatosGridVehiculo());
                    //_vehNew.ShowDialog();
                    //this.CargarDatosGridVehiculo();
                    //_vehNew.Dispose();
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
