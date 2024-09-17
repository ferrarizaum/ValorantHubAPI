using ValorantHubAPI.Data.Entities;
using ValorantHubAPI.Data.Store;

namespace ValorantHubAPI.API.Services
{
    public interface IAgentService
    {
       ICollection<AgentEntity> GetAgents();
    }
    public class AgentService:IAgentService
    {
        private readonly IAppStore _appDbContext;
        public AgentService(IAppStore appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ICollection<AgentEntity> GetAgents()
        {
            Console.WriteLine("Inside GetAgents");
            var agents = _appDbContext.Agents.ToList();
            return agents;
        }
    }
}
