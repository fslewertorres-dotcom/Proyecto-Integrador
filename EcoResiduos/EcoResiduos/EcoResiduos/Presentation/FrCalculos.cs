using EcoResiduos.Domain;
using EcoResiduos.Infraestructure;
using EcoResiduos.Services.Calculo;
using EcoResiduos.Tools;

namespace EcoResiduos.Presentation
{
    /// <summary>
    /// Módulo de cálculo: predicción de llenado (integral) y ubicación óptima de un punto ecológico (gradiente).
    /// Muestra solo el resultado y una explicación corta; el desarrollo matemático está en Documentos.
    /// </summary>
    public partial class FrCalculos : Form
    {
        private readonly Contexto _ctx = Contexto.Instancia;

        public FrCalculos()
        {
            InitializeComponent();

            cbContenedor.DisplayMember = "Texto";
            cbContenedor.ValueMember = "Id";
            cbContenedor.DataSource = _ctx.Contenedores.GetAll()
                .Select(c => new { c.Id, Texto = c.Id + " · " + _ctx.Describir(c) })
                .ToList();

            cbAlcance.Items.Add("Todo el conjunto (96 casas)");
            for (int v = 1; v <= 4; v++)
                cbAlcance.Items.Add("Vía " + v + " (24 casas)");
            cbAlcance.SelectedIndex = 1;
        }

        // ============================ PREDICCIÓN ============================
        private void btnPredecir_Click(object? sender, EventArgs e)
        {
            try
            {
                if (cbContenedor.SelectedValue == null) return;
                long id = (long)cbContenedor.SelectedValue;
                Contenedor? c = _ctx.Contenedores.GetById(id);
                if (c == null) return;
                PuntoRecoleccion? p = _ctx.Puntos.GetById(c.PuntoId);
                if (p == null) return;

                DateTime ahora = _ctx.Reloj;
                double horas = Prediccion.HorasParaLlenarse(c, p.Tipo, ahora);

                // Resultado principal
                if (double.IsInfinity(horas))
                {
                    lblResultadoValor.Text = "Más de 1 semana";
                    lblResultadoFecha.Text = "No necesita recolección pronto.";
                }
                else
                {
                    DateTime cuando = ahora.AddHours(horas);
                    lblResultadoValor.Text = horas.ToString("0.0") + " horas";
                    lblResultadoFecha.Text = "El " + Formato.Nombre(cuando.DayOfWeek).ToLower() + " " + cuando.ToString("dd/MM") +
                                             " a las " + cuando.ToString("HH:mm");
                }

                double horasConstante = Prediccion.HorasConTasaConstante(c);
                lblComparacion.Text = double.IsInfinity(horasConstante)
                    ? ""
                    : "Si la basura cayera siempre al mismo ritmo serían " + horasConstante.ToString("0.0") + " horas.";

                // Nivel actual
                double porcentaje = c.Porcentaje;
                pnlNivelRelleno.Width = (int)(pnlNivelBarra.Width * Math.Min(100, porcentaje) / 100);
                pnlNivelRelleno.BackColor = ColorSegunNivel(porcentaje);
                lblNivelTexto.Text = c.NivelLitros.ToString("0") + " de " + c.CapacidadLitros.ToString("0") +
                                     " litros (" + porcentaje.ToString("0") + " %)";

                // Gráfico: nivel cada 3 horas
                double[] valores = new double[9];
                string[] etiquetas = new string[9];
                for (int i = 0; i <= 8; i++)
                {
                    int h = i * 3;
                    double nivel = Prediccion.NivelFuturo(c, p.Tipo, ahora, h);
                    valores[i] = nivel / c.CapacidadLitros * 100;
                    etiquetas[i] = ahora.AddHours(h).ToString("HH:mm");
                }
                graficoNivel.Titulo = "Nivel proyectado: " + _ctx.Describir(c);
                graficoNivel.MostrarDatos(valores, etiquetas);
            }
            catch (Exception ex)
            {
                Tool.MostrarError(ex);
            }
        }

