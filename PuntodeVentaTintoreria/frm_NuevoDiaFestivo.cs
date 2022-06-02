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
    public partial class frm_NuevoDiaFestivo : Form
    {
        private DiasFestivos infoDiasF;
        public frm_NuevoDiaFestivo(DiasFestivos _dat)
        {
            InitializeComponent();
            infoDiasF = _dat;
        }

        private void frm_NuevoDiaFestivo_Load(object sender, EventArgs e)
        {
            try
            {
                this.MostrarDatos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Metodos Generales
        private void GuardarDiasFestivos()
        {
            try
            {
                int verificador = -1;
                DiasFestivos _dias = new DiasFestivos();
                this.obtenerDatos(_dias);
                DiasFestivosNegocio _dNegocio = new DiasFestivosNegocio();
                if (_dias.id_diasFestivos != 0)
                {
                    _dias.opcion = 2;
                    _dNegocio.ABCDiasFestivos(_dias,ref verificador);
                }
                else
                {
                    _dias.opcion = 1;
                    _dNegocio.ABCDiasFestivos(_dias, ref verificador);
                }

                this.Mensaje(verificador);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Mensaje(int verificador)
        {
            try
            {
                switch (verificador)
                {
                    case 0:
                        MessageBox.Show(this, "Los datos se guardaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        break;
                    case 1:
                        MessageBox.Show(this, "Error al intentar guardar los datos", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    case 2:
                        MessageBox.Show(this, "Existen Pedidos Pendientes por entregar en la fecha: " + dtp_horaPedido.Value.ToString("dd/MM/yyyy"), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.Close();
                        frm_PedidosPendiestesXfecha _pedido = new frm_PedidosPendiestesXfecha(dtp_horaPedido.Value);
                        _pedido.ShowDialog();
                        _pedido.Dispose();                                       
                        break;
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void obtenerDatos(DiasFestivos dias)
        {
            try
            {
                dias.id_diasFestivos = infoDiasF.id_diasFestivos;
                dias.descripcion = txt_Descripcion.Text;
                dias.diaFestivo = dtp_horaPedido.Value;
                dias.id_user = Comun.id_u;
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            try
            {
                if (this.txt_Descripcion.Text == string.Empty)
                {
                    this.txt_Descripcion.Focus();
                    MessageBox.Show(this, "Escriba la descripcion del Grupo", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void MostrarDatos()
        {
            try
            {
                this.txt_Descripcion.Text = infoDiasF.descripcion;
                this.dtp_horaPedido.Value = infoDiasF.diaFestivo;
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
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Regresar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);           
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
                        this.GuardarDiasFestivos();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion        
    }
}
