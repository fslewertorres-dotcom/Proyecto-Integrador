using RutaCircular.Domain;
using RutaCircular.DynamicStructure;
using RutaCircular.Exceptions;
using RutaCircular.Services.Calculo;

namespace RutaCircular.Services
{
    public class ItemPrioridad
    {
        public int Posicion { get; set; }
        public Contenedor Contenedor { get; set; } = null!;
        public PuntoRecoleccion Punto { get; set; } = null!;
        public double HorasParaLlenarse { get; set; }
        /// <summary>Horas para llenarse, divididas entre 2 si es orgánico. Menor = más urgente.</summary>
        public double Urgencia { get; set; }
        /// <summary>Supera el 80 %: entra a la ruta sí o sí.</summary>
        public bool Obligatorio { get; set; }
        public bool EnRuta { get; set; }
        /// <summary>Texto corto que explica por qué entra (o no) a la ruta.</summary>
        public string Motivo { get; set; } = string.Empty;
    }

    /// <summary>
    /// REGLA DE PRIORIDAD (une Cálculo + Estructuras):
    ///  1. Horas para llenarse = integral de la tasa de generación (Prediccion, Simpson).
    ///  2. Urgencia = horas; los orgánicos cuentan el doble de urgentes (horas / 2) por olores y plagas.
    ///  3. Más del 80 % → obligatorio (va primero).
    ///  4. Entra a la ruta si es obligatorio, si se llena en menos de 24 h, o si está en una
    ///     zona social (piscina, gimnasio, asados, parque): esas áreas se revisan en cada ronda
    ///     porque son de uso común y deben quedar limpias.
    /// El orden lo da nuestra ColaPrioridad (min-heap): n inserciones + n extracciones = O(n log n).
    /// </summary>
    public static class ServicioPrioridad
    {
        private const double PenalizacionObligatorio = 1000000;

        public static Lista<ItemPrioridad> Priorizar(IEnumerable<Contenedor> contenedores,
                                                     Func<long, PuntoRecoleccion?> buscarPunto,
                                                     DateTime reloj)
        {
            ColaPrioridad<ItemPrioridad> cola = new ColaPrioridad<ItemPrioridad>();
            foreach (Contenedor c in contenedores)
            {
                PuntoRecoleccion? punto = buscarPunto(c.PuntoId);
                if (punto == null)
                    throw new DatosInvalidosException($"El contenedor {c.Id} está en el punto {c.PuntoId}, que no existe.");

                double horas = Prediccion.HorasParaLlenarse(c, punto.Tipo, reloj);
                double urgencia = horas;
                if (c.Tipo == TipoResiduo.Organico) urgencia = horas / 2;

                bool obligatorio = c.Porcentaje >= ConstantesModelo.UmbralObligatorio * 100;
                bool seLlenaPronto = urgencia <= ConstantesModelo.HorizonteRutaHoras;
                bool zonaSocial = punto.EsZonaComun && c.NivelLitros > 0;

                ItemPrioridad item = new ItemPrioridad();
                item.Contenedor = c;
                item.Punto = punto;
                item.HorasParaLlenarse = horas;
                item.Urgencia = urgencia;
                item.Obligatorio = obligatorio;
                item.EnRuta = obligatorio || seLlenaPronto || zonaSocial;

                if (obligatorio) item.Motivo = "Más del 80 %";
                else if (seLlenaPronto) item.Motivo = "Se llena pronto";
                else if (zonaSocial) item.Motivo = "Zona social";
                else item.Motivo = "Puede esperar";

                double prioridad = urgencia;
                if (obligatorio) prioridad = urgencia - PenalizacionObligatorio;
                cola.Encolar(item, prioridad);
            }

            Lista<ItemPrioridad> resultado = new Lista<ItemPrioridad>();
            int posicion = 1;
            while (!cola.IsEmpty)
            {
                ItemPrioridad item = cola.Desencolar();
                item.Posicion = posicion;
                posicion++;
                resultado.Add(item);
            }
            return resultado;
        }

        /// <summary>Ids de los puntos (sin repetir) que tienen al menos un contenedor en ruta.</summary>
        public static List<long> PuntosEnRuta(Lista<ItemPrioridad> prioridad)
        {
            List<long> puntos = new List<long>();
            foreach (ItemPrioridad item in prioridad)
                if (item.EnRuta && !puntos.Contains(item.Punto.Id))
                    puntos.Add(item.Punto.Id);
            return puntos;
        }

        public static int ContenedoresEnRuta(Lista<ItemPrioridad> prioridad)
        {
            int n = 0;
            foreach (ItemPrioridad item in prioridad)
                if (item.EnRuta) n++;
            return n;
        }

        /// <summary>Contenedores en ruta de un punto (los que se vacían al llegar a esa parada).</summary>
        public static List<Contenedor> ContenedoresEnRutaDe(Lista<ItemPrioridad> prioridad, long puntoId)
        {
            List<Contenedor> lista = new List<Contenedor>();
            foreach (ItemPrioridad item in prioridad)
                if (item.EnRuta && item.Punto.Id == puntoId)
                    lista.Add(item.Contenedor);
            return lista;
        }
    }
}
