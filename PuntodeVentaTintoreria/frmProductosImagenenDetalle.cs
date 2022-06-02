using PuntodeVentaTintoreria.ClaseAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TintoreriaGlobal;
using TintoreriaNegocio;

namespace PuntodeVentaTintoreria
{
    public partial class frmProductosImagenenDetalle : Form
    {
        private Validaciones Val;
        private ProductoImagen infoProducto;
        private string IDProductoAux;
        private bool ModificarImagen;
        private frm_Esperar espere = new frm_Esperar();
        public frmProductosImagenenDetalle(ProductoImagen productoImagen)
        {
            InitializeComponent();
            Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
            infoProducto = productoImagen;
        }

        public frmProductosImagenenDetalle(string ID)
        {
            InitializeComponent();
            IDProductoAux = ID;
            infoProducto = new ProductoImagen();
        }

        public bool ThumbnailCallback()
        {
            return true;
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmProductosImagenenDetalle_Load(object sender, EventArgs e)
        {
            try
            {
                Inicializar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmProductosImagenesDetalle ~ frmProductos_Bunifu_Load");
            }
        }

        #region Metodos Generales
        private void Inicializar()
        {
            try
            {
                this.LlenarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void LlenarDatos()
        {
            try
            {
                try
                {
                    ProductoImagenNegocio productoNegocio = new ProductoImagenNegocio();
                    ProductoImagen pimagen = new ProductoImagen();
                    pimagen.IdImagnen = infoProducto.IdImagnen;
                    pimagen.Conexion = Comun.conexion;
                    string PathFile = "";
                    bool actualizar = false;




                    if (infoProducto.UrlImagen == null)
                    {
                    }
                    else
                    {

                        PathFile = Path.Combine(System.Windows.Forms.Application.StartupPath, @"" + infoProducto.UrlImagen);


                        //Preguntar si actualiza imagen
                        //buscar bit de cambio en la table de imagenes de producto por equipo
                        if (productoNegocio.BuscarActualizacionImagen(pimagen.Conexion, Comun.id_equipo, Comun.id_sucursal, pimagen.IdImagnen))
                            actualizar = true;


                        if (File.Exists(PathFile) && !actualizar)
                        {
                            this.ImgPrincipal.ImageLocation = PathFile;
                            this.LblImage.Text = infoProducto.UrlImagen;
                        }
                        else
                        {
                            int verificador = 0;
                            //Descargar Archivo:
                            productoNegocio.DescargarImagen(pimagen, Comun.id_equipo, Comun.id_sucursal, ref verificador);


                            //Guardar imagen;

                            Bitmap bmpFromString = pimagen.imagen.Base64StringToBitmap();
                            bmpFromString.Save(pimagen.UrlImagen);
                            this.ImgPrincipal.Image = bmpFromString;




                            this.ImgPrincipal.ImageLocation = pimagen.UrlImagen;
                            this.LblImage.Text = "(D) - " + infoProducto.UrlImagen;


                        }


                    }
                }
                catch (Exception)
                {
                    this.ImgPrincipal.Image = PuntodeVentaTintoreria.Properties.Resources.icono_productos;
                    this.LblImage.Text = "No se localiza la imagen";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        #endregion


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmProductosImagenDetalle ~ btnGuardar_Click");
            }
        }
    }
}
