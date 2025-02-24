using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;


        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Product";
            ViewBag.v3 = "Product List";
            ViewBag.v0 = "Product";

            var values = await _productService.GetAllProductAsync();
            return View(values);
        }

        [Route("CreateProduct")]
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Product";
            ViewBag.v3 = "Create Product";
            ViewBag.v0 = "Product";

            var categoryValue = await _categoryService.GetAllCategoryAsync();
            List<SelectListItem> categoryValues = (from item in categoryValue
                                                   select new SelectListItem
                                                       {
                                                           Text = item.CategoryName,
                                                           Value = item.CategoryId
                                                       }).ToList();
            ViewBag.CategoryList = categoryValues;

            return View();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("Index");
        }

        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }

        [Route("EditProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditProduct(string id)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Product";
            ViewBag.v3 = "Edit Product";
            ViewBag.v0 = "Product";

            var categoryValue = await _categoryService.GetAllCategoryAsync();
            List<SelectListItem> categoryValues = (from item in categoryValue
                                                   select new SelectListItem
                                                   {
                                                       Text = item.CategoryName,
                                                       Value = item.CategoryId
                                                   }).ToList();
            ViewBag.CategoryList = categoryValues;

            var productValue = await _productService.GetByIdProductAsync(id);

            return View(productValue);

        }

        [HttpPost]
        [Route("EditProduct/{id}")]
        public async Task<IActionResult> EditProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("Index");

        }
        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {   
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Product";
            ViewBag.v3 = "Product List With Category";
            ViewBag.v0 = "Product";

            var values = await _productService.GetProductWithCategoryAsync();

            return View(values);
        }
    }
}
