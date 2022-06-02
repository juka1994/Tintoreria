using PuntodeVentaTintoreria.ClaseAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TintoreriaGlobal;
using TintoreriaNegocio;

namespace PuntodeVentaTintoreria
{
    public partial class FrmMotivo_Cat : Form
    {
        public FrmMotivo_Cat()
        {
            InitializeComponent();
            Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
        }
        #region Metodos Generales
        private void EliminarCatMotivo(Object Datos)
        {
            try
            {
                Motivo motivo = (Motivo)Datos;
                int Verificador = -1;
                MotivoNegocio motivoNegocio = new MotivoNegocio();
                motivo.opcion = 3;
                motivo.conexion = Comun.conexion;
                motivoNegocio.AbcMotivo(motivo, ref Verificador);
                if (Verificador == 0)
                {
                    this.CargarGridMotivo();
                    MessageBox.Show(this, "Los datos se eliminaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(this, "No se permite la eliminación de este registro", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private Motivo ObtenerDatosGridCatMotivo()
        {
            try
            {
                Motivo motivo = new Motivo();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    motivo.id_motivo = Convert.ToInt32(row.Cells["id_motivo"].Value.ToString());
                    motivo.motivo = row.Cells["motivo"].Value.ToString();
                    motivo.id_u = Comun.id_u;
                }
                return motivo;
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        private void CargarGridMotivo()
        {
            try
            {
                MotivoNegocio motivoNegocio = new MotivoNegocio();
                Motivo motivo = new Motivo();
                motivo.conexion = Comun.conexion;
                motivoNegocio.LLenarGridMotivo(motivo);
                this.GridviewGeneral.AutoGenerateColumns = false;
                this.GridviewGeneral.DataSource = motivo.datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
        private void FrmMotivo_Cat_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarGridMotivo();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_nuevomotivo_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNuevo_Motivo motivo = new FrmNuevo_Motivo(new Motivo());
                motivo.ShowDialog();
                this.CargarGridMotivo();
                motivo.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMotivo_Grid ~ btn_nuevo_Click");
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNuevo_Motivo motivo = new FrmNuevo_Motivo(this.ObtenerDatosGridCatMotivo());
                motivo.ShowDialog();
                this.CargarGridMotivo();
                motivo.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    if (MessageBox.Show("¿Desea eliminar este Registro?", "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.EliminarCatMotivo(this.ObtenerDatosGridCatMotivo());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
