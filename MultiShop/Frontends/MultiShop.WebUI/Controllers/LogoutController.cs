using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Controllers
{
    [Route("LogOut")]

    public class LogoutController : Controller
    {   
        private readonly IIdentityService _identityService;
        public LogoutController(IIdentityService identityService)
        {
            _identityService = identityService;
        }


        public async Task<IActionResult> Index()
        {
            await _identityService.Logout();
            return RedirectToAction("Index", "Login");
        }
    }
}
