namespace PuntodeVentaTintoreria
{
    partial class FrmDetalleTintoteriaRopa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDetalleTintoteriaRopa));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanelTitulo = new System.Windows.Forms.Panel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.GridViewrOPA = new System.Windows.Forms.DataGridView();
            this.idventadetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idsucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colori = new System.Windows.Forms.DataGridViewImageColumn();
            this.fibra = new System.Windows.Forms.DataGridViewImageColumn();
            this.estampado = new System.Windows.Forms.DataGridViewImageColumn();
            this.color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_fibra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_estampado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ubicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatosLavado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.simbolosLavado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.PanelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewrOPA)).BeginInit();
            this.panel10.SuspendLayout();
            this.panel11.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelTitulo
            // 
            this.PanelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.PanelTitulo.Controls.Add(this.btnSalir);
            this.PanelTitulo.Controls.Add(this.btnMinimizar);
            this.PanelTitulo.Controls.Add(this.lblTitulo);
            this.PanelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitulo.Location = new System.Drawing.Point(0, 0);
            this.PanelTitulo.Name = "PanelTitulo";
            this.PanelTitulo.Size = new System.Drawing.Size(936, 47);
            this.PanelTitulo.TabIndex = 12;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.ForeColor = System.Drawing.Color.White;
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.Location = new System.Drawing.Point(890, 10);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(30, 31);
            this.btnSalir.TabIndex = 6;
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
            this.btnMinimizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimizar.Image")));
            this.btnMinimizar.Location = new System.Drawing.Point(854, 10);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(30, 31);
            this.btnMinimizar.TabIndex = 5;
            this.btnMinimizar.UseVisualStyleBackColor = false;
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(8, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(163, 20);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Detalle del Servicio";
            // 
            // GridViewrOPA
            // 
            this.GridViewrOPA.AllowUserToAddRows = false;
            this.GridViewrOPA.AllowUserToDeleteRows = false;
            this.GridViewrOPA.AllowUserToOrderColumns = true;
            this.GridViewrOPA.AllowUserToResizeColumns = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            this.GridViewrOPA.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridViewrOPA.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.GridViewrOPA.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridViewrOPA.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GridViewrOPA.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(230)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridViewrOPA.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridViewrOPA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewrOPA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idventadetalle,
            this.idsucursal,
            this.descripcion,
            this.colori,
            this.fibra,
            this.estampado,
            this.color,
            this.id_fibra,
            this.id_estampado,
            this.ubicacion,
            this.descripcions,
            this.DatosLavado,
            this.simbolosLavado});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridViewrOPA.DefaultCellStyle = dataGridViewCellStyle3;
            this.GridViewrOPA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridViewrOPA.EnableHeadersVisualStyles = false;
            this.GridViewrOPA.GridColor = System.Drawing.Color.White;
            this.GridViewrOPA.Location = new System.Drawing.Point(0, 0);
            this.GridViewrOPA.MultiSelect = false;
            this.GridViewrOPA.Name = "GridViewrOPA";
            this.GridViewrOPA.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridViewrOPA.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GridViewrOPA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewrOPA.Size = new System.Drawing.Size(916, 454);
            this.GridViewrOPA.TabIndex = 23;
            // 
            // idventadetalle
            // 
            this.idventadetalle.DataPropertyName = "id_ventadetalle";
            this.idventadetalle.HeaderText = "idventadetalle";
            this.idventadetalle.Name = "idventadetalle";
            this.idventadetalle.ReadOnly = true;
            this.idventadetalle.Visible = false;
            // 
            // idsucursal
            // 
            this.idsucursal.DataPropertyName = "id_sucursal";
            this.idsucursal.HeaderText = "idsucursal";
            this.idsucursal.Name = "idsucursal";
            this.idsucursal.ReadOnly = true;
            this.idsucursal.Visible = false;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "descripcionPrenda";
            this.descripcion.HeaderText = "DESCRIPCIÓN";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 300;
            // 
            // colori
            // 
            this.colori.DataPropertyName = "color";
            this.colori.HeaderText = "COLOR";
            this.colori.Name = "colori";
            this.colori.ReadOnly = true;
            // 
            // fibra
            // 
            this.fibra.DataPropertyName = "fibra";
            this.fibra.HeaderText = "FIBRA";
            this.fibra.Name = "fibra";
            this.fibra.ReadOnly = true;
            this.fibra.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.fibra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // estampado
            // 
            this.estampado.DataPropertyName = "estampado";
            this.estampado.HeaderText = "ESTAM.";
            this.estampado.Name = "estampado";
            this.estampado.ReadOnly = true;
            this.estampado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.estampado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.estampado.Width = 120;
            // 
            // color
            // 
            this.color.DataPropertyName = "id_color";
            this.color.HeaderText = "COLOR";
            this.color.Name = "color";
            this.color.ReadOnly = true;
            this.color.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.color.Visible = false;
            // 
            // id_fibra
            // 
            this.id_fibra.DataPropertyName = "id_fibra";
            this.id_fibra.HeaderText = "id_fibra";
            this.id_fibra.Name = "id_fibra";
            this.id_fibra.ReadOnly = true;
            this.id_fibra.Visible = false;
            // 
            // id_estampado
            // 
            this.id_estampado.DataPropertyName = "id_estampado";
            this.id_estampado.HeaderText = "id_estampado";
            this.id_estampado.Name = "id_estampado";
            this.id_estampado.ReadOnly = true;
            this.id_estampado.Visible = false;
            // 
            // ubicacion
            // 
            this.ubicacion.DataPropertyName = "id_ubicacion";
            this.ubicacion.HeaderText = "id_ubicacion";
            this.ubicacion.Name = "ubicacion";
            this.ubicacion.ReadOnly = true;
            this.ubicacion.Visible = false;
            this.ubicacion.Width = 110;
            // 
            // descripcions
            // 
            this.descripcions.DataPropertyName = "descripcion";
            this.descripcions.HeaderText = "UBI.";
            this.descripcions.Name = "descripcions";
            this.descripcions.ReadOnly = true;
            this.descripcions.Width = 80;
            // 
            // DatosLavado
            // 
            this.DatosLavado.DataPropertyName = "datos";
            this.DatosLavado.HeaderText = "DATOS LAVADO";
            this.DatosLavado.Name = "DatosLavado";
            this.DatosLavado.ReadOnly = true;
            this.DatosLavado.Width = 750;
            // 
            // simbolosLavado
            // 
            this.simbolosLavado.DataPropertyName = "simbolosLavado";
            this.simbolosLavado.HeaderText = "simbolosLavado";
            this.simbolosLavado.Name = "simbolosLavado";
            this.simbolosLavado.ReadOnly = true;
            this.simbolosLavado.Visible = false;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.White;
            this.panel10.Controls.Add(this.GridViewrOPA);
            this.panel10.Location = new System.Drawing.Point(10, 54);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(916, 454);
            this.panel10.TabIndex = 24;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.DarkGray;
            this.panel11.Controls.Add(this.btnActualizar);
            this.panel11.Location = new System.Drawing.Point(12, 514);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(914, 105);
            this.panel11.TabIndex = 25;
            this.panel11.Visible = false;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnActualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.Color.Transparent;
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnActualizar.Location = new System.Drawing.Point(344, 3);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(226, 98);
            this.btnActualizar.TabIndex = 23;
            this.btnActualizar.Text = "Actualizar Status";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.button1_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork_1);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // FrmDetalleTintoteriaRopa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(196)))), ((int)(((byte)(213)))));
            this.ClientSize = new System.Drawing.Size(936, 624);
            this.Controls.Add(this.panel11);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.PanelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmDetalleTintoteriaRopa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDetalleTintoteria";
            this.Load += new System.EventHandler(this.FrmDetalleTintoteria_Load);
            this.PanelTitulo.ResumeLayout(false);
            this.PanelTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewrOPA)).EndInit();
            this.panel10.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PanelTitulo;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnMinimizar;
        public System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView GridViewrOPA;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button btnActualizar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idventadetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn idsucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewImageColumn colori;
        private System.Windows.Forms.DataGridViewImageColumn fibra;
        private System.Windows.Forms.DataGridViewImageColumn estampado;
        private System.Windows.Forms.DataGridViewTextBoxColumn color;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_fibra;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_estampado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ubicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcions;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatosLavado;
        private System.Windows.Forms.DataGridViewTextBoxColumn simbolosLavado;
    }
}