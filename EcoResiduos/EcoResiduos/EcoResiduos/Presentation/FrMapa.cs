using EcoResiduos.Domain;
using EcoResiduos.DynamicStructure;
using EcoResiduos.Exceptions;
using EcoResiduos.Infraestructure;
using EcoResiduos.Services;
using EcoResiduos.Tools;

namespace EcoResiduos.Presentation
{
    /// <summary>
    /// Pantalla principal de la operación: mapa, cola de prioridad, ruta del día paso a paso
    /// y la animación del operario recogiendo la ruta.
    /// </summary>
    public partial class FrMapa : Form
    {
        private readonly Contexto _ctx = Contexto.Instancia;
        private readonly ServicioRecoleccion _servicio;
        private Grafo? _grafo;
        private Lista<ItemPrioridad> _prioridad = new Lista<ItemPrioridad>();
        private Ruta? _ruta;
        private bool _rutaTerminada;
        private readonly List<PasoRuta> _pasos = new List<PasoRuta>();

        // ---- Estado de la animación del carrito ----
        private List<Coordenada> _camino = new List<Coordenada>();   // puntos (en metros) por donde pasa
        private List<long> _nodosCamino = new List<long>();           // Id del punto en cada posición del camino
        private long[] _paradas = new long[0];
        private int _tramo;            // tramo actual del camino (entre _camino[_tramo] y _camino[_tramo + 1])
        private double _avance;        // metros avanzados dentro del tramo actual
        private int _siguienteParada;  // índice en _paradas de la próxima parada
        private int _pausa;            // "ticks" que el carrito se queda quieto mientras vacía
        private double _litrosRecogidos;
        private int _contenedoresRecogidos;

        public FrMapa()
        {
            InitializeComponent();
            Tema.EstilizarTabla(dgvPrioridad);
            _servicio = new ServicioRecoleccion(_ctx);
            bool puedeRegistrar = Sesion.UsuarioActual != null && Sesion.UsuarioActual.PuedeRegistrarRecolecciones;
            btnRecogerRuta.Enabled = puedeRegistrar;
            btnVaciarSeleccionado.Enabled = puedeRegistrar;
        }

        private void FrMapa_Load(object? sender, EventArgs e)
        {
            try
            {
                _grafo = _ctx.ConstruirGrafo();
                Recalcular();
            }
            catch (Exception ex)
            {
                Tool.MostrarError(ex);
            }
        }

        /// <summary>Al volver a esta ventana se redibuja (por si se calcularon ubicaciones óptimas en otra).</summary>
        private void FrMapa_Activated(object? sender, EventArgs e)
        {
            panelMapa.Invalidate();
        }

        private bool Animando
        {
            get { return temporizador.Enabled; }
        }

        // =====================================================================
        //  PRIORIDAD Y RESUMEN
        // =====================================================================
        private void Recalcular()
        {
            _prioridad = ServicioPrioridad.Priorizar(_ctx.Contenedores.GetAll(), _ctx.Puntos.GetById, _ctx.Reloj);
            dgvPrioridad.DataSource = _prioridad
                .Select(i => new
                {
                    Orden = i.Posicion,
                    i.Contenedor.Id,
                    Punto = i.Punto.Nombre,
                    Tipo = Formato.Nombre(i.Contenedor.Tipo),
                    Llenado = i.Contenedor.Porcentaje.ToString("0") + " %",
                    SeLlenaEn = double.IsInfinity(i.HorasParaLlenarse) ? "> 1 semana" : i.HorasParaLlenarse.ToString("0.0") + " h",
                    EnRuta = i.EnRuta ? "Sí" : "No",
                    i.Motivo
                })
                .ToList();
            lblReloj.Text = Formato.Nombre(_ctx.Reloj.DayOfWeek) + " " + _ctx.Reloj.ToString("dd/MM/yyyy  HH:mm");
            MostrarResumen();
            panelMapa.Actualizar(_ctx, _ruta);
        }

