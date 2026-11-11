using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
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
        private const float OpacidadFondo = 0.12f;

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
            DibujarImagenFondo(g, _areaHijos.ClientSize);

            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            int centroX = _areaHijos.ClientSize.Width / 2;

            using (Font icono = new Font("Segoe UI Symbol", 48F))
            using (Font titulo = new Font("Segoe UI", 26F, FontStyle.Bold))
            using (Font texto = new Font("Segoe UI", 11F))
            using (SolidBrush verde = new SolidBrush(Color.FromArgb(120, Tema.Verde)))
            using (SolidBrush oscuro = new SolidBrush(Tema.VerdeOscuro))
            using (SolidBrush suave = new SolidBrush(Tema.TextoSuave))
            {
                // Se mide el alto real de las tres líneas para centrar el bloque completo en la ventana.
                float altoIcono = g.MeasureString("♻", icono).Height;
                float altoTitulo = g.MeasureString("EcoResiduos", titulo).Height;
                float altoTexto = g.MeasureString("Gestión de residuos", texto).Height;
                float altoBloque = altoIcono + altoTitulo + altoTexto;

                int y = (int)((_areaHijos.ClientSize.Height - altoBloque) / 2);
                DibujarCentrado(g, "♻", icono, verde, centroX, y);
                y += (int)altoIcono;
                DibujarCentrado(g, "EcoResiduos", titulo, oscuro, centroX, y);
                y += (int)altoTitulo;
                DibujarCentrado(g, "Gestión de residuos", texto, suave, centroX, y);
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

            var matriz = new ColorMatrix { Matrix33 = OpacidadFondo };   // Matrix33 = canal alfa (transparencia)
            using (var atributos = new ImageAttributes())
            {
                atributos.SetColorMatrix(matriz);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(ImagenFondo, new Rectangle(x, y, ancho, alto),
                            0, 0, ImagenFondo.Width, ImagenFondo.Height, GraphicsUnit.Pixel, atributos);
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
