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
    public partial class Frm_GuardarEnvioF : Form
    {
        private Validaciones Val;
        public Frm_GuardarEnvioF()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private bool ValidarCampos()
        {
            try
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                Val = new Validaciones();
                if (listViewfolios.SelectedItems.Count == 0)
                {

                    MessageBox.Show(this, "Agregue un folio", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (listViewfolios.SelectedItems.Count > 1)
                {

                    MessageBox.Show(this, "Seleccionar ùnicamente un folio para guardar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (Convert.ToInt32(cmbvehiculo.SelectedValue) == 0)
                {

                    MessageBox.Show(this, "Seleccione un vehìculo", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (cmbchofer.SelectedValue.ToString() == "0")
                {

                    MessageBox.Show(this, "Seleccione un chofer", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void ObtenerDatos(Envio envios)
        {
            try
            {
                ListViewItem item = listViewfolios.SelectedItems[0];
                envios.folio = item.Text;
                envios.fecha_salida = this.dtp_fechaIngreso.Value;
                envios.id_chofer = cmbchofer.SelectedValue.ToString();
                envios.id_vehiculo = cmbvehiculo.SelectedValue.ToString();
                envios.hora_entrega = txthora_.Text;
                envios.idventa = textBox1.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

                envio_negocio.Guardarenvio(env);



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
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
                        MessageBox.Show(this, "Informaciòn Guardada", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "Frm_Envio ~ btnguardar_Click");
            }
        }

        private void Frm_GuardarEnvio_Load(object sender, EventArgs e)
        {
            cargarcombo();
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
                txthora_.Text = String.Format("{0:HH:mm}", DateTime.Now);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "No se pudo cargar la información. Contacte a Soporte Técnico.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmGetString_Bunifu ~ frmGetString_Bunifu()");
                this.DialogResult = DialogResult.Abort;
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
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmGridEntregas ~ txt_buscador_Click");
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
                foreach (DataRow rows in ventaProductos.datos.Rows)
                {
                    string[] row = { rows["folio"].ToString() };
                    textBox1.Text = rows["id_ventaServicio"].ToString();
                    ListViewItem listViewItem = new ListViewItem(row);
                    listViewfolios.Items.Add(listViewItem);

                    listViewfolios.Items[0].Selected = true;
                    listViewfolios.Select();
                    listViewfolios.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderìa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            txt_buscador.Text = "";
            listViewfolios.Items.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                this.AgregarFolio(txt_buscador.Text);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmGridEntrega_Grid ~ btnBuscar_Click");
            }
        }
    }
}
