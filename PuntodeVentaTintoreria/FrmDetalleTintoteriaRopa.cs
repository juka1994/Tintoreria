using PuntodeVentaTintoreria.ClaseAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using TintoreriaGlobal;
using TintoreriaNegocio;

namespace PuntodeVentaTintoreria
{
    public partial class FrmDetalleTintoteriaRopa : Form
    {
        int opciong = 0;
        DocumentosXPagar infoDocumentosXPagar = new DocumentosXPagar();
        private VentaProductos infoventa;
        frm_Esperar espere = new frm_Esperar();
        DocumentosXPagar documentosXPagar;

        public FrmDetalleTintoteriaRopa(VentaProductos venta)
        {
            InitializeComponent();
            infoventa = venta;
            documentosXPagar = new DocumentosXPagar();
            infoventa.conexion = Comun.conexion;
        }

        public FrmDetalleTintoteriaRopa(string idventa, int opcion)
        {
            InitializeComponent();
            infoventa = new VentaProductos();
            infoventa.IDVenta = idventa;
            infoventa.IDSucursal = Comun.id_sucursal;
            documentosXPagar = new DocumentosXPagar();
            infoventa.conexion = Comun.conexion;
            opciong = opcion;
            if (opcion == 1)
            {
                btnActualizar.Text = "INICIAR PROCESO";
                this.Size = new System.Drawing.Size(936, 515);
            }
            else if (opcion == 2)
            {
                btnActualizar.Text = "CONCLUIR PROCESO";
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                VentaTintoreriaNegocio neg = new VentaTintoreriaNegocio();
                //Actualizar datos
                if (opciong == 1)
                {
                    neg.ActualizarStatusProceso(Comun.id_sucursal, infoventa.IDVenta, 2);
                }
                else if (opciong == 2)
                {
                    neg.ActualizarStatusProceso(Comun.id_sucursal, infoventa.IDVenta, 3);
                }
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception)
            {
                                
            }
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void DatosGrid()
        {
            try
            {
                foreach (DataGridViewRow Grid in this.GridViewrOPA.Rows)
                {
                    string simbolos = Grid.Cells[12].Value.ToString();
                    Dictionary<string, string> _listaSimbolos = null;
                    if (simbolos != "")
                    {
                        XElement xElem2 = XElement.Parse(simbolos); //XElement.Load(...)
                        _listaSimbolos = xElem2.Descendants("itemSimbolo")
                                            .ToDictionary(x => (string)x.Attribute("id"), x => (string)x.Attribute("value"));

                        string datossimbolos = "";
                        if (_listaSimbolos != null)
                        {
                            foreach (string item in _listaSimbolos.Values)
                            {
                                datossimbolos += item;
                                datossimbolos += "  ";
                            }
                        }
                        Grid.Cells[11].Value = datossimbolos;
                    }
                }
            }
            catch (Exception)
            {
                               
            }
        }

        private void ImagenGrid()
        {
            try
            {
                foreach (DataGridViewRow Grid in this.GridViewrOPA.Rows)
                {
                    int clave = Convert.ToInt32(Grid.Cells[6].Value);
                    Grid.Cells[3].Value = resizeImage(Image.FromFile(@"C:\CSL\IMG\Colores\" + clave + ".png"), new Size(25, 25));

                    string clave2 = "default";
                    Grid.Cells[4].Value = resizeImage(Image.FromFile(@"C:\CSL\IMG\Fibras\" + clave2 + ".png"), new Size(25, 25));

                    int clave3 = Convert.ToInt32(Grid.Cells[8].Value);
                    Grid.Cells[5].Value = resizeImage(Image.FromFile(@"C:\CSL\IMG\Estapado\" + clave3 + ".png"), new Size(25, 25));
                }
            }
            catch (Exception)
            {
                               
            }
        }

        private void ImagenGrid(DataTable oDTable)
        {
            int rowNumber = 0;
            foreach (DataRow oRow in oDTable.Rows)
            {
                string logoColor = oRow[9].ToString();
                string logoEstampado = oRow[10].ToString();
                string logoFibra = oRow[11].ToString();

                logoColor = string.IsNullOrEmpty(logoColor) ? HelperImgCID.IMAGEN_DEFAULT_BASE64 : logoEstampado;
                logoEstampado = string.IsNullOrEmpty(logoEstampado) ? HelperImgCID.IMAGEN_DEFAULT_BASE64 : logoEstampado;
                logoFibra = string.IsNullOrEmpty(logoFibra) ? HelperImgCID.IMAGEN_DEFAULT_BASE64 : logoFibra;

                GridViewrOPA.Rows[rowNumber].Cells[3].Value = resizeImage(Recursos.Base64StringToBitmap(logoColor), new Size(25, 25)); ;
                GridViewrOPA.Rows[rowNumber].Cells[4].Value = resizeImage(Recursos.Base64StringToBitmap(logoFibra), new Size(25, 25));
                GridViewrOPA.Rows[rowNumber].Cells[5].Value = resizeImage(Recursos.Base64StringToBitmap(logoEstampado), new Size(25, 25));

                rowNumber++;
            }
        }

        private void FrmDetalleTintoteria_Load(object sender, EventArgs e)
        {
            try
            {
                if (!backgroundWorker1.IsBusy)
                    backgroundWorker1.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmDetalleTintoreia ~ frmAlmacen");
            }
        }

        private void CargarDatosRopa()
        {
            try
            {
                DocumentosXPagarNegocio documentosXPagarNegocio = new DocumentosXPagarNegocio();
                documentosXPagar.conexion = Comun.conexion;
                documentosXPagar.idventa = infoventa.IDVenta;
                documentosXPagar.id_sucursal = infoventa.IDSucursal;
                documentosXPagarNegocio.LLenarGridDatosRopaMonitor(documentosXPagar);
                infoDocumentosXPagar.datos = documentosXPagar.datos;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {
            try
            {
                CargarDatosRopa();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmADetalleTintoreria ~ ");
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.GridViewrOPA.AutoGenerateColumns = false;
            this.GridViewrOPA.DataSource = documentosXPagar.datos;
            ImagenGrid(documentosXPagar.datos);
            DatosGrid();
        }
    }
}
