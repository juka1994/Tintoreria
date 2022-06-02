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
    public partial class FrmEquipo_Grid : Form
    {
        public FrmEquipo_Grid()
        {
            InitializeComponent();
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
                    FrmNuevo_Equipo Tipo = new FrmNuevo_Equipo(ObtenerDatosGridCatEquipo());
                    Tipo.ShowDialog();
                    this.CargarGridEquipo();
                    Tipo.Dispose();
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
                        this.EliminarCatEquipo(this.ObtenerDatosGridCatEquipo());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_nuevoTipo_Click(object sender, EventArgs e)
        {
            try
            {
                FrmNuevo_Equipo Tipo = new FrmNuevo_Equipo(new Equipo());
                Tipo.ShowDialog();
                this.CargarGridEquipo();
                Tipo.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderìa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmTipoRopa_Grid ~ btn_nuevoTipo_Click");
            }
        }

      

        #region Metodos Generales
        private Equipo ObtenerDatosGridCatEquipo()
        {
            try
            {
                Equipo Tipo = new Equipo();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    Tipo.id_equipo = row.Cells["IDEquipo"].Value.ToString();
                    Tipo.descripcion = row.Cells["Nombre"].Value.ToString();
                    Tipo.id_sucursal = row.Cells["IDSucursal"].Value.ToString();
                    Tipo.namePrinter = row.Cells["NamePrinter"].Value.ToString();
                }
                return Tipo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private void CargarGridEquipo()
        {
            try
            {
                EquipoNegocio NegocioE = new EquipoNegocio();
                Equipo E = new Equipo();
                E.conexion = Comun.conexion;
                NegocioE.llenarGridEquipo(E);
                this.GridviewGeneral.AutoGenerateColumns = false;
                this.GridviewGeneral.DataSource = E.datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EliminarCatEquipo(Object Datos)
        {
            try
            {
                Equipo Tipo = (Equipo)Datos;
                int Verificador = 0;
                EquipoNegocio TipoNegocio = new EquipoNegocio();
                Tipo.conexion = Comun.conexion;
                Tipo.id_u = Comun.id_u;
                Tipo.opcion = 3;
                TipoNegocio.AbcEquipo(Tipo, ref Verificador);
                if (Verificador == 1)
                {
                    MessageBox.Show(this, "Este registro no se puede eliminar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Verificador == 0)
                {
                    this.CargarGridEquipo();
                    MessageBox.Show(this, "Los datos se eliminaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void FrmEquipo_Cat_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarGridEquipo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
