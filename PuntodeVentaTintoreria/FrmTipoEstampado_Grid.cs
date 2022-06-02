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
    public partial class FrmTipoEstampado_Grid : Form
    {
        public FrmTipoEstampado_Grid()
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
                    FrmNuevoTipoEstampado Tipo = new FrmNuevoTipoEstampado(ObtenerDatosGridCatTipoEstampado());
                    Tipo.ShowDialog();
                    this.CargarGridEstampado();
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
                        this.Eliminar(this.ObtenerDatosGridCatTipoEstampado());
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
                FrmNuevoTipoEstampado Tipo = new FrmNuevoTipoEstampado(new TipoEstampado());
                Tipo.ShowDialog();
                this.CargarGridEstampado();
                Tipo.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderìa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmTipoRopa_Grid ~ btn_nuevoTipo_Click");
            }
        }



        #region Metodos Generales
        private TipoEstampado ObtenerDatosGridCatTipoEstampado()
        {
            try
            {
                TipoEstampado Tipo = new TipoEstampado();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    Tipo.IDEstampado = Convert.ToInt32(row.Cells["IDEstampado"].Value.ToString());
                    Tipo.Descripcion = row.Cells["Descripcion"].Value.ToString();
                }
                return Tipo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private void CargarGridEstampado()
        {
            try
            {
                TipoEstampadoNegocio NegocioE = new TipoEstampadoNegocio();
                TipoEstampado TE = new TipoEstampado();
                TE.Conexion = Comun.conexion;
                NegocioE.ObtenerTipoEstampado(TE);
                this.GridviewGeneral.AutoGenerateColumns = false;
                this.GridviewGeneral.DataSource = TE.TablaDatos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Eliminar(Object Datos)
        {
            try
            {
                TipoEstampado Tipo = (TipoEstampado)Datos;
                int Verificador = 0;
                TipoEstampadoNegocio TipoNegocio = new TipoEstampadoNegocio();
                Tipo.Conexion = Comun.conexion;
                Tipo.IDUsuario = Comun.id_u;
                TipoNegocio.EliminarEstampado(Tipo, ref Verificador);
                if (Verificador == 1)
                {
                    this.CargarGridEstampado();
                    MessageBox.Show(this, "Los datos se eliminaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Verificador == 0)
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

        private void FrmTipoEstampado_Cat_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarGridEstampado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
