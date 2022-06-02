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
    public partial class FrmConfiguracion : Form
    {
        private Validaciones Val;

        public FrmConfiguracion()
        {
            InitializeComponent();
        }
        #region Validaciones
        
        #endregion

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.Guardar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            try
            {
                using (new Recursos.CursorWait())
                {
                    this.Inicializar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Metodos Generales
        private void Inicializar()
        {
            try
            {
                Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
                string impresoraActual = Comun.namePrinter;

                foreach (string printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    cmbImpresoras.Items.Add(printer);
                }

                cmbImpresoras.SelectedText = impresoraActual;
                if (cmbImpresoras.SelectedIndex == -1)
                {
                    cmbImpresoras.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
     
        private void Guardar()
        {
            try
            {
                Equipo oEquipo = new Equipo();
                oEquipo.id_equipo = Comun.id_equipo;
                oEquipo.namePrinter = cmbImpresoras.SelectedItem.ToString();

                TicketNegocio oNegocio = new TicketNegocio();
                RespuestaSQL respuesta = oNegocio.Configuracion_ac_Configuracion(oEquipo, 2);

                MessageBox.Show(this, respuesta.Mensaje, "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, respuesta.Success ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                if (respuesta.Success)
                {
                    Comun.namePrinter = oEquipo.namePrinter;
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
       
        private void VerificarMensajeAccion(int Verificador)
        {

            try
            {
                if (Verificador == 0)
                {
                    MessageBox.Show(this, "Los datos se guardaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                    MessageBox.Show(this, "No se permite la modificación de este registro", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
