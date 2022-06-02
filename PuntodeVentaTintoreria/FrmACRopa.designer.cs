namespace PuntodeVentaTintoreria
{
    partial class FrmACRopa
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
            this.LblTipoRopa = new System.Windows.Forms.Label();
            this.pnl_nuevoColor = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnguardar = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.CmbTipoRopa = new BetterComboBox.BetterComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LblSubTipoRopa = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CmbSubTipoRopa = new BetterComboBox.BetterComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.CmbGrupo = new BetterComboBox.BetterComboBox();
            this.PanelTitulo.SuspendLayout();
            this.pnl_nuevoColor.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.LbTitulo.Size = new System.Drawing.Size(100, 20);
            this.LbTitulo.TabIndex = 3;
            this.LbTitulo.Text = "Nueva ropa";
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
            // LblTipoRopa
            // 
            this.LblTipoRopa.AutoSize = true;
            this.LblTipoRopa.BackColor = System.Drawing.Color.Transparent;
            this.LblTipoRopa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.LblTipoRopa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.LblTipoRopa.Location = new System.Drawing.Point(40, 63);
            this.LblTipoRopa.Name = "LblTipoRopa";
            this.LblTipoRopa.Size = new System.Drawing.Size(79, 13);
            this.LblTipoRopa.TabIndex = 8;
            this.LblTipoRopa.Text = "Tipo de ropa";
            this.LblTipoRopa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnl_nuevoColor
            // 
            this.pnl_nuevoColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.pnl_nuevoColor.Controls.Add(this.CmbTipoRopa);
            this.pnl_nuevoColor.Location = new System.Drawing.Point(138, 51);
            this.pnl_nuevoColor.Name = "pnl_nuevoColor";
            this.pnl_nuevoColor.Size = new System.Drawing.Size(260, 35);
            this.pnl_nuevoColor.TabIndex = 9;
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
            this.pnlBotones.Controls.Add(this.btnguardar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 211);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(451, 83);
            this.pnlBotones.TabIndex = 11;
            // 
            // btnguardar
            // 
            this.btnguardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnguardar.BackColor = System.Drawing.Color.Silver;
            this.btnguardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnguardar.ForeColor = System.Drawing.Color.Black;
            this.btnguardar.Image = global::PuntodeVentaTintoreria.Properties.Resources.icono_listo_44x44B;
            this.btnguardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnguardar.Location = new System.Drawing.Point(356, 3);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(83, 75);
            this.btnguardar.TabIndex = 32;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnguardar.UseVisualStyleBackColor = false;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // CmbTipoRopa
            // 
            this.CmbTipoRopa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.CmbTipoRopa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbTipoRopa.FormattingEnabled = true;
            this.CmbTipoRopa.Location = new System.Drawing.Point(4, 7);
            this.CmbTipoRopa.Name = "CmbTipoRopa";
            this.CmbTipoRopa.Size = new System.Drawing.Size(253, 21);
            this.CmbTipoRopa.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(118, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LblSubTipoRopa
            // 
            this.LblSubTipoRopa.AutoSize = true;
            this.LblSubTipoRopa.BackColor = System.Drawing.Color.Transparent;
            this.LblSubTipoRopa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.LblSubTipoRopa.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.LblSubTipoRopa.Location = new System.Drawing.Point(22, 116);
            this.LblSubTipoRopa.Name = "LblSubTipoRopa";
            this.LblSubTipoRopa.Size = new System.Drawing.Size(97, 13);
            this.LblSubTipoRopa.TabIndex = 12;
            this.LblSubTipoRopa.Text = "Subtipo de ropa";
            this.LblSubTipoRopa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.CmbSubTipoRopa);
            this.panel1.Location = new System.Drawing.Point(138, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(260, 35);
            this.panel1.TabIndex = 13;
            // 
            // CmbSubTipoRopa
            // 
            this.CmbSubTipoRopa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.CmbSubTipoRopa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbSubTipoRopa.FormattingEnabled = true;
            this.CmbSubTipoRopa.Location = new System.Drawing.Point(4, 7);
            this.CmbSubTipoRopa.Name = "CmbSubTipoRopa";
            this.CmbSubTipoRopa.Size = new System.Drawing.Size(253, 21);
            this.CmbSubTipoRopa.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(118, 162);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label4.Location = new System.Drawing.Point(75, 168);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Grupo";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.panel2.Controls.Add(this.CmbGrupo);
            this.panel2.Location = new System.Drawing.Point(138, 155);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(260, 35);
            this.panel2.TabIndex = 16;
            // 
            // CmbGrupo
            // 
            this.CmbGrupo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.CmbGrupo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbGrupo.FormattingEnabled = true;
            this.CmbGrupo.Location = new System.Drawing.Point(4, 7);
            this.CmbGrupo.Name = "CmbGrupo";
            this.CmbGrupo.Size = new System.Drawing.Size(253, 21);
            this.CmbGrupo.TabIndex = 0;
            // 
            // FrmACRopa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(451, 294);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LblSubTipoRopa);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LblTipoRopa);
            this.Controls.Add(this.pnl_nuevoColor);
            this.Controls.Add(this.PanelTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmACRopa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipo simbolo textil";
            this.PanelTitulo.ResumeLayout(false);
            this.PanelTitulo.PerformLayout();
            this.pnl_nuevoColor.ResumeLayout(false);
            this.pnlBotones.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelTitulo;
        public System.Windows.Forms.Label LbTitulo;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label LblTipoRopa;
        private System.Windows.Forms.Panel pnl_nuevoColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private BetterComboBox.BetterComboBox CmbTipoRopa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LblSubTipoRopa;
        private System.Windows.Forms.Panel panel1;
        private BetterComboBox.BetterComboBox CmbSubTipoRopa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private BetterComboBox.BetterComboBox CmbGrupo;
    }
}