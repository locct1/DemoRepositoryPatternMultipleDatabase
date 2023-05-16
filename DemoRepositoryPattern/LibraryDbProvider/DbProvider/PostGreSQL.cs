using Microsoft.EntityFrameworkCore;

namespace DemoRepositoryPattern.LibraryDbProvider.DbProvider
{
    public class PostGreSQL : IDatabaseProvider
    {
        public void ConnectedDatabase(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConnectionString(), x => x.MigrationsAssembly("PostGreSQLMigrations"));
        }
        public string ConnectionString()
        {
            IConfiguration config = GetStringAppsetting.ConnectString();
            return config.GetConnectionString("PostGreSQL");
        }
    }
}