        private void MostrarResumen()
        {
            if (_ruta == null)
            {
                lblDistanciaValor.Text = "—";
                lblTiempoValor.Text = "—";
                lblCostoValor.Text = "—";
                lblParadasValor.Text = "—";
            }
            else
            {
                lblDistanciaValor.Text = _ruta.DistanciaMetros.ToString("0") + " m";
                lblTiempoValor.Text = _ruta.TiempoMinutos.ToString("0") + " min";
                lblCostoValor.Text = "$" + _ruta.Costo.ToString("N0");
                lblParadasValor.Text = _ruta.Paradas.Count.ToString();
            }
            ArmarPasos();
        }

        /// <summary>Llena la lista "Recorrido paso a paso" con la salida, cada parada y el regreso.</summary>
        private void ArmarPasos()
        {
            _pasos.Clear();
            if (_ruta == null)
            {
                int pendientes = ServicioPrioridad.ContenedoresEnRuta(_prioridad);
                _pasos.Add(new PasoRuta
                {
                    Numero = "i",
                    Titulo = "Presione «Calcular ruta del día»",
                    Detalle = pendientes + " contenedores necesitan recolección (ver la pestaña Prioridad)."
                });
            }
            else
            {
                _pasos.Add(new PasoRuta { Numero = "A", Titulo = "Salida desde el cuarto de acopio", Detalle = "El operario toma el carro vacío." });

                double[] tramos = _ruta.DistanciasTramos.ToArray();
                int n = 0;
                foreach (long id in _ruta.Paradas)
                {
                    PuntoRecoleccion? punto = _ctx.Puntos.GetById(id);
                    List<Contenedor> aVaciar = ServicioPrioridad.ContenedoresEnRutaDe(_prioridad, id);
                    List<string> tipos = new List<string>();
                    foreach (Contenedor c in aVaciar) tipos.Add(Formato.Nombre(c.Tipo).ToLower());

                    _pasos.Add(new PasoRuta
                    {
                        Numero = (n + 1).ToString(),
                        Titulo = punto != null ? punto.Nombre : id.ToString(),
                        Detalle = "Camina " + tramos[n].ToString("0") + " m · vacía " + aVaciar.Count +
                                  (aVaciar.Count == 1 ? " contenedor" : " contenedores") +
                                  (tipos.Count > 0 ? " (" + string.Join(", ", tipos) + ")" : ""),
                        PuntoId = id
                    });
                    n++;
                }
                double regreso = n < tramos.Length ? tramos[n] : 0;
                _pasos.Add(new PasoRuta
                {
                    Numero = "A",
                    Titulo = "Regreso al cuarto de acopio",
                    Detalle = "Camina " + regreso.ToString("0") + " m y deja los residuos para la empresa de aseo."
                });

                if (_rutaTerminada)
                    foreach (PasoRuta paso in _pasos) paso.Estado = EstadoPaso.Hecho;
            }

            lstPasos.Items.Clear();
            foreach (PasoRuta paso in _pasos) lstPasos.Items.Add(paso);
        }

        // =====================================================================
        //  CALCULAR LA RUTA
        // =====================================================================
        private async void btnCalcularRuta_Click(object? sender, EventArgs e)
        {
            await CalcularRutaAsync();
        }

