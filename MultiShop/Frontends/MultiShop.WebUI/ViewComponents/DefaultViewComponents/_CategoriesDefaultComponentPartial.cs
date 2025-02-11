using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CategoriesDefaultComponentPartial : ViewComponent
    {   

        private readonly ICategoryService _categoriesService;

        public _CategoriesDefaultComponentPartial(ICategoryService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoriesService.GetAllCategoryAsync();
            return View(categories);
        }
    }
}
