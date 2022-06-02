namespace PuntodeVentaTintoreria
{
    partial class frmComprasRecibidas
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCorreoSistema = new System.Windows.Forms.Label();
            this.pnl_folio = new System.Windows.Forms.Panel();
            this.txt_folioPedido = new System.Windows.Forms.TextBox();
            this.cmb_sucursal = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_proveedor = new System.Windows.Forms.ComboBox();
            this.txt_horaPedido = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp_horaPedido = new System.Windows.Forms.DateTimePicker();
            this.txt_fechaPedido = new System.Windows.Forms.TextBox();
            this.dtp_fechaPedido = new System.Windows.Forms.DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GridViewCompraDetalle = new System.Windows.Forms.DataGridView();
            this.nombreProductoFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtUnidadMedidaFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costoFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_productoFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_unidadMedidaFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_monto = new System.Windows.Forms.TextBox();
            this.txt_observaciones = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.PanelTitulo.SuspendLayout();
            this.pnl_folio.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCompraDetalle)).BeginInit();
            this.pnlBotones.SuspendLayout();
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
            this.PanelTitulo.Size = new System.Drawing.Size(791, 53);
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
            this.lblTitulo.Size = new System.Drawing.Size(141, 20);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Recibir Compras";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.btnMinimizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Image = global::PuntodeVentaTintoreria.Properties.Resources.top_minimizar;
            this.btnMinimizar.Location = new System.Drawing.Point(708, 19);
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
            this.btnSalir.Location = new System.Drawing.Point(746, 19);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(30, 31);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(127, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 17);
            this.label3.TabIndex = 144;
            this.label3.Text = "*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(346, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 17);
            this.label2.TabIndex = 142;
            this.label2.Text = "*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label1.Location = new System.Drawing.Point(277, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 143;
            this.label1.Text = "SUCURSAL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCorreoSistema
            // 
            this.lblCorreoSistema.AutoSize = true;
            this.lblCorreoSistema.BackColor = System.Drawing.Color.Transparent;
            this.lblCorreoSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCorreoSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreoSistema.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblCorreoSistema.Location = new System.Drawing.Point(27, 78);
            this.lblCorreoSistema.Name = "lblCorreoSistema";
            this.lblCorreoSistema.Size = new System.Drawing.Size(94, 13);
            this.lblCorreoSistema.TabIndex = 141;
            this.lblCorreoSistema.Text = "FOLIO PEDIDO";
            this.lblCorreoSistema.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnl_folio
            // 
            this.pnl_folio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.pnl_folio.Controls.Add(this.txt_folioPedido);
            this.pnl_folio.Location = new System.Drawing.Point(30, 96);
            this.pnl_folio.Name = "pnl_folio";
            this.pnl_folio.Size = new System.Drawing.Size(200, 28);
            this.pnl_folio.TabIndex = 139;
            // 
            // txt_folioPedido
            // 
            this.txt_folioPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.txt_folioPedido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_folioPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_folioPedido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txt_folioPedido.Location = new System.Drawing.Point(3, 3);
            this.txt_folioPedido.Name = "txt_folioPedido";
            this.txt_folioPedido.ReadOnly = true;
            this.txt_folioPedido.Size = new System.Drawing.Size(194, 19);
            this.txt_folioPedido.TabIndex = 149;
            // 
            // cmb_sucursal
            // 
            this.cmb_sucursal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.cmb_sucursal.Enabled = false;
            this.cmb_sucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_sucursal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.cmb_sucursal.FormattingEnabled = true;
            this.cmb_sucursal.Location = new System.Drawing.Point(280, 96);
            this.cmb_sucursal.Name = "cmb_sucursal";
            this.cmb_sucursal.Size = new System.Drawing.Size(200, 28);
            this.cmb_sucursal.TabIndex = 140;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label9.Location = new System.Drawing.Point(506, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 148;
            this.label9.Text = "PROVEEDOR";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmb_proveedor
            // 
            this.cmb_proveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.cmb_proveedor.Enabled = false;
            this.cmb_proveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_proveedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.cmb_proveedor.FormattingEnabled = true;
            this.cmb_proveedor.Location = new System.Drawing.Point(509, 96);
            this.cmb_proveedor.Name = "cmb_proveedor";
            this.cmb_proveedor.Size = new System.Drawing.Size(200, 28);
            this.cmb_proveedor.TabIndex = 147;
            // 
            // txt_horaPedido
            // 
            this.txt_horaPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.txt_horaPedido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_horaPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_horaPedido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txt_horaPedido.Location = new System.Drawing.Point(25, 171);
            this.txt_horaPedido.Name = "txt_horaPedido";
            this.txt_horaPedido.ReadOnly = true;
            this.txt_horaPedido.Size = new System.Drawing.Size(205, 19);
            this.txt_horaPedido.TabIndex = 177;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label4.Location = new System.Drawing.Point(30, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 174;
            this.label4.Text = "HORA VENTA";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label5.Location = new System.Drawing.Point(277, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 173;
            this.label5.Text = "FECHA VENTA";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(127, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 17);
            this.label7.TabIndex = 176;
            this.label7.Text = "*";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(367, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 17);
            this.label6.TabIndex = 175;
            this.label6.Text = "*";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dtp_horaPedido
            // 
            this.dtp_horaPedido.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_horaPedido.Location = new System.Drawing.Point(25, 170);
            this.dtp_horaPedido.Name = "dtp_horaPedido";
            this.dtp_horaPedido.Size = new System.Drawing.Size(205, 20);
            this.dtp_horaPedido.TabIndex = 178;
            // 
            // txt_fechaPedido
            // 
            this.txt_fechaPedido.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.txt_fechaPedido.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_fechaPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_fechaPedido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txt_fechaPedido.Location = new System.Drawing.Point(280, 170);
            this.txt_fechaPedido.Name = "txt_fechaPedido";
            this.txt_fechaPedido.Size = new System.Drawing.Size(137, 19);
            this.txt_fechaPedido.TabIndex = 179;
            // 
            // dtp_fechaPedido
            // 
            this.dtp_fechaPedido.Enabled = false;
            this.dtp_fechaPedido.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_fechaPedido.Location = new System.Drawing.Point(280, 170);
            this.dtp_fechaPedido.Name = "dtp_fechaPedido";
            this.dtp_fechaPedido.Size = new System.Drawing.Size(223, 20);
            this.dtp_fechaPedido.TabIndex = 180;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label13.Location = new System.Drawing.Point(28, 542);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(111, 13);
            this.label13.TabIndex = 181;
            this.label13.Text = "OBSERVACIONES";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.panel1.Controls.Add(this.GridViewCompraDetalle);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Location = new System.Drawing.Point(25, 205);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 316);
            this.panel1.TabIndex = 182;
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
            this.id_unidadMedidaFinal});
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
            this.GridViewCompraDetalle.Location = new System.Drawing.Point(21, 29);
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
            this.GridViewCompraDetalle.Size = new System.Drawing.Size(678, 270);
            this.GridViewCompraDetalle.TabIndex = 178;
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
            // 
            // Subtotal
            // 
            this.Subtotal.DataPropertyName = "Subtotal";
            this.Subtotal.HeaderText = "Subtotal";
            this.Subtotal.Name = "Subtotal";
            this.Subtotal.ReadOnly = true;
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.label10.Location = new System.Drawing.Point(18, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 125;
            this.label10.Text = "PRODUCTO";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(94, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 17);
            this.label11.TabIndex = 124;
            this.label11.Text = "*";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.pnlBotones.Controls.Add(this.btnGuardar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 603);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(791, 92);
            this.pnlBotones.TabIndex = 185;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.Silver;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
            this.btnGuardar.Image = global::PuntodeVentaTintoreria.Properties.Resources.icono_listo_44x44B;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.Location = new System.Drawing.Point(686, 9);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(83, 75);
            this.btnGuardar.TabIndex = 116;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnGuardar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnGuardar_KeyPress);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(111)))), ((int)(((byte)(111)))));
            this.label21.Location = new System.Drawing.Point(540, 542);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(70, 18);
            this.label21.TabIndex = 115;
            this.label21.Text = "MONTO";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_monto
            // 
            this.txt_monto.BackColor = System.Drawing.Color.White;
            this.txt_monto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_monto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_monto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txt_monto.Location = new System.Drawing.Point(616, 541);
            this.txt_monto.Name = "txt_monto";
            this.txt_monto.ReadOnly = true;
            this.txt_monto.Size = new System.Drawing.Size(124, 19);
            this.txt_monto.TabIndex = 30;
            this.txt_monto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_monto_KeyDown);
            this.txt_monto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_monto_KeyPress);
            this.txt_monto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_monto_MouseDown);
            // 
            // txt_observaciones
            // 
            this.txt_observaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.txt_observaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_observaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_observaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txt_observaciones.Location = new System.Drawing.Point(145, 537);
            this.txt_observaciones.Multiline = true;
            this.txt_observaciones.Name = "txt_observaciones";
            this.txt_observaciones.ReadOnly = true;
            this.txt_observaciones.Size = new System.Drawing.Size(367, 49);
            this.txt_observaciones.TabIndex = 184;
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
            // backgroundWorker3
            // 
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            this.backgroundWorker3.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker3_RunWorkerCompleted);
            // 
            // frmComprasRecibidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 695);
            this.Controls.Add(this.txt_monto);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txt_observaciones);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmb_proveedor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCorreoSistema);
            this.Controls.Add(this.pnl_folio);
            this.Controls.Add(this.cmb_sucursal);
            this.Controls.Add(this.PanelTitulo);
            this.Controls.Add(this.txt_horaPedido);
            this.Controls.Add(this.dtp_fechaPedido);
            this.Controls.Add(this.txt_fechaPedido);
            this.Controls.Add(this.dtp_horaPedido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmComprasRecibidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmComprasRecibidas";
            this.Load += new System.EventHandler(this.frmComprasRecibidas_Load);
            this.PanelTitulo.ResumeLayout(false);
            this.PanelTitulo.PerformLayout();
            this.pnl_folio.ResumeLayout(false);
            this.pnl_folio.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewCompraDetalle)).EndInit();
            this.pnlBotones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelTitulo;
        public System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCorreoSistema;
        private System.Windows.Forms.Panel pnl_folio;
        private System.Windows.Forms.TextBox txt_folioPedido;
        private System.Windows.Forms.ComboBox cmb_sucursal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmb_proveedor;
        private System.Windows.Forms.TextBox txt_horaPedido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp_horaPedido;
        private System.Windows.Forms.TextBox txt_fechaPedido;
        private System.Windows.Forms.DateTimePicker dtp_fechaPedido;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txt_monto;
        private System.Windows.Forms.TextBox txt_observaciones;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.DataGridView GridViewCompraDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreProductoFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtUnidadMedidaFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn costoFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_productoFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_unidadMedidaFinal;
    }
}