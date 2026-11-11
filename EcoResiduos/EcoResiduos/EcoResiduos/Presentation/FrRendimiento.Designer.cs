namespace EcoResiduos.Presentation
{
    partial class FrRendimiento
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
            pnlControles = new Panel();
            lblTamanos = new Label();
            chk1000 = new CheckBox();
            chk10000 = new CheckBox();
            chk100000 = new CheckBox();
            lblConsultas = new Label();
            numConsultas = new NumericUpDown();
            btnEjecutar = new Button();
            progreso = new ProgressBar();
            lblEstado = new Label();
            pnlTabla = new Panel();
            dgvResultados = new DataGridView();
            pnlConclusion = new Panel();
            lblConclusionTitulo = new Label();
            txtConclusion = new TextBox();
            pnlEncabezado.SuspendLayout();
            pnlControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numConsultas).BeginInit();
            pnlTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).BeginInit();
            pnlConclusion.SuspendLayout();
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
            lblTitulo.Text = "Comparación de algoritmos";
            lblTitulo.Name = "lblTitulo";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9F);
            lblSubtitulo.ForeColor = Color.FromArgb(200, 230, 210);
            lblSubtitulo.Location = new Point(22, 40);
            lblSubtitulo.Text = "QuickSort propio vs Array.Sort · búsqueda lineal vs binaria";
            lblSubtitulo.Name = "lblSubtitulo";
            // 
            // pnlControles
            // 
            pnlControles.Controls.Add(lblTamanos);
            pnlControles.Controls.Add(chk1000);
            pnlControles.Controls.Add(chk10000);
            pnlControles.Controls.Add(chk100000);
            pnlControles.Controls.Add(lblConsultas);
            pnlControles.Controls.Add(numConsultas);
            pnlControles.Controls.Add(btnEjecutar);
            pnlControles.Controls.Add(progreso);
            pnlControles.Controls.Add(lblEstado);
            pnlControles.BackColor = Color.White;
            pnlControles.Location = new Point(16, 80);
            pnlControles.Size = new Size(968, 56);
            pnlControles.Name = "pnlControles";
            // 
            // lblTamanos
            // 
            lblTamanos.AutoSize = true;
            lblTamanos.Font = new Font("Segoe UI", 9F);
            lblTamanos.ForeColor = Color.FromArgb(107, 123, 113);
            lblTamanos.Location = new Point(14, 19);
            lblTamanos.Text = "Tamaños (n):";
            lblTamanos.Name = "lblTamanos";
            // 
            // chk1000
            // 
            chk1000.AutoSize = true;
            chk1000.Checked = true;
            chk1000.CheckState = CheckState.Checked;
            chk1000.Font = new Font("Segoe UI", 9.75F);
            chk1000.Location = new Point(100, 17);
            chk1000.Text = "1.000";
            chk1000.UseVisualStyleBackColor = true;
            chk1000.Name = "chk1000";
            // 
            // chk10000
            // 
            chk10000.AutoSize = true;
            chk10000.Checked = true;
            chk10000.CheckState = CheckState.Checked;
            chk10000.Font = new Font("Segoe UI", 9.75F);
            chk10000.Location = new Point(190, 17);
            chk10000.Text = "10.000";
            chk10000.UseVisualStyleBackColor = true;
            chk10000.Name = "chk10000";
            // 
            // chk100000
            // 
            chk100000.AutoSize = true;
            chk100000.Checked = true;
            chk100000.CheckState = CheckState.Checked;
            chk100000.Font = new Font("Segoe UI", 9.75F);
            chk100000.Location = new Point(280, 17);
            chk100000.Text = "100.000";
            chk100000.UseVisualStyleBackColor = true;
            chk100000.Name = "chk100000";
            // 
            // lblConsultas
            // 
            lblConsultas.AutoSize = true;
            lblConsultas.Font = new Font("Segoe UI", 9F);
            lblConsultas.ForeColor = Color.FromArgb(107, 123, 113);
            lblConsultas.Location = new Point(380, 19);
            lblConsultas.Text = "Búsquedas:";
            lblConsultas.Name = "lblConsultas";
            // 
            // numConsultas
            // 
            numConsultas.Location = new Point(452, 15);
            numConsultas.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            numConsultas.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numConsultas.Size = new Size(80, 23);
            numConsultas.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            numConsultas.Font = new Font("Segoe UI", 9.75F);
            numConsultas.Name = "numConsultas";
            // 
            // btnEjecutar
            // 
            btnEjecutar.BackColor = Color.FromArgb(46, 125, 79);
            btnEjecutar.ForeColor = Color.White;
            btnEjecutar.FlatAppearance.BorderSize = 0;
            btnEjecutar.FlatStyle = FlatStyle.Flat;
            btnEjecutar.Cursor = Cursors.Hand;
            btnEjecutar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnEjecutar.Location = new Point(548, 11);
            btnEjecutar.Size = new Size(190, 34);
            btnEjecutar.Text = "Ejecutar comparación";
            btnEjecutar.UseVisualStyleBackColor = false;
            btnEjecutar.Name = "btnEjecutar";
            btnEjecutar.Click += btnEjecutar_Click;
            // 
            // progreso
            // 
            progreso.Location = new Point(750, 18);
            progreso.MarqueeAnimationSpeed = 30;
            progreso.Size = new Size(100, 20);
            progreso.Style = ProgressBarStyle.Marquee;
            progreso.Visible = false;
            progreso.Name = "progreso";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 9F);
            lblEstado.ForeColor = Color.FromArgb(107, 123, 113);
            lblEstado.Location = new Point(860, 19);
            lblEstado.Text = "";
            lblEstado.Name = "lblEstado";
            // 
            // pnlTabla
            // 
            pnlTabla.Controls.Add(dgvResultados);
            pnlTabla.BackColor = Color.White;
            pnlTabla.Location = new Point(16, 148);
            pnlTabla.Size = new Size(968, 200);
            pnlTabla.Name = "pnlTabla";
            // 
            // dgvResultados
            // 
            dgvResultados.AllowUserToAddRows = false;
            dgvResultados.AllowUserToDeleteRows = false;
            dgvResultados.AllowUserToResizeRows = false;
            dgvResultados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvResultados.BackgroundColor = Color.White;
            dgvResultados.BorderStyle = BorderStyle.None;
            dgvResultados.Location = new Point(12, 12);
            dgvResultados.MultiSelect = false;
            dgvResultados.ReadOnly = true;
            dgvResultados.RowHeadersVisible = false;
            dgvResultados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResultados.Size = new Size(944, 176);
            dgvResultados.Name = "dgvResultados";
            // 
            // pnlConclusion
            // 
            pnlConclusion.Controls.Add(lblConclusionTitulo);
            pnlConclusion.Controls.Add(txtConclusion);
            pnlConclusion.BackColor = Color.White;
            pnlConclusion.Location = new Point(16, 360);
            pnlConclusion.Size = new Size(968, 184);
            pnlConclusion.Name = "pnlConclusion";
            // 
            // lblConclusionTitulo
            // 
            lblConclusionTitulo.AutoSize = true;
            lblConclusionTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblConclusionTitulo.ForeColor = Color.FromArgb(30, 86, 49);
            lblConclusionTitulo.Location = new Point(16, 12);
            lblConclusionTitulo.Text = "Conclusiones";
            lblConclusionTitulo.Name = "lblConclusionTitulo";
            // 
            // txtConclusion
            // 
            txtConclusion.BackColor = Color.White;
            txtConclusion.BorderStyle = BorderStyle.None;
            txtConclusion.Font = new Font("Segoe UI", 9.75F);
            txtConclusion.ForeColor = Color.FromArgb(31, 45, 36);
            txtConclusion.Location = new Point(16, 40);
            txtConclusion.Multiline = true;
            txtConclusion.ReadOnly = true;
            txtConclusion.ScrollBars = ScrollBars.Vertical;
            txtConclusion.Size = new Size(936, 132);
            txtConclusion.Name = "txtConclusion";
            // 
            // FrRendimiento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 243);
            ClientSize = new Size(1000, 560);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Text = "Comparación de algoritmos";
            Controls.Add(pnlEncabezado);
            Controls.Add(pnlControles);
            Controls.Add(pnlTabla);
            Controls.Add(pnlConclusion);
            Name = "FrRendimiento";
            pnlConclusion.ResumeLayout(false);
            pnlConclusion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvResultados).EndInit();
            pnlTabla.ResumeLayout(false);
            pnlTabla.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numConsultas).EndInit();
            pnlControles.ResumeLayout(false);
            pnlControles.PerformLayout();
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlEncabezado;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Panel pnlControles;
        private Label lblTamanos;
        private CheckBox chk1000;
        private CheckBox chk10000;
        private CheckBox chk100000;
        private Label lblConsultas;
        private NumericUpDown numConsultas;
        private Button btnEjecutar;
        private ProgressBar progreso;
        private Label lblEstado;
        private Panel pnlTabla;
        private DataGridView dgvResultados;
        private Panel pnlConclusion;
        private Label lblConclusionTitulo;
        private TextBox txtConclusion;
    }
}
