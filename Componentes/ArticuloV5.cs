using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Componentes
{
    public partial class ArticuloV5 : UserControl
    {

       
        public event EventHandler ArticuloClick;
       


        private Color colorBorder;

        public Color _colorBoder
        {
            get { return colorBorder; }
            set { colorBorder = value; }
        }

        private Color colorIncial;

        public Color _colorInicial
        {
            get { return colorIncial; }
            set { colorIncial = value; }
        }

        private Color colorFinal;

        public Color _colorFinal
        {
            get { return colorFinal; }
            set { colorFinal = value; }
        }


        private string cveArticulo;


        public string _cveArticulo
        {
            get { return cveArticulo; }
            set { cveArticulo = value; }
        }

        private int idGrupoRopa;

        public int _idGrupoRopa
        {
            get { return idGrupoRopa; }
            set { idGrupoRopa = value; }
        }

        private int  tipoArticulo;

        public int  _tipoArticulo
        {
            get { return tipoArticulo; }
            set { tipoArticulo = value; }
        }

        private string nombreArticulo;

        public string _nombreArticulo
        {
            get { return nombreArticulo; }
            set { nombreArticulo = value; }
        }


        private Dictionary<int,decimal> listaPrecios;

        public Dictionary<int,decimal> _listaPrecios
        {
            get { return listaPrecios; }
            set { listaPrecios = value; }
        }

        private DataTable listaSubarticulos;

        public DataTable _listaSubArticulos
        {
            get { return listaSubarticulos; }
            set { listaSubarticulos = value; }
        }


        public ArticuloV5()
        {
            InitializeComponent();
            panelPrincipal.BackColor = colorIncial;
            
        }

        
        

        private void imgArticulo_MouseEnter(object sender, EventArgs e)
        {
            try
            {
            
                panelPrincipal.BackColor = colorFinal;

            }
            catch (Exception)
            {

            }
        }

        private void imgArticulo_MouseHover(object sender, EventArgs e)
        {
            try
            {
                

            }
            catch (Exception)
            {

            }
        }

        private void imgArticulo_MouseLeave(object sender, EventArgs e)
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

                

        private void imgArticulo_Click(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (this.ArticuloClick != null)
                this.ArticuloClick(this, e);
        }

        private void panelPrincipal_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            ControlPaint.DrawBorder(e.Graphics, p.DisplayRectangle, colorBorder, ButtonBorderStyle.Solid);
        }

        private void Articulo_Load(object sender, EventArgs e)
        {
            ToolTipPrincipal.SetToolTip(imgArticulo, nombreArticulo);
            lblNombre.Text = nombreArticulo;
            colorBorder = Color.MediumTurquoise;
            colorFinal = Color.PaleTurquoise;
            colorIncial = Color.LightGray;
        }
    }
}
