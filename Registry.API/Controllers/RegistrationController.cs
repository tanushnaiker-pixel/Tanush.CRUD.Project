using Microsoft.AspNetCore.Mvc;
using Registry.Core.Entities;

namespace Registry.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger;

        public RegistrationController(ILogger<RegistrationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {

            return Ok(await _context.RegistrationInformation.ToArrayAsync()); //Need to change DB to local server
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetUser(int id)
        {
            var user = await _context.RegistrationInformation.FindAsync(id);//Need to change DB to local server
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> PostUser(RegistrationInformation user) //Need to create Class
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }


            _context.RegistrationInformation.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetUser),
                new { id = user.Id },
                user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> PutUser(string id, RegistrationInformation user)//Need to create Class
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;// Not using entity framework

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)// Not using entity framework
            {
                if (!_context.RegistrationInformation.Any(p => p.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            var user = await _context.RegistrationInformation.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.RegistrationInformation.Remove(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }
    }
}
