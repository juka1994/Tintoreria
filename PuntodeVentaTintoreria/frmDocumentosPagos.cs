using PuntodeVentaTintoreria.ClaseAux;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TintoreriaGlobal;
using TintoreriaNegocio;

namespace PuntodeVentaTintoreria
{
    public partial class frmDocumentosPagos : Form
    {
        Validaciones Val;
        DocumentosXPagar infoDocumentosXPagar;
        Bodega infoBodega;
        Cliente cliente = new Cliente();
        
        public frmDocumentosPagos(DocumentosXPagar documentosXPagar)
        {
            Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
            try
            {
                InitializeComponent();
                infoDocumentosXPagar = documentosXPagar;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmDocumentosPagos ~ frmDocumentosPagos(DocumentosXPagar documentosXPagar)");
            }
           
        }
        public frmDocumentosPagos(DocumentosXPagar documentosXPagar, Bodega bodega)
        {
            Comun.conexion = ConfigurationManager.AppSettings.Get("strConnection");
            try
            {
                InitializeComponent();
                infoDocumentosXPagar = documentosXPagar;
                infoBodega = bodega;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmDocumentosPagos ~ frmDocumentosPagos(DocumentosXPagar documentosXPagar, Bodega bodega)");
            }
        }
        private void frmDocumentosPagos_Load(object sender, EventArgs e)
        {
            try
            {
                this.txt_folio.ReadOnly = true;
                this.txt_fechaPedido.ReadOnly = true;
                this.txt_horaPedido.ReadOnly = true;
                this.txt_proveedor.ReadOnly = true;
                this.txt_total.ReadOnly = true;
                this.txt_pagos.ReadOnly = true;
                this.txt_pendiente.ReadOnly = true;
                this.txt_adeudo.ReadOnly = true;
                this.CargarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmDocumentosPagos ~ frmDocumentosPagos_Bunifu_Load");
            }
        }
        #region MetodosGenerales
        private void CargarDatos()
        {
            try
            {
                this.txt_folio.Text = infoDocumentosXPagar.folio;
                this.txt_proveedor.Text = infoDocumentosXPagar.proveedor;
                this.dtp_fechaPedido.Text = infoDocumentosXPagar.fecha.ToString();
                this.txt_fechaPedido.Text = infoDocumentosXPagar.fecha.ToShortDateString();
                this.dtp_horaPedido.Text = infoDocumentosXPagar.hora;
                this.txt_horaPedido.Text = infoDocumentosXPagar.hora;
                this.txt_total.Text = String.Format("{0:C2}", infoDocumentosXPagar.total);
                this.txt_pagos.Text = String.Format("{0:C2}", infoDocumentosXPagar.pago);
                this.txt_pendiente.Text = String.Format("{0:C2}", (infoDocumentosXPagar.total - infoDocumentosXPagar.pago));
                this.txt_pago.Text = String.Format("{0:C2}", (infoDocumentosXPagar.total - infoDocumentosXPagar.pago));               
                this.txt_pago_Validating(null, null);
                if (infoDocumentosXPagar.aplicarBodega == true)
                {
                    txt_pago.Text = string.Format("{0:C2}", infoDocumentosXPagar.monto);
                    txt_pago.ReadOnly = true;
                    this.DrawCambio();
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DrawCambio()
        {
            try
            {
                float cambioPago = 0F;
                cambioPago = this.ObtenerCambio();
                if (cambioPago <= 0)
                {
                    this.txt_adeudo.Text = string.Format("{0:c}", 0);
                    //this.label25.Text = "CAMBIO";
                }
                else
                {
                    this.txt_adeudo.Text = string.Format("{0:c}", cambioPago);
                    //this.label25.Text = "DEBE";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private float ObtenerCambio()
        {
            try
            {
                float total = 0.0F;
                float.TryParse(this.txt_pendiente.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out total);
                return total - this.GetTotalPago();
            }
            catch (Exception ex)
            {
                return 0F;

            }
        }
        private float GetTotalPago()
        {
            try
            {
                float total = 0.0F;
                float.TryParse(this.txt_pago.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out total);
                return total;
            }
            catch (Exception ex)
            {
                return 0F;
            }
        }
        private int validarPago()
        {
            try
            {
                float montototal = 0;
                float montopagoinicial = 0;
                if (!float.TryParse(this.txt_pendiente.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out montototal))
                {
                    this.txt_total.Focus();
                    return 3;
                }
                if (montototal < 0)
                {
                    return 8;
                }
                if (!float.TryParse(this.txt_pago.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out montopagoinicial))
                {
                    this.txt_pago.Focus();
                    return 3;
                }
                if (montopagoinicial < 0)
                {
                    return 11;
                }
                if (montopagoinicial == 0)
                {
                    return 12;
                }
                if (montopagoinicial > montototal)
                {
                    return 13;
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        private void mensajeErrorPago(int i)
        {
            try
            {
                string mensaje = "";
                switch (i)
                {
                    case 3:
                        mensaje = "Dato no válido";
                        break;
                    case 8:
                        mensaje = "El total no puede ser negativo. Revise el pedido.";
                        break;
                    case 11:
                        mensaje = "El pago inicial no puede ser negativo. Revise el pedido.";
                        break;
                    case 12:
                        mensaje = "El pago no puede ser $0.00. Revise el pedido.";
                        break;
                    case 13:
                        mensaje = "El pago no puede ser mayor que el pendiente. Revise el pedido.";
                        break;
                    default:
                        mensaje = "Ocurrió un error. Comuníquese a Soporte.";
                        break;
                }
                MessageBox.Show(this, mensaje, "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    this.Visible = false;
                    MessageBox.Show(this, "!!Pago Realizado!!!", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Information);







                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion
        #region Validaciones
        private void txt_pago_Enter(object sender, EventArgs e)
        {
            try
            {
                TextBox aux = (TextBox)sender;
                this.ActiveControl = aux;
                aux.Focus();
                aux.SelectAll();
            }
            catch (Exception)
            {
            }
        }

        private void txt_pago_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                Val = new Validaciones();
                Val.PermitirSoloNumerosDecimales(e, txt.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmDocumentosPagos ~ txt_pago_KeyPress");
            }
        }

        private void txt_pago_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_pago_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                decimal aux = 0;
                decimal.TryParse(txt_pago.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out aux);
                this.DrawCambio();
            }
            catch (Exception)
            {
            }
        }

        private void txt_pago_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txt_pago_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                decimal aux = 0;
                decimal.TryParse(txt_pago.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out aux);
                txt_pago.Text = string.Format("{0:c}", aux);
                this.DrawCambio();
            }
            catch (Exception)
            {
            }
        }
        #endregion
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            try
            {
                int Verificador = -1;
                int aux = this.validarPago();
                if (aux == 0)
                {
                    DocumentosXPagarNegocio documentosXPagarNegocio = new DocumentosXPagarNegocio();
                    DocumentosXPagar documentosXPagar = new DocumentosXPagar();
                    documentosXPagar.conexion = Comun.conexion;
                    documentosXPagar.opcion = 1;
                    documentosXPagar.imagen = "";
                    documentosXPagar.id_caja = Comun.id_caja;
                    documentosXPagar.id_docXPagar = infoDocumentosXPagar.id_docXPagar;
                    documentosXPagar.id_sucursal = infoDocumentosXPagar.id_sucursal;
                    documentosXPagar.monto = float.Parse(this.txt_pago.Text, NumberStyles.Currency, CultureInfo.CurrentCulture);
                    documentosXPagar.pago = float.Parse(this.txt_pagos.Text, NumberStyles.Currency, CultureInfo.CurrentCulture);
                    documentosXPagar.id_u = Comun.id_u;
                    if (infoDocumentosXPagar.aplicarBodega == true)
                    {
                        documentosXPagarNegocio.AbcAplicarBodega(documentosXPagar, infoBodega, ref Verificador);
                    }
                    else
                    {
                        //documentosXPagarNegocio.AbcDocumentosXPagar(documentosXPagar, ref Verificador);
                        documentosXPagarNegocio.AbcDocumentosXPagar2(documentosXPagar, ref Verificador);
                        try
                        {
                            ImageFormat Formato = ImageFormat.Png;
                            documentosXPagar.extension = ".png";

                            Image imagen = Recursos.ResizeImage(this.ImgPrincipal.Image, 350, 768, Formato);
                            imagen.Save(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Voucher\" + documentosXPagar.id_pagoDocXPagar + documentosXPagar.extension));

                            StreamReader streamReader = new StreamReader(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Voucher\" + documentosXPagar.id_pagoDocXPagar + documentosXPagar.extension));
                            Bitmap bmp = new Bitmap(streamReader.BaseStream);
                            streamReader.Close();
                            documentosXPagar.imagen = bmp.ToBase64String(Formato);

                            documentosXPagar.opcion = 2;
                            //documentosXPagarNegocio.AbcDocumentosXPagar(documentosXPagar, ref Verificador);
                            documentosXPagarNegocio.AbcDocumentosXPagar2(documentosXPagar, ref Verificador);
                        }
                        catch (Exception)
                        {
                        }
                        UtilFtp.UploadFTP(Path.Combine(System.Windows.Forms.Application.StartupPath, @"Resources\Voucher\" + documentosXPagar.id_pagoDocXPagar + ".PNG"), ConfigurationManager.AppSettings.Get("ServerFtpTxt2") + @"/Voucher/", ConfigurationManager.AppSettings.Get("UsuarioFtpTxt2"), ConfigurationManager.AppSettings.Get("ContraseñaFtpTxt2"));
                    }
                    this.VerificarMensajeAccion(Verificador);
                }
                else
                {
                    this.mensajeErrorPago(aux);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmDocumentosPagos~ btnPagar_Click");
            }
        }

        private void btn_imagen_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog BuscarImagen = new OpenFileDialog();
                BuscarImagen.Filter = "Image Files|*.png;*.jpg;*.bmp;*.gif";
                BuscarImagen.FileName = "";
                BuscarImagen.Title = "Seleccione una imagen";
                BuscarImagen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures).ToString();
                if (BuscarImagen.ShowDialog() == DialogResult.OK)
                {
                    this.LblImage.Text = BuscarImagen.FileName;
                    this.ImgPrincipal.ImageLocation = BuscarImagen.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmDocumentosPagos ~ btn_imagen_Click");
            }
        }

        private void txt_pago_KeyUp_1(object sender, KeyEventArgs e)
       {
            try
            {
                decimal aux = 0;
                decimal.TryParse(txt_pago.Text, NumberStyles.Currency, CultureInfo.CurrentCulture, out aux);
             
                this.DrawCambio();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
