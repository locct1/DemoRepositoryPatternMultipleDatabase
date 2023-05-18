using Microsoft.EntityFrameworkCore;

namespace DemoRepositoryPattern.UnitOfWorks
{
    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        TContext DbContext { get; }
    }
}
