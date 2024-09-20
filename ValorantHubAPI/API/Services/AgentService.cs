using ValorantHubAPI.Data.Context;
using ValorantHubAPI.Data.Entities;
using ValorantHubAPI.Data.Store;

namespace ValorantHubAPI.API.Services
{
    public interface IAgentService
    {
       ICollection<AgentEntity> GetAgents();
       AgentEntity PostAgent(AgentEntity agent);
       AgentEntity UpdateAgent(AgentEntity agent, string displayName);
       AgentEntity RemoveAgent(string displayName);
    }
    public class AgentService:IAgentService
    {
        private readonly IAppStore _appDbContext;
        private readonly AppDbContext _dbContext;
        public AgentService(IAppStore appDbContext, 
                            AppDbContext appDbContext2)
        {
            _appDbContext = appDbContext;
            _dbContext = appDbContext2;
        }

        public ICollection<AgentEntity> GetAgents()
        {
            var agents = _dbContext.Agents.ToList();
            return agents;
        }

        public AgentEntity PostAgent(AgentEntity agent)
        {
            _dbContext.Agents.Add(agent);
            _dbContext.SaveChanges();
            return agent;
        }

        public AgentEntity UpdateAgent(AgentEntity agent, string displayName)
        {
            var oldAgent = _appDbContext.Agents.Find(a => a.displayName == displayName);

            if(oldAgent == null)
            {
                return null;
            }

            oldAgent.displayName = agent.displayName;
            oldAgent.description = agent.description;

            return oldAgent;
        }

        public AgentEntity RemoveAgent(string displayName)
        {
            var removedAgent = _appDbContext.Agents.Find(a => a.displayName == displayName);
            _appDbContext?.Agents.Remove(removedAgent);

            return removedAgent;
        }
    }
}