        private async Task CalcularRutaAsync()
        {
            if (_grafo == null || Animando) return;
            btnCalcularRuta.Enabled = false;
            try
            {
                panelMapa.ReiniciarAnimacion();
                _rutaTerminada = false;
                List<long> paradas = ServicioPrioridad.PuntosEnRuta(_prioridad);
                if (paradas.Count == 0)
                {
                    _ruta = null;
                    MessageBox.Show("Ningún contenedor necesita recolección por ahora.", "Ruta del día",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    long acopio = _ctx.ObtenerAcopio().Id;
                    Grafo grafo = _grafo;
                    // Tarea asíncrona: el cálculo corre en otro hilo y la ventana sigue respondiendo.
                    Ruta ruta = await Task.Run(() => ServicioRutas.VecinoMasCercano(grafo, acopio, paradas));
                    ruta.ContenedoresAVaciar = ServicioPrioridad.ContenedoresEnRuta(_prioridad);
                    _ruta = ruta;
                }
                MostrarResumen();
                tabsRuta.SelectedTab = tabRecorrido;
                panelMapa.Actualizar(_ctx, _ruta);
            }
            catch (Exception ex)
            {
                Tool.MostrarError(ex);
            }
            finally
            {
                btnCalcularRuta.Enabled = true;
            }
        }

        // =====================================================================
        //  RECOGER LA RUTA (animación)
        // =====================================================================
        private async void btnRecogerRuta_Click(object? sender, EventArgs e)
        {
            if (Animando) return;
            if (_ruta == null || _rutaTerminada)
            {
                await CalcularRutaAsync();
                if (_ruta == null) return;
            }

            // Se arma la lista de puntos (en metros) por donde pasa el carrito
            _camino = new List<Coordenada>();
            _nodosCamino = new List<long>();
            foreach (long id in _ruta.Recorrido)
            {
                PuntoRecoleccion? p = _ctx.Puntos.GetById(id);
                if (p == null) continue;
                _camino.Add(new Coordenada(p.X, p.Y));
                _nodosCamino.Add(id);
            }
            if (_camino.Count < 2) return;

            _paradas = _ruta.Paradas.ToArray();
            _tramo = 0;
            _avance = 0;
            _siguienteParada = 0;
            _pausa = 10;
            _litrosRecogidos = 0;
            _contenedoresRecogidos = 0;

            panelMapa.ReiniciarAnimacion();
            panelMapa.MoverCarrito(_camino[0], 0);
            CambiarEstadoPaso(0, EstadoPaso.Actual);
            tabsRuta.SelectedTab = tabRecorrido;
            HabilitarControles(false);
            temporizador.Start();
        }

        /// <summary>Cada 30 ms el carrito avanza unos metros por el camino.</summary>
        private void temporizador_Tick(object? sender, EventArgs e)
        {
            if (_pausa > 0)
            {
                _pausa--;
                return;
            }

            double metrosPorTick = trkVelocidad.Value * 0.6;
            double restante = metrosPorTick;

            while (restante > 0 && _tramo < _camino.Count - 1)
            {
                double largoTramo = Distancia(_camino[_tramo], _camino[_tramo + 1]);
                double falta = largoTramo - _avance;
                if (restante < falta)
                {
                    _avance += restante;
                    restante = 0;
                }
                else
                {
                    // Llegó al siguiente punto del camino
                    restante -= falta;
                    _tramo++;
                    _avance = 0;
                    if (LlegarA(_nodosCamino[_tramo])) break;   // se detiene a vaciar
                }
            }

            panelMapa.MoverCarrito(PosicionActual(), _tramo);

            if (_tramo >= _camino.Count - 1)
                TerminarRecorrido();
        }

        private Coordenada PosicionActual()
        {
            if (_tramo >= _camino.Count - 1) return _camino[_camino.Count - 1];
            Coordenada a = _camino[_tramo];
            Coordenada b = _camino[_tramo + 1];
            double largo = Distancia(a, b);
            double t = largo == 0 ? 0 : _avance / largo;
            return new Coordenada(a.X + (b.X - a.X) * t, a.Y + (b.Y - a.Y) * t);
        }

        private static double Distancia(Coordenada a, Coordenada b)
        {
            return Math.Sqrt((b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y));
        }

        /// <summary>
        /// Se llama cada vez que el carrito llega a un punto del camino.
        /// Si es la próxima parada, vacía sus contenedores y devuelve true (el carrito se detiene un momento).
        /// </summary>
        private bool LlegarA(long puntoId)
        {
            if (_siguienteParada >= _paradas.Length || _paradas[_siguienteParada] != puntoId)
                return false;

            long operario = Sesion.UsuarioActual != null ? Sesion.UsuarioActual.Id : 0;
            foreach (Contenedor c in ServicioPrioridad.ContenedoresEnRutaDe(_prioridad, puntoId))
            {
                try
                {
                    Recoleccion r = _servicio.Registrar(c, operario);
                    _litrosRecogidos += r.Litros;
                    _contenedoresRecogidos++;
                }
                catch (ValidacionException)
                {
                    // El contenedor ya estaba vacío: no hay nada que registrar
                }
            }

            panelMapa.MarcarAtendido(puntoId);
            int indicePaso = _siguienteParada + 1;          // el paso 0 es la salida
            CambiarEstadoPaso(indicePaso, EstadoPaso.Hecho);
            CambiarEstadoPaso(indicePaso + 1, EstadoPaso.Actual);
            _siguienteParada++;
            _pausa = 18;
            return true;
        }

        private async void TerminarRecorrido()
        {
            temporizador.Stop();
            foreach (PasoRuta paso in _pasos) paso.Estado = EstadoPaso.Hecho;
            lstPasos.Invalidate();
            _rutaTerminada = true;

            try
            {
                await _servicio.GuardarAsync();
            }
            catch (Exception ex)
            {
                Tool.MostrarError(ex);
            }

            double distancia = _ruta != null ? _ruta.DistanciaMetros : 0;
            Recalcular();
            HabilitarControles(true);
            MessageBox.Show("Ronda terminada.\n\n" +
                            "Contenedores vaciados: " + _contenedoresRecogidos + "\n" +
                            "Residuos recogidos: " + _litrosRecogidos.ToString("0") + " L (" +
                            (_litrosRecogidos * ConstantesModelo.DensidadKgPorLitro).ToString("0.0") + " kg)\n" +
                            "Distancia recorrida: " + distancia.ToString("0") + " m",
                            "Recolección", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CambiarEstadoPaso(int indice, EstadoPaso estado)
        {
            if (indice < 0 || indice >= _pasos.Count) return;
            _pasos[indice].Estado = estado;
            if (estado == EstadoPaso.Actual) lstPasos.TopIndex = Math.Max(0, indice - 2);
            lstPasos.Invalidate();
        }

        private void HabilitarControles(bool habilitar)
        {
            btnCalcularRuta.Enabled = habilitar;
            btnRecogerRuta.Enabled = habilitar;
            btnSimular.Enabled = habilitar;
            btnVaciarSeleccionado.Enabled = habilitar;
        }

        private void FrMapa_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!Animando) return;
            // Si se cierra a mitad de la ronda se guarda lo que ya se recogió
            temporizador.Stop();
            try
            {
                _ctx.Recolecciones.Commit();
                _ctx.Contenedores.Commit();
            }
            catch (Exception ex)
            {
                Tool.MostrarError(ex);
            }
        }

        // =====================================================================
        //  LISTA "RECORRIDO PASO A PASO" (dibujada a mano)
        // =====================================================================
        private void lstPasos_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= lstPasos.Items.Count) return;
            PasoRuta paso = (PasoRuta)lstPasos.Items[e.Index];
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            Rectangle r = e.Bounds;

