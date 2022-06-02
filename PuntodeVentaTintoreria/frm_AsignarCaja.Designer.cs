namespace PuntodeVentaTintoreria
{
    partial class frm_AsignarCaja
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AsignarCaja));
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDatos = new System.Windows.Forms.Panel();
            this.btnImpresora = new System.Windows.Forms.Button();
            this.pnl_impresora = new System.Windows.Forms.Panel();
            this.txt_namePrinter = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnl_nombre = new System.Windows.Forms.Panel();
            this.txtNombreCaja = new System.Windows.Forms.TextBox();
            this.cmbSucCaja = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbEquipo = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.pnl_mac = new System.Windows.Forms.Panel();
            this.mktxtMac = new System.Windows.Forms.MaskedTextBox();
            this.panelNotifi = new System.Windows.Forms.Panel();
            this.picAlerta = new System.Windows.Forms.PictureBox();
            this.txt_mensaje = new System.Windows.Forms.TextBox();
            this.panelTitulo2 = new System.Windows.Forms.Panel();
            this.PanelTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.timeLogin = new System.Windows.Forms.Timer(this.components);
            this.bgw_LoginInit = new System.ComponentModel.BackgroundWorker();
            this.bgw_ImagenInit = new System.ComponentModel.BackgroundWorker();
            this.toolTipLogin = new System.Windows.Forms.ToolTip(this.components);
            this.panelPrincipal.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelDatos.SuspendLayout();
            this.pnl_impresora.SuspendLayout();
            this.pnl_nombre.SuspendLayout();
            this.pnl_mac.SuspendLayout();
            this.panelNotifi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlerta)).BeginInit();
            this.PanelTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPrincipal.BackColor = System.Drawing.Color.White;
            this.panelPrincipal.Controls.Add(this.panel1);
            this.panelPrincipal.Controls.Add(this.panelDatos);
            this.panelPrincipal.Controls.Add(this.panelTitulo2);
            this.panelPrincipal.Controls.Add(this.PanelTitulo);
            this.panelPrincipal.Location = new System.Drawing.Point(4, 7);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(442, 587);
            this.panelPrincipal.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.btn_Guardar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 487);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(442, 100);
            this.panel1.TabIndex = 9;
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.Transparent;
            this.btn_Guardar.BackgroundImage = global::PuntodeVentaTintoreria.Properties.Resources.fondo02;
            this.btn_Guardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Guardar.FlatAppearance.BorderSize = 0;
            this.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Guardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Guardar.ForeColor = System.Drawing.Color.White;
            this.btn_Guardar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Guardar.Image")));
            this.btn_Guardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Guardar.Location = new System.Drawing.Point(283, 32);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btn_Guardar.Size = new System.Drawing.Size(151, 55);
            this.btn_Guardar.TabIndex = 26;
            this.btn_Guardar.Text = "&Guardar";
            this.btn_Guardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Sistema Tintorería";
            // 
            // panelDatos
            // 
            this.panelDatos.Controls.Add(this.btnImpresora);
            this.panelDatos.Controls.Add(this.pnl_impresora);
            this.panelDatos.Controls.Add(this.label13);
            this.panelDatos.Controls.Add(this.label11);
            this.panelDatos.Controls.Add(this.pnl_nombre);
            this.panelDatos.Controls.Add(this.cmbSucCaja);
            this.panelDatos.Controls.Add(this.label14);
            this.panelDatos.Controls.Add(this.label15);
            this.panelDatos.Controls.Add(this.cmbEquipo);
            this.panelDatos.Controls.Add(this.label16);
            this.panelDatos.Controls.Add(this.label17);
            this.panelDatos.Controls.Add(this.label18);
            this.panelDatos.Controls.Add(this.label19);
            this.panelDatos.Controls.Add(this.pnl_mac);
            this.panelDatos.Controls.Add(this.panelNotifi);
            this.panelDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDatos.Location = new System.Drawing.Point(0, 95);
            this.panelDatos.Name = "panelDatos";
            this.panelDatos.Size = new System.Drawing.Size(442, 492);
            this.panelDatos.TabIndex = 8;
            // 
            // btnImpresora
            // 
            this.btnImpresora.BackColor = System.Drawing.Color.Transparent;
            this.btnImpresora.BackgroundImage = global::PuntodeVentaTintoreria.Properties.Resources.fondo02;
            this.btnImpresora.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImpresora.FlatAppearance.BorderSize = 0;
            this.btnImpresora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImpresora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImpresora.ForeColor = System.Drawing.Color.White;
            this.btnImpresora.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImpresora.Location = new System.Drawing.Point(120, 312);
            this.btnImpresora.Name = "btnImpresora";
            this.btnImpresora.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnImpresora.Size = new System.Drawing.Size(234, 33);
            this.btnImpresora.TabIndex = 27;
            this.btnImpresora.Text = "&Elegir Impresora";
            this.btnImpresora.UseVisualStyleBackColor = false;
            this.btnImpresora.Click += new System.EventHandler(this.btn_impresora_Click);
            // 
            // pnl_impresora
            // 
            this.pnl_impresora.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.pnl_impresora.Controls.Add(this.txt_namePrinter);
            this.pnl_impresora.Location = new System.Drawing.Point(139, 351);
            this.pnl_impresora.Name = "pnl_impresora";
            this.pnl_impresora.Size = new System.Drawing.Size(200, 35);
            this.pnl_impresora.TabIndex = 36;
            // 
            // txt_namePrinter
            // 
            this.txt_namePrinter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_namePrinter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_namePrinter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_namePrinter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txt_namePrinter.Location = new System.Drawing.Point(9, 9);
            this.txt_namePrinter.Name = "txt_namePrinter";
            this.txt_namePrinter.Size = new System.Drawing.Size(180, 16);
            this.txt_namePrinter.TabIndex = 2;
            this.txt_namePrinter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_namePrinter_KeyDown);
            this.txt_namePrinter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_namePrinter_KeyPress);
            this.txt_namePrinter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_namePrinter_MouseDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label13.Location = new System.Drawing.Point(61, 189);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "NOMBRE";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(120, 189);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 17);
            this.label11.TabIndex = 26;
            this.label11.Text = "*";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnl_nombre
            // 
            this.pnl_nombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.pnl_nombre.Controls.Add(this.txtNombreCaja);
            this.pnl_nombre.Location = new System.Drawing.Point(139, 179);
            this.pnl_nombre.Name = "pnl_nombre";
            this.pnl_nombre.Size = new System.Drawing.Size(200, 35);
            this.pnl_nombre.TabIndex = 37;
            // 
            // txtNombreCaja
            // 
            this.txtNombreCaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNombreCaja.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCaja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtNombreCaja.Location = new System.Drawing.Point(9, 9);
            this.txtNombreCaja.Name = "txtNombreCaja";
            this.txtNombreCaja.Size = new System.Drawing.Size(188, 16);
            this.txtNombreCaja.TabIndex = 2;
            this.txtNombreCaja.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNombreCaja_KeyDown);
            this.txtNombreCaja.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreCaja_KeyPress);
            this.txtNombreCaja.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtNombreCaja_MouseDown);
            // 
            // cmbSucCaja
            // 
            this.cmbSucCaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.cmbSucCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSucCaja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.cmbSucCaja.FormattingEnabled = true;
            this.cmbSucCaja.Location = new System.Drawing.Point(139, 240);
            this.cmbSucCaja.Name = "cmbSucCaja";
            this.cmbSucCaja.Size = new System.Drawing.Size(200, 28);
            this.cmbSucCaja.TabIndex = 35;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(120, 244);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 17);
            this.label14.TabIndex = 27;
            this.label14.Text = "*";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label15.Location = new System.Drawing.Point(51, 244);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "SUCURSAL";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbEquipo
            // 
            this.cmbEquipo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.cmbEquipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEquipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.cmbEquipo.FormattingEnabled = true;
            this.cmbEquipo.Location = new System.Drawing.Point(139, 127);
            this.cmbEquipo.Name = "cmbEquipo";
            this.cmbEquipo.Size = new System.Drawing.Size(200, 28);
            this.cmbEquipo.TabIndex = 34;
            this.cmbEquipo.SelectedValueChanged += new System.EventHandler(this.cmbEquipo_SelectedValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(120, 131);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(14, 17);
            this.label16.TabIndex = 29;
            this.label16.Text = "*";
            this.label16.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label17.Location = new System.Drawing.Point(68, 132);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(54, 13);
            this.label17.TabIndex = 30;
            this.label17.Text = "EQUIPO";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(120, 77);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(14, 17);
            this.label18.TabIndex = 31;
            this.label18.Text = "*";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label19.Location = new System.Drawing.Point(87, 77);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(33, 13);
            this.label19.TabIndex = 32;
            this.label19.Text = "MAC";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnl_mac
            // 
            this.pnl_mac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.pnl_mac.Controls.Add(this.mktxtMac);
            this.pnl_mac.Location = new System.Drawing.Point(139, 66);
            this.pnl_mac.Name = "pnl_mac";
            this.pnl_mac.Size = new System.Drawing.Size(200, 35);
            this.pnl_mac.TabIndex = 33;
            // 
            // mktxtMac
            // 
            this.mktxtMac.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.mktxtMac.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mktxtMac.Enabled = false;
            this.mktxtMac.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.mktxtMac.Location = new System.Drawing.Point(9, 7);
            this.mktxtMac.Mask = "aa:aa:aa:aa:aa:aa";
            this.mktxtMac.Name = "mktxtMac";
            this.mktxtMac.Size = new System.Drawing.Size(180, 19);
            this.mktxtMac.TabIndex = 1;
            // 
            // panelNotifi
            // 
            this.panelNotifi.BackColor = System.Drawing.Color.Red;
            this.panelNotifi.Controls.Add(this.picAlerta);
            this.panelNotifi.Controls.Add(this.txt_mensaje);
            this.panelNotifi.Location = new System.Drawing.Point(12, 6);
            this.panelNotifi.Name = "panelNotifi";
            this.panelNotifi.Size = new System.Drawing.Size(415, 54);
            this.panelNotifi.TabIndex = 24;
            this.panelNotifi.Visible = false;
            // 
            // picAlerta
            // 
            this.picAlerta.ErrorImage = null;
            this.picAlerta.Image = global::PuntodeVentaTintoreria.Properties.Resources.not_alerta;
            this.picAlerta.InitialImage = null;
            this.picAlerta.Location = new System.Drawing.Point(13, 3);
            this.picAlerta.Name = "picAlerta";
            this.picAlerta.Size = new System.Drawing.Size(49, 47);
            this.picAlerta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAlerta.TabIndex = 25;
            this.picAlerta.TabStop = false;
            this.picAlerta.Visible = false;
            // 
            // txt_mensaje
            // 
            this.txt_mensaje.BackColor = System.Drawing.Color.Red;
            this.txt_mensaje.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_mensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_mensaje.ForeColor = System.Drawing.Color.White;
            this.txt_mensaje.Location = new System.Drawing.Point(91, 3);
            this.txt_mensaje.Multiline = true;
            this.txt_mensaje.Name = "txt_mensaje";
            this.txt_mensaje.Size = new System.Drawing.Size(298, 47);
            this.txt_mensaje.TabIndex = 24;
            this.txt_mensaje.Text = "Msg Error";
            this.txt_mensaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelTitulo2
            // 
            this.panelTitulo2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            this.panelTitulo2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo2.Location = new System.Drawing.Point(0, 47);
            this.panelTitulo2.Name = "panelTitulo2";
            this.panelTitulo2.Size = new System.Drawing.Size(442, 48);
            this.panelTitulo2.TabIndex = 7;
            // 
            // PanelTitulo
            // 
            this.PanelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.PanelTitulo.Controls.Add(this.lblTitulo);
            this.PanelTitulo.Controls.Add(this.btnMinimizar);
            this.PanelTitulo.Controls.Add(this.btnSalir);
            this.PanelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitulo.Location = new System.Drawing.Point(0, 0);
            this.PanelTitulo.Name = "PanelTitulo";
            this.PanelTitulo.Size = new System.Drawing.Size(442, 47);
            this.PanelTitulo.TabIndex = 5;
            this.PanelTitulo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelTitulo_MouseMove);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(8, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(111, 20);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Asignar Caja";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.btnMinimizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Image = global::PuntodeVentaTintoreria.Properties.Resources.top_minimizar;
            this.btnMinimizar.Location = new System.Drawing.Point(359, 9);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(30, 31);
            this.btnMinimizar.TabIndex = 2;
            this.btnMinimizar.UseVisualStyleBackColor = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = global::PuntodeVentaTintoreria.Properties.Resources.top_cerrar;
            this.btnSalir.Location = new System.Drawing.Point(397, 9);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(30, 31);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // timeLogin
            // 
            this.timeLogin.Enabled = true;
            this.timeLogin.Interval = 1000;
            // 
            // toolTipLogin
            // 
            this.toolTipLogin.IsBalloon = true;
            // 
            // frm_AsignarCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(196)))), ((int)(((byte)(213)))));
            this.ClientSize = new System.Drawing.Size(450, 600);
            this.ControlBox = false;
            this.Controls.Add(this.panelPrincipal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_AsignarCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_AsignarCaja_Load);
            this.panelPrincipal.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelDatos.ResumeLayout(false);
            this.panelDatos.PerformLayout();
            this.pnl_impresora.ResumeLayout(false);
            this.pnl_impresora.PerformLayout();
            this.pnl_nombre.ResumeLayout(false);
            this.pnl_nombre.PerformLayout();
            this.pnl_mac.ResumeLayout(false);
            this.pnl_mac.PerformLayout();
            this.panelNotifi.ResumeLayout(false);
            this.panelNotifi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlerta)).EndInit();
            this.PanelTitulo.ResumeLayout(false);
            this.PanelTitulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Panel PanelTitulo;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnSalir;
        public System.Windows.Forms.Label lblTitulo;
        public System.Windows.Forms.Panel panelTitulo2;
        public System.Windows.Forms.Panel panelDatos;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelNotifi;
        private System.Windows.Forms.PictureBox picAlerta;
        private System.Windows.Forms.TextBox txt_mensaje;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Timer timeLogin;
        private System.ComponentModel.BackgroundWorker bgw_LoginInit;
        private System.ComponentModel.BackgroundWorker bgw_ImagenInit;
        private System.Windows.Forms.ToolTip toolTipLogin;
        private System.Windows.Forms.Panel pnl_impresora;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pnl_nombre;
        private System.Windows.Forms.ComboBox cmbSucCaja;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmbEquipo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Panel pnl_mac;
        private System.Windows.Forms.MaskedTextBox mktxtMac;
        private System.Windows.Forms.Button btnImpresora;
        private System.Windows.Forms.TextBox txt_namePrinter;
        private System.Windows.Forms.TextBox txtNombreCaja;
    }
}

