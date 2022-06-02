using PuntodeVentaTintoreria.ClaseAux;
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
   
    public partial class frmAplicarBodega : Form
    {
        Bodega infoBodega;
        private Validaciones Val;
        string id_docXpagar = "";
        public frmAplicarBodega(Bodega bodega)
        {
            try
            {
                InitializeComponent();
                Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
                infoBodega = bodega;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAplicarBodega ~ frmAplicarBodega_Bunifu");
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

        private void pnlProducto_Paint(object sender, PaintEventArgs e)
        {

        }

        #region MetodosGenerales
        private void LLenarDatos()
        {
            try
            {
                txt_producto.Text = infoBodega.nombreProducto;
                txt_cantidad.Text = infoBodega.cantidad.ToString();
                txt_precio.Text = string.Format("{0:C2}", infoBodega.costo);
                txt_subtotal.Text = string.Format("{0:C2}", infoBodega.subtotal);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private bool ValidarDatos()
        {
            if (txt_cantidad.Text == "")
            {
                MessageBox.Show(this, "Escriba una cantidad", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_cantidad.Focus();
                return false;
            }
            if (Convert.ToInt32(txt_cantidad.Text) > infoBodega.cantidad || Convert.ToInt32(txt_cantidad.Text) == 0)
            {
                MessageBox.Show(this, "Escriba una cantidad valida", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_cantidad.Focus();
                return false;
            }
            return true;
        }
        private void CargarGridGeneral()
        {
            try
            {
                Bodega bodega = new Bodega();
                BodegaNegocio bodegaNegocio = new BodegaNegocio();
                bodega.conexion = Comun.conexion;
                bodega.id_proveedor = infoBodega.id_proveedor;
                bodega.id_sucursal = infoBodega.id_sucursal;
                bodegaNegocio.LLenarGridAplicarBodega(bodega);
                this.GridViewArticulos.SelectionChanged -= new System.EventHandler(this.GridViewArticulos_SelectionChanged);
                this.GridViewArticulos.AutoGenerateColumns = false;
                this.GridViewArticulos.DataSource = bodega.datos;
                ImagenGrid();
                this.GridViewArticulos.SelectionChanged += new System.EventHandler(this.GridViewArticulos_SelectionChanged);
                GridViewArticulos_SelectionChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                this.GridviewPagos.AutoGenerateColumns = false;
                this.GridviewPagos.DataSource = documentosXPagar.datos;
                CalcularTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private List<DataGridViewRow> ObtenerFilaSeleccionada()
        {
            try
            {
                List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in GridViewArticulos.Rows)
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
                    MessageBox.Show(this, "Debe seleccionar una fila del grid", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    documentosXPagar.id_docXPagar = row.Cells["id_docXPagar"].Value.ToString();
                    documentosXPagar.fecha = Convert.ToDateTime(row.Cells["fecha"].Value.ToString());
                    documentosXPagar.folio = row.Cells["folioPedido"].Value.ToString();
                    documentosXPagar.proveedor = row.Cells["proveedor"].Value.ToString();
                    documentosXPagar.hora = row.Cells["hora"].Value.ToString();
                    documentosXPagar.total = float.Parse(row.Cells["total"].Value.ToString(), CultureInfo.InvariantCulture);
                    documentosXPagar.id_sucursal = row.Cells["id_sucursal"].Value.ToString();
                    documentosXPagar.id_compra = row.Cells["id_compra"].Value.ToString();
                    documentosXPagar.id_status = Convert.ToInt32(row.Cells["id_status"].Value.ToString());
                    documentosXPagar.pago = float.Parse(this.txt_totalPagos.Text, NumberStyles.Currency, CultureInfo.CurrentCulture);
                    documentosXPagar.monto = float.Parse(this.txt_subtotal.Text, NumberStyles.Currency, CultureInfo.CurrentCulture);
                    documentosXPagar.aplicarBodega = true;
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
            foreach (DataGridViewRow Grid in this.GridViewArticulos.Rows)
            {
                if (Convert.ToInt32(Grid.Cells[5].Value) == 1)
                    Grid.Cells[6].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_ORANGE.png"), new Size(25, 25));
                else if (Convert.ToInt32(Grid.Cells[5].Value) == 2)
                    Grid.Cells[6].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_GREEN.png"), new Size(25, 25));
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
                if (GridviewPagos.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in GridviewPagos.Rows)
                    {
                        total += Convert.ToSingle(row.Cells["monto"].Value);
                    }
                }
                this.txt_totalPagos.Text = string.Format("{0:C2}", total);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion
        #region Validaciones
        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloNumerico(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAplicarBodega_Bunifu ~ txt_cantidad_KeyPress");
            }
        }

        private void txt_cantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_cantidad_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion

        private void frmAplicarBodega_Load(object sender, EventArgs e)
        {
            try
            {
                this.LLenarDatos();
                this.CargarGridGeneral();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAplicarBodega ~ frmAplicarBodega_Bunifu_Load");
            }
        }
        private void GridViewArticulos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    DocumentosXPagar documentosXPagar = this.ObtenerDatosGridDocumentos();
                    id_docXpagar = documentosXPagar.id_docXPagar;
                    if (documentosXPagar.id_docXPagar != "")
                        CargarGridPagos(documentosXPagar.id_docXPagar, documentosXPagar.id_sucursal);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAplicarBodega_Bunifu ~ GridViewArticulos_SelectionChanged");
            }
        }

        private void GridViewArticulos_Sorted(object sender, EventArgs e)
        {
            try
            {
                ImagenGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_cantidad_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txt_cantidad.Text != "")
                {
                    if (Convert.ToInt32(txt_cantidad.Text) <= infoBodega.cantidad)
                        txt_subtotal.Text = string.Format("{0:C2}", float.Parse(txt_precio.Text, NumberStyles.Currency, CultureInfo.CurrentCulture) * Convert.ToInt32(txt_cantidad.Text));
                    else
                        MessageBox.Show(this, "La cantidad deve ser menor a la de bodega", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnguardarA_Click(object sender, EventArgs e)
        {

        }

        private void btnguardarA_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (ValidarDatos())
                {
                    DocumentosXPagar venta_aux = this.ObtenerDatosGridDocumentos();
                    if (venta_aux.id_status == 1)
                    {
                        infoBodega.cantidad = Convert.ToInt32(txt_cantidad.Text);
                        frmDocumentosPagos frmdp = new frmDocumentosPagos(this.ObtenerDatosGridDocumentos(), infoBodega);
                        frmdp.ShowDialog();
                        frmdp.Dispose();
                        if (frmdp.DialogResult == DialogResult.OK)
                        {
                            this.Close();
                        }
                        else
                        {
                            using (new Recursos.CursorWait())
                            {
                                string id_documento_pago = id_docXpagar;

                                this.CargarGridGeneral();
                                int rowIndex = -1;
                                DataGridViewRow row = GridViewArticulos.Rows
                                            .Cast<DataGridViewRow>()
                                            .Where(r => r.Cells["id_docXPagar"].Value.ToString().Equals(id_documento_pago))
                                            .First();
                                rowIndex = row.Index;
                                GridViewArticulos.Rows[rowIndex].Selected = true;
                                GridViewArticulos_SelectionChanged(null, null);
                            }
                        }
                    }
                    else
                        MessageBox.Show(this, "La compra ya no tiene adeudos pendientes", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAplicarBodega_Bunifu ~ btnAplicar_Click");
            }

        }
    }
}
