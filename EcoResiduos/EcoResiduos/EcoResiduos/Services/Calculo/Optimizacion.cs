using EcoResiduos.Domain;
using EcoResiduos.DynamicStructure;

namespace EcoResiduos.Services.Calculo
{
    /// <summary>Una casa vista como punto con peso (los kg que genera al día).</summary>
    public class PuntoPeso
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Peso { get; set; }

        public PuntoPeso(double x, double y, double peso)
        {
            X = x;
            Y = y;
            Peso = peso;
        }
    }

    public class ResultadoOptimizacion
    {
        public double XOptimo { get; set; }
        public double YOptimo { get; set; }
        public int Iteraciones { get; set; }
        public double DistanciaPromedioOptima { get; set; }
        public double DistanciaPromedioInicial { get; set; }
        public Lista<Coordenada> Trayectoria { get; set; } = new Lista<Coordenada>();
    }

    /// <summary>
    /// OPTIMIZACIÓN CON GRADIENTE: ¿dónde ubicar un punto ecológico para que las casas caminen lo menos posible?
    ///
    ///     f(x, y) = Σ wᵢ · [ (x − xᵢ)² + (y − yᵢ)² ]
    ///     ∂f/∂x = 2 Σ wᵢ (x − xᵢ)        ∂f/∂y = 2 Σ wᵢ (y − yᵢ)
    ///
    /// Se aplica el DESCENSO DEL GRADIENTE: se parte de la ubicación actual y se da un paso
    /// en contra del gradiente, una y otra vez, hasta que el paso es casi cero (∇f ≈ 0).
    /// </summary>
    public static class Optimizacion
    {
        public static void Gradiente(PuntoPeso[] puntos, double x, double y, out double gx, out double gy)
        {
            gx = 0;
            gy = 0;
            foreach (PuntoPeso p in puntos)
            {
                gx += 2 * p.Peso * (x - p.X);
                gy += 2 * p.Peso * (y - p.Y);
            }
        }

        /// <summary>Distancia promedio (ponderada) que camina cada casa hasta el punto (x, y).</summary>
        public static double DistanciaPromedio(PuntoPeso[] puntos, double x, double y)
        {
            double suma = 0, pesos = 0;
            foreach (PuntoPeso p in puntos)
            {
                suma += p.Peso * Math.Sqrt((x - p.X) * (x - p.X) + (y - p.Y) * (y - p.Y));
                pesos += p.Peso;
            }
            return pesos == 0 ? 0 : suma / pesos;
        }

        public static ResultadoOptimizacion UbicacionOptima(PuntoPeso[] puntos, double xInicial, double yInicial)
        {
            if (puntos.Length == 0) throw new ArgumentException("No hay casas para optimizar.");

            double sumaPesos = 0;
            foreach (PuntoPeso p in puntos) sumaPesos += p.Peso;

            // Tamaño del paso: con α = 1 / (4 Σw) cada paso recorre la mitad de lo que falta.
            double alfa = 1 / (4 * sumaPesos);
            const double tolerancia = 0.0001;
            const int maxIteraciones = 1000;

            double x = xInicial, y = yInicial;
            var trayectoria = new Lista<Coordenada>();
            trayectoria.Add(new Coordenada(x, y));
            int iteraciones = 0;

            while (iteraciones < maxIteraciones)
            {
                Gradiente(puntos, x, y, out double gx, out double gy);
                double dx = alfa * gx;
                double dy = alfa * gy;
                x = x - dx;
                y = y - dy;
                iteraciones++;
                trayectoria.Add(new Coordenada(x, y));
                if (Math.Sqrt(dx * dx + dy * dy) < tolerancia) break;
            }

            return new ResultadoOptimizacion
            {
                XOptimo = x,
                YOptimo = y,
                Iteraciones = iteraciones,
                DistanciaPromedioOptima = DistanciaPromedio(puntos, x, y),
                DistanciaPromedioInicial = DistanciaPromedio(puntos, xInicial, yInicial),
                Trayectoria = trayectoria
            };
        }

        /// <summary>Casas del conjunto como puntos con peso. via = 0 → todas; 1..4 → solo las de esa vía.</summary>
        public static PuntoPeso[] CasasComoPuntos(int via)
        {
            var lista = new List<PuntoPeso>();
            foreach (Casa casa in PlanoConjunto.Casas)
                if (via == 0 || casa.Via == via)
                    lista.Add(new PuntoPeso(casa.Lote.CentroX, casa.Lote.CentroY, ConstantesModelo.KgPorCasaDia));
            return lista.ToArray();
        }
    }
}
