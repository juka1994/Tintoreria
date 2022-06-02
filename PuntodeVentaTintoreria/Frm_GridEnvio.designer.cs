namespace PuntodeVentaTintoreria
{
    partial class Frm_GridEnvio
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_GridEnvio));
            this.PanelTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.GridViewGeneral = new System.Windows.Forms.DataGridView();
            this.id_envio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chofer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadEntrega = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadEntregada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_LLegadaEnvio = new System.Windows.Forms.Button();
            this.btnGenerarHoja = new System.Windows.Forms.Button();
            this.BtnNuevoEnvio = new System.Windows.Forms.Button();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.PanelTitulo.SuspendLayout();
            this.pnlPrincipal.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewGeneral)).BeginInit();
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
            this.PanelTitulo.Size = new System.Drawing.Size(683, 47);
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
            this.lblTitulo.Size = new System.Drawing.Size(53, 20);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Envìo";
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.pnlPrincipal.Controls.Add(this.pnlBotones);
            this.pnlPrincipal.Controls.Add(this.panel3);
            this.pnlPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 47);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(683, 424);
            this.pnlPrincipal.TabIndex = 13;
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.DarkGray;
            this.pnlBotones.Controls.Add(this.btn_LLegadaEnvio);
            this.pnlBotones.Controls.Add(this.btnGenerarHoja);
            this.pnlBotones.Controls.Add(this.BtnNuevoEnvio);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 344);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(683, 80);
            this.pnlBotones.TabIndex = 114;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.panel3.Controls.Add(this.GridViewGeneral);
            this.panel3.Location = new System.Drawing.Point(12, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(660, 290);
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
            this.id_envio,
            this.chofer,
            this.vehiculo,
            this.CantidadEntrega,
            this.CantidadEntregada});
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
            this.GridViewGeneral.Size = new System.Drawing.Size(660, 290);
            this.GridViewGeneral.TabIndex = 4;
            // 
            // id_envio
            // 
            this.id_envio.DataPropertyName = "id_envio";
            this.id_envio.HeaderText = "id_envio";
            this.id_envio.Name = "id_envio";
            this.id_envio.ReadOnly = true;
            this.id_envio.Visible = false;
            // 
            // chofer
            // 
            this.chofer.DataPropertyName = "chofer";
            this.chofer.HeaderText = "CHOFER";
            this.chofer.Name = "chofer";
            this.chofer.ReadOnly = true;
            this.chofer.Width = 250;
            // 
            // vehiculo
            // 
            this.vehiculo.DataPropertyName = "vehiculo";
            this.vehiculo.HeaderText = "VEHÌCULO";
            this.vehiculo.Name = "vehiculo";
            this.vehiculo.ReadOnly = true;
            this.vehiculo.Width = 250;
            // 
            // CantidadEntrega
            // 
            this.CantidadEntrega.DataPropertyName = "Numero";
            this.CantidadEntrega.HeaderText = "CANT. TOTAL";
            this.CantidadEntrega.Name = "CantidadEntrega";
            this.CantidadEntrega.ReadOnly = true;
            this.CantidadEntrega.Width = 150;
            // 
            // CantidadEntregada
            // 
            this.CantidadEntregada.DataPropertyName = "Entregado";
            this.CantidadEntregada.HeaderText = "CANT. ENTREGADA";
            this.CantidadEntregada.Name = "CantidadEntregada";
            this.CantidadEntregada.ReadOnly = true;
            this.CantidadEntregada.Width = 150;
            // 
            // btn_LLegadaEnvio
            // 
            this.btn_LLegadaEnvio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_LLegadaEnvio.BackColor = System.Drawing.Color.Silver;
            this.btn_LLegadaEnvio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btn_LLegadaEnvio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_LLegadaEnvio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LLegadaEnvio.ForeColor = System.Drawing.Color.Black;
            this.btn_LLegadaEnvio.Image = global::PuntodeVentaTintoreria.Properties.Resources.Llegada_45px;
            this.btn_LLegadaEnvio.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_LLegadaEnvio.Location = new System.Drawing.Point(593, 4);
            this.btn_LLegadaEnvio.Name = "btn_LLegadaEnvio";
            this.btn_LLegadaEnvio.Size = new System.Drawing.Size(85, 72);
            this.btn_LLegadaEnvio.TabIndex = 3;
            this.btn_LLegadaEnvio.Text = "Llegadas";
            this.btn_LLegadaEnvio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_LLegadaEnvio.UseVisualStyleBackColor = false;
            this.btn_LLegadaEnvio.Click += new System.EventHandler(this.btn_LLegadaEnvio_Click);
            // 
            // btnGenerarHoja
            // 
            this.btnGenerarHoja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerarHoja.BackColor = System.Drawing.Color.Silver;
            this.btnGenerarHoja.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btnGenerarHoja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarHoja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarHoja.ForeColor = System.Drawing.Color.Black;
            this.btnGenerarHoja.Image = global::PuntodeVentaTintoreria.Properties.Resources.Entrega_list_45px;
            this.btnGenerarHoja.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGenerarHoja.Location = new System.Drawing.Point(504, 4);
            this.btnGenerarHoja.Name = "btnGenerarHoja";
            this.btnGenerarHoja.Size = new System.Drawing.Size(85, 72);
            this.btnGenerarHoja.TabIndex = 3;
            this.btnGenerarHoja.Text = "Entregas";
            this.btnGenerarHoja.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGenerarHoja.UseVisualStyleBackColor = false;
            this.btnGenerarHoja.Click += new System.EventHandler(this.btnGenerarHoja_Click);
            // 
            // BtnNuevoEnvio
            // 
            this.BtnNuevoEnvio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnNuevoEnvio.BackColor = System.Drawing.Color.Silver;
            this.BtnNuevoEnvio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.BtnNuevoEnvio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNuevoEnvio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnNuevoEnvio.ForeColor = System.Drawing.Color.Black;
            this.BtnNuevoEnvio.Image = ((System.Drawing.Image)(resources.GetObject("BtnNuevoEnvio.Image")));
            this.BtnNuevoEnvio.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnNuevoEnvio.Location = new System.Drawing.Point(416, 4);
            this.BtnNuevoEnvio.Name = "BtnNuevoEnvio";
            this.BtnNuevoEnvio.Size = new System.Drawing.Size(85, 72);
            this.BtnNuevoEnvio.TabIndex = 2;
            this.BtnNuevoEnvio.Text = "Nuevo";
            this.BtnNuevoEnvio.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnNuevoEnvio.UseVisualStyleBackColor = false;
            this.BtnNuevoEnvio.Click += new System.EventHandler(this.BtnNuevoEnvio_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.btnMinimizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Image = global::PuntodeVentaTintoreria.Properties.Resources.top_minimizar;
            this.btnMinimizar.Location = new System.Drawing.Point(600, 9);
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
            this.btnSalir.Location = new System.Drawing.Point(638, 9);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(30, 31);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Frm_GridEnvio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 471);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.PanelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_GridEnvio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_GridEnvio";
            this.Load += new System.EventHandler(this.Frm_GridEnvio_Load);
            this.PanelTitulo.ResumeLayout(false);
            this.PanelTitulo.PerformLayout();
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlBotones.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewGeneral)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelTitulo;
        public System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlPrincipal;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button BtnNuevoEnvio;
        //private System.Windows.Forms.Button button29;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView GridViewGeneral;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_envio;
        private System.Windows.Forms.DataGridViewTextBoxColumn chofer;
        private System.Windows.Forms.DataGridViewTextBoxColumn vehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadEntregada;
        private System.Windows.Forms.Button btnGenerarHoja;
        private System.Windows.Forms.Button btn_LLegadaEnvio;
    }
}