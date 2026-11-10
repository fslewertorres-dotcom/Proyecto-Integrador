namespace RutaCircular.Contracts
{
    /// <summary>Convierte un objeto a una línea de texto (y al revés) para guardarlo en .txt.</summary>
    public interface ISerialize<T>
    {
        static abstract T Deserialize(string textCsv);
        static abstract string Serialize(T obj);
    }
}
