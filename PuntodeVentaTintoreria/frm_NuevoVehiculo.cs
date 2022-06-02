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
    public partial class frm_NuevoVehiculo : Form
    {
        private Vehiculo infoVehiculo;
        private Validaciones Val;
        public frm_NuevoVehiculo(Vehiculo _vehiculo)
        {
            InitializeComponent();
            infoVehiculo = _vehiculo;            
        }
        private void frm_NuevoVehiculo_Load(object sender, EventArgs e)
        {
            using (new Recursos.CursorWait())
            {
                this.Init();
            }
        }
        #region Metodos Generales
        private void Init()
        {
            try
            {
                if (infoVehiculo.ID_vehiculo != 0)
                {
                    ObtenerDatosVehiculo();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ObtenerDatosVehiculo()
        {
            try
            {
                this.txt_vehiculo.Text = infoVehiculo.NombreVeh.ToString();
                this.txt_Placa.Text = infoVehiculo.placas.ToString();
                this.txt_Descripcion.Text = infoVehiculo.Descripcion.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarVehiculo()
        {
            try
            {
                int Verificador = -1;
                Vehiculo _veh = new Vehiculo();
                _veh.conexion = Comun.conexion;
                _veh.IDUsuario = Comun.id_u;
                VehiculoNegocio _vehNegocio = new VehiculoNegocio();
                this.ObtenerDatosVehiculo(ref _veh);
                if (_veh.ID_vehiculo != 0)
                {
                    _veh.opcion = 2;
                    _vehNegocio.AbcVehiculo(_veh, ref Verificador);
                }
                else
                {
                    _veh.opcion = 1;
                    _vehNegocio.AbcVehiculo(_veh, ref Verificador);
                }
                this.VerifcarMensajeAccion(Verificador);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerDatosVehiculo(ref Vehiculo veh)
        {
            try
            {
                veh.ID_vehiculo = infoVehiculo.ID_vehiculo;
                veh.NombreVeh = this.txt_vehiculo.Text;
                veh.placas = this.txt_Placa.Text;
                veh.Descripcion = this.txt_Descripcion.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VerifcarMensajeAccion(int Verificador)
        {
            try
            {
                if (Verificador == 0)
                {
                    MessageBox.Show(this, "Los datos se guardaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);                  
                    this.Close();
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

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (this.ValidarCampos())
                    {
                        this.GuardarVehiculo();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool ValidarCampos()
        {
            try
            {
                Val = new Validaciones();
               
                if (this.txt_vehiculo.Text == string.Empty)
                {
                    this.txt_vehiculo.Focus();
                    MessageBox.Show(this, "Escriba el tipo de vehiculo", "Sistema Punto de VentaLavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txt_Placa.Text == string.Empty)
                {
                    this.txt_Placa.Focus();
                    MessageBox.Show(this, "Escriba la placa del vehiculo", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }               
                if (this.txt_Descripcion.Text == string.Empty)
                {
                    this.txt_Descripcion.Focus();
                    MessageBox.Show(this, "Escriba la descripcion del vehiculo", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }               
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion

     
    }
}
