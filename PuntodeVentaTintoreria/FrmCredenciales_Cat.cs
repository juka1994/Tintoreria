using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TintoreriaGlobal;
using TintoreriaNegocio;

namespace PuntodeVentaTintoreria
{
    public partial class FrmCredenciales_Cat : Form
    {
        public FrmCredenciales_Cat()
        {
            InitializeComponent();
            Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #region Metodos Generales
        private void CargarGridCredencial()
        {
            try
            {
                CredencialNegocio credencial_negocio = new CredencialNegocio();
                Credenciales credencial = new Credenciales();
                credencial.conexion = Comun.conexion;
                credencial_negocio.LLenarGridCredenciales(credencial);
                this.GridviewGeneral.AutoGenerateColumns = false;
                this.GridviewGeneral.DataSource = credencial.datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private Credenciales ObtenerDatosGridCatCredencial()
        {
            try
            {
                Credenciales credencial = new Credenciales();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    credencial.id_credencial = row.Cells["id_credencial"].Value.ToString();
                    credencial.nombreCompleto = row.Cells["nombreCompleto"].Value.ToString();
                    credencial.tipoCredencial = row.Cells["descripcion"].Value.ToString();
                    credencial.id_codigoEab = row.Cells["id_codigoEab"].Value.ToString();
                    credencial.puntos = Convert.ToInt32(row.Cells["puntos"].Value.ToString());
                    credencial.monedero = decimal.Parse(row.Cells["monedero"].Value.ToString(), CultureInfo.InvariantCulture.NumberFormat);
                    credencial.id_cliente = row.Cells["id_cliente"].Value.ToString();
                    credencial.id_tipoCrdencial = Convert.ToInt32(row.Cells["id_tipoCredencial"].Value.ToString());
                    credencial.id_u = Comun.id_u;
                }
                return credencial;
            }
            catch (Exception ex)
            {
                return null;

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
            catch (Exception ex)
            {
                return null;
            }
        }
        private bool ValidarFilaSeleccionada(List<DataGridViewRow> rowSelected)
        {
            try
            {
                if (rowSelected.Count == 0)
                {
                    MessageBox.Show(this, "Debe seleccionar una fila del grid", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btneditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    frm_PedirAutorizacion frmab = new frm_PedirAutorizacion();
                    frmab.ShowDialog();
                    frmab.Dispose();
                    if (frmab.DialogResult == DialogResult.OK)
                    {
                       FrmMembresìa_Editar credencial1 = new FrmMembresìa_Editar(this.ObtenerDatosGridCatCredencial());
                        credencial1.ShowDialog();
                        this.CargarGridCredencial();
                        credencial1.Dispose();

                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmCredenciales_Cat_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarGridCredencial();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderìa", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void GridviewGeneral_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
