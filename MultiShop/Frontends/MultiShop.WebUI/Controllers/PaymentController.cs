using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        public IActionResult Index()
        {   
            ViewBag.directory1 = "MultiShop";
            ViewBag.directory2 = "Payment";
            ViewBag.directory3 = "Credit Cart";
            return View();
        }
    }
}
