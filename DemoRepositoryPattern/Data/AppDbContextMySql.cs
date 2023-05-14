using Microsoft.EntityFrameworkCore;

namespace DemoRepositoryPattern.Data
{
    public class AppDbContextMySql : BaseDbContext
    {
        private readonly string _connectionString;
        public AppDbContextMySql(DbContextOptions<AppDbContextMySql> options, IConfiguration config) : base(options)
        {
            _connectionString = config.GetConnectionString("MySql");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString));

        }

    }
}