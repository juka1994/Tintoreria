namespace PuntodeVentaTintoreria
{
    partial class Frm_GuardarEnvioV
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_GuardarEnvioV));
            this.PanelTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panelenvio = new System.Windows.Forms.Panel();
            this.EliminarFolioEntrega = new System.Windows.Forms.Button();
            this.AgregarFolioVenta = new System.Windows.Forms.Button();
            this.GridViewEntregar = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridviewGeneralFolio = new System.Windows.Forms.DataGridView();
            this.IDVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Folio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btnImportar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbvehiculo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbchofer = new System.Windows.Forms.ComboBox();
            this.lblCorreoSistema = new System.Windows.Forms.Label();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.pnlBusqueda = new System.Windows.Forms.Panel();
            this.txt_buscador = new System.Windows.Forms.TextBox();
            this.PanelTitulo.SuspendLayout();
            this.panelenvio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewEntregar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridviewGeneralFolio)).BeginInit();
            this.panel11.SuspendLayout();
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
            this.PanelTitulo.Size = new System.Drawing.Size(797, 47);
            this.PanelTitulo.TabIndex = 12;
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
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.btnMinimizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Image = global::PuntodeVentaTintoreria.Properties.Resources.top_minimizar;
            this.btnMinimizar.Location = new System.Drawing.Point(714, 9);
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
            this.btnSalir.Location = new System.Drawing.Point(752, 9);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(30, 31);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // panelenvio
            // 
            this.panelenvio.BackColor = System.Drawing.Color.White;
            this.panelenvio.Controls.Add(this.EliminarFolioEntrega);
            this.panelenvio.Controls.Add(this.AgregarFolioVenta);
            this.panelenvio.Controls.Add(this.GridViewEntregar);
            this.panelenvio.Controls.Add(this.GridviewGeneralFolio);
            this.panelenvio.Controls.Add(this.panel11);
            this.panelenvio.Controls.Add(this.label1);
            this.panelenvio.Controls.Add(this.cmbvehiculo);
            this.panelenvio.Controls.Add(this.label2);
            this.panelenvio.Controls.Add(this.label13);
            this.panelenvio.Controls.Add(this.cmbchofer);
            this.panelenvio.Controls.Add(this.lblCorreoSistema);
            this.panelenvio.Controls.Add(this.BtnBuscar);
            this.panelenvio.Controls.Add(this.btn_Eliminar);
            this.panelenvio.Controls.Add(this.pnlBusqueda);
            this.panelenvio.Location = new System.Drawing.Point(12, 63);
            this.panelenvio.Name = "panelenvio";
            this.panelenvio.Size = new System.Drawing.Size(776, 431);
            this.panelenvio.TabIndex = 13;
            // 
            // EliminarFolioEntrega
            // 
            this.EliminarFolioEntrega.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EliminarFolioEntrega.BackColor = System.Drawing.Color.Silver;
            this.EliminarFolioEntrega.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.EliminarFolioEntrega.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EliminarFolioEntrega.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EliminarFolioEntrega.ForeColor = System.Drawing.Color.DimGray;
            this.EliminarFolioEntrega.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.EliminarFolioEntrega.Location = new System.Drawing.Point(355, 160);
            this.EliminarFolioEntrega.Name = "EliminarFolioEntrega";
            this.EliminarFolioEntrega.Size = new System.Drawing.Size(37, 38);
            this.EliminarFolioEntrega.TabIndex = 225;
            this.EliminarFolioEntrega.Text = "-";
            this.EliminarFolioEntrega.UseVisualStyleBackColor = false;
            this.EliminarFolioEntrega.Click += new System.EventHandler(this.EliminarFolioEntrega_Click);
            // 
            // AgregarFolioVenta
            // 
            this.AgregarFolioVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AgregarFolioVenta.BackColor = System.Drawing.Color.Silver;
            this.AgregarFolioVenta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.AgregarFolioVenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AgregarFolioVenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgregarFolioVenta.ForeColor = System.Drawing.Color.DimGray;
            this.AgregarFolioVenta.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AgregarFolioVenta.Location = new System.Drawing.Point(355, 100);
            this.AgregarFolioVenta.Name = "AgregarFolioVenta";
            this.AgregarFolioVenta.Size = new System.Drawing.Size(37, 38);
            this.AgregarFolioVenta.TabIndex = 224;
            this.AgregarFolioVenta.Text = "+";
            this.AgregarFolioVenta.UseVisualStyleBackColor = false;
            this.AgregarFolioVenta.Click += new System.EventHandler(this.AgregarFolioVenta_Click);
            // 
            // GridViewEntregar
            // 
            this.GridViewEntregar.AllowUserToAddRows = false;
            this.GridViewEntregar.AllowUserToDeleteRows = false;
            this.GridViewEntregar.AllowUserToOrderColumns = true;
            this.GridViewEntregar.AllowUserToResizeColumns = false;
            this.GridViewEntregar.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            this.GridViewEntregar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.GridViewEntregar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridViewEntregar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.GridViewEntregar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridViewEntregar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GridViewEntregar.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(230)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridViewEntregar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.GridViewEntregar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridViewEntregar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridViewEntregar.DefaultCellStyle = dataGridViewCellStyle3;
            this.GridViewEntregar.EnableHeadersVisualStyles = false;
            this.GridViewEntregar.GridColor = System.Drawing.Color.White;
            this.GridViewEntregar.Location = new System.Drawing.Point(410, 53);
            this.GridViewEntregar.MultiSelect = false;
            this.GridViewEntregar.Name = "GridViewEntregar";
            this.GridViewEntregar.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridViewEntregar.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GridViewEntregar.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.GridViewEntregar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridViewEntregar.Size = new System.Drawing.Size(351, 190);
            this.GridViewEntregar.TabIndex = 223;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "IDVenta";
            this.dataGridViewTextBoxColumn1.HeaderText = "IDVenta";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Folio";
            this.dataGridViewTextBoxColumn2.HeaderText = "Folio Entrega";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // GridviewGeneralFolio
            // 
            this.GridviewGeneralFolio.AllowUserToAddRows = false;
            this.GridviewGeneralFolio.AllowUserToDeleteRows = false;
            this.GridviewGeneralFolio.AllowUserToOrderColumns = true;
            this.GridviewGeneralFolio.AllowUserToResizeColumns = false;
            this.GridviewGeneralFolio.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            this.GridviewGeneralFolio.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.GridviewGeneralFolio.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GridviewGeneralFolio.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(249)))), ((int)(((byte)(251)))));
            this.GridviewGeneralFolio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.GridviewGeneralFolio.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.GridviewGeneralFolio.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(230)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(8);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridviewGeneralFolio.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.GridviewGeneralFolio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridviewGeneralFolio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDVenta,
            this.Folio});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridviewGeneralFolio.DefaultCellStyle = dataGridViewCellStyle8;
            this.GridviewGeneralFolio.EnableHeadersVisualStyles = false;
            this.GridviewGeneralFolio.GridColor = System.Drawing.Color.White;
            this.GridviewGeneralFolio.Location = new System.Drawing.Point(19, 53);
            this.GridviewGeneralFolio.MultiSelect = false;
            this.GridviewGeneralFolio.Name = "GridviewGeneralFolio";
            this.GridviewGeneralFolio.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridviewGeneralFolio.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GridviewGeneralFolio.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.GridviewGeneralFolio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.GridviewGeneralFolio.Size = new System.Drawing.Size(315, 190);
            this.GridviewGeneralFolio.TabIndex = 222;
            // 
            // IDVenta
            // 
            this.IDVenta.DataPropertyName = "id_ventaServicio";
            this.IDVenta.HeaderText = "IDVenta";
            this.IDVenta.Name = "IDVenta";
            this.IDVenta.ReadOnly = true;
            this.IDVenta.Visible = false;
            // 
            // Folio
            // 
            this.Folio.DataPropertyName = "folio";
            this.Folio.HeaderText = "Seleccionar Folio";
            this.Folio.Name = "Folio";
            this.Folio.ReadOnly = true;
            // 
            // panel11
            // 
            this.panel11.BackColor = System.Drawing.Color.DarkGray;
            this.panel11.Controls.Add(this.btnImportar);
            this.panel11.Location = new System.Drawing.Point(0, 348);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(773, 81);
            this.panel11.TabIndex = 221;
            // 
            // btnImportar
            // 
            this.btnImportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportar.BackColor = System.Drawing.Color.Transparent;
            this.btnImportar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btnImportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportar.ForeColor = System.Drawing.Color.Transparent;
            this.btnImportar.Image = ((System.Drawing.Image)(resources.GetObject("btnImportar.Image")));
            this.btnImportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImportar.Location = new System.Drawing.Point(679, 6);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(82, 69);
            this.btnImportar.TabIndex = 22;
            this.btnImportar.Text = "ACEPTAR";
            this.btnImportar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImportar.UseVisualStyleBackColor = false;
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(483, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 17);
            this.label1.TabIndex = 209;
            this.label1.Text = "*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbvehiculo
            // 
            this.cmbvehiculo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.cmbvehiculo.DisplayMember = "1";
            this.cmbvehiculo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbvehiculo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.cmbvehiculo.FormattingEnabled = true;
            this.cmbvehiculo.Location = new System.Drawing.Point(413, 285);
            this.cmbvehiculo.Name = "cmbvehiculo";
            this.cmbvehiculo.Size = new System.Drawing.Size(312, 28);
            this.cmbvehiculo.TabIndex = 208;
            this.cmbvehiculo.ValueMember = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label2.Location = new System.Drawing.Point(410, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 207;
            this.label2.Text = "VEHICULO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(93, 265);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 17);
            this.label13.TabIndex = 206;
            this.label13.Text = "*";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // cmbchofer
            // 
            this.cmbchofer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.cmbchofer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbchofer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.cmbchofer.FormattingEnabled = true;
            this.cmbchofer.Location = new System.Drawing.Point(33, 285);
            this.cmbchofer.Name = "cmbchofer";
            this.cmbchofer.Size = new System.Drawing.Size(312, 28);
            this.cmbchofer.TabIndex = 205;
            // 
            // lblCorreoSistema
            // 
            this.lblCorreoSistema.AutoSize = true;
            this.lblCorreoSistema.BackColor = System.Drawing.Color.Transparent;
            this.lblCorreoSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCorreoSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreoSistema.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblCorreoSistema.Location = new System.Drawing.Point(30, 269);
            this.lblCorreoSistema.Name = "lblCorreoSistema";
            this.lblCorreoSistema.Size = new System.Drawing.Size(57, 13);
            this.lblCorreoSistema.TabIndex = 202;
            this.lblCorreoSistema.Text = "CHOFER";
            this.lblCorreoSistema.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBuscar.BackColor = System.Drawing.Color.Silver;
            this.BtnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.BtnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.ForeColor = System.Drawing.Color.DimGray;
            this.BtnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("BtnBuscar.Image")));
            this.BtnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnBuscar.Location = new System.Drawing.Point(280, 9);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(37, 38);
            this.BtnBuscar.TabIndex = 180;
            this.BtnBuscar.UseVisualStyleBackColor = false;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Eliminar.BackColor = System.Drawing.Color.Silver;
            this.btn_Eliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Eliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Eliminar.ForeColor = System.Drawing.Color.DimGray;
            this.btn_Eliminar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Eliminar.Image")));
            this.btn_Eliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Eliminar.Location = new System.Drawing.Point(323, 9);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(37, 38);
            this.btn_Eliminar.TabIndex = 179;
            this.btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Eliminar.UseVisualStyleBackColor = false;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // pnlBusqueda
            // 
            this.pnlBusqueda.BackColor = System.Drawing.Color.White;
            this.pnlBusqueda.Controls.Add(this.txt_buscador);
            this.pnlBusqueda.Location = new System.Drawing.Point(19, 12);
            this.pnlBusqueda.Name = "pnlBusqueda";
            this.pnlBusqueda.Size = new System.Drawing.Size(240, 30);
            this.pnlBusqueda.TabIndex = 6;
            // 
            // txt_buscador
            // 
            this.txt_buscador.BackColor = System.Drawing.Color.White;
            this.txt_buscador.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_buscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_buscador.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txt_buscador.Location = new System.Drawing.Point(7, 5);
            this.txt_buscador.Name = "txt_buscador";
            this.txt_buscador.Size = new System.Drawing.Size(223, 19);
            this.txt_buscador.TabIndex = 30;
            this.txt_buscador.Text = "Búsqueda por folio";
            // 
            // Frm_GuardarEnvioV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 503);
            this.Controls.Add(this.panelenvio);
            this.Controls.Add(this.PanelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_GuardarEnvioV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_GuardarEnvio";
            this.Load += new System.EventHandler(this.Frm_GuardarEnvio_Load);
            this.PanelTitulo.ResumeLayout(false);
            this.PanelTitulo.PerformLayout();
            this.panelenvio.ResumeLayout(false);
            this.panelenvio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridViewEntregar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GridviewGeneralFolio)).EndInit();
            this.panel11.ResumeLayout(false);
            this.pnlBusqueda.ResumeLayout(false);
            this.pnlBusqueda.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelTitulo;
        public System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel panelenvio;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbvehiculo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbchofer;
        private System.Windows.Forms.Label lblCorreoSistema;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Panel pnlBusqueda;
        private System.Windows.Forms.TextBox txt_buscador;
        private System.Windows.Forms.Button AgregarFolioVenta;
        private System.Windows.Forms.DataGridView GridViewEntregar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView GridviewGeneralFolio;
        private System.Windows.Forms.Button EliminarFolioEntrega;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Folio;
    }
}