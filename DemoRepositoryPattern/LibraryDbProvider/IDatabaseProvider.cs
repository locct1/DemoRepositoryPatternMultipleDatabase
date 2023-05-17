using Microsoft.EntityFrameworkCore;

namespace DemoRepositoryPattern.LibraryDbProvider
{
    public interface IDatabaseProvider
    {
        public string ConnectionString();
        public void ConnectedDatabase(DbContextOptionsBuilder optionsBuilder);
    }
}
