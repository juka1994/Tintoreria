namespace PuntodeVentaTintoreria
{
    using PuntodeVentaTintoreria.ClaseAux;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using TintoreriaGlobal;
    using TintoreriaNegocio;

    public partial class FrmSimboloTextil : Form
    {
        #region Constructors
        public FrmSimboloTextil()
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
                    FrmNuevoSimboloTextil frm = new FrmNuevoSimboloTextil(ObtenerDatosGrid());
                    frm.ShowDialog();
                    this.CargarGrid();
                    frm.Dispose();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        this.Eliminar(this.ObtenerDatosGrid());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_nuevoTipo_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNuevoSimboloTextil Add = new FrmNuevoSimboloTextil(new SimboloTextil());
                Add.ShowDialog();
                this.CargarGrid();
                Add.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmSimboloTextil_Grid ~ btn_nuevoTipo_Click");
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
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Metodos Generales
        private SimboloTextil ObtenerDatosGrid()
        {
            try
            {
                SimboloTextil oItem = new SimboloTextil();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    oItem.Id = Convert.ToInt32(row.Cells["id"].Value.ToString());
                    oItem.Descripcion = row.Cells["descripcion"].Value.ToString();
                }
                return oItem;
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
                SimboloTextilNegocio oNegocio = new SimboloTextilNegocio();
                this.GridviewGeneral.AutoGenerateColumns = false;
                this.GridviewGeneral.DataSource = oNegocio.GetIndex();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Eliminar(Object Datos)
        {
            try
            {
                SimboloTextil oSimboloTextil = (SimboloTextil)Datos;
                SimboloTextilNegocio oNegocio = new SimboloTextilNegocio();

                oSimboloTextil.id_usuario = Comun.id_u;
                RespuestaSQL oRespuesta = oNegocio.Delete(oSimboloTextil);

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
    }
}
