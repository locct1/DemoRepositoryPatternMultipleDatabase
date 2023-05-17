using Microsoft.EntityFrameworkCore;

namespace DemoRepositoryPattern.LibraryDbProvider.DbProvider
{
    public class MySQL : IDatabaseProvider
    {
        public void ConnectedDatabase(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConnectionString(), ServerVersion.AutoDetect(ConnectionString()),
                x => x.MigrationsAssembly("MySQLMigrations"));
        }
        public string ConnectionString()
        {
            IConfiguration config = GetStringAppsetting.ConnectString();
            return config.GetConnectionString("MySQL");
        }
    }
}
