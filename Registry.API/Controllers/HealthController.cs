using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Registry.Infrastructure.Interfaces;

namespace Registry.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly IRegistryDBContext _registryDBContext;

        public HealthController(IRegistryDBContext registryDBContext)
        {
            _registryDBContext = registryDBContext;
        }

        [HttpGet]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<string>> GetAsync()
        {
            if (!await _registryDBContext.IsHealthy())
            {
                return StatusCode(500, "Not Healthy!");
            }

            return Ok("Healthy!");
        }
    }
}
