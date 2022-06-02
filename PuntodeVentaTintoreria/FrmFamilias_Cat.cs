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
    public partial class FrmFamilias_Cat : Form
    {
        public FrmFamilias_Cat()
        {
            InitializeComponent();
            Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
        }
        #region Metodos Generales
        private void EliminarCatFamilia(Object Datos)
        {
            try
            {
                Familia oFamilia = (Familia)Datos;
                int Verificador = -1;
                FamiliaNegocio oNegocio = new FamiliaNegocio();
                oFamilia.opcion = 3;
                oFamilia.conexion = Comun.conexion;
                oNegocio.AbcFamilia(oFamilia, ref Verificador);
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
        private Familia ObtenerDatosGridCatFamilia ()
        {
            try
            {
                Familia oFamilia = new Familia();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    oFamilia.id_familia = Convert.ToInt32(row.Cells["id_familia"].Value.ToString());
                    oFamilia.descripcion = row.Cells["descripcion"].Value.ToString();
                    oFamilia.id_u = Comun.id_u;
                }
                return oFamilia;
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
                FamiliaNegocio oNegocio = new FamiliaNegocio();
                Familia oFamilia = new Familia();
                oFamilia.conexion = Comun.conexion;
                oFamilia.tipoBusqueda = 1;
                oFamilia.busqueda = string.Empty;
                oNegocio.LLenarGridFamilia(oFamilia);
                this.GridviewGeneral.AutoGenerateColumns = false;
                this.GridviewGeneral.DataSource = oFamilia.datos;
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
        private void FrmFamilias_Cat_Load(object sender, EventArgs e)
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

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNueva_Familia motivo = new FrmNueva_Familia(new Familia());
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

        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNueva_Familia frm = new FrmNueva_Familia(this.ObtenerDatosGridCatFamilia());
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
                        this.EliminarCatFamilia(this.ObtenerDatosGridCatFamilia());
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
