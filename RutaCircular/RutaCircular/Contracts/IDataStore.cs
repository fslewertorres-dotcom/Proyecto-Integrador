using RutaCircular.DynamicStructure;

namespace RutaCircular.Contracts
{
    public interface IDataStore<T> where T : class
    {
        Lista<T> LoadAll();
        void SaveAll(Lista<T> list);
        Task SaveAllAsync(Lista<T> list);
    }
}
