using Microsoft.EntityFrameworkCore;

namespace DemoRepositoryPattern.LibraryDbProvider.DbProvider
{
    public class SQLServer : IDatabaseProvider
    {
        public void ConnectedDatabase(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString(), x => x.MigrationsAssembly("SQLServerMigrations"));
        }
        public string ConnectionString()
        {
            IConfiguration config = GetStringAppsetting.ConnectString();
            return config.GetConnectionString("SQLServer");
        }
    }
}