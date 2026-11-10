using System.Diagnostics;
using RutaCircular.Domain;
using RutaCircular.DynamicStructure;

namespace RutaCircular.Services
{
    public class ResultadoRendimiento
    {
        public int N { get; set; }
        public double MsQuickSort { get; set; }
        public long ComparacionesQuickSort { get; set; }
        public double MsArraySort { get; set; }
        public int Consultas { get; set; }
        public double MsLineal { get; set; }
        public long ComparacionesLineal { get; set; }
        public double MsBinaria { get; set; }
        public long ComparacionesBinaria { get; set; }
        public bool OrdenCorrecto { get; set; }

        /// <summary>Referencias teóricas para comparar con lo medido.</summary>
        public double NLog2N => N * Math.Log2(Math.Max(2, N));
        public double Log2N => Math.Log2(Math.Max(2, N));
    }

    /// <summary>
    /// Comparación práctica de algoritmos con Stopwatch, sobre recolecciones generadas al azar:
    ///  - QuickSort propio vs Array.Sort de .NET (ambos O(n log n)).
    ///  - Búsqueda lineal O(n) vs búsqueda binaria O(log n).
    /// </summary>
    public static class ServicioRendimiento
    {
        public static Task<ResultadoRendimiento> CompararAsync(int n, int consultas = 1000) =>
            Task.Run(() => Comparar(n, consultas));

        public static ResultadoRendimiento Comparar(int n, int consultas = 1000, int semilla = 7)
        {
            if (n < 1) throw new ArgumentException("La cantidad de datos debe ser mayor que cero.");
            var rnd = new Random(semilla);
            var inicio = new DateTime(2026, 1, 1);
            var datos = new Recoleccion[n];
            for (int i = 0; i < n; i++)
            {
                datos[i] = new Recoleccion
                {
                    Id = i + 1,
                    ContenedorId = 111,
                    Fecha = inicio.AddMinutes(rnd.Next(0, 525_600)),
                    Litros = Math.Round(rnd.NextDouble() * 240, 2),
                    OperarioId = 2
                };
            }
            Comparison<Recoleccion> porFecha = (a, b) => a.Fecha.CompareTo(b.Fecha);

            var propio = (Recoleccion[])datos.Clone();
            var sw = Stopwatch.StartNew();
            long compQuick = Ordenamiento.QuickSort(propio, porFecha);
            sw.Stop();
            double msQuick = sw.Elapsed.TotalMilliseconds;

            var net = (Recoleccion[])datos.Clone();
            sw.Restart();
            Array.Sort(net, porFecha);
            sw.Stop();
            double msNet = sw.Elapsed.TotalMilliseconds;

            bool ordenado = true;
            for (int i = 1; i < propio.Length; i++)
                if (propio[i - 1].Fecha > propio[i].Fecha) { ordenado = false; break; }

            // Búsquedas sobre el arreglo ya ordenado
            var claves = new DateTime[consultas];
            for (int i = 0; i < consultas; i++)
                claves[i] = datos[rnd.Next(n)].Fecha;

            long compLineal = 0, compBinaria = 0;
            sw.Restart();
            foreach (DateTime clave in claves)
            {
                Ordenamiento.BusquedaLineal(propio, clave, r => r.Fecha, out int c);
                compLineal += c;
            }
            sw.Stop();
            double msLineal = sw.Elapsed.TotalMilliseconds;

            sw.Restart();
            foreach (DateTime clave in claves)
            {
                Ordenamiento.BusquedaBinaria(propio, clave, r => r.Fecha, out int c);
                compBinaria += c;
            }
            sw.Stop();
            double msBinaria = sw.Elapsed.TotalMilliseconds;

            return new ResultadoRendimiento
            {
                N = n,
                MsQuickSort = msQuick,
                ComparacionesQuickSort = compQuick,
                MsArraySort = msNet,
                Consultas = consultas,
                MsLineal = msLineal,
                ComparacionesLineal = compLineal,
                MsBinaria = msBinaria,
                ComparacionesBinaria = compBinaria,
                OrdenCorrecto = ordenado
            };
        }
    }
}
