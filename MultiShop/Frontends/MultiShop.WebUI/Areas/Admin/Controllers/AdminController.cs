using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {   
        public IActionResult Index()
        {
            return View();
        }
    }
}
