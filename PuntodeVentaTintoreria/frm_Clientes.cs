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
using System.Globalization;

namespace PuntodeVentaTintoreria
{
    public partial class frm_Clientes : Form
    {

        Validaciones Val;
        int tipoBusqueda = 1;
        frm_Esperar espere = new frm_Esperar();
        public frm_Clientes()
        {
            try
            {
                InitializeComponent();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmClientes");
            }
        }
        
      

        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        

        /************************************************************************************************************************************/


        


        private void frm_Clientes_Load(object sender, EventArgs e)
        {
            try
            {
                backgroundWorker1.RunWorkerAsync();
                espere.ShowDialog();
                this.LlenarGridCliente("",tipoBusqueda);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmClientes_Grid ~ frmClientes_Grid_Load");
            }
        }



        #region Metodos Generales
        private List<DataGridViewRow> ObtenerFilaSeleccionada()
        {
            try
            {
                List<DataGridViewRow> rowSelected = new List<DataGridViewRow>();
                foreach (DataGridViewRow row in GridViewGeneral.Rows)
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
        //private void CargarGridCliente(string busqueda, int tipoBusqueda)
        //{
        //    try
        //    {
        //        ClienteNegocio clienteNegocio = new ClienteNegocio();
        //        Cliente cliente = new Cliente();
        //        cliente.conexion = Comun.conexion;
        //        cliente.busqueda = busqueda;
        //        cliente.tipoBusqueda = tipoBusqueda;
        //        clienteNegocio.LLenarGridCliente(cliente);
        //        this.GridViewGeneral.AutoGenerateColumns = false;
        //        this.GridViewGeneral.DataSource = cliente.datos;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

        //    }
        //}
        private void LlenarGridCliente(string busqueda, int tipoBusqueda)
        {
            try
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                Cliente cliente = new Cliente();
                cliente.busqueda = busqueda;
                cliente.tipoBusqueda = tipoBusqueda;
                clienteNegocio.LLenarGridClientes(cliente);
                this.GridViewGeneral.AutoGenerateColumns = false;
                this.GridViewGeneral.DataSource = cliente.datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private Cliente ObtenerDatosGridCliente()
        {
            try
            {
                Cliente cliente = new Cliente();
                foreach (DataGridViewRow row in this.ObtenerFilaSeleccionada())
                {
                    cliente.id_cliente = row.Cells["id_cliente"].Value.ToString();
                    cliente.nombreCompleto = row.Cells["nombreCompleto"].Value.ToString();
                    cliente.nombre = row.Cells["nombre"].Value.ToString();
                    cliente.apePat = row.Cells["apellidopat"].Value.ToString();
                    cliente.apeMat = row.Cells["apMaterno"].Value.ToString();
                    cliente.correoElectronico = row.Cells["correoElectronico"].Value.ToString();
                    cliente.id_pais = Convert.ToInt32(row.Cells["id_pais"].Value.ToString());
                    cliente.id_estado = Convert.ToInt32(row.Cells["id_estado"].Value.ToString());
                    cliente.id_municipio = Convert.ToInt32(row.Cells["id_municipio"].Value.ToString());
                    cliente.fechaNacimiento = Convert.ToDateTime(row.Cells["fechaNacimiento"].Value.ToString());
                    cliente.colonia = row.Cells["colonia"].Value.ToString();
                    cliente.descripcion = row.Cells["membresia"].Value.ToString();
                    cliente.id_tipoCredencial =Convert.ToInt32(row.Cells["id_TipoCredencial"].Value.ToString());
                    cliente.id_genero = Convert.ToInt32(row.Cells["id_genero"].Value.ToString());
                    cliente.telefono = row.Cells["telefono"].Value.ToString();
                    cliente.curp = row.Cells["curp"].Value.ToString();
                    cliente.monedero =Convert.ToDecimal(row.Cells["monedero"].Value.ToString());
                    cliente.direccion = row.Cells["direccion"].Value.ToString();
                    cliente.fechaInicio = DateTime.Now;
                    cliente.solicitado = true;
                    cliente.entregado = true;
                }
                return cliente;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private void EliminarCliente(Cliente cliente)
        {
            try
            {
                int Verificador = -1;
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                cliente.conexion = Comun.conexion;
                cliente.opcion = 3;
                cliente.id_u = Comun.id_u;
                clienteNegocio.AbcCliente(cliente, ref Verificador);
                if (Verificador == 0)
                {
                    this.txt_buscador.Text = "Búsqueda por código o nombre";
                    //this.CargarGridCliente("", tipoBusqueda);
                    this.LlenarGridCliente("",tipoBusqueda);
                    MessageBox.Show(this, "Los datos se eliminaron correctamente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion
        #region Validaciones
        private void txt_buscador_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.TextoNumerosPuntoGuionTilde(e);

                if (e.KeyChar == 13)
                {
                    this.btnBuscar_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmClientes_Grid ~ txt_buscador_KeyPress");
            }
        }

        private void txt_buscador_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_buscador_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion
        #region Eventos

        private void txt_buscador_Click(object sender, EventArgs e)
        {
            try
            {
                this.txt_buscador.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    //this.CargarGridCliente(this.txt_buscador.Text, tipoBusqueda);
                    this.LlenarGridCliente(this.txt_buscador.Text, tipoBusqueda);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmClientes_Grid ~ btnBuscar_Click");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.txt_buscador.Text = "Búsqueda por código o nombre";
                    //this.CargarGridCliente("", tipoBusqueda);
                    this.LlenarGridCliente("",tipoBusqueda);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmClientes_Grid ~ btnCancelar_Click");
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                frm_ClienteNuevo fc = new frm_ClienteNuevo(new Cliente());
                fc.ShowDialog();
                using (new Recursos.CursorWait())
                {
                    this.txt_buscador.Text = "Búsqueda por nombre";
                    //this.CargarGridCliente("", tipoBusqueda);
                    this.LlenarGridCliente("",tipoBusqueda);
                }
                fc.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmClientes_Grid ~ btnNuevo_Click");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    frm_ClienteNuevo fc = new frm_ClienteNuevo(this.ObtenerDatosGridCliente());
                    fc.ShowDialog();
                    using (new Recursos.CursorWait())
                    {
                        this.txt_buscador.Text = "Búsqueda por nombre";
                        //this.CargarGridCliente("", tipoBusqueda);
                        this.LlenarGridCliente("", tipoBusqueda);

                    }
                    fc.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmClientes_Grid ~ btnModificar_Click");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidarFilaSeleccionada(this.ObtenerFilaSeleccionada()))
                {
                    if (MessageBox.Show("¿Desea eliminar este registro?", "Eliminar Registro", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (new Recursos.CursorWait())
                        {
                            this.EliminarCliente(this.ObtenerDatosGridCliente());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmClientes_Grid ~ btnEliminar_Click");
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmClientes_Grid ~ btnCerrar_Click");
            }
        }
        #endregion

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                Cliente cliente = new Cliente();
                cliente.conexion = Comun.conexion;
                cliente.busqueda = "";
                cliente.tipoBusqueda = tipoBusqueda;
                clienteNegocio.LLenarGridCliente(cliente);
                e.Result = cliente.datos;
            }
            catch (Exception ex)
            {

            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                DataTable Aux = (DataTable)e.Result;
                this.GridViewGeneral.AutoGenerateColumns = false;
                this.GridViewGeneral.DataSource = Aux;
                espere.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    this.btnBuscar_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmLogin_Bunifu ~ btnBuscar_KeyPress");
            }
        }
    }
}
