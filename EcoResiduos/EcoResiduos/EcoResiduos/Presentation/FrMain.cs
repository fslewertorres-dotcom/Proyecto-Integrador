using System.Drawing.Drawing2D;
using EcoResiduos.Domain;
using EcoResiduos.Infraestructure;
using EcoResiduos.Tools;

namespace EcoResiduos.Presentation
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

        /// <summary>
        /// true cuando el usuario eligió Archivo → Salir: se cierra la sesión y Program vuelve a mostrar el login.
        /// Si cierra la ventana con la X, queda en false y el programa termina.
        /// </summary>
        public bool VolverAlLogin { get; private set; }

        // ========================= FONDO DE LA VENTANA =========================
        // Se pinta en tres pasos, de atrás hacia adelante:
        //   1. Un degradado azul suave.
        //   2. La imagen de los contenedores, tapada con un "velo" del mismo azul para que se vea tenue.
        //   3. El logo y los textos, en el centro.

        private static readonly Color AzulArriba = Color.FromArgb(240, 246, 251);
        private static readonly Color AzulAbajo = Color.FromArgb(220, 233, 244);

        /// <summary>Qué tanto tapa el velo a la imagen: 0 = nada, 255 = la tapa toda.</summary>
        private const int OpacidadVelo = 215;

        /// <summary>Imagen de contenedores incrustada en el .exe (Recursos/contenedores.png). Se carga una sola vez.</summary>
        private static readonly Image? ImagenFondo = CargarImagenFondo();

        private static Image? CargarImagenFondo()
        {
            try
            {
                using Stream? flujo = typeof(FrMain).Assembly.GetManifestResourceStream("EcoResiduos.contenedores.png");
                if (flujo == null) return null;
                using Image temporal = Image.FromStream(flujo);
                return new Bitmap(temporal);   // copia en memoria para no depender del flujo
            }
            catch
            {
                return null;   // si la imagen falla, el fondo se pinta sin ella
            }
        }

        /// <summary>El área donde se abren los formularios hijos (MdiClient) se pinta con el fondo.</summary>
        private void PrepararFondo()
        {
            foreach (Control control in Controls)
            {
                if (control is MdiClient area)
                {
                    _areaHijos = area;
                    area.BackColor = AzulArriba;
                    area.Paint += AreaHijos_Paint;
                    area.Resize += (s, e) => area.Invalidate();   // al cambiar el tamaño se vuelve a pintar
                }
            }
        }

        private void AreaHijos_Paint(object? sender, PaintEventArgs e)
        {
            if (_areaHijos == null) return;
            Graphics g = e.Graphics;
            Rectangle todo = _areaHijos.ClientRectangle;
            if (todo.Width <= 0 || todo.Height <= 0) return;

            // 1. Degradado azul de arriba hacia abajo
            using (LinearGradientBrush fondo = new LinearGradientBrush(todo, AzulArriba, AzulAbajo, LinearGradientMode.Vertical))
            {
                g.FillRectangle(fondo, todo);
            }

            // 2. Contenedores al 70 % del área, centrados, y encima el velo azul semitransparente
            if (ImagenFondo != null)
            {
                float escala = Math.Min(todo.Width * 0.70f / ImagenFondo.Width, todo.Height * 0.70f / ImagenFondo.Height);
                int ancho = (int)(ImagenFondo.Width * escala);
                int alto = (int)(ImagenFondo.Height * escala);
                g.DrawImage(ImagenFondo, (todo.Width - ancho) / 2, (todo.Height - alto) / 2, ancho, alto);

                using (LinearGradientBrush velo = new LinearGradientBrush(todo,
                           Color.FromArgb(OpacidadVelo, AzulArriba), Color.FromArgb(OpacidadVelo, AzulAbajo),
                           LinearGradientMode.Vertical))
                {
                    g.FillRectangle(velo, todo);
                }
            }

            // 3. Logo y textos centrados, uno debajo del otro
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            using (Font icono = new Font("Segoe UI Symbol", 48F))
            using (Font titulo = new Font("Segoe UI", 26F, FontStyle.Bold))
            using (Font texto = new Font("Segoe UI", 11F))
            {
                float altoBloque = g.MeasureString("♻", icono).Height
                                 + g.MeasureString("EcoResiduos", titulo).Height
                                 + g.MeasureString("Gestión de residuos", texto).Height;
                float y = (todo.Height - altoBloque) / 2;

                y = DibujarCentrado(g, "♻", icono, Tema.Verde, todo.Width, y);
                y = DibujarCentrado(g, "EcoResiduos", titulo, Tema.VerdeOscuro, todo.Width, y);
                DibujarCentrado(g, "Gestión de residuos", texto, Tema.TextoSuave, todo.Width, y);
            }
        }

        /// <summary>Escribe una línea centrada a lo ancho y devuelve dónde empieza la siguiente.</summary>
        private static float DibujarCentrado(Graphics g, string texto, Font fuente, Color color, int anchoArea, float y)
        {
            SizeF tamano = g.MeasureString(texto, fuente);
            using (SolidBrush pincel = new SolidBrush(color))
            {
                g.DrawString(texto, fuente, pincel, (anchoArea - tamano.Width) / 2, y);
            }
            return y + tamano.Height;
        }

        /// <summary>Polimorfismo: cada tipo de usuario dice qué puede hacer, y el menú se arma con eso.</summary>
        private void AplicarPermisos()
        {
            Usuario? usuario = Sesion.UsuarioActual;
            if (usuario == null) throw new InvalidOperationException("No hay una sesión iniciada.");
            mnuConfiguracion.Visible = usuario.PuedeConfigurar;
            mnuAnalisis.Visible = usuario.PuedeVerAnalisis;
            Text = $"EcoResiduos — {usuario}";
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

        /// <summary>Archivo → Salir: cierra la sesión y vuelve al formulario de inicio de sesión.</summary>
        private void mnuSalir_Click(object? sender, EventArgs e)
        {
            VolverAlLogin = true;
            Close();
        }

        private void FrMain_FormClosing(object? sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Desea guardar los cambios antes de salir?", "Salir",
                                             MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (r == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else if (r == DialogResult.Yes)
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

            // Si al final no se cerró, el usuario sigue en la sesión: no hay que volver al login.
            if (e.Cancel) VolverAlLogin = false;
        }
    }
}
