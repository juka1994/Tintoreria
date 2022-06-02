namespace PuntodeVentaTintoreria
{
    partial class Frm_Reporte
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
            this.PanelTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.panel_cabecera = new System.Windows.Forms.Panel();
            this.cmbCaja = new BetterComboBox.BetterComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_equipo = new BetterComboBox.BetterComboBox();
            this.lblFechaF = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtp_fechaCajaFin = new System.Windows.Forms.DateTimePicker();
            this.dtp_fechaCajaInicio = new System.Windows.Forms.DateTimePicker();
            this.txt_nombreUsuario = new System.Windows.Forms.Label();
            this.LblFechaFin = new System.Windows.Forms.Label();
            this.cmb_sucursal = new BetterComboBox.BetterComboBox();
            this.BtnGenerar = new System.Windows.Forms.Button();
            this.RvPrincipal = new Microsoft.Reporting.WinForms.ReportViewer();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.PanelTitulo.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.panel_cabecera.SuspendLayout();
            this.SuspendLayout();
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
            this.PanelTitulo.Size = new System.Drawing.Size(1024, 47);
            this.PanelTitulo.TabIndex = 11;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(8, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(74, 20);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Reporte";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.btnMinimizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Image = global::PuntodeVentaTintoreria.Properties.Resources.top_minimizar;
            this.btnMinimizar.Location = new System.Drawing.Point(941, 9);
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
            this.btnSalir.Location = new System.Drawing.Point(979, 9);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(30, 31);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.pnlPrincipal.Controls.Add(this.panel_cabecera);
            this.pnlPrincipal.Controls.Add(this.RvPrincipal);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 47);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(1024, 653);
            this.pnlPrincipal.TabIndex = 13;
            // 
            // panel_cabecera
            // 
            this.panel_cabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(210)))), ((int)(((byte)(213)))));
            this.panel_cabecera.Controls.Add(this.cmbCaja);
            this.panel_cabecera.Controls.Add(this.label2);
            this.panel_cabecera.Controls.Add(this.cmb_equipo);
            this.panel_cabecera.Controls.Add(this.lblFechaF);
            this.panel_cabecera.Controls.Add(this.lblFechaInicio);
            this.panel_cabecera.Controls.Add(this.dtp_fechaCajaFin);
            this.panel_cabecera.Controls.Add(this.dtp_fechaCajaInicio);
            this.panel_cabecera.Controls.Add(this.txt_nombreUsuario);
            this.panel_cabecera.Controls.Add(this.LblFechaFin);
            this.panel_cabecera.Controls.Add(this.cmb_sucursal);
            this.panel_cabecera.Controls.Add(this.BtnGenerar);
            this.panel_cabecera.Location = new System.Drawing.Point(0, 0);
            this.panel_cabecera.Name = "panel_cabecera";
            this.panel_cabecera.Size = new System.Drawing.Size(1024, 79);
            this.panel_cabecera.TabIndex = 116;
            // 
            // cmbCaja
            // 
            this.cmbCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCaja.FormattingEnabled = true;
            this.cmbCaja.Location = new System.Drawing.Point(338, -14);
            this.cmbCaja.Name = "cmbCaja";
            this.cmbCaja.Size = new System.Drawing.Size(270, 32);
            this.cmbCaja.TabIndex = 1000015;
            this.cmbCaja.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(405, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 23);
            this.label2.TabIndex = 1000014;
            this.label2.Text = "Equipo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmb_equipo
            // 
            this.cmb_equipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_equipo.FormattingEnabled = true;
            this.cmb_equipo.Location = new System.Drawing.Point(338, 41);
            this.cmb_equipo.Name = "cmb_equipo";
            this.cmb_equipo.Size = new System.Drawing.Size(270, 32);
            this.cmb_equipo.TabIndex = 1000013;
            // 
            // lblFechaF
            // 
            this.lblFechaF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaF.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaF.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblFechaF.Location = new System.Drawing.Point(627, 50);
            this.lblFechaF.Name = "lblFechaF";
            this.lblFechaF.Size = new System.Drawing.Size(96, 23);
            this.lblFechaF.TabIndex = 1000012;
            this.lblFechaF.Text = "Fecha Fin:";
            this.lblFechaF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFechaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaInicio.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblFechaInicio.Location = new System.Drawing.Point(622, 12);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(105, 23);
            this.lblFechaInicio.TabIndex = 1000011;
            this.lblFechaInicio.Text = "Fecha Inicio:";
            this.lblFechaInicio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtp_fechaCajaFin
            // 
            this.dtp_fechaCajaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_fechaCajaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fechaCajaFin.Location = new System.Drawing.Point(735, 50);
            this.dtp_fechaCajaFin.Name = "dtp_fechaCajaFin";
            this.dtp_fechaCajaFin.Size = new System.Drawing.Size(120, 26);
            this.dtp_fechaCajaFin.TabIndex = 1000010;
            // 
            // dtp_fechaCajaInicio
            // 
            this.dtp_fechaCajaInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_fechaCajaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fechaCajaInicio.Location = new System.Drawing.Point(736, 12);
            this.dtp_fechaCajaInicio.Name = "dtp_fechaCajaInicio";
            this.dtp_fechaCajaInicio.Size = new System.Drawing.Size(120, 26);
            this.dtp_fechaCajaInicio.TabIndex = 1000009;
            this.dtp_fechaCajaInicio.ValueChanged += new System.EventHandler(this.dtp_fechaCajaInicio_ValueChanged);
            // 
            // txt_nombreUsuario
            // 
            this.txt_nombreUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_nombreUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nombreUsuario.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_nombreUsuario.Location = new System.Drawing.Point(101, 12);
            this.txt_nombreUsuario.Name = "txt_nombreUsuario";
            this.txt_nombreUsuario.Size = new System.Drawing.Size(96, 23);
            this.txt_nombreUsuario.TabIndex = 1000006;
            this.txt_nombreUsuario.Text = "Sucursal";
            this.txt_nombreUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblFechaFin
            // 
            this.LblFechaFin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LblFechaFin.AutoSize = true;
            this.LblFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFechaFin.ForeColor = System.Drawing.Color.White;
            this.LblFechaFin.Location = new System.Drawing.Point(464, -242);
            this.LblFechaFin.Name = "LblFechaFin";
            this.LblFechaFin.Size = new System.Drawing.Size(84, 20);
            this.LblFechaFin.TabIndex = 7;
            this.LblFechaFin.Text = "Fecha fin";
            // 
            // cmb_sucursal
            // 
            this.cmb_sucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_sucursal.FormattingEnabled = true;
            this.cmb_sucursal.Location = new System.Drawing.Point(47, 41);
            this.cmb_sucursal.Name = "cmb_sucursal";
            this.cmb_sucursal.Size = new System.Drawing.Size(259, 32);
            this.cmb_sucursal.TabIndex = 5;
            this.cmb_sucursal.SelectedValueChanged += new System.EventHandler(this.cmb_sucursal_SelectedValueChanged);
            // 
            // BtnGenerar
            // 
            this.BtnGenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.BtnGenerar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGenerar.ForeColor = System.Drawing.Color.Black;
            this.BtnGenerar.Location = new System.Drawing.Point(861, 19);
            this.BtnGenerar.Name = "BtnGenerar";
            this.BtnGenerar.Size = new System.Drawing.Size(148, 43);
            this.BtnGenerar.TabIndex = 0;
            this.BtnGenerar.Text = "Generar reporte";
            this.BtnGenerar.UseVisualStyleBackColor = false;
            this.BtnGenerar.Click += new System.EventHandler(this.BtnGenerar_Click);
            // 
            // RvPrincipal
            // 
            this.RvPrincipal.Location = new System.Drawing.Point(0, 79);
            this.RvPrincipal.Name = "RvPrincipal";
            this.RvPrincipal.ServerReport.BearerToken = null;
            this.RvPrincipal.Size = new System.Drawing.Size(1024, 574);
            this.RvPrincipal.TabIndex = 115;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // Frm_Reporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 700);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.PanelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Reporte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Reportes";
            this.Load += new System.EventHandler(this.Frm_Reporte_Load);
            this.PanelTitulo.ResumeLayout(false);
            this.PanelTitulo.PerformLayout();
            this.pnlPrincipal.ResumeLayout(false);
            this.panel_cabecera.ResumeLayout(false);
            this.panel_cabecera.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelTitulo;
        public System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlPrincipal;
        private Microsoft.Reporting.WinForms.ReportViewer RvPrincipal;
        private System.Windows.Forms.Panel panel_cabecera;
        private System.Windows.Forms.Button BtnGenerar;
        private BetterComboBox.BetterComboBox cmb_sucursal;
        public System.Windows.Forms.Label LblFechaFin;
        private System.Windows.Forms.Label txt_nombreUsuario;
        private System.Windows.Forms.Label lblFechaF;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtp_fechaCajaFin;
        private System.Windows.Forms.DateTimePicker dtp_fechaCajaInicio;
        private System.Windows.Forms.Label label2;
        private BetterComboBox.BetterComboBox cmb_equipo;
        private BetterComboBox.BetterComboBox cmbCaja;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}