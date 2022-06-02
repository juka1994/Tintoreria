namespace PuntodeVentaTintoreria
{
    partial class frm_PedirTipoVenta
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
            this.label1 = new System.Windows.Forms.Label();
            this.panelDatos = new System.Windows.Forms.Panel();
            this.btnPagoPendiente = new System.Windows.Forms.Button();
            this.btnAnticipo = new System.Windows.Forms.Button();
            this.btnPrepago = new System.Windows.Forms.Button();
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
            this.panelPrincipal.Size = new System.Drawing.Size(542, 387);
            this.panelPrincipal.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 352);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 35);
            this.panel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Sistema Tintorería";
            // 
            // panelDatos
            // 
            this.panelDatos.Controls.Add(this.btnPagoPendiente);
            this.panelDatos.Controls.Add(this.btnAnticipo);
            this.panelDatos.Controls.Add(this.btnPrepago);
            this.panelDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDatos.Location = new System.Drawing.Point(0, 95);
            this.panelDatos.Name = "panelDatos";
            this.panelDatos.Size = new System.Drawing.Size(542, 292);
            this.panelDatos.TabIndex = 8;
            // 
            // btnPagoPendiente
            // 
            this.btnPagoPendiente.BackColor = System.Drawing.Color.Transparent;
            this.btnPagoPendiente.BackgroundImage = global::PuntodeVentaTintoreria.Properties.Resources.fondo02;
            this.btnPagoPendiente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPagoPendiente.FlatAppearance.BorderSize = 0;
            this.btnPagoPendiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPagoPendiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagoPendiente.ForeColor = System.Drawing.Color.White;
            this.btnPagoPendiente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPagoPendiente.Location = new System.Drawing.Point(118, 185);
            this.btnPagoPendiente.Name = "btnPagoPendiente";
            this.btnPagoPendiente.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnPagoPendiente.Size = new System.Drawing.Size(305, 42);
            this.btnPagoPendiente.TabIndex = 28;
            this.btnPagoPendiente.Text = "Pago &Pendiente";
            this.btnPagoPendiente.UseVisualStyleBackColor = false;
            this.btnPagoPendiente.Click += new System.EventHandler(this.btnPagoPendiente_Click);
            // 
            // btnAnticipo
            // 
            this.btnAnticipo.BackColor = System.Drawing.Color.Transparent;
            this.btnAnticipo.BackgroundImage = global::PuntodeVentaTintoreria.Properties.Resources.fondo02;
            this.btnAnticipo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAnticipo.FlatAppearance.BorderSize = 0;
            this.btnAnticipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnticipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnticipo.ForeColor = System.Drawing.Color.White;
            this.btnAnticipo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnticipo.Location = new System.Drawing.Point(118, 112);
            this.btnAnticipo.Name = "btnAnticipo";
            this.btnAnticipo.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnAnticipo.Size = new System.Drawing.Size(305, 42);
            this.btnAnticipo.TabIndex = 27;
            this.btnAnticipo.Text = "&Anticipo";
            this.btnAnticipo.UseVisualStyleBackColor = false;
            this.btnAnticipo.Click += new System.EventHandler(this.btnAnticipo_Click);
            // 
            // btnPrepago
            // 
            this.btnPrepago.BackColor = System.Drawing.Color.Transparent;
            this.btnPrepago.BackgroundImage = global::PuntodeVentaTintoreria.Properties.Resources.fondo02;
            this.btnPrepago.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrepago.FlatAppearance.BorderSize = 0;
            this.btnPrepago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrepago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrepago.ForeColor = System.Drawing.Color.White;
            this.btnPrepago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrepago.Location = new System.Drawing.Point(118, 39);
            this.btnPrepago.Name = "btnPrepago";
            this.btnPrepago.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnPrepago.Size = new System.Drawing.Size(305, 42);
            this.btnPrepago.TabIndex = 26;
            this.btnPrepago.Text = "P&repago";
            this.btnPrepago.UseVisualStyleBackColor = false;
            this.btnPrepago.Click += new System.EventHandler(this.btnPrepago_Click);
            // 
            // panelTitulo2
            // 
            this.panelTitulo2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            this.panelTitulo2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo2.Location = new System.Drawing.Point(0, 47);
            this.panelTitulo2.Name = "panelTitulo2";
            this.panelTitulo2.Size = new System.Drawing.Size(542, 48);
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
            this.PanelTitulo.Size = new System.Drawing.Size(542, 47);
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
            this.lblTitulo.Size = new System.Drawing.Size(148, 25);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Tipo de Venta";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.btnMinimizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Image = global::PuntodeVentaTintoreria.Properties.Resources.top_minimizar;
            this.btnMinimizar.Location = new System.Drawing.Point(459, 9);
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
            this.btnSalir.Location = new System.Drawing.Point(497, 9);
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
            // frm_PedirTipoVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(196)))), ((int)(((byte)(213)))));
            this.ClientSize = new System.Drawing.Size(550, 400);
            this.ControlBox = false;
            this.Controls.Add(this.panelPrincipal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_PedirTipoVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_PedirCadenaTexto_Load);
            this.panelPrincipal.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelDatos.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnPrepago;
        private System.Windows.Forms.Timer timeLogin;
        private System.ComponentModel.BackgroundWorker bgw_LoginInit;
        private System.ComponentModel.BackgroundWorker bgw_ImagenInit;
        private System.Windows.Forms.ToolTip toolTipLogin;
        private System.Windows.Forms.Button btnPagoPendiente;
        private System.Windows.Forms.Button btnAnticipo;
    }
}

