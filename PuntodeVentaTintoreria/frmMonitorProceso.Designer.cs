namespace PuntodeVentaTintoreria
{
    partial class frmMonitorProceso
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
            this.panelEspera = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTitulo2 = new System.Windows.Forms.Panel();
            this.btnPrepago = new System.Windows.Forms.Button();
            this.lblPrenda = new System.Windows.Forms.Label();
            this.PanelTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelPrincipal.SuspendLayout();
            this.panelEspera.SuspendLayout();
            this.panelTitulo2.SuspendLayout();
            this.PanelTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPrincipal.BackColor = System.Drawing.Color.White;
            this.panelPrincipal.Controls.Add(this.panelEspera);
            this.panelPrincipal.Controls.Add(this.panelTitulo2);
            this.panelPrincipal.Controls.Add(this.PanelTitulo);
            this.panelPrincipal.Location = new System.Drawing.Point(4, 7);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(1272, 407);
            this.panelPrincipal.TabIndex = 0;
            // 
            // panelEspera
            // 
            this.panelEspera.AutoScroll = true;
            this.panelEspera.Controls.Add(this.label1);
            this.panelEspera.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEspera.Location = new System.Drawing.Point(0, 95);
            this.panelEspera.Name = "panelEspera";
            this.panelEspera.Size = new System.Drawing.Size(1272, 312);
            this.panelEspera.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1272, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Servicios en Espera";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTitulo2
            // 
            this.panelTitulo2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            this.panelTitulo2.Controls.Add(this.btnPrepago);
            this.panelTitulo2.Controls.Add(this.lblPrenda);
            this.panelTitulo2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo2.Location = new System.Drawing.Point(0, 47);
            this.panelTitulo2.Name = "panelTitulo2";
            this.panelTitulo2.Size = new System.Drawing.Size(1272, 48);
            this.panelTitulo2.TabIndex = 7;
            // 
            // btnPrepago
            // 
            this.btnPrepago.BackColor = System.Drawing.Color.Transparent;
            this.btnPrepago.BackgroundImage = global::PuntodeVentaTintoreria.Properties.Resources.fondo02;
            this.btnPrepago.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPrepago.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPrepago.FlatAppearance.BorderSize = 2;
            this.btnPrepago.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrepago.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrepago.ForeColor = System.Drawing.Color.White;
            this.btnPrepago.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrepago.Location = new System.Drawing.Point(8, 5);
            this.btnPrepago.Name = "btnPrepago";
            this.btnPrepago.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.btnPrepago.Size = new System.Drawing.Size(155, 37);
            this.btnPrepago.TabIndex = 27;
            this.btnPrepago.Text = "&Refrescar";
            this.btnPrepago.UseVisualStyleBackColor = false;
            this.btnPrepago.Click += new System.EventHandler(this.btnPrepago_Click);
            // 
            // lblPrenda
            // 
            this.lblPrenda.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblPrenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrenda.ForeColor = System.Drawing.Color.White;
            this.lblPrenda.Location = new System.Drawing.Point(169, 8);
            this.lblPrenda.Name = "lblPrenda";
            this.lblPrenda.Size = new System.Drawing.Size(183, 30);
            this.lblPrenda.TabIndex = 4;
            this.lblPrenda.Text = "00:00";
            this.lblPrenda.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.PanelTitulo.Size = new System.Drawing.Size(1272, 47);
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
            this.lblTitulo.Size = new System.Drawing.Size(240, 20);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Seleccione el tipo de artículo";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.btnMinimizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Image = global::PuntodeVentaTintoreria.Properties.Resources.top_minimizar;
            this.btnMinimizar.Location = new System.Drawing.Point(1189, 9);
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
            this.btnSalir.Location = new System.Drawing.Point(1227, 9);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(30, 31);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // frmMonitorProceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(196)))), ((int)(((byte)(213)))));
            this.ClientSize = new System.Drawing.Size(1280, 420);
            this.ControlBox = false;
            this.Controls.Add(this.panelPrincipal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMonitorProceso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmSelSubTipoPrenda_Load);
            this.panelPrincipal.ResumeLayout(false);
            this.panelEspera.ResumeLayout(false);
            this.panelTitulo2.ResumeLayout(false);
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
        public System.Windows.Forms.Label lblPrenda;
        public System.Windows.Forms.Panel panelEspera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPrepago;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

