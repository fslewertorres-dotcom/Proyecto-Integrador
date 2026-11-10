namespace RutaCircular.Presentation
{
    partial class FrMain
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
            menuPrincipal = new MenuStrip();
            mnuArchivo = new ToolStripMenuItem();
            mnuGuardarTodo = new ToolStripMenuItem();
            mnuSeparador = new ToolStripSeparator();
            mnuSalir = new ToolStripMenuItem();
            mnuConfiguracion = new ToolStripMenuItem();
            mnuPuntos = new ToolStripMenuItem();
            mnuContenedores = new ToolStripMenuItem();
            mnuVias = new ToolStripMenuItem();
            mnuUsuarios = new ToolStripMenuItem();
            mnuOperacion = new ToolStripMenuItem();
            mnuMapa = new ToolStripMenuItem();
            mnuAnalisis = new ToolStripMenuItem();
            mnuHistorico = new ToolStripMenuItem();
            mnuCalculos = new ToolStripMenuItem();
            mnuIndicadores = new ToolStripMenuItem();
            mnuRendimiento = new ToolStripMenuItem();
            estado = new StatusStrip();
            lblUsuario = new ToolStripStatusLabel();
            lblReloj = new ToolStripStatusLabel();
            menuPrincipal.SuspendLayout();
            estado.SuspendLayout();
            SuspendLayout();
            // 
            // menuPrincipal
            // 
            menuPrincipal.Items.AddRange(new ToolStripItem[] { mnuArchivo, mnuConfiguracion, mnuOperacion, mnuAnalisis });
            menuPrincipal.Location = new Point(0, 0);
            menuPrincipal.Name = "menuPrincipal";
            menuPrincipal.Size = new Size(1240, 24);
            menuPrincipal.TabIndex = 0;
            // 
            // mnuArchivo
            // 
            mnuArchivo.DropDownItems.AddRange(new ToolStripItem[] { mnuGuardarTodo, mnuSeparador, mnuSalir });
            mnuArchivo.Name = "mnuArchivo";
            mnuArchivo.Text = "&Archivo";
            // 
            // mnuGuardarTodo
            // 
            mnuGuardarTodo.Name = "mnuGuardarTodo";
            mnuGuardarTodo.ShortcutKeys = Keys.Control | Keys.S;
            mnuGuardarTodo.Text = "Guardar todo";
            mnuGuardarTodo.Click += mnuGuardarTodo_Click;
            // 
            // mnuSeparador
            // 
            mnuSeparador.Name = "mnuSeparador";
            // 
            // mnuSalir
            // 
            mnuSalir.Name = "mnuSalir";
            mnuSalir.Text = "Salir";
            mnuSalir.Click += mnuSalir_Click;
            // 
            // mnuConfiguracion
            // 
            mnuConfiguracion.DropDownItems.AddRange(new ToolStripItem[] { mnuPuntos, mnuContenedores, mnuVias, mnuUsuarios });
            mnuConfiguracion.Name = "mnuConfiguracion";
            mnuConfiguracion.Text = "&Configuración";
            // 
            // mnuPuntos
            // 
            mnuPuntos.Name = "mnuPuntos";
            mnuPuntos.Text = "Puntos de recolección";
            mnuPuntos.Click += mnuPuntos_Click;
            // 
            // mnuContenedores
            // 
            mnuContenedores.Name = "mnuContenedores";
            mnuContenedores.Text = "Contenedores";
            mnuContenedores.Click += mnuContenedores_Click;
            // 
            // mnuVias
            // 
            mnuVias.Name = "mnuVias";
            mnuVias.Text = "Vías";
            mnuVias.Click += mnuVias_Click;
            // 
            // mnuUsuarios
            // 
            mnuUsuarios.Name = "mnuUsuarios";
            mnuUsuarios.Text = "Usuarios";
            mnuUsuarios.Click += mnuUsuarios_Click;
            // 
            // mnuOperacion
            // 
            mnuOperacion.DropDownItems.AddRange(new ToolStripItem[] { mnuMapa });
            mnuOperacion.Name = "mnuOperacion";
            mnuOperacion.Text = "&Operación";
            // 
            // mnuMapa
            // 
            mnuMapa.Name = "mnuMapa";
            mnuMapa.ShortcutKeys = Keys.Control | Keys.M;
            mnuMapa.Text = "Mapa y ruta del día";
            mnuMapa.Click += mnuMapa_Click;
            // 
            // mnuAnalisis
            // 
            mnuAnalisis.DropDownItems.AddRange(new ToolStripItem[] { mnuHistorico, mnuCalculos, mnuIndicadores, mnuRendimiento });
            mnuAnalisis.Name = "mnuAnalisis";
            mnuAnalisis.Text = "A&nálisis";
            // 
            // mnuHistorico
            // 
            mnuHistorico.Name = "mnuHistorico";
            mnuHistorico.Text = "Histórico de recolecciones";
            mnuHistorico.Click += mnuHistorico_Click;
            // 
            // mnuCalculos
            // 
            mnuCalculos.Name = "mnuCalculos";
            mnuCalculos.Text = "Módulo de cálculo";
            mnuCalculos.Click += mnuCalculos_Click;
            // 
            // mnuIndicadores
            // 
            mnuIndicadores.Name = "mnuIndicadores";
            mnuIndicadores.Text = "Indicadores";
            mnuIndicadores.Click += mnuIndicadores_Click;
            // 
            // mnuRendimiento
            // 
            mnuRendimiento.Name = "mnuRendimiento";
            mnuRendimiento.Text = "Comparación de algoritmos";
            mnuRendimiento.Click += mnuRendimiento_Click;
            // 
            // estado
            // 
            estado.Items.AddRange(new ToolStripItem[] { lblUsuario, lblReloj });
            estado.Location = new Point(0, 658);
            estado.Name = "estado";
            estado.Size = new Size(1240, 22);
            estado.TabIndex = 1;
            // 
            // lblUsuario
            // 
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(300, 17);
            lblUsuario.Text = "Usuario:";
            // 
            // lblReloj
            // 
            lblReloj.Name = "lblReloj";
            lblReloj.Size = new Size(300, 17);
            lblReloj.Text = "Reloj:";
            // 
            // FrMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 247, 243);
            ClientSize = new Size(1240, 680);
            Controls.Add(estado);
            Controls.Add(menuPrincipal);
            IsMdiContainer = true;
            MainMenuStrip = menuPrincipal;
            Name = "FrMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ruta Circular";
            FormClosing += FrMain_FormClosing;
            menuPrincipal.ResumeLayout(false);
            menuPrincipal.PerformLayout();
            estado.ResumeLayout(false);
            estado.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuPrincipal;
        private ToolStripMenuItem mnuArchivo;
        private ToolStripMenuItem mnuGuardarTodo;
        private ToolStripSeparator mnuSeparador;
        private ToolStripMenuItem mnuSalir;
        private ToolStripMenuItem mnuConfiguracion;
        private ToolStripMenuItem mnuPuntos;
        private ToolStripMenuItem mnuContenedores;
        private ToolStripMenuItem mnuVias;
        private ToolStripMenuItem mnuUsuarios;
        private ToolStripMenuItem mnuOperacion;
        private ToolStripMenuItem mnuMapa;
        private ToolStripMenuItem mnuAnalisis;
        private ToolStripMenuItem mnuHistorico;
        private ToolStripMenuItem mnuCalculos;
        private ToolStripMenuItem mnuIndicadores;
        private ToolStripMenuItem mnuRendimiento;
        private StatusStrip estado;
        private ToolStripStatusLabel lblUsuario;
        private ToolStripStatusLabel lblReloj;
    }
}
