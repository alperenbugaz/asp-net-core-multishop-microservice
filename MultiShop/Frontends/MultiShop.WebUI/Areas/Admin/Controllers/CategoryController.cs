using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {   
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Category";
            ViewBag.v3 = "Category List";
            ViewBag.v0 = "Category";

            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);

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
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            return RedirectToAction("Index");
        }

        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);

            return RedirectToAction("Index");
        }

        [Route("EditCategory/{id}")]
        [HttpGet]
        public async Task<IActionResult> EditCategory(string id)
        {
            ViewBag.v1 = "Home";
            ViewBag.v2 = "Category";
            ViewBag.v3 = "Edit Category";

            var value = await _categoryService.GetByIdCategoryAsync(id);


            return View(value);
        }

        [HttpPost]
        [Route("EditCategory/{id}")]
        public async Task<IActionResult> EditCategory(EditCategoryDto editCategoryDto)
        {

            await _categoryService.UpdateCategoryAsync(editCategoryDto);
            return RedirectToAction("Index");
            

        }
    }
}
