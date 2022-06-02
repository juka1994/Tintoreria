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
    public partial class FrmMarca_Cat : Form
    {
        public FrmMarca_Cat()
        {
            InitializeComponent();
            Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
        }
        #region Metodos Generales
        private void Eliminar(Object Datos)
        {
            try
            {
                Marca oModelo = (Marca)Datos;
                int Verificador = -1;
                MarcaNegocio oNegocio = new MarcaNegocio();
                oModelo.opcion = 3;
                oModelo.conexion = Comun.conexion;
                oNegocio.AbcMarca(oModelo, ref Verificador);
                if (Verificador == 0)
                {
                    this.CargarGrid();
                    MessageBox.Show(this, "Los datos se eliminaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show(this, "No se permite la eliminación de este registro", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private Marca ObtenerDatosGrid ()
        {
            try
            {
                Marca oModelo = new Marca();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    oModelo.id_marca = Convert.ToInt32(row.Cells["id_marca"].Value.ToString());
                    oModelo.descripcion = row.Cells["descripcion"].Value.ToString();
                    oModelo.id_u = Comun.id_u;
                }
                return oModelo;
            }
            catch (Exception ex)
            {
                return null;

            }
        }
        private void CargarGrid()
        {
            try
            {
                MarcaNegocio oNegocio = new MarcaNegocio();
                Marca oModelo = new Marca();
                oModelo.conexion = Comun.conexion;
                oNegocio.llenarGridMarca(oModelo);
                this.GridviewGeneral.AutoGenerateColumns = false;
                this.GridviewGeneral.DataSource = oModelo.datos;
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
        #endregion
        private void FrmMarca_Cat_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarGrid();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_nuevo_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNueva_Marca_Cat frmNuevo = new FrmNueva_Marca_Cat(new Marca());
                frmNuevo.ShowDialog();
                this.CargarGrid();
                frmNuevo.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmMotivo_Grid ~ btn_nuevo_Click");
            }
        }

        private void btneditar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNueva_Marca_Cat frm = new FrmNueva_Marca_Cat(this.ObtenerDatosGrid());
                frm.ShowDialog();
                this.CargarGrid();
                frm.Dispose();
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
                        this.Eliminar(this.ObtenerDatosGrid());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
