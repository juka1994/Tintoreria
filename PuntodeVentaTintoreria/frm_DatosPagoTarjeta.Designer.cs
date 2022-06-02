namespace PuntodeVentaTintoreria
{
    partial class frm_DatosPagoTarjeta
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
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDatos = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnl_monto = new System.Windows.Forms.Panel();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.cmbBancos = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pnl_numTarjta = new System.Windows.Forms.Panel();
            this.txtNumTarjeta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pnl_dni = new System.Windows.Forms.Panel();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.cmbDocumento = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCorreoSistema = new System.Windows.Forms.Label();
            this.pnl_numAuto = new System.Windows.Forms.Panel();
            this.txtNumAutorizacion = new System.Windows.Forms.TextBox();
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
            this.pnl_monto.SuspendLayout();
            this.pnl_numTarjta.SuspendLayout();
            this.pnl_dni.SuspendLayout();
            this.pnl_numAuto.SuspendLayout();
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
            this.panelPrincipal.Size = new System.Drawing.Size(592, 587);
            this.panelPrincipal.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.btnAceptar);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 505);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 82);
            this.panel1.TabIndex = 9;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.BackgroundImage = global::PuntodeVentaTintoreria.Properties.Resources.fondo02;
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAceptar.Location = new System.Drawing.Point(402, 14);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnAceptar.Size = new System.Drawing.Size(171, 42);
            this.btnAceptar.TabIndex = 9;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "Sistema Tintorería";
            // 
            // panelDatos
            // 
            this.panelDatos.Controls.Add(this.label10);
            this.panelDatos.Controls.Add(this.label11);
            this.panelDatos.Controls.Add(this.pnl_monto);
            this.panelDatos.Controls.Add(this.cmbBancos);
            this.panelDatos.Controls.Add(this.label8);
            this.panelDatos.Controls.Add(this.label9);
            this.panelDatos.Controls.Add(this.label7);
            this.panelDatos.Controls.Add(this.label12);
            this.panelDatos.Controls.Add(this.pnl_numTarjta);
            this.panelDatos.Controls.Add(this.label3);
            this.panelDatos.Controls.Add(this.label4);
            this.panelDatos.Controls.Add(this.pnl_dni);
            this.panelDatos.Controls.Add(this.cmbDocumento);
            this.panelDatos.Controls.Add(this.label2);
            this.panelDatos.Controls.Add(this.label5);
            this.panelDatos.Controls.Add(this.label6);
            this.panelDatos.Controls.Add(this.lblCorreoSistema);
            this.panelDatos.Controls.Add(this.pnl_numAuto);
            this.panelDatos.Controls.Add(this.panelNotifi);
            this.panelDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDatos.Location = new System.Drawing.Point(0, 95);
            this.panelDatos.Name = "panelDatos";
            this.panelDatos.Size = new System.Drawing.Size(592, 492);
            this.panelDatos.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(193, 319);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 17);
            this.label10.TabIndex = 41;
            this.label10.Text = "*";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label11.Location = new System.Drawing.Point(142, 319);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 42;
            this.label11.Text = "MONTO";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnl_monto
            // 
            this.pnl_monto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.pnl_monto.Controls.Add(this.txtMonto);
            this.pnl_monto.Location = new System.Drawing.Point(216, 308);
            this.pnl_monto.Name = "pnl_monto";
            this.pnl_monto.Size = new System.Drawing.Size(281, 35);
            this.pnl_monto.TabIndex = 34;
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtMonto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtMonto.Location = new System.Drawing.Point(2, 6);
            this.txtMonto.MaxLength = 30;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(275, 22);
            this.txtMonto.TabIndex = 8;
            this.txtMonto.Text = "0.00";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMonto_KeyDown);
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            this.txtMonto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtMonto_MouseDown);
            this.txtMonto.Validating += new System.ComponentModel.CancelEventHandler(this.txtMonto_Validating);
            // 
            // cmbBancos
            // 
            this.cmbBancos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.cmbBancos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBancos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.cmbBancos.FormattingEnabled = true;
            this.cmbBancos.Location = new System.Drawing.Point(216, 265);
            this.cmbBancos.Name = "cmbBancos";
            this.cmbBancos.Size = new System.Drawing.Size(285, 28);
            this.cmbBancos.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(193, 269);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 17);
            this.label8.TabIndex = 39;
            this.label8.Text = "*";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label9.Location = new System.Drawing.Point(143, 269);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 40;
            this.label9.Text = "BANCO";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(197, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 17);
            this.label7.TabIndex = 37;
            this.label7.Text = "*";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label12.Location = new System.Drawing.Point(103, 222);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 13);
            this.label12.TabIndex = 38;
            this.label12.Text = "NÚM. TARJETA";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnl_numTarjta
            // 
            this.pnl_numTarjta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.pnl_numTarjta.Controls.Add(this.txtNumTarjeta);
            this.pnl_numTarjta.Location = new System.Drawing.Point(216, 211);
            this.pnl_numTarjta.Name = "pnl_numTarjta";
            this.pnl_numTarjta.Size = new System.Drawing.Size(285, 35);
            this.pnl_numTarjta.TabIndex = 35;
            // 
            // txtNumTarjeta
            // 
            this.txtNumTarjeta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNumTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtNumTarjeta.Location = new System.Drawing.Point(3, 7);
            this.txtNumTarjeta.MaxLength = 30;
            this.txtNumTarjeta.Name = "txtNumTarjeta";
            this.txtNumTarjeta.Size = new System.Drawing.Size(278, 22);
            this.txtNumTarjeta.TabIndex = 6;
            this.txtNumTarjeta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumTarjeta_KeyDown);
            this.txtNumTarjeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumTarjeta_KeyPress);
            this.txtNumTarjeta.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtNumTarjeta_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(197, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 17);
            this.label3.TabIndex = 32;
            this.label3.Text = "*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label4.Location = new System.Drawing.Point(170, 176);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "DNI";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnl_dni
            // 
            this.pnl_dni.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.pnl_dni.Controls.Add(this.txtDNI);
            this.pnl_dni.Location = new System.Drawing.Point(216, 165);
            this.pnl_dni.Name = "pnl_dni";
            this.pnl_dni.Size = new System.Drawing.Size(285, 35);
            this.pnl_dni.TabIndex = 25;
            // 
            // txtDNI
            // 
            this.txtDNI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtDNI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDNI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtDNI.Location = new System.Drawing.Point(2, 6);
            this.txtDNI.MaxLength = 30;
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(278, 22);
            this.txtDNI.TabIndex = 5;
            this.txtDNI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDNI_KeyDown);
            this.txtDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDNI_KeyPress);
            this.txtDNI.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtDNI_MouseDown);
            // 
            // cmbDocumento
            // 
            this.cmbDocumento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.cmbDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDocumento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.cmbDocumento.FormattingEnabled = true;
            this.cmbDocumento.Location = new System.Drawing.Point(216, 124);
            this.cmbDocumento.Name = "cmbDocumento";
            this.cmbDocumento.Size = new System.Drawing.Size(285, 28);
            this.cmbDocumento.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(193, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 17);
            this.label2.TabIndex = 30;
            this.label2.Text = "*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label5.Location = new System.Drawing.Point(86, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "IDENTIFICACIÓN";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(197, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 17);
            this.label6.TabIndex = 28;
            this.label6.Text = "*";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblCorreoSistema
            // 
            this.lblCorreoSistema.AutoSize = true;
            this.lblCorreoSistema.BackColor = System.Drawing.Color.Transparent;
            this.lblCorreoSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCorreoSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreoSistema.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblCorreoSistema.Location = new System.Drawing.Point(60, 89);
            this.lblCorreoSistema.Name = "lblCorreoSistema";
            this.lblCorreoSistema.Size = new System.Drawing.Size(136, 13);
            this.lblCorreoSistema.TabIndex = 29;
            this.lblCorreoSistema.Text = "NÚM. AUTORIZACIÓN";
            this.lblCorreoSistema.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnl_numAuto
            // 
            this.pnl_numAuto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.pnl_numAuto.Controls.Add(this.txtNumAutorizacion);
            this.pnl_numAuto.Location = new System.Drawing.Point(216, 78);
            this.pnl_numAuto.Name = "pnl_numAuto";
            this.pnl_numAuto.Size = new System.Drawing.Size(285, 35);
            this.pnl_numAuto.TabIndex = 26;
            // 
            // txtNumAutorizacion
            // 
            this.txtNumAutorizacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNumAutorizacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumAutorizacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumAutorizacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtNumAutorizacion.Location = new System.Drawing.Point(4, 6);
            this.txtNumAutorizacion.MaxLength = 30;
            this.txtNumAutorizacion.Name = "txtNumAutorizacion";
            this.txtNumAutorizacion.Size = new System.Drawing.Size(278, 22);
            this.txtNumAutorizacion.TabIndex = 3;
            this.txtNumAutorizacion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumAutorizacion_KeyDown);
            this.txtNumAutorizacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumAutorizacion_KeyPress);
            this.txtNumAutorizacion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtNumAutorizacion_MouseDown);
            // 
            // panelNotifi
            // 
            this.panelNotifi.BackColor = System.Drawing.Color.Red;
            this.panelNotifi.Controls.Add(this.picAlerta);
            this.panelNotifi.Controls.Add(this.txt_mensaje);
            this.panelNotifi.Location = new System.Drawing.Point(8, 6);
            this.panelNotifi.Name = "panelNotifi";
            this.panelNotifi.Size = new System.Drawing.Size(569, 54);
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
            this.txt_mensaje.Location = new System.Drawing.Point(67, 3);
            this.txt_mensaje.Multiline = true;
            this.txt_mensaje.Name = "txt_mensaje";
            this.txt_mensaje.ReadOnly = true;
            this.txt_mensaje.Size = new System.Drawing.Size(498, 47);
            this.txt_mensaje.TabIndex = 24;
            this.txt_mensaje.TabStop = false;
            this.txt_mensaje.Text = "Msg Error";
            this.txt_mensaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelTitulo2
            // 
            this.panelTitulo2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            this.panelTitulo2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo2.Location = new System.Drawing.Point(0, 47);
            this.panelTitulo2.Name = "panelTitulo2";
            this.panelTitulo2.Size = new System.Drawing.Size(592, 48);
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
            this.PanelTitulo.Size = new System.Drawing.Size(592, 47);
            this.PanelTitulo.TabIndex = 5;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(8, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(162, 20);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Datos de la Tarjeta";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.btnMinimizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Image = global::PuntodeVentaTintoreria.Properties.Resources.top_minimizar;
            this.btnMinimizar.Location = new System.Drawing.Point(509, 9);
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
            this.btnSalir.Location = new System.Drawing.Point(547, 9);
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
            // frm_DatosPagoTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(196)))), ((int)(((byte)(213)))));
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.ControlBox = false;
            this.Controls.Add(this.panelPrincipal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_DatosPagoTarjeta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_DatosPagoTarjeta_Load);
            this.panelPrincipal.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelDatos.ResumeLayout(false);
            this.panelDatos.PerformLayout();
            this.pnl_monto.ResumeLayout(false);
            this.pnl_monto.PerformLayout();
            this.pnl_numTarjta.ResumeLayout(false);
            this.pnl_numTarjta.PerformLayout();
            this.pnl_dni.ResumeLayout(false);
            this.pnl_dni.PerformLayout();
            this.pnl_numAuto.ResumeLayout(false);
            this.pnl_numAuto.PerformLayout();
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
        private System.Windows.Forms.TextBox txtNumAutorizacion;
        private System.Windows.Forms.Panel panelNotifi;
        private System.Windows.Forms.PictureBox picAlerta;
        private System.Windows.Forms.TextBox txt_mensaje;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Timer timeLogin;
        private System.ComponentModel.BackgroundWorker bgw_LoginInit;
        private System.ComponentModel.BackgroundWorker bgw_ImagenInit;
        private System.Windows.Forms.ToolTip toolTipLogin;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pnl_monto;
        private System.Windows.Forms.ComboBox cmbBancos;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel pnl_numTarjta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnl_dni;
        private System.Windows.Forms.ComboBox cmbDocumento;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCorreoSistema;
        private System.Windows.Forms.Panel pnl_numAuto;
        private System.Windows.Forms.TextBox txtNumTarjeta;
        private System.Windows.Forms.TextBox txtDNI;
    }
}

