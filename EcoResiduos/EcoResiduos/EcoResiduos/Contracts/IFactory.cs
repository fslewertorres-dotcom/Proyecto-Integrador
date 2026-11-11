namespace EcoResiduos.Contracts
{
    /// <summary>
    /// Fábrica estática: permite que el DataStore genérico cree objetos a partir de una línea del .txt.
    /// REFACTOR: se quitó Create() sin parámetros del proyecto anterior porque nunca se usaba
    /// y obligaba a las clases abstractas (Usuario) a inventar un objeto vacío.
    /// </summary>
    public interface IFactory<T>
    {
        static abstract T Create(string textCsv);
    }
}
