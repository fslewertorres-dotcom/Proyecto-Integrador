namespace EcoResiduos.Presentation
{
    partial class FrLogin
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
            pnlMarca = new Panel();
            lblIcono = new Label();
            lblMarca = new Label();
            lblLema = new Label();
            lblBienvenida = new Label();
            lblInstruccion = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblContrasena = new Label();
            txtContrasena = new TextBox();
            btnIngresar = new Button();
            lblMensaje = new Label();
            pnlMarca.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMarca
            // 
            pnlMarca.BackColor = Color.FromArgb(30, 86, 49);
            pnlMarca.Controls.Add(lblIcono);
            pnlMarca.Controls.Add(lblMarca);
            pnlMarca.Controls.Add(lblLema);
            pnlMarca.Dock = DockStyle.Left;
            pnlMarca.Location = new Point(0, 0);
            pnlMarca.Name = "pnlMarca";
            pnlMarca.Size = new Size(320, 440);
            pnlMarca.TabIndex = 0;
            // 
            // lblIcono
            // 
            lblIcono.AutoSize = true;
            lblIcono.Font = new Font("Segoe UI", 48F);
            lblIcono.ForeColor = Color.FromArgb(160, 220, 180);
            lblIcono.Location = new Point(93, 146);
            lblIcono.Name = "lblIcono";
            lblIcono.Size = new Size(125, 86);
            lblIcono.TabIndex = 0;
            lblIcono.Text = "♻";
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblMarca.ForeColor = Color.White;
            lblMarca.Location = new Point(63, 227);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(191, 41);
            lblMarca.TabIndex = 1;
            lblMarca.Text = "EcoResiduos";
            lblMarca.Click += lblMarca_Click;
            // 
            // lblLema
            // 
            lblLema.AutoSize = true;
            lblLema.Font = new Font("Segoe UI", 10.5F);
            lblLema.ForeColor = Color.FromArgb(200, 230, 210);
            lblLema.Location = new Point(60, 268);
            lblLema.Name = "lblLema";
            lblLema.Size = new Size(198, 19);
            lblLema.TabIndex = 2;
            lblLema.Text = "Gestión inteligente de residuos";
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.FromArgb(30, 86, 49);
            lblBienvenida.Location = new Point(368, 60);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(147, 30);
            lblBienvenida.TabIndex = 1;
            lblBienvenida.Text = "Iniciar sesión";
            // 
            // lblInstruccion
            // 
            lblInstruccion.AutoSize = true;
            lblInstruccion.Font = new Font("Segoe UI", 9F);
            lblInstruccion.ForeColor = Color.FromArgb(107, 123, 113);
            lblInstruccion.Location = new Point(370, 96);
            lblInstruccion.Name = "lblInstruccion";
            lblInstruccion.Size = new Size(195, 15);
            lblInstruccion.TabIndex = 2;
            lblInstruccion.Text = "Ingrese con su usuario y contraseña";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 9F);
            lblUsuario.ForeColor = Color.FromArgb(107, 123, 113);
            lblUsuario.Location = new Point(370, 140);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(47, 15);
            lblUsuario.TabIndex = 3;
            lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Font = new Font("Segoe UI", 9.75F);
            txtUsuario.Location = new Point(370, 160);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(340, 25);
            txtUsuario.TabIndex = 4;
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Font = new Font("Segoe UI", 9F);
            lblContrasena.ForeColor = Color.FromArgb(107, 123, 113);
            lblContrasena.Location = new Point(370, 200);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(67, 15);
            lblContrasena.TabIndex = 5;
            lblContrasena.Text = "Contraseña";
            // 
            // txtContrasena
            // 
            txtContrasena.BorderStyle = BorderStyle.FixedSingle;
            txtContrasena.Font = new Font("Segoe UI", 9.75F);
            txtContrasena.Location = new Point(370, 220);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(340, 25);
            txtContrasena.TabIndex = 6;
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(46, 125, 79);
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(370, 268);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(340, 40);
            btnIngresar.TabIndex = 7;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // lblMensaje
            // 
            lblMensaje.Font = new Font("Segoe UI", 9F);
            lblMensaje.ForeColor = Color.FromArgb(214, 69, 69);
            lblMensaje.Location = new Point(370, 318);
            lblMensaje.Name = "lblMensaje";
            lblMensaje.Size = new Size(340, 36);
            lblMensaje.TabIndex = 8;
            // 
            // FrLogin
            // 
            AcceptButton = btnIngresar;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(760, 440);
            Controls.Add(pnlMarca);
            Controls.Add(lblBienvenida);
            Controls.Add(lblInstruccion);
            Controls.Add(lblUsuario);
            Controls.Add(txtUsuario);
            Controls.Add(lblContrasena);
            Controls.Add(txtContrasena);
            Controls.Add(btnIngresar);
            Controls.Add(lblMensaje);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EcoResiduos - Iniciar sesión";
            pnlMarca.ResumeLayout(false);
            pnlMarca.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlMarca;
        private Label lblIcono;
        private Label lblMarca;
        private Label lblLema;
        private Label lblBienvenida;
        private Label lblInstruccion;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblContrasena;
        private TextBox txtContrasena;
        private Button btnIngresar;
        private Label lblMensaje;
    }
}
