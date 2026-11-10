using RutaCircular.Domain;
using RutaCircular.DynamicStructure;
using RutaCircular.Exceptions;
using RutaCircular.Infraestructure;

namespace RutaCircular.Services
{
    public class FrecuenciaPunto
    {
        public string Punto { get; set; } = string.Empty;
        public int Recolecciones { get; set; }
        public double PorSemana { get; set; }
        public double Kg { get; set; }
    }

    public class Indicadores
    {
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public double Dias { get; set; }
        public int TotalRecolecciones { get; set; }

        // Aprovechamiento (código de colores)
        public double KgTotales { get; set; }
        public double KgAprovechables { get; set; }
        public double KgOrganicos { get; set; }
        public double KgNoAprovechables { get; set; }
        public double PorcentajeAprovechable => KgTotales == 0 ? 0 : KgAprovechables / KgTotales * 100;
        public double PorcentajeOrganico => KgTotales == 0 ? 0 : KgOrganicos / KgTotales * 100;
        public double PorcentajeNoAprovechable => KgTotales == 0 ? 0 : KgNoAprovechables / KgTotales * 100;
        /// <summary>Blanco + verde: lo que se podría reciclar o compostar.</summary>
        public double PotencialAprovechamiento => PorcentajeAprovechable + PorcentajeOrganico;

        // Sostenibilidad
        public double KgPorCasaDia { get; set; }
        public double KgPorCasaDiaReferencia => ConstantesModelo.KgPorCasaDia;

        // Eficiencia (ruta de hoy vs. ronda tradicional)
        public Ruta? RutaOptimizada { get; set; }
        public Ruta? RondaTradicional { get; set; }
        public double AhorroDistanciaPorcentaje =>
            RutaOptimizada == null || RondaTradicional == null || RondaTradicional.DistanciaMetros == 0
                ? 0 : (1 - RutaOptimizada.DistanciaMetros / RondaTradicional.DistanciaMetros) * 100;

        // Estado actual
        public int ContenedoresSobreUmbral { get; set; }
        public int TotalContenedores { get; set; }

        public Lista<FrecuenciaPunto> Frecuencias { get; set; } = new();
    }

    /// <summary>
    /// Indicadores de control (la "C" del ciclo PODC): aprovechamiento, eficiencia, frecuencia y sostenibilidad.
    /// Todo sale del histórico de recolecciones y de la ruta calculada.
    /// </summary>
    public static class ServicioIndicadores
    {
        public static Indicadores Calcular(Contexto ctx, DateTime desde, DateTime hasta)
        {
            if (hasta <= desde) throw new ValidacionException("La fecha final debe ser posterior a la inicial.");
            double dias = (hasta - desde).TotalDays;

            double kgTotal = 0, kgAprov = 0, kgOrg = 0, kgNoAprov = 0, kgCasas = 0;
            int total = 0;
            var porPunto = new Dictionary<long, FrecuenciaPunto>();

            foreach (Recoleccion r in ctx.Recolecciones.GetAll())
            {
                if (r.Fecha < desde || r.Fecha >= hasta) continue;
                Contenedor? c = ctx.Contenedores.GetById(r.ContenedorId);
                if (c == null) continue;
                PuntoRecoleccion? p = ctx.Puntos.GetById(c.PuntoId);
                if (p == null) continue;

                total++;
                double kg = r.Kg;
                kgTotal += kg;
                switch (c.Tipo)
                {
                    case TipoResiduo.Aprovechable: kgAprov += kg; break;
                    case TipoResiduo.Organico: kgOrg += kg; break;
                    default: kgNoAprov += kg; break;
                }
                if (p.Tipo == TipoPunto.PuntoEcologico) kgCasas += kg;

                if (!porPunto.ContainsKey(p.Id))
                    porPunto[p.Id] = new FrecuenciaPunto { Punto = p.Nombre };
                porPunto[p.Id].Recolecciones++;
                porPunto[p.Id].Kg += kg;
            }

            var frecuencias = new Lista<FrecuenciaPunto>();
            List<long> ids = new List<long>(porPunto.Keys);
            ids.Sort();
            foreach (long id in ids)
            {
                FrecuenciaPunto f = porPunto[id];
                f.PorSemana = f.Recolecciones / (dias / 7);
                f.Kg = Math.Round(f.Kg, 1);
                frecuencias.Add(f);
            }

            // Eficiencia: ruta optimizada de hoy vs. ronda tradicional (todos los puntos, en orden de Id)
            Grafo grafo = ctx.ConstruirGrafo();
            long acopio = ctx.ObtenerAcopio().Id;
            Lista<ItemPrioridad> prioridad = ServicioPrioridad.Priorizar(ctx.Contenedores.GetAll(), ctx.Puntos.GetById, ctx.Reloj);

            Ruta optimizada = ServicioRutas.VecinoMasCercano(grafo, acopio, ServicioPrioridad.PuntosEnRuta(prioridad));
            optimizada.ContenedoresAVaciar = ServicioPrioridad.ContenedoresEnRuta(prioridad);

            var todos = new List<long>();
            foreach (PuntoRecoleccion p in ctx.Puntos.GetAll())
                if (p.TieneContenedores) todos.Add(p.Id);
            todos.Sort();
            Ruta tradicional = ServicioRutas.EnOrdenFijo(grafo, acopio, todos);
            tradicional.ContenedoresAVaciar = ctx.Contenedores.Count;

            int sobreUmbral = 0;
            foreach (Contenedor c in ctx.Contenedores.GetAll())
                if (c.Porcentaje >= ConstantesModelo.UmbralObligatorio * 100) sobreUmbral++;

            return new Indicadores
            {
                Desde = desde,
                Hasta = hasta,
                Dias = dias,
                TotalRecolecciones = total,
                KgTotales = kgTotal,
                KgAprovechables = kgAprov,
                KgOrganicos = kgOrg,
                KgNoAprovechables = kgNoAprov,
                KgPorCasaDia = kgCasas / ConstantesModelo.TotalCasas / dias,
                RutaOptimizada = optimizada,
                RondaTradicional = tradicional,
                ContenedoresSobreUmbral = sobreUmbral,
                TotalContenedores = ctx.Contenedores.Count,
                Frecuencias = frecuencias
            };
        }
    }
}
