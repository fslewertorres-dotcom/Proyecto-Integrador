namespace EcoResiduos.Presentation
{
    partial class FrPuntos
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
            dgvPuntos = new DataGridView();
            pnlFormulario = new Panel();
            lblFormTitulo = new Label();
            lblId = new Label();
            numId = new NumericUpDown();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblTipo = new Label();
            cbTipo = new ComboBox();
            lblX = new Label();
            numX = new NumericUpDown();
            lblY = new Label();
            numY = new NumericUpDown();
            lblCasas = new Label();
            numCasas = new NumericUpDown();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            btnGuardar = new Button();
            lblNota = new Label();
            errorProvider = new ErrorProvider(components);
            pnlEncabezado.SuspendLayout();
            pnlTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPuntos).BeginInit();
            pnlFormulario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCasas).BeginInit();
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
            lblTitulo.Text = "Ubicaciones del mapa";
            lblTitulo.Name = "lblTitulo";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9F);
            lblSubtitulo.ForeColor = Color.FromArgb(200, 230, 210);
            lblSubtitulo.Location = new Point(22, 40);
            lblSubtitulo.Text = "Nodos del plano: puntos ecológicos, zonas sociales, acopio e intersecciones";
            lblSubtitulo.Name = "lblSubtitulo";
            // 
            // pnlTabla
            // 
            pnlTabla.Controls.Add(lblTablaTitulo);
            pnlTabla.Controls.Add(dgvPuntos);
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
            lblTablaTitulo.Text = "Ubicaciones registradas";
            lblTablaTitulo.Name = "lblTablaTitulo";
            // 
            // dgvPuntos
            // 
            dgvPuntos.AllowUserToAddRows = false;
            dgvPuntos.AllowUserToDeleteRows = false;
            dgvPuntos.AllowUserToResizeRows = false;
            dgvPuntos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPuntos.BackgroundColor = Color.White;
            dgvPuntos.BorderStyle = BorderStyle.None;
            dgvPuntos.Location = new Point(14, 44);
            dgvPuntos.MultiSelect = false;
            dgvPuntos.ReadOnly = true;
            dgvPuntos.RowHeadersVisible = false;
            dgvPuntos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPuntos.Size = new Size(588, 406);
            dgvPuntos.Name = "dgvPuntos";
            dgvPuntos.SelectionChanged += dgvPuntos_SelectionChanged;
            // 
            // pnlFormulario
            // 
            pnlFormulario.Controls.Add(lblFormTitulo);
            pnlFormulario.Controls.Add(lblId);
            pnlFormulario.Controls.Add(numId);
            pnlFormulario.Controls.Add(lblNombre);
            pnlFormulario.Controls.Add(txtNombre);
            pnlFormulario.Controls.Add(lblTipo);
            pnlFormulario.Controls.Add(cbTipo);
            pnlFormulario.Controls.Add(lblX);
            pnlFormulario.Controls.Add(numX);
            pnlFormulario.Controls.Add(lblY);
            pnlFormulario.Controls.Add(numY);
            pnlFormulario.Controls.Add(lblCasas);
            pnlFormulario.Controls.Add(numCasas);
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
            lblFormTitulo.Text = "Datos de la ubicación";
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
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9F);
            lblNombre.ForeColor = Color.FromArgb(107, 123, 113);
            lblNombre.Location = new Point(16, 98);
            lblNombre.Text = "Nombre";
            lblNombre.Name = "lblNombre";
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 9.75F);
            txtNombre.Location = new Point(16, 118);
            txtNombre.Size = new Size(304, 25);
            txtNombre.Name = "txtNombre";
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI", 9F);
            lblTipo.ForeColor = Color.FromArgb(107, 123, 113);
            lblTipo.Location = new Point(16, 150);
            lblTipo.Text = "Tipo";
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
            // lblX
            // 
            lblX.AutoSize = true;
            lblX.Font = new Font("Segoe UI", 9F);
            lblX.ForeColor = Color.FromArgb(107, 123, 113);
            lblX.Location = new Point(16, 202);
            lblX.Text = "X (m)";
            lblX.Name = "lblX";
            // 
            // numX
            // 
            numX.DecimalPlaces = 1;
            numX.Location = new Point(16, 222);
            numX.Maximum = new decimal(new int[] { 120, 0, 0, 0 });
            numX.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            numX.Size = new Size(146, 23);
            numX.Value = new decimal(new int[] { 0, 0, 0, 0 });
            numX.Font = new Font("Segoe UI", 9.75F);
            numX.Name = "numX";
            // 
            // lblY
            // 
            lblY.AutoSize = true;
            lblY.Font = new Font("Segoe UI", 9F);
            lblY.ForeColor = Color.FromArgb(107, 123, 113);
            lblY.Location = new Point(174, 202);
            lblY.Text = "Y (m)";
            lblY.Name = "lblY";
            // 
            // numY
            // 
            numY.DecimalPlaces = 1;
            numY.Location = new Point(174, 222);
            numY.Maximum = new decimal(new int[] { 160, 0, 0, 0 });
            numY.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            numY.Size = new Size(146, 23);
            numY.Value = new decimal(new int[] { 0, 0, 0, 0 });
            numY.Font = new Font("Segoe UI", 9.75F);
            numY.Name = "numY";
            // 
            // lblCasas
            // 
            lblCasas.AutoSize = true;
            lblCasas.Font = new Font("Segoe UI", 9F);
            lblCasas.ForeColor = Color.FromArgb(107, 123, 113);
            lblCasas.Location = new Point(16, 254);
            lblCasas.Text = "Casas atendidas";
            lblCasas.Name = "lblCasas";
            // 
            // numCasas
            // 
            numCasas.Location = new Point(16, 274);
            numCasas.Maximum = new decimal(new int[] { 96, 0, 0, 0 });
            numCasas.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            numCasas.Size = new Size(304, 23);
            numCasas.Value = new decimal(new int[] { 0, 0, 0, 0 });
            numCasas.Font = new Font("Segoe UI", 9.75F);
            numCasas.Name = "numCasas";
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
            lblNota.Text = "Coordenadas en metros: X de 0 a 120 y Y de 0 a 160.";
            lblNota.Name = "lblNota";
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // FrPuntos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 243);
            ClientSize = new Size(1000, 560);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Text = "Ubicaciones del mapa";
            Controls.Add(pnlEncabezado);
            Controls.Add(pnlTabla);
            Controls.Add(pnlFormulario);
            Name = "FrPuntos";
            ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCasas).EndInit();
            ((System.ComponentModel.ISupportInitialize)numY).EndInit();
            ((System.ComponentModel.ISupportInitialize)numX).EndInit();
            ((System.ComponentModel.ISupportInitialize)numId).EndInit();
            pnlFormulario.ResumeLayout(false);
            pnlFormulario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPuntos).EndInit();
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
        private DataGridView dgvPuntos;
        private Panel pnlFormulario;
        private Label lblFormTitulo;
        private Label lblId;
        private NumericUpDown numId;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblTipo;
        private ComboBox cbTipo;
        private Label lblX;
        private NumericUpDown numX;
        private Label lblY;
        private NumericUpDown numY;
        private Label lblCasas;
        private NumericUpDown numCasas;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Button btnGuardar;
        private Label lblNota;
        private ErrorProvider errorProvider;
    }
}
