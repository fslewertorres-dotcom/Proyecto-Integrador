using EcoResiduos.Domain;
using EcoResiduos.Infraestructure;
using EcoResiduos.Services;
using EcoResiduos.Tools;

namespace EcoResiduos.Presentation
{
    /// <summary>Indicadores de control del proceso (Administración: la "C" del ciclo PODC).</summary>
    public partial class FrIndicadores : Form
    {
        private readonly Contexto _ctx = Contexto.Instancia;

        public FrIndicadores()
        {
            InitializeComponent();
            Tema.EstilizarTabla(dgvFrecuencia);
        }

        private void FrIndicadores_Load(object? sender, EventArgs e)
        {
            // Por defecto se toma todo el periodo del histórico
            DateTime minimo = _ctx.Reloj.Date.AddDays(-28);
            DateTime maximo = _ctx.Reloj.Date;
            bool primero = true;
            foreach (Recoleccion r in _ctx.Recolecciones.GetAll())
            {
                if (primero)
                {
                    minimo = r.Fecha.Date;
                    maximo = r.Fecha.Date;
                    primero = false;
                }
                if (r.Fecha.Date < minimo) minimo = r.Fecha.Date;
                if (r.Fecha.Date > maximo) maximo = r.Fecha.Date;
            }
            dtpDesde.Value = minimo;
            dtpHasta.Value = maximo;
            btnCalcular_Click(this, EventArgs.Empty);
        }

        private async void btnCalcular_Click(object? sender, EventArgs e)
        {
            btnCalcular.Enabled = false;
            try
            {
                DateTime desde = dtpDesde.Value.Date;
                DateTime hasta = dtpHasta.Value.Date.AddDays(1);   // incluye todo el último día
                Indicadores ind = await Task.Run(() => ServicioIndicadores.Calcular(_ctx, desde, hasta));
                Mostrar(ind);
            }
            catch (Exception ex)
            {
                Tool.MostrarError(ex);
            }
            finally
            {
                btnCalcular.Enabled = true;
            }
        }

        private void Mostrar(Indicadores ind)
        {
            // Tarjetas
            lblAprovValor.Text = ind.PotencialAprovechamiento.ToString("0") + " %";
            lblAprovDetalle.Text = "se puede reciclar o compostar";

            lblSostValor.Text = ind.KgPorCasaDia.ToString("0.00") + " kg";
            lblSostDetalle.Text = "por casa al día (ref. " + ind.KgPorCasaDiaReferencia.ToString("0.00") + ")";

            if (ind.RutaOptimizada != null && ind.RondaTradicional != null)
            {
                lblEficValor.Text = ind.AhorroDistanciaPorcentaje.ToString("0") + " %";
                lblEficDetalle.Text = "menos camino que la ronda fija";

                lblTradicional.Text = "Ronda tradicional (todos los puntos):\n" +
                                      ind.RondaTradicional.DistanciaMetros.ToString("0") + " m · " +
                                      ind.RondaTradicional.TiempoMinutos.ToString("0") + " min · $" +
                                      ind.RondaTradicional.Costo.ToString("N0");
                lblOptimizada.Text = "Ruta de hoy (solo lo necesario):\n" +
                                     ind.RutaOptimizada.DistanciaMetros.ToString("0") + " m · " +
                                     ind.RutaOptimizada.TiempoMinutos.ToString("0") + " min · $" +
                                     ind.RutaOptimizada.Costo.ToString("N0");
            }

            double porSemana = 0;
            if (ind.Dias > 0) porSemana = ind.TotalRecolecciones / (ind.Dias / 7);
            lblFrecValor.Text = porSemana.ToString("0") + " / semana";
            lblFrecDetalle.Text = ind.ContenedoresSobreUmbral + " de " + ind.TotalContenedores + " contenedores > 80 % hoy";

            // Tabla
            dgvFrecuencia.DataSource = ind.Frecuencias
                .Select(f => new
                {
                    f.Punto,
                    f.Recolecciones,
                    PorSemana = Math.Round(f.PorSemana, 1),
                    f.Kg
                })
                .ToList();

            // Barra de composición: el ancho de cada color es proporcional a su porcentaje
            int total = pnlBarras.Width;
            int anchoOrganico = (int)(total * ind.PorcentajeOrganico / 100);
            int anchoAprovechable = (int)(total * ind.PorcentajeAprovechable / 100);
            pnlBarraOrganico.SetBounds(0, 0, anchoOrganico, pnlBarras.Height);
            pnlBarraAprovechable.SetBounds(anchoOrganico, 0, anchoAprovechable, pnlBarras.Height);
            pnlBarraNoAprovechable.SetBounds(anchoOrganico + anchoAprovechable, 0,
                                             total - anchoOrganico - anchoAprovechable, pnlBarras.Height);
            lblComposicion.Text =
                "■ Orgánico (verde): " + ind.PorcentajeOrganico.ToString("0") + " %   " +
                "■ Aprovechable (blanco): " + ind.PorcentajeAprovechable.ToString("0") + " %\n" +
                "■ No aprovechable (negro): " + ind.PorcentajeNoAprovechable.ToString("0") + " %   " +
                "· Total: " + ind.KgTotales.ToString("N0") + " kg en " + ind.Dias.ToString("0") + " días";
        }
    }
}
