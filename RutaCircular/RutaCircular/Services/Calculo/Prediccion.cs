using RutaCircular.Domain;

namespace RutaCircular.Services.Calculo
{
    /// <summary>
    /// PREDICCIÓN DE LLENADO con una integral en el tiempo:
    ///
    ///     Litros generados entre t0 y t1  =  ∫ G(lugar, día(t), hora(t)) dt
    ///
    /// Como G cambia con la hora, no se puede hacer "litros libres ÷ tasa". Se integra numéricamente
    /// con la REGLA DE SIMPSON en tramos de 15 minutos:
    ///
    ///     ∫[a,b] f(t) dt ≈ (b − a)/6 · [ f(a) + 4·f((a+b)/2) + f(b) ]
    ///
    /// y se avanza tramo a tramo hasta que lo acumulado iguala los litros libres del contenedor.
    /// </summary>
    public static class Prediccion
    {
        public const double PasoHoras = 0.25;
        /// <summary>Si no se llena en una semana se considera "no urgente" (infinito).</summary>
        public const double HorizonteHoras = 168;

        private static double Simpson(TipoPunto tipo, double tasaBase, DateTime inicio, double horas)
        {
            DateTime medio = inicio.AddHours(horas / 2);
            DateTime fin = inicio.AddHours(horas);
            return horas / 6 * (ModeloGeneracion.Tasa(tipo, tasaBase, inicio)
                              + 4 * ModeloGeneracion.Tasa(tipo, tasaBase, medio)
                              + ModeloGeneracion.Tasa(tipo, tasaBase, fin));
        }

        /// <summary>∫ G dt desde "desde" durante "horas" (Simpson compuesto).</summary>
        public static double LitrosGenerados(TipoPunto tipo, double tasaBase, DateTime desde, double horas)
        {
            if (horas <= 0) return 0;
            int n = Math.Max(1, (int)Math.Ceiling(horas / PasoHoras));
            double h = horas / n;
            double total = 0;
            for (int i = 0; i < n; i++)
                total += Simpson(tipo, tasaBase, desde.AddHours(i * h), h);
            return total;
        }

        /// <summary>Horas que faltan para que el contenedor se llene (infinito si no se llena en una semana).</summary>
        public static double HorasParaLlenarse(Contenedor c, TipoPunto tipo, DateTime desde)
        {
            double libres = c.LitrosLibres;
            if (libres <= 0) return 0;

            double acumulado = 0;
            for (double t = 0; t < HorizonteHoras; t += PasoHoras)
            {
                double tramo = Simpson(tipo, c.TasaBaseLitrosHora, desde.AddHours(t), PasoHoras);
                if (tramo > 0 && acumulado + tramo >= libres)
                    return t + PasoHoras * (libres - acumulado) / tramo;   // interpolación dentro del tramo
                acumulado += tramo;
            }
            return double.PositiveInfinity;
        }

        /// <summary>Estimación ingenua con tasa constante, para mostrar la diferencia con la integral.</summary>
        public static double HorasConTasaConstante(Contenedor c) =>
            c.TasaBaseLitrosHora <= 0 ? double.PositiveInfinity : c.LitrosLibres / c.TasaBaseLitrosHora;

        public static double NivelFuturo(Contenedor c, TipoPunto tipo, DateTime desde, double horas) =>
            Math.Min(c.CapacidadLitros, c.NivelLitros + LitrosGenerados(tipo, c.TasaBaseLitrosHora, desde, horas));
    }
}
