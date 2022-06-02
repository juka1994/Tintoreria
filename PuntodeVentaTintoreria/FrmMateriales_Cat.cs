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
    public partial class FrmMateriales_Cat : Form
    {
        public FrmMateriales_Cat()
        {
            InitializeComponent();
            Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
        }

        #region Metodos Generales
        private void EliminarCatMaterial(Object Datos)
        {
            try
            {
                Material material = (Material)Datos;
                int Verificador = 0;
                MaterialNegocio material_negocio = new MaterialNegocio();
                material.opcion = 3;
                material.conexion = Comun.conexion;
                material_negocio.AbcMaterial(material, ref Verificador);
                if (Verificador == 0)
                {
                    this.CargarGridMaterial();
                    MessageBox.Show(this, "Los datos se eliminaron correctamente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private Material ObtenerDatosGridCatMaterial()
        {
            try
            {
                Material material = new Material();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    material.id_material = Convert.ToInt32(row.Cells["id_material"].Value.ToString());
                    material.descripcion = row.Cells["descripcion"].Value.ToString();
                    material.id_u = Comun.id_u;
                }
                return material;
            }
            catch (Exception ex)
            {
                return null;

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
        #endregion

        #region eventos
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_nuevomaterial_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNuevoMaterial sucursal = new FrmNuevoMaterial(new Material());
                sucursal.ShowDialog();
                this.CargarGridMaterial();
                sucursal.Dispose();
            }
            catch (Exception ex)
            {

                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderìa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMateriales_Cat ~ btn_nuevo_Click");
            }
        }

        private void CargarGridMaterial()
        {
            try
            {
                MaterialNegocio material_negocio = new MaterialNegocio();
                Material material = new Material();
                material.conexion = Comun.conexion;
                material_negocio.llenarGridMaterial(material);
                this.GridviewGeneral.AutoGenerateColumns = false;
                this.GridviewGeneral.DataSource = material.datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void FrmMateriales_Cat_Load(object sender, EventArgs e)
        {
            try 
            {
                this.CargarGridMaterial();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderìa", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

        private void btneditar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNuevoMaterial material = new FrmNuevoMaterial(this.ObtenerDatosGridCatMaterial());
                material.ShowDialog();
                this.CargarGridMaterial();
                material.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                        this.EliminarCatMaterial(this.ObtenerDatosGridCatMaterial());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
