namespace PuntodeVentaTintoreria
{
    partial class frm_DatosPagoTransferencia
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDatos = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.panelNotifi = new System.Windows.Forms.Panel();
            this.picAlerta = new System.Windows.Forms.PictureBox();
            this.txt_mensaje = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbBancos = new System.Windows.Forms.ComboBox();
            this.pnl_monto = new System.Windows.Forms.Panel();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.pnl_numAuto = new System.Windows.Forms.Panel();
            this.txtNumCheque = new System.Windows.Forms.TextBox();
            this.lblCorreoSistema = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
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
            this.panelNotifi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlerta)).BeginInit();
            this.pnl_monto.SuspendLayout();
            this.pnl_numAuto.SuspendLayout();
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
            this.panelPrincipal.Size = new System.Drawing.Size(492, 487);
            this.panelPrincipal.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 405);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 82);
            this.panel1.TabIndex = 9;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackgroundImage = global::PuntodeVentaTintoreria.Properties.Resources.fondo02;
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.Location = new System.Drawing.Point(290, 25);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnLogin.Size = new System.Drawing.Size(171, 42);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "&Aceptar";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnAceptar_Click);
            this.btnLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnAceptar_KeyPress);
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
            this.panelDatos.Controls.Add(this.panelNotifi);
            this.panelDatos.Controls.Add(this.label11);
            this.panelDatos.Controls.Add(this.cmbBancos);
            this.panelDatos.Controls.Add(this.pnl_monto);
            this.panelDatos.Controls.Add(this.pnl_numAuto);
            this.panelDatos.Controls.Add(this.lblCorreoSistema);
            this.panelDatos.Controls.Add(this.label8);
            this.panelDatos.Controls.Add(this.label5);
            this.panelDatos.Controls.Add(this.label9);
            this.panelDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDatos.Location = new System.Drawing.Point(0, 95);
            this.panelDatos.Name = "panelDatos";
            this.panelDatos.Size = new System.Drawing.Size(492, 392);
            this.panelDatos.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(157, 256);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 17);
            this.label10.TabIndex = 44;
            this.label10.Text = "*";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panelNotifi
            // 
            this.panelNotifi.BackColor = System.Drawing.Color.Red;
            this.panelNotifi.Controls.Add(this.picAlerta);
            this.panelNotifi.Controls.Add(this.txt_mensaje);
            this.panelNotifi.Location = new System.Drawing.Point(8, 6);
            this.panelNotifi.Name = "panelNotifi";
            this.panelNotifi.Size = new System.Drawing.Size(476, 54);
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
            this.txt_mensaje.Location = new System.Drawing.Point(68, 3);
            this.txt_mensaje.Multiline = true;
            this.txt_mensaje.Name = "txt_mensaje";
            this.txt_mensaje.ReadOnly = true;
            this.txt_mensaje.Size = new System.Drawing.Size(401, 47);
            this.txt_mensaje.TabIndex = 24;
            this.txt_mensaje.Text = "Msg Error";
            this.txt_mensaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label11.Location = new System.Drawing.Point(106, 256);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 45;
            this.label11.Text = "MONTO";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbBancos
            // 
            this.cmbBancos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.cmbBancos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBancos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.cmbBancos.FormattingEnabled = true;
            this.cmbBancos.Location = new System.Drawing.Point(176, 176);
            this.cmbBancos.Name = "cmbBancos";
            this.cmbBancos.Size = new System.Drawing.Size(285, 28);
            this.cmbBancos.TabIndex = 4;
            // 
            // pnl_monto
            // 
            this.pnl_monto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.pnl_monto.Controls.Add(this.txtMonto);
            this.pnl_monto.Location = new System.Drawing.Point(180, 245);
            this.pnl_monto.Name = "pnl_monto";
            this.pnl_monto.Size = new System.Drawing.Size(281, 35);
            this.pnl_monto.TabIndex = 37;
            // 
            // txtMonto
            // 
            this.txtMonto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtMonto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMonto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtMonto.Location = new System.Drawing.Point(3, 6);
            this.txtMonto.MaxLength = 30;
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(275, 22);
            this.txtMonto.TabIndex = 5;
            this.txtMonto.Text = "0.00";
            this.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            this.txtMonto.Validating += new System.ComponentModel.CancelEventHandler(this.txtMonto_Validating);
            // 
            // pnl_numAuto
            // 
            this.pnl_numAuto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.pnl_numAuto.Controls.Add(this.txtNumCheque);
            this.pnl_numAuto.Location = new System.Drawing.Point(176, 101);
            this.pnl_numAuto.Name = "pnl_numAuto";
            this.pnl_numAuto.Size = new System.Drawing.Size(285, 35);
            this.pnl_numAuto.TabIndex = 38;
            // 
            // txtNumCheque
            // 
            this.txtNumCheque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNumCheque.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumCheque.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumCheque.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtNumCheque.Location = new System.Drawing.Point(4, 6);
            this.txtNumCheque.MaxLength = 30;
            this.txtNumCheque.Name = "txtNumCheque";
            this.txtNumCheque.Size = new System.Drawing.Size(278, 22);
            this.txtNumCheque.TabIndex = 3;
            this.txtNumCheque.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNumCheque_KeyDown);
            this.txtNumCheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumCheque_KeyPress);
            this.txtNumCheque.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtNumCheque_MouseDown);
            this.txtNumCheque.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumCheque_Validating);
            // 
            // lblCorreoSistema
            // 
            this.lblCorreoSistema.AutoSize = true;
            this.lblCorreoSistema.BackColor = System.Drawing.Color.Transparent;
            this.lblCorreoSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCorreoSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreoSistema.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblCorreoSistema.Location = new System.Drawing.Point(20, 112);
            this.lblCorreoSistema.Name = "lblCorreoSistema";
            this.lblCorreoSistema.Size = new System.Drawing.Size(136, 13);
            this.lblCorreoSistema.TabIndex = 41;
            this.lblCorreoSistema.Text = "NÚM. AUTORIZACIÓN";
            this.lblCorreoSistema.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(153, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 17);
            this.label8.TabIndex = 42;
            this.label8.Text = "*";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(157, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 17);
            this.label5.TabIndex = 40;
            this.label5.Text = "*";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label9.Location = new System.Drawing.Point(103, 180);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "BANCO";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelTitulo2
            // 
            this.panelTitulo2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            this.panelTitulo2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo2.Location = new System.Drawing.Point(0, 47);
            this.panelTitulo2.Name = "panelTitulo2";
            this.panelTitulo2.Size = new System.Drawing.Size(492, 48);
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
            this.PanelTitulo.Size = new System.Drawing.Size(492, 47);
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
            this.lblTitulo.Size = new System.Drawing.Size(216, 20);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Datos de la Transferencia";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.btnMinimizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Image = global::PuntodeVentaTintoreria.Properties.Resources.top_minimizar;
            this.btnMinimizar.Location = new System.Drawing.Point(409, 9);
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
            this.btnSalir.Location = new System.Drawing.Point(447, 9);
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
            // frm_DatosPagoTransferencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(196)))), ((int)(((byte)(213)))));
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.ControlBox = false;
            this.Controls.Add(this.panelPrincipal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_DatosPagoTransferencia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_DatosPagoTransferencia_Load);
            this.panelPrincipal.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelDatos.ResumeLayout(false);
            this.panelDatos.PerformLayout();
            this.panelNotifi.ResumeLayout(false);
            this.panelNotifi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAlerta)).EndInit();
            this.pnl_monto.ResumeLayout(false);
            this.pnl_monto.PerformLayout();
            this.pnl_numAuto.ResumeLayout(false);
            this.pnl_numAuto.PerformLayout();
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
        private System.Windows.Forms.TextBox txtNumCheque;
        private System.Windows.Forms.Panel panelNotifi;
        private System.Windows.Forms.PictureBox picAlerta;
        private System.Windows.Forms.TextBox txt_mensaje;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Timer timeLogin;
        private System.ComponentModel.BackgroundWorker bgw_LoginInit;
        private System.ComponentModel.BackgroundWorker bgw_ImagenInit;
        private System.Windows.Forms.ToolTip toolTipLogin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbBancos;
        private System.Windows.Forms.Panel pnl_monto;
        private System.Windows.Forms.Panel pnl_numAuto;
        private System.Windows.Forms.Label lblCorreoSistema;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMonto;
    }
}

