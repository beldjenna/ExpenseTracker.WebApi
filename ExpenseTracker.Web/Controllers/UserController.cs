using ExpenseTracker.Core.Models;
using ExpenseTracker.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfileModel>> GetUserById(int id)
        {
            var user = await userService.GetUserByIdAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
           
    }
}
