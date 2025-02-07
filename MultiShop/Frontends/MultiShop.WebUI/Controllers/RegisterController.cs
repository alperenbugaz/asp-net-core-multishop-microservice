using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.RegisterDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        IHttpClientFactory _clientFactory;
        public RegisterController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateRegisterDto createRegisterDto)
        {   
            if (ModelState.IsValid == false)
            {
                return View();
            }

            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createRegisterDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("http://localhost:5001/api/Register", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();

        }
    }
}
