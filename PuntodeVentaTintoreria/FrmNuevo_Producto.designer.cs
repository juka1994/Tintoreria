namespace PuntodeVentaTintoreria
{
    partial class FrmNuevo_Producto
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMinimizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.LblImage = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.cmb_unidadmedida = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cmb_familia = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmb_proveedor = new System.Windows.Forms.ComboBox();
            this.pnl_Stockmin = new System.Windows.Forms.Panel();
            this.txt_stockminimo = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblCorreoSistema = new System.Windows.Forms.Label();
            this.pnl_nombre = new System.Windows.Forms.Panel();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_imagen = new System.Windows.Forms.Button();
            this.pnlBotones = new System.Windows.Forms.Panel();
            this.btnguardar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_observaciones = new System.Windows.Forms.TextBox();
            this.ImgPrincipal = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.PanelTitulo.SuspendLayout();
            this.pnl_Stockmin.SuspendLayout();
            this.pnl_nombre.SuspendLayout();
            this.pnlBotones.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgPrincipal)).BeginInit();
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
            this.PanelTitulo.Size = new System.Drawing.Size(836, 47);
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
            this.lblTitulo.Size = new System.Drawing.Size(136, 20);
            this.lblTitulo.TabIndex = 3;
            this.lblTitulo.Text = "Nuevo Producto";
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMinimizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(139)))), ((int)(((byte)(154)))));
            this.btnMinimizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnMinimizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizar.ForeColor = System.Drawing.Color.White;
            this.btnMinimizar.Image = global::PuntodeVentaTintoreria.Properties.Resources.top_minimizar;
            this.btnMinimizar.Location = new System.Drawing.Point(753, 9);
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
            this.btnSalir.Location = new System.Drawing.Point(791, 9);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(30, 31);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label25.Location = new System.Drawing.Point(38, 214);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(111, 13);
            this.label25.TabIndex = 165;
            this.label25.Text = "OBSERVACIONES";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblImage
            // 
            this.LblImage.AutoSize = true;
            this.LblImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold);
            this.LblImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.LblImage.Location = new System.Drawing.Point(567, 314);
            this.LblImage.Name = "LblImage";
            this.LblImage.Size = new System.Drawing.Size(73, 13);
            this.LblImage.TabIndex = 164;
            this.LblImage.Text = "Default.png";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label21.Location = new System.Drawing.Point(38, 146);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(128, 13);
            this.label21.TabIndex = 160;
            this.label21.Text = "UNIDAD DE MEDIDA";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmb_unidadmedida
            // 
            this.cmb_unidadmedida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.cmb_unidadmedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_unidadmedida.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.cmb_unidadmedida.FormattingEnabled = true;
            this.cmb_unidadmedida.Location = new System.Drawing.Point(41, 164);
            this.cmb_unidadmedida.Name = "cmb_unidadmedida";
            this.cmb_unidadmedida.Size = new System.Drawing.Size(200, 28);
            this.cmb_unidadmedida.TabIndex = 137;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(164, 145);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(14, 17);
            this.label22.TabIndex = 159;
            this.label22.Text = "*";
            this.label22.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label15.Location = new System.Drawing.Point(299, 67);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(140, 13);
            this.label15.TabIndex = 158;
            this.label15.Text = "FAMILIA / CATEGORIA";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmb_familia
            // 
            this.cmb_familia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.cmb_familia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_familia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.cmb_familia.FormattingEnabled = true;
            this.cmb_familia.Location = new System.Drawing.Point(302, 87);
            this.cmb_familia.Name = "cmb_familia";
            this.cmb_familia.Size = new System.Drawing.Size(200, 28);
            this.cmb_familia.TabIndex = 136;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(445, 67);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(14, 17);
            this.label20.TabIndex = 157;
            this.label20.Text = "*";
            this.label20.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label14.Location = new System.Drawing.Point(299, 145);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 13);
            this.label14.TabIndex = 156;
            this.label14.Text = "PROVEEDOR";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmb_proveedor
            // 
            this.cmb_proveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.cmb_proveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_proveedor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.cmb_proveedor.FormattingEnabled = true;
            this.cmb_proveedor.Location = new System.Drawing.Point(302, 163);
            this.cmb_proveedor.Name = "cmb_proveedor";
            this.cmb_proveedor.Size = new System.Drawing.Size(200, 28);
            this.cmb_proveedor.TabIndex = 135;
            // 
            // pnl_Stockmin
            // 
            this.pnl_Stockmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.pnl_Stockmin.Controls.Add(this.txt_stockminimo);
            this.pnl_Stockmin.Location = new System.Drawing.Point(570, 86);
            this.pnl_Stockmin.Name = "pnl_Stockmin";
            this.pnl_Stockmin.Size = new System.Drawing.Size(200, 35);
            this.pnl_Stockmin.TabIndex = 133;
            // 
            // txt_stockminimo
            // 
            this.txt_stockminimo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.txt_stockminimo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_stockminimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_stockminimo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txt_stockminimo.Location = new System.Drawing.Point(5, 9);
            this.txt_stockminimo.Name = "txt_stockminimo";
            this.txt_stockminimo.Size = new System.Drawing.Size(180, 19);
            this.txt_stockminimo.TabIndex = 173;
            this.txt_stockminimo.Text = "0";
            this.txt_stockminimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_stockminimo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_stockminimo_KeyDown);
            this.txt_stockminimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_stockminimo_KeyPress);
            this.txt_stockminimo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_stockminimo_MouseDown);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(667, 67);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(14, 17);
            this.label18.TabIndex = 150;
            this.label18.Text = "*";
            this.label18.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.label19.Location = new System.Drawing.Point(567, 68);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(98, 13);
            this.label19.TabIndex = 151;
            this.label19.Text = "STOCK MÍNIMO";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCorreoSistema
            // 
            this.lblCorreoSistema.AutoSize = true;
            this.lblCorreoSistema.BackColor = System.Drawing.Color.Transparent;
            this.lblCorreoSistema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblCorreoSistema.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorreoSistema.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.lblCorreoSistema.Location = new System.Drawing.Point(31, 66);
            this.lblCorreoSistema.Name = "lblCorreoSistema";
            this.lblCorreoSistema.Size = new System.Drawing.Size(60, 13);
            this.lblCorreoSistema.TabIndex = 139;
            this.lblCorreoSistema.Text = "NOMBRE";
            this.lblCorreoSistema.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnl_nombre
            // 
            this.pnl_nombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.pnl_nombre.Controls.Add(this.txt_nombre);
            this.pnl_nombre.Location = new System.Drawing.Point(34, 84);
            this.pnl_nombre.Name = "pnl_nombre";
            this.pnl_nombre.Size = new System.Drawing.Size(200, 35);
            this.pnl_nombre.TabIndex = 128;
            // 
            // txt_nombre
            // 
            this.txt_nombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.txt_nombre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_nombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txt_nombre.Location = new System.Drawing.Point(7, 7);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(180, 19);
            this.txt_nombre.TabIndex = 171;
            this.txt_nombre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_nombre_KeyDown);
            this.txt_nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_nombre_KeyPress);
            this.txt_nombre.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_nombre_MouseDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(88, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 17);
            this.label5.TabIndex = 138;
            this.label5.Text = "*";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(389, 144);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 17);
            this.label9.TabIndex = 155;
            this.label9.Text = "*";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_imagen
            // 
            this.btn_imagen.BackColor = System.Drawing.Color.Silver;
            this.btn_imagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_imagen.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_imagen.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_imagen.Location = new System.Drawing.Point(570, 155);
            this.btn_imagen.Name = "btn_imagen";
            this.btn_imagen.Size = new System.Drawing.Size(174, 43);
            this.btn_imagen.TabIndex = 176;
            this.btn_imagen.Text = "Seleccionar imagen";
            this.btn_imagen.UseVisualStyleBackColor = false;
            this.btn_imagen.Click += new System.EventHandler(this.btn_imagen_Click);
            // 
            // pnlBotones
            // 
            this.pnlBotones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.pnlBotones.Controls.Add(this.btnguardar);
            this.pnlBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBotones.Location = new System.Drawing.Point(0, 343);
            this.pnlBotones.Name = "pnlBotones";
            this.pnlBotones.Size = new System.Drawing.Size(836, 87);
            this.pnlBotones.TabIndex = 177;
            // 
            // btnguardar
            // 
            this.btnguardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnguardar.BackColor = System.Drawing.Color.Silver;
            this.btnguardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnguardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.btnguardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnguardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnguardar.ForeColor = System.Drawing.Color.Black;
            this.btnguardar.Image = global::PuntodeVentaTintoreria.Properties.Resources.icono_listo_44x44B;
            this.btnguardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnguardar.Location = new System.Drawing.Point(741, 4);
            this.btnguardar.Name = "btnguardar";
            this.btnguardar.Size = new System.Drawing.Size(83, 75);
            this.btnguardar.TabIndex = 32;
            this.btnguardar.Text = "Guardar";
            this.btnguardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnguardar.UseVisualStyleBackColor = false;
            this.btnguardar.Click += new System.EventHandler(this.btnguardar_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(227)))), ((int)(((byte)(230)))));
            this.panel1.Controls.Add(this.txt_observaciones);
            this.panel1.Location = new System.Drawing.Point(34, 230);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 97);
            this.panel1.TabIndex = 178;
            // 
            // txt_observaciones
            // 
            this.txt_observaciones.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.txt_observaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_observaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_observaciones.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.txt_observaciones.Location = new System.Drawing.Point(7, 7);
            this.txt_observaciones.Multiline = true;
            this.txt_observaciones.Name = "txt_observaciones";
            this.txt_observaciones.Size = new System.Drawing.Size(362, 74);
            this.txt_observaciones.TabIndex = 171;
            this.txt_observaciones.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_observaciones_KeyDown);
            this.txt_observaciones.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_observaciones_KeyPress);
            this.txt_observaciones.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_observaciones_MouseDown);
            // 
            // ImgPrincipal
            // 
            this.ImgPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.ImgPrincipal.Image = global::PuntodeVentaTintoreria.Properties.Resources.icono_productos;
            this.ImgPrincipal.Location = new System.Drawing.Point(611, 204);
            this.ImgPrincipal.Name = "ImgPrincipal";
            this.ImgPrincipal.Size = new System.Drawing.Size(102, 107);
            this.ImgPrincipal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImgPrincipal.TabIndex = 163;
            this.ImgPrincipal.TabStop = false;
            this.ImgPrincipal.Tag = "DEFAULT.JPG";
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
            // FrmNuevo_Producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(836, 430);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlBotones);
            this.Controls.Add(this.btn_imagen);
            this.Controls.Add(this.PanelTitulo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.LblImage);
            this.Controls.Add(this.ImgPrincipal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pnl_nombre);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.lblCorreoSistema);
            this.Controls.Add(this.cmb_unidadmedida);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cmb_familia);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmb_proveedor);
            this.Controls.Add(this.pnl_Stockmin);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmNuevo_Producto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmNuevo_Producto";
            this.Load += new System.EventHandler(this.FrmNuevo_Producto_Load);
            this.PanelTitulo.ResumeLayout(false);
            this.PanelTitulo.PerformLayout();
            this.pnl_Stockmin.ResumeLayout(false);
            this.pnl_Stockmin.PerformLayout();
            this.pnl_nombre.ResumeLayout(false);
            this.pnl_nombre.PerformLayout();
            this.pnlBotones.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgPrincipal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelTitulo;
        public System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnMinimizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label LblImage;
        private System.Windows.Forms.PictureBox ImgPrincipal;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cmb_unidadmedida;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cmb_familia;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cmb_proveedor;
        private System.Windows.Forms.Panel pnl_Stockmin;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblCorreoSistema;
        private System.Windows.Forms.Panel pnl_nombre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.TextBox txt_stockminimo;
        private System.Windows.Forms.Button btn_imagen;
        private System.Windows.Forms.Panel pnlBotones;
        private System.Windows.Forms.Button btnguardar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_observaciones;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
    }
}