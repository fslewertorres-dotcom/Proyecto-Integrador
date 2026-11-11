namespace EcoResiduos.Presentation
{
    partial class FrMapa
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
            pnlMapaFondo = new Panel();
            panelMapa = new PanelMapa();
            pnlSimulacion = new Panel();
            lblRelojTitulo = new Label();
            lblReloj = new Label();
            lblSimular = new Label();
            numHoras = new NumericUpDown();
            btnSimular = new Button();
            btnCalcularRuta = new Button();
            btnRecogerRuta = new Button();
            lblVelocidad = new Label();
            trkVelocidad = new TrackBar();
            pnlDistancia = new Panel();
            lblDistanciaTitulo = new Label();
            lblDistanciaValor = new Label();
            pnlTiempo = new Panel();
            lblTiempoTitulo = new Label();
            lblTiempoValor = new Label();
            pnlCosto = new Panel();
            lblCostoTitulo = new Label();
            lblCostoValor = new Label();
            pnlParadas = new Panel();
            lblParadasTitulo = new Label();
            lblParadasValor = new Label();
            tabsRuta = new TabControl();
            tabRecorrido = new TabPage();
            tabPrioridad = new TabPage();
            lstPasos = new ListBox();
            dgvPrioridad = new DataGridView();
            btnVaciarSeleccionado = new Button();
            lblLeyendaTabla = new Label();
            temporizador = new System.Windows.Forms.Timer(components);
            pnlMapaFondo.SuspendLayout();
            pnlSimulacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numHoras).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trkVelocidad).BeginInit();
            pnlDistancia.SuspendLayout();
            pnlTiempo.SuspendLayout();
            pnlCosto.SuspendLayout();
            pnlParadas.SuspendLayout();
            tabsRuta.SuspendLayout();
            tabRecorrido.SuspendLayout();
            tabPrioridad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPrioridad).BeginInit();
            SuspendLayout();
            // 
            // pnlMapaFondo
            // 
            pnlMapaFondo.Controls.Add(panelMapa);
            pnlMapaFondo.BackColor = Color.White;
            pnlMapaFondo.Location = new Point(12, 12);
            pnlMapaFondo.Size = new Size(452, 556);
            pnlMapaFondo.Name = "pnlMapaFondo";
            // 
            // panelMapa
            // 
            panelMapa.BackColor = Color.White;
            panelMapa.Dock = DockStyle.Fill;
            panelMapa.Location = new Point(0, 0);
            panelMapa.Size = new Size(452, 556);
            panelMapa.Name = "panelMapa";
            // 
            // pnlSimulacion
            // 
            pnlSimulacion.Controls.Add(lblRelojTitulo);
            pnlSimulacion.Controls.Add(lblReloj);
            pnlSimulacion.Controls.Add(lblSimular);
            pnlSimulacion.Controls.Add(numHoras);
            pnlSimulacion.Controls.Add(btnSimular);
            pnlSimulacion.BackColor = Color.White;
            pnlSimulacion.Location = new Point(476, 12);
            pnlSimulacion.Size = new Size(692, 56);
            pnlSimulacion.Name = "pnlSimulacion";
            // 
            // lblRelojTitulo
            // 
            lblRelojTitulo.AutoSize = true;
            lblRelojTitulo.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblRelojTitulo.ForeColor = Color.FromArgb(107, 123, 113);
            lblRelojTitulo.Location = new Point(16, 8);
            lblRelojTitulo.Text = "RELOJ DE SIMULACIÓN";
            lblRelojTitulo.Name = "lblRelojTitulo";
            // 
            // lblReloj
            // 
            lblReloj.AutoSize = true;
            lblReloj.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblReloj.ForeColor = Color.FromArgb(30, 86, 49);
            lblReloj.Location = new Point(16, 24);
            lblReloj.Text = "—";
            lblReloj.Name = "lblReloj";
            // 
            // lblSimular
            // 
            lblSimular.AutoSize = true;
            lblSimular.Font = new Font("Segoe UI", 9F);
            lblSimular.ForeColor = Color.FromArgb(107, 123, 113);
            lblSimular.Location = new Point(398, 19);
            lblSimular.Text = "Avanzar";
            lblSimular.Name = "lblSimular";
            // 
            // numHoras
            // 
            numHoras.Location = new Point(454, 15);
            numHoras.Maximum = new decimal(new int[] { 168, 0, 0, 0 });
            numHoras.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numHoras.Size = new Size(60, 23);
            numHoras.Value = new decimal(new int[] { 6, 0, 0, 0 });
            numHoras.Font = new Font("Segoe UI", 9.75F);
            numHoras.Name = "numHoras";
            // 
            // btnSimular
            // 
            btnSimular.BackColor = Color.White;
            btnSimular.ForeColor = Color.FromArgb(30, 86, 49);
            btnSimular.FlatAppearance.BorderColor = Color.FromArgb(46, 125, 79);
            btnSimular.FlatStyle = FlatStyle.Flat;
            btnSimular.Cursor = Cursors.Hand;
            btnSimular.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnSimular.Location = new Point(522, 11);
            btnSimular.Size = new Size(154, 34);
            btnSimular.Text = "horas";
            btnSimular.UseVisualStyleBackColor = false;
            btnSimular.Name = "btnSimular";
            btnSimular.Click += btnSimular_Click;
            // 
            // btnCalcularRuta
            // 
            btnCalcularRuta.BackColor = Color.FromArgb(46, 125, 79);
            btnCalcularRuta.ForeColor = Color.White;
            btnCalcularRuta.FlatAppearance.BorderSize = 0;
            btnCalcularRuta.FlatStyle = FlatStyle.Flat;
            btnCalcularRuta.Cursor = Cursors.Hand;
            btnCalcularRuta.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnCalcularRuta.Location = new Point(476, 80);
            btnCalcularRuta.Size = new Size(220, 40);
            btnCalcularRuta.Text = "Calcular ruta del día";
            btnCalcularRuta.UseVisualStyleBackColor = false;
            btnCalcularRuta.Name = "btnCalcularRuta";
            btnCalcularRuta.Click += btnCalcularRuta_Click;
            // 
            // btnRecogerRuta
            // 
            btnRecogerRuta.BackColor = Color.FromArgb(242, 159, 5);
            btnRecogerRuta.ForeColor = Color.White;
            btnRecogerRuta.FlatAppearance.BorderSize = 0;
            btnRecogerRuta.FlatStyle = FlatStyle.Flat;
            btnRecogerRuta.Cursor = Cursors.Hand;
            btnRecogerRuta.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnRecogerRuta.Location = new Point(704, 80);
            btnRecogerRuta.Size = new Size(220, 40);
            btnRecogerRuta.Text = "▶  Recoger ruta";
            btnRecogerRuta.UseVisualStyleBackColor = false;
            btnRecogerRuta.Name = "btnRecogerRuta";
            btnRecogerRuta.Click += btnRecogerRuta_Click;
            // 
            // lblVelocidad
            // 
            lblVelocidad.AutoSize = true;
            lblVelocidad.Font = new Font("Segoe UI", 9F);
            lblVelocidad.ForeColor = Color.FromArgb(107, 123, 113);
            lblVelocidad.Location = new Point(940, 92);
            lblVelocidad.Text = "Velocidad";
            lblVelocidad.Name = "lblVelocidad";
            // 
            // trkVelocidad
            // 
            trkVelocidad.AutoSize = false;
            trkVelocidad.Location = new Point(1004, 88);
            trkVelocidad.Maximum = 10;
            trkVelocidad.Minimum = 1;
            trkVelocidad.Size = new Size(160, 28);
            trkVelocidad.TickStyle = TickStyle.None;
            trkVelocidad.Value = 5;
            trkVelocidad.Name = "trkVelocidad";
            // 
            // pnlDistancia
            // 
            pnlDistancia.Controls.Add(lblDistanciaTitulo);
            pnlDistancia.Controls.Add(lblDistanciaValor);
            pnlDistancia.BackColor = Color.White;
            pnlDistancia.Location = new Point(476, 132);
            pnlDistancia.Size = new Size(164, 62);
            pnlDistancia.Name = "pnlDistancia";
            // 
            // lblDistanciaTitulo
            // 
            lblDistanciaTitulo.AutoSize = true;
            lblDistanciaTitulo.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblDistanciaTitulo.ForeColor = Color.FromArgb(107, 123, 113);
            lblDistanciaTitulo.Location = new Point(12, 8);
            lblDistanciaTitulo.Text = "DISTANCIA";
            lblDistanciaTitulo.Name = "lblDistanciaTitulo";
            // 
            // lblDistanciaValor
            // 
            lblDistanciaValor.AutoSize = true;
            lblDistanciaValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblDistanciaValor.ForeColor = Color.FromArgb(31, 45, 36);
            lblDistanciaValor.Location = new Point(10, 26);
            lblDistanciaValor.Text = "—";
            lblDistanciaValor.Name = "lblDistanciaValor";
            // 
            // pnlTiempo
            // 
            pnlTiempo.Controls.Add(lblTiempoTitulo);
            pnlTiempo.Controls.Add(lblTiempoValor);
            pnlTiempo.BackColor = Color.White;
            pnlTiempo.Location = new Point(652, 132);
            pnlTiempo.Size = new Size(164, 62);
            pnlTiempo.Name = "pnlTiempo";
            // 
            // lblTiempoTitulo
            // 
            lblTiempoTitulo.AutoSize = true;
            lblTiempoTitulo.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblTiempoTitulo.ForeColor = Color.FromArgb(107, 123, 113);
            lblTiempoTitulo.Location = new Point(12, 8);
            lblTiempoTitulo.Text = "TIEMPO";
            lblTiempoTitulo.Name = "lblTiempoTitulo";
            // 
            // lblTiempoValor
            // 
            lblTiempoValor.AutoSize = true;
            lblTiempoValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTiempoValor.ForeColor = Color.FromArgb(31, 45, 36);
            lblTiempoValor.Location = new Point(10, 26);
            lblTiempoValor.Text = "—";
            lblTiempoValor.Name = "lblTiempoValor";
            // 
            // pnlCosto
            // 
            pnlCosto.Controls.Add(lblCostoTitulo);
            pnlCosto.Controls.Add(lblCostoValor);
            pnlCosto.BackColor = Color.White;
            pnlCosto.Location = new Point(828, 132);
            pnlCosto.Size = new Size(164, 62);
            pnlCosto.Name = "pnlCosto";
            // 
            // lblCostoTitulo
            // 
            lblCostoTitulo.AutoSize = true;
            lblCostoTitulo.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblCostoTitulo.ForeColor = Color.FromArgb(107, 123, 113);
            lblCostoTitulo.Location = new Point(12, 8);
            lblCostoTitulo.Text = "COSTO";
            lblCostoTitulo.Name = "lblCostoTitulo";
            // 
            // lblCostoValor
            // 
            lblCostoValor.AutoSize = true;
            lblCostoValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblCostoValor.ForeColor = Color.FromArgb(31, 45, 36);
            lblCostoValor.Location = new Point(10, 26);
            lblCostoValor.Text = "—";
            lblCostoValor.Name = "lblCostoValor";
            // 
            // pnlParadas
            // 
            pnlParadas.Controls.Add(lblParadasTitulo);
            pnlParadas.Controls.Add(lblParadasValor);
            pnlParadas.BackColor = Color.White;
            pnlParadas.Location = new Point(1004, 132);
            pnlParadas.Size = new Size(164, 62);
            pnlParadas.Name = "pnlParadas";
            // 
            // lblParadasTitulo
            // 
            lblParadasTitulo.AutoSize = true;
            lblParadasTitulo.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
            lblParadasTitulo.ForeColor = Color.FromArgb(107, 123, 113);
            lblParadasTitulo.Location = new Point(12, 8);
            lblParadasTitulo.Text = "PARADAS";
            lblParadasTitulo.Name = "lblParadasTitulo";
            // 
            // lblParadasValor
            // 
            lblParadasValor.AutoSize = true;
            lblParadasValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblParadasValor.ForeColor = Color.FromArgb(31, 45, 36);
            lblParadasValor.Location = new Point(10, 26);
            lblParadasValor.Text = "—";
            lblParadasValor.Name = "lblParadasValor";
            // 
            // tabsRuta
            // 
            tabsRuta.Controls.Add(tabRecorrido);
            tabsRuta.Controls.Add(tabPrioridad);
            tabsRuta.Font = new Font("Segoe UI", 9.75F);
            tabsRuta.Location = new Point(476, 206);
            tabsRuta.Padding = new Point(14, 6);
            tabsRuta.Size = new Size(692, 362);
            tabsRuta.Name = "tabsRuta";
            // 
            // tabRecorrido
            // 
            tabRecorrido.Controls.Add(lstPasos);
            tabRecorrido.BackColor = Color.White;
            tabRecorrido.Location = new Point(4, 32);
            tabRecorrido.Size = new Size(684, 326);
            tabRecorrido.Text = "Recorrido paso a paso";
            tabRecorrido.Name = "tabRecorrido";
            // 
            // tabPrioridad
            // 
            tabPrioridad.Controls.Add(dgvPrioridad);
            tabPrioridad.Controls.Add(btnVaciarSeleccionado);
            tabPrioridad.Controls.Add(lblLeyendaTabla);
            tabPrioridad.BackColor = Color.White;
            tabPrioridad.Location = new Point(4, 32);
            tabPrioridad.Size = new Size(684, 326);
            tabPrioridad.Text = "Prioridad de contenedores";
            tabPrioridad.Name = "tabPrioridad";
            // 
            // lstPasos
            // 
            lstPasos.BorderStyle = BorderStyle.None;
            lstPasos.DrawMode = DrawMode.OwnerDrawFixed;
            lstPasos.Dock = DockStyle.Fill;
            lstPasos.Font = new Font("Segoe UI", 9.75F);
            lstPasos.IntegralHeight = false;
            lstPasos.ItemHeight = 34;
            lstPasos.Location = new Point(0, 0);
            lstPasos.Size = new Size(684, 326);
            lstPasos.Name = "lstPasos";
            lstPasos.DrawItem += lstPasos_DrawItem;
            // 
            // dgvPrioridad
            // 
            dgvPrioridad.AllowUserToAddRows = false;
            dgvPrioridad.AllowUserToDeleteRows = false;
            dgvPrioridad.AllowUserToResizeRows = false;
            dgvPrioridad.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPrioridad.BackgroundColor = Color.White;
            dgvPrioridad.BorderStyle = BorderStyle.None;
            dgvPrioridad.Location = new Point(8, 8);
            dgvPrioridad.MultiSelect = false;
            dgvPrioridad.ReadOnly = true;
            dgvPrioridad.RowHeadersVisible = false;
            dgvPrioridad.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPrioridad.Size = new Size(668, 268);
            dgvPrioridad.Name = "dgvPrioridad";
            dgvPrioridad.CellFormatting += dgvPrioridad_CellFormatting;
            // 
            // btnVaciarSeleccionado
            // 
            btnVaciarSeleccionado.BackColor = Color.White;
            btnVaciarSeleccionado.ForeColor = Color.FromArgb(30, 86, 49);
            btnVaciarSeleccionado.FlatAppearance.BorderColor = Color.FromArgb(46, 125, 79);
            btnVaciarSeleccionado.FlatStyle = FlatStyle.Flat;
            btnVaciarSeleccionado.Cursor = Cursors.Hand;
            btnVaciarSeleccionado.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnVaciarSeleccionado.Location = new Point(8, 284);
            btnVaciarSeleccionado.Size = new Size(260, 34);
            btnVaciarSeleccionado.Text = "Vaciar contenedor seleccionado";
            btnVaciarSeleccionado.UseVisualStyleBackColor = false;
            btnVaciarSeleccionado.Name = "btnVaciarSeleccionado";
            btnVaciarSeleccionado.Click += btnVaciarSeleccionado_Click;
            // 
            // lblLeyendaTabla
            // 
            lblLeyendaTabla.AutoSize = true;
            lblLeyendaTabla.Font = new Font("Segoe UI", 8.25F);
            lblLeyendaTabla.ForeColor = Color.FromArgb(107, 123, 113);
            lblLeyendaTabla.Location = new Point(286, 293);
            lblLeyendaTabla.Text = "Rojo: más del 80 %   ·   Amarillo: entra a la ruta";
            lblLeyendaTabla.Name = "lblLeyendaTabla";
            // 
            // temporizador
            // 
            temporizador.Interval = 30;
            temporizador.Tick += temporizador_Tick;
            // 
            // FrMapa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 243);
            ClientSize = new Size(1180, 580);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Text = "Mapa y ruta del día";
            Controls.Add(pnlMapaFondo);
            Controls.Add(pnlSimulacion);
            Controls.Add(btnCalcularRuta);
            Controls.Add(btnRecogerRuta);
            Controls.Add(lblVelocidad);
            Controls.Add(trkVelocidad);
            Controls.Add(pnlDistancia);
            Controls.Add(pnlTiempo);
            Controls.Add(pnlCosto);
            Controls.Add(pnlParadas);
            Controls.Add(tabsRuta);
            Name = "FrMapa";
            Load += FrMapa_Load;
            Activated += FrMapa_Activated;
            FormClosing += FrMapa_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvPrioridad).EndInit();
            tabPrioridad.ResumeLayout(false);
            tabPrioridad.PerformLayout();
            tabRecorrido.ResumeLayout(false);
            tabRecorrido.PerformLayout();
            tabsRuta.ResumeLayout(false);
            tabsRuta.PerformLayout();
            pnlParadas.ResumeLayout(false);
            pnlParadas.PerformLayout();
            pnlCosto.ResumeLayout(false);
            pnlCosto.PerformLayout();
            pnlTiempo.ResumeLayout(false);
            pnlTiempo.PerformLayout();
            pnlDistancia.ResumeLayout(false);
            pnlDistancia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trkVelocidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)numHoras).EndInit();
            pnlSimulacion.ResumeLayout(false);
            pnlSimulacion.PerformLayout();
            pnlMapaFondo.ResumeLayout(false);
            pnlMapaFondo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlMapaFondo;
        private PanelMapa panelMapa;
        private Panel pnlSimulacion;
        private Label lblRelojTitulo;
        private Label lblReloj;
        private Label lblSimular;
        private NumericUpDown numHoras;
        private Button btnSimular;
        private Button btnCalcularRuta;
        private Button btnRecogerRuta;
        private Label lblVelocidad;
        private TrackBar trkVelocidad;
        private Panel pnlDistancia;
        private Label lblDistanciaTitulo;
        private Label lblDistanciaValor;
        private Panel pnlTiempo;
        private Label lblTiempoTitulo;
        private Label lblTiempoValor;
        private Panel pnlCosto;
        private Label lblCostoTitulo;
        private Label lblCostoValor;
        private Panel pnlParadas;
        private Label lblParadasTitulo;
        private Label lblParadasValor;
        private TabControl tabsRuta;
        private TabPage tabRecorrido;
        private TabPage tabPrioridad;
        private ListBox lstPasos;
        private DataGridView dgvPrioridad;
        private Button btnVaciarSeleccionado;
        private Label lblLeyendaTabla;
        private System.Windows.Forms.Timer temporizador;
    }
}
