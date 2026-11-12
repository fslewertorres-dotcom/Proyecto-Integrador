using System.Drawing.Drawing2D;
using EcoResiduos.Domain;
using EcoResiduos.Infraestructure;
using EcoResiduos.Services;
using EcoResiduos.Tools;

namespace EcoResiduos.Presentation
{
    /// <summary>
    /// Dibuja el plano del conjunto con GDI+: lote, vías, casas, zonas sociales, puntos de recolección,
    /// la ruta del día (con flechas y el orden de las paradas) y el carrito del operario cuando se recoge.
    /// Las coordenadas del modelo están en metros; aquí se convierten a píxeles con una escala.
    /// </summary>
    public class PanelMapa : Panel
    {
        private Contexto? _ctx;
        private Ruta? _ruta;

        // Estado de la animación
        private Coordenada? _carrito;
        private int _tramosRecorridos;
        private readonly List<long> _puntosAtendidos = new List<long>();

        // Conversión metros → píxeles (se calcula en cada OnPaint)
        private float _escala = 1;
        private float _origenX;
        private float _origenY;
        private const float AltoLeyenda = 30;

        // Tooltip al pasar el mouse sobre un punto
        private readonly ToolTip _ayuda = new ToolTip();
        private long _puntoBajoMouse = -1;

        private static readonly Color ColorPasto = Color.FromArgb(220, 239, 214);
        private static readonly Color ColorSeto = Color.FromArgb(94, 140, 85);
        private static readonly Color ColorVia = Color.FromArgb(207, 211, 204);
        private static readonly Color ColorCasa = Color.FromArgb(250, 250, 247);
        private static readonly Color ColorBordeCasa = Color.FromArgb(200, 195, 184);
        private static readonly Color ColorPuerta = Color.FromArgb(185, 138, 94);

        public PanelMapa()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
        }

        public void Actualizar(Contexto contexto, Ruta? ruta)
        {
            _ctx = contexto;
            _ruta = ruta;
            Invalidate();
        }

        /// <summary>Mueve el carrito del operario (posición en metros) y marca cuántos tramos ya recorrió.</summary>
        public void MoverCarrito(Coordenada? posicion, int tramosRecorridos)
        {
            _carrito = posicion;
            _tramosRecorridos = tramosRecorridos;
            Invalidate();
        }

        public void MarcarAtendido(long puntoId)
        {
            if (!_puntosAtendidos.Contains(puntoId)) _puntosAtendidos.Add(puntoId);
            Invalidate();
        }

        public void ReiniciarAnimacion()
        {
            _carrito = null;
            _tramosRecorridos = 0;
            _puntosAtendidos.Clear();
            Invalidate();
        }

        private PointF APantalla(double x, double y)
        {
            return new PointF(_origenX + (float)x * _escala, _origenY + (float)y * _escala);
        }

        private RectangleF APantalla(Rectangulo r)
        {
            PointF p = APantalla(r.X, r.Y);
            return new RectangleF(p.X, p.Y, (float)r.Ancho * _escala, (float)r.Alto * _escala);
        }

        private void CalcularEscala()
        {
            const float margen = 16;
            float anchoDisponible = Width - 2 * margen;
            float altoDisponible = Height - 2 * margen - AltoLeyenda;
            _escala = Math.Min(anchoDisponible / (float)PlanoConjunto.LoteAncho, altoDisponible / (float)PlanoConjunto.LoteAlto);
            if (_escala < 0.1f) _escala = 0.1f;
            // Centrar el plano en el panel
            _origenX = (Width - (float)PlanoConjunto.LoteAncho * _escala) / 2;
            _origenY = margen;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_ctx == null) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            CalcularEscala();

