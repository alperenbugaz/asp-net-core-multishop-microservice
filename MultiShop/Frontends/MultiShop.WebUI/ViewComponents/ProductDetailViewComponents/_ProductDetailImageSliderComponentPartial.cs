using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageSliderComponentPartial : ViewComponent
    {   
        private readonly IHttpClientFactory _clientFactory;

        public _ProductDetailImageSliderComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7070/api/ProductImage/ProductImagesByProductId?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<GetByIdProductImageDto>(data);
                return View(products);
            }
            return View();
        }
    }
}
