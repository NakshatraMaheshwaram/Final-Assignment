using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingMall.EFCore.Data;
using ShoppingMall.EFCore.Models;

namespace ShoppingMall.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationsController : ControllerBase
    {
        private readonly ShoppingMallAPIContext _context;

        public UserRegistrationsController(ShoppingMallAPIContext context)
        {
            _context = context;
        }

        // GET: api/UserRegistrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRegistration>>> GetUserRegistration()
        {
            var users = await _context.UserRegistration.Include("UserRole").ToListAsync();
            return Ok(users);
        }

        // GET: api/UserRegistrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRegistration>> GetUserRegistration(int id)
        {
            var userRegistration = await _context.UserRegistration.Include("UserRole").Where(item => item.Id == id).FirstOrDefaultAsync();

            if (userRegistration == null)
            {
                return NotFound();
            }

            return userRegistration;
        }

        // PUT: api/UserRegistrations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserRegistration(int id, UserRegistration userRegistration)
        {
            if (id != userRegistration.Id)
            {
                return BadRequest();
            }

            _context.Entry(userRegistration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRegistrationExists(id))
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

        // POST: api/UserRegistrations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserRegistration>> PostUserRegistration(UserRegistration userRegistration)
        {
            _context.UserRegistration.Add(userRegistration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserRegistration", new { id = userRegistration.Id }, userRegistration);
        }

        // DELETE: api/UserRegistrations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserRegistration(int id)
        {
            var userRegistration = await _context.UserRegistration.FindAsync(id);
            if (userRegistration == null)
            {
                return NotFound();
            }

            _context.UserRegistration.Remove(userRegistration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserRegistrationExists(int id)
        {
            return _context.UserRegistration.Any(e => e.Id == id);
        }
    }
}
