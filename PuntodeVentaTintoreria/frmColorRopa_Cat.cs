namespace PuntodeVentaTintoreria
{
    using PuntodeVentaTintoreria.ClaseAux;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using TintoreriaGlobal;
    using TintoreriaNegocio;

    public partial class frmColorRopa_Cat : Form
    {
        #region Constructors
        public frmColorRopa_Cat()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmNuevoColor_Cat colorRopa = new frmNuevoColor_Cat(new ColorRopa());
                colorRopa.ShowDialog();
                colorRopa.Dispose();
                this.CargarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmColorRopa_Grid ~ btnAdd_Click");
            }
        }
        private void frmColorRopa_Cat_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    if (MessageBox.Show("¿Desea eliminar este Registro?", "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.EliminarCatColorRopa(this.ObtenerDatosGrid());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavaderìa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmColorRopa ~ btn_eliminar_Click");
            }
        }
        private void btneditar_Click(object sender, EventArgs e)
        {

            try
            {
                frmNuevoColor_Cat colorRopa = new frmNuevoColor_Cat(this.ObtenerDatosGrid());
                colorRopa.ShowDialog();
                colorRopa.Dispose();
                this.CargarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmColorRopa_Grid ~ btn_modificar_Click");
            }
        }
        #endregion

        #region Methods
        private void CargarGrid()
        {
            try
            {
                ColorRopaNegocio colorRopa_negocio = new ColorRopaNegocio();
                ColorRopa colorRopa = new ColorRopa();
                colorRopa.conexion = Comun.conexion;
                colorRopa_negocio.llenarGridColorRopa(colorRopa);
                this.GridviewGeneral.AutoGenerateColumns = false;
                this.GridviewGeneral.DataSource = colorRopa.datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private bool ValidarFilaSeleccionada(List<DataGridViewRow> rowSelected)
        {
            try
            {
                if (rowSelected.Count == 0)
                {
                    MessageBox.Show(this, "Debe seleccionar una fila del grid", "Sistema Punto de Venta Lavanderìa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void EliminarCatColorRopa(Object Datos)
        {
            try
            {
                ColorRopa colorRopa = (ColorRopa)Datos;
                ColorRopaNegocio colorRopa_negocio = new ColorRopaNegocio();
                RespuestaSQL oRespuesta = colorRopa_negocio.Delete(colorRopa);
                MessageBox.Show(oRespuesta.Mensaje, Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, oRespuesta.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                this.CargarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);

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
        private ColorRopa ObtenerDatosGrid()
        {
            try
            {
                ColorRopa colorRopa = new ColorRopa();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    colorRopa.id_colorRopa = Convert.ToInt32(row.Cells["id_colorRopa"].Value.ToString());
                    colorRopa.id_u = Comun.id_u;
                }
                return colorRopa;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
