namespace PuntodeVentaTintoreria
{
    partial class frmDocumentoXPagar
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanelTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panel_cabecera = new System.Windows.Forms.Panel();
            this.cmb_sucursal = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControlDocumentos = new System.Windows.Forms.TabControl();
            this.pendiente = new System.Windows.Forms.TabPage();
            this.GridViewPendientes = new System.Windows.Forms.DataGridView();
            this.pagado = new System.Windows.Forms.TabPage();
            this.GridViewPagados = new System.Windows.Forms.DataGridView();
            this.GridViewPagos = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_totalPagos = new System.Windows.Forms.TextBox();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnguardar = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.folioPedido1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedor1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_status1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.id_sucursal1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_compra1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_docpagar1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folioPedido2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedor2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fecha2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_status2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.id_sucursal2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_compra2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_docpagar2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechapago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.horaPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_pagoDocXPagar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PanelTitulo.SuspendLayout();
            this.panel_cabecera.SuspendLayout();
            this.tabControlDocumentos.SuspendLayout();
            this.pendiente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPendientes)).BeginInit();
            this.pagado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPagados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPagos)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlBotones.SuspendLayout();
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
            this.PanelTitulo.Size = new System.Drawing.Size(806, 47);
            this.PanelTitulo.TabIndex = 7;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(8, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(194, 20);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Documentos Por Pagar";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.btnMinimizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Image = global::PuntodeVentaTintoreria.Properties.Resources.top_minimizar;
            this.btnMinimizar.Location = new System.Drawing.Point(723, 9);
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
            this.btnSalir.Location = new System.Drawing.Point(761, 9);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(30, 31);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panel_cabecera
            // 
            this.panel_cabecera.BackColor = System.Drawing.Color.Gray;
            this.panel_cabecera.Controls.Add(this.cmb_sucursal);
            this.panel_cabecera.Controls.Add(this.label3);
            this.panel_cabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_cabecera.Location = new System.Drawing.Point(0, 47);
            this.panel_cabecera.Name = "panel_cabecera";
            this.panel_cabecera.Size = new System.Drawing.Size(806, 50);
            this.panel_cabecera.TabIndex = 8;
            // 
            // cmb_sucursal
            // 
            this.cmb_sucursal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.cmb_sucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_sucursal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.cmb_sucursal.FormattingEnabled = true;
            this.cmb_sucursal.Location = new System.Drawing.Point(129, 13);
            this.cmb_sucursal.Name = "cmb_sucursal";
            this.cmb_sucursal.Size = new System.Drawing.Size(200, 26);
            this.cmb_sucursal.TabIndex = 1;
            this.cmb_sucursal.SelectedValueChanged += new System.EventHandler(this.cmb_sucursal_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "SUCURSAL:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControlDocumentos
            // 
            this.tabControlDocumentos.Controls.Add(this.pendiente);
            this.tabControlDocumentos.Controls.Add(this.pagado);
            this.tabControlDocumentos.Location = new System.Drawing.Point(15, 118);
            this.tabControlDocumentos.Name = "tabControlDocumentos";
            this.tabControlDocumentos.SelectedIndex = 0;
            this.tabControlDocumentos.Size = new System.Drawing.Size(776, 245);
            this.tabControlDocumentos.TabIndex = 21;
            this.tabControlDocumentos.SelectedIndexChanged += new System.EventHandler(this.tabControlDocumentos_SelectedIndexChanged);
            // 
            // pendiente
            // 
            this.pendiente.Controls.Add(this.GridViewPendientes);
            this.pendiente.Location = new System.Drawing.Point(4, 22);
            this.pendiente.Name = "pendiente";
            this.pendiente.Padding = new System.Windows.Forms.Padding(3);
            this.pendiente.Size = new System.Drawing.Size(768, 219);
            this.pendiente.TabIndex = 0;
            this.pendiente.Text = "PENDIENTES";
            this.pendiente.UseVisualStyleBackColor = true;
            // 
            // GridViewPendientes
            // 
            this.GridViewPendientes.AllowUserToAddRows = false;
            this.GridViewPendientes.AllowUserToDeleteRows = false;
            this.GridViewPendientes.AllowUserToOrderColumns = true;
            this.GridViewPendientes.AllowUserToResizeColumns = false;
            this.GridViewPendientes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            this.GridViewPendientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridViewPendientes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.GridViewPendientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridViewPendientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GridViewPendientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(230)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridViewPendientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridViewPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewPendientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.folioPedido1,
            this.proveedor1,
            this.fecha1,
            this.hora1,
            this.total1,
            this.id_status1,
            this.status1,
            this.id_sucursal1,
            this.id_compra1,
            this.id_docpagar1});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridViewPendientes.DefaultCellStyle = dataGridViewCellStyle3;
            this.GridViewPendientes.EnableHeadersVisualStyles = false;
            this.GridViewPendientes.GridColor = System.Drawing.Color.White;
            this.GridViewPendientes.Location = new System.Drawing.Point(0, 0);
            this.GridViewPendientes.MultiSelect = false;
            this.GridViewPendientes.Name = "GridViewPendientes";
            this.GridViewPendientes.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridViewPendientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GridViewPendientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewPendientes.Size = new System.Drawing.Size(768, 219);
            this.GridViewPendientes.TabIndex = 18;
            this.GridViewPendientes.SelectionChanged += new System.EventHandler(this.GridViewPendientes_SelectionChanged);
            this.GridViewPendientes.Sorted += new System.EventHandler(this.GridViewPendientes_Sorted);
            // 
            // pagado
            // 
            this.pagado.Controls.Add(this.GridViewPagados);
            this.pagado.Location = new System.Drawing.Point(4, 22);
            this.pagado.Name = "pagado";
            this.pagado.Padding = new System.Windows.Forms.Padding(3);
            this.pagado.Size = new System.Drawing.Size(768, 219);
            this.pagado.TabIndex = 1;
            this.pagado.Text = "PAGADOS";
            this.pagado.UseVisualStyleBackColor = true;
            // 
            // GridViewPagados
            // 
            this.GridViewPagados.AllowUserToAddRows = false;
            this.GridViewPagados.AllowUserToDeleteRows = false;
            this.GridViewPagados.AllowUserToOrderColumns = true;
            this.GridViewPagados.AllowUserToResizeColumns = false;
            this.GridViewPagados.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            this.GridViewPagados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.GridViewPagados.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.GridViewPagados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridViewPagados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GridViewPagados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(230)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(8);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridViewPagados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.GridViewPagados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewPagados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.folioPedido2,
            this.proveedor2,
            this.fecha2,
            this.hora2,
            this.total2,
            this.id_status2,
            this.status2,
            this.id_sucursal2,
            this.id_compra2,
            this.id_docpagar2});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridViewPagados.DefaultCellStyle = dataGridViewCellStyle7;
            this.GridViewPagados.EnableHeadersVisualStyles = false;
            this.GridViewPagados.GridColor = System.Drawing.Color.White;
            this.GridViewPagados.Location = new System.Drawing.Point(0, 0);
            this.GridViewPagados.MultiSelect = false;
            this.GridViewPagados.Name = "GridViewPagados";
            this.GridViewPagados.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridViewPagados.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.GridViewPagados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewPagados.Size = new System.Drawing.Size(768, 219);
            this.GridViewPagados.TabIndex = 19;
            this.GridViewPagados.SelectionChanged += new System.EventHandler(this.GridViewPagados_SelectionChanged);
            this.GridViewPagados.Sorted += new System.EventHandler(this.GridViewPagados_Sorted);
            // 
            // GridViewPagos
            // 
            this.GridViewPagos.AllowUserToAddRows = false;
            this.GridViewPagos.AllowUserToDeleteRows = false;
            this.GridViewPagos.AllowUserToOrderColumns = true;
            this.GridViewPagos.AllowUserToResizeColumns = false;
            this.GridViewPagos.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            this.GridViewPagos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.GridViewPagos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.GridViewPagos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridViewPagos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GridViewPagos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(230)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(8);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridViewPagos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.GridViewPagos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewPagos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fechapago,
            this.horaPago,
            this.monto,
            this.id_pagoDocXPagar});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridViewPagos.DefaultCellStyle = dataGridViewCellStyle11;
            this.GridViewPagos.EnableHeadersVisualStyles = false;
            this.GridViewPagos.GridColor = System.Drawing.Color.White;
            this.GridViewPagos.Location = new System.Drawing.Point(15, 452);
            this.GridViewPagos.MultiSelect = false;
            this.GridViewPagos.Name = "GridViewPagos";
            this.GridViewPagos.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridViewPagos.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.GridViewPagos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewPagos.Size = new System.Drawing.Size(424, 146);
            this.GridViewPagos.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(15, 419);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 27);
            this.panel1.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(314, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "LISTADO DE PAGOS";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(165, 118);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(622, 23);
            this.panel2.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(164, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "LISTADO DE DOCUMENTOS";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
            this.label7.Location = new System.Drawing.Point(591, 479);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 18);
            this.label7.TabIndex = 29;
            this.label7.Text = "TOTAL PAGOS:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_totalPagos
            // 
            this.txt_totalPagos.BackColor = System.Drawing.Color.White;
            this.txt_totalPagos.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_totalPagos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
            this.txt_totalPagos.Location = new System.Drawing.Point(552, 512);
            this.txt_totalPagos.Name = "txt_totalPagos";
            this.txt_totalPagos.ReadOnly = true;
            this.txt_totalPagos.Size = new System.Drawing.Size(197, 49);
            this.txt_totalPagos.TabIndex = 28;
            this.txt_totalPagos.Text = "0.00";
            this.txt_totalPagos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.pnlBotones.Controls.Add(this.btnguardar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 608);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(806, 92);
            this.pnlBotones.TabIndex = 30;
            // 
            // btnguardar
            // 
            this.btnguardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnguardar.BackColor = System.Drawing.Color.Transparent;
            this.btnguardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnguardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnguardar.ForeColor = System.Drawing.Color.Gray;
            this.btnguardar.Image = global::PuntodeVentaTintoreria.Properties.Resources.icono_pagos_58x581;
            this.btnguardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnguardar.Location = new System.Drawing.Point(708, 3);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(83, 86);
            this.btnguardar.TabIndex = 32;
            this.btnguardar.Text = "PAGOS";
            this.btnguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnguardar.UseVisualStyleBackColor = false;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // folioPedido1
            // 
            this.folioPedido1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.folioPedido1.DataPropertyName = "folioPedido";
            this.folioPedido1.HeaderText = "FOLIO COMPRA";
            this.folioPedido1.Name = "folioPedido1";
            this.folioPedido1.ReadOnly = true;
            // 
            // proveedor1
            // 
            this.proveedor1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.proveedor1.DataPropertyName = "proveedor";
            this.proveedor1.HeaderText = "PROVEEDOR";
            this.proveedor1.Name = "proveedor1";
            this.proveedor1.ReadOnly = true;
            // 
            // fecha1
            // 
            this.fecha1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fecha1.DataPropertyName = "fecha";
            this.fecha1.HeaderText = "FECHA";
            this.fecha1.Name = "fecha1";
            this.fecha1.ReadOnly = true;
            // 
            // hora1
            // 
            this.hora1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.hora1.DataPropertyName = "hora";
            this.hora1.HeaderText = "HORA";
            this.hora1.Name = "hora1";
            this.hora1.ReadOnly = true;
            // 
            // total1
            // 
            this.total1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.total1.DataPropertyName = "total";
            this.total1.HeaderText = "TOTAL";
            this.total1.Name = "total1";
            this.total1.ReadOnly = true;
            // 
            // id_status1
            // 
            this.id_status1.DataPropertyName = "id_status";
            this.id_status1.HeaderText = "id_status";
            this.id_status1.Name = "id_status1";
            this.id_status1.ReadOnly = true;
            this.id_status1.Visible = false;
            // 
            // status1
            // 
            this.status1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.status1.DataPropertyName = "status";
            this.status1.HeaderText = "STATUS";
            this.status1.Name = "status1";
            this.status1.ReadOnly = true;
            this.status1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.status1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // id_sucursal1
            // 
            this.id_sucursal1.DataPropertyName = "id_sucursal";
            this.id_sucursal1.HeaderText = "id_sucursal";
            this.id_sucursal1.Name = "id_sucursal1";
            this.id_sucursal1.ReadOnly = true;
            this.id_sucursal1.Visible = false;
            // 
            // id_compra1
            // 
            this.id_compra1.DataPropertyName = "id_compra";
            this.id_compra1.HeaderText = "id_compra";
            this.id_compra1.Name = "id_compra1";
            this.id_compra1.ReadOnly = true;
            this.id_compra1.Visible = false;
            // 
            // id_docpagar1
            // 
            this.id_docpagar1.DataPropertyName = "id_docXPagar";
            this.id_docpagar1.HeaderText = "id_docXPagar";
            this.id_docpagar1.Name = "id_docpagar1";
            this.id_docpagar1.ReadOnly = true;
            this.id_docpagar1.Visible = false;
            // 
            // folioPedido2
            // 
            this.folioPedido2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.folioPedido2.DataPropertyName = "folioPedido";
            this.folioPedido2.HeaderText = "FOLIO COMPRA";
            this.folioPedido2.Name = "folioPedido2";
            this.folioPedido2.ReadOnly = true;
            // 
            // proveedor2
            // 
            this.proveedor2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.proveedor2.DataPropertyName = "proveedor";
            this.proveedor2.HeaderText = "PROVEEDOR";
            this.proveedor2.Name = "proveedor2";
            this.proveedor2.ReadOnly = true;
            // 
            // fecha2
            // 
            this.fecha2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fecha2.DataPropertyName = "fecha";
            this.fecha2.HeaderText = "FECHA";
            this.fecha2.Name = "fecha2";
            this.fecha2.ReadOnly = true;
            // 
            // hora2
            // 
            this.hora2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.hora2.DataPropertyName = "hora";
            this.hora2.HeaderText = "HORA";
            this.hora2.Name = "hora2";
            this.hora2.ReadOnly = true;
            // 
            // total2
            // 
            this.total2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.total2.DataPropertyName = "total";
            this.total2.HeaderText = "TOTAL";
            this.total2.Name = "total2";
            this.total2.ReadOnly = true;
            // 
            // id_status2
            // 
            this.id_status2.DataPropertyName = "id_status";
            this.id_status2.HeaderText = "id_status";
            this.id_status2.Name = "id_status2";
            this.id_status2.ReadOnly = true;
            this.id_status2.Visible = false;
            // 
            // status2
            // 
            this.status2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.status2.DataPropertyName = "status";
            this.status2.HeaderText = "STATUS";
            this.status2.Name = "status2";
            this.status2.ReadOnly = true;
            this.status2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.status2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // id_sucursal2
            // 
            this.id_sucursal2.DataPropertyName = "id_sucursal";
            this.id_sucursal2.HeaderText = "id_sucursal";
            this.id_sucursal2.Name = "id_sucursal2";
            this.id_sucursal2.ReadOnly = true;
            this.id_sucursal2.Visible = false;
            // 
            // id_compra2
            // 
            this.id_compra2.DataPropertyName = "id_compra";
            this.id_compra2.HeaderText = "id_compra";
            this.id_compra2.Name = "id_compra2";
            this.id_compra2.ReadOnly = true;
            this.id_compra2.Visible = false;
            // 
            // id_docpagar2
            // 
            this.id_docpagar2.DataPropertyName = "id_docXPagar";
            this.id_docpagar2.HeaderText = "id_docXPagar";
            this.id_docpagar2.Name = "id_docpagar2";
            this.id_docpagar2.ReadOnly = true;
            this.id_docpagar2.Visible = false;
            // 
            // fechapago
            // 
            this.fechapago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fechapago.DataPropertyName = "fechapago";
            this.fechapago.HeaderText = "FECHA";
            this.fechapago.Name = "fechapago";
            this.fechapago.ReadOnly = true;
            // 
            // horaPago
            // 
            this.horaPago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.horaPago.DataPropertyName = "horaPago";
            this.horaPago.HeaderText = "HORA";
            this.horaPago.Name = "horaPago";
            this.horaPago.ReadOnly = true;
            // 
            // monto
            // 
            this.monto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.monto.DataPropertyName = "monto";
            this.monto.HeaderText = "MONTO";
            this.monto.Name = "monto";
            this.monto.ReadOnly = true;
            // 
            // id_pagoDocXPagar
            // 
            this.id_pagoDocXPagar.DataPropertyName = "id_pagoDocXPagar";
            this.id_pagoDocXPagar.HeaderText = "id_pagoDocXPagar";
            this.id_pagoDocXPagar.Name = "id_pagoDocXPagar";
            this.id_pagoDocXPagar.ReadOnly = true;
            this.id_pagoDocXPagar.Visible = false;
            // 
            // frmDocumentoXPagar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 700);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_totalPagos);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GridViewPagos);
            this.Controls.Add(this.tabControlDocumentos);
            this.Controls.Add(this.panel_cabecera);
            this.Controls.Add(this.PanelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmDocumentoXPagar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDocumentoXPagar";
            this.Load += new System.EventHandler(this.frmDocumentoXPagar_Load);
            this.PanelTitulo.ResumeLayout(false);
            this.PanelTitulo.PerformLayout();
            this.panel_cabecera.ResumeLayout(false);
            this.panel_cabecera.PerformLayout();
            this.tabControlDocumentos.ResumeLayout(false);
            this.pendiente.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPendientes)).EndInit();
            this.pagado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPagados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewPagos)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelTitulo;
        public System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panel_cabecera;
        private System.Windows.Forms.ComboBox cmb_sucursal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControlDocumentos;
        private System.Windows.Forms.TabPage pendiente;
        private System.Windows.Forms.DataGridView GridViewPendientes;
        private System.Windows.Forms.TabPage pagado;
        private System.Windows.Forms.DataGridView GridViewPagados;
        private System.Windows.Forms.DataGridView GridViewPagos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_totalPagos;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnguardar;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.DataGridViewTextBoxColumn folioPedido1;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedor1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha1;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora1;
        private System.Windows.Forms.DataGridViewTextBoxColumn total1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_status1;
        private System.Windows.Forms.DataGridViewImageColumn status1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_sucursal1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_compra1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_docpagar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn folioPedido2;
        private System.Windows.Forms.DataGridViewTextBoxColumn proveedor2;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecha2;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora2;
        private System.Windows.Forms.DataGridViewTextBoxColumn total2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_status2;
        private System.Windows.Forms.DataGridViewImageColumn status2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_sucursal2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_compra2;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_docpagar2;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechapago;
        private System.Windows.Forms.DataGridViewTextBoxColumn horaPago;
        private System.Windows.Forms.DataGridViewTextBoxColumn monto;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_pagoDocXPagar;
    }
}