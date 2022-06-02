using System;
using TintoreriaGlobal;
using TintoreriaNegocio;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuntodeVentaTintoreria
{
    public partial class frm_GrupGrid : Form
    {
        public frm_GrupGrid()
        {
            InitializeComponent();
        }

        private void frm_GrupGrid_Load(object sender, EventArgs e)
        {
            try
            {
                this.CargarDatosGridGrupo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #region Metodos
        private void CargarDatosGridGrupo()
        {
            try
            {
                Grupo _grupo = new Grupo();
                _grupo.id_user = Comun.id_u;
                GrupoNegocio _grupoNeg = new GrupoNegocio();
                _grupoNeg.LlennarDatosGridGrupo(_grupo);
                this.GridviewGeneral.AutoGenerateColumns = false;
                this.GridviewGeneral.DataSource = _grupo.datosTabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarFilaSeleccionada(List<DataGridViewRow> rowSelected)
        {
            try
            {
                if (rowSelected.Count == 0)
                {
                    MessageBox.Show("Debe seleccionar una fila del grid", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
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
            catch (Exception)
            {
                return null;
            }
        }

        public Grupo ObtenerDatosGrid()
        {
            try
            {
                Grupo _grupo = new Grupo();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    _grupo.id_Grupo =Convert.ToInt32(row.Cells["id_Grupo"].Value.ToString());
                    _grupo.Descripcion = row.Cells["descripcion"].Value.ToString();
                    string value = row.Cells["cobraLavanderia"].Value.ToString();
                    _grupo.cobrarLavanderia = (value.Equals("SI") ? true : false);                  
                    _grupo.esSistema = Convert.ToBoolean(row.Cells["esSistema"].Value.ToString());
                }
               return _grupo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void EliminarCatGrupo(object grupo)
        {
            try
            {
                Grupo _group = (Grupo)grupo;
                int Verificador = -1;
                GrupoNegocio _vehNegocio = new GrupoNegocio();                
                _group.id_user = Comun.id_u;
                _group.opcion = 3;
                _vehNegocio.ABC_Grupo(_group, ref Verificador);

                if (Verificador == 1)
                {
                    this.CargarDatosGridGrupo();
                    MessageBox.Show("Los datos se eliminaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (Verificador == 0)
                {
                    MessageBox.Show(this, "Este registro no se puede eliminar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Eventos
        private void btnSalir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            try
            {
                WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_nuevoVehiculo_Click(object sender, EventArgs e)
        {
            try
            {
                frm_NuevoGrupo _newGroup = new frm_NuevoGrupo(new Grupo());
                _newGroup.ShowDialog();
                this.CargarDatosGridGrupo();
                _newGroup.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            try
            {               
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    try
                    {
                        frm_NuevoGrupo _newGroup = new frm_NuevoGrupo(this.ObtenerDatosGrid());

                        if (ObtenerDatosGrid().esSistema != true)
                        {
                            _newGroup.ShowDialog();
                            this.CargarDatosGridGrupo();
                            _newGroup.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("No puede modificar el registro del sistema", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                                                     
                }
                  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    try
                    {
                        if (this.ObtenerDatosGrid().esSistema != true )
                        {
                            if (MessageBox.Show("¿Desea eliminar este Registro?", "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                this.EliminarCatGrupo(this.ObtenerDatosGrid());
                            }
                        }
                        else
                        {
                            MessageBox.Show("No puede eliminar el registro del sistema", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                         MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
     
    }
}
