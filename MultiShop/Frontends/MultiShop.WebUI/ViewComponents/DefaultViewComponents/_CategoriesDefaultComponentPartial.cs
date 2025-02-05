using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CategoriesDefaultComponentPartial : ViewComponent
    {   

        private readonly IHttpClientFactory _httpClientService;

        public _CategoriesDefaultComponentPartial(IHttpClientFactory httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientService.CreateClient();
            var response = await client.GetAsync("https://localhost:7070/api/Category");
            if (response.IsSuccessStatusCode)
            {
                var categories = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categories);
                return View(values);
            }
            return View();
        }
    }
}
