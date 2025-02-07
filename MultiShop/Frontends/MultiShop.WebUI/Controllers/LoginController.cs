using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        IHttpClientFactory _clientFactory;
        public LoginController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
