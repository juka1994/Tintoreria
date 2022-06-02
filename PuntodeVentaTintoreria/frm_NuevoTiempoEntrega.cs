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
    public partial class frm_NuevoTiempoEntrega : Form
    {
        private TipoEntrega infoEntrega;
        public frm_NuevoTiempoEntrega(TipoEntrega _entrega)
        {
            InitializeComponent();
            infoEntrega = _entrega;
        }

        private void frm_NuevoTiempoEntrega_Load(object sender, EventArgs e)
        {
            try
            {              
                this.ObtenerDatos();             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region Metodos Generales
        private bool ValidarCampos()
        {
            try
            {
                if (this.txt_Descripcion.Text == string.Empty)
                {
                    this.txt_Descripcion.Focus();
                    MessageBox.Show(this, "Capture la descripcion del tipo de Entrega", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                //if (this.txt_tiempoEntrega.Text == string.Empty || Convert.ToDecimal(txt_tiempoEntrega.Text) <= 0)
                //{
                //    this.txt_tiempoEntrega.Focus();
                //    MessageBox.Show(this, "El tiempo de Entrega debe ser mayor a 0", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return false;
                //}
                if (this.txt_precioxKilo.Text == string.Empty || Convert.ToDecimal(txt_precioxKilo.Text) <= 0)
                {
                    this.txt_precioxKilo.Focus();
                    MessageBox.Show(this, "el precio por Kilogramo debe ser mayor a 0", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void ObtenerDatos()
        {
            try
            {
                this.txt_Descripcion.Text = infoEntrega.descripcion;
                //this.txt_tiempoEntrega.Text = infoEntrega.horas.ToString();
                this.txt_precioxKilo.Text = infoEntrega.precioXkilo.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void guardarTipoEntrega()
        {
             int verificador = -1;
            TipoEntrega _tipo = new TipoEntrega();
            TipoEntregaNegocio _negocio = new TipoEntregaNegocio();
            this.obtenerDatos(_tipo);

            if (_tipo.id_tipoEntrega !=0)
            {
                _tipo.opcion = 2;
                _negocio.ABCTipoEntrega(_tipo, ref verificador);
            }
            else
            {
                _tipo.opcion = 1;
                _negocio.ABCTipoEntrega(_tipo, ref verificador);
            }

            if (verificador == 0)
            {
                MessageBox.Show(this, "Los datos se guardaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void obtenerDatos(TipoEntrega _dato)
        {
            try
            {
                _dato.id_tipoEntrega = infoEntrega.id_tipoEntrega;
                _dato.descripcion = txt_Descripcion.Text;
                //_dato.horas =Convert.ToInt32(txt_tiempoEntrega.Text);
                _dato.precioXkilo = Convert.ToDecimal(txt_precioxKilo.Text);
                _dato.id_user = Comun.id_u;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region eventos
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (this.ValidarCampos())
                    {
                        this.guardarTipoEntrega();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
     
    }
}
