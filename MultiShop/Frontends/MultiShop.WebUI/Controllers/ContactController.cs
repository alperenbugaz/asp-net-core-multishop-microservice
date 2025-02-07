using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController : Controller
    {   
        private readonly IHttpClientFactory _clientFactory;

        public ContactController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto createContactDto)
        {   
            createContactDto.IsRead = false;
            createContactDto.SendDate = DateTime.Now;
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7070/api/Contact", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }


            return View();
        }
    }
}
