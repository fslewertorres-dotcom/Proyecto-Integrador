using RutaCircular.Domain;

namespace RutaCircular.Services.Calculo
{
    /// <summary>
    /// FUNCIÓN DE VARIAS VARIABLES de generación de residuos:
    ///
    ///     G(lugar, día, hora) = tasaBase · Fh(lugar, hora) · Fd(lugar, día)      [litros / hora]
    ///
    /// - tasaBase: promedio semanal del contenedor (sale de 0,64 kg/persona/día × 3,5 personas/hogar).
    /// - Fh: forma de la curva del día. Se arma con "campanas" (gaussianas) en las horas pico:
    ///       g(h; μ, σ) = e^(−(h−μ)² / (2σ²))
    /// - Fd: cuánto más o menos se genera según el día (ej.: la zona de asados se usa el fin de semana).
    /// Fh y Fd se normalizan (se dividen por su promedio) para que el promedio semanal de G sea tasaBase.
    /// </summary>
    public static class ModeloGeneracion
    {
        // Índices de los arreglos de días: 0 = domingo ... 6 = sábado (igual que DayOfWeek de .NET)
        private static readonly double[] DiasResidencial = { 1.3, 1, 1, 1, 1, 1, 1.3 };
        private static readonly double[] DiasPiscina = { 2.5, 0.7, 0.7, 0.7, 0.7, 0.7, 2.5 };
        private static readonly double[] DiasGimnasio = { 0.5, 1, 1, 1, 1, 1, 0.5 };
        private static readonly double[] DiasAsados = { 3, 0.2, 0.2, 0.2, 0.2, 1.2, 3 };
        private static readonly double[] DiasParque = { 1.6, 1, 1, 1, 1, 1, 1.6 };

        private static readonly Dictionary<TipoPunto, double> MediaHora = new();
        private static readonly Dictionary<TipoPunto, double> MediaDia = new();

        static ModeloGeneracion()
        {
            TipoPunto[] tipos = { TipoPunto.PuntoEcologico, TipoPunto.Piscina, TipoPunto.Gimnasio,
                                  TipoPunto.ZonaAsados, TipoPunto.ParqueInfantil };
            foreach (TipoPunto tipo in tipos)
            {
                // Promedio de la curva horaria (integral de 0 a 24 dividida entre 24, regla del punto medio)
                const int n = 2400;
                double suma = 0;
                for (int i = 0; i < n; i++)
                    suma += HoraCruda(tipo, (i + 0.5) * 24.0 / n);
                MediaHora[tipo] = suma / n;
                MediaDia[tipo] = DiasCrudos(tipo).Average();
            }
        }

        private static double Campana(double h, double mu, double sigma) =>
            Math.Exp(-((h - mu) * (h - mu)) / (2 * sigma * sigma));

        private static double HoraCruda(TipoPunto tipo, double h)
        {
            switch (tipo)
            {
                case TipoPunto.PuntoEcologico:
                    return 0.3 + 1.0 * Campana(h, 7, 1.5) + 1.2 * Campana(h, 19.5, 2);   // mañana y noche
                case TipoPunto.Piscina:
                    return 0.05 + Campana(h, 14, 2.5);   // mediodía
                case TipoPunto.Gimnasio:
                    return 0.05 + Campana(h, 6.5, 1) + Campana(h, 19, 1.5);   // antes y después del trabajo
                case TipoPunto.ZonaAsados:
                    return 0.02 + Campana(h, 13, 1.5) + 1.2 * Campana(h, 19.5, 1.5);   // almuerzo y noche
                case TipoPunto.ParqueInfantil:
                    return 0.05 + Campana(h, 16.5, 1.5);   // tarde
                default:
                    return 0;
            }
        }

        private static double[] DiasCrudos(TipoPunto tipo)
        {
            switch (tipo)
            {
                case TipoPunto.PuntoEcologico:
                    return DiasResidencial;
                case TipoPunto.Piscina:
                    return DiasPiscina;
                case TipoPunto.Gimnasio:
                    return DiasGimnasio;
                case TipoPunto.ZonaAsados:
                    return DiasAsados;
                case TipoPunto.ParqueInfantil:
                    return DiasParque;
                default:
                    return new double[7];
            }
        }

        public static bool GeneraResiduos(TipoPunto tipo) => MediaHora.ContainsKey(tipo);

        public static double FactorHora(TipoPunto tipo, double hora) =>
            GeneraResiduos(tipo) ? HoraCruda(tipo, hora) / MediaHora[tipo] : 0;

        public static double FactorDia(TipoPunto tipo, DayOfWeek dia) =>
            GeneraResiduos(tipo) ? DiasCrudos(tipo)[(int)dia] / MediaDia[tipo] : 0;

        /// <summary>G(lugar, día, hora) en litros por hora.</summary>
        public static double Tasa(TipoPunto tipo, double tasaBase, DayOfWeek dia, double hora) =>
            tasaBase * FactorHora(tipo, hora) * FactorDia(tipo, dia);

        public static double Tasa(TipoPunto tipo, double tasaBase, DateTime momento) =>
            Tasa(tipo, tasaBase, momento.DayOfWeek, momento.Hour + momento.Minute / 60.0 + momento.Second / 3600.0);
    }
}
