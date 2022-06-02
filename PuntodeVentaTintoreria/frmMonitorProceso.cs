using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Componentes;
using TintoreriaGlobal;
using TintoreriaNegocio;
using System.IO;

namespace PuntodeVentaTintoreria
{

    /*
     nota el color de fondo por tipo de entrega no es dinamco
         */
    public partial class frmMonitorProceso : Form
    {
        string claveTikect;
        int tiempoespera = 5*60;
        int contadoractual = 0;

        DataTable datosinicio =null;
        DataTable datostramite = null;

        public frmMonitorProceso()
        {
            InitializeComponent();
        }
        
        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        protected virtual void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Metodos

        private void EventoAbrir_Click(object sender, EventArgs e)
        {
            PanelProceso tipo = (PanelProceso)sender;
            this.Visible = false;
            FrmDetalleTintoteriaRopa frm = new FrmDetalleTintoteriaRopa(tipo.CveVenta,tipo.IdGrupoRopa);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                btnPrepago.PerformClick();
            }
            this.Visible = true;
        }

        #endregion

        private void frmSelSubTipoPrenda_Load(object sender, EventArgs e)
        {
            try
            {
                if (!backgroundWorker1.IsBusy)
                    backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception)
            {
                                
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Obtener Datos de Tickets
            try
            {
                tiempoespera = 5 * 60;
                contadoractual = 0;
                VentaTintoreriaNegocio neg = new VentaTintoreriaNegocio();
                datosinicio = neg.ObtenerListaProcesos(Comun.id_sucursal, 1);
                //datostramite = neg.ObtenerListaProcesos(Comun.id_sucursal, 2);
            }
            catch (Exception)
            {
                                
            }
        }

        private void CrearArticulo(DataRow datos, int posX, int posY, int index, int opcion)
        {
            try
            {
                PanelProceso icon_Creativa = new PanelProceso();
                icon_Creativa.Location = new System.Drawing.Point(posX, posY);
                icon_Creativa.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                //Datos
                icon_Creativa.CveVenta = datos["id_ventaServicio"].ToString();
                icon_Creativa.FechaEntrega = Convert.ToDateTime(datos["fechaEntrega"].ToString());
                icon_Creativa.FolioServicio = datos["folio"].ToString();
                icon_Creativa.HoraEntrega = String.Format("{0:t}", datos["horaEntrega"].ToString());
                icon_Creativa.NombreCliente = datos["nombre"].ToString();
                icon_Creativa.CantidadPrenda = Convert.ToInt32(datos["cantidadprendas"].ToString());
                icon_Creativa.Kilogramos = Convert.ToDecimal(datos["totalkilogramos"].ToString());
                icon_Creativa.IdGrupoRopa = opcion;

                icon_Creativa.TipoEntrega = Convert.ToInt32(datos["idformaEntrega"].ToString());
                icon_Creativa.TipoServicio = Convert.ToInt32(datos["id_tipoServicio"].ToString());

                //color fondo segun entrega
                //Esto debe volverse dinamico
                if (Convert.ToInt32(datos["idTipoEntrega"].ToString()) == 1)
                {
                    icon_Creativa.ColorFinal = Color.OliveDrab;
                    icon_Creativa.ColorInicial = Color.OliveDrab;
                    icon_Creativa.ColorTitulo = Color.DarkOliveGreen;
                    icon_Creativa.ColorBoder = Color.Olive;
                }
                else if (Convert.ToInt32(datos["idTipoEntrega"].ToString()) == 2)
                {
                    icon_Creativa.ColorFinal = Color.Goldenrod;
                    icon_Creativa.ColorInicial = Color.Goldenrod;
                    icon_Creativa.ColorTitulo = Color.DarkGoldenrod;
                    icon_Creativa.ColorBoder = Color.Gold;
                }
                else if (Convert.ToInt32(datos["idTipoEntrega"].ToString()) == 3)
                {
                    icon_Creativa.ColorFinal = Color.Firebrick;
                    icon_Creativa.ColorInicial = Color.Firebrick;
                    icon_Creativa.ColorTitulo = Color.DarkRed;
                    icon_Creativa.ColorBoder = Color.IndianRed;
                }
                string path2 = "";
                string path = "";

                if (icon_Creativa.TipoEntrega == 1)
                {//domicilio
                    //path = @"C:\CSL\IMG\iconos\Home.png";
                }
                else
                {//movil

                    //path = @"C:\CSL\IMG\iconos\Dom.png";
                }

                if (icon_Creativa.TipoServicio == 1)
                {//tintereria
                    //path2 = @"C:\CSL\IMG\iconos\Tin.png";
                }
                else
                {//lavanderia

                    //path2 = @"C:\CSL\IMG\iconos\Lav.png";
                }
                //iconos de registro
                icon_Creativa.Size = new System.Drawing.Size(300,250);
                icon_Creativa.TabIndex = index;
                try
                {
                    if (File.Exists(path))
                        icon_Creativa.imgTipoEntrega.Image = Image.FromFile(path);
                    
                    if (File.Exists(path2))
                        icon_Creativa.imgTipoServ.Image = Image.FromFile(path2);
                }
                catch (Exception)
                {

                }
                icon_Creativa.ArticuloClick += new EventHandler(this.EventoAbrir_Click);

                if (opcion == 1)
                    panelEspera.Controls.Add(icon_Creativa);
                //else
                //     if (opcion == 2)
                //    panelTramite.Controls.Add(icon_Creativa);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       private void DibujarDatos(DataTable datos, int opcion)
        {
            try
            {
                //lista de articos
                int posX = 5;
                int posY = 28;
                int cantidadtotal = datos.Rows.Count;

                if (opcion == 1)
                    panelEspera.Controls.Clear();
                //else
                //    if (opcion == 2)
                //    panelTramite.Controls.Clear();

                int contador = 0;
                 for (int i = 0; i < cantidadtotal; i++)
                 {
                    CrearArticulo(datos.Rows[contador], posX + (i * 306), posY , contador,opcion);
                    contador++;
                 }
            }
            catch (Exception)
            {
                               
            }    
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //Dibur los Tikets
            try
            {
                if (datosinicio != null)
                {
                    DibujarDatos(datosinicio,1);
                }
                if (datostramite != null)
                {
                    DibujarDatos(datostramite,2);
                }
            }
            catch (Exception)
            {
                                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                contadoractual++;
                int a = tiempoespera - contadoractual;

                int m = a / 60;
                int s = a % 60;
                               
                lblPrenda.Text = m.ToString("00") + ":" + s.ToString("00");

                if (tiempoespera < 0)
                {
                    tiempoespera = 5 * 60;
                    contadoractual = 1;
                    btnPrepago.PerformClick();
                }
                    
            }
            catch (Exception)
            {
                               
            }
        }

        private void btnPrepago_Click(object sender, EventArgs e)
        {
            try
            {
                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
