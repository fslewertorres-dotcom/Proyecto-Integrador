using RutaCircular.Domain;

namespace RutaCircular.Services.Calculo
{
    /// <summary>
    /// Tiempo y costo de una ronda (funciones de dos variables):
    ///     T(d, n) = d / v + n · tv          (minutos)
    ///     C(d, n) = T(d, n) / 60 · costoHora (pesos)
    /// d = metros recorridos, n = contenedores vaciados.
    /// </summary>
    public static class ModeloCosto
    {
        public static double TiempoMinutos(double distanciaMetros, int contenedores)
        {
            return distanciaMetros / ConstantesModelo.VelocidadMetrosPorMinuto
                 + contenedores * ConstantesModelo.MinutosPorContenedor;
        }

        public static double Costo(double distanciaMetros, int contenedores)
        {
            return TiempoMinutos(distanciaMetros, contenedores) / 60 * ConstantesModelo.CostoHoraOperario;
        }
    }
}
