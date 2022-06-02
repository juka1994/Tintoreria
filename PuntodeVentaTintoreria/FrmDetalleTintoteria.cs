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
using TintoreriaGlobal;
using TintoreriaNegocio;

namespace PuntodeVentaTintoreria
{
    public partial class FrmDetalleTintoteria : Form
    {
        DocumentosXPagar infoDocumentosXPagar = new DocumentosXPagar();
        private VentaProductos infoventa;
        frm_Esperar espere = new frm_Esperar();
        public FrmDetalleTintoteria(VentaProductos venta)
        {
            InitializeComponent();
            infoventa = venta;
            infoventa.conexion = Comun.conexion;
        }

        #region metodos generales
        private void LlenarDatos()
        {
            try
            {
                this.dtp_fechaIngreso.Value = infoventa.FecEntrega;
                this.dtp_fechaIngreso.Enabled = false;
                txt_cantidadprendas.Text = infoventa.CantidadPrendas;
                txthora_.Text =infoventa.HoraEntrega;
                txt_usuario.Text = infoventa.Usuins;

                //datos del ticket
                DataTable oDTableTicket = new DataTable();
                TicketNegocio oNegocio = new TicketNegocio();
                oDTableTicket = oNegocio.ObtenerDatosTicket(infoventa.Folio);

                foreach(DataRow rowDTableTicket in oDTableTicket.Rows)
                {
                    txtSucursal.Text = rowDTableTicket["nombreSucusal"].ToString();
                    txtStatus.Text = rowDTableTicket["nombreStatus"].ToString();
                }

                //datosclientes
                ClienteNegocio cliente_negocio = new ClienteNegocio();
                Cliente cliente = new Cliente();
                cliente.conexion = Comun.conexion;
                cliente.id_cliente = infoventa.IDCliente;
                cliente_negocio.obtenerClienteXIDD(cliente);
                
                foreach (DataRow row in cliente.datos.Rows)
                {
                    txt_nombre.Text = row["nombre"].ToString();
                    txt_apellidoPaterno.Text =row["apePat"].ToString();
                    txt_apellidoMaterno.Text= row["apeMat"].ToString();
                    txt_RFC.Text = row["curp"].ToString();
                    txtcolonia.Text= row["colonia"].ToString();
                    TXTCALLE.Text = row["direccion"].ToString();
                    txt_email.Text= row["correoElectronico"].ToString();
                    txt_ciudad.Text= row["descripcion"].ToString();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Laavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

      

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txt_cantidadprendas_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            try
            {
                frmVentaTintoreria frm = new frmVentaTintoreria(1);
                frm.ImprimirTicket(infoventa.IDVenta);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), Comun.NOMBRE_SISTEMA, MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmDetalleTintoreria ~ btnImportar_Click");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GridViewPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PanelTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                
                LlenarDatos();
            }
            catch (Exception ex)
            {
                LogError.AddExcFileTxt(ex, "frmADetalleTintoreria ~ ");


            }

        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void ImagenGrid(DataTable oDTable)
        {
            int rowNumber = 0;
            foreach (DataRow oRow in oDTable.Rows)
            {
                string logoColor = oRow[7].ToString();
                string logoEstampado = oRow[8].ToString();
                string logoFibra = oRow[9].ToString();

                logoColor = string.IsNullOrEmpty(logoColor) ? HelperImgCID.IMAGEN_DEFAULT_BASE64 : logoEstampado;
                logoEstampado = string.IsNullOrEmpty(logoEstampado) ? HelperImgCID.IMAGEN_DEFAULT_BASE64 : logoEstampado;
                logoFibra = string.IsNullOrEmpty(logoFibra) ? HelperImgCID.IMAGEN_DEFAULT_BASE64 : logoFibra;

                GridViewrOPA.Rows[rowNumber].Cells["colori"].Value = resizeImage(Recursos.Base64StringToBitmap(logoColor), new Size(25, 25)); ;
                GridViewrOPA.Rows[rowNumber].Cells["fibra"].Value = resizeImage(Recursos.Base64StringToBitmap(logoFibra), new Size(25,25));
                GridViewrOPA.Rows[rowNumber].Cells["estampado"].Value = resizeImage(Recursos.Base64StringToBitmap(logoEstampado), new Size(25, 25));

                rowNumber++;
            }
        }

        private void FrmDetalleTintoteria_Load(object sender, EventArgs e)
        {
            try
            {
                LlenarDatos();
                CargarGridPagos();
                CargarDatosRopa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError.AddExcFileTxt(ex, "frmDetalleTintoreria ~ frmAlmacen");
            }
        }

        private void CalcularTotal()
        {
            try
            {
                float total = 0.0F;
                if (GridViewPagos.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in GridViewPagos.Rows)
                    {
                        total += Convert.ToSingle(row.Cells["monto"].Value);
                    }
                }
                this.txt_totalPagos.Text = string.Format("{0:C2}", total);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void CalcularTotalRopa()
        {
            try
            {
                float total = 0.0F;
                if (GridViewrOPA.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in GridViewrOPA.Rows)
                    {
                        total += 1;
                    }
                }
                this.txt_totalPrendas.Text = string.Format("{0:N2}", total);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void CargarGridPagos()
        {
            try
            {
                DocumentosXPagarNegocio documentosXPagarNegocio = new DocumentosXPagarNegocio();
                DocumentosXPagar documentosXPagar = new DocumentosXPagar();
                documentosXPagar.conexion = Comun.conexion;
                documentosXPagar.idventa = infoventa.IDVenta;
                documentosXPagar.id_sucursal = infoventa.IDSucursal;
                documentosXPagarNegocio.LLenarGridPagos(documentosXPagar);
                infoDocumentosXPagar.datos = documentosXPagar.datos;
                this.GridViewPagos.AutoGenerateColumns = false;
                this.GridViewPagos.DataSource = documentosXPagar.datos;
                CalcularTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void CargarDatosRopa()
        {
            try
            {
                DocumentosXPagarNegocio documentosXPagarNegocio = new DocumentosXPagarNegocio();
                DocumentosXPagar documentosXPagar = new DocumentosXPagar();
                documentosXPagar.conexion = Comun.conexion;
                documentosXPagar.idventa = infoventa.IDVenta;
                documentosXPagar.id_sucursal = infoventa.IDSucursal;
                documentosXPagarNegocio.LLenarGridDatosRopa(documentosXPagar);
                infoDocumentosXPagar.datos = documentosXPagar.datos;
                this.GridViewrOPA.AutoGenerateColumns = false;
                this.GridViewrOPA.DataSource = documentosXPagar.datos;
                ImagenGrid(documentosXPagar.datos);
                CalcularTotalRopa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta Lavanderia", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_totalPagos_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelTitulo2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
