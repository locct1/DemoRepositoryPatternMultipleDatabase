namespace DemoRepositoryPattern.UnitOfWorks
{
    public interface IUnitOfWork<TEntity> where TEntity : class
    {
        public IGenericRepository<TEntity> Repository { get; }
    }
}
