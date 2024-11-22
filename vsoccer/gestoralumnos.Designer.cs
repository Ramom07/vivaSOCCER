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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gestoralumnos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.paneltitulo = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnMax = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.logo = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dgDatosAlumnos = new System.Windows.Forms.DataGridView();
            this.Apellido1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chtCalificaciones = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelOpciones = new System.Windows.Forms.Panel();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.cbCategorias = new System.Windows.Forms.ComboBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCerrarsesion = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.txtCalificacion1 = new System.Windows.Forms.TextBox();
            this.txtCalificacion2 = new System.Windows.Forms.TextBox();
            this.txtCalificacion3 = new System.Windows.Forms.TextBox();
            this.txtCalificacion4 = new System.Windows.Forms.TextBox();
            this.btnGuardarCalificaciones = new System.Windows.Forms.Button();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaNacDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tutorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alumnoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paneltitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDatosAlumnos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chtCalificaciones)).BeginInit();
            this.panelOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alumnoBindingSource)).BeginInit();
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
            this.paneltitulo.Margin = new System.Windows.Forms.Padding(4);
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
            this.dgDatosAlumnos.AutoGenerateColumns = false;
            this.dgDatosAlumnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgDatosAlumnos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgDatosAlumnos.BackgroundColor = System.Drawing.Color.MediumOrchid;
            this.dgDatosAlumnos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgDatosAlumnos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.DarkMagenta;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.DarkMagenta;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDatosAlumnos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dgDatosAlumnos.ColumnHeadersHeight = 38;
            this.dgDatosAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgDatosAlumnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.Apellido1,
            this.Apellido2,
            this.categoriaDataGridViewTextBoxColumn,
            this.fechaNacDataGridViewTextBoxColumn,
            this.tutorDataGridViewTextBoxColumn});
            this.dgDatosAlumnos.DataSource = this.alumnoBindingSource;
            this.dgDatosAlumnos.EnableHeadersVisualStyles = false;
            this.dgDatosAlumnos.GridColor = System.Drawing.Color.DarkViolet;
            this.dgDatosAlumnos.Location = new System.Drawing.Point(61, 434);
            this.dgDatosAlumnos.Margin = new System.Windows.Forms.Padding(4);
            this.dgDatosAlumnos.Name = "dgDatosAlumnos";
            this.dgDatosAlumnos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.Violet;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.Plum;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgDatosAlumnos.RowHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgDatosAlumnos.RowHeadersVisible = false;
            this.dgDatosAlumnos.RowHeadersWidth = 51;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.DarkOrchid;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Century Gothic", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.Plum;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.Color.White;
            this.dgDatosAlumnos.RowsDefaultCellStyle = dataGridViewCellStyle18;
            this.dgDatosAlumnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgDatosAlumnos.Size = new System.Drawing.Size(1220, 486);
            this.dgDatosAlumnos.TabIndex = 2;
            this.dgDatosAlumnos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDatosAlumnos_CellClick);
            this.dgDatosAlumnos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDatosAlumnos_CellContentClick);
            this.dgDatosAlumnos.SelectionChanged += new System.EventHandler(this.dgDatosAlumnos_SelectionChanged);
            // 
            // Apellido1
            // 
            this.Apellido1.DataPropertyName = "Apellido1";
            this.Apellido1.HeaderText = "Apellido1";
            this.Apellido1.MinimumWidth = 6;
            this.Apellido1.Name = "Apellido1";
            this.Apellido1.Width = 114;
            // 
            // Apellido2
            // 
            this.Apellido2.DataPropertyName = "Apellido2";
            this.Apellido2.HeaderText = "Apellido2";
            this.Apellido2.MinimumWidth = 6;
            this.Apellido2.Name = "Apellido2";
            this.Apellido2.Width = 114;
            // 
            // chtCalificaciones
            // 
            this.chtCalificaciones.BackColor = System.Drawing.Color.MediumOrchid;
            this.chtCalificaciones.BorderlineColor = System.Drawing.Color.Orchid;
            this.chtCalificaciones.BorderlineWidth = 0;
            chartArea6.Name = "ChartArea1";
            this.chtCalificaciones.ChartAreas.Add(chartArea6);
            legend6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend6.IsTextAutoFit = false;
            legend6.Name = "Legend1";
            this.chtCalificaciones.Legends.Add(legend6);
            this.chtCalificaciones.Location = new System.Drawing.Point(1247, 389);
            this.chtCalificaciones.Margin = new System.Windows.Forms.Padding(4);
            this.chtCalificaciones.Name = "chtCalificaciones";
            this.chtCalificaciones.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "PROMEDIO";
            this.chtCalificaciones.Series.Add(series6);
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
            this.panelOpciones.Location = new System.Drawing.Point(0, 144);
            this.panelOpciones.Margin = new System.Windows.Forms.Padding(4);
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
            this.btnAgregar.ForeColor = System.Drawing.Color.White;
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(431, 32);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(255, 90);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.Text = "    Agregar ";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEliminar.FlatAppearance.BorderSize = 2;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(1247, 32);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(255, 90);
            this.btnEliminar.TabIndex = 0;
            this.btnEliminar.Text = "     Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEditar.FlatAppearance.BorderSize = 2;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Microsoft YaHei", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(841, 32);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(255, 90);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "    Editar ";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // cbCategorias
            // 
            this.cbCategorias.BackColor = System.Drawing.Color.White;
            this.cbCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategorias.FormattingEnabled = true;
            this.cbCategorias.Location = new System.Drawing.Point(61, 364);
            this.cbCategorias.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCategorias.Name = "cbCategorias";
            this.cbCategorias.Size = new System.Drawing.Size(277, 28);
            this.cbCategorias.TabIndex = 5;
            this.cbCategorias.Text = "CATEGORÍAS";
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
            this.btnCerrarsesion.Click += new System.EventHandler(this.btnCerrarsesion_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(464, 355);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(125, 47);
            this.btnActualizar.TabIndex = 7;
            this.btnActualizar.Text = "Actualizar Registros";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // txtCalificacion1
            // 
            this.txtCalificacion1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalificacion1.Location = new System.Drawing.Point(1632, 559);
            this.txtCalificacion1.Name = "txtCalificacion1";
            this.txtCalificacion1.Size = new System.Drawing.Size(59, 28);
            this.txtCalificacion1.TabIndex = 8;
            this.txtCalificacion1.TextChanged += new System.EventHandler(this.txtCalificacion1_TextChanged);
            this.txtCalificacion1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCalificacion1_KeyPress);
            // 
            // txtCalificacion2
            // 
            this.txtCalificacion2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalificacion2.Location = new System.Drawing.Point(1632, 598);
            this.txtCalificacion2.Name = "txtCalificacion2";
            this.txtCalificacion2.Size = new System.Drawing.Size(59, 28);
            this.txtCalificacion2.TabIndex = 9;
            this.txtCalificacion2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCalificacion2_KeyPress);
            // 
            // txtCalificacion3
            // 
            this.txtCalificacion3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalificacion3.Location = new System.Drawing.Point(1632, 640);
            this.txtCalificacion3.Name = "txtCalificacion3";
            this.txtCalificacion3.Size = new System.Drawing.Size(59, 28);
            this.txtCalificacion3.TabIndex = 10;
            this.txtCalificacion3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCalificacion3_KeyPress);
            // 
            // txtCalificacion4
            // 
            this.txtCalificacion4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalificacion4.Location = new System.Drawing.Point(1632, 682);
            this.txtCalificacion4.Name = "txtCalificacion4";
            this.txtCalificacion4.Size = new System.Drawing.Size(59, 28);
            this.txtCalificacion4.TabIndex = 11;
            this.txtCalificacion4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCalificacion4_KeyPress);
            // 
            // btnGuardarCalificaciones
            // 
            this.btnGuardarCalificaciones.Location = new System.Drawing.Point(1632, 753);
            this.btnGuardarCalificaciones.Name = "btnGuardarCalificaciones";
            this.btnGuardarCalificaciones.Size = new System.Drawing.Size(75, 23);
            this.btnGuardarCalificaciones.TabIndex = 12;
            this.btnGuardarCalificaciones.Text = "button1";
            this.btnGuardarCalificaciones.UseVisualStyleBackColor = true;
            this.btnGuardarCalificaciones.Click += new System.EventHandler(this.btnGuardarCalificaciones_Click);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Width = 52;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.Width = 102;
            // 
            // categoriaDataGridViewTextBoxColumn
            // 
            this.categoriaDataGridViewTextBoxColumn.DataPropertyName = "Categoria";
            this.categoriaDataGridViewTextBoxColumn.HeaderText = "Categoria";
            this.categoriaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.categoriaDataGridViewTextBoxColumn.Name = "categoriaDataGridViewTextBoxColumn";
            this.categoriaDataGridViewTextBoxColumn.Width = 118;
            // 
            // fechaNacDataGridViewTextBoxColumn
            // 
            this.fechaNacDataGridViewTextBoxColumn.DataPropertyName = "FechaNac";
            this.fechaNacDataGridViewTextBoxColumn.HeaderText = "FechaNac";
            this.fechaNacDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fechaNacDataGridViewTextBoxColumn.Name = "fechaNacDataGridViewTextBoxColumn";
            this.fechaNacDataGridViewTextBoxColumn.Width = 121;
            // 
            // tutorDataGridViewTextBoxColumn
            // 
            this.tutorDataGridViewTextBoxColumn.DataPropertyName = "Tutor";
            this.tutorDataGridViewTextBoxColumn.HeaderText = "Tutor";
            this.tutorDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tutorDataGridViewTextBoxColumn.Name = "tutorDataGridViewTextBoxColumn";
            this.tutorDataGridViewTextBoxColumn.Width = 81;
            // 
            // alumnoBindingSource
            // 
            this.alumnoBindingSource.DataSource = typeof(vsoccer.Alumno);
            // 
            // gestoralumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumOrchid;
            this.ClientSize = new System.Drawing.Size(1924, 1033);
            this.Controls.Add(this.btnGuardarCalificaciones);
            this.Controls.Add(this.txtCalificacion4);
            this.Controls.Add(this.txtCalificacion3);
            this.Controls.Add(this.txtCalificacion2);
            this.Controls.Add(this.txtCalificacion1);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCerrarsesion);
            this.Controls.Add(this.cbCategorias);
            this.Controls.Add(this.panelOpciones);
            this.Controls.Add(this.chtCalificaciones);
            this.Controls.Add(this.dgDatosAlumnos);
            this.Controls.Add(this.paneltitulo);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
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
            ((System.ComponentModel.ISupportInitialize)(this.alumnoBindingSource)).EndInit();
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
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.BindingSource alumnoBindingSource;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido2;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaNacDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tutorDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox txtCalificacion1;
        private System.Windows.Forms.TextBox txtCalificacion2;
        private System.Windows.Forms.TextBox txtCalificacion3;
        private System.Windows.Forms.TextBox txtCalificacion4;
        private System.Windows.Forms.Button btnGuardarCalificaciones;
    }
}