            Color fondo = paso.Estado == EstadoPaso.Actual ? Color.FromArgb(255, 244, 222) : Color.White;
            using (SolidBrush pincelFondo = new SolidBrush(fondo))
                g.FillRectangle(pincelFondo, r);
            using (Pen linea = new Pen(Tema.Borde))
                g.DrawLine(linea, r.Left + 10, r.Bottom - 1, r.Right - 10, r.Bottom - 1);

            // Círculo con el número (verde = hecho, ámbar = actual, gris = pendiente)
            Color colorCirculo = Color.FromArgb(205, 212, 207);
            if (paso.Estado == EstadoPaso.Hecho) colorCirculo = Tema.Verde;
            if (paso.Estado == EstadoPaso.Actual) colorCirculo = Tema.Ambar;
            Rectangle circulo = new Rectangle(r.Left + 10, r.Top + 5, 24, 24);
            using (SolidBrush pincelCirculo = new SolidBrush(colorCirculo))
                g.FillEllipse(pincelCirculo, circulo);

            string numero = paso.Estado == EstadoPaso.Hecho ? "✓" : paso.Numero;
            using (Font fuenteNumero = new Font("Segoe UI", 8.5F, FontStyle.Bold))
            {
                SizeF t = g.MeasureString(numero, fuenteNumero);
                g.DrawString(numero, fuenteNumero, Brushes.White,
                             circulo.X + (circulo.Width - t.Width) / 2, circulo.Y + (circulo.Height - t.Height) / 2);
            }

