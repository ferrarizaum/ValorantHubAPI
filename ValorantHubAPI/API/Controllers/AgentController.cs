using Microsoft.AspNetCore.Mvc;
using ValorantHubAPI.API.Services;
using ValorantHubAPI.Data.Entities;

namespace ValorantHubAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentController : ControllerBase
    {
        private readonly IAgentService _agentService;

        public AgentController(IAgentService agentService)
        {
            _agentService = agentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var agents = _agentService.GetAgents();
            return Ok(agents);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AgentEntity agent)
        {
            var newAgent = _agentService.PostAgent(agent);
            return Ok(newAgent);
        }

        [HttpPut]
        public IActionResult Put([FromBody] AgentEntity agent, string displayName)
        {
            var updatedAgent = _agentService.UpdateAgent(agent, displayName);
            return Ok(updatedAgent);
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
