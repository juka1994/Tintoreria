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
using PuntodeVentaTintoreria.ClaseAux.EventArgsAux;
using PuntodeVentaTintoreria.Infraestructura.Extensiones;
using Newtonsoft.Json;

namespace PuntodeVentaTintoreria
{
    public partial class frmSelSubTipoPrenda : Form
    {
        string clavetipoprenda;
        int opcion = 0;
        DataRow[] result;
      
        string clavetipo;
        string clavecolor;
        string clavefibra;
        string claveestampado;
        string nombresubtipo;
        string descripcionprenda;
        string comentarioprenda;
        string idgrupo;
        bool cobro;
        public string Clavetipo { get => clavetipo; set => clavetipo = value; }
        public string ClaveColor { get => clavecolor; set => clavecolor = value; }
        public string ClaveFibra { get => clavefibra; set => clavefibra = value; }
        public string ClaveEstampado { get => claveestampado; set => claveestampado = value; }
        public string Nombresubtipo { get => nombresubtipo; set => nombresubtipo = value; }
        public string Comentarioprenda { get => comentarioprenda; set => comentarioprenda = value; }
        public string Descripcionprenda { get => descripcionprenda; set => descripcionprenda = value; }
        public string Idgrupo { get => idgrupo; set => idgrupo = value; }
        public bool Cobro { get => cobro; set => cobro = value; }

        public frmSelSubTipoPrenda(string clave,  string nombreprenda)
        {
            InitializeComponent();
            clavetipoprenda = clave;
            result = Comun.ListaRopa.Select("id_tipoRopa = " + clave);
            lblPrenda.Text = nombreprenda;
            opcion = 1;
            clavetipo="";
            clavecolor="";
            clavefibra="";
            claveestampado="";
            nombresubtipo = "";
            comentarioprenda = "";
            Cobro = true;
        }

        public frmSelSubTipoPrenda(string clave, string nombreprenda,string idropa, string idcolor, string idfibra, string idestampado, string comentario)
        {
            InitializeComponent();
            clavetipoprenda = clave;
            result = Comun.ListaRopa.Select("id_tipoRopa = " + clave);

            lblPrenda.Text = nombreprenda;

            opcion = 2;
            clavetipo = idropa;
            clavecolor = idcolor;
            clavefibra = idfibra;
            claveestampado = idestampado;
            nombresubtipo = "";
            comentarioprenda = comentario;
            txtComentarioPrenda.Text = comentarioprenda;

            IniciarFormWait().ShowDialog();

            panelColor.Visible = true;
            panelTipo.Visible = true;
            panelFibra.Visible = true;
            panelEstampado.Visible = true;
        }

        #region Metodos

        private void mostrarSubtipo(string  nombreArticulo, string cveArticulo, int idGrupoRopa, bool cobrar)
        {
            string nombre = nombreArticulo;
            lblTipo.Text = "Tipo: " + nombre;
            clavetipo = cveArticulo;
            idgrupo = idGrupoRopa.ToString();
            lblTipo.BackColor = Color.Orange;
            nombresubtipo = nombreArticulo;
            cobro = cobrar;
        }

        private void mostrarColor(string nombreArticulo, string cveArticulo)
        {
            string nombre = nombreArticulo;
            lblColor.Text = "Color: " + nombre;
            lblColor.BackColor = Color.Orange;
            clavecolor = cveArticulo;
        }

        private void mostrarFibra(string nombreArticulo, string cveArticulo)
        {
            string nombre = nombreArticulo;
            lblFibra.Text = "Fibra: " + nombre;
            lblFibra.BackColor = Color.Orange;
            clavefibra = cveArticulo;
        }

        private void mostrarEstampado(string nombreArticulo, string cveArticulo)
        {
            string nombre = nombreArticulo;
            lblEstampado.Text = "Estampado: " + nombre;
            lblEstampado.BackColor = Color.Orange;
            claveestampado = cveArticulo;
        }

        #endregion

        #region Eventos

