namespace EcoResiduos.Domain
{
    /// <summary>
    /// Supuestos del modelo con su fuente. Si cambian un valor, cambia todo el sistema.
    /// </summary>
    public static class ConstantesModelo
    {
        // --- Generación (fuentes oficiales) ---
        /// <summary>kg por persona al día: 24,8 M t/año × 47 % hogares ÷ ~50 M hab ÷ 365 (MinAmbiente / DANE).</summary>
        public const double KgPorPersonaDia = 0.64;
        /// <summary>Personas por hogar en el Cesar (DANE, CNPV 2018).</summary>
        public const double PersonasPorHogar = 3.5;
        public const int TotalCasas = 96;
        public static double KgPorCasaDia => KgPorPersonaDia * PersonasPorHogar;   // ≈ 2,24

        // --- Composición (Banco Mundial, citado en la guía de MinAmbiente) ---
        public const double FraccionOrganico = 0.44;
        public const double FraccionAprovechable = 0.38;
        public const double FraccionNoAprovechable = 0.18;

        // --- Supuestos del equipo ---
        /// <summary>Densidad de residuo doméstico suelto (valor típico 0,15–0,30 kg/L).</summary>
        public const double DensidadKgPorLitro = 0.2;
        /// <summary>Por encima de este porcentaje el contenedor entra a la ruta sí o sí.</summary>
        public const double UmbralObligatorio = 0.80;
        /// <summary>Entra a la ruta todo contenedor que se llene en menos de estas horas.</summary>
        public const double HorizonteRutaHoras = 24;
        /// <summary>Velocidad del operario empujando el carro (≈ 0,8 m/s).</summary>
        public const double VelocidadMetrosPorMinuto = 48;
        /// <summary>Tiempo para vaciar un contenedor en el carro.</summary>
        public const double MinutosPorContenedor = 2;
        /// <summary>Costo por hora del operario (supuesto, COP).</summary>
        public const double CostoHoraOperario = 9000;
    }
}
