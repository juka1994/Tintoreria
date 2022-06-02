using PuntodeVentaTintoreria.ClaseAux;
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
    public partial class FrmSucursales_Cat : Form
    {
        public FrmSucursales_Cat()
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

        private void btneditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    FrmNueva_Sucursal sucursal = new FrmNueva_Sucursal(this.ObtenerDatosGridCatSucursal());
                    sucursal.ShowDialog();
                    this.CargarGridSucursal();
                    sucursal.Dispose();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    if (MessageBox.Show("¿Desea eliminar este Registro?", "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        this.EliminarCatSucursal(this.ObtenerDatosGridCatSucursal());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_nuevasucursal_Click(object sender, EventArgs e)
        {
            try
            {
               FrmNueva_Sucursal sucursal = new FrmNueva_Sucursal(new Sucursal());
                sucursal.ShowDialog();
                this.CargarGridSucursal();
                sucursal.Dispose();
            }
            catch (Exception ex)
            {

                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderìa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmSucursales ~ btn_nuevo_Click");
            }
        }

      

        #region Metodos Generales
        private Sucursal ObtenerDatosGridCatSucursal()
        {
            try
            {
                Sucursal sucursal = new Sucursal();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    sucursal.id_sucursal = row.Cells["id_sucursal"].Value.ToString();
                    sucursal.id_tipoSucursal = Convert.ToInt32(row.Cells["id_tipoSucursal"].Value.ToString());
                    sucursal.nombre = row.Cells["nombre"].Value.ToString();
                    sucursal.direccion = row.Cells["direccion"].Value.ToString();
                    sucursal.telefono = row.Cells["telefono"].Value.ToString();
                    sucursal.codigoPostal = row.Cells["codigoPostal"].Value.ToString();
                    sucursal.id_pais = Convert.ToInt32(row.Cells["id_pais"].Value.ToString());
                    sucursal.id_estado = Convert.ToInt32(row.Cells["id_estado"].Value.ToString());
                    sucursal.id_municipio = Convert.ToInt32(row.Cells["id_municipio"].Value.ToString());
                    sucursal.id_iva = Convert.ToInt32(row.Cells["id_iva"].Value.ToString());
                    sucursal.id_u = Comun.id_u;
                }
                return sucursal;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private void CargarGridSucursal()
        {
            try
            {
                SucursalNegocio sucursal_negocio = new SucursalNegocio();
                Sucursal sucursal = new Sucursal();
                sucursal.conexion = Comun.conexion;
                sucursal_negocio.llenarGridSucursal(sucursal);
                this.GridviewGeneral.AutoGenerateColumns = false;
                this.GridviewGeneral.DataSource = sucursal.datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void EliminarCatSucursal(Object Datos)
        {
            try
            {
                Sucursal sucursal = (Sucursal)Datos;
                int Verificador = 0;
                SucursalNegocio sucursal_negocio = new SucursalNegocio();
                sucursal.opcion = 3;
                sucursal.conexion = Comun.conexion;
                sucursal_negocio.AbcSucursal(sucursal, ref Verificador);
                if (Verificador == 0)
                {
                    this.CargarGridSucursal();
                    MessageBox.Show(this, "Los datos se eliminaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Verificador == 1)
                {
                    MessageBox.Show(this, "Este registro no se puede eliminar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

        private void FrmSucursales_Cat_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarGridSucursal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion
    }
}