            using (Font fuenteTitulo = new Font("Segoe UI", 9.5F, FontStyle.Bold))
            using (Font fuenteDetalle = new Font("Segoe UI", 8.25F))
            using (SolidBrush pincelTitulo = new SolidBrush(Tema.Texto))
            using (SolidBrush pincelDetalle = new SolidBrush(Tema.TextoSuave))
            {
                g.DrawString(paso.Titulo, fuenteTitulo, pincelTitulo, r.Left + 44, r.Top + 1);
                g.DrawString(paso.Detalle, fuenteDetalle, pincelDetalle, r.Left + 44, r.Top + 17);
            }
        }

        // =====================================================================
        //  SIMULAR TIEMPO Y VACIAR UN CONTENEDOR
        // =====================================================================
        private async void btnSimular_Click(object? sender, EventArgs e)
        {
            if (Animando) return;
            btnSimular.Enabled = false;
            try
            {
                double horas = (double)numHoras.Value;
                double desbordado = _servicio.SimularTiempo(horas);
                _ruta = null;
                _rutaTerminada = false;
                panelMapa.ReiniciarAnimacion();
                Recalcular();
                await _servicio.GuardarAsync();
                FrMain? principal = MdiParent as FrMain;
                if (principal != null) principal.ActualizarEstado();
                if (desbordado > 0)
                    MessageBox.Show("¡Atención! En estas " + horas.ToString("0") + " horas se desbordaron " +
                                    desbordado.ToString("0") + " litros de residuos.",
                                    "Desbordamiento", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                Tool.MostrarError(ex);
            }
            finally
            {
                btnSimular.Enabled = true;
            }
        }

        private async void btnVaciarSeleccionado_Click(object? sender, EventArgs e)
        {
            if (dgvPrioridad.CurrentRow == null || Animando) return;
            try
            {
                long id = Convert.ToInt64(dgvPrioridad.CurrentRow.Cells["Id"].Value);
                Contenedor? contenedor = _ctx.Contenedores.GetById(id);
                if (contenedor == null) throw new ValidacionException("No existe el contenedor " + id + ".");
                long operario = Sesion.UsuarioActual != null ? Sesion.UsuarioActual.Id : 0;
                Recoleccion r = _servicio.Registrar(contenedor, operario);
                await _servicio.GuardarAsync();
                Recalcular();
                MessageBox.Show("Se registró la recolección de " + r.Litros.ToString("0.#") + " L (" + r.Kg.ToString("0.#") +
                                " kg) de " + _ctx.Describir(contenedor) + ".",
                                "Recolección", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Tool.MostrarError(ex);
            }
        }

        /// <summary>Pinta las filas: rojo = más del 80 %, amarillo = entra a la ruta.</summary>
        private void dgvPrioridad_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || !dgvPrioridad.Columns.Contains("Motivo") || e.CellStyle == null) return;
            object? motivo = dgvPrioridad.Rows[e.RowIndex].Cells["Motivo"].Value;
            object? enRuta = dgvPrioridad.Rows[e.RowIndex].Cells["EnRuta"].Value;
            if (Equals(motivo, "Más del 80 %")) e.CellStyle.BackColor = Color.FromArgb(253, 226, 226);
            else if (Equals(enRuta, "Sí")) e.CellStyle.BackColor = Color.FromArgb(255, 246, 214);
        }
    }
}
