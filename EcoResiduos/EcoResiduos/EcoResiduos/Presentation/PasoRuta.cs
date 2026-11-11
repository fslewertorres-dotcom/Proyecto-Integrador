namespace EcoResiduos.Presentation
{
    public enum EstadoPaso
    {
        Pendiente,
        Actual,
        Hecho
    }

    /// <summary>Un renglón de la lista "Recorrido paso a paso".</summary>
    public class PasoRuta
    {
        public string Numero { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Detalle { get; set; } = string.Empty;
        public EstadoPaso Estado { get; set; } = EstadoPaso.Pendiente;
        /// <summary>Id del punto de la parada (-1 para la salida y el regreso).</summary>
        public long PuntoId { get; set; } = -1;

        public override string ToString()
        {
            return Titulo;
        }
    }
}