        private static Color ColorSegunNivel(double porcentaje)
        {
            if (porcentaje >= 80) return Tema.Rojo;
            if (porcentaje >= 50) return Tema.Amarillo;
            return Tema.Verde;
        }

        // ========================= UBICACIÓN ÓPTIMA =========================
        private void btnOptimizar_Click(object? sender, EventArgs e)
        {
            try
            {
                int via = cbAlcance.SelectedIndex;   // 0 = todo el conjunto, 1..4 = vía
                PuntoPeso[] casas = Optimizacion.CasasComoPuntos(via);

                // Punto de partida: el punto ecológico actual de esa vía (o el acopio, para todo el conjunto)
                PuntoRecoleccion inicial = _ctx.ObtenerAcopio();
                if (via > 0)
                {
                    PuntoRecoleccion? puntoVia = PuntoEcologicoDeVia(via);
                    if (puntoVia != null) inicial = puntoVia;
                }

                ResultadoOptimizacion r = Optimizacion.UbicacionOptima(casas, inicial.X, inicial.Y);

                lblActualValor.Text = "(" + inicial.X.ToString("0") + ", " + inicial.Y.ToString("0") + ") m";
                lblActualDetalle.Text = inicial.Nombre + "\nCada casa camina en promedio " + r.DistanciaPromedioInicial.ToString("0.0") + " m";

                lblOptimaValor.Text = "(" + r.XOptimo.ToString("0") + ", " + r.YOptimo.ToString("0") + ") m";
                lblOptimaDetalle.Text = "Cada casa caminaría en promedio " + r.DistanciaPromedioOptima.ToString("0.0") + " m";

                double ahorro = 0;
                if (r.DistanciaPromedioInicial > 0)
                    ahorro = (1 - r.DistanciaPromedioOptima / r.DistanciaPromedioInicial) * 100;
                lblAhorroValor.Text = ahorro.ToString("0") + " % menos";
                lblAhorroDetalle.Text = "Se encontró en " + r.Iteraciones + " pasos del método del gradiente.";

                // Se guarda para dibujarlo en el mapa
                string etiqueta = via == 0 ? "Óptimo conjunto" : "Óptimo vía " + via;
                _ctx.UbicacionesOptimas.RemoveAll(u => u.Etiqueta == etiqueta);
                _ctx.UbicacionesOptimas.Add(new Coordenada(r.XOptimo, r.YOptimo, etiqueta));
                _ctx.TrayectoriaGradiente.Clear();
                foreach (Coordenada paso in r.Trayectoria)
                    _ctx.TrayectoriaGradiente.Add(paso);
            }
            catch (Exception ex)
            {
                Tool.MostrarError(ex);
            }
        }

        /// <summary>El punto ecológico más cercano al centro de la vía indicada.</summary>
        private PuntoRecoleccion? PuntoEcologicoDeVia(int via)
        {
            double yVia = PlanoConjunto.YVias[via - 1];
            PuntoRecoleccion? mejor = null;
            foreach (PuntoRecoleccion p in _ctx.Puntos.GetAll())
            {
                if (p.Tipo != TipoPunto.PuntoEcologico) continue;
                if (mejor == null || Math.Abs(p.Y - yVia) < Math.Abs(mejor.Y - yVia)) mejor = p;
            }
            return mejor;
        }

        private void btnVerMapa_Click(object? sender, EventArgs e)
        {
            if (MdiParent != null) Tool.openForm<FrMapa>(MdiParent);
        }

        private void btnQuitarOptimos_Click(object? sender, EventArgs e)
        {
            _ctx.UbicacionesOptimas.Clear();
            _ctx.TrayectoriaGradiente.Clear();
            MessageBox.Show("Se quitaron las ubicaciones óptimas del mapa.", "Ubicación óptima",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
