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
    public partial class frm_NuevoGrupo : Form
    {
        private Grupo infoGrupo;
        public frm_NuevoGrupo(Grupo _grupo)
        {
            InitializeComponent();
            infoGrupo = _grupo;
        }
        private void frm_NuevoGrupo_Load(object sender, EventArgs e)
        {
            try
            {
                this.obtenerDatos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Metodos
        private void GuardarGrupo()
        {
            try
            {
                int verificador = -1;
                Grupo _grupo = new Grupo();
                this.obtenerDatos(_grupo);
                GrupoNegocio _grupoNeg = new GrupoNegocio();
                if (_grupo.id_Grupo != 0)
                {
                    _grupo.opcion = 2;
                    _grupoNeg.ABC_Grupo(_grupo, ref verificador);
                }
                else
                {
                    _grupo.opcion = 1;
                    _grupoNeg.ABC_Grupo(_grupo, ref verificador);
                }

                if (verificador == 0)
                {
                    MessageBox.Show(this, "Los datos se guardaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void obtenerDatos()
        {
            try
            {
                txt_Descripcion.Text = infoGrupo.Descripcion;
                check_cobrar.Checked = infoGrupo.cobrarLavanderia;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void obtenerDatos(Grupo _dato)
        {
            try
            {
                _dato.id_Grupo = infoGrupo.id_Grupo;
                _dato.Descripcion = txt_Descripcion.Text;
                _dato.cobrarLavanderia = check_cobrar.Checked;
                _dato.esSistema = infoGrupo.esSistema;
                _dato.id_user = Comun.id_u;
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
                if (this.txt_Descripcion.Text == string.Empty)
                {
                    this.txt_Descripcion.Focus();
                    MessageBox.Show(this, "Escriba la descripcion", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }                
                return true;
            }
            catch (Exception)
            {
                return false;
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

        private void btn_Regresar_Click(object sender, EventArgs e)
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

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (this.ValidarCampos())
                    {
                        this.GuardarGrupo();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        
    }
}
