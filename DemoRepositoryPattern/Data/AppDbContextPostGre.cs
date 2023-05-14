using Microsoft.EntityFrameworkCore;

namespace DemoRepositoryPattern.Data
{
    public class AppDbContextPostGre : BaseDbContext
    {
        private readonly string _connectionString;
        public AppDbContextPostGre(DbContextOptions<AppDbContextPostGre> options, IConfiguration config) : base(options)
        {
            _connectionString = config.GetConnectionString("PostGre");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseNpgsql(_connectionString);

        }
    }
}