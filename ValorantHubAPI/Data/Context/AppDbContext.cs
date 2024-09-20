using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ValorantHubAPI.Data.Entities;

namespace ValorantHubAPI.Data.Context
{
    public class AppDbContext: DbContext
    {
        private readonly IConfiguration _configuration;
        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            Console.WriteLine(connectionString);
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }


        public DbSet<AgentEntity> Agents { get; set; }
        public DbSet<WeaponEntity> Weapons { get; set; }

    }
}
