using Microsoft.AspNetCore.Mvc;
using Registry.Application.Interfaces;
using Registry.Core.Entities;

namespace Registry.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
                if(result == null)
                {
                    return NotFound("No users found.");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all users.");
                return StatusCode(500, "An internal error occurred");
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
                return StatusCode(500, "An internal error occurred");
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddUserAsync(RegistrationInformation registrationInformation, CancellationToken cancellationToken)
        {
            try
            {
                bool result = await _registryService.AddUserAsync(registrationInformation, cancellationToken);
                if(result == true)
                {
                    return Ok("User added successfully.");
                }
                return BadRequest("User already exists.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new user.");
                return StatusCode(500, "An internal error occurred");
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUserAsync(RegistrationInformation registrationInformation, CancellationToken cancellationToken)
        {
            try
            {
                bool result = await _registryService.UpdateUserAsync(registrationInformation, cancellationToken);
                if(result == true)
                {
                    return Ok("User details updated");
                }
                return BadRequest("User does not exist.");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while updating the user.");
                return StatusCode(500, "An internal error occurred");
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAsync(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                bool result = await _registryService.DeleteUserAsync(id, cancellationToken);
                if(result == true)
                {
                    return Ok("User deleted");
                }
                return BadRequest("User does not exist");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the user.");
                return StatusCode(500, "An internal error occurred");
            }
        }
    }
}
