using RutaCircular.DynamicStructure;
using RutaCircular.Exceptions;
using RutaCircular.Services.Calculo;

namespace RutaCircular.Services
{
    public class Ruta
    {
        /// <summary>Puntos donde el operario se detiene, en orden.</summary>
        public Lista<long> Paradas { get; } = new Lista<long>();
        /// <summary>Todos los nodos por los que pasa (incluye intersecciones), para dibujarla.</summary>
        public Lista<long> Recorrido { get; } = new Lista<long>();
        /// <summary>Metros de cada tramo: acopio → parada 1, parada 1 → parada 2, ..., última → acopio.</summary>
        public Lista<double> DistanciasTramos { get; } = new Lista<double>();
        public double DistanciaMetros { get; set; }
        public int ContenedoresAVaciar { get; set; }

        public double TiempoMinutos { get { return ModeloCosto.TiempoMinutos(DistanciaMetros, ContenedoresAVaciar); } }
        public double Costo { get { return ModeloCosto.Costo(DistanciaMetros, ContenedoresAVaciar); } }
    }

    /// <summary>
    /// Ruta del día con la heurística del VECINO MÁS CERCANO sobre distancias de Dijkstra:
    /// desde el acopio, ir siempre al punto pendiente más cercano; al final volver al acopio.
    /// Complejidad: k paradas × Dijkstra O((V+E) log V) = O(k (V+E) log V).
    /// No garantiza la ruta perfecta (eso es el problema del viajante), pero es rápida y buena para pocos puntos.
    /// </summary>
    public static class ServicioRutas
    {
        public static Ruta VecinoMasCercano(Grafo grafo, long inicio, List<long> puntosPorVisitar)
        {
            List<long> pendientes = new List<long>();
            foreach (long p in puntosPorVisitar)
                if (p != inicio && !pendientes.Contains(p)) pendientes.Add(p);
            Validar(grafo, inicio, pendientes);

            Ruta ruta = new Ruta();
            ruta.Recorrido.Add(inicio);
            long actual = inicio;

            while (pendientes.Count > 0)
            {
                ResultadoDijkstra distancias = grafo.Dijkstra(actual);

                // Buscar el punto pendiente más cercano
                long mejor = -1;
                double mejorDistancia = double.PositiveInfinity;
                foreach (long candidato in pendientes)
                {
                    double d = distancias.DistanciaA(candidato);
                    if (d < mejorDistancia)
                    {
                        mejor = candidato;
                        mejorDistancia = d;
                    }
                }
                if (mejor == -1)
                    throw new RutaCircularException($"No hay camino desde el punto {actual} hasta los puntos pendientes.");

                AgregarTramo(ruta, distancias, mejor);
                ruta.Paradas.Add(mejor);
                pendientes.Remove(mejor);
                actual = mejor;
            }

            VolverAlInicio(grafo, ruta, actual, inicio);
            return ruta;
        }

        /// <summary>Ruta en un orden fijo (la "ronda tradicional"), para comparar contra la optimizada.</summary>
        public static Ruta EnOrdenFijo(Grafo grafo, long inicio, List<long> puntosEnOrden)
        {
            Validar(grafo, inicio, puntosEnOrden);

            Ruta ruta = new Ruta();
            ruta.Recorrido.Add(inicio);
            long actual = inicio;
            foreach (long siguiente in puntosEnOrden)
            {
                if (siguiente == inicio) continue;
                ResultadoDijkstra distancias = grafo.Dijkstra(actual);
                if (double.IsInfinity(distancias.DistanciaA(siguiente)))
                    throw new RutaCircularException($"No hay camino desde el punto {actual} hasta el {siguiente}.");
                AgregarTramo(ruta, distancias, siguiente);
                ruta.Paradas.Add(siguiente);
                actual = siguiente;
            }
            VolverAlInicio(grafo, ruta, actual, inicio);
            return ruta;
        }

        private static void Validar(Grafo grafo, long inicio, List<long> puntos)
        {
            if (!grafo.ContieneNodo(inicio))
                throw new ValidacionException($"El punto de inicio {inicio} no está en el plano.");
            foreach (long p in puntos)
                if (!grafo.ContieneNodo(p))
                    throw new ValidacionException($"El punto {p} no está en el plano.");
        }

        private static void VolverAlInicio(Grafo grafo, Ruta ruta, long actual, long inicio)
        {
            if (actual == inicio) return;
            ResultadoDijkstra distancias = grafo.Dijkstra(actual);
            if (double.IsInfinity(distancias.DistanciaA(inicio)))
                throw new RutaCircularException("No hay camino de regreso al cuarto de acopio.");
            AgregarTramo(ruta, distancias, inicio);
        }

        private static void AgregarTramo(Ruta ruta, ResultadoDijkstra distancias, long destino)
        {
            bool primero = true;
            foreach (long nodo in Grafo.ReconstruirCamino(distancias, destino))
            {
                if (primero)
                {
                    primero = false;   // el primero ya está en el recorrido
                    continue;
                }
                ruta.Recorrido.Add(nodo);
            }
            double metros = distancias.DistanciaA(destino);
            ruta.DistanciasTramos.Add(metros);
            ruta.DistanciaMetros += metros;
        }
    }
}
