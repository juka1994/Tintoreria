namespace PuntodeVentaTintoreria
{
    using PuntodeVentaTintoreria.ClaseAux;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using TintoreriaGlobal;
    using TintoreriaNegocio;

    public partial class FrmTipoFibra_Grid : Form
    {

        #region Constructors
        public FrmTipoFibra_Grid()
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
        private void btneditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    FrmNuevoTipoFibra Tipo = new FrmNuevoTipoFibra(ObtenerDatosGridCatTipoEstampado());
                    Tipo.ShowDialog();
                    this.CargarGrid();
                    Tipo.Dispose();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        this.Eliminar(this.ObtenerDatosGridCatTipoEstampado());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_nuevoTipo_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNuevoTipoFibra Add = new FrmNuevoTipoFibra(new TipoFibraRopa());
                Add.ShowDialog();
                this.CargarGrid();
                Add.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderìa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmTipoRopa_Grid ~ btn_nuevoTipo_Click");
            }
        }
        #endregion

        #region Metodos Generales
        private TipoFibraRopa ObtenerDatosGridCatTipoEstampado()
        {
            try
            {
                TipoFibraRopa Tipo = new TipoFibraRopa();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    Tipo.IDFibraRopa = Convert.ToInt32(row.Cells["Id"].Value.ToString());
                    Tipo.Descripcion = row.Cells["Descripcion"].Value.ToString();
                }
                return Tipo;
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
                TipoFibraRopaNegocio oNegocio = new TipoFibraRopaNegocio();
                TipoFibraRopa oTipo = new TipoFibraRopa();
                oNegocio.ObtenerGridTipoFibraRopa(oTipo);
                this.GridviewGeneral.AutoGenerateColumns = false;
                this.GridviewGeneral.DataSource = oTipo.TablaDatos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Eliminar(Object Datos)
        {
            try
            {
                TipoFibraRopa Tipo = (TipoFibraRopa)Datos;
                int Verificador = 0;
                TipoFibraRopaNegocio TipoNegocio = new TipoFibraRopaNegocio();
                
                Tipo.IDUsuario = Comun.id_u;
                TipoNegocio.EliminarTipoFibraRopa(Tipo, ref Verificador);
                if (Verificador == 1)
                {
                    this.CargarGrid();
                    MessageBox.Show(this, "Los datos se eliminaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Verificador == 0)
                {
                    MessageBox.Show(this, "Este registro no se puede eliminar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

        private void FrmTipoFibra_Cat_Load(object sender, EventArgs e)
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
        #endregion
    }
}
