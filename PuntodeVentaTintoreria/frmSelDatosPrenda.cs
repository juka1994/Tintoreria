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
using System.Xml.Linq;
using PuntodeVentaTintoreria.ClaseAux.EventArgsAux;
using PuntodeVentaTintoreria.Infraestructura.Extensiones;

namespace PuntodeVentaTintoreria
{
    public partial class frmSelDatosPrenda : Form
    {
        
        private string _listaXml;
        public string ListaXml
        {
            get { return _listaXml; }
            set { _listaXml = value; }
        }

        Dictionary<string, string> _listaSimbolos;

        public Dictionary<string, string> ListaSimbolos { get => _listaSimbolos; set => _listaSimbolos = value; }

        public frmSelDatosPrenda(string nombreprenda, string xml)
        {
            InitializeComponent();

            _listaSimbolos = new Dictionary<string, string>();
           
            lblNombreprenda.Text = nombreprenda;
            _listaXml = xml;

            if (_listaXml != "")
            {
                DesSerializarDiccionario();
                ListaSeleccionada();
            }
        }
       
        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();

        }

        private void button29_Click(object sender, EventArgs e)
        {
            SerializarDiccionario();
            DialogResult = DialogResult.OK;
            this.Close();
           
        }

        #region Metodos

        private void DatosEvento_Click(object sender, EventArgs e)
        {
            try
            {
                    ArticuloV3 simbolo = (ArticuloV3)sender;
                    if (!simbolo._isCheck)
                    {
                        _listaSimbolos.Add(simbolo._cveArticulo, simbolo._nombreArticulo);
                    }
                    else
                    {
                        _listaSimbolos.Remove(simbolo._cveArticulo);
                    }
            }
            catch (Exception)
            {

                
            }

            //.Show("Seleccionado", "", MessageBoxButtons.OK);
        }

        public void SerializarDiccionario()
        {
            try
            {
                if (_listaSimbolos.Count > 0)
                {


                    XElement xElem = new XElement(
                   "items",
                    _listaSimbolos.Select(x => new XElement("itemSimbolo", new XAttribute("id", x.Key), new XAttribute("value", x.Value)))
                   );

                    _listaXml= xElem.ToString();
                }
                else
                    _listaXml= "";
                
            }
            catch (Exception)
            {

                _listaXml= "";
            }
        }

        private void DesSerializarDiccionario()
        {
            try
            {
                if (ListaXml != "")
                {
                    XElement xElem2 = XElement.Parse(ListaXml); //XElement.Load(...)
                    _listaSimbolos = xElem2.Descendants("itemSimbolo")
                                        .ToDictionary(x => (string)x.Attribute("id"), x => (string)x.Attribute("value"));
                }
            }
            catch (Exception)
            {

                
            }

        }

