using AngularF1APIv2.Context;
using AngularF1APIv2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularF1APIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;

        public TeamController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Team>>> GetTeams()
        {
            return await _context.Teams.ToListAsync();
        }

        [HttpPut("{name}")]
        public async Task<IActionResult> UpdateTeam(string name, [FromBody] Team teamUpdate)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(t => t.TeamName == name);
            if (team == null)
            {
                return NotFound();
            }

            team.TeamPoints = teamUpdate.TeamPoints;
            team.TeamPosition = teamUpdate.TeamPosition;

            _context.Teams.Update(team);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Team Updated!"
            });
        }
    }
}

