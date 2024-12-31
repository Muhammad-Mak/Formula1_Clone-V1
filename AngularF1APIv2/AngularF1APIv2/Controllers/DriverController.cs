using AngularF1APIv2.Context;
using AngularF1APIv2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularF1APIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DriverController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Driver>>> GetDrivers()
        {
            var drivers = await _context.Drivers
           .Join(_context.Teams,
                 driver => driver.TeamID,
                 team => team.TeamID,
                 (driver, team) => new Driver
                 {
                     DriverID = driver.DriverID,
                     DriverNumber = driver.DriverNumber,
                     DriverName = driver.DriverName,
                     DriverPoints = driver.DriverPoints,
                     DriverPosition = driver.DriverPosition,
                     DriverDetails = driver.DriverDetails,
                     Driver_Image = driver.Driver_Image,
                     TeamID = team.TeamID,
                     TeamName = team.TeamName

                 }).ToListAsync();

            return Ok(drivers);
        }

        [HttpPut("{number}")]
        public async Task<IActionResult> UpdateDriver(int number, [FromBody] Driver driverUpdate)
        {
            var driver = await _context.Drivers.FindAsync(number);
            if(driver ==  null)
            {
                return NotFound();
            }

            driver.DriverPoints = driverUpdate.DriverPoints;
            driver.DriverPosition = driverUpdate.DriverPosition;

            _context.Drivers.Update(driver);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                message = "Driver Updated!"
            });
        }
    }
}
