namespace PuntodeVentaTintoreria
{
    partial class frm_VehiculoGrid
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanelTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel_cabecera = new System.Windows.Forms.Panel();
            this.btn_nuevoVehiculo = new System.Windows.Forms.Button();
            this.GridviewGeneral = new System.Windows.Forms.DataGridView();
            this.id_Vehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreVehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.PanelTitulo.SuspendLayout();
            this.panel_cabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridviewGeneral)).BeginInit();
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
            this.PanelTitulo.Size = new System.Drawing.Size(829, 53);
            this.PanelTitulo.TabIndex = 9;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(8, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(78, 20);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Vehiculo";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.btnMinimizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Image = global::PuntodeVentaTintoreria.Properties.Resources.top_minimizar;
            this.btnMinimizar.Location = new System.Drawing.Point(746, 19);
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
            this.btnSalir.Location = new System.Drawing.Point(784, 19);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(30, 31);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel_cabecera
            // 
            this.panel_cabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(210)))), ((int)(((byte)(213)))));
            this.panel_cabecera.Controls.Add(this.btn_nuevoVehiculo);
            this.panel_cabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_cabecera.Location = new System.Drawing.Point(0, 53);
            this.panel_cabecera.Name = "panel_cabecera";
            this.panel_cabecera.Size = new System.Drawing.Size(829, 50);
            this.panel_cabecera.TabIndex = 10;
            // 
            // btn_nuevoVehiculo
            // 
            this.btn_nuevoVehiculo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_nuevoVehiculo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_nuevoVehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nuevoVehiculo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_nuevoVehiculo.Location = new System.Drawing.Point(2, 0);
            this.btn_nuevoVehiculo.Name = "btn_nuevoVehiculo";
            this.btn_nuevoVehiculo.Size = new System.Drawing.Size(154, 43);
            this.btn_nuevoVehiculo.TabIndex = 0;
            this.btn_nuevoVehiculo.Text = "Nuevo Vehiculo";
            this.btn_nuevoVehiculo.UseVisualStyleBackColor = false;
            this.btn_nuevoVehiculo.Click += new System.EventHandler(this.btn_nuevoVehiculo_Click);
            // 
            // GridviewGeneral
            // 
            this.GridviewGeneral.AllowUserToAddRows = false;
            this.GridviewGeneral.AllowUserToDeleteRows = false;
            this.GridviewGeneral.AllowUserToOrderColumns = true;
            this.GridviewGeneral.AllowUserToResizeColumns = false;
            this.GridviewGeneral.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            this.GridviewGeneral.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridviewGeneral.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridviewGeneral.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.GridviewGeneral.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridviewGeneral.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GridviewGeneral.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(230)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridviewGeneral.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridviewGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridviewGeneral.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_Vehiculo,
            this.nombreVehiculo,
            this.placa,
            this.descripcion});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridviewGeneral.DefaultCellStyle = dataGridViewCellStyle3;
            this.GridviewGeneral.EnableHeadersVisualStyles = false;
            this.GridviewGeneral.GridColor = System.Drawing.Color.White;
            this.GridviewGeneral.Location = new System.Drawing.Point(12, 109);
            this.GridviewGeneral.MultiSelect = false;
            this.GridviewGeneral.Name = "GridviewGeneral";
            this.GridviewGeneral.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridviewGeneral.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GridviewGeneral.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.GridviewGeneral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridviewGeneral.Size = new System.Drawing.Size(805, 288);
            this.GridviewGeneral.TabIndex = 16;
            // 
            // id_Vehiculo
            // 
            this.id_Vehiculo.DataPropertyName = "ID_vehiculo";
            this.id_Vehiculo.HeaderText = "Id_Vehiculo";
            this.id_Vehiculo.Name = "id_Vehiculo";
            this.id_Vehiculo.ReadOnly = true;
            this.id_Vehiculo.Visible = false;
            // 
            // nombreVehiculo
            // 
            this.nombreVehiculo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nombreVehiculo.DataPropertyName = "NombreVeh";
            this.nombreVehiculo.FillWeight = 0.7710868F;
            this.nombreVehiculo.HeaderText = "Vehiculo";
            this.nombreVehiculo.Name = "nombreVehiculo";
            this.nombreVehiculo.ReadOnly = true;
            this.nombreVehiculo.Width = 150;
            // 
            // placa
            // 
            this.placa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.placa.DataPropertyName = "placas";
            this.placa.FillWeight = 14.45734F;
            this.placa.HeaderText = "Placa";
            this.placa.Name = "placa";
            this.placa.ReadOnly = true;
            this.placa.Width = 150;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.descripcion.DataPropertyName = "Descripcion";
            this.descripcion.FillWeight = 284.7715F;
            this.descripcion.HeaderText = "Descripción";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            this.descripcion.Width = 464;
            // 
            // btn_editar
            // 
            this.btn_editar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_editar.BackColor = System.Drawing.Color.Silver;
            this.btn_editar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btn_editar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_editar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_editar.ForeColor = System.Drawing.Color.Black;
            this.btn_editar.Image = global::PuntodeVentaTintoreria.Properties.Resources.edit_file_50px;
            this.btn_editar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_editar.Location = new System.Drawing.Point(584, 409);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(85, 78);
            this.btn_editar.TabIndex = 15;
            this.btn_editar.Text = "Editar";
            this.btn_editar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_editar.UseVisualStyleBackColor = false;
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_eliminar.BackColor = System.Drawing.Color.Silver;
            this.btn_eliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btn_eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_eliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_eliminar.ForeColor = System.Drawing.Color.Black;
            this.btn_eliminar.Image = global::PuntodeVentaTintoreria.Properties.Resources.delete_fILE_48px;
            this.btn_eliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_eliminar.Location = new System.Drawing.Point(691, 409);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(85, 78);
            this.btn_eliminar.TabIndex = 14;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_eliminar.UseVisualStyleBackColor = false;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // frm_VehiculoGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(196)))), ((int)(((byte)(213)))));
            this.ClientSize = new System.Drawing.Size(829, 500);
            this.Controls.Add(this.GridviewGeneral);
            this.Controls.Add(this.btn_editar);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.panel_cabecera);
            this.Controls.Add(this.PanelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_VehiculoGrid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_VehiculoGrid";
            this.Load += new System.EventHandler(this.frm_VehiculoGrid_Load);
            this.PanelTitulo.ResumeLayout(false);
            this.PanelTitulo.PerformLayout();
            this.panel_cabecera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridviewGeneral)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelTitulo;
        public System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel_cabecera;
        private System.Windows.Forms.Button btn_nuevoVehiculo;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.DataGridView GridviewGeneral;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_Vehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreVehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn placa;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
    }
}