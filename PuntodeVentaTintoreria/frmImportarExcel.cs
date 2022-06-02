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
    public partial class frmImportarExcel : Form
    {
        Almacen infoAlmacen;
        public frmImportarExcel(Almacen almacen)
        {
            try
            {
                InitializeComponent();
                infoAlmacen = almacen;
                Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmImportarExcel ~ frmImportarExcel()");
            }
        }

        #region MetodosGenerales
        private void ObtenerDatosExcel()
        {
            infoAlmacen.datos = new DataTable();
            infoAlmacen.datos.Columns.Add("id_codigoEan", typeof(string));
            infoAlmacen.datos.Columns.Add("existenciaSistema", typeof(int));
            infoAlmacen.datos.Columns.Add("existenciaFisica", typeof(int));
            infoAlmacen.datos.Columns.Add("diferencia", typeof(int));
            infoAlmacen.datos.Columns.Add("id_producto", typeof(string));
            infoAlmacen.datos.Columns.Add("id_tallaRopa", typeof(int));
            infoAlmacen.datos.Columns.Add("id_colorRopa", typeof(int));
            infoAlmacen.datos.Columns.Add("id_sucursal", typeof(string));
            foreach (DataGridViewRow row in GridViewImportar.Rows)
            {
                DataGridViewCheckBoxCell check_importar = (DataGridViewCheckBoxCell)row.Cells[0];
                DataGridViewTextBoxCell codigo = (DataGridViewTextBoxCell)row.Cells[1];
                DataGridViewTextBoxCell nombre_producto = (DataGridViewTextBoxCell)row.Cells[2];
                DataGridViewTextBoxCell existenciaSistema = (DataGridViewTextBoxCell)row.Cells[3];
                DataGridViewTextBoxCell existenciaFisica = (DataGridViewTextBoxCell)row.Cells[4];
                DataGridViewTextBoxCell diferencia = (DataGridViewTextBoxCell)row.Cells[5];
                DataGridViewTextBoxCell id_producto = (DataGridViewTextBoxCell)row.Cells[6];
                DataGridViewTextBoxCell id_tallaRopa = (DataGridViewTextBoxCell)row.Cells[7];
                DataGridViewTextBoxCell id_colorRopa = (DataGridViewTextBoxCell)row.Cells[8];
                DataGridViewTextBoxCell id_sucursal = (DataGridViewTextBoxCell)row.Cells[9];
                Almacen almacen = new Almacen();
                almacen.id_codigoEan = codigo.Value.ToString();
                almacen.nombreProducto = nombre_producto.Value.ToString();
                almacen.existenciaSistema = Convert.ToInt32(existenciaSistema.Value.ToString());
                almacen.existenciaFisica = Convert.ToInt32(existenciaFisica.Value.ToString());
                almacen.diferencia = Convert.ToInt32(diferencia.Value.ToString());
                almacen.id_tallaRopa = Convert.ToInt32(id_tallaRopa.Value.ToString());
                almacen.id_colorRopa = Convert.ToInt32(id_colorRopa.Value.ToString());
                almacen.id_producto = id_producto.Value.ToString();
                almacen.id_sucursal = id_sucursal.Value.ToString();
                if (Convert.ToBoolean(check_importar.Value) == true)
                {
                    if (Convert.ToInt32(diferencia.Value.ToString()) != 0)
                    {
                        infoAlmacen.datos.Rows.Add(new Object[] {
                                almacen.id_codigoEan,
                                almacen.existenciaSistema,
                                almacen.existenciaFisica,
                                almacen.diferencia,
                                almacen.id_producto,
                                almacen.id_tallaRopa,
                                almacen.id_colorRopa,
                                almacen.id_sucursal
                            });
                    }
                    else
                        MessageBox.Show(this, "La diferencia debe ser diferente de cero", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void VerifcarMensajeAccion(int Verificador)
        {

            try
            {
                if (Verificador == 0)
                {
                    MessageBox.Show(this, "Los datos se guardaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion
        private void frmImportarExcel_Load(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.GridViewImportar.AutoGenerateColumns = false;
                    this.GridViewImportar.DataSource = infoAlmacen.importarExcel;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmImportarExcel ~ frmImportarExcel_Load");
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    int Verificador = -1;
                    AlmacenNegocio almacen_negocio = new AlmacenNegocio();
                    infoAlmacen.conexion = Comun.conexion;
                    infoAlmacen.id_u = Comun.id_u;
                    this.ObtenerDatosExcel();
                    if (infoAlmacen.datos.Rows.Count != 0)
                    {
                        almacen_negocio.ImportarExcel(infoAlmacen, ref Verificador);
                    }
                    this.VerifcarMensajeAccion(Verificador);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmImportarExcel~ btnGuardar_Click");
            }
        }
    }
}
