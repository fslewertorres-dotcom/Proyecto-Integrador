using EcoResiduos.Contracts;
using EcoResiduos.DynamicStructure;
using EcoResiduos.Exceptions;
using EcoResiduos.Persistence;

namespace EcoResiduos.Infraestructure
{
    /// <summary>
    /// Repositorio genérico con caché en memoria.
    ///  - Lista&lt;T&gt; (propia): conserva el orden de los registros y se usa para recorrerlos y guardarlos.
    ///  - Dictionary&lt;E, T&gt; (de .NET, la estructura SELECCIONADA): índice por Id.
    ///    GetById y Exist pasan de O(n) (recorrer la lista) a O(1) promedio (tabla hash).
    /// Los cambios quedan en memoria hasta llamar Commit / CommitAsync (Unit of Work).
    /// </summary>
    public class Repository<T, E> : IRepository<T, E>, IUnitOfWork
        where T : class, IFactory<T>, IEntity<E>, ISerialize<T>
        where E : notnull
    {
        private readonly Lista<T> _cache;
        private readonly Dictionary<E, T> _indice = new();
        private readonly DataStore<T> _store;

        public Repository(string path, string? encabezado = null)
        {
            _store = new DataStore<T>(path, encabezado);
            _cache = _store.LoadAll();
            foreach (T entidad in _cache)
            {
                if (_indice.ContainsKey(entidad.Id))
                    throw new DatosInvalidosException($"El archivo {Path.GetFileName(path)} tiene el Id {entidad.Id} repetido.");
                _indice[entidad.Id] = entidad;
            }
        }

        public int Count => _cache.Count;

        public void Add(T entity)
        {
            if (_indice.ContainsKey(entity.Id))
                throw new ValidacionException($"Ya existe un registro con el Id {entity.Id}.");
            _cache.Add(entity);
            _indice[entity.Id] = entity;
        }

        public void Update(T entity)
        {
            int posicion = _cache.IndexOf(d => d.Id.Equals(entity.Id));
            if (posicion == -1)
                throw new ValidacionException($"No existe un registro con el Id {entity.Id}.");
            _cache.Set(posicion, entity);
            _indice[entity.Id] = entity;
        }

        public void Delete(E id)
        {
            if (!_indice.TryGetValue(id, out T? entidad))
                throw new ValidacionException($"No existe un registro con el Id {id}.");
            _cache.Delete(entidad);
            _indice.Remove(id);
        }

        public bool Exist(E id) => _indice.ContainsKey(id);

        public T? GetById(E id) => _indice.TryGetValue(id, out T? entidad) ? entidad : null;

        public Lista<T> GetAll() => _cache;

        public void Commit() => _store.SaveAll(_cache);

        public Task CommitAsync() => _store.SaveAllAsync(_cache);
    }
}
