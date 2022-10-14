using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment_1.Models;

namespace Assignment_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class locationController : ControllerBase
    {
        private readonly assignment1Context _context;

        public locationController(assignment1Context context)
        {
            _context = context;
        }

        [HttpGet("stateList")]
        public async Task<ActionResult<List<State>>> GetState()
        {
            return await _context.States.ToListAsync();
        }

        [HttpGet("countryList")]
        public async Task<ActionResult<List<Country>>> GetCountry()
        {
            return await _context.Countries.ToListAsync();
        }

        [HttpPost("saveState")]
        public async Task<ActionResult<State>> SaveState(State statedata)
        {
            try
            {
                _context.States.Add(statedata);
                await _context.SaveChangesAsync();
                return Ok(statedata);
            }
            catch (DbUpdateException)
            {
                if (userExist(statedata.StateName))
                {
                    return Conflict();    
                }
            }
            return CreatedAtAction("GetState", new { stateName = statedata.StateName }, statedata);

        }
        private bool userExist(string username)
        {
            return (_context.UserManagements?.Any(e => e.Username == username)).GetValueOrDefault();
        }
    }
}
