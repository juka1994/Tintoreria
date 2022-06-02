namespace PuntodeVentaTintoreria
{
    using PuntodeVentaTintoreria.ClaseAux;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using TintoreriaGlobal;
    using TintoreriaNegocio;

    public partial class FrmRopaIndex : Form
    {
        #region Constructors
        public FrmRopaIndex()
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
                FrmACRopa frm = new FrmACRopa(new Ropa());
                frm.ShowDialog();
                frm.Dispose();
                this.CargarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmRopaIndex ~ btnAdd_Click");
            }
        }
        private void FrmRopaIndex_Load(object sender, EventArgs e)
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
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavaderìa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmColorRopa ~ btn_eliminar_Click");
            }
        }
        private void btneditar_Click(object sender, EventArgs e)
        {

            try
            {
                FrmACRopa frm = new FrmACRopa(this.ObtenerDatosGrid());
                frm.ShowDialog();
                frm.Dispose();
                this.CargarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmRopaIndex ~ btn_modificar_Click");
            }
        }
        #endregion

        #region Methods
        private void CargarGrid()
        {
            try
            {
                RopaNegocio oNegocio = new RopaNegocio();
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
        private void Eliminar(Object Datos)
        {
            try
            {
                Ropa oRopa = (Ropa)Datos;
                RopaNegocio oRopa_negocio = new RopaNegocio();
                RespuestaSQL oRespuesta = oRopa_negocio.Delete(oRopa);
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
        private Ropa ObtenerDatosGrid()
        {
            try
            {
                Ropa oRopa = new Ropa();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    oRopa.Id = row.Cells["id"].Value.ToString();
                }
                return oRopa;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
