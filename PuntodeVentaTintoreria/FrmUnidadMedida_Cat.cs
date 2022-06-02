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
    public partial class FrmUnidadMedida_Cat : Form
    {
        public FrmUnidadMedida_Cat()
        {
            InitializeComponent();
            Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
        }
        #region Metodos Generales
        private void EliminarCatUnidadMedida(Object Datos)
        {
            try
            {
                UnidadMedida oUnidadMedida = (UnidadMedida)Datos;
                int Verificador = -1;
                UnidadMedidaNegocio oNegocio = new UnidadMedidaNegocio();
                oUnidadMedida.opcion = 3;
                oUnidadMedida.conexion = Comun.conexion;
                oNegocio.AbcUnidadMedida(oUnidadMedida, ref Verificador);
                if (Verificador == 0)
                {
                    this.CargarGrid();
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
        private UnidadMedida ObtenerDatosGridCatUnidadMedida ()
        {
            try
            {
                UnidadMedida oUnidadMedida = new UnidadMedida();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    oUnidadMedida.id_unidadMedida = Convert.ToInt32(row.Cells["id_unidadMedida"].Value.ToString());
                    oUnidadMedida.descripcion = row.Cells["descripcion"].Value.ToString();
                    oUnidadMedida.id_u = Comun.id_u;
                }
                return oUnidadMedida;
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        private void CargarGrid()
        {
            try
            {
                UnidadMedidaNegocio oNegocio = new UnidadMedidaNegocio();
                UnidadMedida oUnidad = new UnidadMedida();
                oUnidad.conexion = Comun.conexion;
                oNegocio.llenarGridUnidadMedida(oUnidad);
                this.GridviewGeneral.AutoGenerateColumns = false;
                this.GridviewGeneral.DataSource = oUnidad.datos;
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
        private void FrmUnidadMedida_Cat_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_nuevaUnidadMedida_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNueva_UnidadMedida_Cat motivo = new FrmNueva_UnidadMedida_Cat(new UnidadMedida());
                motivo.ShowDialog();
                this.CargarGrid();
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
                FrmNueva_UnidadMedida_Cat frm = new FrmNueva_UnidadMedida_Cat(this.ObtenerDatosGridCatUnidadMedida());
                frm.ShowDialog();
                this.CargarGrid();
                frm.Dispose();
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
                        this.EliminarCatUnidadMedida(this.ObtenerDatosGridCatUnidadMedida());
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
