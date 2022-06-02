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

using System.Configuration;
using System.Drawing.Imaging;
using System.IO;
using PuntodeVentaTintoreria.ClaseAux;
using System.Management;

namespace PuntodeVentaTintoreria
{
    public partial class frm_BuscarCliente : Form
    {
        Validaciones Val;
        #region Propiedades
        private Cliente _cliente;
        public Cliente cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }
        private string _nombre = "";
        #endregion



        public frm_BuscarCliente()
        {
            try
            {
                InitializeComponent();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        public frm_BuscarCliente(string nombre)
        {
            try
            {
                InitializeComponent();
                _nombre = nombre;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBusca_Cliente ~ frmBusca_Cliente(string nombre)");
                this.DialogResult = DialogResult.Abort;
            }
        }
        
        private void frm_BuscarCliente_Load(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.ActiveControl = this.txtCliente;
                    this.txtCliente.Focus();
                    this.inicializar(_nombre);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBusca_Cliente ~ frmBuscar_Load");
                this.DialogResult = DialogResult.Abort;
            }
        }

        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /*****************************************************************************************************************************/

        #region Métodos Generales
        private void inicializar(string nombre)
        {
            try
            {
                cliente = new Cliente();
                cliente.credenciales = new Credenciales();
                ClienteNegocio cliente_negocio = new ClienteNegocio();
                this.dgv_Clientes.AutoGenerateColumns = false;
                this.dgv_Clientes.DataSource = cliente_negocio.Buscarcliente(nombre, Comun.conexion);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion
        #region Validaciones
        private void txtCliente_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloAlfaNumerico(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBusca_Cliente ~ txtCliente_KeyPress");
            }
        }
        #endregion
        #region Eventos
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBusca_Cliente ~ btnSalir_Click");
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void dgv_Clientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (e.RowIndex >= 0 && e.RowIndex < dgv_Clientes.Rows.Count)
                    {
                        if (!string.IsNullOrEmpty(dgv_Clientes.Rows[e.RowIndex].Cells["ID"].Value.ToString()))
                        {
                            cliente.id_cliente = dgv_Clientes.Rows[e.RowIndex].Cells["ID"].Value.ToString(); ;
                            cliente.nombre = dgv_Clientes.Rows[e.RowIndex].Cells["NOMBRE"].Value.ToString();
                            cliente.apePat = dgv_Clientes.Rows[e.RowIndex].Cells["apePat"].Value.ToString();
                            cliente.apeMat = dgv_Clientes.Rows[e.RowIndex].Cells["apeMat"].Value.ToString();
                            cliente.correoElectronico = dgv_Clientes.Rows[e.RowIndex].Cells["CORREO"].Value.ToString();
                            cliente.credenciales.monedero = (decimal)Convert.ToDouble(dgv_Clientes.Rows[e.RowIndex].Cells["monedero"].Value.ToString());
                            cliente.credenciales.id_codigoEab = dgv_Clientes.Rows[e.RowIndex].Cells["id_codigoEab"].Value.ToString();
                            this.DialogResult = DialogResult.OK;
                        }
                        else
                            cliente.id_cliente = string.Empty;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBusca_Cliente ~ dgv_Clientes_CellDoubleClick");
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void frm_BuscarClient_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == 27)
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBusca_Cliente ~ frmBusca_Cliente_KeyUp");
            }
        }

        private void txtCliente_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.inicializar(this.txtCliente.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmBusca_Cliente ~ txtCliente_KeyUp");
            }
        }

        #endregion

       
    }
}
