using RutaCircular.Domain;
using RutaCircular.DynamicStructure;
using RutaCircular.Exceptions;
using RutaCircular.Infraestructure;

namespace RutaCircular.Services
{
    /// <summary>Reglas para editar las vías (aristas del grafo).</summary>
    public class ServicioVias
    {
        private readonly Contexto _ctx;

        public ServicioVias(Contexto contexto)
        {
            _ctx = contexto;
        }

        /// <summary>Longitud del segmento entre dos puntos: ‖B − A‖ = √((x₂−x₁)² + (y₂−y₁)²).</summary>
        public double DistanciaEuclidiana(long origenId, long destinoId)
        {
            PuntoRecoleccion a = _ctx.Puntos.GetById(origenId) ?? throw new ValidacionException($"No existe el punto {origenId}.");
            PuntoRecoleccion b = _ctx.Puntos.GetById(destinoId) ?? throw new ValidacionException($"No existe el punto {destinoId}.");
            return Math.Round(Math.Sqrt((b.X - a.X) * (b.X - a.X) + (b.Y - a.Y) * (b.Y - a.Y)), 2);
        }

        /// <summary>Valida la vía y, si la distancia es 0, la calcula con las coordenadas.</summary>
        public Via Preparar(long id, long origenId, long destinoId, double distancia)
        {
            if (id <= 0) throw new ValidacionException("El Id debe ser mayor que cero.");
            if (!_ctx.Puntos.Exist(origenId) || !_ctx.Puntos.Exist(destinoId))
                throw new ValidacionException("Seleccione un origen y un destino que existan.");
            if (origenId == destinoId)
                throw new ValidacionException("El origen y el destino no pueden ser el mismo punto.");
            if (distancia < 0)
                throw new ValidacionException("La distancia no puede ser negativa.");

            // No se permiten dos vías entre los mismos puntos (en cualquier sentido, porque el grafo no es dirigido)
            foreach (Via v in _ctx.Vias.GetAll())
            {
                bool mismoPar = (v.OrigenId == origenId && v.DestinoId == destinoId)
                             || (v.OrigenId == destinoId && v.DestinoId == origenId);
                if (mismoPar && v.Id != id)
                    throw new ValidacionException($"Ya existe la vía {v.Id} entre esos dos puntos.");
            }

            return new Via
            {
                Id = id,
                OrigenId = origenId,
                DestinoId = destinoId,
                DistanciaMetros = distancia > 0 ? distancia : DistanciaEuclidiana(origenId, destinoId)
            };
        }

        /// <summary>
        /// Puntos con contenedores a los que no se puede llegar desde el acopio (Dijkstra da infinito).
        /// Sirve para avisar si al borrar una vía el conjunto quedó "partido".
        /// </summary>
        public List<string> PuntosInalcanzables()
        {
            Grafo grafo = _ctx.ConstruirGrafo();
            ResultadoDijkstra desdeAcopio = grafo.Dijkstra(_ctx.ObtenerAcopio().Id);
            var aislados = new List<string>();
            foreach (PuntoRecoleccion p in _ctx.Puntos.GetAll())
                if (p.TieneContenedores && double.IsInfinity(desdeAcopio.DistanciaA(p.Id)))
                    aislados.Add(p.Nombre);
            return aislados;
        }
    }
}
