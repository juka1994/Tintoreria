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
    public partial class frm_nuevaMembresia : Form
    {
        private Membresias infoMembresia;
        public frm_nuevaMembresia(Membresias _membresia)
        {
            InitializeComponent();
            infoMembresia = _membresia;
        }
        private void frm_nuevaMembresia_Load(object sender, EventArgs e)
        {
            try
            {
                this.obtenerDatos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Metodos
        private void guardarMembresia()
        {
            try
            {
                int verificador = -1;
                Membresias _membresia = new Membresias();
                MembresiaNegocio _memNegocio = new MembresiaNegocio();
                this.obtenerDatos(ref _membresia);

                if (_membresia.id_TipoCredencial !=0)
                {
                    _membresia.opcion = 2;
                    _memNegocio.ABCMembresia(_membresia, ref verificador);
                }
                else
                {
                    _membresia.opcion = 1;
                    _memNegocio.ABCMembresia(_membresia, ref verificador);
                }

                if (verificador == 0)
                {
                    MessageBox.Show(this, "Los datos se guardaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void obtenerDatos()
        {
            try
            {                
                this.txt_Descripcion.Text = infoMembresia.descripcion;
                this.txt_Porcentaje.Text = infoMembresia.porcentajexVenta.ToString();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void obtenerDatos(ref Membresias _dato)
        {
            try
            {
                _dato.id_TipoCredencial = infoMembresia.id_TipoCredencial;
                _dato.descripcion = txt_Descripcion.Text;
                _dato.porcentajexVenta = Convert.ToDecimal(txt_Porcentaje.Text);
                _dato.conexion = Comun.conexion;
                _dato.id_user = Comun.id_u;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidarCampos()
        {
            try
            {
                if (this.txt_Descripcion.Text == string.Empty)
                {
                    this.txt_Descripcion.Focus();
                    MessageBox.Show(this, "Escriba la descripcion de la Membresia", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txt_Porcentaje.Text == string.Empty || Convert.ToDecimal(txt_Porcentaje.Text) < 0 || Convert.ToDecimal(txt_Porcentaje.Text) > 100)
                {
                    this.txt_Porcentaje.Focus();
                    MessageBox.Show(this, "El rango del porcentaje debe ser: 0 - 100 %", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion
        #region Eventos

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        this.guardarMembresia();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message.ToString(), "Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message.ToString(), "Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
