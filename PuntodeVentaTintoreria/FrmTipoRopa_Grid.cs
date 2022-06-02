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
    public partial class FrmTipoRopa_Grid : Form
    {
        public FrmTipoRopa_Grid()
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
                    FrmNuevoTipoRopa Tipo = new FrmNuevoTipoRopa(ObtenerDatosGridCatTipoRopa());
                    Tipo.ShowDialog();
                    this.CargarGridTipoRopa();
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
                        this.EliminarCatTipoRopa(this.ObtenerDatosGridCatTipoRopa());
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
                FrmNuevoTipoRopa Tipo = new FrmNuevoTipoRopa(new TipoRopa());
                Tipo.ShowDialog();
                this.CargarGridTipoRopa();
                Tipo.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderìa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "FrmTipoRopa_Grid ~ btn_nuevoTipo_Click");
            }
        }

      

        #region Metodos Generales
        private TipoRopa ObtenerDatosGridCatTipoRopa()
        {
            try
            {
                TipoRopa Tipo = new TipoRopa();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    Tipo.IDTipoRopa = Convert.ToInt32(row.Cells["IDTipoRopa"].Value.ToString());
                    Tipo.Descripcion = row.Cells["Descripcion"].Value.ToString();
                }
                return Tipo;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private void CargarGridTipoRopa()
        {
            try
            {
                TipoRopaNegocio NegocioTR = new TipoRopaNegocio();
                TipoRopa TR = new TipoRopa();
                TR.Conexion = Comun.conexion;
                NegocioTR.ObtenerTipoRopa(TR);
                this.GridviewGeneral.AutoGenerateColumns = false;
                this.GridviewGeneral.DataSource = TR.TablaDatos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EliminarCatTipoRopa(Object Datos)
        {
            try
            {
                TipoRopa Tipo = (TipoRopa)Datos;
                int Verificador = 0;
                TipoRopaNegocio TipoNegocio = new TipoRopaNegocio();
                Tipo.Conexion = Comun.conexion;
                Tipo.IDUsuario = Comun.id_u;
                TipoNegocio.EliminarTipoRopa(Tipo, ref Verificador);
                if (Verificador == 1)
                {
                    this.CargarGridTipoRopa();
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

        private void FrmSucursales_Cat_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarGridTipoRopa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void BtnPrecios_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;

                FrmPrecioXTipoEntregaIndex frm = new FrmPrecioXTipoEntregaIndex(ObtenerDatosGridCatTipoRopa());
                frm.ShowDialog();
                frm.Dispose();
                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
