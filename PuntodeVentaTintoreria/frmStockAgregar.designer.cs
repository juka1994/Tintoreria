namespace PuntodeVentaTintoreria
{
    partial class frmStockAgregar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.LblTitulo = new System.Windows.Forms.Label();
            this.PanelTitulo = new System.Windows.Forms.Panel();
            this.LblNuevaCantidadAlmacen = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.TxtNuevaCantidadAlmacen = new System.Windows.Forms.TextBox();
            this.LblCantidadIngresar = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TxtCantidadIngresar = new System.Windows.Forms.TextBox();
            this.LblUnidadesMedidas = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CmbUnidadesMedidas = new BetterComboBox.BetterComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TxtUnidadMedidaProducto = new System.Windows.Forms.TextBox();
            this.LblFactorConversion = new System.Windows.Forms.Label();
            this.pnl_cantidad = new System.Windows.Forms.Panel();
            this.TxtFactorConversion = new System.Windows.Forms.TextBox();
            this.pnl_cantidadActual = new System.Windows.Forms.Panel();
            this.TxtCantidadActual = new System.Windows.Forms.TextBox();
            this.pnl_producto = new System.Windows.Forms.Panel();
            this.TxtNombreProducto = new System.Windows.Forms.TextBox();
            this.TxtObservaciones = new System.Windows.Forms.TextBox();
            this.txt_observacionesa = new System.Windows.Forms.TextBox();
            this.LblUnidadMedidaProducto = new System.Windows.Forms.Label();
            this.LblCantidadActual = new System.Windows.Forms.Label();
            this.LblProducto = new System.Windows.Forms.Label();
            this.LblObservacion = new System.Windows.Forms.Label();
            this.pnlBotones.SuspendLayout();
            this.PanelTitulo.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_cantidad.SuspendLayout();
            this.pnl_cantidadActual.SuspendLayout();
            this.pnl_producto.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.Silver;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Image = global::PuntodeVentaTintoreria.Properties.Resources.icono_listo_44x44B;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.Location = new System.Drawing.Point(544, 8);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(83, 75);
            this.btnGuardar.TabIndex = 31;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.pnlBotones.Controls.Add(this.btnGuardar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 411);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(670, 92);
            this.pnlBotones.TabIndex = 34;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = global::PuntodeVentaTintoreria.Properties.Resources.top_cerrar;
            this.btnSalir.Location = new System.Drawing.Point(625, 19);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(30, 31);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.btnMinimizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Image = global::PuntodeVentaTintoreria.Properties.Resources.top_minimizar;
            this.btnMinimizar.Location = new System.Drawing.Point(587, 19);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(30, 31);
            this.btnMinimizar.TabIndex = 2;
            this.btnMinimizar.UseVisualStyleBackColor = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // LblTitulo
            // 
            this.LblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblTitulo.AutoSize = true;
            this.LblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblTitulo.ForeColor = System.Drawing.Color.White;
            this.LblTitulo.Location = new System.Drawing.Point(8, 25);
            this.LblTitulo.Name = "LblTitulo";
            this.LblTitulo.Size = new System.Drawing.Size(124, 20);
            this.LblTitulo.TabIndex = 3;
            this.LblTitulo.Text = "Agregar Stock";
            // 
            // PanelTitulo
            // 
            this.PanelTitulo.AutoSize = true;
            this.PanelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.PanelTitulo.Controls.Add(this.LblTitulo);
            this.PanelTitulo.Controls.Add(this.btnMinimizar);
            this.PanelTitulo.Controls.Add(this.btnSalir);
            this.PanelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitulo.Location = new System.Drawing.Point(0, 0);
            this.PanelTitulo.Name = "PanelTitulo";
            this.PanelTitulo.Size = new System.Drawing.Size(670, 53);
            this.PanelTitulo.TabIndex = 12;
            // 
            // LblNuevaCantidadAlmacen
            // 
            this.LblNuevaCantidadAlmacen.AutoSize = true;
            this.LblNuevaCantidadAlmacen.BackColor = System.Drawing.Color.Transparent;
            this.LblNuevaCantidadAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.LblNuevaCantidadAlmacen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.LblNuevaCantidadAlmacen.Location = new System.Drawing.Point(278, 213);
            this.LblNuevaCantidadAlmacen.Name = "LblNuevaCantidadAlmacen";
            this.LblNuevaCantidadAlmacen.Size = new System.Drawing.Size(166, 13);
            this.LblNuevaCantidadAlmacen.TabIndex = 62;
            this.LblNuevaCantidadAlmacen.Text = "Nueva cantidad en almacén";
            this.LblNuevaCantidadAlmacen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.panel4.Controls.Add(this.TxtNuevaCantidadAlmacen);
            this.panel4.Location = new System.Drawing.Point(277, 229);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(207, 35);
            this.panel4.TabIndex = 63;
            // 
            // TxtNuevaCantidadAlmacen
            // 
            this.TxtNuevaCantidadAlmacen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.TxtNuevaCantidadAlmacen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtNuevaCantidadAlmacen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TxtNuevaCantidadAlmacen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.TxtNuevaCantidadAlmacen.Location = new System.Drawing.Point(6, 7);
            this.TxtNuevaCantidadAlmacen.Name = "TxtNuevaCantidadAlmacen";
            this.TxtNuevaCantidadAlmacen.ReadOnly = true;
            this.TxtNuevaCantidadAlmacen.Size = new System.Drawing.Size(198, 19);
            this.TxtNuevaCantidadAlmacen.TabIndex = 32;
            // 
            // LblCantidadIngresar
            // 
            this.LblCantidadIngresar.AutoSize = true;
            this.LblCantidadIngresar.BackColor = System.Drawing.Color.Transparent;
            this.LblCantidadIngresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.LblCantidadIngresar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.LblCantidadIngresar.Location = new System.Drawing.Point(30, 213);
            this.LblCantidadIngresar.Name = "LblCantidadIngresar";
            this.LblCantidadIngresar.Size = new System.Drawing.Size(117, 13);
            this.LblCantidadIngresar.TabIndex = 60;
            this.LblCantidadIngresar.Text = "Cantidad a ingresar";
            this.LblCantidadIngresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.panel3.Controls.Add(this.TxtCantidadIngresar);
            this.panel3.Location = new System.Drawing.Point(33, 229);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(218, 35);
            this.panel3.TabIndex = 61;
            // 
            // TxtCantidadIngresar
            // 
            this.TxtCantidadIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.TxtCantidadIngresar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtCantidadIngresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TxtCantidadIngresar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.TxtCantidadIngresar.Location = new System.Drawing.Point(6, 7);
            this.TxtCantidadIngresar.Name = "TxtCantidadIngresar";
            this.TxtCantidadIngresar.Size = new System.Drawing.Size(207, 19);
            this.TxtCantidadIngresar.TabIndex = 32;
            this.TxtCantidadIngresar.Text = "0.000000";
            this.TxtCantidadIngresar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtCantidadIngresar.TextChanged += new System.EventHandler(this.TxtCantidadIngresar_TextChanged);
            this.TxtCantidadIngresar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCantidadIngresar_KeyDown);
            this.TxtCantidadIngresar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtCantidadIngresar_KeyPress);
            // 
            // LblUnidadesMedidas
            // 
            this.LblUnidadesMedidas.AutoSize = true;
            this.LblUnidadesMedidas.BackColor = System.Drawing.Color.Transparent;
            this.LblUnidadesMedidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.LblUnidadesMedidas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.LblUnidadesMedidas.Location = new System.Drawing.Point(32, 143);
            this.LblUnidadesMedidas.Name = "LblUnidadesMedidas";
            this.LblUnidadesMedidas.Size = new System.Drawing.Size(122, 13);
            this.LblUnidadesMedidas.TabIndex = 59;
            this.LblUnidadesMedidas.Text = "Unidades de medida";
            this.LblUnidadesMedidas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.panel2.Controls.Add(this.CmbUnidadesMedidas);
            this.panel2.Location = new System.Drawing.Point(33, 159);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(218, 35);
            this.panel2.TabIndex = 53;
            // 
            // CmbUnidadesMedidas
            // 
            this.CmbUnidadesMedidas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.CmbUnidadesMedidas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbUnidadesMedidas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbUnidadesMedidas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.CmbUnidadesMedidas.FormattingEnabled = true;
            this.CmbUnidadesMedidas.Location = new System.Drawing.Point(5, 3);
            this.CmbUnidadesMedidas.Name = "CmbUnidadesMedidas";
            this.CmbUnidadesMedidas.Size = new System.Drawing.Size(209, 28);
            this.CmbUnidadesMedidas.TabIndex = 33;
            this.CmbUnidadesMedidas.SelectedValueChanged += new System.EventHandler(this.CmbUnidadesMedidas_SelectedValueChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.TxtUnidadMedidaProducto);
            this.panel1.Location = new System.Drawing.Point(505, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(142, 35);
            this.panel1.TabIndex = 57;
            // 
            // TxtUnidadMedidaProducto
            // 
            this.TxtUnidadMedidaProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.TxtUnidadMedidaProducto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtUnidadMedidaProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TxtUnidadMedidaProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.TxtUnidadMedidaProducto.Location = new System.Drawing.Point(3, 8);
            this.TxtUnidadMedidaProducto.Name = "TxtUnidadMedidaProducto";
            this.TxtUnidadMedidaProducto.ReadOnly = true;
            this.TxtUnidadMedidaProducto.Size = new System.Drawing.Size(136, 19);
            this.TxtUnidadMedidaProducto.TabIndex = 32;
            // 
            // LblFactorConversion
            // 
            this.LblFactorConversion.AutoSize = true;
            this.LblFactorConversion.BackColor = System.Drawing.Color.Transparent;
            this.LblFactorConversion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.LblFactorConversion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.LblFactorConversion.Location = new System.Drawing.Point(278, 143);
            this.LblFactorConversion.Name = "LblFactorConversion";
            this.LblFactorConversion.Size = new System.Drawing.Size(127, 13);
            this.LblFactorConversion.TabIndex = 51;
            this.LblFactorConversion.Text = "Factor de conversión";
            this.LblFactorConversion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnl_cantidad
            // 
            this.pnl_cantidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.pnl_cantidad.Controls.Add(this.TxtFactorConversion);
            this.pnl_cantidad.Location = new System.Drawing.Point(281, 159);
            this.pnl_cantidad.Name = "pnl_cantidad";
            this.pnl_cantidad.Size = new System.Drawing.Size(203, 35);
            this.pnl_cantidad.TabIndex = 52;
            // 
            // TxtFactorConversion
            // 
            this.TxtFactorConversion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.TxtFactorConversion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtFactorConversion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TxtFactorConversion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.TxtFactorConversion.Location = new System.Drawing.Point(6, 7);
            this.TxtFactorConversion.Name = "TxtFactorConversion";
            this.TxtFactorConversion.ReadOnly = true;
            this.TxtFactorConversion.Size = new System.Drawing.Size(194, 19);
            this.TxtFactorConversion.TabIndex = 32;
            // 
            // pnl_cantidadActual
            // 
            this.pnl_cantidadActual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.pnl_cantidadActual.Controls.Add(this.TxtCantidadActual);
            this.pnl_cantidadActual.Location = new System.Drawing.Point(347, 93);
            this.pnl_cantidadActual.Name = "pnl_cantidadActual";
            this.pnl_cantidadActual.Size = new System.Drawing.Size(137, 35);
            this.pnl_cantidadActual.TabIndex = 54;
            // 
            // TxtCantidadActual
            // 
            this.TxtCantidadActual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.TxtCantidadActual.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtCantidadActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TxtCantidadActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.TxtCantidadActual.Location = new System.Drawing.Point(3, 7);
            this.TxtCantidadActual.Name = "TxtCantidadActual";
            this.TxtCantidadActual.ReadOnly = true;
            this.TxtCantidadActual.Size = new System.Drawing.Size(131, 19);
            this.TxtCantidadActual.TabIndex = 31;
            // 
            // pnl_producto
            // 
            this.pnl_producto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.pnl_producto.Controls.Add(this.TxtNombreProducto);
            this.pnl_producto.Location = new System.Drawing.Point(33, 93);
            this.pnl_producto.Name = "pnl_producto";
            this.pnl_producto.Size = new System.Drawing.Size(302, 35);
            this.pnl_producto.TabIndex = 55;
            // 
            // TxtNombreProducto
            // 
            this.TxtNombreProducto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.TxtNombreProducto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtNombreProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TxtNombreProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.TxtNombreProducto.Location = new System.Drawing.Point(3, 8);
            this.TxtNombreProducto.Name = "TxtNombreProducto";
            this.TxtNombreProducto.ReadOnly = true;
            this.TxtNombreProducto.Size = new System.Drawing.Size(294, 19);
            this.TxtNombreProducto.TabIndex = 30;
            // 
            // TxtObservaciones
            // 
            this.TxtObservaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.TxtObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TxtObservaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.TxtObservaciones.Location = new System.Drawing.Point(38, 308);
            this.TxtObservaciones.Multiline = true;
            this.TxtObservaciones.Name = "TxtObservaciones";
            this.TxtObservaciones.Size = new System.Drawing.Size(609, 58);
            this.TxtObservaciones.TabIndex = 58;
            // 
            // txt_observacionesa
            // 
            this.txt_observacionesa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.txt_observacionesa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_observacionesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_observacionesa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txt_observacionesa.Location = new System.Drawing.Point(33, 300);
            this.txt_observacionesa.MaxLength = 300;
            this.txt_observacionesa.Multiline = true;
            this.txt_observacionesa.Name = "txt_observacionesa";
            this.txt_observacionesa.Size = new System.Drawing.Size(614, 70);
            this.txt_observacionesa.TabIndex = 56;
            // 
            // LblUnidadMedidaProducto
            // 
            this.LblUnidadMedidaProducto.AutoSize = true;
            this.LblUnidadMedidaProducto.BackColor = System.Drawing.Color.Transparent;
            this.LblUnidadMedidaProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.LblUnidadMedidaProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.LblUnidadMedidaProducto.Location = new System.Drawing.Point(512, 72);
            this.LblUnidadMedidaProducto.Name = "LblUnidadMedidaProducto";
            this.LblUnidadMedidaProducto.Size = new System.Drawing.Size(109, 13);
            this.LblUnidadMedidaProducto.TabIndex = 66;
            this.LblUnidadMedidaProducto.Text = "Unidad de medida";
            this.LblUnidadMedidaProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblCantidadActual
            // 
            this.LblCantidadActual.AutoSize = true;
            this.LblCantidadActual.BackColor = System.Drawing.Color.Transparent;
            this.LblCantidadActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.LblCantidadActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.LblCantidadActual.Location = new System.Drawing.Point(353, 73);
            this.LblCantidadActual.Name = "LblCantidadActual";
            this.LblCantidadActual.Size = new System.Drawing.Size(96, 13);
            this.LblCantidadActual.TabIndex = 64;
            this.LblCantidadActual.Text = "Cantidad actual";
            this.LblCantidadActual.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblProducto
            // 
            this.LblProducto.AutoSize = true;
            this.LblProducto.BackColor = System.Drawing.Color.Transparent;
            this.LblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.LblProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.LblProducto.Location = new System.Drawing.Point(41, 73);
            this.LblProducto.Name = "LblProducto";
            this.LblProducto.Size = new System.Drawing.Size(58, 13);
            this.LblProducto.TabIndex = 65;
            this.LblProducto.Text = "Producto";
            this.LblProducto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblObservacion
            // 
            this.LblObservacion.AutoSize = true;
            this.LblObservacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblObservacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.LblObservacion.Location = new System.Drawing.Point(32, 284);
            this.LblObservacion.Name = "LblObservacion";
            this.LblObservacion.Size = new System.Drawing.Size(78, 13);
            this.LblObservacion.TabIndex = 67;
            this.LblObservacion.Text = "Observación";
            // 
            // frmStockAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 503);
            this.Controls.Add(this.LblObservacion);
            this.Controls.Add(this.LblUnidadMedidaProducto);
            this.Controls.Add(this.LblCantidadActual);
            this.Controls.Add(this.LblProducto);
            this.Controls.Add(this.LblNuevaCantidadAlmacen);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.LblCantidadIngresar);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.LblUnidadesMedidas);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LblFactorConversion);
            this.Controls.Add(this.pnl_cantidad);
            this.Controls.Add(this.pnl_cantidadActual);
            this.Controls.Add(this.pnl_producto);
            this.Controls.Add(this.TxtObservaciones);
            this.Controls.Add(this.txt_observacionesa);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.PanelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmStockAgregar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmStockAgregar";
            this.Load += new System.EventHandler(this.frmStockAgregar_Load);
            this.pnlBotones.ResumeLayout(false);
            this.PanelTitulo.ResumeLayout(false);
            this.PanelTitulo.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_cantidad.ResumeLayout(false);
            this.pnl_cantidad.PerformLayout();
            this.pnl_cantidadActual.ResumeLayout(false);
            this.pnl_cantidadActual.PerformLayout();
            this.pnl_producto.ResumeLayout(false);
            this.pnl_producto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnMinimizar;
        public System.Windows.Forms.Label LblTitulo;
        private System.Windows.Forms.Panel PanelTitulo;
        private System.Windows.Forms.Label LblNuevaCantidadAlmacen;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox TxtNuevaCantidadAlmacen;
        private System.Windows.Forms.Label LblCantidadIngresar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox TxtCantidadIngresar;
        private System.Windows.Forms.Label LblUnidadesMedidas;
        private System.Windows.Forms.Panel panel2;
        private BetterComboBox.BetterComboBox CmbUnidadesMedidas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtUnidadMedidaProducto;
        private System.Windows.Forms.Label LblFactorConversion;
        private System.Windows.Forms.Panel pnl_cantidad;
        private System.Windows.Forms.TextBox TxtFactorConversion;
        private System.Windows.Forms.Panel pnl_cantidadActual;
        private System.Windows.Forms.TextBox TxtCantidadActual;
        private System.Windows.Forms.Panel pnl_producto;
        private System.Windows.Forms.TextBox TxtNombreProducto;
        private System.Windows.Forms.TextBox TxtObservaciones;
        private System.Windows.Forms.TextBox txt_observacionesa;
        private System.Windows.Forms.Label LblUnidadMedidaProducto;
        private System.Windows.Forms.Label LblCantidadActual;
        private System.Windows.Forms.Label LblProducto;
        private System.Windows.Forms.Label LblObservacion;
    }
}