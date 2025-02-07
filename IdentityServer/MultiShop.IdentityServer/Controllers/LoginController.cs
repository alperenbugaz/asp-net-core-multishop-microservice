using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;

namespace MultiShop.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        public LoginController(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
        {   

            var result = await _signInManager.PasswordSignInAsync(userLoginDto.UserName, userLoginDto.Password, false, false);
            if (result.Succeeded)
            {
                return Ok("Login successful");
            }

            else
            {
                return BadRequest("Username or password is invalid");
            }
        }
    }
}
