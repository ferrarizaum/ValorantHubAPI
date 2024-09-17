using System.ComponentModel.DataAnnotations.Schema;
using ValorantHubAPI.Data.Entities;

namespace ValorantHubAPI.Data.Context
{
    public interface IAppDbContext
    {
        List<WeaponEntity> Weapons { get; }
        List<AgentEntity> Agents { get; }
    }
   
    public class AppDbContext: IAppDbContext
    {
        [NotMapped]
        public List<WeaponEntity> Weapons { get; private set; } = new List<WeaponEntity>();
        [NotMapped]
        public List<AgentEntity> Agents { get; private set; } = new List<AgentEntity>();

        public AppDbContext()
        {
            Weapons = new List<WeaponEntity>();
            Agents = new List<AgentEntity>();
        }

    }
}
