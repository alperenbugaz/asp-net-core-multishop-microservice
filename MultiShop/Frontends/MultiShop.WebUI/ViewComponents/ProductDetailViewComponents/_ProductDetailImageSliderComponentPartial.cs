using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageSliderComponentPartial : ViewComponent
    {   
        private readonly IProductImageService _productImageService;


        public _ProductDetailImageSliderComponentPartial(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            //var client = _clientFactory.CreateClient();
            //var response = await client.GetAsync("https://localhost:7070/api/ProductImage/ProductImagesByProductId?id=" + id);
            //if (response.IsSuccessStatusCode)
            //{
            //    var data = await response.Content.ReadAsStringAsync();
            //    var products = JsonConvert.DeserializeObject<GetByIdProductImageDto>(data);
            //    return View(products);
            //}
            //return View();

            var productImages = await _productImageService.GetByProductIdProductImageAsync(id);
            return View(productImages);
        }
    }
}
