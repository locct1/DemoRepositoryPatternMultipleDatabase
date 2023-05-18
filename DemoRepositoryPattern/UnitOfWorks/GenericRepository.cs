using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DemoRepositoryPattern.UnitOfWorks
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public async virtual Task<IEnumerable<TEntity>> GetAll(
           Expression<Func<TEntity, bool>> filter = null,
           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy is null)
            {
                return query.ToList();
            }
            return orderBy(query).ToList();
        }
        public async virtual Task<TEntity> GetByID(object id)
        {
            return _dbSet.Find(id);
        }
        public async virtual Task Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }
        public async virtual Task Delete(object id)
        {
            TEntity entityDelete = _dbSet.Find(id);
            Delete(entityDelete);

        }
        public async virtual Task Delete(TEntity entityDelete)
        {
            if (_context.Entry(entityDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityDelete);
            }
            _dbSet.Remove(entityDelete);

        }
        public async virtual Task Update(TEntity entityUpdate)
        {
            _dbSet.Attach(entityUpdate);
            _context.Entry(entityUpdate).State = EntityState.Modified;

        }
    }
}
