namespace vsoccer
{
    partial class gestoralumnos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gestoralumnos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.paneltitulo = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnMax = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.logo = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgDatosAlumnos = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chtCalificaciones = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelOpciones = new System.Windows.Forms.Panel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnCuenta = new System.Windows.Forms.Button();
            this.cbCategorias = new System.Windows.Forms.ComboBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCerrarsesion = new System.Windows.Forms.Button();
            this.paneltitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDatosAlumnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtCalificaciones)).BeginInit();
            this.panelOpciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // paneltitulo
            // 
            this.paneltitulo.AutoSize = true;
            this.paneltitulo.BackColor = System.Drawing.Color.DarkMagenta;
            this.paneltitulo.Controls.Add(this.btnCerrar);
            this.paneltitulo.Controls.Add(this.btnMax);
            this.paneltitulo.Controls.Add(this.btnMin);
            this.paneltitulo.Controls.Add(this.logo);
            this.paneltitulo.Controls.Add(this.lblTitulo);
            this.paneltitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.paneltitulo.Location = new System.Drawing.Point(0, 0);
            this.paneltitulo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.paneltitulo.Name = "paneltitulo";
            this.paneltitulo.Size = new System.Drawing.Size(1924, 146);
            this.paneltitulo.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(101)))), ((int)(((byte)(113)))));
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(3)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(1871, 2);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(51, 55);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnMax
            // 
            this.btnMax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMax.FlatAppearance.BorderSize = 0;
            this.btnMax.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(225)))), ((int)(((byte)(230)))));
            this.btnMax.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMax.Image = ((System.Drawing.Image)(resources.GetObject("btnMax.Image")));
            this.btnMax.Location = new System.Drawing.Point(1821, 2);
            this.btnMax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(51, 55);
            this.btnMax.TabIndex = 4;
            this.btnMax.UseVisualStyleBackColor = true;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // btnMin
            // 
            this.btnMin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(225)))), ((int)(((byte)(230)))));
            this.btnMin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Image = ((System.Drawing.Image)(resources.GetObject("btnMin.Image")));
            this.btnMin.Location = new System.Drawing.Point(1771, 2);
            this.btnMin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(51, 55);
            this.btnMin.TabIndex = 3;
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // logo
            // 
            this.logo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.logo.Image = ((System.Drawing.Image)(resources.GetObject("logo.Image")));
            this.logo.Location = new System.Drawing.Point(23, 14);
            this.logo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(187, 130);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 1;
            this.logo.TabStop = false;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(616, 44);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(726, 80);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "GESTOR DE ALUMNOS";
            // 
            // dgDatosAlumnos
            // 
            this.dgDatosAlumnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgDatosAlumnos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgDatosAlumnos.BackgroundColor = System.Drawing.Color.MediumOrchid;
            this.dgDatosAlumnos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgDatosAlumnos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.DarkMagenta;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DarkMagenta;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDatosAlumnos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgDatosAlumnos.ColumnHeadersHeight = 38;
            this.dgDatosAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgDatosAlumnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgDatosAlumnos.EnableHeadersVisualStyles = false;
            this.dgDatosAlumnos.GridColor = System.Drawing.Color.DarkViolet;
            this.dgDatosAlumnos.Location = new System.Drawing.Point(61, 434);
            this.dgDatosAlumnos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgDatosAlumnos.Name = "dgDatosAlumnos";
            this.dgDatosAlumnos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Violet;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Plum;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDatosAlumnos.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgDatosAlumnos.RowHeadersVisible = false;
            this.dgDatosAlumnos.RowHeadersWidth = 51;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.DarkOrchid;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Plum;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            this.dgDatosAlumnos.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.dgDatosAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDatosAlumnos.Size = new System.Drawing.Size(1053, 486);
            this.dgDatosAlumnos.TabIndex = 2;
            this.dgDatosAlumnos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDatosAlumnos_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 56;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Nombre del alumno";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 199;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Categoria";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 118;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Fecha de nacimiento";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 211;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Tutor";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 81;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Telefono";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 109;
            // 
            // chtCalificaciones
            // 
            this.chtCalificaciones.BackColor = System.Drawing.Color.MediumOrchid;
            this.chtCalificaciones.BorderlineColor = System.Drawing.Color.Orchid;
            this.chtCalificaciones.BorderlineWidth = 0;
            chartArea3.Name = "ChartArea1";
            this.chtCalificaciones.ChartAreas.Add(chartArea3);
            legend3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend3.IsTextAutoFit = false;
            legend3.Name = "Legend1";
            this.chtCalificaciones.Legends.Add(legend3);
            this.chtCalificaciones.Location = new System.Drawing.Point(1301, 434);
            this.chtCalificaciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chtCalificaciones.Name = "chtCalificaciones";
            this.chtCalificaciones.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.chtCalificaciones.Series.Add(series3);
            this.chtCalificaciones.Size = new System.Drawing.Size(519, 486);
            this.chtCalificaciones.TabIndex = 3;
            this.chtCalificaciones.Text = "chart1";
            this.chtCalificaciones.Click += new System.EventHandler(this.chtCalificaciones_Click);
            // 
            // panelOpciones
            // 
            this.panelOpciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelOpciones.BackColor = System.Drawing.Color.MediumOrchid;
            this.panelOpciones.Controls.Add(this.btnAgregar);
            this.panelOpciones.Controls.Add(this.btnEliminar);
            this.panelOpciones.Controls.Add(this.btnEditar);
            this.panelOpciones.Controls.Add(this.btnCuenta);
            this.panelOpciones.Location = new System.Drawing.Point(0, 144);
            this.panelOpciones.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelOpciones.Name = "panelOpciones";
            this.panelOpciones.Size = new System.Drawing.Size(1924, 156);
            this.panelOpciones.TabIndex = 4;
            // 
            // btnAgregar
            // 
            this.btnAgregar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAgregar.FlatAppearance.BorderSize = 2;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(431, 32);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(255, 90);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "    Agregar ";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEliminar.FlatAppearance.BorderSize = 2;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(1247, 32);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(255, 90);
            this.btnEliminar.TabIndex = 0;
            this.btnEliminar.Text = "     Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEditar.FlatAppearance.BorderSize = 2;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(841, 32);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(255, 90);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "    Editar ";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnCuenta
            // 
            this.btnCuenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCuenta.FlatAppearance.BorderSize = 0;
            this.btnCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCuenta.Font = new System.Drawing.Font("Microsoft YaHei", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCuenta.Image = ((System.Drawing.Image)(resources.GetObject("btnCuenta.Image")));
            this.btnCuenta.Location = new System.Drawing.Point(1821, 16);
            this.btnCuenta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCuenta.Name = "btnCuenta";
            this.btnCuenta.Size = new System.Drawing.Size(93, 106);
            this.btnCuenta.TabIndex = 2;
            this.btnCuenta.Text = " Cuenta";
            this.btnCuenta.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCuenta.UseVisualStyleBackColor = true;
            // 
            // cbCategorias
            // 
            this.cbCategorias.BackColor = System.Drawing.Color.White;
            this.cbCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategorias.FormattingEnabled = true;
            this.cbCategorias.Items.AddRange(new object[] {
            "MINI Lunes y Miercoles",
            "MINI Martes y Jueves",
            "MENOR Lunes y Miercoles",
            "MENOR Martes y Jueves",
            "MAYOR Lunes y Miercoles",
            "MAYOR Martes y Jueves"});
            this.cbCategorias.Location = new System.Drawing.Point(61, 364);
            this.cbCategorias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCategorias.Name = "cbCategorias";
            this.cbCategorias.Size = new System.Drawing.Size(277, 28);
            this.cbCategorias.TabIndex = 5;
            this.cbCategorias.Text = "CATEGORIAS";
            // 
            // btnImprimir
            // 
            this.btnImprimir.AutoSize = true;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(369, 359);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(59, 44);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.UseVisualStyleBackColor = true;
            // 
            // btnCerrarsesion
            // 
            this.btnCerrarsesion.AutoSize = true;
            this.btnCerrarsesion.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCerrarsesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarsesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarsesion.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarsesion.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarsesion.Image")));
            this.btnCerrarsesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarsesion.Location = new System.Drawing.Point(1847, 949);
            this.btnCerrarsesion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCerrarsesion.Name = "btnCerrarsesion";
            this.btnCerrarsesion.Size = new System.Drawing.Size(68, 69);
            this.btnCerrarsesion.TabIndex = 6;
            this.btnCerrarsesion.UseVisualStyleBackColor = true;
            // 
            // gestoralumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumOrchid;
            this.ClientSize = new System.Drawing.Size(1924, 1033);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCerrarsesion);
            this.Controls.Add(this.cbCategorias);
            this.Controls.Add(this.panelOpciones);
            this.Controls.Add(this.chtCalificaciones);
            this.Controls.Add(this.dgDatosAlumnos);
            this.Controls.Add(this.paneltitulo);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "gestoralumnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.gestoralumnos_Load);
            this.paneltitulo.ResumeLayout(false);
            this.paneltitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDatosAlumnos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtCalificaciones)).EndInit();
            this.panelOpciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel paneltitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dgDatosAlumnos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtCalificaciones;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Panel panelOpciones;
        private System.Windows.Forms.ComboBox cbCategorias;
        private System.Windows.Forms.Button btnCerrarsesion;
        private System.Windows.Forms.Button btnCuenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.Button btnMin;
    }
}

