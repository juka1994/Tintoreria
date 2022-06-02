using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TintoreriaGlobal;
using TintoreriaNegocio;
using PuntodeVentaTintoreria.ClaseAux;
using CreativaSL.LibControls.WinForms;

namespace PuntodeVentaTintoreria
{
    public partial class frmVentaProductos : Form
    {
        public frmVentaProductos()
        {

            try
            {
                InitializeComponent();
            }
            catch (Exception)
            {
                MessageBox.Show(this, "No se pudo cargar la información. Contacte a Soporte Técnico.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
      

        protected virtual void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        protected virtual void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /**************************************************************************************************************************************/

        #region Variables
        private CultureInfo provider = CultureInfo.CurrentCulture;
        List<Venta> ventasPendientes = new List<Venta>();
        int contador = 1;
        int tabActuales = 0;
        bool bandPrecioMayoreo = false;
        Image closeImage, closeImageAct;

        private decimal Ivasucursal = 0;

        frm_Esperar espere = new frm_Esperar();
        #endregion

        private void frmVentaProductos_Load(object sender, EventArgs e)
        {
            try
            {
                this.backgroundWorker1.RunWorkerAsync();
                espere.ShowDialog();
                this.ActiveControl = this.txt_fCB;
                this.txt_fCB.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
            }
        }

       
       
        #region Metodos Generales       
        private void ConsultaVale()
        {
            try
            {
                int Verificador = -1;
                Venta ventavale = new Venta();
                TabPage tabSeleccionado = new TabPage();
                if (tabControl1.TabPages.Count > 0)
                    tabSeleccionado = this.tabControl1.SelectedTab;
                foreach (Venta venta in ventasPendientes)
                {
                    if (venta.id_ventaTemporal == tabSeleccionado.Name)
                    {
                        ventavale = venta;
                    }
                }

                if (ventavale.vale.IDVale == null)
                {
                    Vales_Negocio vale_negocio = new Vales_Negocio();
                    frm_PedirCodigoVale codigo = new frm_PedirCodigoVale();
                    codigo.ShowDialog();
                    if (codigo.DialogResult == DialogResult.OK)
                    {
                        Venta ventaAux = new Venta();
                        ventaAux.vale = new Vales { Conexion = Comun.conexion, Folio = codigo.TextotxtCantidad };
                        ventaAux.vale.TablaDatos = new DataTable();
                        ventaAux.vale.TablaDatos.Columns.Add("id_venta", typeof(string));
                        ventaAux.vale.TablaDatos.Columns.Add("id_sucursal", typeof(string));
                        ventaAux.vale.TablaDatos.Columns.Add("id_producto", typeof(string));
                        ventaAux.vale.TablaDatos.Columns.Add("id_tallaRopa", typeof(string));
                        ventaAux.vale.TablaDatos.Columns.Add("id_colorRopa", typeof(string));
                        ventaAux.vale.TablaDatos.Columns.Add("id_ventaDetalle", typeof(string));
                        ventaAux.vale.TablaDatos.Columns.Add("descuento", typeof(float));
                        vale_negocio.ConsultaVale(ventaAux);
                        if (ventaAux.vale.IDVale != null)
                        {
                            if (ventavale.productosVenta.Count() != 0)
                            {
                                int banVale = 0;
                                switch (ventaAux.vale.IDTipoVale)
                                {
                                    case 1:
                                        foreach (VentaProductos ventaProductoAux in ventavale.productosVenta)
                                        {
                                            ventaProductoAux.Descuento = ((ventaProductoAux.Subtotal) * (ventaAux.vale.Porcentaje / 100));
                                            ventaAux.vale.DescuentoTotalVale += ((ventaProductoAux.Subtotal) * (ventaAux.vale.Porcentaje / 100));

                                            ventaAux.vale.TablaDatos.Rows.Add(new Object[] {
                                                ventavale.id_ventaTemporal,
                                                Comun.id_sucursal,
                                                ventaProductoAux.IDProducto,
                                                ventaProductoAux.IDTallaRopa,
                                                ventaProductoAux.IDColorRopa,
                                                ventaProductoAux.IDVentadetalle,
                                                ventaProductoAux.Descuento
                                            });
                                        }
                                        this.txtDescuentoVale.Text = string.Format("{0:F2}", ventaAux.vale.DescuentoTotalVale);
                                        ventaAux.vale.Conexion = Comun.conexion;
                                        ventaAux.id_sucursal = Comun.id_sucursal;
                                        vale_negocio.ModificarDescuentoVentaDetalle(ref Verificador, ref ventaAux);
                                        ventavale.vale = ventaAux.vale;
                                        MessageBox.Show(this, "Vale Aplicado Correctamente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        break;
                                    case 2:
                                        ventaAux.vale.DescuentoTotalVale += ventaAux.vale.Monto;
                                        if (ventavale.total >= ventaAux.vale.DescuentoTotalVale)
                                        {
                                            banVale = 1;
                                            decimal descuentoXProducto = ventaAux.vale.DescuentoTotalVale;
                                            foreach (VentaProductos ventaProductoAux in ventavale.productosVenta)
                                            {
                                                if (descuentoXProducto >= ventaProductoAux.Subtotal)
                                                {
                                                    ventaProductoAux.Descuento = ventaProductoAux.Subtotal;
                                                    descuentoXProducto = descuentoXProducto - ventaProductoAux.Descuento;
                                                }
                                                else
                                                {
                                                    ventaProductoAux.Descuento = descuentoXProducto;
                                                    descuentoXProducto = 0;
                                                }
                                                ventaAux.vale.TablaDatos.Rows.Add(new Object[] {
                                                ventavale.id_ventaTemporal,
                                                Comun.id_sucursal,
                                                ventaProductoAux.IDProducto,
                                                ventaProductoAux.IDTallaRopa,
                                                ventaProductoAux.IDColorRopa,
                                                ventaProductoAux.IDVentadetalle,
                                                ventaProductoAux.Descuento
                                                });
                                            }
                                        }
                                        else
                                            ventaAux.vale = new Vales();

                                        this.txtDescuentoVale.Text = string.Format("{0:F2}", ventaAux.vale.DescuentoTotalVale);
                                        if (banVale == 0)
                                        {
                                            MessageBox.Show(this, "Revisar las condiciones para aplicar el vale, el descuento del vale es mayor que el total", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else if (banVale == 1)
                                        {
                                            ventaAux.vale.Conexion = Comun.conexion;
                                            ventaAux.id_sucursal = Comun.id_sucursal;
                                            vale_negocio.ModificarDescuentoVentaDetalle(ref Verificador, ref ventaAux);
                                            ventavale.vale = ventaAux.vale;
                                            MessageBox.Show(this, "Vale Aplicado Correctamente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        break;
                                    case 3:
                                        foreach (VentaProductos ventaProductoAux in ventavale.productosVenta)
                                        {
                                            if (ventaProductoAux.IDProducto == ventaAux.vale.ProductoRequerido.id_producto)
                                            {
                                                banVale = 1;
                                                if (ventaProductoAux.CantidadVenta >= (int)ventaAux.vale.CantidadRequeridaNxN)
                                                {
                                                    banVale = 2;
                                                    break;
                                                }
                                            }
                                        }
                                        if (banVale == 2)
                                        {
                                            foreach (VentaProductos ventaProductoAux in ventavale.productosVenta)
                                            {
                                                if (ventaProductoAux.IDProducto == ventaAux.vale.ProductoRequerido.id_producto)
                                                {
                                                    ventaAux.descuento = (decimal)(ventaAux.vale.CantidadGratisNxN * ventaProductoAux.Precio);
                                                    ventaProductoAux.Descuento = ventaAux.descuento;
                                                    ventaAux.vale.DescuentoTotalVale = ventaProductoAux.Descuento;
                                                    ventaAux.vale.TablaDatos.Rows.Add(new Object[] {
                                                        ventavale.id_ventaTemporal,
                                                        Comun.id_sucursal,
                                                        ventaProductoAux.IDProducto,
                                                        ventaProductoAux.IDTallaRopa,
                                                        ventaProductoAux.IDColorRopa,
                                                        ventaProductoAux.IDVentadetalle,
                                                        ventaProductoAux.Descuento
                                                    });
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                            ventaAux.vale = new Vales();
                                        this.txtDescuentoVale.Text = string.Format("{0:F2}", ventaAux.vale.DescuentoTotalVale);
                                        if (banVale == 0)
                                            MessageBox.Show(this, "Revisar las condiciones para aplicar el vale, no existe el producto requerido", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        else if (banVale == 1)
                                            MessageBox.Show(this, "Revisar las condiciones para aplicar el vale, no existe la cantidad minima del producto requerido", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        else if (banVale == 2)
                                        {
                                            ventaAux.vale.Conexion = Comun.conexion;
                                            ventaAux.id_sucursal = Comun.id_sucursal;
                                            vale_negocio.ModificarDescuentoVentaDetalle(ref Verificador, ref ventaAux);
                                            ventavale.vale = ventaAux.vale;
                                            MessageBox.Show(this, "Vale Aplicado Correctamente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        break;
                                    case 4:
                                        foreach (VentaProductos ventaProductoAux in ventavale.productosVenta)
                                        {
                                            if (ventaProductoAux.IDProducto == ventaAux.vale.ProductoRequerido.id_producto)
                                            {
                                                banVale = 1;
                                                if (ventaProductoAux.CantidadVenta >= (int)ventaAux.vale.CantRequeridad)
                                                {
                                                    banVale = 2;
                                                    break;
                                                }
                                            }
                                        }

                                        if (banVale == 2)
                                        {
                                            foreach (VentaProductos ventaProductoAux in ventavale.productosVenta)
                                            {
                                                if (ventaProductoAux.IDProducto == ventaAux.vale.ProductoGratis.id_producto)
                                                {
                                                    banVale = 3;
                                                    if (ventaProductoAux.CantidadVenta >= ventaAux.vale.CantGratis)
                                                    {
                                                        banVale = 4;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        if (banVale == 4)
                                        {
                                            foreach (VentaProductos ventaProductoAux in ventavale.productosVenta)
                                            {
                                                if (ventaProductoAux.IDProducto == ventaAux.vale.ProductoGratis.id_producto)
                                                {
                                                    ventaAux.descuento = (decimal)(ventaAux.vale.CantGratis * ventaProductoAux.Precio);
                                                    ventaProductoAux.Descuento = ventaAux.descuento;
                                                    ventaAux.vale.DescuentoTotalVale = ventaProductoAux.Descuento;
                                                    ventaAux.vale.TablaDatos.Rows.Add(new Object[] {
                                                        ventavale.id_ventaTemporal,
                                                        Comun.id_sucursal,
                                                        ventaProductoAux.IDProducto,
                                                        ventaProductoAux.IDTallaRopa,
                                                        ventaProductoAux.IDColorRopa,
                                                        ventaProductoAux.IDVentadetalle,
                                                        ventaProductoAux.Descuento
                                                    });
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                            ventaAux.vale = new Vales();
                                        this.txtDescuentoVale.Text = string.Format("{0:F2}", ventaAux.vale.DescuentoTotalVale);
                                        if (banVale == 0)
                                            MessageBox.Show(this, "Revisar las condiciones para aplicar el vale, no existe el producto requerido", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        else if (banVale == 1)
                                            MessageBox.Show(this, "Revisar las condiciones para aplicar el vale, no existe la cantidad minima del producto requerido", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        if (banVale == 2)
                                            MessageBox.Show(this, "Revisar las condiciones para aplicar el vale, no existe el producto gratis", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        else if (banVale == 3)
                                            MessageBox.Show(this, "Revisar las condiciones para aplicar el vale, no existe la cantidad minima del producto gratis", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        else if (banVale == 4)
                                        {
                                            ventaAux.vale.Conexion = Comun.conexion;
                                            ventaAux.id_sucursal = Comun.id_sucursal;
                                            vale_negocio.ModificarDescuentoVentaDetalle(ref Verificador, ref ventaAux);
                                            ventavale.vale = ventaAux.vale;
                                            MessageBox.Show(this, "Vale Aplicado Correctamente", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        break;
                                }
                            }
                            else
                                MessageBox.Show(this, "No hay productos para poder aplicar el vale", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            codigo.Dispose();
                            MessageBox.Show(this, "Vale no encontrado", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                    MessageBox.Show(this, "Ya existe un vale aplicado", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Inicializar()
        {
            try
            {
                this.LiberarVentasNoGuardadas();
                this.CargarCombos();
                this.CargarVentasPendientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void CargarVentasPendientes()
        {
            try
            {
                VentaProductos datos = new VentaProductos();
                VentaProductosNegocio vn = new VentaProductosNegocio();
                List<VentaProductos> lista = new List<VentaProductos>();
                datos.IDSucursal = Comun.id_sucursal;
                datos.IDCajero = Comun.id_u;
                datos.StrCnx = Comun.conexion;
                lista = vn.ObtenerVentasPendientes(datos);
                ventasPendientes.Clear();
                this.tabControl1.TabPages.Clear();
                if (lista.Count == 0)
                {
                    VentaProductos nuevaVenta = AgregarVentaPendienteNueva();
                    Venta ventaPend = new Venta();
                    ventaPend.cliente = new Cliente();
                    ventaPend.cliente.id_cliente = nuevaVenta.IDCliente;
                    ventaPend.idCliente = nuevaVenta.IDCliente;
                    ventaPend.vale = new Vales();
                    ventaPend.id_ventaTemporal = nuevaVenta.IDVenta;
                    ventaPend.textTab = nuevaVenta.nameTab;
                    ventasPendientes.Add(ventaPend);
                    AgregarTabVenta(nuevaVenta);
                    nuevaVenta.StrCnx = Comun.conexion;
                    this.MostrarDatosCliente(nuevaVenta);
                }
                else
                {
                    foreach (VentaProductos venta in lista)
                    {
                        Cliente cliente = new Cliente();
                        cliente.credenciales = new Credenciales();
                        ClienteNegocio cn = new ClienteNegocio();
                        venta.StrCnx = Comun.conexion;
                        venta.IDSucursal = Comun.id_sucursal;
                        cliente = cn.ObtenerClienteXIDVenta(venta);
                        Venta ventaPend = new Venta();
                        ventaPend.id_ventaTemporal = venta.IDVenta;
                        ventaPend.textTab = venta.nameTab;
                        ventaPend.cliente = cliente;
                        ventaPend.cliente.id_cliente = cliente.id_cliente;
                        ventaPend.idCliente = cliente.id_cliente;
                        ventaPend.vale = new Vales();
                        ventasPendientes.Add(ventaPend);
                        AgregarTabVenta(venta);
                        this.MostrarDatosCliente(venta);
                    }

                    VentaProductos nuevaVenta = AgregarVentaPendienteNueva();
                    Venta ventaPendN = new Venta();
                    ventaPendN.cliente = new Cliente();
                    ventaPendN.cliente.id_cliente = nuevaVenta.IDCliente;
                    ventaPendN.idCliente = nuevaVenta.IDCliente;
                    ventaPendN.vale = new Vales();
                    ventaPendN.id_ventaTemporal = nuevaVenta.IDVenta;
                    ventaPendN.textTab = nuevaVenta.nameTab;
                    ventasPendientes.Add(ventaPendN);
                    AgregarTabVenta(nuevaVenta);
                    nuevaVenta.StrCnx = Comun.conexion;
                    this.MostrarDatosCliente(nuevaVenta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private VentaProductos AgregarVentaPendienteNueva()
        {
            try
            {
                VentaProductosNegocio vn = new VentaProductosNegocio();
                VentaProductos datos = new VentaProductos();
                datos.IDCajero = Comun.id_u;
                datos.IDSucursal = Comun.id_sucursal;
                datos.IDCaja = Comun.id_caja;
                datos.StrCnx = Comun.conexion;
                datos.nameTab = string.Concat("0000", contador);
                contador++;
                datos.nameTab = "Ticket " + datos.nameTab.Substring(datos.nameTab.Length - 3, 3);
                vn.InsertarVentaPendiente(datos);
                return datos;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private void AgregarTabVenta(VentaProductos datos)
        {
            try
            {
                TabPage newtab = new TabPage();
                newtab.Margin = new Padding(3);
                newtab.Padding = new Padding(3);
                newtab.Name = datos.IDVenta;
                newtab.Text = datos.nameTab;
                this.tabControl1.TabPages.Add(newtab);
                tabControl1.SelectedTab = newtab;
                DataGridView dgv = new DataGridView();
                dgv.Name = "DGV" + datos.IDVenta;
                dgv.Dock = DockStyle.Fill;
                dgv.Location = new System.Drawing.Point(0, 0);
                dgv.MultiSelect = false;
                dgv.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(208)))), ((int)(((byte)(57)))));
                this.DGVTabPage.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Muli", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(249, 249, 251);
                dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
                dgv.Size = new System.Drawing.Size(1076, 558);
                dgv.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvProductos_CellDoubleClick);
                this.agregarColumnasDataGridView(dgv, 15);
                this.EstablecerPropiedadesGridHome(dgv);
                newtab.Controls.Add(dgv);
                this.tabControl1.SelectedTab = this.tabControl1.TabPages[newtab.Name];
                tabControl1.SelectedTab = tabControl1.TabPages[tabControl1.TabCount - 1];
                this.DgvProductosBindingSource(datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void CalcularTotal(VentaProductos datos)
        {
            try
            {
                Venta ventaaux = new Venta();
                List<VentaProductos> detalleVenta = new List<VentaProductos>();
                DataGridView dgvSeleccionado = new DataGridView();
                TabPage tabSeleccionado = new TabPage();
                if (tabControl1.TabPages.Count > 0)
                    tabSeleccionado = this.tabControl1.SelectedTab;
                dgvSeleccionado = this.findDGV(tabSeleccionado);

                foreach (Venta venta in ventasPendientes)
                {
                    if (venta.id_ventaTemporal == tabSeleccionado.Name)
                    {
                        detalleVenta = venta.productosVenta;
                        ventaaux = venta;
                        break;
                    }
                }

                ventaaux.subTotal = 0;
                ventaaux.descuento = 0;
                ventaaux.iva = 0;
                ventaaux.puntos = 0;
                ventaaux.total = 0;
                ventaaux.monedero = 0;

                if (detalleVenta != null)
                {
                    if (detalleVenta.Count > 0)
                    {
                        foreach (VentaProductos ventaProductos in detalleVenta)
                        {
                            ventaaux.subTotal += (float)ventaProductos.Subtotal;
                            ventaaux.descuento += ventaProductos.Descuento;
                            ventaaux.iva += (float)ventaProductos.Iva;
                            ventaaux.puntos += (int)ventaProductos.puntos;
                            ventaaux.total += ventaProductos.Total;
                            ventaaux.monedero += (float)ventaProductos.Monedero;
                        }
                    }
                }


                //obtener IVA y calcular general.
                // float ivatotal = ventaaux.total * (float)(Ivasucursal/100);
                // float subtotal = ventaaux.subTotal - ivatotal;

                //this.txtSubtotal.Text = string.Format("{0:C2}", subtotal);
                //this.txtIva.Text = string.Format("{0:C2}", ivatotal);


                this.txtSubtotal.Text = string.Format("{0:C2}", ventaaux.subTotal);
                this.txtIva.Text = string.Format("{0:C2}", ventaaux.iva);


                this.txtDescuento.Text = string.Format("{0:C2}", ventaaux.descuento);

                this.txtPuntos.Text = ventaaux.puntos.ToString();
                this.txtMonedero.Text = string.Format("{0:C2}", ventaaux.monedero);
                this.txtTotal.Text = string.Format("{0:C2}", ventaaux.total);
                this.txtDescuentoVale.Text = string.Format("{0:C2}", ventaaux.vale.DescuentoTotalVale);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void CargarCombos()
        {
            try
            {
                this.LlenaComboFamilia();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void LlenaComboFamilia()
        {
            try
            {
                Familia datos = new Familia();
                datos.conexion = Comun.conexion;
                datos.opcion = 1;
                VentaProductosNegocio vpn = new VentaProductosNegocio();
                this.cmbFamilia.SelectedValueChanged -= new System.EventHandler(this.cmbFamilia_SelectedValueChanged);
                this.cmbFamilia.DisplayMember = "descripcion";
                this.cmbFamilia.ValueMember = "id_familia";
                this.cmbFamilia.DataSource = vpn.LlenaComboFamilia(datos);
                this.cmbFamilia.SelectedValueChanged += new System.EventHandler(this.cmbFamilia_SelectedValueChanged);
                this.cmbFamilia_SelectedValueChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void CargarIVASucursal()
        {
            try
            {

                /*SucursalNegocio suc = new SucursalNegocio();
                Ivasucursal = suc.ObtenerIvaSucursal(Comun.conexion, Comun.id_sucursal);

    */

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ConsultaProductos()
        {
            try
            {
                VentaProductos ventaProductos = new VentaProductos();
                VentaProductosNegocio ventaProductosNegocio = new VentaProductosNegocio();
                //Filtros para la busqueda de productos 
                ventaProductos.IDSucursal = Comun.id_sucursal;
                ventaProductos.IDFamilia = Convert.ToInt32(this.cmbFamilia.SelectedValue.ToString());
                ventaProductos.NombreProducto = this.txt_fNombre.Text.Trim();
                ventaProductos.IDCodigoEan = this.txt_fCB.Text.Trim();
                ventaProductos.StrCnx = Comun.conexion;
                ventaProductos.listaDetalle = new List<VentaProductos>();
                ventaProductosNegocio.ConsultaProductos(ventaProductos);
                this.panelProductos.Controls.Clear();
                int posX = 3, posY = 4, totalProductos = ventaProductos.listaDetalle.Count();
                for (int i = 1; i <= totalProductos; i++)
                {
                    for (int j = 0; j <= 4; j++)
                    {
                        if (i <= totalProductos && j < 4)
                        {
                            string nombreCtrl = string.Format("icon_Creativa{0}", i);
                            this.ImagenProductos(nombreCtrl, posX, posY, i - 1, ventaProductos.listaDetalle);
                            posX += 46;
                            i++;
                        }
                    }
                    i--;
                    posX = 3; posY += 60;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void DgvProductosAgregar(Object sender, EventArgs e)
        {
            try
            {
                Control ctrlImagen = (Control)sender;
                Icon_Creativa find_IconCreativa = (Icon_Creativa)this.Controls.Find(ctrlImagen.Tag.ToString(), true)[0];
                this.txtNombreCorto.Text = find_IconCreativa.pNombre;
                this.txtPrecio.Text = string.Format("{0:C2}", find_IconCreativa.pPrecio);
                //this.txtCantidadMayoreo.Text = find_IconCreativa.pcantidadMayoreo.ToString();
                //this.txtPrecioMayoreo.Text = string.Format("{0:C2}", find_IconCreativa.pPrecioMayoreo);
                frm_PedirCantidadProducto cantidad = new frm_PedirCantidadProducto();
                cantidad.ShowDialog();
                if (cantidad.DialogResult == DialogResult.OK)
                {
                    int cant = 0;
                    if (int.TryParse(cantidad.TextotxtCantidad, out cant))
                    {
                        if (cant > 0)
                        {
                            VentaProductos producto = new VentaProductos();
                            VentaProductosNegocio vn = new VentaProductosNegocio();
                            producto.IDVenta = GetIDTabSeleccionado();
                            if (!string.IsNullOrEmpty(producto.IDVenta))
                            {
                                producto.IDSucursal = Comun.id_sucursal;
                                producto.IDCaja = Comun.id_caja;
                                producto.IDVendedor = Comun.id_u;
                                producto.IDCajero = Comun.id_u;
                                producto.StrCnx = Comun.conexion;
                                producto.IDProducto = find_IconCreativa.pIDProducto;
                                //producto.IDTallaRopa = find_IconCreativa.pIDTalla;
                                //producto.IDColorRopa = find_IconCreativa.pIDColor;
                                producto.IDCodigoEan = find_IconCreativa.pCodBarra;
                                producto.Precio = (decimal)find_IconCreativa.pPrecio;
                                producto.CantidadVenta = cant;
                                TabPage tabSeleccionado = new TabPage();
                                if (tabControl1.TabPages.Count > 0)
                                    tabSeleccionado = this.tabControl1.SelectedTab;
                                foreach (Venta venta in ventasPendientes)
                                {
                                    if (venta.id_ventaTemporal == tabSeleccionado.Name)
                                    {
                                        bandPrecioMayoreo = venta.bandPrecioMayoreo;
                                        break;
                                    }
                                }
                                producto.BandPrecioMayoreo = bandPrecioMayoreo;
                                vn.AgregarProductoVentaTmp(producto);
                                if (producto.validador == 0)
                                {
                                    ProductoDetalle datosProd = new ProductoDetalle();
                                    datosProd.id_producto = producto.IDProducto;
                                    datosProd.id_tallaRopa = producto.IDTallaRopa;
                                    datosProd.id_colorRopa = producto.IDColorRopa;
                                    datosProd.id_sucursal = producto.IDSucursal;
                                    datosProd.conexion = Comun.conexion;
                                    datosProd = vn.obtenerExistenciaProducto(datosProd);
                                    find_IconCreativa.pCantidad = datosProd.existencia;
                                    DgvProductosBindingSource(producto);
                                }
                                else
                                {
                                    this.MostrarMensajeErrorAgregarProducto(producto.validador);
                                }
                                bandPrecioMayoreo = false;
                            }
                            else
                            {
                                MessageBox.Show(this, "No se puede agregar producto.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                            MessageBox.Show(this, "La cantidad no puede ser 0", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                        MessageBox.Show(this, "Ingrese un dato válido", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                cantidad.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void MostrarMensajeErrorAgregarProducto(int error)
        {
            try
            {
                string mensaje = "";
                switch (error)
                {
                    case 51000:
                        mensaje = "No se pudo agregar el producto. Comuníquese a Soporte Técnico. Código: 51000. ";
                        break;
                    case 52000:
                        mensaje = "No se pudo agregar el producto. Comuníquese a Soporte Técnico. Código: 52000. ";
                        break;
                    case 53000:
                        mensaje = "El producto no está disponible para ésta Sucursal. Código: 53000.";
                        break;
                    case 54000:
                        mensaje = "No hay existencia suficiente del producto para ésta Sucursal. ";
                        break;
                    default:
                        mensaje = "No se pudo agregar el producto. Comuníquese a Soporte Técnico. ";
                        break;
                }
                MessageBox.Show(this, mensaje, "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void DgvProductosBindingSource(VentaProductos datos)
        {
            try
            {
                VentaProductosNegocio vn = new VentaProductosNegocio();
                DataGridView dgvSeleccionado = new DataGridView();
                TabPage tabSeleccionado = new TabPage();
                if (tabControl1.TabPages.Count > 0)
                    tabSeleccionado = this.tabControl1.SelectedTab;
                dgvSeleccionado = this.findDGV(tabSeleccionado);
                datos.IDSucursal = Comun.id_sucursal;
                datos.StrCnx = Comun.conexion;
                datos.IDVenta = tabSeleccionado.Name;
                if (!string.IsNullOrEmpty(dgvSeleccionado.Name))
                {
                    List<VentaProductos> detalleVenta = vn.ObtenerDetalleVentaPendiente(datos);
                    dgvSeleccionado.DataSource = detalleVenta;
                    foreach (Venta venta in ventasPendientes)
                    {
                        if (venta.id_ventaTemporal == tabSeleccionado.Name)
                        {
                            venta.productosVenta = detalleVenta;
                            break;
                        }
                    }
                    this.CalcularTotal(datos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ImagenProductos(string nombreCtrl, int posX, int posY, int index, List<VentaProductos> List)
        {
            try
            {
                Icon_Creativa icon_Creativa = new Icon_Creativa();
                icon_Creativa.BackColor = System.Drawing.Color.Transparent;
                icon_Creativa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                icon_Creativa.Location = new System.Drawing.Point(posX, posY);
                icon_Creativa.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
                icon_Creativa.Name = nombreCtrl;
                icon_Creativa.pImgTag = nombreCtrl;
                icon_Creativa.pCantidad = List[index].Existencia;
                icon_Creativa.pNombre = List[index].NombreProducto;
                icon_Creativa.pNombrecorto = List[index].NombreProducto;
                icon_Creativa.pPrecio = (float)List[index].Precio;
                //icon_Creativa.pPrecioMayoreo = List[index].PrecioMayoreo;
                //icon_Creativa.pcantidadMayoreo = List[index].CantidadMayoreo;
                icon_Creativa.pCodBarra = List[index].IDCodigoEan;
                icon_Creativa.pIDProducto = List[index].IDProducto;
                //icon_Creativa.pIDTalla = List[index].IDTallaRopa;
                //icon_Creativa.pIDColor = List[index].IDColorRopa;
                //icon_Creativa.pIva = Convert.ToSingle(List[index].PorcentajeIva);
                //icon_Creativa.pIvaMayoreo = Convert.ToSingle(List[index].PorcentajeIvaMayoreo);
                icon_Creativa.Size = new System.Drawing.Size(44, 58);
                icon_Creativa.TabIndex = index;
                try
                {
                    icon_Creativa.pImgIcon = Image.FromFile(Application.StartupPath + @"\Resources\Productos\" + List[index].IDProducto.ToString() + ".png");
                }
                catch (Exception)
                {
                    if (List[index].IDTipoProducto == 1)
                        icon_Creativa.pImgIcon = PuntodeVentaTintoreria.Properties.Resources.icono_productos;
                    else if (List[index].IDTipoProducto == 2)
                        icon_Creativa.pImgIcon = PuntodeVentaTintoreria.Properties.Resources.icono_propa;
                    else
                        icon_Creativa.pImgIcon = PuntodeVentaTintoreria.Properties.Resources.icono_otroscargos;
                }
                icon_Creativa.DoubleClick += new Icon_Creativa.DoubleClickEventArgs(this.icon_Creativa_DoubleClick);
                icon_Creativa.MouseHover += new Icon_Creativa.MouseHoverEventArgs(this.icon_Creativa_MouseHover);
                this.panelProductos.Controls.Add(icon_Creativa);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void LimpiarVentaProductos()
        {
            try
            {
                this.txtSubtotal.Text = string.Format("{0:F2}", 0);
                this.txtIva.Text = string.Format("{0:F2}", 0);
                this.txtDescuento.Text = string.Format("{0:F2}", 0);
                this.txtMonedero.Text = string.Format("{0:F2}", 0);
                this.txtPuntos.Text = "0";
                this.txtTotal.Text = string.Format("{0:F2}", 0);
                this.txtPrecio.Text = string.Format("{0:F2}", 0);
                this.txtNombreCorto.Text = "";
                this.txtCliente.Text = "";
                this.txtnomCliente.Text = "";
                this.txtMonederoCliente.Text = string.Format("{0:F2}", 0);
                this.txtPuntosClientes.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void QuitarVenta(TabPage tab)
        {
            try
            {
                foreach (Venta venta in ventasPendientes)
                {
                    if (tab.Name == venta.id_ventaTemporal)
                    {
                        this.ventasPendientes.Remove(venta);
                        this.tabControl1.TabPages.Remove(tab);
                        break;
                    }
                }
                if (ventasPendientes.Count == 0)
                {
                    VentaProductos nuevaVenta = AgregarVentaPendienteNueva();
                    Venta ventaPend = new Venta();
                    ventaPend.id_ventaTemporal = nuevaVenta.IDVenta;
                    ventaPend.textTab = nuevaVenta.nameTab;
                    ventaPend.cliente = new Cliente();
                    ventaPend.cliente.id_cliente = nuevaVenta.IDCliente;
                    ventaPend.idCliente = nuevaVenta.IDCliente;
                    ventaPend.vale = new Vales();
                    ventasPendientes.Add(ventaPend);
                    AgregarTabVenta(nuevaVenta);
                    nuevaVenta.StrCnx = Comun.conexion;
                    this.MostrarDatosCliente(nuevaVenta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void LlenarDatosCliente(Cliente datos)
        {
            try
            {
                if (string.IsNullOrEmpty(datos.id_cliente))
                {
                    this.txtCliente.Text = "";
                    this.txtMonederoCliente.Text = string.Format("{0:C2}", 0.0);
                    this.txtPuntosClientes.Text = "0";
                    this.txtnomCliente.Text = "";
                }
                else
                {
                    this.txtCliente.Text = datos.codigoMonedero;
                    this.txtMonederoCliente.Text = string.Format("{0:C2}", datos.credenciales.monedero);
                    this.txtPuntosClientes.Text = datos.credenciales.puntos.ToString();
                    this.txtnomCliente.Text = datos.credenciales.nombreCompleto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void AsignarClienteListaVentas(Cliente datos)
        {
            try
            {
                if (this.tabControl1.TabPages.Count > 0)
                {
                    if (this.tabControl1.SelectedTab != null)
                    {
                        foreach (Venta venta in this.ventasPendientes)
                        {
                            if (venta.id_ventaTemporal == this.tabControl1.SelectedTab.Name)
                            {
                                venta.cliente = datos;
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void PermitirSoloNumeros(KeyPressEventArgs e)
        {

            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                    if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;

            }

        }
        private void PermitirSoloNumerosDecimales(KeyPressEventArgs e, string cadena)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                  if (Char.IsControl(e.KeyChar))
            {
                if (e.KeyChar != 8)
                    e.Handled = true;
                else
                    e.Handled = false;
            }
            else
            {
                if (e.KeyChar == (char)'.')
                {
                    if (cadena.IndexOf('.') == -1)
                        e.Handled = false;
                    else
                        e.Handled = true;
                }
                else
                {
                    e.Handled = true;
                }
            }

        }
        private void PermitirSoloLetras(KeyPressEventArgs e)
        {

            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (e.KeyChar == (char)Keys.Space)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }

        }
        private float Truncate(float? value, int length)
        {


            decimal val = Convert.ToDecimal(value);
            return (float)decimal.Round(val, length);

        }
        private string GetIDTabSeleccionado()
        {

            TabPage tabSeleccionado = new TabPage();
            if (this.tabControl1.TabPages.Count > 0)
            {
                tabSeleccionado = this.tabControl1.SelectedTab;
            }
            return tabSeleccionado.Name;

        }
        private void btnDescProd_Click(object sender, EventArgs e)
        {

        }
        private DataGridView findDGV(TabPage tab)
        {
            DataGridView dgv = new DataGridView();
            foreach (Control control in tab.Controls.Find("DGV" + tab.Name, true))
            {
                dgv = (DataGridView)control;
            }
            return dgv;
        }
        private void agregarColumnasDataGridView(DataGridView dgv, int columnas)
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgv.RowHeadersWidth = 60;
            dgv.ColumnHeadersHeight = 31;

            dgv.BorderStyle = BorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(5, 5, 5, 5);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(227, 228, 232);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Muli", 10F);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 249, 251);
            dgv.RowsDefaultCellStyle.BackColor = Color.FromArgb(242, 242, 242);
            dgv.RowHeadersVisible = false;

            dgv.EnableHeadersVisualStyles = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.BackgroundColor = System.Drawing.Color.FromArgb(249, 249, 251);
            dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(227, 228, 232);
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Muli", 8.25F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(102, 102, 102);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            for (int i = 0; i < columnas; i++)
            {
                DataGridViewColumn columT = new DataGridViewColumn();
                DataGridViewCell cell = new DataGridViewTextBoxCell();
                columT.CellTemplate = cell;
                dgv.Columns.Add(columT);
            }
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        }
        private void SetFormatDgv(DataGridView dgv)
        {
            try
            {
                dgv.Columns[dgv.Name + "Precio"].DefaultCellStyle.Format = "c";
                dgv.Columns[dgv.Name + "IVA"].DefaultCellStyle.Format = "c";
                dgv.Columns[dgv.Name + "Descuento"].DefaultCellStyle.Format = "c";
                dgv.Columns[dgv.Name + "SubTotal"].DefaultCellStyle.Format = "c";
                dgv.Columns[dgv.Name + "Total"].DefaultCellStyle.Format = "c";
                dgv.Columns[dgv.Name + "Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns[dgv.Name + "IVA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns[dgv.Name + "Descuento"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns[dgv.Name + "SubTotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns[dgv.Name + "Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns[dgv.Name + "Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgv.Columns[dgv.Name + "IDProducto"].Visible = false;
                dgv.Columns[dgv.Name + "IDTallaRopa"].Visible = false;
                dgv.Columns[dgv.Name + "IDColorRopa"].Visible = false;
                dgv.Columns[dgv.Name + "IDCodigoEan"].Visible = false;
                dgv.Columns[dgv.Name + "Descripcion"].Visible = false;
                dgv.Columns[dgv.Name + "Monedero"].Visible = false;
                dgv.Columns[dgv.Name + "Puntos"].Visible = false;
                dgv.Columns[dgv.Name + "IDVentaDetalle"].Visible = false;

                dgv.Columns[dgv.Name + "IDProducto"].Width = 100;
                dgv.Columns[dgv.Name + "IDTallaRopa"].Width = 30;
                dgv.Columns[dgv.Name + "IDColorRopa"].Width = 30;
                dgv.Columns[dgv.Name + "Nombre"].Width = 300;
                dgv.Columns[dgv.Name + "IDCodigoEan"].Width = 100;
                dgv.Columns[dgv.Name + "Descripcion"].Width = 100;
                dgv.Columns[dgv.Name + "Precio"].Width = 90;
                dgv.Columns[dgv.Name + "Cantidad"].Width = 90;
                dgv.Columns[dgv.Name + "Subtotal"].Width = 90;
                dgv.Columns[dgv.Name + "Iva"].Width = 90;
                dgv.Columns[dgv.Name + "Descuento"].Width = 90;
                dgv.Columns[dgv.Name + "Total"].Width = 90;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void MostrarDatosCliente(VentaProductos datos)
        {
            try
            {
                ClienteNegocio cn = new ClienteNegocio();
                Cliente cliente = new Cliente();
                cliente = cn.ObtenerClienteXIDVenta(datos);
                this.LlenarDatosCliente(cliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private int validarVenta()
        {
            try
            {
                float montototal = 0;
                List<VentaProductos> listaPr = new List<VentaProductos>();
                Cliente cliente = new Cliente();
                if (tabControl1.TabPages.Count > 0)
                {
                    if (tabControl1.SelectedTab != null)
                    {
                        foreach (Venta venta in this.ventasPendientes)
                        {
                            if (venta.id_ventaTemporal == tabControl1.SelectedTab.Name)
                            {
                                listaPr = venta.productosVenta;
                                cliente = venta.cliente;
                                break;
                            }
                        }
                    }
                }
                if (listaPr.Count <= 0)
                {
                    return 9;
                }
                if (!float.TryParse(this.txtTotal.Text, NumberStyles.Currency, provider, out montototal))
                {
                    this.txtTotal.Focus();
                    return 3;
                }
                if (string.IsNullOrEmpty(cliente.id_cliente))
                    return 10;
                if (montototal < 0)
                {
                    return 8;
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        private void AbrirCajon()
        {
            try
            {
                PrinterSettings ps = new PrinterSettings();
                ps.PrinterName = string.IsNullOrEmpty(Comun.namePrinter) ? "" : Comun.namePrinter;
                byte[] codigo = new byte[] { 27, 112, 48, 50, 250 };
                if (ps.IsValid)
                    RawPrinterHelper.SendStringToPrinter(ps.PrinterName, System.Text.ASCIIEncoding.ASCII.GetString(codigo));
                else
                    throw new Exception("No se pudo conectar con la impresora.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void MostrarDatos(string id)
        {
            try
            {
                VentaProductos datos = new VentaProductos();
                datos.IDSucursal = Comun.id_sucursal;
                datos.StrCnx = Comun.conexion;
                datos.IDVenta = id;
                this.MostrarDatosCliente(datos);
                this.CalcularTotal(datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void actualizarExistencia(Producto producto)
        {
            try
            {
                foreach (Control aux in this.panelProductos.Controls)
                {
                    if (aux.Name.Length >= "icon_Creativa".Length)
                    {
                        if (aux.Name.Substring(0, "icon_Creativa".Length) == "icon_Creativa")
                        {
                            Icon_Creativa find_IconCreativa = (Icon_Creativa)aux;
                            //if (find_IconCreativa.pIDProducto == producto.id_producto && find_IconCreativa.pIDTalla == producto.productoDetalle.id_tallaRopa && find_IconCreativa.pIDColor == producto.productoDetalle.id_colorRopa)
                            //{
                            //    find_IconCreativa.pCantidad = producto.productoDetalle.existencia;
                            //    break;
                            //}
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #region Métodos de configuración de x DataGridView
        private void EstablecerPropiedadesGridHome(DataGridView actual)
        {
            try
            {
                // Arreglos con los datos de encabezado, propiedad de enlace y nombre de columna.
                var Headertexts = new List<string>  {   "IDProducto", "IDTallaRopa", "IDColorRopa", "Producto", "IDCodigoEAN", "Descripción", "Precio",
                                                        "Cantidad", "Subtotal", "Iva", "Descuento", "Total", "Monedero", "Puntos","IDVentadetalle" };

                var Data = new List<string>         {   "IDProducto", "IDTallaRopa", "IDColorRopa", "NombreProducto", "IDCodigoEAN", "Descripcion", "Precio",
                                                        "CantidadVenta", "Subtotal", "Iva", "Descuento", "Total", "Monedero",  "Puntos", "IDVentadetalle"};

                var Names = new List<string>        {  actual.Name+ "IDProducto", actual.Name+ "IDTallaRopa", actual.Name+ "IDColorRopa", actual.Name + "Nombre", actual.Name + "IDCodigoEan",
                                                       actual.Name + "Descripcion", actual.Name + "Precio", actual.Name + "Cantidad",
                                                       actual.Name + "Subtotal", actual.Name + "Iva", actual.Name + "Descuento",
                                                       actual.Name + "Total", actual.Name + "Monedero", actual.Name + "Puntos", actual.Name + "IDVentadetalle" };
                // Establecer las propiedades
                this.RecorrerForGridHome(Headertexts, 1, actual);
                this.RecorrerForGridHome(Names, 2, actual);
                this.RecorrerForGridHome(Data, 3, actual);
                actual.AutoSize = true;
                actual.AutoGenerateColumns = false;
                actual.AllowUserToAddRows = false;
                actual.AllowUserToDeleteRows = false;
                actual.AllowUserToOrderColumns = false;
                actual.AllowUserToResizeColumns = false;
                actual.MultiSelect = false;
                actual.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                actual.ReadOnly = true;
                this.SetFormatDgv(actual);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void DataPropertyNameGridHome(int numColum, string nombre, DataGridView actual)
        {
            try
            {
                actual.Columns[numColum].DataPropertyName = nombre;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void RecorrerForGridHome(List<string> campos, int opcion, DataGridView actual)
        {
            try
            {
                for (var index = 0; index < campos.Count; index++)
                {
                    if (opcion == 1)
                        this.HeaderTextGridHome(index, campos[index], actual);
                    else if (opcion == 2)
                        this.NameGridHome(index, campos[index], actual);
                    else if (opcion == 3)
                        this.DataPropertyNameGridHome(index, campos[index], actual);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void HeaderTextGridHome(int numColum, string nombre, DataGridView actual)
        {
            try
            {
                actual.Columns[numColum].HeaderText = nombre;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void NameGridHome(int numColum, string nombre, DataGridView actual)
        {
            try
            {
                actual.Columns[numColum].Name = nombre;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void mensajeErrorPago(int i)
        {
            try
            {
                string mensaje = "";
                switch (i)
                {
                    case 2:
                        mensaje = "El pago no cubre el total";
                        break;
                    case 1:
                        mensaje = "No cuenta con suficiente monedero";
                        break;
                    case 3:
                        mensaje = "Dato no válido";
                        break;
                    case 8:
                        mensaje = "El total no puede ser negativo. Revise la venta.";
                        break;
                    case 9:
                        mensaje = "No hay productos en la venta";
                        break;
                    case 10:
                        mensaje = "Introduzca un cliente";
                        break;
                    default:
                        mensaje = "Ocurrió un error. Comuníquese a Soporte.";
                        break;
                }
                MessageBox.Show(this, mensaje, "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private int validarPago(float total, float pago, float monedero, float moncliente)
        {

            if (total <= pago)
                if (monedero <= moncliente)
                    return 0;
                else
                    return 1;
            else
                return 2;


        }
        private void LiberarVentasNoGuardadas()
        {
            try
            {
                VentaProductosNegocio vpn = new VentaProductosNegocio();
                VentaProductos datos = new VentaProductos();
                datos.StrCnx = Comun.conexion;
                datos.IDCaja = Comun.id_caja;
                datos.IDSucursal = Comun.id_sucursal;
                vpn.liberarVentasNoGuardadas(datos);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private bool LiberarVentaTab()
        {
            try
            {
                VentaProductosNegocio vpn = new VentaProductosNegocio();
                VentaProductos datos = new VentaProductos();
                datos.StrCnx = Comun.conexion;
                datos.IDCaja = Comun.id_caja;
                datos.IDSucursal = Comun.id_sucursal;
                datos.IDVenta = this.tabControl1.SelectedTab.Name;
                return vpn.liberarVentaTab(datos);
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        #endregion
        #region Validaciones
        private void txt_fNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txt_fNombre_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyValue == 86)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtCliente_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show(this, "No puedes copiar o pegar", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        #endregion
        #region Eventos
        private void btnPromociones_Click(object sender, EventArgs e)
        {
            try
            {
                VentaProductos promociones = new VentaProductos();
                this.ConsultaVale();
                this.DgvProductosBindingSource(promociones);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.LiberarVentasNoGuardadas();
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDescuentos_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tabControl1.TabPages.Count > 0)
                {
                    if (this.tabControl1.SelectedTab != null)
                    {
                        frm_PedirAutorizacion autorizar = new frm_PedirAutorizacion();
                        autorizar.ShowDialog();
                        if (autorizar.DialogResult == DialogResult.OK)
                        {
                            frm_IngresarDescuento frmt = new frm_IngresarDescuento(2);
                            frmt.montomax = decimal.Parse(this.txtTotal.Text, NumberStyles.Currency);
                            frmt.ShowDialog();
                            if (frmt.DialogResult == DialogResult.OK)
                            {
                                VentaProductos descuento = new VentaProductos();
                                VentaProductosNegocio vn = new VentaProductosNegocio();
                                descuento.StrCnx = Comun.conexion;
                                descuento.IDTipoProducto = 4;
                                descuento.NombreProducto = "Desc. Gen.: " + frmt.motivo;
                                descuento.observaciones = frmt.motivo;
                                descuento.Descuento = frmt.monto;
                                descuento.Precio = descuento.Descuento;
                                descuento.Iva = 0;
                                descuento.PorcentajeIva = 0;
                                descuento.Subtotal = 0;
                                descuento.Total = 0;
                                descuento.CantidadVenta = 1;
                                descuento.IDSucursal = Comun.id_sucursal;
                                descuento.IDVenta = this.tabControl1.SelectedTab.Name;
                                descuento.IDCaja = Comun.id_caja;
                                descuento.IDCajero = Comun.id_u;
                                descuento.IDVendedor = Comun.id_u;
                                //vn.insertarProductoGenerico(descuento);
                                vn.insertarProductoGenerico2(descuento);
                                vn.AgregarProductoVentaTmp(descuento);
                                this.DgvProductosBindingSource(descuento);
                            }
                            frmt.Dispose();
                        }
                        autorizar.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProdGen_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.tabControl1.TabPages.Count > 0)
                {
                    if (this.tabControl1.SelectedTab != null)
                    {
                        frm_IngresarProductoGenerico fpg = new frm_IngresarProductoGenerico();
                        fpg.ShowDialog();
                        if (fpg.DialogResult == DialogResult.OK)
                        {
                            VentaProductos prodGen = new VentaProductos();
                            VentaProductosNegocio vpn = new VentaProductosNegocio();
                            prodGen.NombreProducto = "Prod. Gen. : " + fpg.nombreproducto;
                            prodGen.observaciones = fpg.nombreproducto;
                            prodGen.Descuento = 0;
                            prodGen.Iva = 0;
                            prodGen.PorcentajeIva = 0;
                            prodGen.Subtotal = (decimal)(fpg.cantidad * fpg.monto);
                            prodGen.Total = prodGen.Subtotal - prodGen.Descuento;
                            prodGen.CantidadVenta = fpg.cantidad;
                            prodGen.Precio = fpg.monto;
                            prodGen.IDTipoProducto = 3;
                            prodGen.IDCajero = Comun.id_u;
                            prodGen.StrCnx = Comun.conexion;
                            prodGen.IDSucursal = Comun.id_sucursal;
                            prodGen.IDVenta = this.tabControl1.SelectedTab.Name;
                            prodGen.IDCaja = Comun.id_caja;
                            prodGen.IDCajero = Comun.id_u;
                            prodGen.IDVendedor = Comun.id_u;
                            //vpn.insertarProductoGenerico(prodGen);
                            vpn.insertarProductoGenerico2(prodGen);
                            vpn.AgregarProductoVentaTmp(prodGen);
                            this.DgvProductosBindingSource(prodGen);
                        }
                        fpg.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrecioMayoreo_Click(object sender, EventArgs e)
        {
            try
            {
                frm_PedirAutorizacion autorizar = new frm_PedirAutorizacion();
                autorizar.ShowDialog();
                autorizar.Dispose();
                if (autorizar.DialogResult == DialogResult.OK)
                {
                    TabPage tabSeleccionado = new TabPage();
                    if (tabControl1.TabPages.Count > 0)
                        tabSeleccionado = this.tabControl1.SelectedTab;
                    foreach (Venta venta in ventasPendientes)
                    {
                        if (venta.id_ventaTemporal == tabSeleccionado.Name)
                        {
                            venta.bandPrecioMayoreo = true;
                            break;
                        }
                    }
                    VentaProductos venta_mayoreo = new VentaProductos();
                    venta_mayoreo.BandPrecioMayoreo = true;
                    venta_mayoreo.StrCnx = Comun.conexion;
                    VentaProductosNegocio vn = new VentaProductosNegocio();
                    venta_mayoreo.IDVenta = GetIDTabSeleccionado();
                    venta_mayoreo.IDSucursal = Comun.id_sucursal;
                    vn.CambiarPrecioMayoreo(venta_mayoreo);
                    this.DgvProductosBindingSource(venta_mayoreo);
                    this.bandPrecioMayoreo = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            try
            {
                int Verificador = -1;
                if (this.tabControl1.TabPages.Count > 0)
                {
                    if (this.tabControl1.SelectedTab != null)
                    {
                        int aux = this.validarVenta();
                        if (aux == 0)
                        {
                            frm_Pagos frmC = new frm_Pagos(decimal.Parse(this.txtTotal.Text, NumberStyles.Currency), decimal.Parse(this.txtTotal.Text, NumberStyles.Currency), 0, decimal.Parse(this.txtMonederoCliente.Text, NumberStyles.Currency), this.txtnomCliente.Text, decimal.Parse(this.txtMonedero.Text, NumberStyles.Currency),1);
                            frmC.ShowDialog();
                            if (frmC.DialogResult == DialogResult.OK)
                            {
                                VentaProductos ventaProductos = new VentaProductos();
                                VentaProductosNegocio vn = new VentaProductosNegocio();
                                List<VentaProductos> productosVendidos = new List<VentaProductos>();
                                Cliente cliente = new Cliente();
                                ClienteNegocio cn = new ClienteNegocio();
                                foreach (Venta venta in this.ventasPendientes)
                                {
                                    if (venta.id_ventaTemporal == this.tabControl1.SelectedTab.Name)
                                    {
                                        productosVendidos = venta.productosVenta;
                                        cliente = venta.cliente;
                                        ventaProductos.Vale = venta.vale;
                                        break;
                                    }
                                }
                                ventaProductos.ventadetalle = new DataTable();
                                ventaProductos.ventadetalle.Columns.Add("id_producto", typeof(string));
                                ventaProductos.ventadetalle.Columns.Add("id_tallaRopa", typeof(int));
                                ventaProductos.ventadetalle.Columns.Add("id_colorRopa", typeof(int));
                                ventaProductos.ventadetalle.Columns.Add("nombre_producto", typeof(string));
                                ventaProductos.ventadetalle.Columns.Add("id_codigoEan", typeof(string));
                                ventaProductos.ventadetalle.Columns.Add("descripcion", typeof(string));
                                ventaProductos.ventadetalle.Columns.Add("precio", typeof(float));
                                ventaProductos.ventadetalle.Columns.Add("cantidad_venta", typeof(int));
                                ventaProductos.ventadetalle.Columns.Add("subtotal", typeof(float));
                                ventaProductos.ventadetalle.Columns.Add("descuento", typeof(float));
                                ventaProductos.ventadetalle.Columns.Add("iva", typeof(float));
                                ventaProductos.ventadetalle.Columns.Add("total", typeof(float));
                                ventaProductos.ventadetalle.Columns.Add("monedero", typeof(float));
                                ventaProductos.ventadetalle.Columns.Add("puntos", typeof(int));
                                if (productosVendidos.Count > 0)
                                {
                                    foreach (VentaProductos producto in productosVendidos)
                                    {
                                        ventaProductos.ventadetalle.Rows.Add(new Object[] {
                                            producto.IDProducto,
                                            producto.IDTallaRopa,
                                            producto.IDColorRopa,
                                            producto.NombreProducto,
                                            producto.IDCodigoEan,
                                            producto.Descripcion,
                                            producto.Precio,
                                            producto.CantidadVenta,
                                            producto.Subtotal,
                                            producto.Descuento,
                                            producto.Iva,
                                            producto.Total,
                                            producto.Monedero,
                                            producto.puntos
                                        });

                                        ventaProductos.Subtotal += producto.Subtotal;
                                        ventaProductos.Descuento += producto.Descuento;
                                        ventaProductos.Iva += producto.Iva;
                                        ventaProductos.Total += producto.Total;
                                        ventaProductos.Monedero += (float)producto.Monedero;
                                        ventaProductos.puntos += (int)producto.puntos;
                                    }
                                }


                                ventaProductos.PagoEfectivo = frmC.getPagoEfectivo();
                                ventaProductos.PagoMonedero = frmC.getPagoMonedero();
                                ventaProductos.PagoTarjeta = frmC.getPagoTarjeta();
                                ventaProductos.PagoTransferencia = frmC.getPagoTransferencia();
                                ventaProductos.Pago = ventaProductos.PagoEfectivo + ventaProductos.PagoMonedero + ventaProductos.PagoTarjeta + ventaProductos.PagoTransferencia;
                                ventaProductos.Cambio = frmC.getCambio();

                                if (ventaProductos.PagoMonedero > 0 || ventaProductos.PagoTarjeta > 0 || ventaProductos.PagoTransferencia > 0)
                                    ventaProductos.banBloqueoMultipleFormasPago = true;

                                ventaProductos.IDSucursal = Comun.id_sucursal;
                                ventaProductos.IDVenta = this.tabControl1.SelectedTab.Name;
                                ventaProductos.IDCliente = cliente.id_cliente;
                                ventaProductos.IDCaja = Comun.id_caja;
                                ventaProductos.IDVendedor = Comun.id_u;
                                ventaProductos.IDCajero = Comun.id_u;
                                ventaProductos.IDTipoVenta = 1;
                                ventaProductos.IDStatus = 2;
                                ventaProductos.Monedero = float.Parse(this.txtMonedero.Text, NumberStyles.Currency);
                                ventaProductos.puntos = int.Parse(this.txtPuntos.Text, NumberStyles.Currency);

                                ventaProductos.DatosTarjeta = new DataTable();
                                ventaProductos.DatosTarjeta.Columns.Add("autorizacion", typeof(string));
                                ventaProductos.DatosTarjeta.Columns.Add("tipoDocumento", typeof(string));
                                ventaProductos.DatosTarjeta.Columns.Add("folioDNI", typeof(string));
                                ventaProductos.DatosTarjeta.Columns.Add("numTarjeta", typeof(string));
                                ventaProductos.DatosTarjeta.Columns.Add("id_banco", typeof(int));
                                ventaProductos.DatosTarjeta.Columns.Add("monto", typeof(float));

                                if (ventaProductos.PagoTarjeta > 0)
                                {
                                    if (frmC.getDatosTarjeta() != null)
                                    {
                                        FormaPago DatosPagoTarjeta = frmC.getDatosTarjeta();
                                        ventaProductos.DatosTarjeta.Rows.Add(
                                            new Object[] {
                                        DatosPagoTarjeta.autorizacion,
                                        DatosPagoTarjeta.tipoDocumento != null ? DatosPagoTarjeta.tipoDocumento.id_tipoDocumento : string.Empty,
                                        DatosPagoTarjeta.folioIFE,
                                        DatosPagoTarjeta.numtarjeta,
                                        DatosPagoTarjeta.banco != null ? DatosPagoTarjeta.banco.idBanco : 0,
                                        DatosPagoTarjeta.monto});
                                    }
                                }

                                ventaProductos.DatosTransferencia = new DataTable();
                                ventaProductos.DatosTransferencia.Columns.Add("autorizacion", typeof(string));
                                ventaProductos.DatosTransferencia.Columns.Add("id_banco", typeof(int));
                                ventaProductos.DatosTransferencia.Columns.Add("monto", typeof(float));

                                if (ventaProductos.PagoTransferencia > 0)
                                {
                                    if (frmC.getDatosTransferencia() != null)
                                    {
                                        FormaPago DatosPagoTransferencia = frmC.getDatosTransferencia();
                                        ventaProductos.DatosTransferencia.Rows.Add(
                                            new Object[] {
                                        DatosPagoTransferencia.autorizacion,
                                        DatosPagoTransferencia.banco != null ? DatosPagoTransferencia.banco.idBanco : 0,
                                        DatosPagoTransferencia.monto});
                                    }
                                }

                                ventaProductos.StrCnx = Comun.conexion;
                                vn.InsertarProductos(ref Verificador, ref ventaProductos, ref productosVendidos, cliente);

                                try
                                {
                                    this.AbrirCajon();
                                    Ticket_Impresion impresion = new Ticket_Impresion(1, ventaProductos);
                                    impresion.imprimirTicket();
                                    MessageBox.Show(this, "!!Venta exitosa!!!", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(this, "!!Venta exitosa!!! - No se pudo imprimir el Ticket. " + ex.Message, "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                finally
                                {
                                    this.LimpiarVentaProductos();
                                    this.QuitarVenta(this.tabControl1.SelectedTab);
                                }
                            }
                        }
                        else
                        {
                            this.mensajeErrorPago(aux);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       /* private void btnVender_Click(object sender, EventArgs e)
        {
            try
            {
                int Verificador = -1;
                if (this.tabControl1.TabPages.Count > 0)
                {
                    if (this.tabControl1.SelectedTab != null)
                    {
                        int aux = this.validarVenta();
                        if (aux == 0)
                        {
                            frm_Pagos frmC = new frm_Pagos(float.Parse(this.txtTotal.Text, NumberStyles.Currency), float.Parse(this.txtTotal.Text, NumberStyles.Currency), 0.0F, float.Parse(this.txtMonederoCliente.Text, NumberStyles.Currency), this.txtnomCliente.Text, float.Parse(this.txtMonedero.Text, NumberStyles.Currency));
                            frmC.ShowDialog();
                            if (frmC.DialogResult == DialogResult.OK)
                            {
                                VentaProductos ventaProductos = new VentaProductos();
                                VentaProductosNegocio vn = new VentaProductosNegocio();
                                List<VentaProductos> productosVendidos = new List<VentaProductos>();
                                Cliente cliente = new Cliente();
                                ClienteNegocio cn = new ClienteNegocio();
                                foreach (Venta venta in this.ventasPendientes)
                                {
                                    if (venta.id_ventaTemporal == this.tabControl1.SelectedTab.Name)
                                    {
                                        productosVendidos = venta.productosVenta;
                                        cliente = venta.cliente;
                                        ventaProductos.Vale = venta.vale;
                                        break;
                                    }
                                }
                                ventaProductos.ventadetalle = new DataTable();
                                ventaProductos.ventadetalle.Columns.Add("id_producto", typeof(string));
                                ventaProductos.ventadetalle.Columns.Add("id_tallaRopa", typeof(int));
                                ventaProductos.ventadetalle.Columns.Add("id_colorRopa", typeof(int));
                                ventaProductos.ventadetalle.Columns.Add("nombre_producto", typeof(string));
                                ventaProductos.ventadetalle.Columns.Add("id_codigoEan", typeof(string));
                                ventaProductos.ventadetalle.Columns.Add("descripcion", typeof(string));
                                ventaProductos.ventadetalle.Columns.Add("precio", typeof(float));
                                ventaProductos.ventadetalle.Columns.Add("cantidad_venta", typeof(int));
                                ventaProductos.ventadetalle.Columns.Add("subtotal", typeof(float));
                                ventaProductos.ventadetalle.Columns.Add("descuento", typeof(float));
                                ventaProductos.ventadetalle.Columns.Add("iva", typeof(float));
                                ventaProductos.ventadetalle.Columns.Add("total", typeof(float));
                                ventaProductos.ventadetalle.Columns.Add("monedero", typeof(float));
                                ventaProductos.ventadetalle.Columns.Add("puntos", typeof(int));
                                if (productosVendidos.Count > 0)
                                {
                                    foreach (VentaProductos producto in productosVendidos)
                                    {
                                        ventaProductos.ventadetalle.Rows.Add(new Object[] {
                                            producto.IDProducto,
                                            producto.IDTallaRopa,
                                            producto.IDColorRopa,
                                            producto.NombreProducto,
                                            producto.IDCodigoEan,
                                            producto.Descripcion,
                                            producto.Precio,
                                            producto.CantidadVenta,
                                            producto.Subtotal,
                                            producto.Descuento,
                                            producto.Iva,
                                            producto.Total,
                                            producto.Monedero,
                                            producto.puntos
                                        });

                                        ventaProductos.Subtotal += (float)producto.Subtotal;
                                        ventaProductos.Descuento += (float)producto.Descuento;
                                        ventaProductos.Iva += (float)producto.Iva;
                                        ventaProductos.Total += (float)producto.Total;
                                        ventaProductos.Monedero += (float)producto.Monedero;
                                        ventaProductos.puntos += (int)producto.puntos;
                                    }
                                }


                                ventaProductos.PagoEfectivo = frmC.getPagoEfectivo();
                                ventaProductos.PagoMonedero = frmC.getPagoMonedero();
                                ventaProductos.PagoTarjeta = frmC.getPagoTarjeta();
                                ventaProductos.PagoTransferencia = frmC.getPagoTransferencia();
                                ventaProductos.Pago = ventaProductos.PagoEfectivo + ventaProductos.PagoMonedero + ventaProductos.PagoTarjeta + ventaProductos.PagoTransferencia;
                                ventaProductos.Cambio = frmC.getCambio();

                                if (ventaProductos.PagoMonedero > 0 || ventaProductos.PagoTarjeta > 0 || ventaProductos.PagoTransferencia > 0)
                                    ventaProductos.banBloqueoMultipleFormasPago = true;

                                ventaProductos.IDSucursal = Comun.id_sucursal;
                                ventaProductos.IDVenta = this.tabControl1.SelectedTab.Name;
                                ventaProductos.IDCliente = cliente.id_cliente;
                                ventaProductos.IDCaja = Comun.id_caja;
                                ventaProductos.IDVendedor = Comun.id_u;
                                ventaProductos.IDCajero = Comun.id_u;
                                ventaProductos.IDTipoVenta = 1;
                                ventaProductos.IDStatus = 2;
                                ventaProductos.Monedero = float.Parse(this.txtMonedero.Text, NumberStyles.Currency);
                                ventaProductos.puntos = int.Parse(this.txtPuntos.Text, NumberStyles.Currency);

                                ventaProductos.DatosTarjeta = new DataTable();
                                ventaProductos.DatosTarjeta.Columns.Add("autorizacion", typeof(string));
                                ventaProductos.DatosTarjeta.Columns.Add("tipoDocumento", typeof(string));
                                ventaProductos.DatosTarjeta.Columns.Add("folioDNI", typeof(string));
                                ventaProductos.DatosTarjeta.Columns.Add("numTarjeta", typeof(string));
                                ventaProductos.DatosTarjeta.Columns.Add("id_banco", typeof(int));
                                ventaProductos.DatosTarjeta.Columns.Add("monto", typeof(float));

                                if (ventaProductos.PagoTarjeta > 0)
                                {
                                    if (frmC.getDatosTarjeta() != null)
                                    {
                                        FormaPago DatosPagoTarjeta = frmC.getDatosTarjeta();
                                        ventaProductos.DatosTarjeta.Rows.Add(
                                            new Object[] {
                                        DatosPagoTarjeta.autorizacion,
                                        DatosPagoTarjeta.tipoDocumento != null ? DatosPagoTarjeta.tipoDocumento.id_tipoDocumento : string.Empty,
                                        DatosPagoTarjeta.folioIFE,
                                        DatosPagoTarjeta.numtarjeta,
                                        DatosPagoTarjeta.banco != null ? DatosPagoTarjeta.banco.idBanco : 0,
                                        DatosPagoTarjeta.monto});
                                    }
                                }

                                ventaProductos.DatosTransferencia = new DataTable();
                                ventaProductos.DatosTransferencia.Columns.Add("autorizacion", typeof(string));
                                ventaProductos.DatosTransferencia.Columns.Add("id_banco", typeof(int));
                                ventaProductos.DatosTransferencia.Columns.Add("monto", typeof(float));

                                if (ventaProductos.PagoTransferencia > 0)
                                {
                                    if (frmC.getDatosTransferencia() != null)
                                    {
                                        FormaPago DatosPagoTransferencia = frmC.getDatosTransferencia();
                                        ventaProductos.DatosTransferencia.Rows.Add(
                                            new Object[] {
                                        DatosPagoTransferencia.autorizacion,
                                        DatosPagoTransferencia.banco != null ? DatosPagoTransferencia.banco.idBanco : 0,
                                        DatosPagoTransferencia.monto});
                                    }
                                }

                                ventaProductos.StrCnx = Comun.conexion;
                                vn.InsertarProductos(ref Verificador, ref ventaProductos, ref productosVendidos, cliente);

                                try
                                {
                                    this.AbrirCajon();
                                    Ticket_Impresion impresion = new Ticket_Impresion(1, ventaProductos);
                                    impresion.imprimirTicket();
                                    MessageBox.Show(this, "!!Venta exitosa!!!", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(this, "!!Venta exitosa!!! - No se pudo imprimir el Ticket. " + ex.Message, "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                finally
                                {
                                    this.LimpiarVentaProductos();
                                    this.QuitarVenta(this.tabControl1.SelectedTab);
                                }
                            }
                        }
                        else
                        {
                            this.mensajeErrorPago(aux);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/
        #region Eventos V2.0
        private void txt_fCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                TextBox cbarra = (TextBox)sender;
                Validaciones val = new Validaciones();
                if (!string.IsNullOrEmpty(cbarra.Text))
                {
                    if (e.KeyChar == (Char)13)
                    {
                        this.AgregarProductoXIDEanCode(cbarra.Text);
                        this.txt_fCB.Text = string.Empty;
                        this.txt_fCB.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AgregarProductoXIDEanCode(string EANCode)
        {
            try
            {
                VentaProductos producto = new VentaProductos();
                VentaProductosNegocio vn = new VentaProductosNegocio();
                producto.IDVenta = GetIDTabSeleccionado();
                if (!string.IsNullOrEmpty(producto.IDVenta))
                {
                    producto.StrCnx = Comun.conexion;
                    producto.IDCodigoEan = EANCode;
                    producto.IDSucursal = Comun.id_sucursal;
                    Producto aux = vn.ObtenerProductoXIDEanCode(producto);
                    if (!string.IsNullOrEmpty(aux.id_producto))
                    {
                        producto.IDCaja = Comun.id_caja;
                        producto.IDVendedor = Comun.id_u;
                        producto.IDCajero = Comun.id_u;
                        producto.IDProducto = aux.id_producto;
                        producto.IDTallaRopa = aux.productoDetalle.id_tallaRopa;
                        producto.IDColorRopa = aux.productoDetalle.id_colorRopa;
                        producto.IDCodigoEan = aux.productoDetalle.id_prodxsuc;
                        producto.Precio = aux.productoDetalle.precio;
                        producto.CantidadVenta = 1;
                        TabPage tabSeleccionado = new TabPage();
                        if (tabControl1.TabPages.Count > 0)
                            tabSeleccionado = this.tabControl1.SelectedTab;
                        foreach (Venta venta in ventasPendientes)
                        {
                            if (venta.id_ventaTemporal == tabSeleccionado.Name)
                            {
                                bandPrecioMayoreo = venta.bandPrecioMayoreo;
                                break;
                            }
                        }
                        producto.BandPrecioMayoreo = bandPrecioMayoreo;
                        vn.AgregarProductoVentaTmp(producto);
                        if (producto.validador == 0)
                        {
                            Producto datosProd = new Producto();
                            datosProd.productoDetalle = new ProductoDetalle();
                            datosProd.id_producto = producto.IDProducto;
                            datosProd.productoDetalle.id_tallaRopa = producto.IDTallaRopa;
                            datosProd.productoDetalle.id_colorRopa = producto.IDColorRopa;
                            datosProd.productoDetalle.id_sucursal = producto.IDSucursal;
                            datosProd.conexion = Comun.conexion;
                            datosProd = vn.obtenerExistenciaProducto(datosProd);
                            DgvProductosBindingSource(producto);
                            this.actualizarExistencia(datosProd);
                        }
                        else
                        {
                            this.MostrarMensajeErrorAgregarProducto(producto.validador);
                        }
                        bandPrecioMayoreo = false;
                    }
                    else
                    {
                        MessageBox.Show(this, "Código incorrecto.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show(this, "No se puede agregar producto.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    if (tabControl1.TabPages.Count > 0)
                    {
                        if (tabControl1.SelectedTab != null)
                        {
                            VentaProductos datos = new VentaProductos();
                            ClienteNegocio cn = new ClienteNegocio();
                            datos.Usuins = Comun.id_u;
                            datos.StrCnx = Comun.conexion;
                            datos.IDCliente = this.txtCliente.Text;
                            datos.IDVenta = this.tabControl1.SelectedTab.Name;
                            datos.IDSucursal = Comun.id_sucursal;
                            Cliente cliente = new Cliente();
                            cliente.credenciales = new Credenciales();
                            cliente = cn.obtenerClienteXEANCodigo(datos);
                            if (string.IsNullOrEmpty(cliente.id_cliente))
                                MessageBox.Show(this, "Código de cliente incorrecto", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.LlenarDatosCliente(cliente);
                            this.AsignarClienteListaVentas(cliente);
                        }
                    }
                }
                else
                {
                    this.PermitirSoloNumeros(e);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Código de cliente incorrecto", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.TabPages.Count > 0)
                {
                    if (tabControl1.SelectedTab != null)
                    {
                        frm_BuscarCliente bc = new frm_BuscarCliente();
                        bc.ShowDialog();
                        if (bc.DialogResult == DialogResult.OK)
                        {
                            using (new Recursos.CursorWait())
                            {
                                Cliente cliente = new Cliente();
                                ClienteNegocio cn = new ClienteNegocio();
                                VentaProductos datos = new VentaProductos();
                                cliente = bc.cliente;
                                datos.Usuins = Comun.id_u;
                                datos.StrCnx = Comun.conexion;
                                datos.IDCliente = cliente.id_cliente;
                                datos.IDVenta = this.tabControl1.SelectedTab.Name;
                                datos.IDSucursal = Comun.id_sucursal;
                                cliente = cn.obtenerClienteXIDClienteVentas(datos);
                                if (string.IsNullOrEmpty(datos.IDCliente))
                                    MessageBox.Show(this, "No se cargaron los datos del cliente. ", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.LlenarDatosCliente(cliente);
                                this.AsignarClienteListaVentas(cliente);
                                DgvProductosBindingSource(datos);
                            }
                        }
                        bc.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbFamilia_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.txt_fNombre.Text = "";
                this.txt_fCB.Text = "";
                this.ConsultaProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                this.PermitirSoloNumeros(e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.tabControl1.TabPages.Count > 0)
                {
                    if (this.tabControl1.SelectedTab != null)
                    {
                        this.MostrarDatos(this.tabControl1.SelectedTab.Name);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "No se pudo cargar la información. Contacte a Soporte Técnico.", "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgvSeleccionado = (DataGridView)sender;
                if (e.RowIndex != -1)
                {
                    if (dgvSeleccionado.Rows[e.RowIndex].Cells[dgvSeleccionado.Name + "IDProducto"].Value != null && dgvSeleccionado.Rows[e.RowIndex].Cells[dgvSeleccionado.Name + "IDTallaRopa"].Value != null && dgvSeleccionado.Rows[e.RowIndex].Cells[dgvSeleccionado.Name + "IDColorRopa"].Value != null)
                    {
                        if (MessageBox.Show("¿Desea borrar el producto seleccionado?", "Sistema Punto de Venta CSL", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            VentaProductos datos = new VentaProductos();
                            VentaProductosNegocio vn = new VentaProductosNegocio();
                            datos.IDProducto = dgvSeleccionado.Rows[e.RowIndex].Cells[dgvSeleccionado.Name + "IDProducto"].Value.ToString();
                            datos.IDTallaRopa = Convert.ToInt32(dgvSeleccionado.Rows[e.RowIndex].Cells[dgvSeleccionado.Name + "IDTallaRopa"].Value.ToString());
                            datos.IDColorRopa = Convert.ToInt32(dgvSeleccionado.Rows[e.RowIndex].Cells[dgvSeleccionado.Name + "IDColorRopa"].Value.ToString());
                            datos.IDVenta = this.GetIDTabSeleccionado();
                            datos.IDSucursal = Comun.id_sucursal;
                            datos.StrCnx = Comun.conexion;
                            vn.EliminarProductoVentaTmp(datos);
                            if (datos.validador == 0)
                            {
                                Producto datosProd = new Producto();
                                datosProd.productoDetalle = new ProductoDetalle();
                                datosProd.id_producto = datos.IDProducto;
                                datosProd.productoDetalle.id_tallaRopa = datos.IDTallaRopa;
                                datosProd.productoDetalle.id_colorRopa = datos.IDColorRopa;
                                datosProd.productoDetalle.id_sucursal = datos.IDSucursal;
                                datosProd.conexion = Comun.conexion;
                                datosProd = vn.obtenerExistenciaProducto(datosProd);
                                this.actualizarExistencia(datosProd);
                                DgvProductosBindingSource(datos);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmVentas_Bunifu_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmVentas_Bunifu_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.LiberarVentasNoGuardadas();
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txt_fNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (Char)13)
                {
                    this.ConsultaProductos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region Eventos Delegados
        private void icon_Creativa_DoubleClick(System.Object sender, EventArgs e)
        {
            try
            {
                this.DgvProductosAgregar(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void icon_Creativa_MouseHover(System.Object sender, EventArgs e)
        {
            try
            {
                Control ctrlImagen = (Control)sender;
                Icon_Creativa find_IconCreativa = (Icon_Creativa)this.Controls.Find(ctrlImagen.Tag.ToString(), true)[0];
                this.txtNombreCorto.Text = find_IconCreativa.pNombre;
                this.txtPrecio.Text = string.Format("{0:C2}", find_IconCreativa.pPrecio);
                //this.txtCantidadMayoreo.Text = find_IconCreativa.pcantidadMayoreo.ToString();
                //this.txtPrecioMayoreo.Text = string.Format("{0:C2}", find_IconCreativa.pPrecioMayoreo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #endregion


        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                Rectangle rect = tabControl1.GetTabRect(e.Index);
                Rectangle imageRec = new Rectangle(rect.Right - closeImage.Width, rect.Top + (rect.Height - closeImage.Height) / 2, closeImage.Width, closeImage.Height);
                rect.Size = new Size(rect.Width + 20, 38);

                Font f;
                Brush br = Brushes.Black;
                StringFormat strF = new StringFormat(StringFormat.GenericDefault);
                if (tabControl1.SelectedTab == tabControl1.TabPages[e.Index])
                {
                    e.Graphics.DrawImage(closeImageAct, imageRec);
                    f = new Font("Courier", 10, FontStyle.Bold);
                    e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, f, br, rect, strF);
                }
                else
                {
                    e.Graphics.DrawImage(closeImage, imageRec);
                    f = new Font("Courier", 9, FontStyle.Regular);
                    e.Graphics.DrawString(tabControl1.TabPages[e.Index].Text, f, br, rect, strF);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnDescProd_Click_1(object sender, EventArgs e)
        {
            try
            {
                tabActuales++;
                VentaProductos ventaActualizar = new VentaProductos();
                if (tabControl1.TabPages.Count > 0)
                {
                    TabPage tabSeleccionado = new TabPage();
                    DataGridView dgvSeleccionado = new DataGridView();
                    tabSeleccionado = this.tabControl1.SelectedTab;
                    frm_PedirCadenaTexto getNombreTicket = new frm_PedirCadenaTexto();
                    getNombreTicket.dato = tabSeleccionado.Text;
                    getNombreTicket.ShowDialog();
                    if (getNombreTicket.DialogResult == DialogResult.OK)
                    {
                        ventaActualizar.IDVenta = tabSeleccionado.Name;
                        ventaActualizar.nameTab = getNombreTicket.dato;
                        ventaActualizar.IDSucursal = Comun.id_sucursal;
                        ventaActualizar.StrCnx = Comun.conexion;
                        VentaProductosNegocio vn = new VentaProductosNegocio();
                        vn.ActualizarVentaTemporal(ventaActualizar);
                        tabSeleccionado.Text = getNombreTicket.dato;
                        VentaProductos nuevaVenta = new VentaProductos();
                        nuevaVenta.Vale = new Vales();
                        nuevaVenta = AgregarVentaPendienteNueva();
                        Venta Venta = new Venta();
                        Venta.id_ventaTemporal = nuevaVenta.IDVenta;
                        Venta.dataGridViewName = "DGV" + nuevaVenta.IDVenta;
                        Venta.productosVenta = new List<VentaProductos>();
                        Venta.textTab = tabSeleccionado.Text;
                        Venta.cliente = new Cliente();
                        Venta.cliente.id_cliente = nuevaVenta.IDCliente;
                        Venta.idCliente = nuevaVenta.IDCliente;
                        Venta.vale = new Vales();
                        ventasPendientes.Add(Venta);
                        AgregarTabVenta(nuevaVenta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void txt_fNombre_Click(object sender, EventArgs e)
        {
            try
            {
                this.txt_fNombre.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void txt_fCB_Click(object sender, EventArgs e)
        {
            try
            {
                this.txt_fCB.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                for (int i = 0; i < tabControl1.TabCount; i++)
                {
                    Rectangle rect = tabControl1.GetTabRect(i);
                    Rectangle imageRec = new Rectangle(rect.Right - closeImage.Width, rect.Top + (rect.Height - closeImage.Height) / 2, closeImage.Width, closeImage.Height);
                    if (imageRec.Contains(e.Location))
                    {
                        if (LiberarVentaTab() == true)
                        {
                            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                            if (tabControl1.TabPages.Count == 0)
                            {
                                VentaProductos nuevaVenta = AgregarVentaPendienteNueva();
                                Venta ventaPend = new Venta();
                                ventaPend.cliente = new Cliente();
                                ventaPend.cliente.id_cliente = nuevaVenta.IDCliente;
                                ventaPend.idCliente = nuevaVenta.IDCliente;
                                ventaPend.vale = new Vales();
                                ventaPend.id_ventaTemporal = nuevaVenta.IDVenta;
                                ventaPend.textTab = nuevaVenta.nameTab;
                                ventasPendientes.Add(ventaPend);
                                AgregarTabVenta(nuevaVenta);
                                nuevaVenta.StrCnx = Comun.conexion;
                                this.MostrarDatosCliente(nuevaVenta);
                                this.ConsultaProductos();
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }
        #endregion


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                VentaProductosNegocio vpn = new VentaProductosNegocio();
                VentaProductos datos = new VentaProductos();
                datos.StrCnx = Comun.conexion;
                datos.IDCaja = Comun.id_caja;
                datos.IDSucursal = Comun.id_sucursal;
                vpn.liberarVentasNoGuardadas(datos);
                this.CargarIVASucursal();

            }
            catch (Exception ex)
            {
                //MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
            }
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                Familia datos = new Familia();
                datos.conexion = Comun.conexion;
                datos.opcion = 1;
                VentaProductosNegocio vpn = new VentaProductosNegocio();
                this.cmbFamilia.SelectedValueChanged -= new System.EventHandler(this.cmbFamilia_SelectedValueChanged);
                this.cmbFamilia.DisplayMember = "descripcion";
                this.cmbFamilia.ValueMember = "id_familia";
                this.cmbFamilia.DataSource = vpn.LlenaComboFamilia(datos);
                this.cmbFamilia.SelectedValueChanged += new System.EventHandler(this.cmbFamilia_SelectedValueChanged);
                this.cmbFamilia_SelectedValueChanged(null, null);

                this.CargarVentasPendientes();

                Size mysize = new System.Drawing.Size(20, 20);
                Bitmap bt = new Bitmap(Properties.Resources.close);
                Bitmap btm = new Bitmap(bt, mysize);
                closeImageAct = btm;

                Bitmap bt2 = new Bitmap(Properties.Resources.closeBlack);
                Bitmap btm2 = new Bitmap(bt2, mysize);
                closeImage = btm2;
                tabControl1.Padding = new Point(30);

                espere.Close();
            }
            catch (Exception ex)
            {
                // MessageBox.Show(this, ex.Message.ToString(), "Sistema Punto de Venta CSL", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Abort;
            }
        }

    }


}
