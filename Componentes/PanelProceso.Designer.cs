namespace Componentes
{
    partial class PanelProceso
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelProceso));
            this.ToolTipPrincipal = new System.Windows.Forms.ToolTip(this.components);
            this.imgTipoServ = new System.Windows.Forms.PictureBox();
            this.imgTipoEntrega = new System.Windows.Forms.PictureBox();
            this.panelTxt = new System.Windows.Forms.Panel();
            this.txtCantidad = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.Label();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.txtFecha = new System.Windows.Forms.Label();
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.txtFolio = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtHora = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgTipoServ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTipoEntrega)).BeginInit();
            this.panelTxt.SuspendLayout();
            this.panelPrincipal.SuspendLayout();
            this.panelTitulo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolTipPrincipal
            // 
            this.ToolTipPrincipal.AutomaticDelay = 0;
            this.ToolTipPrincipal.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ToolTipPrincipal.ForeColor = System.Drawing.Color.White;
            this.ToolTipPrincipal.IsBalloon = true;
            // 
            // imgTipoServ
            // 
            this.imgTipoServ.BackColor = System.Drawing.Color.Transparent;
            this.imgTipoServ.Image = ((System.Drawing.Image)(resources.GetObject("imgTipoServ.Image")));
            this.imgTipoServ.Location = new System.Drawing.Point(4, 2);
            this.imgTipoServ.Margin = new System.Windows.Forms.Padding(2);
            this.imgTipoServ.Name = "imgTipoServ";
            this.imgTipoServ.Size = new System.Drawing.Size(33, 36);
            this.imgTipoServ.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgTipoServ.TabIndex = 9;
            this.imgTipoServ.TabStop = false;
            this.ToolTipPrincipal.SetToolTip(this.imgTipoServ, "Nombre del producto");
            // 
            // imgTipoEntrega
            // 
            this.imgTipoEntrega.BackColor = System.Drawing.Color.Transparent;
            this.imgTipoEntrega.Image = ((System.Drawing.Image)(resources.GetObject("imgTipoEntrega.Image")));
            this.imgTipoEntrega.Location = new System.Drawing.Point(41, 2);
            this.imgTipoEntrega.Margin = new System.Windows.Forms.Padding(2);
            this.imgTipoEntrega.Name = "imgTipoEntrega";
            this.imgTipoEntrega.Size = new System.Drawing.Size(33, 36);
            this.imgTipoEntrega.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgTipoEntrega.TabIndex = 10;
            this.imgTipoEntrega.TabStop = false;
            this.ToolTipPrincipal.SetToolTip(this.imgTipoEntrega, "Nombre del producto");
            // 
            // panelTxt
            // 
            this.panelTxt.BackColor = System.Drawing.Color.DimGray;
            this.panelTxt.Controls.Add(this.txtCantidad);
            this.panelTxt.Controls.Add(this.txtNombre);
            this.panelTxt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTxt.Location = new System.Drawing.Point(0, 169);
            this.panelTxt.Margin = new System.Windows.Forms.Padding(2);
            this.panelTxt.Name = "panelTxt";
            this.panelTxt.Size = new System.Drawing.Size(225, 34);
            this.panelTxt.TabIndex = 8;
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.Transparent;
            this.txtCantidad.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtCantidad.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.ForeColor = System.Drawing.Color.White;
            this.txtCantidad.Location = new System.Drawing.Point(166, 0);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(0);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(59, 34);
            this.txtCantidad.TabIndex = 1;
            this.txtCantidad.Text = "#999";
            this.txtCantidad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.Transparent;
            this.txtNombre.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtNombre.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.White;
            this.txtNombre.Location = new System.Drawing.Point(0, 0);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(0);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(166, 34);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.Text = "Nombre del cliente y sus apellidos";
            this.txtNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.BackColor = System.Drawing.Color.Firebrick;
            this.panelPrincipal.Controls.Add(this.txtFecha);
            this.panelPrincipal.Controls.Add(this.txtHora);
            this.panelPrincipal.Controls.Add(this.panelTitulo);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Margin = new System.Windows.Forms.Padding(2);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(225, 169);
            this.panelPrincipal.TabIndex = 9;
            this.panelPrincipal.Click += new System.EventHandler(this.ImgArticulo_Click);
            // 
            // txtFecha
            // 
            this.txtFecha.BackColor = System.Drawing.Color.Transparent;
            this.txtFecha.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtFecha.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFecha.ForeColor = System.Drawing.Color.White;
            this.txtFecha.Location = new System.Drawing.Point(0, 53);
            this.txtFecha.Margin = new System.Windows.Forms.Padding(0);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.Size = new System.Drawing.Size(225, 116);
            this.txtFecha.TabIndex = 11;
            this.txtFecha.Text = "01/01/2017 - 14:00";
            this.txtFecha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtFecha.Click += new System.EventHandler(this.ImgArticulo_Click);
            // 
            // panelTitulo
            // 
            this.panelTitulo.BackColor = System.Drawing.Color.DimGray;
            this.panelTitulo.Controls.Add(this.imgTipoEntrega);
            this.panelTitulo.Controls.Add(this.imgTipoServ);
            this.panelTitulo.Controls.Add(this.txtFolio);
            this.panelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitulo.Location = new System.Drawing.Point(0, 0);
            this.panelTitulo.Margin = new System.Windows.Forms.Padding(2);
            this.panelTitulo.Name = "panelTitulo";
            this.panelTitulo.Size = new System.Drawing.Size(225, 41);
            this.panelTitulo.TabIndex = 9;
            // 
            // txtFolio
            // 
            this.txtFolio.BackColor = System.Drawing.Color.Maroon;
            this.txtFolio.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtFolio.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFolio.ForeColor = System.Drawing.Color.White;
            this.txtFolio.Location = new System.Drawing.Point(77, 0);
            this.txtFolio.Margin = new System.Windows.Forms.Padding(0);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(148, 41);
            this.txtFolio.TabIndex = 0;
            this.txtFolio.Text = "Folio";
            this.txtFolio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // txtHora
            // 
            this.txtHora.BackColor = System.Drawing.Color.Transparent;
            this.txtHora.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtHora.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHora.ForeColor = System.Drawing.Color.White;
            this.txtHora.Location = new System.Drawing.Point(0, 41);
            this.txtHora.Margin = new System.Windows.Forms.Padding(0);
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(225, 12);
            this.txtHora.TabIndex = 10;
            this.txtHora.Text = "00:00:00";
            this.txtHora.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.txtHora.Visible = false;
            this.txtHora.Click += new System.EventHandler(this.ImgArticulo_Click);
            // 
            // PanelProceso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.panelTxt);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PanelProceso";
            this.Size = new System.Drawing.Size(225, 203);
            this.Load += new System.EventHandler(this.Articulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgTipoServ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTipoEntrega)).EndInit();
            this.panelTxt.ResumeLayout(false);
            this.panelPrincipal.ResumeLayout(false);
            this.panelTitulo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ToolTipPrincipal;
        private System.Windows.Forms.Panel panelTxt;
        private System.Windows.Forms.Label txtNombre;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Label txtCantidad;
        private System.Windows.Forms.Label txtFecha;
        private System.Windows.Forms.Panel panelTitulo;
        public System.Windows.Forms.PictureBox imgTipoEntrega;
        public System.Windows.Forms.PictureBox imgTipoServ;
        private System.Windows.Forms.Label txtFolio;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label txtHora;
    }
}
