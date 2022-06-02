using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Componentes
{
    public partial class PanelProceso : UserControl
    {

        #region Event Handlers

        public event EventHandler ArticuloClick;

        #endregion

        #region Variables

        int Horas = 0;
        int Minutos = 0;
        int Segundos = 0;
        private DateTime FechaFinal;
        private DateTime FechaActual;

        #endregion

        #region Propiedades

        private Color colorBorder;
        public Color ColorBoder
        {
            get { return colorBorder; }
            set { colorBorder = value; }
        }

        private Color colorIncial;
        public Color ColorInicial
        {
            get { return colorIncial; }
            set
            {
                colorIncial = value;
                panelPrincipal.BackColor = colorIncial;
            }
        }

        private Color colorFinal;
        public Color ColorFinal
        {
            get { return colorFinal; }
            set { colorFinal = value; }
        }

        private Color colorTitulo;
        public Color ColorTitulo
        {
            get { return colorTitulo; }
            set { colorTitulo = value;
                panelTitulo.BackColor = colorTitulo;
                txtFolio.BackColor = colorTitulo;
                panelTxt.BackColor = colorTitulo;
            }
        }

        private string cveVenta;
        public string CveVenta
        {
            get { return cveVenta; }
            set { cveVenta = value; }
        }

        private int idGrupoRopa;
        public int IdGrupoRopa
        {
            get { return idGrupoRopa; }
            set { idGrupoRopa = value; }
        }

        private decimal kilogramos;
        public decimal Kilogramos
        {
            get { return kilogramos; }
            set { kilogramos = value; }
        }

        private int tipoServicio;
        public int TipoServicio
        {
            get { return tipoServicio; }
            set { tipoServicio = value;
                if (tipoServicio == 1)
                {
                    imgTipoServ.Image = Componentes.Properties.Resources.DFDomicilio;
                    ToolTipPrincipal.SetToolTip(imgTipoServ, "Servicio Tinterería");
                }
                else
                {
                    imgTipoServ.Image = Componentes.Properties.Resources.DFDomicilio;
                    ToolTipPrincipal.SetToolTip(imgTipoServ, "Servicio Lavandería");
                }
            }
        }

        private int tipoEntrega;
        public int TipoEntrega
        {
            get { return tipoEntrega; }
            set { tipoEntrega = value;
                if (tipoEntrega == 1)
                {
                    ToolTipPrincipal.SetToolTip(imgTipoEntrega, "Entrega en Sucursal");
                    imgTipoEntrega.Image = Componentes.Properties.Resources.DFSucursal;
                }
                else
                {
                    imgTipoEntrega.Image = Componentes.Properties.Resources.DFDomicilio;
                    ToolTipPrincipal.SetToolTip(imgTipoEntrega, "Entrega a Domiciolio");
                }
            }
        }

        private string nombreCliente;
        public string NombreCliente
        {
            get { return nombreCliente; }
            set { nombreCliente = value; }
        }

        private string folioServicio;
        public string FolioServicio
        {
            get { return folioServicio; }
            set { folioServicio = value; }
        }

        private DateTime fechaEntrega;
        public DateTime FechaEntrega
        {
            get { return fechaEntrega; }
            set { fechaEntrega = value; }
        }

        private string horaEntrega;
        public string HoraEntrega
        {
            get { return horaEntrega; }
            set { horaEntrega = value; }
        }

        private int cantidadPrenda;
        public int CantidadPrenda
        {
            get { return cantidadPrenda; }
            set { cantidadPrenda = value; }
        }

        #endregion

        #region Constructor

        public PanelProceso()
        {
            InitializeComponent();
            panelPrincipal.BackColor = colorIncial;
            tipoServicio = 1;
            tipoEntrega = 1;
        }

        #endregion

        #region Eventos

        private void ImgArticulo_MouseEnter(object sender, EventArgs e)
        {
            try
            {
            
                panelPrincipal.BackColor = colorFinal;

            }
            catch (Exception)
            {

            }
        }

        private void ImgArticulo_MouseHover(object sender, EventArgs e)
        {
            try
            {
                

            }
            catch (Exception)
            {

            }
        }

        private void ImgArticulo_MouseLeave(object sender, EventArgs e)
        {
            try
            {
             
                panelPrincipal.BackColor = colorIncial;
                ToolTipPrincipal.Hide(this);

            }
            catch (Exception)
            {

            }
        }

        private void ImgArticulo_Click(object sender, EventArgs e)
        {
            if (this.ArticuloClick != null)
                this.ArticuloClick(this, e);
        }

        private void PanelPrincipal_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics, p.DisplayRectangle, colorBorder, ButtonBorderStyle.Solid);
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            double segundostotal = 0;
            FechaActual = DateTime.Now;
            segundostotal = FechaFinal.Subtract(FechaActual).TotalSeconds;
            if (segundostotal > 0)
            {

                Minutos = (int)segundostotal / 60;
                Segundos = (int)segundostotal % 60;
                Horas = Minutos / 60;
                Minutos = Minutos % 60;

            }
            else
            {
                Minutos = 0;
                Segundos = 0;
                Horas = 0;
            }
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //if (!backgroundWorker1.IsBusy)
                  //  backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception)
            {


            }
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                txtHora.Text = Horas.ToString("00") + ":" + Minutos.ToString("00") + ":" + Segundos.ToString("00");

            }
            catch (Exception)
            {


            }

        }

        #endregion

        #region Constructor

        private void Articulo_Load(object sender, EventArgs e)
        {
            FechaFinal = Convert.ToDateTime(fechaEntrega.Day + "/" + fechaEntrega.Month + "/" + fechaEntrega.Year + " " + horaEntrega + ":00");
            FechaActual = DateTime.Now;
            txtNombre.Text = nombreCliente;
            txtFolio.Text = folioServicio;
            txtFecha.Text = fechaEntrega.ToShortDateString() + "-" + horaEntrega;
            txtCantidad.Text = "#"+cantidadPrenda.ToString();
           // timer1.Enabled = true;
        }

        #endregion
    
    }
}
