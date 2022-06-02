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
    public partial class Articulo : UserControl
    {
        #region EventHandlers 

        public event EventHandler ArticuloClick;

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
            set { colorIncial = value; }
        }

        private Color colorFinal;
        public Color ColorFinal
        {
            get { return colorFinal; }
            set { colorFinal = value; }
        }

        private string cveArticulo;
        public string CveArticulo
        {
            get { return cveArticulo; }
            set { cveArticulo = value; }
        }

        private int idGrupoRopa;
        public int IdGrupoRopa
        {
            get { return idGrupoRopa; }
            set { idGrupoRopa = value; }
        }

        private int  tipoArticulo;
        public int  TipoArticulo
        {
            get { return tipoArticulo; }
            set { tipoArticulo = value; }
        }

        private string nombreArticulo;
        public string NombreArticulo
        {
            get { return nombreArticulo; }
            set { nombreArticulo = value; }
        }

        private Dictionary<int,decimal> listaPrecios;
        public Dictionary<int,decimal> ListaPrecios
        {
            get { return listaPrecios; }
            set { listaPrecios = value; }
        }

        private DataTable listaSubarticulos;
        public DataTable ListaSubArticulos
        {
            get { return listaSubarticulos; }
            set { listaSubarticulos = value; }
        }

        #endregion

        #region Constructor

        public Articulo()
        {
            InitializeComponent();
            panelPrincipal.BackColor = colorIncial;
        }

        #endregion

        #region Eventos

        private void ImgArticulo_MouseEnter(object sender, EventArgs e)
        {
            panelPrincipal.BackColor = colorFinal;
        }

        private void ImgArticulo_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void ImgArticulo_MouseLeave(object sender, EventArgs e)
        {
            panelPrincipal.BackColor = colorIncial;
            ToolTipPrincipal.Hide(this);
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

        private void Articulo_Load(object sender, EventArgs e)
        {
            ToolTipPrincipal.SetToolTip(imgArticulo, nombreArticulo);
            lblNombre.Text = nombreArticulo;
            colorBorder = Color.MediumTurquoise;
            colorFinal = Color.PaleTurquoise;
            colorIncial = Color.LightGray;            
        }

        #endregion

    }
}
