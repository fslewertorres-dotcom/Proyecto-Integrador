namespace EcoResiduos.Presentation
{
    partial class FrContenedores
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlEncabezado = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            pnlTabla = new Panel();
            lblTablaTitulo = new Label();
            dgvContenedores = new DataGridView();
            pnlFormulario = new Panel();
            lblFormTitulo = new Label();
            lblId = new Label();
            numId = new NumericUpDown();
            lblPunto = new Label();
            cbPunto = new ComboBox();
            lblTipo = new Label();
            cbTipo = new ComboBox();
            lblCapacidad = new Label();
            numCapacidad = new NumericUpDown();
            lblNivel = new Label();
            numNivel = new NumericUpDown();
            lblTasa = new Label();
            numTasa = new NumericUpDown();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            btnGuardar = new Button();
            lblNota = new Label();
            errorProvider = new ErrorProvider(components);
            pnlEncabezado.SuspendLayout();
            pnlTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContenedores).BeginInit();
            pnlFormulario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCapacidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numNivel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTasa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
            SuspendLayout();
            // 
            // pnlEncabezado
            // 
            pnlEncabezado.Controls.Add(lblTitulo);
            pnlEncabezado.Controls.Add(lblSubtitulo);
            pnlEncabezado.BackColor = Color.FromArgb(30, 86, 49);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Size = new Size(1000, 64);
            pnlEncabezado.Name = "pnlEncabezado";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(20, 8);
            lblTitulo.Text = "Contenedores";
            lblTitulo.Name = "lblTitulo";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9F);
            lblSubtitulo.ForeColor = Color.FromArgb(200, 230, 210);
            lblSubtitulo.Location = new Point(22, 40);
            lblSubtitulo.Text = "Canecas de cada punto: tipo de residuo, capacidad y nivel actual";
            lblSubtitulo.Name = "lblSubtitulo";
            // 
            // pnlTabla
            // 
            pnlTabla.Controls.Add(lblTablaTitulo);
            pnlTabla.Controls.Add(dgvContenedores);
            pnlTabla.BackColor = Color.White;
            pnlTabla.Location = new Point(16, 80);
            pnlTabla.Size = new Size(616, 464);
            pnlTabla.Name = "pnlTabla";
            // 
            // lblTablaTitulo
            // 
            lblTablaTitulo.AutoSize = true;
            lblTablaTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTablaTitulo.ForeColor = Color.FromArgb(30, 86, 49);
            lblTablaTitulo.Location = new Point(16, 12);
            lblTablaTitulo.Text = "Contenedores registrados";
            lblTablaTitulo.Name = "lblTablaTitulo";
            // 
            // dgvContenedores
            // 
            dgvContenedores.AllowUserToAddRows = false;
            dgvContenedores.AllowUserToDeleteRows = false;
            dgvContenedores.AllowUserToResizeRows = false;
            dgvContenedores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvContenedores.BackgroundColor = Color.White;
            dgvContenedores.BorderStyle = BorderStyle.None;
            dgvContenedores.Location = new Point(14, 44);
            dgvContenedores.MultiSelect = false;
            dgvContenedores.ReadOnly = true;
            dgvContenedores.RowHeadersVisible = false;
            dgvContenedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvContenedores.Size = new Size(588, 406);
            dgvContenedores.Name = "dgvContenedores";
            dgvContenedores.SelectionChanged += dgvContenedores_SelectionChanged;
            // 
            // pnlFormulario
            // 
            pnlFormulario.Controls.Add(lblFormTitulo);
            pnlFormulario.Controls.Add(lblId);
            pnlFormulario.Controls.Add(numId);
            pnlFormulario.Controls.Add(lblPunto);
            pnlFormulario.Controls.Add(cbPunto);
            pnlFormulario.Controls.Add(lblTipo);
            pnlFormulario.Controls.Add(cbTipo);
            pnlFormulario.Controls.Add(lblCapacidad);
            pnlFormulario.Controls.Add(numCapacidad);
            pnlFormulario.Controls.Add(lblNivel);
            pnlFormulario.Controls.Add(numNivel);
            pnlFormulario.Controls.Add(lblTasa);
            pnlFormulario.Controls.Add(numTasa);
            pnlFormulario.Controls.Add(btnAgregar);
            pnlFormulario.Controls.Add(btnActualizar);
            pnlFormulario.Controls.Add(btnEliminar);
            pnlFormulario.Controls.Add(btnLimpiar);
            pnlFormulario.Controls.Add(btnGuardar);
            pnlFormulario.Controls.Add(lblNota);
            pnlFormulario.BackColor = Color.White;
            pnlFormulario.Location = new Point(648, 80);
            pnlFormulario.Size = new Size(336, 464);
            pnlFormulario.Name = "pnlFormulario";
            // 
            // lblFormTitulo
            // 
            lblFormTitulo.AutoSize = true;
            lblFormTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblFormTitulo.ForeColor = Color.FromArgb(30, 86, 49);
            lblFormTitulo.Location = new Point(16, 12);
            lblFormTitulo.Text = "Datos del contenedor";
            lblFormTitulo.Name = "lblFormTitulo";
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 9F);
            lblId.ForeColor = Color.FromArgb(107, 123, 113);
            lblId.Location = new Point(16, 46);
            lblId.Text = "Id";
            lblId.Name = "lblId";
            // 
            // numId
            // 
            numId.Location = new Point(16, 66);
            numId.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numId.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            numId.Size = new Size(304, 23);
            numId.Value = new decimal(new int[] { 0, 0, 0, 0 });
            numId.Font = new Font("Segoe UI", 9.75F);
            numId.Name = "numId";
            // 
            // lblPunto
            // 
            lblPunto.AutoSize = true;
            lblPunto.Font = new Font("Segoe UI", 9F);
            lblPunto.ForeColor = Color.FromArgb(107, 123, 113);
            lblPunto.Location = new Point(16, 98);
            lblPunto.Text = "Punto";
            lblPunto.Name = "lblPunto";
            // 
            // cbPunto
            // 
            cbPunto.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPunto.FlatStyle = FlatStyle.Flat;
            cbPunto.Font = new Font("Segoe UI", 9.75F);
            cbPunto.Location = new Point(16, 118);
            cbPunto.Size = new Size(304, 25);
            cbPunto.Name = "cbPunto";
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI", 9F);
            lblTipo.ForeColor = Color.FromArgb(107, 123, 113);
            lblTipo.Location = new Point(16, 150);
            lblTipo.Text = "Tipo de residuo";
            lblTipo.Name = "lblTipo";
            // 
            // cbTipo
            // 
            cbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipo.FlatStyle = FlatStyle.Flat;
            cbTipo.Font = new Font("Segoe UI", 9.75F);
            cbTipo.Location = new Point(16, 170);
            cbTipo.Size = new Size(304, 25);
            cbTipo.Name = "cbTipo";
            // 
            // lblCapacidad
            // 
            lblCapacidad.AutoSize = true;
            lblCapacidad.Font = new Font("Segoe UI", 9F);
            lblCapacidad.ForeColor = Color.FromArgb(107, 123, 113);
            lblCapacidad.Location = new Point(16, 202);
            lblCapacidad.Text = "Capacidad (L)";
            lblCapacidad.Name = "lblCapacidad";
            // 
            // numCapacidad
            // 
            numCapacidad.Location = new Point(16, 222);
            numCapacidad.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            numCapacidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numCapacidad.Size = new Size(146, 23);
            numCapacidad.Value = new decimal(new int[] { 120, 0, 0, 0 });
            numCapacidad.Font = new Font("Segoe UI", 9.75F);
            numCapacidad.Name = "numCapacidad";
            // 
            // lblNivel
            // 
            lblNivel.AutoSize = true;
            lblNivel.Font = new Font("Segoe UI", 9F);
            lblNivel.ForeColor = Color.FromArgb(107, 123, 113);
            lblNivel.Location = new Point(174, 202);
            lblNivel.Text = "Nivel actual (L)";
            lblNivel.Name = "lblNivel";
            // 
            // numNivel
            // 
            numNivel.DecimalPlaces = 1;
            numNivel.Location = new Point(174, 222);
            numNivel.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            numNivel.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            numNivel.Size = new Size(146, 23);
            numNivel.Value = new decimal(new int[] { 0, 0, 0, 0 });
            numNivel.Font = new Font("Segoe UI", 9.75F);
            numNivel.Name = "numNivel";
            // 
            // lblTasa
            // 
            lblTasa.AutoSize = true;
            lblTasa.Font = new Font("Segoe UI", 9F);
            lblTasa.ForeColor = Color.FromArgb(107, 123, 113);
            lblTasa.Location = new Point(16, 254);
            lblTasa.Text = "Tasa base (L/h)";
            lblTasa.Name = "lblTasa";
            // 
            // numTasa
            // 
            numTasa.DecimalPlaces = 2;
            numTasa.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numTasa.Location = new Point(16, 274);
            numTasa.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            numTasa.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            numTasa.Size = new Size(304, 23);
            numTasa.Value = new decimal(new int[] { 0, 0, 0, 0 });
            numTasa.Font = new Font("Segoe UI", 9.75F);
            numTasa.Name = "numTasa";
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(46, 125, 79);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Cursor = Cursors.Hand;
            btnAgregar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnAgregar.Location = new Point(16, 320);
            btnAgregar.Size = new Size(96, 34);
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.White;
            btnActualizar.ForeColor = Color.FromArgb(30, 86, 49);
            btnActualizar.FlatAppearance.BorderColor = Color.FromArgb(46, 125, 79);
            btnActualizar.FlatStyle = FlatStyle.Flat;
            btnActualizar.Cursor = Cursors.Hand;
            btnActualizar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnActualizar.Location = new Point(120, 320);
            btnActualizar.Size = new Size(96, 34);
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.White;
            btnEliminar.ForeColor = Color.FromArgb(214, 69, 69);
            btnEliminar.FlatAppearance.BorderColor = Color.FromArgb(214, 69, 69);
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnEliminar.Location = new Point(224, 320);
            btnEliminar.Size = new Size(96, 34);
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.White;
            btnLimpiar.ForeColor = Color.FromArgb(30, 86, 49);
            btnLimpiar.FlatAppearance.BorderColor = Color.FromArgb(46, 125, 79);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnLimpiar.Location = new Point(16, 364);
            btnLimpiar.Size = new Size(96, 34);
            btnLimpiar.Text = "Nuevo";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(46, 125, 79);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnGuardar.Location = new Point(120, 364);
            btnGuardar.Size = new Size(200, 34);
            btnGuardar.Text = "Guardar en archivo";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Click += btnGuardar_Click;
            // 
            // lblNota
            // 
            lblNota.Font = new Font("Segoe UI", 8.25F);
            lblNota.ForeColor = Color.FromArgb(107, 123, 113);
            lblNota.Location = new Point(16, 410);
            lblNota.Size = new Size(304, 34);
            lblNota.Text = "La tasa base es el promedio semanal; el sistema la ajusta según la hora y el día.";
            lblNota.Name = "lblNota";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // FrContenedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 243);
            ClientSize = new Size(1000, 560);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Text = "Contenedores";
            Controls.Add(pnlEncabezado);
            Controls.Add(pnlTabla);
            Controls.Add(pnlFormulario);
            Name = "FrContenedores";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTasa).EndInit();
            ((System.ComponentModel.ISupportInitialize)numNivel).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCapacidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)numId).EndInit();
            pnlFormulario.ResumeLayout(false);
            pnlFormulario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvContenedores).EndInit();
            pnlTabla.ResumeLayout(false);
            pnlTabla.PerformLayout();
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlEncabezado;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Panel pnlTabla;
        private Label lblTablaTitulo;
        private DataGridView dgvContenedores;
        private Panel pnlFormulario;
        private Label lblFormTitulo;
        private Label lblId;
        private NumericUpDown numId;
        private Label lblPunto;
        private ComboBox cbPunto;
        private Label lblTipo;
        private ComboBox cbTipo;
        private Label lblCapacidad;
        private NumericUpDown numCapacidad;
        private Label lblNivel;
        private NumericUpDown numNivel;
        private Label lblTasa;
        private NumericUpDown numTasa;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Button btnGuardar;
        private Label lblNota;
        private ErrorProvider errorProvider;
    }
}
