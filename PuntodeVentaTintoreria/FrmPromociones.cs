namespace PuntodeVentaTintoreria
{
    using PuntodeVentaTintoreria.ClaseAux;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using TintoreriaGlobal;
    using TintoreriaNegocio;

    public partial class FrmPromociones : Form
    {
        #region Attributes
        private bool EsBusqueda = false;
        private bool TabActivos = false;
        private bool TabConcluidos = false;
        private bool TabSuspend = false;
        private bool TabTramite = false;
        private string TextoBusqueda = string.Empty;
        private bool opcionRadioButton = true;
        #endregion

        #region Constructors
        public FrmPromociones()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Frm_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarGridTramite();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void txt_buscador_Click(object sender, EventArgs e)
        {
            try
            {
                this.txt_buscador.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmPromociones ~ txt_buscador_Click");
            }
        }
        private void tcVales_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (this.tcVales.SelectedIndex)
                {
                    case 0:
                        if (this.EsBusqueda)
                            this.CargarGridTramiteBusq();
                        else
                            this.CargarGridTramite();
                        break;
                    case 1:
                        if (this.EsBusqueda)
                            this.CargarGridActivosBusq();
                        else
                            this.CargarGridActivos();
                        break;
                    case 2:
                        if (this.EsBusqueda)
                            this.CargarGridSuspendidosBusq();
                        else
                            this.CargarGridSuspendidos();
                        break;
                    case 3:
                        if (this.EsBusqueda)
                            this.CargarGridConcluidosBusq();
                        else
                            this.CargarGridConcluidos();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmPromociones ~ tcVales_SelectedIndexChanged");
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.TabTramite = false;
                this.TabSuspend = false;
                this.TabActivos = false;
                this.TabConcluidos = false;
                this.EsBusqueda = true;
                this.TextoBusqueda = this.txt_buscador.Text.Trim();
                this.tcVales_SelectedIndexChanged(this.tcVales, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmPromociones ~ btnBuscar_Click");
            }
        }
        private void txt_buscador_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
           {
                if (e.KeyChar == 13)
                {
                    this.btnBuscar_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Methods
        private void CargarGridTramite()
        {
            try
            {
                if (!this.TabTramite)
                {
                    Vales DatosAux = new Vales { Conexion = Comun.conexion, TabVales = 0 };
                    Vales_Negocio VN = new Vales_Negocio();
                    VN.ObtenerVales(DatosAux);
                    this.dgvValesTramite.AutoGenerateColumns = false;
                    this.dgvValesTramite.DataSource = DatosAux.TablaDatos;
                    this.TabTramite = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CargarGridTramiteBusq()
        {
            try
            {
                if (!this.TabTramite)
                {
                    Vales DatosAux = new Vales { Conexion = Comun.conexion, OpcionRadioButton = opcionRadioButton, TabVales = 0, Nombre = this.TextoBusqueda };
                    Vales_Negocio VN = new Vales_Negocio();
                    VN.ObtenerValesBusqueda(DatosAux);
                    this.dgvValesTramite.AutoGenerateColumns = false;
                    this.dgvValesTramite.DataSource = DatosAux.TablaDatos;
                    this.TabTramite = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CargarGridActivos()
        {
            try
            {
                if (!this.TabActivos)
                {
                    Vales DatosAux = new Vales { Conexion = Comun.conexion, TabVales = 1 };
                    Vales_Negocio VN = new Vales_Negocio();
                    VN.ObtenerVales(DatosAux);
                    this.dgvValesActivos.AutoGenerateColumns = false;
                    this.dgvValesActivos.DataSource = DatosAux.TablaDatos;
                    this.TabActivos = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CargarGridActivosBusq()
        {
            try
            {
                if (!this.TabActivos)
                {
                    Vales DatosAux = new Vales { Conexion = Comun.conexion, OpcionRadioButton = opcionRadioButton, TabVales = 1, Nombre = this.TextoBusqueda };
                    Vales_Negocio VN = new Vales_Negocio();
                    VN.ObtenerValesBusqueda(DatosAux);
                    this.dgvValesActivos.AutoGenerateColumns = false;
                    this.dgvValesActivos.DataSource = DatosAux.TablaDatos;
                    this.TabActivos = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CargarGridSuspendidos()
        {
            try
            {
                if (!this.TabSuspend)
                {
                    Vales DatosAux = new Vales { Conexion = Comun.conexion, TabVales = 2 };
                    Vales_Negocio VN = new Vales_Negocio();
                    VN.ObtenerVales(DatosAux);
                    this.dgvValesSuspendidos.AutoGenerateColumns = false;
                    this.dgvValesSuspendidos.DataSource = DatosAux.TablaDatos;
                    this.TabSuspend = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CargarGridSuspendidosBusq()
        {
            try
            {
                if (!this.TabSuspend)
                {
                    Vales DatosAux = new Vales { Conexion = Comun.conexion, OpcionRadioButton = opcionRadioButton, TabVales = 2, Nombre = this.TextoBusqueda };
                    Vales_Negocio VN = new Vales_Negocio();
                    VN.ObtenerValesBusqueda(DatosAux);
                    this.dgvValesSuspendidos.AutoGenerateColumns = false;
                    this.dgvValesSuspendidos.DataSource = DatosAux.TablaDatos;
                    this.TabSuspend = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CargarGridConcluidos()
        {
            try
            {
                if (!this.TabConcluidos)
                {
                    Vales DatosAux = new Vales { Conexion = Comun.conexion, TabVales = 3 };
                    Vales_Negocio VN = new Vales_Negocio();
                    VN.ObtenerVales(DatosAux);
                    this.dgvValesConcluidos.AutoGenerateColumns = false;
                    this.dgvValesConcluidos.DataSource = DatosAux.TablaDatos;
                    this.TabConcluidos = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CargarGridConcluidosBusq()
        {
            try
            {
                if (!this.TabConcluidos)
                {
                    Vales DatosAux = new Vales { Conexion = Comun.conexion, TabVales = 3, OpcionRadioButton = opcionRadioButton, Nombre = this.TextoBusqueda };
                    Vales_Negocio VN = new Vales_Negocio();
                    VN.ObtenerValesBusqueda(DatosAux);
                    this.dgvValesConcluidos.AutoGenerateColumns = false;
                    this.dgvValesConcluidos.DataSource = DatosAux.TablaDatos;
                    this.TabConcluidos = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                FrmNuevaPromocion Vale = new FrmNuevaPromocion();
                Vale.ShowDialog();
                Vale.Dispose();
                if (Vale.DialogResult == DialogResult.OK)
                {
                    using (new Recursos.CursorWait())
                    {
                        this.TabTramite = false;
                        this.CargarGridTramite();
                    }
                }
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmPromociones ~ btnNuevo_Click");
                this.Visible = true;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ObtenerGridSeleccionado().SelectedRows.Count == 1)
                {
                    Vales DatosAux = this.ObtenerDatosVale();
                    if (!string.IsNullOrEmpty(DatosAux.IDVale))
                    {
                        if (DatosAux.IDEstatusVale == 1)
                        {
                            DatosAux = this.ObtenerDetalleVale(DatosAux.IDVale);
                            if (!string.IsNullOrEmpty(DatosAux.IDVale))
                            {
                                FrmNuevaPromocion ModificarVale = new FrmNuevaPromocion(DatosAux);
                                this.Visible = false;
                                ModificarVale.ShowDialog();
                                ModificarVale.Dispose();
                                if (ModificarVale.DialogResult == DialogResult.OK)
                                {
                                    using (new Recursos.CursorWait())
                                    {
                                        this.TabTramite = false;
                                        this.TabSuspend = false;
                                        this.tcVales_SelectedIndexChanged(this.tcVales, e);
                                    }
                                }
                                this.Visible = true;
                            }
                            else
                            {
                                MessageBox.Show(this, "Ocurrió un error. Intente nuevamente.", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "El estatus del vale no permite su modificación.", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                    MessageBox.Show(this, "Seleccione un registro.", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmPromociones ~ btnModificar_Click");
                this.Visible = true;
            }
        }

        private DataGridView ObtenerGridSeleccionado()
        {
            try
            {
                DataGridView DGV;
                switch (this.tcVales.SelectedIndex)
                {
                    case 0:
                        DGV = this.dgvValesTramite;
                        break;
                    case 1:
                        DGV = this.dgvValesActivos;
                        break;
                    case 2:
                        DGV = this.dgvValesSuspendidos;
                        break;
                    case 3:
                        DGV = this.dgvValesConcluidos;
                        break;
                    default:
                        DGV = this.dgvValesTramite;
                        break;
                }
                return DGV;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Vales ObtenerDatosVale()
        {
            try
            {
                Vales DatosAux = new Vales();
                int TabIndex = this.tcVales.SelectedIndex;
                DataGridView DGV = this.ObtenerGridSeleccionado();
                Int32 RowData = DGV.Rows.GetFirstRow(DataGridViewElementStates.Selected);
                if (RowData > -1)
                {
                    DataGridViewRow FilaDatos = DGV.Rows[RowData];
                    DatosAux.IDVale = FilaDatos.Cells["IDVale" + TabIndex].Value.ToString();
                    int IDTipoVale = 0, IDEstatusVale = 0;
                    int.TryParse(FilaDatos.Cells["IDTipoVale" + TabIndex].Value.ToString(), out IDTipoVale);
                    int.TryParse(FilaDatos.Cells["IDEstatusVale" + TabIndex].Value.ToString(), out IDEstatusVale);
                    DatosAux.Nombre = FilaDatos.Cells["Nombre" + TabIndex].Value.ToString();
                    DatosAux.Folio = FilaDatos.Cells["Folio" + TabIndex].Value.ToString();
                    DatosAux.IDTipoVale = IDTipoVale;
                    DatosAux.IDEstatusVale = IDEstatusVale;
                    DatosAux.RequierePeriodo = Convert.ToBoolean(FilaDatos.Cells["RequiereFecha" + TabIndex].Value);
                }
                return DatosAux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Vales ObtenerDetalleVale(string IDValePar)
        {
            try
            {
                Vales DatosAux = new Vales { IDVale = IDValePar, Conexion = Comun.conexion };
                Vales_Negocio VN = new Vales_Negocio();
                return VN.ObtenerValeDetalle(DatosAux);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ObtenerGridSeleccionado().SelectedRows.Count == 1)
                {
                    Vales DatosAux = this.ObtenerDatosVale();
                    if (!string.IsNullOrEmpty(DatosAux.IDVale))
                    {
                        if (DatosAux.IDEstatusVale == 1 && this.tcVales.SelectedIndex == 0)
                        {
                            if (MessageBox.Show("¿Está seguro de activar la promoción " + DatosAux.Folio + "?", Comun.NOMBRE_SISTEMA, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                DatosAux.Conexion = Comun.conexion;
                                DatosAux.IDUsuario = Comun.id_u;
                                Vales_Negocio VN = new Vales_Negocio();
                                VN.ActivarVale(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    using (new Recursos.CursorWait())
                                    {
                                        this.TabTramite = false;
                                        this.TabSuspend = false;
                                        this.TabActivos = false;
                                        this.TabConcluidos = false;
                                        this.tcVales_SelectedIndexChanged(this.tcVales, e);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(this, "Ocurrió un error al guardar los datos. Intente nuevamente.", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "El estatus de la promoción no permite su activación.", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                    MessageBox.Show(this, "Seleccione un registro.", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmPromociones ~ btnActivar_Click");
            }
        }

        private void btnSuspender_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ObtenerGridSeleccionado().SelectedRows.Count == 1)
                {
                    Vales DatosAux = this.ObtenerDatosVale();
                    if (!string.IsNullOrEmpty(DatosAux.IDVale))
                    {
                        if (DatosAux.IDEstatusVale == 2)
                        {
                            if (MessageBox.Show("¿Está seguro de suspender la promoción: " + DatosAux.Folio + "?", Comun.NOMBRE_SISTEMA, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                DatosAux.Conexion = Comun.conexion;
                                DatosAux.IDUsuario = Comun.id_u;
                                Vales_Negocio VN = new Vales_Negocio();
                                VN.SuspenderVale(DatosAux);
                                if (DatosAux.Completado)
                                {
                                    using (new Recursos.CursorWait())
                                    {
                                        this.TabTramite = false;
                                        this.TabSuspend = false;
                                        this.TabActivos = false;
                                        this.TabConcluidos = false;
                                        this.tcVales_SelectedIndexChanged(this.tcVales, e);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show(this, "Ocurrió un error al guardar los datos. Intente nuevamente.", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "No se puede suspender la promoción. El estatus actual no lo permite.", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                    MessageBox.Show(this, "Seleccione un registro.", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmPromociones ~ btnSuspender_Click");
            }
        }

        private void btnReactivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ObtenerGridSeleccionado().SelectedRows.Count == 1)
                {
                    Vales DatosAux = this.ObtenerDatosVale();
                    if (!string.IsNullOrEmpty(DatosAux.IDVale))
                    {
                        if ((DatosAux.IDEstatusVale == 1 || DatosAux.IDEstatusVale == 2) && this.tcVales.SelectedIndex == 3)
                        {
                            FrmNuevaPromocion frmvf = new FrmNuevaPromocion(DatosAux);
                            frmvf.ShowDialog();
                            frmvf.Dispose();
                            using (new Recursos.CursorWait())
                            {
                                this.TabTramite = false;
                                this.TabSuspend = false;
                                this.TabActivos = false;
                                this.TabConcluidos = false;
                                this.tcVales_SelectedIndexChanged(this.tcVales, e);
                            }

                        }
                        else
                        {
                            MessageBox.Show(this, "No se puede reactivar la promoción. El estatus actual no lo permite.", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                    MessageBox.Show(this, "Seleccione un registro.", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmPromociones ~ btnReactivar_Click");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ObtenerGridSeleccionado().SelectedRows.Count == 1)
                {
                    Vales DatosAux = this.ObtenerDatosVale();
                    if (!string.IsNullOrEmpty(DatosAux.IDVale))
                    {
                        if (MessageBox.Show("¿Está seguro de eliminar la promoción: " + DatosAux.Folio + "?", "Sistema Punto de Venta CSL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DatosAux.IDUsuario = Comun.id_u;
                            DatosAux.Conexion = Comun.conexion;
                            Vales_Negocio VN = new Vales_Negocio();
                            VN.EliminarVale(DatosAux);
                            if (DatosAux.Completado)
                            {
                                using (new Recursos.CursorWait())
                                {
                                    switch (this.tcVales.SelectedIndex)
                                    {
                                        case 0:
                                            this.TabTramite = false;
                                            break;
                                        case 1:
                                            this.TabActivos = false;
                                            break;
                                        case 2:
                                            this.TabSuspend = false;
                                            break;
                                        case 3:
                                            this.TabConcluidos = false;
                                            break;
                                    }
                                    this.tcVales_SelectedIndexChanged(this.tcVales, e);
                                }
                            }
                            else
                            {
                                MessageBox.Show(this, "Ocurrió un error al guardar los datos. Intente nuevamente.", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                else
                    MessageBox.Show(this, "Seleccione un registro.", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmPromocion ~ btnEliminar_Click");
            }
        }
    }
}
