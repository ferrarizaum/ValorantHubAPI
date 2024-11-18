using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ValorantHubAPI.Data.Entities;

namespace ValorantHubAPI.Data.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AgentEntity> Agents { get; set; }
        public DbSet<WeaponEntity> Weapons { get; set; }

    }
}
