namespace PuntodeVentaTintoreria
{
    partial class frmGridEntregas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGridEntregas));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTitulo2 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txt_buscador = new System.Windows.Forms.TextBox();
            this.PanelTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnTerminar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btnUbicacion = new System.Windows.Forms.Button();
            this.btnTicket = new System.Windows.Forms.Button();
            this.btnFecha = new System.Windows.Forms.Button();
            this.BtnPago = new System.Windows.Forms.Button();
            this.btnEntregar = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.GridViewGeneral = new System.Windows.Forms.DataGridView();
            this.id_statusServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewImageColumn();
            this.entrega = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaentrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_ventaServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hor_ventaServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horaEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_tipoServicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_ubicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelTitulo2.SuspendLayout();
            this.PanelTitulo.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewGeneral)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitulo2
            // 
            this.panelTitulo2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            this.panelTitulo2.Controls.Add(this.btnCancelar);
            this.panelTitulo2.Controls.Add(this.btnBuscar);
            this.panelTitulo2.Controls.Add(this.txt_buscador);
            this.panelTitulo2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo2.Location = new System.Drawing.Point(0, 47);
            this.panelTitulo2.Name = "panelTitulo2";
            this.panelTitulo2.Size = new System.Drawing.Size(767, 48);
            this.panelTitulo2.TabIndex = 9;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.Location = new System.Drawing.Point(524, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(50, 45);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(468, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(50, 45);
            this.btnBuscar.TabIndex = 23;
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            this.btnBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnBuscar_KeyPress);
            // 
            // txt_buscador
            // 
            this.txt_buscador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txt_buscador.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_buscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_buscador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txt_buscador.Location = new System.Drawing.Point(28, 15);
            this.txt_buscador.Name = "txt_buscador";
            this.txt_buscador.Size = new System.Drawing.Size(417, 22);
            this.txt_buscador.TabIndex = 22;
            this.txt_buscador.Text = "Búsqueda por código o nombre";
            this.txt_buscador.Click += new System.EventHandler(this.txt_buscador_Click);
            this.txt_buscador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_buscador_KeyPress);
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
            this.PanelTitulo.Size = new System.Drawing.Size(767, 47);
            this.PanelTitulo.TabIndex = 8;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(8, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(155, 20);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Listado de Tickets";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.btnMinimizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Image = global::PuntodeVentaTintoreria.Properties.Resources.top_minimizar;
            this.btnMinimizar.Location = new System.Drawing.Point(684, 9);
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
            this.btnSalir.Location = new System.Drawing.Point(722, 9);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(30, 31);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.pnlPrincipal.Controls.Add(this.pnlBotones);
            this.pnlPrincipal.Controls.Add(this.panel3);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 95);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(767, 470);
            this.pnlPrincipal.TabIndex = 11;
            this.pnlPrincipal.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPrincipal_Paint);
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.DarkGray;
            this.pnlBotones.Controls.Add(this.btnTerminar);
            this.pnlBotones.Controls.Add(this.btn_Cancelar);
            this.pnlBotones.Controls.Add(this.btnUbicacion);
            this.pnlBotones.Controls.Add(this.btnTicket);
            this.pnlBotones.Controls.Add(this.btnFecha);
            this.pnlBotones.Controls.Add(this.BtnPago);
            this.pnlBotones.Controls.Add(this.btnEntregar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 390);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(767, 80);
            this.pnlBotones.TabIndex = 114;
            // 
            // btnTerminar
            // 
            this.btnTerminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTerminar.BackColor = System.Drawing.Color.Silver;
            this.btnTerminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btnTerminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTerminar.ForeColor = System.Drawing.Color.Black;
            this.btnTerminar.Image = global::PuntodeVentaTintoreria.Properties.Resources.icono_listo_44x44B;
            this.btnTerminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTerminar.Location = new System.Drawing.Point(15, 3);
            this.btnTerminar.Name = "btnTerminar";
            this.btnTerminar.Size = new System.Drawing.Size(115, 72);
            this.btnTerminar.TabIndex = 12;
            this.btnTerminar.Text = "Terminar";
            this.btnTerminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTerminar.UseVisualStyleBackColor = false;
            this.btnTerminar.Click += new System.EventHandler(this.BtnTerminar_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancelar.BackColor = System.Drawing.Color.Silver;
            this.btn_Cancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.ForeColor = System.Drawing.Color.Black;
            this.btn_Cancelar.Image = global::PuntodeVentaTintoreria.Properties.Resources.cancelacion_40px;
            this.btn_Cancelar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Cancelar.Location = new System.Drawing.Point(136, 3);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(115, 72);
            this.btn_Cancelar.TabIndex = 11;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Cancelar.UseVisualStyleBackColor = false;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btnUbicacion
            // 
            this.btnUbicacion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUbicacion.BackColor = System.Drawing.Color.Silver;
            this.btnUbicacion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btnUbicacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUbicacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUbicacion.ForeColor = System.Drawing.Color.Black;
            this.btnUbicacion.Image = ((System.Drawing.Image)(resources.GetObject("btnUbicacion.Image")));
            this.btnUbicacion.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnUbicacion.Location = new System.Drawing.Point(254, 3);
            this.btnUbicacion.Name = "btnUbicacion";
            this.btnUbicacion.Size = new System.Drawing.Size(115, 72);
            this.btnUbicacion.TabIndex = 10;
            this.btnUbicacion.Text = "Ubicaciòn";
            this.btnUbicacion.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUbicacion.UseVisualStyleBackColor = false;
            this.btnUbicacion.Click += new System.EventHandler(this.btnUbicacion_Click);
            // 
            // btnTicket
            // 
            this.btnTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTicket.BackColor = System.Drawing.Color.Silver;
            this.btnTicket.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btnTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTicket.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTicket.ForeColor = System.Drawing.Color.Black;
            this.btnTicket.Image = ((System.Drawing.Image)(resources.GetObject("btnTicket.Image")));
            this.btnTicket.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTicket.Location = new System.Drawing.Point(373, 3);
            this.btnTicket.Name = "btnTicket";
            this.btnTicket.Size = new System.Drawing.Size(105, 72);
            this.btnTicket.TabIndex = 7;
            this.btnTicket.Text = " Ticket";
            this.btnTicket.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTicket.UseVisualStyleBackColor = false;
            this.btnTicket.Click += new System.EventHandler(this.button35_Click);
            // 
            // btnFecha
            // 
            this.btnFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFecha.BackColor = System.Drawing.Color.Silver;
            this.btnFecha.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btnFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFecha.ForeColor = System.Drawing.Color.Black;
            this.btnFecha.Image = ((System.Drawing.Image)(resources.GetObject("btnFecha.Image")));
            this.btnFecha.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFecha.Location = new System.Drawing.Point(481, 3);
            this.btnFecha.Name = "btnFecha";
            this.btnFecha.Size = new System.Drawing.Size(105, 72);
            this.btnFecha.TabIndex = 5;
            this.btnFecha.Text = "Fecha";
            this.btnFecha.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFecha.UseVisualStyleBackColor = false;
            this.btnFecha.Click += new System.EventHandler(this.btnFecha_Click);
            // 
            // BtnPago
            // 
            this.BtnPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnPago.BackColor = System.Drawing.Color.Silver;
            this.BtnPago.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.BtnPago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPago.ForeColor = System.Drawing.Color.Black;
            this.BtnPago.Image = ((System.Drawing.Image)(resources.GetObject("BtnPago.Image")));
            this.BtnPago.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnPago.Location = new System.Drawing.Point(590, 4);
            this.BtnPago.Name = "BtnPago";
            this.BtnPago.Size = new System.Drawing.Size(85, 72);
            this.BtnPago.TabIndex = 2;
            this.BtnPago.Text = "Pago";
            this.BtnPago.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnPago.UseVisualStyleBackColor = false;
            this.BtnPago.Click += new System.EventHandler(this.BtnPago_Click);
            // 
            // btnEntregar
            // 
            this.btnEntregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEntregar.BackColor = System.Drawing.Color.Silver;
            this.btnEntregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btnEntregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntregar.ForeColor = System.Drawing.Color.Black;
            this.btnEntregar.Image = global::PuntodeVentaTintoreria.Properties.Resources.icono_entregar_58x58B;
            this.btnEntregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEntregar.Location = new System.Drawing.Point(678, 4);
            this.btnEntregar.Name = "btnEntregar";
            this.btnEntregar.Size = new System.Drawing.Size(85, 72);
            this.btnEntregar.TabIndex = 1;
            this.btnEntregar.Text = "Entregar";
            this.btnEntregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEntregar.UseVisualStyleBackColor = false;
            this.btnEntregar.Click += new System.EventHandler(this.btnEntregar_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.panel3.Controls.Add(this.GridViewGeneral);
            this.panel3.Location = new System.Drawing.Point(12, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(740, 320);
            this.panel3.TabIndex = 113;
            // 
            // GridViewGeneral
            // 
            this.GridViewGeneral.AllowUserToAddRows = false;
            this.GridViewGeneral.AllowUserToDeleteRows = false;
            this.GridViewGeneral.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            this.GridViewGeneral.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridViewGeneral.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridViewGeneral.BackgroundColor = System.Drawing.Color.White;
            this.GridViewGeneral.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridViewGeneral.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GridViewGeneral.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(230)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridViewGeneral.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridViewGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewGeneral.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_statusServicio,
            this.status,
            this.entrega,
            this.Folio,
            this.fechaentrega,
            this.Cliente,
            this.Cantidad,
            this.Vendedor,
            this.id_ventaServicio,
            this.id_cliente,
            this.id_sucursal,
            this.hor_ventaServicio,
            this.horaEntrega,
            this.cajero,
            this.id_tipoServicio,
            this.id_ubicacion,
            this.total,
            this.pago});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridViewGeneral.DefaultCellStyle = dataGridViewCellStyle3;
            this.GridViewGeneral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridViewGeneral.EnableHeadersVisualStyles = false;
            this.GridViewGeneral.Location = new System.Drawing.Point(0, 0);
            this.GridViewGeneral.MultiSelect = false;
            this.GridViewGeneral.Name = "GridViewGeneral";
            this.GridViewGeneral.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridViewGeneral.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GridViewGeneral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewGeneral.Size = new System.Drawing.Size(740, 320);
            this.GridViewGeneral.TabIndex = 3;
            // 
            // id_statusServicio
            // 
            this.id_statusServicio.DataPropertyName = "id_statusServicio";
            this.id_statusServicio.HeaderText = "id_status";
            this.id_statusServicio.Name = "id_statusServicio";
            this.id_statusServicio.ReadOnly = true;
            this.id_statusServicio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.id_statusServicio.Visible = false;
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // entrega
            // 
            this.entrega.DataPropertyName = "entrega";
            this.entrega.HeaderText = "E";
            this.entrega.Name = "entrega";
            this.entrega.ReadOnly = true;
            this.entrega.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.entrega.Visible = false;
            // 
            // Folio
            // 
            this.Folio.DataPropertyName = "Folio";
            this.Folio.HeaderText = "Folio";
            this.Folio.Name = "Folio";
            this.Folio.ReadOnly = true;
            // 
            // fechaentrega
            // 
            this.fechaentrega.DataPropertyName = "fechaEntrega";
            this.fechaentrega.HeaderText = "Fecha de Entrega";
            this.fechaentrega.Name = "fechaentrega";
            this.fechaentrega.ReadOnly = true;
            // 
            // Cliente
            // 
            this.Cliente.DataPropertyName = "Cliente";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "cantidadprendas";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Vendedor
            // 
            this.Vendedor.DataPropertyName = "Vendedor";
            this.Vendedor.HeaderText = "Vendedor";
            this.Vendedor.Name = "Vendedor";
            this.Vendedor.ReadOnly = true;
            // 
            // id_ventaServicio
            // 
            this.id_ventaServicio.DataPropertyName = "id_ventaServicio";
            this.id_ventaServicio.HeaderText = "id_ventaServicio";
            this.id_ventaServicio.Name = "id_ventaServicio";
            this.id_ventaServicio.ReadOnly = true;
            this.id_ventaServicio.Visible = false;
            // 
            // id_cliente
            // 
            this.id_cliente.DataPropertyName = "id_cliente";
            this.id_cliente.HeaderText = "id_cliente";
            this.id_cliente.Name = "id_cliente";
            this.id_cliente.ReadOnly = true;
            this.id_cliente.Visible = false;
            // 
            // id_sucursal
            // 
            this.id_sucursal.DataPropertyName = "id_sucursal";
            this.id_sucursal.HeaderText = "id_sucursal";
            this.id_sucursal.Name = "id_sucursal";
            this.id_sucursal.ReadOnly = true;
            this.id_sucursal.Visible = false;
            // 
            // hor_ventaServicio
            // 
            this.hor_ventaServicio.DataPropertyName = "hor_ventaServicio";
            this.hor_ventaServicio.HeaderText = "hor_ventaServicio";
            this.hor_ventaServicio.Name = "hor_ventaServicio";
            this.hor_ventaServicio.ReadOnly = true;
            this.hor_ventaServicio.Visible = false;
            // 
            // horaEntrega
            // 
            this.horaEntrega.DataPropertyName = "horaEntrega";
            this.horaEntrega.HeaderText = "horaEntrega";
            this.horaEntrega.Name = "horaEntrega";
            this.horaEntrega.ReadOnly = true;
            this.horaEntrega.Visible = false;
            // 
            // cajero
            // 
            this.cajero.DataPropertyName = "cajero";
            this.cajero.HeaderText = "cajero";
            this.cajero.Name = "cajero";
            this.cajero.ReadOnly = true;
            this.cajero.Visible = false;
            // 
            // id_tipoServicio
            // 
            this.id_tipoServicio.HeaderText = "id_tipoServicio";
            this.id_tipoServicio.Name = "id_tipoServicio";
            this.id_tipoServicio.ReadOnly = true;
            this.id_tipoServicio.Visible = false;
            // 
            // id_ubicacion
            // 
            this.id_ubicacion.HeaderText = "id_ubicacion";
            this.id_ubicacion.Name = "id_ubicacion";
            this.id_ubicacion.ReadOnly = true;
            this.id_ubicacion.Visible = false;
            // 
            // total
            // 
            this.total.DataPropertyName = "total";
            this.total.HeaderText = "total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Visible = false;
            // 
            // pago
            // 
            this.pago.DataPropertyName = "pago";
            this.pago.HeaderText = "pago";
            this.pago.Name = "pago";
            this.pago.ReadOnly = true;
            this.pago.Visible = false;
            // 
            // frmGridEntregas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(196)))), ((int)(((byte)(213)))));
            this.ClientSize = new System.Drawing.Size(767, 565);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.panelTitulo2);
            this.Controls.Add(this.PanelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmGridEntregas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGridEntregas";
            this.Load += new System.EventHandler(this.frmGridEntregas_Load);
            this.panelTitulo2.ResumeLayout(false);
            this.panelTitulo2.PerformLayout();
            this.PanelTitulo.ResumeLayout(false);
            this.PanelTitulo.PerformLayout();
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlBotones.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewGeneral)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panelTitulo2;
        private System.Windows.Forms.Panel PanelTitulo;
        public System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnTicket;
        private System.Windows.Forms.Button btnFecha;
        private System.Windows.Forms.Button BtnPago;
        private System.Windows.Forms.Button btnEntregar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView GridViewGeneral;
        private System.Windows.Forms.Button btnUbicacion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txt_buscador;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_statusServicio;
        private System.Windows.Forms.DataGridViewImageColumn status;
        private System.Windows.Forms.DataGridViewCheckBoxColumn entrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folio;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaentrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_ventaServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_sucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn hor_ventaServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn horaEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn cajero;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_tipoServicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_ubicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn pago;
        private System.Windows.Forms.Button btnTerminar;
    }
}