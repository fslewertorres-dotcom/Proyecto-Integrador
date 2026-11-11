using EcoResiduos.DynamicStructure;

namespace EcoResiduos.Contracts
{
    public interface IRepository<T, E> where T : class, IEntity<E>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(E id);
        bool Exist(E id);
        T? GetById(E id);
        Lista<T> GetAll();
    }
}
