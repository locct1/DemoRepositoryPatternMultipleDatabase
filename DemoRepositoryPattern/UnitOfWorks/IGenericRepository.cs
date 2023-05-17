using System.Linq.Expressions;

namespace DemoRepositoryPattern.UnitOfWorks
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll(
           Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        Task<TEntity> GetByID(object id);
        Task Insert(TEntity entity);
        Task Delete(object id);
        Task Delete(TEntity entityDelete);
        Task Update(TEntity entityUpdate);
    }
}
