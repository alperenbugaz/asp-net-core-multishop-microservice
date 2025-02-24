using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.CommentServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/Comment")]

    public class CommentController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ICommentService _commentService;
        private readonly IProductService _productService;
        public CommentController(HttpClient httpClient, ICommentService commentService, IProductService productService)
        {
            _httpClient = httpClient;
            _commentService = commentService;
            _productService = productService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Comment";
            ViewBag.v3 = "Comment List";
            ViewBag.v0 = "Comment";
            ViewBag.ProductName = "Product Name";

            // CommentService üzerinden yorumları çek
            var comments = await _commentService.GetAllCommentAsync();

            // Ürünleri çekmek için direkt HttpClient kullanalım
            var products = await _productService.GetAllProductAsync();


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

        //[HttpPost]
        //[Route("CreateComment")]
        //public async Task<IActionResult> CreateComment(CreateCommentDto createCommentDto)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var json = JsonConvert.SerializeObject(createCommentDto);
        //    var data = new StringContent(json, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PostAsync("http://localhost:7075/api/Comment", data);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        //[Route("DeleteComment/{id}")]
        //public async Task<IActionResult> DeleteComment(string id)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.DeleteAsync("http://localhost:7075/api/Comment?id=" + id);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        //[Route("UpdateComment/{id}")]
        //[HttpGet]
        //public async Task<IActionResult> UpdateComment(string id)
        //{
        //    ViewBag.v1 = "Home";
        //    ViewBag.v2 = "Comment";
        //    ViewBag.v3 = "Edit Comment";

        //    var client = _httpClientFactory.CreateClient();
        //    var responseMessage = await client.GetAsync("http://localhost:7075/api/Comment/" + id);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var data = await responseMessage.Content.ReadAsStringAsync();
        //        var values = JsonConvert.DeserializeObject<UpdateCommentDto>(data);
        //        return View(values);
        //    }
        //    return View();
        //}

        //[HttpPost]
        //[Route("UpdateComment/{id}")]
        //public async Task<IActionResult> UpdateComment(UpdateCommentDto udpateCommentDto)
        //{
        //    var client = _httpClientFactory.CreateClient();
        //    var json = JsonConvert.SerializeObject(udpateCommentDto);
        //    var data = new StringContent(json, Encoding.UTF8, "application/json");
        //    var responseMessage = await client.PutAsync("http://localhost:7075/api/Comment", data);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
    }
}
