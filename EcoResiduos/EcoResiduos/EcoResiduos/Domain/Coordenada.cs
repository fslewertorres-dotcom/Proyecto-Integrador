namespace EcoResiduos.Domain
{
    /// <summary>Un punto del plano en metros (se usa para la ubicación óptima y su trayectoria).</summary>
    public class Coordenada
    {
        public double X { get; set; }
        public double Y { get; set; }
        public string Etiqueta { get; set; } = string.Empty;

        public Coordenada(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Coordenada(double x, double y, string etiqueta)
        {
            X = x;
            Y = y;
            Etiqueta = etiqueta;
        }
    }
}
