namespace PuntodeVentaTintoreria
{
    partial class Frm_UsuarioGrid
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
            this.btn_nuevoUsuario = new System.Windows.Forms.Button();
            this.GridviewGeneral = new System.Windows.Forms.DataGridView();
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.NombreCompleto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.user = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_tipoUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoPat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apellidoMat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_pais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_municipio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_turno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fCaducidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.conInt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fBloq = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.PanelTitulo.Size = new System.Drawing.Size(1181, 53);
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
            this.lblTitulo.Size = new System.Drawing.Size(71, 20);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Usuario";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.btnMinimizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Image = global::PuntodeVentaTintoreria.Properties.Resources.top_minimizar;
            this.btnMinimizar.Location = new System.Drawing.Point(1098, 19);
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
            this.btnSalir.Location = new System.Drawing.Point(1136, 19);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(30, 31);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel_cabecera
            // 
            this.panel_cabecera.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(210)))), ((int)(((byte)(213)))));
            this.panel_cabecera.Controls.Add(this.btn_nuevoUsuario);
            this.panel_cabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_cabecera.Location = new System.Drawing.Point(0, 53);
            this.panel_cabecera.Name = "panel_cabecera";
            this.panel_cabecera.Size = new System.Drawing.Size(1181, 50);
            this.panel_cabecera.TabIndex = 10;
            // 
            // btn_nuevoUsuario
            // 
            this.btn_nuevoUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_nuevoUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_nuevoUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_nuevoUsuario.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_nuevoUsuario.Location = new System.Drawing.Point(2, 0);
            this.btn_nuevoUsuario.Name = "btn_nuevoUsuario";
            this.btn_nuevoUsuario.Size = new System.Drawing.Size(154, 43);
            this.btn_nuevoUsuario.TabIndex = 0;
            this.btn_nuevoUsuario.Text = "Nuevo Usuario";
            this.btn_nuevoUsuario.UseVisualStyleBackColor = false;
            this.btn_nuevoUsuario.Click += new System.EventHandler(this.btn_nuevoVehiculo_Click);
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
            this.NombreCompleto,
            this.sucursal,
            this.tipoUsuario,
            this.fechaNacimiento,
            this.telefono,
            this.user,
            this.id_usuario,
            this.id_sucursal,
            this.id_tipoUsuario,
            this.nombre,
            this.apellidoPat,
            this.apellidoMat,
            this.id_pais,
            this.id_estado,
            this.id_municipio,
            this.direccion,
            this.id_turno,
            this.password,
            this.fCaducidad,
            this.conInt,
            this.estatus,
            this.fBloq});
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
            this.GridviewGeneral.Size = new System.Drawing.Size(1157, 338);
            this.GridviewGeneral.TabIndex = 16;
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
            this.btn_editar.Location = new System.Drawing.Point(936, 453);
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
            this.btn_eliminar.Location = new System.Drawing.Point(1043, 453);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(85, 78);
            this.btn_eliminar.TabIndex = 14;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_eliminar.UseVisualStyleBackColor = false;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // NombreCompleto
            // 
            this.NombreCompleto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NombreCompleto.DataPropertyName = "NombreCompleto";
            this.NombreCompleto.FillWeight = 0.7710868F;
            this.NombreCompleto.HeaderText = "Nombre";
            this.NombreCompleto.Name = "NombreCompleto";
            this.NombreCompleto.ReadOnly = true;
            this.NombreCompleto.Width = 150;
            // 
            // sucursal
            // 
            this.sucursal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sucursal.DataPropertyName = "sucursal";
            this.sucursal.FillWeight = 14.45734F;
            this.sucursal.HeaderText = "Sucursal";
            this.sucursal.Name = "sucursal";
            this.sucursal.ReadOnly = true;
            this.sucursal.Width = 150;
            // 
            // tipoUsuario
            // 
            this.tipoUsuario.DataPropertyName = "tipoUsuario";
            this.tipoUsuario.HeaderText = "Tipo Usuario";
            this.tipoUsuario.Name = "tipoUsuario";
            this.tipoUsuario.ReadOnly = true;
            // 
            // fechaNacimiento
            // 
            this.fechaNacimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.fechaNacimiento.DataPropertyName = "fechaNacimiento";
            this.fechaNacimiento.FillWeight = 284.7715F;
            this.fechaNacimiento.HeaderText = "Fecha Nacimiento";
            this.fechaNacimiento.Name = "fechaNacimiento";
            this.fechaNacimiento.ReadOnly = true;
            this.fechaNacimiento.Width = 464;
            // 
            // telefono
            // 
            this.telefono.DataPropertyName = "telefono";
            this.telefono.HeaderText = "Telefono";
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            // 
            // user
            // 
            this.user.DataPropertyName = "user";
            this.user.HeaderText = "User";
            this.user.Name = "user";
            this.user.ReadOnly = true;
            // 
            // id_usuario
            // 
            this.id_usuario.DataPropertyName = "id_usuario";
            this.id_usuario.HeaderText = "id_usuario";
            this.id_usuario.Name = "id_usuario";
            this.id_usuario.ReadOnly = true;
            this.id_usuario.Visible = false;
            // 
            // id_sucursal
            // 
            this.id_sucursal.DataPropertyName = "id_sucursal";
            this.id_sucursal.HeaderText = "id_sucursal";
            this.id_sucursal.Name = "id_sucursal";
            this.id_sucursal.ReadOnly = true;
            this.id_sucursal.Visible = false;
            // 
            // id_tipoUsuario
            // 
            this.id_tipoUsuario.DataPropertyName = "id_tipoUsuario";
            this.id_tipoUsuario.HeaderText = "id_tipoUsuario";
            this.id_tipoUsuario.Name = "id_tipoUsuario";
            this.id_tipoUsuario.ReadOnly = true;
            this.id_tipoUsuario.Visible = false;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Visible = false;
            // 
            // apellidoPat
            // 
            this.apellidoPat.DataPropertyName = "apellidoPat";
            this.apellidoPat.HeaderText = "apellidoPat";
            this.apellidoPat.Name = "apellidoPat";
            this.apellidoPat.ReadOnly = true;
            this.apellidoPat.Visible = false;
            // 
            // apellidoMat
            // 
            this.apellidoMat.DataPropertyName = "apellidoMat";
            this.apellidoMat.HeaderText = "apellidoMat";
            this.apellidoMat.Name = "apellidoMat";
            this.apellidoMat.ReadOnly = true;
            this.apellidoMat.Visible = false;
            // 
            // id_pais
            // 
            this.id_pais.DataPropertyName = "id_pais";
            this.id_pais.HeaderText = "id_pais";
            this.id_pais.Name = "id_pais";
            this.id_pais.ReadOnly = true;
            this.id_pais.Visible = false;
            // 
            // id_estado
            // 
            this.id_estado.DataPropertyName = "id_estado";
            this.id_estado.HeaderText = "id_estado";
            this.id_estado.Name = "id_estado";
            this.id_estado.ReadOnly = true;
            this.id_estado.Visible = false;
            // 
            // id_municipio
            // 
            this.id_municipio.DataPropertyName = "id_municipio";
            this.id_municipio.HeaderText = "id_municipio";
            this.id_municipio.Name = "id_municipio";
            this.id_municipio.ReadOnly = true;
            this.id_municipio.Visible = false;
            // 
            // direccion
            // 
            this.direccion.DataPropertyName = "direccion";
            this.direccion.HeaderText = "direccion";
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            this.direccion.Visible = false;
            // 
            // id_turno
            // 
            this.id_turno.DataPropertyName = "id_turno";
            this.id_turno.HeaderText = "id_turno";
            this.id_turno.Name = "id_turno";
            this.id_turno.ReadOnly = true;
            this.id_turno.Visible = false;
            // 
            // password
            // 
            this.password.DataPropertyName = "password";
            this.password.HeaderText = "password";
            this.password.Name = "password";
            this.password.ReadOnly = true;
            this.password.Visible = false;
            // 
            // fCaducidad
            // 
            this.fCaducidad.DataPropertyName = "fCaducidad";
            this.fCaducidad.HeaderText = "fCaducidad";
            this.fCaducidad.Name = "fCaducidad";
            this.fCaducidad.ReadOnly = true;
            this.fCaducidad.Visible = false;
            // 
            // conInt
            // 
            this.conInt.DataPropertyName = "conInt";
            this.conInt.HeaderText = "conInt";
            this.conInt.Name = "conInt";
            this.conInt.ReadOnly = true;
            this.conInt.Visible = false;
            // 
            // estatus
            // 
            this.estatus.DataPropertyName = "estatus";
            this.estatus.HeaderText = "estatus";
            this.estatus.Name = "estatus";
            this.estatus.ReadOnly = true;
            this.estatus.Visible = false;
            // 
            // fBloq
            // 
            this.fBloq.DataPropertyName = "fBloq";
            this.fBloq.HeaderText = "fBloq";
            this.fBloq.Name = "fBloq";
            this.fBloq.ReadOnly = true;
            this.fBloq.Visible = false;
            // 
            // Frm_UsuarioGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(196)))), ((int)(((byte)(213)))));
            this.ClientSize = new System.Drawing.Size(1181, 538);
            this.Controls.Add(this.GridviewGeneral);
            this.Controls.Add(this.btn_editar);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.panel_cabecera);
            this.Controls.Add(this.PanelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_UsuarioGrid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_VehiculoGrid";
            this.Load += new System.EventHandler(this.Frm_UsuarioGrid_Load);
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
        private System.Windows.Forms.Button btn_nuevoUsuario;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.DataGridView GridviewGeneral;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCompleto;
        private System.Windows.Forms.DataGridViewTextBoxColumn sucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaNacimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn user;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_sucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_tipoUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoPat;
        private System.Windows.Forms.DataGridViewTextBoxColumn apellidoMat;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_pais;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_municipio;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_turno;
        private System.Windows.Forms.DataGridViewTextBoxColumn password;
        private System.Windows.Forms.DataGridViewTextBoxColumn fCaducidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn conInt;
        private System.Windows.Forms.DataGridViewTextBoxColumn estatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn fBloq;
    }
}