namespace vsoccer
{
    partial class iniciodesesion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(iniciodesesion));
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.lnkOlvide = new System.Windows.Forms.LinkLabel();
            this.panellogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtContraseña = new vsoccer.RJTextBox();
            this.txtUsuario = new vsoccer.RJTextBox();
            this.btnVercontraseña = new System.Windows.Forms.Button();
            this.panellogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.ForeColor = System.Drawing.SystemColors.Control;
            this.lblDescripcion.Location = new System.Drawing.Point(306, 215);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(417, 36);
            this.lblDescripcion.TabIndex = 1;
            this.lblDescripcion.Text = "Gestor de Academia de Fútbol";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.SystemColors.Control;
            this.lblUsuario.Location = new System.Drawing.Point(354, 341);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(67, 18);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblContrasena
            // 
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasena.ForeColor = System.Drawing.SystemColors.Control;
            this.lblContrasena.Location = new System.Drawing.Point(354, 445);
            this.lblContrasena.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(95, 18);
            this.lblContrasena.TabIndex = 3;
            this.lblContrasena.Text = "Contraseña";
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarSesion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnIniciarSesion.Location = new System.Drawing.Point(400, 555);
            this.btnIniciarSesion.Margin = new System.Windows.Forms.Padding(4);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(193, 37);
            this.btnIniciarSesion.TabIndex = 4;
            this.btnIniciarSesion.Text = "Iniciar Sesión";
            this.btnIniciarSesion.UseVisualStyleBackColor = true;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // lnkOlvide
            // 
            this.lnkOlvide.AutoSize = true;
            this.lnkOlvide.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkOlvide.ForeColor = System.Drawing.Color.LawnGreen;
            this.lnkOlvide.LinkColor = System.Drawing.Color.Lime;
            this.lnkOlvide.Location = new System.Drawing.Point(421, 509);
            this.lnkOlvide.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkOlvide.Name = "lnkOlvide";
            this.lnkOlvide.Size = new System.Drawing.Size(147, 20);
            this.lnkOlvide.TabIndex = 5;
            this.lnkOlvide.TabStop = true;
            this.lnkOlvide.Text = "Olvidé Contraseña";
            // 
            // panellogo
            // 
            this.panellogo.Controls.Add(this.pictureBox1);
            this.panellogo.Controls.Add(this.lblDescripcion);
            this.panellogo.Location = new System.Drawing.Point(1, 1);
            this.panellogo.Name = "panellogo";
            this.panellogo.Size = new System.Drawing.Size(990, 265);
            this.panellogo.TabIndex = 11;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::vsoccer.Properties.Resources.image_removebg_preview__7___2_;
            this.pictureBox1.Location = new System.Drawing.Point(384, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(257, 173);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(303, 424);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(37, 51);
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(296, 321);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(54, 55);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // txtContraseña
            // 
            this.txtContraseña.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(19)))), ((int)(((byte)(33)))));
            this.txtContraseña.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtContraseña.BorderSize = 2;
            this.txtContraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.ForeColor = System.Drawing.Color.White;
            this.txtContraseña.Location = new System.Drawing.Point(474, 439);
            this.txtContraseña.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Padding = new System.Windows.Forms.Padding(7);
            this.txtContraseña.PasswordChar = false;
            this.txtContraseña.Size = new System.Drawing.Size(250, 40);
            this.txtContraseña.TabIndex = 13;
            this.txtContraseña.Texts = "";
            this.txtContraseña.UnderlineStyle = true;
            // 
            // txtUsuario
            // 
            this.txtUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(19)))), ((int)(((byte)(33)))));
            this.txtUsuario.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.txtUsuario.BorderSize = 2;
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.ForeColor = System.Drawing.Color.White;
            this.txtUsuario.Location = new System.Drawing.Point(474, 330);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Padding = new System.Windows.Forms.Padding(7);
            this.txtUsuario.PasswordChar = false;
            this.txtUsuario.Size = new System.Drawing.Size(250, 40);
            this.txtUsuario.TabIndex = 12;
            this.txtUsuario.Texts = "";
            this.txtUsuario.UnderlineStyle = true;
            // 
            // btnVercontraseña
            // 
            this.btnVercontraseña.FlatAppearance.BorderSize = 0;
            this.btnVercontraseña.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVercontraseña.ForeColor = System.Drawing.Color.Transparent;
            this.btnVercontraseña.Image = ((System.Drawing.Image)(resources.GetObject("btnVercontraseña.Image")));
            this.btnVercontraseña.Location = new System.Drawing.Point(730, 460);
            this.btnVercontraseña.Name = "btnVercontraseña";
            this.btnVercontraseña.Size = new System.Drawing.Size(45, 25);
            this.btnVercontraseña.TabIndex = 14;
            this.btnVercontraseña.UseVisualStyleBackColor = true;
            // 
            // iniciodesesion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(19)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(987, 726);
            this.Controls.Add(this.btnVercontraseña);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.panellogo);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.lnkOlvide);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnIniciarSesion);
            this.Controls.Add(this.lblContrasena);
            this.Controls.Add(this.lblUsuario);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "iniciodesesion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iniciodesesion";
            this.panellogo.ResumeLayout(false);
            this.panellogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.LinkLabel lnkOlvide;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panellogo;
        private RJTextBox txtUsuario;
        private RJTextBox txtContraseña;
        private System.Windows.Forms.Button btnVercontraseña;
    }
}