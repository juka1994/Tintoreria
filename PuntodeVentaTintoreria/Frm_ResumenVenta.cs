using PuntodeVentaTintoreria.ClaseAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TintoreriaGlobal;
using TintoreriaNegocio;

namespace PuntodeVentaTintoreria
{
    public partial class Frm_ResumenVenta : Form
    {
        Caja infoCaja = new Caja();
        Validaciones Val;
        public Frm_ResumenVenta()
        {
            InitializeComponent();
        }
        private void Frm_ResumenVenta_Load(object sender, EventArgs e)
        {
            try
            {
                this.backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_ResumenVenta ~ Frm_ResumenVenta_Load");
            }
        }

        #region Eventos
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            try
            {
                this.AbrirCajon();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_ResumenVenta ~ btnAbrirCaja_Click");
            }
        }

        private void btnRetiro_Click(object sender, EventArgs e)
        {
            try
            {
                frm_TintoreriaRetiros _frmRetiro = new frm_TintoreriaRetiros(1, new Retiros());
                _frmRetiro.ShowDialog();
                _frmRetiro.Dispose();
                this.LLenarDatosCaja();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_ResumenVenta ~ btnRetiro_Click");
            }
        }

        private void btnDeposito_Click(object sender, EventArgs e)
        {
            try
            {
                frm_TintoreriaDepositos TintoreDep = new frm_TintoreriaDepositos(new Depositos());
                TintoreDep.ShowDialog();
                TintoreDep.Dispose();
                this.LLenarDatosCaja();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_ResumenVenta ~ btnDeposito_Click");
            }
        }

        private void btnRetiroCajaLLena_Click(object sender, EventArgs e)
        {
            try
            {
                frm_TintoreriaRetiros _frmRetiro = new frm_TintoreriaRetiros(2, new Retiros());
                _frmRetiro.ShowDialog();
                _frmRetiro.Dispose();
                this.LLenarDatosCaja();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_ResumenVenta ~ btnDeposito_Click");
            }
        }

