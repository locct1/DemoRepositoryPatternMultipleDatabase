using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace DemoRepositoryPattern.Data
{
    public class AppDbContextSqlServer : BaseDbContext
    {
        private readonly string _connectionString;
        public AppDbContextSqlServer(DbContextOptions<AppDbContextSqlServer> options, IConfiguration config) : base(options)
        {
            _connectionString = config.GetConnectionString("SqlServer");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(_connectionString);

        }
    }
}
