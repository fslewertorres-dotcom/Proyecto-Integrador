namespace RutaCircular.Presentation
{
    partial class FrIndicadores
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
            pnlFiltros = new Panel();
            lblDesde = new Label();
            dtpDesde = new DateTimePicker();
            lblHasta = new Label();
            dtpHasta = new DateTimePicker();
            btnCalcular = new Button();
            pnlAprov = new Panel();
            pnlFranjaAprov = new Panel();
            lblAprovTitulo = new Label();
            lblAprovValor = new Label();
            lblAprovDetalle = new Label();
            pnlSost = new Panel();
            pnlFranjaSost = new Panel();
            lblSostTitulo = new Label();
            lblSostValor = new Label();
            lblSostDetalle = new Label();
            pnlEfic = new Panel();
            pnlFranjaEfic = new Panel();
            lblEficTitulo = new Label();
            lblEficValor = new Label();
            lblEficDetalle = new Label();
            pnlFrec = new Panel();
            pnlFranjaFrec = new Panel();
            lblFrecTitulo = new Label();
            lblFrecValor = new Label();
            lblFrecDetalle = new Label();
            pnlTabla = new Panel();
            lblTablaTitulo = new Label();
            dgvFrecuencia = new DataGridView();
            pnlRutas = new Panel();
            lblRutasTitulo = new Label();
            lblTradicional = new Label();
            lblOptimizada = new Label();
            lblComposicionTitulo = new Label();
            pnlBarras = new Panel();
            pnlBarraOrganico = new Panel();
            pnlBarraAprovechable = new Panel();
            pnlBarraNoAprovechable = new Panel();
            lblComposicion = new Label();
            pnlEncabezado.SuspendLayout();
            pnlFiltros.SuspendLayout();
            pnlAprov.SuspendLayout();
            pnlFranjaAprov.SuspendLayout();
            pnlSost.SuspendLayout();
            pnlFranjaSost.SuspendLayout();
            pnlEfic.SuspendLayout();
            pnlFranjaEfic.SuspendLayout();
            pnlFrec.SuspendLayout();
            pnlFranjaFrec.SuspendLayout();
            pnlTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFrecuencia).BeginInit();
            pnlRutas.SuspendLayout();
            pnlBarras.SuspendLayout();
            pnlBarraOrganico.SuspendLayout();
            pnlBarraAprovechable.SuspendLayout();
            pnlBarraNoAprovechable.SuspendLayout();
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
            lblTitulo.Text = "Indicadores de gestión";
            lblTitulo.Name = "lblTitulo";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9F);
            lblSubtitulo.ForeColor = Color.FromArgb(200, 230, 210);
            lblSubtitulo.Location = new Point(22, 40);
            lblSubtitulo.Text = "Aprovechamiento, sostenibilidad, eficiencia y frecuencia de la recolección";
            lblSubtitulo.Name = "lblSubtitulo";
            // 
            // pnlFiltros
            // 
            pnlFiltros.Controls.Add(lblDesde);
            pnlFiltros.Controls.Add(dtpDesde);
            pnlFiltros.Controls.Add(lblHasta);
            pnlFiltros.Controls.Add(dtpHasta);
            pnlFiltros.Controls.Add(btnCalcular);
            pnlFiltros.BackColor = Color.White;
            pnlFiltros.Location = new Point(16, 80);
            pnlFiltros.Size = new Size(968, 56);
            pnlFiltros.Name = "pnlFiltros";
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Font = new Font("Segoe UI", 9F);
            lblDesde.ForeColor = Color.FromArgb(107, 123, 113);
            lblDesde.Location = new Point(14, 19);
            lblDesde.Text = "Desde";
            lblDesde.Name = "lblDesde";
            // 
            // dtpDesde
            // 
            dtpDesde.Font = new Font("Segoe UI", 9.75F);
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(60, 15);
            dtpDesde.Size = new Size(120, 25);
            dtpDesde.Name = "dtpDesde";
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Font = new Font("Segoe UI", 9F);
            lblHasta.ForeColor = Color.FromArgb(107, 123, 113);
            lblHasta.Location = new Point(200, 19);
            lblHasta.Text = "Hasta";
            lblHasta.Name = "lblHasta";
            // 
            // dtpHasta
            // 
            dtpHasta.Font = new Font("Segoe UI", 9.75F);
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(244, 15);
            dtpHasta.Size = new Size(120, 25);
            dtpHasta.Name = "dtpHasta";
            // 
            // btnCalcular
            // 
            btnCalcular.BackColor = Color.FromArgb(46, 125, 79);
            btnCalcular.ForeColor = Color.White;
            btnCalcular.FlatAppearance.BorderSize = 0;
            btnCalcular.FlatStyle = FlatStyle.Flat;
            btnCalcular.Cursor = Cursors.Hand;
            btnCalcular.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnCalcular.Location = new Point(384, 11);
            btnCalcular.Size = new Size(180, 34);
            btnCalcular.Text = "Calcular indicadores";
            btnCalcular.UseVisualStyleBackColor = false;
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Click += btnCalcular_Click;
            // 
            // pnlAprov
            // 
            pnlAprov.Controls.Add(pnlFranjaAprov);
            pnlAprov.Controls.Add(lblAprovTitulo);
            pnlAprov.Controls.Add(lblAprovValor);
            pnlAprov.Controls.Add(lblAprovDetalle);
            pnlAprov.BackColor = Color.White;
            pnlAprov.Location = new Point(16, 148);
            pnlAprov.Size = new Size(232, 96);
            pnlAprov.Name = "pnlAprov";
            // 
            // pnlFranjaAprov
            // 
            pnlFranjaAprov.BackColor = Color.FromArgb(76, 175, 80);
            pnlFranjaAprov.Dock = DockStyle.Left;
            pnlFranjaAprov.Location = new Point(0, 0);
            pnlFranjaAprov.Size = new Size(6, 96);
            pnlFranjaAprov.Name = "pnlFranjaAprov";
            // 
            // lblAprovTitulo
            // 
            lblAprovTitulo.AutoSize = true;
            lblAprovTitulo.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblAprovTitulo.ForeColor = Color.FromArgb(107, 123, 113);
            lblAprovTitulo.Location = new Point(18, 10);
            lblAprovTitulo.Text = "APROVECHAMIENTO";
            lblAprovTitulo.Name = "lblAprovTitulo";
            // 
            // lblAprovValor
            // 
            lblAprovValor.AutoSize = true;
            lblAprovValor.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblAprovValor.ForeColor = Color.FromArgb(31, 45, 36);
            lblAprovValor.Location = new Point(16, 28);
            lblAprovValor.Text = "—";
            lblAprovValor.Name = "lblAprovValor";
            // 
            // lblAprovDetalle
            // 
            lblAprovDetalle.Font = new Font("Segoe UI", 8.25F);
            lblAprovDetalle.ForeColor = Color.FromArgb(107, 123, 113);
            lblAprovDetalle.Location = new Point(18, 66);
            lblAprovDetalle.Size = new Size(206, 20);
            lblAprovDetalle.Text = "";
            lblAprovDetalle.Name = "lblAprovDetalle";
            // 
            // pnlSost
            // 
            pnlSost.Controls.Add(pnlFranjaSost);
            pnlSost.Controls.Add(lblSostTitulo);
            pnlSost.Controls.Add(lblSostValor);
            pnlSost.Controls.Add(lblSostDetalle);
            pnlSost.BackColor = Color.White;
            pnlSost.Location = new Point(261, 148);
            pnlSost.Size = new Size(232, 96);
            pnlSost.Name = "pnlSost";
            // 
            // pnlFranjaSost
            // 
            pnlFranjaSost.BackColor = Color.FromArgb(46, 125, 79);
            pnlFranjaSost.Dock = DockStyle.Left;
            pnlFranjaSost.Location = new Point(0, 0);
            pnlFranjaSost.Size = new Size(6, 96);
            pnlFranjaSost.Name = "pnlFranjaSost";
            // 
            // lblSostTitulo
            // 
            lblSostTitulo.AutoSize = true;
            lblSostTitulo.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblSostTitulo.ForeColor = Color.FromArgb(107, 123, 113);
            lblSostTitulo.Location = new Point(18, 10);
            lblSostTitulo.Text = "SOSTENIBILIDAD";
            lblSostTitulo.Name = "lblSostTitulo";
            // 
            // lblSostValor
            // 
            lblSostValor.AutoSize = true;
            lblSostValor.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblSostValor.ForeColor = Color.FromArgb(31, 45, 36);
            lblSostValor.Location = new Point(16, 28);
            lblSostValor.Text = "—";
            lblSostValor.Name = "lblSostValor";
            // 
            // lblSostDetalle
            // 
            lblSostDetalle.Font = new Font("Segoe UI", 8.25F);
            lblSostDetalle.ForeColor = Color.FromArgb(107, 123, 113);
            lblSostDetalle.Location = new Point(18, 66);
            lblSostDetalle.Size = new Size(206, 20);
            lblSostDetalle.Text = "";
            lblSostDetalle.Name = "lblSostDetalle";
            // 
            // pnlEfic
            // 
            pnlEfic.Controls.Add(pnlFranjaEfic);
            pnlEfic.Controls.Add(lblEficTitulo);
            pnlEfic.Controls.Add(lblEficValor);
            pnlEfic.Controls.Add(lblEficDetalle);
            pnlEfic.BackColor = Color.White;
            pnlEfic.Location = new Point(506, 148);
            pnlEfic.Size = new Size(232, 96);
            pnlEfic.Name = "pnlEfic";
            // 
            // pnlFranjaEfic
            // 
            pnlFranjaEfic.BackColor = Color.FromArgb(242, 159, 5);
            pnlFranjaEfic.Dock = DockStyle.Left;
            pnlFranjaEfic.Location = new Point(0, 0);
            pnlFranjaEfic.Size = new Size(6, 96);
            pnlFranjaEfic.Name = "pnlFranjaEfic";
            // 
            // lblEficTitulo
            // 
            lblEficTitulo.AutoSize = true;
            lblEficTitulo.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblEficTitulo.ForeColor = Color.FromArgb(107, 123, 113);
            lblEficTitulo.Location = new Point(18, 10);
            lblEficTitulo.Text = "EFICIENCIA DE LA RUTA";
            lblEficTitulo.Name = "lblEficTitulo";
            // 
            // lblEficValor
            // 
            lblEficValor.AutoSize = true;
            lblEficValor.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblEficValor.ForeColor = Color.FromArgb(31, 45, 36);
            lblEficValor.Location = new Point(16, 28);
            lblEficValor.Text = "—";
            lblEficValor.Name = "lblEficValor";
            // 
            // lblEficDetalle
            // 
            lblEficDetalle.Font = new Font("Segoe UI", 8.25F);
            lblEficDetalle.ForeColor = Color.FromArgb(107, 123, 113);
            lblEficDetalle.Location = new Point(18, 66);
            lblEficDetalle.Size = new Size(206, 20);
            lblEficDetalle.Text = "";
            lblEficDetalle.Name = "lblEficDetalle";
            // 
            // pnlFrec
            // 
            pnlFrec.Controls.Add(pnlFranjaFrec);
            pnlFrec.Controls.Add(lblFrecTitulo);
            pnlFrec.Controls.Add(lblFrecValor);
            pnlFrec.Controls.Add(lblFrecDetalle);
            pnlFrec.BackColor = Color.White;
            pnlFrec.Location = new Point(751, 148);
            pnlFrec.Size = new Size(232, 96);
            pnlFrec.Name = "pnlFrec";
            // 
            // pnlFranjaFrec
            // 
            pnlFranjaFrec.BackColor = Color.FromArgb(47, 102, 144);
            pnlFranjaFrec.Dock = DockStyle.Left;
            pnlFranjaFrec.Location = new Point(0, 0);
            pnlFranjaFrec.Size = new Size(6, 96);
            pnlFranjaFrec.Name = "pnlFranjaFrec";
            // 
            // lblFrecTitulo
            // 
            lblFrecTitulo.AutoSize = true;
            lblFrecTitulo.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblFrecTitulo.ForeColor = Color.FromArgb(107, 123, 113);
            lblFrecTitulo.Location = new Point(18, 10);
            lblFrecTitulo.Text = "FRECUENCIA";
            lblFrecTitulo.Name = "lblFrecTitulo";
            // 
            // lblFrecValor
            // 
            lblFrecValor.AutoSize = true;
            lblFrecValor.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblFrecValor.ForeColor = Color.FromArgb(31, 45, 36);
            lblFrecValor.Location = new Point(16, 28);
            lblFrecValor.Text = "—";
            lblFrecValor.Name = "lblFrecValor";
            // 
            // lblFrecDetalle
            // 
            lblFrecDetalle.Font = new Font("Segoe UI", 8.25F);
            lblFrecDetalle.ForeColor = Color.FromArgb(107, 123, 113);
            lblFrecDetalle.Location = new Point(18, 66);
            lblFrecDetalle.Size = new Size(206, 20);
            lblFrecDetalle.Text = "";
            lblFrecDetalle.Name = "lblFrecDetalle";
            // 
            // pnlTabla
            // 
            pnlTabla.Controls.Add(lblTablaTitulo);
            pnlTabla.Controls.Add(dgvFrecuencia);
            pnlTabla.BackColor = Color.White;
            pnlTabla.Location = new Point(16, 256);
            pnlTabla.Size = new Size(560, 288);
            pnlTabla.Name = "pnlTabla";
            // 
            // lblTablaTitulo
            // 
            lblTablaTitulo.AutoSize = true;
            lblTablaTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTablaTitulo.ForeColor = Color.FromArgb(30, 86, 49);
            lblTablaTitulo.Location = new Point(16, 12);
            lblTablaTitulo.Text = "Recolecciones por punto";
            lblTablaTitulo.Name = "lblTablaTitulo";
            // 
            // dgvFrecuencia
            // 
            dgvFrecuencia.AllowUserToAddRows = false;
            dgvFrecuencia.AllowUserToDeleteRows = false;
            dgvFrecuencia.AllowUserToResizeRows = false;
            dgvFrecuencia.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFrecuencia.BackgroundColor = Color.White;
            dgvFrecuencia.BorderStyle = BorderStyle.None;
            dgvFrecuencia.Location = new Point(14, 44);
            dgvFrecuencia.MultiSelect = false;
            dgvFrecuencia.ReadOnly = true;
            dgvFrecuencia.RowHeadersVisible = false;
            dgvFrecuencia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFrecuencia.Size = new Size(532, 232);
            dgvFrecuencia.Name = "dgvFrecuencia";
            // 
            // pnlRutas
            // 
            pnlRutas.Controls.Add(lblRutasTitulo);
            pnlRutas.Controls.Add(lblTradicional);
            pnlRutas.Controls.Add(lblOptimizada);
            pnlRutas.Controls.Add(lblComposicionTitulo);
            pnlRutas.Controls.Add(pnlBarras);
            pnlRutas.Controls.Add(lblComposicion);
            pnlRutas.BackColor = Color.White;
            pnlRutas.Location = new Point(592, 256);
            pnlRutas.Size = new Size(392, 288);
            pnlRutas.Name = "pnlRutas";
            // 
            // lblRutasTitulo
            // 
            lblRutasTitulo.AutoSize = true;
            lblRutasTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRutasTitulo.ForeColor = Color.FromArgb(30, 86, 49);
            lblRutasTitulo.Location = new Point(16, 12);
            lblRutasTitulo.Text = "Ruta de hoy vs. ronda tradicional";
            lblRutasTitulo.Name = "lblRutasTitulo";
            // 
            // lblTradicional
            // 
            lblTradicional.Font = new Font("Segoe UI", 9.75F);
            lblTradicional.ForeColor = Color.FromArgb(31, 45, 36);
            lblTradicional.Location = new Point(16, 44);
            lblTradicional.Size = new Size(360, 40);
            lblTradicional.Text = "";
            lblTradicional.Name = "lblTradicional";
            // 
            // lblOptimizada
            // 
            lblOptimizada.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            lblOptimizada.ForeColor = Color.FromArgb(30, 86, 49);
            lblOptimizada.Location = new Point(16, 88);
            lblOptimizada.Size = new Size(360, 40);
            lblOptimizada.Text = "";
            lblOptimizada.Name = "lblOptimizada";
            // 
            // lblComposicionTitulo
            // 
            lblComposicionTitulo.AutoSize = true;
            lblComposicionTitulo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblComposicionTitulo.ForeColor = Color.FromArgb(30, 86, 49);
            lblComposicionTitulo.Location = new Point(16, 150);
            lblComposicionTitulo.Text = "Composición de lo recogido";
            lblComposicionTitulo.Name = "lblComposicionTitulo";
            // 
            // pnlBarras
            // 
            pnlBarras.Controls.Add(pnlBarraOrganico);
            pnlBarras.Controls.Add(pnlBarraAprovechable);
            pnlBarras.Controls.Add(pnlBarraNoAprovechable);
            pnlBarras.BackColor = Color.FromArgb(222, 230, 224);
            pnlBarras.Location = new Point(16, 182);
            pnlBarras.Size = new Size(360, 26);
            pnlBarras.Name = "pnlBarras";
            // 
            // pnlBarraOrganico
            // 
            pnlBarraOrganico.BackColor = Color.FromArgb(76, 175, 80);
            pnlBarraOrganico.Location = new Point(0, 0);
            pnlBarraOrganico.Size = new Size(0, 26);
            pnlBarraOrganico.Name = "pnlBarraOrganico";
            // 
            // pnlBarraAprovechable
            // 
            pnlBarraAprovechable.BackColor = Color.FromArgb(176, 190, 182);
            pnlBarraAprovechable.Location = new Point(0, 0);
            pnlBarraAprovechable.Size = new Size(0, 26);
            pnlBarraAprovechable.Name = "pnlBarraAprovechable";
            // 
            // pnlBarraNoAprovechable
            // 
            pnlBarraNoAprovechable.BackColor = Color.FromArgb(58, 63, 60);
            pnlBarraNoAprovechable.Location = new Point(0, 0);
            pnlBarraNoAprovechable.Size = new Size(0, 26);
            pnlBarraNoAprovechable.Name = "pnlBarraNoAprovechable";
            // 
            // lblComposicion
            // 
            lblComposicion.Font = new Font("Segoe UI", 9F);
            lblComposicion.ForeColor = Color.FromArgb(107, 123, 113);
            lblComposicion.Location = new Point(16, 216);
            lblComposicion.Size = new Size(360, 60);
            lblComposicion.Text = "";
            lblComposicion.Name = "lblComposicion";
            // 
            // FrIndicadores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 243);
            ClientSize = new Size(1000, 560);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Text = "Indicadores de gestión";
            Controls.Add(pnlEncabezado);
            Controls.Add(pnlFiltros);
            Controls.Add(pnlAprov);
            Controls.Add(pnlSost);
            Controls.Add(pnlEfic);
            Controls.Add(pnlFrec);
            Controls.Add(pnlTabla);
            Controls.Add(pnlRutas);
            Name = "FrIndicadores";
            Load += FrIndicadores_Load;
            pnlBarraNoAprovechable.ResumeLayout(false);
            pnlBarraNoAprovechable.PerformLayout();
            pnlBarraAprovechable.ResumeLayout(false);
            pnlBarraAprovechable.PerformLayout();
            pnlBarraOrganico.ResumeLayout(false);
            pnlBarraOrganico.PerformLayout();
            pnlBarras.ResumeLayout(false);
            pnlBarras.PerformLayout();
            pnlRutas.ResumeLayout(false);
            pnlRutas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFrecuencia).EndInit();
            pnlTabla.ResumeLayout(false);
            pnlTabla.PerformLayout();
            pnlFranjaFrec.ResumeLayout(false);
            pnlFranjaFrec.PerformLayout();
            pnlFrec.ResumeLayout(false);
            pnlFrec.PerformLayout();
            pnlFranjaEfic.ResumeLayout(false);
            pnlFranjaEfic.PerformLayout();
            pnlEfic.ResumeLayout(false);
            pnlEfic.PerformLayout();
            pnlFranjaSost.ResumeLayout(false);
            pnlFranjaSost.PerformLayout();
            pnlSost.ResumeLayout(false);
            pnlSost.PerformLayout();
            pnlFranjaAprov.ResumeLayout(false);
            pnlFranjaAprov.PerformLayout();
            pnlAprov.ResumeLayout(false);
            pnlAprov.PerformLayout();
            pnlFiltros.ResumeLayout(false);
            pnlFiltros.PerformLayout();
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlEncabezado;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Panel pnlFiltros;
        private Label lblDesde;
        private DateTimePicker dtpDesde;
        private Label lblHasta;
        private DateTimePicker dtpHasta;
        private Button btnCalcular;
        private Panel pnlAprov;
        private Panel pnlFranjaAprov;
        private Label lblAprovTitulo;
        private Label lblAprovValor;
        private Label lblAprovDetalle;
        private Panel pnlSost;
        private Panel pnlFranjaSost;
        private Label lblSostTitulo;
        private Label lblSostValor;
        private Label lblSostDetalle;
        private Panel pnlEfic;
        private Panel pnlFranjaEfic;
        private Label lblEficTitulo;
        private Label lblEficValor;
        private Label lblEficDetalle;
        private Panel pnlFrec;
        private Panel pnlFranjaFrec;
        private Label lblFrecTitulo;
        private Label lblFrecValor;
        private Label lblFrecDetalle;
        private Panel pnlTabla;
        private Label lblTablaTitulo;
        private DataGridView dgvFrecuencia;
        private Panel pnlRutas;
        private Label lblRutasTitulo;
        private Label lblTradicional;
        private Label lblOptimizada;
        private Label lblComposicionTitulo;
        private Panel pnlBarras;
        private Panel pnlBarraOrganico;
        private Panel pnlBarraAprovechable;
        private Panel pnlBarraNoAprovechable;
        private Label lblComposicion;
    }
}
