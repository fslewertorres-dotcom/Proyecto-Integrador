using EcoResiduos.Domain;
using EcoResiduos.DynamicStructure;
using EcoResiduos.Exceptions;
using EcoResiduos.Services.Calculo;

namespace EcoResiduos.Services
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
    ///     zona social (piscina, gimnasio, asados, parque) y pasa del 30 %: esas áreas son de uso
    ///     común y deben quedar limpias, pero no vale la pena ir a vaciar una caneca casi vacía.
    ///  5. "Aprovechar el viaje": si el operario ya va a detenerse en un punto, también vacía
    ///     los contenedores de ese punto que pasen del 40 %, para no tener que volver pronto.
    /// El orden lo da nuestra ColaPrioridad (min-heap): n inserciones + n extracciones = O(n log n).
    /// </summary>
    public static class ServicioPrioridad
    {
        private const double PenalizacionObligatorio = 1000000;

        /// <summary>Comienzo del texto del Motivo de los obligatorios (el mapa lo usa para pintar la fila de rojo).</summary>
        public const string MotivoObligatorio = "Más del 80 %";

        public static Lista<ItemPrioridad> Priorizar(IEnumerable<Contenedor> contenedores,
                                                     Func<long, PuntoRecoleccion?> buscarPunto,
                                                     DateTime reloj)
        {
            List<ItemPrioridad> items = new List<ItemPrioridad>();
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
                bool zonaSocial = punto.EsZonaComun && c.Porcentaje >= ConstantesModelo.UmbralZonaSocial * 100;

                ItemPrioridad item = new ItemPrioridad();
                item.Contenedor = c;
                item.Punto = punto;
                item.HorasParaLlenarse = horas;
                item.Urgencia = urgencia;
                item.Obligatorio = obligatorio;
                item.EnRuta = obligatorio || seLlenaPronto || zonaSocial;

                if (obligatorio)
                    item.Motivo = $"{MotivoObligatorio} (va sí o sí)";
                else if (seLlenaPronto && horas > ConstantesModelo.HorizonteRutaHoras)
                    item.Motivo = $"Orgánico, se llena en {Horas(horas)}";   // los orgánicos se adelantan por olores
                else if (seLlenaPronto)
                    item.Motivo = $"Se llena pronto (en {Horas(horas)})";
                else if (zonaSocial)
                    item.Motivo = "Zona social (pasa del 30 %)";
                else
                    item.Motivo = "Puede esperar";

                items.Add(item);
            }

            // Aprovechar el viaje: en los puntos donde el operario ya se va a detener,
            // también se vacían los contenedores que pasen del 40 %.
            List<long> paradas = new List<long>();
            foreach (ItemPrioridad item in items)
                if (item.EnRuta && !paradas.Contains(item.Punto.Id)) paradas.Add(item.Punto.Id);

            foreach (ItemPrioridad item in items)
            {
                if (item.EnRuta || !paradas.Contains(item.Punto.Id)) continue;
                if (item.Contenedor.Porcentaje < ConstantesModelo.UmbralAprovecharViaje * 100) continue;
                item.EnRuta = true;
                item.Motivo = "Aprovecha el viaje (pasa del 40 %)";
            }

            ColaPrioridad<ItemPrioridad> cola = new ColaPrioridad<ItemPrioridad>();
            foreach (ItemPrioridad item in items)
            {
                double prioridad = item.Urgencia;
                if (item.Obligatorio) prioridad = item.Urgencia - PenalizacionObligatorio;
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

        /// <summary>Horas en texto corto: "menos de 1 h", "17 h".</summary>
        private static string Horas(double horas)
        {
            if (horas < 1) return "menos de 1 h";
            return horas.ToString("0") + " h";
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
