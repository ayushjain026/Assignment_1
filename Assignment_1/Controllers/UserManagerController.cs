using Assignment_1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagerController : ControllerBase
    {
        private readonly assignment1Context _context;

        public UserManagerController(assignment1Context context)
        {
            _context = context;
        }

        // GET: api/UserManager
        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<UserManagement>>> GetUsers()
        {
            if (_context.UserManagements == null)
            {
                return NotFound();
            }
            return await _context.UserManagements.ToListAsync();
        }

        // GET: api/UserManager/abcd
        [HttpGet("{username}")]
        public async Task<ActionResult<UserManagement>> GetTodotask(string username)
        {
            if (_context.UserManagements == null)
            {
                return NotFound();
            }
            var userData = await _context.UserManagements.FindAsync(username);

            if (userData == null)
            {
                return NotFound();
            }
            return userData;
        }

        // POST: api/UserManager
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserManagement>> PostTodotask(UserManagement userDate)
        {
            if (_context.UserManagements == null)
            {
                return Problem("Entity set 'remember_meContext.Todotasks'  is null.");
            }
            _context.UserManagements.Add(userDate);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (userExist(userDate.Username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetTodotask", new { username = userDate.Username }, userDate);
        }
        private bool userExist(string username)
        {
            //return (_context.UserManagements?.Any(e => e.Username == username).GetValueOrDefault();
            //return (_context.UserManagements?.Any(e => e.Id == id)).GetValueOrDefault();
            return (_context.UserManagements?.Any(e => e.Username == username)).GetValueOrDefault();
        }

        // PUT: api/UserManager/username
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{username}")]
        public async Task<IActionResult> PutUser(string username, UserManagement userDate)
        {
            if (username != userDate.Username)
            {
                return BadRequest();
            }

            _context.Entry(userDate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!userExist(username))
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

        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteUser(string username)
        {
            var user = _context.UserManagements.FirstOrDefault(e => e.Username == username);
            if (user == null)
            {
                return NotFound();
            }
            _context.UserManagements.Remove(user);
            await _context.SaveChangesAsync();

            return Ok("User Information updated sucessfully");

        }


    }
}
