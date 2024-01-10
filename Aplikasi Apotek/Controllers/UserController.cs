using Aplikasi_Apotek.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            if(_apotekContext.User == null)
            {
                return NotFound();
            }
            return await _apotekContext.User.ToListAsync();
        }

        // Get User Data By Id
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            if( _apotekContext.User == null)
            {
                return NotFound();
            }

            var user = await _apotekContext.User.FindAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            return user;
        }

        // Create New User
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<User>> CreateNewUser(User user)
        {
            _apotekContext.User.Add(user);
            await _apotekContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id_user }, user);
        }

        // Check
        private bool UserAvailable(int id)
        {
            return (_apotekContext.User?.Any(x => x.Id_user == id)).GetValueOrDefault();
        }

        // Edit Existing User
        [Authorize]
        [HttpPut]
        public async Task<ActionResult> EditUser(int id, User user)
        {
            if (id != user.Id_user)
            {
                return BadRequest();
            }
            _apotekContext.Entry(user).State = EntityState.Modified;
            try
            {
                await _apotekContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAvailable(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

        // Delete User
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            if (_apotekContext.User == null)
            {
                return NotFound();
            }
            var user = await _apotekContext.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _apotekContext.User.Remove(user);

            await _apotekContext.SaveChangesAsync();

            return Ok();
        }
    }
}
