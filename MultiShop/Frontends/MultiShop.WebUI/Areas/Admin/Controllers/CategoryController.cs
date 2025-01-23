using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Category")]

    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {   
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Category";
            ViewBag.v3 = "Category List";
            ViewBag.v0 = "Category";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(data);
                return View(values);
            }
            //Serilaize - Deserialize
            //Serialize -> Object to Json Ekle,Güncelle
            //Deserialize -> Json to Object Listele,Id ye göre getir

            return View();
        }

        [Route("CreateCategory")]
        [HttpGet]
        public async Task<IActionResult> CreateCategory()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Category";
            ViewBag.v3 = "Create Category";
            ViewBag.v0 = "Category";
            return View();
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createCategoryDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/Category", data);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7070/api/Category?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("EditCategory/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditCategory(string id)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Category";
            ViewBag.v3 = "Edit Category";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Category/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<EditCategoryDto>(data);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("EditCategory/{id}")]
        public async Task<IActionResult> EditCategory(EditCategoryDto editCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(editCategoryDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7070/api/Category", data);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
