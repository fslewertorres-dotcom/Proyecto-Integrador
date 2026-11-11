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
            lblConjunto = new Label();
            lblBienvenida = new Label();
            lblInstruccion = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblContrasena = new Label();
            txtContrasena = new TextBox();
            btnIngresar = new Button();
            lblMensaje = new Label();
            lblAyuda = new Label();
            pnlMarca.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMarca
            // 
            pnlMarca.Controls.Add(lblIcono);
            pnlMarca.Controls.Add(lblMarca);
            pnlMarca.Controls.Add(lblLema);
            pnlMarca.Controls.Add(lblConjunto);
            pnlMarca.BackColor = Color.FromArgb(30, 86, 49);
            pnlMarca.Dock = DockStyle.Left;
            pnlMarca.Location = new Point(0, 0);
            pnlMarca.Size = new Size(320, 440);
            pnlMarca.Name = "pnlMarca";
            // 
            // lblIcono
            // 
            lblIcono.AutoSize = true;
            lblIcono.Font = new Font("Segoe UI", 48F);
            lblIcono.ForeColor = Color.FromArgb(160, 220, 180);
            lblIcono.Location = new Point(40, 60);
            lblIcono.Text = "♻";
            lblIcono.Name = "lblIcono";
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblMarca.ForeColor = Color.White;
            lblMarca.Location = new Point(40, 170);
            lblMarca.Text = "EcoResiduos";
            lblMarca.Name = "lblMarca";
            // 
            // lblLema
            // 
            lblLema.AutoSize = true;
            lblLema.Font = new Font("Segoe UI", 10.5F);
            lblLema.ForeColor = Color.FromArgb(200, 230, 210);
            lblLema.Location = new Point(43, 215);
            lblLema.Text = "Gestión inteligente de residuos";
            lblLema.Name = "lblLema";
            // 
            // lblConjunto
            // 
            lblConjunto.AutoSize = true;
            lblConjunto.Font = new Font("Segoe UI", 8.25F);
            lblConjunto.ForeColor = Color.FromArgb(200, 230, 210);
            lblConjunto.Location = new Point(43, 380);
            lblConjunto.Text = "Conjunto Portal del Viento · Aguachica, Cesar";
            lblConjunto.Name = "lblConjunto";
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblBienvenida.ForeColor = Color.FromArgb(30, 86, 49);
            lblBienvenida.Location = new Point(368, 60);
            lblBienvenida.Text = "Iniciar sesión";
            lblBienvenida.Name = "lblBienvenida";
            // 
            // lblInstruccion
            // 
            lblInstruccion.AutoSize = true;
            lblInstruccion.Font = new Font("Segoe UI", 9F);
            lblInstruccion.ForeColor = Color.FromArgb(107, 123, 113);
            lblInstruccion.Location = new Point(370, 96);
            lblInstruccion.Text = "Ingrese con su usuario y contraseña";
            lblInstruccion.Name = "lblInstruccion";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 9F);
            lblUsuario.ForeColor = Color.FromArgb(107, 123, 113);
            lblUsuario.Location = new Point(370, 140);
            lblUsuario.Text = "Usuario";
            lblUsuario.Name = "lblUsuario";
            // 
            // txtUsuario
            // 
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Font = new Font("Segoe UI", 9.75F);
            txtUsuario.Location = new Point(370, 160);
            txtUsuario.Size = new Size(340, 25);
            txtUsuario.Name = "txtUsuario";
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Font = new Font("Segoe UI", 9F);
            lblContrasena.ForeColor = Color.FromArgb(107, 123, 113);
            lblContrasena.Location = new Point(370, 200);
            lblContrasena.Text = "Contraseña";
            lblContrasena.Name = "lblContrasena";
            // 
            // txtContrasena
            // 
            txtContrasena.BorderStyle = BorderStyle.FixedSingle;
            txtContrasena.Font = new Font("Segoe UI", 9.75F);
            txtContrasena.Location = new Point(370, 220);
            txtContrasena.Size = new Size(340, 25);
            txtContrasena.UseSystemPasswordChar = true;
            txtContrasena.Name = "txtContrasena";
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(46, 125, 79);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnIngresar.Location = new Point(370, 268);
            btnIngresar.Size = new Size(340, 40);
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Click += btnIngresar_Click;
            // 
            // lblMensaje
            // 
            lblMensaje.Font = new Font("Segoe UI", 9F);
            lblMensaje.ForeColor = Color.FromArgb(214, 69, 69);
            lblMensaje.Location = new Point(370, 318);
            lblMensaje.Size = new Size(340, 36);
            lblMensaje.Text = "";
            lblMensaje.Name = "lblMensaje";
            // 
            // lblAyuda
            // 
            lblAyuda.AutoSize = true;
            lblAyuda.Font = new Font("Segoe UI", 8.25F);
            lblAyuda.ForeColor = Color.FromArgb(107, 123, 113);
            lblAyuda.Location = new Point(370, 396);
            lblAyuda.Text = "Pruebas: admin / admin123  ·  operario / operario123";
            lblAyuda.Name = "lblAyuda";
            // 
            // FrLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AcceptButton = btnIngresar;
            BackColor = Color.White;
            ClientSize = new Size(760, 440);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EcoResiduos - Iniciar sesión";
            Controls.Add(pnlMarca);
            Controls.Add(lblBienvenida);
            Controls.Add(lblInstruccion);
            Controls.Add(lblUsuario);
            Controls.Add(txtUsuario);
            Controls.Add(lblContrasena);
            Controls.Add(txtContrasena);
            Controls.Add(btnIngresar);
            Controls.Add(lblMensaje);
            Controls.Add(lblAyuda);
            Name = "FrLogin";
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
        private Label lblConjunto;
        private Label lblBienvenida;
        private Label lblInstruccion;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblContrasena;
        private TextBox txtContrasena;
        private Button btnIngresar;
        private Label lblMensaje;
        private Label lblAyuda;
    }
}
