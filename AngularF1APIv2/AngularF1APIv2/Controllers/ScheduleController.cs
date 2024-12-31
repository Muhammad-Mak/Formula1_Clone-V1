using AngularF1APIv2.Context;
using AngularF1APIv2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AngularF1APIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ScheduleController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Schedule>>> GetSchedules()
        {
            return await _context.Schedules.ToListAsync();
        }
        [HttpPut("{location}")]
        public async Task<IActionResult> UpdateRace(string location, [FromBody] Schedule scheduleUpdate)
        {
            var schedule = await _context.Schedules.FirstOrDefaultAsync(r => r.Location == location);
            if (schedule == null)
            {
                return NotFound();
            }

            schedule.RaceDate = scheduleUpdate.RaceDate;

            _context.Schedules.Update(schedule);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Schedule Updated"
            });
        }

        [HttpDelete("{location}")]
        public async Task<IActionResult> DeleteSchedule(string location)
        {
            var schedule = await _context.Schedules.FirstOrDefaultAsync(r => r.Location == location);
            if (schedule == null)
            {
                return NotFound();
            }

            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Race deleted from schedule"
            });
        }
    }
}
