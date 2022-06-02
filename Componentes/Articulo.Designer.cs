namespace Componentes
{
    partial class Articulo
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
            this.ToolTipPrincipal = new System.Windows.Forms.ToolTip(this.components);
            this.imgArticulo = new System.Windows.Forms.PictureBox();
            this.panelPrincipal = new System.Windows.Forms.Panel();
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
            this.imgArticulo.BackColor = System.Drawing.Color.Transparent;
            this.imgArticulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgArticulo.Image = global::Componentes.Properties.Resources.DFTipoRopa;
            this.imgArticulo.Location = new System.Drawing.Point(0, 0);
            this.imgArticulo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.imgArticulo.Name = "imgArticulo";
            this.imgArticulo.Size = new System.Drawing.Size(68, 73);
            this.imgArticulo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgArticulo.TabIndex = 7;
            this.imgArticulo.TabStop = false;
            this.ToolTipPrincipal.SetToolTip(this.imgArticulo, "Nombre del producto");
            this.imgArticulo.Click += new System.EventHandler(this.ImgArticulo_Click);
            this.imgArticulo.MouseEnter += new System.EventHandler(this.ImgArticulo_MouseEnter);
            this.imgArticulo.MouseLeave += new System.EventHandler(this.ImgArticulo_MouseLeave);
            this.imgArticulo.MouseHover += new System.EventHandler(this.ImgArticulo_MouseHover);
            // 
            // panelPrincipal
            // 
            this.panelPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPrincipal.Controls.Add(this.imgArticulo);
            this.panelPrincipal.Location = new System.Drawing.Point(0, 0);
            this.panelPrincipal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelPrincipal.Name = "panelPrincipal";
            this.panelPrincipal.Size = new System.Drawing.Size(68, 73);
            this.panelPrincipal.TabIndex = 0;
            this.panelPrincipal.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelPrincipal_Paint);
            // 
            // panelTxt
            // 
            this.panelTxt.BackColor = System.Drawing.Color.DimGray;
            this.panelTxt.Controls.Add(this.lblNombre);
            this.panelTxt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelTxt.Location = new System.Drawing.Point(0, 73);
            this.panelTxt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelTxt.Name = "panelTxt";
            this.panelTxt.Size = new System.Drawing.Size(68, 16);
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
            this.lblNombre.Size = new System.Drawing.Size(68, 16);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre Producto";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Articulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.panelTxt);
            this.Controls.Add(this.panelPrincipal);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Articulo";
            this.Size = new System.Drawing.Size(68, 89);
            this.Load += new System.EventHandler(this.Articulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgArticulo)).EndInit();
            this.panelPrincipal.ResumeLayout(false);
            this.panelTxt.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ToolTipPrincipal;
        private System.Windows.Forms.Panel panelPrincipal;
        public System.Windows.Forms.PictureBox imgArticulo;
        private System.Windows.Forms.Panel panelTxt;
        private System.Windows.Forms.Label lblNombre;
    }
}
