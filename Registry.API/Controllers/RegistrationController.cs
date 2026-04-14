using Microsoft.AspNetCore.Mvc;
using Registry.Core.Entities;
using Registry.Infrastructure.Interfaces;

namespace Registry.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistryRepository _registryRepository;
        private readonly ILogger<RegistrationController> _logger;

        public RegistrationController(IRegistryRepository registryRepository, ILogger<RegistrationController> logger)
        {
            _registryRepository = registryRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<RegistrationInformation>>> GetAllAsync()
        {
            try
            {
                var result = await _registryRepository.GetAllAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all users.");
                return BadRequest("An error occurred");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegistrationInformation>> GetUserAsync(Guid id)
        {
            try
            {
                var result = await _registryRepository.GetUserAsync(id);
                if (result == null)
                {
                    return NotFound("No user found with the given ID.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving the user.");
                return BadRequest("An error occurred");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddUserAsync(RegistrationInformation registrationInformation)
        {
            try
            {
                await _registryRepository.AddUserAsync(registrationInformation);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new user.");
                return BadRequest("An error occurred");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserAsync(Guid id, RegistrationInformation registrationInformation)
        {
            try
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
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the user.");
                return BadRequest("An error occurred");
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAsync(Guid id)
        {
            try
            {
                var existingUser = await _registryRepository.GetUserAsync(id);
                if (existingUser == null)
                {
                    return NotFound("User not found.");
                }
                await _registryRepository.DeleteUserAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the user.");
                return BadRequest("An error occurred");
            }
        }
    }
}
