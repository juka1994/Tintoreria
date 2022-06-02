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
    public partial class frm_EnvioDetalleGrid : Form
    {
        private int id_envio;
        public frm_EnvioDetalleGrid(int _dat)
        {
            InitializeComponent();
            id_envio = _dat;
        }
        private void frm_EnvioDetalleGrid_Load(object sender, EventArgs e)
        {
            try
            {
                this.LLenarGridEnvio();               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Metodos Generales

        public void LLenarGridEnvio()
        {
            try
            {
                EnvioDetalleNegocio _eNEgocio = new EnvioDetalleNegocio();
                List<EnvioDetalle>Lista = _eNEgocio.CargarDatosGridEnvio(id_envio);
                GridViewGeneral.AutoGenerateColumns = false;
                GridViewGeneral.DataSource = Lista; //_eNEgocio.CargarDatosGridEnvio(id_envio);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Tintoreria", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                int verificador = -1;
                EnvioDetalleNegocio _EDN = new EnvioDetalleNegocio();
                List<EnvioDetalle> Lista = (List<EnvioDetalle>)GridViewGeneral.DataSource;
                DataTable tabla = ObtenerTabla(Lista);
                string user = Comun.id_u;
                _EDN.GuardarDatos(tabla,user,ref verificador);

                if(verificador == 1)
                {
                    MessageBox.Show("Datos Guardados correctamente!!!", "Sistema Tintoreria");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Sistema Administrador CSL", "Sistema Administrador CSL", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Tintoreria", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ObtenerTabla(List<EnvioDetalle>lista)
        {
            try
            {
                DataTable tbl = new DataTable();
                tbl.Columns.Add("id_envioDetalle", typeof(int));
                tbl.Columns.Add("recibe", typeof(string));
                tbl.Columns.Add("observacion", typeof(string));
                tbl.Columns.Add("id_status", typeof(int));          
                foreach (var item in lista)
                {
                    tbl.Rows.Add(new object[] { item.id_envioDetalle, item.recibe, item.observacion, item.idStatusEnvio});                 
                }
                return tbl;
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
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Tintoreria", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Tintoreria", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_LLegadaEnvio_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Tintoreria", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion       
    }
}
