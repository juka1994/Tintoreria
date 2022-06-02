namespace PuntodeVentaTintoreria
{
    using PuntodeVentaTintoreria.ClaseAux;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using TintoreriaGlobal;
    using TintoreriaNegocio;

    public partial class FrmConversionesIndex : Form
    {
        #region Params
        private ConversionNegocio oNegocio;
        private string idProducto;
        private string nombreProducto;
        private string nombreUnidadMedidaProducto;
        #endregion

        #region Constructors
        public FrmConversionesIndex(string idProducto, string nombreProducto, string nombreUnidadMedidaProducto)
        {
            this.idProducto = idProducto;
            this.nombreProducto = nombreProducto;
            this.nombreUnidadMedidaProducto = nombreUnidadMedidaProducto;

            if (string.IsNullOrEmpty(this.idProducto))
            {
                MessageBox.Show("Error al obtener los datos del producto, contacte con soporte técnico.", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            InitializeComponent();
            oNegocio = new ConversionNegocio();
            this.lblTitulo.Text = "Conversiones del producto: " + this.nombreProducto;
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
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                FrmACConversion frm = new FrmACConversion(new Conversion() { NombreUnidadMedidaEntrada = this.nombreUnidadMedidaProducto, IdProducto = this.idProducto });
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
        private void FrmConversionesIndex_Load(object sender, EventArgs e)
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
                LogError.AddExcFileTxt(ex, "FrmConversionesIndex ~ btn_eliminar_Click");
            }
        }
        private void BtnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    FrmACConversion frm = new FrmACConversion(ObtenerDatosGrid());
                    frm.ShowDialog();
                    frm.Dispose();
                    this.CargarGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmConversionesIndex ~ BtnEditar_Click");
            }
        }
        #endregion

        #region Methods
        private void CargarGrid()
        {
            try
            {
                this.GridviewGeneral.AutoGenerateColumns = false;
                this.GridviewGeneral.DataSource = oNegocio.ObtenerIndex(this.idProducto);
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
                Conversion oConversion = (Conversion)Datos;
                ConversionNegocio oNegocion = new ConversionNegocio();
                RespuestaSQL oRespuesta = oNegocion.Del(oConversion);
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
        private Conversion ObtenerDatosGrid()
        {
            try
            {
                Conversion oConversion = new Conversion();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    oConversion.Id = Convert.ToInt32(row.Cells["id"].Value.ToString());
                    oConversion.NombreUnidadMedidaEntrada = row.Cells["nombreUnidadMedidaEntrada"].Value.ToString();
                    oConversion.IdProducto = row.Cells["id"].Value.ToString();
                }
                return oConversion;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}
