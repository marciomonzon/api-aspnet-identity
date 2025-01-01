using IdentityApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;

        public UserController(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet("get-user-logged")]
        public IActionResult GetUserLogged()
        {
            var userIdentity = User.Identity!.Name;

            return Ok(userIdentity);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] object empty)
        {
            await _signInManager.SignOutAsync();

            return Ok();
        }
    }
}
