using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TintoreriaGlobal;
using TintoreriaNegocio;

namespace PuntodeVentaTintoreria
{
    public partial class frmProductoImagen_Grid : Form
    {
        Validaciones Val;
        public string IDProductoAux;
        int tipoBusqueda = 1;
        frm_Esperar espere = new frm_Esperar();
        public frmProductoImagen_Grid(string IdProducto)
        {
            InitializeComponent();
            IDProductoAux = IdProducto;
           
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Metodos Generales
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
        private void CargarGridProductoImg(string IDProducto)
        {
            try
            {
                ProductoImagenNegocio ImgNegocio = new ProductoImagenNegocio();
                ProductoImagen Imgproducto = new ProductoImagen();
                Imgproducto.Conexion = Comun.conexion;
                Imgproducto.IdProducto = IDProducto;
                ImgNegocio.LLenarGridProductoImg(Imgproducto);
                this.GridViewGeneral.AutoGenerateColumns = false;
                this.GridViewGeneral.DataSource = Imgproducto.TablaDatos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private ProductoImagen ObtenerDatosGrid()
        {
            try
            {
                ProductoImagen producto = new ProductoImagen();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    producto.IdImagnen = row.Cells["IDImagenes"].Value.ToString();
                    producto.IdProducto = row.Cells["IDProducto"].Value.ToString();
                    producto.UrlImagen = row.Cells["UrlImagen"].Value.ToString();
                    producto.Alt = row.Cells["Alt"].Value.ToString();
                    producto.Title = row.Cells["Title"].Value.ToString();
                    producto.NombreArc = row.Cells["NombreArc"].Value.ToString();
                    producto.TipoArc = row.Cells["TipoArc"].Value.ToString();
                    producto.Descripcion = row.Cells["Descripcion"].Value.ToString();
                }
                return producto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private void EliminarProveedor(ProductoImagen ProductoImagen)
        {
            try
            {
                int Verificador = -1;
                ProductoImagenNegocio proveedorNegocio = new ProductoImagenNegocio();
                ProductoImagen.Conexion = Comun.conexion;
                ProductoImagen.opcion = 3;
                ProductoImagen.id_u = Comun.id_u;
                proveedorNegocio.AbcProductoImg(ProductoImagen, ref Verificador);
                if (Verificador == 0)
                {
                    this.CargarGridProductoImg(this.IDProductoAux);
                    MessageBox.Show(this, "Los datos se eliminaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ProductoImagenNegocio ImgNegocio = new ProductoImagenNegocio();
                ProductoImagen Imgproducto = new ProductoImagen();
                Imgproducto.Conexion = Comun.conexion;
                Imgproducto.IdProducto = this.IDProductoAux;
                ImgNegocio.LLenarGridProductoImg(Imgproducto);
                e.Result = Imgproducto.TablaDatos;
            }
            catch (Exception ex)
            {

            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                DataTable Aux = (DataTable)e.Result;
                this.GridViewGeneral.AutoGenerateColumns = false;
                this.GridViewGeneral.DataSource = Aux;

                espere.Close();
            }
            catch (Exception ex)
            {

            }
        }
        private void frmProductoImagen_Grid_Load(object sender, EventArgs e)
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frmProductosImagenes_Nuevo fp = new frmProductosImagenes_Nuevo(this.IDProductoAux);
                fp.ShowDialog();
                using (new Recursos.CursorWait())
                {
                    this.CargarGridProductoImg(this.IDProductoAux);
                }
                fp.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    frmProductosImagenes_Nuevo fp = new frmProductosImagenes_Nuevo(this.ObtenerDatosGrid());
                    fp.ShowDialog();
                    using (new Recursos.CursorWait())
                    {
                        this.CargarGridProductoImg(this.IDProductoAux);
                    }
                    fp.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    if (MessageBox.Show("¿Desea eliminar este registro?", "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (new Recursos.CursorWait())
                        {
                            this.EliminarProveedor(this.ObtenerDatosGrid());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetalleimagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    frmProductosImagenenDetalle fp = new frmProductosImagenenDetalle(this.ObtenerDatosGrid());
                    fp.ShowDialog();
                    fp.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
