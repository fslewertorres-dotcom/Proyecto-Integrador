namespace RutaCircular.Domain
{
    /// <summary>Código de colores de la Resolución 2184 de 2019.</summary>
    public enum TipoResiduo
    {
        Organico,        // caneca verde
        Aprovechable,    // caneca blanca
        NoAprovechable   // caneca negra
    }

    /// <summary>Tipo de nodo del plano. El tipo define también el perfil de generación de basura.</summary>
    public enum TipoPunto
    {
        PuntoEcologico,
        Piscina,
        Gimnasio,
        ZonaAsados,
        ParqueInfantil,
        Acopio,
        Interseccion
    }
}
