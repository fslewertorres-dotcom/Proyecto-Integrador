namespace EcoResiduos.Presentation
{
    partial class FrUsuarios
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
            dgvUsuarios = new DataGridView();
            pnlFormulario = new Panel();
            lblFormTitulo = new Label();
            lblId = new Label();
            numId = new NumericUpDown();
            lblRol = new Label();
            cbRol = new ComboBox();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblContrasena = new Label();
            txtContrasena = new TextBox();
            lblConfirmar = new Label();
            txtConfirmar = new TextBox();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            btnGuardar = new Button();
            lblNota = new Label();
            pnlEncabezado.SuspendLayout();
            pnlTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            pnlFormulario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numId).BeginInit();
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
            lblTitulo.Text = "Usuarios";
            lblTitulo.Name = "lblTitulo";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9F);
            lblSubtitulo.ForeColor = Color.FromArgb(200, 230, 210);
            lblSubtitulo.Location = new Point(22, 40);
            lblSubtitulo.Text = "Personas que pueden entrar al sistema y qué puede hacer cada una";
            lblSubtitulo.Name = "lblSubtitulo";
            // 
            // pnlTabla
            // 
            pnlTabla.Controls.Add(lblTablaTitulo);
            pnlTabla.Controls.Add(dgvUsuarios);
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
            lblTablaTitulo.Text = "Usuarios registrados";
            lblTablaTitulo.Name = "lblTablaTitulo";
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AllowUserToResizeRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.BorderStyle = BorderStyle.None;
            dgvUsuarios.Location = new Point(14, 44);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(588, 406);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;
            // 
            // pnlFormulario
            // 
            pnlFormulario.Controls.Add(lblFormTitulo);
            pnlFormulario.Controls.Add(lblId);
            pnlFormulario.Controls.Add(numId);
            pnlFormulario.Controls.Add(lblRol);
            pnlFormulario.Controls.Add(cbRol);
            pnlFormulario.Controls.Add(lblUsuario);
            pnlFormulario.Controls.Add(txtUsuario);
            pnlFormulario.Controls.Add(lblNombre);
            pnlFormulario.Controls.Add(txtNombre);
            pnlFormulario.Controls.Add(lblContrasena);
            pnlFormulario.Controls.Add(txtContrasena);
            pnlFormulario.Controls.Add(lblConfirmar);
            pnlFormulario.Controls.Add(txtConfirmar);
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
            lblFormTitulo.Text = "Datos del usuario";
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
            numId.Size = new Size(110, 23);
            numId.Value = new decimal(new int[] { 0, 0, 0, 0 });
            numId.Font = new Font("Segoe UI", 9.75F);
            numId.Name = "numId";
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI", 9F);
            lblRol.ForeColor = Color.FromArgb(107, 123, 113);
            lblRol.Location = new Point(138, 46);
            lblRol.Text = "Rol";
            lblRol.Name = "lblRol";
            // 
            // cbRol
            // 
            cbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRol.FlatStyle = FlatStyle.Flat;
            cbRol.Font = new Font("Segoe UI", 9.75F);
            cbRol.Location = new Point(138, 66);
            cbRol.Size = new Size(182, 25);
            cbRol.Name = "cbRol";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 9F);
            lblUsuario.ForeColor = Color.FromArgb(107, 123, 113);
            lblUsuario.Location = new Point(16, 98);
            lblUsuario.Text = "Usuario";
            lblUsuario.Name = "lblUsuario";
            // 
            // txtUsuario
            // 
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Font = new Font("Segoe UI", 9.75F);
            txtUsuario.Location = new Point(16, 118);
            txtUsuario.Size = new Size(304, 25);
            txtUsuario.Name = "txtUsuario";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9F);
            lblNombre.ForeColor = Color.FromArgb(107, 123, 113);
            lblNombre.Location = new Point(16, 150);
            lblNombre.Text = "Nombre completo";
            lblNombre.Name = "lblNombre";
            // 
            // txtNombre
            // 
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 9.75F);
            txtNombre.Location = new Point(16, 170);
            txtNombre.Size = new Size(304, 25);
            txtNombre.Name = "txtNombre";
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Font = new Font("Segoe UI", 9F);
            lblContrasena.ForeColor = Color.FromArgb(107, 123, 113);
            lblContrasena.Location = new Point(16, 202);
            lblContrasena.Text = "Contraseña";
            lblContrasena.Name = "lblContrasena";
            // 
            // txtContrasena
            // 
            txtContrasena.BorderStyle = BorderStyle.FixedSingle;
            txtContrasena.Font = new Font("Segoe UI", 9.75F);
            txtContrasena.Location = new Point(16, 222);
            txtContrasena.Size = new Size(146, 25);
            txtContrasena.UseSystemPasswordChar = true;
            txtContrasena.Name = "txtContrasena";
            // 
            // lblConfirmar
            // 
            lblConfirmar.AutoSize = true;
            lblConfirmar.Font = new Font("Segoe UI", 9F);
            lblConfirmar.ForeColor = Color.FromArgb(107, 123, 113);
            lblConfirmar.Location = new Point(174, 202);
            lblConfirmar.Text = "Confirmar";
            lblConfirmar.Name = "lblConfirmar";
            // 
            // txtConfirmar
            // 
            txtConfirmar.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmar.Font = new Font("Segoe UI", 9.75F);
            txtConfirmar.Location = new Point(174, 222);
            txtConfirmar.Size = new Size(146, 25);
            txtConfirmar.UseSystemPasswordChar = true;
            txtConfirmar.Name = "txtConfirmar";
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
            lblNota.Text = "Mínimo 6 caracteres. Al actualizar, deje la contraseña vacía para conservar la actual.";
            lblNota.Name = "lblNota";
            // 
            // FrUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 243);
            ClientSize = new Size(1000, 560);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Text = "Usuarios";
            Controls.Add(pnlEncabezado);
            Controls.Add(pnlTabla);
            Controls.Add(pnlFormulario);
            Name = "FrUsuarios";
            ((System.ComponentModel.ISupportInitialize)numId).EndInit();
            pnlFormulario.ResumeLayout(false);
            pnlFormulario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
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
        private DataGridView dgvUsuarios;
        private Panel pnlFormulario;
        private Label lblFormTitulo;
        private Label lblId;
        private NumericUpDown numId;
        private Label lblRol;
        private ComboBox cbRol;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblContrasena;
        private TextBox txtContrasena;
        private Label lblConfirmar;
        private TextBox txtConfirmar;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Button btnGuardar;
        private Label lblNota;
    }
}
