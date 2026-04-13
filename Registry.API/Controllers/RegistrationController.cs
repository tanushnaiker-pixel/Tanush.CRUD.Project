using Microsoft.AspNetCore.Mvc;
using Registry.Core.Entities;
using Registry.Infrastructure.Implementation;
using Registry.Infrastructure.Interfaces;

namespace Registry.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistryRepository _registryRepository;

        public RegistrationController(IRegistryRepository registryRepository)
        {
            _registryRepository = registryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<RegistrationInformation>>> GetAllAsync()
        {
            var result = await _registryRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegistrationInformation>> GetUserAsync(string id)
        {
            var result = await _registryRepository.GetUserAsync(id);
            if(result == null)
            {
                return NotFound("No user found with the given ID.");
            }
            return Ok(result);

        }

        [HttpPost]
        public async Task<ActionResult> AddUserAsync(RegistrationInformation registrationInformation)
        {
            await _registryRepository.AddUserAsync(registrationInformation);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserAsync(string id, RegistrationInformation registrationInformation)
        {
            var existingUser = await _registryRepository.GetUserAsync(id);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }
            registrationInformation.Id = id;
            await _registryRepository.UpdateUserAsync(registrationInformation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAsync(string id)
        {
            var existingUser = await _registryRepository.GetUserAsync(id);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }
            await _registryRepository.DeleteUserAsync(id);
            return NoContent();
        }

        //private readonly ILogger<RegistrationController> _logger;

        //public RegistrationController(ILogger<RegistrationController> logger)
        //{
        //    _logger = logger;
        //}
    }
}
