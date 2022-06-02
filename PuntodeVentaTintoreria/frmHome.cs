using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using TintoreriaGlobal;
using TintoreriaNegocio;
using System.IO;
using PuntodeVentaTintoreria.ClaseAux;
using PuntodeVentaTintoreria.ClaseAux.EventArgsAux;

namespace PuntodeVentaTintoreria
{
    public partial class frmHome : Form
    {
        private bool Verificador = false;
        private string colorfondo02 = "#1f8b9a";
        private bool CatalogosActivos;

        public frmHome()
        {
            InitializeComponent();
            CatalogosActivos = false;
            this.lblMpoEdo.Text = Comun.UbicacionMacAddress;
            this.lblDireccion.Text = Comun.DireccionMacAddress;
            this.lblSucursal.Text = Comun.TipoSucursal;
        }


        #region EventosForm



        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        protected virtual void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPictureBox_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                PictureBox pic = (PictureBox)sender;
                pic.BackColor = ColorTranslator.FromHtml(colorfondo02);
            }
            catch (Exception)
            {


            }
        }

        private void btnPictureBox_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                PictureBox pic = (PictureBox)sender;
                pic.BackColor = Color.Transparent;
            }
            catch (Exception)
            {


            }

        }

        #endregion

        private void btnMenu_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.panelMenuHome.Visible) this.panelMenuHome.Visible = false;
                else this.panelMenuHome.Visible = true;

            }
            catch (Exception)
            {


            }

        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.panelMenuContext.Visible)
                {
                    this.panelMenuContext.Visible = false;
                }
                else
                {
                    this.panelMenuContext.BringToFront();
                    this.panelMenuContext.Visible = true;
                }
            }
            catch (Exception)
            {


            }
        }

        private void btnOpciones_Click(object sender, EventArgs e)
        {
            try
            {
                if (!panelOpcionesGeneral01.Visible)
                {
                    panelOpcionesGeneral01.Visible = true;
                    panelOpcionesGeneral02.Visible = false;
                    panelOpcionesGeneral03.Visible = false;
                    panelOpcionesGeneral04.Visible = false;
                    panelOpcionesGeneral05.Visible = false;
                }

            }
            catch (Exception)
            {


            }
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            try
            {
                if (!panelOpcionesGeneral02.Visible)
                {
                    panelOpcionesGeneral01.Visible = false;
                    panelOpcionesGeneral02.Visible = true;
                    panelOpcionesGeneral03.Visible = false;
                    panelOpcionesGeneral04.Visible = false;
                    panelOpcionesGeneral05.Visible = false;
                }

            }
            catch (Exception)
            {


            }
        }

        private void btnCatalogos_Click(object sender, EventArgs e)
        {
            try
            {
                if (!panelOpcionesGeneral03.Visible)
                {
                    panelOpcionesGeneral01.Visible = false;
                    panelOpcionesGeneral02.Visible = false;
                    panelOpcionesGeneral03.Visible = true;
                    panelOpcionesGeneral04.Visible = false;
                    panelOpcionesGeneral05.Visible = false;
                }

            }
            catch (Exception)
            {


            }
        }

        private void btnConfiguración_Click(object sender, EventArgs e)
        {
            try
            {
                if (!panelOpcionesGeneral04.Visible)
                {

                    panelOpcionesGeneral01.Visible = false;
                    panelOpcionesGeneral02.Visible = false;
                    panelOpcionesGeneral03.Visible = false;
                    panelOpcionesGeneral04.Visible = true;
                    panelOpcionesGeneral05.Visible = false;
                }

            }
            catch (Exception)
            {


            }
        }

        private void btnTintoreria_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmVentaTintoreria frmt = new frmVentaTintoreria(1);
            if (frmt.ShowDialog() == DialogResult.OK)
            {


            }
            frmt.Dispose();
            this.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmVentaLavanderia frmt = new frmVentaLavanderia();
            if (frmt.ShowDialog() == DialogResult.OK)
            {
            }
            frmt.Dispose();
            this.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmBuscarTicket frmt = new frmBuscarTicket();
            if (frmt.ShowDialog() == DialogResult.OK)
            {
                frmDetalleTicket frmd = new frmDetalleTicket();
                frmd.ShowDialog();
                frmd.Dispose();

            }
            frmt.Dispose();
            this.Visible = true;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmVentaProductos frmt = new frmVentaProductos();
            if (frmt.ShowDialog() == DialogResult.OK)
            {
            }
            frmt.Dispose();
            this.Visible = true;
        }

        private void btnDispositivos_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmLoginPermisos frmt = new frmLoginPermisos(0);
            frmt.ShowDialog();
            frmt.Dispose();
            this.Visible = true;
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmLoginPermisos frmt = new frmLoginPermisos(1);
            if (frmt.ShowDialog() == DialogResult.OK)
            {
                int Mostrar = frmt.VerificarOpcion;
                this.OcultarPanel(Mostrar);
            }
            frmt.Dispose();
            this.Visible = true;
        }

        private void OcultarPanel(int MostrarPanel)
        {
            try
            {
                if (MostrarPanel == 0)
                {
                    if (!panelOpcionesGeneral01.Visible)
                    {
                        panelOpcionesGeneral01.Visible = true;
                        panelOpcionesGeneral02.Visible = false;
                        panelOpcionesGeneral03.Visible = false;
                        panelOpcionesGeneral04.Visible = false;
                        panelOpcionesGeneral05.Visible = false;
                    }
                }
                else if (MostrarPanel == 1)
                {
                    if (!panelOpcionesGeneral05.Visible)
                    {

                        panelOpcionesGeneral01.Visible = false;
                        panelOpcionesGeneral02.Visible = false;
                        panelOpcionesGeneral03.Visible = false;
                        panelOpcionesGeneral04.Visible = false;
                        panelOpcionesGeneral05.Visible = true;
                        panelOpcionesGeneral05.Location = new Point(50, 175);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void panelOpcionesGeneral03_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnVender_Click(object sender, EventArgs e)
        {

            try
            {

                frmVentaProductos fc = new frmVentaProductos();
                fc.ShowDialog();
                fc.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

                LogError.AddExcFileTxt(ex, "CtrlOperaciones ~ btnNuevaCompra_Click");
            }
        }

        private void btnCambiosProductos_Click(object sender, EventArgs e)
        {
            try
            {

                frm_VentaCambios frmcg = new frm_VentaCambios();
                frmcg.ShowDialog();
                frmcg.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "CtrlOperaciones ~ btnCambios_Click");
            }
        }

        private void btnCancelaciones_Click(object sender, EventArgs e)
        {
            try
            {

                frm_VentaCancelaciones frmcg = new frm_VentaCancelaciones();
                frmcg.ShowDialog();
                frmcg.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

                LogError.AddExcFileTxt(ex, "CtrlOperaciones ~ toolsm_cancelaciones_Click");
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            try
            {

                frm_Clientes fcg = new frm_Clientes();
                fcg.ShowDialog();
                fcg.Dispose();


            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

                LogError.AddExcFileTxt(ex, "CtrlOperaciones ~ toolsm_clientes_Click");
            }
        }

        private void btnTintoreria_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            frmVentaTintoreria frmt = new frmVentaTintoreria(1);
            if (frmt.ShowDialog() == DialogResult.OK)
            {
            }
            frmt.Dispose();
            this.Visible = true;
        }

        private void btnProductosInv_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                FrmProductos_Grid fpg = new FrmProductos_Grid();
                fpg.ShowDialog();
                fpg.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ toolsm_productos_Click");
            }
        }

        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmAlmacen frma = new frmAlmacen();
                frma.ShowDialog();
                frma.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnAlmacen_Click");
            }
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmComprasGrid fcg = new frmComprasGrid();
                fcg.ShowDialog();
                fcg.Dispose();
                this.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ toolsm_compras_Click");
            }
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmProveedores_Grid fpg = new frmProveedores_Grid();
                fpg.ShowDialog();
                fpg.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ toolsm_proveedores_Click");
            }
        }

        private void btnBodega_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmBodega frmb = new frmBodega();
                frmb.ShowDialog();
                frmb.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnArtsBodega_Click");
            }
        }

        private void btnCuentasPagar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmDocumentoXPagar frmdg = new frmDocumentoXPagar();
                frmdg.ShowDialog();
                frmdg.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnDocsXPagar_Click");
            }
        }


        #region Eventos

        private void bgwCatalogos_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ComunNegocio cn = new ComunNegocio();
                cn.ObtenerCatalogosTintoreria();
            }
            catch (Exception)
            {


            }
        }

        private void bgwCatalogos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                CatalogosActivos = true;
            }
            catch (Exception)
            {


            }
        }

        #endregion

        private void btnLavanderia_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmVentaTintoreria frmt = new frmVentaTintoreria(2);
            if (frmt.ShowDialog() == DialogResult.OK)
            {


            }
            frmt.Dispose();
            this.Visible = true;
        }

        private void btnMonitorProcesos_Click(object sender, EventArgs e)
        {
            frmMonitorProceso frmt = new frmMonitorProceso();
            if (frmt.ShowDialog() == DialogResult.OK)
            {


            }
            frmt.Dispose();
            this.Visible = true;
        }

        private void btnEntregass_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmGridEntregas frmt = new frmGridEntregas();
            if (frmt.ShowDialog() == DialogResult.OK)
            {


            }
            frmt.Dispose();
            this.Visible = true;


        }

        private void btnEnvios_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Frm_GridEnvio frmt = new Frm_GridEnvio();
            if (frmt.ShowDialog() == DialogResult.OK)
            {


            }
            frmt.Dispose();
            this.Visible = true;

        }

        #region Catálogos
        private void btnCatEmpresa_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            frmDatosEmpresa_Cat frm = new frmDatosEmpresa_Cat();
            frm.ShowDialog();
            frm.Dispose();
            this.Visible = true;
        }

        private void btnCatSucursales_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FrmSucursales_Cat frm = new FrmSucursales_Cat();
            frm.ShowDialog();
            frm.Dispose();
            this.Visible = true;
        }
        #endregion

        private void btnCatColorRopa_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmColorRopa_Cat frm = new frmColorRopa_Cat();
                frm.ShowDialog();
                frm.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnAlmacen_Click");
            }
        }

        private void btnCatMaterialesRopa_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                FrmMateriales_Cat frm = new FrmMateriales_Cat();
                frm.ShowDialog();
                frm.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnAlmacen_Click");
            }
        }

        private void btnCatMotivoCancelacion_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                FrmMotivo_Cat frm = new FrmMotivo_Cat();
                frm.ShowDialog();
                frm.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnAlmacen_Click");
            }
        }

        private void btnCatUnidadesMedida_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                FrmUnidadMedida_Cat frm = new FrmUnidadMedida_Cat();
                frm.ShowDialog();
                frm.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnAlmacen_Click");
            }
        }

        private void btnCatFamilias_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                FrmFamilias_Cat frm = new FrmFamilias_Cat();
                frm.ShowDialog();
                frm.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnAlmacen_Click");
            }
        }

        private void btnCatMarcasRopa_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                FrmMarca_Cat frm = new FrmMarca_Cat();
                frm.ShowDialog();
                frm.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnAlmacen_Click");
            }
        }

        private void btnCatEquipos_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                FrmEquipo_Grid feg = new FrmEquipo_Grid();
                feg.ShowDialog();
                feg.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnCatEquipos_Click");
            }
        }

        private void btnCatTipoRopa_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                FrmTipoRopa_Grid feg = new FrmTipoRopa_Grid();
                feg.ShowDialog();
                feg.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnCatTipoRopa_Click");
            }
        }

        private void btnCatTipoEstampados_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                FrmTipoEstampado_Grid FE = new FrmTipoEstampado_Grid();
                FE.ShowDialog();
                FE.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnCatTipoEstampados_Click");
            }
        }

        private void configurarTicket_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                FrmConfiguracion frm = new FrmConfiguracion();
                frm.ShowDialog();
                frm.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ configurarTicket_Click");
            }
        }

        private void btnCatVehiculos_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frm_VehiculoGrid frm_Vehiculo = new frm_VehiculoGrid();
                frm_Vehiculo.ShowDialog();
                frm_Vehiculo.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnCatVehiculos_Click");
            }
        }

        private void TmrImagenes_Tick(object sender, EventArgs e)
        {
            try
            {
                if(!BgwImagenes.IsBusy && CatalogosActivos)
                {
                    TmrImagenes.Stop();
                    lblMessageImage.Text = "Espere un momento. Actualizando imágenes...";
                    BgwImagenes.RunWorkerAsync();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void BgwImagenes_DoWork(object sender, DoWorkEventArgs e)
        {
            //No necesita Try Catch
            string UrlBase = Comun.PathBaseImages; //Application.StartupPath + @"\Resources\Iconos";
            if (!Directory.Exists(UrlBase))
            {
                Directory.CreateDirectory(UrlBase);
            }

            VerificarImagenesTipoRopa(UrlBase);
            VerificarImagenesEstampadoRopa(UrlBase);
            VerificarImagenesFibraRopa(UrlBase);
            VerificarImagenesSimboloRopa(UrlBase);

            VerificarImagenesColorRopa(UrlBase);
            VerificarImagenesSubTipoRopa(UrlBase);
        }

        private void BgwImagenes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error is null)
                {
                    lblMessageImage.Text = "Imágenes actualizadas correctamente.";
                }
                else
                {
                    lblMessageImage.Text = string.Empty;
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                TmrImagenes.Start();
            }
        }

        #region Métodos para creación de imágenes

        private void VerificarImagenesTipoRopa(string pathBase)
        {
            try
            {
                pathBase = pathBase + @"\TipoRopa";
                if (!Directory.Exists(pathBase))
                {
                    Directory.CreateDirectory(pathBase);
                }
                foreach (DataRow item in Comun.TipoListaRopa.Rows)
                {
                    int.TryParse(item["id_tipoRopa"].ToString(), out int id);
                    string ext = item["extension"]?.ToString();
                    if (!string.IsNullOrEmpty(ext))
                    {
                        string pathItem = pathBase + string.Format(@"\{0}{1}", id, ext);
                        DateTime.TryParse(item["lastUpdate"].ToString(), out DateTime lastUpdateDB);
                        if (!File.Exists(pathItem))
                        {
                            try
                            {
                                string ImgBase64 = ObtenerImagen(1, id);
                                CrearImagen(pathItem, ImgBase64);
                                File.SetLastAccessTime(pathItem, lastUpdateDB);
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else
                        {
                            //Se obtiene la última fecha de modificación
                            DateTime lastUpdate = File.GetLastAccessTime(pathItem);
                            if (lastUpdate < lastUpdateDB)
                            {
                                try
                                {
                                    string ImgBase64 = ObtenerImagen(1, id);
                                    CrearImagen(pathItem, ImgBase64);
                                    File.SetLastAccessTime(pathItem, lastUpdateDB);
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }                        
                    }
                }
            }
            catch(Exception ex)
            {
                
            }
        }

        private void VerificarImagenesEstampadoRopa(string pathBase)
        {
            try
            {
                pathBase = pathBase + @"\Estampado";
                if (!Directory.Exists(pathBase))
                {
                    Directory.CreateDirectory(pathBase);
                }
                foreach (DataRow item in Comun.EstampadosRopa.Rows)
                {
                    int.TryParse(item["id_estampadoRopa"].ToString(), out int id);
                    string ext = item["extension"]?.ToString();
                    if (!string.IsNullOrEmpty(ext))
                    {
                        string pathItem = pathBase + string.Format(@"\{0}{1}", id, ext);
                        DateTime.TryParse(item["lastUpdate"].ToString(), out DateTime lastUpdateDB);
                        if (!File.Exists(pathItem))
                        {
                            try
                            {
                                
                                string ImgBase64 = ObtenerImagen(2, id);
                                CrearImagen(pathItem, ImgBase64);
                                File.SetLastAccessTime(pathItem, lastUpdateDB);
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else
                        {
                            //Se obtiene la última fecha de modificación
                            DateTime lastUpdate = File.GetLastAccessTime(pathItem);
                            if (lastUpdate < lastUpdateDB)
                            {
                                try
                                {
                                    string ImgBase64 = ObtenerImagen(2, id);
                                    CrearImagen(pathItem, ImgBase64);
                                    File.SetLastAccessTime(pathItem, lastUpdateDB);
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

        private void VerificarImagenesFibraRopa(string pathBase)
        {
            try
            {
                pathBase = pathBase + @"\Fibra";
                if (!Directory.Exists(pathBase))
                {
                    Directory.CreateDirectory(pathBase);
                }
                foreach (DataRow item in Comun.FibrasRopa.Rows)
                {
                    int.TryParse(item["id_fibraRopa"].ToString(), out int id);
                    string ext = item["extension"]?.ToString();
                    if (!string.IsNullOrEmpty(ext))
                    {
                        string pathItem = pathBase + string.Format(@"\{0}{1}", id, ext);
                        DateTime.TryParse(item["lastUpdate"].ToString(), out DateTime lastUpdateDB);
                        if (!File.Exists(pathItem))
                        {
                            try
                            {
                                string ImgBase64 = ObtenerImagen(3, id);
                                CrearImagen(pathItem, ImgBase64);
                                File.SetLastAccessTime(pathItem, lastUpdateDB);
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else
                        {
                            //Se obtiene la última fecha de modificación
                            DateTime lastUpdate = File.GetLastAccessTime(pathItem);
                            if (lastUpdate < lastUpdateDB)
                            {
                                try
                                {
                                    string ImgBase64 = ObtenerImagen(3, id);
                                    CrearImagen(pathItem, ImgBase64);
                                    File.SetLastAccessTime(pathItem, lastUpdateDB);
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

        private void VerificarImagenesSimboloRopa(string pathBase)
        {
            try
            {
                pathBase = pathBase + @"\Simbolo";
                if (!Directory.Exists(pathBase))
                {
                    Directory.CreateDirectory(pathBase);
                }
                foreach (DataRow item in Comun.SimbolosRopa.Rows)
                {
                    int.TryParse(item["id_simboloRopa"].ToString(), out int id);
                    string ext = item["extension"]?.ToString();
                    if (!string.IsNullOrEmpty(ext))
                    {
                        string pathItem = pathBase + string.Format(@"\{0}{1}", id, ext);
                        DateTime.TryParse(item["lastUpdate"].ToString(), out DateTime lastUpdateDB);
                        if (!File.Exists(pathItem))
                        {
                            try
                            {
                                string ImgBase64 = ObtenerImagen(4, id);
                                CrearImagen(pathItem, ImgBase64);
                                File.SetLastAccessTime(pathItem, lastUpdateDB);
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else
                        {
                            //Se obtiene la última fecha de modificación
                            DateTime lastUpdate = File.GetLastAccessTime(pathItem);
                            if (lastUpdate < lastUpdateDB)
                            {
                                try
                                {
                                    string ImgBase64 = ObtenerImagen(4, id);
                                    CrearImagen(pathItem, ImgBase64);
                                    File.SetLastAccessTime(pathItem, lastUpdateDB);
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }

        private void VerificarImagenesColorRopa(string pathBase)
        {
            try
            {
                pathBase = pathBase + @"\Color";
                if (!Directory.Exists(pathBase))
                {
                    Directory.CreateDirectory(pathBase);
                }
                foreach (DataRow item in Comun.ColoresRopa.Rows)
                {
                    int.TryParse(item["id_colorRopa"].ToString(), out int id);
                    string ext = item["extension"]?.ToString();
                    if (!string.IsNullOrEmpty(ext))
                    {
                        string pathItem = pathBase + string.Format(@"\{0}{1}", id, ext);
                        DateTime.TryParse(item["lastUpdate"].ToString(), out DateTime lastUpdateDB);
                        if (!File.Exists(pathItem))
                        {
                            try
                            {
                                string ImgBase64 = ObtenerImagen(5, id);
                                CrearImagen(pathItem, ImgBase64);
                                File.SetLastAccessTime(pathItem, lastUpdateDB);
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else
                        {
                            //Se obtiene la última fecha de modificación
                            DateTime lastUpdate = File.GetLastAccessTime(pathItem);
                            if (lastUpdate < lastUpdateDB)
                            {
                                try
                                {
                                    string ImgBase64 = ObtenerImagen(5, id);
                                    CrearImagen(pathItem, ImgBase64);
                                    File.SetLastAccessTime(pathItem, lastUpdateDB);
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void VerificarImagenesSubTipoRopa(string pathBase)
        {
            try
            {
                pathBase = pathBase + @"\Subtipo";
                if (!Directory.Exists(pathBase))
                {
                    Directory.CreateDirectory(pathBase);
                }
                foreach (DataRow item in Comun.ListaRopa.Rows)
                {
                    int.TryParse(item["id_ropa"].ToString(), out int id);
                    string ext = item["extension"]?.ToString();
                    if (!string.IsNullOrEmpty(ext))
                    {
                        string pathItem = pathBase + string.Format(@"\{0}{1}", id, ext);
                        DateTime.TryParse(item["lastUpdate"].ToString(), out DateTime lastUpdateDB);
                        if (!File.Exists(pathItem))
                        {
                            try
                            {
                                string ImgBase64 = ObtenerImagen(6, id);
                                CrearImagen(pathItem, ImgBase64);
                                File.SetLastAccessTime(pathItem, lastUpdateDB);
                            }
                            catch (Exception)
                            {
                            }
                        }
                        else
                        {
                            //Se obtiene la última fecha de modificación
                            DateTime lastUpdate = File.GetLastAccessTime(pathItem);
                            if (lastUpdate < lastUpdateDB)
                            {
                                try
                                {
                                    string ImgBase64 = ObtenerImagen(6, id);
                                    CrearImagen(pathItem, ImgBase64);
                                    File.SetLastAccessTime(pathItem, lastUpdateDB);
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void CrearImagen(string path, string imageBase64)
        {
            try
            {
                //var image = imageBase64.Base64StringToBitmap();
                byte[] byteBuffer = Convert.FromBase64String(imageBase64);
                File.WriteAllBytes(path, byteBuffer);
                byteBuffer = null;
                //Image clone = (Image)image;
                //clone.(path);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public string ObtenerImagen(int tipo, int id)
        {
            try
            {
                string Image = string.Empty;
                ImagenNegocio neg = new ImagenNegocio();
                switch (tipo)
                {
                    case 1: Image = neg.ObtenerImagenTipoRopa(id);
                        break;
                    case 2: Image = neg.ObtenerImagenEstampadoRopa(id);
                        break;
                    case 3: Image = neg.ObtenerImagenFibraRopa(id);
                        break;
                    case 4: Image = neg.ObtenerImagenSimboloRopa(id);
                        break;
                    case 5: Image = neg.ObtenerImagenColorRopa(id);
                        break;
                    case 6: Image = neg.ObtenerImagenSubtipoRopa(id);
                        break;
                    default:
                        throw new InvalidDataException("Tipo no válido.");
                }
                return Image;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        private FrmEspera IniciarFormWait()
        {
            try
            {
                FrmEspera frmEspera = new FrmEspera("Espere un momento.", 1);
                frmEspera.DoWork += new FrmEspera.DoWorkHandler(this.FrmEspera_DoWork);
                frmEspera.RunWorkedComplete += new FrmEspera.RunWorkedCompleteHandler(this.FrmEspera_WorkerCompleted);
                return frmEspera;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FrmEspera_DoWork(FrmEspera m, DoWorkWaitEventArgs e)
        {
            try
            {
                ComunNegocio cn = new ComunNegocio();
                var y = Comun.FechasFestivas;
                cn.ObtenerCatalogosTintoreria();
                //e.Result = result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FrmEspera_WorkerCompleted(FrmEspera m, RunWorkerCompletedWaitEventArgs e)
        {
            try
            {
                if (e.Error is null)
                {
                    CatalogosActivos = true;
                }
                else
                {
                    MessageBox.Show("Error al obtener datos de configuración inicial. Detalles del error: " + e.Error.Message, "Sistema Punto de Venta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al obtener datos de configuración inicial. ", "Sistema Punto de Venta.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmHome_Shown(object sender, EventArgs e)
        {
            FrmEspera frmwait = IniciarFormWait();
            frmwait.ShowDialog();
        }

        private void btnCatTipoFibras_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                FrmTipoFibra_Grid frm = new FrmTipoFibra_Grid();
                frm.ShowDialog();
                frm.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnCatTipoFibras_Click");
            }
        }

        private void btnCatMembresias_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frm_MembresiasGrid _membresia = new frm_MembresiasGrid();
                _membresia.ShowDialog();
                _membresia.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnCatMembresias_Click");
            }
        }

        private void btnCatSimbolosTextiles_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                FrmSimboloTextil frm = new FrmSimboloTextil();
                frm.ShowDialog();
                frm.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnCatSimbolosTextiles_Click");
            }
        }

        private void btnTipoSimboloTextil_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                FrmTipoSimboloTextil frm = new FrmTipoSimboloTextil();
                frm.ShowDialog();
                frm.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnTipoSimboloTextil_Click");
            }
        }

        private void btn_grupo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frm_GrupGrid _grupo = new frm_GrupGrid();
                _grupo.ShowDialog();
                _grupo.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ btn_grupo_Click");
            }
        }

        private void btnClientes_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frm_Clientes _clientes = new frm_Clientes();
                _clientes.ShowDialog();
                _clientes.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnClientes_Click_1");
            }
        }

        private void btnPromocion_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                FrmPromociones frm = new FrmPromociones();
                frm.ShowDialog();
                frm.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnPromocion_Click");
            }
        }

        private void btnCatSubtipoRopa_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                FrmSubTipoRopaIndex frm = new FrmSubTipoRopaIndex();
                frm.ShowDialog();
                frm.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnCatSubtipoRopa_Click");
            }
        }

        private void btnCatTiempoEntrega_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frm_TiempoEntregaGrid _tiempo = new frm_TiempoEntregaGrid();
                _tiempo.ShowDialog();
                _tiempo.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnCatDefectos_Click");
            }
        }

        private void btnCatDiasFestivos_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frm_DiasFestivosGrid _festivos = new frm_DiasFestivosGrid();
                _festivos.ShowDialog();
                _festivos.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnCatDiasFestivos_Click");
            }
        }

        private void TmrSistema_Tick(object sender, EventArgs e)
        {
            this.lblFechaHora.Text = DateTime.Now.ToString("dd/MM/yyyy h:mm tt");
        }

        private void Btn_RetiroCaja_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frm_TintoreriaRetiros _frmRetiro = new frm_TintoreriaRetiros(1, new Retiros());
                _frmRetiro.ShowDialog();
                _frmRetiro.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ Btn_RetiroCaja_Click");
            }
        }

        private void btnDeposito_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frm_TintoreriaDepositos _frmDepositos = new frm_TintoreriaDepositos(new Depositos());
                _frmDepositos.ShowDialog();
                _frmDepositos.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ Btn_RetiroCaja_Click");
                
            }
        }

        private void btnResumenVenta_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                Frm_ResumenVenta _Resumen = new Frm_ResumenVenta();
                _Resumen.ShowDialog();
                _Resumen.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnResumenVenta_Click");
            }
        }

        #region Region de Reportes

        private void btnReporteCajaxFechaXsucursal_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                Frm_Reporte Reporte = new Frm_Reporte(4, new Caja());
                Reporte.ShowDialog();
                Reporte.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnReporteCajaxFechaXsucursal_Click");
            }
        }

        private void btnRCajaXDiaXSucursal_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                Frm_Reporte Reporte = new Frm_Reporte(5, new Caja());
                Reporte.ShowDialog();
                Reporte.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnReporteCajaxFechaXsucursal_Click");
            }
        }

        private void btnDMovimientoXfechaXSucursal_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                Frm_Reporte Reporte = new Frm_Reporte(6, 0);
                Reporte.ShowDialog();
                Reporte.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ btnDMovimientoXfechaXSucursal_Click");
            }
        }
        #endregion
        private void btn_Lavado_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frm_DetalleLavadoGrid _Dlavado = new frm_DetalleLavadoGrid();
                _Dlavado.ShowDialog();
                _Dlavado.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ btn_Lavado_Click");
            }
        }

        private void BtnRopa_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                FrmRopaIndex frm = new FrmRopaIndex();
                frm.ShowDialog();
                frm.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ BtnRopa_Click");
            }
        }

        private void btn_Usuario_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                Frm_UsuarioGrid UGrid = new Frm_UsuarioGrid();
                UGrid.ShowDialog();
                UGrid.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Visible = true;
                LogError.AddExcFileTxt(ex, "FrmHome ~ btn_Usuario_Click");
            }
        }
    }
}
