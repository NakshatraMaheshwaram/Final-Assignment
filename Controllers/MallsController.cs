using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingMall.EFCore.Data;
using ShoppingMall.EFCore.Models;

namespace ShoppingMall.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MallsController : ControllerBase
    {
        private readonly ShoppingMallAPIContext _context;

        public MallsController(ShoppingMallAPIContext context)
        {
            _context = context;
        }

        // GET: api/Malls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mall>>> GetMall()
        {
            return await _context.Mall.ToListAsync();
        }

        // GET: api/Malls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mall>> GetMall(int id)
        {
            var mall = await _context.Mall.FindAsync(id);

            if (mall == null)
            {
                return NotFound();
            }

            return mall;
        }

        // PUT: api/Malls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMall(int id, Mall mall)
        {
            if (id != mall.Id)
            {
                return BadRequest();
            }

            _context.Entry(mall).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MallExists(id))
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

        // POST: api/Malls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mall>> PostMall(Mall mall)
        {
            _context.Mall.Add(mall);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMall", new { id = mall.Id }, mall);
        }

        // DELETE: api/Malls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMall(int id)
        {
            var mall = await _context.Mall.FindAsync(id);
            if (mall == null)
            {
                return NotFound();
            }

            _context.Mall.Remove(mall);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MallExists(int id)
        {
            return _context.Mall.Any(e => e.Id == id);
        }
    }
}
