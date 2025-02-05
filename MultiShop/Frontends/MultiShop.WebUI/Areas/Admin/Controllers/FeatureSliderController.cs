using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    [AllowAnonymous]
    public class FeatureSliderController : Controller
    {   
        private IHttpClientFactory _clientFactory;

        public FeatureSliderController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {   
            ViewBag.v1 = "Homepage";
            ViewBag.v2 = "Feature Slider";
            ViewBag.v3 = "Slider List";
            ViewBag.v0 = "List";

            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7070/api/FeatureSlider");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultSliderDto>>(data);
                return View(result);
            }

            return View();
        }

        [Route("CreateFeatureSlider")]
        public IActionResult CreateFeatureSlider()
        {
            ViewBag.v1 = "Homepage";
            ViewBag.v2 = "Feature Slider";
            ViewBag.v3 = "Slider List";
            ViewBag.v4 = "Create";
            return View();
        }

        [HttpPost]
        [Route("CreateFeatureSlider")]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto model)
        {   
            model.Status = false;
            var client = _clientFactory.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7070/api/FeatureSlider", model);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("EditFeatureSlider/{id}")]
        public async Task<IActionResult> EditFeatureSlider(string id)
        {
            ViewBag.v1 = "Homepage";
            ViewBag.v2 = "Feature Slider";
            ViewBag.v3 = "Slider List";
            ViewBag.v4 = "Edit";
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7070/api/FeatureSlider/" + id);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<EditFeatureSliderDto>(data);
                return View(result);
            }
            return View();
        }

        [HttpPost]
        [Route("EditFeatureSlider/{id}")]
        public async Task<IActionResult> EditFeatureSlider(EditFeatureSliderDto model)
        {
            var client = _clientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7070/api/FeatureSlider/", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("DeleteFeatureSlider/{id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7070/api/FeatureSlider/" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
