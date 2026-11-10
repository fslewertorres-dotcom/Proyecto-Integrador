namespace RutaCircular.Contracts
{
    /// <summary>Toda entidad que se guarda tiene un identificador.</summary>
    public interface IEntity<TId>
    {
        TId Id { get; }
    }
}