            DibujarTerreno(g);
            DibujarZonasSociales(g);
            DibujarCasas(g);
            DibujarGrafo(g);
            DibujarRuta(g);
            DibujarGradiente(g);
            DibujarPuntos(g);
            DibujarCarrito(g);
            DibujarLeyenda(g);
        }

        // ---------------------------------------------------------------- terreno y vías
        private void DibujarTerreno(Graphics g)
        {
            RectangleF lote = APantalla(new Rectangulo(0, 0, PlanoConjunto.LoteAncho, PlanoConjunto.LoteAlto));
            using (SolidBrush pasto = new SolidBrush(ColorPasto))
                g.FillRectangle(pasto, lote);
            using (Pen seto = new Pen(ColorSeto, 4))
                g.DrawRectangle(seto, lote.X, lote.Y, lote.Width, lote.Height);

            using (SolidBrush via = new SolidBrush(ColorVia))
            {
                g.FillRectangle(via, APantalla(PlanoConjunto.ViaPrincipal));
                g.FillRectangle(via, APantalla(PlanoConjunto.Sendero));
                for (int i = 0; i < PlanoConjunto.YVias.Length; i++)
                    g.FillRectangle(via, APantalla(PlanoConjunto.ViaInterna(i)));
            }

            // Línea blanca discontinua en el centro de las vías
            using (Pen linea = new Pen(Color.White, 1.2f))
            {
                linea.DashStyle = DashStyle.Dash;
                g.DrawLine(linea, APantalla(4, 2), APantalla(4, 158));
                for (int i = 0; i < PlanoConjunto.YVias.Length; i++)
                    g.DrawLine(linea, APantalla(9, PlanoConjunto.YVias[i]), APantalla(80, PlanoConjunto.YVias[i]));
            }

            // Entrada
            using (Font fuente = Tema.Fuente(7.5F, FontStyle.Bold))
            using (SolidBrush pincel = new SolidBrush(Tema.VerdeOscuro))
            {
                PointF entrada = APantalla(24, 152);   // a la derecha de la etiqueta "Acopio" para no montarse
                g.DrawString("▲ ENTRADA", fuente, pincel, entrada.X, entrada.Y);
            }
        }

        private void DibujarZonasSociales(Graphics g)
        {
            using Font fuente = Tema.Fuente(8F, FontStyle.Bold);
            foreach (ZonaComun zona in PlanoConjunto.ZonasComunes)
            {
                Color relleno = Color.FromArgb(201, 232, 190);
                Color borde = Color.FromArgb(120, 170, 105);
                if (zona.Tipo == TipoPunto.Piscina) { relleno = Color.FromArgb(169, 216, 242); borde = Color.FromArgb(70, 150, 200); }
                if (zona.Tipo == TipoPunto.Gimnasio) { relleno = Color.FromArgb(227, 220, 245); borde = Color.FromArgb(140, 120, 190); }
                if (zona.Tipo == TipoPunto.ZonaAsados) { relleno = Color.FromArgb(251, 224, 194); borde = Color.FromArgb(215, 150, 80); }

                RectangleF r = APantalla(zona.Area);
                using (GraphicsPath camino = Redondeado(r, 6))
                using (SolidBrush pincel = new SolidBrush(relleno))
                using (Pen lapiz = new Pen(borde, 1.5f))
                {
                    g.FillPath(pincel, camino);
                    g.DrawPath(lapiz, camino);
                }
                using (SolidBrush texto = new SolidBrush(borde))
                {
                    StringFormat centrado = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Far };
                    g.DrawString(zona.Nombre, fuente, texto, new RectangleF(r.X, r.Y, r.Width, r.Height - 4), centrado);
                }
            }
        }

        private void DibujarCasas(Graphics g)
        {
            using SolidBrush casa = new SolidBrush(ColorCasa);
            using Pen borde = new Pen(ColorBordeCasa);
            using SolidBrush puerta = new SolidBrush(ColorPuerta);
            foreach (Casa c in PlanoConjunto.Casas)
            {
                RectangleF r = APantalla(c.Lote);
                g.FillRectangle(casa, r);
                g.DrawRectangle(borde, r.X, r.Y, r.Width, r.Height);

                // Franja café del lado que da a la vía (como las puertas de las imágenes del conjunto)
                bool daHaciaAbajo = (c.Hilera - 1) % 2 == 0;
                float y = daHaciaAbajo ? r.Bottom - 2.5f : r.Y;
                g.FillRectangle(puerta, r.X + r.Width * 0.3f, y, r.Width * 0.4f, 2.5f);
            }
        }

        /// <summary>Las aristas del grafo, muy suaves, para que se vea que el plano es un grafo.</summary>
        private void DibujarGrafo(Graphics g)
        {
            if (_ctx == null) return;
            using Pen arista = new Pen(Color.FromArgb(120, 140, 150, 140), 1f);
            arista.DashStyle = DashStyle.Dot;
            foreach (Via v in _ctx.Vias.GetAll())
            {
                PuntoRecoleccion? a = _ctx.Puntos.GetById(v.OrigenId);
                PuntoRecoleccion? b = _ctx.Puntos.GetById(v.DestinoId);
                if (a != null && b != null) g.DrawLine(arista, APantalla(a.X, a.Y), APantalla(b.X, b.Y));
            }
        }

        // ---------------------------------------------------------------- ruta
        private List<PointF> PuntosDelRecorrido()
        {
            List<PointF> puntos = new List<PointF>();
            if (_ruta == null || _ctx == null) return puntos;
            foreach (long id in _ruta.Recorrido)
            {
                PuntoRecoleccion? p = _ctx.Puntos.GetById(id);
                if (p != null) puntos.Add(APantalla(p.X, p.Y));
            }
            return puntos;
        }

        private void DibujarRuta(Graphics g)
        {
            List<PointF> puntos = PuntosDelRecorrido();
            if (puntos.Count < 2) return;

            // 1. "Sombra" ancha para que la ruta resalte sobre las vías
            using (Pen sombra = new Pen(Color.FromArgb(70, Tema.Ambar), 10))
            {
                sombra.LineJoin = LineJoin.Round;
                sombra.StartCap = LineCap.Round;
                sombra.EndCap = LineCap.Round;
                g.DrawLines(sombra, puntos.ToArray());
            }

            // 2. Cada tramo: verde si ya se recorrió, ámbar si falta
            using Pen pendiente = new Pen(Tema.Ambar, 3.5f);
            using Pen hecho = new Pen(Tema.Verde, 3.5f);
            pendiente.StartCap = LineCap.Round; pendiente.EndCap = LineCap.Round;
            hecho.StartCap = LineCap.Round; hecho.EndCap = LineCap.Round;
            for (int i = 0; i < puntos.Count - 1; i++)
            {
                Pen lapiz = i < _tramosRecorridos ? hecho : pendiente;
                g.DrawLine(lapiz, puntos[i], puntos[i + 1]);
                DibujarFlecha(g, puntos[i], puntos[i + 1], i < _tramosRecorridos ? Tema.VerdeOscuro : Color.FromArgb(190, 110, 0));
            }
        }

        /// <summary>Triángulo en la mitad del tramo que indica el sentido del recorrido.</summary>
        private static void DibujarFlecha(Graphics g, PointF desde, PointF hasta, Color color)
        {
            float dx = hasta.X - desde.X;
            float dy = hasta.Y - desde.Y;
            float largo = (float)Math.Sqrt(dx * dx + dy * dy);
            if (largo < 18) return;   // tramo muy corto: no cabe la flecha

            float ux = dx / largo, uy = dy / largo;          // dirección
            PointF medio = new PointF(desde.X + dx / 2, desde.Y + dy / 2);
            const float tam = 6;
            PointF punta = new PointF(medio.X + ux * tam, medio.Y + uy * tam);
            PointF izquierda = new PointF(medio.X - ux * tam - uy * tam, medio.Y - uy * tam + ux * tam);
            PointF derecha = new PointF(medio.X - ux * tam + uy * tam, medio.Y - uy * tam - ux * tam);
            using SolidBrush pincel = new SolidBrush(color);
            g.FillPolygon(pincel, new PointF[] { punta, izquierda, derecha });
        }

        // ---------------------------------------------------------------- gradiente
        private void DibujarGradiente(Graphics g)
        {
            if (_ctx == null) return;
            if (_ctx.TrayectoriaGradiente.Count > 1)
            {
                using Pen lapiz = new Pen(Color.MediumVioletRed, 1.5f);
                lapiz.DashStyle = DashStyle.Dot;
                for (int i = 0; i < _ctx.TrayectoriaGradiente.Count - 1; i++)
                {
                    Coordenada a = _ctx.TrayectoriaGradiente[i];
                    Coordenada b = _ctx.TrayectoriaGradiente[i + 1];
                    g.DrawLine(lapiz, APantalla(a.X, a.Y), APantalla(b.X, b.Y));
                }
            }
            using Font fuente = Tema.Fuente(7.5F, FontStyle.Bold);
            foreach (Coordenada optimo in _ctx.UbicacionesOptimas)
            {
                PointF c = APantalla(optimo.X, optimo.Y);
                g.FillPolygon(Brushes.MediumVioletRed, Estrella(c, 9, 4));
                g.DrawString(optimo.Etiqueta, fuente, Brushes.MediumVioletRed, c.X + 9, c.Y + 2);
            }
        }

        // ---------------------------------------------------------------- puntos
        private void DibujarPuntos(Graphics g)
        {
            if (_ctx == null) return;

            // Número de parada de cada punto en la ruta
            Dictionary<long, int> ordenParada = new Dictionary<long, int>();
            if (_ruta != null)
            {
                int n = 1;
                foreach (long id in _ruta.Paradas)
                {
                    ordenParada[id] = n;
                    n++;
                }
            }

            using Font fuente = Tema.Fuente(7F, FontStyle.Bold);
            using Font fuenteNumero = Tema.Fuente(7.5F, FontStyle.Bold);
            foreach (PuntoRecoleccion punto in _ctx.Puntos.GetAll())
            {
                PointF c = APantalla(punto.X, punto.Y);

                if (punto.Tipo == TipoPunto.Interseccion)
                {
                    g.FillEllipse(Brushes.Gray, c.X - 2.5f, c.Y - 2.5f, 5, 5);
                    continue;
                }

                if (punto.Tipo == TipoPunto.Acopio)
                {
                    RectangleF caja = new RectangleF(c.X - 10, c.Y - 10, 20, 20);
                    using (GraphicsPath camino = Redondeado(caja, 4))
                    using (SolidBrush azul = new SolidBrush(Tema.Azul))
                        g.FillPath(azul, camino);
                    DibujarTextoCentrado(g, "A", fuenteNumero, Brushes.White, c);
                    using (SolidBrush texto = new SolidBrush(Tema.Azul))
                        g.DrawString("Acopio", fuente, texto, c.X + 12, c.Y - 6);
                    continue;
                }

                // Punto con contenedores: color según el contenedor más lleno
                double maximo = 0;
                foreach (Contenedor cont in _ctx.ContenedoresDe(punto.Id))
                    maximo = Math.Max(maximo, cont.Porcentaje);
                Color color = Tema.Verde;
                if (maximo >= 80) color = Tema.Rojo;
                else if (maximo >= 50) color = Tema.Amarillo;

                const float radio = 9;
                using (SolidBrush relleno = new SolidBrush(color))
                    g.FillEllipse(relleno, c.X - radio, c.Y - radio, 2 * radio, 2 * radio);
                using (Pen borde = new Pen(Color.White, 2))
                    g.DrawEllipse(borde, c.X - radio, c.Y - radio, 2 * radio, 2 * radio);

                // Porcentaje en una etiqueta blanca debajo del punto
                string porcentaje = maximo.ToString("0") + "%";
                SizeF t = g.MeasureString(porcentaje, fuente);
                RectangleF etiqueta = new RectangleF(c.X - t.Width / 2 - 2, c.Y + radio + 1, t.Width + 4, t.Height);
                using (GraphicsPath camino = Redondeado(etiqueta, 3))
                    g.FillPath(Brushes.White, camino);
                using (SolidBrush texto = new SolidBrush(Tema.Texto))
                    g.DrawString(porcentaje, fuente, texto, etiqueta.X + 2, etiqueta.Y);

                // Ya se recogió en esta ronda: chulo verde
                if (_puntosAtendidos.Contains(punto.Id))
                    DibujarTextoCentrado(g, "✓", fuenteNumero, Brushes.White, c);

                // Número de parada
                if (ordenParada.ContainsKey(punto.Id))
                {
                    PointF esquina = new PointF(c.X + 9, c.Y - 9);
                    using (SolidBrush fondoNumero = new SolidBrush(Tema.VerdeOscuro))
                        g.FillEllipse(fondoNumero, esquina.X - 8, esquina.Y - 8, 16, 16);
                    DibujarTextoCentrado(g, ordenParada[punto.Id].ToString(), fuenteNumero, Brushes.White, esquina);
                }
            }
        }

        // ---------------------------------------------------------------- carrito
        private void DibujarCarrito(Graphics g)
        {
            if (_carrito == null) return;
            PointF c = APantalla(_carrito.X, _carrito.Y);
            RectangleF caja = new RectangleF(c.X - 8, c.Y - 8, 16, 16);

            using (SolidBrush sombra = new SolidBrush(Color.FromArgb(60, 0, 0, 0)))
                g.FillRectangle(sombra, caja.X + 2, caja.Y + 2, caja.Width, caja.Height);
            using (SolidBrush cuerpo = new SolidBrush(Tema.VerdeOscuro))
                g.FillRectangle(cuerpo, caja);
            using (Pen borde = new Pen(Color.White, 2))
                g.DrawRectangle(borde, caja.X, caja.Y, caja.Width, caja.Height);

            using Font fuente = Tema.Fuente(7F, FontStyle.Bold);
            SizeF t = g.MeasureString("Operario", fuente);
            RectangleF etiqueta = new RectangleF(c.X - t.Width / 2 - 3, caja.Y - t.Height - 3, t.Width + 6, t.Height);
            using (GraphicsPath camino = Redondeado(etiqueta, 3))
            using (SolidBrush fondo = new SolidBrush(Tema.VerdeOscuro))
                g.FillPath(fondo, camino);
            g.DrawString("Operario", fuente, Brushes.White, etiqueta.X + 3, etiqueta.Y);
        }

        // ---------------------------------------------------------------- leyenda
        private void DibujarLeyenda(Graphics g)
        {
            float y = Height - AltoLeyenda + 4;
            float x = 12;
            using Font fuente = Tema.Fuente(7.5F);
            using SolidBrush texto = new SolidBrush(Tema.TextoSuave);

            x = ItemLeyenda(g, x, y, Tema.Verde, "< 50 %", fuente, texto, true);
            x = ItemLeyenda(g, x, y, Tema.Amarillo, "50–80 %", fuente, texto, true);
            x = ItemLeyenda(g, x, y, Tema.Rojo, "≥ 80 %", fuente, texto, true);
            x = ItemLeyenda(g, x, y, Tema.Ambar, "Ruta", fuente, texto, false);
            ItemLeyenda(g, x, y, Tema.VerdeOscuro, "Recorrido", fuente, texto, false);

            // Escala gráfica de 10 m
            float largo = 10 * _escala;
            float xEscala = Width - largo - 40;
            using (Pen negro = new Pen(Tema.Texto, 2))
                g.DrawLine(negro, xEscala, y + 12, xEscala + largo, y + 12);
            g.DrawString("10 m", fuente, texto, xEscala + largo + 4, y + 5);
        }

        private static float ItemLeyenda(Graphics g, float x, float y, Color color, string texto, Font fuente, Brush pincel, bool circulo)
        {
            using (SolidBrush relleno = new SolidBrush(color))
            {
                if (circulo) g.FillEllipse(relleno, x, y + 7, 10, 10);
                else g.FillRectangle(relleno, x, y + 10, 14, 4);
            }
            float ancho = circulo ? 10 : 14;
            g.DrawString(texto, fuente, pincel, x + ancho + 3, y + 5);
            return x + ancho + 3 + g.MeasureString(texto, fuente).Width + 10;
        }

        // ---------------------------------------------------------------- ayudas de dibujo
        private static void DibujarTextoCentrado(Graphics g, string texto, Font fuente, Brush pincel, PointF centro)
        {
            SizeF t = g.MeasureString(texto, fuente);
            g.DrawString(texto, fuente, pincel, centro.X - t.Width / 2, centro.Y - t.Height / 2);
        }

        /// <summary>Rectángulo con esquinas redondeadas.</summary>
        private static GraphicsPath Redondeado(RectangleF r, float radio)
        {
            GraphicsPath camino = new GraphicsPath();
            float d = radio * 2;
            camino.AddArc(r.X, r.Y, d, d, 180, 90);
            camino.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            camino.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            camino.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            camino.CloseFigure();
            return camino;
        }

        private static PointF[] Estrella(PointF centro, float rExterno, float rInterno)
        {
            PointF[] puntos = new PointF[10];
            for (int i = 0; i < 10; i++)
            {
                double angulo = -Math.PI / 2 + i * Math.PI / 5;
                float r = i % 2 == 0 ? rExterno : rInterno;
                puntos[i] = new PointF(centro.X + r * (float)Math.Cos(angulo), centro.Y + r * (float)Math.Sin(angulo));
            }
            return puntos;
        }

        // ---------------------------------------------------------------- tooltip
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (_ctx == null) return;

            long encontrado = -1;
            foreach (PuntoRecoleccion p in _ctx.Puntos.GetAll())
            {
                if (p.Tipo == TipoPunto.Interseccion) continue;
                PointF c = APantalla(p.X, p.Y);
                float dx = e.X - c.X, dy = e.Y - c.Y;
                if (dx * dx + dy * dy <= 12 * 12)
                {
                    encontrado = p.Id;
                    break;
                }
            }
            if (encontrado == _puntoBajoMouse) return;
            _puntoBajoMouse = encontrado;

            if (encontrado == -1)
            {
                _ayuda.Hide(this);
                return;
            }
            PuntoRecoleccion? punto = _ctx.Puntos.GetById(encontrado);
            if (punto == null) return;
            string texto = punto.Nombre;
            foreach (Contenedor c in _ctx.ContenedoresDe(punto.Id))
                texto += "\n• " + Formato.Nombre(c.Tipo) + ": " + c.Porcentaje.ToString("0") + " %";
            _ayuda.Show(texto, this, e.X + 14, e.Y + 14);
        }
    }
}
