using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutComponentPartial : ViewComponent
    {
        IHttpClientFactory _clientFactory;
        public _FooterUILayoutComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {   
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7070/api/About");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var about = JsonConvert.DeserializeObject<List<ResultAboutDto>>(content);
                return View(about);
            }

            return View();
        }
    }
}
