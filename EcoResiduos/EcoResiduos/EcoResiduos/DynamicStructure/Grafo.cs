namespace EcoResiduos.DynamicStructure
{
    public class Arista
    {
        public long Destino { get; }
        public double Peso { get; }

        public Arista(long destino, double peso)
        {
            Destino = destino;
            Peso = peso;
        }
    }

    public class ResultadoDijkstra
    {
        public long Origen { get; }
        public Dictionary<long, double> Distancias { get; }
        public Dictionary<long, long> Previos { get; }

        public ResultadoDijkstra(long origen, Dictionary<long, double> distancias, Dictionary<long, long> previos)
        {
            Origen = origen;
            Distancias = distancias;
            Previos = previos;
        }

        public double DistanciaA(long nodo) =>
            Distancias.TryGetValue(nodo, out double d) ? d : double.PositiveInfinity;
    }

    /// <summary>
    /// Grafo no dirigido y ponderado con LISTA DE ADYACENCIA.
    /// Nodos = puntos del plano (Id), aristas = tramos de vía con su distancia en metros.
    /// Se eligió lista de adyacencia (y no matriz) porque el plano es poco denso:
    /// 17 nodos y 19 aristas → la matriz tendría 289 celdas casi todas vacías.
    /// Memoria O(V + E).
    /// </summary>
    public class Grafo
    {
        private readonly Dictionary<long, Lista<Arista>> _adyacencia = new();

        public int CantidadNodos => _adyacencia.Count;
        public int CantidadAristas { get; private set; }
        public IEnumerable<long> Nodos => _adyacencia.Keys;

        public void AgregarNodo(long id)
        {
            if (!_adyacencia.ContainsKey(id))
                _adyacencia[id] = new Lista<Arista>();
        }

        public void AgregarArista(long a, long b, double peso)
        {
            if (peso < 0) throw new ArgumentException("La distancia de una vía no puede ser negativa.");
            AgregarNodo(a);
            AgregarNodo(b);
            _adyacencia[a].Add(new Arista(b, peso));
            _adyacencia[b].Add(new Arista(a, peso));
            CantidadAristas++;
        }

        public bool ContieneNodo(long id) => _adyacencia.ContainsKey(id);

        public Lista<Arista> Vecinos(long id) =>
            _adyacencia.TryGetValue(id, out var lista) ? lista : new Lista<Arista>();

        /// <summary>
        /// Dijkstra: distancia mínima desde el origen hasta todos los nodos.
        /// Usa nuestra ColaPrioridad (min-heap) → O((V + E) log V).
        /// Si un nodo sale de la cola con una distancia vieja se ignora ("eliminación perezosa").
        /// </summary>
        public ResultadoDijkstra Dijkstra(long origen)
        {
            if (!ContieneNodo(origen))
                throw new ArgumentException($"El punto {origen} no existe en el grafo.");

            var distancias = new Dictionary<long, double>();
            var previos = new Dictionary<long, long>();
            foreach (long nodo in _adyacencia.Keys)
                distancias[nodo] = double.PositiveInfinity;
            distancias[origen] = 0;

            var cola = new ColaPrioridad<long>();
            cola.Encolar(origen, 0);

            while (!cola.IsEmpty)
            {
                long u = cola.Desencolar(out double distU);
                if (distU > distancias[u]) continue;   // entrada vieja

                foreach (Arista arista in _adyacencia[u])
                {
                    double nueva = distU + arista.Peso;
                    if (nueva < distancias[arista.Destino])
                    {
                        distancias[arista.Destino] = nueva;
                        previos[arista.Destino] = u;
                        cola.Encolar(arista.Destino, nueva);
                    }
                }
            }
            return new ResultadoDijkstra(origen, distancias, previos);
        }

        /// <summary>
        /// Reconstruye el camino origen → destino usando una PILA (Stack de .NET):
        /// los "previos" se leen del destino hacia atrás y la pila los devuelve en el orden correcto.
        /// </summary>
        public static Lista<long> ReconstruirCamino(ResultadoDijkstra resultado, long destino)
        {
            var camino = new Lista<long>();
            if (double.IsInfinity(resultado.DistanciaA(destino))) return camino;

            var pila = new Stack<long>();
            long actual = destino;
            pila.Push(actual);
            while (actual != resultado.Origen)
            {
                actual = resultado.Previos[actual];
                pila.Push(actual);
            }
            while (pila.Count > 0)
                camino.Add(pila.Pop());
            return camino;
        }
    }
}
