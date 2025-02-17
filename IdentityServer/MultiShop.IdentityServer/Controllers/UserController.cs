using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.IdentityServer.Models;
using System.IdentityModel.Tokens.Jwt;
using static Duende.IdentityServer.IdentityServerConstants;

namespace MultiShop.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)] 
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {   
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {   

            var userClaims = User.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub);
            var user = await _userManager.FindByIdAsync(userClaims.Value);
            return Ok(new 
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname
            });
        }

        [HttpGet("GetAllUserList")]
        public async Task<IActionResult> GetAllUserList()
        {
            var users = await _userManager.Users.ToListAsync();
            return Ok(users);
        }
    }
}
