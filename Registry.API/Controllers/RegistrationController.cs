using Microsoft.AspNetCore.Mvc;
using Registry.Application.Interfaces;
using Registry.Core.Entities;

namespace Registry.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistryService _registryService;
        private readonly ILogger<RegistrationController> _logger;

        public RegistrationController(IRegistryService registryService, ILogger<RegistrationController> logger)
        {
            _registryService = registryService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<RegistrationInformation>>> GetAllAsync(CancellationToken cancellationToken)
        {
            try
            {
                var result = await _registryService.GetAllAsync(cancellationToken);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all users.");
                return BadRequest("An error occurred");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegistrationInformation>> GetUserAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _registryService.GetUserAsync(id, cancellationToken);
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
        public async Task<ActionResult> AddUserAsync(RegistrationInformation registrationInformation, CancellationToken cancellationToken)
        {
            try
            {
                await _registryService.AddUserAsync(registrationInformation, cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new user.");
                return BadRequest("An error occurred");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUserAsync(Guid id, RegistrationInformation registrationInformation, CancellationToken cancellationToken)
        {
            try
            {
                var existingUser = await _registryService.GetUserAsync(id, cancellationToken);
                if (existingUser == null)
                {
                    return NotFound("User not found.");
                }
                registrationInformation.Id = id;
                await _registryService.UpdateUserAsync(registrationInformation, cancellationToken);
                return NoContent();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the user.");
                return BadRequest("An error occurred");
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var existingUser = await _registryService.GetUserAsync(id, cancellationToken);
                if (existingUser == null)
                {
                    return NotFound("User not found.");
                }
                await _registryService.DeleteUserAsync(id, cancellationToken);
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
