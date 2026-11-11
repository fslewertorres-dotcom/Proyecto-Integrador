using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Reflection;
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

        /// <summary>Opacidad de la imagen de contenedores del fondo (0 = invisible, 1 = normal).</summary>
        private const float OpacidadFondo = 0.16f;

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

        /// <summary>El área gris del MDI se pinta con la imagen de contenedores y el logo.</summary>
        private void PrepararFondo()
        {
            foreach (Control control in Controls)
            {
                if (control is MdiClient area)
                {
                    _areaHijos = area;
                    area.BackColor = FondoAzulArriba;
                    // Doble búfer: el degradado se pinta completo en memoria y no parpadea al redimensionar.
                    typeof(Control).GetProperty("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance)
                                   ?.SetValue(area, true);
                    area.Paint += AreaHijos_Paint;
                    area.Resize += (s, e) => area.Invalidate();
                }
            }
        }

        private void AreaHijos_Paint(object? sender, PaintEventArgs e)
        {
            if (_areaHijos == null) return;
            Graphics g = e.Graphics;
            Size area = _areaHijos.ClientSize;
            if (area.Width <= 0 || area.Height <= 0) return;

            // Capa 1 (atrás): degradado azul suave.
            DibujarCapaAzul(g, area);
            // Capa 2 (medio): contenedores con su propia sombra, para que se despeguen del fondo.
            DibujarImagenFondo(g, area);

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
            int centroX = area.Width / 2;

            using (Font icono = new Font("Segoe UI Symbol", 48F))
            using (Font titulo = new Font("Segoe UI", 26F, FontStyle.Bold))
            using (Font texto = new Font("Segoe UI", 11F))
            using (SolidBrush verde = new SolidBrush(Color.FromArgb(210, Tema.Verde)))
            using (SolidBrush oscuro = new SolidBrush(Tema.VerdeOscuro))
            using (SolidBrush suave = new SolidBrush(Tema.TextoSuave))
            {
                // Se mide el alto real de las tres líneas para centrar el bloque completo en la ventana.
                SizeF tamIcono = g.MeasureString("♻", icono);
                SizeF tamTitulo = g.MeasureString("EcoResiduos", titulo);
                SizeF tamTexto = g.MeasureString("Gestión de residuos", texto);
                float altoBloque = tamIcono.Height + tamTitulo.Height + tamTexto.Height;
                float anchoBloque = Math.Max(tamTitulo.Width, Math.Max(tamIcono.Width, tamTexto.Width));

                int y = (int)((area.Height - altoBloque) / 2);

                // Capa 3 (frente): halo claro detrás del logo y los textos, que los separa de la imagen.
                DibujarHalo(g, centroX, y + altoBloque / 2, anchoBloque, altoBloque);

                DibujarCentradoConSombra(g, "♻", icono, verde, centroX, y);
                y += (int)tamIcono.Height;
                DibujarCentradoConSombra(g, "EcoResiduos", titulo, oscuro, centroX, y);
                y += (int)tamTitulo.Height;
                DibujarCentradoConSombra(g, "Gestión de residuos", texto, suave, centroX, y);
            }
        }

        /// <summary>Tonos del fondo azul (muy suaves, combinan con el verde del menú y la barra de estado).</summary>
        private static readonly Color FondoAzulArriba = Color.FromArgb(240, 246, 251);
        private static readonly Color FondoAzulAbajo = Color.FromArgb(220, 233, 244);

        /// <summary>Capa de fondo: degradado vertical azul con una luz suave en el centro.</summary>
        private static void DibujarCapaAzul(Graphics g, Size area)
        {
            Rectangle todo = new Rectangle(Point.Empty, area);
            using (var degradado = new LinearGradientBrush(todo, FondoAzulArriba, FondoAzulAbajo, LinearGradientMode.Vertical))
            {
                g.FillRectangle(degradado, todo);
            }

            // Luz central: da profundidad para que el fondo no se vea plano.
            g.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF luz = new RectangleF(-area.Width * 0.15f, -area.Height * 0.10f, area.Width * 1.30f, area.Height * 1.20f);
            using (var ruta = new GraphicsPath())
            {
                ruta.AddEllipse(luz);
                using (var brillo = new PathGradientBrush(ruta))
                {
                    brillo.CenterColor = Color.FromArgb(150, 255, 255, 255);
                    brillo.SurroundColors = new[] { Color.FromArgb(0, 255, 255, 255) };
                    g.FillRectangle(brillo, todo);
                }
            }
        }

        /// <summary>Halo blanco difuminado que deja el logo y los textos al frente.</summary>
        private static void DibujarHalo(Graphics g, float centroX, float centroY, float anchoBloque, float altoBloque)
        {
            float ancho = anchoBloque + 220;
            float alto = altoBloque + 110;
            using (var ruta = new GraphicsPath())
            {
                ruta.AddEllipse(centroX - ancho / 2, centroY - alto / 2, ancho, alto);
                using (var halo = new PathGradientBrush(ruta))
                {
                    halo.CenterColor = Color.FromArgb(225, 248, 251, 254);
                    halo.SurroundColors = new[] { Color.FromArgb(0, 248, 251, 254) };
                    halo.FocusScales = new PointF(0.45f, 0.35f);   // centro más amplio y borde que se desvanece
                    g.FillPath(halo, ruta);
                }
            }
        }

        /// <summary>Dibuja los contenedores centrados en la ventana, casi transparentes, detrás del logo.</summary>
        private static void DibujarImagenFondo(Graphics g, Size area)
        {
            if (ImagenFondo == null || area.Width <= 0 || area.Height <= 0) return;

            float escala = Math.Min(area.Width * 0.70f / ImagenFondo.Width, area.Height * 0.70f / ImagenFondo.Height);
            int ancho = (int)(ImagenFondo.Width * escala);
            int alto = (int)(ImagenFondo.Height * escala);
            int x = (area.Width - ancho) / 2;
            int y = (area.Height - alto) / 2;

            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // Sombra: la silueta de los contenedores en azul grisáceo, desplazada y repetida varias
            // veces con muy poca opacidad para que quede difuminada. Así la imagen "flota" sobre el fondo.
            var sombra = new ColorMatrix(new[]
            {
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0.035f, 0 },
                new float[] { 60 / 255f, 90 / 255f, 125 / 255f, 0, 1 }   // color de la sombra
            });
            using (var atributosSombra = new ImageAttributes())
            {
                atributosSombra.SetColorMatrix(sombra);
                int[,] desplazamientos = { { 6, 9 }, { 9, 12 }, { 12, 16 }, { 4, 6 } };
                for (int i = 0; i < desplazamientos.GetLength(0); i++)
                {
                    g.DrawImage(ImagenFondo,
                                new Rectangle(x + desplazamientos[i, 0], y + desplazamientos[i, 1], ancho, alto),
                                0, 0, ImagenFondo.Width, ImagenFondo.Height, GraphicsUnit.Pixel, atributosSombra);
                }
            }

            var matriz = new ColorMatrix { Matrix33 = OpacidadFondo };   // Matrix33 = canal alfa (transparencia)
            using (var atributos = new ImageAttributes())
            {
                atributos.SetColorMatrix(matriz);
                g.DrawImage(ImagenFondo, new Rectangle(x, y, ancho, alto),
                            0, 0, ImagenFondo.Width, ImagenFondo.Height, GraphicsUnit.Pixel, atributos);
            }
        }

        /// <summary>Dibuja el texto centrado con una sombra suave debajo, para que resalte al frente.</summary>
        private static void DibujarCentradoConSombra(Graphics g, string texto, Font fuente, Brush pincel, int centroX, int y)
        {
            SizeF tamano = g.MeasureString(texto, fuente);
            float x = centroX - tamano.Width / 2;
            using (var sombra = new SolidBrush(Color.FromArgb(45, 30, 60, 90)))
            {
                g.DrawString(texto, fuente, sombra, x + 1, y + 2);
            }
            g.DrawString(texto, fuente, pincel, x, y);
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
