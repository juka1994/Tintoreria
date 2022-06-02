using PuntodeVentaTintoreria.ClaseAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TintoreriaGlobal;
using TintoreriaNegocio;

namespace PuntodeVentaTintoreria
{
    public partial class FrmProductos_Grid : Form
    {
        Validaciones Val;
        int tipoBusqueda = 1;
        Producto infoProducto = new Producto();
        frm_Esperar espere = new frm_Esperar();
        public FrmProductos_Grid()
        {
            InitializeComponent();
            Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
        }

        #region Metodos Generales
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
        private void CargarGridProducto(string busqueda, int tipoBusqueda)
        {
            try
            {
                ProductoNegocio productoNegocio = new ProductoNegocio();
                Producto producto = new Producto();
                producto.conexion = Comun.conexion;
                producto.busqueda = busqueda;
                producto.tipoBusqueda = tipoBusqueda;
                productoNegocio.LLenarGridProductoSinImagen(producto);
                this.GridviewGeneral.AutoGenerateColumns = false;
                this.GridviewGeneral.DataSource = producto.datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Producto ObtenerDatosGridProducto()
        {
            try
            {
                Producto producto = new Producto();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    producto.id_producto = row.Cells["id_producto"].Value.ToString();
                    producto.id_proveedor = row.Cells["id_proveedor"].Value.ToString();
                    producto.id_familia = Convert.ToInt32(row.Cells["id_familia"].Value);
                    producto.cantidadMayoreo = Convert.ToInt32(row.Cells["cantidadMayoreo"].Value);
                    producto.inventarioOptimo = Convert.ToInt32(row.Cells["inventarioOptimo"].Value);
                    producto.nombreProducto = row.Cells["nombreProducto"].Value.ToString();
                    producto.id_unidadMedida = Convert.ToInt32(row.Cells["id_unidadMedida"].Value);
                    producto.observaciones = row.Cells["observaciones"].Value.ToString();
                    producto.NombreUnidadMedida = row.Cells["unidadMedida"].Value.ToString();
                }
                return producto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private void EliminarProducto(Producto producto)
        {
            try
            {
                int Verificador = -1;
                ProductoNegocio productoNegocio = new ProductoNegocio();
                producto.conexion = Comun.conexion;
                producto.opcion = 3;
                producto.id_u = Comun.id_u;
                producto.productoDetalle = new ProductoDetalle();
                //productoNegocio.AbcProductoGeneral(producto, ref Verificador);
                productoNegocio.AbcProductoGeneral2(producto, ref Verificador);
                if (Verificador == 0)
                {
                    this.txt_buscador.Text = "Búsqueda por nombre o familia";
                    this.CargarGridProducto("", tipoBusqueda);
                    MessageBox.Show(this, "Los datos se eliminaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
                ProductoNegocio productoNegocio = new ProductoNegocio();
                Producto producto = new Producto();
                producto.conexion = Comun.conexion;
                producto.busqueda = "";
                producto.tipoBusqueda = tipoBusqueda;
                productoNegocio.LLenarGridProductoSinImagen(producto);
                infoProducto.datos = producto.datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de conección", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                this.GridviewGeneral.AutoGenerateColumns = false;
                this.GridviewGeneral.DataSource = infoProducto.datos;
                espere.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Validaciones
        private void txt_buscador_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.TextoNumerosPuntoGuionTilde(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmProductos_Grid ~ txt_buscador_KeyPress");
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
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txt_buscador_Click(object sender, EventArgs e)
        {
            try
            {
                this.txt_buscador.SelectAll();
                this.txt_buscador.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.CargarGridProducto(this.txt_buscador.Text, tipoBusqueda);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmProductos_Grid ~ btnBuscar_Click");
            }
        }

        private void BtnProducto_Click(object sender, EventArgs e)
        {
            try
            {
               FrmNuevo_Producto fp = new FrmNuevo_Producto(new Producto());
                fp.ShowDialog();
                using (new Recursos.CursorWait())
                {
                    this.txt_buscador.Text = "Búsqueda por nombre o familia";
                    this.CargarGridProducto("", tipoBusqueda);
                }
                fp.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmProductos_Grid ~ btnNueva_Ropa_Click");
            }
        }

        private void pnlBotones_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    if (MessageBox.Show("¿Desea eliminar este registro?", "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (new Recursos.CursorWait())
                        {
                            this.EliminarProducto(this.ObtenerDatosGridProducto());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmProductos_Grid ~ btnEliminar_Click");
            }
        }

        private void txt_buscador_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmProductos_Grid_Load(object sender, EventArgs e)
        {
            try
            {
                this.backgroundWorker1.RunWorkerAsync();
                espere.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmProductos_Grid ~ frmProductos_Grid_Load");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.txt_buscador.Text = "Búsqueda por nombre o familia";
                    this.CargarGridProducto("", tipoBusqueda);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmProductos_Grid ~ btnCancelar_Click");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                FrmProductosRopa fpp = new FrmProductosRopa(new Producto());
                fpp.ShowDialog();
                using (new Recursos.CursorWait())
                {
                    this.txt_buscador.Text = "Búsqueda por nombre o familia";
                    this.CargarGridProducto("", tipoBusqueda);
                }
                fpp.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmProductos_Grid ~ btnNuevo_Click");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    Producto producto = this.ObtenerDatosGridProducto();
                    
                    FrmNuevo_Producto fp = new FrmNuevo_Producto(this.ObtenerDatosGridProducto());
                    fp.ShowDialog();
                    using (new Recursos.CursorWait())
                    {
                        this.txt_buscador.Text = "Búsqueda por nombre o familia";
                        this.CargarGridProducto("", tipoBusqueda);
                    }
                    fp.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmProductos_Grid ~ btnModificar_Click");
            }
        }

        private void btnImprimirCodigoBarra_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                    {
                        Ean13Images eanImagenes = new Ean13Images();
                        eanImagenes.Lista01 = new List<Ean13Images>();
                        eanImagenes.Lista02 = new List<Ean13Images>();
                        eanImagenes.Lista03 = new List<Ean13Images>();
                        List<Ean13Images> ListaPrincipal = new List<Ean13Images>();
                        Producto producto = new Producto();
                        producto = this.ObtenerDatosGridProducto();
                        producto.conexion = Comun.conexion;
                        ProductoNegocio PN = new ProductoNegocio();
                        ListaPrincipal = PN.ObtenerCodigoBarraProducto(producto);
                        int i = 0;
                        foreach (Ean13Images Item in ListaPrincipal)
                        {
                            BarCodeEan13.Ean13Settings config = new BarCodeEan13.Ean13Settings();
                            config.BarCodeHeight = 120;
                            config.LeftMargin = 10;
                            config.RightMargin = 10;
                            config.TopMargin = 10;
                            config.BottomMargin = 10;
                            config.BarWidth = 2;
                            BarCodeEan13.Ean13 barcode = new BarCodeEan13.Ean13(Item.id_ean13, null, config);
                            barcode.Paint().Save(@"Resources\CB\" + Item.id_ean13 + ".png");
                            Item.path = new Uri(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\CB\" + Item.id_ean13 + ".png")).AbsoluteUri;
                            i++;
                            switch (i)
                            {
                                case 1:
                                    eanImagenes.Lista01.Add(Item);
                                    break;
                                case 2:
                                    eanImagenes.Lista02.Add(Item);
                                    break;
                                case 3:
                                    eanImagenes.Lista03.Add(Item);
                                    i = 0;
                                    break;
                                default: break;
                            }
                        }
                       frmReporteEan13 fre = new frmReporteEan13(eanImagenes);
                        fre.ShowDialog();
                        fre.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmProductos_Grid ~ btnImprimirCodigoBarra_Click");
            }
        }

        private void btnImaganes_Click(object sender, EventArgs e)
        {
            if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
            {
                Producto producto = this.ObtenerDatosGridProducto();
                if (producto.EsAccesorio == true || producto.id_tipoProducto == 2)
                {
                    frmProductoImagen_Grid fp = new frmProductoImagen_Grid(producto.id_producto);
                    fp.ShowDialog();
                    using (new Recursos.CursorWait())
                    {
                        this.txt_buscador.Text = "Búsqueda por nombre o familia";
                        this.CargarGridProducto("", tipoBusqueda);
                    }
                    fp.Dispose();
                }
                else
                {
                    MessageBox.Show(this, "Para subir una imagen tienes que ser un accesorio o ropa", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnConversiones_Click(object sender, EventArgs e)
        {
            if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
            {
                this.Visible = false;
                Producto producto = this.ObtenerDatosGridProducto();
                FrmConversionesIndex frm = new FrmConversionesIndex(producto.id_producto, producto.nombreProducto, producto.NombreUnidadMedida);
                frm.ShowDialog();
                frm.Dispose();
                this.Visible = true;
                this.txt_buscador.Text = "Búsqueda por nombre o familia";
                this.CargarGridProducto("", tipoBusqueda);
            }
        }
    }
}
