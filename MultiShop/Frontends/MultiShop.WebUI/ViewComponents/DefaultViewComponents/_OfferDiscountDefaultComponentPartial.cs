using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _OfferDiscountDefaultComponentPartial : ViewComponent
    {   
        private readonly IHttpClientFactory _clientFactory;

        public _OfferDiscountDefaultComponentPartial(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {   
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7070/api/OfferDiscount");

            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var offerDiscounts = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(data);
                return View(offerDiscounts);
            }

            return View();
        }
    }
}
