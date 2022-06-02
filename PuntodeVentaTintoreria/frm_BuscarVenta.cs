using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TintoreriaGlobal;
using TintoreriaNegocio;

using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
using PuntodeVentaTintoreria.ClaseAux;
using System.Management;
using System.Globalization;

namespace PuntodeVentaTintoreria
{
    public partial class frm_BuscarVenta : Form
    {
        int tipoBusqueda = 1;

        public frm_BuscarVenta()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBusquedaVenta_Grid ~ frmBusquedaVenta_Grid()");
            }
        }
        
      

        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /************************************************************************************************************************************/
     

        private void frm_BuscarVenta_Load(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.CargarGridBusqueda(tipoBusqueda, "", DateTime.Today);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBusquedaVenta_Grid ~ frmBusquedaVenta_Grid_Load");
            }
        }
        #region MetodosGenerales
        private void CargarGridBusqueda(int tipoBusqueda, string buscador, DateTime fecha)
        {
            try
            {
                VentaProductos ventaProductos = new VentaProductos();
                VentaProductosNegocio ventaProductosNegocio = new VentaProductosNegocio();
                ventaProductos.conexion = Comun.conexion;
                ventaProductos.Folio = buscador;
                ventaProductos.tipoBusqueda = tipoBusqueda;
                ventaProductos.FecVenta = fecha;
                ventaProductos.NombreCliente = buscador;
                ventaProductos.IDSucursal = Comun.id_sucursal;
                ventaProductosNegocio.LLenarGridBusquedaVenta(ventaProductos);
                this.GridViewGeneral.AutoGenerateColumns = true;
                this.GridViewGeneral.DataSource = ventaProductos.datos;
                ImagenGrid();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
        }
        private void ImagenGrid()
        {
            try
            {

                foreach (DataGridViewRow Grid in this.GridViewGeneral.Rows)
                {
                    if (Convert.ToInt32(Grid.Cells[12].Value) == 1)
                        Grid.Cells[13].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_ORANGE.png"), new Size(25, 25));
                    else if (Convert.ToInt32(Grid.Cells[12].Value) == 2)
                        Grid.Cells[13].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_GREEN.png"), new Size(25, 25));
                    else if (Convert.ToInt32(Grid.Cells[12].Value) == 3)
                        Grid.Cells[13].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_BLUE.png"), new Size(25, 25));
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        private List<DataGridViewRow> ObtenerFilaSeleccionada()
        {
            try
            {
                List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in GridViewGeneral.Rows)
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
        private VentaProductos ObtenerDatosGridBusqueda()
        {
            try
            {
                VentaProductos ventaProducto = new VentaProductos();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    ventaProducto.Folio = row.Cells["folio"].Value.ToString();
                    ventaProducto.FecVenta = Convert.ToDateTime(row.Cells["fec_venta"].Value.ToString());
                    ventaProducto.HorVenta = row.Cells["hor_venta"].Value.ToString();
                    ventaProducto.IDCliente = row.Cells["id_cliente"].Value.ToString();
                    ventaProducto.NombreCliente = row.Cells["cliente"].Value.ToString();
                    ventaProducto.IDVendedor = row.Cells["id_vendedor"].Value.ToString();
                    ventaProducto.NombreVendedor = row.Cells["vendedor"].Value.ToString();
                    ventaProducto.Importe = float.Parse(row.Cells["importe"].Value.ToString(), CultureInfo.InvariantCulture);
                    ventaProducto.Descuento = decimal.Parse(row.Cells["descuento"].Value.ToString(), CultureInfo.InvariantCulture);
                    ventaProducto.Iva = decimal.Parse(row.Cells["iva"].Value.ToString(), CultureInfo.InvariantCulture);
                    ventaProducto.Total = decimal.Parse(row.Cells["total"].Value.ToString(), CultureInfo.InvariantCulture);
                    ventaProducto.IDSucursal = row.Cells["id_sucursal"].Value.ToString();
                    ventaProducto.IDVenta = row.Cells["id_venta"].Value.ToString();
                    ventaProducto.IDStatus = Convert.ToInt32(row.Cells["id_statusVenta"].Value.ToString());
                }
                return ventaProducto;
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        #endregion
        #region Validaciones
        private void txt_buscador_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Validaciones Val = new Validaciones();
                Val.SoloAlfaNumerico(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBusquedaVenta_Grid ~ txt_buscador_KeyPress");
            }
        }

        private void txt_buscador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_buscador_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion
        #region Eventos                          
        private void check_folioCliente_OnChange(object sender, EventArgs e)
        {
            try
            {

                if (check_folioCliente.Checked)
                {
                    check_fecha.Checked = false;
                    tipoBusqueda = 1;
                    this.CargarGridBusqueda(tipoBusqueda, txt_buscador.Text, dtp_fechaVenta.Value);
                    this.txt_buscador.SelectAll();
                }
                else
                {
                    check_folioCliente.Checked = true;
                    check_fecha.Checked = false;
                    tipoBusqueda = 1;
                    this.CargarGridBusqueda(tipoBusqueda, txt_buscador.Text, dtp_fechaVenta.Value);
                    this.txt_buscador.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBusquedaVenta_Grid ~ check_folioCliente_OnChange");
            }
        }

        private void check_fecha_OnChange(object sender, EventArgs e)
        {
            try
            {
                if (check_fecha.Checked)
                {
                    //check_folioCliente.Checked = false;
                    tipoBusqueda = 2;
                    this.CargarGridBusqueda(tipoBusqueda, txt_buscador.Text, dtp_fechaVenta.Value);
                }
                else
                {
                    check_fecha.Checked = true;
                    //check_folioCliente.Checked = false;
                    tipoBusqueda = 2;
                    this.CargarGridBusqueda(tipoBusqueda, txt_buscador.Text, dtp_fechaVenta.Value);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBusquedaVenta_Grid ~ check_fecha_OnChange");
            }
        }

        private void dtp_fechaVenta_onValueChanged(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (tipoBusqueda == 2)
                        this.CargarGridBusqueda(tipoBusqueda, txt_buscador.Text, dtp_fechaVenta.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBusquedaVenta_Grid ~ dtp_fechaVenta_onValueChanged");
            }
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    this.Visible = false;
                    frm_VentaCambioNuevo fdmt = new frm_VentaCambioNuevo(this.ObtenerDatosGridBusqueda());
                    fdmt.ShowDialog();
                    fdmt.Dispose();
                    this.Visible = true;
                    txt_buscador.Text = "Búsqueda por folio o cliente";
                    this.CargarGridBusqueda(tipoBusqueda, "", dtp_fechaVenta.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBusquedaVenta_Grid ~ btn_Aceptar_Click");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBusquedaVenta_Grid ~ btnCerrar_Click");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                txt_buscador.Text = "Búsqueda por folio o cliente";
                this.CargarGridBusqueda(1, "", dtp_fechaVenta.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBusquedaVenta_Grid ~ btnCancelar_Click");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tipoBusqueda == 1)
                    this.CargarGridBusqueda(tipoBusqueda, txt_buscador.Text, dtp_fechaVenta.Value);
                else if (tipoBusqueda == 2)
                    this.CargarGridBusqueda(tipoBusqueda, "", dtp_fechaVenta.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBusquedaVenta_Grid ~ btnBuscar_Click");
            }
        }

        private void GridViewGeneral_Sorted(object sender, EventArgs e)
        {
            try
            {
                this.ImagenGrid();
            }
            catch (Exception)
            {
            }
        }

        private void txt_buscador_Click(object sender, EventArgs e)
        {

        }




        #endregion

        private void txt_buscador_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
