using Microsoft.AspNetCore.Mvc;
using Registry.Core.Entities;
using Registry.Infrastructure.Interfaces;

namespace Registry.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly IRegistryRepository _repo;

        public RegistrationController(ILogger<RegistrationController> logger, IRegistryRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await _repo.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(string id)
        {
            var user = await _repo.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> PostUser(RegistrationInformation user)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            await _repo.AddUser(user);
           
            return CreatedAtAction(
                nameof(GetUser),
                new { id = user.Id },
                user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutUser(string id, RegistrationInformation user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            await _repo.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            var user = await _repo.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            await _repo.DeleteUser(user);
            return Ok(user);
        }
    }
}
