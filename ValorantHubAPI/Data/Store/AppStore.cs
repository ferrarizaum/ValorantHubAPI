using System.ComponentModel.DataAnnotations.Schema;
using ValorantHubAPI.Data.Entities;

namespace ValorantHubAPI.Data.Store
{
    public interface IAppStore
    {
        List<WeaponEntity> Weapons { get; }
        List<AgentEntity> Agents { get; }
    }

    public class AppStore : IAppStore
    {
        [NotMapped]
        public List<WeaponEntity> Weapons { get; private set; } = new List<WeaponEntity>();
        [NotMapped]
        public List<AgentEntity> Agents { get; private set; } = new List<AgentEntity>();

        public AppStore()
        {
            Weapons = new List<WeaponEntity>();
            Agents = new List<AgentEntity>();
        }

    }
}
