namespace PuntodeVentaTintoreria
{
    partial class FrmACSubTipoRopa
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
            this.PanelTitulo = new System.Windows.Forms.Panel();
            this.LbTitulo = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.LblDescripcion = new System.Windows.Forms.Label();
            this.pnl_nuevoColor = new System.Windows.Forms.Panel();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.LblImage = new System.Windows.Forms.Label();
            this.ImgPrincipal = new System.Windows.Forms.PictureBox();
            this.BtnImagen = new System.Windows.Forms.Button();
            this.PanelTitulo.SuspendLayout();
            this.pnl_nuevoColor.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelTitulo
            // 
            this.PanelTitulo.AutoSize = true;
            this.PanelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.PanelTitulo.Controls.Add(this.LbTitulo);
            this.PanelTitulo.Controls.Add(this.btnMinimizar);
            this.PanelTitulo.Controls.Add(this.btnSalir);
            this.PanelTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitulo.Location = new System.Drawing.Point(0, 0);
            this.PanelTitulo.Name = "PanelTitulo";
            this.PanelTitulo.Size = new System.Drawing.Size(451, 40);
            this.PanelTitulo.TabIndex = 7;
            // 
            // LbTitulo
            // 
            this.LbTitulo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.LbTitulo.AutoSize = true;
            this.LbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTitulo.ForeColor = System.Drawing.Color.White;
            this.LbTitulo.Location = new System.Drawing.Point(8, 12);
            this.LbTitulo.Name = "LbTitulo";
            this.LbTitulo.Size = new System.Drawing.Size(199, 20);
            this.LbTitulo.TabIndex = 3;
            this.LbTitulo.Text = "Nuevo Subtipo de Ropa";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.btnMinimizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Image = global::PuntodeVentaTintoreria.Properties.Resources.top_minimizar;
            this.btnMinimizar.Location = new System.Drawing.Point(368, 6);
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
            this.btnSalir.Location = new System.Drawing.Point(406, 6);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(30, 31);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // LblDescripcion
            // 
            this.LblDescripcion.AutoSize = true;
            this.LblDescripcion.BackColor = System.Drawing.Color.Transparent;
            this.LblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.LblDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.LblDescripcion.Location = new System.Drawing.Point(47, 62);
            this.LblDescripcion.Name = "LblDescripcion";
            this.LblDescripcion.Size = new System.Drawing.Size(74, 13);
            this.LblDescripcion.TabIndex = 8;
            this.LblDescripcion.Text = "Descripción";
            this.LblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnl_nuevoColor
            // 
            this.pnl_nuevoColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.pnl_nuevoColor.Controls.Add(this.TxtDescripcion);
            this.pnl_nuevoColor.Location = new System.Drawing.Point(138, 51);
            this.pnl_nuevoColor.Name = "pnl_nuevoColor";
            this.pnl_nuevoColor.Size = new System.Drawing.Size(200, 35);
            this.pnl_nuevoColor.TabIndex = 9;
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.TxtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TxtDescripcion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.TxtDescripcion.Location = new System.Drawing.Point(10, 7);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(180, 19);
            this.TxtDescripcion.TabIndex = 12;
            this.TxtDescripcion.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtDescipcion_KeyDown);
            this.TxtDescripcion.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TxtDescipcion_MouseDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(118, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.pnlBotones.Controls.Add(this.BtnGuardar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 263);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(451, 87);
            this.pnlBotones.TabIndex = 11;
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGuardar.BackColor = System.Drawing.Color.Silver;
            this.BtnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.Color.Black;
            this.BtnGuardar.Image = global::PuntodeVentaTintoreria.Properties.Resources.icono_listo_44x44B;
            this.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnGuardar.Location = new System.Drawing.Point(356, 5);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(83, 75);
            this.BtnGuardar.TabIndex = 32;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // LblImage
            // 
            this.LblImage.AutoSize = true;
            this.LblImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.LblImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.LblImage.Location = new System.Drawing.Point(1, 235);
            this.LblImage.Name = "LblImage";
            this.LblImage.Size = new System.Drawing.Size(73, 13);
            this.LblImage.TabIndex = 188;
            this.LblImage.Text = "Default.png";
            // 
            // ImgPrincipal
            // 
            this.ImgPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.ImgPrincipal.ErrorImage = global::PuntodeVentaTintoreria.Properties.Resources.icono_productos;
            this.ImgPrincipal.Image = global::PuntodeVentaTintoreria.Properties.Resources.icono_productos;
            this.ImgPrincipal.Location = new System.Drawing.Point(191, 102);
            this.ImgPrincipal.Name = "ImgPrincipal";
            this.ImgPrincipal.Size = new System.Drawing.Size(207, 124);
            this.ImgPrincipal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImgPrincipal.TabIndex = 187;
            this.ImgPrincipal.TabStop = false;
            this.ImgPrincipal.Tag = "DEFAULT.JPG";
            // 
            // BtnImagen
            // 
            this.BtnImagen.BackColor = System.Drawing.Color.Silver;
            this.BtnImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnImagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnImagen.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BtnImagen.Location = new System.Drawing.Point(3, 132);
            this.BtnImagen.Name = "BtnImagen";
            this.BtnImagen.Size = new System.Drawing.Size(174, 43);
            this.BtnImagen.TabIndex = 186;
            this.BtnImagen.Text = "Seleccionar imagen";
            this.BtnImagen.UseVisualStyleBackColor = false;
            this.BtnImagen.Click += new System.EventHandler(this.BtnImagen_Click);
            // 
            // FrmACSubTipoRopa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(451, 350);
            this.Controls.Add(this.LblImage);
            this.Controls.Add(this.ImgPrincipal);
            this.Controls.Add(this.BtnImagen);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblDescripcion);
            this.Controls.Add(this.pnl_nuevoColor);
            this.Controls.Add(this.PanelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmACSubTipoRopa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sub tipo de ropa";
            this.PanelTitulo.ResumeLayout(false);
            this.PanelTitulo.PerformLayout();
            this.pnl_nuevoColor.ResumeLayout(false);
            this.pnl_nuevoColor.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImgPrincipal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelTitulo;
        public System.Windows.Forms.Label LbTitulo;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label LblDescripcion;
        private System.Windows.Forms.Panel pnl_nuevoColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label LblImage;
        private System.Windows.Forms.PictureBox ImgPrincipal;
        private System.Windows.Forms.Button BtnImagen;
    }
}