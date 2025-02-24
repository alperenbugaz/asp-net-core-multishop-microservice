using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {   
        private readonly IHttpClientFactory _clientFactory;
        private readonly IProductService _productService;
        public ProductListController(IHttpClientFactory clientFactory, IProductService productService)
        {
            _clientFactory = clientFactory;
            _productService = productService;
        }

        public IActionResult Index(string id)
        {
            ViewBag.vbCategoryId = id;

            return View();
        }

        public IActionResult ProductDetail(string id)
        {
            ViewBag.vbProductId = id;

            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {   
            createCommentDto.ImageUrl = "test";
            createCommentDto.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            createCommentDto.Rating = 2;
            createCommentDto.Status = false;
            createCommentDto.ProductId = "1";
            var client = _clientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCommentDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7194/api/Comment", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index" ,"Default");
            }
            return View();
        }

        public async Task<IActionResult> SearchProduct(string query)
        {

            var values = await _productService.GetProductWithQueryParam(query);

            return View(values);
        }

    }
}
