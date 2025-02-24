using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        [Route("Error/PageNotFound")]
        public IActionResult PageNotFound()
        {
            return View("PageNotFound");
        }
    }
}
