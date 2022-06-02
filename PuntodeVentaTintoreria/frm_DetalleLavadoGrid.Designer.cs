namespace PuntodeVentaTintoreria
{
    partial class frm_DetalleLavadoGrid
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanelTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btn_FinalizarLavadoDetalle = new System.Windows.Forms.Button();
            this.btnEntregar = new System.Windows.Forms.Button();
            this.GridViewGeneral = new System.Windows.Forms.DataGridView();
            this.id_lavado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_lavadoDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_cabecera = new System.Windows.Forms.Panel();
            this.btn_nuevoDetalleLavado = new System.Windows.Forms.Button();
            this.PanelTitulo.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewGeneral)).BeginInit();
            this.panel_cabecera.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelTitulo
            // 
            this.PanelTitulo.AutoSize = true;
            this.PanelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.PanelTitulo.Controls.Add(this.lblTitulo);
            this.PanelTitulo.Controls.Add(this.btnMinimizar);
            this.PanelTitulo.Controls.Add(this.btnSalir);
            this.PanelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitulo.Location = new System.Drawing.Point(0, 0);
            this.PanelTitulo.Name = "PanelTitulo";
            this.PanelTitulo.Size = new System.Drawing.Size(800, 53);
            this.PanelTitulo.TabIndex = 16;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(8, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(154, 20);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Detalle de Lavado";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.btnMinimizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Image = global::PuntodeVentaTintoreria.Properties.Resources.top_minimizar;
            this.btnMinimizar.Location = new System.Drawing.Point(717, 19);
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
            this.btnSalir.Location = new System.Drawing.Point(755, 19);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(30, 31);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.DarkGray;
            this.pnlBotones.Controls.Add(this.btn_FinalizarLavadoDetalle);
            this.pnlBotones.Controls.Add(this.btnEntregar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 316);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(800, 87);
            this.pnlBotones.TabIndex = 151;
            // 
            // btn_FinalizarLavadoDetalle
            // 
            this.btn_FinalizarLavadoDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_FinalizarLavadoDetalle.BackColor = System.Drawing.Color.Silver;
            this.btn_FinalizarLavadoDetalle.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btn_FinalizarLavadoDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_FinalizarLavadoDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_FinalizarLavadoDetalle.ForeColor = System.Drawing.Color.Black;
            this.btn_FinalizarLavadoDetalle.Image = global::PuntodeVentaTintoreria.Properties.Resources.icono_listo_44x44B;
            this.btn_FinalizarLavadoDetalle.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_FinalizarLavadoDetalle.Location = new System.Drawing.Point(700, 3);
            this.btn_FinalizarLavadoDetalle.Name = "btn_FinalizarLavadoDetalle";
            this.btn_FinalizarLavadoDetalle.Size = new System.Drawing.Size(85, 80);
            this.btn_FinalizarLavadoDetalle.TabIndex = 2;
            this.btn_FinalizarLavadoDetalle.Text = "Finalizar";
            this.btn_FinalizarLavadoDetalle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_FinalizarLavadoDetalle.UseVisualStyleBackColor = false;
            this.btn_FinalizarLavadoDetalle.Click += new System.EventHandler(this.btn_FinalizarLavadoDetalle_Click);
            // 
            // btnEntregar
            // 
            this.btnEntregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEntregar.BackColor = System.Drawing.Color.Silver;
            this.btnEntregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btnEntregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntregar.ForeColor = System.Drawing.Color.Black;
            this.btnEntregar.Image = global::PuntodeVentaTintoreria.Properties.Resources.edit_file_50px;
            this.btnEntregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEntregar.Location = new System.Drawing.Point(611, 3);
            this.btnEntregar.Name = "btnEntregar";
            this.btnEntregar.Size = new System.Drawing.Size(85, 80);
            this.btnEntregar.TabIndex = 1;
            this.btnEntregar.Text = "Modificar";
            this.btnEntregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEntregar.UseVisualStyleBackColor = false;
            this.btnEntregar.Click += new System.EventHandler(this.btnEntregar_Click);
            // 
            // GridViewGeneral
            // 
            this.GridViewGeneral.AllowUserToAddRows = false;
            this.GridViewGeneral.AllowUserToDeleteRows = false;
            this.GridViewGeneral.AllowUserToOrderColumns = true;
            this.GridViewGeneral.AllowUserToResizeColumns = false;
            this.GridViewGeneral.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            this.GridViewGeneral.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.GridViewGeneral.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridViewGeneral.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.GridViewGeneral.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridViewGeneral.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GridViewGeneral.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(230)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(8);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridViewGeneral.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.GridViewGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewGeneral.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_lavado,
            this.id_status,
            this.id_lavadoDetalle,
            this.nombreProducto,
            this.cantidad,
            this.unidadMedida,
            this.status});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridViewGeneral.DefaultCellStyle = dataGridViewCellStyle8;
            this.GridViewGeneral.EnableHeadersVisualStyles = false;
            this.GridViewGeneral.GridColor = System.Drawing.Color.White;
            this.GridViewGeneral.Location = new System.Drawing.Point(0, 102);
            this.GridViewGeneral.MultiSelect = false;
            this.GridViewGeneral.Name = "GridViewGeneral";
            this.GridViewGeneral.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridViewGeneral.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GridViewGeneral.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.GridViewGeneral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewGeneral.Size = new System.Drawing.Size(800, 211);
            this.GridViewGeneral.TabIndex = 177;
            // 
            // id_lavado
            // 
            this.id_lavado.DataPropertyName = "id_lavado";
            this.id_lavado.HeaderText = "id_lavado";
            this.id_lavado.Name = "id_lavado";
            this.id_lavado.ReadOnly = true;
            this.id_lavado.Visible = false;
            // 
            // id_status
            // 
            this.id_status.DataPropertyName = "id_statusLavado";
            this.id_status.HeaderText = "id_status";
            this.id_status.Name = "id_status";
            this.id_status.ReadOnly = true;
            this.id_status.Visible = false;
            // 
            // id_lavadoDetalle
            // 
            this.id_lavadoDetalle.DataPropertyName = "id_lavadoDetalle";
            this.id_lavadoDetalle.HeaderText = "id_lavadoDetalle";
            this.id_lavadoDetalle.Name = "id_lavadoDetalle";
            this.id_lavadoDetalle.ReadOnly = true;
            this.id_lavadoDetalle.Visible = false;
            // 
            // nombreProducto
            // 
            this.nombreProducto.DataPropertyName = "nombreProducto";
            this.nombreProducto.HeaderText = "Producto";
            this.nombreProducto.Name = "nombreProducto";
            this.nombreProducto.ReadOnly = true;
            // 
            // cantidad
            // 
            this.cantidad.DataPropertyName = "cantidad";
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // unidadMedida
            // 
            this.unidadMedida.DataPropertyName = "descripcion";
            this.unidadMedida.HeaderText = "Unidad de medida";
            this.unidadMedida.Name = "unidadMedida";
            this.unidadMedida.ReadOnly = true;
            // 
            // status
            // 
            this.status.DataPropertyName = "estatus";
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // panel_cabecera
            // 
            this.panel_cabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(210)))), ((int)(((byte)(213)))));
            this.panel_cabecera.Controls.Add(this.btn_nuevoDetalleLavado);
            this.panel_cabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_cabecera.Location = new System.Drawing.Point(0, 53);
            this.panel_cabecera.Name = "panel_cabecera";
            this.panel_cabecera.Size = new System.Drawing.Size(800, 50);
            this.panel_cabecera.TabIndex = 178;
            // 
            // btn_nuevoDetalleLavado
            // 
            this.btn_nuevoDetalleLavado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_nuevoDetalleLavado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_nuevoDetalleLavado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nuevoDetalleLavado.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_nuevoDetalleLavado.Location = new System.Drawing.Point(2, 0);
            this.btn_nuevoDetalleLavado.Name = "btn_nuevoDetalleLavado";
            this.btn_nuevoDetalleLavado.Size = new System.Drawing.Size(276, 43);
            this.btn_nuevoDetalleLavado.TabIndex = 0;
            this.btn_nuevoDetalleLavado.Text = "Nuevos Productos de lavado";
            this.btn_nuevoDetalleLavado.UseVisualStyleBackColor = false;
            this.btn_nuevoDetalleLavado.Click += new System.EventHandler(this.btn_nuevoDetalleLavado_Click);
            // 
            // frm_DetalleLavadoGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 403);
            this.Controls.Add(this.panel_cabecera);
            this.Controls.Add(this.GridViewGeneral);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.PanelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_DetalleLavadoGrid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_DetalleLavadoGrid";
            this.Load += new System.EventHandler(this.frm_DetalleLavadoGrid_Load);
            this.PanelTitulo.ResumeLayout(false);
            this.PanelTitulo.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewGeneral)).EndInit();
            this.panel_cabecera.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelTitulo;
        public System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnEntregar;
        private System.Windows.Forms.DataGridView GridViewGeneral;
        private System.Windows.Forms.Panel panel_cabecera;
        private System.Windows.Forms.Button btn_nuevoDetalleLavado;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_lavado;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_lavadoDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.Button btn_FinalizarLavadoDetalle;
    }
}