namespace Componentes
{
    partial class ArticuloV4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticuloV4));
            this.ToolTipPrincipal = new System.Windows.Forms.ToolTip(this.components);
            this.imgArticulo = new System.Windows.Forms.PictureBox();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            this.chkArticulo = new System.Windows.Forms.CheckBox();
            this.panelTxt = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgArticulo)).BeginInit();
            this.panelPrincipal.SuspendLayout();
            this.panelTxt.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolTipPrincipal
            // 
            this.ToolTipPrincipal.AutomaticDelay = 0;
            this.ToolTipPrincipal.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ToolTipPrincipal.ForeColor = System.Drawing.Color.White;
            this.ToolTipPrincipal.IsBalloon = true;
            // 
            // imgArticulo
            // 
            this.imgArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgArticulo.BackColor = System.Drawing.Color.Transparent;
            this.imgArticulo.Image = ((System.Drawing.Image)(resources.GetObject("imgArticulo.Image")));
            this.imgArticulo.Location = new System.Drawing.Point(33, 6);
            this.imgArticulo.Margin = new System.Windows.Forms.Padding(0);
            this.imgArticulo.Name = "imgArticulo";
            this.imgArticulo.Size = new System.Drawing.Size(50, 52);
            this.imgArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgArticulo.TabIndex = 9;
            this.imgArticulo.TabStop = false;
            this.ToolTipPrincipal.SetToolTip(this.imgArticulo, "Nombre del producto");
            this.imgArticulo.Click += new System.EventHandler(this.imgArticulo_Click);
            this.imgArticulo.MouseEnter += new System.EventHandler(this.imgArticulo_MouseEnter);
            this.imgArticulo.MouseLeave += new System.EventHandler(this.imgArticulo_MouseLeave);
            this.imgArticulo.MouseHover += new System.EventHandler(this.imgArticulo_MouseHover);
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Controls.Add(this.imgArticulo);
            this.panelPrincipal.Controls.Add(this.chkArticulo);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(90, 85);
            this.panelPrincipal.TabIndex = 0;
            this.panelPrincipal.Click += new System.EventHandler(this.imgArticulo_Click);
            this.panelPrincipal.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPrincipal_Paint);
            this.panelPrincipal.MouseEnter += new System.EventHandler(this.imgArticulo_MouseEnter);
            this.panelPrincipal.MouseLeave += new System.EventHandler(this.imgArticulo_MouseLeave);
            this.panelPrincipal.MouseHover += new System.EventHandler(this.imgArticulo_MouseHover);
            // 
            // chkArticulo
            // 
            this.chkArticulo.BackColor = System.Drawing.Color.Transparent;
            this.chkArticulo.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkArticulo.Enabled = false;
            this.chkArticulo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chkArticulo.FlatAppearance.BorderSize = 2;
            this.chkArticulo.FlatAppearance.CheckedBackColor = System.Drawing.Color.Aqua;
            this.chkArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkArticulo.Location = new System.Drawing.Point(1, 3);
            this.chkArticulo.Name = "chkArticulo";
            this.chkArticulo.Size = new System.Drawing.Size(30, 25);
            this.chkArticulo.TabIndex = 8;
            this.chkArticulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkArticulo.UseVisualStyleBackColor = false;
            // 
            // panelTxt
            // 
            this.panelTxt.BackColor = System.Drawing.Color.DimGray;
            this.panelTxt.Controls.Add(this.lblNombre);
            this.panelTxt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTxt.Location = new System.Drawing.Point(0, 90);
            this.panelTxt.Name = "panelTxt";
            this.panelTxt.Size = new System.Drawing.Size(90, 20);
            this.panelTxt.TabIndex = 8;
            // 
            // lblNombre
            // 
            this.lblNombre.BackColor = System.Drawing.Color.Transparent;
            this.lblNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNombre.Font = new System.Drawing.Font("Arial Narrow", 7.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(0, 0);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(90, 20);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Color Producto";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ArticuloV4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.panelTxt);
            this.Controls.Add(this.panelPrincipal);
            this.Name = "ArticuloV4";
            this.Size = new System.Drawing.Size(90, 110);
            this.Load += new System.EventHandler(this.Articulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgArticulo)).EndInit();
            this.panelPrincipal.ResumeLayout(false);
            this.panelTxt.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ToolTipPrincipal;
        private System.Windows.Forms.Panel panelPrincipal;
        private System.Windows.Forms.Panel panelTxt;
        private System.Windows.Forms.Label lblNombre;
        public System.Windows.Forms.PictureBox imgArticulo;
        private System.Windows.Forms.CheckBox chkArticulo;
    }
}