        private void btnCajaActual_Click(object sender, EventArgs e)
        {
            try
            {
                Frm_Reporte Reporte = new Frm_Reporte(3, infoCaja);
                Reporte.ShowDialog();
                Reporte.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_ResumenVenta ~ btnDeposito_Click");
            }
        }
        private void btnMovCaja_Click(object sender, EventArgs e)
        {
            try
            {                
                    Frm_Reporte Reporte = new Frm_Reporte(2, 0);
                    Reporte.ShowDialog();
                    Reporte.Dispose();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_ResumenVenta ~ btnDeposito_Click");
            }
        }
        private void btnBusquedaGrid_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtBusFolio.Text == "Folio de Venta" && this.txtBusCliente.Text == "Nombre del Cliente")
                    this.CargarGridHome("", "", tab_venta.SelectedIndex);
                else if (this.txtBusCliente.Text == "Nombre del Cliente" && this.txtBusFolio.Text != "Folio de Venta")
                    this.CargarGridHome(this.txtBusFolio.Text, "", tab_venta.SelectedIndex);
                else if (this.txtBusCliente.Text != "Nombre del Cliente" && this.txtBusFolio.Text == "Folio de Venta")
                    this.CargarGridHome("", this.txtBusCliente.Text, tab_venta.SelectedIndex);
                else if (this.txtBusCliente.Text != "Nombre del Cliente" && this.txtBusFolio.Text != "Folio de Venta")
                    this.CargarGridHome(this.txtBusCliente.Text, this.txtBusCliente.Text, tab_venta.SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_ResumenVenta ~ btnBusquedaGrid_Click");
            }
        }

        private void btnCancelarBus_Click(object sender, EventArgs e)
        {
            try
            {
                txtBusCliente.Text = "";
                txtBusFolio.Text = "";
                this.CargarGridHome("", "", tab_venta.SelectedIndex);
                this.LLenarDatosCaja();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_ResumenVenta ~ btnCancelarBus_Click");
            }
        }
        #endregion


        #region Metodos
        private void CargarGridHome(string folio, string cliente, int tabIndex)
        {
            try
            {
                VentaProductosNegocio ventaProductosNegocio = new VentaProductosNegocio();
                VentaProductos ventaProductos = new VentaProductos();
                ventaProductos.conexion = Comun.conexion;
                ventaProductos.IDCaja = Comun.id_caja;
                ventaProductos.Folio = folio;
                ventaProductos.NombreCliente = cliente;
                ventaProductosNegocio.LLenarGridHome(tabIndex, ventaProductos);
                switch (tabIndex)
                {
                    case 0:
                        this.GridViewVentas.AutoGenerateColumns = false;
                        this.GridViewVentas.DataSource = ventaProductos.datos;
                        break;
                    case 1:
                        this.GridViewPedido.AutoGenerateColumns = false;
                        this.GridViewPedido.DataSource = ventaProductos.datos;
                        break;
                    case 2:
                        this.GridViewCancelacion.AutoGenerateColumns = false;
                        this.GridViewCancelacion.DataSource = ventaProductos.datos;
                        break;
                    default:
                        this.GridViewVentas.AutoGenerateColumns = false;
                        this.GridViewVentas.DataSource = ventaProductos.datos;
                        break;
                }
                ImagenGrid(tabIndex);
                ImagenGridEntregado();
                ImagenGridDispositivo();
                ImagenGridTerminado();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AbrirCajon()
        {
            try
            {
                PrinterSettings ps = new PrinterSettings();
                ps.PrinterName = string.IsNullOrEmpty(Comun.namePrinter) ? "" : Comun.namePrinter;
                byte[] codigo = new byte[] { 27, 112, 48, 50, 250 };
                if (ps.IsValid)
                    RawPrinterHelper.SendStringToPrinter(ps.PrinterName, System.Text.ASCIIEncoding.ASCII.GetString(codigo));
                else
                    throw new Exception("No se pudo conectar con la impresora.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LLenarDatosCaja()
        {
            try
            {
                infoCaja.CadConexion = Comun.conexion;
                infoCaja.id_caja = Comun.id_caja;
                infoCaja.id_sucursal = Comun.id_sucursal;
                CajaNegocio caja_negocio = new CajaNegocio();
                caja_negocio.ObtenerCajaXID(infoCaja);
                this.txt_inicioCajaTotal.Text = String.Format("{0:C2}", infoCaja.TotalInicioCaja);
                this.txt_ventaTotal.Text = String.Format("{0:C2}", infoCaja.TotalVentas);
                this.txt_pedidosTotal.Text = String.Format("{0:C2}", infoCaja.TotalPedidos);
                this.txt_cambiosTotal.Text = String.Format("{0:C2}", infoCaja.TotalCambios);
                this.txt_cancelacionesTotal.Text = String.Format("{0:C2}", infoCaja.TotalCancelaciones);
                this.txt_comprasTotal.Text = String.Format("{0:C2}", infoCaja.TotalCompras);
                this.txt_depositos.Text = String.Format("{0:C2}", infoCaja.TotalDepositos);
                this.txt_retiros.Text = String.Format("{0:C2}", infoCaja.TotalRetirosPagos);
                this.txt_total.Text = String.Format("{0:C2}", infoCaja.TotalCaja);
                infoCaja.lstCaja = new List<Caja>();
                infoCaja.lstCaja.Add(infoCaja);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ImagenGrid(int tabIndex)
        {
            switch (tabIndex)
            {
                case 0:
                    foreach (DataGridViewRow Grid in this.GridViewVentas.Rows)
                    {
                        if (Convert.ToInt32(Grid.Cells[12].Value) == 1)
                            Grid.Cells[13].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_ORANGE.png"), new Size(25, 25));
                        else if (Convert.ToInt32(Grid.Cells[12].Value) == 2)
                            Grid.Cells[13].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_GREEN.png"), new Size(25, 25));
                        else if (Convert.ToInt32(Grid.Cells[12].Value) == 3)
                            Grid.Cells[13].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_BLUE.png"), new Size(25, 25));
                    }
                    break;
                case 1:
                    foreach (DataGridViewRow Grid in this.GridViewPedido.Rows)
                    {
                        if (Convert.ToInt32(Grid.Cells[12].Value) == 1)
                            Grid.Cells[13].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_ORANGE.png"), new Size(25, 25));
                        else if (Convert.ToInt32(Grid.Cells[12].Value) == 2)
                            Grid.Cells[13].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_GREEN.png"), new Size(25, 25));
                        else if (Convert.ToInt32(Grid.Cells[12].Value) == 3)
                            Grid.Cells[13].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_BLUE.png"), new Size(25, 25));
                    }
                    break;
                default:
                    break;
            }
        }
        private void ImagenGridEntregado()
        {
            foreach (DataGridViewRow Grid in this.GridViewPedido.Rows)
            {
                if (Convert.ToBoolean(Grid.Cells[14].Value) == false)
                    Grid.Cells[15].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_ORANGE.png"), new Size(25, 25));
                else if (Convert.ToBoolean(Grid.Cells[14].Value) == true)
                    Grid.Cells[15].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_GREEN.png"), new Size(25, 25));
            }
        }
        private void ImagenGridDispositivo()
        {
            foreach (DataGridViewRow Grid in this.GridViewPedido.Rows)
            {
                if (Convert.ToInt32(Grid.Cells[16].Value) == 1)
                    Grid.Cells[17].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_GREEN.png"), new Size(25, 25));
                else if (Convert.ToInt32(Grid.Cells[16].Value) == 2)
                    Grid.Cells[17].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_BLUE.png"), new Size(25, 25));
            }
        }
        private void ImagenGridTerminado()
        {
            foreach (DataGridViewRow Grid in this.GridViewPedido.Rows)
            {
                if (Convert.ToBoolean(Grid.Cells["terminado"].Value) == false)
                    Grid.Cells["statusTer"].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_ORANGE.png"), new Size(25, 25));
                else if (Convert.ToBoolean(Grid.Cells["terminado"].Value) == true)
                    Grid.Cells["statusTer"].Value = resizeImage(Image.FromFile(Application.StartupPath + @"\Resources\Estatus\GLOBES_GREEN.png"), new Size(25, 25));
            }
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private bool ValidarFilaSeleccionada(List<DataGridViewRow> rowSelected)
        {
            try
            {
                if (rowSelected.Count == 0)
                {
                    MessageBox.Show(this, "Debe seleccionar una fila del grid", Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private List<DataGridViewRow> ObtenerFilaSeleccionada()
        {
            try
            {
                List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();


                foreach (DataGridViewRow row in GridViewVentas.Rows)
                {
                    if (row.Selected)
                    {
                        rowSelected.Add(row);
                    }
                }


                return rowSelected;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Segundo Plano
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                VentaProductosNegocio ventaProductosNegocio = new VentaProductosNegocio();
                VentaProductos ventaProductos = new VentaProductos();
                ventaProductos.conexion = Comun.conexion;
                ventaProductos.IDCaja = Comun.id_caja;                            
                ventaProductos.Folio = "";
                ventaProductos.NombreCliente = "";
                ventaProductosNegocio.LLenarGridHome(0, ventaProductos);
                e.Result = ventaProductos.datos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                DataTable datos = (DataTable)e.Result;
                this.GridViewVentas.AutoGenerateColumns = false;
                this.GridViewVentas.DataSource = datos;
                LLenarDatosCaja();
                ImagenGrid(0);
                ImagenGridEntregado();
                ImagenGridDispositivo();
                ImagenGridTerminado();
                //espere.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
