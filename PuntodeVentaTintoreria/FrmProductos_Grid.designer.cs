namespace PuntodeVentaTintoreria
{
    partial class FrmProductos_Grid
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
            this.GridviewGeneral = new System.Windows.Forms.DataGridView();
            this.nombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_proveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadMayoreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inventarioOptimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_unidadMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_familia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.bunifuTileButton1 = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.txt_buscador = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.BtnConversiones = new System.Windows.Forms.Button();
            this.PanelTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridviewGeneral)).BeginInit();
            this.pnlBotones.SuspendLayout();
            this.pnlBusqueda.SuspendLayout();
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
            this.PanelTitulo.Size = new System.Drawing.Size(1056, 47);
            this.PanelTitulo.TabIndex = 6;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(8, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(90, 20);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Productos";
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.btnMinimizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Image = global::PuntodeVentaTintoreria.Properties.Resources.top_minimizar;
            this.btnMinimizar.Location = new System.Drawing.Point(973, 9);
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
            this.btnSalir.Location = new System.Drawing.Point(1011, 9);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(30, 31);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
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
            this.nombreProducto,
            this.tipoProducto,
            this.proveedor,
            this.unidadMedida,
            this.id_proveedor,
            this.cantidadMayoreo,
            this.inventarioOptimo,
            this.observaciones,
            this.id_producto,
            this.id_unidadMedida,
            this.id_familia});
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
            this.GridviewGeneral.Location = new System.Drawing.Point(12, 78);
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
            this.GridviewGeneral.Size = new System.Drawing.Size(1030, 288);
            this.GridviewGeneral.TabIndex = 11;
            // 
            // nombreProducto
            // 
            this.nombreProducto.DataPropertyName = "nombreProducto";
            this.nombreProducto.HeaderText = "PRODUCTO";
            this.nombreProducto.Name = "nombreProducto";
            this.nombreProducto.ReadOnly = true;
            // 
            // tipoProducto
            // 
            this.tipoProducto.DataPropertyName = "tipoProducto";
            this.tipoProducto.HeaderText = "TIPO PRODUCTO";
            this.tipoProducto.Name = "tipoProducto";
            this.tipoProducto.ReadOnly = true;
            // 
            // proveedor
            // 
            this.proveedor.DataPropertyName = "proveedor";
            this.proveedor.HeaderText = "PROVEEDOR";
            this.proveedor.Name = "proveedor";
            this.proveedor.ReadOnly = true;
            // 
            // unidadMedida
            // 
            this.unidadMedida.DataPropertyName = "unidadMedida";
            this.unidadMedida.HeaderText = "UNIDAD MEDIDA";
            this.unidadMedida.Name = "unidadMedida";
            this.unidadMedida.ReadOnly = true;
            // 
            // id_proveedor
            // 
            this.id_proveedor.DataPropertyName = "id_proveedor";
            this.id_proveedor.HeaderText = "id_proveedor";
            this.id_proveedor.Name = "id_proveedor";
            this.id_proveedor.ReadOnly = true;
            this.id_proveedor.Visible = false;
            // 
            // cantidadMayoreo
            // 
            this.cantidadMayoreo.DataPropertyName = "cantidadMayoreo";
            this.cantidadMayoreo.HeaderText = "cantidadMayoreo";
            this.cantidadMayoreo.Name = "cantidadMayoreo";
            this.cantidadMayoreo.ReadOnly = true;
            this.cantidadMayoreo.Visible = false;
            // 
            // inventarioOptimo
            // 
            this.inventarioOptimo.DataPropertyName = "inventarioOptimo";
            this.inventarioOptimo.HeaderText = "inventarioOptimo";
            this.inventarioOptimo.Name = "inventarioOptimo";
            this.inventarioOptimo.ReadOnly = true;
            this.inventarioOptimo.Visible = false;
            // 
            // observaciones
            // 
            this.observaciones.DataPropertyName = "observaciones";
            this.observaciones.HeaderText = "observaciones";
            this.observaciones.Name = "observaciones";
            this.observaciones.ReadOnly = true;
            this.observaciones.Visible = false;
            // 
            // id_producto
            // 
            this.id_producto.DataPropertyName = "id_producto";
            this.id_producto.HeaderText = "id_producto";
            this.id_producto.Name = "id_producto";
            this.id_producto.ReadOnly = true;
            this.id_producto.Visible = false;
            // 
            // id_unidadMedida
            // 
            this.id_unidadMedida.DataPropertyName = "id_unidadMedida";
            this.id_unidadMedida.HeaderText = "id_unidadMedida";
            this.id_unidadMedida.Name = "id_unidadMedida";
            this.id_unidadMedida.ReadOnly = true;
            this.id_unidadMedida.Visible = false;
            // 
            // id_familia
            // 
            this.id_familia.DataPropertyName = "id_familia";
            this.id_familia.HeaderText = "id_familia";
            this.id_familia.Name = "id_familia";
            this.id_familia.ReadOnly = true;
            this.id_familia.Visible = false;
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.pnlBotones.Controls.Add(this.BtnConversiones);
            this.pnlBotones.Controls.Add(this.button1);
            this.pnlBotones.Controls.Add(this.btnModificar);
            this.pnlBotones.Controls.Add(this.bunifuTileButton1);
            this.pnlBotones.Controls.Add(this.btnBuscar);
            this.pnlBotones.Controls.Add(this.btnCancelar);
            this.pnlBotones.Controls.Add(this.pnlBusqueda);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 386);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(1056, 102);
            this.pnlBotones.TabIndex = 12;
            this.pnlBotones.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBotones_Paint);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.DimGray;
            this.button1.Image = global::PuntodeVentaTintoreria.Properties.Resources.boton_eliminar_58x58;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(956, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 84);
            this.button1.TabIndex = 21;
            this.button1.Text = "ELIMINAR";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnModificar
            // 
            this.btnModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModificar.BackColor = System.Drawing.Color.Transparent;
            this.btnModificar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.DimGray;
            this.btnModificar.Image = global::PuntodeVentaTintoreria.Properties.Resources.boton_modificar_58x58;
            this.btnModificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnModificar.Location = new System.Drawing.Point(860, 11);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(90, 84);
            this.btnModificar.TabIndex = 18;
            this.btnModificar.Text = "MODIFICAR";
            this.btnModificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // bunifuTileButton1
            // 
            this.bunifuTileButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuTileButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTileButton1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.bunifuTileButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bunifuTileButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuTileButton1.ForeColor = System.Drawing.Color.DimGray;
            this.bunifuTileButton1.Image = global::PuntodeVentaTintoreria.Properties.Resources.boton_agregar_58x58;
            this.bunifuTileButton1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.bunifuTileButton1.Location = new System.Drawing.Point(668, 11);
            this.bunifuTileButton1.Name = "bunifuTileButton1";
            this.bunifuTileButton1.Size = new System.Drawing.Size(90, 84);
            this.bunifuTileButton1.TabIndex = 16;
            this.bunifuTileButton1.Text = "NUEVO P.";
            this.bunifuTileButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bunifuTileButton1.UseVisualStyleBackColor = false;
            this.bunifuTileButton1.Click += new System.EventHandler(this.BtnProducto_Click);
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
            this.btnBuscar.Location = new System.Drawing.Point(251, 23);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(134, 65);
            this.btnBuscar.TabIndex = 15;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.button1_Click);
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
            this.btnCancelar.Location = new System.Drawing.Point(391, 23);
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
            this.pnlBusqueda.Size = new System.Drawing.Size(240, 30);
            this.pnlBusqueda.TabIndex = 5;
            // 
            // txt_buscador
            // 
            this.txt_buscador.BackColor = System.Drawing.Color.White;
            this.txt_buscador.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_buscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_buscador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txt_buscador.Location = new System.Drawing.Point(14, 7);
            this.txt_buscador.Name = "txt_buscador";
            this.txt_buscador.Size = new System.Drawing.Size(223, 19);
            this.txt_buscador.TabIndex = 30;
            this.txt_buscador.Text = "Búsqueda por nombre o familia";
            this.txt_buscador.Click += new System.EventHandler(this.txt_buscador_Click);
            this.txt_buscador.TextChanged += new System.EventHandler(this.txt_buscador_TextChanged);
            this.txt_buscador.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_buscador_KeyDown);
            this.txt_buscador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_buscador_KeyPress);
            this.txt_buscador.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_buscador_MouseDown);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // BtnConversiones
            // 
            this.BtnConversiones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnConversiones.BackColor = System.Drawing.Color.Transparent;
            this.BtnConversiones.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.BtnConversiones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnConversiones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConversiones.ForeColor = System.Drawing.Color.DimGray;
            this.BtnConversiones.Image = global::PuntodeVentaTintoreria.Properties.Resources.cambios_58x58;
            this.BtnConversiones.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnConversiones.Location = new System.Drawing.Point(764, 11);
            this.BtnConversiones.Name = "BtnConversiones";
            this.BtnConversiones.Size = new System.Drawing.Size(90, 84);
            this.BtnConversiones.TabIndex = 22;
            this.BtnConversiones.Text = "CONV.";
            this.BtnConversiones.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnConversiones.UseVisualStyleBackColor = false;
            this.BtnConversiones.Click += new System.EventHandler(this.BtnConversiones_Click);
            // 
            // FrmProductos_Grid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(196)))), ((int)(((byte)(213)))));
            this.ClientSize = new System.Drawing.Size(1056, 488);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.GridviewGeneral);
            this.Controls.Add(this.PanelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmProductos_Grid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmProductos_Grid";
            this.Load += new System.EventHandler(this.FrmProductos_Grid_Load);
            this.PanelTitulo.ResumeLayout(false);
            this.PanelTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridviewGeneral)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelTitulo;
        public System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.DataGridView GridviewGeneral;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.TextBox txt_buscador;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button bunifuTileButton1;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_proveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadMayoreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn inventarioOptimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn observaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_unidadMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_familia;
        private System.Windows.Forms.Button BtnConversiones;
    }
}