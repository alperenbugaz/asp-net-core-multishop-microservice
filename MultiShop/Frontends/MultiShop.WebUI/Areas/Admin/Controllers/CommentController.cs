using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Comment")]

    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public CommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Comment";
            ViewBag.v3 = "Comment List";
            ViewBag.v0 = "Comment";
            ViewBag.ProductName = "Product Name";

            var client = _httpClientFactory.CreateClient();

            // Yorumları çek
            var responseMessage = await client.GetAsync("https://localhost:7194/api/Comment");
            if (!responseMessage.IsSuccessStatusCode)
            {
                return View();
            }
            var data = await responseMessage.Content.ReadAsStringAsync();
            var comments = JsonConvert.DeserializeObject<List<ResultCommentDto>>(data);

            // Ürünleri çek
            var productResponse = await client.GetAsync("https://localhost:7070/api/Product");
            if (!productResponse.IsSuccessStatusCode)
            {
                return View(comments);
            }
            var productData = await productResponse.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultProductDto>>(productData);

            // Yorumlara uygun ürün isimlerini eşle
            foreach (var comment in comments)
            {
                var matchedProduct = products.FirstOrDefault(p => p.ProductId == comment.ProductId);
                if (matchedProduct != null)
                {
                    comment.ProductName = matchedProduct.ProductName;
                }
            }

            return View(comments);
        }

        [Route("CreateComment")]
        [HttpGet]
        public async Task<IActionResult> CreateComment()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Comment";
            ViewBag.v3 = "Create Comment";
            ViewBag.v0 = "Comment";
            return View();
        }

        [HttpPost]
        [Route("CreateComment")]
        public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(createCommentDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7194/api/Comment", data);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("DeleteComment/{id}")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7194/api/Comment?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Route("UpdateComment/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateComment(string id)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Comment";
            ViewBag.v3 = "Edit Comment";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7194/api/Comment/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCommentDto>(data);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateComment/{id}")]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto udpateCommentDto)
        {
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(udpateCommentDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7194/api/Comment", data);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
