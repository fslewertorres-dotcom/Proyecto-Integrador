namespace EcoResiduos.Presentation
{
    partial class FrCalculos
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
            tabs = new TabControl();
            tabPrediccion = new TabPage();
            tabGradiente = new TabPage();
            lblInstruccion = new Label();
            cbContenedor = new ComboBox();
            btnPredecir = new Button();
            pnlResultado = new Panel();
            lblResultadoTitulo = new Label();
            lblResultadoValor = new Label();
            lblResultadoFecha = new Label();
            lblComparacion = new Label();
            pnlNivel = new Panel();
            lblNivelTitulo = new Label();
            pnlNivelBarra = new Panel();
            pnlNivelRelleno = new Panel();
            lblNivelTexto = new Label();
            lblExplicacion = new Label();
            pnlGrafico = new Panel();
            graficoNivel = new GraficoNivel();
            lblInstruccion2 = new Label();
            cbAlcance = new ComboBox();
            btnOptimizar = new Button();
            btnVerMapa = new Button();
            btnQuitarOptimos = new Button();
            btnUsarUbicacion = new Button();
            btnVolverOriginal = new Button();
            pnlActual = new Panel();
            lblActualTitulo = new Label();
            lblActualValor = new Label();
            lblActualDetalle = new Label();
            pnlOptima = new Panel();
            lblOptimaTitulo = new Label();
            lblOptimaValor = new Label();
            lblOptimaDetalle = new Label();
            pnlAhorro = new Panel();
            lblAhorroTitulo = new Label();
            lblAhorroValor = new Label();
            lblAhorroDetalle = new Label();
            lblExplicacionGradiente = new Label();
            pnlEncabezado.SuspendLayout();
            tabs.SuspendLayout();
            tabPrediccion.SuspendLayout();
            tabGradiente.SuspendLayout();
            pnlResultado.SuspendLayout();
            pnlNivel.SuspendLayout();
            pnlNivelBarra.SuspendLayout();
            pnlNivelRelleno.SuspendLayout();
            pnlGrafico.SuspendLayout();
            pnlActual.SuspendLayout();
            pnlOptima.SuspendLayout();
            pnlAhorro.SuspendLayout();
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
            lblTitulo.Text = "Módulo de cálculo";
            lblTitulo.Name = "lblTitulo";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9F);
            lblSubtitulo.ForeColor = Color.FromArgb(200, 230, 210);
            lblSubtitulo.Location = new Point(22, 40);
            lblSubtitulo.Text = "Predicción de llenado y ubicación óptima de los puntos ecológicos";
            lblSubtitulo.Name = "lblSubtitulo";
            // 
            // tabs
            // 
            tabs.Controls.Add(tabPrediccion);
            tabs.Controls.Add(tabGradiente);
            tabs.Font = new Font("Segoe UI", 9.75F);
            tabs.Location = new Point(16, 80);
            tabs.Padding = new Point(14, 6);
            tabs.Size = new Size(968, 464);
            tabs.Name = "tabs";
            // 
            // tabPrediccion
            // 
            tabPrediccion.Controls.Add(lblInstruccion);
            tabPrediccion.Controls.Add(cbContenedor);
            tabPrediccion.Controls.Add(btnPredecir);
            tabPrediccion.Controls.Add(pnlResultado);
            tabPrediccion.Controls.Add(pnlNivel);
            tabPrediccion.Controls.Add(pnlGrafico);
            tabPrediccion.BackColor = Color.FromArgb(244, 247, 243);
            tabPrediccion.Location = new Point(4, 32);
            tabPrediccion.Size = new Size(960, 428);
            tabPrediccion.Text = "Predicción de llenado";
            tabPrediccion.Name = "tabPrediccion";
            // 
            // tabGradiente
            // 
            tabGradiente.Controls.Add(lblInstruccion2);
            tabGradiente.Controls.Add(cbAlcance);
            tabGradiente.Controls.Add(btnOptimizar);
            tabGradiente.Controls.Add(btnVerMapa);
            tabGradiente.Controls.Add(btnQuitarOptimos);
            tabGradiente.Controls.Add(pnlActual);
            tabGradiente.Controls.Add(pnlOptima);
            tabGradiente.Controls.Add(pnlAhorro);
            tabGradiente.Controls.Add(lblExplicacionGradiente);
            tabGradiente.Controls.Add(btnUsarUbicacion);
            tabGradiente.Controls.Add(btnVolverOriginal);
            tabGradiente.BackColor = Color.FromArgb(244, 247, 243);
            tabGradiente.Location = new Point(4, 32);
            tabGradiente.Size = new Size(960, 428);
            tabGradiente.Text = "Ubicación óptima";
            tabGradiente.Name = "tabGradiente";
            // 
            // lblInstruccion
            // 
            lblInstruccion.AutoSize = true;
            lblInstruccion.Font = new Font("Segoe UI", 9.75F);
            lblInstruccion.ForeColor = Color.FromArgb(31, 45, 36);
            lblInstruccion.Location = new Point(14, 14);
            lblInstruccion.Text = "Elija un contenedor para saber cuándo se va a llenar.";
            lblInstruccion.Name = "lblInstruccion";
            // 
            // cbContenedor
            // 
            cbContenedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbContenedor.FlatStyle = FlatStyle.Flat;
            cbContenedor.Font = new Font("Segoe UI", 9.75F);
            cbContenedor.Location = new Point(16, 40);
            cbContenedor.Size = new Size(420, 25);
            cbContenedor.Name = "cbContenedor";
            // 
            // btnPredecir
            // 
            btnPredecir.BackColor = Color.FromArgb(46, 125, 79);
            btnPredecir.ForeColor = Color.White;
            btnPredecir.FlatAppearance.BorderSize = 0;
            btnPredecir.FlatStyle = FlatStyle.Flat;
            btnPredecir.Cursor = Cursors.Hand;
            btnPredecir.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnPredecir.Location = new Point(452, 36);
            btnPredecir.Size = new Size(140, 34);
            btnPredecir.Text = "Predecir";
            btnPredecir.UseVisualStyleBackColor = false;
            btnPredecir.Name = "btnPredecir";
            btnPredecir.Click += btnPredecir_Click;
            // 
            // pnlResultado
            // 
            pnlResultado.Controls.Add(lblResultadoTitulo);
            pnlResultado.Controls.Add(lblResultadoValor);
            pnlResultado.Controls.Add(lblResultadoFecha);
            pnlResultado.Controls.Add(lblComparacion);
            pnlResultado.BackColor = Color.FromArgb(232, 243, 236);
            pnlResultado.Location = new Point(16, 84);
            pnlResultado.Size = new Size(420, 150);
            pnlResultado.Name = "pnlResultado";
            // 
            // lblResultadoTitulo
            // 
            lblResultadoTitulo.AutoSize = true;
            lblResultadoTitulo.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblResultadoTitulo.ForeColor = Color.FromArgb(107, 123, 113);
            lblResultadoTitulo.Location = new Point(16, 12);
            lblResultadoTitulo.Text = "SE LLENA EN";
            lblResultadoTitulo.Name = "lblResultadoTitulo";
            // 
            // lblResultadoValor
            // 
            lblResultadoValor.AutoSize = true;
            lblResultadoValor.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblResultadoValor.ForeColor = Color.FromArgb(30, 86, 49);
            lblResultadoValor.Location = new Point(14, 30);
            lblResultadoValor.Text = "—";
            lblResultadoValor.Name = "lblResultadoValor";
            // 
            // lblResultadoFecha
            // 
            lblResultadoFecha.Font = new Font("Segoe UI", 9.75F);
            lblResultadoFecha.ForeColor = Color.FromArgb(31, 45, 36);
            lblResultadoFecha.Location = new Point(16, 80);
            lblResultadoFecha.Size = new Size(390, 20);
            lblResultadoFecha.Text = "";
            lblResultadoFecha.Name = "lblResultadoFecha";
            // 
            // lblComparacion
            // 
            lblComparacion.Font = new Font("Segoe UI", 8.25F);
            lblComparacion.ForeColor = Color.FromArgb(107, 123, 113);
            lblComparacion.Location = new Point(16, 106);
            lblComparacion.Size = new Size(390, 36);
            lblComparacion.Text = "";
            lblComparacion.Name = "lblComparacion";
            // 
            // pnlNivel
            // 
            pnlNivel.Controls.Add(lblNivelTitulo);
            pnlNivel.Controls.Add(pnlNivelBarra);
            pnlNivel.Controls.Add(lblNivelTexto);
            pnlNivel.Controls.Add(lblExplicacion);
            pnlNivel.BackColor = Color.White;
            pnlNivel.Location = new Point(16, 246);
            pnlNivel.Size = new Size(420, 170);
            pnlNivel.Name = "pnlNivel";
            // 
            // lblNivelTitulo
            // 
            lblNivelTitulo.AutoSize = true;
            lblNivelTitulo.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblNivelTitulo.ForeColor = Color.FromArgb(107, 123, 113);
            lblNivelTitulo.Location = new Point(16, 12);
            lblNivelTitulo.Text = "NIVEL ACTUAL";
            lblNivelTitulo.Name = "lblNivelTitulo";
            // 
            // pnlNivelBarra
            // 
            pnlNivelBarra.Controls.Add(pnlNivelRelleno);
            pnlNivelBarra.BackColor = Color.FromArgb(222, 230, 224);
            pnlNivelBarra.Location = new Point(16, 36);
            pnlNivelBarra.Size = new Size(388, 24);
            pnlNivelBarra.Name = "pnlNivelBarra";
            // 
            // pnlNivelRelleno
            // 
            pnlNivelRelleno.BackColor = Color.FromArgb(46, 125, 79);
            pnlNivelRelleno.Location = new Point(0, 0);
            pnlNivelRelleno.Size = new Size(0, 24);
            pnlNivelRelleno.Name = "pnlNivelRelleno";
            // 
            // lblNivelTexto
            // 
            lblNivelTexto.Font = new Font("Segoe UI", 9.75F);
            lblNivelTexto.ForeColor = Color.FromArgb(31, 45, 36);
            lblNivelTexto.Location = new Point(16, 66);
            lblNivelTexto.Size = new Size(388, 20);
            lblNivelTexto.Text = "";
            lblNivelTexto.Name = "lblNivelTexto";
            // 
            // lblExplicacion
            // 
            lblExplicacion.Font = new Font("Segoe UI", 8.25F);
            lblExplicacion.ForeColor = Color.FromArgb(107, 123, 113);
            lblExplicacion.Location = new Point(16, 98);
            lblExplicacion.Size = new Size(388, 60);
            lblExplicacion.Text = "¿Cómo se calcula? Se suma hora a hora la basura que cae en el contenedor (una integral), porque en las horas pico se llena más rápido.";
            lblExplicacion.Name = "lblExplicacion";
            // 
            // pnlGrafico
            // 
            pnlGrafico.Controls.Add(graficoNivel);
            pnlGrafico.BackColor = Color.White;
            pnlGrafico.Location = new Point(452, 80);
            pnlGrafico.Size = new Size(492, 336);
            pnlGrafico.Name = "pnlGrafico";
            // 
            // graficoNivel
            // 
            graficoNivel.BackColor = Color.White;
            graficoNivel.Dock = DockStyle.Fill;
            graficoNivel.Location = new Point(0, 0);
            graficoNivel.Size = new Size(492, 336);
            graficoNivel.Name = "graficoNivel";
            // 
            // lblInstruccion2
            // 
            lblInstruccion2.AutoSize = true;
            lblInstruccion2.Font = new Font("Segoe UI", 9.75F);
            lblInstruccion2.ForeColor = Color.FromArgb(31, 45, 36);
            lblInstruccion2.Location = new Point(14, 14);
            lblInstruccion2.Text = "¿Dónde conviene poner el punto ecológico para que los vecinos caminen lo menos posible?";
            lblInstruccion2.Name = "lblInstruccion2";
            // 
            // cbAlcance
            // 
            cbAlcance.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAlcance.FlatStyle = FlatStyle.Flat;
            cbAlcance.Font = new Font("Segoe UI", 9.75F);
            cbAlcance.Location = new Point(16, 40);
            cbAlcance.Size = new Size(260, 25);
            cbAlcance.Name = "cbAlcance";
            // 
            // btnOptimizar
            // 
            btnOptimizar.BackColor = Color.FromArgb(46, 125, 79);
            btnOptimizar.ForeColor = Color.White;
            btnOptimizar.FlatAppearance.BorderSize = 0;
            btnOptimizar.FlatStyle = FlatStyle.Flat;
            btnOptimizar.Cursor = Cursors.Hand;
            btnOptimizar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnOptimizar.Location = new Point(286, 36);
            btnOptimizar.Size = new Size(130, 34);
            btnOptimizar.Text = "Calcular";
            btnOptimizar.UseVisualStyleBackColor = false;
            btnOptimizar.Name = "btnOptimizar";
            btnOptimizar.Click += btnOptimizar_Click;
            // 
            // btnVerMapa
            // 
            btnVerMapa.BackColor = Color.White;
            btnVerMapa.ForeColor = Color.FromArgb(30, 86, 49);
            btnVerMapa.FlatAppearance.BorderColor = Color.FromArgb(46, 125, 79);
            btnVerMapa.FlatStyle = FlatStyle.Flat;
            btnVerMapa.Cursor = Cursors.Hand;
            btnVerMapa.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnVerMapa.Location = new Point(424, 36);
            btnVerMapa.Size = new Size(140, 34);
            btnVerMapa.Text = "Ver en el mapa";
            btnVerMapa.UseVisualStyleBackColor = false;
            btnVerMapa.Name = "btnVerMapa";
            btnVerMapa.Click += btnVerMapa_Click;
            // 
            // btnQuitarOptimos
            // 
            btnQuitarOptimos.BackColor = Color.White;
            btnQuitarOptimos.ForeColor = Color.FromArgb(30, 86, 49);
            btnQuitarOptimos.FlatAppearance.BorderColor = Color.FromArgb(46, 125, 79);
            btnQuitarOptimos.FlatStyle = FlatStyle.Flat;
            btnQuitarOptimos.Cursor = Cursors.Hand;
            btnQuitarOptimos.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnQuitarOptimos.Location = new Point(572, 36);
            btnQuitarOptimos.Size = new Size(140, 34);
            btnQuitarOptimos.Text = "Quitar del mapa";
            btnQuitarOptimos.UseVisualStyleBackColor = false;
            btnQuitarOptimos.Name = "btnQuitarOptimos";
            btnQuitarOptimos.Click += btnQuitarOptimos_Click;
            // 
            // pnlActual
            // 
            pnlActual.Controls.Add(lblActualTitulo);
            pnlActual.Controls.Add(lblActualValor);
            pnlActual.Controls.Add(lblActualDetalle);
            pnlActual.BackColor = Color.White;
            pnlActual.Location = new Point(16, 92);
            pnlActual.Size = new Size(300, 130);
            pnlActual.Name = "pnlActual";
            // 
            // lblActualTitulo
            // 
            lblActualTitulo.AutoSize = true;
            lblActualTitulo.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblActualTitulo.ForeColor = Color.FromArgb(107, 123, 113);
            lblActualTitulo.Location = new Point(16, 12);
            lblActualTitulo.Text = "UBICACIÓN ACTUAL";
            lblActualTitulo.Name = "lblActualTitulo";
            // 
            // lblActualValor
            // 
            lblActualValor.AutoSize = true;
            lblActualValor.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblActualValor.ForeColor = Color.FromArgb(31, 45, 36);
            lblActualValor.Location = new Point(14, 32);
            lblActualValor.Text = "—";
            lblActualValor.Name = "lblActualValor";
            // 
            // lblActualDetalle
            // 
            lblActualDetalle.Font = new Font("Segoe UI", 9F);
            lblActualDetalle.ForeColor = Color.FromArgb(107, 123, 113);
            lblActualDetalle.Location = new Point(16, 80);
            lblActualDetalle.Size = new Size(270, 40);
            lblActualDetalle.Text = "";
            lblActualDetalle.Name = "lblActualDetalle";
            // 
            // pnlOptima
            // 
            pnlOptima.Controls.Add(lblOptimaTitulo);
            pnlOptima.Controls.Add(lblOptimaValor);
            pnlOptima.Controls.Add(lblOptimaDetalle);
            pnlOptima.BackColor = Color.FromArgb(232, 243, 236);
            pnlOptima.Location = new Point(328, 92);
            pnlOptima.Size = new Size(300, 130);
            pnlOptima.Name = "pnlOptima";
            // 
            // lblOptimaTitulo
            // 
            lblOptimaTitulo.AutoSize = true;
            lblOptimaTitulo.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblOptimaTitulo.ForeColor = Color.FromArgb(107, 123, 113);
            lblOptimaTitulo.Location = new Point(16, 12);
            lblOptimaTitulo.Text = "UBICACIÓN ÓPTIMA";
            lblOptimaTitulo.Name = "lblOptimaTitulo";
            // 
            // lblOptimaValor
            // 
            lblOptimaValor.AutoSize = true;
            lblOptimaValor.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblOptimaValor.ForeColor = Color.FromArgb(30, 86, 49);
            lblOptimaValor.Location = new Point(14, 32);
            lblOptimaValor.Text = "—";
            lblOptimaValor.Name = "lblOptimaValor";
            // 
            // lblOptimaDetalle
            // 
            lblOptimaDetalle.Font = new Font("Segoe UI", 9F);
            lblOptimaDetalle.ForeColor = Color.FromArgb(107, 123, 113);
            lblOptimaDetalle.Location = new Point(16, 80);
            lblOptimaDetalle.Size = new Size(270, 40);
            lblOptimaDetalle.Text = "";
            lblOptimaDetalle.Name = "lblOptimaDetalle";
            // 
            // pnlAhorro
            // 
            pnlAhorro.Controls.Add(lblAhorroTitulo);
            pnlAhorro.Controls.Add(lblAhorroValor);
            pnlAhorro.Controls.Add(lblAhorroDetalle);
            pnlAhorro.BackColor = Color.White;
            pnlAhorro.Location = new Point(640, 92);
            pnlAhorro.Size = new Size(300, 130);
            pnlAhorro.Name = "pnlAhorro";
            // 
            // lblAhorroTitulo
            // 
            lblAhorroTitulo.AutoSize = true;
            lblAhorroTitulo.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblAhorroTitulo.ForeColor = Color.FromArgb(107, 123, 113);
            lblAhorroTitulo.Location = new Point(16, 12);
            lblAhorroTitulo.Text = "CADA HOGAR CAMINA";
            lblAhorroTitulo.Name = "lblAhorroTitulo";
            // 
            // lblAhorroValor
            // 
            lblAhorroValor.AutoSize = true;
            lblAhorroValor.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblAhorroValor.ForeColor = Color.FromArgb(30, 86, 49);
            lblAhorroValor.Location = new Point(14, 32);
            lblAhorroValor.Text = "—";
            lblAhorroValor.Name = "lblAhorroValor";
            // 
            // lblAhorroDetalle
            // 
            lblAhorroDetalle.Font = new Font("Segoe UI", 9F);
            lblAhorroDetalle.ForeColor = Color.FromArgb(107, 123, 113);
            lblAhorroDetalle.Location = new Point(16, 80);
            lblAhorroDetalle.Size = new Size(270, 40);
            lblAhorroDetalle.Text = "";
            lblAhorroDetalle.Name = "lblAhorroDetalle";
            // 
            // lblExplicacionGradiente
            // 
            lblExplicacionGradiente.Font = new Font("Segoe UI", 9F);
            lblExplicacionGradiente.ForeColor = Color.FromArgb(107, 123, 113);
            lblExplicacionGradiente.Location = new Point(16, 240);
            lblExplicacionGradiente.Size = new Size(920, 40);
            lblExplicacionGradiente.Text = "¿Cómo se calcula? Se parte de la ubicación actual y se avanza paso a paso en la dirección en que la distancia total baja más rápido (método del gradiente), hasta que ya no se puede mejorar.";
            lblExplicacionGradiente.Name = "lblExplicacionGradiente";
            // 
            // btnUsarUbicacion
            // 
            btnUsarUbicacion.BackColor = Color.FromArgb(46, 125, 79);
            btnUsarUbicacion.ForeColor = Color.White;
            btnUsarUbicacion.FlatAppearance.BorderSize = 0;
            btnUsarUbicacion.FlatStyle = FlatStyle.Flat;
            btnUsarUbicacion.Cursor = Cursors.Hand;
            btnUsarUbicacion.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnUsarUbicacion.Location = new Point(16, 292);
            btnUsarUbicacion.Size = new Size(190, 34);
            btnUsarUbicacion.Text = "Usar esta ubicación";
            btnUsarUbicacion.UseVisualStyleBackColor = false;
            btnUsarUbicacion.Enabled = false;
            btnUsarUbicacion.Name = "btnUsarUbicacion";
            btnUsarUbicacion.Click += btnUsarUbicacion_Click;
            // 
            // btnVolverOriginal
            // 
            btnVolverOriginal.BackColor = Color.White;
            btnVolverOriginal.ForeColor = Color.FromArgb(30, 86, 49);
            btnVolverOriginal.FlatAppearance.BorderColor = Color.FromArgb(46, 125, 79);
            btnVolverOriginal.FlatStyle = FlatStyle.Flat;
            btnVolverOriginal.Cursor = Cursors.Hand;
            btnVolverOriginal.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnVolverOriginal.Location = new Point(214, 292);
            btnVolverOriginal.Size = new Size(190, 34);
            btnVolverOriginal.Text = "Volver a la original";
            btnVolverOriginal.UseVisualStyleBackColor = false;
            btnVolverOriginal.Enabled = false;
            btnVolverOriginal.Name = "btnVolverOriginal";
            btnVolverOriginal.Click += btnVolverOriginal_Click;
            // 
            // FrCalculos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 243);
            ClientSize = new Size(1000, 560);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Text = "Módulo de cálculo";
            Controls.Add(pnlEncabezado);
            Controls.Add(tabs);
            Name = "FrCalculos";
            pnlAhorro.ResumeLayout(false);
            pnlAhorro.PerformLayout();
            pnlOptima.ResumeLayout(false);
            pnlOptima.PerformLayout();
            pnlActual.ResumeLayout(false);
            pnlActual.PerformLayout();
            pnlGrafico.ResumeLayout(false);
            pnlGrafico.PerformLayout();
            pnlNivelRelleno.ResumeLayout(false);
            pnlNivelRelleno.PerformLayout();
            pnlNivelBarra.ResumeLayout(false);
            pnlNivelBarra.PerformLayout();
            pnlNivel.ResumeLayout(false);
            pnlNivel.PerformLayout();
            pnlResultado.ResumeLayout(false);
            pnlResultado.PerformLayout();
            tabGradiente.ResumeLayout(false);
            tabGradiente.PerformLayout();
            tabPrediccion.ResumeLayout(false);
            tabPrediccion.PerformLayout();
            tabs.ResumeLayout(false);
            tabs.PerformLayout();
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlEncabezado;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private TabControl tabs;
        private TabPage tabPrediccion;
        private TabPage tabGradiente;
        private Label lblInstruccion;
        private ComboBox cbContenedor;
        private Button btnPredecir;
        private Panel pnlResultado;
        private Label lblResultadoTitulo;
        private Label lblResultadoValor;
        private Label lblResultadoFecha;
        private Label lblComparacion;
        private Panel pnlNivel;
        private Label lblNivelTitulo;
        private Panel pnlNivelBarra;
        private Panel pnlNivelRelleno;
        private Label lblNivelTexto;
        private Label lblExplicacion;
        private Panel pnlGrafico;
        private GraficoNivel graficoNivel;
        private Label lblInstruccion2;
        private ComboBox cbAlcance;
        private Button btnOptimizar;
        private Button btnVerMapa;
        private Button btnQuitarOptimos;
        private Button btnUsarUbicacion;
        private Button btnVolverOriginal;
        private Panel pnlActual;
        private Label lblActualTitulo;
        private Label lblActualValor;
        private Label lblActualDetalle;
        private Panel pnlOptima;
        private Label lblOptimaTitulo;
        private Label lblOptimaValor;
        private Label lblOptimaDetalle;
        private Panel pnlAhorro;
        private Label lblAhorroTitulo;
        private Label lblAhorroValor;
        private Label lblAhorroDetalle;
        private Label lblExplicacionGradiente;
    }
}
