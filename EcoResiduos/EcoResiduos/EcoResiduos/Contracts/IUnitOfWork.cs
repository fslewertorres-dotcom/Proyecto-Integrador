namespace EcoResiduos.Contracts
{
    /// <summary>
    /// Confirma (guarda en disco) los cambios hechos en memoria.
    /// REFACTOR: se corrigió el nombre (antes IUnidOfWork) y se agregó la versión asíncrona.
    /// </summary>
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
    }
}
