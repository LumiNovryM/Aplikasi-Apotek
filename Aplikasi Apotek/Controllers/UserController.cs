using Aplikasi_Apotek.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aplikasi_Apotek.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApotekContext _apotekContext;

        public UserController(ApotekContext apotekContext)
        {
            _apotekContext = apotekContext;
        }

        // Get All User Data
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            if(_apotekContext.User == null)
            {
                return NotFound();
            }
            return await _apotekContext.User.ToListAsync();
        }
    }
}