        protected virtual void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        protected virtual void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DatosEvento_Click(object sender, EventArgs e)
        {
            ArticuloV5 tipo = (ArticuloV5)sender;
            bool cobrar = true;
            if (tipo._tipoArticulo == 1) cobrar = true;
            else cobrar = false;
            mostrarSubtipo(tipo._nombreArticulo, tipo._cveArticulo, tipo._idGrupoRopa, cobrar);
        }

        private void ColorEvento_Click(object sender, EventArgs e)
        {
            ArticuloV2 color = (ArticuloV2) sender;
            mostrarColor(color.NombreArticulo, color.CveArticulo);
        }

        private void FibraEvento_Click(object sender, EventArgs e)
        {
            ArticuloV2 fibra = (ArticuloV2)sender;
            mostrarFibra(fibra.NombreArticulo, fibra.CveArticulo);
            
        }

        private void EstampadoEvento_Click(object sender, EventArgs e)
        {
            ArticuloV2 estampado = (ArticuloV2)sender;
            mostrarEstampado(estampado.NombreArticulo, estampado.CveArticulo);
        }

        private void FrmSelSubTipoPrenda_Load(object sender, EventArgs e)
        {
            try
            {

                lblTipo.BackColor = Color.Gray;
                lblFibra.BackColor = Color.Gray;
                lblColor.BackColor = Color.Gray;
                lblEstampado.BackColor = Color.Gray;
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            string error = "";

            if (clavetipo == "")
                error = "Debe seleccionar un tipo de prenda \n";

            if (clavecolor == "")
                error = "Debe seleccionar un color \n";

            if (clavefibra == "")
                error = "Debe seleccionar un tipo de fibra \n";

            if (claveestampado == "")
                error = "Debe seleccionar un tipo de estampado \n";

            if (error == "")
            {
                descripcionprenda = lblColor.Text + "," + lblFibra.Text + "," + lblEstampado.Text;
                comentarioprenda = txtComentarioPrenda.Text;

                this.Close();
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show(error, "", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void BtnMaxRest_Click(object sender, EventArgs e)
        {
            if (this.WindowState.Equals(FormWindowState.Maximized))
            {
                WindowState = FormWindowState.Normal;
            }
            else if (WindowState.Equals(FormWindowState.Normal))
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        #endregion

        #region Asincrono para dibujado de controles

        private Panel DibujarColor()
        {
            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            CargarColorBGW(panel);
            return panel;
        }

        private Panel DibujarSubtipo()
        {
            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            CargarSubtipoBGW(panel);
            return panel;
        }

        private Panel DibujarFibra()
        {
            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            CargarFibraBGW(panel);
            return panel;
        }

        private Panel DibujarEstampado()
        {
            Panel panel = new Panel();
            panel.Dock = DockStyle.Fill;
            CargarEstampadosBGW(panel);
            return panel;
        }

        private void CargarSubtipoBGW(Panel panel)
        {
            try
            {
                if (result != null)
                {
                    for (int contador = 0; contador < result.Length; contador++)
                    {
                        DibujarSubtipo(panel, result[contador]["id_grupo"].ToString(), result[contador]["id_ropa"].ToString(), result[contador]["nombreProducto"].ToString(), Convert.ToBoolean(result[contador]["cobrarLavanderia"].ToString()), contador, result[contador]["extension"].ToString());
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void CargarColorBGW(Panel panel)
        {
            try
            {
                if (Comun.ColoresRopa != null)
                {
                    for (int contador = 0; contador < Comun.ColoresRopa.Rows.Count; contador++)
                    {
                        //int.TryParse(Comun.ColoresRopa.Rows[contador]["R"].ToString(), out int R);
                        //int.TryParse(Comun.ColoresRopa.Rows[contador]["G"].ToString(), out int G);
                        //int.TryParse(Comun.ColoresRopa.Rows[contador]["B"].ToString(), out int B);
                        //int.TryParse(Comun.ColoresRopa.Rows[contador]["A"].ToString(), out int A);
                        //Color color = Color.FromArgb(A, R, G, B);
                        DibujarColor(panel, Comun.ColoresRopa.Rows[contador]["id_colorRopa"].ToString(), Comun.ColoresRopa.Rows[contador]["descripcion"].ToString(), contador, Comun.ColoresRopa.Rows[contador]["extension"].ToString());
                    }
                }
            }
            catch (Exception)
            {


            }
        }

        private void CargarFibraBGW(Panel panel)
        {
            try
            {
                if (Comun.FibrasRopa != null)
                {
                    //lista de articos
                    for (int contador = 0; contador < Comun.FibrasRopa.Rows.Count; contador++)
                    {
                        DibujarFibra(panel, Comun.FibrasRopa.Rows[contador]["id_fibraRopa"].ToString(), Comun.FibrasRopa.Rows[contador]["descripcion"].ToString(), contador, Comun.FibrasRopa.Rows[contador]["extension"].ToString());
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void CargarEstampadosBGW(Panel panel)
        {
            try
            {
                if (Comun.EstampadosRopa != null)
                {
                    for (int contador = 0; contador < Comun.EstampadosRopa.Rows.Count; contador++)
                    {
                        DibujarEstampado(panel, Comun.EstampadosRopa.Rows[contador]["id_estampadoRopa"].ToString(), Comun.EstampadosRopa.Rows[contador]["descripcion"].ToString(), contador, Comun.EstampadosRopa.Rows[contador]["extension"].ToString());
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void DibujarColor(Panel panel, string clave, string nombreCtrl, int index, string extension)
        {
            try
            {
                ArticuloV2 icon_Creativa = new ArticuloV2
                {
                    Name = nombreCtrl.Trim().ToUpper(),
                    NombreArticulo = nombreCtrl.Trim().ToUpper(),
                    CveArticulo = clave.Trim(),
                    ColorBoder = Color.MediumTurquoise,
                    ColorFinal = Color.PaleTurquoise,
                    ColorInicial = Color.LightGray,
                    Size = new System.Drawing.Size(52, 75),
                    TabIndex = index
                };

                string path = Comun.PathBaseImages + @"\Color\" + clave + extension;
                try
                {
                    if (File.Exists(path))
                        icon_Creativa.imgArticulo.Image = Image.FromFile(path);
                    else
                        icon_Creativa.imgArticulo.Image = global::PuntodeVentaTintoreria.Properties.Resources.DFFibras;
                }
                catch (Exception)
                {

                }

                icon_Creativa.ArticuloClick += new EventHandler(this.ColorEvento_Click);
                panel.Controls.Add(icon_Creativa);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void DibujarSubtipo(Panel panel, string grupo, string clave, string nombreCtrl, bool cobro, int index, string extension)
        {
            try
            {
                ArticuloV5 icon_Creativa = new ArticuloV5
                {
                    _idGrupoRopa = Convert.ToInt32(grupo.Trim()),
                    _cveArticulo = clave.Trim(),
                    Name = nombreCtrl.Trim().ToUpper(),
                    _nombreArticulo = nombreCtrl.Trim().ToUpper(),
                    _colorBoder = Color.MediumTurquoise,
                    _colorFinal = Color.PaleTurquoise,
                    _colorInicial = Color.LightGray,
                    Size = new System.Drawing.Size(80, 120),
                    TabIndex = index
                };
                if (cobro)
                    icon_Creativa._tipoArticulo = 1;
                else
                    icon_Creativa._tipoArticulo = 0;

                string path = Comun.PathBaseImages + @"\Subtipo\" + clave + extension;
                try
                {
                    if (File.Exists(path))
                        icon_Creativa.imgArticulo.Image = Image.FromFile(path);
                    else
                        icon_Creativa.imgArticulo.Image = global::PuntodeVentaTintoreria.Properties.Resources.DFFibras;
                }
                catch (Exception)
                {

                }

                icon_Creativa.ArticuloClick += new EventHandler(this.DatosEvento_Click);


                panel.Controls.Add(icon_Creativa);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void DibujarFibra(Panel panel, string clave, string nombreCtrl, int index, string extension)
        {
            try
            {
                ArticuloV2 icon_Creativa = new ArticuloV2
                {
                    Name = nombreCtrl.Trim().ToUpper(),
                    NombreArticulo = nombreCtrl.Trim().ToUpper(),
                    CveArticulo = clave.Trim(),
                    ColorBoder = Color.MediumTurquoise,
                    ColorFinal = Color.PaleTurquoise,
                    ColorInicial = Color.LightGray,
                    Size = new System.Drawing.Size(52, 75),
                    TabIndex = index
                };
                string path = Comun.PathBaseImages + @"\Fibra\" + clave + extension;
                try
                {
                    if (File.Exists(path))
                        icon_Creativa.imgArticulo.Image = Image.FromFile(path);
                    else
                        icon_Creativa.imgArticulo.Image = global::PuntodeVentaTintoreria.Properties.Resources.DFFibras;
                }
                catch (Exception)
                {

                }
                icon_Creativa.ArticuloClick += new EventHandler(this.FibraEvento_Click);
                panel.Controls.Add(icon_Creativa);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void DibujarEstampado(Panel panel, string clave, string nombreCtrl, int index, string extension)
        {
            try
            {
                ArticuloV2 icon_Creativa = new ArticuloV2
                {
                    Name = nombreCtrl.Trim().ToUpper(),
                    NombreArticulo = nombreCtrl.Trim().ToUpper(),
                    CveArticulo = clave.Trim(),
                    ColorBoder = Color.MediumTurquoise,
                    ColorFinal = Color.PaleTurquoise,
                    ColorInicial = Color.LightGray,
                    Size = new System.Drawing.Size(52, 75),
                    TabIndex = index
                };

                try
                {
                    string path = Comun.PathBaseImages + @"\Estampado\" + clave + extension;
                    if (File.Exists(path))
                        icon_Creativa.imgArticulo.Image = Image.FromFile(path);
                    else
                        icon_Creativa.imgArticulo.Image = global::PuntodeVentaTintoreria.Properties.Resources.DFEstampado;
                }
                catch (Exception)
                {

                }
                icon_Creativa.ArticuloClick += new EventHandler(this.EstampadoEvento_Click);
                panel.Controls.Add(icon_Creativa);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private FrmEspera IniciarFormWait()
        {
            try
            {
                FrmEspera frmEspera = new FrmEspera("Espere un momento.", 1);
                frmEspera.DoWork += new FrmEspera.DoWorkHandler(this.FrmEspera_DoWork);
                frmEspera.RunWorkedComplete += new FrmEspera.RunWorkedCompleteHandler(this.FrmEspera_WorkerCompleted);
                return frmEspera;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FrmEspera_DoWork(FrmEspera m, DoWorkWaitEventArgs e)
        {
            try
            {
                var task1 = Task.Run(() => DibujarColor());
                var task2 = Task.Run(() => DibujarSubtipo());
                var task3 = Task.Run(() => DibujarFibra());
                var task4 = Task.Run(() => DibujarEstampado());
                var allTasks = new List<Task> { task1, task2, task3, task4 };
                Task.WaitAll(allTasks.ToArray());
                var result = new List<Panel> { task1.Result, task2.Result, task3.Result, task4.Result };
                e.Result = result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FrmEspera_WorkerCompleted(FrmEspera m, RunWorkerCompletedWaitEventArgs e)
        {
            try
            {
                if (e.Error is null)
                {
                    if (e.Result != null)
                    {
                        List<Panel> panels = e.Result as List<Panel>;
                        if (panels.Count == 4)
                        {
                            panelColor.Controls.AddRange(panels[0].Controls.ToArrayControl());
                            panelTipo.Controls.AddRange(panels[1].Controls.ToArrayControl());
                            panelFibra.Controls.AddRange(panels[2].Controls.ToArrayControl());
                            panelEstampado.Controls.AddRange(panels[3].Controls.ToArrayControl());
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error al cargar la información.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FrmSelSubTipoPrenda_Shown(object sender, EventArgs e)
        {
            FrmEspera frmwait = IniciarFormWait();
            frmwait.ShowDialog();
            if (!(frmwait.Exceptions is null))
            {
                string ListaErrores = string.Empty;
                foreach (var ex in frmwait.Exceptions.InnerExceptions)
                {
                    ListaErrores += string.Concat(ex.Message.ToString(), " ", Environment.NewLine);
                }
                MessageBox.Show(string.Format("Error: {0}", ListaErrores));
            }
        }

        #endregion

    }
}
