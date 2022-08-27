using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingMall.EFCore.Data;
using ShoppingMall.EFCore.Models;

namespace ShoppingMall.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginsController : ControllerBase
    {
        private readonly ShoppingMallAPIContext _context;

        public UserLoginsController(ShoppingMallAPIContext context)
        {
            _context = context;
        }
        // GET: api/UserRegistrations/5
        [HttpGet]
        [Route("{emailid}/{password}")]
        public async Task<ActionResult<UserRegistration>> UserLogin(string emailid, string password)
        {
            var userRegistration = await _context.UserRegistration.Include("UserRole").Where(item => item.EmailId == emailid && item.Password == password).FirstOrDefaultAsync();

            if (userRegistration == null)
            {
                return NotFound();
            }

            return userRegistration;
        }
    }
}
