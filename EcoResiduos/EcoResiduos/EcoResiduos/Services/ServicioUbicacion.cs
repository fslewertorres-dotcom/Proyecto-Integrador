using EcoResiduos.Domain;
using EcoResiduos.Exceptions;
using EcoResiduos.Infraestructure;

namespace EcoResiduos.Services
{
    /// <summary>
    /// Mueve un punto ecológico a la ubicación óptima (gradiente) y permite deshacerlo.
    /// Al mover el punto también se recalcula el largo de las vías que llegan a él,
    /// para que la ruta del día use las distancias nuevas.
    /// </summary>
    public static class ServicioUbicacion
    {
        public static bool TieneOriginal(Contexto ctx, long puntoId) => ctx.UbicacionesOriginales.ContainsKey(puntoId);

        public static void Mover(Contexto ctx, long puntoId, double x, double y)
        {
            PuntoRecoleccion punto = ctx.Puntos.GetById(puntoId)
                ?? throw new ValidacionException($"No existe el punto {puntoId}.");

            // La ubicación original se guarda solo la primera vez (si se mueve dos veces, se vuelve a la primera).
            if (!ctx.UbicacionesOriginales.ContainsKey(puntoId))
            {
                ctx.UbicacionesOriginales[puntoId] = new Coordenada(punto.X, punto.Y);
                foreach (Via v in ViasDe(ctx, puntoId))
                    if (!ctx.DistanciasOriginales.ContainsKey(v.Id))
                        ctx.DistanciasOriginales[v.Id] = v.DistanciaMetros;
            }

            punto.X = Math.Round(x, 1);
            punto.Y = Math.Round(y, 1);

            ServicioVias servicioVias = new ServicioVias(ctx);
            foreach (Via v in ViasDe(ctx, puntoId))
                v.DistanciaMetros = servicioVias.DistanciaEuclidiana(v.OrigenId, v.DestinoId);
        }

        public static void Restaurar(Contexto ctx, long puntoId)
        {
            if (!ctx.UbicacionesOriginales.TryGetValue(puntoId, out Coordenada? original))
                throw new ValidacionException("Ese punto está en su ubicación original.");
            PuntoRecoleccion punto = ctx.Puntos.GetById(puntoId)
                ?? throw new ValidacionException($"No existe el punto {puntoId}.");

            punto.X = original.X;
            punto.Y = original.Y;
            ctx.UbicacionesOriginales.Remove(puntoId);

            ServicioVias servicioVias = new ServicioVias(ctx);
            foreach (Via v in ViasDe(ctx, puntoId))
            {
                long otroExtremo = v.OrigenId == puntoId ? v.DestinoId : v.OrigenId;
                if (ctx.UbicacionesOriginales.ContainsKey(otroExtremo))
                {
                    // El otro extremo también se movió: la vía sigue sin su largo original.
                    v.DistanciaMetros = servicioVias.DistanciaEuclidiana(v.OrigenId, v.DestinoId);
                }
                else if (ctx.DistanciasOriginales.TryGetValue(v.Id, out double metros))
                {
                    v.DistanciaMetros = metros;
                    ctx.DistanciasOriginales.Remove(v.Id);
                }
            }
        }

        private static List<Via> ViasDe(Contexto ctx, long puntoId)
        {
            List<Via> vias = new List<Via>();
            foreach (Via v in ctx.Vias.GetAll())
                if (v.OrigenId == puntoId || v.DestinoId == puntoId) vias.Add(v);
            return vias;
        }
    }
}
