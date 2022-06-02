namespace PuntodeVentaTintoreria
{
    using PuntodeVentaTintoreria.ClaseAux;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using TintoreriaGlobal;
    using TintoreriaNegocio;

    public partial class FrmTipoSimboloTextil : Form
    {
        #region Constructors
        public FrmTipoSimboloTextil()
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
                FrmNuevoTipoSimboloTextil Add = new FrmNuevoTipoSimboloTextil(new TipoSimboloTextil());
                Add.ShowDialog();
                Add.Dispose();
                this.CargarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmTipoSimboloTextil ~ btnAdd_Click");
            }
        }
        private void Frm_Load(object sender, EventArgs e)
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
                        this.Eliminar(this.ObtenerDatosGrid());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmTipoSimboloTextil ~ btn_eliminar_Click");
            }
        }
        private void btneditar_Click(object sender, EventArgs e)
        {

            try
            {
                FrmNuevoTipoSimboloTextil edit = new FrmNuevoTipoSimboloTextil(this.ObtenerDatosGrid());
                edit.ShowDialog();
                edit.Dispose();
                this.CargarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmTipoSimboloTextil ~ btn_modificar_Click");
            }
        }
        #endregion

        #region Methods
        private void CargarGrid()
        {
            try
            {
                TipoSimboloTextilNegocio oNegocio = new TipoSimboloTextilNegocio();
                this.GridviewGeneral.AutoGenerateColumns = false;
                this.GridviewGeneral.DataSource = oNegocio.GetIndex();
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
        private void Eliminar(Object oObject)
        {
            try
            {
                TipoSimboloTextil oTipoSimboloTextol = (TipoSimboloTextil)oObject;
                TipoSimboloTextilNegocio oNegocio = new TipoSimboloTextilNegocio();
                RespuestaSQL oRespuesta = oNegocio.Delete(oTipoSimboloTextol);
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
        private TipoSimboloTextil ObtenerDatosGrid()
        {
            try
            {
                TipoSimboloTextil item = new TipoSimboloTextil();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    item.Id = Convert.ToInt32(row.Cells["id"].Value.ToString());
                }
                return item;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
