namespace PuntodeVentaTintoreria
{
    partial class frm_BuscarCliente
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDatos = new System.Windows.Forms.Panel();
            this.dgv_Clientes = new System.Windows.Forms.DataGridView();
            this.panelTitulo2 = new System.Windows.Forms.Panel();
            this.txt_titulo = new System.Windows.Forms.Label();
            this.pnl_monto = new System.Windows.Forms.Panel();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.PanelTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.timeLogin = new System.Windows.Forms.Timer(this.components);
            this.bgw_LoginInit = new System.ComponentModel.BackgroundWorker();
            this.bgw_ImagenInit = new System.ComponentModel.BackgroundWorker();
            this.toolTipLogin = new System.Windows.Forms.ToolTip(this.components);
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NOMBRE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apePat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apeMat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CORREO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_codigoEab = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.monedero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelPrincipal.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Clientes)).BeginInit();
            this.panelTitulo2.SuspendLayout();
            this.pnl_monto.SuspendLayout();
            this.PanelTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPrincipal.BackColor = System.Drawing.Color.White;
            this.panelPrincipal.Controls.Add(this.panel1);
            this.panelPrincipal.Controls.Add(this.panelDatos);
            this.panelPrincipal.Controls.Add(this.panelTitulo2);
            this.panelPrincipal.Controls.Add(this.PanelTitulo);
            this.panelPrincipal.Location = new System.Drawing.Point(4, 7);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(760, 387);
            this.panelPrincipal.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 358);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 29);
            this.panel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Sistema Tintorería";
            // 
            // panelDatos
            // 
            this.panelDatos.Controls.Add(this.dgv_Clientes);
            this.panelDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDatos.Location = new System.Drawing.Point(0, 95);
            this.panelDatos.Name = "panelDatos";
            this.panelDatos.Size = new System.Drawing.Size(760, 292);
            this.panelDatos.TabIndex = 8;
            // 
            // dgv_Clientes
            // 
            this.dgv_Clientes.AllowUserToAddRows = false;
            this.dgv_Clientes.AllowUserToDeleteRows = false;
            this.dgv_Clientes.AllowUserToOrderColumns = true;
            this.dgv_Clientes.AllowUserToResizeColumns = false;
            this.dgv_Clientes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            this.dgv_Clientes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Clientes.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Clientes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_Clientes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgv_Clientes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(230)))), ((int)(((byte)(238)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Clientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Clientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Clientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NOMBRE,
            this.apePat,
            this.apeMat,
            this.CORREO,
            this.id_codigoEab,
            this.monedero});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Clientes.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Clientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Clientes.EnableHeadersVisualStyles = false;
            this.dgv_Clientes.Location = new System.Drawing.Point(0, 0);
            this.dgv_Clientes.MultiSelect = false;
            this.dgv_Clientes.Name = "dgv_Clientes";
            this.dgv_Clientes.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Clientes.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Clientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Clientes.Size = new System.Drawing.Size(760, 292);
            this.dgv_Clientes.TabIndex = 2;
            this.dgv_Clientes.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Clientes_CellDoubleClick);
            // 
            // panelTitulo2
            // 
            this.panelTitulo2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(174)))), ((int)(((byte)(193)))));
            this.panelTitulo2.Controls.Add(this.txt_titulo);
            this.panelTitulo2.Controls.Add(this.pnl_monto);
            this.panelTitulo2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo2.Location = new System.Drawing.Point(0, 47);
            this.panelTitulo2.Name = "panelTitulo2";
            this.panelTitulo2.Size = new System.Drawing.Size(760, 48);
            this.panelTitulo2.TabIndex = 7;
            // 
            // txt_titulo
            // 
            this.txt_titulo.AutoSize = true;
            this.txt_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_titulo.ForeColor = System.Drawing.Color.White;
            this.txt_titulo.Location = new System.Drawing.Point(8, 13);
            this.txt_titulo.Name = "txt_titulo";
            this.txt_titulo.Size = new System.Drawing.Size(107, 29);
            this.txt_titulo.TabIndex = 27;
            this.txt_titulo.Text = "Nombre:";
            // 
            // pnl_monto
            // 
            this.pnl_monto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.pnl_monto.Controls.Add(this.txtCliente);
            this.pnl_monto.Location = new System.Drawing.Point(98, 7);
            this.pnl_monto.Name = "pnl_monto";
            this.pnl_monto.Size = new System.Drawing.Size(479, 35);
            this.pnl_monto.TabIndex = 5;
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txtCliente.Location = new System.Drawing.Point(3, 6);
            this.txtCliente.MaxLength = 150;
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(473, 27);
            this.txtCliente.TabIndex = 1;
            this.txtCliente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCliente_KeyDown);
            this.txtCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCliente_KeyPress);
            this.txtCliente.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCliente_KeyUp);
            this.txtCliente.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtCliente_MouseDown);
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
            this.PanelTitulo.Size = new System.Drawing.Size(760, 47);
            this.PanelTitulo.TabIndex = 5;
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(8, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(224, 25);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Búsqueda de Clientes";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.btnMinimizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Image = global::PuntodeVentaTintoreria.Properties.Resources.top_minimizar;
            this.btnMinimizar.Location = new System.Drawing.Point(677, 9);
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
            this.btnSalir.Location = new System.Drawing.Point(715, 9);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(30, 31);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // timeLogin
            // 
            this.timeLogin.Enabled = true;
            this.timeLogin.Interval = 1000;
            // 
            // toolTipLogin
            // 
            this.toolTipLogin.IsBalloon = true;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "id_cliente";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // NOMBRE
            // 
            this.NOMBRE.DataPropertyName = "nombre";
            this.NOMBRE.HeaderText = "NOMBRE";
            this.NOMBRE.Name = "NOMBRE";
            this.NOMBRE.ReadOnly = true;
            this.NOMBRE.Width = 150;
            // 
            // apePat
            // 
            this.apePat.DataPropertyName = "apePat";
            this.apePat.HeaderText = "APELLIDO PATERNO";
            this.apePat.Name = "apePat";
            this.apePat.ReadOnly = true;
            this.apePat.Width = 150;
            // 
            // apeMat
            // 
            this.apeMat.DataPropertyName = "apeMat";
            this.apeMat.HeaderText = "APELLIDO MATERNO";
            this.apeMat.Name = "apeMat";
            this.apeMat.ReadOnly = true;
            this.apeMat.Width = 150;
            // 
            // CORREO
            // 
            this.CORREO.DataPropertyName = "CorreoElectronico";
            this.CORREO.HeaderText = "CORREO";
            this.CORREO.Name = "CORREO";
            this.CORREO.ReadOnly = true;
            this.CORREO.Width = 250;
            // 
            // id_codigoEab
            // 
            this.id_codigoEab.DataPropertyName = "id_codigoEab";
            this.id_codigoEab.HeaderText = "codigoEab";
            this.id_codigoEab.Name = "id_codigoEab";
            this.id_codigoEab.ReadOnly = true;
            this.id_codigoEab.Visible = false;
            // 
            // monedero
            // 
            this.monedero.DataPropertyName = "monedero";
            this.monedero.HeaderText = "monedero";
            this.monedero.Name = "monedero";
            this.monedero.ReadOnly = true;
            this.monedero.Visible = false;
            // 
            // frm_BuscarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(196)))), ((int)(((byte)(213)))));
            this.ClientSize = new System.Drawing.Size(768, 400);
            this.ControlBox = false;
            this.Controls.Add(this.panelPrincipal);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_BuscarCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frm_BuscarCliente_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frm_BuscarClient_KeyUp);
            this.panelPrincipal.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Clientes)).EndInit();
            this.panelTitulo2.ResumeLayout(false);
            this.panelTitulo2.PerformLayout();
            this.pnl_monto.ResumeLayout(false);
            this.pnl_monto.PerformLayout();
            this.PanelTitulo.ResumeLayout(false);
            this.PanelTitulo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Panel PanelTitulo;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnSalir;
        public System.Windows.Forms.Label lblTitulo;
        public System.Windows.Forms.Panel panelTitulo2;
        public System.Windows.Forms.Panel panelDatos;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timeLogin;
        private System.ComponentModel.BackgroundWorker bgw_LoginInit;
        private System.ComponentModel.BackgroundWorker bgw_ImagenInit;
        private System.Windows.Forms.ToolTip toolTipLogin;
        private System.Windows.Forms.Label txt_titulo;
        private System.Windows.Forms.Panel pnl_monto;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.DataGridView dgv_Clientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NOMBRE;
        private System.Windows.Forms.DataGridViewTextBoxColumn apePat;
        private System.Windows.Forms.DataGridViewTextBoxColumn apeMat;
        private System.Windows.Forms.DataGridViewTextBoxColumn CORREO;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_codigoEab;
        private System.Windows.Forms.DataGridViewTextBoxColumn monedero;
    }
}

