namespace DemoRepositoryPattern.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : class;
        Task<int> SaveChangesAsync();

    }
}
