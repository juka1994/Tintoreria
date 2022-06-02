namespace PuntodeVentaTintoreria
{
    partial class frmHistorial
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanelTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.GridViewHistorial = new System.Windows.Forms.DataGridView();
            this.id_movimientoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadMedidaMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factorConversion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadConvertida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadMedidaAlmacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_tipoMovimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_sucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.txt_buscador = new System.Windows.Forms.TextBox();
            this.PanelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewHistorial)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.pnlBusqueda.SuspendLayout();
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
            this.PanelTitulo.Size = new System.Drawing.Size(1214, 53);
            this.PanelTitulo.TabIndex = 15;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(8, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(204, 20);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Historial de Movimientos";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.btnMinimizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Image = global::PuntodeVentaTintoreria.Properties.Resources.top_minimizar;
            this.btnMinimizar.Location = new System.Drawing.Point(1131, 19);
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
            this.btnSalir.Location = new System.Drawing.Point(1169, 19);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(30, 31);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // GridViewHistorial
            // 
            this.GridViewHistorial.AllowUserToAddRows = false;
            this.GridViewHistorial.AllowUserToDeleteRows = false;
            this.GridViewHistorial.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            this.GridViewHistorial.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.GridViewHistorial.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.GridViewHistorial.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.GridViewHistorial.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridViewHistorial.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GridViewHistorial.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(230)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(8);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridViewHistorial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.GridViewHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewHistorial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_movimientoProducto,
            this.nombreSucursal,
            this.nombreProducto,
            this.cantidadMovimiento,
            this.unidadMedidaMovimiento,
            this.factorConversion,
            this.cantidadConvertida,
            this.cantidadAlmacen,
            this.unidadMedidaAlmacen,
            this.totalProducto,
            this.id_tipoMovimiento,
            this.id_producto,
            this.descripcion,
            this.usuario,
            this.fecins,
            this.id_sucursal});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridViewHistorial.DefaultCellStyle = dataGridViewCellStyle11;
            this.GridViewHistorial.EnableHeadersVisualStyles = false;
            this.GridViewHistorial.GridColor = System.Drawing.Color.White;
            this.GridViewHistorial.Location = new System.Drawing.Point(12, 116);
            this.GridViewHistorial.MultiSelect = false;
            this.GridViewHistorial.Name = "GridViewHistorial";
            this.GridViewHistorial.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridViewHistorial.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.GridViewHistorial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewHistorial.Size = new System.Drawing.Size(1187, 288);
            this.GridViewHistorial.TabIndex = 16;
            // 
            // id_movimientoProducto
            // 
            this.id_movimientoProducto.DataPropertyName = "id_movimientoProducto";
            this.id_movimientoProducto.HeaderText = "id_movimientoProducto";
            this.id_movimientoProducto.Name = "id_movimientoProducto";
            this.id_movimientoProducto.ReadOnly = true;
            this.id_movimientoProducto.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.id_movimientoProducto.Visible = false;
            this.id_movimientoProducto.Width = 167;
            // 
            // nombreSucursal
            // 
            this.nombreSucursal.DataPropertyName = "nombreSucursal";
            this.nombreSucursal.HeaderText = "Sucursal";
            this.nombreSucursal.Name = "nombreSucursal";
            this.nombreSucursal.ReadOnly = true;
            this.nombreSucursal.Width = 166;
            // 
            // nombreProducto
            // 
            this.nombreProducto.DataPropertyName = "nombreProducto";
            this.nombreProducto.HeaderText = "Producto";
            this.nombreProducto.Name = "nombreProducto";
            this.nombreProducto.ReadOnly = true;
            this.nombreProducto.Width = 167;
            // 
            // cantidadMovimiento
            // 
            this.cantidadMovimiento.DataPropertyName = "cantidadMovimiento";
            this.cantidadMovimiento.HeaderText = "Cantidad de movimiento";
            this.cantidadMovimiento.Name = "cantidadMovimiento";
            this.cantidadMovimiento.ReadOnly = true;
            this.cantidadMovimiento.Width = 167;
            // 
            // unidadMedidaMovimiento
            // 
            this.unidadMedidaMovimiento.DataPropertyName = "unidadMedidaMovimiento";
            this.unidadMedidaMovimiento.HeaderText = "Unidad de medida del movimiento";
            this.unidadMedidaMovimiento.Name = "unidadMedidaMovimiento";
            this.unidadMedidaMovimiento.ReadOnly = true;
            // 
            // factorConversion
            // 
            this.factorConversion.DataPropertyName = "factorConversion";
            this.factorConversion.HeaderText = "Factor de conversión";
            this.factorConversion.Name = "factorConversion";
            this.factorConversion.ReadOnly = true;
            // 
            // cantidadConvertida
            // 
            this.cantidadConvertida.DataPropertyName = "cantidadConvertida";
            this.cantidadConvertida.HeaderText = "Cantidad convertida";
            this.cantidadConvertida.Name = "cantidadConvertida";
            this.cantidadConvertida.ReadOnly = true;
            this.cantidadConvertida.Width = 167;
            // 
            // cantidadAlmacen
            // 
            this.cantidadAlmacen.DataPropertyName = "cantidadAlmacen";
            this.cantidadAlmacen.HeaderText = "Cantidad en almacén";
            this.cantidadAlmacen.Name = "cantidadAlmacen";
            this.cantidadAlmacen.ReadOnly = true;
            this.cantidadAlmacen.Width = 166;
            // 
            // unidadMedidaAlmacen
            // 
            this.unidadMedidaAlmacen.DataPropertyName = "unidadMedidaAlmacen";
            this.unidadMedidaAlmacen.HeaderText = "Unidad de medida en almacen";
            this.unidadMedidaAlmacen.Name = "unidadMedidaAlmacen";
            this.unidadMedidaAlmacen.ReadOnly = true;
            // 
            // totalProducto
            // 
            this.totalProducto.DataPropertyName = "totalProducto";
            this.totalProducto.HeaderText = "Total en almacén";
            this.totalProducto.Name = "totalProducto";
            this.totalProducto.ReadOnly = true;
            // 
            // id_tipoMovimiento
            // 
            this.id_tipoMovimiento.DataPropertyName = "id_tipoMovimiento";
            this.id_tipoMovimiento.HeaderText = "id_tipoMovimiento";
            this.id_tipoMovimiento.Name = "id_tipoMovimiento";
            this.id_tipoMovimiento.ReadOnly = true;
            this.id_tipoMovimiento.Visible = false;
            // 
            // id_producto
            // 
            this.id_producto.DataPropertyName = "id_producto";
            this.id_producto.HeaderText = "id_producto";
            this.id_producto.Name = "id_producto";
            this.id_producto.ReadOnly = true;
            this.id_producto.Visible = false;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "observaciones";
            this.descripcion.HeaderText = "MOV.";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // usuario
            // 
            this.usuario.DataPropertyName = "usuario";
            this.usuario.HeaderText = "USUARIO";
            this.usuario.Name = "usuario";
            this.usuario.ReadOnly = true;
            // 
            // fecins
            // 
            this.fecins.DataPropertyName = "fecins";
            this.fecins.HeaderText = "FECHA";
            this.fecins.Name = "fecins";
            this.fecins.ReadOnly = true;
            // 
            // id_sucursal
            // 
            this.id_sucursal.DataPropertyName = "id_sucursal";
            this.id_sucursal.HeaderText = "id_sucursal";
            this.id_sucursal.Name = "id_sucursal";
            this.id_sucursal.ReadOnly = true;
            this.id_sucursal.Visible = false;
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.pnlBotones.Controls.Add(this.btnBuscar);
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.pnlBusqueda);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 502);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(1214, 102);
            this.pnlBotones.TabIndex = 17;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.DimGray;
            this.btnBuscar.Image = global::PuntodeVentaTintoreria.Properties.Resources.boton_buscar_58x58;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnBuscar.Location = new System.Drawing.Point(321, 23);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(130, 65);
            this.btnBuscar.TabIndex = 15;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.DimGray;
            this.btnCancelar.Image = global::PuntodeVentaTintoreria.Properties.Resources.boton_cancelar_58x58;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(457, 23);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(140, 65);
            this.btnCancelar.TabIndex = 14;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.BackColor = System.Drawing.Color.White;
            this.pnlBusqueda.Controls.Add(this.txt_buscador);
            this.pnlBusqueda.Location = new System.Drawing.Point(5, 41);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Size = new System.Drawing.Size(262, 30);
            this.pnlBusqueda.TabIndex = 5;
            // 
            // txt_buscador
            // 
            this.txt_buscador.BackColor = System.Drawing.Color.White;
            this.txt_buscador.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_buscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_buscador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txt_buscador.Location = new System.Drawing.Point(5, 6);
            this.txt_buscador.Name = "txt_buscador";
            this.txt_buscador.Size = new System.Drawing.Size(251, 19);
            this.txt_buscador.TabIndex = 30;
            this.txt_buscador.Text = "Búsqueda por  sucursal o producto";
            this.txt_buscador.Click += new System.EventHandler(this.txt_buscador_Click_1);
            // 
            // frmHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1214, 604);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.GridViewHistorial);
            this.Controls.Add(this.PanelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmHistorial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmHistorial";
            this.Load += new System.EventHandler(this.frmHistorial_Load);
            this.PanelTitulo.ResumeLayout(false);
            this.PanelTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewHistorial)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelTitulo;
        public System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView GridViewHistorial;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.TextBox txt_buscador;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_movimientoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadMedidaMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn factorConversion;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadConvertida;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadMedidaAlmacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_tipoMovimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecins;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_sucursal;
    }
}