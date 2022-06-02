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
    public partial class frmAArticuloBodega : Form
    {
        private Bodega infoBodega;
        private Validaciones Val;
        public frmAArticuloBodega(Bodega bodega)
        {
            try
            {
                Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
                InitializeComponent();
                infoBodega = bodega;

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAArticuloBodega ~ frmAArticuloBodega_Bunifu()");
            }
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    if (this.ValidarCampos())
                    {
                        this.GuadarCatBodega();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAArticuloBodega ~ btnGuardar_Click");
            }

        }

        #region Metodos Generales        
        private void GuadarCatBodega()
        {
            try
            {
                int Verificador = 0;
                Bodega bodega = new Bodega();
                BodegaNegocio Bodega_Negocio = new BodegaNegocio();
                this.ObtenerDatos(ref bodega);
                if (bodega.cantidad <= infoBodega.cantidad)
                {
                    Bodega_Negocio.AbcBodega(bodega, ref Verificador);
                    this.VerifcarMensajeAccion(Verificador);
                }
                else
                    MessageBox.Show(this, "Mayor que la cantidad en bodega", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAArticuloBodega_Bunifu ~ GuadarCatBodega");
            }
        }
        private void ObtenerDatos(ref Bodega bodega)
        {
            try
            {
                bodega.id_producto = infoBodega.id_producto;
                bodega.id_sucursal = infoBodega.id_sucursal;
                bodega.id_colorRopa = infoBodega.id_colorRopa;
                bodega.id_tallaRopa = infoBodega.id_tallaRopa;
                bodega.opcion = infoBodega.opcion;
                bodega.cantidad = Convert.ToInt32(this.txt_cantidad.Text);
                bodega.id_u = Comun.id_u;
                bodega.conexion = Comun.conexion;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidarCampos()
        {
            Validaciones Val = new Validaciones();
            try
            {
                if (this.txt_cantidad.Text.Length == 0)
                {
                    this.txt_cantidad.Focus();
                    MessageBox.Show(this, "Escriba la cantidad correspondiente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void VerifcarMensajeAccion(int Verificador)
        {

            try
            {
                if (Verificador == 0)
                {
                    MessageBox.Show(this, "Los datos se guardaron correctamente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region Validaciones
        private void txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                Val = new Validaciones();
                Val.SoloNumerico(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_cantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_cantidad_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        #endregion
        private void frmAArticuloBodega_Load(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    txt_nombreProducto.Text = infoBodega.nombreProducto;
                    txt_cantidadActual.Text = infoBodega.cantidad.ToString();
                    this.ActiveControl = this.txt_cantidad;
                    this.txt_cantidad.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmAArticuloBodega~ frmAArticuloBodega_Load");
            }
        }

        private void txt_cantidad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
