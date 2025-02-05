using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Product";
            ViewBag.v3 = "Product List";
            ViewBag.v0 = "Product";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Product");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(data);
                return View(values);
            }
            //Serilaize - Deserialize
            //Serialize -> Object to Json Ekle,Güncelle
            //Deserialize -> Json to Object Listele,Id ye göre getir

            return View();
        }

        [Route("CreateProduct")]
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Product";
            ViewBag.v3 = "Create Product";
            ViewBag.v0 = "Product";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(data);
                List<SelectListItem> categoryValues = (from item in values
                                                       select new SelectListItem
                                                       {
                                                           Text = item.CategoryName,
                                                           Value = item.CategoryId
                                                       }).ToList();
                ViewBag.CategoryList = categoryValues;

            }
            return View();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createProductDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/Product", data);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7070/api/Product?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("EditProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditProduct(string id)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Product";
            ViewBag.v3 = "Edit Product";
            ViewBag.v0 = "Product";

            var clientCategory = _httpClientFactory.CreateClient();
            var responseMessageCategory = await clientCategory.GetAsync("https://localhost:7070/api/Category");
            if (responseMessageCategory.IsSuccessStatusCode)
            {
                var dataCategory = await responseMessageCategory.Content.ReadAsStringAsync();
                var valuesCategory = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(dataCategory);
                List<SelectListItem> categoryValues = (from item in valuesCategory
                                                       select new SelectListItem
                                                       {
                                                           Text = item.CategoryName,
                                                           Value = item.CategoryId
                                                       }).ToList();
                ViewBag.CategoryList = categoryValues;
            }

            var clientProduct = _httpClientFactory.CreateClient();
            var responseMessageProduct = await clientProduct.GetAsync("https://localhost:7070/api/Product/" + id);
            if (responseMessageProduct.IsSuccessStatusCode)
            {
                var dataProduct = await responseMessageProduct.Content.ReadAsStringAsync();
                var valuesProduct = JsonConvert.DeserializeObject<UpdateProductDto>(dataProduct);
                return View(valuesProduct);
            }
            return View();

        }

        [HttpPost]
        [Route("EditProduct/{id}")]
        public async Task<IActionResult> EditProduct(UpdateProductDto updateProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(updateProductDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7070/api/Product", data);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();

        }
        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {   
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Product";
            ViewBag.v3 = "Product List With Category";
            ViewBag.v0 = "Product";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Product/ProductListWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(data);
                return View(values);
            }
            return View();
        }
    }
}
