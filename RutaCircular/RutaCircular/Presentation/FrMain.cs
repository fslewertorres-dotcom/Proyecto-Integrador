using RutaCircular.Domain;
using RutaCircular.Infraestructure;
using RutaCircular.Tools;

namespace RutaCircular.Presentation
{
    public partial class FrMain : Form
    {
        private MdiClient? _areaHijos;

        public FrMain()
        {
            InitializeComponent();
            Tema.EstilizarMenu(menuPrincipal);
            Tema.EstilizarBarraEstado(estado);
            PrepararFondo();
            AplicarPermisos();
            ActualizarEstado();
        }

        /// <summary>El área gris del MDI se pinta con el logo y una guía rápida.</summary>
        private void PrepararFondo()
        {
            foreach (Control control in Controls)
            {
                if (control is MdiClient area)
                {
                    _areaHijos = area;
                    area.BackColor = Tema.Fondo;
                    area.Paint += AreaHijos_Paint;
                    area.Resize += (s, e) => area.Invalidate();
                }
            }
        }

        private void AreaHijos_Paint(object? sender, PaintEventArgs e)
        {
            if (_areaHijos == null) return;
            Graphics g = e.Graphics;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            int centroX = _areaHijos.ClientSize.Width / 2;
            int y = _areaHijos.ClientSize.Height / 2 - 130;

            using (Font icono = new Font("Segoe UI Symbol", 48F))
            using (Font titulo = new Font("Segoe UI", 26F, FontStyle.Bold))
            using (Font texto = new Font("Segoe UI", 11F))
            using (SolidBrush verde = new SolidBrush(Color.FromArgb(120, Tema.Verde)))
            using (SolidBrush oscuro = new SolidBrush(Tema.VerdeOscuro))
            using (SolidBrush suave = new SolidBrush(Tema.TextoSuave))
            {
                DibujarCentrado(g, "♻", icono, verde, centroX, y);
                DibujarCentrado(g, "Ruta Circular", titulo, oscuro, centroX, y + 90);
                DibujarCentrado(g, "Gestión de residuos · Conjunto Portal del Viento", texto, suave, centroX, y + 140);

                string guia = Sesion.UsuarioActual != null && Sesion.UsuarioActual.PuedeConfigurar
                    ? "Empiece por  Operación → Mapa y ruta del día   ·   Análisis → Indicadores"
                    : "Empiece por  Operación → Mapa y ruta del día";
                DibujarCentrado(g, guia, texto, suave, centroX, y + 190);
            }
        }

        private static void DibujarCentrado(Graphics g, string texto, Font fuente, Brush pincel, int centroX, int y)
        {
            SizeF tamano = g.MeasureString(texto, fuente);
            g.DrawString(texto, fuente, pincel, centroX - tamano.Width / 2, y);
        }

        /// <summary>Polimorfismo: cada tipo de usuario dice qué puede hacer, y el menú se arma con eso.</summary>
        private void AplicarPermisos()
        {
            Usuario? usuario = Sesion.UsuarioActual;
            if (usuario == null) throw new InvalidOperationException("No hay una sesión iniciada.");
            mnuConfiguracion.Visible = usuario.PuedeConfigurar;
            mnuAnalisis.Visible = usuario.PuedeVerAnalisis;
            Text = $"Ruta Circular — {usuario}";
        }

        /// <summary>Los formularios hijos la llaman cuando cambia el reloj de simulación.</summary>
        public void ActualizarEstado()
        {
            DateTime reloj = Contexto.Instancia.Reloj;
            lblUsuario.Text = $"Usuario: {Sesion.UsuarioActual}";
            lblReloj.Text = $"   Reloj de simulación: {Formato.Nombre(reloj.DayOfWeek)} {reloj:dd/MM/yyyy HH:mm}";
        }

        private void mnuPuntos_Click(object? sender, EventArgs e) { Tool.openForm<FrPuntos>(this); }
        private void mnuContenedores_Click(object? sender, EventArgs e) { Tool.openForm<FrContenedores>(this); }
        private void mnuVias_Click(object? sender, EventArgs e) { Tool.openForm<FrVias>(this); }
        private void mnuUsuarios_Click(object? sender, EventArgs e) { Tool.openForm<FrUsuarios>(this); }
        private void mnuMapa_Click(object? sender, EventArgs e) { Tool.openForm<FrMapa>(this); }
        private void mnuHistorico_Click(object? sender, EventArgs e) { Tool.openForm<FrHistorico>(this); }
        private void mnuCalculos_Click(object? sender, EventArgs e) { Tool.openForm<FrCalculos>(this); }
        private void mnuIndicadores_Click(object? sender, EventArgs e) { Tool.openForm<FrIndicadores>(this); }
        private void mnuRendimiento_Click(object? sender, EventArgs e) { Tool.openForm<FrRendimiento>(this); }

        private async void mnuGuardarTodo_Click(object? sender, EventArgs e)
        {
            try
            {
                await Tool.MostrarProgresoAsync(estado, "Guardando...", () => Contexto.Instancia.GuardarTodoAsync());
                MessageBox.Show("Todos los datos se guardaron.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Tool.MostrarError(ex);
            }
        }

        private void mnuSalir_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void FrMain_FormClosing(object? sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Desea guardar los cambios antes de salir?", "Salir",
                                             MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (r == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
            if (r == DialogResult.Yes)
            {
                try
                {
                    Contexto.Instancia.GuardarTodo();
                }
                catch (Exception ex)
                {
                    Tool.MostrarError(ex);
                    e.Cancel = true;
                }
            }
        }
    }
}
