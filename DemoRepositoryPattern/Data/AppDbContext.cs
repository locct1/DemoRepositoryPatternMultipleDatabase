using DemoRepositoryPattern.LibraryDbProvider;
using Microsoft.EntityFrameworkCore;

namespace DemoRepositoryPattern.Data
{
    public class AppDbContext : DbContext
    {
        //private readonly string _connectionString;
        private readonly CreateDatabase DBProvider = new CreateDatabase();
        public AppDbContext()
        {
            //_connectionString = DBProvider.GetDBProvider().ConnectionString();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            DBProvider.GetDBProvider().ConnectedDatabase(optionsBuilder);
        }
        #region DbSet
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        #endregion
    }
}