        private Panel CargarDatosLavado()
        {
            try
            {
                DataRow[] resultado = Comun.SimbolosRopa.Select("id_tipoSimboloRopa = 1");
                Panel panel = new Panel();
                if (resultado != null)
                {
                    for (int contador = 0; contador < resultado.Length; contador++)
                    {
                        DibujarLavado(panel, resultado[contador]["id_simboloRopa"].ToString(), resultado[contador]["descripcion"].ToString(), contador, 1);
                    }
                }
                return panel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        private Panel CargarDatosSecado()
        {
            try
            {
                DataRow[] resultado = Comun.SimbolosRopa.Select("id_tipoSimboloRopa = 2");
                Panel panel = new Panel();
                if (resultado != null)
                {
                    for (int contador = 0; contador < resultado.Length; contador++)
                    {
                        DibujarLavado(panel, resultado[contador]["id_simboloRopa"].ToString(), resultado[contador]["descripcion"].ToString(), contador, 2);
                    }
                }
                return panel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Panel CargarDatosPlanchado()
        {
            try
            {
                DataRow[] resultado = Comun.SimbolosRopa.Select("id_tipoSimboloRopa = 3");
                Panel panel = new Panel();
                if (resultado != null)
                {
                    for (int contador = 0; contador < resultado.Length; contador++)
                    {
                        DibujarLavado(panel, resultado[contador]["id_simboloRopa"].ToString(), resultado[contador]["descripcion"].ToString(), contador, 3);
                    }
                }
                return panel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Panel CargarDatosBlanqueado()
        {
            try
            {
                DataRow[] resultado = Comun.SimbolosRopa.Select("id_tipoSimboloRopa = 4");
                Panel panel = new Panel();
                if (resultado != null)
                {
                    for (int contador = 0; contador < resultado.Length; contador++)
                    {
                        DibujarLavado(panel, resultado[contador]["id_simboloRopa"].ToString(), resultado[contador]["descripcion"].ToString(), contador, 4);
                    }
                }
                return panel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Panel CargarDatosLimpiezaSeco()
        {
            try
            {
                DataRow[] resultado = Comun.SimbolosRopa.Select("id_tipoSimboloRopa = 5");
                Panel panel = new Panel();
                if (resultado != null)
                {
                    for (int contador = 0; contador < resultado.Length; contador++)
                    {
                        DibujarLavado(panel, resultado[contador]["id_simboloRopa"].ToString(), resultado[contador]["descripcion"].ToString(), contador, 5);
                    }
                }
                return panel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ListaSeleccionada()
        {
            try
            {
                for (int i = 0; i < _listaSimbolos.Count; i++)
                {
                    string clave = _listaSimbolos.ElementAt(i).Key;
                    BuscarControl(clave);
                }
            }
            catch (Exception)
            {
            }
        }

        private void BuscarControl(string clave)
        {
            try
            {
                Control[] control =  this.Controls.Find("Name" + clave, true);
                if (control[0].GetType().ToString() == "ArticuloV3")
                {
                    //control del tipo boton
                    ArticuloV3 simbolo = (ArticuloV3)control[0];
                    simbolo._isCheck = true;
                }
            }
            catch (Exception)
            {

                
            }

        }

        private void DibujarLavado(Panel panelContenedor, string clave, string nombreCtrl, int index, int panel)
        {
            try
            {
                ArticuloV3 icon_Creativa = new ArticuloV3();
                icon_Creativa.Name = clave;
                icon_Creativa._nombreArticulo = nombreCtrl;
                icon_Creativa._cveArticulo = "Name" + clave;
                icon_Creativa._colorBoder = Color.MediumTurquoise;
                icon_Creativa._colorFinal = Color.PaleTurquoise;
                icon_Creativa._colorInicial = Color.LightGray;

                icon_Creativa.Size = new System.Drawing.Size(70, 95);
                icon_Creativa.TabIndex = index;


                string path = @"C:\CSL\IMG\Simbolos\" + clave + ".png";
                string path2 = @"C:\CSL\IMG\Simbolos\default.png";
                try
                {
                    if (File.Exists(path))
                        icon_Creativa.imgArticulo.Image = Image.FromFile(path);
                    else
                        icon_Creativa.imgArticulo.Image = Image.FromFile(path2);
                }
                catch (Exception)
                {

                }
                icon_Creativa.ArticuloClick += new EventHandler(this.DatosEvento_Click);
                panelContenedor.Controls.Add(icon_Creativa);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void FrmSelDatosPrenda_Load(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception)
            {
            }
           
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
                var task1 = Task.Run(() => CargarDatosLavado());
                var task2 = Task.Run(() => CargarDatosSecado());
                var task3 = Task.Run(() => CargarDatosPlanchado());
                var task4 = Task.Run(() => CargarDatosBlanqueado());
                var task5 = Task.Run(() => CargarDatosLimpiezaSeco());
                var allTasks = new List<Task> { task1, task2, task3, task4, task5 };
                Task.WaitAll(allTasks.ToArray());
                var result = new List<Panel> { task1.Result, task2.Result, task3.Result, task4.Result, task5.Result };
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
                        if (panels.Count == 5)
                        {
                            panelOpcionesEtiqueta01.Controls.AddRange(panels[0].Controls.ToArrayControl());
                            panelOpcionesEtiqueta02.Controls.AddRange(panels[1].Controls.ToArrayControl());
                            panelOpcionesEtiqueta03.Controls.AddRange(panels[2].Controls.ToArrayControl());
                            panelOpcionesEtiqueta04.Controls.AddRange(panels[3].Controls.ToArrayControl());
                            panelOpcionesEtiqueta05.Controls.AddRange(panels[4].Controls.ToArrayControl());
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

        private void FrmSelDatosPrenda_Shown(object sender, EventArgs e)
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
    }
}
