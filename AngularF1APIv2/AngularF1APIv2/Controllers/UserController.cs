using AngularF1APIv2.Context;
using AngularF1APIv2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AngularF1APIv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly AppDbContext dbContext;
        public UserController(AppDbContext appDbContext)
        {
            dbContext = appDbContext;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {
            if (userObj == null)
            {
                return BadRequest();
            }

            var user = await dbContext.Users.FirstOrDefaultAsync(x=>x.Username == userObj.Username && x.Password == userObj.Password);
            if (user == null)
            {
                return NotFound(new { status = false, Message = "User not Found"});
            }
            if (user.Role == 0)
            {
                return Ok(new
                {
                    status = true,
                    Message = "Logged in!",
                    data = user,
                    admin = false,
                    username = userObj.Username
                });
            }
            return Ok(new
            {
                status = true,
                Message = "Logged in!",
                data = user,
                admin = true,
                username = userObj.Username
            });

        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUpUser([FromBody] User userObj)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Username == userObj.Username); 
            if (userObj == null)
            {
                return BadRequest();
            }else if(user != null)
            {
                return BadRequest(new { Message = "User Already Exists" });
            }


            await dbContext.Users.AddAsync(userObj);

            await dbContext.SaveChangesAsync();
            return Ok(new
            {
                Message = "New User Registered"
            });
        }
    }
}
