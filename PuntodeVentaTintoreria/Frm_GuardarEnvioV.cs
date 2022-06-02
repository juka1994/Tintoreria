using PuntodeVentaTintoreria.ClaseAux;
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

namespace PuntodeVentaTintoreria
{
    public partial class Frm_GuardarEnvioV : Form
    {
        private DataTable TablaFolioVenta;
        private Validaciones Val;
        public Frm_GuardarEnvioV()
        {
            InitializeComponent();
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

        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (this.ValidarCampos())
                    {
                        this.GuardarEnvio();
                        MessageBox.Show(this, "Informaciòn Guardada", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_GuardarEnvioV ~ btnImportar_Click");
            }
        }

        private void Frm_GuardarEnvio_Load(object sender, EventArgs e)
        {
            try
            {
                cargarcombo();
                TablaFolioVenta = new DataTable();
                TablaFolioVenta.Columns.Add("IDVenta", typeof(string));
                TablaFolioVenta.Columns.Add("Folio", typeof(string));
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_GuardarEnvio_Load ~ btn_Eliminar_Click");
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                txt_buscador.Text = "";
                this.GridviewGeneralFolio.DataSource = null;
                this.GridviewGeneralFolio.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_GuardarEnvioV ~ btn_Eliminar_Click");
            }
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.AgregarFolio(txt_buscador.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_GuardarEnvioV ~ BtnBuscar_Click");
            }
        }

        private void AgregarFolioVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    VentaProductos venta = new VentaProductos();
                    venta = ObtenerDatosGridFolio();
                    DataRow[] rows = new DataRow[0];
                    rows = TablaFolioVenta.Select("IDVenta = '" + venta.IDVenta.ToString() + "' AND Folio = '" + venta.Folio.ToString() + "'");
                    if (rows.Count() == 0)
                    {
                        TablaFolioVenta.Rows.Add(venta.IDVenta, venta.Folio);
                        this.GridViewEntregar.AutoGenerateColumns = false;
                        this.GridViewEntregar.DataSource = TablaFolioVenta;
                        if (this.GridviewGeneralFolio.CurrentRow != null)
                        {
                            int fila = this.GridviewGeneralFolio.CurrentRow.Index;
                            this.GridviewGeneralFolio.CurrentCell = null;
                            this.GridviewGeneralFolio.Rows[fila].Visible = false;
                        }
                    }
                    else
                        MessageBox.Show(this, "El folio ya esta registrado para entregar.", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_GuardarEnvioV ~ AgregarFolioVenta_Click");
            }
        }

        private void EliminarFolioEntrega_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada2()))
                {
                    if (MessageBox.Show("¿Desea eliminar este registro?", "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        DataRow myRow = (this.ObtenerFilaSeleccionada2()[0].DataBoundItem as DataRowView).Row;
                        TablaFolioVenta.Rows.Remove(myRow);
                    }
                    this.GridViewEntregar.AutoGenerateColumns = false;
                    this.GridViewEntregar.DataSource = TablaFolioVenta;
                    if (GridViewEntregar.Rows.Count > 0)
                        GridViewEntregar.Rows[0].Selected = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_GuardarEnvioV ~ EliminarFolioEntrega_Click");
            }

        }
        #endregion

        #region Metodos

        private VentaProductos ObtenerDatosGridFolio()
        {
            try
            {
                VentaProductos VentaP = new VentaProductos();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    VentaP.IDVenta = row.Cells["IDVenta"].Value.ToString();
                    VentaP.Folio = row.Cells["Folio"].Value.ToString();
                }
                return VentaP;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void cargarcombo()
        {
            try
            {
                if (Comun.ListaVehiculos != null)
               
 {
                    cmbvehiculo.DataSource = Comun.ListaVehiculos;
                    cmbvehiculo.ValueMember = "id_vehiculo";
                    cmbvehiculo.DisplayMember = "nombre";
                }

                if (Comun.ListaChoferes != null)
                {
                    cmbchofer.DataSource = Comun.ListaChoferes;
                    cmbchofer.ValueMember = "id_usuario";
                    cmbchofer.DisplayMember = "nombrecom";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se pudo cargar la información. Contacte a Soporte Técnico.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_GuardarEnvioV ~ cargarcombo()");
                this.DialogResult = DialogResult.Abort;
            }
        }

        private List<DataGridViewRow> ObtenerFilaSeleccionada()
        {
            try
            {
                List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in GridviewGeneralFolio.Rows)
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

        private List<DataGridViewRow> ObtenerFilaSeleccionada2()
        {
            try
            {
                List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in GridViewEntregar.Rows)
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

        private void AgregarFolio(string buscador)
        {
            try
            {
                VentaProductos ventaProductos = new VentaProductos();
                VentaProductosNegocio ventaProductosNegocio = new VentaProductosNegocio();
                ventaProductos.conexion = Comun.conexion;
                ventaProductos.Folio = buscador;
                ventaProductos.IDSucursal = Comun.id_sucursal;
                ventaProductosNegocio.LLenarGridBusquedaFolio(ventaProductos);
                this.GridviewGeneralFolio.AutoGenerateColumns = false;
                this.GridviewGeneralFolio.DataSource = ventaProductos.datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderìa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_GuardarEnvioV ~ AgregarFolio(string buscador)");
            }
        }

        private void GuardarEnvio()
        {
            try
            {
                EnvioNegocio envio_negocio = new EnvioNegocio();
                Envio env = new Envio();
                env.id_sucursal = Comun.id_sucursal;
                env.conexion = Comun.conexion;
                env.id_u = Comun.id_u;
                this.ObtenerDatos(env);
                envio_negocio.Guardarenvio(env, TablaFolioVenta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ObtenerDatos(Envio envios)
        {
            try
            {
                envios.id_chofer = cmbchofer.SelectedValue.ToString();
                envios.id_vehiculo = cmbvehiculo.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private bool ValidarCampos()
        {
            try
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                Val = new Validaciones();
                if (GridViewEntregar.Rows.Count == 0)
                {
                    this.txt_buscador.Focus();
                    MessageBox.Show(this, "Agregue un folio para entregar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (cmbchofer.SelectedValue.ToString() == "0")
                {
                    this.cmbchofer.Focus();
                    MessageBox.Show(this, "Seleccione un chofer", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToInt32(cmbvehiculo.SelectedValue) == 0)
                {
                    this.cmbvehiculo.Focus();
                    MessageBox.Show(this, "Seleccione un vehìculo", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #endregion
    }
}
