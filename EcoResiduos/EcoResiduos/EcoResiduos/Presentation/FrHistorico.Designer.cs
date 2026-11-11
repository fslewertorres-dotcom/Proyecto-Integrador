namespace EcoResiduos.Presentation
{
    partial class FrHistorico
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
            lblOrdenar = new Label();
            cbCampo = new ComboBox();
            cbSentido = new ComboBox();
            btnOrdenar = new Button();
            lblBuscar = new Label();
            dtpFecha = new DateTimePicker();
            btnBuscar = new Button();
            btnRecargar = new Button();
            lblInfo = new Label();
            pnlTabla = new Panel();
            dgvHistorico = new DataGridView();
            pnlEncabezado.SuspendLayout();
            pnlFiltros.SuspendLayout();
            pnlTabla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorico).BeginInit();
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
            lblTitulo.Text = "Histórico de recolecciones";
            lblTitulo.Name = "lblTitulo";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9F);
            lblSubtitulo.ForeColor = Color.FromArgb(200, 230, 210);
            lblSubtitulo.Location = new Point(22, 40);
            lblSubtitulo.Text = "Cada vez que se vacía un contenedor queda registrado aquí";
            lblSubtitulo.Name = "lblSubtitulo";
            // 
            // pnlFiltros
            // 
            pnlFiltros.Controls.Add(lblOrdenar);
            pnlFiltros.Controls.Add(cbCampo);
            pnlFiltros.Controls.Add(cbSentido);
            pnlFiltros.Controls.Add(btnOrdenar);
            pnlFiltros.Controls.Add(lblBuscar);
            pnlFiltros.Controls.Add(dtpFecha);
            pnlFiltros.Controls.Add(btnBuscar);
            pnlFiltros.Controls.Add(btnRecargar);
            pnlFiltros.BackColor = Color.White;
            pnlFiltros.Location = new Point(16, 80);
            pnlFiltros.Size = new Size(968, 64);
            pnlFiltros.Name = "pnlFiltros";
            // 
            // lblOrdenar
            // 
            lblOrdenar.AutoSize = true;
            lblOrdenar.Font = new Font("Segoe UI", 9F);
            lblOrdenar.ForeColor = Color.FromArgb(107, 123, 113);
            lblOrdenar.Location = new Point(14, 23);
            lblOrdenar.Text = "Ordenar por";
            lblOrdenar.Name = "lblOrdenar";
            // 
            // cbCampo
            // 
            cbCampo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCampo.FlatStyle = FlatStyle.Flat;
            cbCampo.Font = new Font("Segoe UI", 9.75F);
            cbCampo.Location = new Point(92, 19);
            cbCampo.Size = new Size(130, 25);
            cbCampo.Name = "cbCampo";
            // 
            // cbSentido
            // 
            cbSentido.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSentido.FlatStyle = FlatStyle.Flat;
            cbSentido.Font = new Font("Segoe UI", 9.75F);
            cbSentido.Location = new Point(230, 19);
            cbSentido.Size = new Size(120, 25);
            cbSentido.Name = "cbSentido";
            // 
            // btnOrdenar
            // 
            btnOrdenar.BackColor = Color.FromArgb(46, 125, 79);
            btnOrdenar.ForeColor = Color.White;
            btnOrdenar.FlatAppearance.BorderSize = 0;
            btnOrdenar.FlatStyle = FlatStyle.Flat;
            btnOrdenar.Cursor = Cursors.Hand;
            btnOrdenar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnOrdenar.Location = new Point(358, 15);
            btnOrdenar.Size = new Size(110, 34);
            btnOrdenar.Text = "Ordenar";
            btnOrdenar.UseVisualStyleBackColor = false;
            btnOrdenar.Name = "btnOrdenar";
            btnOrdenar.Click += btnOrdenar_Click;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9F);
            lblBuscar.ForeColor = Color.FromArgb(107, 123, 113);
            lblBuscar.Location = new Point(500, 23);
            lblBuscar.Text = "Buscar día";
            lblBuscar.Name = "lblBuscar";
            // 
            // dtpFecha
            // 
            dtpFecha.Font = new Font("Segoe UI", 9.75F);
            dtpFecha.Format = DateTimePickerFormat.Short;
            dtpFecha.Location = new Point(572, 19);
            dtpFecha.Size = new Size(120, 25);
            dtpFecha.Name = "dtpFecha";
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = Color.White;
            btnBuscar.ForeColor = Color.FromArgb(30, 86, 49);
            btnBuscar.FlatAppearance.BorderColor = Color.FromArgb(46, 125, 79);
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnBuscar.Location = new Point(700, 15);
            btnBuscar.Size = new Size(100, 34);
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnRecargar
            // 
            btnRecargar.BackColor = Color.White;
            btnRecargar.ForeColor = Color.FromArgb(30, 86, 49);
            btnRecargar.FlatAppearance.BorderColor = Color.FromArgb(46, 125, 79);
            btnRecargar.FlatStyle = FlatStyle.Flat;
            btnRecargar.Cursor = Cursors.Hand;
            btnRecargar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            btnRecargar.Location = new Point(840, 15);
            btnRecargar.Size = new Size(110, 34);
            btnRecargar.Text = "Recargar";
            btnRecargar.UseVisualStyleBackColor = false;
            btnRecargar.Name = "btnRecargar";
            btnRecargar.Click += btnRecargar_Click;
            // 
            // lblInfo
            // 
            lblInfo.Font = new Font("Segoe UI", 9.75F);
            lblInfo.ForeColor = Color.FromArgb(30, 86, 49);
            lblInfo.Location = new Point(16, 152);
            lblInfo.Size = new Size(968, 22);
            lblInfo.Text = "";
            lblInfo.Name = "lblInfo";
            // 
            // pnlTabla
            // 
            pnlTabla.Controls.Add(dgvHistorico);
            pnlTabla.BackColor = Color.White;
            pnlTabla.Location = new Point(16, 180);
            pnlTabla.Size = new Size(968, 364);
            pnlTabla.Name = "pnlTabla";
            // 
            // dgvHistorico
            // 
            dgvHistorico.AllowUserToAddRows = false;
            dgvHistorico.AllowUserToDeleteRows = false;
            dgvHistorico.AllowUserToResizeRows = false;
            dgvHistorico.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorico.BackgroundColor = Color.White;
            dgvHistorico.BorderStyle = BorderStyle.None;
            dgvHistorico.Location = new Point(12, 12);
            dgvHistorico.MultiSelect = false;
            dgvHistorico.ReadOnly = true;
            dgvHistorico.RowHeadersVisible = false;
            dgvHistorico.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorico.Size = new Size(944, 340);
            dgvHistorico.Name = "dgvHistorico";
            // 
            // FrHistorico
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 243);
            ClientSize = new Size(1000, 560);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Text = "Histórico de recolecciones";
            Controls.Add(pnlEncabezado);
            Controls.Add(pnlFiltros);
            Controls.Add(lblInfo);
            Controls.Add(pnlTabla);
            Name = "FrHistorico";
            ((System.ComponentModel.ISupportInitialize)dgvHistorico).EndInit();
            pnlTabla.ResumeLayout(false);
            pnlTabla.PerformLayout();
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
        private Label lblOrdenar;
        private ComboBox cbCampo;
        private ComboBox cbSentido;
        private Button btnOrdenar;
        private Label lblBuscar;
        private DateTimePicker dtpFecha;
        private Button btnBuscar;
        private Button btnRecargar;
        private Label lblInfo;
        private Panel pnlTabla;
        private DataGridView dgvHistorico;
    }
}
