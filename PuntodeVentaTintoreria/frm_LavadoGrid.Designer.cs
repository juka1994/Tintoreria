namespace PuntodeVentaTintoreria
{
    partial class frm_LavadoGrid
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanelTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.GridViewCompraDetalle = new System.Windows.Forms.DataGridView();
            this.nombreProductoFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtUnidadMedidaFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_productoFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_unidadMedidaFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_lavadoDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridViewProductosDetalle = new System.Windows.Forms.DataGridView();
            this.label10 = new System.Windows.Forms.Label();
            this.cmb_producto = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.label21 = new System.Windows.Forms.Label();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.txt_costoTotal = new System.Windows.Forms.TextBox();
            this.btnEntregar = new System.Windows.Forms.Button();
            this.ActivoInt1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.nombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.existencia1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CmbUnidadMedida = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PrecioUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUnidadMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelTitulo.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCompraDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewProductosDetalle)).BeginInit();
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
            this.PanelTitulo.Size = new System.Drawing.Size(800, 53);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.panel1.Controls.Add(this.btn_Eliminar);
            this.panel1.Controls.Add(this.btn_Agregar);
            this.panel1.Controls.Add(this.GridViewCompraDetalle);
            this.panel1.Controls.Add(this.GridViewProductosDetalle);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cmb_producto);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(0, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 353);
            this.panel1.TabIndex = 149;
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Eliminar.BackColor = System.Drawing.Color.Silver;
            this.btn_Eliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Eliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Eliminar.ForeColor = System.Drawing.Color.DimGray;
            this.btn_Eliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Eliminar.Location = new System.Drawing.Point(744, 287);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(34, 27);
            this.btn_Eliminar.TabIndex = 178;
            this.btn_Eliminar.Text = "-";
            this.btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Eliminar.UseVisualStyleBackColor = false;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Agregar.BackColor = System.Drawing.Color.Silver;
            this.btn_Agregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btn_Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Agregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Agregar.ForeColor = System.Drawing.Color.DimGray;
            this.btn_Agregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Agregar.Location = new System.Drawing.Point(744, 227);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(34, 27);
            this.btn_Agregar.TabIndex = 176;
            this.btn_Agregar.Text = "+";
            this.btn_Agregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Agregar.UseVisualStyleBackColor = false;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // GridViewCompraDetalle
            // 
            this.GridViewCompraDetalle.AllowUserToAddRows = false;
            this.GridViewCompraDetalle.AllowUserToDeleteRows = false;
            this.GridViewCompraDetalle.AllowUserToOrderColumns = true;
            this.GridViewCompraDetalle.AllowUserToResizeColumns = false;
            this.GridViewCompraDetalle.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            this.GridViewCompraDetalle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridViewCompraDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridViewCompraDetalle.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.GridViewCompraDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridViewCompraDetalle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GridViewCompraDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(230)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridViewCompraDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridViewCompraDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewCompraDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreProductoFinal,
            this.cantidadFinal,
            this.txtUnidadMedidaFinal,
            this.costoFinal,
            this.Subtotal,
            this.id_productoFinal,
            this.id_unidadMedidaFinal,
            this.id_lavadoDetalle});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridViewCompraDetalle.DefaultCellStyle = dataGridViewCellStyle3;
            this.GridViewCompraDetalle.EnableHeadersVisualStyles = false;
            this.GridViewCompraDetalle.GridColor = System.Drawing.Color.White;
            this.GridViewCompraDetalle.Location = new System.Drawing.Point(3, 210);
            this.GridViewCompraDetalle.MultiSelect = false;
            this.GridViewCompraDetalle.Name = "GridViewCompraDetalle";
            this.GridViewCompraDetalle.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridViewCompraDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GridViewCompraDetalle.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.GridViewCompraDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewCompraDetalle.Size = new System.Drawing.Size(720, 139);
            this.GridViewCompraDetalle.TabIndex = 177;
            // 
            // nombreProductoFinal
            // 
            this.nombreProductoFinal.DataPropertyName = "nombreProductoFinal";
            this.nombreProductoFinal.HeaderText = "Producto";
            this.nombreProductoFinal.Name = "nombreProductoFinal";
            this.nombreProductoFinal.ReadOnly = true;
            // 
            // cantidadFinal
            // 
            this.cantidadFinal.DataPropertyName = "cantidadFinal";
            this.cantidadFinal.HeaderText = "Cantidad";
            this.cantidadFinal.Name = "cantidadFinal";
            this.cantidadFinal.ReadOnly = true;
            // 
            // txtUnidadMedidaFinal
            // 
            this.txtUnidadMedidaFinal.DataPropertyName = "txtUnidadMedidaFinal";
            this.txtUnidadMedidaFinal.HeaderText = "Unidad de medida";
            this.txtUnidadMedidaFinal.Name = "txtUnidadMedidaFinal";
            this.txtUnidadMedidaFinal.ReadOnly = true;
            this.txtUnidadMedidaFinal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // costoFinal
            // 
            this.costoFinal.DataPropertyName = "costoFinal";
            this.costoFinal.HeaderText = "Precio unitario";
            this.costoFinal.Name = "costoFinal";
            this.costoFinal.ReadOnly = true;
            this.costoFinal.Visible = false;
            // 
            // Subtotal
            // 
            this.Subtotal.DataPropertyName = "Subtotal";
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.ReadOnly = true;
            this.Subtotal.Visible = false;
            // 
            // id_productoFinal
            // 
            this.id_productoFinal.DataPropertyName = "id_productoFinal";
            this.id_productoFinal.HeaderText = "id_productoFinal";
            this.id_productoFinal.Name = "id_productoFinal";
            this.id_productoFinal.ReadOnly = true;
            this.id_productoFinal.Visible = false;
            // 
            // id_unidadMedidaFinal
            // 
            this.id_unidadMedidaFinal.DataPropertyName = "id_unidadMedidaFinal";
            this.id_unidadMedidaFinal.HeaderText = "id_unidadMedidaFinal";
            this.id_unidadMedidaFinal.Name = "id_unidadMedidaFinal";
            this.id_unidadMedidaFinal.ReadOnly = true;
            this.id_unidadMedidaFinal.Visible = false;
            // 
            // id_lavadoDetalle
            // 
            this.id_lavadoDetalle.DataPropertyName = "id_lavadoDetalle";
            this.id_lavadoDetalle.HeaderText = "id_lavadoDetalle";
            this.id_lavadoDetalle.Name = "id_lavadoDetalle";
            this.id_lavadoDetalle.ReadOnly = true;
            this.id_lavadoDetalle.Visible = false;
            // 
            // GridViewProductosDetalle
            // 
            this.GridViewProductosDetalle.AllowUserToAddRows = false;
            this.GridViewProductosDetalle.AllowUserToDeleteRows = false;
            this.GridViewProductosDetalle.AllowUserToOrderColumns = true;
            this.GridViewProductosDetalle.AllowUserToResizeColumns = false;
            this.GridViewProductosDetalle.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            this.GridViewProductosDetalle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.GridViewProductosDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridViewProductosDetalle.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.GridViewProductosDetalle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridViewProductosDetalle.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GridViewProductosDetalle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(230)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(8);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridViewProductosDetalle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.GridViewProductosDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewProductosDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ActivoInt1,
            this.nombreProducto,
            this.existencia1,
            this.cantidad1,
            this.CmbUnidadMedida,
            this.PrecioUnitario,
            this.id_producto,
            this.idUnidadMedida});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridViewProductosDetalle.DefaultCellStyle = dataGridViewCellStyle8;
            this.GridViewProductosDetalle.EnableHeadersVisualStyles = false;
            this.GridViewProductosDetalle.GridColor = System.Drawing.Color.White;
            this.GridViewProductosDetalle.Location = new System.Drawing.Point(3, 61);
            this.GridViewProductosDetalle.MultiSelect = false;
            this.GridViewProductosDetalle.Name = "GridViewProductosDetalle";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridViewProductosDetalle.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GridViewProductosDetalle.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.GridViewProductosDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewProductosDetalle.Size = new System.Drawing.Size(794, 143);
            this.GridViewProductosDetalle.TabIndex = 176;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.label10.Location = new System.Drawing.Point(3, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 125;
            this.label10.Text = "PRODUCTO";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmb_producto
            // 
            this.cmb_producto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.cmb_producto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_producto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.cmb_producto.FormattingEnabled = true;
            this.cmb_producto.Location = new System.Drawing.Point(6, 27);
            this.cmb_producto.Name = "cmb_producto";
            this.cmb_producto.Size = new System.Drawing.Size(238, 28);
            this.cmb_producto.TabIndex = 6;
            this.cmb_producto.SelectedValueChanged += new System.EventHandler(this.cmb_producto_SelectedValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(79, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 17);
            this.label11.TabIndex = 124;
            this.label11.Text = "*";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.DarkGray;
            this.pnlBotones.Controls.Add(this.label21);
            this.pnlBotones.Controls.Add(this.pnlBusqueda);
            this.pnlBotones.Controls.Add(this.btnEntregar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 408);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(800, 80);
            this.pnlBotones.TabIndex = 150;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.label21.Location = new System.Drawing.Point(38, 36);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(124, 18);
            this.label21.TabIndex = 117;
            this.label21.Text = "COSTO TOTAL";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label21.Visible = false;
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.BackColor = System.Drawing.Color.White;
            this.pnlBusqueda.Controls.Add(this.txt_costoTotal);
            this.pnlBusqueda.Location = new System.Drawing.Point(170, 29);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Size = new System.Drawing.Size(256, 30);
            this.pnlBusqueda.TabIndex = 116;
            this.pnlBusqueda.Visible = false;
            // 
            // txt_costoTotal
            // 
            this.txt_costoTotal.BackColor = System.Drawing.Color.White;
            this.txt_costoTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_costoTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_costoTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txt_costoTotal.Location = new System.Drawing.Point(4, 6);
            this.txt_costoTotal.Name = "txt_costoTotal";
            this.txt_costoTotal.Size = new System.Drawing.Size(239, 19);
            this.txt_costoTotal.TabIndex = 30;
            // 
            // btnEntregar
            // 
            this.btnEntregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEntregar.BackColor = System.Drawing.Color.Silver;
            this.btnEntregar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btnEntregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEntregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntregar.ForeColor = System.Drawing.Color.Black;
            this.btnEntregar.Image = global::PuntodeVentaTintoreria.Properties.Resources.save50px;
            this.btnEntregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEntregar.Location = new System.Drawing.Point(638, 4);
            this.btnEntregar.Name = "btnEntregar";
            this.btnEntregar.Size = new System.Drawing.Size(85, 72);
            this.btnEntregar.TabIndex = 1;
            this.btnEntregar.Text = "Guardar";
            this.btnEntregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEntregar.UseVisualStyleBackColor = false;
            this.btnEntregar.Click += new System.EventHandler(this.btnEntregar_Click);
            // 
            // ActivoInt1
            // 
            this.ActivoInt1.DataPropertyName = "seleccionar";
            this.ActivoInt1.HeaderText = "Seleccionar";
            this.ActivoInt1.Name = "ActivoInt1";
            this.ActivoInt1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ActivoInt1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // nombreProducto
            // 
            this.nombreProducto.DataPropertyName = "nombreProducto";
            this.nombreProducto.HeaderText = "Producto";
            this.nombreProducto.Name = "nombreProducto";
            this.nombreProducto.ReadOnly = true;
            // 
            // existencia1
            // 
            this.existencia1.DataPropertyName = "existencia";
            this.existencia1.HeaderText = "Existencia";
            this.existencia1.Name = "existencia1";
            this.existencia1.ReadOnly = true;
            // 
            // cantidad1
            // 
            this.cantidad1.DataPropertyName = "cantidad";
            this.cantidad1.HeaderText = "Cantidad";
            this.cantidad1.Name = "cantidad1";
            // 
            // CmbUnidadMedida
            // 
            this.CmbUnidadMedida.DataPropertyName = "idUnidadMedida";
            this.CmbUnidadMedida.HeaderText = "Unidad de medida";
            this.CmbUnidadMedida.Name = "CmbUnidadMedida";
            // 
            // PrecioUnitario
            // 
            this.PrecioUnitario.DataPropertyName = "precioUnitario";
            this.PrecioUnitario.HeaderText = "Precio unitario";
            this.PrecioUnitario.Name = "PrecioUnitario";
            this.PrecioUnitario.Visible = false;
            // 
            // id_producto
            // 
            this.id_producto.DataPropertyName = "id_producto";
            this.id_producto.HeaderText = "id_producto";
            this.id_producto.Name = "id_producto";
            this.id_producto.Visible = false;
            // 
            // idUnidadMedida
            // 
            this.idUnidadMedida.DataPropertyName = "idUnidadMedida";
            this.idUnidadMedida.HeaderText = "idUnidadMedida";
            this.idUnidadMedida.Name = "idUnidadMedida";
            this.idUnidadMedida.Visible = false;
            // 
            // frm_LavadoGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 488);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PanelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_LavadoGrid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frm_LavadoGrid";
            this.Load += new System.EventHandler(this.frm_LavadoGrid_Load);
            this.PanelTitulo.ResumeLayout(false);
            this.PanelTitulo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCompraDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewProductosDetalle)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.pnlBotones.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.DataGridView GridViewCompraDetalle;
        private System.Windows.Forms.DataGridView GridViewProductosDetalle;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmb_producto;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnEntregar;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.TextBox txt_costoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreProductoFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtUnidadMedidaFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_productoFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_unidadMedidaFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_lavadoDetalle;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ActivoInt1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn existencia1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad1;
        private System.Windows.Forms.DataGridViewComboBoxColumn CmbUnidadMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUnidadMedida;
    }
}