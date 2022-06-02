namespace PuntodeVentaTintoreria
{
    using PuntodeVentaTintoreria.ClaseAux;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using TintoreriaGlobal;
    using TintoreriaNegocio;

    public partial class FrmPrecioXTipoEntregaIndex : Form
    {
        #region Variables
        private TipoRopa oTipoRopa;
        #endregion

        #region Constructors
        public FrmPrecioXTipoEntregaIndex(TipoRopa tipoRopa)
        {
            InitializeComponent();
            this.oTipoRopa = tipoRopa;
            this.LblTitulo.Text = "Precio por tipo de entrega: " + this.oTipoRopa.Descripcion;
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
                FrmACPrecioXTipoEntrega frm = new FrmACPrecioXTipoEntrega(new PrecioXTipoEntrega() { IdTipoRopa = this.oTipoRopa.IDTipoRopa });
                frm.ShowDialog();
                frm.Dispose();
                this.CargarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmColorRopa_Grid ~ btnAdd_Click");
            }
        }
        private void FrmPrecioXTipoEntregaIndex_Load(object sender, EventArgs e)
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
                FrmACPrecioXTipoEntrega frm = new FrmACPrecioXTipoEntrega(this.ObtenerDatosGrid());
                frm.ShowDialog();
                frm.Dispose();
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
                PrecioXTipoEntregaNegocio oPrecioXTipoEntregaNegocio = new PrecioXTipoEntregaNegocio();
                this.GridviewGeneral.AutoGenerateColumns = false;
                this.GridviewGeneral.DataSource = oPrecioXTipoEntregaNegocio.GetIndex(this.oTipoRopa.IDTipoRopa);
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
                PrecioXTipoEntrega item = (PrecioXTipoEntrega)Datos;
                PrecioXTipoEntregaNegocio oPrecioXTipoEntregaNegocio = new PrecioXTipoEntregaNegocio();
                RespuestaSQL oRespuesta = oPrecioXTipoEntregaNegocio.Delete(item.Id);
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
        private PrecioXTipoEntrega ObtenerDatosGrid()
        {
            try
            {
                PrecioXTipoEntrega item = new PrecioXTipoEntrega();
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
