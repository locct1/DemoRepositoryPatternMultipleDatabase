using DemoRepositoryPattern.Data;
using DemoRepositoryPattern.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Transactions;

namespace DemoRepositoryPattern.UnitOfWorks
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IUnitOfWork where TContext : DbContext
    {
        private readonly TContext _context;
        private bool disposed = false;
        private Dictionary<Type, object> repositories;
        public TContext DbContext => _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork{TContext}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public UnitOfWork(TContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IGenericRepository<TEntity> GetRepository<TEntity>(bool hasCustomRepository = false) where TEntity : class
        {
            if (repositories == null)
            {
                repositories = new Dictionary<Type, object>();
            }

            // what's the best way to support custom reposity?
            if (hasCustomRepository)
            {
                var customRepo = _context.GetService<IGenericRepository<TEntity>>();
                if (customRepo != null)
                {
                    return customRepo;
                }
            }

            var type = typeof(TEntity);
            if (!repositories.ContainsKey(type))
            {
                repositories[type] = new GenericRepository<TEntity>(_context);
            }

            return (IGenericRepository<TEntity>)repositories[type];
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }


        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // clear repositories
                    if (repositories != null)
                    {
                        repositories.Clear();
                    }

                    // dispose the db context.
                    _context.Dispose();
                }
            }

            disposed = true;
        }
    }
}
