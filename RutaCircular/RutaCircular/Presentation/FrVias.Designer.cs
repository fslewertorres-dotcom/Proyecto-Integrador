namespace RutaCircular.Presentation
{
    partial class FrVias
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
            pnlEncabezado = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            pnlTabla = new Panel();
            lblTablaTitulo = new Label();
            dgvVias = new DataGridView();
            pnlFormulario = new Panel();
            lblFormTitulo = new Label();
            lblId = new Label();
            numId = new NumericUpDown();
            lblOrigen = new Label();
            cbOrigen = new ComboBox();
            lblDestino = new Label();
            cbDestino = new ComboBox();
            lblDistancia = new Label();
            numDistancia = new NumericUpDown();
            btnCalcularDistancia = new Button();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            btnGuardar = new Button();
            lblNota = new Label();
            pnlEncabezado.SuspendLayout();
            pnlTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVias).BeginInit();
            pnlFormulario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numDistancia).BeginInit();
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
            lblTitulo.Text = "Vías del conjunto";
            lblTitulo.Name = "lblTitulo";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9F);
            lblSubtitulo.ForeColor = Color.FromArgb(200, 230, 210);
            lblSubtitulo.Location = new Point(22, 40);
            lblSubtitulo.Text = "Tramos que conectan los puntos del plano (aristas del grafo)";
            lblSubtitulo.Name = "lblSubtitulo";
            // 
            // pnlTabla
            // 
            pnlTabla.Controls.Add(lblTablaTitulo);
            pnlTabla.Controls.Add(dgvVias);
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
            lblTablaTitulo.Text = "Vías registradas";
            lblTablaTitulo.Name = "lblTablaTitulo";
            // 
            // dgvVias
            // 
            dgvVias.AllowUserToAddRows = false;
            dgvVias.AllowUserToDeleteRows = false;
            dgvVias.AllowUserToResizeRows = false;
            dgvVias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVias.BackgroundColor = Color.White;
            dgvVias.BorderStyle = BorderStyle.None;
            dgvVias.Location = new Point(14, 44);
            dgvVias.MultiSelect = false;
            dgvVias.ReadOnly = true;
            dgvVias.RowHeadersVisible = false;
            dgvVias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVias.Size = new Size(588, 406);
            dgvVias.Name = "dgvVias";
            dgvVias.SelectionChanged += dgvVias_SelectionChanged;
            // 
            // pnlFormulario
            // 
            pnlFormulario.Controls.Add(lblFormTitulo);
            pnlFormulario.Controls.Add(lblId);
            pnlFormulario.Controls.Add(numId);
            pnlFormulario.Controls.Add(lblOrigen);
            pnlFormulario.Controls.Add(cbOrigen);
            pnlFormulario.Controls.Add(lblDestino);
            pnlFormulario.Controls.Add(cbDestino);
            pnlFormulario.Controls.Add(lblDistancia);
            pnlFormulario.Controls.Add(numDistancia);
            pnlFormulario.Controls.Add(btnCalcularDistancia);
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
            lblFormTitulo.Text = "Datos de la vía";
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
            // lblOrigen
            // 
            lblOrigen.AutoSize = true;
            lblOrigen.Font = new Font("Segoe UI", 9F);
            lblOrigen.ForeColor = Color.FromArgb(107, 123, 113);
            lblOrigen.Location = new Point(16, 98);
            lblOrigen.Text = "Origen";
            lblOrigen.Name = "lblOrigen";
            // 
            // cbOrigen
            // 
            cbOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
            cbOrigen.FlatStyle = FlatStyle.Flat;
            cbOrigen.Font = new Font("Segoe UI", 9.75F);
            cbOrigen.Location = new Point(16, 118);
            cbOrigen.Size = new Size(304, 25);
            cbOrigen.Name = "cbOrigen";
            // 
            // lblDestino
            // 
            lblDestino.AutoSize = true;
            lblDestino.Font = new Font("Segoe UI", 9F);
            lblDestino.ForeColor = Color.FromArgb(107, 123, 113);
            lblDestino.Location = new Point(16, 150);
            lblDestino.Text = "Destino";
            lblDestino.Name = "lblDestino";
            // 
            // cbDestino
            // 
            cbDestino.DropDownStyle = ComboBoxStyle.DropDownList;
            cbDestino.FlatStyle = FlatStyle.Flat;
            cbDestino.Font = new Font("Segoe UI", 9.75F);
            cbDestino.Location = new Point(16, 170);
            cbDestino.Size = new Size(304, 25);
            cbDestino.Name = "cbDestino";
            // 
            // lblDistancia
            // 
            lblDistancia.AutoSize = true;
            lblDistancia.Font = new Font("Segoe UI", 9F);
            lblDistancia.ForeColor = Color.FromArgb(107, 123, 113);
            lblDistancia.Location = new Point(16, 202);
            lblDistancia.Text = "Distancia (m)";
            lblDistancia.Name = "lblDistancia";
            // 
            // numDistancia
            // 
            numDistancia.DecimalPlaces = 2;
            numDistancia.Location = new Point(16, 222);
            numDistancia.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numDistancia.Minimum = new decimal(new int[] { 0, 0, 0, 0 });
            numDistancia.Size = new Size(190, 23);
            numDistancia.Value = new decimal(new int[] { 0, 0, 0, 0 });
            numDistancia.Font = new Font("Segoe UI", 9.75F);
            numDistancia.Name = "numDistancia";
            // 
            // btnCalcularDistancia
            // 
            btnCalcularDistancia.BackColor = Color.White;
            btnCalcularDistancia.ForeColor = Color.FromArgb(30, 86, 49);
            btnCalcularDistancia.FlatAppearance.BorderColor = Color.FromArgb(46, 125, 79);
            btnCalcularDistancia.FlatStyle = FlatStyle.Flat;
            btnCalcularDistancia.Cursor = Cursors.Hand;
            btnCalcularDistancia.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnCalcularDistancia.Location = new Point(214, 220);
            btnCalcularDistancia.Size = new Size(106, 30);
            btnCalcularDistancia.Text = "Calcular";
            btnCalcularDistancia.UseVisualStyleBackColor = false;
            btnCalcularDistancia.Name = "btnCalcularDistancia";
            btnCalcularDistancia.Click += btnCalcularDistancia_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.FromArgb(46, 125, 79);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Cursor = Cursors.Hand;
            btnAgregar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnAgregar.Location = new Point(16, 316);
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
            btnActualizar.Location = new Point(120, 316);
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
            btnEliminar.Location = new Point(224, 316);
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
            btnLimpiar.Location = new Point(16, 360);
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
            btnGuardar.Location = new Point(120, 360);
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
            lblNota.Location = new Point(16, 406);
            lblNota.Size = new Size(304, 34);
            lblNota.Text = "Si deja la distancia en 0 se calcula con las coordenadas. Después de cambiar vías, vuelva a abrir el mapa.";
            lblNota.Name = "lblNota";
            // 
            // FrVias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 243);
            ClientSize = new Size(1000, 560);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Text = "Vías del conjunto";
            Controls.Add(pnlEncabezado);
            Controls.Add(pnlTabla);
            Controls.Add(pnlFormulario);
            Name = "FrVias";
            ((System.ComponentModel.ISupportInitialize)numDistancia).EndInit();
            ((System.ComponentModel.ISupportInitialize)numId).EndInit();
            pnlFormulario.ResumeLayout(false);
            pnlFormulario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVias).EndInit();
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
        private DataGridView dgvVias;
        private Panel pnlFormulario;
        private Label lblFormTitulo;
        private Label lblId;
        private NumericUpDown numId;
        private Label lblOrigen;
        private ComboBox cbOrigen;
        private Label lblDestino;
        private ComboBox cbDestino;
        private Label lblDistancia;
        private NumericUpDown numDistancia;
        private Button btnCalcularDistancia;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Button btnGuardar;
        private Label lblNota;
    }
}
