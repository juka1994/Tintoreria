namespace Componentes
{
    partial class ArticuloV5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArticuloV5));
            this.ToolTipPrincipal = new System.Windows.Forms.ToolTip(this.components);
            this.imgArticulo = new System.Windows.Forms.PictureBox();
            this.panelTxt = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.panelPrincipal = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.imgArticulo)).BeginInit();
            this.panelTxt.SuspendLayout();
            this.panelPrincipal.SuspendLayout();
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
            this.imgArticulo.BackColor = System.Drawing.Color.Transparent;
            this.imgArticulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgArticulo.Image = ((System.Drawing.Image)(resources.GetObject("imgArticulo.Image")));
            this.imgArticulo.Location = new System.Drawing.Point(0, 0);
            this.imgArticulo.Name = "imgArticulo";
            this.imgArticulo.Size = new System.Drawing.Size(90, 77);
            this.imgArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgArticulo.TabIndex = 7;
            this.imgArticulo.TabStop = false;
            this.ToolTipPrincipal.SetToolTip(this.imgArticulo, "Nombre del producto");
            this.imgArticulo.Click += new System.EventHandler(this.imgArticulo_Click);
            this.imgArticulo.MouseEnter += new System.EventHandler(this.imgArticulo_MouseEnter);
            this.imgArticulo.MouseLeave += new System.EventHandler(this.imgArticulo_MouseLeave);
            this.imgArticulo.MouseHover += new System.EventHandler(this.imgArticulo_MouseHover);
            // 
            // panelTxt
            // 
            this.panelTxt.BackColor = System.Drawing.Color.DimGray;
            this.panelTxt.Controls.Add(this.lblNombre);
            this.panelTxt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTxt.Location = new System.Drawing.Point(0, 77);
            this.panelTxt.Name = "panelTxt";
            this.panelTxt.Size = new System.Drawing.Size(90, 33);
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
            this.lblNombre.Size = new System.Drawing.Size(90, 33);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre Producto";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Controls.Add(this.imgArticulo);
            this.panelPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(90, 77);
            this.panelPrincipal.TabIndex = 9;
            // 
            // ArticuloV5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.panelPrincipal);
            this.Controls.Add(this.panelTxt);
            this.Name = "ArticuloV5";
            this.Size = new System.Drawing.Size(90, 110);
            this.Load += new System.EventHandler(this.Articulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgArticulo)).EndInit();
            this.panelTxt.ResumeLayout(false);
            this.panelPrincipal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ToolTipPrincipal;
        private System.Windows.Forms.Panel panelTxt;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Panel panelPrincipal;
        public System.Windows.Forms.PictureBox imgArticulo;
    }
}
