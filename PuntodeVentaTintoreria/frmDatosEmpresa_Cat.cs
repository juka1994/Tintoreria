using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TintoreriaGlobal;
using TintoreriaNegocio;

namespace PuntodeVentaTintoreria
{
    public partial class frmDatosEmpresa_Cat : Form
    {
        private Empresa infoEmpresa;
        private Validaciones Val;
        private bool ModificarImagen;
        public frmDatosEmpresa_Cat()
        {
            InitializeComponent();
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlNoTickets_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PanelTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmDatosEmpresa_Cat_Load(object sender, EventArgs e)
        {
            try
            {
                this.Inicializar();
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
                this.LLenarDatos();
                this.CargarImagen();
                this.ActiveControl = this.txtRazonSocial;
                this.txtRazonSocial.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LLenarDatos()
        {
            try
            {
                Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
                EmpresaNegocio empresa_negocio = new EmpresaNegocio();
                infoEmpresa = new Empresa();
                infoEmpresa.conexion = Comun.conexion;
                empresa_negocio.LLenarDatosEmpresa(infoEmpresa);
                infoEmpresa.id_empresa = Convert.ToInt32(infoEmpresa.datos.Rows[0]["id_empresa"].ToString());
                infoEmpresa.logo = infoEmpresa.datos.Rows[0]["logo"].ToString();
                this.txtRazonSocial.Text = infoEmpresa.datos.Rows[0]["razonSocial"].ToString();
                this.txtNombreComercial.Text = infoEmpresa.datos.Rows[0]["nombreComercial"].ToString();
                this.txtRfc.Text = infoEmpresa.datos.Rows[0]["RFC"].ToString();
                this.txtMensaje1.Text = infoEmpresa.datos.Rows[0]["mensaje1"].ToString();
                this.txtMensaje2.Text = infoEmpresa.datos.Rows[0]["mensaje2"].ToString();
                this.txtMensaje3.Text = infoEmpresa.datos.Rows[0]["mensaje3"].ToString();
                this.txtSlogan.Text = infoEmpresa.datos.Rows[0]["slogan"].ToString();
                this.txtNoTickets.Text = infoEmpresa.datos.Rows[0]["numeroTickets"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void GuardarCatEmpresa()
        {
            int Verificador = 0;
            Empresa empresa = new Empresa();
            empresa.conexion = Comun.conexion;
           
            empresa.id_empresa = infoEmpresa.id_empresa;
            EmpresaNegocio empresa_negocio = new EmpresaNegocio();
            this.ObtenerDatos(ref empresa);
            if (empresa.id_empresa != 0)
            {
                empresa_negocio.AbcEmpresa(empresa, ref Verificador);
                if (ModificarImagen)
                {

                    try
                    {
                        ImageFormat Formato = ImageFormat.Png;
                        empresa.extension = ".png";

                        Bitmap logoImagen = new Bitmap(this.pbxImagen.Image);
                        logoImagen.MakeTransparent();
                        logoImagen.Save(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Empresas\" + empresa.id_empresa + empresa.extension), Formato);

                        StreamReader streamReader = new StreamReader(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Empresas\" + empresa.id_empresa + empresa.extension));
                        Bitmap bmp = new Bitmap(streamReader.BaseStream);
                        streamReader.Close();
                        empresa.logo = bmp.ToBase64String(Formato);
                        empresa_negocio.AbcEmpresa(empresa, ref Verificador);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                empresa_negocio.AbcEmpresa(empresa, ref Verificador);

                try
                {
                    ImageFormat Formato = ImageFormat.Png;
                    empresa.extension = ".png";

                    Image imagen = Recursos.ResizeImage(this.pbxImagen.Image, 200, 80, Formato);
                    imagen.Save(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Empresas\" + empresa.id_empresa + empresa.extension));

                    StreamReader streamReader = new StreamReader(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Empresas\" + empresa.id_empresa + empresa.extension));
                    Bitmap bmp = new Bitmap(streamReader.BaseStream);
                    streamReader.Close();
                    empresa.logo = bmp.ToBase64String(Formato);

                    empresa_negocio.AbcEmpresa(empresa, ref Verificador);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.VerifcarMensajeAccion(Verificador);
        }
        private void VerifcarMensajeAccion(int Verificador)
        {

            try
            {
                if (Verificador == 0)
                {
                    MessageBox.Show(this, "Los datos se guardaron correctamente", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ObtenerDatos(ref Empresa empresa)
        {
            try
            {
                empresa.id_empresa = infoEmpresa.id_empresa;
                empresa.razonSocial = this.txtRazonSocial.Text;
                empresa.nombreComercial = this.txtNombreComercial.Text;
                empresa.rfc = this.txtRfc.Text;
                empresa.mensaje1 = this.txtMensaje1.Text;
                empresa.mensaje2 = this.txtMensaje2.Text;
                empresa.mensaje3 = this.txtMensaje3.Text;
                empresa.slogan = this.txtSlogan.Text;
                empresa.numeroTickets = Convert.ToInt32(this.txtNoTickets.Text);
                empresa.logo = infoEmpresa.logo;
                empresa.id_u = Comun.id_u;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarImagen()
        {
            try
            {
                ImageFormat Formato = ImageFormat.Png;
                infoEmpresa.extension = ".png";
                Bitmap bmpFromString = infoEmpresa.logo.Base64StringToBitmap();
                this.pbxImagen.Image = bmpFromString;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        private bool ValidarCampos()
        {
            Validaciones Val = new Validaciones();
            try
            {
                if (this.txtRazonSocial.Text.Length == 0)
                {
                    this.txtRazonSocial.Focus();
                    MessageBox.Show(this, "Escriba la razon social de la empresa", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txtNombreComercial.Text.Length == 0)
                {
                    this.txtNombreComercial.Focus();
                    MessageBox.Show(this, "Escriba el nombre comercial de la empresa", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txtSlogan.Text.Length == 0)
                {
                    this.txtSlogan.Focus();
                    MessageBox.Show(this, "Escriba el slogan de la empresa", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txtRfc.Text.Length == 0)
                {
                    this.txtRfc.Focus();
                    MessageBox.Show(this, "Escriba el RFC de la empresa", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                if (this.txtNoTickets.Text.Length == 0)
                {
                    this.txtNoTickets.Focus();
                    MessageBox.Show(this, "Escriba la cantidad de Tickets", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
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
                        this.GuardarCatEmpresa();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRazonSocial_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlImagen_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pbxImagen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog BuscarImagen = new OpenFileDialog();
                BuscarImagen.Filter = "Archivos de Imagen PNG Image |*.png";
                BuscarImagen.FileName = "";
                BuscarImagen.Title = "Buscar Imagen";
                BuscarImagen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures).ToString();
                if (BuscarImagen.ShowDialog() == DialogResult.OK)
                {
                    ModificarImagen = true;
                    this.pbxImagen.ImageLocation = BuscarImagen.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
