using DemoRepositoryPattern.Data;
using DemoRepositoryPattern.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace DemoRepositoryPattern.UnitOfWorks
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity>, IDisposable where TEntity : class
    {
        private AppDbContext _context = new AppDbContext();

        private IGenericRepository<TEntity> _repository;

        public IGenericRepository<TEntity> Repository
        {
            get
            {
                if (this._repository is null)
                {
                    this._repository = new GenericRepository<TEntity>(_context);
                }
                return this._repository;
            }
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
