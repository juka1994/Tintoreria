using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TintoreriaGlobal;
using TintoreriaNegocio;

namespace PuntodeVentaTintoreria
{
    public partial class frmDocumentoXPagar : Form
    {
        DocumentosXPagar infoDocumentosXPagar = new DocumentosXPagar();
        string id_docXpagar = "";
        frm_Esperar espere = new frm_Esperar();
        string id_proveedor = "";
        string id_compra= "";
        string foliopedido = "";
        public frmDocumentoXPagar()
        {
            try
            {
                InitializeComponent();
                Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
               
                infoDocumentosXPagar.id_sucursal = Comun.id_sucursal;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          
          
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                SucursalNegocio sucursal_negocio = new SucursalNegocio();
                Sucursal sucursal = new Sucursal();
                sucursal.conexion = Comun.conexion;
                sucursal_negocio.ObtenerComboSucursal(sucursal);
                e.Result = sucursal.datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                DataTable Aux = (DataTable)e.Result;
                this.cmb_sucursal.SelectedValueChanged -= new System.EventHandler(this.cmb_sucursal_SelectedValueChanged);
                this.cmb_sucursal.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_sucursal.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_sucursal.DataSource = Aux;
                this.cmb_sucursal.DisplayMember = "nombre";
                this.cmb_sucursal.ValueMember = "id_sucursal";
                this.cmb_sucursal.SelectedValueChanged += new System.EventHandler(this.cmb_sucursal_SelectedValueChanged);
                this.cmb_sucursal.SelectedValue = infoDocumentosXPagar.id_sucursal;

                backgroundWorker2.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DocumentosXPagarNegocio documentosXPagarNegocio = new DocumentosXPagarNegocio();
                DocumentosXPagar documentosXPagar = new DocumentosXPagar();
                documentosXPagar.conexion = Comun.conexion;
                documentosXPagar.id_sucursal = infoDocumentosXPagar.id_sucursal; ;
                documentosXPagarNegocio.LLenarGridDocumentosXPagar(documentosXPagar, 0);
                e.Result = documentosXPagar.datos;
            }
            catch (Exception ex)
            {

            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                DataTable Aux = (DataTable)e.Result;
                infoDocumentosXPagar.datos = Aux;
                this.GridViewPendientes.SelectionChanged -= new System.EventHandler(this.GridViewPendientes_SelectionChanged);
                this.GridViewPendientes.AutoGenerateColumns = false;
                this.GridViewPendientes.DataSource = Aux;
                ImagenGrid();
                this.GridViewPendientes.SelectionChanged += new System.EventHandler(this.GridViewPendientes_SelectionChanged);
                GridViewPendientes_SelectionChanged(null, null);

                espere.Close();

            }
            catch (Exception ex)
            {

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
        #region MetodosGenerales        
        private void CargarComboSucursal()
        {
            try
            {
                SucursalNegocio sucursal_negocio = new SucursalNegocio();
                Sucursal sucursal = new Sucursal();
                sucursal.conexion = Comun.conexion;
                sucursal_negocio.ObtenerComboSucursal(sucursal);
                this.cmb_sucursal.SelectedValueChanged -= new System.EventHandler(this.cmb_sucursal_SelectedValueChanged);
                this.cmb_sucursal.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                this.cmb_sucursal.AutoCompleteSource = AutoCompleteSource.ListItems;
                this.cmb_sucursal.DataSource = sucursal.datos;
                this.cmb_sucursal.DisplayMember = "nombre";
                this.cmb_sucursal.ValueMember = "id_sucursal";
                this.cmb_sucursal.SelectedValueChanged += new System.EventHandler(this.cmb_sucursal_SelectedValueChanged);
                this.cmb_sucursal.SelectedValue = infoDocumentosXPagar.id_sucursal;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarGridDocumentos(string id_sucursal, int tabIndex)
        {
            try
            {
                DocumentosXPagarNegocio documentosXPagarNegocio = new DocumentosXPagarNegocio();
                DocumentosXPagar documentosXPagar = new DocumentosXPagar();
                documentosXPagar.conexion = Comun.conexion;
                documentosXPagar.id_sucursal = id_sucursal;
                documentosXPagarNegocio.LLenarGridDocumentosXPagar(documentosXPagar, tabIndex);
                switch (tabIndex)
                {
                    case 0:
                        infoDocumentosXPagar.datos = documentosXPagar.datos;
                        this.GridViewPendientes.SelectionChanged -= new System.EventHandler(this.GridViewPendientes_SelectionChanged);
                        this.GridViewPendientes.AutoGenerateColumns = false;
                        this.GridViewPendientes.DataSource = documentosXPagar.datos;
                        ImagenGrid();
                        this.GridViewPendientes.SelectionChanged += new System.EventHandler(this.GridViewPendientes_SelectionChanged);
                        GridViewPendientes_SelectionChanged(null, null);
                        break;
                    case 1:
                        infoDocumentosXPagar.datos = documentosXPagar.datos;
                        this.GridViewPagados.SelectionChanged -= new System.EventHandler(this.GridViewPagados_SelectionChanged);
                        this.GridViewPagados.AutoGenerateColumns = false;
                        this.GridViewPagados.DataSource = documentosXPagar.datos;
                        ImagenGrid();
                        this.GridViewPagados.SelectionChanged += new System.EventHandler(this.GridViewPagados_SelectionChanged);
                        GridViewPagados_SelectionChanged(null, null);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void CargarGridPagos(string id_docXPagar, string id_sucursal)
        {
            try
            {
                DocumentosXPagarNegocio documentosXPagarNegocio = new DocumentosXPagarNegocio();
                DocumentosXPagar documentosXPagar = new DocumentosXPagar();
                documentosXPagar.conexion = Comun.conexion;
                documentosXPagar.id_docXPagar = id_docXPagar;
                documentosXPagar.id_sucursal = id_sucursal;
                documentosXPagarNegocio.LLenarGridDocumentosXPagarPagos(documentosXPagar);
                infoDocumentosXPagar.datos = documentosXPagar.datos;
                this.GridViewPagos.AutoGenerateColumns = false;
                this.GridViewPagos.DataSource = documentosXPagar.datos;
                CalcularTotal();
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
                switch (this.tabControlDocumentos.SelectedIndex)
                {
                    case 0:
                        foreach (DataGridViewRow row in GridViewPendientes.Rows)
                        {
                            if (row.Selected)
                            {
                                rowSelected.Add(row);
                            }
                        }
                        break;
                    case 1:
                        foreach (DataGridViewRow row in GridViewPagados.Rows)
                        {
                            if (row.Selected)
                            {
                                rowSelected.Add(row);
                            }
                        }
                        break;
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
        private DocumentosXPagar ObtenerDatosGridDocumentos()
        {
            try
            {
                DocumentosXPagar documentosXPagar = new DocumentosXPagar();
                int TabIndex = this.tabControlDocumentos.SelectedIndex + 1;
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    documentosXPagar.id_docXPagar = row.Cells["id_docpagar" + TabIndex].Value.ToString();
                    documentosXPagar.fecha = Convert.ToDateTime(row.Cells["fecha" + TabIndex].Value.ToString());
                    documentosXPagar.folio = row.Cells["folioPedido" + TabIndex].Value.ToString();
                    documentosXPagar.proveedor = row.Cells["proveedor" + TabIndex].Value.ToString();
                    documentosXPagar.hora = row.Cells["hora" + TabIndex].Value.ToString();
                    documentosXPagar.total = float.Parse(row.Cells["total" + TabIndex].Value.ToString(), NumberStyles.Currency, CultureInfo.CurrentCulture);
                    documentosXPagar.id_sucursal = row.Cells["id_sucursal" + TabIndex].Value.ToString();
                    documentosXPagar.id_compra = row.Cells["id_compra" + TabIndex].Value.ToString();
                    documentosXPagar.id_status = Convert.ToInt32(row.Cells["id_status" + TabIndex].Value.ToString());
                    documentosXPagar.pago = float.Parse(this.txt_totalPagos.Text, NumberStyles.Currency, CultureInfo.CurrentCulture);
                }
                return documentosXPagar;
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        private void ImagenGrid()
        {
            switch (tabControlDocumentos.SelectedIndex)
            {
                case 0:
                    foreach (DataGridViewRow Grid in this.GridViewPendientes.Rows)
                    {
                        if (Convert.ToInt32(Grid.Cells[5].Value) == 1)
                            Grid.Cells[6].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_ORANGE.png"), new Size(25, 25));
                        else if (Convert.ToInt32(Grid.Cells[5].Value) == 2)
                            Grid.Cells[6].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_GREEN.png"), new Size(25, 25));
                    }
                    break;
                case 1:
                    foreach (DataGridViewRow Grid in this.GridViewPagados.Rows)
                    {
                        if (Convert.ToInt32(Grid.Cells[5].Value) == 1)
                            Grid.Cells[6].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_ORANGE.png"), new Size(25, 25));
                        else if (Convert.ToInt32(Grid.Cells[5].Value) == 2)
                            Grid.Cells[6].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_GREEN.png"), new Size(25, 25));
                    }
                    break;
            }
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        private void CalcularTotal()
        {
            try
            {
                float total = 0.0F;
                if (GridViewPagos.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in GridViewPagos.Rows)
                    {
                        total += Convert.ToSingle(row.Cells["monto"].Value);
                    }
                }
                this.txt_totalPagos.Text = string.Format("{0:C2}", total);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion


        private void cmb_sucursal_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (Comun.id_tu == 1)
                    {
                        infoDocumentosXPagar.id_sucursal = cmb_sucursal.SelectedValue.ToString();
                        this.CargarGridDocumentos(cmb_sucursal.SelectedValue.ToString(), tabControlDocumentos.SelectedIndex);
                    }
                    else
                    {
                        cmb_sucursal.Enabled = false;
                        this.CargarGridDocumentos(cmb_sucursal.SelectedValue.ToString(), tabControlDocumentos.SelectedIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControlDocumentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.CargarGridDocumentos(cmb_sucursal.SelectedValue.ToString(), tabControlDocumentos.SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridViewPendientes_Sorted(object sender, EventArgs e)
        {
            try
            {
                ImagenGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridViewPagados_Sorted(object sender, EventArgs e)
        {
            try
            {
                ImagenGrid();
            }
            catch (Exception)
            {
            }
        }

        private void GridViewPagados_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    DocumentosXPagar documentosXPagar = this.ObtenerDatosGridDocumentos();
                    id_docXpagar = documentosXPagar.id_docXPagar;
                    id_proveedor = documentosXPagar.proveedor;
                    id_compra = documentosXPagar.id_compra;
                    foliopedido = documentosXPagar.folio;

                    if (documentosXPagar.id_docXPagar != "")
                        CargarGridPagos(documentosXPagar.id_docXPagar, documentosXPagar.id_sucursal);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridViewPendientes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    DocumentosXPagar documentosXPagar = this.ObtenerDatosGridDocumentos();
                    id_docXpagar = documentosXPagar.id_docXPagar;
                    id_proveedor = documentosXPagar.proveedor;
                    id_compra = documentosXPagar.id_compra;
                    foliopedido = documentosXPagar.folio;
                    if (documentosXPagar.id_docXPagar != "")
                        CargarGridPagos(documentosXPagar.id_docXPagar, documentosXPagar.id_sucursal);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmDocumentoXPagar_Load(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker1.RunWorkerAsync();
                espere.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    DocumentosXPagar venta_aux = this.ObtenerDatosGridDocumentos();
                    if (venta_aux.id_status == 1)
                    {
                        frmDocumentosPagos frmdp = new frmDocumentosPagos(this.ObtenerDatosGridDocumentos());
                        frmdp.ShowDialog();
                        if (frmdp.DialogResult == DialogResult.OK)
                        {
                            using (new Recursos.CursorWait())
                            {
                                string id_documento_pago = id_docXpagar;

                                this.CargarGridDocumentos(cmb_sucursal.SelectedValue.ToString(), tabControlDocumentos.SelectedIndex);
                                int rowIndex = -1;
                                switch (tabControlDocumentos.SelectedIndex)
                                {
                                    case 0:
                                        if (GridViewPendientes.Rows
                                                .Cast<DataGridViewRow>()
                                                .Where(r => r.Cells["id_docpagar1"].Value.ToString().Equals(id_documento_pago))
                                                .Count() == 1)
                                        {
                                            DataGridViewRow row = GridViewPendientes.Rows
                                            .Cast<DataGridViewRow>()
                                            .Where(r => r.Cells["id_docpagar1"].Value.ToString().Equals(id_documento_pago))
                                            .First();
                                            rowIndex = row.Index;
                                            GridViewPendientes.Rows[rowIndex].Selected = true;
                                            GridViewPendientes_SelectionChanged(null, null);
                                        }
                                        break;
                                    case 1:
                                        //DataGridViewRow row = GridViewPendientes.Rows
                                        //    .Cast<DataGridViewRow>()
                                        //    .Where(r => r.Cells["id_docpagar2"].Value.ToString().Equals(id_documento_pago))
                                        //    .First();
                                        //     rowIndex = row.Index;
                                        //     GridViewPagados.Rows[rowIndex].Selected = true;
                                        //     GridViewPagados_SelectionChanged(null, null);
                                        break;
                                }


                                int Verificador2 = -1;
                                NotificacionNegocio notificacionNegocio = new NotificacionNegocio();
                                Notificacion notificacion = new Notificacion();
                                notificacion.conexion = Comun.conexion;
                                notificacion.opcion = 2;
                                notificacion.id_generico = id_compra;
                                notificacion.id_persona = id_proveedor;
                                notificacion.id_tipoNotificacion = 1;
                                notificacion.enviar = true;
                                notificacion.nombre = "Pago Realizado";
                                notificacion.texto = "Se registró un pago, del pedido con folio [" + foliopedido + "],inicié sesion en la aplicación movil para ver los detalles.";
                                notificacion.descripcion = notificacion.texto;
                                notificacion.id_u = Comun.id_u;
                                notificacionNegocio.AbcNotificacionAppDU(notificacion, ref Verificador2);
                                if (Verificador2 == 0)
                                    if (notificacion.datos.Rows[0]["id_token"].ToString() != null)
                                        ClasesAux.EnvioMensaje.EnviarMensaje(
                                            notificacion.datos.Rows[0]["id_token"].ToString(),
                                            notificacion.datos.Rows[0]["nombre"].ToString(),
                                            notificacion.datos.Rows[0]["descripcion"].ToString(),
                                            false);
                            }
                        }
                        frmdp.Dispose();
                    }
                    else
                        MessageBox.Show(this, "La compra ya no tiene adeudos pendientes", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
