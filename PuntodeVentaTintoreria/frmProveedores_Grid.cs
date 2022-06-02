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
    public partial class frmProveedores_Grid : Form
    {
        Validaciones Val;
        int tipoBusqueda = 1;
        frm_Esperar espere = new frm_Esperar();
        public frmProveedores_Grid()
        {
            InitializeComponent();
            Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlBotones_Paint(object sender, PaintEventArgs e)
        {

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
                    MessageBox.Show(this, "Debe seleccionar una fila del grid", "Sistema Punto de Venta Lavaneria", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void CargarGridProveedor(string busqueda, int tipoBusqueda)
        {
            try
            {
                ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
                Proveedor proveedor = new Proveedor();
                proveedor.conexion = Comun.conexion;
                proveedor.busqueda = busqueda;
                proveedor.tipoBusqueda = tipoBusqueda;
                proveedorNegocio.LLenarGridProveedor(proveedor);
                this.GridViewGeneral.AutoGenerateColumns = false;
                this.GridViewGeneral.DataSource = proveedor.datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private Proveedor ObtenerDatosGridProveedor()
        {
            try
            {
                Proveedor proveedor = new Proveedor();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    proveedor.id_proveedor = row.Cells["id_proveedor"].Value.ToString();
                    proveedor.proveedor = row.Cells["proveedor"].Value.ToString();
                    proveedor.direccion = row.Cells["direccion"].Value.ToString();
                    proveedor.telefono = row.Cells["telefono"].Value.ToString();
                    proveedor.contacto = row.Cells["contacto"].Value.ToString();
                    proveedor.correo = row.Cells["correo"].Value.ToString();
                    proveedor.sendMail = Convert.ToBoolean(row.Cells["SENMAIL"].Value.ToString());
                    proveedor.user = row.Cells["user"].Value.ToString();
                }
                return proveedor;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private void EliminarProveedor(Proveedor proveedor)
        {
            try
            {
                int Verificador = -1;
                ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
                proveedor.conexion = Comun.conexion;
                proveedor.opcion = 3;
                proveedor.id_u = Comun.id_u;
                proveedorNegocio.AbcProveedor(proveedor, ref Verificador);
                if (Verificador == 0)
                {
                    this.txt_buscador.Text = "";
                    this.CargarGridProveedor("", tipoBusqueda);
                    MessageBox.Show(this, "Los datos se eliminaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
        #endregion


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ProveedorNegocio proveedorNegocio = new ProveedorNegocio();
                Proveedor proveedor = new Proveedor();
                proveedor.conexion = Comun.conexion;
                proveedor.busqueda = "";
                proveedor.tipoBusqueda = tipoBusqueda;
                proveedorNegocio.LLenarGridProveedor(proveedor);
                e.Result = proveedor.datos;
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
        private void frmProveedores_Grid_Load(object sender, EventArgs e)
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

        private void button2ñ_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.CargarGridProveedor(this.txt_buscador.Text, tipoBusqueda);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.txt_buscador.Text = "Búsqueda por nombre o contacto";
                    this.CargarGridProveedor("", tipoBusqueda);
                }
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
                frmProveedores fp = new frmProveedores(new Proveedor());
                fp.ShowDialog();
                using (new Recursos.CursorWait())
                {
                    this.txt_buscador.Text = "Búsqueda por nombre o contacto";
                    this.CargarGridProveedor("", tipoBusqueda);
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
                    frmProveedores fp = new frmProveedores(this.ObtenerDatosGridProveedor());
                    fp.ShowDialog();
                    using (new Recursos.CursorWait())
                    {
                        this.txt_buscador.Text = "Búsqueda por nombre o contacto";
                        this.CargarGridProveedor("", tipoBusqueda);
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
                            this.EliminarProveedor(this.ObtenerDatosGridProveedor());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
