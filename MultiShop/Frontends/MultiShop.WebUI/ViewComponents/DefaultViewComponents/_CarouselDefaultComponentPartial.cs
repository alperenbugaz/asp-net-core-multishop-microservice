using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    [AllowAnonymous]
    public class _CarouselDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _clientFactory;
        public _CarouselDefaultComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
           var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7070/api/FeatureSlider");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<List<ResultSliderDto>>(data);
                return View(model);
            }
            return View();

        }
    }
}
